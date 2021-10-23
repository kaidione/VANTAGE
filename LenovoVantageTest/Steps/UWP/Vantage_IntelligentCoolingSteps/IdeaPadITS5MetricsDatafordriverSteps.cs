using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class VAN17534_IdeaPadITS5MetricsDatafordriverSteps
    {
        public string _ITSRegistryValuePath = "hklm\\SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION\\Data";
        public string _ITSYMCRegistryPath = "hklm\\SOFTWARE\\Lenovo\\MoccaMode\\Mode";
        private WindowsDriver<WindowsElement> _session;
        private InformationalWebDriver _webDriver;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public int BeforeBright = IntelligentCoolingBaseHelper.GetMonitorBrightness();
        private string _thinkitsPluginPath = @"C:\ProgramData\Lenovo\ImController\Plugins\ThinkSmartSensePlugin";
        private string _thinkitsNewPluginPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\ITS files\ThinkSmartSensePlugin");

        public VAN17534_IdeaPadITS5MetricsDatafordriverSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"ITSlast mode is (.*)")]
        public void ThenITSlastModeIsISTD(String ITSMode)
        {
            Thread.Sleep(1000);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string temp = _intelligentcoolingPages.getInfoFromLog();
            var lastmode = temp.Split(',')[1];
            if (lastmode.Contains(ITSMode))
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }


        [Then(@"ITSCurrent mode is (.*)")]
        public void ThenITSCurrentModeIs(String ITSMode)
        {
            var iTSMode = _baseHelper.GetIntelligentCoolingMetricDataInfo().Split('-')[0];
            if (iTSMode == ITSMode)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }

        [Given(@"run (.*)")]
        public void GivenRunCreaterApp(string Pro)
        {
            switch (Pro.ToLower())
            {
                case "dnf":
                    Process.Start(@"C:\Program Files\DNF\TCLS\Client.exe");
                    break;
                case "csgo":
                    Process.Start("steam://rungameid/730");
                    break;
                case "photoshop":
                    Process.Start(@"C:\photoshop.exe");
                    break;
                case "aida":
                    Process.Start(@"C:\Aida64.exe");
                    break;
                case "firefox":
                    Process.Start(@"C:\Program Files\Mozilla Firefox\firefox.exe");
                    break;
                case "bilibili":
                    Process.Start(@"shell:appsFolder\36699Atelier39.forWin10_pke1vz55rvc1r!App");
                    break;
                case "wechat":
                    Process.Start(@"C:\Program Files (x86)\Tencent\WeChat\WeChat.exe");
                    break;
                case "qqlive":
                    Process.Start(@"C:\Program Files (x86)\Tencent\QQLive\QQLive.exe");
                    break;
                case "ie":
                    Process.Start("iexplore.exe");
                    break;
            }
        }

        [Given(@"Minimize (.*)")]
        public void GivenMinimizePhotoshop(string Pro)
        {
            WebForm2.MiniMizeAppication(Pro);
        }

        [Given(@"Restart ITS Service")]
        public void GivenRestartITSService()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(1);
            _baseHelper.IntelligentCoolinggIMCServiceControl(0);
        }

        [Given(@"Stop ITS Service")]
        public void GivenStopITSService()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(1);
        }

        [Given(@"Start ITS Service")]
        public void GivenStartITSService()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(0);
        }

        [Given(@"lever less than (.*)")]
        public void GivenLeverLessThan(int p0)
        {
            var level = VantageCommonHelper.GetCurrentBatteryPercent();
            while (level >= 30)
            {
                level = VantageCommonHelper.GetCurrentBatteryPercent();
                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        [Given(@"Battery Percentage more than (.*)")]
        public void GivenBatteryPercentageMoreThan(int p0)
        {
            var level = VantageCommonHelper.GetCurrentBatteryPercent();
            while (level <= p0)
            {
                level = VantageCommonHelper.GetCurrentBatteryPercent();
                Thread.Sleep(TimeSpan.FromSeconds(300));
            }
        }

        [Given(@"launch Start menu")]
        public void GivenLaunchStartMenu()
        {
            KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 0, 0);
            KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 2, 0);
        }

        [Then(@"Before Brightness less than After Brightness")]
        public void ThenBeforeBrightnessLessThanAfterBrightness()
        {
            int AF = IntelligentCoolingBaseHelper.GetMonitorBrightness();
            Assert.True(BeforeBright > AF);
        }

        [Given(@"click read more")]
        public void GivenClickReadMore()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.ReadMore?.Click();
        }

        [Given(@"click more info")]
        public void GivenClickMoreInfo()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink?.Click();
        }

        [Given(@"click less info for ITS")]
        public void GivenClickLessInfoForIts()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20LessLink?.Click();
        }

        [Given(@"close popwindow")]
        public void GivenClosePopwindow()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.popupwindowclosebutton?.Click();
            if (!VantageConstContent.NotLEMask)
            {
                Assert.IsNull(_intelligentcoolingPages.popupwindowclosebutton, "LE DYTC5 close button exist, it's a bug!");
                _intelligentcoolingPages.xicon?.Click();
            }
        }

        [Given(@"close x icon")]
        public void GivenCloseXIcon()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            _intelligentcoolingPages.xicon?.Click();
        }

        [Given(@"move thinkpad plugin")]
        public void GivenMoveThinkpadPlugin()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            if (Directory.Exists(@"C:\ThinkSmartSensePlugin"))
            {
                Directory.Delete(@"C:\ThinkSmartSensePlugin", true);
            }
            if (Directory.Exists(_thinkitsPluginPath))
            {
                Directory.Move(_thinkitsPluginPath, @"C:\ThinkSmartSensePlugin");
                _baseHelper.IntelligentCoolinggIMCServiceControl(2);
            }
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }

        [Given(@"recover thinkpad plugin")]
        public void GivenRecoverThinkpadPlugin()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(3);
            if (!Directory.Exists(_thinkitsPluginPath))
            {
                Directory.CreateDirectory(_thinkitsPluginPath);
            }
            SmartStandbyTestSteps sst = new SmartStandbyTestSteps(_webDriver);
            sst.CopyFolder(_thinkitsNewPluginPath, _thinkitsPluginPath);
            _baseHelper.IntelligentCoolinggIMCServiceControl(2);
        }
    }


}
public class WebForm2 : System.Web.UI.Page
{
    [DllImport("user32.dll", EntryPoint = "PostMessage")]
    public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
    [DllImport("User32.dll ", EntryPoint = "FindWindow")]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
    [DllImport("user32.dll", EntryPoint = "SetWindowPos", CharSet = CharSet.Auto)]
    private static extern int SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int y, int Width, int Height, int flags);
    [DllImport("User32.dll ", EntryPoint = "SendMessage")]
    private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);
    public const int WM_SYSCOMMAND = 0x112;
    public const int SC_MINIMIZE = 0xF020;
    public const int SC_MAXIMIZE = 0xF030;

    public static void MiniMizeAppication(string processName)
    {
        Process[] processs = Process.GetProcessesByName(processName);
        if (processs != null)
        {
            foreach (Process p in processs)
            {
                IntPtr handle = FindWindow(null, p.MainWindowTitle);
                //IntPtr handle = FindWindow("YodaoMainWndClass",null);
                PostMessage(handle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
            }
        }
    }
}


