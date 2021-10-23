namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class NoSAWidgetOnDashBoardStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;

        public NoSAWidgetOnDashBoardStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Verify this is no SA widget on Dashboard")]
        public void ThenVerifyThisIsNoSAWidgetOnDashboard()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.VerifySAWidgetNotExist();
        }
    }
}
