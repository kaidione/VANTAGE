namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class WIFISecurityPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private WIFISecurityPage wifiSecurityPage;

        public WIFISecurityPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Show noInternetConnection Pane on WiFi Security page")]
        public void ThenShowNoInternetConnectionPaneOnWiFiSecurityPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.IsTrue(wifiSecurityPage.noInternetConnectionPane_WiFiPage.Enabled);
        }

        [Then(@"Show Offline icon on WiFi Security page")]
        public void ThenShowOfflineIconOnWiFiSecurityPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.IsTrue(wifiSecurityPage.offlineIcon_WiFiPage.Enabled);
        }

        [Then(@"Verify it opens “WiFi security” page")]
        public void ThenVerifyItOpensWiFiSecurityPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.IsTrue(wifiSecurityPage.wiFiSecurityHeaderTitle.Displayed);
        }

        [Then(@"Click Back Link on WiFi Security page")]
        public void ThenClickBackLinkOnWiFiSecurityPage()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.backLink_wiFiSecurityPage.Click();
        }

        [Then(@"Verify WiFi security page name is displayed correctly")]
        public void ThenVerifyWiFiSecurityPageNameIsDisplayedCorrectly()
        {
            wifiSecurityPage = new WIFISecurityPage(webDriver.Session);
            wifiSecurityPage.VerifyContentAreEqual(wifiSecurityPage.expectWiFiSecurityHeaderTitle, wifiSecurityPage.wiFiSecurityHeaderTitle);
        }

    }

}
