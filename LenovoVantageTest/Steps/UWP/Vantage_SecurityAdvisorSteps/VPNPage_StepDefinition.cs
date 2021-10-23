namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class VPNPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private VPNPage vPNPage;

        public VPNPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Show noInternetConnection Pane on VPN page")]
        public void ThenShowNoInternetConnectionPaneOnVPNPage()
        {
            vPNPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vPNPage.noInternetConnectionPane_VPNPage.Enabled);
        }

        [Then(@"Show Offline icon on VPN page")]
        public void ThenShowOfflineIconOnVPNPage()
        {
            vPNPage = new VPNPage(webDriver.Session);
            Assert.IsTrue(vPNPage.offlineIcon_VPNPage.Enabled);
        }

        [Then(@"Verify VPN page name is displayed correctly")]
        public void ThenVerifyVPNPageNameIsDisplayedCorrectly()
        {
            vPNPage = new VPNPage(webDriver.Session);
            vPNPage.VerifyContentAreEqual(vPNPage.expectVPNPageName, vPNPage.vpnSecurityTitle);
        }

        [Then(@"Click Back Link on VPN Security page")]
        public void ThenClickBackLinkOnVPNSecurityPage()
        {
            vPNPage = new VPNPage(webDriver.Session);
            vPNPage.backLinkOnVPNPage.Click();
        }

    }

}
