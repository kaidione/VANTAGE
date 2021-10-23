using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX60GPUOCOnSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;

        public GamingX60GPUOCOnSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"The OC value is (.*) And the Method is (.*)")]
        public void ThenTheGPUOCValueIsAndTheMethodIsGetGPUOCStatus(int p0, string p1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.IsTrue(NerveCenterHelper.GetThermalModeValue(p0, p1), string.Format("Get {0} Value is ", p1) + p0);
        }

        [Then(@"The OC On label should be shown in Performance Mode")]
        public void ThenTheOCOnLabelShouldBeShownInPerformanceMode()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModePerformanceOCOn);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModePerformanceOCOnName);
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance | Overclock on");
        }

        [Then(@"The OC On label should not be shown in Performance Mode")]
        public void ThenTheOCOnLabelShouldNotBeShownInPerformanceMode()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNull(_gamingThermalModePages.ThermalModePerformanceOCOn);
            Assert.IsNull(_gamingThermalModePages.ThermalModePerformanceOCOnName);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Performance | Overclock on");
        }

        [Then(@"The OC On label should not be shown in Balance Mode")]
        public void ThenTheOCOnLabelShouldNotBeShownInBalanceMode()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNull(_gamingThermalModePages.ThermalModeBalanceOCOnName);
            Assert.AreNotEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance | Overclock on");
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeBalance);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeBalanceName);
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance");
        }

        [Then(@"The OC On label should be shown in Balance Mode")]
        public void ThenTheOCOnLabelShouldBeShownInBalanceMode()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeBalance);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeBalanceOCOnName);
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Balance | Overclock on");
        }

        [Then(@"The OC On label should not be shown in Quiet Mode")]
        public void ThenTheOCOnLabelShouldNotBeShownInQuietMode()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeQuiet);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeQuietName);
            Assert.AreEqual(_gamingThermalModePages.ThermalModeInHomepage.Text, "Thermal Mode Quiet");
        }

        [When(@"Click the Legion Edge")]
        public void WhenClickTheHeaderImage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge);
            _nerveCenterPages.GamingLegionEdge.Click();
        }

        [When(@"Hover the '(.*)' in the Legion Edge")]
        public void WhenHoverThePerformacnceModeOCOnInTheLegionEdge(string item)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            switch (item)
            {
                case "Performacnce Mode OC On":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingThermalModePages.ThermalModePerformanceOCOn);
                    break;
                case "Performacnce Mode":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingThermalModePages.ThermalModePerformance);
                    break;
                case "Balance Mode":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingThermalModePages.ThermalModeBalance);
                    break;
                case "Quiet Mode":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingThermalModePages.ThermalModeQuiet);
                    break;
                default:
                    Assert.Fail("NO target elements found.");
                    break;
            }
        }

        [Then(@"The OC On tips (.*) should be shown")]
        public void ThenTheOCOnTipsShouldBeShown(string p2)
        {
            Assert.AreEqual(p2, _gamingThermalModePages.ThermalModeInHomepage.GetAttribute("HelpText"));
        }
    }
}
