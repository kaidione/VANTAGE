using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class HardwareSettingsBatteryConditionOIdeaPadSteps
    {
        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hsPowerSettingsPage;

        public HardwareSettingsBatteryConditionOIdeaPadSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"IdeaPad Machine")]
        public void GivenIdeaPadMachine()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool machineTypeFlag = _hsPowerSettingsPage.IsIdeaPad();
            Assert.IsTrue(machineTypeFlag, "This computer is not ideapad");
        }

        [Then(@"Green Checkmark Icon is show")]
        public void ThenGreenCheckmarkIconIsShow()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryConditionIconGoodBatteryId, "The green checkmark icon is not find");
        }

        [Then(@"Display a ""(.*)""")]
        public void ThenDisplayA(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryConditionTipGoodId, "The good tip is not find");
            Assert.AreEqual(_hsPowerSettingsPage.BatteryConditionTipGoodId.Text, p0, "The tip is not true");
        }

        [Then(@"Title name should be ""(.*)""")]
        public void ThenTitleNameShouldBe(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryGaugeSubtitleId, "The battery gaugesubtitle is not find");
            Assert.AreEqual(_hsPowerSettingsPage.BatteryGaugeSubtitleId.Text, p0, "The gaugesubtitle is not true");
        }

        [Given(@"No AC adapter")]
        public void GivenNoACAdapter()
        {
            if (VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
        }

        [Then(@"AC adapter")]
        public void ThenACAdapter()
        {
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
        }

        [Then(@"Remaining time should be show")]
        public void ThenRemainingTimeShouldBeShow()
        {
            Thread.Sleep(30000);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryGaugeRemaingTimeTitleId, "The battery remaining title is not find");
            Assert.AreEqual(_hsPowerSettingsPage.BatteryGaugeRemaingTimeTitleId.Text, "Remaining time", "The gaugesubtitle is not true");
            Assert.NotNull(_hsPowerSettingsPage.BatteryRemainingTimeValueId, "The battery remaining value is not find");
        }

        [Given(@"There is No battery detected")]
        public void WhenThereIsNoBatteryDetected()
        {
            Assert.AreEqual(0, VantageCommonHelper.JudgeBatteryNums(), "The machine have battery!");
        }

        [Then(@"Red cross Icon is show")]
        public void ThenRedCrossIconIsShow()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BadBatteryRedCrossIconId, "The red cross icon is not find");
        }

        [Then(@"There Display a ""(.*)""")]
        public void ThenThereDisplayA(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryConditionBatteryNotDetectedId, "The not detected tip is not find");
            Assert.AreEqual(_hsPowerSettingsPage.BatteryConditionBatteryNotDetectedId.Text, p0, "The tip is not true");
        }

        [Then(@"Remaining time should not be show")]
        public void ThenRemainingTimeShouldNotBeShow()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.BatteryGaugeRemaingTimeTitleId, "The battery remaining title is find");
            Assert.IsNull(_hsPowerSettingsPage.BatteryRemainingTimeValueId, "The battery remaining value is  find");
        }

        [Then(@"The tips in Battery Gauge")]
        public void ThenTheTipsInBatteryGauge()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsPowerSettingsPage.BatteryGaugeNotDetectedTitleId.FindElementsByName(SettingsBase.GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryGaugeNotDetectedTitleChildren")), "The tip in gauge is not find");
        }

    }
}
