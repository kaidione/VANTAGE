using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using static LenovoVantageTest.Helper.VantageCommonHelper;
using Point = System.Drawing.Point;

namespace LenovoVantageTest.Pages
{
    public class HSPowerSettingsPage : SettingsBase
    {
        string csLogPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Auto Logs\IdeaGuiTool.exe");
        string workPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Auto Logs");
        string logPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Auto Logs\Logs\debug.log");
        private WindowsDriver<WindowsElement> session;

        public static uint SND_ASYNC = 0x0001;
        public static uint SND_FILENAME = 0x00020000;
        private string batteryChargeToggle = "//*[@AutomationId='ds-power-battery-threshold']";
        private string batteryGuageNote = "//*[@AutomationId='batteryGauge-thresholdNote']";
        //HS-threshold
        private string _hsThredholdCheckBox = "//*[@AutomationId='ds-power-battery-threshold_checkbox']";
        private string _hsThredholdEnableBtn = "//*[@AutomationId='battery-threshold-popup-enable']";
        private string _hsThreholdSecondaryBatteryStartDropDown = "//*[@AutomationId='threshold-secondary-battery-start-dropdown']";
        private string _hsThreholdSecondaryBatteryStopDropDown = "//*[@AutomationId='threshold-secondary-battery-stop-dropdown']";
        private string _hsThreholdPrimaryBatteryStartDropDown = "//*[@AutomationId='threshold-primary-battery-start-dropdown']";
        private string _hsThreholdPrimaryBatteryStopDropDown = "//*[@AutomationId='threshold-primary-battery-stop-dropdown']";

        private string _hsJudgeDualBattery = "//*[@AutomationId='threshold-secondary-battery-title']";
        private string _hsThreholdTitle = "ds-power-battery-threshold-title";

        private string _hsPrimaryStartFirstValue = "//*[@AutomationId='threshold-primary-battery-startAtChargeOption-40']";
        private string _hsPrimaryStartLastValue = "//*[@AutomationId='threshold-primary-battery-startAtChargeOption-95']";
        private string _hsPrimaryStopFirstValue = "//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-45']";
        private string _hsPrimaryStopLastValue = "//*[@AutomationId='threshold-primary-battery-stopAtChargeOption-100']";

        private string _hsSecondaryStartFirstValue = "//*[@AutomationId='threshold-secondary-battery-startAtChargeOption-40']";
        private string _hsSecondaryStartLastValue = "//*[@AutomationId='threshold-secondary-battery-startAtChargeOption-95']";
        private string _hsSecondaryStopFirstValue = "//*[@AutomationId='threshold-secondary-battery-stopAtChargeOption-45']";
        private string _hsSecondaryStopLastValue = "//*[@AutomationId='threshold-secondary-battery-stopAtChargeOption-100']";

        public WindowsElement HSThredholdCheckBoxEle => FindElementByApp(session, "AutomationId", "PowerPage", "HSThredholdCheckBoxEle", 10);
        public WindowsElement HSThredholdEnableBtnEle => FindElementByApp(session, "AutomationId", "PowerPage", "HSThredholdEnableBtnEle", 10);

        public WindowsElement HSThreholdSecondaryBatteryStartDropDownEle => base.GetElement(session, "XPath", _hsThreholdSecondaryBatteryStartDropDown);
        public WindowsElement HSThreholdSecondaryBatteryStopDropDownEle => base.GetElement(session, "XPath", _hsThreholdSecondaryBatteryStopDropDown);
        public WindowsElement HSThreholdPrimaryBatteryStartDropDownEle => base.GetElement(session, "XPath", _hsThreholdPrimaryBatteryStartDropDown);
        public WindowsElement HSThreholdPrimaryBatteryStopDropDownEle => base.GetElement(session, "XPath", _hsThreholdPrimaryBatteryStopDropDown);
        public WindowsElement HSJudgeDualBatteryEle => base.GetElement(session, "XPath", _hsJudgeDualBattery);
        public WindowsElement HSThreholdTitleEle => base.GetElement(session, "XPath", _hsThreholdTitle);

        public WindowsElement HSPrimaryStartFirstValueEle => base.GetElement(session, "XPath", _hsPrimaryStartFirstValue);
        public WindowsElement HSPrimaryStartLastValueEle => base.GetElement(session, "XPath", _hsPrimaryStartLastValue);
        public WindowsElement HSPrimaryStopFirstValueEle => base.GetElement(session, "XPath", _hsPrimaryStopFirstValue);
        public WindowsElement HSPrimaryStopLastValueEle => base.GetElement(session, "XPath", _hsPrimaryStopLastValue);

        public WindowsElement HSSecondaryStartFirstValueEle => base.GetElement(session, "XPath", _hsSecondaryStartFirstValue);
        public WindowsElement HSSecondaryStartLastValueEle => base.GetElement(session, "XPath", _hsSecondaryStartLastValue);
        public WindowsElement HSSecondaryStopFirstValueEle => base.GetElement(session, "XPath", _hsSecondaryStopFirstValue);
        public WindowsElement HSSecondaryStopLastValueEle => base.GetElement(session, "XPath", _hsSecondaryStopLastValue);
        public WindowsElement HSBatteryThresholdRightIcon => base.GetElement(session, "AutomationId", "ds-power-battery-threshold-tooltip_right_icon");
        public WindowsElement BatteryChargeThresholdTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdTitle"));
        public WindowsElement BatteryChargeThresholdCaption => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdCaption"));
        public WindowsElement BatteryChargeThresholdAlertBox => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBox"));
        public WindowsElement BatteryChargeThresholdAlertBoxTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxTitle"));
        public WindowsElement BatteryChargeThresholdAlertBoxLine1 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxLine1"));
        public WindowsElement BatteryChargeThresholdAlertBoxLine2 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxLine2"));
        public WindowsElement BatteryChargeThresholdAlertBoxLine3 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxLine3"));
        public WindowsElement BatteryChargeThresholdAlertBoxLine4 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxLine4"));
        public WindowsElement BatteryChargeThresholdAlertBoxHere => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdAlertBoxHere"));
        public WindowsElement BatteryChargeThresholdJumpPageBack => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageBack"));
        public WindowsElement BatteryChargeThresholdJumpPageTtile1 => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageTtile1"));
        public WindowsElement BatteryChargeThresholdJumpPageTtile2 => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageTtile2"));
        public WindowsElement BatteryChargeThresholdJumpPageLine1 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageLine1"));
        public WindowsElement BatteryChargeThresholdJumpPageLine2 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageLine2"));
        public WindowsElement BatteryChargeThresholdJumpPageLine3 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageLine3"));
        public WindowsElement BatteryChargeThresholdJumpPageLine4 => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdJumpPageLine4"));
        public WindowsElement BatteryChargeThresholdStartValue => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdStartValue"));
        public WindowsElement BatteryChargeThresholdStopValue => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdStopValue"));
        public WindowsElement BatterySettingsSectionTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatterySettingsSectionTitle"), 10);
        //ds-power-battery-threshold-toolTip

