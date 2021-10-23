namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityAdvisorAboutFingerPrintReaderStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;

        public SecurityAdvisorAboutFingerPrintReaderStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }


        [Then(@"Scroll the scrollbar to make sure the Fingerprint visiable")]
        public void ThenScrollTheScrollbarToMakeSureTheFingerprintVisiable()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.ScrollScreen();
        }

        [Then(@"Verify the Finger Print Reader status status is NOT ENROLLED")]
        public void ThenVerifyTheFingerPrintReaderStatusStatusIsNOTENROLLED()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.IsTrue(securityPage.fingerPrintReaderNotEnrolledText.Enabled);
        }

    }
}
