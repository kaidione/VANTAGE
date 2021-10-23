using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using System.Xml;

namespace LenovoVantageTest.Pages
{
    public class GamingThermalModePages : SettingsBase
    {
        private WindowsDriver<WindowsElement> _session;
        private List<string> _proProcess = new List<string> { "Microsoft WWA Host", "Lenovo.Modern.ImController", "Microsoft Visual Studio 2019", "Lenovo.Modern.ImController.PluginHost", "LenovoVantageService" };
        public GamingThermalModePages(WindowsDriver<WindowsElement> session)
        {
            if (session.SessionId == null)
            {
                string applicationId = "E046963F.LenovoCompanion_k1h2ywk1493x8!App";
                var factory = new BaseTestClass();
                var appInstance = factory.LaunchWinApplication(applicationId);
                session = appInstance.Session;
            }
            _session = session;
            base.session = session;
        }

        public WindowsElement VantageMinimize => base.FindElementByTimes(_session, "XPath", VantageConstContent.VantageMinizeId);
        public WindowsElement VantageMaximize => base.FindElementByTimes(_session, "XPath", VantageConstContent.VantageMaxizeId);
        public WindowsElement VantageClose => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='Close']");
        //Dialog
        public WindowsElement GamingLegionEdge => base.FindElementByTimes(_session, "AutomationId", "gaming_legion_edge");

