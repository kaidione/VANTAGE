using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;

namespace LenovoVantageTest.Steps.UWP.IntelligentCooling
{
    public class IntelligentCoolingBaseHelper
    {
        private IntelligentCoolingPages intelligentcoolingPages;
        private string itsRegeditPathJP = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC";
        private string itsCQLRegeditPathJP = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC\\CQL";   //Capability 2 
        private string itsMMCRegeditPathJP = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\IC\\MMC";
        private string legacyRegeditPath = "SYSTEM\\CurrentControlSet\\Services\\IBMPMSVC\\IC";
        private string itsRegeditPathCN = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC";
        private string itsMMCRegeditPathCN = @"SYSTEM\CurrentControlSet\Services\LITSSVC\LNBITS\IC\MMC";
        private string itsAUTODETECTRegeditPathCN = @"SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\AUTODETECT";// Capability bit1  1 selected  0 not select 
        private string itsDataCollectionRegeditPathCN = "SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION";
        private string itsServiceName = "LITSSVC";
        private string imcServiceName = "ImControllerService";
        private string itsPluginPathJP = @"C:\ProgramData\Lenovo\ImController\Plugins\ThinkSmartSensePlugin";
        private string itsPluginPathCN = @"C:\ProgramData\Lenovo\ImController\Plugins\IdeaNotebookPlugin";
        private string itsBackPluginPath = @"C:\IntelligentCooling";
        public string _eventLogFile = @"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx";
        private List<string> _eventLogxml = new List<string>();   //Xml 全部信息
        private List<string> _eventLogtime = new List<string>();   //time 全部信息

        private List<string> _startLogxml = new List<string>();   //Xml 第一次采集信息
        private List<string> _secondLogxml = new List<string>();   //Xml 第二次采集信息
        private List<string> _endLogxml = new List<string>();   //Xml 最后一次采集信息

        private string _startTime = string.Empty;  //开始时间   第一次切换时间
        private string _secondTime = string.Empty;  //开始时间  第二次切换时间
        private string _endTime = string.Empty;   //结束时间    最后一次切换时间
        private int _sleepAuto = 0;   //记录等待时长

        private static string _currentmode = string.Empty;
        private static string _currentfunction = string.Empty;
        private static string _mode = string.Empty;

        //ITS DeviceId
        private string thinkDeviceID = "ACPI\\LEN0100";
        private string ideaITS3DeviceID = "ACPI\\LIC0001";
        private string ideaITS4DeviceID = "ACPI\\IDEA2004";
        private string ideaITS5DeviceID = "ACPI\\IDEA2008";

        private string _exception = string.Empty;


        public enum IntelligentCoolingToggle
        {
            ON,
            OFF,
            Unknown
        }
        public enum IntelligentCoolingMode
        {
            IntelligentCooling,
            ExtremePerformance,
            Performance,
            BatterySaving,
            CoolQuiet,
            AutoPerformance,
            AutoQuiet,
            Unknown
        }
        public enum IntelligentCoolingRadioButtonCheckBox
        {
            Selected,
            NotSelected,
            Unknown
        }
        public enum IntelligentCooingType
        {
            Toggle,
            CheckBox,
            RadioButton,
            Unknown
        }
        #region get Reset Execution Mark

        public static class IntelligentCoolingResetExecution
        {
            public static bool isSupport { get; set; }
            public static string tips { get; set; }

        }
        #endregion

        #region  CN ITS Driver Registry Value 

        // AutomaticModeSetting   1:off   2:on 
        // CurrentSetting  1:quiet  3:performance
        // eg: 2,0 >> on   1,1 >> quiet   1,3 >> performance

        public string GetIntelligentCoolingModeValueCN()
        {
            string modeValue = GetLocalMachineRegeditValue("CurrentSetting", itsMMCRegeditPathCN);
            return modeValue;
        }
        public string GetIntelligentCoolingToggleValueCN()
        {
            string toggleValue = GetLocalMachineRegeditValue("AutomaticModeSetting", itsMMCRegeditPathCN);
            return toggleValue;
        }

        public IntelligentCoolingRadioButtonCheckBox GetIntelligentCoolingAutoTransitionValueCN()
        {
            string autoValue = GetLocalMachineRegeditValue("Capability", itsAUTODETECTRegeditPathCN);
            autoValue = FillNumberToSpecifiedLength(autoValue, 4);
            autoValue = autoValue.Substring(autoValue.Length - 2).Substring(0, 1);
            if (autoValue == "0")
            {
                return IntelligentCoolingRadioButtonCheckBox.NotSelected;
            }
            else if (autoValue == "1")
            {
                return IntelligentCoolingRadioButtonCheckBox.Selected;
            }
            return IntelligentCoolingRadioButtonCheckBox.Unknown;
        }

        /// <summary>Get  currentchange  / data / lastchange  value</summary>
        /// <returns></returns>
        public string GetDataCollectionValue()
        {
            string _curChange = GetLocalMachineRegeditValue("CurrentChange", itsDataCollectionRegeditPathCN);
            string _data = GetLocalMachineRegeditValue("Data", itsDataCollectionRegeditPathCN);
            string _lastChange = GetLocalMachineRegeditValue("LastChange", itsDataCollectionRegeditPathCN);
            return _curChange + "," + _data + "," + _lastChange;
        }

        #endregion

        #region Get Toggle Mode Checkbox RadioButton Status

