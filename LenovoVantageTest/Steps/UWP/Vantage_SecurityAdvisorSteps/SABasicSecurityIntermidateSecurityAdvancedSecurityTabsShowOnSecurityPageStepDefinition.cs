namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SABasicSecurityIntermidateSecurityAdvancedSecurityTabsShowOnSecurityPageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;

        public SABasicSecurityIntermidateSecurityAdvancedSecurityTabsShowOnSecurityPageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        /// <summary>
        /// Verify Security Main page contains "Basic Security", "Intermidate Security" and "Advanced Security" 
        /// </summary>
        [Then(@"the page contains Basic Security, Intermidate Security and Advanced Security")]
        public void ThenThePageContainsBasicSecurityIntermidateSecurityAndAdvancedSecurity()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.basicSecurityTab.Displayed);
            Assert.IsTrue(securityPage.intermediateSecurityTab.Displayed);
            Assert.IsTrue(securityPage.advancedSecurityTab.Displayed);
        }
    }
}
