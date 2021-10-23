namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class BasicSecurityPageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;
        private DashBoardPage dashBoardPage;

        public BasicSecurityPageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"The Basic Security SubTab Has Anti-Virus and FireWall text")]
        public void ThenTheBasicSecuritySubTabHasAnti_VirusAndFireWallText()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual(securityPage.expect_antiVirusText, securityPage.antivirusText);
            securityPage.VerifyContentAreEqual(securityPage.expect_firewallText, securityPage.firewallText);
        }


        [Then(@"The Basic Security SubTab Has Anti-Virus and FireWall Button")]
        public void ThenTheBasicSecuritySubTabHasAnti_VirusAndFireWallButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.goToAntiVirusButton.Enabled);
            Assert.IsTrue(securityPage.goToFireWallButton.Enabled);
        }
    }
}
