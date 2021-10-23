using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class OptimizeMyMicrophoneSteps
    {
        private HSAudioSettingsPage _audioPage;
        private InformationalWebDriver _webDriver;
        private string _voiceRecognitionState;
        private string _onlyMyVoiceState;
        private string _normalState;
        private string _multipleVoicesState;

        public OptimizeMyMicrophoneSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Check OptimizeMyMicrophone ""(.*)""")]
        public void GivenCheckOptimizeMyMicrophone(string type)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (type == "title")
            {
                Assert.IsNotNull(_audioPage.AudioMicrophoneOptimizeTitle, "The AudioMicrophoneOptimizeTitle is null");
                Assert.AreEqual(_audioPage.AudioMicrophoneOptimizeTitle.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AudioMicrophoneOptimizeTitleText").ToString(), "The titleText is not true");
            }
            if (type == "description")
            {
                Assert.IsNotNull(_audioPage.AudioMicrophoneOptimizeCaption, "The AudioMicrophoneOptimizeCaption is null");
                Assert.AreEqual(_audioPage.AudioMicrophoneOptimizeCaption.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.OptimizeMicrophoneCaptionContext").ToString(), "The descriptionText is not true");
            }
            if (type == "VoiceRecognition")
            {
                Assert.IsNotNull(_audioPage.RadioMicrophoneVoiceRecognition, "The RadioMicrophoneVoiceRecognition is null");
                Assert.AreEqual(_audioPage.RadioMicrophoneVoiceRecognition.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.VoiceRecognitionText").ToString(), "The VoiceRecognitionText is not true");
                Assert.IsNotNull(_audioPage.RadioMicrophoneVoiceRecognitionLabel, "The RadioMicrophoneVoiceRecognitionLabel is null");
            }
            if (type == "OnlyMyVoice")
            {
                Assert.IsNotNull(_audioPage.RadioMicrophoneOnlyMyVoice, "The RadioMicrophoneOnlyMyVoice is null");
                Assert.AreEqual(_audioPage.RadioMicrophoneOnlyMyVoice.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.OnlyMyVoiceText").ToString(), "The OnlyMyVoiceText is not true");
                Assert.IsNotNull(_audioPage.RadioMicrophoneOnlyMyVoiceLabel, "The RadioMicrophoneVoiceRecognitionLabel is null");
            }
            if (type == "Normal")
            {
                Assert.IsNotNull(_audioPage.RadioMicrophoneNormal, "The RadioMicrophoneOnlyMyVoice is null");
                Assert.AreEqual(_audioPage.RadioMicrophoneNormal.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.NormalText").ToString(), "The NormalText is not true");
                Assert.IsNotNull(_audioPage.RadioMicrophoneNormalLabel, "The RadioMicrophoneNormalLabel is null");
            }
            if (type == "MultipleVoices")
            {
                Assert.IsNotNull(_audioPage.RadioMicrophoneMultipleVoices, "The RadioMicrophoneOnlyMyVoice is null");
                Assert.AreEqual(_audioPage.RadioMicrophoneMultipleVoices.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.MultipleVoicesText").ToString(), "The MultipleVoicesText is not true");
                Assert.IsNotNull(_audioPage.RadioMicrophoneMultipleVoicesLabel, "The RadioMicrophoneMultipleVoicesLabel is null");
            }
        }

        [Given(@"Get four button value")]
        public void GivenGetFourButtonValue()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            _voiceRecognitionState = _audioPage.RadioMicrophoneVoiceRecognition.GetAttribute("Toggle.ToggleState");
            _onlyMyVoiceState = _audioPage.RadioMicrophoneOnlyMyVoice.GetAttribute("Toggle.ToggleState");
            _normalState = _audioPage.RadioMicrophoneNormal.GetAttribute("Toggle.ToggleState");
            _multipleVoicesState = _audioPage.RadioMicrophoneMultipleVoices.GetAttribute("Toggle.ToggleState");
        }

        [Then(@"The four button value is same")]
        public void ThenTheFourButtonValueIsSame()
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(_voiceRecognitionState, _audioPage.RadioMicrophoneVoiceRecognition.GetAttribute("Toggle.ToggleState"), "The _voiceRecognitionState is not same");
            Assert.AreEqual(_onlyMyVoiceState, _audioPage.RadioMicrophoneOnlyMyVoice.GetAttribute("Toggle.ToggleState"), "The _onlyMyVoiceState is not same");
            Assert.AreEqual(_normalState, _audioPage.RadioMicrophoneNormal.GetAttribute("Toggle.ToggleState"), "The _normalState is not same");
            Assert.AreEqual(_multipleVoicesState, _audioPage.RadioMicrophoneMultipleVoices.GetAttribute("Toggle.ToggleState"), "The _multipleVoicesState is not same");
        }

        [Given(@"Switch ""(.*)"" Microphone button")]
        public void GivenSwitchMicrophoneButton(string p0)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (p0)
            {
                case "VoiceRecognition":
                    bool result = VantageCommonHelper.SwitchToggleStatus(_audioPage.RadioMicrophoneVoiceRecognition, ToggleState.On);
                    Assert.IsTrue(result);
                    break;
                case "OnlyMyVoice":
                    bool resultOn = VantageCommonHelper.SwitchToggleStatus(_audioPage.RadioMicrophoneOnlyMyVoice, ToggleState.On);
                    Assert.IsTrue(resultOn);
                    break;
                case "Normal":
                    bool resultNo = VantageCommonHelper.SwitchToggleStatus(_audioPage.RadioMicrophoneNormal, ToggleState.On);
                    Assert.IsTrue(resultNo);
                    break;
                case "MultipleVoices":
                    bool resultMu = VantageCommonHelper.SwitchToggleStatus(_audioPage.RadioMicrophoneMultipleVoices, ToggleState.On);
                    Assert.IsTrue(resultMu);
                    break;
            }
        }

        [Then(@"The ""(.*)"" Audio checkbox is ""(.*)""")]
        public void ThenTheAudioCheckboxIs(string p0, string p1)
        {
            _audioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (p1 == "gray out")
            {
                switch (p0)
                {
                    case "SuppressKeyboardNoise":
                        Assert.IsFalse(_audioPage.AudioMicrophoneSuppressCheckbox.Enabled, "The SuppressKeyboardNoise is not grayout");
                        break;
                    case "AcousticEchoCancellation":
                        Assert.IsFalse(_audioPage.AudioMicrophoneAcousticEchoCheckbox.Enabled, "The AcousticEchoCancellation is not grayout");
                        break;
                }
            }
            else
            {
                switch (p0)
                {
                    case "SuppressKeyboardNoise":
                        Assert.IsTrue(_audioPage.AudioMicrophoneSuppressCheckbox.Enabled, "The SuppressKeyboardNoise is grayout");
                        break;
                    case "AcousticEchoCancellation":
                        Assert.IsTrue(_audioPage.AudioMicrophoneAcousticEchoCheckbox.Enabled, "The AcousticEchoCancellation is grayout");
                        break;
                }
            }
        }

        [Then(@"Check Realtek ""(.*)"" value")]
        public void ThenCheckRealtekValue(string p0)
        {
            UwpAppInfo uwp = UwpAppManagement.SearchUwpAppByName("*RealtekAudioControl*");
            string commond = "shell:AppsFolder\\" + uwp.PackageFamilyName.Trim() + "!App";
            Process.Start(commond);
            Thread.Sleep(1000);
            SendKeys.SendWait("{Tab}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Tab}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Enter}");
            Thread.Sleep(1000);
            UIAutomationControl automationControl = new UIAutomationControl();
            TogglePattern toggle = null;
            //AutomationElementCollection collection = automationControl.FindChildElementsInAutomationElementByClass(AutomationElement.RootElement, "ToggleSwitch");
            switch (p0)
            {
                case "Voice Recognition":
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekVoiceRecogniton").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.On, "The reatek voice recognition value is not same with le");
                    break;
                case "OnlyMyVoice":
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekOnlyMyVoice").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.On, "The reatek OnlyMyVoice value is not same with le");
                    break;
                case "Normal":
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekVoiceRecogniton").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.Off, "The reatek voice recognition value is not same with le,Normal");
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekOnlyMyVoice").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.Off, "The reatek OnlyMyVoice value is not same with le,Normal");
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekMultiplevoices").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.Off, "The reatek MultipleVoices value is not same with le,Normal");
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekDisableMicrophone").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.Off, "The reatek Defalut value is not same with le,Normal");
                    break;
                case "MultipleVoices":
                    toggle = automationControl.FindElementByName(AutomationElement.RootElement, VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.RealTekMultiplevoices").ToString()).GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                    Assert.AreEqual(toggle.Current.ToggleState, ToggleState.On, "The reatek MultipleVoices value is not same with le");
                    break;
            }

            CommandBase.RunCmd("taskkill /f /t /im RtkUWP.exe");

        }

        [Given(@"Lunch UWP By FamilyName ""(.*)"" and type '(.*)'")]
        public void GivenLunchUWPByFamilyNameAndType(string familyname, string type)
        {
            UwpAppInfo uwp = UwpAppManagement.SearchUwpAppByName(familyname);
            string commond = "shell:AppsFolder\\" + uwp.PackageFamilyName.Trim() + type;
            Process.Start(commond);
        }

    }
}
