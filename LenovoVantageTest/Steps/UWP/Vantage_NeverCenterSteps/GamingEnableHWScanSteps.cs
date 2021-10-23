using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingEnableHWScanSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingEnableHWScanSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Machine is Gaming")]
        public void GivenMachineIsGaming()
        {
            Assert.IsTrue(NerveCenterHelper.GetMachineIsGaming());
            Thread.Sleep(5000);
        }

        [When(@"Check the HareWare Scan icon")]
        public void WhenCheckTheHareWareScanIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsHWScan);
        }

        [When(@"Click the HareWare Scan icon")]
        public void WhenClickTheHareWareScanIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SystemToolsHWScan);
            _nerveCenterPages.SystemToolsHWScan.Click();
        }

        [Then(@"Open HareWare Scan page")]
        public void ThenOpenHareWareScanPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HwScanTitle);
        }

        [When(@"Enter Auto Close page")]
        public void WhenEnterAutoClosePage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "LegionEdgeAutoCloseIcon element is null");
            _nerveCenterPages.LegionEdgeAutoCloseIcon.Click();
            _nerveCenterPages.LegionEdgeAutoCloseIcon?.Click();
        }

        [When(@"Back to the homepage")]
        public void WhenBackToTheHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoCloseBackLink);
            _nerveCenterPages.AutoCloseBackLink.Click();
        }
    }
}
