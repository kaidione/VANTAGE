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
    public class VAN280_VantageKeystrokeSuppressionSteps
    {
        private InformationalWebDriver _webDriver;
        private HSAudioSettingsPage _hsAudioSettingsPage;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private ToggleState _KStoggleStatus = ToggleState.On;
        private DashBoardPage _dashBoardPage;
        private bool isSupport = false;
        private string _realtekPath = @"C:\Program Files\Realtek\Audio\HDA\RAVCpl64.exe";

        public VAN280_VantageKeystrokeSuppressionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"voice recognition is unselect")]
        public void GivenVoiceRecognitionIsUnselect()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            if (_hsAudioSettingsPage.MicroPhoneVoiceRecognition != null && VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicroPhoneVoiceRecognition) == ToggleState.On)
            {
                if (_hsAudioSettingsPage.MicroPhoneOnlyMyVoice != null)
                {
                    _hsAudioSettingsPage.MicroPhoneOnlyMyVoice.Click();
                }
                else if (_hsAudioSettingsPage.MicroPhoneNormal != null)
                {
                    _hsAudioSettingsPage.MicroPhoneNormal.Click();
                }
                else if (_hsAudioSettingsPage.MicroPhoneMultipleVoices != null)
                {
                    _hsAudioSettingsPage.MicroPhoneMultipleVoices.Click();
                }
            }
        }

        [When(@"Get kssuppress toggle state")]
        public void WhenGetKSsuppressStatus()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            _KStoggleStatus = VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
        }

        [When(@"Switch vantage page KeystrokeSuppression")]
        public void WhenSwitchVantagePage()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            Assert.IsTrue(result);
            Assert.IsNotNull(_hsAudioSettingsPage.JumpMicrophoneLink);
            _hsAudioSettingsPage.JumpMicrophoneLink.Click();
        }

        [When(@"Relaungh vantage page KeystrokeSuppression")]
        public void WhenRelaunghVantagePage()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            Assert.IsTrue(result);
            Assert.IsNotNull(_hsAudioSettingsPage.JumpMicrophoneLink);
            _hsAudioSettingsPage.JumpMicrophoneLink.Click();
        }

        [When(@"Minimize vantage page KeystrokeSuppression")]
        public void WhenMinimizeVantagePage()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioSettingsPage.VantageMinizeElement.Click();
            _webDriver.Session.Manage()?.Window?.Maximize();
        }

        [Then(@"the toggle should not change and the feature should work normally")]
        public void ThenThenTheToggleShouldNotChangeAndTheFeatureShouldWorkNormally()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle), _KStoggleStatus);
            _hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle.Click();
            Assert.AreNotEqual(VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle), _KStoggleStatus);
        }

        [Given(@"machines not support keyboard suppress")]
        public void GivenMachinesNotSupportKeyboardSuppress()
        {
            Assert.IsFalse(isSupport);
        }

        [Given(@"machines support keyboard suppress")]
        public void GivenMachinesSupportKeyboardSuppress()
        {

        }

        [Given(@"go to keyboard suppress")]
        public void GivenGoToKeyboardSuppress()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioSettingsPage.GotoMySettingsAudioPage();
            Assert.IsNotNull(_hsAudioSettingsPage.JumpMicrophoneLink);
            _hsAudioSettingsPage.JumpMicrophoneLink.Click();
        }

        [When(@"check the UI")]
        public void WhenCheckTheUI()
        {

        }

        [When(@"click the question mark")]
        public void WhenClickTheQuestionMark()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionMaskEle);
            _hsAudioSettingsPage.KeystrokeSuppressionMaskEle.Click();
        }

        [When(@"make a connection")]
        public void WhenMakeAConnection()
        {
            //ScenarioContext.Current.Pending();
        }

        [When(@"turn on the toggle")]
        public void WhenTurnOnTheToggle()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);

            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            _hsAudioSettingsPage.SetCheckBoxStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle, System.Windows.Automation.ToggleState.On);
        }

        [When(@"turn off the toggle")]
        public void WhenTurnOffTheToggle()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);

            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            _hsAudioSettingsPage.SetCheckBoxStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle, System.Windows.Automation.ToggleState.Off);
        }

        [When(@"check performance test")]
        public void WhenCheckPerformanceTest()
        {
        }

        [When(@"check metrics data test")]
        public void WhenCheckMetricsDataTest()
        {
        }

        [Then(@"there is no such a feature")]
        public void ThenThereIsNoSuchAFeature()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            Assert.IsNull(_hsAudioSettingsPage.KeystrokeSuppressionMaskEle);
        }

        [Then(@"there is a toggle and a question mark")]
        public void ThenThereIsAToggleAndAQuestionMark()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionMaskEle);
        }

        [Then(@"it will show a KeystrokeSuppression textbox to introduce the feature")]
        public void ThenItWillShowAKeystrokeSuppressionTextboxToIntroduceTheFeature(string p0)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(p0, _hsAudioSettingsPage.KeystrokeTooltipToolTipEle.Text);
        }

        [Then(@"the feature in Realtek Audio Console is on")]
        public void ThenTheFeatureInRealtekAudioConsoleIsOn()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsAudioSettingsPage.OpenRAVCpl64());
            var systemKeystroke = _hsAudioSettingsPage.contrl.FindElement("Realtek HD Audio Manager", "1694", "", 10);
            Assert.IsNotNull(systemKeystroke);
            Common.KillProcess("RAVCpl64", true);
        }

        [Then(@"the toggle is on")]
        public void ThenTheToggleIsOn()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(_hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle), ToggleState.On);
        }

        [Then(@"the feature in Realtek Audio Console is off")]
        public void ThenTheFeatureInRealtekAudioConsoleIsOff()
        {
        }

        [Then(@"the toggle is off")]
        public void ThenTheToggleIsOff()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(_hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle), ToggleState.Off);
        }

        [Then(@"The UI should show in (.*) seconds")]
        public void ThenTheUIShouldShowInSeconds(int p0)
        {
        }

        [Then(@"The toggle button should send metrics data normally")]
        public void ThenTheToggleButtonShouldSendMetricsDataNormally()
        {
        }
        [Then(@"check title is Suppress Keyboard Noise with an icon in front and a toggle, question mark on the right")]
        public void ThenCheckTitleIsSuppressKeyboardNoiseWithAnIconInFrontAndAToggleQuestionMarkOnTheRight()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeTooltiptitle, "KeystrokeTooltiptitle is null");
            Assert.IsTrue(_hsAudioSettingsPage.ShowTextbox(_hsAudioSettingsPage.KeystrokeTooltiptitle).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.InputAndAccessories.KeystrokeTooltiptitletext").ToString()));
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionCheckBox, "KeystrokeSuppressionCheckBox is null");
            Assert.IsNotNull(_hsAudioSettingsPage.KeystrokeSuppressionQuesttion, "KeystrokeSuppressionQuesttion is null");
        }

    }
}
