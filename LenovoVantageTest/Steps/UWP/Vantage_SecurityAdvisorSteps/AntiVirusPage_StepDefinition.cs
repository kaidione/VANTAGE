namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class AntiVirusPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private AntiVirusPage antiVirusPage;

        public AntiVirusPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Verify Anti-virus page name is displayed correctly")]
        public void ThenVerifyAnti_VirusPageNameIsDisplayedCorrectly()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual(antiVirusPage.expect_AntiVirusPageName, antiVirusPage.antiVirusPageTitle);
        }

        [Then(@"Click BACK link on Anti Virus page")]
        public void ThenClickBACKLinkOnAntiVirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.backLink_AntiVirusPage.Click();
        }

        [Then(@"Show noInternetConnection Pane on antivirus page")]
        public void ThenShowNoInternetConnectionPaneOnAntivirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.noInternetConnectionPane.Enabled);
        }

        [Then(@"Show Offline icon antivirus page")]
        public void ThenShowOfflineIconAntivirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.offlineIcon_antiVirusPage.Enabled);
        }

    }

}
