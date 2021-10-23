using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class QuickSettingsLeSteps : SettingsBase
    {
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HSAudioSettingsPage _hSAudioSettingsPage;
        private InformationalWebDriver _webDriver;
        public WindowsElement HoverEle = null;
        private ToggleState cameraToggle = ToggleState.Indeterminate;

        public QuickSettingsLeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Send ""(.*)"" Keys ""(.*)"" times")]
        public void GivenSendKeysTimes(string p0, int p1)
        {
            for (int i = p1; i > 0; i--)
            {
                SendKeys.SendWait(p0);
            }
        }

        [When(@"Hover the mouse on ""(.*)""")]
        public void WhenHoverTheMouseOn(string p0)
        {
            HoverEle = FindElementByTimes(_webDriver.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile(p0));
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, HoverEle);
        }

        [Then(@"Find the Mic access button ""(.*)""")]
        public void ThenFindTheMicAccessButton(string p0)
        {
            WindowsElement micAccessButton = null;
            if (p0 == "Null")
            {
                micAccessButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 5, false, 5);
                Assert.IsNull(micAccessButton, "The micAccessButton button is  find");
            }
            else
            {
                micAccessButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 15, false, 60);
                Assert.IsNotNull(micAccessButton, "The micAccessButton button is not find");
            }
        }

        [Then(@"Click Mic access button")]
        public void ThenClickMicAccessButton()
        {
            WindowsElement micAccessButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button1']", 15, false, 60);
            Assert.IsNotNull(micAccessButton, "The micAccessButton button is not find");
            micAccessButton.Click();
        }

        [Given(@"""(.*)"" Microphone driver")]
        public void GivenMicrophoneDriver(string p0)
        {
            _hSAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            if (p0 == "Disable")
            {
                _hSAudioSettingsPage.DisableMicrophoneDriver("off");
            }
            else
            {
                _hSAudioSettingsPage.DisableMicrophoneDriver("on");
            }
        }

        [Then(@"Quicksettings Mic is ""(.*)""")]
        public void ThenQuicksettingsMicIs(string p0)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (p0 == "hidden")
            {
                Assert.IsNull(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, "The QuickSettingsMicrphoneToggle is find");
            }
            else
            {
                Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, "The QuickSettingsMicrphoneToggle is not find");
            }
        }

        [Then(@"The camera value in display page is ""(.*)""")]
        public void ThenTheCameraValueInDisplayPageIs(string p0)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (p0 == "on")
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), ToggleState.On, "The display page toggle is off");
            }
            else
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), ToggleState.Off, "The display page toggle is on");
            }
        }

        [Then(@"Get quicksettings camera state")]
        public void ThenGetQuicksettingsCameraState()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            cameraToggle = VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle);
        }

        [Then(@"Check camera in quick and display")]
        public void ThenCheckCameraInQuickAndDisplay()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (cameraToggle == ToggleState.On)
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), ToggleState.Off, "The display page toggle is not same with quicksettings");
            }
            if (cameraToggle == ToggleState.Off)
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.CameraPrivacyToggle), ToggleState.On, "The display page toggle is not same with quicksettings");
            }
        }

        [Then(@"Click Mic access no button")]
        public void ThenClickMicAccessNoButton()
        {
            WindowsElement micAccessButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, "//Button[@AutomationId='Button0']", 15, false, 60);
            Assert.IsNotNull(micAccessButton, "The micAccessButton no button is not find");
            micAccessButton.Click();
        }

    }
}