        //Thermal Mode
        public WindowsElement ThermalModeInHomepage => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermal_mode')]");
        public WindowsElement ThermalModePerformance => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_performance");
        public WindowsElement ThermalModePerformanceOCOnName => base.FindElementByTimes(_session, "Name", "Thermal Mode Performance | Overclock on");
        public WindowsElement ThermalModePerformanceName => base.FindElementByTimes(_session, "Name", "Thermal Mode Performance");
        public WindowsElement ThermalModePerformanceOCOn => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_performance_overclock_on");
        public WindowsElement ThermalModeBalance => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_balance");
        public WindowsElement ThermalModeBalanceOCOnName => base.FindElementByTimes(_session, "Name", "Thermal Mode Balance | Overclock on");
        public WindowsElement ThermalModeBalanceName => base.FindElementByTimes(_session, "Name", "Thermal Mode Balance");
        public WindowsElement ThermalModeQuiet => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_quiet");
        public WindowsElement ThermalModeQuietName => base.FindElementByTimes(_session, "Name", "Thermal Mode Quiet");
        public WindowsElement GetThermalMode => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermal_mode')]");
        public WindowsElement GetOverDrive => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'overDrive')]");
        public WindowsElement GethybridMode => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'hybridMode')]");
        public List<WindowsElement> GetThermalModeParentList => new List<WindowsElement>(base.FindElementsByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermal_mode_')]/parent::*/*"));
        public WindowsElement ThermalModeBananceInSettings => base.FindElementByTimes(_session, "AutomationId", "radio-banance");
        public WindowsElement ThermalModePerformanceInSettings => base.FindElementByTimes(_session, "AutomationId", "radio-performance");
        public WindowsElement ThermalModeQuietInSettings => base.FindElementByTimes(_session, "AutomationId", "radio-quiet");
        public List<WindowsElement> GamingthermalModeSettingPopupList => new List<WindowsElement>(session.FindElementsByXPath("//*[@AutomationId='thermal_mode_setting_popup']/child::*/*"));
        public WindowsElement ThermalModeQuietSettingsPopup => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_setting_popup");
        public WindowsElement ThermalModeQuietSettingsPopupDismiss => base.GetElement(_session, "AutomationId", "thermal_mode_setting_popup", 2);
        public WindowsElement GetThermalModeInSettingPopup => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermal_mode_setting_')]");
        //thermal_mode_setting_popup_close
        public WindowsElement ThermalModeBananceInSettingsCloseBtn => base.FindElementByTimes(_session, "AutomationId", "thermal_mode_setting_popup_close");
        // thermalmode_autoPerformanceSwitch
        public WindowsElement GetThermalModeAutoPerformanceSwitch => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermalmode_autoPerformanceSwitch_toggle_')]");
        public WindowsElement GetTouchpadStatus => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming.dashboard.device.legionEdge.touchpadLock_toggle_')]");
        public WindowsElement EnableOCCheckboxElement => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'enable_OC_checkbox_')]");
        //
        public WindowsElement ThermalModeGoInstallButton => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'thermal_mode_go_Install_button')]");

        public WindowsElement GamingDeviceMenu => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-nav-lnk-device']");

        //ThermalModeSettingsPopup
        public WindowsElement ThermalModeSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_header_text']");
        public WindowsElement ThermalModeSettingsDescriptionCommon => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_header_description_choose_mode']");
        public WindowsElement ThermalModeSettingsDescriptionFnQ => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_header description_Fn+Q']");
        public WindowsElement ThermalModeSettingsPerformanceTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_performance_mode']");
        public WindowsElement ThermalModeSettingsPerformanceDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_performance_mode_description']");
        public WindowsElement ThermalModeSettingsEnableOCDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='enable_OC_description']");
        public WindowsElement ThermalModeSettingsBalanceTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_balance_mode']");
        public WindowsElement ThermalModeSettingsBalanceDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_balance_mode_description']");
        public WindowsElement ThermalModeSettingsQuietTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_quiet_mode']");
        public WindowsElement ThermalModeSettingsQuietDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='thermal_mode_setting_quiet_mode_description']");
        public WindowsElement ThermalModeSettingsAutoPerformanceSwitchDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='auto_performance_switch_description']");
        public WindowsElement ThermalModeSettingsAutoAdjustCheckBoxUnChecked => base.FindElementByTimes(_session, "AutomationId", "enable_autoAdjustSettings_checkbox_unchecked");
        public WindowsElement ThermalModeSettingsAutoAdjustCheckBoxChecked => base.FindElementByTimes(_session, "AutomationId", "enable_autoAdjustSettings_checkbox_checked");
        public WindowsElement GetThermalModeAutoAdjustCheckBox => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'enable_autoAdjustSettings_checkbox_')]");
        public WindowsElement ThermalModeSettingsAutoAdjustCheckBoxDescription => base.FindElementByTimes(_session, "Name", "Automatically detect the current game and tune CPU/GPU performance. When enabled, the temperature on your computer and fan noise might increase.");
        public WindowsElement GamingHomepageFamily => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='menu-main-text-machineFamilyName']");
        //thermal_mode_CPU/GPU_driver_description enable_OC_descriptio
        public WindowsElement GamingThermalModeInstallGPuCPUDesc => base.FindElementByTimes(session, "AutomationId", "thermal_mode_CPU/GPU_driver_description");
        public WindowsElement GamingThermalModeDescription => base.FindElementByTimes(session, "Name", "Enable CPU/GPU Overclocking in Performance Mode.");
        public WindowsElement EnableOCDescription => base.FindElementByTimes(session, "AutomationId", "enable_OC_description");
        public WindowsElement AdvancedDescription => base.FindElementByTimes(session, "AutomationId", "advanced_button");
        public WindowsElement GamingThermalModeInstallGPuDesc => base.FindElementByTimes(session, "AutomationId", "thermal_mode_GPU_driver_description");
        //AutomationId:	"thermal_mode_CPU_driver_description"
        public WindowsElement GamingThermalModeInstallCPuDesc => base.FindElementByTimes(session, "AutomationId", "thermal_mode_CPU_driver_description");

        // GPU OC_VRAM
        public WindowsElement GPUOCClockLabelTextElement => base.FindElementByTimes(_session, "AutomationId", "gpu_clock_offset_item");
        public WindowsElement VRAMOCClockLabelTextElement => base.FindElementByTimes(_session, "AutomationId", "vram_clock_offset_item");
        //vram_clock_offsetlevel50
        public WindowsElement VramClockOffsetlevel200 => base.FindElementByTimes(_session, "AutomationId", "vram_clock_offsetlevel200");
        public WindowsElement VramTips => base.FindElementByTimes(_session, "Name", "Add an offset to memory clock frequency.");
        //"gpu_clock_offset_slider"
        //"vram_clock_offset_slider"
        public WindowsElement GPUClockOffsetSlider => base.FindElementByTimes(_session, "AutomationId", "gpu_clock_offset_slider");
        public WindowsElement VramClockOffsetSlider => base.FindElementByTimes(_session, "AutomationId", "vram_clock_offset_slider");

        public WindowsElement VramClockOffsetMinusIconClickabler => base.FindElementByTimes(_session, "AutomationId", "vram_clock_offset_minus_icon_clickable");
        public WindowsElement VramClockOffsetPlusIconClickabler => base.FindElementByTimes(_session, "AutomationId", "vram_clock_offset_plus_icon_clickable");

        public WindowsElement VramClockOffsetCloseWindow => base.FindElementByTimes(_session, "AutomationId", "overclock_advanced_settings_close_button");
        public WindowsElement VramClockOffsetSave => base.FindElementByTimes(_session, "AutomationId", "save_change_dialog_save_button");

        //Quick Settings
        public WindowsElement GetQuickSettingsRapidChargeToggleStatus => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming.dashboard.device.quickSettings.rapidCharge_toggle_')]");
        // Xtu, Gpu Json Path
        private string _xtuJsonPath = "C:\\XtuToolValue.json";
        private string _gpuJsonPath = "C:\\gpu.json";
        private string _overclockToolDestPath = @"C:\Overclock\googleTest.exe";
        private string _overclockToolSourcePath = Path.Combine(VantageConstContent.DataPath, "Data\\Tools\\Overclock");
        public string CpuOCListPath = Path.Combine(VantageConstContent.DataPath, "Data\\NerveCenterDocument\\OCList.json");
        public string CpuCoreOCListPath = Path.Combine(VantageConstContent.DataPath, "Data\\NerveCenterDocument\\CoreOCList.json");
        //Pluginxml
        public string _PluginManifestXml = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoGamingSystemPlugin\PluginManifest.xml";
        public string _VantageMachineInfoXml = @"C:\ProgramData\Lenovo\ImController\Shared\MachineInformation.xml";

        public bool LegionEdgeContainsThermalMode()
        {
            for (int i = 0; i < GetThermalModeParentList.Count; i++)
            {
                WindowsElement element = GetThermalModeParentList[i];
                if (element.Text.Contains("legion edge help"))
                {
                    return true;
                }
            }
            return false;
        }

        public enum ThermalMode
        {
            BalanceMode,
            PerformanceMode,
            QuietMode,
            Unknown,
            Null
        }

        public ThermalMode GetCurrentThermalMode()
        {
            for (int i = 0; i < GamingthermalModeSettingPopupList.Count; i++)
            {
                WindowsElement thermalModeSetting = GamingthermalModeSettingPopupList[i];
                if (thermalModeSetting.Selected == true && thermalModeSetting.Text.Contains("mode"))
                {
                    switch (GetElementTextName(thermalModeSetting).ToLower())
                    {
                        case "quiet mode":
                            return ThermalMode.QuietMode;
                        case "balance mode":
                            return ThermalMode.BalanceMode;
                        case "performance mode":
                            return ThermalMode.PerformanceMode;
                        default:
                            return ThermalMode.Unknown;
                    }
                }
            }
            return ThermalMode.Unknown;
        }

        public ThermalMode GetCurrentThermalModeInHomePage()
        {
            if (ThermalModeInHomepage == null)
            {
                return ThermalMode.Null;
            }
            switch (GetElementTextName(ThermalModeInHomepage))
            {
                case "Thermal Mode Quiet":
                    return ThermalMode.QuietMode;
                case "Thermal Mode Balance":
                case "Thermal Mode Balance | Overclock on":
                    return ThermalMode.BalanceMode;
                case "Thermal Mode Performance":
                case "Thermal Mode Performance | Overclock on":
                    return ThermalMode.PerformanceMode;
                default:
                    return ThermalMode.Unknown;
            }
        }

        public ThermalMode GetTheThermalMode(string p0)
        {
            ThermalMode thermalMode = new ThermalMode();
            switch (p0)
            {
                case "Balance Mode":
                    thermalMode = ThermalMode.BalanceMode;
                    break;
                case "Performance Mode":
                    thermalMode = ThermalMode.PerformanceMode;
                    break;
                case "Quiet Mode":
                    thermalMode = ThermalMode.QuietMode;
                    break;
                default:
                    thermalMode = ThermalMode.Unknown;
                    break;
            }
            return thermalMode;
        }
        // Set Thermal Mode In Settings
        public bool SetThermalMode(ThermalMode thermalMode)
        {
            if (thermalMode != GetCurrentThermalMode())
            {
                switch (thermalMode)
                {
                    case ThermalMode.BalanceMode:
                        ThermalModeBananceInSettings.Click();
                        break;
                    case ThermalMode.PerformanceMode:
                        ThermalModePerformanceInSettings.Click();
                        break;
                    case ThermalMode.QuietMode:
                        ThermalModeQuietInSettings.Click();
                        break;
                }
            }
            return thermalMode == GetCurrentThermalMode();
        }

        public bool SetThermalModeAutoPerformanceSwitch(ToggleState toggleState)
        {

            if (toggleState.Equals(ToggleState.On))
            {
                if (!GetElementTextName(GetThermalModeAutoPerformanceSwitch).Equals("auto switch on"))
                {
                    GetThermalModeAutoPerformanceSwitch.Click();
                }
                if (GetElementTextName(GetThermalModeAutoPerformanceSwitch).Equals("auto switch on"))
                {
                    return true;
                }
            }
            else if (toggleState.Equals(ToggleState.Off))
            {

                if (!GetElementTextName(GetThermalModeAutoPerformanceSwitch).Equals("auto switch off"))
                {
                    GetThermalModeAutoPerformanceSwitch.Click();
                }
                if (GetElementTextName(GetThermalModeAutoPerformanceSwitch).Equals("auto switch off"))
                {
                    return true;
                }
            }
            return false;
        }

        public bool SetThermalModeAutoAdjustCheckbox(WindowsElement windowsElement, ToggleState toggleState)
        {
            if (!GetCheckBoxStatus(windowsElement).Equals(toggleState))
            {
                windowsElement.Click();
            }
            if (GetCheckBoxStatus(windowsElement).Equals(toggleState))
            {
                return true;
            }
            return false;
        }

        public ToggleState GetEnableOCStatusInThermalModeSettings()
        {
            return GetCheckBoxStatus(EnableOCCheckboxElement);
        }

        public ToggleState GetAutoAdjustStatusInThermalModeSettings()
        {
            return GetCheckBoxStatus(GetThermalModeAutoAdjustCheckBox);
        }

        public string GetCPUOCValue(string key)
        {
            if (!File.Exists(_xtuJsonPath))
            {
                return string.Empty;
            }
            StreamReader file = File.OpenText(_xtuJsonPath);
            JsonTextReader reader = new JsonTextReader(file);
            JObject jsonObject = (JObject)JToken.ReadFrom(reader);
            JArray parent = (JArray)jsonObject.GetValue("CPUOverClock");
            JEnumerable<JToken> jTokens = parent.Children();
            foreach (JToken jToken in jTokens)
            {
                JObject jObject = (JObject)jToken;
                JToken objectValue = jObject.GetValue(key, StringComparison.CurrentCultureIgnoreCase);
                if (objectValue != null)
                {
                    return objectValue.ToString();
                }
            }

            return string.Empty;
        }

        public string RunXtuTool()
        {
            if (!File.Exists(_overclockToolDestPath))
            {
                File.Copy(_overclockToolSourcePath, _overclockToolDestPath, true);
            }
            string cmd = string.Format(_overclockToolDestPath + @" --gtest_filter=*.GetOverClockValue > " + _gpuJsonPath);
            CommandBase.RunCmd(cmd);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Common.KillProcess("googleTest", true);
            string output = File.ReadAllText(_gpuJsonPath);
            return output;
        }

        public string GetGPUOCValue(int tryTimes = 5, string gpuValueStr = "graphic offset")
        {
            string failedMsg = "API call failed with error";
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string output = RunXtuTool();
            string[] lines = new string[] { };
            for (int i = 0; i < tryTimes; i++)
            {
                if (output.Contains(failedMsg))
                {
                    output = RunXtuTool();
                }
                else
                {
                    lines = output.Split(new string[] { "\r\n" }, StringSplitOptions.None);
                    break;
                }
            }

            foreach (string line in lines)
            {
                if (line.Contains("graphic offset"))
                {
                    string[] gpuValue = line.Split(':');
                    if (gpuValueStr.Equals("memory offset"))
                    {
                        //memory offset:200000 graphic offset:100000
                        string memoryOffset = gpuValue[1].Split(' ')[0];
                        return memoryOffset;
                    }
                    else
                    {
                        if (gpuValue.Length > 1)
                        {
                            string graphicOffset = gpuValue[2];
                            return graphicOffset;
                        }
                    }
                }
            }
            return string.Empty;
        }


        public List<OCValueItem> GetOCValueListByFaimlyname(string path)
        {
            string familyName = VantageCommonHelper.GetCurrentMachineType();
            string jsonString = File.ReadAllText(path);
            var cpuOCRoot = Utility.JsonSerializerClass.Deserialize<OCListRoot>(jsonString);
            foreach (var ocItem in cpuOCRoot.GamingOCList)
            {
                if (ocItem.Familyname.ToLower().Equals(familyName.ToLower()))
                {
                    List<OCValueItem> cpuOcList = ocItem.OCValue;
                    return cpuOcList;
                }
            }
            Console.WriteLine("Info: GetOCValueListByFaimlyname(),the familyName not found:" + familyName + " please configure related files," + path);
            return null;
        }

        public bool SupportXtu()
        {
            List<OCValueItem> cpuOcList = GetOCValueListByFaimlyname(CpuOCListPath);
            if (cpuOcList.Count < 2)
            {
                return false;
            }
            return true;
        }

        public Dictionary<string, string> GetXtuOCValueFromXtuTool()
        {
            VantageCommonHelper.RunCmd(VantageConstContent.XtuToolFilePath);
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Common.KillProcess("XtuCLI", true);
            Dictionary<string, string> xtuValues = new Dictionary<string, string>();
            if (File.Exists(_xtuJsonPath))
            {
                var jsonText = File.ReadAllText(_xtuJsonPath);
                JObject jo = JObject.Parse(jsonText);
                JEnumerable<JToken> children = jo.GetValue("CPUOverClock").Children();
                foreach (JToken jToken in children)
                {
                    string xtuOcValeStr = jToken.ToString();
                    string[] xtuOcVales = xtuOcValeStr.Split("{}".ToCharArray())[1].Split(',');
                    if (xtuOcVales.Length < 2)
                    {
                        break;
                    }
                    foreach (string vals in xtuOcVales)
                    {
                        string key = vals.Split(':')[0].Trim().Split('"')[1].ToLower();
                        if (key.StartsWith("core") && key.Length < 10)
                        {
                            string keyName = key.Substring(0, 5);
                            string keyIndex = key.Substring(5, 1);

                            keyIndex = (Convert.ToInt32(keyIndex) + 1).ToString();
                            key = keyName + keyIndex;
                        }
                        string value = vals.Split(':')[1].Trim().Split('"')[1];
                        xtuValues.Add(key, value);
                    }
                }
            }
            return xtuValues;
        }

        public void ScrollScreen(int p0)
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -p0);
            Thread.Sleep(5000);
        }

        public bool MachineIsGaming(string machine)
        {
            if (string.IsNullOrEmpty(machine))
            {
                return false;
            }
            List<string> context = new List<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(_PluginManifestXml);
            string path = "PluginManifest/ApplicabilityFilter";
            XmlNodeList nodelist = xmlDoc.SelectNodes(path);
            foreach (XmlNode node in nodelist)
            {
                foreach (XmlNode child in node.ChildNodes)
                {
                    if (child.Attributes.Count <= 0)
                        continue;
                    if (child.Attributes[0].InnerText == machine && child.InnerText == "true")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public string CheckMachineinfoConsistent()
        {
            string xmlContent = File.ReadAllText(_VantageMachineInfoXml);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            XmlNodeList nodelist = xmlDoc.SelectNodes("MachineInformation/Family");
            string family = nodelist[0].InnerText;
            return family;
        }

        public string CheckVantageConsitent()
        {
            string vantagefamily = GamingHomepageFamily.Text;
            return vantagefamily;
        }

        public bool SetRapidChargeSwitch(ToggleState toggleState)
        {

            if (toggleState.Equals(ToggleState.On))
            {
                if (!GetElementTextName(GetQuickSettingsRapidChargeToggleStatus).Equals("quicksettings repidcharge on"))
                {
                    GetQuickSettingsRapidChargeToggleStatus.Click();
                }
                if (GetElementTextName(GetQuickSettingsRapidChargeToggleStatus).Equals("quicksettings repidcharge on"))
                {
                    return true;
                }
            }
            else if (toggleState.Equals(ToggleState.Off))
            {

                if (!GetElementTextName(GetQuickSettingsRapidChargeToggleStatus).Equals("quicksettings repidcharge off"))
                {
                    GetQuickSettingsRapidChargeToggleStatus.Click();
                }
                if (GetElementTextName(GetQuickSettingsRapidChargeToggleStatus).Equals("quicksettings repidcharge off"))
                {
                    return true;
                }
            }
            return false;
        }
    }
}