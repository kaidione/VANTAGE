using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingHomepageOCLabelSteps
    {
        private InformationalWebDriver _webDriver;
        private GamingThermalModePages _gamingThermalModePages;
        private ToggleState _enabledGPUState;
        private ToggleState _enabledGPUStateafter;
        public GamingHomepageOCLabelSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }
        [Then(@"Check the Performance OverClock in homepage LEGION EDGE")]
        public void ThenThePOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance");
        }

        [Then(@"Check the Performance Enable OverClock in homepage LEGION EDGE")]
        public void ThenThePEOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance | Overclock on");
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance");
        }

        [Then(@"Check the Performance OverClock Value in the tools")]
        public void ThenThePOverClockIsInTools()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance");
        }
        [Then(@"Check the Quiet OverClock in homepage LEGION EDGE")]
        public void ThenTheQOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Quite | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Quiet");
        }
        [Then(@"Check the Quiet Enable OverClock in homepage LEGION EDGE")]
        public void ThenTheQEOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Quite | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Quiet");
        }
        [Then(@"Check the Balance OverClock in homepage LEGION EDGE")]
        public void ThenTheBOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance");
        }
        [Then(@"Check the Balance Enable OverClock in homepage LEGION EDGE")]
        public void ThenTheBEOverClockIsInhomepageLEGINEEDGE()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance | Overclock on");
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance");
        }
        [Then(@"Check the OverClock Value in the tools")]
        public void ThenTheOverClockValuesInTools()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModePerformance);
        }

        [When(@"Need Enable OverClocking Checkbox Status")]
        public void ThenEnableOverClockingCheckboxStatusShouldNotBeChanged()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _enabledGPUState = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            if (_enabledGPUState.ToString() == "Off")
            {
                _gamingThermalModePages.EnableOCCheckboxElement.Click();
            }
            _enabledGPUStateafter = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            Assert.AreEqual(_enabledGPUStateafter.ToString(), "On");
        }
        [When(@"Not Enable OverClocking checkbox status")]
        public void WhenNotEnableOverClockingCheckboxStatusShouldNotBeChanged()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _enabledGPUState = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            if (_enabledGPUState.ToString() == "On")
            {
                _gamingThermalModePages.EnableOCCheckboxElement.Click();
            }
            _enabledGPUStateafter = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            Assert.AreEqual(_enabledGPUStateafter.ToString(), "Off");
        }
    }
}
