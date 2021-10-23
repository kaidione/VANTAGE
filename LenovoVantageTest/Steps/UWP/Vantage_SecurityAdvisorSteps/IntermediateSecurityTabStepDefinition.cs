namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class IntermediateSecurityTabStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;
        private PasswordHealthPage passwordHealthPage;

        public IntermediateSecurityTabStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Click GO TO PASSWORD HEALTH button")]
        public void ThenClickGOTOPASSWORDHEALTHButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.goToPasswordHealthButton.Click();
        }

        [Then(@"The Dashlane is not installed and back to SA")]
        public void ThenTheDashlaneIsNotInstalledAndBackToSA()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.getDashLaneButton.Displayed);
            Assert.IsTrue(passwordHealthPage.getDashLaneButton.Enabled);
            passwordHealthPage.backLink_PasswordHealthPage.Click();
        }

        [Then(@"VISIT FINGERPRINT READER button")]
        public void ThenVISITFINGERPRINTREADERButton()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.intermediateSecurityTab.Click();
            securityPage.ScrollScreen();
            securityPage.visitFingerPrintReaderButton.Click();
        }
    }
}
