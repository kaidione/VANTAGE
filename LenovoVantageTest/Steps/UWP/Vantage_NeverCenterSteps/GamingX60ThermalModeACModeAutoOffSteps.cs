using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX60ThermalModeACModeAutoOffSteps
    {
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;
        private ToggleState _autoAdjustState;

        public GamingX60ThermalModeACModeAutoOffSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Auto adjust checkbox is (.*)")]
        public void GivenAutoAdjustCheckboxIs(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            ToggleState toggleState = ToggleState.Off;
            if (p0.ToLower().Equals("on"))
            {
                toggleState = ToggleState.On;
            }
            _gamingThermalModePages.SetThermalModeAutoAdjustCheckbox(_gamingThermalModePages.GetThermalModeAutoAdjustCheckBox, toggleState);
            _autoAdjustState = toggleState;
        }

        [When(@"Check the Auto adjust checkbox status")]
        public void WhenCheckTheAutoAdjustCheckboxCheckboxStatus()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _autoAdjustState = _gamingThermalModePages.GetAutoAdjustStatusInThermalModeSettings();
        }

        [Then(@"Auto adjust checkbox status should not be changed")]
        public void ThenAutoAdjustCheckboxStatusShouldNotBeChanged()
        {
            Assert.AreEqual(_autoAdjustState, _gamingThermalModePages.GetAutoAdjustStatusInThermalModeSettings());
        }

        [Then(@"The Intelligent Sub Mode value is (.*) And the Method is (.*)")]
        public void ThenTheIntelligentSubModeValueIsAndTheMethodIsGetThermalMode(int p0, string p1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.IsTrue(NerveCenterHelper.GetThermalModeValue(p0, p1), string.Format("Get {0} Value is ", p1) + p0);
        }
    }
}
