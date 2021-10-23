using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Automation;
using System.Xml;
using TangramTest.Utility;

namespace LenovoVantageTest.Pages.Helper
{
    class DesktopPowerManagementHelper
    {
        public static WindowsDriver<WindowsElement> Session;
        public static bool DPMPowerPlanIitializationStatus = false;
        public static bool ResetVantage = false;
        public static string DPMTips = string.Empty;
        public static string DPMFolder = @"C:\ProgramData\Lenovo\ImController\Plugins\ThinkDPMPlugin";
        public static string VantageMachineInformationFile = @"C:\ProgramData\Lenovo\ImController\shared\MachineInformation.xml";
        public static string[] DPMPowerPlanDefault = { "Maximum Performance", "Maximum Energy Saving", "Timers off (Presentation)", "Power Source Optimized", "Video Playback", "Balanced", "High performance", "Power saver" };
        public static string[] DPMPowerUseDropDownMenuList = { "1 minute", "2 minutes", "3 minutes", "5 minutes", "10 minutes", "15 minutes", "20 minutes", "25 minutes", "30 minutes", "45 minutes", "1 hour", "2 hours", "3 hours", "4 hours", "5 hours", "Never" };
        public static string[] DPMPowerButtonOptionsDefault = { "Do nothing", "Sleep", "Hibernate", "Shut down", "Turn off the display" };
        public static string[] DPMRequiredSignInOptionsDefault = { "Never", "When PC wakes up from sleep" };
        public static string[] SpecificEnclosureType = { "allinone", "desktop" };

        #region Get DPM Machine

        public static bool GetMachineIsDPM()
        {
            try
            {
                string sku = VantageCommonHelper.GetMachineSku();
                if (!File.Exists(VantageMachineInformationFile))
                {
                    DPMTips = "Note:The file not exist,info:" + VantageMachineInformationFile;
                    return false;
                }
                string[] infos = File.ReadAllLines(VantageMachineInformationFile);
                string brand = string.Empty;
                string subbrand = string.Empty;
                foreach (var item in infos)
                {
                    if (item.Contains("<Brand>"))
                    {
                        brand = item;
                    }
                    if (item.Contains("<SubBrand>"))
                    {
                        subbrand = item;
                    }
                }
                if ((brand.ToLower().Contains("lenovo") || brand.ToLower().Contains("think")) && subbrand.ToLower().Contains("thinkcentre")
                    && (sku.ToLower().Contains("lenovo") || sku.ToLower().Contains("think")) && sku.ToLower().Contains("thinkcentre") && Directory.Exists(DPMFolder))
                {
                    if (!DPMPowerPlanIitializationStatus)   //  Power Plan Scheme Iitialization
                    {
                        DPMPowerPlanSchemeIitialization();
                        DPMPowerPlanIitializationStatus = true;
                        Console.WriteLine("Note:DPM Power Plan Scheme Iitialization sucess.");
                    }
                    return true;
                }
                DPMTips = "Note:The Machine does not support DPM,info: brand >>" + brand + " subbrand >>" + subbrand + " sku >>" + sku;
            }
            catch (Exception ex)
            {
                DPMTips = "GetMachineIsDPM error \r\n" + ex.ToString();
            }
            return false;
        }

        #endregion

        #region Machine is Specific Enclosure Type

