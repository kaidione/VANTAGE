namespace LenovoVantageTestWithThirdPartAntiVirusWithoutFirewall.Steps
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityAdvisorDefaultAVIsThirdPartyStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;
        private AntiVirusPage antiVirusPage;

        public SecurityAdvisorDefaultAVIsThirdPartyStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [When(@"The third part anti virus status is enable")]
        public void WhenTheThirdPartAntiVirusStatusIsEnable()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.virusEnableStatus.Enabled);
        }

        [Then(@"Click the collasp of McAFee and verify the text")]
        public void ThenClickTheCollaspOfMcAFeeAndVerifyTheText()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.expandMcaFeeButton.Click();
            Assert.IsTrue(antiVirusPage.getMcafeeButton.Enabled);
            Assert.IsTrue(antiVirusPage.mcafeeLiveSafeProtection.Enabled);
            Assert.IsTrue(antiVirusPage.protectYourDeviceText.Enabled);
        }

        [Then(@"Verify the Anti Viurs in SA widget is PARTIALLY PROTECTED")]
        public void ThenVerifyTheAntiViursInSAWidgetIsPARTIALLYPROTECTED()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antiVirusPage.antivirusPartiallyProtect_saWidget, antiVirusPage.antivirusLink.GetAttribute("Name").Trim());
            //Assert.IsTrue(antiVirusPage.saAntiVirusStatus.Enabled);
            //antiVirusPage.getMcafeeButton.Click();
        }

        [Then(@"Show Offline icon in Anti-virus page")]
        public void ThenShowOfflineIconInAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.offlineIcon_antiVirusPage.Enabled);
        }

        [Then(@"verify offline icon is not show in Anti-virus page")]
        public void ThenVerifyOfflineIconIsNotShowInAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.elementIsNoPresent(antiVirusPage.offlineIcon_antiVirusPage_autoid, "AutomationId");
        }

        [Then(@"Show offline banner in Anti-virus page")]
        public void ThenShowOfflineBannerInAnti_VirusPage()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            Assert.IsTrue(antiVirusPage.noConnectionPane.Enabled);
        }

    }
}