        public IntelligentCoolingMode GetIntelligentCoolingModeStatusCN(int dytc = 4)
        {
            string modeState = GetIntelligentCoolingModeValueCN();
            string toggleStatus = GetIntelligentCoolingToggleValueCN();
            WriteLog("GetIntelligentCoolingToggleStatusCN  Note: toggleStatus >> " + toggleStatus + " modeStatus >> " + modeState + " dytc >> " + dytc);
            if (modeState == "3" && toggleStatus == "1" && dytc == 4)
            {
                return IntelligentCoolingMode.Performance;
            }
            else if (modeState == "3" && toggleStatus == "1" && dytc >= 5)
            {
                return IntelligentCoolingMode.ExtremePerformance;
            }
            else if (modeState == "1" && toggleStatus == "1" && dytc == 4)
            {
                return IntelligentCoolingMode.CoolQuiet;
            }
            else if (modeState == "1" && toggleStatus == "1" && dytc >= 5)
            {
                return IntelligentCoolingMode.BatterySaving;
            }
            else if (modeState == "0" && toggleStatus == "2" && dytc >= 5)
            {
                return IntelligentCoolingMode.IntelligentCooling;
            }
            return IntelligentCoolingMode.Unknown;
        }
        public IntelligentCoolingToggle GetIntelligentCoolingToggleStatusCN()
        {
            string modeState = GetIntelligentCoolingModeValueCN();
            string toggleStatus = GetIntelligentCoolingToggleValueCN();
            WriteLog("GetIntelligentCoolingToggleStatusCN  Note: toggleStatus >> " + toggleStatus + " modeStatus >> " + modeState);
            if (modeState == "0" && toggleStatus == "2")
            {
                return IntelligentCoolingToggle.ON;
            }
            return IntelligentCoolingToggle.OFF;
        }
        public string GetIntelligentCoolingElementCurrentStatus(WindowsElement element, IntelligentCooingType type = IntelligentCooingType.Toggle)
        {
            string value = GetAttributesByPageSource(element, "Toggle.ToggleState");
            if (type == IntelligentCooingType.Toggle)
            {
                switch (value)
                {
                    case "1":
                        return IntelligentCoolingToggle.ON.ToString();
                    case "0":
                        return IntelligentCoolingToggle.OFF.ToString();
                    default:
                        break;
                }
            }
            else if (type == IntelligentCooingType.CheckBox || type == IntelligentCooingType.RadioButton)
            {
                switch (value)
                {
                    case "1":
                        return IntelligentCoolingRadioButtonCheckBox.Selected.ToString();
                    case "0":
                        return IntelligentCoolingRadioButtonCheckBox.NotSelected.ToString();
                    default:
                        break;
                }
            }
            return IntelligentCoolingToggle.Unknown.ToString();
        }

        public IntelligentCoolingMode GetIntelligentCoolingModeStatusJP(int dytc = 4)
        {
            string modeState = GetIntelligentCoolingModeValueJP();
            if (modeState == "1" && dytc == 4)
            {
                return IntelligentCoolingMode.CoolQuiet;
            }
            else if (modeState == "3" && dytc == 4)
            {
                return IntelligentCoolingMode.Performance;
            }
            return IntelligentCoolingMode.Unknown;
        }

        public IntelligentCoolingToggle GetIntelligentCoolingToggleStatusJP(int dytc = 4)
        {
            string toggleStatus = GetIntelligentCoolingToggleValueJP();
            if (toggleStatus == "0" && dytc == 4)
            {
                return IntelligentCoolingToggle.OFF;
            }
            else if (toggleStatus == "1" && dytc == 4)
            {
                return IntelligentCoolingToggle.ON;
            }
            return IntelligentCoolingToggle.Unknown;
        }

        #endregion

        #region JP ITS Driver Registry Value

        /// <summary>CurrentSetting  3：performance   1: quiet </summary>
        public string GetIntelligentCoolingModeValueJP()
        {
            string modeValue = GetLocalMachineRegeditValue("CurrentSetting", itsMMCRegeditPathJP);
            return modeValue;
        }

        /// <summary>CurrentSetting   0>>off   1>>on </summary>
        public string GetIntelligentCoolingToggleValueJP()
        {
            string toggleValue = GetLocalMachineRegeditValue("CurrentSetting", itsCQLRegeditPathJP);
            return toggleValue;
        }

