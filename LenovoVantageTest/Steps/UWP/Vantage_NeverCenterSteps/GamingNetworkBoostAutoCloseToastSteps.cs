using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingNetworkBoostAutoCloseToastSteps : SettingsBase
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingNetworkBoostAutoCloseToastSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Clean Auto Close And Network Boost Registry Key Under Toast")]
        public void GivenCleanAutoCloseAndNetworkBoostRegistryKeyUnderToast()
        {
            if (RegistryHelp.IsRegistrySubKeyExist(VantageConstContent.RegistryNetworkBoost))
            {
                RegistryHelp.DeleteRegistrySubKey(VantageConstContent.RegistryNetworkBoost);
            }
            if (RegistryHelp.IsRegistrySubKeyExist(VantageConstContent.RegistryAutoClose))
            {
                RegistryHelp.DeleteRegistrySubKey(VantageConstContent.RegistryAutoClose);
            }
        }

        [Given(@"Clean Registry Key Toast")]
        public void GivenCleanRegistryKeyToast()
        {
            if (RegistryHelp.IsRegistrySubKeyExist(VantageConstContent.RegistryToast))
            {
                RegistryHelp.DeleteRegistrySubKey(VantageConstContent.RegistryToast);
            }
        }

        [Given(@"Clean Messaging History File")]
        public void GivenCleanMessagingHistoryFile()
        {
            if (File.Exists(VantageConstContent.MessagingHistoryData))
            {
                File.Delete(VantageConstContent.MessagingHistoryData);
                Assert.IsFalse(File.Exists(VantageConstContent.MessagingHistoryData), "Fail to delete messaging history file.");
            }
        }

        [Given(@"(.*) Toast Message Was Shown For The (.*) Time And Click The Ignore Button")]
        public void GivenToastMessageWasShownForTheTimeAndClickTheIgnoreButton(string p0, int p1)
        {
            p0 = (p0 + "ShownTimes").Replace(" ", "");
            int times = Convert.ToInt32(RegistryHelp.GetRegistryKeyValue(VantageConstContent.RegistryKeyMap[p0]));
            Assert.IsTrue(times == p1, p0 + " toast message was shown for the " + p1.ToString() + " time. But was " + times + " time.");
        }

        [Given(@"Network Boost Driver Is Not Installed")]
        public void GivenNetworkBoostDriverIsNotInstalled()
        {
            int timeout = 0;
            while (true)
            {
                if (VantageCommonHelper.DriverPackageExists(VantageConstContent.GamingFeatureDriverDesc) == false)
                {
                    break;
                }
                else if (timeout > 5)
                {
                    Assert.Fail("Network boost driver is installed");
                }
                timeout++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        [Given(@"Network Boost Driver Is Installed")]
        public void GivenNetworkBoostDriverIsInstalled()
        {
            int timeout = 0;
            if (VantageCommonHelper.DriverPackageExists(VantageConstContent.GamingFeatureDriverDesc) == false)
            {
                Process.Start(VantageConstContent.GamingFeatureDriverSetup);
            }
            while (VantageCommonHelper.DriverPackageExists(VantageConstContent.GamingFeatureDriverDesc) == false)
            {
                if (timeout > 10)
                {
                    Assert.Fail("Failed to install Network Boost Driver");
                }
                timeout++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }

        [Given(@"Adjust The System Time To (.*) Days Later")]
        public void GivenAdjustTheSystemTimeToDaysLater(int p0)
        {
            string strDateTime = DateTime.Now.AddDays(Convert.ToDouble(p0)).ToString();
            Common.SetSystemDateTime(strDateTime);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [Given(@"Set System Time Automatically To Sync")]
        public void GivenSetSystemTimeAutomaticallyToSync()
        {
            Thread.Sleep(5000);
            Common.SetSystemTimeAutomatically(true);
            Thread.Sleep(5000);
            string strDateTime = DateTime.Now.ToString();
            Common.SetSystemDateTime(strDateTime);
            Common.SetSystemTimeAutomatically(true);
        }

        [Given(@"Restart Windows Time Service")]
        public void GivenRestartWindowsTimeService()
        {
            Thread.Sleep(5000);
            VantageCommonHelper.ServiceControl(VantageConstContent.WindowsTimeServiceName, 1);
            VantageCommonHelper.ServiceControl(VantageConstContent.WindowsTimeServiceName, 0);
            Thread.Sleep(5000);
        }

        [Given(@"Uninstall The Network Boost Driver")]
        public void GivenUninstallTheNetworkBoostDriver()
        {
            string devcon = Environment.Is64BitOperatingSystem ? "devcon_64.exe" : "devcon_32.exe";
            VantageCommonHelper.RunCmd(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\" + devcon) + @"  remove Root\{A8E2977E-B102-4C80-A01F-C162DEF2E495}");
        }

        [When(@"No Any Operation For About (.*)S")]
        public void WhenNoAnyOperationForAboutS(int p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(p0));
        }

        [When(@"Click The (.*) Button (.*)")]
        public void WhenClickTheIgnoreButton(string p0, string p1)
        {
            Thread.Sleep(3000);
            HSSmartAssistPage hs = new HSSmartAssistPage(null);
            int timeOut = 0;
            Dictionary<string, string> pairs = new Dictionary<string, string>();
            if (p1.Trim().ToLower() == "new notification")
            {
                IntPtr intptr = UnManagedAPI.FindWindow("Windows.UI.Core.CoreWindow", "New notification");
                UnManagedAPI.RECT rect = new UnManagedAPI.RECT();
                UnManagedAPI.GetWindowRect(intptr, ref rect);
                VantageCommonHelper.SetMouseClick((rect.Left + 100).ToString(), (rect.Top + 100).ToString(), true);
                while (timeOut < 20)
                {
                    timeOut++;
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    intptr = UnManagedAPI.FindWindow("Windows.UI.Core.CoreWindow", "New notification");
                    UnManagedAPI.GetWindowRect(intptr, ref rect);
                    VantageCommonHelper.SetMouseClick((rect.Left + 100).ToString(), (rect.Top + 100).ToString(), true);
                }
            }

            WindowsDriver<WindowsElement> desktopSession = hs.GetControlPanelSession(true);
            List<WindowsElement> elements = FindElementsByTimes(desktopSession, "XPath", p0.Trim().ToLower() == "move this notification to action center" ? VantageConstContent.DismissBtn : VantageConstContent.ToastBtn);
            timeOut = 0;
            while (elements == null)
            {
                desktopSession = hs.GetControlPanelSession(true);
                elements = FindElementsByTimes(desktopSession, "XPath", p0.Trim().ToLower() == "move this notification to action center" ? VantageConstContent.DismissBtn : VantageConstContent.ToastBtn);
                if (timeOut > 10)
                {
                    break;
                }
                timeOut++;
            }
            Assert.NotZero(elements.Count, "Lenovo Vantage Toast Button total is 0");
            bool isClick = false;


            foreach (WindowsElement element in elements)
            {
                if (element.GetAttribute("Name").Trim().ToLower() == p0.Trim().ToLower())
                {
                    element.Click();
                    isClick = true;
                    break;
                }
            }
            Assert.IsTrue(isClick, "The Lenovo Vantage Toast Button click fail.");
            Thread.Sleep(TimeSpan.FromSeconds(4));
        }

        [When(@"ReLaunch Lenovo Vantage For Toast Message")]
        public void WhenReLaunchLenovoVantageForToastMessage()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
        }

        [When(@"Check The Toast Message")]
        public void WhenCheckTheToastMessage()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            SettingsBase.FindAndClickNotificationCenter(20);
        }

        [Then(@"(.*) Message Should (.*)")]
        public void ThenMessageShould(string p0, string p1)
        {
            if (p1 == "Be Shown")
            {
                Assert.IsTrue(VantageCommonHelper.CheckToastPopUp(p0, p1), p0 + " should " + p1);
            }
            else if (p1 == "Not Be Shown")
            {
                Assert.IsFalse(VantageCommonHelper.CheckToastPopUp(p0, p1), p0 + " should " + p1);
            }
        }
    }
}
