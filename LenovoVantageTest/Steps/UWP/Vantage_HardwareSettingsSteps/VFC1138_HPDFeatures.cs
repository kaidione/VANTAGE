using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class VFC1138_HPDFeatures
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private InformationalWebDriver _webDriver;
        private HSHPDPage _hSHPDPage;

        public VFC1138_HPDFeatures(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The toggle of Human Presence Sensing is greyed out and user can not change the toggle's state")]
        public void ThenCheckToggleIsGreyed()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.IsFalse(_hSHPDPage.IntelligentSecurityToggle.Enabled, "The IntelligentSecurityToggle is not greyed");
        }

        [Then(@"the context is Sensor has an issue. This feature is unavailable and the style follow the UI SPEC")]
        public void ThenTheContextIsAndTheStyleFollowTheUISPEC()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.IsNotNull(_hSHPDPage.IntelligentSecurityHpdSensorNote, "The IntelligentSecurityHpdSensorNote is null");
            Assert.AreEqual(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.HPD.IntelligentSecurityHpdSensorNoteText").ToString(), _hSHPDPage.ShowTextbox(_hSHPDPage.IntelligentSecurityHpdSensorNote));
        }

        [Then(@"The whole HPD feature can not show except the total toggle Human Presence Sensing")]
        public void ThenCheckHumanPresenceSensing()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.IsNotNull(_hSHPDPage.HumanPresenceSensingTitle, "The HumanPresenceSensingTitle is null");
            Assert.IsNull(_hSHPDPage.HPDZeroTouchLoginTitle, "The HPDZeroTouchLoginTitle is not null");
        }

    }
}
