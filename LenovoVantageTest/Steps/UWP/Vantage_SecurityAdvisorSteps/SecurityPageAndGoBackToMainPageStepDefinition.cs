namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityPageAndGoBackToMainPageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;

        public SecurityPageAndGoBackToMainPageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"the page title is Security and there is Back link")]
        public void ThenThePageTitleIsSecurityAndThereIsBackLink()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.securityTitle.Displayed);
            Assert.IsTrue(securityPage.backLink.Enabled);
        }
    }
}
