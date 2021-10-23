using Appconfig;
using Http.Util;
using IWshRuntimeLibrary;
using LenovoMultipleCleint.Common;
using LogServer;
using Microsoft.Win32;
using Microsoft.WindowsAPICodePack.Net;
using MultipleCleint.Bean;
using RegistryHelpTest.Utility;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Upgrade;
using winformUI.Bean;
using winformUI.Serialize.Bean;
using File = System.IO.File;

namespace winformUI.Common
{
    public class CommonFunction
    {
        public static string GetClientDatetimeStr()
        {
            DateTime dateTime = DateTime.Now;
            return dateTime.ToString(CommonConstStr.DateTimeFormat);
        }

        public static void RunProcess(string path, string arg)
        {
            if (File.Exists(path))
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = path;
                processInfo.UseShellExecute = true;
                processInfo.WorkingDirectory = Environment.CurrentDirectory;
                //设置启动动作,确保以管理员身份运行
                processInfo.Verb = "runas";
                processInfo.Arguments = arg;
                processInfo.WindowStyle = ProcessWindowStyle.Normal;
                Process.Start(processInfo);
            }
        }

        public static void SetShareUserPasswordexpires()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.WorkingDirectory = @"C:/WINDOWS/system32";
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                process.StartInfo.Verb = "runas";
                process.StartInfo.CreateNoWindow = true;
                process.Start();

                //设置账户密码不过期
                //wmic.exe UserAccount Where Name="share" Set PasswordExpires="false"
                string cmd = "wmic.exe UserAccount Where Name='" + "share" + "' set passwordexpires=false";
                process.StandardInput.WriteLine(cmd);
                process.StandardInput.Flush();
                //if (add)
                //{
                //    //添加用户
                //    //string cmd = "net user " + username + " " + password + " /ADD /COMMENT:\"" + comment + "\" /FULLNAME:" + username;
                //    //process.StandardInput.WriteLine(cmd);
                //    //process.StandardInput.Flush();



                //    //设置为管理员
                //    if (isadmin)
                //    {
                //        process.StandardInput.WriteLine("net LOCALGROUP Administrators " + username + " /add");
                //    }
                //}
                //else
                //{
                //    //删除用户
                //    cmd = "net user " + username + " /delete";
                //    process.StandardInput.WriteLine(cmd);
                //    process.StandardInput.Flush();
                //}

                //关闭命令输入流，防止卡死
                process.StandardInput.Close();
                //net localgroup administrators tian /add
                StreamReader readerEnd = process.StandardOutput;
                StreamReader readerErr = process.StandardError;

