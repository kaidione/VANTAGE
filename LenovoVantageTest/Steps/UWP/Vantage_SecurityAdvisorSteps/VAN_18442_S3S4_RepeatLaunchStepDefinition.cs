
using System;
using Newtonsoft.Json.Linq;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework.Internal;
using System.IO;
using LenovoVantageTest;
using LenovoVantageTest.Utility;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class VAN_18442_S3S4_RepeatLaunchStepDefinition
    {
        List<string> errorlist = new List<string>();
        VantageUI vantageUI = new VantageUI();
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;
        Dictionary<string, MethodInfo> steplist = new Dictionary<string, MethodInfo>();
        enum TestType { NONE, S3, S4, Repeat };
        TestType testingType = TestType.NONE;
        public VAN_18442_S3S4_RepeatLaunchStepDefinition(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [Given("Vantage Is Closed")]
        public void VantageIsClosed()
        {
            vantageUI.CloseVantageProcess();
        }
        [Given("Latest Vantage Is Installed")]
        public void LatestVantageIsInstalled()
        {
            string ver = vantageUI.GetVantageShellVersion();

            string environment = "";
            using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCycleRequirement.json"), FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fileStream))
            {
                environment = sr.ReadToEnd();
            }
            JObject joEnvironmentRequirement = JObject.Parse(environment);
            string expectedVantageShellVersion = joEnvironmentRequirement.GetValue("VantageShell").ToString();
            string server2Test = joEnvironmentRequirement.GetValue("Server").ToString();
            string vantageShellPackagePath = Constants.VantagePackgePath;
            bool result = vantageUI.AssureVantageIsInstalledAndVersionIsRightAndGoThroughTutorial(expectedVantageShellVersion, server2Test, vantageShellPackagePath, "");
            if (!result)
            {
                Assert.IsTrue(result);
            }
        }
        [Given("Read To Go Into S3 And Wake Up")]
        public void ReadToGoIntoS3AndWakeUp()
        {
            testingType = TestType.S3;
        }
        [Given("Read To Go Into S4 And Wake Up")]
        public void ReadToGoIntoS4AndWakeUp()
        {
            testingType = TestType.S4;
        }
        [Given("Read To Repeat 10 Times")]
        public void ReadToRepeat10Times()
        {
            testingType = TestType.Repeat;
        }
        [Given("Ready To Launch Vantage")]
        public void ReadyToLaunchVantage()
        {

        }

        [Given("Ready To Click Support")]
        public void ReadyToClickSupport()
        {

        }
        [Given("Ready To Assure An Article Exists")]
        public void ReadyToAssureAnArticleExists()
        {

        }
        [Given("Ready To Click My Device")]
        public void ReadyToClickMyDevice()
        {

        }
        [Given("Ready To Assure Bios Version Exists")]
        public void ReadyToAssureBiosVersionExists()
        {

        }
        [Given("Ready To Assure Processor Exists")]
        public void ReadyToAssureProcessorExists()
        {

        }
        [Given("Ready To Click Security")]
        public void ReadyToClickSecurity()
        {

        }
        [Given("Ready To Assure Security Advisor 101 Exists")]
        public void ReadyToAssureSecurityAdvisor101Exists()
        {

        }
        [When("I Do Above Steps Repeatly")]
        public void IDoAboveStepsRepeatly()
        {
            RepeatSteps(10);
        }
        [When("I Do Above Steps 3 Time")]
        public void IDoAboveSteps3Time()
        {
            RepeatSteps();
        }
        void RepeatSteps(int _loopTime = 3)
        {
            vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_ReadyToDoRepeatingSteps");

            for (int i = 0; i < _loopTime; i++)
            {
                switch (testingType)
                {
                    case TestType.S3:
                        vantageUI.EnterS3();
                        System.Threading.Thread.Sleep(10000);
                        break;
                    case TestType.S4:
                        vantageUI.EnterS4();
                        System.Threading.Thread.Sleep(120000);
                        break;
                    case TestType.Repeat:
                        break;
                    default:
                        throw new Exception("You choosed wrong testing type");
                }

                vantageUI.LaunchVantageWithProtocol();
                string supportId = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Support")["SupportMenuTitle"].ToString();
                if (vantageUI.VantageElementExistUsingAutomationId(supportId))
                {
                    vantageUI.VantageClickElementtUsingAutomationId(supportId);
                    string articleId = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Support")["article1"].ToString();
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_supportpage");
                    if (vantageUI.VantageElementExistUsingAutomationId(articleId))
                    {

                    }
                    else
                    {

                        errorlist.Add("NO article at support page");
                    }

                }
                else
                {
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_NOSuuportPage");
                    errorlist.Add("NO Support page occur?");
                }

                string myDeviceID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Navbar")["device"].ToString();
                if (vantageUI.VantageElementExistUsingAutomationId(myDeviceID))
                {
                    vantageUI.VantageClickElementtUsingAutomationId(myDeviceID);
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_MyDevicePage");
                    if (vantageUI.VantageElementExistUsingAutomationId(VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Device")["biosVersion"].ToString()))
                    {

                    }
                    else
                    {

                        errorlist.Add("NO Bios value?");
                    }
                }
                else
                {
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_NoMyDevicePage");
                    errorlist.Add("NO My Device page occur?");
                }
                string securityID = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Navbar")["security"].ToString();
                if (vantageUI.VantageElementExistUsingAutomationId(securityID))
                {
                    vantageUI.VantageClickElementtUsingAutomationId(securityID);
                    string security1010Button = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("Security")["SecurityAdvisor101Button"].ToString(); //默认personal才有My Security page
                    string wifiCheckThreat = VantageAutomationIDCollector.Instance.GetVantageAutomationIDs().GetValue("WiFiPage")["CheckThreatButton"].ToString(); //默认Professional segment只能看到wifi security page
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_SecurityPage");
                    if (vantageUI.VantageElementExistUsingAutomationId(security1010Button) || vantageUI.VantageElementExistUsingAutomationId(wifiCheckThreat))
                    {

                    }
                    else
                    {

                        errorlist.Add("NO Security button exist?");
                    }
                }
                else
                {
                    vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_NoSecurityPage");
                    errorlist.Add("NO My Security page occur?");
                }

                vantageUI.CloseVantageProcess();
            }
            vantageUI.PrintScreen(TestContext.CurrentContext.Test.Name + "_RepeatingStepsIsDone");
        }
        [Then("No Error Stop Me")]
        public void NoErrorStopMe()
        {
            Assert.IsTrue(errorlist.Count == 0);
        }
    }
}
