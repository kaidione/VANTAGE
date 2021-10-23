using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingReskinWiFiSecurityEntranceSteps : SettingsBase
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private HSSmartAssistPage _hSSmartAssist;
        private WindowsDriver<WindowsElement> _appsession;

        public GamingReskinWiFiSecurityEntranceSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"System notifications is disabled")]
        public void GivenSystemNotificationsIsDisabled()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Process.Start("ms-settings:notifications");
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            _appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement typeElement = FindElementByTimes(_appsession, "XPath", @"//*[@AutomationId='SystemSettings_Notifications_ShowAppNotifications_ToggleSwitch']");
            SetCheckBoxStatus(typeElement, ToggleState.Off, _webDriver.Session);
            Common.KillProcess("SystemSettings", true);
        }

        [Given(@"System notifications is enabled")]
        public void GivenSystemNotificationsIsEnabled()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Process.Start("ms-settings:notifications");
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            _appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement typeElement = FindElementByTimes(_appsession, "XPath", @"//*[@AutomationId='SystemSettings_Notifications_ShowAppNotifications_ToggleSwitch']");
            SetCheckBoxStatus(typeElement, ToggleState.On, _webDriver.Session);
            Common.KillProcess("SystemSettings", true);
        }

        [Given(@"WiFi Security plugin exist")]
        public void GivenWiFiSecurityPluginExist()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(Directory.Exists(@"C:\ProgramData\Lenovo\ImController\Plugins\LenovoWiFiSecurityPlugin"));
        }

        [Given(@"WiFi Security Display in homepage")]
        public void GivenWiFiSecurityDisplayInHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsWiFiSecurityIcon);
        }

        [Given(@"Dobly not supported")]
        public void GivenDoblyNotSupported()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.QuickSettingsDolbyIcon);
        }

        [Then(@"WiFi Security is at the bottom in Quick Settings section")]
        public void ThenWiFiSecurityIsAtTheBottomInQuickSettingsSection()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode, _nerveCenterPages.GamingQuickSettingsToggleList.Last(), "WiFi Security is not at the bottom in Quick Settings section");
        }

        [Given(@"Dobly supported")]
        public void GivenDoblySupported()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon);
        }

        [Then(@"WiFi Security is above of Dolby")]
        public void ThenWiFiSecurityIsAboveOfDolby()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsWiFiSecurityIcon);
            WindowsElement WiFiPosition = _nerveCenterPages.QuickSettingsWiFiSecurityIcon;
            int y = WiFiPosition.Location.Y + WiFiPosition.Rect.Height / 2;
            WindowsElement DolbyPosition = _nerveCenterPages.QuickSettingsDolbyIcon;
            int _y = DolbyPosition.Location.Y + DolbyPosition.Rect.Height / 2;
            Assert.Less(y, _y);
        }

        [Then(@"The WiFi Security gear icon is displayed before the toggle")]
        public void ThenTheWiFiSecurityGearIconIsDisplayedBeforeTheToggle()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsWiFiSecurityIcon);
            WindowsElement gearPosition = _nerveCenterPages.QuickSettingsWiFiSecurityIcon;
            int x = gearPosition.Location.X + gearPosition.Rect.Width / 2;
            WindowsElement togglePosition = _nerveCenterPages.QuickSettingsWiFiSecurityToggleMode;
            int _x = togglePosition.Location.X + togglePosition.Rect.Width / 2;
            Assert.Less(x, _x);
        }

        [When(@"Click the WiFi Security Gear Icon")]
        public void WhenClickTheWiFiSecurityGearIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var quickSettingsWiFiSecurityIconEle = _nerveCenterPages.QuickSettingsWiFiSecurityIcon;
            Assert.IsNotNull(quickSettingsWiFiSecurityIconEle, "quickSettingsWiFiSecurityIconEle is null");
            quickSettingsWiFiSecurityIconEle.Click();
        }

        [Then(@"The WiFi Security toggle status within homepage '(.*)'")]
        public void ThenTheWiFiSecurityToggleStatusWithinHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode);
            string message = string.Format("The WiFi Security toggle is {0} not found", status);
            Assert.IsTrue(_nerveCenterPages.ShowTextbox(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode).Contains(status), message);
        }

        [Given(@"Turn on or off WiFi Security toggle within homepage '(.*)'")]
        public void GivenTurnOnOrOffWiFiSecurityToggleWithinHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode, "the QuickSettingsWiFiSecurityToggleMode not found");
            switch (status.ToLower())
            {
                case "on":
                    if (_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode.GetAttribute("AutomationId").Contains(status.ToLower()) == false)
                    {
                        _nerveCenterPages.QuickSettingsWiFiSecurityToggleMode.Click();
                    }
                    Assert.NotNull(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOn, "turn on QuickSettingsWiFiSecurityToggle fail");
                    break;
                case "off":
                    if (_nerveCenterPages.QuickSettingsWiFiSecurityToggleMode.GetAttribute("AutomationId").Contains(status.ToLower()) == false)
                    {
                        _nerveCenterPages.QuickSettingsWiFiSecurityToggleMode.Click();
                    }
                    Assert.NotNull(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOff, "turn off QuickSettingsWiFiSecurityToggle fail");
                    break;
                default:
                    Assert.Fail("GivenTurnOnOrOffWiFiSecurityToggleWithinHomepage() no run");
                    break;
            }
        }

    }
}