        public bool GetMachineSupportIntelligentCoolingCQL()
        {
            string cqlValue = GetLocalMachineRegeditValue("Capability", itsCQLRegeditPathJP);
            if (cqlValue == "2")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Verify Mode Toggle CN

        public bool VerifyCurrentModeIsPerformanceModeCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingPerformanceMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusCN(4) == IntelligentCoolingMode.Performance && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsPerformanceModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyCurrentModeIsIntelligentCoolingModeCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusCN(5) == IntelligentCoolingMode.IntelligentCooling && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsPerformanceModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyCurrentModeIsExtremePerformanceModeCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusCN(5) == IntelligentCoolingMode.ExtremePerformance && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsPerformanceModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyCurrentModeIsBatterySavingModeCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingBatterySavingMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusCN(5) == IntelligentCoolingMode.BatterySaving && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsPerformanceModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyCurrentModeIsCoolQuietModeCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingCoolQuietMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusCN(4) == IntelligentCoolingMode.CoolQuiet && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsCoolQuietModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyToggleStatusIsOnCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingToggle, IntelligentCooingType.Toggle);
                if (GetIntelligentCoolingToggleStatusCN() == IntelligentCoolingToggle.ON && status == IntelligentCoolingToggle.ON.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsCoolQuietModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyToggleStatusIsOffCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingToggle, IntelligentCooingType.Toggle);
                if (GetIntelligentCoolingToggleStatusCN() == IntelligentCoolingToggle.OFF && status == IntelligentCoolingToggle.OFF.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsCoolQuietModeCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyAutoTransitionIsSelectedCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingAutoTransition, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingAutoTransitionValueCN() == IntelligentCoolingRadioButtonCheckBox.Selected && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note:  VerifyAutoTransitionIsSelectedCN " + ex.ToString());
                return false;
            }
        }
        public bool VerifyAutoTransitionIsNotSelectedCN(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingAutoTransition, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingAutoTransitionValueCN() == IntelligentCoolingRadioButtonCheckBox.NotSelected && status == IntelligentCoolingRadioButtonCheckBox.NotSelected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note:  VerifyAutoTransitionIsNotSelectedCN " + ex.ToString());
                return false;
            }
        }

        #endregion

        #region Verify Mode Toggle JP

        public bool VerifyCurrentModeIsPerformanceModeJP(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingPerformanceMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusJP(4) == IntelligentCoolingMode.Performance && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsPerformanceModeJP " + ex.ToString());
                return false;
            }
        }

        public bool VerifyCurrentModeIsCoolQuietModeJP(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingCoolQuietMode, IntelligentCooingType.RadioButton);
                if (GetIntelligentCoolingModeStatusJP(4) == IntelligentCoolingMode.CoolQuiet && status == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyCurrentModeIsCoolQuietModeJP " + ex.ToString());
                return false;
            }
        }

        public bool VerifyToggleStatusIsOffJP(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingToggle, IntelligentCooingType.Toggle);
                if (GetIntelligentCoolingToggleStatusJP(4) == IntelligentCoolingToggle.OFF && status == IntelligentCoolingToggle.OFF.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyToggleStatusIsOffJP " + ex.ToString());
                return false;
            }
        }
        public bool VerifyToggleStatusIsOnJP(WindowsDriver<WindowsElement> session)
        {
            try
            {
                intelligentcoolingPages = new IntelligentCoolingPages(session);
                string status = GetIntelligentCoolingElementCurrentStatus(intelligentcoolingPages.IntelligentCoolingToggle, IntelligentCooingType.Toggle);
                if (GetIntelligentCoolingToggleStatusJP(4) == IntelligentCoolingToggle.ON && status == IntelligentCoolingToggle.ON.ToString())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                WriteLog("Note: VerifyToggleStatusIsOnJP " + ex.ToString());
                return false;
            }
        }
        #endregion

        #region select mode  switch toggle

        public void SelectExtremePerformanceMode(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode.Click();
        }

        public void SelectIntelligentCoolingMode(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode.Click();
        }

        public void SelectBatterySavingMode(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingBatterySavingMode.Click();
        }

        public void SelectPerformanceMode(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingPerformanceMode.Click();
        }

        public void SelectCoolQuietMode(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingCoolQuietMode.Click();
        }

        public void SwitchIntelligentCoolingToggle(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingToggle.Click();
        }

        public void TurnOnIntelligentCoolingToggleCN(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyToggleStatusIsOffCN(session);
            if (status)
            {
                SwitchIntelligentCoolingToggle(session);
            }
        }

        public void TurnOffIntelligentCoolingToggleCN(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyToggleStatusIsOnCN(session);
            if (status)
            {
                SwitchIntelligentCoolingToggle(session);
            }
        }

        public void TurnOnIntelligentCoolingToggleJP(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyToggleStatusIsOffJP(session);
            if (status)
            {
                SwitchIntelligentCoolingToggle(session);
            }
        }

        public void TurnOffIntelligentCoolingToggleJP(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyToggleStatusIsOnJP(session);
            if (status)
            {
                SwitchIntelligentCoolingToggle(session);
            }
        }

        public void SelectAutoTransitionCheckbox(WindowsDriver<WindowsElement> session)
        {
            intelligentcoolingPages = new IntelligentCoolingPages(session);
            intelligentcoolingPages.IntelligentCoolingAutoTransition.Click();
        }
        public void AutoTransitionIsSelected(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyAutoTransitionIsNotSelectedCN(session);
            if (status)
            {
                SelectAutoTransitionCheckbox(session);
            }
        }

        public void AutoTransitionIsNotSelected(WindowsDriver<WindowsElement> session)
        {
            bool status = VerifyAutoTransitionIsSelectedCN(session);
            if (status)
            {
                SelectAutoTransitionCheckbox(session);
            }
        }

        #endregion

        #region check if support intelligent cooling

        /// <summary>
        /// Thinkpad DeviceID "ACPI\LEN0100"
        /// Ideapad ITS3.0  DeviceID "ACPI\LIC0001"
        /// Ideapad ITS4.0  DeviceID "ACPI\IDEA2004"
        /// Ideapad ITS5.0  DeviceID "ACPI\IDEA2008"
        /// </summary>
        /// <param name="DeviceID"></param>
        /// <returns>0：不支持，1：支持驱动已安装，2：支持驱动未安装，3：异常</returns>
        public string isSupportIntelligentCooling(string DeviceID)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_PnPSignedDriver");
                foreach (ManagementObject mo in mos.Get())
                {
                    if (mo["DeviceID"].ToString().Contains(DeviceID) && !string.IsNullOrEmpty(mo["DeviceName"].ToString()))
                    {
                        return "1";
                    }
                    if (mo["DeviceID"].ToString().Contains(DeviceID) && string.IsNullOrEmpty(mo["DeviceName"].ToString()))
                    {
                        return "2";
                    }
                }
                return "0";
            }
            catch
            {
                return "3";
            }
        }

        public string GetDriverVersion(string DeviceID)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_PnPSignedDriver");
                foreach (ManagementObject mo in mos.Get())
                {
                    if (mo["DeviceID"].ToString().Contains(DeviceID) && !string.IsNullOrEmpty(mo["DeviceName"].ToString()))
                    {
                        return mo["DriverVersion"].ToString();
                    }
                }
                return "0.0.0.0";
            }
            catch { return "0.0.0.0"; }
        }

        #endregion

        #region Parsing attribute values

        /// <summary> Parsing attribute values</summary>
        /// <returns>attribute value</returns>
        public string GetAttributesByPageSource(WindowsElement element, string AttributeName, WindowsDriver<WindowsElement> session = null, string Xpath = null)
        {
            string AttributeValue = string.Empty;
            try
            {
                if (element != null)
                {
                    return element.GetAttribute(AttributeName);
                }
                if (!string.IsNullOrEmpty(Xpath))
                {
                    XmlDocument xmldoc = new XmlDocument();
                    xmldoc.LoadXml(session.PageSource);
                    XmlNode xmlTarget = xmldoc.DocumentElement.SelectSingleNode(Xpath);
                    if (xmlTarget != null)
                    {
                        return xmlTarget.Attributes[AttributeName].Value;
                    }
                    else
                    {
                        return xmlTarget.InnerText;
                    }
                }
                return AttributeValue;
            }
            catch
            {
                return AttributeName;
            }
        }

        #endregion

        #region read Regedit

        public static string GetCurrentUserRegeditValue(string name, string regPath)
        {
            string info = string.Empty;
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(regPath, true);
                info = reg.GetValue(name).ToString();
                reg.Close();
                return info;
            }
            catch
            {
                return info;
            }
        }

        public static string GetLocalMachineRegeditValue(string name, string regPath)
        {
            string info = string.Empty;
            try
            {
                RegistryKey localMachineRegidtry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey reg = localMachineRegidtry?.OpenSubKey(regPath, true);
                info = reg?.GetValue(name)?.ToString();
                reg?.Close();
                return info;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return info;
            }
        }

        public static string CreateLocalMachineSubKey(string name, string regPath, string setValue, RegistryValueKind type = RegistryValueKind.String)
        {
            string info = string.Empty;
            try
            {
                string[] regSubPath = regPath.Split('\\');
                RegistryKey parentKey = Registry.LocalMachine;
                RegistryKey reg = Registry.LocalMachine;
                string registrySubKey = string.Empty;
                foreach (string subKey in regSubPath)
                {
                    List<string> subKeyNames = parentKey.GetSubKeyNames().ToList<string>();
                    if (!subKeyNames.Contains(subKey))
                    {
                        parentKey.CreateSubKey(subKey);
                    }
                    registrySubKey += subKey + "\\";
                    parentKey = Registry.LocalMachine.OpenSubKey(registrySubKey, true);
                }

                reg = Registry.LocalMachine.OpenSubKey(regPath, true);
                reg.SetValue(name, setValue, type);
                reg.Close();
                return info;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return info;
            }
        }

        public static string SetLocalMachineRegeditValue(string name, string regPath, object value, RegistryValueKind type = RegistryValueKind.String)
        {
            string info = string.Empty;
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(regPath, true);
                reg?.SetValue(name, value, type);
                reg?.Close();
                return info;
            }
            catch
            {
                return info;
            }
        }

        public static string SetCurrentUserRegeditValue(string name, string regPath, object value, RegistryValueKind type = RegistryValueKind.String)
        {
            string info = string.Empty;
            try
            {
                RegistryKey reg = Registry.CurrentUser.OpenSubKey(regPath, true);
                reg.SetValue(name, value, type);
                reg.Close();
                return info;
            }
            catch
            {
                return info;
            }
        }

        #endregion

        #region Get Intelligent Cooling info

        /// <summary>
        /// isIntelligentCooling:  true / false   support/not support
        /// version: no/any value    no >> driver not install
        /// DYTC：3/4/5/6
        /// Type: Think/Idea
        /// info: tips
        /// </summary>
        /// <returns>isIntelligentCooling|version|DYTC|Type|info</returns>
        public List<string> GetSupportIntelligentCoolingInfo()
        {
            bool isIntelligentCooling = false;
            List<string> itsinfo = new List<string>();
            if (isSupportIntelligentCooling(thinkDeviceID) == "1")
            {
                itsinfo.Add("true");
                var itsVersionJP = GetLocalMachineRegeditValue("Version", itsRegeditPathJP);
                if (itsVersionJP == "16384")  // 0x0004000
                {
                    itsinfo.Add("16384");
                    itsinfo.Add("4");
                }
                else if (itsVersionJP == "20480")//0x0005000
                {
                    itsinfo.Add("20480");
                    itsinfo.Add("5");
                }
                else if (itsVersionJP == "24576")//0x0006000
                {
                    itsinfo.Add("24576");
                    itsinfo.Add("6");
                }
                else
                {
                    itsinfo.Add(itsVersionJP);
                    itsinfo.Add("unknown");
                }
                itsinfo.Add("think");
                itsinfo.Add("The Intelligent Cooling Driver is installed");
            }
            else if (isSupportIntelligentCooling(thinkDeviceID) == "2")
            {
                itsinfo.Add("true");
                itsinfo.Add("no");
                itsinfo.Add("no");
                itsinfo.Add("Think");
                itsinfo.Add("The Intelligent Cooling Driver not installed");
            }
            else if (isSupportIntelligentCooling(ideaITS3DeviceID) == "1")
            {
                var itsVersionCN = GetLocalMachineRegeditValue("Version", itsRegeditPathCN);
                itsinfo.Add("true");
                itsinfo.Add(itsVersionCN);
                itsinfo.Add("4");
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver is installed");
            }
            else if (isSupportIntelligentCooling(ideaITS3DeviceID) == "2")
            {
                itsinfo.Add("true");
                itsinfo.Add("no");
                itsinfo.Add("4");
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver not installed");
            }
            else if (isSupportIntelligentCooling(ideaITS4DeviceID) == "1")
            {
                var itsVersionCN = GetLocalMachineRegeditValue("Version", itsRegeditPathCN);
                itsinfo.Add("true");
                if (itsVersionCN == "20480") //0x0005000
                {
                    itsinfo.Add("20480");
                    itsinfo.Add("5");
                }
                else
                {
                    itsinfo.Add(itsVersionCN);
                    itsinfo.Add("unknown");
                }
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver is installed");
            }
            else if (isSupportIntelligentCooling(ideaITS4DeviceID) == "2")
            {
                itsinfo.Add("true");
                itsinfo.Add("no");
                itsinfo.Add("5");
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver not installed");
            }
            else if (isSupportIntelligentCooling(ideaITS5DeviceID) == "1")
            {
                var itsVersionCN = GetLocalMachineRegeditValue("Version", itsRegeditPathCN);
                itsinfo.Add("true");
                if (itsVersionCN == "24576") //0x0006000
                {
                    itsinfo.Add("24576");
                    itsinfo.Add("6");
                }
                else
                {
                    itsinfo.Add(itsVersionCN);
                    itsinfo.Add("unknown");
                }
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver is installed");
            }
            else if (isSupportIntelligentCooling(ideaITS5DeviceID) == "2")
            {
                itsinfo.Add("true");
                itsinfo.Add("no");
                itsinfo.Add("6");
                itsinfo.Add("idea");
                itsinfo.Add("The Intelligent Cooling Driver not installed");
            }
            else
            {
                var legacyVersion = GetLocalMachineRegeditValue("Version", legacyRegeditPath);
                if (legacyVersion == "12288") //legacy 0x0003000
                {
                    itsinfo.Add("true");
                    itsinfo.Add("12288");
                    itsinfo.Add("3");
                    itsinfo.Add("think");
                    itsinfo.Add("Support Legacy Function");
                }
                else
                {
                    itsinfo.Add("false");
                    itsinfo.Add("no");
                    itsinfo.Add("no");
                    itsinfo.Add("no");
                    itsinfo.Add("Doesn't support Intelligent Cooling");
                }
            }
            return itsinfo;
        }

        #endregion

        #region get the machine if support intelligent cooling

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dytc"></param>
        /// <param name="type"></param>
        /// <param name="skip">true:support ITS ,false : doesn't support ITS</param>
        /// <returns></returns>
        public bool CheckMachineSupportIntelligentCooling(string dytc, string type, bool skip = true)
        {
            bool isSupportFlag = false;
            try
            {
                List<string> info = GetSupportIntelligentCoolingInfo();
                if (info.Count > 0)
                {
                    if (skip == false)  //not support machine run
                    {
                        if (info[0] == "false")
                        {
                            isSupportFlag = true;
                            WriteLog("The machine does not support intelligent cooling. Info:" + string.Join(" ", info));
                        }
                        else
                        {
                            isSupportFlag = false;
                            WriteLog("The machine support intelligent cooling. Info:" + string.Join(" ", info));
                        }
                    }
                    else  //support machine run
                    {
                        if (info[0] == "true" && info[1] != "no" && info[2] == dytc && info[3] == type)  //support its | driver install
                        {
                            isSupportFlag = true;
                            WriteLog("The machine support intelligent cooling. Info: " + string.Join(" ", info));
                        }
                        else
                        {
                            isSupportFlag = false;
                            if (info[0] == "true")
                            {
                                WriteLog("The machine support intelligent cooling but dytc version is " + info[2] + " Info: " + string.Join(" ", info));

                            }
                            else
                            {
                                WriteLog("The machine doesn't support intelligent cooling. Info: " + string.Join(" ", info));
                            }
                        }
                    }
                }
                else
                {
                    isSupportFlag = false;
                    WriteLog("The machine GetSupportIntelligentCoolingInfo() method is null, Info:" + string.Join(" ", info));
                }
                return isSupportFlag;
            }
            catch (Exception ex)
            {
                WriteLog("CheckMachineSupportIntelligentCooling ,Exception Info:" + ex.ToString());
                return isSupportFlag;
            }
        }

        #endregion

        #region regdit vlue deal
        public string FillNumberToSpecifiedLength(string specfill, int speclength = 4, bool objstr = false)
        {
            try
            {
                specfill = System.Convert.ToString(long.Parse(specfill), 2);
                if (specfill.Length < speclength)
                {
                    int m = speclength - specfill.Length;
                    for (int i = 0; i < m; i++)
                    {
                        specfill = specfill.Insert(0, "0");
                        if (specfill.Length == 64)
                        {
                            break;
                        }
                    }
                    return specfill;
                }
                else
                {
                    if (objstr)
                    {
                        return specfill;
                    }
                    else
                    {
                        return specfill.Substring(0, speclength);
                    }
                }
            }
            catch
            {
                return specfill;
            }
        }

        #endregion

        #region Metric Date Collection Toolbar for ITS CN

        /// <summary> 时间差 获取 </summary>
        /// <returns></returns>
        public static int GetDiffTime(string _beginTime, string _endTime)
        {
            DateTime beginTime = Convert.ToDateTime(_beginTime);
            DateTime endTime = Convert.ToDateTime(_endTime);
            TimeSpan span = endTime - beginTime;
            int iTatol = Convert.ToInt32(span.TotalSeconds);
            return iTatol;
        }

        /// <summary> 时间戳转换</summary>
        /// <returns></returns>
        public long UnixTime(string _time)
        {
            DateTime beginTime = Convert.ToDateTime(_time);
            long epoch = (beginTime.ToUniversalTime().Ticks - 621355968000000000) / 10000000;
            return epoch;
        }

        /// <summary>
        /// 解析 Json 文件
        /// </summary>
        /// <param name="json">Json字段</param>
        /// <param name="index">0:SessinId|1:CurrentMode|2:LastMode|3:LastModeStartTime|4:Event_time|5:ModeSwitchWay|6:ITSVersion</param>
        /// <returns></returns>
        public string GetIntelligentCoolingStatusViaEvent(string json, int index)
        {
            ITS its = JsonConvert.DeserializeObject<ITS>(json);
            switch (its.ITS_status[index].name)
            {
                case "SessinId":
                    return its.ITS_status[index].value;
                case "CurrentMode":
                    return its.ITS_status[index].value;
                case "LastMode":
                    return its.ITS_status[index].value;
                case "LastModeStartTime":
                    return its.ITS_status[index].value;
                case "Event_time":
                    return its.ITS_status[index].value;
                case "ModeSwitchWay":
                    return its.ITS_status[index].value;
                case "ITSVersion":
                    return its.ITS_status[index].value;
                default:
                    return "Error";
            }
        }
        public class ITS
        {
            public List<ITS_status> ITS_status { get; set; }
        }
        public class ITS_status
        {
            public string name { get; set; }
            public string value { get; set; }
        }
        public bool GetIsMetricDataLenovoVantageToolbar()
        {
            // 1.0.119.33
            var vantageToolbar = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoBatteryGaugePackage\x64\LenovoBatteryGaugePackage.dll";
            if (File.Exists(vantageToolbar))
            {
                var version = FileVersionInfo.GetVersionInfo(vantageToolbar).FileVersion;
                if (int.Parse(version.Split('.')[0]) == 1)  //判断第一位
                {
                    if (int.Parse(version.Split('.')[1]) == 0) //判断第二位
                    {
                        if (int.Parse(version.Split('.')[2]) == 119) //判断第三位
                        {
                            if (int.Parse(version.Split('.')[3]) < 33) //判断第四位
                            {
                                WriteLog("Note:The LenovoBatteryGaugePackage doesn't support Metric data. Versin:" + version);
                                return false;
                            }
                        }
                        else if (int.Parse(version.Split('.')[2]) < 119)  //判断第三位
                        {
                            WriteLog("Note:The LenovoBatteryGaugePackage doesn't support Metric data. Versin:" + version);
                            return false;
                        }
                    }
                }
                else if (int.Parse(version.Split('.')[0]) < 1)
                {
                    WriteLog("Note:The LenovoBatteryGaugePackage doesn't support Metric data. Versin:" + version);
                    return false;
                }
                return true;
            }
            else
            {
                WriteLog("Note:Note:The LenovoBatteryGaugePackage file don't find.");
                return false;
            }
        }
        public bool GetIsMetricDataIntelligentCoolingITS4Driver()
        {
            var _version = GetDriverVersion(ideaITS4DeviceID).Split('.');
            if (int.Parse(_version[0]) == 4)  //版本首位
            {
                if (int.Parse(_version[1]) == 0)  // 第二位
                {
                    if (int.Parse(_version[1]) == 0)  // 第三位
                    {
                        if (int.Parse(_version[3]) <= 22) //版本最后一位
                        {
                            WriteLog("Note:Doesn't support Metric data. Version:" + GetDriverVersion(ideaITS4DeviceID));
                            return false;
                        }
                    }
                }
            }
            else if (int.Parse(_version[0]) < 4)
            {
                WriteLog("Note:Doesn't support Metric data. Version:" + GetDriverVersion(ideaITS4DeviceID));
                return false;
            }
            return true;
        }

        /// <summary>curmode/lastmode/MMCAUTO/data</summary>
        /// <returns></returns>
        public string GetIntelligentCoolingMetricDataInfo()
        {
            string data = GetDataCollectionValue().Split(',')[1];
            data = FillNumberToSpecifiedLength(data, 64);

            string _lastmode = data.Substring(data.Length - 30);  //0-29 后30   last mode
            string _curmode = data.Substring(4, 30);  // 30-59 前30  current mode
            string _curva = string.Empty;
            string _lastva = string.Empty;
            string _temp = string.Empty;

            string _lastmodeb0 = _lastmode.Substring(_lastmode.Length - 1);  // STD  b0
            string _lastmodeb2 = _lastmode.Substring(_lastmode.Length - 3).Substring(0, 1);  // EPM b2
            string _lastmodeb3 = _lastmode.Substring(_lastmode.Length - 4).Substring(0, 1);  //BSM b3
            string _lastmodeb4 = _lastmode.Substring(_lastmode.Length - 5).Substring(0, 1);  //APM b4
            string _lastmodeb5 = _lastmode.Substring(_lastmode.Length - 6).Substring(0, 1);  //AQM b5
            string _lastmodeb6 = _lastmode.Substring(_lastmode.Length - 7).Substring(0, 1);  //MYHPAD b6
            string _lastmodeb7 = _lastmode.Substring(_lastmode.Length - 8).Substring(0, 1);  //MYHTENT b7
            string _lastmodeb8 = _lastmode.Substring(_lastmode.Length - 9).Substring(0, 1);  //IEPM b8
            string _lastmodeb9 = _lastmode.Substring(_lastmode.Length - 10).Substring(0, 1);  //IBSM b9
            string _lastmodeb10 = _lastmode.Substring(_lastmode.Length - 11).Substring(0, 1);  //CQL b10

            string _curmodeb0 = _curmode.Substring(_curmode.Length - 1);  // STD  b0
            string _curmodeb2 = _curmode.Substring(_curmode.Length - 3).Substring(0, 1);  // EPM b2
            string _curmodeb3 = _curmode.Substring(_curmode.Length - 4).Substring(0, 1);  //BSM b3
            string _curmodeb4 = _curmode.Substring(_curmode.Length - 5).Substring(0, 1);  //APM b4
            string _curmodeb5 = _curmode.Substring(_curmode.Length - 6).Substring(0, 1);  //AQM b5
            string _curmodeb6 = _curmode.Substring(_curmode.Length - 7).Substring(0, 1);  //MYHPAD b6
            string _curmodeb7 = _curmode.Substring(_curmode.Length - 8).Substring(0, 1);  //MYHTENT b7
            string _curmodeb8 = _curmode.Substring(_curmode.Length - 9).Substring(0, 1);  //IEPM b8
            string _curmodeb9 = _curmode.Substring(_curmode.Length - 10).Substring(0, 1);  //IBSM b9
            string _curmodeb10 = _curmode.Substring(_curmode.Length - 11).Substring(0, 1);  //CQL b10

            string _switchtype = data.Substring(3, 1);  //第60位  默认Auto  1:MMC   

            if (_curmodeb0 == "1") { _curva += "STD-ISTD"; }
            if (_curmodeb2 == "1") { _curva += "EPM-EP"; }
            if (_curmodeb3 == "1") { _curva += "BSM-BS"; }
            if (_curmodeb4 == "1") { _curva += "APM-IAP"; }
            if (_curmodeb5 == "1") { _curva += "AQM-IAQ"; }
            if (_curmodeb6 == "1") { _curva += "MYHPAD-PAD"; }
            if (_curmodeb7 == "1") { _curva += "MYHTENT-TENT"; }
            if (_curmodeb8 == "1") { _curva += "IEPM-iEPM"; }
            if (_curmodeb9 == "1") { _curva += "IBSM-iBSM"; }
            if (_curmodeb10 == "1") { _curva += "CQL-CQL"; }

            if (_lastmodeb0 == "1") { _lastva += "STD-ISTD"; }
            if (_lastmodeb2 == "1") { _lastva += "EPM-EP"; }
            if (_lastmodeb3 == "1") { _lastva += "BSM-BS"; }
            if (_lastmodeb4 == "1") { _lastva += "APM-IAP"; }
            if (_lastmodeb5 == "1") { _lastva += "AQM-IAQ"; }
            if (_lastmodeb6 == "1") { _lastva += "MYHPAD-PAD"; }
            if (_lastmodeb7 == "1") { _lastva += "MYHTENT-TENT"; }
            if (_lastmodeb8 == "1") { _lastva += "IEPM-iEPM"; }
            if (_lastmodeb9 == "1") { _lastva += "IBSM-iBSM"; }
            if (_lastmodeb10 == "1") { _lastva += "CQL-CQL"; }

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


        #endregion

        #region Intelligent cooling Service action

        /// <summary> 0:Start ITS | 1:Stop ITS | 2:Start IMC | 3:Stop IMC | 4:Stop ITS IMC | default: start ITS IMC </summary>
        /// <param name="obj"></param>
        public void IntelligentCoolinggIMCServiceControl(int obj = 6)
        {
            switch (obj)
            {
                case 0:
                    Common.StartService(itsServiceName);
                    break;
                case 1:
                    Common.StopService(itsServiceName);
                    break;
                case 2:
                    Common.StartService(imcServiceName);
                    break;
                case 3:
                    Common.StopService(imcServiceName);
                    break;
                case 4:
                    Common.StopService(itsServiceName);
                    Common.StopService(imcServiceName);
                    break;
                default:
                    Common.StartService(itsServiceName);
                    Common.StartService(imcServiceName);
                    break;
            }
        }
        #endregion

        #region delete plugin control
        public bool DeleteSpecificPlugin(string pluginpath, string backpluginpath)
        {
            Common.StopService(imcServiceName);
            Thread.Sleep(2000);
            if (Directory.Exists(pluginpath))
            {
                if (Directory.Exists(backpluginpath))
                {
                    Directory.Delete(backpluginpath, true);
                }
                try
                {
                    Directory.Move(pluginpath, backpluginpath);
                }
                catch
                {
                    WriteLog("Exception: Move Plugin Folder Faild: DeletePath >>" + pluginpath + "  DeleteBackPath:" + backpluginpath);
                    return false;
                }
            }
            else
            {
                WriteLog("Exception: The " + pluginpath + " not found.");
                return false;
            }
            if (Directory.Exists(pluginpath))
            {
                WriteLog("Exception: The " + pluginpath + " not delete.");
                return false;
            }
            else
            {
                return true;
            }
        }

        //Reset方法必须与Delete方法连用
        public bool ResetIntelligentCoolingPluginFolder(string pluginpath, string backpluginpath)
        {
            try
            {
                if (Directory.Exists(pluginpath))
                {
                    return true;
                }
                if (Directory.Exists(backpluginpath))
                {
                    Directory.Move(backpluginpath, pluginpath);
                }
                Common.StartService(imcServiceName);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog("Exception: ResetIntelligentCoolingPluginFolder is Fail " + ex.ToString());
                return false;
            }
        }

        public bool DeleteIntelligentCoolingPluginJP()
        {
            return DeleteSpecificPlugin(itsPluginPathJP, itsBackPluginPath);
        }
        public bool DeleteIntelligentCoolingPluginCN()
        {
            return DeleteSpecificPlugin(itsPluginPathCN, itsBackPluginPath);
        }

        public bool ResetIntelligentCoolingPluginJP()
        {
            return ResetIntelligentCoolingPluginFolder(itsPluginPathJP, itsBackPluginPath);
        }
        public bool ResetIntelligentCoolingPluginCN()
        {
            return ResetIntelligentCoolingPluginFolder(itsPluginPathCN, itsBackPluginPath);
        }

        #endregion

        #region ConnectWiFi DisconnectWiFi
        public bool DisconnectWiFi()
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;

                p.StartInfo.Verb = "runas";
                p.Start();
                p.StandardInput.WriteLine("Netsh wlan disconnect  " + "&exit");
                Thread.Sleep(3000);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog("断开Wifi，错误信息：" + ex.Message);
                WriteLog("断开Wifi，错误信息：" + ex.ToString());
                return false;
            }
        }

        public bool ConnectWiFi(string networkname)
        {
            try
            {
                Process p = new Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                p.StartInfo.RedirectStandardError = true;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;

                p.StartInfo.Verb = "runas";
                p.Start();
                p.StandardInput.WriteLine("Netsh wlan connect " + networkname + "&exit");
                p.WaitForExit();
                p.Close();
                Thread.Sleep(5000);
                return true;
            }
            catch (Exception ex)
            {
                WriteLog("连接Wifi，错误信息：" + ex.Message);
                WriteLog("连接Wifi，错误信息：" + ex.ToString());
                return false;
            }
        }
        #endregion

        #region write log
        public void WriteLog(string LogText)
        {
            try
            {
                string path = "C:\\IntelligentCoolingLog";
                string logfile = Path.Combine(path, "IntelligentCoolingLog.log");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (!File.Exists(logfile))
                {
                    StreamWriter swFile;
                    swFile = File.CreateText(logfile);
                    swFile.Close();
                }
                StreamWriter sw = new StreamWriter(logfile, true, Encoding.UTF8);
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "  " + LogText);
                sw.Close();
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        #endregion

        #region debug

        #endregion

        public static Tuple<string, string, string> GetITSXMLValue(string xmlStr, string value)
        {

            List<string> list = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNodeList nodeList = xmlDoc.SelectNodes(value);
            Tuple<string, string, string> tuple = new Tuple<string, string, string>(nodeList[0].ChildNodes[1].InnerText, nodeList[1].ChildNodes[1].InnerText, nodeList[2].ChildNodes[1].InnerText);

            return tuple;
            //foreach (var node in nodeList)
            //{
            //    var nodeChild = node as XmlNode;
            //    var settingList = nodeChild.FirstChild;
            //    var setting = settingList?.InnerText;
            //    if (string.IsNullOrEmpty(setting) || index != 0 && index != nodeIndex)
            //    {
            //        nodeIndex++;
            //        continue;
            //    }
            //        return setting;
            //}
            //return string.Empty;
        }

        public static string GetXMLValue(string xmlStr, string value, string getvalue = "", int index = 0)
        {
            if (string.IsNullOrEmpty(xmlStr))
            {
                return string.Empty;
            }
            List<string> list = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNodeList nodeList = xmlDoc.SelectNodes(value);
            int nodeIndex = 0;
            foreach (var node in nodeList)
            {
                var nodeChild = node as XmlNode;
                var settingList = nodeChild.FirstChild;
                var setting = settingList?.InnerText;
                if (string.IsNullOrEmpty(setting) || index != 0 && index != nodeIndex)
                {
                    nodeIndex++;
                    continue;
                }
                if (string.Empty == getvalue)
                {
                    return setting;
                }
            }
            return string.Empty;
        }

        public static string getlogtime(string time)
        {
            string[] sArray = time.Split('T');
            string logtime = sArray[0] + " " + sArray[1];
            return logtime;
        }

        /// 获取 Event Log Xml 以及 创建 时间 信息 
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returnGetEventLogXmlTimeInfos>
        public void GetEventLogXmlTimeInfo(string target)
        {
            try
            {
                _eventLogtime.Clear();
                _eventLogxml.Clear();
                using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
                {
                    EventRecord record;
                    while ((record = reader.ReadEvent()) != null)
                    {
                        using (record)
                        {
                            if (record.FormatDescription().Contains(target))
                            {
                                _eventLogxml.Add(record.FormatDescription());
                                _eventLogtime.Add(record.TimeCreated.ToString());
                            }
                        }
                    }
                }
            }
            catch
            {
                throw new ValidationException("\r\n Note: Get xml File and Time fail ");
            }
        }

        public void CheckEventLogInfo(string target)
        {
            using (var reader = new EventLogReader(_eventLogFile, PathType.FilePath))
            {
                bool dytc = false;
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains(target))
                        {
                            dytc = true;
                            break;
                        }
                    }
                }
                Assert.IsTrue(dytc, "未找到相应的log数据");
            }
        }

        /// 返回 某个时间段 以后所有Xml
        /// </summary>
        /// <returns></returns>
        public List<string> GetEventLogXmlTimeInfoByTime()
        {
            GetEventLogXmlTimeInfo("ITS_status");  //获取所有采集
            List<string> temp = new List<string>();
            try
            {
                int i = _eventLogtime.Count;
                if (i > 0)
                {
                    temp.Add(_eventLogxml[i - 1]);
                    return temp;
                }
                else
                {
                    return temp;
                }
            }
            catch (Exception ex)
            {

                _exception += "\r\n Note: GetEventLogXmlTimeInfoByTime fail " + _startTime + ex.ToString();
                return temp;
            }
        }

        public void StartTimeEventLogXmlTimeInfo()
        {
            _startLogxml.Clear();
            _startLogxml = GetEventLogXmlTimeInfoByTime();
        }

        public string StartTimeEventLogXmlShow()
        {
            return string.Join("\r\n", _startLogxml);
        }

        public void FirstGetModeChangeSecondTime(string target)
        {
            _secondTime = GetNowTime();
        }

        public string SecondTimeEventLogXmlTimeInfo()
        {
            _secondLogxml.Clear();
            _secondLogxml = GetEventLogXmlTimeInfoByTime();
            return _secondLogxml[0].ToString();
        }

        private string GetNowTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public long GetNowTime_Unix()
        {
            var unixdate = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            return unixdate;
        }

        public static string GetCurrentModeFromBIOS()
        {
            string mode = string.Empty;

            _mode = DesktopPowerManagementHelper.RunCmd("C:\\DetectMode.exe -0");
            _currentfunction = _mode.Split(':')[3];
            _currentfunction = System.Text.RegularExpressions.Regex.Replace(_currentfunction, @"[^0-9]+", "");
            _currentmode = _mode.Split(':')[4];
            _currentmode = System.Text.RegularExpressions.Regex.Replace(_currentmode, @"[^0-9]+", "");

            if (_currentfunction == "0" && _currentmode == "15") { mode = "STD"; }
            if (_currentfunction == "5" && _currentmode == "15") { mode = "APM"; }
            if (_currentfunction == "6" && _currentmode == "15") { mode = "AQM"; }
            if (_currentfunction == "3" && _currentmode == "0") { mode = "PAD"; }
            if (_currentfunction == "3" && _currentmode == "1") { mode = "TENT"; }
            if (_currentfunction == "11" && _currentmode == "2") { mode = "EPM"; }
            if (_currentfunction == "11" && _currentmode == "3") { mode = "BSM"; }
            if (_currentfunction == "7" && _currentmode == "15") { mode = "IEPM"; }
            if (_currentfunction == "8" && _currentmode == "15") { mode = "IBSM"; }

            return mode;
        }

        public static string GetXMLValue1(string xmlStr, string value, string getvalue = "", int index = 0)
        {
            if (string.IsNullOrEmpty(xmlStr))
            {
                return string.Empty;
            }
            List<string> list = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            XmlNodeList nodeList = xmlDoc.SelectNodes(value);
            int nodeIndex = 0;
            foreach (var node in nodeList)
            {
                var nodeChild = node as XmlNode;
                var settingList = nodeChild.FirstChild;
                var setting = settingList?.InnerText;
                if (string.IsNullOrEmpty(setting) || index != 0 && index != nodeIndex)
                {
                    nodeIndex++;
                    continue;
                }
                if (string.Empty != getvalue)
                {
                    if (nodeChild.Attributes[0].Value.Equals(getvalue, StringComparison.CurrentCultureIgnoreCase))
                    {
                        return setting;
                    }
                }
            }
            return string.Empty;
        }

        public static void DeleteFile(string fileName = "wincmd.txt")
        {
            string path = Path.Combine(Application.StartupPath, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        public static void RunCmd(string cmd, bool isEnterFlag = false)
        {
            //cbh
            Console.WriteLine(cmd);
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;

            if (isEnterFlag)
            {//Run as administrator cbh
                processStartInfo.Verb = "Run as";
            }

            processStartInfo.CreateNoWindow = false;
            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("{enter}");
            Console.WriteLine("The Path is " + cmd);
            Thread.Sleep(60000);
            //process.StandardInput.WriteLine("exit");
            process.Close();

        }
        #region DPI Control

        public const int ENUM_CURRENT_SETTINGS = -1;
        public const int CDS_UPDATEREGISTRY = 0x01;
        public const int CDS_TEST = 0x02;
        public const int DISP_CHANGE_SUCCESSFUL = 0;
        public const int DISP_CHANGE_RESTART = 1;
        public const int DISP_CHANGE_FAILED = -1;

        public const int DMDO_DEFAULT = 0;
        public const int DMDO_90 = 1;
        public const int DMDO_180 = 2;
        public const int DMDO_270 = 3;
        public struct DEVMODE
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            public string dmFormName;
            public short dmLogPixels;
            public short dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }
        [DllImport("user32.dll")]
        public static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);
        public static string ChangeResolution(int width, int height)
        {
            DEVMODE devmode = new DEVMODE();
            devmode.dmDeviceName = new string(new char[32]);
            devmode.dmFormName = new string(new char[32]);
            devmode.dmSize = (short)Marshal.SizeOf(devmode);
            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devmode) != 0)
            {
                devmode.dmPelsWidth = width;
                devmode.dmPelsHeight = height;
                int iRet = ChangeDisplaySettings(ref devmode, CDS_TEST);
                if (iRet == DISP_CHANGE_FAILED)
                {
                    return "This request cannot be executed.";
                }
                else
                {
                    iRet = ChangeDisplaySettings(ref devmode, CDS_UPDATEREGISTRY);
                    switch (iRet)
                    {
                        case DISP_CHANGE_SUCCESSFUL:
                            return "Change successful.";
                        case DISP_CHANGE_RESTART:
                            return "Need to restart computer.";
                        default:
                            return "Change failed.";
                    }
                }
            }
            return "ChangeResolution() no run";
        }

        public static ExpandCollapsePattern GetSelectionPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(ExpandCollapsePattern.Pattern, out currentPattern))
            {

            }
            return currentPattern as ExpandCollapsePattern;
        }

        public static SelectionItemPattern GetSelectionItemPattern(AutomationElement element)
        {
            object currentPattern;
            if (!element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out currentPattern))
            {


            }
            return currentPattern as SelectionItemPattern;
        }
        #endregion
        public static int GetMonitorBrightness()
        {
            var mclass = new ManagementClass("WmiMonitorBrightness")
            {
                Scope = new ManagementScope(@"\\.\root\wmi")
            };
            var instances = mclass.GetInstances();
            foreach (ManagementObject instance in instances)
            {
                return (byte)instance.GetPropertyValue("CurrentBrightness");
            }
            return 0;
        }

    }
}
