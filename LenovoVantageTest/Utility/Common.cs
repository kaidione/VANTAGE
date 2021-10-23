using DeviceInformation.Contracts.SystemInfomation.MachineInformation;
using LenovoVantageTest.Helper;
using LenovoVantageTest.LogHelper;
using Microsoft.Win32;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SHDocVw;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Management;
using System.Management.Automation.Runspaces;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace LenovoVantageTest.Utility
{
    public class Common
    {
        public const string hostsPath = @"C:\Windows\System32\drivers\etc\hosts";
        // <summary>
        // 重定向服务器到测试服务器
        // </summary>
        // <param name="sourceUrl">原服务器地址</param>
        // <param name="destUrl">测试服务器地址</param>
        // <param name="restore">指示测试完成后是否需要恢复，true测试完成后需要恢复，false测试完成后无需恢复</param>
        // <returns>true-完成重定向,false-未完成重定向</returns>
        public static bool RedirectUrl(string sourceUrl, string destUrl, out bool restore)
        {
            bool result = false;
            restore = BackupRestoreFile(hostsPath, true);
            string words = "\n" + destUrl + "\t" + sourceUrl;
            FileStream fs = new FileStream(hostsPath, FileMode.Append);
            TextWriter tw = new StreamWriter(fs);
            tw.WriteLine(words);
            tw.Flush();
            tw.Close();
            result = true;
            return result;
        }
        public static string BackupIMCLog()
        {
            if (!Directory.Exists(Constants.imcLogPath))
            {
                Logger.Instance.WriteLog("IMC Log folder doesnt exist!!", LogType.Warning);
                return "IMC Log folder doesnt exist!!";
            }
            string imclogfolder = Path.Combine(Constants.logPath, string.Format("Log.TangramTest_{0}", DateTime.Now.ToString(Constants.DATETIMEFORMATFORPATH)));
            Logger.Instance.WriteLog(string.Format("ImController log folder is moved to {0}", imclogfolder), LogType.Warning);
            Common.CopyDirectory(Constants.imcLogPath, imclogfolder);
            return imclogfolder;
        }

        public static string GetCurrentWebServerFromNewConfig()
        {
            string env = "Unknow";
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Packages\E046963F.LenovoCompanion_k1h2ywk1493x8\LocalState\config.json";
            if (File.Exists(filePath))
            {
                StreamReader file = File.OpenText(filePath);
                JsonTextReader reader = new JsonTextReader(file);
                JObject jsonObject = (JObject)JToken.ReadFrom(reader);

                JObject entry = (JObject)jsonObject["entry"];
                JObject webInEntry = (JObject)entry["web"];
                env = webInEntry["env"].ToString();

                Console.WriteLine($"Current testing Web server is {env}");
            }
            else
            {
                Console.WriteLine($"{filePath} does not exist!");
            }

            return env;
        }

        // <summary>
        // 备份/恢复文件
        // </summary>
        // <param name="filePath">文件路径</param>
        // <param name="toBackup">true - to backup, false - to restore</param>
        // <returns>true - backup/restore success, false - backup/restore failure</returns>
        public static bool BackupRestoreFile(string filePath, bool toBackup = false)
        {
            string backFilePath = filePath + "Backup";
            if (toBackup)
            {
                //backup the file
                if (File.Exists(filePath))
                {
                    if (File.Exists(backFilePath))
                        File.Delete(backFilePath);
                    File.Move(filePath, backFilePath);
                    return true;
                }
            }
            else
            {
                //delete the file first
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
                //restore the file
                if (File.Exists(backFilePath))
                {
                    if (File.Exists(filePath))
                        File.Delete(filePath);
                    File.Move(backFilePath, filePath);
                    return true;
                }
            }
            return false;
        }

        // <summary>
        // 备份/恢复文件
        // </summary>
        // <param name="directoryPath">文件路径</param>
        // <param name="toBackup">true - to backup, false - to restore</param>
        // <returns>true - backup/restore success, false - backup/restore failure</returns>
        public static bool BackupRestoreDirectory(string directoryPath, bool toBackup = false)
        {
            string backDirPath = directoryPath.Trim('\\') + "Backup";
            if (toBackup)
            {
                //backup the directory
                if (Directory.Exists(directoryPath))
                {
                    if (Directory.Exists(backDirPath))
                        Directory.Delete(backDirPath, true);
                    Directory.Move(directoryPath, backDirPath);
                    return true;
                }
            }
            else
            {
                //delete the directory first
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
                //restore the directory
                if (Directory.Exists(backDirPath))
                {
                    if (Directory.Exists(directoryPath))
                        Directory.Delete(directoryPath, true);
                    Directory.Move(backDirPath, directoryPath);
                    return true;
                }
            }
            return false;
        }

        public static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For object or For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        // <summary>
        // 获取文件绝对路径（翻译环境变量）
        // </summary>
        // <param name="path">文件相对路径</param>
        // <returns>绝对路径</returns>
        public static string FileConverter(string path)
        {
            string newPath = "";
            string[] s = path.Split('\\');
            Environment.SpecialFolder sFolder = FolderMapping(s[0]);
            s[0] = null;
            string file = string.Join("\\", s);
            file = file.TrimStart('\\');

            newPath = System.IO.Path.Combine(Environment.GetFolderPath(sFolder), file);
            return newPath;
        }

        static Environment.SpecialFolder FolderMapping(string st)
        {
            Environment.SpecialFolder ret;
            switch (st.ToLower())
            {
                case "%appdata%":
                    ret = Environment.SpecialFolder.LocalApplicationData;
                    break;
                case "%systemroot%":
                    ret = Environment.SpecialFolder.Windows;
                    break;
                case "%programfiles%":
                    ret = Environment.SpecialFolder.ProgramFiles;
                    break;
                case "%programdata%":
                    ret = Environment.SpecialFolder.CommonApplicationData;
                    break;
                case "%localappdata%":
                    ret = Environment.SpecialFolder.LocalApplicationData;
                    break;
                default: throw new Exception("file path is invalid, could not support current SpecialFolder(%appdata%,%systemroot%,%programfiles%)");
            }
            return ret;
        }

        public static bool MakeDirRecursive(string dirPath)
        {
            string[] stringFolder = dirPath.Split('\\');
            string newfolder = "";
            try
            {
                foreach (string folder in stringFolder)
                {
                    newfolder += folder + "\\";
                    if (!System.IO.Directory.Exists(newfolder))
                    {
                        System.IO.Directory.CreateDirectory(newfolder);
                    }
                }
                if (System.IO.Directory.Exists(dirPath))
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public static bool GetRunningProcess(string processName)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length > 0)
                {
                    Logger.Instance.WriteLog(string.Format("No process named: \"{0}\" found.", processName), LogType.Warning);
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("kill process error: " + ex.Message, LogType.Warning);
                return false;
            }
        }

        public static bool KillProcess(string processName, bool needVerify)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length == 0)
                {
                    //Logger.Instance.WriteLog(string.Format("No process named: \"{0}\" found.", processName),  LogType.Warning);
                    return false;
                }
                foreach (Process p in ps0)
                {
                    //Logger.Instance.WriteLog(string.Format("To kill Process {0}", processName), LogType.Warning);
                    p.Kill();
                    p.WaitForExit();
                    System.Threading.Thread.Sleep(1500);
                    //Logger.Instance.WriteLog(string.Format("Process {0} is killed", processName), LogType.Warning);
                }
                if (needVerify)
                {
                    //Verify
                    Process[] ps1 = Process.GetProcessesByName(processName);
                    if (ps1.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("kill process error: " + ex.Message, LogType.Warning);
                return false;
            }
        }

        public static bool KillProcess(int processId, bool needVerify)
        {
            Process ps0 = Process.GetProcessById(processId);
            if (ps0 != null)
            {
                ps0.Kill();
            }

            if (needVerify)
            {
                //Verify
                try
                {
                    Process ps1 = Process.GetProcessById(processId);

                }
                catch (System.ArgumentException ex)
                {
                    //The process specified by the processId parameter is not running.
                    return true;
                }
            }
            return false;
        }
        public static void RunCmdWithShell(string _cmd)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd";
            process.StartInfo.Arguments = "/c " + _cmd;
            process.Start();
            process.WaitForExit();
        }

        public static void RunBat(string fileName)
        {
            string targetPath = string.Format(@"文件夹路径");
            Process process = new Process();
            //process.StartInfo.WorkingDirectory = targetPath;
            process.StartInfo.FileName = fileName;
            process.StartInfo.UseShellExecute = true;
            process.Start();
        }

        public static bool StartProcess(string processName)
        {
            Process p = new Process();
            p.StartInfo.FileName = processName;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
            if (p.ExitCode == 0)
            {
                //Verify
                Process[] ps1 = Process.GetProcessesByName(processName);
                if (ps1.Length == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                Logger.Instance.WriteLog(string.Format("Exit code to start process \"{0}\" is not 0", processName), LogType.Warning);
                return false;
            }
        }

        public static string StartProcessWithOutput(string fileName, string param = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = param;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            return p.StandardOutput.ReadToEnd();
        }

        public static void StartProcess(string fileName, string param = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = param;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            p.WaitForExit();
        }

        public static string GetProcessCMDLine(Process process)
        {
            ManagementObjectSearcher commandLineSearcher = new ManagementObjectSearcher(
            "SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id);
            String commandLine = "";
            foreach (ManagementObject commandLineObject in commandLineSearcher.Get())
            {
                commandLine += (String)commandLineObject["CommandLine"];
            }
            return commandLine;
        }

        public static void StartProcessWithoutWaitingExit(string fileName, string param = "")
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.Arguments = param;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }
        public static void StartProcessWithoutWaitingExit(string fileName)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
        }

        public static void StartProcessWithoutWaitingExitAsAdmin(string fileName)
        {
            Process p = new Process();
            p.StartInfo.FileName = fileName;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = false;
            p.StartInfo.RedirectStandardInput = false;
            p.StartInfo.RedirectStandardOutput = false;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.Verb = "runas";
            p.Start();
        }

        public static bool StartProtocol(string protocolStr, string processName, int timeout = 30)
        {
            Process p = new Process();
            p.StartInfo.FileName = protocolStr;
            p.StartInfo.CreateNoWindow = true;
            p.Start();
            if (processName.Equals(""))
            {
                timeout = 5;
            }
            do
            {
                Process[] ps1 = Process.GetProcessesByName(processName);
                if (ps1.Length == 0)
                {
                    System.Threading.Thread.Sleep(1 * 1000);
                    timeout--;
                }
                else
                {
                    return true;
                }
            }
            while (timeout > 0);
            return false;
        }

        internal static void StartService(string serviceName)
        {
            Logger.Instance.WriteLog($"Try to start service {serviceName}.", LogType.Information);
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = serviceName;
                try
                {
                    sc.Refresh();

                    if (sc.Status.Equals(ServiceControllerStatus.StartPending) || sc.Status.Equals(ServiceControllerStatus.Stopped))
                    {
                        var cmds = new List<string>{
                            string.Format("Start-Service -Name \"{0}\" ", serviceName)
                        };
                        RunPowershellCmdlet(cmds);
                        sc.WaitForStatus(ServiceControllerStatus.Running);
                    }
                    Logger.Instance.WriteLog($"The service {serviceName} status is {sc.Status}", LogType.Information);
                }
                catch (InvalidOperationException)
                {
                    Logger.Instance.WriteLog($"Could not start the service {serviceName}.", LogType.Warning);
                }
            }
        }

        internal static void StopService(string serviceName)
        {
            Logger.Instance.WriteLog($"Try to stop service {serviceName}.", LogType.Information);
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = serviceName;
                try
                {
                    sc.Refresh();
                    if (sc.Status.Equals(ServiceControllerStatus.Running))
                    {
                        var cmds = new List<string>{
                            string.Format("Stop-Service -Name \"{0}\" -Force ", serviceName)
                        };
                        RunPowershellCmdlet(cmds);
                        sc.WaitForStatus(ServiceControllerStatus.Stopped, new TimeSpan(1500));
                    }
                    Logger.Instance.WriteLog($"The service {serviceName} status is {sc.Status}", LogType.Information);
                }
                catch (Exception)
                {
                    Logger.Instance.WriteLog($"Could not stop the service {serviceName}.", LogType.Error);
                }
            }
        }

        internal static void RestartService(string serviceName)
        {
            Logger.Instance.WriteLog($"Try to stop service {serviceName}.", LogType.Information);
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = serviceName;
                try
                {
                    sc.Refresh();
                    if (sc.Status.Equals(ServiceControllerStatus.Running))
                    {
                        StopService(serviceName);
                        StartService(serviceName);
                        Logger.Instance.WriteLog($"The service {serviceName} status is {sc.Status}");
                    }
                    if (sc.Status.Equals(ServiceControllerStatus.Stopped))
                    {
                        StartService(serviceName);
                        Logger.Instance.WriteLog($"The service {serviceName} status is {sc.Status}");
                    }


                }
                catch (Exception)
                {
                    Logger.Instance.WriteLog($"Could not stop the service {serviceName}.", LogType.Error);
                }
            }
        }


        internal static bool CheckServiceIsRunning(string serviceName)
        {
            using (ServiceController sc = new ServiceController())
            {
                sc.ServiceName = serviceName;
                sc.Refresh();
                if (sc.Status.Equals(ServiceControllerStatus.Running))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public static void enableCameraDriver(bool action = true)
        {
            string item = @"USB\VID_*&MI_00";
            Process proc = new Process();
            proc.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Environment.Is64BitOperatingSystem ? @"Data\Tools\devcon_64.exe" : @"Data\Tools\devcon_32.exe");
            if (action)
                proc.StartInfo.Arguments = "enable " + item;
            else
                proc.StartInfo.Arguments = "disable " + item;
            try
            {
                proc.Start();
                proc.WaitForExit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception Handler:" + ex.Message);
            }
        }
        // <summary>  
        // 字符串转Unicode  
        // </summary>  
        // <param name="source">源字符串</param>  
        // <returns>Unicode编码后的字符串</returns>  
        public static string String2Unicode(string source)
        {
            var bytes = Encoding.Unicode.GetBytes(source);
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < bytes.Length; i += 2)
            {
                stringBuilder.AppendFormat("\\u{0:x2}{1:x2}", bytes[i + 1], bytes[i]);
            }
            return stringBuilder.ToString();
        }

        public static ManagementObjectCollection GetProcessesByName_Win32(string processName)
        {
            string wmiQuery = string.Format("select * from Win32_Process where Name='{0}'", processName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
            {
                return searcher.Get();
            }
        }
        public static bool WalkThroughProcess(Func<Process, bool> _callback)
        {
            if (_callback == null)
            {
                return false;
            }
            foreach (Process process in Process.GetProcesses())
            {
                if (_callback(process))
                {
                    return true;
                }
            }
            return false;
        }

        // <summary>
        // 获取本机实际的机器信息
        // </summary>
        // <returns>返回一个MachineInformation类型的对象</returns>
        public static MachineInformation GetActualMachineInfo()
        {
            //Refer to https://lnvusconf.lenovonet.lenovo.local/display/W10DF/Machine+Information

            MachineInformation actualInfo = new MachineInformation();
            try
            {
                //Get system infomation from Environment class
                string OSName = Environment.OSVersion.Platform.ToString(); //OSName = "Win32NT"
                string OSVersion = Environment.OSVersion.Version.ToString(); //OSVersion should be "6.3.15063", 注意：需要在app.manifest应用程序清单文件中去掉关于Windows10兼容性的注释，否则WIn10系统上将返回 OSVersion = "6.2.9200.0"
                string OSVersionStr = Environment.OSVersion.VersionString; //OSVersionStr = "Microsoft Windows NT 6.2.9200.0"


                //(13). < OSBitness > 64 </ OSBitness >
                bool Is64bit = Environment.Is64BitOperatingSystem; //Is64bit = true
                if (Is64bit)
                { actualInfo.OperatingSystemBitness = "64"; }
                else
                { actualInfo.OperatingSystemBitness = "32"; }

                string CultureName = CultureInfo.CurrentCulture.Name; //CultureName = "en-US"
                string[] array = CultureName.Split('-');
                //(10). < Locale > en </ Locale >
                actualInfo.Locale = array[0]; //actualInfo.Locale = "en"

                //(5). < Country > US </ Country >
                //以下.Net方法发现有Bug，在IdeaPad-E53上，地区设为“China”后竟然返回"US"
                //RegionInfo myRT = new RegionInfo(CultureName);
                //actualInfo.CountryCode = myRT.TwoLetterISORegionName;

                //用此方法获取Country Code更为准确
                actualInfo.CountryCode = Geo.GetCountryCode();

                //Get BIOS infomation from [Win32_BIOS] WMI class
                string BIOS_SerialNumber = "Unknow";
                ManagementObjectSearcher sql = new ManagementObjectSearcher("Select * From Win32_BIOS");
                ManagementObjectCollection moc = sql.Get();
                if (moc.Count > 0)
                {
                    foreach (ManagementObject mo in moc)
                    {
                        string BIOS_SMBIOSBIOSVersion = mo["SMBIOSBIOSVersion"].ToString(); //BIOS_SMBIOSBIOSVersion = "N1DET77W (2.08 )"
                        string BIOS_ReleaseDate = mo["ReleaseDate"].ToString(); //BIOS_ReleaseDate = "20160803000000.000000+000"
                        string BIOS_ECMajorVersion = mo["EmbeddedControllerMajorVersion"].ToString(); //BIOS_ECMajorVersion = "1"
                        string BIOS_ECMinorVersion = mo["EmbeddedControllerMinorVersion"].ToString(); //BIOS_ECMinorVersion = "15"
                        string BIOS_Name = mo["Name"].ToString(); //BIOS_Name = "N1DET77W (2.08 )"
                        string BIOS_Manufacturer = mo["Manufacturer"].ToString(); //BIOS_Manufacturer = "LENOVO"
                        BIOS_SerialNumber = mo["SerialNumber"].ToString(); //BIOS_SerialNumber = "PF0DWB7N"

                    }
                }

                //(20). < Serialnumber > PF0DWB7N </ Serialnumber >
                actualInfo.SerialNumber = BIOS_SerialNumber; //actualInfo.SerialNumber = "PF0DWB7N" , 此方法在IdeaPad上获取的Serialnumber并不准确


                //Get CPU infomation from [Win32_Processor] WMI class
                string CPU_AddressWidth = "Unknow";
                string CPU_Architecture = "Unknow";

                ManagementObjectSearcher sql2 = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");
                ManagementObjectCollection moc2 = sql2.Get();
                if (moc2.Count > 0)
                {
                    foreach (ManagementObject mo in moc2)
                    {
                        CPU_AddressWidth = mo["AddressWidth"].ToString();
                        CPU_Architecture = mo["Architecture"].ToString();
                    }
                }
                //(17). < CPUAddressWidth > 64 </ CPUAddressWidth >
                actualInfo.CPUAddressWidth = CPU_AddressWidth;  //actualInfo.CPUAddressWidth = "64"

                //(18). < CPUArchitecture > x64 </ CPUArchitecture >
                //vantage3.0 name processor as  I386,AMD64,ARM64

                switch (CPU_Architecture)
                {
                    case "0":
                        actualInfo.CPUArchitecture = "I386"; //x86 处理器架构
                        break;
                    case "5":
                        actualInfo.CPUArchitecture = "AMD64"; //ARM 处理器架构
                        break;
                    case "9":
                        actualInfo.CPUArchitecture = "ARM64"; //x64 处理器架构
                        break;
                    case "11":
                        actualInfo.CPUArchitecture = "neutral"; //非特定处理器架构
                        break;
                    case "65535":
                        actualInfo.CPUArchitecture = "unknown"; //未知的处理器架构
                        break;
                    default:
                        actualInfo.CPUArchitecture = "unknow";
                        break;
                }

                //Get machine infomation form registry [Computer\HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS\]
                string Regkey_BIOS = @"HKLM\HARDWARE\DESCRIPTION\System\BIOS\";

                //(1). <BiosVersion>N1DET77W 2.08 </BiosVersion>
                string BiosVersionOriginal = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "BIOSVersion").ToString();  //BiosVersionOriginal = "N1DET77W (2.08 )"
                actualInfo.BiosVersion = BiosVersionOriginal.Replace("(", "").Replace(")", ""); //actualInfo.BiosVersion = "N1DET77W 2.08 "

                //(2). < BiosDate > 08032016 </ BiosDate >
                string BiosDateOriginal = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "BIOSReleaseDate").ToString();  //BiosDateOriginal = "08/03/2016"
                actualInfo.BiosDate = BiosDateOriginal.Replace("/", ""); //actualInfo.BiosDate = "08032016 "

                //(3). < ECVersion > 1.15 </ ECVersion >
                string ECVersionMajor = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "ECFirmwareMajorRelease").ToString();  //ECVersionMajor = "1"
                string ECVersionMinor = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "ECFirmwareMinorRelease").ToString();  //ECVersionMinor =  "8"
                ECVersionMinor = (Convert.ToDouble(ECVersionMinor) / 100).ToString("0.00").Remove(0, 2); //ECVersionMinor = "08"
                actualInfo.ECVersion = ECVersionMajor + "." + ECVersionMinor; //actualInfo.ECVersion = "1.08"


                //(11). < MTM > 20ESZ1HXUS </ MTM >
                actualInfo.MTM = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "SystemProductName").ToString(); //actualInfo.MTM = "20ESZ1HXUS"

                //(12). < Manufacturer > LENOVO </ Manufacturer >
                actualInfo.Manufacturer = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "SystemManufacturer").ToString(); //actualInfo.Manufacturer = "LENOVO"


                //(21). < SKU > LENOVO_MT_20ES_BU_Think_FM_ThinkPad P70 </ SKU >
                actualInfo.SKU = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "SystemSKU").ToString();  //actualInfo.SKU = "LENOVO_MT_20ES_BU_Think_FM_ThinkPad P70"
                actualInfo.SKU = actualInfo.SKU.Replace("-", "");   //e.g.  "Lenovo YOGA-710-14IKB" --> "Lenovo YOGA-71014IKB"


                string[] array2Tmp = actualInfo.SKU.Split('_');
                //(4). < Brand > think </ Brand >
                BrandType parsedValue = BrandType.None;
                try
                {
                    string RegBrand = array2Tmp[4];
                    if (RegBrand != null)
                    {
                        if (false == Enum.TryParse<BrandType>(RegBrand.Trim(), true, out parsedValue))
                        {
                            Enum.TryParse<BrandType>(RegBrand.Trim().Replace("-", string.Empty).Replace(" ", String.Empty).Replace("_", String.Empty), true, out parsedValue);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteLog($"Get 'Brand' exception: {ex.Message}", LogType.Error);
                }
                actualInfo.Brand = parsedValue;  //actualInfo.Brand = "Think"

                //(8). < Family > ThinkPad P70 </ Family >
                //以下弃用方法可能得到值为 "IDEAPAD", 可能不准确
                string Regkey_HardwareConfig = @"HKLM\SYSTEM\HardwareConfig\Current\";
                actualInfo.Family = RegistryHelp.GetRegistryKeyValue(Regkey_HardwareConfig + "SystemFamily").ToString(); //actualInfo.Family = "ThinkPad P70"

                //通过解析SKU来得到family，以这个为准
                if (!string.IsNullOrWhiteSpace(actualInfo.SKU))  //actualInfo.SKU = "LENOVO_MT_20ES_BU_Think_FM_ThinkPad P70"
                {
                    var items = actualInfo.SKU.Split('_').ToList();
                    //取最后一个"_"之后的string
                    actualInfo.Family = items[items.Count - 1];  //actualInfo.Family = "ThinkPad P70"
                }

                //(22). < SubBrand > ThinkPad </ SubBrand >
                try
                {
                    string[] array1Tmp = actualInfo.Family.Split(' ');
                    actualInfo.SubBrand = array1Tmp[0]; ; //actualInfo.SubBrand = "ThinkPad"

                    //特别处理Yoga子品牌， 如SKU为 "LENOVO_MT_80V4_BU_idea_FM_Lenovo YOGA 71014IKB"
                    if (actualInfo.SKU.ToLower().Contains("yoga"))
                    {
                        if (actualInfo.SKU.ToLower().Contains("idea"))
                        {
                            actualInfo.SubBrand = "IdeaPad";
                        }
                        else if (actualInfo.SKU.ToLower().Contains("think"))
                        {
                            actualInfo.SubBrand = "ThinkPad";
                        }

                    }

                    //Temporary work around,  Not consider "IdeaCentre" , "IdeaTab"
                    if (actualInfo.SKU.ToLower().Contains("idea"))
                    {
                        actualInfo.SubBrand = "IdeaPad";
                    }

                }
                catch (Exception ex)
                {
                    Logger.Instance.WriteLog($"Get 'SubBrand' exception: {ex.Message}", LogType.Error);
                }

                // Get Windows version info form registry[Computer\HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows NT\CurrentVersion]
                string RegKey_WinVerInfo = @"HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\";
                string curVer = RegistryHelp.GetRegistryKeyValue(RegKey_WinVerInfo + "CurrentVersion").ToString(); //curVer = "6.3"
                string curBuild = RegistryHelp.GetRegistryKeyValue(RegKey_WinVerInfo + "CurrentBuild").ToString(); //curBuild = "15063"

                //(14). < OSVersionString > 6.3.15063 </ OSVersionString >
                actualInfo.OperatingSystemVerion = curVer + "." + curBuild; //actualInfo.OperatingSystemVerion = "6.3.15063"

                //(15). < OSName > Windows 10 Pro </ OSName >
                actualInfo.OSName = RegistryHelp.GetRegistryKeyValue(RegKey_WinVerInfo + "ProductName").ToString(); //actualInfo.OSName = "Windows 10 Pro"

                //(16). < OS > WIN10 </ OS >
                string[] arrayTmp = actualInfo.OSName.Split(' ');
                actualInfo.OS = "WIN" + arrayTmp[1]; //actualInfo.OS = "WIN10"

                //(9). < FirstRunDate > 2017 - 03 - 05 </ FirstRunDate >
                //Folder: Modification date of folder (64-bit): %systemdrive%\Users\Default\Documents
                //Folder: Modification date of folder (32-bit): %systemdrive%\Users\Default
                string targetFolder = @"C:\Users\Default\Documents";
                if (!Environment.Is64BitOperatingSystem)
                {
                    targetFolder = @"C:\Users\Default";
                }

                if (Directory.Exists(targetFolder))
                {
                    DirectoryInfo dir = new DirectoryInfo(targetFolder);
                    //DateTime TimeDir = dir.LastWriteTime; //取该文件夹的最后修改时间

                    DateTime TimeDir = System.IO.Directory.GetLastWriteTime(targetFolder);

                    actualInfo.FirstRunDate = TimeDir;
                }
                else
                {
                    Logger.Instance.WriteLog("!!! " + targetFolder + " does NOT exist!", LogType.Warning);
                }


                ///弃用的方法：比较C:\ProgramData\Lenovo\文件夹的创建时间 和 C:\Windows\Modules.log文件的修改时间，哪个更早，便是哪个。
                //string modulesLog = @"C:\Windows\Modules.log";  //此文件有可能不存在
                //            string lenovoDir = @"C:\ProgramData\Lenovo\";
                //            FileInfo file = new FileInfo(modulesLog);
                //            DateTime TimeFile = file.LastWriteTime;
                //            DirectoryInfo dir = new DirectoryInfo(lenovoDir);
                //            DateTime TimeDir = dir.CreationTime;
                //            if (DateTime.Compare(TimeFile, TimeDir) < 0  && File.Exists(modulesLog))
                //            { actualInfo.FirstRunDate = TimeFile; } //Modules.log文件的修改时间更早
                //            else
                //            { actualInfo.FirstRunDate = TimeDir; } //Lenovo文件夹的创建时间更早





                //(6). < DateCreated > 2017 - 12 - 15 </ DateCreated >
                //string machineInfoXML = @"C:\ProgramData\Lenovo\ImController\shared\MachineInformation.xml";
                //FileInfo xmlFile = new FileInfo(machineInfoXML);
                //actualInfo.DateCreated = xmlFile.LastWriteTime; //actualInfo.DateCreated = "2017 - 12 - 15"
                actualInfo.DateCreated = DateTime.Now; //from Confluence Define Page, [Origins of values] https://lnvusconf.lenovonet.lenovo.local/display/W10DF/Machine+Information


                //(7). < EnclosureType > notebook </ EnclosureType >
                //How to get this ?

                //Get EnclosureType infomation from [Win32_SystemEnclosure] WMI class ???
                //string EnclosureType = "Unknow";
                //ManagementObjectSearcher sql3 = new ManagementObjectSearcher("get * /format:list");
                //ManagementObjectCollection moc3 = sql3.Get();
                //if (moc.Count > 0)
                //{
                //    foreach (ManagementObject mo in moc)
                //    {
                //        string aaa = mo["Name"].ToString(); 
                //    }
                //}
                actualInfo.Enclosure = EnclosureType.None;


                //(19). < PreloadTagList />
                //How to get this ? 
                actualInfo.PreloadTagList = new string[0];
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog($"Common.GetActualMachineInfo exception: {ex.Message}", LogType.Warning);
            }
            return actualInfo;
        }

        public static MachineInformation GetMachineInformationFromFile()
        {
            try
            {
                StreamReader file = new StreamReader(Constants.machineInformationSource);
                string machineInfo = file.ReadToEnd();
                file.Close();
                return Serializer.Deserialize<MachineInformation>(machineInfo);
            }
            catch (Exception ex)
            {
                StreamReader file = new StreamReader(Constants.machineInformationVantage);
                string machineInfo = file.ReadToEnd();
                file.Close();
                return Serializer.Deserialize<MachineInformation>(machineInfo);
            }
        }


        public static void SetHostFileToTestingServer_old(string line1 = "10.37.114.6 download.lenovo.com", string line2 = "10.37.114.6 filedownload.lenovo.com")
        {
            try
            {
                string hostFile = hostsPath;

                //backup original host file
                string hostBakFile = @"C:\Windows\System32\drivers\etc\hosts_bak";

                if (!File.Exists(hostFile))
                {
                    Logger.Instance.WriteLog(string.Format("!!! Can't find " + hostFile + "! Now create it."), LogType.Warning);
                }
                else
                {
                    FileInfo f = new FileInfo(hostFile);
                    f.CopyTo(hostBakFile, true);
                }

                FileStream fs = new FileStream(hostFile, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);

                if (line1.ToLower().Contains("production") || line2.ToLower().Contains("production"))
                {
                    //清空host里面所有内容
                    sw.Write("");
                    Logger.Instance.WriteLog(string.Format("hosts file is set to production servers. Download:{0}, filedownload:{1}", line1, line2));

                }
                else
                {
                    //将域名指向所指定的Server IP
                    sw.WriteLine(line1);
                    sw.WriteLine(line2);
                    Logger.Instance.WriteLog(string.Format("!!!!!! hosts file is set to specified servers. Download:{0}, filedownload:{1}", line1, line2));
                }

                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(string.Format("Exception when set hosts file:\r\n" + e.ToString()), LogType.Warning);
            }

        }

        public static void SetHostFileToTestingServer(string line1, string line2)
        {
            try
            {
                string hostFile = hostsPath;

                //backup original host file
                string hostBakFile = @"C:\Windows\System32\drivers\etc\hosts_bak";

                if (!File.Exists(hostFile))
                {
                    Logger.Instance.WriteLog(string.Format("!!! Can't find " + hostFile + "! Now create it."), LogType.Warning);
                }
                else
                {
                    FileInfo f = new FileInfo(hostFile);
                    f.CopyTo(hostBakFile, true);
                }

                FileStream fs = new FileStream(hostFile, FileMode.Create, FileAccess.ReadWrite);
                StreamWriter sw = new StreamWriter(fs);

                if (line1.ToLower().Contains("production") || line2.ToLower().Contains("production"))
                {
                    //清空host里面所有内容
                    sw.Write("");
                    Logger.Instance.WriteLog(string.Format("hosts file is set to production servers. Download:{0}, filedownload:{1}", line1, line2));

                }
                else
                {
                    //将域名指向所指定的Server IP
                    sw.WriteLine(line1);
                    sw.WriteLine(line2);
                    Logger.Instance.WriteLog(string.Format("!!!!!! hosts file is set to specified servers. Download:{0}, filedownload:{1}", line1, line2));
                }

                sw.Flush();
                fs.Flush();
                sw.Close();
                fs.Close();
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(string.Format("Exception when set hosts file:\r\n" + e.ToString()), LogType.Warning);
            }

        }
        //有一个imchelper，里面有restart imc功能，为什么不用那条？？
        public static void RestartService()
        {
            Common.StopService(Constants.IMCONTROLLER_SERVICE_NAME);
            Thread.Sleep(2 * 1000); //wait for release files

            Common.StartService(Constants.IMCONTROLLER_SERVICE_NAME);
            Thread.Sleep(3 * 1000); //wait for release files

            Logger.Instance.WriteLog(string.Format("Restarted IMC Service."), LogType.Warning);
        }




        public static IEnumerable<string> GetCommandLines(string processName)
        {
            List<string> results = new List<string>();
            string wmiQuery = string.Format("select CommandLine from Win32_Process where Name='{0}'", processName);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(wmiQuery))
            {
                using (ManagementObjectCollection retObjectCollection = searcher.Get())
                {
                    foreach (ManagementObject retObject in retObjectCollection)
                    {
                        results.Add((string)retObject["CommandLine"]);
                    }
                }
            }
            return results;
        }

        public static void KillProcessByCMDLineKeyWord(string targetProcName, string CMDLineKeyWord)
        {
            IEnumerable<string> commandLines = null;

            try
            {
                Process[] allProcesses = Process.GetProcesses();
                foreach (Process procs in allProcesses)
                {
                    if (procs.ProcessName.Contains(targetProcName))
                    {
                        commandLines = GetCommandLines(procs.ProcessName + ".exe");

                        foreach (string cmdLine in commandLines)
                        {
                            if (cmdLine.Contains(CMDLineKeyWord))
                            {
                                KillProcess(procs.Id, true);
                                Logger.Instance.WriteLog(string.Format("Killed process - " + procs.ProcessName + "||" + cmdLine + ""), LogType.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(string.Format("Exception of executing KillProcessByCMDLineKeyWord()! \r\n" + e.ToString()), LogType.Warning);
            }

        }

        static void CopyDirectory_CalcCount(string srcPath, string destPath, ref int fileCount)
        {
            try
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);   //目标目录下不存在此文件夹即创建子文件夹
                }
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();  //获取目录下（不包含子目录）的文件和子目录
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)     //判断是否文件夹
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);   //目标目录下不存在此文件夹即创建子文件夹
                        }
                        CopyDirectory_CalcCount(i.FullName, destPath + "\\" + i.Name, ref fileCount);    //递归调用复制子文件夹
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);      //不是文件夹即复制文件，true表示可以覆盖同名文件
                        fileCount++;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(string.Format("Exception:\r\n" + e.ToString()), LogType.Warning);
            }
        }
        public static void CopyDirectory(string srcPath, string destPath)
        {
            if (!Directory.Exists(srcPath))
            {
                return;
            }
            int fileCount = 0;
            CopyDirectory_CalcCount(srcPath, destPath, ref fileCount);
            Logger.Instance.WriteLog(string.Format("{0} files are copied", fileCount));
        }

        public static void CreateDirectory(string directoryPath)
        {
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
        }

        public static void DeleteDirectory(string _targetDir)
        {
            if (!Directory.Exists(_targetDir))
            {
                return;
            }
            string[] files = Directory.GetFiles(_targetDir);
            string[] dirs = Directory.GetDirectories(_targetDir);
            foreach (string file in files)
            {
                File.SetAttributes(file, FileAttributes.Normal);
                File.Delete(file);
            }
            foreach (string dir in dirs)
            {
                DeleteDirectory(dir);
            }
            (new DirectoryInfo(_targetDir)).Attributes = FileAttributes.Normal;
            System.Threading.Thread.Sleep(200);
            Directory.Delete(_targetDir);
        }

        public static void ClearLogsFolderFile(string folderName = "")
        {
            if (folderName == "")
            {
                folderName = Constants.imcLogPath;
            }

            if (!Directory.Exists(folderName))
            {
                Logger.Instance.WriteLog("Directory " + folderName + " not exist");
                return;
            }
            try
            {

                foreach (string deleteFile in Directory.GetFileSystemEntries(folderName))
                {
                    if (File.Exists(deleteFile))
                        File.Delete(deleteFile);
                    else
                        ClearLogsFolderFile(deleteFile);
                }
                //Directory.Delete(folderName);  

            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(string.Format("!!! Exception in ClearLogsFolder() - " + e.ToString()), LogType.Warning);
            }
        }

        public static string FindIMCLog(string fileName)
        {
            string lastestLog = string.Empty;
            string searchKeyWordInFileName = fileName;

            List<FileInfo> logFiles = new List<FileInfo>(); //可能存在多个同名（修改时间不同）的文件，都存下来先，我们取创建时间最新的那个log

            DirectoryInfo logFolder = new DirectoryInfo(Constants.imcLogPath);
            foreach (FileInfo file in logFolder.GetFiles())
            {
                if (file.FullName.Contains(searchKeyWordInFileName))
                {
                    logFiles.Add(file);
                    break;
                }
            }

            if (logFiles.Count > 0)
            {
                FileInfo lastestFile = null;

                //设定一个初始比较的时间
                DateTime time = new DateTime(1900, 1, 1);

                //取时间最新的那个log		
                foreach (FileInfo fi in logFiles)
                {
                    if (fi.CreationTime > time)
                    {
                        time = fi.CreationTime;
                        lastestFile = fi;
                    }
                }

                lastestLog = lastestFile.FullName; ;  //"Log.ImController.PluginHost.LenovoContextEnginePlugin_17-12-22_03-32-48-125.log"
            }

            Logger.Instance.WriteLog(string.Format("The Lastest IMC Log is :" + lastestLog), LogType.Warning);

            return lastestLog;
        }

        public static string FindLastestIMCLog()
        {
            string lastestLog = string.Empty;
            string searchKeyWordInFileName = @"Log.ImController.Service_";

            List<FileInfo> logFiles = new List<FileInfo>(); //可能存在多个同名（修改时间不同）的文件，都存下来先，我们取创建时间最新的那个log

            DirectoryInfo logFolder = new DirectoryInfo(Constants.imcLogPath);
            foreach (FileInfo file in logFolder.GetFiles())
            {
                if (file.FullName.Contains(searchKeyWordInFileName))
                {
                    logFiles.Add(file);
                }
            }

            if (logFiles.Count > 0)
            {
                FileInfo lastestFile = null;

                //设定一个初始比较的时间
                DateTime time = new DateTime(1900, 1, 1);

                //取时间最新的那个log		
                foreach (FileInfo fi in logFiles)
                {
                    if (fi.CreationTime > time)
                    {
                        time = fi.CreationTime;
                        lastestFile = fi;
                    }
                }

                lastestLog = lastestFile.FullName; ;  //"Log.ImController.PluginHost.LenovoContextEnginePlugin_17-12-22_03-32-48-125.log"
            }

            Logger.Instance.WriteLog(string.Format("The Lastest IMC Log is :" + lastestLog), LogType.Warning);

            return lastestLog;
        }

        // <summary>
        // 执行Powershell命令
        // </summary>
        // <param name="cmdlet">PS命令行（此处不可有用户交互式的命令，否则会抛出异常）</param>
        public static void RunPowershellCmdlet(string cmdlet)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            pipe.Commands.AddScript(cmdlet);
            pipe.Invoke();
            runspace.Close();
        }

        // <summary>
        // 执行一组Powershell cmdlets，可用于带上下文的场景
        // </summary>
        // <param name="cmdlets">PS命令行，按顺序传入（此处不可有用户交互式的命令，否则会抛出异常）</param>
        public static void RunPowershellCmdlet(List<string> cmdlets)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            foreach (string cmd in cmdlets)
            {
                pipe.Commands.AddScript(cmd);
            }
            pipe.Invoke();
            runspace.Close();
        }

        public static void MakeDataLink(int trytimes = 5)
        {
            var cmds = new List<string>();
            var file = string.Empty;
            if (Constants.SettingsAgentIpAddress.Contains(Constants.CurrentAgentMachineIp))
            {
                cmds = new List<string>
                {
                    string.Format("Start-Process -FilePath \"{0}\" -Wait -passthru ", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CopyDataForSettings.bat"))
                };
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CopyDataForSettings.bat");
            }
            else
            {
                cmds = new List<string>
                {
                    string.Format("Start-Process -FilePath \"{0}\" -Wait -passthru ", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BJ_makeDatalink.bat"))
                };
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BJ_makeDatalink.bat");
            }
            do
            {
                Common.RunPowershellCmdlet(cmds);
                if (Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data")))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Try CreateShortcut...");
                    VantageCommonHelper.CreateShortcut(AppDomain.CurrentDomain.BaseDirectory, "BJDatalink", file);
                    Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BJDatalink.lnk"));
                }
                Thread.Sleep(1000);
                trytimes--;
                Console.WriteLine("Try MakeDataLink... " + trytimes);
            } while (trytimes > 0);
        }

        // <summary>
        // 设置C:\Windows\System32\drivers\etc\hosts，增加/删除一条重定向内容
        // </summary>
        // <param name="entry">待设置的内容</param>
        // <param name="addOrDelete">true - 增加， false - 删除</param>
        public static void SetHostsFile(string entry, bool addOrDelete)
        {
            string hostFile = hostsPath;
            try
            {
                StringBuilder sb = new StringBuilder();
                if (File.Exists(hostFile))
                {
                    StreamReader sr = new StreamReader(hostFile);

                    //获取文件内容
                    while (!sr.EndOfStream)
                    {
                        sb.AppendLine(sr.ReadLine());
                    }
                    sr.Close();
                }

                //若文件不存在，确想删除条目，立即退出
                if (sb.Length == 0 && !addOrDelete)
                    return;

                if (addOrDelete)
                {
                    //需要把新的条目插入文件头部。防止可能若存在两个类似的条目，新条目不生效
                    sb.Insert(0, entry + "\r\n");
                }
                else
                {
                    //删除条目
                    sb.Replace(entry, "");
                }

                //去掉多余的空行
                sb.Replace("\r\n\r\n", "\r\n");

                StreamWriter sw = new StreamWriter(hostFile);
                sw.Write(sb);
                sw.Flush();
                sw.Close();

                Logger.Instance.WriteLog("hosts file contents:\r\n" + sb.ToString(), LogType.Warning);
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog("set hosts file exception. " + e.Message, LogType.Warning);
            }
        }

        // <summary>
        // 设置系统日期时间
        // </summary>
        // <param name="dateTimeStr">"3/25/2019 18:05:45"</param>
        public static void SetSystemDateTime(string dateTimeStr)
        {
            SetSystemTimeAutomatically(false);
            Logger.Instance.WriteLog($"Set system time to {dateTimeStr}...", LogType.Warning);
            List<string> cmds = new List<string>
            {
                $"Set-Date -Date \"{dateTimeStr}\"",
            };
            RunPowershellCmdlet(cmds);
        }


        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;


            public void FromDateTime(DateTime time)
            {
                wYear = (ushort)time.Year;
                wMonth = (ushort)time.Month;
                wDayOfWeek = (ushort)time.DayOfWeek;
                wDay = (ushort)time.Day;
                wHour = (ushort)time.Hour;
                wMinute = (ushort)time.Minute;
                wSecond = (ushort)time.Second;
                wMilliseconds = (ushort)time.Millisecond;
            }

            public DateTime ToDateTime()
            {
                return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
            }

            public static DateTime ToDateTime(SystemTime time)
            {
                return time.ToDateTime();
            }
        }

        [DllImport("Kernel32.dll")]
        public static extern bool SetLocalTime(ref SystemTime Time);

        // <summary>
        // 设置系统时间同步方式
        // </summary>
        // <param name="sync">true - 自动同步，false - 不自动同步</param>
        public static void SetSystemTimeAutomatically(bool sync)
        {
            Logger.Instance.WriteLog($"Set system time automatically to {sync}...", LogType.Warning);
            RegistryHelp.SetRegistryKeyValuePlus(@"HKLM\SYSTEM\CurrentControlSet\Services\W32Time\Parameters\Type", sync ? "NTP" : "NoSync");
            RunPowershellCmdlet("w32tm.exe /resync");
        }



        public static void CloseWindow(string winName)
        {
            const UInt32 WM_CLOSE = 0x0010;
            IntPtr windowPtr = UnManagedAPI.FindWindowByCaption(IntPtr.Zero, winName);
            UnManagedAPI.PostMessage(windowPtr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

        }


        public static bool Existbiometric()
        {
            const uint WINBIO_TYPE_FINGERPRINT = 0x00000008;
            IntPtr pointer = IntPtr.Zero;
            int count = 0;
            UnManagedAPI.WinBioEnumBiometricUnits(WINBIO_TYPE_FINGERPRINT, ref pointer,
                ref count);
            if (count > 0)
                UnManagedAPI.WinBioFree(pointer);
            return count > 0;
        }


        public static long GetSystemVersion()
        {
            string key = @"HKLM\SOFTWARE\Microsoft\Windows NT\CurrentVersion\CurrentBuild";
            string value = RegistryHelp.GetRegistryKeyValue(key).ToString();
            return Convert.ToInt32(value);
        }


        public static void Enable(string interfaceName)
        {
            ProcessStartInfo psi =
                   new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" enable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        public static void Disable(string interfaceName)
        {
            ProcessStartInfo psi =
                new ProcessStartInfo("netsh", "interface set interface \"" + interfaceName + "\" disable");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }


        public static void ClearEventLog(string logName)
        {
            var cmdProcess = new Process()
            {
                StartInfo = new ProcessStartInfo()
                {
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                },
            };

            // Use the windows event util to install the manifest
            cmdProcess.Start();
            cmdProcess.StandardInput.WriteLine("wevtutil cl " + logName); //clear-log
            cmdProcess.StandardInput.WriteLine("exit");
            cmdProcess.WaitForExit();
        }

        public static void WMIEnumerator(string _wmiQuery, Func<ManagementObject, bool> _callback)
        {
            if (_callback == null)
            {
                return;
            }
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(_wmiQuery))
            {
                using (ManagementObjectCollection retObjectCollection = searcher.Get())
                {
                    foreach (ManagementObject retObject in retObjectCollection)
                    {

                        if (_callback(retObject))
                        {
                            break;
                        }

                    }
                }
            }

        }
        public static void regGoThroughInstalledSoftware32(Func<RegistryKey, bool> _callback)
        {
            if (_callback == null)
            {
                return;
            }
            string regPath = @"Software\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32);
            RegistryKey uninstallKey = registryKey.OpenSubKey(regPath, false);
            foreach (string subkeyName in uninstallKey.GetSubKeyNames())
            {
                if (_callback(uninstallKey.OpenSubKey(subkeyName)))
                {
                    return;
                }
            }
        }
        public static void regGoThroughInstalledSoftware64(Func<RegistryKey, bool> _callback)
        {
            if (_callback == null)
            {
                return;
            }
            string regPath = @"Software\Microsoft\Windows\CurrentVersion\Uninstall";
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64);
            RegistryKey uninstallKey = registryKey.OpenSubKey(regPath, false);
            foreach (string subkeyName in uninstallKey.GetSubKeyNames())
            {
                if (_callback(uninstallKey.OpenSubKey(subkeyName)))
                {
                    return;
                }
            }
        }
        //Author:Marcus
        //Desc:要让SUP在Standard User下运行，但我们的automation又是以adminstrator起的，我们要分辨出当前登录Windows的用户是谁。
        //    Standard User会影响cmd 判断Vantage是否安装：admin安装了不代表standard user安装了。
        //                 会影响读取HKCU.
        //     获得logged in & active user 的name后，就可以用密码登录了。获得用户名的好处是不用担心用户名不是预期的。
        //Google了很多方法：
        //1. 有的人说C#的Environment.UserName或者System.Security.Principal.WindiwsIdentity.GetCurrent()可以，但这2种方法只能返回当前进程使用的用户，即administrator。
        //2. WMI的Win32_ComputerSystem ， 概率会出现UserName=null 的情况 ，没找到有效原因，而我偏偏遇上了，一旦遇上它就固定是null了，除非Reboot。
        //3. WMI的Win32_LoggedOnUser ，显示自机器boot后所有的logged on user信息，包括连上后退出的。所以靠这个没法正确定位当前用户。即使联合使用Win32_LogonSession也没用。
        //4. social.technet.microsoft.com一篇post: WMI script gives the complete list of all the remote users (logged off users also). I need only the current remote users.
        //   直接查explorer.exe的owner来判断反而能直观看到，例外是如果几个用户都logged in了呢，只不过做了switch，情况如下
        //  a. 一个是admin一个是standard user，那standard user看不到其他用户的explorer.exe 
        //  b. 某一个是admin，那它可以看到所有explorer.exe
        //  我们测试刚好是b，那可以用方法4判断
        //5. stackoverflow.com下powershell-win32-serverconnection-on-ts-server-2012-no-result里一个用户提到用cmd的query方法，可以看到logged in的用户。
        //   经验证确实可以，而且不会list所有已经disconnected的历史数据，而且是interactive的用户, service不会在里面。
        //  这种方法更好！！ 但没人知道这个方法背后调用了什么API完成的。
        //  当前只能分析query user返回的字符串，用PowerShell的.AddScript("query user").Invoke()返回是null，没人能解释。所以只能用cmd的方式读取输出文本(power shell我还没弄懂).
        //
        public static string GetActiveLoggedInUserNameInWindows()
        {
            //根据stackoverflow.com的process-start-in-c-sharp-the-system-cannot-find-the-file-specified-error
            //Automation被编译成了32bit，所以无法访问system32下的东西，我又不想临时关闭redirection或把query.exe copy出来。用文档提到的方法简单了许多。
            //thewindowsclub.com/sysnative-folder-in-windows-64-bit 解释了sysnative是方便32bit APP访问64bit dll，而不用关闭redirection
            //Marcus 2019/12/25 , Win10 Home版不带query.exe，无法使用。即使copy了pro版的query.exe过去，也会报错，没有方案绕过。由于当前Home版只有一台，而且不使用standard user，
            //所以当发现没有query.exe时，我用当前第一个explorer.exe的owner作为已登录的用户。

            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"sysnative\query.exe")))
            {
                return RetrieveExplorerOwnerName();
            }
            string result = Common.StartProcessWithOutput(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), @"sysnative\query.exe"), "user");
            string[] lines = result.Split("\r\n".ToArray());
            string activeUserLine = lines.Single(line =>
            {
                if (line.Contains("Active"))
                {
                    return true;//terminate
                }
                return false;//continue
            });
            if (activeUserLine.Equals(""))
            {
                throw new Exception("!! NO Logged in User via quer user ??");
            }
            Regex regex = new Regex(@"(?<=>)\w+");
            MatchCollection matchCollection = regex.Matches(activeUserLine);
            return matchCollection[0].Value;
        }
        static string RetrieveExplorerOwnerName()
        {
            ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("select * from win32_process where name='explorer.exe'");
            foreach (ManagementObject process in managementObjectSearcher.Get())
            {
                if (process["ExecutablePath"] != null)
                {
                    string executablePath = process["ExecutablePath"].ToString();
                    string[] ownerinfo = new string[2];
                    process.InvokeMethod("GetOwner", (object[])ownerinfo);
                    return ownerinfo[0];
                }
            }
            return "";
        }

        public static void CloseWindowsProxy()
        {
            string script = "Set-ItemProperty -Path \"Registry::HKCU\\Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings\" ProxyEnable -value 0";
            Common.RunPowershellCmdlet(script);
        }

        public static string ConvertJsonString(string str)
        {
            //格式化json字符串
            Newtonsoft.Json.JsonSerializer serializer = new Newtonsoft.Json.JsonSerializer();
            TextReader tr = new StringReader(str);
            JsonTextReader jtr = new JsonTextReader(tr);
            object obj = serializer.Deserialize(jtr);
            if (obj != null)
            {
                StringWriter textWriter = new StringWriter();
                JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
                {
                    Formatting = Formatting.Indented,
                    Indentation = 4,
                    IndentChar = ' '
                };
                serializer.Serialize(jsonWriter, obj);
                return textWriter.ToString();
            }
            else
            {
                return str;
            }
        }

        /*Author:Marcus
         Desc:since Some checkpoints need to verify a folder is open, the precondition is to ensure no such folder open before test.
              Someone said taskkill /FI "WINDOWTITLE eq xxx" could help , it doesn't pass my test. This command finds nothing , but N/A for expected window.
        Ref: stackoverflow.com/questions/13463639/is-there-a-way-to-close-a-particular-instance-of-explorer-with-c
        */
        public static void CloseOpenedFolderUsingItsPath(string _keyRecognizerInfolderpath)
        {
            try
            {
                ShellWindows shellWindows = new SHDocVw.ShellWindows();
                string processType;
                foreach (InternetExplorer item in shellWindows)
                {
                    processType = Path.GetFileNameWithoutExtension(item.FullName).ToLower();
                    if (processType.Equals("explorer") && item.LocationURL.ToLower().Contains(_keyRecognizerInfolderpath.ToLower()))
                    {
                        item.Quit();
                    }
                }
            }
            catch (Exception ex)
            {

            }

        }

        public static void AutomaticShutdown(int hours, bool isDebug, int times)
        {
            int dayOfWeek = Convert.ToInt32(DateTime.Now.DayOfWeek) < 1 ? 7 : Convert.ToInt32(DateTime.Now.DayOfWeek);
            if (dayOfWeek >= 5)
            {
                string NowHour = Convert.ToString(DateTime.Now.TimeOfDay).Split(':')[0];
                if (Convert.ToInt32(NowHour) > hours)
                {
                    int time = 60 * times;
                    Process.Start("c:/windows/system32/shutdown.exe", "-s -t " + time);
                }
            }
        }
    }
}
