namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class ClickPasswordHealthLinkOnAVPageWillGoToPMPageStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private DashBoardPage dashBoardPage;

        public ClickPasswordHealthLinkOnAVPageWillGoToPMPageStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }
        [Given(@"Click Security and Anti-Virus Link")]
        public void GivenClickSecurityAndAnti_VirusLink()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.HoverOnSAListItem(dashBoardPage.securityToggle);
            dashBoardPage.antiVriusLink.Click();
        }
    }
}
