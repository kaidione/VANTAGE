using LenovoVantageTest.Pages.HardwareSettingsPages;
using NUnit.Framework;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LenovoVantageTest.Utility
{

    public class BaseTestClass
    {
        private const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WADIp = "127.0.0.1";
        private const string WADPort = "4723";
        private const string wadPath = "C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe";


        protected static WindowsDriver<WindowsElement> session;
        protected static RemoteTouchScreen touchScreen;

        public InformationalWebDriver LaunchWinApplication(string appId)
        {
            if (session == null || touchScreen == null)
            {
                string exePath = @"C:\Program Files (x86)\Windows Application Driver\WinAppDriver.exe";
                if (!File.Exists(exePath))
                {
                    Console.WriteLine(string.Format("The Path {0} is null.", exePath));
                    return null;
                }

                Process[] process = Process.GetProcessesByName("WinAppDriver");
                if (process.Length == 0)
                {
                    Process.Start(exePath);
                    Thread.Sleep(3000);
                }

                try
                {
                    for (int i = 0; i < 5; i++) // try 5 times for vantage
                    {
                        if (appId.Contains("E046963F.Lenovo") == false)
                        {
                            break;
                        }
                        Process.Start(@"shell:AppsFolder\" + appId);  //Launch App Via Command
                        Thread.Sleep(TimeSpan.FromSeconds(5));
                        string packeageName = string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
                        string companionLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName);
                        LogHelper.Logger.Instance.WriteLog(File.ReadAllText(companionLogPath));
                        string windowsName = VantageConstContent.VantageTypePlan != VantageConstContent.VantageType.LE
                            ? Constants.VantageTitle : Constants.VantageLETitle;
                        IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", windowsName);
                        if (intPtr != IntPtr.Zero)
                        {
                            break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

                // Create a new session to bring up the application by application ID
                AppiumOptions opt = new AppiumOptions();
                opt.AddAdditionalCapability("app", appId);
                opt.AddAdditionalCapability("deviceName", "WindowsPC");
                try
                {

                    session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), opt);
                    // Identify the current window handle. You can check through inspect.exe which window this is.
                    var currentWindowHandle = session.CurrentWindowHandle;

                    // Wait for 5 seconds or however long it is needed for the right window to appear/for the splash screen to be dismissed
                    Thread.Sleep(TimeSpan.FromSeconds(5));

                    // Return all window handles associated with this process/application.
                    // At this point hopefully you have one to pick from. Otherwise you can
                    // simply iterate through them to identify the one you want.
                    var allWindowHandles = session.WindowHandles;

                    // Assuming you only have only one window entry in allWindowHandles and it is in fact the correct one,
                    // switch the session to that window as follows. You can repeat this logic with any top window with the same
                    // process id (any entry of allWindowHandles)

                    session.SwitchTo().Window(allWindowHandles[0]);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), opt);
                }

                Assert.IsNotNull(session);

                Thread.Sleep(TimeSpan.FromSeconds(5));
                try
                {
                    session.Manage().Window.Maximize();
                }
                catch (InvalidOperationException)
                {

                }
            }

            return new InformationalWebDriver(session, session);
        }

        public WindowsDriver<WindowsElement> LaunchApplication(string appId)
        {
            try
            {
                AppiumOptions appCapabilities = new AppiumOptions();
                appCapabilities.AddAdditionalCapability("app", appId);
                appCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
                appCapabilities.AddAdditionalCapability("ms:waitForAppLaunch", "60");
                session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), appCapabilities);
                Thread.Sleep(TimeSpan.FromSeconds(5));
                session.Manage().Window.Maximize();
                return session;
            }
            catch (Exception ex)
            {
                Console.WriteLine("LaunchApplication: " + ex.Message);
                return null;
            }
        }

        public InformationalWebDriver DesktopSession()
        {
            if (session == null || touchScreen == null)
            {
                // Create a new session to bring up the application by application ID
                AppiumOptions opt = new AppiumOptions();
                opt.AddAdditionalCapability("app", "Root");
                opt.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), opt);
            }

            return new InformationalWebDriver(session, session);
        }

        public void KillProccess(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }

        public static void StartWinAppDriver()
        {
            string proName = "WinAppDriver";
            Process[] ps = Process.GetProcessesByName(proName);
            if (ps.Length > 0)
            {
                return;
            }
            if (File.Exists(wadPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo(wadPath);
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
                startInfo.Arguments = WADIp + " " + WADPort;
                //Process.Start(wadPath, WADIp + " " + WADPort);          
                Process.Start(startInfo);
            }
        }

        public bool proccessIsExsitInTaskManager(string name)
        {
            Process[] processes = Process.GetProcessesByName(name);

            foreach (Process process in processes)
            {
                process.Dispose();
                return true;
            }
            return false;
        }
    }
}
