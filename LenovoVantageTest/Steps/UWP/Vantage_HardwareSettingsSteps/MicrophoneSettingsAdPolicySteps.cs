using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Forms;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class MicrophoneSettingsAdPolicySteps : SettingsBase
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSAudioSettingsPage _HSAudioSettingsPage;
        private HSQuickSettingsPage _HSQuickSettingsPage;
        private SettingsBase _SettingsBase;
        private InformationalWebDriver desktopSession;
        private VantageUI vantageUI = new VantageUI();
        private BaseTestClass baseTestClass = new BaseTestClass();
        private ToggleState _toggleStatus = ToggleState.On;
        private string _volumeSet = string.Empty;

        public MicrophoneSettingsAdPolicySteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
        }

        #region BeforeAndAfterScenarios
        [BeforeScenario("MicrophoneSettings_AdPolicy")]
        [BeforeScenario("MicrophoneSettings_NoSupport_AdPolicy")]
        [BeforeScenario("MicrophoneSettings_PolicyValues")]
        [BeforeScenario("MicrophoneSettings_NoSupport_PolicyValues")]
        [BeforeScenario("MicrophoneSettings_AdvanceMicrophone_PolicyValues")]
        [AfterScenario("MicrophoneSettings_AdPolicy")]
        [AfterScenario("MicrophoneSettings_NoSupport_AdPolicy")]
        [AfterScenario("MicrophoneSettings_PolicyValues")]
        [AfterScenario("MicrophoneSettings_NoSupport_PolicyValues")]
        [AfterScenario("MicrophoneSettings_AdvanceMicrophone_PolicyValues")]
        public static void BeforeAfterScenario()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_microphone);
            DeleteAdPolicyKey(Constants.vantage_adpolicy_audio_smart_settings);
            SetLocationService("on", "ms-settings:privacy-microphone", "Microphone");
        }

        [AfterScenario("MicrophoneResetPolicies")]
        public static void ResetPolicyForOtherSections()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_camera);
            DeleteAdPolicyKey(Constants.vantage_adpolicy_audio_smart_settings);
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.standby-settings");
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.battery-settings");
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.energy-star");
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-settings");
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.power-smart-settings");
            DeleteAdPolicyKey(@"HKLM\SOFTWARE\Policies\Lenovo\Commercial Vantage\feature.device-settings.power.dpm-power-settings");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        [StepDefinition(@"Microphone Settings AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_microphone);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_microphone, booleanValue);
            }
        }

        [Then(@"Microphone Settings and Jump to Settings should be (visible|not visible)")]
        public void ThenMicrophoneSectionVisible(string visibility)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSAudioSettingsPage.MicrophoneSection, "Microphone section should be visibile");
                Assert.IsNotNull(_HSAudioSettingsPage.JumpMicrophoneLink, "Microphone jump to settings should be visibile");
                Assert.IsNotNull(_HSAudioSettingsPage.MicrophoneFeatureTitle, "Microphone title should be visibile");
                Assert.IsNotNull(_HSAudioSettingsPage.MicrophoneVolumeTitle, "Microphone volume should be visibile");
                Assert.IsNotNull(_HSAudioSettingsPage.MicrophoneSldierBar, "Microphone volume slider should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.MicrophoneSection, "Microphone section should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.JumpMicrophoneLink, "Microphone jump to settings should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.MicrophoneFeatureTitle, "Microphone title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.MicrophoneVolumeTitle, "Microphone volume should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.MicrophoneSldierBar, "Microphone volume slider should be not visibile")),
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"AdPolicy for all features on Audio page are set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForAllFeaturesOnSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_microphone);
                DeleteAdPolicyKey(Constants.vantage_adpolicy_audio_smart_settings);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_microphone, booleanValue);
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_audio_smart_settings, booleanValue);
            }
        }

        [StepDefinition(@"Open Menu to check audio link")]
        public bool CheckLinkOnMenu()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.MySettingsMenuDropClickFunction();
            return true;
        }

        [Then(@"Audio (Link|Tab) should be (visible|not visible)")]
        public void CheckElementVisibility(string element, string visibility)
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            bool shouldBeVisible = visibility == "visible" ? true : false;
            WindowsElement elementToCheck = element == "Tab" ? _SettingsBase.MySettingsAudio : _SettingsBase.AudioSettingsPage;
            if (shouldBeVisible)
            {
                Assert.IsNotNull(elementToCheck);
            }
            else
            {
                Assert.IsNull(elementToCheck);
            }
        }

        [StepDefinition(@"go to Audio page if available")]
        public bool GivenGoToAudioPage()
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            try
            {
                bool result = _HSAudioSettingsPage.GotoAudioPage();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Audio page was not present because AD Policy for all features are enabled or machine does not support it");
                return true;
            }
        }

        [Then("(Microphone|Suppress Keyboard|Acoustic Echo Cancellation) settings toggle should be (On|Off)")]
        public void ThenAutomaticDolbyAudioSettingsToggleShouldBeOn(string element, ToggleState expectedState)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            WindowsElement elementToCheck = GetRightElementToCheck(element);
            ToggleState toggleState = _HSAudioSettingsPage.GetCheckBoxStatus(elementToCheck);
            Assert.AreEqual(expectedState, toggleState);
        }

        [StepDefinition(@"The disable microphone checkbox on Windows Settings should be (unchecked|checked)")]
        public void WhenCheckMicrophoneStatusOnMsSettings(string action)
        {
            int i = 3;
            System.Diagnostics.Process.Start("ms-settings:sound");
            while (!Common.GetRunningProcess("SystemSettings") && i > 0)
            {
                System.Diagnostics.Process.Start("ms-settings:sound");
                i--;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            desktopSession = baseTestClass.DesktopSession();
            desktopSession.Session.FindElementByAccessibilityId("SystemSettings_Audio_Input_Modern_Properties_HyperlinkButton").Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            WindowsElement statusCheckBox = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_Audio_EnableInputDevice_CheckBox");
            ToggleState statusCheckBoxElement = VantageCommonHelper.GetToggleStatus(statusCheckBox);
            if (action.ToLower() == "checked")
            {
                Assert.AreEqual(statusCheckBoxElement, ToggleState.On);
            }
            else
            {
                Assert.AreEqual(statusCheckBoxElement, ToggleState.Off);
            }
            Common.KillProcess("SystemSettings", true);
        }

        [StepDefinition(@"User sets microphone volume to (100|70)")]
        public void SetMicrophoneVolume(int value)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            if (_HSAudioSettingsPage.MicrophoneSldierBar != null)
            {
                switch (value)
                {
                    case 100:
                        VantageCommonHelper.DragSlider(_AppDriver.Session, _HSAudioSettingsPage.MicrophoneSldierBar, 355);
                        _volumeSet = VantageCommonHelper.GetAttributeValue(_HSAudioSettingsPage.MicrophoneSldierBar, "AriaProperties");
                        break;
                    case 70:
                        VantageCommonHelper.DragSlider(_AppDriver.Session, _HSAudioSettingsPage.MicrophoneSldierBar, 145);
                        _volumeSet = VantageCommonHelper.GetAttributeValue(_HSAudioSettingsPage.MicrophoneSldierBar, "AriaProperties");
                        break;
                    default:
                        break;
                }
            }
        }

        [StepDefinition(@"The microphone volume value should be the same set previously")]
        public void CheckMicrophoneVolume()
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);

            Assert.AreEqual(_volumeSet, VantageCommonHelper.GetAttributeValue(_HSAudioSettingsPage.MicrophoneSldierBar, "AriaProperties"));
        }

        [StepDefinition(@"The microphone volume value on Windows Settings should be (\d+)")]
        public void CheckMicrophoneVolumeOnWindowsSettings(int value)
        {
            int i = 3;
            System.Diagnostics.Process.Start("ms-settings:sound");
            while (!Common.GetRunningProcess("SystemSettings") && i > 0)
            {
                System.Diagnostics.Process.Start("ms-settings:sound");
                i--;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            desktopSession = baseTestClass.DesktopSession();
            desktopSession.Session.FindElementByAccessibilityId("SystemSettings_Audio_Input_Modern_Properties_HyperlinkButton").Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            WindowsElement volumeValueTexbox = desktopSession.Session.FindElementByAccessibilityId("SystemSettings_Audio_Input_LevelSlider_BatterySaverThresholdValueTextBlock");
            string volumeValue = VantageCommonHelper.GetAttributeValue(volumeValueTexbox, "Name");
            if (value == 100)
            {
                Assert.That(volumeValue, Is.AnyOf(_volumeSet, "100"));
            }
            else
            {
                Assert.That(volumeValue, Is.AnyOf(_volumeSet, "70"));
            }

            Common.KillProcess("SystemSettings", true);
        }

        [StepDefinition(@"Turn (off|on) the Microphone Section's (Microphone|Suppress Keyboard|Acoustic Echo Cancellation) toggle")]
        public void WhenTurnSectionToggle(string status, string element)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            WindowsElement elementToCheck = GetRightElementToCheck(element);
            Assert.NotNull(elementToCheck);
            ToggleState stateToToggle = status == "on" ? ToggleState.On : ToggleState.Off;
            VantageCommonHelper.SwitchToggleStatus(elementToCheck, stateToToggle);
        }

        private WindowsElement GetRightElementToCheck(string element)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            WindowsElement elementToCheck = null;
            switch (element)
            {
                case "Microphone":
                    elementToCheck = _HSAudioSettingsPage.MicrophoenCheckbox;
                    break;
                case "Suppress Keyboard":
                    elementToCheck = _HSAudioSettingsPage.KeystrokeSuppressionCheckBoxEle;
                    break;
                case "Acoustic Echo Cancellation":
                    elementToCheck = _HSAudioSettingsPage.AcousticEchoCancellationToggle;
                    break;
                default:
                    break;
            }

            return elementToCheck;
        }

        [StepDefinition("value on Realtek Audio Console for (Suppress Keyboard|Acoustic Echo Cancellation) is (on|off)")]
        public void CheckValueOnRealtekAudio(string feature, string status)
        {
            UwpAppInfo uwp = UwpAppManagement.SearchUwpAppByName("*RealtekAudioControl*");
            string command = "shell:AppsFolder\\" + uwp.PackageFamilyName.Trim() + "!App";
            Process.Start(command);
            Thread.Sleep(5000);
            SendKeys.SendWait("{Tab}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Tab}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(1000);
            UIAutomationControl automationControl = new UIAutomationControl();
            TogglePattern toggle = null;
            string elementName = feature != "Acoustic Echo Cancellation"
                ? "Keystroke suppression can suppress typing noise."
                : "AEC removes the acoustic echo coupled into the microphones from the loudspeaker output thru air.";

            AutomationElement automationElement = automationControl.FindElementByName(AutomationElement.RootElement, elementName);
            if (automationElement != null)
            {
                toggle = automationElement.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                ToggleState valueToCheck = status == "on" ? ToggleState.On : ToggleState.Off;
                if (toggle != null)
                {
                    Assert.AreEqual(toggle.Current.ToggleState, valueToCheck, $"The {feature} value is not same with le");
                }
            }
        }

        [StepDefinition("Optimize My Microphone for value is (OnlyMyVoice|VoiceRecognition)")]
        public void CheckOptimizeSelectedOption(string feature)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);
            WindowsElement elementToCheck = GetRightOptimizeRadioToCheck(feature);
            Assert.IsTrue(elementToCheck.Selected);
        }

        private WindowsElement GetRightOptimizeRadioToCheck(string feature)
        {
            WindowsElement elementToCheck = null;
            switch (feature)
            {
                case "OnlyMyVoice":
                    elementToCheck = _HSAudioSettingsPage.RadioMicrophoneOnlyMyVoice;
                    break;
                case "VoiceRecognition":
                    elementToCheck = _HSAudioSettingsPage.RadioMicrophoneVoiceRecognition;
                    break;
                default:
                    break;
            }

            return elementToCheck;
        }

        [Then(@"Advanced Microphone Options should be (visible|not visible)")]
        public void ThenAdvancedMicrophoneSectionVisible(string visibility)
        {
            _HSAudioSettingsPage = new HSAudioSettingsPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSAudioSettingsPage.SMBAdvancedMicrophoneQuickDescription, "Advanced Microphone section should be visibile");
                Assert.IsNotNull(_HSAudioSettingsPage.SMBAdvancedMicrophoneDescription, "Advanced Microphone description should be visibile");
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.SMBAdvancedMicrophoneQuickDescription, "Advanced Microphone section should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSAudioSettingsPage.SMBAdvancedMicrophoneDescription, "Advanced Microphone description should be not visibile")),
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [Then(@"The Microphone Section is (shown|not shown) in Quick Settings Widget")]
        public void CheckMicrophoneVisibilityOnQuickSettings(string visibility)
        {
            _HSQuickSettingsPage = new HSQuickSettingsPage(_AppDriver.Session);
            bool visibilityCheck = visibility == "shown" ? true : false;
            if (visibilityCheck)
            {
                Assert.IsNotNull(_HSQuickSettingsPage.QuickSettingsMicrphoneToggle, "Microphone option is not showing on Quick Settings widget");
            }
            else
            {
                Assert.IsNull(_HSQuickSettingsPage.QuickSettingsMicrphoneToggle, "Microphone option is showing on Quick Settings widget");
            }
        }

        [Then(@"The Microphone tip in quick settings section is hidden")]
        public void ThenHideMicrophoneTip()
        {
            _HSQuickSettingsPage = new HSQuickSettingsPage(_AppDriver.Session);
            Assert.IsNull(_HSQuickSettingsPage.microphoneAccessTip, "Microphone privacy tip is showing on Quick Settings widget");
        }

        [Then(@"The Display and Camera page is loaded")]
        public void DisplayAndCameraPageLoaded()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            Assert.IsNotNull(_SettingsBase.MediaLevel2Tiltle, "Display and Camera title is not present, so the page was not loaded");
        }

    }
}
