using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingReskinSupportSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        public GamingReskinSupportSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Click the Support Icon")]
        public void WhenClickTheSupportIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportNVLink);
            _nerveCenterPages.SupportNVLink.Click();
            Thread.Sleep(2000);
        }

        [When(@"Check Open Support page")]
        public void WhenCheckOpenSupportPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportTitle, "SupportTitle is null");
        }

        [When(@"Check Open Support link")]
        public void WhenCheckOpenSupportLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportNVLink);
            _nerveCenterPages.SupportNVLink.Click();
            Assert.IsNotNull(_nerveCenterPages.SupportDPLink);
            Thread.Sleep(2000);
        }

        [When(@"Click the Support link")]
        public void WhenClickTheSupportLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportNVLink);
            _nerveCenterPages.SupportNVLink.Click();
            Assert.IsNotNull(_nerveCenterPages.SupportDPLink);
            _nerveCenterPages.SupportDPLink.Click();
            Thread.Sleep(2000);
        }

        [When(@"Check the Support link")]
        public void WhenCheckTheSupportLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.SupportNVLink);
            _nerveCenterPages.SupportNVLink.Click();
            Assert.IsNotNull(_nerveCenterPages.SupportDPLink);
        }

        [When(@"Pagedown")]
        public void WhenPagedown()
        {
            SendKeys.SendWait("{PgDn}");
        }
    }
}