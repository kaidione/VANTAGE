using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;

namespace LenovoVantageTest.Helper
{
    /// <summary>
    /// 用于存放NerveCenter 公用方法
    /// </summary>
    public class NerveCenterHelper
    {
        //Gaming Mchine Config
        public static string NerveCenterConfigFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\GamingMachineConfig.xml"); //@"C:\NerveCenterDocument\GamingMachineConfig.xml";
        public static string NerveCenterConfigFileCopy = @"C:\NerveCenterDocument\GamingMachineConfig.xml";   //Auto Script read file path
        public static string NerveCenterConfigPath = @"C:\NerveCenterDocument";

        public static string NerveCenterGamingAppIniFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\NerveCenterGamingApp.ini");
        public static string NerveCenterGamingAppIniFileCopy = @"C:\NerveCenterDocument\NerveCenterGamingApp.ini";
        //Gaming Mchine Registry
        public static string GamingMachineRegeditPath = @"Software\Wow6432Node\Lenovo\ImController\Applicability\Tags";
        public static string GamingMachineRegeditKey = "System.Profile.Gaming";
        private const string _driverDesc = "DriverDesc";
        private const string _driverRegeditPath = "SYSTEM\\CurrentControlSet\\Control\\Class\\{4d36e97d-e325-11ce-bfc1-08002be10318}";

        //Gaming Game run statte
        public static string GameRunningRegeditPath = @"SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Event\GameDetectHelperPlugin\GameStartEvent";
        public static string GameRunningRegeditKey = "GameRunningState";

        //Gaming common app ini
        public static string NerveCenterAppRunListIniFile = @"C:\NerveCenterAppRunList.ini";//Path.Combine(VantageConstContent.DataPath, @"Data\NerveCenterAppRunList.ini");

        public static string GPUSpecIniFile = Path.Combine(VantageConstContent.DataPath, @"Data\NerveCenterDocument\GPUSpec.ini");

        //Gaming Overclock machine list
        public static string[] GPUCPUGamingMachineList = { "Legion S7 15IMH05", "Legion S7 15IMH5", "Legion Y9000X 2021", "Legion Y9000K2020H", "Legion Y9000K 2020", "Legion 7 15IMH05", "Legion 7 15IMHg05", "ZHENGJIUZHE REN9000-34IMZ", "ZHENGJIUZHE REN9000K-34IMZ", "Legion T7 34IMZ05", "Legion T7 34IMZ5" };

        public static string[] GPUGamingMachineList = { "Legion T5-28IMB05", "Legion 5 15IMH05H","Legion Y7000 2020H","Legion 5 15IMH05","Legion Y7000 2020","Legion 5P 15IMH05H","Legion Y7000P2020H","Legion 5P 15IMH05","Legion Y7000P2020","Legion 5 17IMH05H","Legion 5 17IMH05","Legion 5 15IMH05H","Legion 5 15ARH05","Legion R7000 2020",
                            "Legion 5 15ARH05H","Legion 5P 15ARH05H","Legion R7000P2020H","Legion 5 17ARH05H","Legion R5 28IMB05","Legion T5 28IMB05","ZHENGJIUZHE REN7000-28IMB","Legion T5 28ICB05","Legion S7 15ARH5","Legion R9000X 2021","Legion T5 26AMR5","Legion T5 26AMR5","Legion REN7000P-26AMR"};

        public static string[] NotSupportOverclockGamingMachineList = { "Legion Y740S-15IMH", "Legion Y9000X2020R", "IdeaPad Gaming 3 15IMH05", "IdeaPad Creator 5 15IMH05", "IdeaPad Gaming 3 15ARH05", "IdeaCentre GeekPro-14IMB", "IdeaCentre G5 14IMB05", "IdeaCentre GeekPro-14AMR", "IdeaCentre G5 14AMR05" };

        public static string[] ThermalModeOnlyTwoModeGamingMachineList = { "IdeaCentre GeekPro-14IMB", "IdeaCentre G5 14IMB05", "IdeaCentre GeekPro-14AMR", "IdeaCentre G5 14AMR05" };

        public static string CPUFrequencyTools = Path.Combine(VantageConstContent.DataPath, @"Data\NerveCenterDocument\HardwareInfoPluginTest.exe");

        #region Get Gaming Machine

