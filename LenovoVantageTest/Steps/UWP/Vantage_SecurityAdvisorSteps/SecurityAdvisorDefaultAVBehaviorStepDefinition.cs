namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityAdvisorDefaultAVBehaviorStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;
        private AntiVirusPage antiVirusPage;

        public SecurityAdvisorDefaultAVBehaviorStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"FireWall and Anti-Virus are all disabled")]
        public void GivenFireWallAndAnti_VirusAreAllDisabled()
        {

        }

        [Then(@"Anti-Vius ListItem Is Disabled")]
        public void ThenAnti_ViusIsDisabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Virus protection DISABLED", antiVirusPage.antiVirusDisabled);
        }

        [Then(@"FireWall ListItem Is Disabled")]
        public void ThenFireWallIsDisabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Home network protection DISABLED", antiVirusPage.fireWallDisabled);
        }

        [Then(@"Anti-Vius ListItem Is Enabled")]
        public void ThenAnti_ViusListItemIsEnabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Virus protection ENABLED", antiVirusPage.antiVirusEnabled);
        }

        [Then(@"FireWall ListItem Is Enabled")]
        public void ThenFireWallListItemIsEnabled()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Home network protection ENABLED", antiVirusPage.fireWallEnabled);
        }

        [Then(@"The Page Has Windows Defender Basic Protection Text")]
        public void ThenThePageHasWindowsDefenderBasicProtectionText()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Virus protection DISABLED", antiVirusPage.antiVirusDisabled);
        }

        [Then(@"Launch Mcafee button is here and text is right")]
        public void ThenLaunchMcafeeButtonIsHereAndTextIsRight()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Launch McAfee", antiVirusPage.launchMcaFeeButton);
        }

        [Then(@"Subscribe Now link is here and text is right")]
        public void ThenSubcribeNowLinkIsHereAndTextIsRight()
        {
            antiVirusPage = new AntiVirusPage(webDriver.Session);
            antiVirusPage.VerifyContentAreEqual("Subscribe Now", antiVirusPage.subscribeLink);
        }
    }
}
