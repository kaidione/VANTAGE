using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HSAudioSteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private WindowsDriver<WindowsElement> _DolbyAccessDriver;
        private const string MUSIC_UI_PROCCESS_NAME = "Music.UI";

        public HSAudioSteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        [AfterScenario("AudioSmartSettings_AdPolicy")]
        [AfterScenario("AudioSmartSettings_notSupport_AdPolicy")]
        public void AfterMicrophoneAdPolicyScenario()
        {
            AdPolicyRegistryHelper.DeleteAudioSmartSettings();

            _DolbyAccessDriver?.Quit();
            Common.KillProcess("Music.UI", true);
        }

        [AfterScenario("Audio_AdPolicy")]
        public void AfterAudioAllAdPolicyScenario()
        {
            AdPolicyRegistryHelper.DeleteMicrophoneAdPolicy();
            AdPolicyRegistryHelper.DeleteAudioSmartSettings();
        }

        [Given(@"microphone adpolicy is not configured")]
        [When(@"set microphone adpolicy to Not Configured")]
        public void GivenSetMicrophoneAdpolicyToNotConfigured()
        {
            AdPolicyRegistryHelper.DeleteMicrophoneAdPolicy();
        }

        [Given("microphone adpolicy is enabled")]
        [When(@"set microphone adpolicy to enabled")]
        public void GivenSetMicrophoneAdpolicyToEnabled()
        {
            AdPolicyRegistryHelper.SetMicrophoneAdPolicy(isEnabled: true);
        }

        [Given("microphone adpolicy is disabled")]
        [When(@"set microphone adpolicy to disabled")]
        public void GivenSetMicrophoneAdpolicyToDisabled()
        {
            AdPolicyRegistryHelper.SetMicrophoneAdPolicy(isEnabled: false);
        }

        [Given("Audio Smart Settings adpolicy is enabled")]
        [When("Set Audio Smart Settings adpolicy to enabled")]
        public void GivenSetAudioSmartSettingsAdpolicyToEnabled()
        {
            AdPolicyRegistryHelper.SetAudioSmartSettingsAdPolicy(isEnabled: true);
        }

        [Given("Audio Smart Settings adpolicy is disabled")]
        [When("Set Audio Smart Settings adpolicy to disabled")]
        public void GivenSetAudioSmartSettingsAdpolicyToDisabled()
        {
            AdPolicyRegistryHelper.SetAudioSmartSettingsAdPolicy(isEnabled: false);
        }

        [Given("Audio Smart Settings adpolicy is not configured")]
        [When("Set Audio Smart Settings adpolicy to not configured")]
        public void GivenSetAudioSmartSettingsAdpolicyToNotConfigured()
        {
            AdPolicyRegistryHelper.DeleteAudioSmartSettings();
        }

        [Then(@"The Audio Smart Settings section should be visible")]
        public void ThenTheMicrophoneSectionShouldBeVisible()
        {
            var hsAudioPage = new HSAudioSettingsPage(_AppDriver.Session);
            Assert.IsNotNull(hsAudioPage.AudiosmartSettingsCollapseCardTitle);

            Assert.IsNotNull(hsAudioPage.AutomaticAudioOptimizationForVoIPTitle, "Element 'Automatic Audio Optimization For VoIP Title' Is Not Found");
            Assert.IsNotNull(hsAudioPage.AutomaticAudioOptimizationForVoIPToggle, "Element 'Automatic Audio Optimization For VoIP Toggle' Is Not Found");
            Assert.IsNotNull(hsAudioPage.AutomaticAudioOptimizationForVoIPQuestionMark, "Element 'Automatic Audio Optimization For VoIP QuestionMark' Is Not Found");

            Assert.IsNotNull(hsAudioPage.AudioAutomaticDolbyCheckBox);
        }

        [Then("The Audio Smart Settings jump to settings should be visible")]
        public void ThenTheAudioSmartSettingsJumpToSettingsShouldBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            Assert.IsNotNull(hsAudioSettingsPage.AudioSmartSettingsJumpLink);
        }

        [Then(@"The Audio Smart Settings section should not be visible")]
        public void ThenTheMicrophoneSectionShouldNotBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            Assert.IsNull(hsAudioSettingsPage.AudiosmartSettingsCollapseCardTitle);
        }

        [Then("The Audio Smart Settings jump to settings should not be visible")]
        public void ThenTheMicrophoneJumpToSettingsShouldNotBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            Assert.IsNull(hsAudioSettingsPage.JumpMicrophoneLink);
        }

        [Then("the audio menu link should not be visible")]
        public void ThenTheAudioMenuLinkShouldNotBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            hsAudioSettingsPage.MySettingsMenuDropClickFunction();
            Assert.IsNull(hsAudioSettingsPage.AudioSettingsPage);
        }

        [Then("the audio menu link should be visible")]
        public void ThenTheAudioMenuLinkShouldBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            hsAudioSettingsPage.MySettingsMenuDropClickFunction();
            Assert.IsNotNull(hsAudioSettingsPage.AudioSettingsPage);
        }

        [Then("the my device settings audio tab should be visible")]
        public void ThenTheMyDeviceSettingsAudioTabShouldBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            hsAudioSettingsPage.GoToMyDevicesSettings();
            Assert.IsNotNull(hsAudioSettingsPage.MySettingsAudio);
        }

        [Then("the my device settings audio tab should not be visible")]
        public void ThenTheMyDeviceSettingsAudioTabShouldNotBeVisible()
        {
            var hsAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            hsAudioSettingsPage.GoToMyDevicesSettings();
            Assert.IsNull(hsAudioSettingsPage.MySettingsAudio);
        }

        [Then("Automatic Dolby Audio settings toggle should be (On|Off)")]
        public void ThenAutomaticDolbyAudioSettingsToggleShouldBeOn(ToggleState expectedState)
        {
            var hsAudioPage = new HSAudioSettingsPage(_AppDriver.Session);
            ToggleState toggleState = hsAudioPage.GetCheckBoxStatus(hsAudioPage.AudioAutomaticDolbyCheckBox);
            Assert.AreEqual(expectedState, toggleState);
        }

        [Then("Automatic Audio Optimization For VoIP Toggle should be (On|Off)")]
        public void ThenAutomaticAudioOptimizationForVoIPToggleShouldBeOn(ToggleState expectedState)
        {
            var hsAudioPage = new HSAudioSettingsPage(_AppDriver.Session);
            ToggleState toggleState = hsAudioPage.GetCheckBoxStatus(hsAudioPage.AutomaticAudioOptimizationForVoIPToggle);

            Assert.AreEqual(expectedState, toggleState);
        }

        [StepDefinition("start play music")]
        public void StartMusic()
        {
            Process.Start("mswindowsmusic:");
            Thread.Sleep(500);
            Process[] musicProcess = Process.GetProcessesByName(MUSIC_UI_PROCCESS_NAME);
            Assert.IsTrue(musicProcess?.Length > 0);
        }

        [StepDefinition("open Dolby Access Atmos Settings")]
        public void OpenDolbyAccess()
        {
            _DolbyAccessDriver = VantageCommonHelper.LaunchDolbyUwp(isAccess: true);

            var hsAudioPage = new HSAudioSettingsPage(_AppDriver.Session);
            var dolbySettings = hsAudioPage.FindElementByTimes(_DolbyAccessDriver, "AutomationId", "NavigationPanel_PageTab_Settings", timeOut: 2);
            dolbySettings.Click();
        }

        [StepDefinition("dolby Access Atmos Settings changes to (Music|Voice)")]
        public void DolbyAccessChangeTo(string mode)
        {
            string modeEnabledId = string.Empty;
            switch (mode.ToLower())
            {
                case "music":
                    modeEnabledId = "SoundProfileNavigation_Music_enabled";
                    break;
                case "voice":
                    modeEnabledId = "SoundProfileNavigation_Voice_enabled";
                    break;
                default:
                    break;
            }

            var dolbyUwpXpath = $"//*[contains(@AutomationId, {modeEnabledId})]";
            var modeElement = VantageCommonHelper.FindElementByXPath(_DolbyAccessDriver, dolbyUwpXpath, timeOut: 2);

            Assert.IsNotNull(modeElement, $"Dolby access cannot change to {mode}");
        }
    }
}
