using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.ServiceModel.Channels;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class SmartStandbyV1FeatureTest : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hsPowerSettingsPage;
        private ErrorMessage _errorResult;
        private SmartStandbyTestSteps _smartStandbyTestSteps;
        static private string _regsmartstandby = @"SOFTWARE\WOW6432Node\Lenovo\SmartStandby";
        private string _currentUIDays;
        private string _currentRegDay;
        private string _currentRegTime;
        private string _currentStartDropDownTime;
        private string _currentEndDropDownTime;
        private string _currentDropDownDays;

        public SmartStandbyV1FeatureTest(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Get current message")]
        public void WhenGetCurrentMessage()
        {
            _smartStandbyTestSteps = new SmartStandbyTestSteps(_webDriver);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _currentRegTime = _smartStandbyTestSteps.GetRegiTime();
            _currentRegDay = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("DayOfWeekOff", _regsmartstandby);
            _currentStartDropDownTime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartAMPMValue, "Name");
            _currentEndDropDownTime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndAMPMValue, "Name");
            _currentDropDownDays = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "Name");
        }

        [Then(@"The SmartStandby value is new value")]
        public void ThenTheSmartStandbyValueIsNewValue()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _smartStandbyTestSteps = new SmartStandbyTestSteps(_webDriver);
            Assert.AreEqual(_currentRegTime, _smartStandbyTestSteps.GetRegiTime());
            Assert.AreEqual(_currentStartDropDownTime, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartAMPMValue, "Name"));
            Assert.AreEqual(_currentEndDropDownTime, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndAMPMValue, "Name"));
            Assert.AreEqual(_currentDropDownDays, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "Name"));
            Assert.AreEqual(_currentRegDay, IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("DayOfWeekOff", _regsmartstandby));
        }

        [Then(@"The SmartStandby value in regedit new value")]
        public void ThenTheSmartStandbyValueInRegeditNewValue()
        {
            _smartStandbyTestSteps = new SmartStandbyTestSteps(_webDriver);
            Assert.AreEqual(_currentRegTime, _smartStandbyTestSteps.GetRegiTime());
        }

        [When(@"Click dropdown menu pop a window")]
        public void WhenClickDropdownMenuPopAWindow()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCheckMark, "The start check windows is not find");
            _hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList.Click();
            _hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCheckMark, "The end check windows is not find");
            _hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList.Click();
            _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList.Click();
            Assert.IsNotNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSun, "The day check windows is not find");
            _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList.Click();
        }

        [When(@"Checked Weeks and ""(.*)""")]
        public void WhenCheckedWeeksAnd(string isSave, Table table)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Dictionary<string, WindowsElement> weekDays = _hsPowerSettingsPage.GetSmartStandbyWeekDays();
            WindowsElement[] WeekdaysID = new WindowsElement[7];
            WindowsElement oneWeek;
            for (int i = 0; i < 7; i++)
            {
                if (table.Rows[0][i] != "no")
                {
                    weekDays.TryGetValue(table.Rows[0][i], out oneWeek);
                    WeekdaysID[i] = oneWeek;
                }
                else
                {
                    WeekdaysID[i] = null;
                }
            }
            for (int w = 0; w < WeekdaysID.Length; w++)
            {
                if (WeekdaysID[w] == null)
                {
                    continue;
                }
                ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(WeekdaysID[w]);
                SelectElement(WeekdaysID[w], tarToggle);
            }
            if (isSave == "save")
            {
                _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCheckMark.Click();
            }
            else
            {
                _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCloseMark.Click();
            }
        }

        [Then(@"Ui display ""(.*)"" The Regedit is ""(.*)""")]
        public void ThenUiDisplayTheRegeditIs(string messageDisplay, string regeditDisplay)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (VantageTypePlan == VantageType.LE)
            {
                if (messageDisplay == "Weekdays, Sat")
                {
                    messageDisplay = "Weekdays, Saturday";
                }
                if (messageDisplay == "Mon, Tue, Sat")
                {
                    messageDisplay = "Monday, Tuesday, Saturday";
                }
            }
            Assert.AreEqual(messageDisplay, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList.Text, "The display day in ui is not true");
            string regDays = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("DayOfWeekOff", _regsmartstandby);
            Assert.AreEqual(regDays, regeditDisplay, "The value in regedit is not ture");
        }

        [Then(@"The day menu will display previous value")]
        public void ThenTheDayMenuWillDisplayPreviousValue()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(_currentDropDownDays, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList.Text, "The display day in ui is not true");
            string regDays = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue("DayOfWeekOff", _regsmartstandby);
            Assert.AreEqual(regDays, _currentRegDay, "The value in regedit is not ture");
        }

        [Then(@"There is not find v botton")]
        public void ThenThereIsNotFindVBotton()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.ScrollScreenToWindowsElement(_webDriver.Session, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCloseMark);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCheckMark, "The v button is find");
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCloseMark);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"All the element will hidden")]
        public void ThenAllTheElementWillHidden()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList, "The start time list is find");
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList, "The end time list is find");
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "The week day list is find");
        }
    }
}
