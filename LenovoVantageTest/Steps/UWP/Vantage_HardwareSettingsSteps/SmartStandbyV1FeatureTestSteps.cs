using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class SmartStandbyV1FeatureTestSteps : SettingsBase
    {
        private HSPowerSettingsPage _hsPowerSettingsPage;
        private InformationalWebDriver _webDriver;
        static private string _regsmartstandby = @"SOFTWARE\WOW6432Node\Lenovo\SmartStandby";
        private int _startHourReg = 0;
        private int _endHourReg = 0;
        private string _startMinutesReg = string.Empty;
        private string _endMinutesReg = string.Empty;
        private string _startHourUI = string.Empty;
        private string _startMinutesUI = string.Empty;
        private string _endHourUI = string.Empty;
        private string _endMinutesUI = string.Empty;
        private string _scheduleDaysUI = string.Empty;
        private string _scheduleDaysRegedit = string.Empty;
        static private string[] minutes = new string[4] { "00", "15", "30", "45" };
        SmartStandbyTestSteps _smartStandbyFunction;
        private ErrorMessage _errorResult;

        public SmartStandbyV1FeatureTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            _smartStandbyFunction = new SmartStandbyTestSteps(_webDriver);

        }

        [Then(@"Check the Smart Standby toggle state")]
        public void ThenCheckTheSmartStandbyToggleState()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTToggle);
            int toggleValue = 0;
            object val = _smartStandbyFunction.GetRegistryValue(_regsmartstandby, "IsEnabled");
            if (tarToggle == ToggleState.On)
            {
                toggleValue = 1;
            }
            else if (tarToggle == ToggleState.Off)
            {
                toggleValue = 0;
            }
            else
            {
                toggleValue = -1;
            }
            Assert.AreEqual(val, toggleValue);
        }

        [Then(@"Check the Smart Standby Start Time")]
        public void ThenCheckTheSmartStandbyStartTime()
        {
            GetStartRegedit();
            GetStartValueinUI();
            Assert.AreEqual(_startMinutesReg, _startMinutesUI);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string startAMPM = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartAMPMValue, "Name");
            if (_startHourReg >= 12)
            {
                if (_startHourReg != 12)
                {
                    _startHourReg = _startHourReg - 12;
                }
                Assert.AreEqual(_startHourReg.ToString(), _startHourUI);
                Assert.AreEqual("PM", startAMPM);
            }
            else
            {
                if (_startHourReg == 0)
                {
                    _startHourReg = _startHourReg + 12;
                }
                Assert.AreEqual(_startHourReg.ToString(), _startHourUI);
                Assert.AreEqual("AM", startAMPM);
            }
        }

        [Then(@"Check the Smart Standby End Time")]
        public void ThenCheckTheSmartStandbyEndTime()
        {
            GetEndRegedit();
            GetEndValueinUI();
            Assert.AreEqual(_endMinutesReg, _endMinutesUI);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string endAMPM = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndAMPMValue, "Name");
            if (_endHourReg >= 12)
            {
                if (_endHourReg != 12)
                {
                    _endHourReg = _endHourReg - 12;
                }
                Assert.AreEqual(_endHourReg.ToString(), _endHourUI);
                Assert.AreEqual("PM", endAMPM);
            }
            else
            {
                if (_endHourReg == 0)
                {
                    _endHourReg = _endHourReg + 12;
                }
                Assert.AreEqual(_endHourReg.ToString(), _endHourUI);
                Assert.AreEqual("AM", endAMPM);
            }
        }

        [Then(@"Check the Smart Standby Schedule Days")]
        public void ThenCheckTheSmartStandbyScheduleDays()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            //use this schedule for, 
            string scheduleDays = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "Name");
            if (scheduleDays.Contains("use this schedule for"))
            {
                string[] sArrsy = Regex.Split(scheduleDays, "use this schedule for,", RegexOptions.IgnoreCase);
                scheduleDays = sArrsy[1];
            }
            Assert.AreEqual(_smartStandbyFunction.getWeekday().Trim(), scheduleDays.Trim());
        }

        [Then(@"Check the DropDown List")]
        public void ThenCheckTheDropDownList()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyStartHoursTitle, _hsPowerSettingsPage.SmartStadbyStartHoursTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyStartMinutesTitle, _hsPowerSettingsPage.SmartStadbyStartMinutesTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyStartAMPMTitle, _hsPowerSettingsPage.SmartStadbyStartAMPMTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyEndHoursTitle, _hsPowerSettingsPage.SmartStadbyEndHoursTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyEndMinutesTitle, _hsPowerSettingsPage.SmartStadbyEndMinutesTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStadbyEndAMPMTitle, _hsPowerSettingsPage.SmartStadbyEndAMPMTitleSPEC);
        }

        [Then(@"Check the DropDown Hours Value range")]
        public void ThenCheckTheDropDownHoursValueRange()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList);
            int StartHour = int.Parse(VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name"));
            for (int i = StartHour; i <= StartHour + 11; i++)
            {
                int name = i;
                if (i != 12)
                {
                    name = i % 12;
                }
                Assert.True(VantageCommonHelper.GetAttributeValue(base.GetElement(_webDriver.Session, "AutomationId", name + "'hours'"), "Name").Contains(name + ""));
                ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartHOURSDown);
            }
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCloseMark);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            int EndHour = int.Parse(VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name"));
            for (int i = EndHour; i <= EndHour + 11; i++)
            {
                int name = i;
                if (i != 12)
                {
                    name = i % 12;
                }
                Assert.True(VantageCommonHelper.GetAttributeValue(base.GetElement(_webDriver.Session, "AutomationId", name + "'hours'"), "Name").Contains(name + ""));
                ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndHOURSDown);
            }
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCloseMark);
        }

        [Then(@"Check the DropDown Minutes Value range")]
        public void ThenCheckTheDropDownMinutesValueRange()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList);
            string StartMinute = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name");
            int startFrom = 0;
            for (int i = 0; i < 4; i++)
            {
                if (minutes[i].Equals(StartMinute))
                {
                    startFrom = i;
                }
            }
            for (int i = startFrom; i <= startFrom + 3; i++)
            {
                string name = minutes[i % 4];
                Assert.True(VantageCommonHelper.GetAttributeValue(base.GetElement(_webDriver.Session, "AutomationId", name + ", 'minutes'"), "Name").Contains(name + ""));
                ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartMINUTESDown);
            }
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCloseMark);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            string EndMinute = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name");
            int endFrom = 0;
            for (int i = 0; i < 4; i++)
            {
                if (minutes[i].Equals(EndMinute))
                {
                    endFrom = i;
                }
            }
            for (int i = endFrom; i <= endFrom + 3; i++)
            {
                string name = minutes[i % 4];
                Assert.True(VantageCommonHelper.GetAttributeValue(base.GetElement(_webDriver.Session, "AutomationId", name + ", 'minutes'"), "Name").Contains(name + ""));
                ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndMINUTESDown);
            }
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCloseMark);
        }

        [Then(@"Check the DropDown AMPM Value range")]
        public void ThenCheckTheDropDownAMPMValueRange()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartAM, _hsPowerSettingsPage.SmartStandbyTManualScheduleAMRadioSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartPM, _hsPowerSettingsPage.SmartStandbyTManualSchedulePMRadioSPEC);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCloseMark);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndAM, _hsPowerSettingsPage.SmartStandbyTManualScheduleAMRadioSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndPM, _hsPowerSettingsPage.SmartStandbyTManualSchedulePMRadioSPEC);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCloseMark);
        }

        [When(@"Set a More Than (.*) Hours Time")]
        public void WhenSetAMoreThanHoursTime(int p0)
        {
            GetStartRegedit();
            SetSmartStandbyEndValue(_startHourReg, _startMinutesReg);
        }

        [When(@"Click ScheduledayDropdownist")]
        public void WhenClickScheduledayDropdownist()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList);
        }

        [Then(@"The Order of Date follow the UISPEC")]
        public void ThenTheOrderOfDateFollowTheUISPEC()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSun, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSunSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysMon, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysMonSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysTue, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysTueSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysWed, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysWedSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysThurs, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysThursSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysFri, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysFriSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSat, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSatSPEC);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSat);
        }

        private void GetStartRegedit()
        {
            object val = _smartStandbyFunction.GetRegistryValue(_regsmartstandby, "ActiveTimeStart");
            string startRegValue = val.ToString();
            _startHourReg = int.Parse(startRegValue.Split(':')[0]);
            _startMinutesReg = startRegValue.Split(':')[1];
        }

        private void GetEndRegedit()
        {
            object val = _smartStandbyFunction.GetRegistryValue(_regsmartstandby, "ActiveTimeEnd");
            string endRegValue = val.ToString();
            _endHourReg = int.Parse(endRegValue.Split(':')[0]);
            _endMinutesReg = endRegValue.Split(':')[1];
        }

        private void GetStartValueinUI()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _startHourUI = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name");
            _startMinutesUI = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name");
        }

        private void GetEndValueinUI()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _endHourUI = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name");
            _endMinutesUI = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name");
        }

        private void SetSmartStandbyEndValue(int setHour, string setMinutes)
        {
            GetEndRegedit();
            uint setMinutesInt = Convert.ToUInt32(setMinutes);
            uint _endMinutesRegInt = Convert.ToUInt32(_endMinutesReg);
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            int EndHour = int.Parse(VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name"));
            if (setHour >= 12)
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndPM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndAM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            if (setHour >= _endHourReg)
            {
                for (int i = 0; i < setHour - _endHourReg; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndHOURSDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {
                for (int i = 0; i < _endHourReg - setHour; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndHOURSUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            if (setMinutesInt >= _endMinutesRegInt)
            {
                for (int i = 0; i < (setMinutesInt - _endMinutesRegInt) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndMINUTESDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {
                for (int i = 0; i < (_endMinutesRegInt - setMinutesInt) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndMINUTESUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCheckMark);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }
    }
}