                process.WaitForExit();
                if (process.HasExited)
                {
                    string outMsg = readerEnd.ReadToEnd();
                    string errMsg = readerErr.ReadToEnd();
                    Debug.WriteLine("outMsg:" + outMsg);
                    Debug.WriteLine("errMsg:" + errMsg);

                }
                process.Close();

            }
            catch (Exception ex)
            {

            }
        }

        public static MachineInformation GetSystemInformation()
        {
            MachineInformation actualInfo = new MachineInformation();
            try
            {
                ManagementObjectSearcher searcher = null;
                string curBuild = SystemInfo.GetLocalMachineRegKeyValue(CommonConstStr.LocalMachineCurrentVersionRegPath, "CurrentBuild").ToString();
                actualInfo.OSName = SystemInfo.GetLocalMachineRegKeyValue(CommonConstStr.LocalMachineCurrentVersionRegPath, "ProductName").ToString();
                actualInfo.ComputerName = SystemInformation.ComputerName;
                string[] arrayTmp = actualInfo.OSName.Split(' ');
                actualInfo.OS = "WIN" + arrayTmp[1];
                try
                {
                    //10. OS制造商 label26
                    string Regkey_BIOS = @"HKLM\HARDWARE\DESCRIPTION\System\BIOS\";
                    actualInfo.Manufacturer = RegistryHelp.GetRegistryKeyValue(Regkey_BIOS + "SystemManufacturer").ToString();
                    //11. 产品ID label25
                    string productId = SystemInfo.GetLocalMachineRegKeyValue(CommonConstStr.LocalMachineCurrentVersionRegPath, "ProductId").ToString();
                    actualInfo.ProductId = productId;
                    string Regkey_HardwareConfig = @"HKLM\SYSTEM\HardwareConfig\Current\";
                    actualInfo.Family = RegistryHelp.GetRegistryKeyValue(Regkey_HardwareConfig + "SystemFamily").ToString(); //actualInfo.Family = "ThinkPad P70"
                }
                catch (Exception ex)
                {
                }

                if (!string.IsNullOrEmpty(actualInfo.SKU))  //actualInfo.SKU = "LENOVO_MT_20ES_BU_Think_FM_ThinkPad P70"
                {
                    var items = actualInfo.SKU.Split('_').ToList();
                    actualInfo.Family = items[items.Count - 1];  //actualInfo.Family = "ThinkPad P70"
                }

                actualInfo.OperatingSystemBitness = Environment.Is64BitOperatingSystem ? "64-bit" : "32-bit";
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog($"Common.GetActualMachineInfo exception: {ex.Message}", LogType.Warning);
            }
            return actualInfo;
        }

        public static void LaunchNginx()
        {
            try
            {
                ProcessStartInfo info = new ProcessStartInfo();
                info.FileName = "cmd.exe";
                info.UseShellExecute = false;
                info.RedirectStandardInput = true;
                info.RedirectStandardOutput = true;
                info.WorkingDirectory = CommonConstStr.multipleNginxFolder;
                info.CreateNoWindow = true;
                Process p = new Process();
                p.StartInfo = info;
                p.Start();
                p.StandardInput.WriteLine("nginx.exe");
                p.StandardInput.WriteLine("exit");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public static void StartProcess(string cmdStr)
        {
            try
            {
                var processInfo = new ProcessStartInfo(cmdStr)
                {
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };

                Process process = new Process
                {
                    StartInfo = processInfo
                };
                process.Start();
                Thread.Sleep(1000);
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static string GetLocalIPv4(NetworkInterfaceType _type)
        {
            string output = "";
            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _type && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }
            return output;
        }

        public static string GetLocalIPAddress()
        {
            //Get the networks that are currently connected to
            string getCurrentConnectIP = string.Empty;
            var networks = NetworkListManager.GetNetworks(NetworkConnectivityLevels.Connected);
            string connectId = string.Empty;
            foreach (Network network in networks)
            {
                Debug.WriteLine("[" + network.Name + "]");
                if (!network.Name.Contains("Unidentified network"))
                {
                    Debug.WriteLine("\t[NetworkConnections]");
                    foreach (NetworkConnection conn in network.Connections)
                    {
                        Debug.WriteLine("\t\t" + conn.AdapterId.ToString());
                        connectId = conn.AdapterId.ToString();
                        break;
                    }
                }
            }

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象
            foreach (NetworkInterface adapter in adapters)
            {
                if (adapter.Id.ToLower().Contains(connectId))
                {
                    Debug.WriteLine("名称：" + adapter.Name);
                    Debug.WriteLine("类型：" + adapter.NetworkInterfaceType);
                    getCurrentConnectIP = GetLocalIPv4(adapter.NetworkInterfaceType);
                    Debug.WriteLine("Address：" + getCurrentConnectIP);
                    // 格式化显示MAC地址                
                    PhysicalAddress pa = adapter.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址
                    byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
                        if (i != bytes.Length - 1)
                        {
                            sb.Append("-");
                        }
                    }
                    Debug.WriteLine("MAC 地址：" + sb);
                    Debug.WriteLine("");
                    break;
                }
            }

            if (!string.IsNullOrEmpty(getCurrentConnectIP))
            {
                return getCurrentConnectIP;
            }
            string ipV4Addrress = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipV4Addrress = ip.ToString();
                }
            }

            if (!string.IsNullOrEmpty(ipV4Addrress))
            {
                return ipV4Addrress;
            }
            return string.Empty;
        }

        public static string GetLocalIPAddressByCmd()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                string strCmd = "ipconfig";
                process.Start();
                process.StandardInput.WriteLine(strCmd);
                string output = string.Empty;
                StringBuilder sb = new StringBuilder();
                string localIP = string.Empty;
                string containsEnUs = "Default Gateway";
                string containsZhCn = "默认网关";

                while (!process.StandardOutput.EndOfStream)
                {
                    output = process.StandardOutput.ReadLine().Trim();

                    if (output.Contains(containsEnUs) || output.Contains(containsZhCn))
                    {
                        string[] splitOutput = output.Split(':');
                        if (splitOutput.Length > 1 && !string.IsNullOrEmpty(splitOutput[1].Trim()))
                        {
                            if (!string.IsNullOrEmpty(localIP))
                            {
                                string[] getIps = localIP.Split(':');
                                if (getIps.Length > 1)
                                {
                                    var ipAddress = getIps[1].Trim();
                                    if (ipAddress.Contains("("))
                                    {
                                        ipAddress = ipAddress.Split('(')[0];
                                    }
                                    return ipAddress;
                                }
                            }
                        }
                    }
                    if (output.ToLower().Contains("IPv4"))
                    {
                        localIP = output.Trim();
                    }
                }
                process.Close();
                return output;
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog("GetLocalIPAddress():  " + e.Message, LogType.Error);
            }

            return string.Empty;
        }

        public static void DeleteFolder(string dir)
        {
            DirectoryInfo info = new DirectoryInfo(dir);
            if (!info.Exists)
            {
                return;
            }
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        DirectoryInfo d1 = new DirectoryInfo(d);
                        if (d1.GetFiles().Length != 0)
                        {
                            DeleteFolder(d1.FullName);
                        }
                        Directory.Delete(d);
                    }
                    catch
                    {

                    }
                }
            }
            Console.WriteLine("Delete Succeed!Time：" + DateTime.Now.ToString());
        }

        public static bool KillProcess(string processName, bool needVerify)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length == 0)
                {
                    return false;
                }
                foreach (Process p in ps0)
                {
                    p.Kill();
                    Thread.Sleep(500);
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
                return false;
            }
        }

        public static void AddStartUp()
        {
            string strAssName = Application.StartupPath + @"\" + Application.ProductName + @".exe";
            string strShortFileName = Application.ProductName;
            RegistryKey rgkRun = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (rgkRun == null)
            {
                rgkRun = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                rgkRun.SetValue(strShortFileName, strAssName);
            }
            else
            {
                object getStrAssName = new object();
                try
                {
                    getStrAssName = rgkRun.GetValue(strShortFileName);
                    if (getStrAssName == null)
                    {
                        rgkRun.SetValue(strShortFileName, strAssName);
                    }
                    else if (!getStrAssName.Equals(strAssName))
                    {
                        rgkRun.DeleteValue(strShortFileName);
                        rgkRun.SetValue(strShortFileName, strAssName);
                    }
                }
                catch (Exception ex)
                {
                    if (getStrAssName == null)
                    {
                        rgkRun.SetValue(strShortFileName, strAssName);
                    }

                    Logger.Instance.WriteLog(CommonConstStr.machineUserNameLog + "异常: " + ex.StackTrace
                        + GetClientDatetimeStr(), LogType.Warning); ;

                }
            }
        }

        static void CopyDirectory_CalcCount(string srcPath, string destPath, ref int fileCount)
        {
            try
            {
                if (!Directory.Exists(destPath))
                {
                    Directory.CreateDirectory(destPath);
                }
                DirectoryInfo dir = new DirectoryInfo(srcPath);
                FileSystemInfo[] fileinfo = dir.GetFileSystemInfos();
                foreach (FileSystemInfo i in fileinfo)
                {
                    if (i is DirectoryInfo)
                    {
                        if (!Directory.Exists(destPath + "\\" + i.Name))
                        {
                            Directory.CreateDirectory(destPath + "\\" + i.Name);
                        }
                        CopyDirectory_CalcCount(i.FullName, destPath + "\\" + i.Name, ref fileCount);
                    }
                    else
                    {
                        File.Copy(i.FullName, destPath + "\\" + i.Name, true);
                        fileCount++;
                    }
                }
            }
            catch (Exception e)
            {
            }
        }

        internal static ConcurrentQueue<string> TestQueueCommand = new ConcurrentQueue<string>();

        private static void ReceiveCommndFromTestClients()
        {
            Socket sSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            int port = 17777;
            try
            {
                string ipAddress = CommonConstStr.CurrentMachneIp;
                Console.WriteLine(ipAddress);
                IPAddress ip = IPAddress.Parse(ipAddress);
                IPEndPoint ipe = new IPEndPoint(ip, port);
                sSocket.Bind(ipe);
                sSocket.Listen(100);
                string dateTime = DateTime.Now.ToString("F");
                Console.WriteLine(dateTime + " Begin listen，Please wait");
                string newRecStr = string.Empty;
                string needBackupFile = string.Empty;
                byte[] recByte = new byte[4096];
                while (true)
                {
                    Socket serverSocket = sSocket.Accept();
                    dateTime = DateTime.Now.ToString("F");
                    int bytes = serverSocket.Receive(recByte, recByte.Length, 0);
                    newRecStr = Encoding.ASCII.GetString(recByte, 0, bytes);
                    Logger.Instance.WriteLog("Have Connected " + newRecStr, LogType.Success);
                    TestQueueCommand.Enqueue(newRecStr);
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Have Connected " + ex.StackTrace, LogType.Success);
                sSocket.Close();
            }
        }

        public static bool EmptyAFolder(string folder, List<string> exceptFolder = null)
        {
            try
            {
                if (Directory.Exists(folder))
                {
                    //delete all sub folder
                    foreach (string sf in Directory.GetDirectories(folder))
                    {
                        if (exceptFolder != null && exceptFolder.Contains(folder))
                        {
                            continue;
                        }
                        try
                        {
                            Directory.Delete(sf, true);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    //delete all file
                    foreach (string file in Directory.GetFiles(folder))
                    {
                        try
                        {
                            File.Delete(file);
                        }
                        catch (Exception ee)
                        {
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public static void RunTest()
        {
            BambooMultipleServer.StartBambooMultipleServer();
            LaunchNginx();
        }

        //public static void ThreadSetStatus()
        //{
        //    while (true)
        //    {
        //        GetRunningStatus();
        //        Thread.Sleep(5 * 60 * 1000);
        //    }
        //}

        public static void Shutdown()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams = mcWin32.GetMethodParameters("Win32Shutdown");
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown", mboShutdownParams, null);
            }
        }

        public static void GetRunningStatus()
        {
            CurrentTestMachineStatus request = new CurrentTestMachineStatus();

            if (IsRunning(CommonConstStr.nuint3ConsoleProcess))
            {
                request.TestMachineStatus = 0;
            }
            else
            {
                request.TestMachineStatus = 1;
            }

            if (request.TestMachineStatus.ToString() == ClientConfig.GetClientStatus())
            {
                return;
            }
            else
            {
                request.TestMachineIp = CommonConstStr.CurrentMachneIp;
                string responseStr = HttpRequest.SendPost(CommonConstStr.StatusInterface, JsonUtil.ToJSONStr(request));
                if (responseStr.Contains("20000"))
                {
                    ClientConfig.SetClientStatus(request.TestMachineStatus.ToString());
                }
            }
        }

        public static void RestartTestServer()
        {
            try
            {
                KillProcess(CommonConstStr.bambooProcess, true);
                KillProcess(CommonConstStr.nuint3ConsoleProcess, true);
                KillProcess(CommonConstStr.winappdriverProcess, true);
                KillProcess(CommonConstStr.multipleNginxProcess, true);
                KillProcess(CommonConstStr.multipleNginxProcess, true);

                if (File.Exists(CommonConstStr.OneToMoreClientPath))
                {
                    KillProcess(CommonConstStr.multipleClientsProcess, true);
                    File.Delete(CommonConstStr.OneToMoreClientPath);
                }
                // 判断新的 Multiple Client

                if (File.Exists(CommonConstStr.multipleNginxFolder))
                {
                    KillProcess(CommonConstStr.multipleNginxProcess, true);
                    LaunchNginx();
                }

                if (Directory.Exists(CommonConstStr.bambooRootDir))
                {
                    // Kill Bamboo
                    KillProcess(CommonConstStr.nuint3ConsoleProcess, true);
                    KillProcess(CommonConstStr.bambooProcess, true);
                    DeleteFolder(CommonConstStr.bambooBuildDir);
                    DeleteFolder(CommonConstStr.bambooCacheDir);
                    DeleteFolder(CommonConstStr.bambooLogDir);
                    DeleteFolder(CommonConstStr.bambooTempDir);
                    DeleteFolder(CommonConstStr.bambooCacheDir);
                    // Start Bamboo
                    if (File.Exists(CommonConstStr.bambooAgentBatFile))
                    {
                        StartProcess(CommonConstStr.bambooAgentBatFile);
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public static void RebootMachine()
        {
            Process.Start("shutdown.exe", "-r -t 0");
        }

        public static void RunCmd(string cmdStr, string tempFile)
        {
            try
            {
                var processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + cmdStr)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    Verb = "runas"
                };
                Process process = new Process
                {
                    StartInfo = processInfo
                };
                process.Start();
                Thread.Sleep(5000);

                string output = process.StandardOutput.ReadLine() + "\r\n";
                File.AppendAllText(tempFile, output);
                while (!process.StandardOutput.EndOfStream)
                {
                    output = process.StandardOutput.ReadLine() + "\r\n";
                    File.AppendAllText(tempFile, output);
                }
                process.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        // Send Response to TestServer
        public static void RunCmdByUI(string cmdStr)
        {
            try
            {
                Logger.Instance.WriteLog("Run Command : " + cmdStr, LogType.Information);
                switch (cmdStr)
                {
                    case "GetRunningStatus":
                        GetRunningStatus();
                        break;
                    case "clearMachinesCache":
                        RestartTestServer();
                        break;
                    case "clearMachinesCacheReboot":
                        RestartTestServer();
                        RebootMachine();
                        break;
                    case "SetMachinesShutDown":
                        Shutdown();
                        break;
                    case "SetRerun":
                        string runStr = File.ReadAllText(CommonConstStr.CommandFile);
                        BambooMultipleServer.RunCases(runStr);
                        break;
                }
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("Run Command Exception: " + ex.StackTrace + "Command :" + cmdStr, LogType.Failure);
            }
        }


        private static void RunCommand()
        {
            string newRecStr = string.Empty;
            while (true)
            {
                if (TestQueueCommand.Count > 0)
                {
                    bool tryGetReceiveCommand = TestQueueCommand.TryDequeue(out newRecStr);
                    if (!tryGetReceiveCommand) continue;
                    RunCmdByUI(newRecStr);
                }
                Thread.Sleep(3000);
            }
        }

        public static void RunReceiveCommand()
        {
            Thread receiveCommandThread = new Thread(ReceiveCommndFromTestClients);
            receiveCommandThread.IsBackground = true;
            Thread runCommandThread = new Thread(RunCommand);
            runCommandThread.IsBackground = true;

            Thread upgradeThread = new Thread(UpgradeClient);
            upgradeThread.IsBackground = true;
            upgradeThread.Priority = ThreadPriority.BelowNormal;

            receiveCommandThread.Start();
            runCommandThread.Start();
            upgradeThread.Start();
        }

        internal static bool IsRunning(string processName)
        {
            Process[] ps0 = Process.GetProcessesByName(processName);
            if (ps0.Length == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static void DeleteServenLogs(string logDateDirectory, int subDay)
        {
            try
            {
                if (!Directory.Exists(logDateDirectory))
                {
                    return;
                }
                DirectoryInfo directoryInfo = new DirectoryInfo(logDateDirectory);
                DirectoryInfo[] allDirectory = directoryInfo.GetDirectories();
                DateTime nowDate = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd"));

                foreach (DirectoryInfo dir in allDirectory)
                {
                    int dirIndex = Convert.ToInt32(dir.Name);
                    if (dirIndex > 7)
                    {
                        Directory.Delete(dir.FullName, true);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

        }

        public static void UpgradeClient()
        {
            // 更新 exe
            while (true)
            {
                try
                {
                    GetUpgradeResourcesRequ request = new GetUpgradeResourcesRequ();

                    string clientName = Application.ProductName;
                    request.clientName = clientName;
                    string downloadBkStr = "downloadbk";
                    string saveClientName = clientName + downloadBkStr;

                    request.version = ClientConfig.GetClientVersion();
                    request.clientId = ClientConfig.GetClientId();
                    string responseStr = HttpRequest.SendPost(CommonConstStr.UpgradeInterface, JsonUtil.ToJSONStr(request));

                    if (responseStr.Contains("upgradeserver"))
                    {

                        AutotestUpgrade response = JsonUtil.FromJSONClass<AutotestUpgrade>(responseStr);

                        if (response.version == ClientConfig.GetClientVersion())
                        {
                            return;
                        }

                        HttpRequest.DownloadFile(response.upgradeserver, saveClientName);


                        if (File.Exists(saveClientName))
                        {
                            ClientConfig.SetClientVersion(response.version);
                            RunProcess(CommonConstStr.ExternalProcaseePath, "update ");
                            Logger.Instance.WriteLog(CommonConstStr.machineUserNameLog + " Upgrade Successed  " + GetClientDatetimeStr(), LogType.Information);
                        }
                    }
                    else
                    {
                    }

                }
                catch (Exception ex)
                {

                }

                Thread.Sleep(5 * 60 * 1000);
            }
        }


        /// <summary>
        /// 快捷方式名称-任意自定义
        /// </summary>
        private const string QuickName = "LenovoMultipleClient";

        /// <summary>
        /// 自动获取系统自动启动目录
        /// </summary>
        private static string systemStartPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Startup); } }

        /// <summary>
        /// 自动获取程序完整路径
        /// </summary>
        private static string appAllPath { get { return Process.GetCurrentProcess().MainModule.FileName; } }

        /// <summary>
        /// 设置开机自动启动-只需要调用改方法就可以了参数里面的bool变量是控制开机启动的开关的，默认为开启自启启动
        /// </summary>
        /// <param name="onOff">自启开关</param>
        public static void SetMeAutoStart(bool onOff = true)
        {
            if (onOff)//开机启动
            {
                //获取启动路径应用程序快捷方式的路径集合
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                //存在2个以快捷方式则保留一个快捷方式-避免重复多于
                if (shortcutPaths.Count >= 1)
                {
                    for (int i = 0; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
                shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                if (shortcutPaths.Count <= 0)//不存在则创建快捷方式
                {
                    CreateShortcut(systemStartPath, QuickName, appAllPath, "LenovoMultipleClient");
                }
            }
            else//开机不启动
            {
                //获取启动路径应用程序快捷方式的路径集合
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                //存在快捷方式则遍历全部删除
                if (shortcutPaths.Count > 0)
                {
                    for (int i = 0; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
            }
            //创建桌面快捷方式-如果需要可以取消注释
            //CreateDesktopQuick(desktopPath, QuickName, appAllPath);
        }

        /// <summary>
        ///  向目标路径创建指定文件的快捷方式
        /// </summary>
        /// <param name="directory">目标目录</param>
        /// <param name="shortcutName">快捷方式名字</param>
        /// <param name="targetPath">文件完全路径</param>
        /// <param name="description">描述</param>
        /// <param name="iconLocation">图标地址</param>
        /// <returns>成功或失败</returns>
        private static bool CreateShortcut(string directory, string shortcutName, string targetPath, string description = null, string iconLocation = null)
        {
            try
            {
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);                         //目录不存在则创建
                //添加引用 Com 中搜索 Windows Script Host Object Model
                string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));          //合成路径
                WshShell shell = new IWshRuntimeLibrary.WshShell();
                IWshShortcut shortcut = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(shortcutPath);    //创建快捷方式对象
                shortcut.TargetPath = targetPath;                                                               //指定目标路径
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);                                  //设置起始位置
                shortcut.WindowStyle = 1;                                                                       //设置运行方式，默认为常规窗口
                shortcut.Description = description;                                                             //设置备注
                shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;    //设置图标路径
                shortcut.Save();                                                                                //保存快捷方式
                return true;
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
                temp = "";
            }
            return false;
        }

        /// <summary>
        /// 获取指定文件夹下指定应用程序的快捷方式路径集合
        /// </summary>
        /// <param name="directory">文件夹</param>
        /// <param name="targetPath">目标应用程序路径</param>
        /// <returns>目标应用程序的快捷方式</returns>
        private static List<string> GetQuickFromFolder(string directory, string targetPath)
        {
            List<string> tempStrs = new List<string>();
            tempStrs.Clear();
            string tempStr = null;
            string[] files = Directory.GetFiles(directory, "*.lnk");
            if (files == null || files.Length < 1)
            {
                return tempStrs;
            }
            for (int i = 0; i < files.Length; i++)
            {
                //files[i] = string.Format("{0}\\{1}", directory, files[i]);
                tempStr = GetAppPathFromQuick(files[i]);
                if (tempStr == targetPath)
                {
                    tempStrs.Add(files[i]);
                }
            }
            return tempStrs;
        }

        /// <summary>
        /// 获取快捷方式的目标文件路径-用于判断是否已经开启了自动启动
        /// </summary>
        /// <param name="shortcutPath"></param>
        /// <returns></returns>
        private static string GetAppPathFromQuick(string shortcutPath)
        {
            //快捷方式文件的路径 = @"d:\Test.lnk";
            if (System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortct = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                //快捷方式文件指向的路径.Text = 当前快捷方式文件IWshShortcut类.TargetPath;
                //快捷方式文件指向的目标目录.Text = 当前快捷方式文件IWshShortcut类.WorkingDirectory;
                return shortct.TargetPath;
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 根据路径删除文件-用于取消自启时从计算机自启目录删除程序的快捷方式
        /// </summary>
        /// <param name="path">路径</param>
        private static void DeleteFile(string path)
        {
            FileAttributes attr = System.IO.File.GetAttributes(path);
            if (attr == FileAttributes.Directory)
            {
                Directory.Delete(path, true);
            }
            else
            {
                System.IO.File.Delete(path);
            }
        }

        /// <summary>
        /// 在桌面上创建快捷方式-如果需要可以调用
        /// </summary>
        /// <param name="desktopPath">桌面地址</param>
        /// <param name="appPath">应用路径</param>
        public void CreateDesktopQuick(string desktopPath = "", string quickName = "", string appPath = "")
        {
            List<string> shortcutPaths = GetQuickFromFolder(desktopPath, appPath);
            //如果没有则创建
            if (shortcutPaths.Count < 1)
            {
                CreateShortcut(desktopPath, quickName, appPath, "软件描述");
            }
        }


    }
}
