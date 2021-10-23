using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class AcousticEchoCancellationSteps
    {
        private HSAudioSettingsPage _audioPage;
        private InformationalWebDriver _webDriver;
        private string _driverName = string.Empty;
        private ToggleState _aecToggleState = ToggleState.Indeterminate;
        private bool _performanceTag = true;
        private HSQuickSettingsPage _hSQuickSettings;

        public AcousticEchoCancellationSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to Meeting manager page")]
        public void GivenGoToMeetingManagerPage()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioPage.GoToMeetingManagerPage();
        }

        [When(@"Click acoustic echo question mask")]
        public void WhenClickAcousticEchoQuestionMask()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecQuestionMark);
            _audioPage.MicrophoneAecQuestionMark.Click();
        }

        [When(@"Get audio driver name")]
        public void WhenGetAudioDriverName()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _driverName = _audioPage.GetAudioDriverName();
        }

        [When(@"Open audio and screenshot")]
        public void WhenOpenAudioAndScreenshot()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioPage.OpenAudioScreenShot(_driverName, _webDriver.Session, "VAN281");
        }

        [When(@"Open audio and screenshot '(.*)'")]
        public void WhenOpenAudioAndScreenshotStatus(string fileName)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioPage.OpenAudioScreenShot(_driverName, _webDriver.Session, fileName);
        }

        [When(@"Click aec toggle")]
        public void WhenClickToggle()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecCheckbox);
            _audioPage.MicrophoneAecCheckbox.Click();
        }

        [Then(@"the header is Acoustic Echo Cancellation\.there is a toggle,there is a question mark")]
        public void ThenTheHeaderIsAcousticEchoCancellation_ThereIsAToggleThereIsAQuestionMark()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecTitle);
            Assert.NotNull(_audioPage.MicrophoneAecCheckbox);
            Assert.NotNull(_audioPage.MicrophoneAecQuestionMark);
        }

        [Then(@"Machines Not Support AEC And Elements Not Show")]
        public void ThenMachinesNotSupportAECAndElementsNotShow()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNull(_audioPage.MicrophoneAecTitle, "AEC Elements 'MicrophoneAecTitle' Is Not Hidden");
            Assert.IsNull(_audioPage.MicrophoneAecCheckbox, "AEC Elements 'MicrophoneAecCheckbox' Is Not Hidden");
            Assert.IsNull(_audioPage.MicrophoneAecQuestionMark, "AEC Elements 'MicrophoneAecQuestionMark' Is Not Hidden");
        }

        [Given(@"Turn '(.*)' AEC Toggle")]
        public void GivenTurnAECToggle(string Status)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (Status.ToLower().Equals("on"))
            {
                if (_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox) == ToggleState.Off)
                {
                    _audioPage.MicrophoneAecCheckbox.Click();
                }
                Assert.AreEqual(_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox), ToggleState.On);
            }
            if (Status.ToLower().Equals("off"))
            {
                if (_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox) == ToggleState.On)
                {
                    _audioPage.MicrophoneAecCheckbox.Click();
                }
                Assert.AreEqual(_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox), ToggleState.Off);
            }
        }

        [Then(@"AEC Toggle Status is '(.*)'")]
        public void ThenAECToggleStatusis(string Status)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (Status.ToLower().Equals("on"))
            {
                Assert.AreEqual(_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox), ToggleState.On);
            }
            else if (Status.ToLower().Equals("off"))
            {
                Assert.AreEqual(_audioPage.GetCheckBoxStatus(_audioPage.MicrophoneAecCheckbox), ToggleState.Off);
            }
        }

        [Then(@"It will show a textbox to introduce the feature")]
        public void ThenItWillShowATextboxToIntroduceTheFeature()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecTooltip);
        }

        [Then(@"Click toggle change normally")]
        public void ThenClickToggleChangeNormally()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecCheckbox);
            Assert.AreNotEqual(_aecToggleState, VantageCommonHelper.GetToggleStatus(_audioPage.MicrophoneAecCheckbox));
        }

        [Then(@"The toggle should be quick switch")]
        public void ThenTheToggleShouldBeQuickSwitch()
        {
            Assert.IsTrue(_performanceTag);
        }

        [When(@"Get aec toggle state")]
        public void WhenGetToggleState()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecCheckbox);
            _aecToggleState = VantageCommonHelper.GetToggleStatus(_audioPage.MicrophoneAecCheckbox);
        }

        [When(@"Quickly switch aec toggle")]
        public void WhenQuicklySwitchAecToggle()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneAecCheckbox);
            _performanceTag = VantageCommonHelper.PerformanceSwitchToggle(_audioPage.MicrophoneAecCheckbox);
        }

        [Then(@"Suppressing keyboard noise, Acoustic echo cancellation and Optimize my microphone for will be (.*)")]
        public void ThenSuppressingKeyboardNoiseAcousticEchoCancellationAndOptimizeMyMicrophoneForWillBeShown(String type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type.ToLower())
            {
                case "shown":
                    Assert.IsNotNull(_audioPage.KeystrokeTooltiptitle, "KeystrokeTooltiptitle is null");
                    Assert.IsNotNull(_audioPage.MicrophoneAecTitle, "MicrophoneAecTitle is null");
                    Assert.IsNotNull(_audioPage.MicroPhoneOptimizationTitle, "MicroPhoneOptimizationTitle is null");
                    break;
                case "hidden":
                    Assert.IsNull(_audioPage.KeystrokeTooltiptitle, "KeystrokeTooltiptitle is not null");
                    Assert.IsNull(_audioPage.MicrophoneAecTitle, "MicrophoneAecTitle is not null");
                    Assert.IsNull(_audioPage.MicroPhoneOptimizationTitle, "MicroPhoneOptimizationTitle is not null");
                    break;
            }
        }

        [Then(@"Microphone effects link will be (.*)")]
        public void ThenMicrophoneEffectsLinkWillBeShown(string type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "shown":
                    Assert.NotNull(_audioPage.MicrophoneEffectslink, "MicrophoneEffectslink is null");
                    Assert.NotNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneDescriptionText").ToString()));
                    Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionText").ToString()));
                    Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHere).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));
                    break;
                case "hidden":
                    Assert.IsNull(_audioPage.MicrophoneEffectslink, "MicrophoneEffectslink is not null");
                    Assert.IsNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is not null");
                    Assert.IsNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is not null");
                    Assert.IsNull(_audioPage.AdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is not null");
                    break;
            }
        }

        [Then(@"It will show title text")]
        public void ThenItwillshowTitleText()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneEffectslink, "AdvancedMicrophoneEffects is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.MicrophoneEffectslink).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneEffectsText").ToString()));
        }

        [Given(@"Scroll the Advanced microphone effects")]
        public void GivenScrollTheAdvancedMicrophoneEffects()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _audioPage.ScrollScreenToWindowsElement(_webDriver.Session, _audioPage.MicrophoneEffectslink);
        }

        [Then(@"Click Here (.*)")]
        public void ThenClickHere(String type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "DolbyAccess":
                    _audioPage.ClickElement(_audioPage.AdvancedMicrophoneEffectsHere);
                    break;
                case "NoDolbyAccess":
                    _audioPage.ClickElement(_audioPage.AdvancedMicrophoneEffectsHeres);
                    break;
            }
        }

        [Then(@"It will show description and a quick interface description with (.*) Driver")]
        public void ThenItwillshowDescriptionAndAQuickInterfaceDescriptionNoDolbyAccess(string type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneDescriptionText").ToString()));
            switch (type)
            {
                case "Install":
                    Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionText").ToString()));
                    Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHere).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));
                    break;
                case "UnInstall":
                    Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescriptions, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescriptions).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionTexts").ToString()));
                    Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHeres, "AdvancedMicrophoneQuickDescription is null");
                    Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHeres).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));
                    break;
            }
        }

        [Given(@"install '(.*)' Driver")]
        public void GivenInstall(string p0)
        {
            _hSQuickSettings = new HSQuickSettingsPage(_webDriver.Session);
            switch (p0)
            {
                case "DolbyAccess":
                    UwpAppInfo comp = UwpAppManagement.SearchDriverByNames(VantageConstContent.DolbyAccessSettings);
                    if (comp == null)
                    {
                        Assert.IsTrue(File.Exists(VantageConstContent.AudioDriverDolbyAccess), "AudioDriverForteMedia is not exist");
                        CommandBase.RunCmd(VantageConstContent.AudioDriverDolbyAccess);
                        VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.ForteMediainstallbutton").ToString());
                    }
                    break;
                case "ForteMedia":
                    UwpAppInfo comps = UwpAppManagement.SearchDriverByNames(VantageConstContent.FMAPOControlSettings);
                    if (comps == null)
                    {
                        bool flag = true;
                        int times = 2;
                        Assert.IsTrue(File.Exists(VantageConstContent.AudioDriverForteMedia), "AudioDriverForteMedia is not exist");
                        CommandBase.RunCmd(VantageConstContent.AudioDriverForteMedia);
                        VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.ForteMediainstallbutton").ToString());
                        VantageCommonHelper.FindElementByIdAndMouseClick("launchWhenReadyCheckbox");
                        while (flag)
                        {
                            if (times == 0)
                            {
                                break;
                            }
                            AutomationElement a = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.ForteMediainstallbutton").ToString());
                            if (a != null)
                            {
                                flag = false;
                            }
                            times--;
                        }
                        VantageCommonHelper.FindElementByIdAndMouseClick("Close");
                    }
                    break;
            }
        }

        [Given(@"uninstall '(.*)' Driver")]
        public void GivenUninstallDriver(string p0)
        {
            switch (p0)
            {
                case "DolbyAccess":
                    UwpAppInfo comp = UwpAppManagement.SearchDriverByNames(VantageConstContent.DolbyAccessSettings);
                    if (comp != null)
                    {
                        UwpAppManagement.UninstallUwpApp(comp.PackageFullName);
                    }
                    break;
                case "ForteMedia":
                    UwpAppInfo comps = UwpAppManagement.SearchDriverByNames(VantageConstContent.FMAPOControlSettings);
                    if (comps != null)
                    {
                        UwpAppManagement.UninstallUwpApp(comps.PackageFullName);
                    }
                    break;
            }
        }

        [Then(@"Advanced microphone effects should (.*)")]
        public void ThenAdvancedMicrophoneEffectsShouldNoshown(String type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "shown":
                    Assert.NotNull(_audioPage.MicrophoneEffectslink, "AdvancedMicrophoneEffects is null");
                    break;
                case "noshown":
                    Assert.IsNull(_audioPage.MicrophoneEffectslink, "AdvancedMicrophoneEffects is not null");
                    break;
            }
        }

        [Then(@"Keep the privacy access link for Microphone")]
        public void ThenKeeptheprivacyaccesslinkforMicrophone()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.GoToWindowsPrivacySettings, "GoToWindowsPrivacySettings is null");
        }

        [Then(@"The link should be To change to To add the application suitable for your hardware, click here")]
        public void ThenTheQuickInterfaceWillChangeToToAddTheApplicationSuitableForYourHardwareClickHere()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescriptions, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescriptions).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionTexts").ToString()));
            Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHeres, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHeres).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));
        }

        [Then(@"The link should be To change to access the application most suitable for your microphone, click here")]
        public void ThenTheQuickInterfaceWillChangeToToAccessTheApplicationMostSuitableForYourMicrophoneClickHere()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescription).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionText").ToString()));
            Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHere).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));

        }

        [Then(@"the UI of Advanced microphone effects should not change")]
        public void ThenTheUIOfAdvancedMicrophoneEffectsShouldNotChange()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneEffectslink, "AdvancedMicrophoneEffects is null");
            Assert.NotNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
            Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
        }

        [Then(@"the UI of Advanced microphone effects should be shown within (.*) seconds")]
        public void ThenTheUIOfAdvancedMicrophoneEffectsShouldBeShownWithinSeconds(int p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.NotNull(_audioPage.MicrophoneEffectslink, "AdvancedMicrophoneEffects is null");
            Assert.NotNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
            Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, 2, "The UI should show completely in 2 seconds");
        }

        [Then(@"Click Look for an app in the Microsoft Store")]
        public void ThenClickLookForAnAppInTheMicrosoftStore()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicrosoftStore").ToString());
        }

        [Then(@"Click ok jump to Microphone Store")]
        public void ThenClickOkJumpToMicrophoneStore()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicrosoftStoreOk").ToString());
        }

        [Then(@"Click here for (.*) Driver (.*)")]
        public void ThenClickHereHasNoDriver(string type, string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "install":
                    _audioPage.ClickElement(_audioPage.AdvancedMicrophoneEffectsHere);
                    break;
                case "uninstall":
                    _audioPage.ClickElement(_audioPage.AdvancedMicrophoneEffectsHeres);
                    break;
            }
        }

        [Then(@"Locate Smart Microphone settings app display Microsoft Store")]
        public void ThenLocateSmartMicrophoneSettingsAppDisplayMicrosoftStore()
        {
            AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.SmartMicrophoneSettingstoMicrosoftstore").ToString());
            Assert.IsNotNull(automationElement, "Element 'Smart Microphone settings' Is Not Found");
            string windowsName = "Microsoft Store";
            IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", windowsName);
            UnManagedAPI.SendMessage(intPtr, UnManagedAPI.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        }

        [Then(@"Meeting manager page will be hidden")]
        public void ThenMeetingManagerPageWillBeHidden()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNull(_audioPage.MettingManagerPage, "Element 'Metting Manager Page' Is Not null");

        }

        [Then(@"It will launch Smart microphone settings app")]
        public void ThenItWillLaunchSmartMicrophoneSettingsApp()
        {
            AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.SmartMicrophoneSettingsApp").ToString(), 1);
            Assert.IsNotNull(automationElement, "Element 'Smart Microphone settings' Is Not Found");
        }

        [Then(@"including Microphone toggle, Microphone Valume, Advanced microphone effects will be shown")]
        public void ThenIncludingMicrophoneToggleMicrophoneValumeAdvancedMicrophoneEffectsWillBeShown()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_audioPage.MicrophoneTitle, " MicrophoneTitle is null");
            Assert.IsNotNull(_audioPage.MicrophoenCheckbox, "MicrophoenCheckbox is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeTitle, "MicrophoneVolumeTitle is null");
            Assert.NotNull(_audioPage.MicrophoneSldierBar, "MicrophoneSldierBar is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeSilent, "MicrophoneVolumeSilent is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeLound, "MicrophoneVolumeLound is null");
            Assert.NotNull(_audioPage.MicrophoneEffectslink, "MicrophoneEffectslink is null");
            Assert.NotNull(_audioPage.AdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneDescriptionText").ToString()));
            Assert.NotNull(_audioPage.AdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneQuickDescription).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AdvancedMicrophoneQuickDescriptionText").ToString()));
            Assert.NotNull(_audioPage.AdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.AdvancedMicrophoneEffectsHere).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicriophoneClickHere").ToString()));
        }

        [When(@"Click Microphone for meetings link")]
        public void WhenClickMicrophoneForMeetingsLink()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneForMettingsLink, "MicrophoneForMettingsLink is null");
            _audioPage.MicrophoneForMettingsLink.Click();
        }

        [When(@"Choose a mode and launch Smart Audio 3 app")]
        public void WhenChooseAModeAndLaunchSmartAudioApp()
        {
            Assert.IsTrue(File.Exists(VantageConstContent.SmartAudioApp), "SmartAudio3App is not exist.");
            Process.Start(VantageConstContent.SmartAudioApp);
            VantageCommonHelper.FindElementByIdAndMouseClick(_audioPage.ConferenceMode.ToString());
        }

        [Then(@"Optimize my microphone for on Meeting manager page should show")]
        public void ThenOptimizeMyMicrophoneForOnMeetingManagerPageShouldShow()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_audioPage.MicroPhoneOptimizationTitle, "MicroPhoneOptimizationTitle is null");
        }

        [Then(@"Microphone toggle, microphone valume, optimize my microphone for should show")]
        public void ThenMicrophoneToggleMicrophoneValumeOptimizeMyMicrophoneForShouldShow()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_audioPage.MicrophoneTitle, " MicrophoneTitle is null");
            Assert.IsNotNull(_audioPage.MicrophoenCheckbox, "MicrophoenCheckbox is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeTitle, "MicrophoneVolumeTitle is null");
            Assert.NotNull(_audioPage.MicrophoneSldierBar, "MicrophoneSldierBar is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeSilent, "MicrophoneVolumeSilent is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeLound, "MicrophoneVolumeLound is null");
            Assert.IsNotNull(_audioPage.MicroPhoneOptimizationTitle, "MicroPhoneOptimizationTitle is null");
        }

        [Then(@"Microphone for meetings link will be hidden")]
        public void ThenMicrophoneForMeetingsLinkWillBeHidden()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNull(_audioPage.MicrophoneForMettingsLink, "MicrophoneForMettingsLink is not null");
        }

        [Then(@"Microphone toggle microphone valume will be show")]
        public void ThenMicrophoneToggleMicrophoneValumeWillBeShow()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_audioPage.MicrophoneTitle, " MicrophoneTitle is null");
            Assert.IsNotNull(_audioPage.MicrophoenCheckbox, "MicrophoenCheckbox is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeTitle, "MicrophoneVolumeTitle is null");
            Assert.NotNull(_audioPage.MicrophoneSldierBar, "MicrophoneSldierBar is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeSilent, "MicrophoneVolumeSilent is null");
            Assert.NotNull(_audioPage.MicrophoneVolumeLound, "MicrophoneVolumeLound is null");
        }

        [Then(@"Microphone for meetings title text")]
        public void ThenMicrophoneForMeetingsTitleText()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneForMeetingstitle, "MicrophoneForMeetingstitle is null");
            Assert.IsTrue(_audioPage.ShowTextbox(_audioPage.MicrophoneForMeetingstitle).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MicrophoneForMeetingstitletext").ToString()));
        }

    }
}