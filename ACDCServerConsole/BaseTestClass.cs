using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace LenovoVantageTest.Utility
{
    public class BaseSessionTestClass
    {
        private const string windowsApplicationDriverUrl = "http://127.0.0.1:4723";
        private const string WADIp = "127.0.0.1";
        private const string WADPort = "4723";
        private const string wadPath = "C:\\Program Files (x86)\\Windows Application Driver\\WinAppDriver.exe";

        private static BaseSessionTestClass _instance = null;

        /// <summary>
        /// Prevents a default instance of the 
        /// <see cref="Singleton"/> class from being created.
        /// </summary>
        public BaseSessionTestClass()
        {
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static BaseSessionTestClass Instance
        {
            get { return _instance ?? (_instance = new BaseSessionTestClass()); }
        }

        protected static WindowsDriver<WindowsElement> session;
        protected static RemoteTouchScreen touchScreen;

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

        public WindowsDriver<WindowsElement> DesktopSession()
        {
            if (session == null || touchScreen == null)
            {
                // Create a new session to bring up the application by application ID
                StartWinAppDriver();
                AppiumOptions opt = new AppiumOptions();
                opt.AddAdditionalCapability("app", "Root");
                opt.AddAdditionalCapability("deviceName", "WindowsPC");
                session = new WindowsDriver<WindowsElement>(new Uri(windowsApplicationDriverUrl), opt);
            }

            return session;
        }
    }
}
