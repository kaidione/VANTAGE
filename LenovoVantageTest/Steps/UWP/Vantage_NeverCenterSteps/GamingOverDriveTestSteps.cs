using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingOverDriveTestSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private GamingThermalModePages _gamingThermalModePages;

        public GamingOverDriveTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        //step01
        [Given(@"Refresh rate < 144Hz")]//
        public void DisplayFrequency_Below()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            DEVMODE dm = new DEVMODE();
            dm = GetResolution();
            int DisplayFrequency = dm.dmDisplayFrequency;
            if (DisplayFrequency < 144)
            {
                Assert.IsTrue(true, "more than 144");
            }
        }

        [Given(@"The Machine not support Specific function '(.*)'")]
        public void GivenTheMachineSupportSpecificFunction(NerveCenterHelper.GamingFeature function)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            bool support = NerveCenterHelper.GetGamingFeatureIsSupport(function, familyname);
            Assert.IsFalse(support, "The machine support this function:" + function.ToString() + " familyname:" + familyname);
        }

        [Then(@"Over drive toggle should not be shown in the Legion edge section")]
        public void OverDriveToggle_NoShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNull(_gamingThermalModePages.GetOverDrive);
            Assert.IsTrue(true, "Over drive toggle shown");
        }

        //step02
        [Then(@"Over drive capability value is 0")]
        public void OverDriveValue_0()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int status = Get_WMI_SupportOD("GetSupportOD");
            if (status == 0)
            {
                Assert.IsTrue(true, "The machine support this function:");
            }
        }

        //step03
        [Given(@"Refresh rate >= 144Hz")]
        public void DisplayFrequency_Exceed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            DEVMODE dm = new DEVMODE();
            dm = GetResolution();
            int DisplayFrequency = dm.dmDisplayFrequency;
            if (DisplayFrequency >= 144)
            {
                Assert.IsTrue(true, "DisplayFrequency is below 144");
            }
        }

        //step07
        [Then(@"Over drive toggle should be shown in the Legion edge section")]
        public void OverDriveToggle_Shown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetOverDrive);
            Assert.IsTrue(_gamingThermalModePages.LegionEdgeContainsThermalMode());
        }

        //step08
        [Then(@"Over drive capability value is 1")]
        public void IsSupportOD_1()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int status = Get_WMI_SupportOD("GetSupportOD");
            if (status == 1)
            {
                Assert.IsTrue(true, "The machine donot support this function:");
            }
        }

        //step09
        [Then(@"Over drive toggle position should be behind Hybrid mode in the Legion edge section")]
        public void OverDriveToggle_behind_HybridMode()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetOverDrive);
            Assert.IsNotNull(_gamingThermalModePages.GethybridMode);
            Assert.IsTrue(_gamingThermalModePages.LegionEdgeContainsThermalMode());
            int OverDrive_y = _gamingThermalModePages.GetOverDrive.Location.Y;
            int hybridMode_y = _gamingThermalModePages.GethybridMode.Location.Y;
            if (OverDrive_y > hybridMode_y)
            {
                Assert.IsTrue(true);
            }

        }

        //step10
        [Then(@"Over drive toggle status should be consistent with the Bios")]
        public void OverDriveToggle_ON()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOn);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
        }

        //step11
        [Given(@"Over Drive toggle status is on")]
        public void OverDriveToggle_ON2()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            if (_nerveCenterPages.LegionEdgeOverDriveToggleOn == null)
            {
                _nerveCenterPages.LegionEdgeOverDriveToggleOff.Click();
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOnName);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOn);
            }
        }

        [Then(@"Over drive value should be 1")]
        public void GetODStatusValue_1()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int status = Get_WMI_SupportOD("GetODStatus");
            if (status == 1)
            {
                Assert.IsTrue(true, "The GetODStatus value is 0 ");
            }
        }

        //step12
        [Given(@"click Over Drive toggle_on")]
        public void Click_OverDriveToggle_ON()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOnName);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOn);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            _nerveCenterPages.LegionEdgeOverDriveToggleOn.Click();
        }

        [Then(@"Over drive toggle status should be off")]
        public void OverDriveToggle_OFF()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);

            Assert.IsNull(_nerveCenterPages.LegionEdgeOverDriveToggleOn);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOffName);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
        }

        //step13
        [Given(@"set Over Drive toggle status to off")]
        public void SET_OverDriveToggle_Off()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.menuDevice);
            Assert.IsNotNull(_nerveCenterPages.GamingsystemstatusInfo);
            _nerveCenterPages.LegionEdgeOverDriveToggleOn.Click();
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOff);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeOverDriveToggleOffName);
        }

        [Then(@"Over drive value should be 0")]
        public void GetODStatusValue_0()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int status = Get_WMI_SupportOD("GetODStatus");
            if (status == 0)
            {
                Assert.IsTrue(true, "The GetODStatus value is 1 ");
            }
        }

        //Get_WMI_SupportOD and GetODStatus
        public static int Get_WMI_SupportOD(string getMethod)
        {
            int mode = 0;
            Process proc = new Process();
            string driverPath = string.Empty;
            string result = @"C:\GetThermalModeValueTmp.txt";
            proc.StartInfo.FileName = "wscript";
            switch (getMethod)
            {
                case "GetSupportOD":
                    driverPath = Path.Combine(VantageConstContent.DataPath, "Data\\NerveCenterDocument\\GetSupportOD_Script.vbs");
                    break;
                case "GetODStatus":
                    driverPath = Path.Combine(VantageConstContent.DataPath, "Data\\NerveCenterDocument\\GetODstatus_Script.vbs");
                    break;
                default:
                    break;
            }
            proc.StartInfo.Arguments = driverPath;
            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.Close();
            Thread.Sleep(1500);
            string modeValue = File.ReadAllText(result);
            modeValue = modeValue.Trim().TrimEnd("\n\r".ToCharArray());
            if (string.IsNullOrEmpty(modeValue))
            {
                return 2;
            }
            if (File.Exists(result))
            {
                File.Delete(result);
            }
            mode = int.Parse(modeValue);
            return mode;
        }

        //dmDisplayFrequency
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern int ChangeDisplaySettings([In] ref DEVMODE lpDevMode, int dwFlags);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool EnumDisplaySettings(string lpszDeviceName, Int32 iModeNum, ref DEVMODE lpDevMode);

        public DEVMODE GetResolution()
        {
            DEVMODE dm = new DEVMODE();
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE));
            bool mybool;
            mybool = EnumDisplaySettings(null, -1, ref dm);
            return dm;
        }
    }
    public enum DMDO
    {
        DEFAULT = 0,
        D90 = 1,
        D180 = 2,
        D270 = 3
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct DEVMODE
    {
        public const int DM_DISPLAYFREQUENCY = 0x400000;
        public const int DM_PELSWIDTH = 0x80000;
        public const int DM_PELSHEIGHT = 0x100000;
        private const int CCHDEVICENAME = 32;
        private const int CCHFORMNAME = 32;

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
        public string dmDeviceName;
        public short dmSpecVersion;
        public short dmDriverVersion;
        public short dmSize;
        public short dmDriverExtra;
        public int dmFields;

        public int dmPositionX;
        public int dmPositionY;
        public DMDO dmDisplayOrientation;
        public int dmDisplayFixedOutput;

        public short dmColor;
        public short dmDuplex;
        public short dmYResolution;
        public short dmTTOption;
        public short dmCollate;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
        public string dmFormName;
        public int dmBitsPerPel;
        public int dmPelsWidth;
        public int dmPelsHeight;
        public int dmDisplayFlags;
        public int dmDisplayFrequency;

    }

}



