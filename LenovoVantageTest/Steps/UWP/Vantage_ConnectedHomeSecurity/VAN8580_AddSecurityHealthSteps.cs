using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Features.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public class VAN8580_AddSecurityHealthSteps
    {
        private InformationalWebDriver _webDriver;
        private CHSAdminPage _CHSAdminPage;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;
        public VAN8580_AddSecurityHealthSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Check Join the CHS Group")]
        public void ThenCheckJoinTheCHSGroup()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSOverview, "fail to join CHS group");
        }

        [When(@"Create Password")]
        public void WhenCreatePassword()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.ChangeWinPassword("", "1");
        }

        [Given(@"Delete Machine Password")]
        public void GivenDeleteMachinePassword()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.ChangeWinPassword("1", "");
        }

        [Then(@"(.*) Result Keep the Same result with System")]
        public void ThenResultKeepTheSameResultWithSystem(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            bool pluginResult = _CHSAdminPage.GetSecurityHealthResult(p0);
            bool systemResult = _CHSAdminPage.GetSystemResult(p0);
            Assert.AreEqual(systemResult, pluginResult);
        }

        [When(@"Click Here Link in CHS Subpage")]
        public void GivenClickHereLinkInCHSSubpage()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSHereLink, "The CHS Here link not found");
            _CHSAdminPage.CHSHereLink.Click();
        }

        [Then(@"Check Here Link in CHS Subpage")]
        public void ThenCheckHereLinkInCHSSubpage()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSHereLink, "The CHS Here link not found");
        }


        [Then(@"The Article Pop up")]
        public void ThenTheArticlePopUp()
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            Assert.IsNotNull(_CHSAdminPage.CHSArticle, "The CHS Article don't pop up!");
        }

        [When(@"(.*) Firewall")]
        public void WhenDisableFirewall(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.ChangeFirewallStatus(p0);
        }

        [Given(@"(.*) Developermode")]
        public void GivenDisableDevelopermode(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.ChangeDeveloperMode(p0);
        }

        [Then(@"Check (.*) in SH")]
        public void ThenCheckNopasswordInSH(bool p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            bool pluginResult = _CHSAdminPage.GetSecurityHealthResult("PasswordProtection");
            Assert.AreEqual(p0, pluginResult);
        }

        [When(@"Enable (.*)")]
        public void WhenEnableSideload(string p0)
        {
            _CHSAdminPage = new CHSAdminPage(_webDriver.Session);
            _CHSAdminPage.EnableSideloadStatus(p0);
        }
    }
}
