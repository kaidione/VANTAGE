using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class Dashboard_ShowUPEContentInPositionBStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private Utility.InformationalWebDriver webDriver;
        private DashBoardPage dasheboardPage;
        DateTime seeHeroBanner;

        public Dashboard_ShowUPEContentInPositionBStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }


        [Given(@"Make sure hypothesis file is set as expected")]
        public void GivenMakeSureHypothesisFileIsSet(Table table)
        {
            string filePath = table.Rows[0][0];
            string strExpectJson = table.Rows[0][1];

            //hypothesis.config file should be exist
            FileAssert.Exists(filePath);

            //read hypothesis.config as json file
            StreamReader file = File.OpenText(filePath);
            JsonTextReader reader = new JsonTextReader(file);
            JObject jsonObject = (JObject)JToken.ReadFrom(reader);
            JObject choicesesObject = (JObject)jsonObject["Choiceses"];
            string actualTileSource = (string)choicesesObject["TileSource"];
            file.Close();

            dynamic expectJson = JsonConvert.DeserializeObject(strExpectJson);
            JObject expectValue = (JObject)expectJson["Choiceses"];
            string expectTileSource = (string)choicesesObject["TileSource"];

            Assert.AreEqual(actualTileSource, expectTileSource);

        }

        [When(@"Make sure user is currently on the Dashboard page")]
        public void WhenMakeSureUserIsCurrentlyOnTheDashboardPage()
        {
            dasheboardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dasheboardPage.heroBanner.Displayed);
            seeHeroBanner = DateTime.Now;
        }


        [Then(@"Check UPE content on positionB can be fully shown in (.*) sec")]
        public void ThenCheckUPEContentOnPositionBCanBeFullyShownInSec(int p0)
        {
            dasheboardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dasheboardPage.contentBoxBTextBox.Displayed);
            Assert.IsTrue(dasheboardPage.contentBoxB.Displayed);
            Assert.IsTrue(dasheboardPage.contentBoxB_Title.Displayed);
            Assert.IsTrue(dasheboardPage.contentBoxB_Description.Displayed);

            TimeSpan seePositionB = DateTime.Now.Subtract(seeHeroBanner);
            double seePositionBSec = seePositionB.TotalSeconds;

            Assert.LessOrEqual(seePositionBSec, p0);

            String positionB_Title = dasheboardPage.contentBoxB_Title.GetAttribute("Name");
            String positionB_Description = dasheboardPage.contentBoxB_Description.GetAttribute("Name");

            Logger.Instance.WriteLog("PositionB Tile = " + positionB_Title + "\r\n");
            Logger.Instance.WriteLog("PositionB Description = " + positionB_Description + "\r\n");


        }

        [Then(@"Check UPE API request body is as expected")]
        public void ThenCheckUPEAPIRequestBodyIsAsExpected()
        {
        }

        [Then(@"Check corresponding UPE Content on positionB is as expected")]
        public void ThenCheckCorrespondingUPEContentOnPositionBIsAsExpected()
        {
        }





    }
}
