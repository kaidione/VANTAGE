using LenovoVantageTest.Pages.HardwareSettingsPages;
using Microsoft.Win32;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Management;
using System.Windows.Automation;
using static LenovoVantageTest.Helper.VantageCommonHelper;

namespace LenovoVantageTest.Pages
{
    public class IntelligentCoolingPages : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        public IntelligentCoolingPages(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        //Menu Common
        public WindowsElement MenuDevice => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']");
        public WindowsElement MyDeviceSettings => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-dropdown-menu-device-1']");
        public WindowsElement MyDeviceSettingsPowerTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-power']");
        public WindowsElement MyDeviceSettingsAudioTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-header-menu-audio']");
        public WindowsElement HSJumpToSmartSettings => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='jumptoSetting-smartSettings']");


        //ITS Ideapad DYTC6
        public WindowsElement IntelligentCoolingBatterySavingMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='quiteBatterySaving']");
        public WindowsElement IntelligentCoolingIntelligentCoolingMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICQuiteCool']");
        public WindowsElement IntelligentCoolingExtremePerformanceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICPerformance']");
        public WindowsElement CreatorSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='creatorSettings-panel-expansion-panel-header-customize']");
        public WindowsElement IntelligentPerformanceTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-powerSmartSettings-title']");
        public WindowsElement CollapseTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='creatorSettings-collapse-link']");
        public WindowsElement intelligentDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-powerSmartSettings-caption']");
        public WindowsElement IntelligentCoolingSelectModeDesc => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='IntelligentCooling-selectedModeText']");
        public WindowsElement IntelligentCoolingAutoTransition => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='IntelligentCooling-5.0-AutoTransition_checkbox']");
        public WindowsElement IntelligentCoolingAutoTransitionDesc1 => base.FindElementByTimes(session, "XPath", "//*[AutomationId='IntelligentCooling-5.0-AutoTransition_checkbox-label1']");
        public WindowsElement IntelligentCoolingAutoTransitionDesc2 => base.FindElementByTimes(session, "XPath", "//*[AutomationId='IntelligentCooling-5.0-AutoTransition_checkbox-label2']");
        public WindowsElement IntelligentCoolingAutoTransitionMoreLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-autoTransition-more']");
        public WindowsElement IntelligentCoolingAutoTransitionLessLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-autoTransition-less']");
        public WindowsElement IntelligentCoolingAutoTransitionReadMoreDescA => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ITSAutoTransitionReadMore-PartA']");
        public WindowsElement IntelligentCoolingAutoTransitionReadMoreDescB => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ITSAutoTransitionReadMore-PartB']");
        public WindowsElement IntelligentCoolingAutoTransitionReadMoreDescC => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ITSAutoTransitionReadMore-PartC']");

        //ITS Common
        public WindowsElement PowerSmartSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-powerSmartSettings-collapse-card-title']");
        public WindowsElement IntelligentCoolingTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-powerSmartSettings-title']");
        public WindowsElement IntelligentCoolingTitleThink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='powersmartsettings-intelligentCooling-title']");
        public WindowsElement IntelligentCoolingDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-powerSmartSettings-caption']");
        public WindowsElement IntelligentCoolingPerformanceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICPerformance']");
        public WindowsElement IntelligentCoolingMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICQuiteCool']");
        public WindowsElement ExtremePerformanceMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICPerformance']");
        public WindowsElement BatterySavingMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='quiteBatterySaving']");
        public WindowsElement IntelligentCoolingCoolQuietMode => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='radioICQuiteCool']");
        public WindowsElement IntelligentCoolingToggle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='ds-power-powerSmartSettings_checkbox']");
        public List<WindowsElement> IntelligentCoolingToggleGroup => new List<WindowsElement>(base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='intelligent-cooling-radio-group']"));
        public WindowsElement IntelligentCoolingCollapseExpand => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-powerSmartSettings-collapse-link']");
        //ITS Thinkpad DYTC6.0
        public WindowsElement IntelligentCoolingThinkDYTC6CS20Desc01 => base.GetElement(session, "XPath", "//*[@AutomationId='powersmartsettings-dytc6-dec1']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20Desc02 => base.GetElement(session, "XPath", "//*[@AutomationId='powersmartsettings-dytc6-dec2']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20Desc03 => base.GetElement(session, "XPath", "//*[@AutomationId='powersmartsettings-dytc6-dec3']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20Desc03_1 => base.GetElement(session, "XPath", "//*[@AutomationId='powersmartsettings-dytc6-dec3_1']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20QuietModeDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode1']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20QuietModeDescLE => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode1']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20BalancedModeDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode2']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20PerformanceModeDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode3']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20UltraPerformanceModeDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode4']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20MoreLink => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-more-info']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20LessLink => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-less-info']");
        public WindowsElement IntelligentCoolingThinkDYTC6CS20Images => base.GetElement(session, "XPath", "//*[@AutomationId='powersmartsettings-dytc6-toolbar']");
        public WindowsElement VangtageMax => base.GetElement(session, "XPath", "//*[@AutomationId='Maximize']");
        public WindowsElement ToolBarITSMode => base.GetElement(session, "XPath", "//*[@AutomationId='1070']");
        public WindowsElement DolbyCheckBox => base.GetElement(session, "XPath", "//*[@AutomationId='audio-automatic-dolby_checkbox']");
        public WindowsElement LearnMore => base.GetElement(session, "XPath", "//*[@AutomationId='VerbText']");
        public WindowsElement IntelligentCoolingCaption => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.IntelligentCoolingCaption"));
        public WindowsElement ReadMore => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-read-more']");
        public WindowsElement popupwindowtitle => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings-intelligentCooling-intelligentCoolingModesModal-title']");
        public WindowsElement popupwindowclosebutton => base.GetElement(session, "XPath", "//*[@AutomationId='intelligentCoolingModesModal-close-button']");
        public WindowsElement xicon => base.GetElement(session, "XPath", "//*[@AutomationId='intelligentCoolingModesModal-close-icon']");
        public WindowsElement IntelligentCoolingDYTC5Title => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings.intelligentCooling.title']");
        public WindowsElement IntelligentCoolingDYTC5QuietDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreMode1']");
        public WindowsElement IntelligentCoolingDYTC5BalancedDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreMode2']");
        public WindowsElement IntelligentCoolingDYTC5Desc => base.GetElement(session, "XPath", "//*[@AutomationId='powerSmartSettings-dytc5-description']");
        public WindowsElement IntelligentCoolingDYTC5PerformanceDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreMode3']");
        public WindowsElement IntelligentCoolingDYTC5PopupIcon01 => base.GetElement(session, "XPath", "//*[@AutomationId='intelligent-cooling-modes-no-1']");
        public WindowsElement IntelligentCoolingDYTC5PopupDesc01 => base.GetElement(session, "XPath", "//*[@AutomationId='modal-intelligent-cooling-modes-list1']");
        public WindowsElement IntelligentCoolingDYTC5PopupImg01 => base.GetElement(session, "XPath", "//*[@AutomationId='toolbar']");
        public WindowsElement IntelligentCoolingDYTC5PopupIcon02 => base.GetElement(session, "XPath", "//*[@AutomationId='intelligent-cooling-modes-no-2']");
        public WindowsElement IntelligentCoolingDYTC5PopupDesc02 => base.GetElement(session, "XPath", "//*[@AutomationId='modal-intelligent-cooling-modes-list2']");
        public WindowsElement IntelligentCoolingDYTC5PopupImg02 => base.GetElement(session, "XPath", "//*[@AutomationId='battery-guage']");
        public WindowsElement IntelligentCoolingDYTC6QuietModeDes => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode1']");
        public WindowsElement IntelligentCoolingDYTC6BalancedModeDes => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode2']");
        public WindowsElement IntelligentCoolingDYTC6PerformanceModeDes => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode3']");
        public WindowsElement IntelligentCoolingDYTC6MWSQuiteDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode1']");
        public WindowsElement IntelligentCoolingDYTC6MWSBalancedDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode2']");
        public WindowsElement IntelligentCoolingDYTC6MWSPerformanceDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode3']");
        public WindowsElement IntelligentCoolingDYTC6MWSUltraperformanceDesc => base.GetElement(session, "XPath", "//*[@AutomationId='readMoreDytc6Mode4']");
        public WindowsElement IntelligentCoolingDYTC3CQLAPSHint => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='power.powerSmartSettings.intelligentCooling.apsHint']");
        public WindowsElement IntelligentCoolingDYTC3CQLOptimizeDesc => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='power.powerSmartSettings.intelligentCooling.optimize']");
        public WindowsElement IntelligentCooling5GpuOcCheckBox => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gpu-overclocking-checkbox_checkbox']");
        public WindowsElement IntelligentCooling5GpuOcCheckBoxDesc1 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='descriptionOne']");
        public WindowsElement IntelligentCooling5GpuOcCheckBoxDesc2 => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='descriptionTwo']");

        public static string IntelligentCooling6Title = "//*[@AutomationId='powersmartsettings-intelligentCooling-title']";
        public static string IntelligentCoolingCaptionLegacyTIOText = "Intelligent Cooling automatically balances thermal performance to adjust to your needs. The Intelligent Cooling feature adjusts performance settings to provide a cooler surface for your comfort, when the notebook is being held. When the device is on a desktop surface, this feature optimizes performance.";
        public static string IntelligentCoolingCaptionText = "When on,this feature dynamically adjusts thermal settings to your needs.It adjusts settings to keep the device cool and quiet while being held or idle. While the device is on a stable surface, it optimizes the performance. When off, you can manually set the thermal priority.";
        public static string IntelligentCoolingToggleOff = "//*[@AutomationId='ds-power-powerSmartSettings_off_sizeStopProp']";
        public static string Intelligentcoolingwords = "//*[@Name='This mode enables the best experience with fan speed and system performance balanced. For example, when in gaming, it optimizes the performance. While in the office, it reduces the noise.']";
        public static string Batterysavingwords = "//*[@Name='This mode enables the maximum battery life by automatically adjusting the brightness, changing the power settings, disabling features on advanced image processing, etc.']";
        public static string Extremeperformanceword = "//*[@Name='This mode enables the maximum system performance. In this mode, the fast fan speed might cause big noise.']";
        public static string Intelligentcoolingwordstop = "//*[@Name='This feature enables you to adjust your fan speed, maximize the system performance, or extend your battery life if needed. It has three modes below. You also can switch the modes using hotkeys (Fn+Q) or from Lenovo Vantage Toolbar.']";
        public static string IntelligentCoolingToggleOn = "//*[@AutomationId='ds-power-powerSmartSettings_on_sizeStopProp']";

        public static string IntelligentCoolingPerformanceTitle = "//*[@AutomationId='myDevice-settings-power-intelligent-cooling-performance-label']";
        public static string IntelligentCoolingCoolQuietTitle = "//*[@AutomationId='myDevice-settings-power-intelligent-cooling-LE-CoolingDown2x-label']";
        public static string IntelligentCoolingbatterysaving = "//*[@AutomationId='quiteBatterySaving-label']";
        public static string IntelligentCoolingDec1 = "//*[@AutomationId='powersmartsettings-dytc6-dec1']";
        public static string IntelligentCoolingDec1Text = "Intelligent Cooling adjusts fan speed, maximum performance, and manages your battery life.";
        public static string IntelligentCoolingDec2 = "//*[@AutomationId='powersmartsettings-dytc6-dec2']";
        public static string IntelligentCoolingDec2Text = "The feature has modes listed below and now is adjusted by Windows performance power slider. You can access it by clicking the battery icon in the Windows system tray.";
        public static string IntelligentCoolingDec3Enable = "//*[@AutomationId='powersmartsettings-dytc6-dec3_1']";
        public static string IntelligentCoolingDec3Disable = "//*[@AutomationId='powersmartsettings-dytc6-dec3']";
        public static string IntelligentCoolingDec3EnableText = "Some of the modes can automatically adjust across a wider range of performance based on your activity. To disable automatic mode, press Fn+ T.";
        public static string IntelligentCoolingDec3DisableText = "Some of the modes can automatically adjust across a wider range of performance based on your activity. To enable automatic mode, press Fn+ T.";
        public static string IntelligentCoolingMoreDec1 = "//*[@AutomationId='readMoreDytc6Mode1']";
        public static string IntelligentCoolingMoreDec1DisableText = "Quiet mode: The slider is on the left. Fan speed and performance are lowered for a cooler, quieter computer and best battery life.";
        public static string IntelligentCoolingMoreDec1EnableText = "Auto Battery mode: The slider is on the left. The mode is dynamically switched to Quiet mode or Battery mode for the best DC mode experience.";
        public static string IntelligentCoolingMoreDec2 = "//*[@AutomationId='readMoreDytc6Mode2']";
        public static string IntelligentCoolingMoreDec2DisableText = "Balanced mode: The slider is in the center or center right. Fan speed and performance are dynamically balanced for the best experience.";
        public static string IntelligentCoolingMoreDec2EnableText = "Auto Performance mode: The slider is in the center or center right. The mode is dynamically switched to Quiet mode, Balanced mode or Performance mode for the best AC mode experience.";
        public static string IntelligentCoolingMoreDec3 = "//*[@AutomationId='readMoreDytc6Mode3']";
        public static string IntelligentCoolingMoreDec3DisableText = "Performance mode: The slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        public static string IntelligentCoolingMoreDec3EnableText = "Performance mode: The slider is far right. Fan speed and permissible surface temperature are higher for maximum performance.";
        public static string IntelligentCoolingMoreLink = "//*[@AutomationId='powerSmartSettings-intelligentCooling-more-info']";
        public static string IntelligentCoolingLessLink = "//*[@AutomationId='powerSmartSettings-intelligentCooling-less-info']";
        public static string IntelligentCoolingImage = "//*[@AutomationId='powersmartsettings-dytc6-toolbar']";

        //ITS Thinkpad DYTC5.0 UI Desc
        public static string MoreInfoLink = "//*[@AutomationId='powerSmartSettings-intelligentCooling-more-info']";
        public static string ReadmoreLink = "//*[@AutomationId='powerSmartSettings-intelligentCooling-read-more']";
        public static string IntelligentCoolingtTitle5 = "//*[@AutomationId='powerSmartSettings.intelligentCooling.title']";
        public static string IntelligentCoolingDesc = "//*[@AutomationId='powerSmartSettings.description']";
        public static string IntelligentCoolingModeDesc = "//*[@AutomationId='readMoreDiv']";
        public static string QuietmodeName = "//*[@AutomationId='Quiet mode']";
        public static string QuietmodeDesc = "//*[@AutomationId='readMoreMode1']";
        public static string BalancedmodeName = "//*[@AutomationId='Balanced mode']";
        public static string BalancedmodeDesc = "//*[@AutomationId='readMoreMode2']";
        public static string PerformancemodeName = "//*[@AutomationId='Performance mode']";
        public static string PerformancemodeDesc = "//*[@AutomationId='readMoreMode3']";

        //ITS Thinkpad DYTC5.0 Popup Window
        public static string PopupWindowCloseButton = "//*[@AutomationId='intelligentCoolingModesModal-close-button']";
        public static string PopupWindowXiconButton = "//*[@AutomationId='intelligentCoolingModesModal-close-icon']";
        public static string PopupWindowTitle = "//*[@AutomationId='powerSmartSettings-intelligentCooling-intelligentCoolingModesModal-title']";
        public static string PopupWindowSecIcon01 = "//*[@AutomationId='intelligent-cooling-modes-no-1']";
        public static string PopupWindowSecDesc01 = "//*[@AutomationId='modal-intelligent-cooling-modes-list1']";
        public static string PopupWindowSecImg01 = "//*[@AutomationId='toolbar']";
        public static string PopupWindowSecIcon02 = "//*[@AutomationId='intelligent-cooling-modes-no-2']";
        public static string PopupWindowSecDesc02 = "//*[@AutomationId='modal-intelligent-cooling-modes-list2']";
        public static string PopupWindowSecImg02 = "//*[@AutomationId='battery-guage']";
        public static string HomePageMyDeviceSettings = "//*[@AutomationId='menu-main-nav-lnk-dropdown-toggle-device']";

        public string _ITSRegistryValuePathsy = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION";

        //Battery Settings
        public WindowsElement batterySettings_Title => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-batterySettings-collapse-card-title']");

        public string getInfoFromLog()
        {
            string data = System.Convert.ToString(long.Parse(GetDataCollectionValue()), 2);
            if (data.Length < 64)
            {
                int m = 64 - data.Length;
                for (int i = 0; i < m; i++)
                {
                    data = data.Insert(0, "0");
                    if (data.Length == 64)
                    {
                        break;
                    }
                }
            }
            string _curva = string.Empty;
            string _lastva = string.Empty;
            string _temp = string.Empty;
            string _lastmode = data.Substring(data.Length - 30);
            string _currentmode = data.Substring(4, 30);
            string _switchtype = data.Substring(3, 1);

            string _lastmodeb0 = _lastmode.Substring(_lastmode.Length - 1);
            string _lastmodeb2 = _lastmode.Substring(_lastmode.Length - 3).Substring(0, 1);
            string _lastmodeb3 = _lastmode.Substring(_lastmode.Length - 4).Substring(0, 1);
            string _lastmodeb4 = _lastmode.Substring(_lastmode.Length - 5).Substring(0, 1);
            string _lastmodeb5 = _lastmode.Substring(_lastmode.Length - 6).Substring(0, 1);
            string _lastmodeb6 = _lastmode.Substring(_lastmode.Length - 7).Substring(0, 1);
            string _lastmodeb7 = _lastmode.Substring(_lastmode.Length - 8).Substring(0, 1);

            string _currentmodeb0 = _currentmode.Substring(_currentmode.Length - 1);
            string _currentmodeb2 = _currentmode.Substring(_currentmode.Length - 3).Substring(0, 1);
            string _currentmodeb3 = _currentmode.Substring(_currentmode.Length - 4).Substring(0, 1);
            string _currentmodeb4 = _currentmode.Substring(_currentmode.Length - 5).Substring(0, 1);
            string _currentmodeb5 = _currentmode.Substring(_currentmode.Length - 6).Substring(0, 1);
            string _currentmodeb6 = _currentmode.Substring(_currentmode.Length - 7).Substring(0, 1);
            string _currentmodeb7 = _currentmode.Substring(_currentmode.Length - 8).Substring(0, 1);

            if (_currentmodeb0 == "1") { _curva += "STD-ISTD"; }
            if (_currentmodeb2 == "1") { _curva += "EPM-EP"; }
            if (_currentmodeb3 == "1") { _curva += "BSM-BS"; }
            if (_currentmodeb4 == "1") { _curva += "APM-IAP"; }
            if (_currentmodeb5 == "1") { _curva += "AQM-IAQ"; }
            if (_currentmodeb6 == "1") { _curva += "MYPAND-PAD"; }
            if (_currentmodeb7 == "1") { _curva += "MYTENT-TENT"; }

            if (_lastmodeb0 == "1") { _lastva += "STD-ISTD"; }
            if (_lastmodeb2 == "1") { _lastva += "EPM-EP"; }
            if (_lastmodeb3 == "1") { _lastva += "BSM-BS"; }
            if (_lastmodeb4 == "1") { _lastva += "APM-IAP"; }
            if (_lastmodeb5 == "1") { _lastva += "AQM-IAQ"; }
            if (_lastmodeb6 == "1") { _lastva += "MYPAND-PAD"; }
            if (_lastmodeb7 == "1") { _lastva += "MYTENT-TENT"; }

            if (_switchtype == "1")
            {
                _temp = _curva + "," + _lastva + "," + "MMC-FNQ-TRAY" + "," + data;
            }
            else
            {
                _temp = _curva + "," + _lastva + "," + "AUTO" + "," + data;

            }
            return _temp;
        }

        public Dictionary<string, string> IntellgentCoolingStateElement = new Dictionary<string, string> {
            {"Extreme performance", "radioICPerformance"},
            {"Intelligent cooling", "radioICQuiteCool"},
            {"Battery saving", "quiteBatterySaving"}
        };

        public Dictionary<string, int> IntellgentCoolingStateInToolBar = new Dictionary<string, int> {
            {"Extreme performance", 1},
            {"Intelligent cooling", 2},
            {"Battery saving", 3}
        };


        public string GetDataCollectionValue()
        {
            string value = string.Empty;
            value = GetValueFromRegedit("Data", _ITSRegistryValuePathsy);
            return value;
        }

        public bool SelectIntelligentCoolingModeOnInToolbar(string intelligentCoolingMode)
        {
            AutomationElement itsModeInToolbar = FindElementByIdIsEnabled(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString());
            string itsModeToolbarName = itsModeInToolbar.Current.Name;
            itsModeToolbarName = itsModeToolbarName.Substring(0, itsModeToolbarName.Length - 9);
            if (itsModeToolbarName.Contains(intelligentCoolingMode))
            {
                return true;
            }
            int toolbarCurrentValue = 0;
            IntellgentCoolingStateInToolBar.TryGetValue(itsModeToolbarName, out toolbarCurrentValue);
            int targetValue;
            IntellgentCoolingStateInToolBar.TryGetValue(intelligentCoolingMode, out targetValue);
            if (toolbarCurrentValue > targetValue)
            {
                targetValue = targetValue + 3;
            }
            int times = targetValue - toolbarCurrentValue;
            for (int i = 0; i < times; i++)
            {
                ClickSystemControl(itsModeInToolbar);
            }
            itsModeInToolbar = FindElementByIdIsEnabled(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ITSMode).ToString());
            if (itsModeInToolbar.Current.Name.Contains(intelligentCoolingMode))
            {
                return true;
            }
            return false;
        }

        private static void SetValueFromRegedit(string names, string regeditPath, int Value)
        {

            RegistryKey cv = OpenKey(regeditPath);
            if (cv != null)
            {
                try
                {
                    cv.SetValue(names, Value, RegistryValueKind.DWord);
                }
                catch
                {
                    throw new ValidationException("Key:" + names + " not found");
                }
            }
        }

        public static void EnableAMT(string names, string regeditPath, int Value = 2)
        {
            SetValueFromRegedit(names, regeditPath, Value);
        }

        public static void DisableAMT(string names, string regeditPath, int Value = 1)
        {
            SetValueFromRegedit(names, regeditPath, Value);
        }

        public static int GetNonGamingMachineValue(string getMethod = "GetNonGamingProductInfo")
        {
            string thermalmode = string.Empty;
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\WMI",
                    @"LENOVO_NON_GAMING_DATA.InstanceName='ACPI\PNP0C14\GMZN_0'",
                    null);
                ManagementBaseObject outsfmParams = classInstance.InvokeMethod(getMethod, null, null);
                thermalmode = outsfmParams["Data"].ToString();
                Console.WriteLine("WMI output value" + getMethod + " Info:" + thermalmode + ";" + outsfmParams["Data"]);
                return Convert.ToInt32(thermalmode);
            }
            catch (ManagementException err)
            {
                Console.WriteLine("Error: GetMachineThermalModeValue(),WMI Info:" + err.Message);
                return 99;
            }
        }

        public static int GetITSMachineSupportGPUOC(string getMethod = "IsSupportGpuOc")
        {
            string thermalmode = string.Empty;
            try
            {
                ManagementObject classInstance = new ManagementObject("root\\WMI",
                    @"LENOVO_GAMEZONE_DATA.InstanceName='ACPI\PNP0C14\GMZN_0'",
                    null);
                ManagementBaseObject outsfmParams = classInstance.InvokeMethod(getMethod, null, null);
                thermalmode = outsfmParams["Data"].ToString();
                Console.WriteLine("WMI output value" + getMethod + " Info:" + thermalmode + ";" + outsfmParams["Data"]);
                return Convert.ToInt32(thermalmode);
            }
            catch (ManagementException err)
            {
                Console.WriteLine("Error: GetMachineThermalModeValue(),WMI Info:" + err.Message);
                return 99;
            }
        }
    }
}
