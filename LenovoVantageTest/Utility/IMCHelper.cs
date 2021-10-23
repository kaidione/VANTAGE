using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.ServiceProcess;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Automation;
using SystemInterfaceWraper;

namespace LenovoVantageTest
{
    public class IMCHelper
    {

        string iMCProgramFiles = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), "Lenovo\\ImController");

        List<string> iMCConfigs = new List<string>() { "Lenovo.Modern.ImController.exe.config", "Lenovo.Modern.ImController.PluginHost.CompanionApp.exe.config", "Lenovo.Modern.ImController.PluginHost.Device.exe.config", "Lenovo.Modern.ImController.PluginHost.exe.config", "Lenovo.Modern.ImController.PluginHost.SettingsApp.exe.config" };
        public List<string> iMCDriverID = new List<string>() { "root\\iMDriverV2", "Root\\iMDriverV2", "root\\iMDriver", "Root\\iMDriver" };
        List<string> iMCDriverFileNames = new List<string>() { "iMDriver.dll", "iMDriverV2.dll" };
        List<string> iMCFolders = null;
        List<string> iMCServices = new List<string>() { "ImControllerService" };
        ProcessStartInfo info = new ProcessStartInfo();
        Process proc = new Process();
        PowerShell ps = PowerShell.Create();
        IMCHelper()
        {

            iMCFolders = new List<string>() { iMCProgramFiles, Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), "Lenovo\\ImController"), Constants.iMCProgramData, Constants.imcLogPath };
            proc.StartInfo = info;
        }
        static IMCHelper _singleton;
        public static IMCHelper Singleton
        {
            get
            {
                if (_singleton == null)
                {
                    _singleton = new IMCHelper();
                }
                return _singleton;
            }
        }
        //IMC 可能会启动一些PluginHost, stop service并不会让它们退出。
        public void KillAllImcProcess()
        {
            foreach (Process item in Process.GetProcesses())
            {
                if (item.ProcessName.ToLower().StartsWith("lenovo.modern.imcontroller"))
                {
                    try
                    {
                        item.Kill();
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteLog("Fail to Kill Process " + item.ProcessName + " . This process must fail IMC installation. reason " + ex.Message, LogType.Warning);
                    }
                }
            }
        }

        public void RemoveDriverPackage()
        {
            List<string> removeList = new List<string>();
            foreach (var item in Directory.GetFiles(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "INF"), "oem*.inf"))
            {
                using (FileStream fs = new FileStream(item, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (sr.ReadToEnd().Contains("iMDriver"))
                    {
                        removeList.Add(item);
                    }
                }
            }
            string devcon = Environment.Is64BitOperatingSystem ? "devcon_64.exe" : "devcon_32.exe";
            proc.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\" + devcon);
            foreach (var item in removeList)
            {
                info.Arguments = " dp_delete " + item.Substring(item.LastIndexOf('\\') + 1);
                proc.Start();
                proc.WaitForExit();
            }
        }
        public void UninstallIMC()
        {
            //Remove present iMCDriver
            StopIMCService(); //Ensure No Service is going
            KillAllImcProcess();//Some plugins may run at background via Lenovo.Modern.PluginHost.exe,which end up locking files
            info.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Environment.Is64BitOperatingSystem ? @"Data\Tools\devcon_64.exe" : @"Data\Tools\devcon_32.exe");
            foreach (string item in iMCDriverID)
            {
                info.Arguments = "remove " + item;
                try
                {
                    proc.Start();
                    proc.WaitForExit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Top Exception Handler:" + ex.Message);
                }

            }
            //Some folder/files are created when iMC is installed . Wiht procmon.exe ,we can know what files/regs are created/added 
            //C:\Windows\System32\DriverStore\FileRepository\imdriver.inf_amd64_e700cdad939dc875 ,here the suffix may vary !!!  
            //without System privilege , No file can be deleted       
            foreach (var item in iMCDriverFileNames)
            {
                info.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\psexec.exe");

                string driverPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), @"drivers\UMDF");
                info.Arguments = string.Format("-accepteula -i -s -d cmd /c del {0}", Path.Combine(driverPath, item));
                proc.Start();
                proc.WaitForExit();
            }
            RemoveEntryInProgramFeature();
            RemoveDriverPackage();
            //ignore DriverStore\FileRepository\imdriverxxx
            //Clean entry in service. In PowerShell sc === Set-Content      
            DeleteIMCService();
        }
        public bool IMCServiceIsRunning()
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(10))
            {
                foreach (string item in iMCServices)
                {
                    IEnumerable<ServiceController> all = ServiceController.GetServices().Where(x =>
                    {
                        if (x.ServiceName.ToLower() == item.ToLower())
                        {
                            if (x.Status.ToString().ToLower() == "running" || x.Status.ToString().ToLower() == "startpending")
                            {
                                return true;
                            }
                            else
                            {
                                Logger.Instance.WriteLog(item + " status =" + x.Status, LogType.Warning);
                            }
                        }
                        return false;
                    });
                    if (all.Count() == 0)
                    {
                        continue;
                    }
                    return true;
                }
            }
            Logger.Instance.WriteLog("IMC service is not running in 10 seconds", LogType.Warning);
            return false;
        }
        public string IMCServiceStatus()
        {
            foreach (string item in iMCServices)
            {
                IEnumerable<ServiceController> all = ServiceController.GetServices().Where(x =>
                {
                    if (x.ServiceName.ToLower() == item.ToLower())
                    {
                        return true;
                    }
                    return false;
                });
                if (all.Count() == 0)
                {
                    continue;
                }
                else
                {
                    return all.ElementAt(0).Status.ToString();
                }

            }
            return "NO Service existing!!";
        }
        bool OperateIMCService(int operation = 0)
        {
            string operationName = "";
            switch (operation)
            {
                case 0:
                    operationName = "stop";
                    break;
                case 1:
                    operationName = "start";
                    break;
                case 2:
                    operationName = "delete";
                    break;
                default:
                    throw new NotImplementedException();
            }
            //确认servcie确实与预期一致
            foreach (string item in iMCServices)
            {
                IEnumerable<ServiceController> all = ServiceController.GetServices().Where(x =>
                {
                    return x.ServiceName.ToLower() == item.ToLower();
                });
                if (all.Count() == 0)
                {
                    continue;
                }
                info.FileName = "sc";
                info.Arguments = operationName + " " + item;
                proc.StartInfo = info;
                proc.Start();
                proc.WaitForExit();
                switch (operation)
                {
                    case 0://stop
                        try
                        {
                            all.ElementAt(0).WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(0, 0, 30));
                            Logger.Instance.WriteLog(string.Format("{0} is stopped at {1}", item, DateTime.Now.ToString(Constants.DATETIMEFORMAT)), LogType.Warning);
                            return true;
                        }
                        catch (System.ServiceProcess.TimeoutException)
                        {
                            Logger.Instance.WriteLog(string.Format("{0} stopping failed in 30 seconds", item), LogType.Warning);

                        }
                        break;
                    case 1://start
                        try
                        {
                            all.ElementAt(0).WaitForStatus(ServiceControllerStatus.Running, new TimeSpan(0, 0, 30));
                            Logger.Instance.WriteLog(string.Format("{0} is started at {1}", item, DateTime.Now.ToString(Constants.DATETIMEFORMAT)), LogType.Warning);
                            return true;
                        }
                        catch (System.ServiceProcess.TimeoutException)
                        {
                            Logger.Instance.WriteLog(string.Format("{0} starting failed in 30 seconds", item), LogType.Warning);

                        }
                        break;
                    case 2:
                        operationName = "delete";
                        all = ServiceController.GetServices().Where(x =>
                        {
                            return x.ServiceName.ToLower() == item.ToLower();
                        });
                        if (all.Count() == 0)
                        {
                            return true;
                        }
                        Logger.Instance.WriteLog(item + " delete failed", LogType.Warning);
                        break;
                }
            }
            return false;
        }
        public bool StopIMCService()
        {
            return OperateIMCService(0);
        }
        public bool startIMService()
        {
            if (!OperateIMCService(1))
            {
                return false;
            }
            return true;
        }
        public bool RestartIMCService()
        {
            if (!OperateIMCService(0))
            {
                return false;
            }
            //太快从Start-Stop-Start转换，可能会Start fail.给点时间间隔
            System.Threading.Thread.Sleep(5000);
            if (!OperateIMCService(1))
            {
                return false;
            }
            return true;
        }
        public void DeleteIMCService()
        {
            OperateIMCService(2);
        }
        //http://www.cnblogs.com/h46incon/archive/2011/05/26/2059185.html
        //
        //Uninstall iMC and Companion in this test
        //Remove registry items about IMC , policies , files , service
        //Install Specified IMC
        //Cases about install elder IMC should be placed at the end of tests
        public void ClearIMCAndTangram(bool cleanCompanion = false)
        {

            if (cleanCompanion)
            {
                IMCHelper.Singleton.UninstallTangram();

            }

            UninstallIMC();

            //Clean folders at ProgramFiles ProgramData

            foreach (string item in iMCFolders)
            {
                if (Directory.Exists(item))
                {
                    DeleteFolder(item);
                }
            }

            //It may require trusted right to delete files here, ignore. C:\Windows\System32\DriverStore\Temp\{7b766160-0b61-7044-afc0-0f2710786437}\x64\ImController\SET3985.tmp            
            //There could be important folder for other APPS, don't clean c:\users...\Temp

            return;
        }
        public void DeletePossibleFiles(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }
            try
            {
                IEnumerable<string> ienumFiles = Directory.EnumerateFiles(folder);
                foreach (string item in ienumFiles)
                {
                    try
                    {
                        File.Delete(item);
                    }
                    catch (Exception ex)
                    {
                        Logger.Instance.WriteLog(ex.Message, LogType.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, LogType.Warning);
            }

            try
            {
                IEnumerable<string> ienumFolders = Directory.EnumerateDirectories(folder);
                foreach (string item in ienumFolders)
                {
                    DeletePossibleFiles(item);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, LogType.Warning);
            }


        }

        public void DeleteFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                return;
            }
            try
            {
                Directory.Delete(folder, true);
            }
            catch
            {
                Logger.Instance.WriteLog("Can not delete folder " + folder, LogType.Warning);
            }
        }
        bool SecurityFilesReady()
        {
            int files = 5;
            foreach (string item in Directory.EnumerateFiles(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\iMCSecurity")))
            {
                foreach (string config in iMCConfigs)
                {
                    if (item.Contains(config))
                    {
                        files--;
                    }
                }


            }
            //Files are not complete
            if (files > 0)
            {
                return false;
            }
            return true;
        }
        bool DismissIMCPopup()
        {
            Condition[] popup = new Condition[] { new PropertyCondition(AutomationElement.NameProperty, "Setup"), new PropertyCondition(AutomationElement.ClassNameProperty, "#32770") };
            AutomationElement root = AutomationElement.RootElement.FindFirst(TreeScope.Children, new AndCondition(popup));
            if (root == null)
            {
                return false;
            }
            AutomationElement text = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "You are attempting to install the same version that is on this system."));
            if (text == null)
            {
                return false;
            }
            AutomationElement button = root.FindFirst(TreeScope.Descendants, new PropertyCondition(AutomationElement.NameProperty, "OK"));
            if (button == null)
            {
                return false;
            }
            object invoke = null;
            button.TryGetCurrentPattern(InvokePattern.Pattern, out invoke);
            if (invoke == null)
            {
                return false;
            }
            try
            {
                ((InvokePattern)invoke).Invoke();
            }
            catch (Exception)
            {
                Logger.Instance.WriteLog("Click Setup failed");
            }
            return true;
        }
        bool DismissIMCPopupInTimeoutSeconds(int timeoutSeconds)
        {
            DateTime now = DateTime.Now;
            while (DateTime.Now < now.AddSeconds(timeoutSeconds))
            {
                if (DismissIMCPopup())
                {
                    return true;
                }
            }
            return false;
        }

        public static string GetInstallPathByServerIP(string moduleName, ServerType serType)
        {
            String path = "";
            if (moduleName.Equals("ImController") ||
               moduleName.Equals("Plugins") ||
               moduleName.Equals("Tangram"))
            {

                if (serType.Equals(ServerType.Testing))
                {
                    path = "Data\\" + moduleName + "\\LatestTesting";
                }
                else if (serType.Equals(ServerType.Staging))
                {
                    path = "Data\\" + moduleName + "\\LatestStaging";
                }
                else if (serType.Equals(ServerType.Production))
                {
                    path = "Data\\" + moduleName + "Tangram\\latest";
                }
            }
            return path;

        }
        public bool InstallIMC(string packagePath)
        {
            Timer timer = new Timer();
            timer.Interval = 10 * 1000;  //check every 10s
            timer.Elapsed += HandleImcontrollerInstallationException;
            timer.Enabled = true;
            timer.AutoReset = true;
            timer.Start();
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, packagePath)))
            {
                Logger.Instance.WriteLog("NO Installation package " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, packagePath), LogType.Error);
                return false;
            }
            if (packagePath.ToLower().Contains("latest") || packagePath.ToLower().Contains("latesttesting"))
            {
                packagePath = GetInstallPathByServerIP("ImController", Constants.TargetServer) + "\\SystemInterfaceFoundation.exe";
            }
            Logger.Instance.WriteLog(" Installation path " + packagePath);

            info.FileName = packagePath;
            if (packagePath.ToLower().Contains(".exe"))
            {
                info.Arguments = "/silent /norestart";
            }
            else if (packagePath.ToLower().Contains(".msi"))
            {
                info.Arguments = "/quiet /passive /norestart";
            }
            else
            {
                throw new FormatException("Unkown iMC package");
            }
            Task.Factory.StartNew(() =>
            {
                DismissIMCPopupInTimeoutSeconds(30);
            });
            proc.Start();
            proc.WaitForExit();
            Logger.Instance.WriteLog("IMC Installation completed");
            timer.Stop();
            timer.Dispose();
            return true;
        }

        // <summary>
        // 在已安装IMController的系统上再次安装相同版本时，会有MessageBox提示，导致测试暂停，此方法处理这个MessageBox，让测试继续
        // </summary>
        private void HandleImcontrollerInstallationException(object sender, ElapsedEventArgs e)
        {
            /*
            try
            {
                UIAutomationControl control = new UIAutomationControl();
                var button = control.FindButtonPlus("Setup", null, "OK", 2);
                if (button != null)
                {
                    Logger.Instance.WriteLog("'OK' button in IMC Setup is found. Will click it.",LogType.Information);
                    button.Invoke();
                    Logger.Instance.WriteLog("Clicked!", LogType.Information);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog(ex.Message, LogType.Error);
            }
            */
        }
        public void UninstallTangram(string appx_partialName = "LenovoCompanion")
        {
            //Remove Companion
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            pipe.Commands.AddScript("Get-AppxPackage |?{$_.Name -like '*" + appx_partialName + "*'}|Remove-AppxPackage");
            pipe.Invoke();
            runspace.Close();

        }
        //Disable signature checking about Subscription & PluginHost file
        public bool DisableSubSecurity()
        {
            if (!SecurityFilesReady())
            {
                return false;
            }
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\iMCSecurity");
            foreach (string item in iMCConfigs)
            {
                if (item.ToLower().Contains(".pluginhost."))
                {
                    File.Copy(Path.Combine(path, item), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Lenovo\ImController\PluginHost\" + item), true);
                    if (Environment.Is64BitOperatingSystem)
                    {
                        File.Copy(Path.Combine(path, item), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86), @"Lenovo\ImController\PluginHost\" + item), true);
                    }
                }
                else
                {
                    File.Copy(Path.Combine(path, item), Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles), @"Lenovo\ImController\Service\" + item), true);
                }
            }
            return true;
        }
        //File version with iMcontroller
        public string IMCExeVer()
        {
            string serviceFile = Constants.IMCONTROLLER_SERVICE_BASE + @"\Lenovo.Modern.ImController.exe";
            string powerShellScript = string.Format("[System.Diagnostics.FileVersionInfo]::GetVersionInfo(\"{0}\")", serviceFile);
            ps.AddScript(powerShellScript);

            foreach (PSObject psobj in ps.Invoke())
            {
                return string.Format("{0}.{1}.{2}.{3}", psobj.Properties["FileMajorPart"].Value, psobj.Properties["FileMinorPart"].Value, psobj.Properties["FileBuildPart"].Value, psobj.Properties["FilePrivatePart"].Value);

            }
            return string.Empty;
        }
        //Driver version shown on Device Manager
        //zhou fang与我都遇到了一代方法获取的Win32_PnPSignedDriver不及时的问题(1. iMC uninstall后还能获得Device Driver，2.升级iMC后Driver Version始终不更新。除非重启或等很久12小时？？)
        //即使使用了MI(2代WMI)，信息依然不能及时更新（不知道更新机制）
        //一个driver file(PE文件)可能被多个签名。没查到直接的C#方法，只能混用API与C#方法。
        public Tuple<string, string, string, List<string>> IMCDriverInfo()
        {
            DriverInfoAgentWrapper driverInfoAgent = new DriverInfoAgentWrapper();
            DriverInfoWrap driverInfo = new DriverInfoWrap();
            string driverFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers\\UMDF\\iMDriver.dll");
            foreach (string id in iMCDriverID)
            {
                driverInfo.hardwareId = id;
                int res = driverInfoAgent.GetDriverInfoTableByHwidWrapper(ref driverInfo);
                if (res == 0)
                {
                    string err = "";
                    return new Tuple<string, string, string, List<string>>("", "", driverInfo.driverVersion, Crypt32.RetrieveSignersInPEFile(driverFile, ref err));

                }
            }
            /*
            string computer = "localhost";
            // Create CIM session
            CimSession Session = CimSession.Create(computer);
            // Query , returns CimInstances
            var imcDriver = Session.QueryInstances(@"root\cimv2", "WQL", "SELECT * FROM Win32_PnPSignedDriver where hardwareid like'%iMDriver%'");

            foreach (CimInstance driver in imcDriver)
            {

                Console.WriteLine(driver.CimInstanceProperties["DeviceID"].ToString());
                if (driver.CimInstanceProperties["DeviceName"] == null || driver.CimInstanceProperties["Manufacturer"] == null || driver.CimInstanceProperties["DriverVersion"] == null || driver.CimInstanceProperties["Signer"] == null)
                {
                    Logger.Instance.WriteLog(Logger.Instance.WriteLogSeverity.Error, "Win32_PnPSignedDriver may not be synchronized with Device Manager ,need restart??");
                    break;//WMI可能还未更新完
                }
                Session.Close();
                return new Tuple<string, string, string, string>(driver.CimInstanceProperties["DeviceName"].Value.ToString(), driver.CimInstanceProperties["Manufacturer"].Value.ToString(), driver.CimInstanceProperties["DriverVersion"].Value.ToString(), driver.CimInstanceProperties["Signer"].Value.ToString());
            }
            Session.Close();
            */
            return new Tuple<string, string, string, List<string>>(string.Empty, string.Empty, string.Empty, new List<string>());

        }
        //SystemRight may be like a number ,instead of enum value , refer to below links
        //https://social.technet.microsoft.com/Forums/windows/en-US/cb822c55-9f96-48e6-9c60-ca64ed13ef94/what-is-the-diference-between-acl-access-rule-268435456-and-fullcontrol?forum=winserverpowershell
        //https://msdn.microsoft.com/en-us/library/aa374896(v=vs.85).aspx
        //https://stackoverflow.com/questions/9694834/encountering-a-filesystemrights-value-that-isnt-defined-in-enumeration
        void FolderPermissionRecursive(string folderName, ref string notMatchedFolderName)
        {
            try
            {
                //如果有个临时文件夹生成，这时不在了
                foreach (string subFolder in Directory.EnumerateDirectories(folderName))
                {
                    FolderPermissionRecursive(subFolder, ref notMatchedFolderName);
                }
            }
            catch
            {
                return;
            }
            DirectoryInfo info = new DirectoryInfo(folderName);
            System.Security.AccessControl.DirectorySecurity ds = info.GetAccessControl();
            //User must has Read & Execute access
            //Administrator & System must have Full access
            bool systemAccess = false, administratorAccess = false, usersAccess = false;
            foreach (System.Security.AccessControl.FileSystemAccessRule item in ds.GetAccessRules(true, true, typeof(System.Security.Principal.NTAccount)))
            {
                if (item.IdentityReference.Value == "NT AUTHORITY\\SYSTEM")
                {

                    if (item.AccessControlType == System.Security.AccessControl.AccessControlType.Allow && item.FileSystemRights == System.Security.AccessControl.FileSystemRights.FullControl)
                    {
                        systemAccess = true;
                    }
                }
                if (item.IdentityReference.Value == "BUILTIN\\Administrators")
                {

                    if (item.AccessControlType == System.Security.AccessControl.AccessControlType.Allow && item.FileSystemRights == System.Security.AccessControl.FileSystemRights.FullControl)
                    {
                        administratorAccess = true;
                    }
                }
                //from Monica , once ReadAndExecute access exists , Test pass
                if (item.IdentityReference.Value == "BUILTIN\\Users")
                {
                    if (item.AccessControlType == System.Security.AccessControl.AccessControlType.Allow && item.FileSystemRights == (System.Security.AccessControl.FileSystemRights.ReadAndExecute | System.Security.AccessControl.FileSystemRights.Synchronize))
                    {
                        usersAccess = true;
                    }
                }
            }
            if (!systemAccess)
            {
                notMatchedFolderName = string.Format("System hashas no full control on {0}", folderName);
            }
            if (!administratorAccess)
            {
                notMatchedFolderName = notMatchedFolderName + string.Format(" ,Administrator hashas no full control on {0}", folderName);
            }
            if (!usersAccess)
            {
                notMatchedFolderName = notMatchedFolderName + string.Format(" ,Users hashas no Read & Execute control on {0}", folderName);
            }
        }
        //Accessible : Administrators =FULL , Users = FUll , User = Read,Execute, 
        public void ImcFolderPermission(ref string notMatchedFolder)
        {
            FolderPermissionRecursive(Constants.iMCProgramData, ref notMatchedFolder);
        }

        RegistryKey IMCInRegistry(RegistryKey uninstall)
        {
            Regex reg = new Regex("System.* Interface.* Foundation.*");
            foreach (string item in uninstall.GetSubKeyNames())
            {
                RegistryKey key = uninstall.OpenSubKey(item, false);
                if (key.GetValue("DisplayName") != null && reg.IsMatch(key.GetValue("DisplayName").ToString()))
                {

                    return key;
                }
            }
            return null;
        }
        public RegistryKey EntryInProgramFeature()
        {
            RegistryKey uninstall32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
            RegistryKey result = IMCInRegistry(uninstall32);

            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey uninstall64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall");
                result = IMCInRegistry(uninstall64);
            }
            return result;
        }
        void RemoveEntryInProgramFeature()
        {
            RegistryKey imcEntry = EntryInProgramFeature();
            if (imcEntry == null)
            {
                return;
            }
            RegistryKey uninstall32 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
            try
            {
                uninstall32.DeleteSubKey(imcEntry.Name);
            }
            catch (Exception)
            {

            }

            if (Environment.Is64BitOperatingSystem)
            {
                RegistryKey uninstall64 = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall", true);
                try
                {
                    uninstall64.DeleteSubKey(imcEntry.Name);
                }
                catch (Exception)
                {

                }
            }
        }
        bool ValidateXML(string path, Func<StreamReader, bool> validator, string error)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                using (StreamReader sr = new StreamReader(fs))
                {
                    if (!validator(sr))
                    {
                        return false;
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                Logger.Instance.WriteLog("No " + path);
                error = string.Format("{0}", ex.Message);
                return false;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Invalid xml,n " + path);
                error += string.Format("  {0}", ex.Message);
                return false;
            }
            return true;
        }
        public string ValidateMachineInfoAndAppsAndTags()
        {
            string machineinfo = Path.Combine(Path.Combine(Constants.iMCProgramData, "shared"), "MachineInformation.xml");
            string appsandtags = Path.Combine(Path.Combine(Constants.iMCProgramData, "shared"), "AppsAndTags.xml");
            string errorInfo = "";
            if (!ValidateXML(machineinfo, delegate (StreamReader reader)
            {
                if (reader.ReadToEnd().Contains("<BiosVersion>"))
                {
                    return true;
                }
                errorInfo += string.Format("not found <BiosVersion> in MachineInformation.xml");
                return false;
            }, errorInfo))
            {
                return errorInfo;
            }
            if (!ValidateXML(appsandtags, delegate (StreamReader reader)
            {
                if (reader.ReadToEnd().Contains("<InstalledApp type=\"WindowsStore\""))
                {
                    return true;
                }
                errorInfo += string.Format("   .not found <BiosVersion> in AppsAndTags.xml");
                return false;
            }, errorInfo))
            {
                return errorInfo;
            }
            return "";
        }

    }

}
