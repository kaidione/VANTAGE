namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class PasswordHealthItemStepDefiniation
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;

        public PasswordHealthItemStepDefiniation(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Click Intermediate Security Tab")]
        public void ThenClickIntermediateSecurityTab()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.intermediateSecurityTab.Click();
            securityPage.ScrollScreen();

            /// Password Health Section Assertion
            Assert.IsTrue(securityPage.passwordHealthText.Displayed);

            //securityPage.VerifyContentAreEqual("INSTALLED", securityPage.passwordHealthInstalledText);
            securityPage.VerifyContentAreEqual("NOT INSTALLED", securityPage.passwordHealthNotInstalledText);
            Assert.IsFalse(securityPage.myOwnPasswordCheckBox.Selected);

            /// Finger Print Read Section Assertion
            securityPage.VerifyContentAreEqual("Fingerprint Reader", securityPage.fingerPrintReaderText);
        }

        [Then(@"Click the checkbox of I have my own password manager")]
        public void ThenClickTheCheckboxOfIHaveMyOwnPasswordManager()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.myOwnPasswordCheckBox.Click();
            Assert.IsTrue(securityPage.iHaveMyOwnPasswordHealth.Enabled);
            securityPage.myOwnPasswordCheckBox.Click();
        }
    }
}
