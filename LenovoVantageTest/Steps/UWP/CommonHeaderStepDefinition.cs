using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class CommonHeaderStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private InformationalWebDriver _session;

        public CommonHeaderStepDefinition(InformationalWebDriver appDriver)
        {
            this._session = appDriver;
        }
        [Given("the first number is (.*)")]
        public void GivenTheFirstNumberIs(int number)
        {
            //TODO: implement arrange (precondition) logic
            // For storing and retrieving scenario-specific data see https://go.specflow.org/doc-sharingdata 
            // To use the multiline text or the table argument of the scenario,
            // additional string/Table parameters can be defined on the step definition
            // method. 

            _scenarioContext.Pending();
        }

        [StepDefinition(@"Hover the mouse on the '(.*)' button using the automationId specified with json path '(.*)'")]
        public void HoverTheMouseOnTheButton(string _buttonComment, string _jsonPath)
        {

            VantageUI.instance.VantageMouseFocusElementtUsingAutomationId(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString());
        }

        //[StepDefinition(@"Go to Smart Assist page")]
        //public void gotoSmartAssist()
        //{
        //    new SettingsBase(_session.Session).SmartAssist?.Click();
        //}

        [StepDefinition(@"verify there is NO Smart Assist")]
        public void verifySmartAssist()
        {
            Assert.IsTrue(new SettingsBase(_session.Session).SmartAssist == null);
        }

        [StepDefinition(@"Click on the top left of vantage")]
        public void WhenClickVantageLİcon()
        {
            VantageCommonHelper.SetMouseClick("24", "56");
        }

        [Given(@"Restart IMC Service")]
        public void GivenRestartIMCService()
        {
            Common.RestartService();
        }

        [Given(@"install Vantage with default server")]
        public void GivenİnstallVantageWithoutLaunching()
        {
            VantageUI.instance.installVantage(TestRequirementHelper.Instance.GetTestRequirement().Value<string>("VantagePackagePath"));

            DateTime begin = DateTime.Now;
            while (UwpAppManagement.SearchUwpAppByName(Constants.PackageName4Vantage3) == null && (DateTime.Now - begin).TotalSeconds < 60)
            {
                System.Threading.Thread.Sleep(1000);
            }
            string server = TestRequirementHelper.Instance.GetTestRequirement().Value<string>("Server");
            VantageUI.instance.modifyConfigJsonFile(server);
        }
    }
}