        /// <summary>Get Gaming Machine</summary>
        /// <returns>false : Not Gaming Machine</returns>
        public static bool GetMachineIsGaming()
        {
            string value = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(GamingMachineRegeditKey, GamingMachineRegeditPath);
            if (!string.IsNullOrEmpty(value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Get Game Running State

        /// <summary>Get Game Running State</summary>
        /// <returns>true: isRunning/false: not run</returns>
        public static bool GetGameRunningState()
        {
            string value = IntelligentCoolingBaseHelper.GetLocalMachineRegeditValue(GameRunningRegeditKey, GameRunningRegeditPath);
            if (int.Parse(value) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region 机型列表

        public static GamingMachine GetGamingMachineInfo(string machineFamilyName)
        {
            GamingMachine machine = new GamingMachine();
            try
            {
                foreach (GamingMachine m in GetGamingMachineList())
                {
                    if (m.FamilyName.Contains(","))
                    {
                        foreach (var item in m.FamilyName.Split(','))
                        {
                            if (item.Trim().Equals(machineFamilyName))
                            {
                                m.Series = GetGamingMachineSeries(machineFamilyName.Trim());
                                return m;
                            }
                        }
                    }
                    else
                    {
                        if (m.FamilyName.Equals(machineFamilyName))
                        {
                            m.Series = GetGamingMachineSeries(machineFamilyName.Trim());
                            return m;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: GetGamingMachineInfo() \r\n" + ex.ToString());
            }
            return machine;
        }

        public static GamingMachineSeries GetGamingMachineSeries(string machineFamilyName)
        {
            XmlDocument xmldoc = new XmlDocument();
            try
            {
                if (!Directory.Exists(NerveCenterConfigPath))
                {
                    Directory.CreateDirectory(NerveCenterConfigPath);
                }
                if (!File.Exists(NerveCenterConfigFileCopy))
                {
                    File.Copy(NerveCenterConfigFile, NerveCenterConfigFileCopy, true);
                }
                if (File.Exists(NerveCenterConfigFileCopy))
                {
                    xmldoc.Load(NerveCenterConfigFileCopy);
                    XmlNodeList machineSeries = xmldoc.DocumentElement.SelectNodes("//GamingMachineConfig//Filter");
                    foreach (XmlElement node in machineSeries)
                    {
                        switch (node.Attributes["type"].Value.ToLower())
                        {
                            case "x30":
                                if (node.InnerText.ToLower().Contains(machineFamilyName.ToLower()))
                                {
                                    Console.WriteLine("GetGamingMachineSeries() X30,Machine:" + machineFamilyName + "\r\nInfo:" + node.InnerText);
                                    return GamingMachineSeries.X30;
                                }
                                break;
                            case "x40":
                                if (node.InnerText.ToLower().Contains(machineFamilyName.ToLower()))
                                {
                                    Console.WriteLine("GetGamingMachineSeries() X40,Machine:" + machineFamilyName + "\r\nInfo:" + node.InnerText);
                                    return GamingMachineSeries.X40;
                                }
                                break;
                            case "x50":
                                if (node.InnerText.ToLower().Contains(machineFamilyName.ToLower()))
                                {
                                    Console.WriteLine("GetGamingMachineSeries() X50,Machine:" + machineFamilyName + "\r\nInfo:" + node.InnerText);
                                    return GamingMachineSeries.X50;
                                }
                                break;
                            case "x60":
                                if (node.InnerText.ToLower().Contains(machineFamilyName.ToLower()))
                                {
                                    Console.WriteLine("GetGamingMachineSeries() X60,Machine:" + machineFamilyName + "\r\nInfo:" + node.InnerText);
                                    return GamingMachineSeries.X60;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                    return GamingMachineSeries.Unknow;
                }
                else
                {
                    return GamingMachineSeries.Unknow;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: GetGamingMachineSeries() \r\n" + ex.ToString());
                return GamingMachineSeries.Unknow;
            }
        }

        public static List<GamingMachine> GetGamingMachineList()
        {
            List<GamingMachine> machines = new List<GamingMachine>();
            XmlDocument xmldoc = new XmlDocument();
            if (!Directory.Exists(NerveCenterConfigPath))
            {
                Directory.CreateDirectory(NerveCenterConfigPath);
            }
            if (!File.Exists(NerveCenterConfigFileCopy))
            {
                File.Copy(NerveCenterConfigFile, NerveCenterConfigFileCopy, true);
            }
            if (File.Exists(NerveCenterConfigFileCopy))
            {
                xmldoc.Load(NerveCenterConfigFileCopy);
                XmlNodeList machinelist = xmldoc.DocumentElement.SelectNodes("//GamingMachine");
                foreach (XmlElement node in machinelist)
                {
                    GamingMachine machine = new GamingMachine();
                    GamingQuickSettings gamingQuickSettings = new GamingQuickSettings();
                    GamingLegionStatus gamingLegionStatus = new GamingLegionStatus();
                    GamingSystemTools gamingSystemTools = new GamingSystemTools();
                    GamingLegionEdge gamingLegionEdge = new GamingLegionEdge();
                    GamingLighting gamingLighting = new GamingLighting();
                    GamingUITitle gamingUITitle = new GamingUITitle();
                    try
                    {
                        machine.FamilyName = node.FirstChild.InnerText;   // GamingFamilyName
                        machine.Type = node.FirstChild.Attributes["type"].Value;
                        //GamingUITitle
                        gamingUITitle.Title = node.ChildNodes[1].Attributes["title"].Value;
                        gamingUITitle.Support = Convert.ToBoolean(node.ChildNodes[1].Attributes["support"].Value);
                        gamingUITitle.LogoIcon = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[1].FirstChild.Attributes["support"].Value),
                            node.ChildNodes[1].FirstChild.Attributes["value"].Value, node.ChildNodes[1].FirstChild.InnerText);    //YLogo
                        gamingUITitle.HeaderName = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[1].ChildNodes[1].Attributes["support"].Value),
                            node.ChildNodes[1].ChildNodes[1].Attributes["value"].Value, node.ChildNodes[1].ChildNodes[1].InnerText);      //HeaderName
                        gamingUITitle.HelpName = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[1].LastChild.Attributes["support"].Value),
                            node.ChildNodes[1].LastChild.Attributes["value"].Value, node.ChildNodes[1].LastChild.InnerText);      //HelpName
                        gamingUITitle.EdgeName = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[1].ChildNodes[2].Attributes["support"].Value),
                            node.ChildNodes[1].ChildNodes[2].Attributes["value"].Value, node.ChildNodes[1].ChildNodes[2].InnerText);       //EdgeName
                        machine.GamingUITitle = gamingUITitle;
                        //GamingLegionStatus
                        gamingLegionStatus.Title = node.ChildNodes[2].Attributes["title"].Value;
                        gamingLegionStatus.Support = Convert.ToBoolean(node.ChildNodes[2].Attributes["support"].Value);
                        gamingLegionStatus.Priority = node.ChildNodes[2].Attributes["priority"].Value.Split(',').ToList();
                        gamingLegionStatus.GPU = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[2].FirstChild.Attributes["support"].Value),
                            node.ChildNodes[2].FirstChild.Attributes["value"].Value, node.ChildNodes[2].FirstChild.InnerText);     //GPU
                        gamingLegionStatus.CPU = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[2].ChildNodes[1].Attributes["support"].Value),
                            node.ChildNodes[2].ChildNodes[1].Attributes["value"].Value, node.ChildNodes[2].ChildNodes[1].InnerText);     //CPU
                        gamingLegionStatus.RAM = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[2].ChildNodes[2].Attributes["support"].Value),
                            node.ChildNodes[2].ChildNodes[2].Attributes["value"].Value, node.ChildNodes[2].ChildNodes[2].InnerText);     //RAM
                        gamingLegionStatus.DISK = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[2].ChildNodes[3].Attributes["support"].Value),
                            node.ChildNodes[2].ChildNodes[3].Attributes["value"].Value, node.ChildNodes[2].ChildNodes[3].InnerText);   //DISK
                        gamingLegionStatus.INFO = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[2].LastChild.Attributes["support"].Value),
                            node.ChildNodes[2].LastChild.Attributes["value"].Value, node.ChildNodes[2].LastChild.InnerText);   //INFO
                        machine.GamingLegionStatus = gamingLegionStatus;
                        //GamingLegionEdge
                        gamingLegionEdge.Title = node.ChildNodes[3].Attributes["title"].Value;
                        gamingLegionEdge.Support = Convert.ToBoolean(node.ChildNodes[3].Attributes["support"].Value);
                        gamingLegionEdge.Priority = node.ChildNodes[3].Attributes["priority"].Value.Split(',').ToList();
                        gamingLegionEdge.CPUOverclock = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].FirstChild.Attributes["support"].Value),
                            node.ChildNodes[3].FirstChild.Attributes["value"].Value, node.ChildNodes[3].FirstChild.InnerText);   //CPUOverclock
                        gamingLegionEdge.ThermalMode = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[1].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[1].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[1].InnerText);     //ThermalMode
                        gamingLegionEdge.RAMOverclock = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[2].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[2].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[2].InnerText);   //RAMOverclock
                        gamingLegionEdge.NetworkBoost = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[3].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[3].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[3].InnerText);       //NetworkBoost
                        gamingLegionEdge.AutoClose = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[4].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[4].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[4].InnerText);     //AutoClose
                        gamingLegionEdge.HybridMode = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[5].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[5].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[5].InnerText);      //HybridMode
                        gamingLegionEdge.OverDrive = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].ChildNodes[6].Attributes["support"].Value),
                            node.ChildNodes[3].ChildNodes[6].Attributes["value"].Value, node.ChildNodes[3].ChildNodes[6].InnerText);     //OverDrive
                        gamingLegionEdge.TouchpadLock = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[3].LastChild.Attributes["support"].Value),
                            node.ChildNodes[3].LastChild.Attributes["value"].Value, node.ChildNodes[3].LastChild.InnerText);   //TouchpadLock
                        machine.GamingLegionEdge = gamingLegionEdge;
                        //QuickSettings
                        gamingQuickSettings.Title = node.ChildNodes[4].Attributes["title"].Value;
                        gamingQuickSettings.Support = Convert.ToBoolean(node.ChildNodes[4].Attributes["support"].Value);
                        gamingQuickSettings.Priority = node.ChildNodes[4].Attributes["priority"].Value.Split(',').ToList();
                        gamingQuickSettings.ThermalMode = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[4].FirstChild.Attributes["support"].Value),
                            node.ChildNodes[4].FirstChild.Attributes["value"].Value, node.ChildNodes[4].FirstChild.InnerText);       //ThermalMode
                        gamingQuickSettings.RapidCharge = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[4].ChildNodes[1].Attributes["support"].Value),
                             node.ChildNodes[4].ChildNodes[1].Attributes["value"].Value, node.ChildNodes[4].ChildNodes[1].InnerText);      //RapidCharge
                        gamingQuickSettings.WiFiSecurity = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[4].ChildNodes[2].Attributes["support"].Value),
                            node.ChildNodes[4].ChildNodes[2].Attributes["value"].Value, node.ChildNodes[4].ChildNodes[2].InnerText);       //WiFiSecurity
                        gamingQuickSettings.Dolby = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[4].LastChild.Attributes["support"].Value),
                            node.ChildNodes[4].LastChild.Attributes["value"].Value, node.ChildNodes[4].LastChild.InnerText); //Dolby
                        machine.GamingQuickSettings = gamingQuickSettings;
                        //GamingSystemTools
                        gamingSystemTools.Title = node.ChildNodes[5].Attributes["title"].Value;
                        gamingSystemTools.Support = Convert.ToBoolean(node.ChildNodes[5].Attributes["support"].Value);
                        gamingSystemTools.Priority = node.ChildNodes[5].Attributes["priority"].Value.Split(',').ToList();
                        gamingSystemTools.SystemUpdate = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].FirstChild.Attributes["support"].Value),
                            node.ChildNodes[5].FirstChild.Attributes["value"].Value, node.ChildNodes[5].FirstChild.InnerText);       //SystemUpdate
                        gamingSystemTools.MacroKey = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].ChildNodes[1].Attributes["support"].Value),
                            node.ChildNodes[5].ChildNodes[1].Attributes["value"].Value, node.ChildNodes[5].ChildNodes[1].InnerText);       //MacroKey
                        gamingSystemTools.Power = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].ChildNodes[2].Attributes["support"].Value),
                           node.ChildNodes[5].ChildNodes[2].Attributes["value"].Value, node.ChildNodes[5].ChildNodes[2].InnerText);     //Power
                        gamingSystemTools.Media = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].ChildNodes[3].Attributes["support"].Value),
                            node.ChildNodes[5].ChildNodes[3].Attributes["value"].Value, node.ChildNodes[5].ChildNodes[3].InnerText);     //Media
                        machine.GamingSystemTools = gamingSystemTools;
                        gamingSystemTools.HardwareScan = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].ChildNodes[4].Attributes["support"].Value),
                           node.ChildNodes[5].ChildNodes[4].Attributes["value"].Value, node.ChildNodes[5].ChildNodes[4].InnerText);       //HardwareScan
                        gamingSystemTools.LegionAccessoryCentral = new Tuple<bool, string, string>(Convert.ToBoolean(node.ChildNodes[5].LastChild.Attributes["support"].Value),
                            node.ChildNodes[5].LastChild.Attributes["value"].Value, node.ChildNodes[5].LastChild.InnerText);     //LegionAccessory
                        //GamingLighting
                        gamingLighting.Title = node.LastChild.Attributes["title"].Value;
                        gamingLighting.Support = Convert.ToBoolean(node.LastChild.Attributes["support"].Value);
                        gamingLighting.Text = node.LastChild.InnerText;
                        machine.GamingLighting = gamingLighting;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error:GetGamingMachineList()+\r\n" + ex.ToString());
                    }
                    machines.Add(machine);
                }
                return machines;
            }
            else
            {
                return machines;
            }
        }

        public class GamingMachine
        {
            public string Type { get; set; }
            public GamingMachineSeries Series { get; set; }
            public string FamilyName { get; set; }
            public GamingUITitle GamingUITitle { get; set; }
            public GamingLighting GamingLighting { get; set; }
            public GamingLegionEdge GamingLegionEdge { get; set; }
            public GamingSystemTools GamingSystemTools { get; set; }
            public GamingLegionStatus GamingLegionStatus { get; set; }
            public GamingQuickSettings GamingQuickSettings { get; set; }
            public GamingFeatureValues GetValues(Tuple<bool, string, string> tuple)
            {
                GamingFeatureValues featureValues = new GamingFeatureValues();
                try
                {
                    featureValues.Support = tuple.Item1;
                    featureValues.Value = tuple.Item2;
                    featureValues.Text = tuple.Item3;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: GetValues() \r\n" + ex.ToString());
                }
                return featureValues;
            }
        }

        public enum GamingMachineSeries
        {
            X30,
            X40,
            X50,
            X60,
            Unknow
        }

        public class GamingLegionStatus
        {
            public string Title { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
            public Tuple<bool, string, string> GPU { get; set; }
            public Tuple<bool, string, string> CPU { get; set; }
            public Tuple<bool, string, string> RAM { get; set; }
            public Tuple<bool, string, string> DISK { get; set; }
            public Tuple<bool, string, string> INFO { get; set; }
        }

        public class GamingUITitle
        {
            public string Title { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
            public Tuple<bool, string, string> LogoIcon { get; set; }
            public Tuple<bool, string, string> EdgeName { get; set; }
            public Tuple<bool, string, string> HelpName { get; set; }
            public Tuple<bool, string, string> HeaderName { get; set; }
        }

        public class GamingLegionEdge
        {
            public string Title { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
            public Tuple<bool, string, string> AutoClose { get; set; }
            public Tuple<bool, string, string> OverDrive { get; set; }
            public Tuple<bool, string, string> HybridMode { get; set; }
            public Tuple<bool, string, string> ThermalMode { get; set; }
            public Tuple<bool, string, string> CPUOverclock { get; set; }
            public Tuple<bool, string, string> NetworkBoost { get; set; }
            public Tuple<bool, string, string> RAMOverclock { get; set; }
            public Tuple<bool, string, string> TouchpadLock { get; set; }
        }

        public class GamingQuickSettings
        {
            public string Title { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
            public Tuple<bool, string, string> Dolby { get; set; }
            public Tuple<bool, string, string> ThermalMode { get; set; }
            public Tuple<bool, string, string> RapidCharge { get; set; }
            public Tuple<bool, string, string> WiFiSecurity { get; set; }
        }

        public class GamingSystemTools
        {
            public string Title { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
            public Tuple<bool, string, string> Power { get; set; }
            public Tuple<bool, string, string> Media { get; set; }
            public Tuple<bool, string, string> MacroKey { get; set; }
            public Tuple<bool, string, string> SystemUpdate { get; set; }
            public Tuple<bool, string, string> HardwareScan { get; set; }
            public Tuple<bool, string, string> LegionAccessoryCentral { get; set; }
            public bool LegionAccessoryCentralInstallStatus
            {
                get
                {
                    if (Directory.Exists("C:\\Program Files (x86)\\Lenovo\\Legion Accessory Central"))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }

        public static bool LegionAccessoryCentralAppIsExist(bool isInstall = true, int trytime = 5)
        {

            GamingSystemTools systemTools = new GamingSystemTools();
            if (isInstall)  //must install
            {
                if (systemTools.LegionAccessoryCentralInstallStatus) //get install status is install
                {
                    return true;
                }
                else
                {
                    if (!Directory.Exists(NerveCenterConfigPath))
                    {
                        Directory.CreateDirectory(NerveCenterConfigPath);
                    }
                    if (!File.Exists(NerveCenterGamingAppIniFileCopy))
                    {
                        File.Copy(NerveCenterGamingAppIniFile, NerveCenterGamingAppIniFileCopy, true);
                    }
                    do
                    {
                        CommonAppInfo appInfo = GetCommonAppInformation("LegionAccessoryCentral", NerveCenterGamingAppIniFileCopy); //string path = ReadIniValue("LegionAccessoryCentral", "File", NerveCenterGamingAppIniFileCopy);
                        Process.Start(appInfo.File);
                        Thread.Sleep(4000);
                        SendKeys.SendWait("{ENTER}");  // click next btn
                        Thread.Sleep(2000);
                        SendKeys.SendWait("{TAB}");  // sel not accept
                        Thread.Sleep(1000);
                        SendKeys.SendWait("{UP}");  // sel accept
                        Thread.Sleep(1000);
                        SendKeys.SendWait("{TAB}");  // sel back btn
                        Thread.Sleep(1000);
                        SendKeys.SendWait("{TAB}");  //sel next btn
                        Thread.Sleep(1000);
                        SendKeys.SendWait("{ENTER}"); //click next btn
                        Thread.Sleep(2000);
                        SendKeys.SendWait("{ENTER}");  // click install btn
                        Thread.Sleep(5000);
                        SendKeys.SendWait(" ");  // click launch check box no check
                        Thread.Sleep(1000);
                        SendKeys.SendWait("{ENTER}");  // finish
                        Thread.Sleep(2000);
                        if (systemTools.LegionAccessoryCentralInstallStatus == true)
                        {
                            return true;
                        }
                        foreach (var pro in appInfo.ProcessName.Split(','))
                        {
                            SettingsBase.KillProcess(pro);
                            CommandBase.RunCmdException("taskkill /F /IM " + pro);
                        }
                        Console.WriteLine("Info: Try install app");
                        trytime--;
                    } while (trytime > 0);
                    Console.WriteLine("Info:LenovoAccessoryCentralAppIsExist() Install Time Out!");
                    return false;
                }
            }
            else  // must unistall
            {
                if (systemTools.LegionAccessoryCentralInstallStatus) //get install status  is install
                {
                    do
                    {
                        KeyboardMouse.ShowDesktop();
                        CommonAppInfo appInfo = GetCommonAppInformation("LegionAccessoryCentral", NerveCenterGamingAppIniFileCopy);
                        Process.Start(appInfo.UninstallExe);    //Process.Start("C:\\Program Files (x86)\\Lenovo\\Legion Accessory Central\\unins000.exe");
                        Thread.Sleep(4000);
                        SendKeys.SendWait("{TAB}");  // yes btn
                        Thread.Sleep(2000);
                        SendKeys.SendWait("{ENTER}");  //click yes btn
                        Thread.Sleep(10000);
                        SendKeys.SendWait("{ENTER}");  //ok btn
                        Thread.Sleep(2000);
                        if (systemTools.LegionAccessoryCentralInstallStatus == false)
                        {
                            IntPtr app = UnManagedAPI.FindWindow("ApplicationFrameWindow", "Lenovo Vantage");
                            UnManagedAPI.ShowWindow(app, UnManagedAPI.SW_SHOWMAXIMIZED);
                            //int width = (int)(Screen.PrimaryScreen.Bounds.Width);
                            ////int height = (int)(Screen.PrimaryScreen.Bounds.Height);
                            //UnManagedAPI.SetWindowPos(app, 0, 0, 0, width, height, 0x46);
                            return true;
                        }

                        foreach (var pro in appInfo.ProcessName.Split(','))
                        {
                            SettingsBase.KillProcess(pro);
                        }
                        Console.WriteLine("Info: Try uninstall app");
                        trytime--;
                    } while (trytime > 0);
                    Console.WriteLine("Info:LenovoAccessoryCentralAppIsExist() Uninstall Time Out!");
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public class GamingLighting
        {
            public string Title { get; set; }
            public string Text { get; set; }
            public bool Support { get; set; }
            public List<string> Priority { get; set; }
        }

        public class GamingFeatureValues
        {
            public string Value { get; set; }
            public string Text { get; set; }
            public bool Support { get; set; }
        }

        public enum GamingFeature
        {
            AutoClose,
            OverDrive,
            HybridMode,
            ThermalModeNew,
            ThermalModeOnlyTwoMode,
            ThermalModeOld,
            CPUOverclockOld,
            GPUOverclockNew,
            CPUGPUOverclockNew,
            NotSupportOverclock,
            RAMOverclock,
            NetworkBoost,
            TouchpadLock,
            Dolby,
            RapidCharge,
            WiFiSecurity,
            Power,
            Media,
            MacroKey,
            SystemUpdate,
            HardwareScan,
            LegionAccessoryCentral,
            Lighting
        }

        public static bool GetGamingFeatureIsSupport(GamingFeature feature, string familyname)
        {
            try
            {
                GamingMachine machine = GetGamingMachineInfo(familyname);
                bool cpu = false;
                bool gpu = false;
                switch (feature)
                {
                    //System Tools
                    case GamingFeature.SystemUpdate:
                        return machine.GetValues(machine.GamingSystemTools.SystemUpdate).Support;
                    case GamingFeature.Power:
                        return machine.GetValues(machine.GamingSystemTools.Power).Support;
                    case GamingFeature.Media:
                        return machine.GetValues(machine.GamingSystemTools.Media).Support;
                    case GamingFeature.HardwareScan:
                        return machine.GetValues(machine.GamingSystemTools.HardwareScan).Support;
                    case GamingFeature.MacroKey:
                        return machine.GetValues(machine.GamingSystemTools.MacroKey).Support;
                    case GamingFeature.LegionAccessoryCentral:
                        return machine.GetValues(machine.GamingSystemTools.MacroKey).Support;

                    //Legion Edge
                    case GamingFeature.CPUGPUOverclockNew:
                        cpu = GetMachineIsSupportCPUGPUOverclock(false);
                        gpu = GetMachineIsSupportCPUGPUOverclock(true);
                        foreach (string m in GPUCPUGamingMachineList)
                        {
                            if (familyname == m && cpu == true && gpu == true)
                            {
                                return true;
                            }
                        }
                        return false;
                    case GamingFeature.GPUOverclockNew:
                        gpu = GetMachineIsSupportCPUGPUOverclock(true);
                        foreach (string m in GPUGamingMachineList)
                        {
                            if (familyname == m && gpu == true)
                            {
                                return true;
                            }
                        }
                        return false;
                    case GamingFeature.NotSupportOverclock:
                        foreach (string m in NotSupportOverclockGamingMachineList)
                        {
                            if (familyname == m)
                            {
                                return true;
                            }
                        }
                        return false;
                    case GamingFeature.ThermalModeOnlyTwoMode:
                        foreach (string m in ThermalModeOnlyTwoModeGamingMachineList)
                        {
                            if (familyname == m)
                            {
                                return true;
                            }
                        }
                        return false;
                    case GamingFeature.CPUOverclockOld:
                        return machine.GetValues(machine.GamingLegionEdge.CPUOverclock).Support;
                    case GamingFeature.ThermalModeNew:
                        return machine.GetValues(machine.GamingLegionEdge.ThermalMode).Support;
                    case GamingFeature.RAMOverclock:
                        return machine.GetValues(machine.GamingLegionEdge.RAMOverclock).Support;  //ramOverclock = machine.GetValues(machine.GamingLegionEdge.RAMOverclock).Support;
                    case GamingFeature.NetworkBoost:
                        return GetMachineIsGaming();   //networkBoost = machine.GetValues(machine.GamingLegionEdge.NetworkBoost).Support;
                    case GamingFeature.AutoClose:
                        return GetMachineIsGaming();  //autoClose = machine.GetValues(machine.GamingLegionEdge.AutoClose).Support;
                    case GamingFeature.HybridMode:
                        return machine.GetValues(machine.GamingLegionEdge.HybridMode).Support;
                    case GamingFeature.OverDrive:
                        return machine.GetValues(machine.GamingLegionEdge.OverDrive).Support;
                    case GamingFeature.TouchpadLock:
                        return machine.GetValues(machine.GamingLegionEdge.TouchpadLock).Support;

                    //Quick Settings
                    case GamingFeature.ThermalModeOld:
                        return machine.GetValues(machine.GamingQuickSettings.ThermalMode).Support;
                    case GamingFeature.RapidCharge:
                        return machine.GetValues(machine.GamingQuickSettings.RapidCharge).Support;
                    case GamingFeature.WiFiSecurity:
                        return machine.GetValues(machine.GamingQuickSettings.WiFiSecurity).Support;
                    case GamingFeature.Dolby:
                        return machine.GetValues(machine.GamingQuickSettings.Dolby).Support;

                    //Lighting
                    case GamingFeature.Lighting:
                        return machine.GamingLighting.Support;
                }

                Console.WriteLine("Error Info: GetGamingFeatureIsSupport() not run!");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Info:" + ex.ToString());
                return false;
            }
        }

        public static bool GetMachineIsSupportCPUGPUOverclock(bool isGPU)
        {
            string cpu = string.Empty;
            string gpu = string.Empty;
            string instanceName = string.Empty;
            try
            {
                //ACPI\\PNP0C14\\GMZN_0   //ACPI\\PNP0C14\\GamingWMI_0
                instanceName = GetWMIInformation("LENOVO_GAMEZONE_DATA", "InstanceName")[0];
                ManagementObject classInstance = new ManagementObject("root\\WMI", "LENOVO_GAMEZONE_DATA.InstanceName=\'" + instanceName + "\'", null);
                if (isGPU)
                {
                    ManagementBaseObject outgpuParams = classInstance.InvokeMethod("IsSupportGpuOC", null, null);
                    gpu = outgpuParams["Data"].ToString();
                    Console.WriteLine("GPU Info:" + gpu + ";" + outgpuParams["Data"]);
                    if (gpu == "2") //返回0不支持GPU超频，返回1支持GPU超频,返回2支持高级GPU超频
                    {
                        return true;
                    }
                    else if (gpu == "0")
                    {
                        return false;
                    }
                }
                else
                {
                    ManagementBaseObject outcpuParams = classInstance.InvokeMethod("IsSupportCpuOC", null, null);
                    cpu = outcpuParams["Data"].ToString();
                    Console.WriteLine("CPU Info:" + cpu + ";" + outcpuParams["Data"]);
                    if (cpu == "2")   //返回0不支持CPU超频，返回1支持CPU超频，返回2支持高级CPU超频
                    {
                        return true;
                    }
                    else if (cpu == "0")
                    {
                        return false;
                    }
                }
                return false;
            }
            catch (ManagementException err)
            {
                Console.WriteLine("Error: GetMachineIsSupportCPUGPUOverclock(),WMI Info:" + err.Message);
                return false;
            }
        }

        /// <summary>
        /// GetSmartFanMode
        /// 1为Quiet Mode – Low Speed Fan, 2为Balance Mode – Balance Acoustic, 3为 Performance Mode – High Speed Fan
        /// GetThermalMode
        /// 1为Quiet Mode – Low Speed Fan, 2为Balance Mode – Balance Acoustic, 3为 Performance Mode – High Speed Fan
        /// GetIntelligentSubMode
        /// 0 - Auto Adjust checkbox off,1 - 运行common游戏,2 - 运行legend ,3 - 运行dota2 ,4 - 运行Csgo
        /// GetSupportThermalMode
        /// 0不支持Thermal mode,1 支持Quiet Mode,2 支持Balance Mode,4 支持 Performance  Mode,8 支持Full Speed Mode - full speed fan(only for PCM)
        /// 注意：返回值为以上的组合值，如返回3，代表可以支持Quiet mode和 Balance Mode
        /// IsSupportLightingFeature
        /// 18-T750RKL all lights supported , 6-T750 all lights supported, 11-T550AMD all lights supported, 1- T550Intel all lights supported, 2- T550Intel OY supported, 3- T550Intel Big Y supported, 4- T550G single color supported
        /// 注意：返回值为以上的组合值，如返回3，代表可以支持Quiet mode和 Balance Mode
        /// </summary>
        public static int GetMachineThermalModeValue(string getMethod = "GetSmartFanMode")
        {
            string thermalmode = string.Empty;
            string instanceName = string.Empty;
            try
            {
                instanceName = GetWMIInformation("LENOVO_GAMEZONE_DATA", "InstanceName")[0];
                ManagementObject classInstance = new ManagementObject("root\\WMI", "LENOVO_GAMEZONE_DATA.InstanceName=\'" + instanceName + "\'", null);
                ManagementBaseObject outsfmParams = classInstance.InvokeMethod(getMethod, null, null);
                thermalmode = outsfmParams["Data"].ToString();
                Console.WriteLine("ThermalMode " + getMethod + " Info:" + thermalmode + ";" + outsfmParams["Data"]);
                return Convert.ToInt32(thermalmode);
            }
            catch (ManagementException err)
            {
                Console.WriteLine("Error: GetMachineThermalModeValue(),WMI Info:" + err.Message);
                return 99;
            }
        }

        public static bool GetThermalModeValue(int mode, string getMethod = "GetSmartFanMode")
        {
            int modevalue = GetMachineThermalModeValue(getMethod);
            return mode == modevalue;
        }

        public static bool GetGPUVendorValue(int vendor, string getMethod = "GetGPUVendor")
        {
            int vendorvalue = GetGPULightingCapability(getMethod);
            return vendor == vendorvalue;
        }

        /// </summary>
        /// 1-NV ,2-AMD
        public static int GetGPULightingCapability(string getMethod = "GetGPUVendor")
        {
            object gpuvendor = null;
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\WMI",
                   "SELECT * FROM LENOVO_GAMEZONE_GPU_LED_DATA");
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    if (queryObj["vendorid"] != null)
                    {
                        gpuvendor = queryObj["vendorid"];
                        break;
                    }
                }
                return Convert.ToInt32(gpuvendor);
            }
            catch (ManagementException err)
            {
                Console.WriteLine("Error: GetGPULightingCapability(),WMI Info:" + err.Message);
                return 99;
            }
        }

        #endregion

        public static bool JudgeDriverExist(string driverName)
        {
            string driverText = string.Empty;
            if ("ledDriver".Equals(driverName))
            {
                driverText = "lenovo led";
            }
            else if ("netfilterDriver".Equals(driverName))
            {
                driverText = "lenovo gaming netfilter device";
            }
            else
            {
                driverText = "XTU3SERVICE";
            }
            RegistryKey cv = RegistryHelp.OpenKey(_driverRegeditPath);
            string[] cvArray = cv.GetSubKeyNames();
            bool flag = true;
            for (int i = 0; i < cvArray.Length - 1; i++)
            {
                string regPath = _driverRegeditPath + "\\" + cvArray[i];
                if (RegistryHelp.GetValueFromRegedit(_driverDesc, regPath).Contains(driverText).Equals("null"))
                {
                    flag = false;
                    break;
                }
            }
            return flag;
        }

        public static string GetRequestInfomationFromImController(string RequestName, string CommandRequestName, string CommandRequestType, string CommandRequestParameter = null)
        {
            Lenovo.Beijing.PA.ContractSender sender = new Lenovo.Beijing.PA.ContractSender();
            Lenovo.Beijing.PA.ContractSender.ImcContractRequest imcContract = new Lenovo.Beijing.PA.ContractSender.ImcContractRequest();
            imcContract.RequestName = RequestName;
            imcContract.CommandRequestName = CommandRequestName;
            imcContract.CommandRequestType = CommandRequestType;
            imcContract.CommandRequestParameter = CommandRequestParameter;
            return sender.GetRequestInfomationFromImController(imcContract);
        }

        public static string ConvertClocksValueFromGPUBoostTool(string ClocksValue)
        {
            double doubleResult = Convert.ToDouble(ClocksValue) / 1000000;
            return doubleResult.ToString("0.00");
        }

        public static string ConvertMaximumCPUFrequencyFromWMITool(string frequency, string status)
        {
            int result = Convert.ToInt32(frequency);
            string hexResult = Convert.ToString(result, 16);
            string hexSub = string.Empty;
            if (status.ToLower() == "unoverclocked")
            {
                hexSub = hexResult.Substring(0, 4);
            }
            else if (status.ToLower() == "overclocked")
            {
                hexSub = hexResult.Substring(4, 4);
            }
            int decimalResult = Convert.ToInt32(hexSub, 16);
            double doubleResult = Convert.ToDouble(decimalResult) / 1000;
            return doubleResult.ToString("0.00");
        }

        public static List<string> GetGamingCommonAppList(string xmlinfo)
        {
            List<string> obj = new List<string>();
            try
            {
                string[] tempobj = xmlinfo.Split(new string[] { "<Data><![CDATA[" }, StringSplitOptions.None);  //string parsing 1
                string[] temp = tempobj[1].Split(new string[] { "]]></Data>" }, StringSplitOptions.None);  //string parsing 2
                string tempxml = temp[0]; //get standard xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);
                XmlNodeList applist = xmldoc.DocumentElement.SelectNodes("//GamingCommonListItem");
                foreach (XmlNode app in applist)
                {
                    if (app.ChildNodes[0].InnerText == "ProcessDescription")
                    {
                        obj.Add(app.ChildNodes[1].InnerText);
                    }
                }
                return obj;
            }
            catch (Exception ex)
            {
                obj.Add(ex.Message);
                return obj;
            }
        }

        public enum GamingAppList
        {
            AutoCloseAppCount,
            AutoCloseAdded,
            AutoCloseNoAdded,
            NetBoostAppCount,
            NetBoostAdded,
            NetBoostNoAdded
        }
        /// <summary>get auto close/netboost applist</summary>
        /// <returns>applist</returns>
        public static List<string> GetApplistHelper(GamingAppList gamingAppList)
        {
            string info = string.Empty;
            List<string> applist = new List<string>();
            switch (gamingAppList)
            {
                case GamingAppList.NetBoostAdded:
                    info = GetRequestInfomationFromImController("Gaming.NetworkBoost", "Get-ProcessInNetBoostList", "sync");
                    break;
                case GamingAppList.NetBoostAppCount:
                    info = GetRequestInfomationFromImController("Gaming.NetworkBoost", "Get-NetUsingProcess", "sync");
                    break;
                case GamingAppList.NetBoostNoAdded:
                    applist = GetGamingCommonAppList(GetRequestInfomationFromImController("Gaming.NetworkBoost", "Get - NetUsingProcess", "sync")).Except(GetGamingCommonAppList(GetRequestInfomationFromImController("Gaming.NetworkBoost", "Get-ProcessInNetBoostList", "sync"))).ToList();
                    return applist;
                case GamingAppList.AutoCloseAdded:
                    info = GetRequestInfomationFromImController("Gaming.Optimization", "Get-ProcessInAutoList", "sync");
                    break;
                case GamingAppList.AutoCloseAppCount:
                    info = GetRequestInfomationFromImController("Gaming.Optimization", "Get-ProcessRunning", "sync");
                    break;
                case GamingAppList.AutoCloseNoAdded:
                    applist = GetGamingCommonAppList(GetRequestInfomationFromImController("Gaming.Optimization", "Get-ProcessRunning", "sync")).Except(GetGamingCommonAppList(GetRequestInfomationFromImController("Gaming.Optimization", "Get-ProcessInAutoList", "sync"))).ToList();
                    return applist;
                default:
                    return applist;
            }
            return GetGamingCommonAppList(info);
        }

        public static bool LaunchAppAsCurrentUser(string file)
        {
            try
            {
                string currentUser = Environment.UserName;
                System.Security.SecureString secureStr = new System.Security.SecureString();
                secureStr.AppendChar('1');
                try
                {
                    Process.Start(file, currentUser, secureStr, "");
                }
                catch
                {
                    Process.Start(file);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary> 
        /// No value >= 9000，Mark is game 
        /// 
        /// </summary>
        /// <param name="appName"></param>
        /// <returns></returns>
        public static CommonAppInfo GetCommonAppInformation(string appName, string file = "C:\\NerveCenterAppRunList.ini")
        {
            if (file == NerveCenterAppRunListIniFile)  //app list config, 需要手动配置，请勿进行复制操作
            {
                if (!File.Exists(file))
                {
                    Console.WriteLine("Info: Please configure the file manually," + file);
                }
            }
            else  //Gaming 、LegionAccessoryCentral config ini
            {
                if (!Directory.Exists(NerveCenterConfigPath))
                {
                    Directory.CreateDirectory(NerveCenterConfigPath);
                }
                if (!File.Exists(NerveCenterGamingAppIniFileCopy))
                {
                    File.Copy(NerveCenterGamingAppIniFile, NerveCenterGamingAppIniFileCopy, true);
                }
            }
            CommonAppInfo appInfo = new CommonAppInfo();
            appInfo.File = ReadIniValue(appName, "File", file);
            appInfo.DescName = ReadIniValue(appName, "DescName", file);
            appInfo.Package = ReadIniValue(appName, "Package", file);
            appInfo.UninstallExe = ReadIniValue(appName, "UninstallExe", file);
            appInfo.ProcessName = ReadIniValue(appName, "ProcessName", file);
            appInfo.Alias = ReadIniValue(appName, "Alias", file);
            try
            {
                appInfo.No = int.Parse(ReadIniValue(appName, "No", file));
            }
            catch
            {
                appInfo.No = 0;
            }

            return appInfo;
        }

        /// <summary> Get GPU infomation by machine type </summary>
        /// <param name="machineType"></param>
        /// <returns></returns>
        public static GPUInfo GetGPUInformation(string machineType)
        {
            GPUInfo gpuInfo = new GPUInfo();
            gpuInfo.DefaultVal = ReadIniValue(machineType, "defaultval", GPUSpecIniFile);
            gpuInfo.Minimum = ReadIniValue(machineType, "minimum", GPUSpecIniFile);
            gpuInfo.Maximum = ReadIniValue(machineType, "maximum", GPUSpecIniFile);
            gpuInfo.Keys = new List<string>();
            int i = 1;
            while (true)
            {
                if (ReadIniValue(machineType, "key" + i, GPUSpecIniFile) == "")
                    break;
                gpuInfo.Keys.Add(ReadIniValue(machineType, "key" + i, GPUSpecIniFile));
                i++;
            }
            return gpuInfo;
        }

        public enum AppName
        {
            NotePad,
            IE,
            WindowsCalculator,
            WindowsVideo,
            WindowsStore,
            WindowsCamera,
            SndVol,
            CharacterMap,
            WindowsMediaPlayer,
            WindowsITHome,
            WindowsLaPin,
            WindowsGrooveMusic,
            WindowsTips,
            WindowsWeather,
            Windows3DPaint,
            WindowsMaps,
            WindowsClock,
            WindowsNews,
            Windows3DBuilder,
            WindowsPeople,
            WindowsOneNote,
            WindowsHolographic,
            WindowsPhotos,
            WindowsDefender,
            WindowsParentalControls,
            WindowsSmartGlass,
            WindowsPPIProjection,
            WindowsDrawboardPDF,
            WindowsSoundRecord,
            WindowsGetHelp,
            WindowsPhone,
            WindowsSports,
            WindowsFeedBack,
            StoreMicrosoftStickyNotes,
            StoreICloud,
            StoreHuyaMini,
            StoreWhatsApp,
            StoreSpotify,
            StorePandora,
            StoreSlack,
            StoreIHeartRadio,
            StoreFitbit,
            StoreAmazonAlexa,
            StoreAmazonLINE,
            StorePython,
            StoreCinebench,
            StoreUbuntu,
            StoreXimalaya,
            StoreMangGuoTV,
            StoreAiQiYi,
            WeChat,
            GameWorldOfWarcraft,
            SnippingTool,
            MicrosoftEdge
        }

        public class CommonAppInfo
        {
            public string File { get; set; }

            public string Alias { get; set; }
            public string DescName { get; set; }
            public string ProcessName { get; set; }
            public string Package { get; set; }
            public string UninstallExe { get; set; }
            public int No { get; set; }

        }

        public class GPUInfo
        {
            public string DefaultVal { get; set; }
            public string Minimum { get; set; }
            public string Maximum { get; set; }
            public List<string> Keys { get; set; }
        }

        #region Ini Read

        public static string ReadIniValue(string section, string key, string filepath)
        {
            StringBuilder sb = new StringBuilder(255);                //255为字符串长度  
            GetPrivateProfileString(section, key, "", sb, 255, filepath);
            return sb.ToString();
        }
        public static void IniWriteValue(string Section, string Key, string Value, string path)
        {
            WritePrivateProfileString(Section, Key, Value, path);
        }

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        internal static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32 ", CharSet = CharSet.Unicode)]
        internal static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #endregion

        #region Get Display info

        public static List<string> GetDisplayAdaptersInfo(string value)
        {
            return GetWMIInformation("Win32_VideoController", value, "root\\CIMV2");
        }

        public static List<string> GetWMIInformation(string className, string value, string querypath = "root\\WMI")
        {
            List<string> info = new List<string>();
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(querypath, "SELECT * FROM " + className);
                foreach (ManagementObject mo in searcher.Get())
                {
                    info.Add(mo[value].ToString());
                    Console.WriteLine("Info:GetWMIInformation()," + mo[value].ToString());
                }
                return info;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: GetWMIInformation() +\r\n" + ex.ToString());
            }
            return info;
        }

        #endregion

        public static string GetTouchpadStatus()
        {
            try
            {
                ManagementObject classInstance =
                    new ManagementObject("root\\WMI",
                    "LENOVO_GAMEZONE_DATA.InstanceName='ACPI\\PNP0C14\\GMZN_0'",
                    null);
                ManagementBaseObject outParams = classInstance.InvokeMethod("GetTPStatus", null, null);
                string TPStatus = outParams["Data"] + "";
                return TPStatus;
            }
            catch (ManagementException err)
            {
                MessageBox.Show("An error occurred while trying to execute the WMI method: " + err.Message);
            }
            return "";
        }

        #region Get GPU CPU RAM Info

        public static List<string> GetGPUCPURAMInfoFormat(string target = "GPU")
        {
            List<string> targetlist = new List<string>();
            string info = string.Empty;
            switch (target)
            {
                case "VRAM":
                case "GPU":
                    info = DesktopPowerManagementHelper.RunCmd("powershell.exe -command \"Get-WmiObject Win32_VideoController | Select-Object Name\"");
                    break;
                case "CPU":
                    info = DesktopPowerManagementHelper.RunCmd("wmic cpu get Name");
                    break;
                case "RAM":
                    info = DesktopPowerManagementHelper.RunCmd("wmic MEMORYCHIP get Name");
                    break;
                default:
                    return targetlist;
            }
            foreach (var item in info.Split(new string[] { "\r\n" }, StringSplitOptions.None).ToList())
            {
                if (!string.IsNullOrEmpty(item))
                {
                    targetlist.Add(item);
                }
            }
            return targetlist;
        }

        public static string GetGPUCPURAMInfoCorrect(string vantageName, string target = "GPU")
        {
            Console.WriteLine("Vantage Info:" + vantageName);
            foreach (var item in GetGPUCPURAMInfoFormat(target))
            {
                Console.WriteLine(target + " Info:" + item);
                if (vantageName.Trim() == item.Trim())
                {
                    return item.Trim();
                }
            }
            return "Detail Info:" + string.Join(" ", GetGPUCPURAMInfoFormat(target));
        }
        #endregion

    }
}
