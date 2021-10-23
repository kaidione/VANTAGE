namespace LenovoVantageTest.Foundation
{
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using System;


    public class Utility
    {
        private static WindowsDriver<WindowsElement> orphanedSession;

        private static WindowsElement orphanedElement;

        private static string orphanedWindowHandle;

        ~Utility()
        {
            CleanupOrphanedSession();
        }

        public static WindowsDriver<WindowsElement> CreateNewSession(string appId, string argument = null)
        {
            AppiumOptions opt = new AppiumOptions();
            opt.AddAdditionalCapability("app", appId);
            opt.AddAdditionalCapability("deviceName", "WindowsPC");

            if (argument != null)
            {
                opt.AddAdditionalCapability("appArguments", argument);
            }
            return new WindowsDriver<WindowsElement>(new Uri(CommonTestSettings.WindowsApplicationDriverUrl), opt);
        }

        public static bool CurrentWindowIsAlive(WindowsDriver<WindowsElement> remoteSession)
        {
            bool windowIsAlive = false;

            if (remoteSession != null)
            {
                try
                {
                    windowIsAlive = !string.IsNullOrEmpty(remoteSession.CurrentWindowHandle) && remoteSession.CurrentWindowHandle != "0";
                    windowIsAlive = true;
                }
                catch
                {
                }
            }
            return windowIsAlive;
        }

        private static void CleanupOrphanedSession()
        {
            orphanedWindowHandle = null;
            orphanedElement = null;

            // Cleanup after the session if exists
            if (orphanedSession != null)
            {
                orphanedSession.Quit();
                orphanedSession = null;
            }
        }
    }
}

