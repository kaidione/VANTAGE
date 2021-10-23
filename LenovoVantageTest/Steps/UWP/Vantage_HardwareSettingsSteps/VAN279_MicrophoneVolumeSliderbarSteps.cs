using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class MicrophoneVolumeSliderbarSteps
    {
        private InformationalWebDriver _webDriver;
        private HSAudioSettingsPage _audioPage;
        private DashBoardPage _dashBoardPage;
        private string _volumeBefore = string.Empty;

        public MicrophoneVolumeSliderbarSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Check the UI of slider-bar")]
        public void WhenCheckTheUIOfSlider_Bar()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneSldierBar);
            _volumeBefore = VantageCommonHelper.GetAttributeValue(_audioPage.MicrophoneSldierBar, "AriaProperties");
        }

        [When(@"Drag the slider bar")]
        public void WhenDragTheSliderBar()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneSldierBar);
            bool result = VantageCommonHelper.DragSlider(_webDriver.Session, _audioPage.MicrophoneSldierBar, -200);
            Assert.IsTrue(result);
        }

        [When(@"Get microphone volume")]
        public void WhenGetMicrophoneVolume()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _volumeBefore = VantageCommonHelper.GetAttributeValue(_audioPage.MicrophoneSldierBar, "AriaProperties");
        }

        [Then(@"Header is microphone volume,slider bar exists")]
        public void ThenHeaderIsMicrophoneVolumeSliderBarExists()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneVolumeTitle);
            Assert.NotNull(_audioPage.MicrophoneSldierBar);
            Assert.NotNull(_audioPage.MicrophoneVolumeSilent);
            Assert.NotNull(_audioPage.MicrophoneVolumeLound);
        }

        [Then(@"The slider bar can be dragged normally")]
        public void ThenTheSliderBarCanBeDraggedNormally()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneSldierBar);
            Assert.AreNotEqual(_volumeBefore, VantageCommonHelper.GetAttributeValue(_audioPage.MicrophoneSldierBar, "AriaProperties"));
        }

        [Then(@"The slider bar should not changae and should work normally")]
        public void ThenTheSliderBarShouldNotChangaeAndShouldWorkNormally()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_audioPage.MicrophoneSldierBar);
            Assert.AreEqual(_volumeBefore, VantageCommonHelper.GetAttributeValue(_audioPage.MicrophoneSldierBar, "AriaProperties"));
        }

        [When(@"Jump to microphone")]
        public void WhenJumpToMicrophone()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (_audioPage.JumpMicrophoneLink != null)
            {
                _audioPage.JumpMicrophoneLink.Click();
            }
        }

        [When(@"Switch vantage page microphone slider")]
        public void WhenSwitchVantagePageMicrophoneSlider()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            _dashBoardPage.HoverOnSAListItem(_dashBoardPage.securityToggle);
            _dashBoardPage.securityTab.Click();
            bool result = _audioPage.GotoAudioPage();
            Assert.IsTrue(result);
        }

        [When(@"Relaungh vantage page microphone slider")]
        public void WhenRelaunghVantagePageMicrophoneSlider()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _audioPage.GotoAudioPage();
            Assert.IsTrue(result);
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
        }

        [When(@"Minimize vantage page microphone slider")]
        public void WhenMinimizeVantagePageMicrophoneSlider()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioPage.VantageMinizeElement.Click();
            _webDriver.Session.Manage()?.Window?.Maximize();
        }

        [When(@"Set microphone '(.*)'")]
        public void WhenSetMicrophone(string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState toggleState = ToggleState.Off;
            if (p0.ToLower().Equals("on"))
            {
                toggleState = ToggleState.On;
            }
            _audioPage.SetCheckBoxStatus(_audioPage.MicrophoenCheckbox, toggleState);
        }

        [When(@"Set microphone '(.*)' in Audio page")]
        public void WhenSetMicrophoneInAudioPage(string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState toggleState = ToggleState.Off;
            if (p0.ToLower().Equals("on"))
            {
                toggleState = ToggleState.On;
            }
            _audioPage.SetCheckBoxStatus(_audioPage.MicrophoenCheckbox, toggleState);
        }

        [When(@"Get microphone '(.*)' in Audio page")]
        public void WhenGetMicrophoneInAudioPage(string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState toggleState = ToggleState.Off;
            if (p0.ToLower().Equals("on"))
            {
                toggleState = ToggleState.On;
            }
            Assert.AreEqual(toggleState, _audioPage.GetCheckBoxStatus(_audioPage.MicrophoenCheckbox));
        }

    }
}
