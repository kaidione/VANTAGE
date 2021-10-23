using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading;
using System.Xml;

namespace LenovoVantageTest.Pages
{
    public class GamingLightingPages : SettingsBase
    {
        private WindowsDriver<WindowsElement> _session;

        public WindowsElement StyleOffElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_rgb_lighting_profile0']");
        public WindowsElement Style1Element => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_rgb_lighting_profile1']");
        public WindowsElement Style2Element => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_rgb_lighting_profile2']");
        public WindowsElement Style3Element => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_rgb_lighting_profile3']");
        public WindowsElement StyleOffElementHomepage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile0']");
        public WindowsElement Style1ElementHomepage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile1']");
        public WindowsElement Style2ElementHomepage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile2']");
        public WindowsElement Style3ElementHomepage => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile3']");

        public WindowsElement CustomizeElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_customize_gear']", 30, 30);
        //lightingcustomize-header-title
        public WindowsElement LightingcustomizeTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='lightingcustomize-header-title']");

        //"gaming_lighting_right_arrow_clickable"
        public WindowsElement GamingLightingRightArrow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_right_arrow_clickable']");
        public WindowsElement GamingLightingLeftArrow => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_left_arrow_clickable']");
        public WindowsElement GamingLightingRightArrowGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_right_arrow_unclickable']");
        public WindowsElement GamingLightingLeftArrowGrey => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_left_arrow_unclickable']");

        private string _block1Id = "gaming_lighting_selection_area_legion_icon_lighting_(front)";
        private string _block2Id = "gaming_lighting_selection_area_internal_ambient_lighting";
        private string _block3Id = "gaming_lighting_selection_area_legion_liquid_cooling_pump_lighting";
        private string _block4Id = "gaming_lighting_selection_area_legion_rear_fan_lighting";
        private string _block5Id = "gaming_lighting_selection_area_legion_front_fan_lighting";
        private string _block6Id = "gaming_lighting_selection_area_legion_liquid_cooling_fan_lighting";

        public string Block1Name = "1/6 Legion Icon Lighting (Front)";
        public string Block2Name = "2/6 Internal Ambient Lighting";
        public string Block3Name = "3/6 Legion CPU Fan Lighting";
        public string Block4Name = "4/6 Legion Rear Fan Lighting";
        public string Block5Name = "5/6 Legion Front fan Lighting";
        public string Block6Name = "6/6 Legion Top Fan Lighting";


