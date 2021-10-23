namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class MySecurityPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private MySecurityPage mySecurityPage;

        public MySecurityPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Verify the widget title show correctly")]
        public void ThenVerifyTheWidgetTitleShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QATitle, mySecurityPage.qATitle);
        }

        [Then(@"Verify the widget list itemOne question show correctly")]
        public void ThenVerifyTheWidgetListItemOneQuestionShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            //mySecurityPage.ScrollScreen();
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion1_Title, mySecurityPage.qAQuestion1_Title);
        }

        [Then(@"Verify the widget list itemTwo question show correctly")]
        public void ThenVerifyTheWidgetListItemTwoQuestionShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            //mySecurityPage.ScrollScreen();
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion2_Title, mySecurityPage.qAQuestion2_Title);
        }

        [Then(@"Verify the widget list itemThree question show correctly")]
        public void ThenVerifyTheWidgetListItemThreeQuestionShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion3_Title, mySecurityPage.qAQuestion3_Title);
        }

        [Then(@"Verify the widget list itemFour question show correctly")]
        public void ThenVerifyTheWidgetListItemFourQuestionShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion4_Title, mySecurityPage.qAQuestion4_Title);
        }

        [Then(@"Verify the widget list itemFive question show correctly")]
        public void ThenVerifyTheWidgetListItemFiveQuestionShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion5_Title, mySecurityPage.qAQuestion5_Title);
        }


        [Then(@"Verify the widget list item question One content show correctly")]
        public void ThenVerifyTheWidgetListItemQuestionOneContentShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion1_Content, mySecurityPage.qAQuestion1_Content);
        }

        [Then(@"Verify the widget list item question Two content show correctly")]
        public void ThenVerifyTheWidgetListItemQuestionTwoContentShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion2_Content, mySecurityPage.qAQuestion2_Content);
        }


        [Then(@"Verify the widget list item question Three content show correctly")]
        public void ThenVerifyTheWidgetListItemQuestionThreeContentShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.ScrollScreen();
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion3_Content, mySecurityPage.qAQuestion3_Content);
        }

        [Then(@"Verify the widget list item question Four content show correctly")]
        public void ThenVerifyTheWidgetListItemQuestionFourContentShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion4_Content, mySecurityPage.qAQuestion4_Content);
        }

        [Then(@"Verify the widget list item question Five content show correctly")]
        public void ThenVerifyTheWidgetListItemQuestionFiveContentShowCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_QAQuestion5_Content, mySecurityPage.qAQuestion5_Content);
        }

        [When(@"Click list itemOne Label")]
        public void WhenClickListItemOneLabel()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            //mySecurityPage.ScrollScreen();
            mySecurityPage.qAQuestion1_Title.Click();
        }

        [When(@"Click list itemTwo Label")]
        public void WhenClickListItemTwoLabel()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.ScrollScreen();
            mySecurityPage.qAQuestion2_Title.Click();
        }

        [When(@"Click list itemThree Label")]
        public void WhenClickListItemThreeLabel()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.ScrollScreen();
            mySecurityPage.qAQuestion3_Title.Click();
        }

        [When(@"Click list itemFour Label")]
        public void WhenClickListItemFourLabel()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.ScrollScreen();
            mySecurityPage.qAQuestion4_Title.Click();
        }

        [When(@"Click list itemFive Label")]
        public void WhenClickListItemFiveLabel()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.ScrollScreen();
            mySecurityPage.qAQuestion5_Title.Click();
        }

        [Then(@"Click “BACK” link on My security page")]
        public void ThenClickBACKLinkOnMySecurityPage()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.backLink_MySecurityPage.Click();
        }

        [Then(@"Verify My security page name is displayed correctly")]
        public void ThenVerifyMySecurityPageNameIsDisplayedCorrectly()
        {
            mySecurityPage = new MySecurityPage(webDriver.Session);
            mySecurityPage.VerifyContentAreEqual(mySecurityPage.expect_MySecurityPageName, mySecurityPage.mySecurityTitle);
        }

    }

}
