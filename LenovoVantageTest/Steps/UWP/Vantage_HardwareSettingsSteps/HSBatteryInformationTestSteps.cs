using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HSBatteryInformationTestSteps
    {
        private HSToolbarPage _toolbarPage;
        private InformationalWebDriver _webDriver;
        public HSBatteryInformationTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Check battery Message")]
        public void ThenCheckBatteryMessage()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.BatteryTitle, "ThenCheckBatteryTitle is null");
            Assert.IsNotNull(_toolbarPage.Percentage, "ThenCheckBatteryPercentage is null");
            Assert.IsNotNull(_toolbarPage.BatteryDetailsBtn, "ThenCheckBatteryBtn is null");
        }

        [Then(@"Click Battery Details Btn")]
        public void ThenClickBtnBatteryDetails()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.BatteryDetailsBtn, "batterydetails is null");
            _toolbarPage.BatteryDetailsBtn.Click();
        }

        [Then(@"the Battery Gauge panel will display text")]
        public void GivenTheBatteryGaugePanelWillDisplayText()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.BatteryTimeToFullChargeText, "BatteryTimeToFullChargeText is null");
        }

        [Then(@"Click Battery Details Close Icon Btn")]
        public void ThenClickBatteryDetailsCloseIconBtn()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.BatteryDetailsCloseBtn, "batterydetails is null");
            _toolbarPage.BatteryDetailsCloseBtn.Click();
        }

        [Then(@"Check BatteryGauge Toolbar Adapter Icon")]
        public void ThenCheckBatteryGaugeToolbarAdapterIcon()
        {
            AutomationElement toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString(), 2);
            Assert.IsNotNull(toolbar, "ThenCheckBatteryGaugeToolbarAdapterIcon is null");
        }

        [Then(@"Check Battery Adapter Icon")]
        public void ThenCheckBatteryAdapterIcon()
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_toolbarPage.BatteryIcon, "ThenCheckBatteryAdapterIcon is null");
        }

        [Then(@"Check (.*) time value")]
        public void ThenCheckYesTimeValue(string state)
        {
            _toolbarPage = new HSToolbarPage(_webDriver.Session);
            if (state.ToLower().Equals("YES"))
            {
                Assert.IsNotNull(_toolbarPage.BatteryRemainingTime, "BatteryRemainingTime is null");
                Assert.IsNotNull(_toolbarPage.BatteryRemainingTimeValue, "BatteryRemainingTimeValue is null");
            }
            else if (state.ToLower().Equals("NO"))
            {
                Assert.IsNull(_toolbarPage.BatteryRemainingTime, "BatteryRemainingTime is null");
                Assert.IsNull(_toolbarPage.BatteryRemainingTimeValue, "BatteryRemainingTimeValue is null");
            }
        }

        [Then(@"Check time value in BatteryGauge Toolbar")]
        public void ThenCheckTimeValueInBatteryGaugeToolbar()
        {
            AutomationElement toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString(), 2);
            Assert.IsNotNull(toolbar, "ThenCheckTimeValueInBatteryGaugeToolbar is null");
        }


    }
}
