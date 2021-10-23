using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    class HSCameraBlurRegressionSteps
    {
        private HSDispalyCameraPage _HSDisplayCameraPage;
        private SettingsBase _settingsBase;
        private InformationalWebDriver _webDriver;
        private ToggleState _toggleStatus = ToggleState.On;

        public HSCameraBlurRegressionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to DisplayCamera page")]
        public void GivenGoToDisplayCameraPage()
        {
            _settingsBase = new SettingsBase(_webDriver.Session);
            _settingsBase.GotoMySettingsDisplayCameraPage();
        }

        [Given(@"Go to Camera Blur Panel")]
        public void GivenGoTOCameraBlurPanel()
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsNotNull(_HSDisplayCameraPage.CameraLink);
            _HSDisplayCameraPage.CameraLink.Click();
        }

        [Given(@"Turn (.*) Camera Blur Toggle")]
        public void GivenTurnCameraBlurToggle(string status)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_HSDisplayCameraPage.CameraBlurCheckBox);
            _toggleStatus = VantageCommonHelper.GetToggleStatus(_HSDisplayCameraPage.CameraBlurCheckBox);
            switch (status)
            {
                case "On":
                    if (_toggleStatus == ToggleState.Off)
                    {
                        _HSDisplayCameraPage.CameraBlurCheckBox.Click();
                    }
                    break;
                case "Off":
                    if (_toggleStatus == ToggleState.On)
                    {
                        _HSDisplayCameraPage.CameraBlurCheckBox.Click();
                    }
                    break;
            }
        }

        [Then(@"three blur buttons (.*)")]
        public void ThenCheckThreeModeStatus(string status)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            if (status == "hide")
            {
                Assert.IsNull(_HSDisplayCameraPage.comicModeRadio);
                Assert.IsNull(_HSDisplayCameraPage.blurModeRadio);
                Assert.IsNull(_HSDisplayCameraPage.sketchModeRadio);
            }
            else if (status == "show")
            {
                Assert.IsNotNull(_HSDisplayCameraPage.comicModeRadio);
                Assert.IsNotNull(_HSDisplayCameraPage.blurModeRadio);
                Assert.IsNotNull(_HSDisplayCameraPage.sketchModeRadio);
            }
            else
            {
                Assert.Fail("three mode has no such status");
            }

        }

        [Then(@"The toggle's value of Camera blur should be (.*)")]
        public void ThenCheckToggleStatus(string status)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.NotNull(_HSDisplayCameraPage.CameraBlurCheckBox);
            _toggleStatus = VantageCommonHelper.GetToggleStatus(_HSDisplayCameraPage.CameraBlurCheckBox);
            if (status == "On")
            {
                Assert.AreEqual(_toggleStatus, ToggleState.On);
            }
            else if (status == "Off")
            {
                Assert.AreEqual(_toggleStatus, ToggleState.Off);
            }
            else
            {
                Assert.Fail("CameraBlur toggle has no such status");
            }
        }

        [When(@"Minimize vantage camera blur toggle")]
        public void WhenMinimizeVantageMicophoneToggle()
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            _HSDisplayCameraPage.VantageMinizeElement.Click();
            //_webDriver.Session.Manage()?.Window?.Maximize();
        }

        [When(@"choose (.*) mode")]
        public void WhenChooseCameraMode(string typemode)
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsNotNull(_HSDisplayCameraPage.comicModeRadio);
            Assert.IsNotNull(_HSDisplayCameraPage.blurModeRadio);
            Assert.IsNotNull(_HSDisplayCameraPage.sketchModeRadio);
            if (typemode == "blur")
            {
                _HSDisplayCameraPage.blurModeRadio.Click();
            }
            else if (typemode == "comic")
            {
                _HSDisplayCameraPage.comicModeRadio.Click();
            }
            else if (typemode == "sketch")
            {
                _HSDisplayCameraPage.sketchModeRadio.Click();
            }
            else
            {
                Assert.Fail("Camera mode  has no such type");
            }
        }

        [Given(@"Launch windows camera")]
        public void GivenLaunchWindowsCamera()
        {
            string _cameraUwpAppid = "Microsoft.WindowsCamera_8wekyb3d8bbwe!App";
            var session = VantageCommonHelper.LaunchSystemUwp(_cameraUwpAppid);
            _webDriver = new InformationalWebDriver(session, session);
        }

        [Then(@"camera section hide")]
        public void ThenCameraSectionHide()
        {
            _HSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            Assert.IsNull(_HSDisplayCameraPage.CameraLink);
            Assert.IsNull(_HSDisplayCameraPage.CameraTitle);
            Assert.IsNull(_HSDisplayCameraPage.CameraBlurCaption);
            Assert.IsNull(_HSDisplayCameraPage.CameraBlurTitle);
        }

        [Then(@"close windows camera")]
        public void ThenCloseWindowsCamera()
        {
            Common.KillProcess("WindowsCamera", true);
        }

        [Given(@"Display Desktop")]
        [When(@"Display Desktop")]
        public void GivenDisplayDesktop()
        {
            KeyboardMouse.ShowDesktop();
        }

    }
}
