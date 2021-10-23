using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class SMBAudioMicrophoneSteps
    {

        private HSAudioSettingsPage _audioPage;
        private InformationalWebDriver _webDriver;

        public SMBAudioMicrophoneSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"It will show title text for SMB")]
        public void ThenItWillShowTitleTextForSMB()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.SMBMicrophoneEffectslink, "SMBAdvancedMicrophoneEffects is null");
            string ss = _audioPage.AdvancedMicrophoneEffectsText;
            Assert.AreEqual(_audioPage.SMBMicrophoneEffectslink.Text, _audioPage.AdvancedMicrophoneEffectsText);
        }

        [Then(@"Microphone for meetings title text for SMB")]
        public void ThenMicrophoneForMeetingsTitleTextForSMB()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.MicrophoneForMeetingstitle, "MicrophoneForMeetingstitle is null");
            Assert.AreEqual(_audioPage.MicrophoneForMeetingstitletext, _audioPage.MicrophoneForMeetingstitle.Text);
        }

        [Then(@"It will show description and a quick interface description with (.*) Driver for SMB")]
        public void ThenItWillShowDescriptionAndAQuickInterfaceDescriptionWithInstallDriverForSMB(string type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneDescription, "SMBAdvancedMicrophoneDescription is null");
            Assert.AreEqual(_audioPage.AdvancedMicrophoneDescriptionText, _audioPage.SMBAdvancedMicrophoneDescription.Text);
            switch (type)
            {
                case "Install":
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.AdvancedMicrophoneQuickDescriptionText, _audioPage.SMBAdvancedMicrophoneQuickDescription.Text);
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.MicriophoneClickHere, _audioPage.SMBAdvancedMicrophoneEffectsHere.GetAttribute("Name"));
                    break;
                case "UnInstall":
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescriptions, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.AdvancedMicrophoneQuickDescriptionTexts, _audioPage.SMBAdvancedMicrophoneQuickDescriptions.Text);
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneEffectsHeres, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.MicriophoneClickHere, _audioPage.SMBAdvancedMicrophoneEffectsHeres.GetAttribute("Name"));
                    break;
            }
        }

        [Then(@"SMB Click here for (.*) Driver (.*)")]
        public void ThenSMBClickHereForInstallDriverWithoutRefresh(string type, string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "install":
                    _audioPage.ClickElement(_audioPage.SMBAdvancedMicrophoneEffectsHere);
                    break;
                case "uninstall":
                    _audioPage.ClickElement(_audioPage.SMBAdvancedMicrophoneEffectsHeres);
                    break;
            }
        }

        [Then(@"The link should be To change to To add the application suitable for your hardware, click here for SMB")]
        public void ThenTheLinkShouldBeToChangeToToAddTheApplicationSuitableForYourHardwareClickHereForSMB()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescriptions, "AdvancedMicrophoneQuickDescription is null");
            Assert.AreEqual(_audioPage.AdvancedMicrophoneQuickDescriptionTexts, _audioPage.SMBAdvancedMicrophoneQuickDescriptions.Text);
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneEffectsHeres, "AdvancedMicrophoneQuickDescription is null");
            Assert.AreEqual(_audioPage.MicriophoneClickHere, _audioPage.SMBAdvancedMicrophoneEffectsHeres.GetAttribute("Name"));
        }

        [Then(@"The link should be To change to access the application most suitable for your microphone, click here for SMB")]
        public void ThenTheLinkShouldBeToChangeToAccessTheApplicationMostSuitableForYourMicrophoneClickHereForSMB()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
            Assert.AreEqual(_audioPage.AdvancedMicrophoneQuickDescriptionText, _audioPage.SMBAdvancedMicrophoneQuickDescription.Text);
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
            Assert.AreEqual(_audioPage.MicriophoneClickHere, _audioPage.SMBAdvancedMicrophoneEffectsHere.GetAttribute("Name"));
        }

        [Then(@"SMB Microphone effects link will be (.*)")]
        public void ThenAMBMicrophoneEffectsLinkWillBeShown(string type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "shown":
                    Assert.NotNull(_audioPage.SMBMicrophoneEffectslink, "MicrophoneEffectslink is null");
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
                    Assert.AreEqual(_audioPage.AdvancedMicrophoneDescriptionText, _audioPage.SMBAdvancedMicrophoneDescription.Text);
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.AdvancedMicrophoneQuickDescriptionText, _audioPage.SMBAdvancedMicrophoneQuickDescription.Text);
                    Assert.NotNull(_audioPage.SMBAdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is null");
                    Assert.AreEqual(_audioPage.MicriophoneClickHere, _audioPage.SMBAdvancedMicrophoneEffectsHere.GetAttribute("Name"));
                    break;
                case "hidden":
                    Assert.IsNull(_audioPage.SMBMicrophoneEffectslink, "MicrophoneEffectslink is not null");
                    Assert.IsNull(_audioPage.SMBAdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is not null");
                    Assert.IsNull(_audioPage.SMBAdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is not null");
                    Assert.IsNull(_audioPage.SMBAdvancedMicrophoneEffectsHere, "AdvancedMicrophoneQuickDescription is not null");
                    break;
            }
        }

        [Then(@"the UI of Advanced microphone effects should be shown within (.*) seconds for SMB")]
        public void ThenTheUIOfAdvancedMicrophoneEffectsShouldBeShownWithinSecondsForSMB(int p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.NotNull(_audioPage.SMBMicrophoneEffectslink, "AdvancedMicrophoneEffects is null");
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneDescription, "AdvancedMicrophoneDescription is null");
            Assert.NotNull(_audioPage.SMBAdvancedMicrophoneQuickDescription, "AdvancedMicrophoneQuickDescription is null");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, 2, "The UI should show completely in 2 seconds");
        }

        [Then(@"Keep the privacy access link for Microphone for SMB")]
        public void ThenKeepThePrivacyAccessLinkForMicrophoneForSMB()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_audioPage.SMBGoToWindowsPrivacySettings, "SMBGoToWindowsPrivacySettings is null");
        }

    }
}