        public static bool GetMachineIsSpecificEnclosureType()
        {
            try
            {
                string[] infos = File.ReadAllLines(VantageMachineInformationFile);
                string enclosuretype = string.Empty;
                foreach (var item in infos)
                {
                    if (item.Contains("<EnclosureType>"))
                    {
                        enclosuretype = item;
                        break;
                    }
                }
                foreach (var et in SpecificEnclosureType)
                {
                    if (enclosuretype.ToLower().Trim().Contains(et.ToLower().Trim()))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Info:" + ex.ToString());
            }
            return false;
        }

        #endregion

        #region PowerSettingsOptions

        public enum PowerSettingsOptions
        {
            DiskAC,
            DiskDC,
            DisplayAC,
            DisplayDC,
            SleepAC,
            SleepDC,
            HibernateAC,
            HibernateDC
        }

        public static bool PowerSettingsOptionsControl(PowerSettingsOptions option, int minutes, bool isVerify = true)
        {
            switch (option)
            {
                case PowerSettingsOptions.DiskAC:
                    RunCmd("powercfg /change disk-timeout-ac " + minutes);
                    break;
                case PowerSettingsOptions.DiskDC:
                    RunCmd("powercfg /change disk-timeout-dc " + minutes);
                    break;
                case PowerSettingsOptions.DisplayAC:
                    RunCmd("powercfg /change monitor-timeout-ac " + minutes);
                    break;
                case PowerSettingsOptions.DisplayDC:
                    RunCmd("powercfg /change monitor-timeout-dc " + minutes);
                    break;
                case PowerSettingsOptions.HibernateAC:
                    RunCmd("powercfg /change hibernate-timeout-ac " + minutes);
                    break;
                case PowerSettingsOptions.HibernateDC:
                    RunCmd("powercfg /change hibernate-timeout-dc " + minutes);
                    break;
                case PowerSettingsOptions.SleepAC:
                    RunCmd("powercfg /change standby-timeout-ac " + minutes);
                    break;
                case PowerSettingsOptions.SleepDC:
                    RunCmd("powercfg /change standby-timeout-dc " + minutes);
                    break;
                default:
                    return false;
            }
            if (isVerify)
            {
                return CheckPowerSettingsValues(option, minutes);
            }
            else
            {
                return true;
            }
        }

        private static bool CheckPowerSettingsValues(PowerSettingsOptions option, int minutes, int trytimes = 30)
        {
            do
            {
                switch (option)
                {
                    case PowerSettingsOptions.DiskAC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_DISK_AC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.DiskDC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_DISK_DC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.DisplayAC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_DISPLAY_AC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.DisplayDC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_DISPLAY_DC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.HibernateAC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_HIBERNATE_AC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.HibernateDC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_HIBERNATE_DC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.SleepAC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_SLEEP_AC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    case PowerSettingsOptions.SleepDC:
                        if (GetCurrentPowerPlanSchemeSettingsInfo().SCHEM_SLEEP_DC_Setting_Second == minutes * 60)
                        {
                            return true;
                        }
                        break;
                    default:
                        return false;
                }
                trytimes--;
                Random r = new Random();
                PowerSettingsOptionsControl(option, r.Next(0, 3600), false);
                Thread.Sleep(200);
                PowerSettingsOptionsControl(option, minutes, false);
                Thread.Sleep(200);
            } while (trytimes > 0);
            return false;
        }

        #endregion

        #region PowerPlanOptions

        public enum PowerPlanOptions
        {
            SetPowerPlan,
            CreatePowerPlan,
            CopyPowerPlan,
            DeletePowerPlan
        }

        public class PowerPlanScheme
        {
            public const string GUID_SYSTEM_BUTTON_SUBGROUP = "4f971e89-eebd-4455-a8de-9e59040e7347";
            public const string NO_SUBGROUP_GUID = "fea3413e-7e05-4911-9a71-700331f1c294";
            public const string GUID_POWERBUTTON_ACTION = "7648efa3-dd9c-4e3e-b566-50f929386280";
            public const string GUID_LID_ACTION = "5ca83367-6e45-459f-a27b-476b1d01c936";
            public const string GUID_SLEEPBUTTON_ACTION = "96996bc0-ad50-47ec-923b-6f41874dd9eb";
            public const string GUID_LOCK_CONSOLE_ON_WAKE = "0E796BDB-100D-47D6-A2D5-F7D2DAA51F51";  //{0x0E796BDB,0x100D,0x47D6,0xA2,0xD5,0xF7,0xD2,0xDA,0xA5,0x1F,0x51}

            public string SCHEME_GUID { get; set; }
            public string SCHEME_GUID_NAME { get; set; }
            public bool SCHEME_GUID_STATUS { get; set; }
            public int SCHEM_DISK_AC_Setting_Second { get; set; }
            public int SCHEM_DISK_DC_Setting_Second { get; set; }
            public int SCHEM_SLEEP_AC_Setting_Second { get; set; }
            public int SCHEM_SLEEP_DC_Setting_Second { get; set; }
            public int SCHEM_HIBERNATE_AC_Setting_Second { get; set; }
            public int SCHEM_HIBERNATE_DC_Setting_Second { get; set; }
            public int SCHEM_DISPLAY_AC_Setting_Second { get; set; }
            public int SCHEM_DISPLAY_DC_Setting_Second { get; set; }
        }

        public static string PowerPlanOptionsControl(PowerPlanOptions option, PowerPlanScheme scheme, string schemeName = null)
        {
            switch (option)
            {
                case PowerPlanOptions.CreatePowerPlan:
                    var schemetemp = CreatePowerPlanScheme(scheme).SCHEME_GUID;
                    var cr1 = RunCmd("powercfg /CHANGENAME " + schemetemp + " \"" + schemeName + "\"");
                    var cr2 = RunCmd("powercfg /SETACTIVE " + schemetemp);
                    return schemetemp + cr1 + cr2;
                case PowerPlanOptions.DeletePowerPlan:
                    return RunCmd("powercfg /DELETE " + scheme.SCHEME_GUID);
                case PowerPlanOptions.CopyPowerPlan:
                    var schemecopy = CreatePowerPlanScheme(scheme).SCHEME_GUID;
                    var co1 = RunCmd("powercfg /CHANGENAME " + schemecopy + " \"" + scheme.SCHEME_GUID_NAME + " Copy\"");
                    var co2 = RunCmd("powercfg /SETACTIVE " + schemecopy);
                    return schemecopy + co1 + co2;
                case PowerPlanOptions.SetPowerPlan:
                    return RunCmd("powercfg /SETACTIVE " + scheme.SCHEME_GUID);
                default:
                    return null;
            }
        }

        private static PowerPlanScheme CreatePowerPlanScheme(PowerPlanScheme schemecopy)
        {
            PowerPlanScheme scheme = new PowerPlanScheme();
            try
            {
                string commandinfo = RunCmd("powercfg /DUPLICATESCHEME " + schemecopy.SCHEME_GUID);
                string[] infolist = commandinfo.Split('\n');
                foreach (string info in infolist)
                {
                    if (!string.IsNullOrEmpty(info) && info.Contains("GUID"))
                    {
                        scheme = GetPowerPlanScheme(info, false, false);
                        return scheme;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreatePowerPlanScheme error \r\n" + ex.ToString());
            }
            return scheme;
        }

        public static PowerPlanScheme GetCurrentPowerPlanSchemeInfo()
        {
            PowerPlanScheme scheme = new PowerPlanScheme();
            try
            {
                string commandinfo = RunCmd("powercfg -getactivescheme");
                string[] infolist = commandinfo.Split('\n');
                foreach (string info in infolist)
                {
                    if (!string.IsNullOrEmpty(info) && info.Contains("GUID"))
                    {
                        scheme = GetPowerPlanScheme(info, true, false);
                        return scheme;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CreatePowerPlanScheme error \r\n" + ex.ToString());
            }
            return scheme;
        }

        public static PowerPlanScheme GetCurrentPowerPlanSchemeSettingsInfo()
        {
            PowerPlanScheme scheme = new PowerPlanScheme();
            try
            {
                scheme = GetCurrentPowerPlanSchemeInfo();
                string[] info = RunCmd("powercfg -q " + scheme.SCHEME_GUID + " SUB_DISK").Split('\n');
                scheme.SCHEM_DISK_AC_Setting_Second = Convert.ToInt32(info[info.Length - 6].Split(':')[1].Trim(), 16);
                scheme.SCHEM_DISK_DC_Setting_Second = Convert.ToInt32(info[info.Length - 5].Split(':')[1].Trim(), 16);
                info = RunCmd("powercfg -q " + scheme.SCHEME_GUID + " SUB_SLEEP STANDBYIDLE").Split('\n');
                scheme.SCHEM_SLEEP_AC_Setting_Second = Convert.ToInt32(info[info.Length - 6].Split(':')[1].Trim(), 16);
                scheme.SCHEM_SLEEP_DC_Setting_Second = Convert.ToInt32(info[info.Length - 5].Split(':')[1].Trim(), 16);
                info = RunCmd("powercfg -q " + scheme.SCHEME_GUID + " SUB_SLEEP HIBERNATEIDLE").Split('\n');
                scheme.SCHEM_HIBERNATE_AC_Setting_Second = Convert.ToInt32(info[info.Length - 6].Split(':')[1].Trim(), 16);
                scheme.SCHEM_HIBERNATE_DC_Setting_Second = Convert.ToInt32(info[info.Length - 5].Split(':')[1].Trim(), 16);
                info = RunCmd("powercfg -q " + scheme.SCHEME_GUID + " SUB_VIDEO VIDEOIDLE").Split('\n');
                scheme.SCHEM_DISPLAY_AC_Setting_Second = Convert.ToInt32(info[info.Length - 6].Split(':')[1].Trim(), 16);
                scheme.SCHEM_DISPLAY_DC_Setting_Second = Convert.ToInt32(info[info.Length - 5].Split(':')[1].Trim(), 16);
                return scheme;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetCurrentPowerPlanSchemeSettingsInfo error \r\n" + ex.ToString());
            }
            return scheme;
        }

        public static List<PowerPlanScheme> GetPowerPlanSchemesInfo()
        {
            List<PowerPlanScheme> schemes = new List<PowerPlanScheme>();
            try
            {
                string commandinfo = RunCmd("powercfg -l");
                string[] infolist = commandinfo.Split('\n');
                foreach (string info in infolist)
                {
                    if (!string.IsNullOrEmpty(info) && info.Contains("GUID"))
                    {
                        PowerPlanScheme scheme = new PowerPlanScheme();
                        scheme = GetPowerPlanScheme(info, true, true);
                        schemes.Add(scheme);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetPowerPlanSchemesInfo error \r\n" + ex.ToString());
            }
            return schemes;
        }

        public static PowerPlanScheme GetPowerPlanScheme(string info, bool getStatus = true, bool isListInfo = false)
        {
            PowerPlanScheme scheme = new PowerPlanScheme();
            try
            {
                if (!string.IsNullOrEmpty(info) && info.Contains("GUID"))  //电源方案 GUID: 381b4222-f694-41f0-9685-ff5bb260df2e  (平衡) *
                {
                    scheme.SCHEME_GUID = info.Split(':')[1].Trim().Split('(')[0].Trim();
                    string tempname = info.Split(new string[] { scheme.SCHEME_GUID }, StringSplitOptions.None)[1].Trim().Substring(1); //info.Split(':')[1].Trim().Split('(')[1].Split(')')[0].Trim();
                    if (tempname.Substring(tempname.Length - 1) == "*")
                    {
                        scheme.SCHEME_GUID_NAME = tempname.Substring(0, tempname.Length - 3);
                        scheme.SCHEME_GUID_STATUS = true;
                    }
                    else
                    {
                        scheme.SCHEME_GUID_NAME = tempname.Substring(0, tempname.Length - 1);
                        scheme.SCHEME_GUID_STATUS = false;
                    }
                    if (getStatus)
                    {
                        if (!isListInfo)
                        {
                            scheme.SCHEME_GUID_STATUS = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetPowerPlanScheme error \r\n" + ex.ToString());
            }
            return scheme;
        }

        #endregion

        #region Set Default Values For All Power Plans 、Power Plan Scheme initialization

        public static bool SetDefaultValuesForAllPowerPlans()
        {
            foreach (PowerPlanScheme planScheme in GetPowerPlanSchemesInfo())
            {
                switch (planScheme.SCHEME_GUID_NAME)
                {
                    case "Maximum Performance":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 180);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 25);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 45);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 0);
                        break;
                    case "Maximum Energy Saving":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 120);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 5);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 45);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 0);
                        break;
                    case "Timers off (Presentation)":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 60);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 15);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 25);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 0);
                        break;
                    case "Power Source Optimized":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 30);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 15);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 0);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 120);
                        break;
                    case "Video Playback":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 15);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 5);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 25);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 60);
                        break;
                    case "Balanced":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 15);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 15);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 5);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 10);
                        break;
                    case "High performance":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 0);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 0);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 240);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 0);
                        break;
                    case "Power saver":
                        PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DiskAC, 3);
                        PowerSettingsOptionsControl(PowerSettingsOptions.DisplayAC, 5);
                        PowerSettingsOptionsControl(PowerSettingsOptions.SleepAC, 2);
                        PowerSettingsOptionsControl(PowerSettingsOptions.HibernateAC, 5);
                        break;
                    default:
                        break;
                }
            }
            return true;
        }

        public static void DPMPowerPlanSchemeIitialization()
        {
            foreach (PowerPlanScheme planScheme in GetPowerPlanSchemesInfo())
            {
                if (planScheme.SCHEME_GUID_NAME == "Maximum Performance")
                {
                    PowerPlanOptionsControl(PowerPlanOptions.SetPowerPlan, planScheme);
                    break;
                }
            }

            foreach (PowerPlanScheme planScheme in GetPowerPlanSchemesInfo())
            {
                bool flag = false;
                foreach (string planname in DPMPowerPlanDefault)
                {
                    if (planScheme.SCHEME_GUID_NAME == planname)
                    {
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    PowerPlanOptionsControl(PowerPlanOptions.DeletePowerPlan, planScheme);
                }
            }
        }

        #endregion

        # region GetPowerPlanTimeInfo

        /// <summary>GetPowerPlanTimeInfo</summary>
        /// <returns>display,hdd,sleep,hibernate</returns>
        public static Tuple<string, string, string, string> GetPowerPlanTimeInfo(PowerPlanScheme powerPlanScheme, bool PowerStatusIsAC = true)
        {
            Tuple<string, string, string, string> tuple;
            if (PowerStatusIsAC)
            {
                tuple = new Tuple<string, string, string, string>(PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_DISPLAY_AC_Setting_Second), PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_DISK_AC_Setting_Second),
                    PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_SLEEP_AC_Setting_Second), PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_HIBERNATE_AC_Setting_Second));
            }
            else
            {
                tuple = new Tuple<string, string, string, string>(PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_DISPLAY_DC_Setting_Second), PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_DISK_DC_Setting_Second),
                    PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_SLEEP_DC_Setting_Second), PowerPlanTimeConversionInformation(powerPlanScheme.SCHEM_HIBERNATE_DC_Setting_Second));
            }
            return tuple;
        }

        private static string PowerPlanTimeConversionInformation(int time)
        {
            if (time == 0)
            {
                return "Never";
            }
            else if (time == 60)
            {
                return "1 minute";
            }
            else if (time == 3600)
            {
                return "1 hour";
            }
            else if (time > 60 && time <= 18000)
            {
                if (time % 3600 == 0)
                {
                    return time / 3600 + " hours";
                }
                else
                {
                    return time / 60 + " minutes";
                }
            }
            else
            {
                return time + "seconds";
            }
        }

        #endregion

        #region run cmd command

        public static string RunCmd(string cmd, bool isEnterFlag = false, bool isAddC = false)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.FileName = "cmd.exe";
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.RedirectStandardError = true;
            processStartInfo.UseShellExecute = false;
            if (isAddC)
            {
                processStartInfo.Arguments = "/c" + cmd;
            }
            if (isEnterFlag)
            {
                processStartInfo.Verb = "Run as";
            }
            processStartInfo.CreateNoWindow = true;
            Process process = new Process
            {
                StartInfo = processStartInfo
            };
            process.Start();
            process.StandardInput.WriteLine(cmd);
            process.StandardInput.WriteLine("exit");
            process.StandardInput.AutoFlush = true;
            string output = process.StandardOutput.ReadToEnd();//get cmd output info
            process.WaitForExit();
            process.Close();
            return output;
        }

        #endregion

        #region power plan manual operation

        public enum PowerButtonOptions
        {
            DoNothing,
            Sleep,
            Hibernate,
            ShutDown,
            TurnOffTheDisplay,
            Unknown
        }

        public enum PowerSettingsType
        {
            PowerButtonAC,
            PowerButtonDC,
            SleepButtonAC,
            SleepButtonDC,
            CloseTheLidAC,
            CloseTheLidDC,
            SignInAC,
            SignInDC
        }

        public static bool ManualCreatePowerPlan(string planname)
        {
            UIAutomationControl automationControl = new UIAutomationControl();
            Process.Start("powercfg.cpl");
            Thread.Sleep(2000);
            AutomationElement elementCreate = automationControl.FindElementInRootElement(AutomationElement.RootElement, "LinkText", "Create a power plan");
            automationControl.InvokeByAutomationElement(elementCreate);
            Thread.Sleep(1000);
            AutomationElement elementEdit = automationControl.FindElementInRootElement(AutomationElement.RootElement, "EditBox_PlanName", "Plan name:");
            automationControl.ReadSetTextByAutomationElement(elementEdit, planname);
            if (planname.Length > 128)
            {
                automationControl.ReadSetTextByAutomationElement(elementEdit, planname.Substring(0, 129));
                string curText = automationControl.ReadSetTextByAutomationElement(elementEdit, planname, true);
                if (planname == curText || curText.Contains(planname.Substring(0, 128)) || curText.Contains(planname.Substring(0, 129)))
                {
                    return false;
                }
                else
                {
                    automationControl.ReadSetTextByAutomationElement(elementEdit, planname.Substring(0, 128));
                    curText = automationControl.ReadSetTextByAutomationElement(elementEdit, planname, true);
                    if (curText != planname.Substring(0, 128))
                    {
                        return false;
                    }
                }
            }
            else
            {
                if (automationControl.ReadSetTextByAutomationElement(elementEdit, planname, true) != planname)
                {
                    return false;
                }
            }
            Thread.Sleep(1000);
            AutomationElement elementNextBtn = automationControl.FindElementInRootElement(AutomationElement.RootElement, "Link_Accept", "Next");
            automationControl.InvokeByAutomationElement(elementNextBtn);
            Thread.Sleep(1000);
            AutomationElement elementCreateBtn = automationControl.FindElementInRootElement(AutomationElement.RootElement, "Link_Accept", "Create");
            automationControl.InvokeByAutomationElement(elementCreateBtn);
            Thread.Sleep(1000);
            return true;
        }

        public static bool ManualPowerButtonsOptionsControl(PowerButtonOptions option, PowerSettingsType type)
        {
            Process.Start("powercfg.cpl");
            Thread.Sleep(2000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElement elementChoosePowerBtn = automationControl.FindElementInRootElement(AutomationElement.RootElement, "LinkText", "Choose what the power buttons do");
            automationControl.InvokeByAutomationElement(elementChoosePowerBtn);
            Thread.Sleep(2000);
            AutomationElementCollection collection = automationControl.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "Control", "Combobox");
            AutomationElement element = GetAutomationElementForPowerAndSleepButtonSettings(collection, type);
            if (element == null)
            {
                return false;
            }
            automationControl.ExpandOrCollapseByAutomationElement(element);
            AutomationElement target = null;
            switch (option)
            {
                case PowerButtonOptions.DoNothing:
                    target = automationControl.FindElementByName(element, "Do nothing");
                    break;
                case PowerButtonOptions.Sleep:
                    target = automationControl.FindElementByName(element, "Sleep");
                    break;
                case PowerButtonOptions.Hibernate:
                    target = automationControl.FindElementByName(element, "Hibernate");
                    break;
                case PowerButtonOptions.ShutDown:
                    target = automationControl.FindElementByName(element, "Shut down");
                    break;
                case PowerButtonOptions.TurnOffTheDisplay:
                    target = automationControl.FindElementByName(element, "Turn off The display");
                    break;
                default:
                    return false;
            }
            if (target == null)
            {
                return false;
            }
            automationControl.SelectComBoxByAutomationElement(target);
            Thread.Sleep(1000);
            AutomationElement elementSaveBtn = automationControl.FindElementInRootElement(AutomationElement.RootElement, "Link_Accept", "Save changes");
            automationControl.InvokeByAutomationElement(elementSaveBtn);
            return true;
        }

        public static bool PowerButtonsOptionsControl(PowerPlanScheme scheme, PowerButtonOptions option, PowerSettingsType type)
        {
            switch (type)
            {
                case PowerSettingsType.PowerButtonAC:
                    RunCmd("powercfg -SETACVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS PBUTTONACTION " + (int)option);
                    break;
                case PowerSettingsType.PowerButtonDC:
                    RunCmd("powercfg -SETDCVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS PBUTTONACTION " + (int)option);
                    break;
                case PowerSettingsType.SleepButtonAC:
                    RunCmd("powercfg -SETACVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS SBUTTONACTION " + (int)option);
                    break;
                case PowerSettingsType.SleepButtonDC:
                    RunCmd("powercfg -SETDCVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS SBUTTONACTION " + (int)option);
                    break;
                case PowerSettingsType.CloseTheLidAC:
                    RunCmd("powercfg -SETACVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS LIDACTION " + (int)option);
                    break;
                case PowerSettingsType.CloseTheLidDC:
                    RunCmd("powercfg -SETDCVALUEINDEX " + scheme.SCHEME_GUID + " SUB_BUTTONS LIDACTION " + (int)option);
                    break;
                default:
                    return false;
            }
            return true;
        }

        private static AutomationElement GetAutomationElementForPowerAndSleepButtonSettings(AutomationElementCollection collectionCombox, PowerSettingsType type)
        {
            Dictionary<PowerSettingsType, AutomationElement> keys = PowerAndSleepButtonSettingsStatus(collectionCombox);
            foreach (var key in keys)
            {
                if (key.Key == type)
                {
                    return key.Value;
                }
            }
            return null;
        }

        private static Dictionary<PowerSettingsType, AutomationElement> PowerAndSleepButtonSettingsStatus(AutomationElementCollection collectionCombox)
        {
            Dictionary<PowerSettingsType, AutomationElement> keys = new Dictionary<PowerSettingsType, AutomationElement>();
            foreach (AutomationElement element in collectionCombox)
            {
                var nametemp = element.GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString().ToLower();
                if (nametemp.Contains("battery") && nametemp.Contains("power button"))
                {
                    keys.Add(PowerSettingsType.PowerButtonDC, element);
                }
                if (nametemp.Contains("battery") && nametemp.Contains("sleep button"))
                {
                    keys.Add(PowerSettingsType.SleepButtonDC, element);
                }
                if (nametemp.Contains("battery") && nametemp.Contains("close the lid"))
                {
                    keys.Add(PowerSettingsType.CloseTheLidDC, element);
                }
                if (nametemp.Contains("plugged") && nametemp.Contains("power button"))
                {
                    keys.Add(PowerSettingsType.PowerButtonAC, element);
                }
                if (nametemp.Contains("plugged") && nametemp.Contains("sleep button"))
                {
                    keys.Add(PowerSettingsType.SleepButtonAC, element);
                }
                if (nametemp.Contains("plugged") && nametemp.Contains("close the lid"))
                {
                    keys.Add(PowerSettingsType.CloseTheLidAC, element);
                }
            }
            return keys;
        }

        public static object GetCurrentPowerButtonSignInOptionsViaContract(bool isPowerButton = true)
        {
            try
            {
                string xmlinfo = GetPowerContractRequestInfo();
                string[] tempobj = xmlinfo.Split(new string[] { "<Data><![CDATA[" }, StringSplitOptions.None);  //string parsing 1
                string[] temp = tempobj[1].Split(new string[] { "]]></Data>" }, StringSplitOptions.None);  //string parsing 2
                string tempxml = temp[0]; //get standard xml
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(tempxml);
                XmlNode pbaction = xmldoc.DocumentElement.SelectSingleNode("//PowerButtonAction");
                XmlNode signinaction = xmldoc.DocumentElement.SelectSingleNode("//PasswordOnStandby");
                if (isPowerButton)
                {
                    switch (pbaction.InnerText.Trim().ToLower())
                    {
                        case "donothing":
                            return PowerButtonOptions.DoNothing;
                        case "sleep":
                            return PowerButtonOptions.Sleep;
                        case "hibernate":
                            return PowerButtonOptions.Hibernate;
                        case "shutdown":
                            return PowerButtonOptions.ShutDown;
                        case "poweroffdisplay":
                            return PowerButtonOptions.TurnOffTheDisplay;
                        default:
                            return PowerButtonOptions.Unknown;
                    }
                }
                else
                {
                    switch (signinaction.InnerText.Trim().ToLower())
                    {
                        case "yes":
                            return RequiredSignInOption.WakesUpFromSleep;
                        case "no":
                            return RequiredSignInOption.Never;
                        default:
                            return RequiredSignInOption.Unknow;
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static string GetPowerContractRequestInfo()
        {
            return NerveCenterHelper.GetRequestInfomationFromImController("SystemManagement.PowerProfile", "Get-AllPowerPlans", "", "<![CDATA[]]>");
        }

        //https://docs.microsoft.com/zh-cn/windows/win32/api/powrprof/nf-powrprof-powerreaddcvalueindex
        //https://docs.microsoft.com/zh-cn/windows/uwp/launch-resume/launch-settings-app
        //HKEY_LOCAL_MACHINE\SYSTEM\CurrentControlSet\Control\Power\PowerSettings

        [DllImport("PowrProf.dll", SetLastError = true)]
        public static extern uint PowerReadACValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, ref uint AcValueIndex);

        [DllImport("PowrProf.dll", SetLastError = true)]
        public static extern uint PowerReadDCValueIndex(IntPtr RootPowerKey, ref Guid SchemeGuid, ref Guid SubGroupOfPowerSettingsGuid, ref Guid PowerSettingGuid, ref uint AcValueIndex);

        public static object GetCurrentPowerButtonSignInOptionsViaWindowsAPI(PowerSettingsType type, bool isPowerButton = true)
        {
            uint getIndex = 99;
            uint flag = 0;
            Guid SchemeGuid = StringToGuid(GetCurrentPowerPlanSchemeInfo().SCHEME_GUID);
            Guid SubGroupOfPowerSettingsGuid = StringToGuid(PowerPlanScheme.GUID_SYSTEM_BUTTON_SUBGROUP);
            Guid PowerSettingGuid = Guid.Empty;
            switch (type)
            {
                case PowerSettingsType.PowerButtonAC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_POWERBUTTON_ACTION);
                    flag = PowerReadACValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.PowerButtonDC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_POWERBUTTON_ACTION);
                    flag = PowerReadDCValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.SleepButtonAC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_SLEEPBUTTON_ACTION);
                    flag = PowerReadACValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.SleepButtonDC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_SLEEPBUTTON_ACTION);
                    flag = PowerReadDCValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.CloseTheLidAC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_LID_ACTION);
                    flag = PowerReadACValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.CloseTheLidDC:
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_LID_ACTION);
                    flag = PowerReadDCValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.SignInAC:
                    SubGroupOfPowerSettingsGuid = StringToGuid(PowerPlanScheme.NO_SUBGROUP_GUID);
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_LOCK_CONSOLE_ON_WAKE);
                    flag = PowerReadACValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                case PowerSettingsType.SignInDC:
                    SubGroupOfPowerSettingsGuid = StringToGuid(PowerPlanScheme.NO_SUBGROUP_GUID);
                    PowerSettingGuid = StringToGuid(PowerPlanScheme.GUID_LOCK_CONSOLE_ON_WAKE);
                    flag = PowerReadACValueIndex(IntPtr.Zero, ref SchemeGuid, ref SubGroupOfPowerSettingsGuid, ref PowerSettingGuid, ref getIndex);
                    break;
                default:
                    flag = 2;
                    break;
            }
            if (flag != 0) // If the function succeeds, the return value is zero
            {
                if (isPowerButton)
                {
                    return PowerButtonOptions.Unknown;
                }
                else
                {
                    return RequiredSignInOption.Unknow;
                }
            }
            if (!isPowerButton)
            {
                switch (getIndex)
                {
                    case 0:
                        return RequiredSignInOption.Never;
                    case 1:
                        return RequiredSignInOption.WakesUpFromSleep;
                    default:
                        return RequiredSignInOption.Unknow;
                }
            }
            else
            {
                switch (getIndex)
                {
                    case 0:
                        return PowerButtonOptions.DoNothing;
                    case 1:
                        return PowerButtonOptions.Sleep;
                    case 2:
                        return PowerButtonOptions.Hibernate;
                    case 3:
                        return PowerButtonOptions.ShutDown;
                    case 4:
                        return PowerButtonOptions.TurnOffTheDisplay;
                    default:
                        return PowerButtonOptions.Unknown;
                }
            }
        }

        public static Guid StringToGuid(string str)
        {
            Guid guid = new Guid();
            if (Guid.TryParse(str, out guid))
            {
                Console.WriteLine("StringToGuid sucess");
            }
            else
            {
                Console.WriteLine("StringToGuid fail");
            }
            return guid;
        }

        #endregion

        #region Sign in / reset password / change password

        public enum RequiredSignInOption
        {
            Never,
            WakesUpFromSleep,
            Unknow
        }

        public static string ChangeWinUserPasswd(string username, string oldPwd, string newPwd)
        {
            try
            {
                DirectoryEntry localMachine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry user = localMachine.Children.Find(username, "user");
                object[] password = new object[] { oldPwd, newPwd };
                object ret = user.Invoke("ChangePassword", password);
                user.CommitChanges();
                localMachine.Close();
                user.Close();
                return "sucess";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public static bool ResetUserPassword(string userName, string pwd)
        {
            string _Path = "WinNT://" + Environment.MachineName;
            DirectoryEntry machine = new DirectoryEntry(_Path);
            DirectoryEntry user = machine.Children.Find(userName, "User");
            if (user != null)
            {
                user.Invoke("SetPassword", pwd);
                user.CommitChanges();
                user.Close();
                return true;
            }
            Console.WriteLine("ResetUserPassword fail,{0},{1}", userName, pwd);
            return false;
        }

        public static bool SetRequiredSignInOption(RequiredSignInOption requiredSignIn)
        {
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElement element = automationControl.FindElementInRootElement(AutomationElement.RootElement, "SystemSettings_Users_DelayLock_ComboBox");
            if (element == null)
            {
                return false;
            }
            automationControl.ExpandOrCollapseByAutomationElement(element);
            AutomationElementCollection collection = automationControl.FindElementsByClass(element, "ComboBoxItem");
            switch (requiredSignIn)
            {
                case RequiredSignInOption.Never:
                    foreach (AutomationElement e in collection)
                    {
                        if (e.GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString().ToLower().Contains("never"))
                        {
                            automationControl.SelectComBoxByAutomationElement(e);
                            break;
                        }
                    }
                    break;
                case RequiredSignInOption.WakesUpFromSleep:
                    foreach (AutomationElement e in collection)
                    {
                        if (e.GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString().ToLower().Contains("wakes up from sleep"))
                        {
                            automationControl.SelectComBoxByAutomationElement(e);
                            break;
                        }
                    }
                    break;
                default:
                    return false;
            }
            Thread.Sleep(2000);
            RequiredSignInOption option = (RequiredSignInOption)GetCurrentPowerButtonSignInOptionsViaWindowsAPI(PowerSettingsType.SignInAC, false);
            if (option == requiredSignIn)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static RequiredSignInOption GetRequiredSignInOption()
        {
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            var element = automationControl.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "ContentPresenter", "ComboBoxItem");
            if (element.Count == 1)
            {
                if (element[0].GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString().ToLower().Contains("wakes up from sleep"))
                {
                    return RequiredSignInOption.WakesUpFromSleep;
                }
                if (element[0].GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString().ToLower().Contains("never"))
                {
                    return RequiredSignInOption.Never;
                }
                return RequiredSignInOption.Unknow;
            }
            else
            {
                Console.WriteLine("ms-settings:signinoptions >>" + element.Count);
                return RequiredSignInOption.Unknow;
            }
        }

        public static bool ManualAddedUserPassword(string userName, string pwd)
        {
            bool flag = ManualAddedOrRemoveUserPasswordCommonAction(userName, true);
            if (!flag)
            {
                Console.WriteLine("Info:ManualAddedUserPassword via commandline fail,popwindow not show");
                return false;
            }
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElementCollection collection = automationControl.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "TouchEdit_Inner", "TouchEditInner");
            if (collection.Count < 3)
            {
                Console.WriteLine("Info:ManualAddedUserPassword popwindows not show,popwindow not show");
                return false;
            }
            automationControl.ReadSetTextByAutomationElement(collection[0], pwd);
            automationControl.ReadSetTextByAutomationElement(collection[1], pwd);
            automationControl.ReadSetTextByAutomationElement(collection[2], "tips");
            AutomationElement elementNextFinish = automationControl.FindElementByClass("Settings", "Button1", "", "TouchButton");
            automationControl.InvokeByAutomationElement(elementNextFinish);
            Thread.Sleep(2000);
            automationControl.InvokeByAutomationElement(elementNextFinish);
            Thread.Sleep(5000);
            Console.WriteLine("Info:ManualAddedUserPassword finishing...");
            for (int i = 0; i < 10; i++)
            {
                AutomationElement element = automationControl.FindElementInRootElement(AutomationElement.RootElement, "SystemSettings_Users_DelayLock_ComboBox", null, 5);
                if (element != null)
                {
                    Console.WriteLine("Info:ManualAddedUserPassword finished.");
                    Thread.Sleep(5000);
                    SettingsBase.KillProcess("SystemSettings");
                    return true;
                }
                Thread.Sleep(5000);
            }
            Console.WriteLine("Info：ManualAddedUserPassword Time Out!");
            SettingsBase.KillProcess("SystemSettings");
            return false;
        }

        public static bool ManualRemoveUserPassword(string userName)
        {
            bool flag = ManualAddedOrRemoveUserPasswordCommonAction(userName, false);
            if (!flag)
            {
                Console.WriteLine("Info:ManualRemoveUserPassword via commandline fail,popwindow not show");
                return false;
            }
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElementCollection collection = automationControl.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "TouchEdit_Inner", "TouchEditInner");
            if (collection.Count == 0)
            {
                Console.WriteLine("Info:ManualRemoveUserPassword popwindow not show");
                return false;
            }
            automationControl.ReadSetTextByAutomationElement(collection[0], "1");
            AutomationElement elementNextFinish = automationControl.FindElementByClass("Settings", "Button1", "", "TouchButton");
            automationControl.InvokeByAutomationElement(elementNextFinish);
            Thread.Sleep(2000);
            automationControl.InvokeByAutomationElement(elementNextFinish);
            Thread.Sleep(2000);
            automationControl.InvokeByAutomationElement(elementNextFinish);
            Thread.Sleep(5000);
            Console.WriteLine("Info:ManualRemoveUserPassword finishing...");
            for (int i = 0; i < 20; i++)
            {
                AutomationElement element = automationControl.FindElementInRootElement(AutomationElement.RootElement, "SystemSettings_Users_DelayLock_ComboBox", null, 5);
                if (element == null)
                {
                    Console.WriteLine("Info:ManualRemoveUserPassword finished.");
                    Thread.Sleep(5000);
                    SettingsBase.KillProcess("SystemSettings");
                    return true;
                }
                Thread.Sleep(5000);
            }
            Console.WriteLine("Info：ManualRemoveUserPassword Time Out!");
            SettingsBase.KillProcess("SystemSettings");
            return false;

        }

        private static bool ManualAddedOrRemoveUserPasswordCommonAction(string userName, bool isAddpw = false)
        {

            if (string.IsNullOrEmpty(userName))
            {
                userName = Environment.UserName;
            }
            bool flag = false;
            if (isAddpw)
            {
                flag = ResetUserPassword(userName, null);
            }
            else
            {
                flag = ResetUserPassword(userName, "1");
            }
            if (!flag)
            {
                return false;
            }
            Process.Start("ms-settings:signinoptions");
            Thread.Sleep(3000);
            UIAutomationControl automationControl = new UIAutomationControl();
            AutomationElementCollection signincollection = automationControl.FindElementsByClass(AutomationElement.RootElement, "ListViewItem");
            foreach (AutomationElement elementPwd in signincollection)
            {
                string temp = elementPwd.GetCurrentPropertyValue(AutomationElement.NameProperty, false).ToString();
                Console.WriteLine("sign in option log:" + temp);
                if (temp.Contains("Password Sign in with your account"))
                {
                    automationControl.SelectComBoxByAutomationElement(elementPwd);
                    automationControl.ExpandOrCollapseByAutomationElement(elementPwd);
                    Console.WriteLine("sign in option select");
                    Thread.Sleep(3000);
                    break;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                AutomationElement elementAddChange = automationControl.FindElementByClass("Settings", "AddOrChangePassword_Button", "", "Button");
                automationControl.InvokeByAutomationElement(elementAddChange);
                Thread.Sleep(4000);
                AutomationElementCollection pwEdit = automationControl.FindElementsByClasssNameAndAutomationIDCollection(AutomationElement.RootElement, "TouchEdit_Inner", "TouchEditInner");
                if (pwEdit.Count != 0)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Modify Vantage Server

        public enum VantageServiceOption
        {
            QA,
            QA2,
            Stage,
            SITBeta,
            Product,
            Default
        }

        public static void ChangeVantageService(VantageServiceOption serviceOption)
        {
            string packeageName = string.Format("Packages\\{0}\\LocalState\\config.json", VantageConstContent.GetVantageUwpAppName() + "_k1h2ywk1493x8");
            string companionLogPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), packeageName);
            if (File.Exists(companionLogPath))
            {
                File.Delete(companionLogPath);
                Console.WriteLine("Note: ChangeVantageService del file," + companionLogPath);
            }
            if (!VantageConstContent.NotLEMask)  //Le Vantage server 
            {
                if (serviceOption == VantageServiceOption.QA2 || serviceOption == VantageServiceOption.Default)
                {
                    Console.WriteLine("Note: Le vantage ChangeVantageService Run," + serviceOption);
                }
                else
                {
                    Console.WriteLine("Note: Le vantage ChangeVantageService Not run," + serviceOption);
                    return;
                }
            }
            switch (serviceOption)
            {
                case VantageServiceOption.Product:
                    File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\product.json")));
                    break;
                case VantageServiceOption.SITBeta:
                    File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\beta.json")));
                    break;
                case VantageServiceOption.QA:
                    File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\qa.json")));
                    break;
                case VantageServiceOption.QA2:
                    if (!VantageConstContent.NotLEMask)
                    {
                        File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\qa.json")));
                    }
                    else
                    {
                        File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\qa-2.json")));
                    }
                    break;
                case VantageServiceOption.Stage:
                    File.AppendAllText(companionLogPath, File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\DPM\\stage.json")));
                    break;
                default:
                    VantageCommonHelper.ReplaceFile();
                    break;
            }
            Console.WriteLine("Note: ChangeVantageService sucess," + serviceOption);
        }

        #endregion

        #region Find Windows Element Exist With Page Source

        public static bool FindWindowsElementExistWithPageSource(string pageSource, WindowsElement element, string tips = null)
        {
            try
            {
                XmlDocument xmldoc = new XmlDocument();
                xmldoc.LoadXml(pageSource);
                string xpath = "//*[@AutomationId='" + element.GetAttribute("AutomationId") + "']";
                XmlNode xmlTarget = xmldoc.DocumentElement.SelectSingleNode(xpath);
                if (xmlTarget != null)
                {
                    return true;
                }
                Console.WriteLine("Tips: FindWindowsElementExistWithPageSource() Fail," + tips);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Note: FindWindowsElementExistWithPageSource() Fail," + ex.ToString());
            }
            return false;
        }
        #endregion

        #region Write Log to Test Report

        public static string WriteLogToTestReport(string detail, string type)
        {
            try
            {
                switch (type.ToLower())
                {
                    case "datetime":
                        VantageConstContent.ShowTips = DateTime.Now.ToString("yyyy-MM-dd");
                        break;
                    case "cpumemory":
                        VantageConstContent.ShowTips = GetMemoryInfo() + "\r\n" + PerformanceCounterFun("Processor", "_Total", "% Processor Time");
                        break;
                    case "toolbarcpumemory":
                        VantageConstContent.ShowTips = UsingPerfmon("QuickSettingEx") + "\r\n" + UsingMemory("QuickSettingEx");
                        break;
                    case "toolbareventerror":
                        VantageConstContent.ShowTips = GetToolbarEventErrorLog();
                        break;
                    case "settingsaddinheartbeatdata":
                        VantageConstContent.ShowTips = GetSettingsAddinHeartBeatData();
                        break;
                    case "sealedbatterytoastlog":
                        VantageConstContent.ShowTips = GetSealedBatteryToastLog();
                        break;
                    default:
                        VantageConstContent.ShowTips = " ";
                        break;
                }
                return "Type:" + type + " detail:" + detail + "\r\nShowTips：\r\n" + VantageConstContent.ShowTips;
            }
            catch (Exception ex)
            {
                return "WriteLogToTestReport() Exception Info:" + ex.Message;
            }
        }

        #endregion

        #region CPU Memory Info

        [DllImport("kernel32")]
        public static extern void GetSystemInfo(ref CPU_INFO cpuinfo);

        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MEMORY_INFO meminfo);

        [DllImport("kernel32")]
        public static extern void GetSystemTime(ref SYSTEMTIME_INFO stinfo);

        //定义CPU的信息结构  
        [StructLayout(LayoutKind.Sequential)]
        public struct CPU_INFO
        {
            public uint dwOemId;
            public uint dwPageSize;
            public uint lpMinimumApplicationAddress;
            public uint lpMaximumApplicationAddress;
            public uint dwActiveProcessorMask;
            public uint dwNumberOfProcessors;
            public uint dwProcessorType;
            public uint dwAllocationGranularity;
            public uint dwProcessorLevel;
            public uint dwProcessorRevision;
            public uint dwProcessorLoad;
        }

        //定义内存的信息结构  
        [StructLayout(LayoutKind.Sequential)]
        public struct MEMORY_INFO
        {
            public uint dwLength;
            public uint dwMemoryLoad;
            public uint dwTotalPhys;
            public uint dwAvailPhys;
            public uint dwTotalPageFile;
            public uint dwAvailPageFile;
            public uint dwTotalVirtual;
            public uint dwAvailVirtual;
        }

        //定义系统时间的信息结构  
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME_INFO
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        public static string GetMemoryInfo()
        {
            MEMORY_INFO MemInfo;
            MemInfo = new MEMORY_INFO();
            GlobalMemoryStatus(ref MemInfo);
            return "Percentage of Memory Usage:" + MemInfo.dwMemoryLoad.ToString() + "%\r\n" +
                    "Memory Total Size:" + MemInfo.dwTotalPhys.ToString() + "字节\r\n" +
                    "Memory Available Size::" + MemInfo.dwAvailPhys.ToString() + "字节\r\n";
        }

        public static string PerformanceCounterFun(string CategoryName, string InstanceName, string CounterName)
        {
            PerformanceCounter pc = new PerformanceCounter(CategoryName, CounterName, InstanceName);
            while (true)
            {
                pc.NextValue();
                Thread.Sleep(1000);
                float cpuLoad1 = pc.NextValue();
                Thread.Sleep(1000);
                float cpuLoad2 = pc.NextValue();
                Thread.Sleep(1000);
                float cpuLoad3 = pc.NextValue();
                float cpuLoad = (cpuLoad1 + cpuLoad2 + cpuLoad3) / 3;
                return "Percentage of CPU Usage:" + cpuLoad1 + "%";
            }
        }

        public static string UsingPerfmon(string pname)
        {
            try
            {
                using (PerformanceCounter p = new PerformanceCounter("Process", "% Processor Time", pname))
                {
                    string info = string.Empty;
                    for (int i = 0; i < 10; i++)
                    {
                        float p1 = p.NextValue() / Environment.ProcessorCount;
                        Thread.Sleep(500);
                        info += p1 + "%;";
                    }
                    return "Percentage of CPU Usage:" + info;
                }
            }
            catch (Exception ex)
            {
                return "Percentage of CPU Usage Exception:" + ex.Message;
            }

        }

        public static string UsingMemory(string pname)
        {
            try
            {
                using (PerformanceCounter p = new PerformanceCounter("Process", "Working Set - Private", pname))
                {
                    string info = string.Empty;
                    for (int i = 0; i < 3; i++)
                    {
                        float p1 = p.NextValue() / (1024 * 1024);
                        Thread.Sleep(1000);
                        info += p1 + ";";
                    }
                    return "Memory Usage (MB):" + info;
                }
            }
            catch (Exception ex)
            {
                return "Memory Usage (MB) Exception:" + ex.Message;
            }
        }

        #endregion
        public static string GetToolbarEventErrorLog()
        {
            if (string.IsNullOrEmpty(string.Join("\r\n", GetEventLogInfo("QuickSetting", @"C:\Windows\System32\winevt\Logs\Application.evtx", "2", 24))))
            {
                return "Toolbar has no throw exceptions in eventlog";
            }
            return string.Join("\r\n", GetEventLogInfo("QuickSetting", @"C:\Windows\System32\winevt\Logs\Application.evtx", "2", 24));
        }

        /// <summary>
        /// target : Filter the required log information
        /// eventLogfile : event log file
        /// logLevel : 
        /// 2 means filtering the error part of the content 
        /// 3 means filtering the warn part of the content 
        /// 4 means filtering the information part of the content 
        /// logInhour : Means to get logs generated within a few hours 
        /// </summary>
        /// <returns></returns>
        public static List<string> GetEventLogInfo(string target, string eventLogfile, string logLevel, int logInhour = 0)
        {
            List<string> loglist = new List<string>();
            try
            {
                using (var reader = new EventLogReader(eventLogfile, PathType.FilePath))
                {
                    EventRecord record;
                    while ((record = reader.ReadEvent()) != null)
                    {
                        if (string.IsNullOrEmpty(record.FormatDescription()) || AddEventRecordDescriptionToList(target, record) == null)
                        {
                            continue;
                        }

                        if (logInhour != 0)
                        {
                            int seconds = IntelligentCoolingBaseHelper.GetDiffTime(record.TimeCreated.ToString(), DateTime.Now.ToString());
                            if (seconds >= logInhour * 3600)
                            {
                                continue;
                            }
                        }

                        if (!string.IsNullOrEmpty(logLevel) && record.Level.ToString() == logLevel)
                        {
                            loglist.Add(AddEventRecordDescriptionToList(target, record));
                        }
                        else
                        {
                            loglist.Add(AddEventRecordDescriptionToList(target, record));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" GetEventLogInfo() Exception Info:" + ex.ToString());
                loglist.Add("Note: GetEventLogInfo() fail" + ex.Message);
            }
            return loglist;
        }

        private static string AddEventRecordDescriptionToList(string target, EventRecord record)
        {
            if (string.IsNullOrEmpty(target))
            {
                return record.TimeCreated.ToString() + "\r\n" + record.FormatDescription();
            }
            else
            {
                if (!string.IsNullOrEmpty(record.FormatDescription()) && record.FormatDescription().Contains(target))
                {
                    return record.TimeCreated.ToString() + "\r\n" + record.FormatDescription();
                }
            }
            return null;
        }

        private static string GetSettingsAddinHeartBeatData()
        {
            string logstr = "Heart Beat Value: ";
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(@"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx", PathType.FilePath))
            {
                EventRecord record;
                string addinlevel = HSToolbarPage.GetAddinLevel();
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoBatteryGaugePackage") && record.FormatDescription().Contains(addinlevel))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                int index = 0;
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    string pattern = @"{""name"":""(.*?)"",""value"":""(.*?)""(}?)";
                    foreach (Match match in Regex.Matches(str, pattern))
                    {
                        logstr = logstr + match.Value + "\n";
                    }
                }
            }
            return logstr;
        }

        private static string GetSealedBatteryToastLog()
        {
            var files = Directory.GetFiles(@"C:\ProgramData\Lenovo\Modern\Logs", "*.log");
            string logName = null;
            string logstr = "SealedBatteryToastLog: ";
            foreach (var item in files)
            {
                if (item.Contains("Log.Plugins.IdeaNotebookPlugin"))
                {
                    logName = item;
                }

            }
            if (logName != null)
            {
                foreach (string str in File.ReadAllLines(logName, Encoding.Default))
                {
                    logstr = logstr + str + "\n";
                }
            }
            return logstr;
        }
    }
}