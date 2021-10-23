using System;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace winformUI.Common
{
    public static class CommonConstStr
    {
        public static string loginUserName = string.Empty;

        public static string machineUserNameLog
        {
            get
            {
                return Environment.UserName;
            }
        }

        public const string DateTimeFormat = "yyyy_MM_dd HH_mm_ss";
        public const string LogDateTimeFormat = "yyyyMMdd_HHmmss";
        public static string CurrentMachneIp = "";
        public static string CommonAutomationFolder = @"C:\LenovoAutomationTest\nginx\html\common";

        public const string OneToMoreClientName = "LenovoMultipleClient";
        public const string OneToMoreClientPath = @"C:\LenovoVantageTest\BambooMultipleServer.exe";

        public const string PushTestReport = "client/pushTestReport";
        public const string DownloadResourceInterface = "AutoTest/UpgradeResources";
        public const string UpgradeInterface = "client/getUpgradeResources";

        ///client/getUpgradeResources
        public const string StatusInterface = "client/getTestMachineStatus";

        public static string DownloadFileSavePath = Application.StartupPath;
        public static string ExternalProcaseePath = Path.Combine(Application.StartupPath, "updateClient.exe");

        public static string UserFileName = Path.Combine(Application.StartupPath, "user.xml");

        public static string TaskPoolFolder = Application.StartupPath;
        //E:\Auto\vantage-uwp-automation-bj\MultipleClient\MultipleClientConfig.xml
        public static string TaskPoolFile = Path.Combine(TaskPoolFolder, "MultipleClientConfig.xml");
        public static DateTime ServerDateTime;
        public static Stopwatch ClientStopwatch = new Stopwatch();
        public static bool CurrentMachinIsX64 = false;

        // Regedit Path 
        public const string LocalMachineCurrentVersionRegPath = @"SOFTWARE\Microsoft\Windows NT\CurrentVersion\";

        public const string LogFilePath = @"C:\AutomationTestResult";
        public const string LogDirectory = @"C:\AutomationTestResult\log";


        public static string UserPath = Environment.GetEnvironmentVariable("USERPROFILE");
        public static string bambooRootDir = Path.Combine(UserPath, "bamboo-agent-home");
        public const string defaultPath = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\Bamboo Automated Environment.url";

        public const string startPath = @"%USERPROFILE%\AppData\Roaming\Microsoft\Windows\Start Menu\Programs\Startup\Bamboo Automated Environment.url";


        public const string VantageLogDir = @"C:\VantageTestLogs";
        public const string PowerMgrFile = @"C:\Windows\SysWOW64\Lenovo\PowerMgr\PowerMgr.exe";

        public static string bambooBuildDir = Path.Combine(bambooRootDir, @"xml-data\build-dir");
        public static string bambooCacheDir = Path.Combine(bambooRootDir, @"caches");
        public static string bambooLogDir = Path.Combine(bambooRootDir, @"logs");
        public static string bambooTempDir = Path.Combine(bambooRootDir, @"temp");
        public static string bambooAgentBatFile = Path.Combine(bambooRootDir, @"bin\BambooAgent.bat");

        public static string multipleNginxFolder
        {
            get
            {
                if (Directory.Exists(CommonAutomationFolder))
                {
                    return @"C:\LenovoAutomationTest\nginx";
                }
                return @"C:\LenovoVantageTest\nginx";
            }
        }

        public const string bambooProcess = "wrapper";
        public const string winappdriverProcess = "WinAppDriver";
        public const string nuint3ConsoleProcess = "nunit3-console";
        public const string TGitCacheProcess = "TGitCache";
        public const string PowerMgrProcess = "PowerMgr";
        public const string multipleClientsProcess = "BambooMultipleServer";
        public const string multipleNginxProcess = "nginx";

        public static bool LenovoOneToMoreFlag = false;

        public static string CommandFile
        {
            get
            {
                if (Directory.Exists(CommonAutomationFolder))
                {
                    return @"C:\LenovoAutomationTest\nginx\www\Command.txt";
                }
                return @"C:\LenovoVantageTest\nginx\www\Command.txt";
            }
        }

        //tempFile
        public const string tempFile = "log.txt";

        public static bool Is64BiteOS
        {
            get
            {
                SelectQuery query = new SelectQuery("select AddressWidth from Win32_Processor");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                ManagementObjectCollection moCollection = searcher.Get();
                bool checkResult = false;
                foreach (ManagementObject mo in moCollection)
                {
                    foreach (PropertyData property in mo.Properties)
                    {
                        if (property.Name.Equals("AddressWidth"))
                        {
                            if (property.Value.ToString() == "64")
                            {
                                checkResult = true;
                                CurrentMachinIsX64 = true;
                            }
                            else
                            {
                                checkResult = false;
                            }
                            break;
                        }
                    }
                }
                searcher.Dispose();
                moCollection.Dispose();
                return checkResult;
            }
        }

        public static string MultipleClientConfig
        {
            get
            {
                return @".\MultipleClientConfig.xml";
            }
        }
    }
}
