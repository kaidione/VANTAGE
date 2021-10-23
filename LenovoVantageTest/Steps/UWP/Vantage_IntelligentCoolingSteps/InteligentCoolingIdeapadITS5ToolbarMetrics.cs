using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class InteligentCoolingIdeapadITS5ToolbarMetrics
    {
        private WindowsDriver<WindowsElement> _session;
        private long _nowtime;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();


        public InteligentCoolingIdeapadITS5ToolbarMetrics(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"check eventlog switch type is (.*)")]
        public void ThenCheckEventlogSwitchTypeIs(string p)
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            string switchType = intelligentCooling.SecondTimeEventLogXmlTimeInfo();
            if (switchType.Contains(string.Format("\"name\":\"ModeSwitchWay\",\"value\":\"{0}\"", p)))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Switch Type is: " + switchType);
            }
        }

        [Then(@"check eventlog last mode is (.*)")]
        public void ThenCheckEventlogLastModeIs(string p)
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            string lastMode = intelligentCooling.SecondTimeEventLogXmlTimeInfo();
            if (lastMode.Contains(string.Format("\"name\":\"LastMode\",\"value\":\"{0}\"", p)))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Switch Type is: " + lastMode);
            }
        }

        [Then(@"check eventlog current mode is (.*)")]
        public void ThenCheckEventlogCurrentModeIs(string p)
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            string currentMode = intelligentCooling.SecondTimeEventLogXmlTimeInfo();
            if (currentMode.Contains(string.Format("\"name\":\"CurrentMode\",\"value\":\"{0}\"", p)))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("Switch Type is: " + currentMode);
            }
        }
        [When(@"get unix time now")]
        public void WhenGetUnixTimeNow()
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            _nowtime = intelligentCooling.GetNowTime_Unix();
        }

        [Then(@"check eventlog time is ok")]
        public void ThenCheckEventlogTimeIsOk()
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            string currentMode = intelligentCooling.SecondTimeEventLogXmlTimeInfo();
            var lasttime = currentMode.Split(',')[9];
            lasttime = lasttime.Split(':')[1].Replace("}", "").Replace("\"", "");
            long lasttimefromlog = long.Parse(lasttime);
            long errorValue = _nowtime - lasttimefromlog;
            bool errorstatus = (errorValue <= 2 && errorValue >= 0) ? true : false;
            Assert.IsTrue(errorstatus, "errorValue of the time is: " + errorValue);
        }

        [Then(@"check eventlog time is ok for APMAQM")]
        public void ThenCheckEventlogTimeIsOkForAPMAQM()
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            string currentMode = intelligentCooling.SecondTimeEventLogXmlTimeInfo();
            var lasttime = currentMode.Split(',')[9];
            lasttime = lasttime.Split(':')[1].Replace("}", "").Replace("\"", "");
            long lasttimefromlog = long.Parse(lasttime);
            long errorValue = _nowtime - lasttimefromlog;
            bool errorstatus = (errorValue <= 60 && errorValue >= 0) ? true : false;
            if (errorstatus)
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Warn("errorValue of the time is: " + errorValue);
            }
        }

        [Then(@"Check Event Log Content Is Empty")]
        public void ThenCheckEventLogContentIsEmpty()
        {
            IntelligentCoolingBaseHelper intelligentCooling = new IntelligentCoolingBaseHelper();
            intelligentCooling.StartTimeEventLogXmlTimeInfo();
            Assert.IsTrue(string.IsNullOrEmpty(intelligentCooling.StartTimeEventLogXmlShow()), "There should no data send to event viewer.");
        }

    }
}