        public WindowsElement HSBatteryThresholdToolTip => base.GetElement(session, "AutomationId", "ds-power-battery-threshold-toolTip");
        //public WindowsElement HSBatteryThresholdTitle => base.GetElement(session, "AutomationId", "ds-power-battery-threshold-title");
        public WindowsElement HSBatteryThresholdTitle => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryThresholdTitle", 10);
        public WindowsElement BatteryThresholdNote => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryThresholdNote"));
        public WindowsElement PrimaryBatteryThresholdCheckbox => FindElementByApp(session, "AutomationId", "PowerPage", "PrimaryBatteryThresholdCheckbox", 10);
        public WindowsElement BatteryGaugethresholdNoteEle => base.GetElement(session, "AutomationId", "batteryGauge-thresholdNote");
        public WindowsElement ConservationModeCheckbox => base.FindElementByTimes(session, "XPath", VantageConstContent.HS_ConservationCheckBox);
        public WindowsElement RapidChargeModeCheckbox => base.GetElement(session, "XPath", VantageConstContent.HS_RapidChargeCheckBox);
        public WindowsElement ConservationModeTitle => base.GetElement(session, "XPath", VantageConstContent.HS_ConservationTitle);
        public WindowsElement WifiSecurityCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.WifiSecurity.WiFiSecurityToggle"));
        public WindowsElement WifiSecurityTitle => base.GetElement(session, "XPath", "//*[@AutomationId='security-wifi-header-title']");
        public WindowsElement WifiSecuritySigninButton => base.GetElement(session, "XPath", "//*[@AutomationId='btn-common-dialog-sign in']");
        public WindowsElement WifiSecurityDialogCloseButton => base.GetElement(session, "XPath", "//*[@AutomationId='sa-ws-btn-locationClose']");
        public WindowsElement WifiSecurityDialogAgreeButton => base.GetElement(session, "XPath", "//*[@AutomationId='sa-ws-btn-locationAgree']");
        public WindowsElement BatteryGaugeProgressStep1TextEle => FindElementByApp(session, "Name", "PowerPage", "BatteryGaugeProgressStep1TextEle", 10);
        //Step 1, out of 3 steps in total: Calibrating to full charge
        public WindowsElement BatteryGaugeProgressFullCharge => base.GetElement(session, "Name", "Step 1, out of 3 steps in total: Calibrating to full charge");

        public WindowsElement BatteryGaugeSecondaryBatteryPanelTitle => FindElementByApp(session, "AutomationId", "PowerPage", "BatteryGaugeSecondaryBatteryPanelTitle", 10);
        public WindowsElement BatteryGaugePrimaryBatteryPanelTitle => FindElementByApp(session, "AutomationId", "PowerPage", "BatteryGaugePrimaryBatteryPanelTitle", 10);
        public WindowsElement BatteryGaugeOnlyOneNote => base.GetElement(session, "Name", "Note: Only one battery can be reset at a time.");
        public WindowsElement PowerPagePowerSectionTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.PowerSectionTitle"));