        public WindowsElement LegionIconLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block1Id));
        public WindowsElement InternalAmbientLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block2Id));
        public WindowsElement LegionCPUFanLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block3Id));
        public WindowsElement LegionRearFanLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block4Id));
        public WindowsElement LegionFrontfanLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block5Id));
        public WindowsElement LegionTopFanLightingElement => base.FindElementByTimes(session, "XPath", string.Format("//*[@AutomationId='{0}']", _block6Id));
        public WindowsElement LightingSectionHomepageElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_lighting_desktop_Image']");
        public WindowsElement LightingProfileOffHomepageElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile0']");
        public WindowsElement LightingProfile1HomepageElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile1']");
        public WindowsElement LightingProfile2HomepageElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile2']");
        public WindowsElement LightingProfile3HomepageElement => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='gaming_dashboard_lighting_profile3']");
        public WindowsElement LightingSetToDefaultElement => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_setdefault_profile')]");

        // "gaming_lighting_effect_drop_menu"
        public WindowsElement LightingEffectDropMenu => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_effect_drop_menu')]");
        public WindowsElement LightingEffectText => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_effect_text')]");

        public string LightingEffectAutomationId = string.Empty;
        public WindowsElement LightingEffectElement
        {

            get
            {
                if (LightingEffectAutomationId == "Off")
                {
                    return base.FindElementByTimes(_session, "XPath", string.Format("//*[@AutomationId='lighting_effect_off']"));
                }
                return base.FindElementByTimes(_session, "XPath", string.Format("//*[@Name='{0}']", LightingEffectAutomationId));
            }
        }

        public static string LighingBlockTypeFile = Path.Combine(VantageConstContent.DataPath, "Data\\NerveCenterDocument\\LighingBlockType.json");

        public string LighingLogFile = "logfile-leddtsettingsmodule";

        public WindowsElement CurrentGamingLightingSelectionArea => base.FindElementByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_selection_area')]", 30, 50);

        public string CurrentLightingSelectionAreaText = string.Empty;
        public WindowsElement CurrentGamingLightingSelectionAreaText => base.FindElementByTimes(_session, "XPath", string.Format("//*[@Name='{0}']", CurrentLightingSelectionAreaText), 30, 50);


        public string BrightnessLevel = string.Empty;
        public WindowsElement BrightnessLevelElement => base.FindElementByTimes(_session, "XPath", string.Format("//*[@AutomationId='gaming_lighting_brightnesslevel{0}']", BrightnessLevel));
        public WindowsElement BrightnessText => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='gaming_lighting_speed_text']");
        public string SpeedLevel = string.Empty;
        public WindowsElement SpeedLevelElement => base.FindElementByTimes(_session, "XPath", string.Format("//*[@AutomationId='gaming_lighting_speedlevel{0}']", SpeedLevel));
        public WindowsElement SpeedLevelText => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='gaming_lighting_color_text']");
        public WindowsElement ColorBtnElement => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='colorBtn']");
        public WindowsElement ColorText => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='gaming_lighting_color_text']");
        public WindowsElement ColorBtnAdvanceElement => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='gaming_lighting_color_picker_icon_advanced']");

        public List<WindowsElement> LightingColorsNumber => base.FindElementsByTimes(_session, "XPath", "//*[@LocalizedControlType='number']");

        // CANCEL
        public WindowsElement ColorCancelBtn => base.FindElementByTimes(_session, "XPath", "//*[@Name='CANCEL']");
        //gaming_lighting_color_picker_color_
        public List<WindowsElement> AllGamingLightingColors => base.FindElementsByTimes(_session, "XPath", "//*[contains(@AutomationId, 'gaming_lighting_color_picker_color_')]");

        public WindowsElement InstallButton => base.FindElementByTimes(_session, "XPath", "//*[@AutomationId='gaming_lighting_gpu_driver_install_button']");

        private List<string> _proProcess = new List<string> { "Microsoft WWA Host", "Lenovo.Modern.ImController", "Microsoft Visual Studio 2019", "Lenovo.Modern.ImController.PluginHost", "LenovoVantageService" };

        //Pluginxml
        public string _PluginManifestXml = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoGamingSystemPlugin\PluginManifest.xml";
        public string _VantageMachineInfoXml = @"C:\ProgramData\Lenovo\ImController\Shared\MachineInformation.xml";

        public GamingLightingPages(WindowsDriver<WindowsElement> session)
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

        public int SelectBock(string p0)
        {
            WindowsElement currentSelectionArea = CurrentGamingLightingSelectionArea;

            string currentSelectionAreaText = ShowTextbox(currentSelectionArea);
            int currentBlockId = Convert.ToInt32(currentSelectionAreaText.ToCharArray()[0]) - 49;
            int expectBlockId = Convert.ToInt32(p0.ToCharArray()[0]) - 49;
            if (p0.Equals(currentSelectionAreaText))
            {
                return currentBlockId;
            }
            else
            {
                int DValue = expectBlockId - currentBlockId;
                if (DValue > 0)
                {
                    for (int i = 0; i < DValue; i++)
                    {
                        GamingLightingRightArrow.Click();
                        Thread.Sleep(500);
                    }
                }
                else
                {
                    for (int i = 0; i > DValue; i--)
                    {
                        GamingLightingLeftArrow.Click();
                        Thread.Sleep(500);
                    }
                }
            }

            return expectBlockId;
        }


        public static LightingBlockIdTypeItem GetLightingBlockIdTypeItem()
        {
            LightingBlockIdTypeRoot gamingLighting = new LightingBlockIdTypeRoot();
            string jsonString = File.ReadAllText(LighingBlockTypeFile);
            gamingLighting = JsonSerializerClass.JsonDeserialize<LightingBlockIdTypeRoot>(jsonString);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            LightingBlockIdTypeItem lightingBlockIdType = gamingLighting.LightingBlockIdType.Find(item => item.Familyname == familyname);
            return lightingBlockIdType;
        }

        public string GetXMLFilesPath(DirectoryInfo directories)
        {
            string profileXMLPath = directories.FullName;
            FileInfo[] files = directories.GetFiles();
            foreach (FileInfo fi in files)
            {
                if (fi.FullName.Contains("GZLedProfile"))
                {
                    return fi.FullName;
                }
            }
            DirectoryInfo[] directoriesmore = directories.GetDirectories();
            foreach (DirectoryInfo d in directoriesmore)
            {
                profileXMLPath = GetXMLFilesPath(d);
            }
            return profileXMLPath;
        }

        public LedProfileList GetLedProfileListFromLocal()
        {
            string ledProfilePath = @"C:\ProgramData\Lenovo\ImController\SystemPluginData\LenovoGamingSystemPlugin\data\ledprofile";
            string ledProfileXMLPath = string.Empty;
            if (Directory.Exists(ledProfilePath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(ledProfilePath);
                ledProfileXMLPath = GetXMLFilesPath(directoryInfo);
            }
            if (ledProfileXMLPath != null)
            {
                string jsonString = File.ReadAllText(ledProfileXMLPath);
                FileInfo fileInfo = new FileInfo(ledProfileXMLPath);

                if (fileInfo.Extension.Equals(".json"))
                {
                    if (!string.IsNullOrEmpty(jsonString))
                    {
                        //{"block":1,"brightness":3,"colorid":1412573,"speed":2,"type":4},
                        jsonString = jsonString.Replace("_", "").Replace("k\":", "k\":\"").
                            Replace(",\"b", "\",\"b").Replace("s\":", "s\":\"").Replace(",\"c", "\",\"c")
                            .Replace("d\":", "d\":\"").Replace(",\"s", "\",\"s")
                            .Replace(",\"t", "\",\"t").Replace("e\":", "e\":\"").Replace("},", "\"},")
                            .Replace("}]\",", "}],").Replace("}],\"s", "\"}],\"s").Replace("}]}", "\"}]}");
                        ;
                    }
                }
                else
                {
                    jsonString = jsonString.Replace("<?xml version=\"1.0\" encoding=\"UTF-8\"?>\r\n", "").Replace("{\"item\":", "");
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(jsonString.ToLower());
                    string json = Newtonsoft.Json.JsonConvert.SerializeXmlNode(doc);
                    json = json.Replace("{\"item\":", "").Replace("{\"ledprofilelist\":", "").Replace("}]},", "}],").Replace("}]}}}", "}]}").Replace("brigness", "brightness");
                    jsonString = json;
                }
                //System.Text.Json.
                return JsonSerializer.Deserialize<LedProfileList>(jsonString.ToLower());


            }
            return null;
        }


        // 比较Type变化的值(New Type And Old Type) changed = true  代表其他block 和新的 Type 一致
        // 比较Type变化的值(New Type And Old Type) changed = false 代表之前block 和旧的 Type 一致
        public List<int> GetLightingColorId()
        {
            LightingBlockIdTypeRoot gamingLighting = new LightingBlockIdTypeRoot();
            string jsonString = File.ReadAllText(LighingBlockTypeFile);
            gamingLighting = JsonSerializerClass.JsonDeserialize<LightingBlockIdTypeRoot>(jsonString);
            return gamingLighting?.colorid;
        }

        private string GetTypeValueFromLog(List<string> AutomationNewLogList, string blockIdStr)
        {
            string typeValue = string.Empty;
            foreach (string lightingLog in AutomationNewLogList)
            {
                string[] logs = lightingLog.Split(':');
                int length = logs.Length;
                if (length > 0)
                {
                    string lightingLogs = logs[length - 1];
                    string[] items = lightingLogs.Split(' ');
                    //SetSimpleLighting block=2 type=2 color=1412573 speed=2 brightness=3 result=Done
                    if (items.Length > 1)
                    {
                        if (items[1].Split('=')[1] == blockIdStr)
                        {
                            typeValue = items[2].Split('=')[1].Trim();
                        }
                    }
                }
            }
            return typeValue;
        }

        public bool LightingComparsionXMLAndLog(List<LightingItem> newXMLLightingStyle,
            List<LightingItem> oldCompareLightingStyle, bool changed, string oldReadFormLogStr,
            string selectCompareValue, string selectLightingTypeName, string selectBlockId)
        {
            // Gaming 设置type值,根据 Profile , Blockid 获取保存在系统当前的值
            List<string> typeStrs = new List<string>();
            string compreValue = string.Empty;
            string lightingTypeValue = string.Empty;

            string lightingLogFile = Common.FindIMCLog(LighingLogFile);
            // AutomationLog::SetSimpleLighting  
            if (string.IsNullOrEmpty(lightingLogFile))
            {
                return false;
            }

            string[] lightingLog = File.ReadAllText(lightingLogFile).Split('\n');
            string[] oldLightingType = oldReadFormLogStr.Split('\n');

            List<string> AutomationNewLogList = new List<string>();

            List<string> AutomationOldLogList = new List<string>();


            if (selectLightingTypeName.Contains(" "))
            {
                int firstSpace = selectLightingTypeName.IndexOf(' ');
                selectLightingTypeName = selectLightingTypeName.Substring(firstSpace).Trim();
            }
            string simgpleLightings = string.Empty;
            if (GamingMachineListPage.GamingLightingTypesList.ContainsKey(selectLightingTypeName))
            {
                GamingMachineListPage.GamingLightingTypesList.TryGetValue(selectLightingTypeName,
                    out simgpleLightings);
            }

            foreach (string log in lightingLog)
            {
                if (log.Contains("AutomationLog"))
                {
                    if (string.IsNullOrEmpty(simgpleLightings))
                    {
                        continue;
                    }
                    string[] simpleLightingType = simgpleLightings.Split(',');
                    bool automationLogFlag = false;
                    if (log.Contains(simpleLightingType[0]))
                    {
                        automationLogFlag = true;
                    }
                    else if (log.Contains(simpleLightingType[1]) && !automationLogFlag)
                    {
                        automationLogFlag = true;
                    }

                    if (automationLogFlag)
                    {
                        AutomationNewLogList.Add(log);
                    }
                }
            }

            foreach (string log in oldLightingType)
            {
                if (log.Contains("AutomationLog"))
                {
                    string[] simpleLightingType = simgpleLightings.Split(',');
                    bool automationLogFlag = false;
                    if (log.Contains(simpleLightingType[0]))
                    {
                        automationLogFlag = true;
                    }
                    else if (log.Contains(simpleLightingType[1]) && !automationLogFlag)
                    {
                        automationLogFlag = true;
                    }
                    if (automationLogFlag)
                    {
                        AutomationOldLogList.Add(log);
                    }
                }
            }

            // json file read Current Block Id

            if (changed)
            {
                int index = 0;
                if (NerveCenterHelper.GetMachineThermalModeValue("IsSupportLightingFeature") >= 23)
                {
                    index = 1;
                }
                for (int i = 0; i < GamingMachineListPage.GamingLightingEffectChangedList.Count; i++)
                {
                    string blockIdStr = GamingMachineListPage.GamingLightingEffectChangedList[i].Split(new char[] { '/' })[index];
                    // 改变当前block的type,检查其他block的type和新值相同 xml
                    LightingItem lightingItem1 = newXMLLightingStyle.Find(item => item.block.Equals(blockIdStr));
                    if (lightingItem1 == null) continue;
                    typeStrs.Add(blockIdStr);
                    if (lightingItem1.type != selectCompareValue)
                    {
                        return false;
                    }
                    // 比较 Log 的值 改变的和新值 相同.
                    string automationNewLogType = GetTypeValueFromLog(AutomationNewLogList, blockIdStr);
                    if (!automationNewLogType.Equals(selectCompareValue))
                    {
                        return false;
                    }
                }
            }

            // 其他值不变 除去选中 的值
            for (int j = 0; j < newXMLLightingStyle.Count; j++)
            {
                string blockId = newXMLLightingStyle[j].block;
                if (typeStrs.Contains(blockId) || blockId.Equals(selectBlockId)) continue;

                LightingItem findBlockId = oldCompareLightingStyle.Find(item => item.block.Equals(blockId));
                LightingItem lightingItem1 = newXMLLightingStyle.Find(item => item.block.Equals(blockId));

                if (lightingItem1.type != findBlockId.type)
                {
                    return false;
                }

                string automationNewLogType = GetTypeValueFromLog(AutomationNewLogList, blockId);
                string automationOldLogType = GetTypeValueFromLog(AutomationOldLogList, blockId);

                if (!automationOldLogType.Equals(automationNewLogType))
                {
                    return false;
                }
            }

            return true;

        }

        public bool LightingComparisonBaseFile(int profile, int blockId, string typeName,
            LightingBlockIdTypeItem lightingBlockIdType, string compareName,
            out LightingItem compareLightingItem, out string selectCompreValue, out int blockValueStr,
            out List<LightingItem> compareLightingStyle, bool isCompareColor = false, string compareColorValue = "")
        {
            //根据保存的文件，

            Thread.Sleep(2000);
            // Gaming 设置值,根据 Profile , Blockid 获取保存在系统当前的值
            LedProfileList lightingSetXmlFile = GetLedProfileListFromLocal();
            List<LightingItem> lightingStyle = lightingSetXmlFile.style1;

            LightingItem lightingItem = null;
            string compreValue = string.Empty;
            string lightingTypeValue = string.Empty;
            switch (profile)
            {
                case 2:
                    lightingStyle = lightingSetXmlFile.style2;
                    break;
                case 3:
                    lightingStyle = lightingSetXmlFile.style3;
                    break;
            }

            compareLightingStyle = lightingStyle;
            int blockValue = lightingBlockIdType.Blockid[blockId];
            if (typeName.Contains(" ") || typeName.Contains("_"))
            {
                typeName = typeName.Replace(" ", "");
                typeName = typeName.Replace("_", "");
            }


            if (isCompareColor)
            {
                lightingItem = lightingStyle.Find(item => item.block == blockValue.ToString());
                compreValue = lightingItem.GetValue(compareName).ToString();
                lightingTypeValue = compareColorValue;
            }
            else
            {
                lightingTypeValue = lightingBlockIdType.Type.GetValue(typeName).ToString();
                lightingItem = lightingStyle.Find(item => item.block == blockValue.ToString());
                compreValue = lightingItem.GetValue(compareName).ToString();
            }
            selectCompreValue = compreValue;
            compareLightingItem = lightingItem;
            blockValueStr = blockValue;

            return lightingTypeValue == compreValue;
        }

        public string ReadFormLog()
        {
            string lightingLogFile = Common.FindIMCLog(LighingLogFile);
            // AutomationLog::SetSimpleLighting  
            if (string.IsNullOrEmpty(lightingLogFile))
            {
                return string.Empty;
            }
            return File.ReadAllText(lightingLogFile);
        }

        public bool ReadFormLogGenerate(LightingItem lightingItem, string selectLightingBlockName,
            string typeName)
        {
            Thread.Sleep(3000);
            string lightingLogFile = Common.FindIMCLog(LighingLogFile);
            // AutomationLog::SetSimpleLighting  
            if (string.IsNullOrEmpty(lightingLogFile))
            {
                return false;
            }
            string[] lightingLog = File.ReadAllText(lightingLogFile).Split('\n');
            string simgpleLighting = string.Empty;

            if (selectLightingBlockName.Contains(" "))
            {
                int firstSpace = selectLightingBlockName.IndexOf(' ');
                selectLightingBlockName = selectLightingBlockName.Substring(firstSpace).Trim();
            }

            if (GamingMachineListPage.GamingLightingTypesList.ContainsKey(selectLightingBlockName))
            {
                GamingMachineListPage.GamingLightingTypesList.TryGetValue(selectLightingBlockName, out simgpleLighting);
            }
            List<string> AutomationNewLogList = new List<string>();

            foreach (string log in lightingLog)
            {
                if (log.Contains("AutomationLog"))
                {
                    string[] simpleLightingType = simgpleLighting.Split(',');
                    bool automationLogFlag = false;
                    if (log.Contains(simpleLightingType[0]))
                    {
                        automationLogFlag = true;
                    }
                    else if (simgpleLighting.Contains(",") && !automationLogFlag)
                    {
                        if (log.Contains(simpleLightingType[1]))
                        {
                            automationLogFlag = true;
                        }
                    }
                    if (automationLogFlag)
                    {
                        AutomationNewLogList.Add(log);
                    }
                }
            }
            foreach (string log in AutomationNewLogList)
            {
                string[] logs = log.Split(':');
                int length = logs.Length;
                if (length > 0)
                {
                    string lightingLogs = logs[length - 1];
                    string[] items = lightingLogs.Split(' ');
                    //SetSimpleLighting block=2 type=2 color=1412573 speed=2 brightness=3 result=Done
                    if (items.Length > 1)
                    {
                        if (items[1].Split('=')[1] == lightingItem.block.ToString())
                        {
                            if (typeName.Trim().Equals("CPU Temperature"))
                            {
                                lightingItem.colorid = "255";
                            }
                            if (items[2].Split('=')[1].Trim() == lightingItem.type.ToString() && items[3].Split('=')[1].Trim() == lightingItem.colorid.ToString() &&
                                items[4].Split('=')[1].Trim() == lightingItem.speed.ToString() && items[5].Split('=')[1].Trim() == lightingItem.brightness.ToString())
                            {
                                return true;
                            }
                        }
                    }
                }
            }

            return false;
        }

        public bool LightingSppedBrignessComparison(int profile, int blockId, string typeName, LightingBlockIdTypeItem lightingBlockIdType, string comparsionValue)
        {
            //根据保存的文件
            // Gaming 设置值,根据 Profile , Blockid 获取保存在系统当前的值
            LedProfileList lightingSetFile = GetLedProfileListFromLocal();
            List<LightingItem> lightingStyle = lightingSetFile.style1;
            switch (profile)
            {
                case 2:
                    lightingStyle = lightingSetFile.style2;
                    break;

                case 3:
                    lightingStyle = lightingSetFile.style3;
                    break;
            }

            int blockValue = lightingBlockIdType.Blockid[blockId];
            LightingItem lightingItem = lightingStyle.Find(item => item.block == blockValue.ToString());
            string fileValue = lightingItem.GetValue(typeName).ToString();
            return comparsionValue.Equals(fileValue);
        }

        public List<LightingItem> LightingDistinctItem(List<LightingItem> oldList, List<LightingItem> newList)
        {
            List<LightingItem> listNew = new List<LightingItem>();
            foreach (LightingItem item in newList)
            {
                if (oldList.Find(e => e.block == item.block && e.brightness == item.brightness && e.colorid == item.colorid && e.speed == item.speed && e.type == item.type) == null)
                {
                    listNew.Add(item);
                }
            }
            return listNew;
        }

        public bool StyleItemsCompartion(LightingStyle oldItem, LightingStyle newItem)
        {

            PropertyInfo[] propertyInfos = newItem.GetType().GetProperties();
            for (int i = 0; i < oldItem.item.Count; i++)
            {
                foreach (PropertyInfo pi in propertyInfos)
                {
                    string newItemValue = newItem.item[0].GetValue(pi.Name).ToString();
                    string oldItemValue = oldItem.item[0].GetValue(pi.Name).ToString();
                    if (!newItemValue.Equals(oldItemValue))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool LightingItemCompartion(LightingItem oldItem, LightingItem newItem, string compartionName)
        {
            PropertyInfo[] propertyInfos = newItem.GetType().GetProperties();
            foreach (PropertyInfo pi in propertyInfos)
            {
                string newItemValue = newItem.GetValue(pi.Name).ToString();
                string oldItemValue = oldItem.GetValue(pi.Name).ToString();
                if (pi.Name != compartionName)
                {
                    if (!newItemValue.Equals(oldItemValue))
                    {
                        return false;
                    }
                }
                else
                {
                    if (newItemValue.Equals(oldItemValue))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="profile"></param>
        /// <param name="blockId"></param>
        /// <param name="typeName"></param>
        /// <param name="oldLightingType">设置之前的值</param>
        /// <returns></returns>
        public bool LightingComparisonLocalFile(int profile, int blockId, LightingBlockIdTypeItem lightingBlockIdType, string typeName,
            LedProfileList oldLightingType, bool changed = false)
        {
            LedProfileList newLightingType = GetLedProfileListFromLocal();
            int blockValue = lightingBlockIdType.Blockid[blockId];


            switch (profile)
            {
                case 1:
                    List<LightingItem> style2List = LightingDistinctItem(oldLightingType.style2, newLightingType.style2);
                    List<LightingItem> style3List = LightingDistinctItem(oldLightingType.style3, newLightingType.style3);

                    if (style2List.Count != 0 || style3List.Count != 0)
                    {
                        return false;
                    }

                    List<LightingItem> listNew = LightingDistinctItem(oldLightingType.style1, newLightingType.style1);
                    List<LightingItem> listOld = LightingDistinctItem(newLightingType.style1, oldLightingType.style1);

                    if (listNew.Count == 0 && listOld.Count == 0)
                    {
                        return true;
                    }

                    if (listNew.Count > 0 && listOld.Count > 0 && listNew[0].block == blockValue.ToString() && listOld[0].block == blockValue.ToString())
                    {
                        return true;
                    }
                    break;

                case 2:

                    List<LightingItem> style1List = LightingDistinctItem(oldLightingType.style1, newLightingType.style1);

                    style3List = LightingDistinctItem(oldLightingType.style3, newLightingType.style3);

                    if (style1List.Count != 0 || style3List.Count != 0)
                    {
                        return false;
                    }


                    listNew = LightingDistinctItem(oldLightingType.style2, newLightingType.style2);
                    listOld = LightingDistinctItem(newLightingType.style2, oldLightingType.style2);

                    if (listNew.Count == 0 && listOld.Count == 0)
                    {
                        return true;
                    }

                    if (listNew.Count == 1 && listOld.Count == 1 && listNew[0].block == blockValue.ToString() && listOld[0].block == blockValue.ToString())
                    {
                        return true;
                    }
                    break;

                case 3:

                    style1List = LightingDistinctItem(oldLightingType.style1, newLightingType.style1);

                    style2List = LightingDistinctItem(oldLightingType.style2, newLightingType.style2);

                    if (style2List.Count != 0 || style1List.Count != 0)
                    {
                        return false;
                    }

                    listNew = LightingDistinctItem(oldLightingType.style3, newLightingType.style3);
                    listOld = LightingDistinctItem(newLightingType.style3, oldLightingType.style3);

                    if (listNew.Count == 0 && listOld.Count == 0)
                    {
                        return true;
                    }

                    break;
            }

            return false;

        }

        public string GetSelectedColorValue(out int selectColorId)
        {
            ColorBtnElement.Click();
            string colorValue = string.Empty;
            int i = 0;
            bool haveColor = false;
            if (AllGamingLightingColors != null && AllGamingLightingColors.Count > 0)
            {
                foreach (WindowsElement item in AllGamingLightingColors)
                {
                    if (ShowTextbox(item).Contains("unSelected"))
                    {
                        i++;
                        continue;
                    }
                    else
                    {
                        haveColor = true;
                        break;
                    }
                }
            }

            ColorBtnAdvanceElement.Click();

            if (LightingColorsNumber != null && LightingColorsNumber.Count > 0)
            {
                foreach (WindowsElement item in LightingColorsNumber)
                {
                    colorValue += item.Text.Trim().Replace("\r\n", "") + ",";
                }
            }
            if (colorValue.Length > 0)
            {
                colorValue = colorValue.Substring(0, colorValue.Length - 1);
            }

            ColorCancelBtn.Click();
            if (haveColor)
            {

                selectColorId = i;
            }
            else
            {

                selectColorId = 30;
            }

            return colorValue;
        }



        public bool CompareBaseFileLogXml(int profileIndex, int blockIndex, string selectType, LightingBlockIdTypeItem lightingBlockIdType, string compareName, LedProfileList originalLedProfileList, string selectLightingTypeName)
        {

            LightingItem compareLightingItem;
            string selectCompreValue;
            List<LightingItem> compareLightingStyle;
            int blockValue;
            bool compareBaseFile = LightingComparisonBaseFile(profileIndex, blockIndex, selectType,
                lightingBlockIdType, compareName, out compareLightingItem,
                out selectCompreValue, out blockValue, out compareLightingStyle);

            bool compareDeveloperLog = ReadFormLogGenerate(compareLightingItem, selectLightingTypeName, selectType);

            bool compareLightingXmlFile = LightingComparisonLocalFile(profileIndex, blockIndex, lightingBlockIdType, compareName, originalLedProfileList);

            return compareBaseFile && compareDeveloperLog && compareLightingXmlFile;
        }

        public bool CompareColorBaseFileLogXml(int profileIndex, int blockIndex, LightingBlockIdTypeItem lightingBlockIdType, LedProfileList originalLedProfileList, string compareColorValue, string selectLightingTypeName)
        {

            LightingItem compareLightingItem;
            string selectCompreValue;

            List<LightingItem> compareLightingStyle;
            int blockValue;

            bool compareBaseFile = LightingComparisonBaseFile(profileIndex, blockIndex, "", lightingBlockIdType, "lightingColorid", out compareLightingItem,
                out selectCompreValue, out blockValue, out compareLightingStyle, true, compareColorValue);

            bool compareDeveloperLog = ReadFormLogGenerate(compareLightingItem, selectLightingTypeName, "Colorid");

            bool compareLightingXmlFile = LightingComparisonLocalFile(profileIndex, blockIndex, lightingBlockIdType, "lightingColorid", originalLedProfileList);

            return compareBaseFile && compareDeveloperLog && compareLightingXmlFile;
        }

    }
}
