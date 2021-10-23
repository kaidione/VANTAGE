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
    public class MicrophoneOptimizationModeSteps
    {
        private HSAudioSettingsPage _audioPage;
        private DashBoardPage _dashBoardPage;
        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private ToggleState _recognitionState = ToggleState.Indeterminate;
        private ToggleState _multipleVoicesState = ToggleState.Indeterminate;
        private ToggleState _onlyMyVoiceState = ToggleState.Indeterminate;
        private ToggleState _normalState = ToggleState.Indeterminate;

        public MicrophoneOptimizationModeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Get microphone optimization state")]
        public void WhenGetMicrophoneOptimizationState()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicroPhoneMultipleVoices);
            Assert.NotNull(_audioPage.MicroPhoneOnlyMyVoice);
            Assert.NotNull(_audioPage.MicroPhoneNormal);
            Assert.NotNull(_audioPage.MicroPhoneVoiceRecognition);
            _multipleVoicesState = VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneMultipleVoices);
            _onlyMyVoiceState = VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneOnlyMyVoice);
            _normalState = VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneNormal);
            _recognitionState = VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneVoiceRecognition);
            Assert.AreNotEqual(_multipleVoicesState, ToggleState.Indeterminate);
            Assert.AreNotEqual(_onlyMyVoiceState, ToggleState.Indeterminate);
            Assert.AreNotEqual(_normalState, ToggleState.Indeterminate);
            Assert.AreNotEqual(_recognitionState, ToggleState.Indeterminate);
        }

        [Then(@"The Microphone Optimization mode includes: voice recognition, only my voice, Normal, Multiple voices")]
        public void ThenTheMicrophoneOptimizationModeIncludesVoiceRecognitionOnlyMyVoiceNormalMultipleVoices()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicroPhoneVoiceRecognition);
            Assert.NotNull(_audioPage.MicroPhoneMultipleVoices);
            Assert.NotNull(_audioPage.MicroPhoneOnlyMyVoice);
            Assert.NotNull(_audioPage.MicroPhoneNormal);
        }

        [Then(@"The Optimization MicroPhone Caption Corrcet")]
        public void ThenTheOptimizationMicroPhoneCaptionCorrect()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.OptimizeMicrophoneCaption);
            Assert.AreEqual(_audioPage.OptimizeMicrophoneCaption.Text, _audioPage.OptimizeMicrophoneCaptionContext);
        }


        [Then(@"Any of the modes can be selected")]
        public void ThenAnyOfTheModesCanBeSelected()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicroPhoneMultipleVoices);
            _audioPage.MicroPhoneMultipleVoices.Click();
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneMultipleVoices), ToggleState.On);
            Assert.NotNull(_audioPage.MicroPhoneOnlyMyVoice);
            _audioPage.MicroPhoneOnlyMyVoice.Click();
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneOnlyMyVoice), ToggleState.On);
            Assert.NotNull(_audioPage.MicroPhoneNormal);
            _audioPage.MicroPhoneNormal.Click();
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneNormal), ToggleState.On);
            Assert.NotNull(_audioPage.MicroPhoneVoiceRecognition);
            _audioPage.MicroPhoneVoiceRecognition.Click();
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneVoiceRecognition), ToggleState.On);
        }

        [Then(@"The mode should not change and should work normally")]
        public void ThenTheModeShouldNotChangeAndShouldWorkNormally()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicroPhoneMultipleVoices);
            Assert.NotNull(_audioPage.MicroPhoneOnlyMyVoice);
            Assert.NotNull(_audioPage.MicroPhoneNormal);
            Assert.NotNull(_audioPage.MicroPhoneVoiceRecognition);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneVoiceRecognition), _recognitionState);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneMultipleVoices), _multipleVoicesState);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneOnlyMyVoice), _onlyMyVoiceState);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_audioPage.MicroPhoneNormal), _normalState);
        }
        [When(@"Switch vantage microphone optimization mode")]
        public void WhenSwitchVantageMicrophoneOptimizationMode()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            _audioPage.GotoAudioPage();
            _audioPage.JumpMicrophoneLink.Click();
        }

        [When(@"Relaungh vantage microphone optimization mode")]
        public void WhenRelaunghVantageMicrophoneOptimizationMode()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
            _audioPage.GotoAudioPage();
            _audioPage.JumpMicrophoneLink.Click();
        }

    }
}