        //Smart Standby
        public WindowsElement SmartStandbyJumpLink => base.GetElement(session, "AutomationId", "jumptoSetting-smartStandby");
        public WindowsElement SmartStandbyTFeatureTitle => GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.Standby.Title"));
        public WindowsElement SmartStandbyTFeatureDescription => base.GetElement(session, "AutomationId", "smart-standby-toggle-caption");
        public WindowsElement SmartStandbyTQuestionMark => base.GetElement(session, "AutomationId", "smart-standby-toggle-tooltip_right_icon");
        public WindowsElement SmartStandbyTQuestionTip => base.GetElement(session, "AutomationId", "smart-standby-toggle-toolTip");
        public WindowsElement SmartStandbyTComputerScheduleTitle => base.GetElement(session, "AutomationId", "smart-standby-schedule-computer", 10);
        public WindowsElement SmartStandbyTManualOption => base.GetElement(session, "AutomationId", "Manual mode", 10);
        public WindowsElement SmartStandbyTAutoOption => base.GetElement(session, "AutomationId", "Automatic mode", 10);
        public WindowsElement SmartStandbyTToggle => base.GetElement(session, "AutomationId", "smart-standby-toggle_checkbox");
        public WindowsElement SmartStandbyTManualScheduleTitle => base.GetElement(session, "AutomationId", "smartstandby-timer-heading");
        public WindowsElement SmartStandbyTManualScheduleDays => base.GetElement(session, "AutomationId", "smartstandby-schedule");
        public WindowsElement SmartStandbyTManualScheduleTime => base.GetElement(session, "AutomationId", "smartstandby-time");
        public WindowsElement SmartStandbyTManualScheduleChangeLink => base.GetElement(session, "AutomationId", "smartstandby-click-to-change");
        public WindowsElement SmartStandbyTManualScheduleCollapseLink => base.GetElement(session, "AutomationId", "smartstandby-click-to-change-collapse");
        public WindowsElement SmartStandbyTManualScheduleStartSectionTitle => base.GetElement(session, "AutomationId", "start");
        public WindowsElement SmartStandbyTManualScheduleStartSectionDropDownList => base.GetElement(session, "AutomationId", "smartStandby-start-dropDown-btn");
        public WindowsElement SmartStandbyTManualScheduleEndSectionTitle => base.GetElement(session, "AutomationId", "end");
        public WindowsElement SmartStandbyTManualScheduleEndSectionDropDownList => base.GetElement(session, "AutomationId", "smartStandby-end-dropDown-btn");
        public WindowsElement SmartStandbyTManualScheduleDaysSectionTitle => base.GetElement(session, "AutomationId", "use-schedule-for");
        public WindowsElement SmartStandbyTManualScheduleDaysSectionDropDownList => base.GetElement(session, "AutomationId", "smartStandby-shedule");
        public WindowsElement SmartStandbyTManualScheduleStartHOURSUp => base.GetElement(session, "AutomationId", "smartStandby-start-hours-prev-btn");
        public WindowsElement SmartStandbyTManualScheduleStartHOURSDown => base.GetElement(session, "AutomationId", "smartStandby-start-hours-next-btn");
        public WindowsElement SmartStandbyTManualScheduleStartMINUTESUp => base.GetElement(session, "AutomationId", "smartStandby-start-minutes-prev-btn");
        public WindowsElement SmartStandbyTManualScheduleStartMINUTESDown => base.GetElement(session, "AutomationId", "smartStandby-start-minutes-next-btn");
        public WindowsElement SmartStandbyTManualScheduleEndHOURSUp => base.GetElement(session, "AutomationId", "smartStandby-end-hours-prev-btn");
        public WindowsElement SmartStandbyTManualScheduleEndHOURSDown => base.GetElement(session, "AutomationId", "smartStandby-end-hours-next-btn");
        public WindowsElement SmartStandbyTManualScheduleEndMINUTESUp => base.GetElement(session, "AutomationId", "smartStandby-end-minutes-prev-btn");
        public WindowsElement SmartStandbyTManualScheduleEndMINUTESDown => base.GetElement(session, "AutomationId", "smartStandby-end-minutes-next-btn");
        public WindowsElement SmartStandbyTManualScheduleStartAM => base.GetElement(session, "AutomationId", "start-am-radio");
        public WindowsElement SmartStandbyTManualScheduleStartPM => base.GetElement(session, "AutomationId", "start-pm-radio");
        public WindowsElement SmartStandbyTManualScheduleEndAM => base.GetElement(session, "AutomationId", "end-am-radio");
        public WindowsElement SmartStandbyTManualScheduleEndPM => base.GetElement(session, "AutomationId", "end-pm-radio");
        public WindowsElement SmartStandbyTManualScheduleStartCheckMark => base.GetElement(session, "AutomationId", "smartStandby-start-done-icon");
        public WindowsElement SmartStandbyTManualScheduleEndCheckMark => base.GetElement(session, "AutomationId", "smartStandby-end-done-icon");
        public WindowsElement SmartStandbyTManualScheduleDaysCheckMark => base.GetElement(session, "AutomationId", "daysPickerDone");
        public WindowsElement SmartStandbyTManualScheduleStartCloseMark => base.GetElement(session, "AutomationId", "smartStandby-start-close-icon");
        public WindowsElement SmartStandbyTManualScheduleEndCloseMark => base.GetElement(session, "AutomationId", "smartStandby-end-close-icon");
        public WindowsElement SmartStandbyTManualScheduleDaysCloseMark => base.GetElement(session, "AutomationId", "daysPickerClear");
        public WindowsElement SmartStandbyTManualScheduleDaysSun => base.GetElement(session, "AutomationId", "Sunday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysMon => base.GetElement(session, "AutomationId", "Monday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysTue => base.GetElement(session, "AutomationId", "Tuesday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysWed => base.GetElement(session, "AutomationId", "Wednesday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysThurs => base.GetElement(session, "AutomationId", "Thursday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysFri => base.GetElement(session, "AutomationId", "Friday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleDaysSat => base.GetElement(session, "AutomationId", "Saturday_checkbox");
        public WindowsElement SmartStandbyTManualScheduleTimeWithout20 => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyTManualScheduleTimeWithout20"));
        public WindowsElement SmartStandbyTManualScheduleAnyDayTip => base.GetElement(session, "AutomationId", "smartStandby-warningtip");
        public WindowsElement SmartStandbyTManualScheduleGraphLink => base.GetElement(session, "AutomationId", "modal_smartStandby_graphLink");
        public WindowsElement SmartStandbyTManualScheduleUsageGraphTitle => base.GetElement(session, "AutomationId", "usage-computer");
        public WindowsElement SmartStandbyTManualScheduleActiveGraphTitle => base.GetElement(session, "AutomationId", "smart-standby-active-time");
        public WindowsElement SmartStandbyTManualScheduleActiveGraphCloseButton => base.GetElement(session, "AutomationId", "smart-standby-close-button");
        public WindowsElement SmartStandbyTManualScheduleActiveGraphCloseButtonX => base.GetElement(session, "AutomationId", "modal-smartStandby-close");
        public WindowsElement SmartStandbyTAutoScheduleTip => base.GetElement(session, "AutomationId", "smartStandby-automaticMode-subNote");
        public WindowsElement SmartStandbyStartHoursValue => base.GetElement(session, "AutomationId", "start-hours-value");
        public WindowsElement SmartStandbyStartMinutesValue => base.GetElement(session, "AutomationId", "start-minutes-value");
        public WindowsElement SmartStandbyStartAMPMValue => base.GetElement(session, "AutomationId", "start-amPm-value");
        public WindowsElement SmartStandbyEndHoursValue => base.GetElement(session, "AutomationId", "end-hours-value");
        public WindowsElement SmartStandbyEndMinutesValue => base.GetElement(session, "AutomationId", "end-minutes-value");
        public WindowsElement SmartStandbyEndAMPMValue => base.GetElement(session, "AutomationId", "end-amPm-value");
        public WindowsElement SmartStadbyUsageChart => base.GetElement(session, "AutomationId", "usageComputer-chartContainer");
        public WindowsElement SmartStadbyActiveChart => base.GetElement(session, "AutomationId", "appliedActiveTime-chartContainer");
        public WindowsElement SmartStadbyStartHoursTitle => base.GetElement(session, "AutomationId", "smartStandby-start-hours");
        public WindowsElement SmartStadbyStartMinutesTitle => base.GetElement(session, "AutomationId", "smartStandby-start-minutes");
        public WindowsElement SmartStadbyStartAMPMTitle => base.GetElement(session, "AutomationId", "smartStandby-start-amPm");
        public WindowsElement SmartStadbyEndHoursTitle => base.GetElement(session, "AutomationId", "smartStandby-end-hours");
        public WindowsElement SmartStadbyEndMinutesTitle => base.GetElement(session, "AutomationId", "smartStandby-end-minutes");
        public WindowsElement SmartStadbyEndAMPMTitle => base.GetElement(session, "AutomationId", "smartStandby-end-amPm");
        public WindowsElement SmartStandbyNotEnoughData => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyNotEnoughData"));
        public WindowsElement SmartStandbyNotEnoughDataNameForLe => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyNotEnoughDataNameForLe"));
        public WindowsElement StandBySettingsTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.StandBySettingsTitle"), 10);

        // Energy Star
        public WindowsElement EnergyStarTitleElement => base.GetElement(session, "AutomationId", "device-settings-power-otherSettings-collapse-card-title");
        public WindowsElement EnergyStarImageElement => base.GetElement(session, "AutomationId", "energystar-image");
        public WindowsElement EnergyStarContentElement => base.GetElement(session, "AutomationId", "power-energyStar-description");

        public string SmartStandbyTFeatureDescriptionSPEC = "This feature schedules your computer to optimize battery power savings during idle hours without sacrificing fast-resume experience of Modern Standby during hours of heavier use.";
        public string SmartStandbyTQuestionTipSPEC = GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyTQuestionTipSPEC").ToString();
        public string SmartStandbyTComputerScheduleTitleSPEC = "Schedule your computer";
        public string SmartStandbyTManualOptionSPEC = "Manual mode";
        public string SmartStandbyTAutoOptionSPEC = "Automatic mode";
        public string SmartStandbyTManualScheduleTitleSPEC = "The time you typically use this computer:";
        public string SmartStandbyTManualScheduleChangeLinkSPEC = "CLICK TO CHANGE";
        public string SmartStandbyTManualScheduleCollapseLinkSPEC = "COLLAPSE";
        public string SmartStandbyTManualScheduleStartSectionTitleSPEC = "START";
        public string SmartStandbyTManualScheduleEndSectionTitleSPEC = "END";
        public string SmartStandbyTManualScheduleDaysSectionTitleSPEC = "USE THIS SCHEDULE FOR";
        public string SmartStandbyTManualScheduleTimeWithout20SPEC = GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyTManualScheduleTimeWithout20SPEC").ToString();
        public string SmartStandbyTManualScheduleAnyDayTipSPEC = "Please select at least one day.";
        public string SmartStandbyTManualScheduleGraphLinkSPEC = "Click to see the usage and applied active time";
        public string SmartStandbyTManualScheduleUsageGraphTitleSPEC = "Usage of this computer";
        public string SmartStandbyTManualScheduleActiveGraphTitleSPEC = "Applied active time";
        public string SmartStandbyTAutoScheduleTipSPEC = "Your computer is scheduled for quicker resume based on the usage.";
        public string SmartStadbyStartHoursTitleSPEC = "HOURS";
        public string SmartStadbyStartMinutesTitleSPEC = "MINUTES";
        public string SmartStadbyStartAMPMTitleSPEC = "AM/PM";
        public string SmartStadbyEndHoursTitleSPEC = "HOURS";
        public string SmartStadbyEndMinutesTitleSPEC = "MINUTES";
        public string SmartStadbyEndAMPMTitleSPEC = "AM/PM";
        public string SmartStandbyTManualScheduleAMRadioSPEC = "AM";
        public string SmartStandbyTManualSchedulePMRadioSPEC = "PM";
        public string SmartStandbyNotEnoughDataSPEC = GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SmartStandbyNotEnoughDataSPEC").ToString();
        //"PowerMgr" Battery Gauge Reset
        public string PowerMgrProcessName = "PowerMgr";
        //public WindowsElement BatteryMissingDriverCondition => base.GetElement(session, "AutomationId", "battery-condition-tip-MissingDriver", 10);
        public WindowsElement BatteryMissingDriverCondition => FindElementByApp(session, "AutomationId", "PowerPage", "BatteryMissingDriverCondition", 10, 2, true);
        public WindowsElement HSBatteryGuageResetBatteryNote => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetBatteryNote", 10);
        public WindowsElement HSBatteryThresoldBatteryNote => FindElementByApp(session, "Name", "PowerPage", "HSBatteryThresoldBatteryNote", 10);

        public WindowsElement BatteryGoodConditionIcon => base.GetElement(session, "AutomationId", "batteryConditionIcon-GoodBattery");
        //public WindowsElement HSBatteryGuageResetTitle => base.GetElement(session, "AutomationId", "ds-power-battery-batteryGaugeReset-title");
        public WindowsElement HSBatteryGuageResetTitle => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetTitle", 10);
        //public WindowsElement HSBatteryGuageResetCaption => base.GetElement(session, "AutomationId", "ds-power-battery-batteryGaugeReset-caption");
        public WindowsElement HSBatteryGuageResetCaption => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetCaption", 10);
        public WindowsElement HSBatteryGuageReset2Details => base.GetElement(session, "AutomationId", "Battery-2-details");
        //public WindowsElement HSBatteryGuageResetOneBatteryTitle => base.GetElement(session, "AutomationId", "deviceSettings-batteryGauge-subtitle");
        public WindowsElement HSBatteryGuageResetOneBatteryTitle => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetOneBatteryTitle", 10);
        //public WindowsElement HSBatteryGuageResetBarcodeTitle => base.GetElement(session, "AutomationId", "battery-barcode-title-1");
        public WindowsElement HSBatteryGuageResetBarcodeTitle => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetBarcodeTitle", 10);
        //public WindowsElement HSBatteryGuageResetBarcodeValue => base.GetElement(session, "AutomationId", "battery-barcode-value-1");
        public WindowsElement HSBatteryGuageResetBarcodeValue => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetBarcodeValue", 10);
        //public WindowsElement HSBatteryGuageResetBtn => base.GetElement(session, "AutomationId", "myDevice-settings-battery-gauge-reset-stop-btn1");
        public WindowsElement HSBatteryGuageResetBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetBtn", 10);
        //public WindowsElement HSBatteryGuageResetlastReset => base.GetElement(session, "AutomationId", "batterySettings-gaugeReset-lastReset-title-1");
        public WindowsElement HSBatteryGuageResetlastReset => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetlastReset");
        //public WindowsElement HSBatteryGuageResetlastResetTimeValue => base.GetElement(session, "AutomationId", "batterySettings-battery-lastResetTime-value-12hrs-1");
        public WindowsElement HSBatteryGuageResetlastResetTimeValue => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetlastResetTimeValue", 10);
        public WindowsElement HSBatteryGuageResetprogressText1 => base.GetElement(session, "AutomationId", "batterySettings-gaugeReset-progressText1");
        public WindowsElement HSBatteryGuageResetRemainingValue => base.GetElement(session, "AutomationId", "batterySettings-gaugeReset-remainingPercentage-value");
        public WindowsElement HSBatteryGuageResetStarttimeValue => base.GetElement(session, "AutomationId", "battery-startTime-value-12hrs-format");
        //public WindowsElement HSBatteryGuageResetPopupTitle => base.GetElement(session, "AutomationId", "ds-guageReset-popup");
        public WindowsElement HSBatteryGuageResetPopupTitle => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPopupTitle", 10);
        public WindowsElement HSBatteryGuageResetPopupDescription1 => base.GetElement(session, "AutomationId", "ds-guageResetpopup-description1");
        public WindowsElement HSBatteryGuageResetPopupDescription2 => base.GetElement(session, "AutomationId", "ds-guageResetpopup-description2");

        public WindowsElement HSBatteryGuageResetPopupWindow => base.GetElement(session, "AutomationId", "modal-battery-charge-threshold");
        public WindowsElement HSBatteryGuageResetPopupTitleText => base.GetElement(session, "Name", "Battery gauge reset");
        public WindowsElement HSBatteryGuageResetStopPopupDescription => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetStopPopupDescription", 10);
        public WindowsElement HSBatteryGuageResetLastResetText => base.GetElement(session, "Name", "Last reset");
        public WindowsElement HSBatteryGuageResetProcessText => base.GetElement(session, "Name", "Process");
        public WindowsElement HSBatteryGuageResetRemainingText => base.GetElement(session, "Name", "Remaining");
        public WindowsElement HSBatteryGuageResetStarttimeText => base.GetElement(session, "Name", "Start time");


        public WindowsElement HSBatteryGuageResetPopupYes => base.GetElement(session, "AutomationId", "battery-guageReset-popup-yes");
        public WindowsElement HSBatteryGuageResetPopupCancel => base.GetElement(session, "AutomationId", "battery-guageReset-popup-cancel");
        public WindowsElement HSBatteryGuageResetPopupClose => base.GetElement(session, "AutomationId", "ds-guageReset-popup-close-button");

        public string Expected_HSBatteryGuageResetPopup_TitleDescription_1 = "The resetting process is as follows:";
        public string Expected_HSBatteryGuageResetPopup_TitleDescription_2 = "Fully charge the battery --> Discharge to low battery power --> Recharge to high battery power or full charge";
        public string Expected_HSBatteryGuageResetPopup_Note = "Notes:";
        public string Expected_HSBatteryGuageResetPopup_Note_Description1 = "1. The process may take several hours.Please avoid using the computer during this period.";
        public string Expected_HSBatteryGuageResetPopup_Note_Description2 = "2. Close all open apps and connect your computer to ac power.";
        public string Expected_HSBatteryGuageResetPopup_Note_Description3 = "3. During the process, the battery charge threshold function is disabled.";
        public WindowsElement HSBatteryGuageResetPopup_TitleDescription_1 => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_TitleDescription_1", 10);
        public WindowsElement HSBatteryGuageResetPopup_TitleDescription_2 => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_TitleDescription_2", 10);
        public WindowsElement HSBatteryGuageResetPopup_Note => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_Note", 10);
        public WindowsElement HSBatteryGuageResetPopup_Note_Description1 => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_Note_Description1", 10);
        public WindowsElement HSBatteryGuageResetPopup_Note_Description2 => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_Note_Description2", 10);
        public WindowsElement HSBatteryGuageResetPopup_Note_Description3 => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetPopup_Note_Description3", 10);

        //public WindowsElement HSBatteryGuageResetPopupContinueBtn => base.GetElement(session, "AutomationId", "battery-guageReset-popup-continue");
        public WindowsElement HSBatteryGuageResetPopupContinueBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPopupContinueBtn", 10);
        //public WindowsElement HSBatteryGuageResetPopupCancelBtn => base.GetElement(session, "AutomationId", "battery-guageReset-popup-cancel");
        public WindowsElement HSBatteryGuageResetPopupCancelBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPopupCancelBtn", 10);
        //public WindowsElement HSBatteryGuageResetPopupCloseBtn => base.GetElement(session, "AutomationId", "ds-guageReset-popup-close-button");
        public WindowsElement HSBatteryGuageResetPopupCloseBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPopupCloseBtn", 10);
        public WindowsElement HSBatteryGuageResetPerformedProgress => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPerformedProgress", 10);
        public WindowsElement HSBatteryGuageResetPerformedRemaining => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPerformedRemaining", 10);
        public WindowsElement HSBatteryGuageResetPerformedStartTime => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetPerformedStartTime", 10);
        //public WindowsElement HSBatteryGuageResetStopBtn => base.GetElement(session, "AutomationId", "myDevice-settings-battery-gauge-reset-stop-btn1");
        public WindowsElement HSBatteryGuageResetStopBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageStopBtn", 10);
        //public WindowsElement HSBatteryGuageResetStopPopYesBtn => base.GetElement(session, "AutomationId", "battery-guageReset-popup-yes");
        public WindowsElement HSBatteryGuageResetStopPopYesBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetStopPopYesBtn", 10);
        public WindowsElement HSBatteryThresoldOneBatteryStartValue => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryThresoldOneBatteryStartValue", 10);
        public WindowsElement HSBattrtyState => FindElementByApp(session, "Name", "PowerPage", "HSBattrtyState", 10);
        public WindowsElement HSBattrtyDetailsButton => FindElementByApp(session, "AutomationId", "PowerPage", "HSBattrtyDetailsButton", 10);
        public WindowsElement HSBatteryGuageResetNotInACNote => FindElementByApp(session, "Name", "PowerPage", "HSBatteryGuageResetNotInACNote", 10);
        public WindowsElement HSBatteryGuageResetSecondaryResetBtn => FindElementByApp(session, "AutomationId", "PowerPage", "HSBatteryGuageResetSecondaryResetBtn", 10);

        public string SmartStandbyTManualScheduleDaysSunSPEC = "Sunday";
        public string SmartStandbyTManualScheduleDaysMonSPEC = "Monday";
        public string SmartStandbyTManualScheduleDaysTueSPEC = "Tuesday";
        public string SmartStandbyTManualScheduleDaysWedSPEC = "Wednesday";
        public string SmartStandbyTManualScheduleDaysThursSPEC = "Thursday";
        public string SmartStandbyTManualScheduleDaysFriSPEC = "Friday";
        public string SmartStandbyTManualScheduleDaysSatSPEC = "Saturday";

        public WindowsElement JumpToOtherSettings => base.GetElement(session, "XPath", VantageConstContent.HSJumpToOtherSettings);
        public WindowsElement OtherSettingstoolBarCheckBox => base.GetElement(session, "XPath", VantageConstContent.HS_OtherSettingstoolBarCheckBox);
        //public WindowsElement JumpToBatterySettings => base.GetElement(session, "XPath", VantageConstContent.HSJumpToBatterySettings);
        public WindowsElement JumpToBatterySettings => FindElementByApp(session, "AutomationId", "PowerPage", "HSJumpToBatterySettings", 10);
        public WindowsElement JumpToPowerSettings => FindElementByTimes(session, "XPath", VantageConstContent.HSJumpToPowerSettings);
        public WindowsElement RapidChargeCheckBox => base.FindElementByTimes(session, "XPath", VantageConstContent.HS_RapidChargeCheckBox);
        public WindowsElement ConservationCheckBox => base.GetElement(session, "XPath", VantageConstContent.HS_ConservationCheckBox);
        public WindowsElement BatteryChargeThresholdCheckBox => base.GetElement(session, "AutomationId", "ds-power-battery-threshold_checkbox");
        public WindowsElement BatteryAirplaneCheckBox => base.GetElement(session, "AutomationId", "ds-power-battery-airplane_checkbox");
        public WindowsElement BatteryChargeThresholdEnable => base.GetElement(session, "AutomationId", "battery-threshold-popup-enable");
        public WindowsElement BatteryGuageResetPrimary => base.GetElement(session, "AutomationId", "myDevice-settings-battery-gauge-reset-stop-btn1");
        public WindowsElement BatteryGuageResetContinue => base.GetElement(session, "AutomationId", "battery-guageReset-popup-continue");
        public WindowsElement BatteryGuageResetYes => base.GetElement(session, "AutomationId", "battery-guageReset-popup-yes");
        //Easy Resume
        public WindowsElement EasyResumeTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.EasyResumeTitle"));
        public WindowsElement EasyResumeToggle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.EasyResumeToggle"));
        public WindowsElement EasyResumeDescriptionId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.EasyResumeDescriptionId"));
        public WindowsElement EasyResumeQuestionMark => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.EasyResumeQuestionMark"));
        public WindowsElement EasyResumeQuestionMarkToolTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.EasyResumeQuestionMarkToolTip"));
        //Flip To Start
        public WindowsElement FlipToStartTitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FlipToStartTitleId"));
        public WindowsElement FlipToStartDescriptionId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FlipToStartDescriptionId"));
        public WindowsElement FlipToStartToggle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FlipToStartToggle"));
        public WindowsElement FlipToStartQuestionMark => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FlipToStartQuestionMark"));
        public WindowsElement FlipToStartQuestionMarkToolTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FlipToStartQuestionMarkToolTip"));
        //Always on USB
        public WindowsElement AlwaysUSBTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AlwaysUSBTitle"));
        public WindowsElement AlwaysUSBCaptionId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AlwaysUSBCaptionId"));
        public WindowsElement AlwaysUSBToggle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AlwaysUSBToggle"));
        public WindowsElement AlwaysUSBCheckbox => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AlwaysUSBCheckbox"));
        public WindowsElement AlwaysUSBCheckboxLabel => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AlwaysUSBCheckboxLabel"));
        //Rapid Charge
        public WindowsElement RapidChargeTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.RapidChargeTitle"));
        public WindowsElement RapidChargeCaptionId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.RapidChargeCaptionId"));
        public WindowsElement RapidChargeCheckbox => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.RapidChargeCheckbox"));
        public WindowsElement ConservationModeTitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeTitle"));
        public WindowsElement ConservationModeCaptionId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeCaptionId"));
        public string ConservationModeCaptionText => GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeCaptionText");
        public string ConservationModeNoteCaptionText => GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeNoteCaptionText");
        public WindowsElement ConservationModeNoteId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeNoteId"));
        public WindowsElement ConservationModeCheckboxId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ConservationModeCheckbox"));
        public WindowsElement AirplaneModeTitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AirplaneModelTitle"));
        public WindowsElement AirplaneModeCheckboxId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AirplaneModelCheckbox"));
        public WindowsElement AutoAirplaneModeCheckboxId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.AutoAirplaneModelCheckbox"));

        //Battery Condition On ThinkPad Function
        public WindowsElement BatteryDetailButton => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.batterydetail_btn"));
        public WindowsElement BatteryConditionGreenIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionGreenIcon"));
        public WindowsElement BatteryConditionYellowIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionYellowIcon"));
        public WindowsElement BatteryConditionRedIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionRedIcon"));
        public WindowsElement BatteryConditionGoodTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionGoodTip"));
        public WindowsElement BatteryConditionFairTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionFairTip"));
        public WindowsElement BatteryConditionPoorTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionPoorTip"));
        public WindowsElement BatteryConditionMissingDriverTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionMissingDriverTip"));
        public WindowsElement BatteryConditionPermanentErrorTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionPermanentErrorTip"));
        public WindowsElement BatteryConditionHighTemperatureTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionHighTemperatureTip"));
        public WindowsElement BatteryConditionTrickleChargeTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionTrickleChargeTip"));
        public WindowsElement BatteryConditionOverheatedBatteryTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionOverheatedBatteryTip"));
        public WindowsElement BatteryConditionHWAuthenticationErrorTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionHWAuthenticationErrorTip"));
        public WindowsElement ThinkPadNoBatteryTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ThinkPadNoBatteryTip"));
        public WindowsElement ThinkPadNoBatteryQuestionMarkIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ThinkPadNoBatteryQuestionMarkIcon"));
        public WindowsElement ThinkPadNoBatteryQuestionMarkTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ThinkPadNoBatteryQuestionMarkTip"));

        //Battery Health
        public WindowsElement BatterySettingsOpenTable => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatterySettingsOpenTable"));
        public WindowsElement BatterySettingsCloseTable => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatterySettingsCloseTable"));
        public WindowsElement BatteryHealthTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryHealthTitle"));
        public WindowsElement BatteryHealthIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryHealthIcon"));
        public WindowsElement BatteryHealthDescription => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryHealthDescription"));
        public WindowsElement BatteryHealthStatus => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryHealthStatus"));
        public WindowsElement BatteryHealthStatusStars => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryHealthStatusStars"));
        public WindowsElement BatteryCapacityTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityTitle"));
        public WindowsElement BatteryCapacityQuestionMark => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityQuestionMark"));
        public WindowsElement BatteryCapacityCircle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityCircle"));
        public WindowsElement BatteryCapacityTipLine1 => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityTipLine1"));
        public WindowsElement BatteryCapacityTipLine2 => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityTipLine2"));
        public WindowsElement BatteryCapacityQuestionMarkTip => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryCapacityQuestionMarkTip"));
        public WindowsElement BatteryTemperatureTitle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryTemperatureTitle"));
        public WindowsElement BatteryTemperatureIndicatorImage => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryTemperatureIndicatorImage"));
        public WindowsElement BatteryTemperatureIndicatorText => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryTemperatureIndicatorText"));
        public WindowsElement BatteryTemperatureDescription => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryTemperatureDescription"));


        public WindowsElement BatteryConditionIconGoodBatteryId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionIconGoodBattery"));
        public WindowsElement BatteryConditionTipGoodId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionTipGood"));
        public WindowsElement BatteryGaugeSubtitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryGaugeSubtitle"));
        public WindowsElement BatteryGaugeRemaingTimeTitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryGaugeRemaingTimeTitle"));
        public WindowsElement BatteryRemainingTimeValueId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryRemainingTimeValue"));
        public WindowsElement BadBatteryRedCrossIconId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BadBatteryRedCrossIcon"));
        public WindowsElement BatteryConditionBatteryNotDetectedId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryConditionBatteryNotDetected"));
        public WindowsElement BatteryGaugeNotDetectedTitleId => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryGaugeNotDetectedTitle"));
        public WindowsElement FullACAdapterSupportIcon => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FullACAdapterSupportIcon"));
        public WindowsElement FullACAdapterSupportText => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.FullACAdapterSupportText"));

        //Battery Charge Threshold Two Battery
        public WindowsElement ThresholdSecondaryBatteryStartDropdown => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ThresholdSecondaryBatteryStartDropdown"));
        public WindowsElement ThresholdSecondaryBatteryStopDropdown => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.ThresholdSecondaryBatteryStopDropdown"));
        public WindowsElement SecondBatteryThresholdCheckbox => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SecondBatteryThresholdCheckbox"));
        public WindowsElement TaskBarBatteryLevelButtonNoPluggedin => base.GetElement(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.TaskBarBatteryLevelButtonNoPluggedin"));
        public WindowsElement TaskBarBatteryLevelButtonPluggedin => base.GetElement(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.TaskBarBatteryLevelButtonPluggedin"));
        public WindowsElement TaskBarBatteryLevelButtonFullCharge => base.GetElement(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.TaskBarBatteryLevelButtonFullCharge"));
        public WindowsElement BatteryChargeThresholdSelectedStartChargePrimary => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdSelectedStartChargePrimary"));
        public WindowsElement BatteryChargeThresholdSelectedStartChargeSecond => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.BatteryChargeThresholdSelectedStartChargeSecond"));

        //Sealed Battery Warranty

        public string SealedBatteryWarrantyName = string.Empty;

        public WindowsElement SealedBatteryWarrantyElement => base.GetElement(session, "Name", SealedBatteryWarrantyName);

        public string BatteryWarrantySettings = string.Empty;
        public WindowsElement BatteryWarrantySettingsElement => base.FindElementByTimes(session, "AutomationId", BatteryWarrantySettings);
        public WindowsElement SealedBatteryWarrantyTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.Title"));
        public WindowsElement BatteryWarrantyTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyTitle"));
        public WindowsElement BatteryWarrantyValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyValue"));
        public WindowsElement BatteryWarrantyTip => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyTip"));
        public WindowsElement ExploreMoreButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.ExploreMoreButton"));
        public WindowsElement QuestionMarklink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.QuestionMarklink"));
        public WindowsElement QuestionMarkTip => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.QuestionMarkTip"));
        public WindowsElement BatteryUpSellexpired => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryUpSellexpired"));
        public WindowsElement WarrantyDateInfo => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.WarrantyDateInfo"));
        public WindowsElement BatteryUpSellendDateText => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryUpSellendDateText"));
        public WindowsElement WarrantyDetails => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.WarrantyDetails"));
        public WindowsElement WarrantyEndDate => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.WarrantyEndDate"));
        public WindowsElement UpgradeSupportService => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.UpgradeSupportService"), 90);
        public WindowsElement LenovoPremiumService => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.LenovoPremiumService"), 90);
        public WindowsElement SealedBatterySB => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.SealedBatterySB"), 90);
        public WindowsElement SealedBattery => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.SealedBattery"), 90);
        public WindowsElement SealedBatteryWarranty => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.SealedBatteryWarranty"), 90);
        public WindowsElement LenovoWarranty => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.LenovoWarranty"), 90);
        public WindowsElement Continue => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.Continue"), 90);
        public WindowsElement BatteryWarrantyMore => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyMore"));
        public WindowsElement BatteryWarrantyLess => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyLess"));
        public WindowsElement PowerBatteryWarrantyTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.PowerBatteryWarrantyTitle"));
        public WindowsElement PowerBatteryWarrantyCaption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.PowerBatteryWarrantyCaption"));
        public WindowsElement WarrantyAndProtection => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.WarrantyAndProtection"));
        public WindowsElement SealedBatteryWarrantyNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.SealedBatteryWarrantyNote"));
        public WindowsElement BatteryWarrantyQuestinonMark => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyQuestinonMark"));
        public WindowsElement BatterySettingsWarrantyEXPLOREMOREButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatterySettingsWarrantyEXPLOREMOREButton"));
        public WindowsElement BatteryWarrantyStartDateValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyStartDateValue"));
        public WindowsElement BatteryWarrantyEndDateValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyEndDateValue"));
        public WindowsElement BatteryWarrantyDurationMonthValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyDurationMonthValue"));
        public WindowsElement BatteryWarrantyTimeRemainingValue => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyTimeRemainingValue"));
        public WindowsElement BatteryWarrantyDurationStatus => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.SealedBatteryWarranty.BatteryWarrantyDurationStatus"));


        public enum BatteryHealthToolButton
        {
            NextBtn = 12324,
            ApplayButton = 1036,
            FinishBtn = 12325,
            RestarBtn = 1049
        }

        public HSPowerSettingsPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        [DllImport("user32.dll")]
        private static extern int SetCursorPos(int x, int y);
        /// <summary>
        /// 移动鼠标到指定的坐标点
        /// </summary>
        public void MoveMouseToPoint(Point p)
        {
            SetCursorPos(p.X, p.Y);
        }
        /// <summary>
        /// 设置鼠标的移动范围
        /// </summary>
        public void SetMouseRectangle(Rectangle rectangle)
        {
            System.Windows.Forms.Cursor.Clip = rectangle;
        }
        /// <summary>
        /// 设置位置
        /// </summary>
        public void SetMouseAtScreen(int width, int height)
        {
            Point centerP = new Point(width, height);
            MoveMouseToPoint(centerP);
        }

        public ToggleState GetCheckBoxStatus(WindowsElement windowsElement)
        {
            if (windowsElement != null)
            {
                string initToggleState = windowsElement.GetAttribute("Toggle.ToggleState");
                if (initToggleState != Convert.ToInt32(ToggleState.On).ToString())
                {
                    return ToggleState.Off;
                }
                else
                {
                    return ToggleState.On;
                }
            }

            return ToggleState.Indeterminate;
        }

        public bool GotoPowerPage()
        {
            try
            {
                JumpToBatterySettings();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetBatteryHoldTitle()
        {
            try
            {
                return HSBatteryThresholdTitle.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public bool GetBatteryHoldToggle()
        {
            try
            {
                return HSThredholdCheckBoxEle != null;
            }
            catch
            {
                return false;
            }
        }

        public ToggleState GetBatteryHoldToggleState()
        {
            try
            {
                return GetCheckBoxStatus(HSThredholdCheckBoxEle);
            }
            catch
            {
                return ToggleState.Indeterminate;
            }
        }

        public bool ClickQuestionMark()
        {
            try
            {
                HSBatteryThresholdRightIcon.Click();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string GetQuestionMarkToolTip()
        {
            try
            {
                return HSBatteryThresholdToolTip.Text;
            }
            catch
            {
                return string.Empty;
            }
        }

        public int SupportDualBatteries()
        {
            try
            {
                return VantageCommonHelper.JudgeBatteryNums();
            }
            catch
            {
                return 0;
            }
        }

        public bool TurnOnBatteryChargeThreshold()
        {
            try
            {
                if (GetCheckBoxStatus(HSThredholdCheckBoxEle) == ToggleState.Off)
                {
                    HSThredholdCheckBoxEle.Click();
                    HSThredholdEnableBtnEle.Click();
                }
                if (GetCheckBoxStatus(HSThredholdCheckBoxEle) == ToggleState.On)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool FindProcessByName(string processName)
        {
            Process[] process = Process.GetProcessesByName(processName);
            if (process.Length > 0)
            {
                return true;
            }
            return false;
        }

        public bool TurnOffBatteryChargeThreshold()
        {
            try
            {
                if (GetCheckBoxStatus(HSThredholdCheckBoxEle) == ToggleState.On)
                {
                    HSThredholdCheckBoxEle.Click();
                }
                if (GetCheckBoxStatus(HSThredholdCheckBoxEle) == ToggleState.Off)
                {
                    return true;
                }
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void BatteryGaugeWhenShowStopBtn()
        {
            try
            {
                if (HSBatteryGuageResetStopBtn != null && GetElementTextName(HSBatteryGuageResetStopBtn).Equals("Stop"))
                {
                    HSBatteryGuageResetStopBtn.Click();
                    HSBatteryGuageResetStopPopYesBtn.Click();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public int GetTimerOutBatteryPercent(int waitTime)
        {
            string startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            while (true)
            {
                try
                {
                    string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    int endFlag = Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper.GetDiffTime(startTime, endTime);
                    if (endFlag > waitTime)
                    {
                        int newCurrentPercent = GetCurrentBatteryPercent();
                        return newCurrentPercent;
                    }
                }
                catch
                {
                    throw new Exception("GetTimerOutBatteryPercent is failing");
                }
            }

        }

        public static void FindElementByIdAndMouseMove(string automationId, int findTimes = 2, bool isLeftClick = true)
        {
            AutomationElement automationElement = FindElementByIdIsEnabled(automationId, findTimes);
            if (automationElement != null)
            {
                var position = automationElement.Current.BoundingRectangle;
                int x = ((int)position.Left + (int)position.Width / 2);
                int y = ((int)position.Bottom - (int)position.Height / 2);
                DoMouseMove(x, y);
            }
        }

        public Dictionary<string, WindowsElement> GetSmartStandbyWeekDays()
        {
            Dictionary<string, WindowsElement> weekends = new Dictionary<string, WindowsElement>();
            weekends.Add("sunday", SmartStandbyTManualScheduleDaysSun);
            weekends.Add("monday", SmartStandbyTManualScheduleDaysMon);
            weekends.Add("tuesday", SmartStandbyTManualScheduleDaysTue);
            weekends.Add("wednesday", SmartStandbyTManualScheduleDaysWed);
            weekends.Add("thursday", SmartStandbyTManualScheduleDaysThurs);
            weekends.Add("friday", SmartStandbyTManualScheduleDaysFri);
            weekends.Add("saturday", SmartStandbyTManualScheduleDaysSat);
            return weekends;
        }

        public string GetConservationValue()
        {
            string targetPath = @"c:\ConservationDebug.log";
            if (File.Exists(targetPath))
            {
                return ReadConservationLog(targetPath);
            }
            else
            {
                var startInfo = new ProcessStartInfo();
                startInfo.WorkingDirectory = workPath;
                startInfo.FileName = csLogPath;
                Process.Start(startInfo);
                Thread.Sleep(15000);
                CommandBase.RunCmd("taskkill /f /t /im IdeaGuiTool.exe");
                bool isrewrite = true;
                File.Copy(logPath, targetPath, isrewrite);
                return ReadConservationLog(targetPath);
            }
        }

        public string ReadConservationLog(string path)
        {
            string conservationValue = string.Empty;
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.Contains("Conservation mode threshold:"))
                        {
                            conservationValue = line;
                            break;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            conservationValue = conservationValue.Split(':')[1].Trim();
            if (conservationValue == "55%-60%")
            {
                conservationValue = "55-60%";
            }
            else if (conservationValue == "75%-80%")
            {
                conservationValue = "75-80%";
            }
            return conservationValue;
        }

        public void SetBatteryHealthValue(string Value)
        {
            string toolPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\BatteryHealthTool\");
            toolPath = toolPath + @"0006_L19C4PH0_0090_6120_" + Value + @"\LnvBFU.exe";
            string wkPath = toolPath + @"0006_L19C4PH0_0090_6120_" + Value;
            var startInfo = new ProcessStartInfo();
            startInfo.WorkingDirectory = wkPath;
            startInfo.FileName = toolPath;
            Process.Start(startInfo);
            WindowsDriver<WindowsElement> deskSession = GetControlPanelSession(true);
            Thread.Sleep(3000);
            WindowsElement nextButton1 = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.NextBtn).ToString());
            nextButton1.Click();
            Thread.Sleep(2000);
            WindowsElement nextButton2 = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.NextBtn).ToString());
            bool canClick = nextButton2.Enabled;
            while (!canClick)
            {
                canClick = nextButton2.Enabled;
            }
            Thread.Sleep(1000);
            nextButton2.Click();
            WindowsElement applayButton = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.ApplayButton).ToString());
            applayButton.Click();
            WindowsElement nextButton3 = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.NextBtn).ToString());
            nextButton3.Click();
            Thread.Sleep(1000);
            WindowsElement nextButton4 = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.NextBtn).ToString());
            nextButton4.Click();
            Thread.Sleep(1000);
            WindowsElement nextButton5 = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.NextBtn).ToString());
            nextButton5.Click();
            bool endChange = true;
            while (endChange)
            {
                WindowsElement finishButton = GetElement(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.FinishBtn).ToString());
                WindowsElement okButton = GetElement(deskSession, "Name", "OK");
                if (okButton != null)
                {
                    okButton.Click();
                }
                if (finishButton != null)
                {
                    endChange = false;
                    finishButton.Click();
                }
            }
            Thread.Sleep(2000);
            WindowsElement endButton = FindElementByTimes(deskSession, "AutomationId", Convert.ToInt32(BatteryHealthToolButton.RestarBtn).ToString());
            if (endButton != null)
            {
                CommandBase.RunCmd("taskkill /f /t /im LnvBFU.exe");
            }
        }

        public void HSWaitTwoBatteryLevel(string batteryType, int batteryLevel)
        {
            int batteryIndex = 0;
            int times = 5;
            if (!(batteryType.ToLower() == "primary"))
            {
                batteryIndex = 1;
            }
            int currentPercent = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(batteryIndex);
            int oldBatteryValue = currentPercent;
            while (currentPercent < batteryLevel)
            {
                if (times == 0)
                {
                    break;
                }
                Thread.Sleep(50000);
                currentPercent = VantageCommonHelper.GetTowBatteryComputerBatteryLevel(batteryIndex);
                if (currentPercent != oldBatteryValue)
                {
                    Debug.WriteLine("The old value is " + oldBatteryValue + " new value is " + currentPercent);
                    oldBatteryValue = currentPercent;
                }
                else if (currentPercent == oldBatteryValue)
                {
                    times--;
                }
            }
        }
    }
}
