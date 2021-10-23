using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Channels;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class SmartStandbyTestSteps : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSPowerSettingsPage _hsPowerSettingsPage;
        private ErrorMessage _errorResult;
        static private string _regsmartstandby = @"SOFTWARE\WOW6432Node\Lenovo\SmartStandby";
        static private string _regsmartstandbyAuto = @"SOFTWARE\WOW6432Node\Lenovo\SmartStandby\Autonomic";
        static private uint[] _weekday = new uint[7] { 0x02, 0x04, 0x08, 0x10, 0x20, 0x40, 0x80 };
        static private string[] _weekdays = new string[7] { "Sun", "Mon", "Tue", "Wed", "Thurs", "Fri", "Sat" };
        static private string[] _weekdaysfull = new string[7] { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };
        static private UInt32[] minutes = new UInt32[4] { 0, 15, 30, 45 };
        private object[] _smartstandbyvalue = new object[3];
        private string _currentStartDropDownTime;
        private string _currentEndDropDownTime;
        private string _currentDropDownDays;
        private string _currentUITime;
        private string _currentUIDays;
        private string _currentRegTime;
        private string _currentRegDays;
        private string _currentRegStartTime;
        private string _currentRegEndTime;
        private string _currentIsEnabled;
        private string _currentIsAutomic;
        private string[] _currentSmartActiveHours;
        private string[] _smartActiveHours830 = { "1.06:15-1.17:30", "2.08:00-2.17:15", "3.13:45-4.05:30", "4.07:15-4.17:15", "5.07:15-5.18:45", "6.07:30-6.09:00" };
        private string[] _smartActiveHours10 = { "1.09:00-1.22:15", "2.08:30-2.22:30", "3.08:45-3.23:00", "4.09:15-4.22:15", "5.08:45-5.21:30" };
        private string[] _smartActiveHours9 = { "1.08:15-1.18:45", "2.07:45-2.10:45", "2.12:45-2.18:15", "3.08:30-3.17:30", "4.07:45-5.18:15" };
        private string _currentIspresenceDataSufficcient;

        public struct TIME
        {
            public UInt32 hours;
            public UInt32 minutes;
        }

        public struct SSTIME
        {
            public TIME start;
            public TIME end;
        }

        public SmartStandbyTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Machine Support Smart Standby (.*)")]
        public void GivenMachineSupportSmartStandby(string p0)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string smartStandbyDriverVer = GetDriverVersion("Lenovo Smart Standby");
            if (smartStandbyDriverVer == "UnknownVersion")
            {
                Assert.Fail("Machine Not Support Smart Standby");
            }
            else
            {
                string first = smartStandbyDriverVer.Split('.')[0];
                if ((Convert.ToInt32(first) >= 4 && p0 == "2.0") || (Convert.ToInt32(first) < 4 && p0 == "1.0"))
                {
                    Assert.True(true);
                }
                else
                {
                    Assert.Fail("Please change the Smart Standby driver to the correct one");
                }

            }
        }

        [When(@"Go to Smart Standby section")]
        public void WhenGoToSmartStandbySection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyJumpLink);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check the Smart Standby Version Two feature description")]
        public void ThenCheckTheSmartStandbyFeatureDescription()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTFeatureDescription, _hsPowerSettingsPage.SmartStandbyTFeatureDescriptionSPEC);
        }

        [When(@"Click Smart Standby Version Two Question Mark")]
        public void WhenClickSmartStandbyTQuestionMark()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTQuestionMark);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check the Smart Standby Version Two Question tip description")]
        public void ThenCheckTheSmartStandbyQuestionTipDescription()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTQuestionTip, _hsPowerSettingsPage.SmartStandbyTQuestionTipSPEC);
        }

        [When(@"Turn on Smart Standby Version Two toggle")]
        public void WhenTurnOnSmartStandbyTToggle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTToggle);
            SelectElement(_hsPowerSettingsPage.SmartStandbyTToggle, tarToggle);
            Assert.AreEqual(1, GetRegistryValue(_regsmartstandby, "IsEnabled"));
        }

        [Then(@"Check the Smart Standby Version Two Computer Schedule Title")]
        public void ThenCheckTheSmartStandbyTComsputerScheduleTitle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTComputerScheduleTitle, _hsPowerSettingsPage.SmartStandbyTComputerScheduleTitleSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Schedule Manual Options")]
        public void ThenCheckTheSmartStandbyTComputerScheduleManualOptions()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualOption, _hsPowerSettingsPage.SmartStandbyTManualOptionSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Schedule Auto Options")]
        public void ThenCheckTheSmartStandbyTComputerScheduleAutoOptions()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTAutoOption, _hsPowerSettingsPage.SmartStandbyTAutoOptionSPEC);
        }

        [Then(@"Section Smart Standby Section elements will be hide")]
        public void ThenSectionSmartStandbySectionElementsWillBeHide()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTAutoOption, "SmartStandbyTAutoOption is not null");
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualOption, "SmartStandbyTManualOption is not null");
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTComputerScheduleTitle, "SmartStandbyTComputerScheduleTitle is not null");
        }

        [Given(@"Select Manual Mode")]
        [When(@"Select Manual Mode")]
        public void WhenSelectManualMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTManualOption);
            SelectElement(_hsPowerSettingsPage.SmartStandbyTManualOption, tarToggle);
            Thread.Sleep(2000);
            Assert.AreEqual(0, GetRegistryValue(_regsmartstandby, "IsAutonomic"));
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Title")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleTitle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleTitleSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Days")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleDays()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDays, getWeekday().Trim());
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Time")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleTime()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleTime, GetRegiTime().Trim());
            //Assert.True(true, GetRegiTime().Trim());
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Change Link")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleDropDownLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink, _hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLinkSPEC);
        }

        [When(@"Click the Change Drop Down link")]
        public void WhenClickTheChangeDropDownLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Start Section")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleStartSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionTitleSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule End Section")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleEndSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionTitleSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Days Section")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleDaysSection()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionTitleSPEC);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Collapse link")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleCollapseLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleCollapseLink, _hsPowerSettingsPage.SmartStandbyTManualScheduleCollapseLinkSPEC);
        }

        [When(@"Click the Collapse link")]
        public void WhenClickTheCollapseLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleCollapseLink);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check if there has the Smart Standby Version Two Computer Manual Schedule Section")]
        public void ThenCheckIfThereHasTheSmartStandbyVersionTwoComputerManualScheduleSection()
        {
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionTitle);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionTitle);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionTitle);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList);
        }

        [When(@"Set a new Smart Standby Schedule ""(.*)"" and ""(.*)""")]
        public void WhenSetANewSmartStandbySchedule(string vantageVersion, string isSave)
        {
            SetSmartStandbyRandomValue(vantageVersion, isSave);
        }

        [When(@"Get the current Smart Standby Schedule")]
        public void WhenGetTheCurrentSmartStandbySchedule()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _currentUITime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleTime, "Name");
            _currentUIDays = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDays, "Name");
            object val = GetRegistryValue(_regsmartstandby, "DayOfWeekOff");
            _currentRegDays = val.ToString();
            _currentRegTime = GetRegiTime();
            _currentStartDropDownTime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartAMPMValue, "Name");
            _currentEndDropDownTime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndAMPMValue, "Name");
            _currentDropDownDays = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "Name");
        }

        [When(@"Set a More Than (.*) Hours Smart Standby Schedule ""(.*)""")]
        public void WhenSetAMoreThanHoursSmartStandbySchedule(int p0, string vantageVersion)
        {
            object[] parameters = new object[] { _currentRegStartTime, _currentRegStartTime, "" };
            string isSave = "save";
            SetSmartStandbyEndValue(parameters, vantageVersion, isSave);
        }

        [Then(@"There is a more than 20 Hours tip")]
        public void ThenThereIsAMoreThanHoursTip()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleTimeWithout20, _hsPowerSettingsPage.SmartStandbyTManualScheduleTimeWithout20SPEC);
        }

        [When(@"Refresh Smart Stansby Feature")]
        public void WhenRefreshSmartStansbyFeature()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            GoToMyDevicesSettings();
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyJumpLink);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);

        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Time Keep the previous one")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleTimeKeepThePreviousOne()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleTime, _currentUITime);
            Assert.AreEqual(_currentRegTime, GetRegiTime());
            Assert.AreEqual(_currentUITime, GetRegiTime());
            Assert.AreEqual(_currentStartDropDownTime, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyStartAMPMValue, "Name"));
            Assert.AreEqual(_currentEndDropDownTime, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndHoursValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndMinutesValue, "Name") + VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyEndAMPMValue, "Name"));
        }

        [When(@"Uncheck any day")]
        public void WhenUncheckAnyDay()
        {
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            WindowsElement[] WeekdaysID = new WindowsElement[7] { _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSun, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysMon, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysTue, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysWed, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysThurs, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysFri, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSat };
            for (int w = 0; w < 7; w++)
            {
                ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(WeekdaysID[w]);
                UnSelectElement(WeekdaysID[w], tarToggle);
            }
        }

        [Then(@"There is a any day tip")]
        public void ThenThereIsAAnyDayTip()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleAnyDayTip, _hsPowerSettingsPage.SmartStandbyTManualScheduleAnyDayTipSPEC);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCheckMark);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCloseMark);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check the Smart Standby Version Two Computer Manual Schedule Days Keep the previous one")]
        public void ThenCheckTheSmartStandbyVersionTwoComputerManualScheduleDaysKeepThePreviousOne()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleDays, _currentUIDays);
            Assert.AreEqual(_currentRegDays, GetRegistryValue(_regsmartstandby, "DayOfWeekOff").ToString());
            Assert.AreEqual(_currentDropDownDays, VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList, "Name"));
        }

        [When(@"Turn off Smart Standby Version Two toggle")]
        public void WhenTurnOffSmartStandbyVersionTwoToggle()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTToggle);
            UnSelectElement(_hsPowerSettingsPage.SmartStandbyTToggle, tarToggle);
            Assert.AreEqual(0, GetRegistryValue(_regsmartstandby, "IsEnabled"));
        }

        [Then(@"Check if Manual Mode is in selected state")]
        [Then(@"Check if Automatic Mode is in unselected state")]
        public void ThenCheckIfManualModeIsInSelectedState()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(ToggleState.On, _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTManualOption));
            Assert.AreEqual(ToggleState.Off, _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTAutoOption));
            Assert.AreEqual(0, GetRegistryValue(_regsmartstandby, "IsAutonomic"));
        }

        [Then(@"Check Graph link")]
        public void ThenCheckUsageAndActiveLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleGraphLink, _hsPowerSettingsPage.SmartStandbyTManualScheduleGraphLinkSPEC);
        }

        [When(@"Click Graph link")]
        public void WhenClickGraphLink()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleGraphLink);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [Then(@"Check the Usage Graph")]
        public void ThenCheckTheUsageGraph()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleUsageGraphTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleUsageGraphTitleSPEC);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTManualScheduleActiveGraphTitle, _hsPowerSettingsPage.SmartStandbyTManualScheduleActiveGraphTitleSPEC);
        }

        [When(@"Close the Usage Graph")]
        public void ThenCloseTheUsageGraph()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleActiveGraphCloseButton);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }

        [When(@"CloseX the Usage Graph")]
        public void WhenCloseXTheUsageGraph()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleActiveGraphCloseButtonX);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
        }


        [Then(@"There is no Usage Graph")]
        public void ThenThereIsNoUsageGraph()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleActiveGraphCloseButton);
        }

        [When(@"Select Auto Mode")]
        [Given(@"Select Auto Mode")]
        public void WhenSelectAutoMode()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTAutoOption);
            SelectElement(_hsPowerSettingsPage.SmartStandbyTAutoOption, tarToggle);
            Assert.AreEqual(1, GetRegistryValue(_regsmartstandby, "IsAutonomic"));
        }

        [Then(@"Check Auto mode tip")]
        public void ThenCheckAutoModeTip()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyTAutoScheduleTip, _hsPowerSettingsPage.SmartStandbyTAutoScheduleTipSPEC);
        }

        [Then(@"Check there is no Manual Mode section")]
        public void ThenCheckThereIsNoManualModeSection()
        {
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleTitle);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleDays);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleTime);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyTManualScheduleChangeLink);
        }

        [When(@"There is not enough data in Machine")]
        public void WhenThereIsNotEnoughDataInMachine()
        {
            DeleteDir(@"C:\Windows\System32\SleepStudy");
            DeleteDir(@"C:\ProgramData\Lenovo\SmartStandby");
        }

        [When(@"Restart the Smart Standby Schedule Task")]
        public void WhenRestartTheSmartStandbyScheduleTask()
        {
            //TaskSchedulerClass ts = new TaskSchedulerClass();
            //IRegisteredTask scheduler = Scheduler.GetSchedulerConttains(@"","");
            //TaskSchedulerClass ts = new TaskSchedulerClass();
            //ts.Connect(null, null, null, null);
            //ITaskFolder taskFolder = ts.GetFolder(@"\Lenovo\SmartStandby");
            //var taskList = taskFolder.GetTasks(0);
            //foreach (IRegisteredTask task in taskList) {
            //    Assert.True(true,task.Name.ToString());
            //    if (task.Name.Contains("Daily analysis")) {
            //        task.Run(null);
            //    }
            //}
            DesktopPowerManagementHelper.RunCmd(@"C:\Windows\System32\DriverStore\FileRepository\smartstandbycomponent.inf_amd64_5c67d36ae277810f\AutonomicMgr.exe dailyAnalysis", true);
            Thread.Sleep(30 * 1000);
        }

        [Then(@"Check the Not Enough Usage data Tip")]
        public void ThenCheckTheNotEnoughUsageDataTip()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyNotEnoughDataNameForLe, _hsPowerSettingsPage.SmartStandbyNotEnoughDataSPEC);
            }
            else
            {
                CheckUIWithSPEC(_hsPowerSettingsPage.SmartStandbyNotEnoughData, _hsPowerSettingsPage.SmartStandbyNotEnoughDataSPEC);
            }
        }

        [StepDefinition(@"Take Screen Shot (.*) in (.*) under (.*)")]
        [StepDefinition(@"Take screen shot (.*) in (.*) under (.*) after 0 seconds")]
        public void ThenTakeScreenShotIn(string imageName, string pathName, string component)
        {
            int waitTime = ScenarioStepContext.Current.StepInfo.Text.Contains("after 0 seconds") ? 0 : 2;
            Thread.Sleep(TimeSpan.FromSeconds(waitTime));
            AddScreenshotIntoReport(imageName.Trim(), pathName.Trim(), component.Trim());
        }

        [When(@"Take Screen Shot (.*) IN (.*) under (.*) for (.*)")]
        public void WhenTakeScreenShotINForUsageChart(string ImageName, string PathName, string Component, string UIAUID)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            float scaling = CaptureScreen.GetScalingFactor();
            int srcX = 0;
            int srcY = 0;
            int width = (int)(Screen.PrimaryScreen.Bounds.Width * scaling);
            int height = (int)(Screen.PrimaryScreen.Bounds.Height * scaling);
            WindowsElement ScreenElement = base.GetElement(_webDriver.Session, "AutomationId", UIAUID);
            if (ScreenElement != null)
            {
                var position = ScreenElement.Location;
                var positionS = ScreenElement.Size;
                srcX = (int)position.X;
                srcY = (int)position.Y;
                width = (int)positionS.Width;
                height = (int)positionS.Height;
            }
            AddScreenshotIntoReport(ImageName, PathName, Component, true, srcX, srcY, width, height);
        }


        [When(@"Get the related Regedit value before we closed Vantage")]
        public void WhenGetTheRelatedRegeditValueBeforeWeClosedVantage()
        {
            _currentRegStartTime = GetRegistryValue(_regsmartstandby, "ActiveTimeStart").ToString();
            _currentRegEndTime = GetRegistryValue(_regsmartstandby, "ActiveTimeEnd").ToString();
            _currentRegDays = GetRegistryValue(_regsmartstandby, "DayOfWeekOff").ToString();
            _currentIsEnabled = GetRegistryValue(_regsmartstandby, "IsEnabled").ToString();
            _currentIsAutomic = GetRegistryValue(_regsmartstandby, "IsAutonomic").ToString();
            _currentIspresenceDataSufficcient = GetRegistryValue(_regsmartstandbyAuto, "IsPresenceDataSufficient").ToString();
        }

        [When(@"Get the SmartActiveHours Regedit Value")]
        public void WhenGetTheSmartActiveHoursRegeditValue()
        {
            _currentSmartActiveHours = (string[])GetRegistryValue(_regsmartstandbyAuto, "SmartActiveHours");
        }

        [Then(@"Check if the SmartActiveHours Match the (.*) SPEC")]
        public void ThenCheckIfTheSmartActiveHoursMatchThe_SmartActiveHoursSPEC(string specTime)
        {
            string[] specRegTime = null;
            switch (specTime)
            {
                case "_smartActiveHours830":
                    specRegTime = _smartActiveHours830;
                    break;
                case "_smartActiveHours9":
                    specRegTime = _smartActiveHours9;
                    break;
                case "_smartActiveHours10":
                    specRegTime = _smartActiveHours10;
                    break;
                default:
                    break;
            }
            Assert.IsTrue(Enumerable.SequenceEqual(_currentSmartActiveHours, specRegTime));
        }

        [Then(@"Check if the SmartActiveHours Match the previous value")]
        public void ThenCheckIfTheSmartActiveHoursMatchThePreviousValue()
        {
            string[] tempSmartActiveHours = (string[])GetRegistryValue(_regsmartstandbyAuto, "SmartActiveHours"); ;
            if (_currentSmartActiveHours == null)
            {
                Assert.IsNull(tempSmartActiveHours);
            }
            else
            {
                Assert.IsTrue(Enumerable.SequenceEqual(_currentSmartActiveHours, tempSmartActiveHours));
            }
        }

        [When(@"ReLaunch Vantage for Smart Standby")]
        public void WhenReLaunchVantageForSmartStandby()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool result = _hsPowerSettingsPage.JumpToBatterySettings();
            VantageCommonHelper.CloseAlertWindow(session);
            Assert.IsTrue(result);
        }


        [Then(@"Check the Mode ManualTime ManualSchedule AutoTime Keep the previous one")]
        public void ThenCheckTheModeManualTimeManualScheduleAutoTimeKeepThePreviousOne()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarMode = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTAutoOption);
            ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTToggle);
            Assert.AreEqual(ToggleState.On, tarMode);
            Assert.AreEqual(ToggleState.On, tarToggle);
            Assert.AreEqual(_currentRegStartTime, GetRegistryValue(_regsmartstandby, "ActiveTimeStart").ToString());
            Assert.AreEqual(_currentRegEndTime, GetRegistryValue(_regsmartstandby, "ActiveTimeEnd").ToString());
            Assert.AreEqual(_currentRegDays, GetRegistryValue(_regsmartstandby, "DayOfWeekOff").ToString());
            Assert.AreEqual(_currentIsEnabled, GetRegistryValue(_regsmartstandby, "IsEnabled").ToString());
            Assert.AreEqual(_currentIsAutomic, GetRegistryValue(_regsmartstandby, "IsAutonomic").ToString());
            Assert.AreEqual(_currentIspresenceDataSufficcient, GetRegistryValue(_regsmartstandbyAuto, "IsPresenceDataSufficient").ToString());
        }

        [Then(@"The (.*) IN (.*) under (.*) keep the same with the (.*) IN (.*) under (.*) And Write log to report")]
        public void ThenTheUsageCurrentINUnderHSScreenShotResultKeepTheSameWithTheUsagePreviousINUnderHSScreenShotResult(string currentImageName, string currentImageJIRA, string currentImageComponent, string previousImageName, string previousImageJIRA, string previousImageComponent)
        {
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).FullName; //Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string currentscreenShotPath = Path.Combine(projectDiectory, "Report", currentImageComponent, currentImageJIRA);
            var currentfilepath = currentscreenShotPath + "\\" + currentImageName + ".jpg";
            string previousscreenShotPath = Path.Combine(projectDiectory, "Report", previousImageComponent, previousImageJIRA);
            var previousfilepath = previousscreenShotPath + "\\" + previousImageName + ".jpg";
            ImageDiff imageCheck = new ImageDiff();
            float fResult = imageCheck.ImageDiffByPIc(currentfilepath, previousfilepath);
            if (Math.Abs(fResult - 1.0) <= double.Epsilon)
            {
                Assert.IsTrue(true);
            }
            else
            {
                string info = DesktopPowerManagementHelper.WriteLogToTestReport("The two picture are not the same, the Diff rate is " + fResult + ", please check the image", "ImageDiff");
                Hooks.WriteInfoReport(info);
                VantageConstContent.ShowTips = string.Empty;
                Assert.Warn("Needed Manual Check: " + fResult + " : " + currentfilepath + " is not match " + previousfilepath);
            }
        }

        [When(@"User use the machine during (.*) under (.*) step")]
        public void WhenUserUseTheMachineDuring(string dataName, string step)
        {
            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\SmartStandby", dataName);
            string specPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\SmartStandby");
            string specUsageChart = specPath + "\\" + dataName + "Usage.jpg";
            string specActiveChart = specPath + "\\" + dataName + "Active.jpg";
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).FullName; //Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string screenShotPath = Path.Combine(projectDiectory, "Report", "HSScreenShotResult", "13723");
            CopyFolder(dirPath, @"C:\Windows\System32\SleepStudy");
            if (!Directory.Exists(screenShotPath))
            {
                Directory.CreateDirectory(screenShotPath);
            }
            File.Copy(specUsageChart, screenShotPath + "\\" + step + "UsageSPEC.jpg", true);
            File.Copy(specActiveChart, screenShotPath + "\\" + step + "ActiveSPEC.jpg", true);
        }

        [Then(@"Automatic mode is in (.*) state")]
        public void ThenAutomaticModeIsInONState(string status)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState tarMode = _hsPowerSettingsPage.GetCheckBoxStatus(_hsPowerSettingsPage.SmartStandbyTAutoOption);
            if (status.Equals("ON"))
            {
                Assert.AreEqual(ToggleState.On, tarMode);
            }
            else
            {
                Assert.AreEqual(ToggleState.Off, tarMode);
            }
        }

        [Then(@"Check if the DateSufficient value is (.*)")]
        public void ThenCheckIfTheDateSufficientValueIs(string expectedValue)
        {
            Assert.AreEqual(expectedValue, _currentIspresenceDataSufficcient);
        }

        [Then(@"There is no Not Engouth Date Tip")]
        public void ThenThereIsNoNotEngouthDateTip()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsPowerSettingsPage.SmartStandbyNotEnoughData);
        }


        /**The below is the Function Logic for Smart Standby feature
         */
        public object GetRegistryValue(string path, string name)
        {
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey tmp = rk.OpenSubKey(path, false);
            return tmp?.GetValue(name);
        }

        private uint GetCount(uint x)
        {
            uint count = 0;
            while (x > 0)
            {
                x = x & (x - 1);
                count++;
            }
            return count;
        }

        public string getWeekday()
        {
            string tmp = string.Empty;
            object val = GetRegistryValue(_regsmartstandby, "DayOfWeekOff");
            uint value = Convert.ToUInt32(val);
            string[] tempList;
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                tempList = _weekdaysfull;
            }
            else
            {
                tempList = _weekdays;
            }
            if (value == 0)
            {
                tmp = "Everyday";
            }
            else
            {
                if (((~value) & 0x7c) == 0x7c)
                {
                    tmp = "Weekdays";
                    if (((~value) & _weekday[6]) == _weekday[6])
                    {
                        tmp = tmp + ", " + tempList[6];
                    }
                    if (((~value) & _weekday[0]) == _weekday[0])
                    {
                        tmp = tmp + ", " + tempList[0];
                    }
                }
                else
                {
                    value = ~value & 0xff - 1;
                    if (GetCount(value) == 1)
                    {
                        for (int i = 0; i < 7; i++)
                        {
                            if ((value & _weekday[i]) == _weekday[i])
                            {
                                tmp = _weekdaysfull[i];
                            }
                        }
                    }
                    else
                    {
                        if ((value & 0x82) == 0x82)
                        {
                            string End = "Weekends, ";
                            for (int i = 1; i < 6; i++)
                            {
                                if ((value & _weekday[i]) == _weekday[i])
                                {
                                    tmp = tmp + tempList[i] + ", ";

                                }
                            }
                            tmp = tmp + End;
                        }
                        else
                        {
                            for (int i = 0; i < 7; i++)
                            {
                                if ((value & _weekday[i]) == _weekday[i])
                                {
                                    tmp = tmp + tempList[i] + ", ";

                                }
                            }
                        }
                        tmp = tmp.Remove(tmp.Length - 2);
                    }
                }
            }
            return tmp;
        }

        public string GetRegiTime()
        {
            string tmp = "from ";
            _currentRegStartTime = GetRegistryValue(_regsmartstandby, "ActiveTimeStart").ToString();
            tmp = tmp + GetRegistryValue(_regsmartstandby, "ActiveTimeStart");
            tmp = tmp + " to " + GetRegistryValue(_regsmartstandby, "ActiveTimeEnd");
            return tmp;
        }

        public SSTIME GetSmartStandbyTime()
        {
            SSTIME sst = new SSTIME();
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            string strTime = VantageCommonHelper.GetAttributeValue(_hsPowerSettingsPage.SmartStandbyTManualScheduleTime, "Name");
            if (strTime != null)
            {
                sst.start = new TIME() { hours = Convert.ToUInt32(strTime.Split(' ')[1].Split(':')[0]), minutes = Convert.ToUInt32(strTime.Split(' ')[1].Split(':')[1]) };
                sst.end = new TIME() { hours = Convert.ToUInt32(strTime.Split(' ')[3].Split(':')[0]), minutes = Convert.ToUInt32(strTime.Split(' ')[3].Split(':')[1]) };
            }
            else
            {
                Assert.Fail("Get SmartStandbyTime fail.");
            }
            return sst;
        }

        public SSTIME GetSmartStandbyTimeV1()
        {
            SSTIME sst = new SSTIME();
            string startTime = GetRegistryValue(_regsmartstandby, "ActiveTimeStart").ToString();
            string endTime = GetRegistryValue(_regsmartstandby, "ActiveTimeEnd").ToString();
            sst.start = new TIME() { hours = Convert.ToUInt32(startTime.Split(':')[0]), minutes = Convert.ToUInt32(startTime.Split(':')[1]) };
            sst.end = new TIME() { hours = Convert.ToUInt32(endTime.Split(':')[0]), minutes = Convert.ToUInt32(endTime.Split(':')[1]) };
            return sst;
        }

        private string SetSmartStandbyRandomValue(string vantageVersion, string isSave)
        {
            string tmp = string.Empty;
            string rd_value = string.Empty;
            Random rd = new Random();
            string rd_hours = string.Format("{0:D2}", rd.Next(0, 24));
            string rd_minutes = string.Format("{0:D2}", minutes[rd.Next(0, 4)]);
            UInt32 tmp_end_hour = Convert.ToUInt32(rd_hours) + Convert.ToUInt32(rd.Next(1, 20));
            LogHelper.Logger.Instance.WriteLog($"*rd_hours: {rd_hours} and *rd_minutes: {rd_minutes} and *tmp_end_hour: {tmp_end_hour}*");
            if (tmp_end_hour >= 24)
            {
                tmp_end_hour = tmp_end_hour - 24;
            }
            string rd_end_hours = string.Format("{0:D2}", tmp_end_hour);
            string rd_end_minutes = string.Format("{0:D2}", minutes[rd.Next(0, 4)]);
            LogHelper.Logger.Instance.WriteLog($"*rd_end_hours: {rd_end_hours} and *rd_end_minutes: {rd_end_minutes}*");
            List<UInt32> list_weekdays = new List<UInt32> { 0xfc, 0xfa, 0xf6, 0xee, 0xde, 0xbe, 0x7e };
            for (int n = 0; n < 2; n++)
            {
                list_weekdays.Remove(list_weekdays[rd.Next(0, list_weekdays.ToArray().Length)]);
            }
            UInt32 week = list_weekdays[0] & list_weekdays[1] & list_weekdays[2] & list_weekdays[3] & list_weekdays[4];
            tmp = rd_hours + ":" + rd_minutes + "," + rd_end_hours + ":" + rd_end_minutes + "," + week.ToString();
            _smartstandbyvalue = new object[] { rd_hours + ":" + rd_minutes, rd_end_hours + ":" + rd_end_minutes, week.ToString() };
            SetSmartStandbyStartValue(_smartstandbyvalue, vantageVersion, isSave);
            SetSmartStandbyEndValue(_smartstandbyvalue, vantageVersion, isSave);
            SetSmartStandbyDaysValue(_smartstandbyvalue, isSave);
            //Assert.True(true,tmp);
            return tmp;
        }

        private void SetSmartStandbyStartValue(object[] parameters, string vantageVersion, string isSave)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            TIME para_start = new TIME() { hours = Convert.ToUInt32(parameters[0].ToString().Split(':')[0]), minutes = Convert.ToUInt32(parameters[0].ToString().Split(':')[1]) };
            SSTIME sst = new SSTIME();
            if (vantageVersion == "1.0")
            {
                sst = GetSmartStandbyTimeV1();
            }
            else
            {
                sst = GetSmartStandbyTime();
            }
            LogHelper.Logger.Instance.WriteLog($"*sst.start.hours: {sst.start.hours} and *sst.start.minutes: {sst.start.minutes}*");
            //start
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartSectionDropDownList);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            if (para_start.hours >= 12)
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartPM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartAM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            if (para_start.hours >= sst.start.hours)
            {
                for (int i = 0; i < para_start.hours - sst.start.hours; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartHOURSDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {//smartStandby-start-hours-prev-btn
                for (int i = 0; i < sst.start.hours - para_start.hours; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartHOURSUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            if (para_start.minutes >= sst.start.minutes)
            {
                for (int i = 0; i < (para_start.minutes - sst.start.minutes) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartMINUTESDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {
                for (int i = 0; i < (sst.start.minutes - para_start.minutes) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartMINUTESUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            if (isSave == "notsave")
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCloseMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleStartCheckMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }

        }

        public void SetSmartStandbyEndValue(object[] parameters, string vantageVersion, string isSave)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            TIME para_end = new TIME() { hours = Convert.ToUInt32(parameters[1].ToString().Split(':')[0]), minutes = Convert.ToUInt32(parameters[1].ToString().Split(':')[1]) };
            SSTIME sst = new SSTIME();
            if (vantageVersion == "1.0")
            {
                sst = GetSmartStandbyTimeV1();
            }
            else
            {
                sst = GetSmartStandbyTime();
            }
            LogHelper.Logger.Instance.WriteLog($"*sst.end.hours: {sst.end.hours} and *sst.end.minutes: {sst.end.minutes}*");
            //end
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndSectionDropDownList);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            if (para_end.hours >= 12)
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndPM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndAM);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            if (para_end.hours >= sst.end.hours)
            {
                for (int i = 0; i < para_end.hours - sst.end.hours; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndHOURSDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {
                for (int i = 0; i < sst.end.hours - para_end.hours; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndHOURSUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            if (para_end.minutes >= sst.end.minutes)
            {
                for (int i = 0; i < (para_end.minutes - sst.end.minutes) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndMINUTESDown);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            else
            {
                for (int i = 0; i < (sst.end.minutes - para_end.minutes) / 15; i++)
                {
                    _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndMINUTESUp);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                    Thread.Sleep(300);
                }
            }
            if (isSave == "notsave")
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCloseMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleEndCheckMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }

        }

        private void SetSmartStandbyDaysValue(object[] parameters, String isSave)
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            //SCHEDULE
            _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSectionDropDownList);
            Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            UInt32 para_schedule = Convert.ToUInt32(parameters[2]);
            WindowsElement[] WeekdaysID = new WindowsElement[7] { _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSun, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysMon, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysTue, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysWed, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysThurs, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysFri, _hsPowerSettingsPage.SmartStandbyTManualScheduleDaysSat };
            for (int w = 0; w < 7; w++)
            {
                para_schedule = para_schedule >> 1;
                UInt32 tmp = para_schedule & 0x01;
                ToggleState tarToggle = _hsPowerSettingsPage.GetCheckBoxStatus(WeekdaysID[w]);
                string sta = "0";
                if (tarToggle == ToggleState.On)
                {
                    sta = "1";
                }
                if (sta == tmp.ToString())
                {
                    _errorResult = ClickVantageElements(WeekdaysID[w]);
                    Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
                }
            }
            if (isSave == "notsave")
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCloseMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
            else
            {
                _errorResult = ClickVantageElements(_hsPowerSettingsPage.SmartStandbyTManualScheduleDaysCheckMark);
                Assert.AreEqual(ErrorMessage.ClickSuccessed, _errorResult);
            }
        }

        public void CopyFolder(string sourcFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
            {
                Directory.CreateDirectory(destFolder);
            }
            string[] files = Directory.GetFiles(sourcFolder);
            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest, true);
            }
            string[] folders = Directory.GetDirectories(sourcFolder);
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }
    }
}
