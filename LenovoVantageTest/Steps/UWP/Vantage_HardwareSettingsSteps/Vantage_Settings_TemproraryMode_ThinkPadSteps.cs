using BoDi;
using LenovoVantageTest.Commands;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

[Binding]
public class Vantage_Settings_TemproraryMode_ThinkPadSteps
{
    private InformationalWebDriver _webDriver;
    private HSQuickSettingsPage _hsQuickSettingsPage;
    public HSSystemUpdatePage _systemUpdatePage;
    public readonly IObjectContainer objectContainer;
    public static int wid = Screen.PrimaryScreen.Bounds.Width;
    public static int hei = Screen.PrimaryScreen.Bounds.Height;
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
    private static string inifilename = "PWMSIMDF.INI";
    private static string inifilepath = "C:\\Windows\\SysWOW64\\Lenovo\\PowerMgr" + "\\" + inifilename;
    //private static string iniFilePath = Path.Combine(VantageConstContent.DataPath, "Data\\Tools\\Battery tools\\Temproray mode tool for think\\Temporary mode\\PWMSIMDF.INI");
    private static string iniFilePath = Path.Combine(VantageConstContent.DataPath, "Data\\Tools\\PWMSIMDF.INI");
    private static string RestoreIsPICapable;
    private static string RestoreIsDLSCapable;
    private static string RestoreCurrentOperatingMode;


    public Vantage_Settings_TemproraryMode_ThinkPadSteps(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [AfterFeature("CheckLEBatteryChargeThresholdOneBattery")]
    public static void AfterFeature()
    {
        GivenMachineIsThinkPadAndSupportTemprorayPIDLSMode();
    }

    [Given(@"Into Battery Details page")]
    public void GivenIfTemporaryModeIsEnabledAndThenLaunchBatteryDetailsPage()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.seeBatteryDetailsLink);
        bool isEnble = _hsQuickSettingsPage.seeBatteryDetailsLink.Enabled;
        int times = 20;
        while (!isEnble)
        {
            if (times == 0)
            {
                break;
            }
            Thread.Sleep(1000);
            isEnble = _hsQuickSettingsPage.seeBatteryDetailsLink.Enabled;
            times--;
        }
        _hsQuickSettingsPage.seeBatteryDetailsLink.Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [When(@"Click on the question mark")]
    public void WhenClickOnTheQuestionMark()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink);
        _hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink.Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"Battery Details Page Show Question Mark")]
    public void ThenBatteryDetailsPageShowQuestionMark()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink, "Element 'See Battery Details QuestionMark' Is Not Found");
    }

    [Then(@"Battery Details Page Not Show Tooltip")]
    public void ThenBatteryDetailsPageNotShowTooltip()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(_hsQuickSettingsPage.questionMarkMessage, "Element 'QuestionMark Message Tooltip' Is Found");
    }

    [When(@"Click on the here for more information")]
    public void WhenClickOnTheHereForMoreInformation()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.BatteryDetailsQuestionMarkClickHere);
        _hsQuickSettingsPage.BatteryDetailsQuestionMarkClickHere.Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"Check Question Mark Message display using the name specified with json path '(.*)'")]
    public void ThenCheckQuestionMarkMessage(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessage, "questionMarkMessage is null");
        if (VantageTypePlan != VantageType.LE)
        {
            Assert.IsTrue(_hsQuickSettingsPage.questionMarkMessage.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
        }
        else
        {
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.questionMarkMessage).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.QuestionMarkMessageInformation, "QuestionMarkMessageInformation is null");
            Assert.IsTrue(_hsQuickSettingsPage.QuestionMarkMessageInformation.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.QuestionMarkMessageInformation").ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.QuestionMarkMessageHere, "QuestionMarkMessageHere is null");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.QuestionMarkMessageHere).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.QuestionMarkMessageHere").ToString()));
        }
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"Check Question Mark Click Here Message display using the name specified with json path '(.*)' '(.*)' '(.*)' '(.*)'")]
    public void ThenCheckQuestionMarkClickHereMessage(string _jsonPathMSLine1, string _jsonPathMSLine2, string _jsonPathMSLine3, string _jsonPathMSLine4)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (VantageTypePlan != VantageType.LE)
        {
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine1, "questionMarkMessageLine1 is null");
            Assert.IsTrue(_hsQuickSettingsPage.questionMarkMessageLine1.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine1).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine2, "questionMarkMessageLine2 is null");
            Assert.IsTrue(_hsQuickSettingsPage.questionMarkMessageLine2.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine2).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine3, "questionMarkMessageLine3 is null");
            Assert.IsTrue(_hsQuickSettingsPage.questionMarkMessageLine3.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine3).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine4, "questionMarkMessageLine4 is null");
            Assert.IsTrue(_hsQuickSettingsPage.questionMarkMessageLine4.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine4).ToString()));
        }
        else
        {
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine1, "questionMarkMessageLine1 is null");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.questionMarkMessageLine1).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine1).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine2, "questionMarkMessageLine2 is null");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.questionMarkMessageLine2).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine2).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine3, "questionMarkMessageLine3 is null");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.questionMarkMessageLine3).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine3).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.questionMarkMessageLine4, "questionMarkMessageLine4 is null");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.questionMarkMessageLine4).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPathMSLine4).ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.HighDensityBattery, "HighDensityBattery is null");
            Assert.IsTrue(_hsQuickSettingsPage.HighDensityBattery.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.HighDensityBatterytext").ToString()));
            Assert.IsNotNull(_hsQuickSettingsPage.HighDensityBatteryworks, "HighDensityBatteryworks is null");
            Assert.IsTrue(_hsQuickSettingsPage.HighDensityBatteryworks.Text.Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.HighDensityBatteryworkstext").ToString()));
        }
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [When(@"Click Vantage Maxmize Button")]
    public void WhenClickVantageMaxmizeButton()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.VantageMaxmizeButton);
        _hsQuickSettingsPage.VantageMaxmizeButton.Click();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Given(@"change ThinkPad machine to AC condition")]
    public void GivenchangeThinkPadmachinetoACcondition()
    {
        //DischargeStatus.exe stop 1
        CmdCommands.IncreaseBatteryValue();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Given(@"change ThinkPad machine to DC condition")]
    public void GivenchangeThinkPadmachinetoDCcondition()
    {
        //DischargeStatus.exe start 1
        CmdCommands.ReduceBatteryValue();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"Restore Display Settings")]
    public void ThenRestoreDisplaySettings()
    {
        string info = ChangeResolution(wid, hei);
        Console.WriteLine("Restore Display Settings Info:" + info);
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Given(@"Change machine support temporary mode but it is disabled")]
    public void GivenChangeMachineNotSupportPIDLSModeStatus()
    {
        SetIniFileValue("CurrentOperatingMode", "2");
        SetIniFileValue("PermanentMode", "2");
        SetIniFileValue("IsPICapable", "1");
        SetIniFileValue("BatterySpecification", "2");
        RestartProcess();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"Restore PI DLS mode Settings")]
    public void ThenRestorePIDLSModeSettings()
    {
        SetIniFileValue("IsPICapable", RestoreIsPICapable);
        SetIniFileValue("IsDLSCapable", RestoreIsDLSCapable);
        SetIniFileValue("CurrentOperatingMode", RestoreCurrentOperatingMode);
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [When(@"There should not show question mark and the link")]
    public void WhenThereShouldNotShowQuestionMarkAndTheLink()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNull(_hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink);
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }

    [Then(@"The question mark should still be displayed beside FCC")]
    public void ThenTheQuestionMarkShouldStillBeDisplayedBesideFCC()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.FullChargeCapacity, "FullChargeCapacity is null");
        Point FullChargeCapacity = VantageCommonHelper.GetWindowsElementPoint(_hsQuickSettingsPage.FullChargeCapacity);
        Assert.IsNotNull(_hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink, "seeBatteryDetailsQuestionMarkLink is null");
        Point questionMarkMessage = VantageCommonHelper.GetWindowsElementPoint(_hsQuickSettingsPage.seeBatteryDetailsQuestionMarkLink);
        Assert.IsNotNull(_hsQuickSettingsPage.ManufactureDate, "ManufactureDate is null");
        Point ManufactureDate = VantageCommonHelper.GetWindowsElementPoint(_hsQuickSettingsPage.ManufactureDate);
        bool result = FullChargeCapacity.X < questionMarkMessage.X && questionMarkMessage.X < ManufactureDate.X && Math.Abs(questionMarkMessage.Y - FullChargeCapacity.Y) < 5;
        Assert.IsTrue(result, "The question mark not displayed beside FCC and ManufactureDate");
    }

    [Given(@"Machine is ThinkPad and enable Temproray mode")]
    public static void GivenMachineIsThinkPadAndSupportTemprorayPIDLSMode()
    {
        if (File.Exists(inifilepath))
        {
            SetIniFileValue("CurrentOperatingMode", "3");
            SetIniFileValue("BatterySpecification", "2");
            SetIniFileValue("PermanentMode", "2");
            Thread.Sleep(TimeSpan.FromSeconds(3));
            RestartProcess();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
        else
        {
            File.Copy(iniFilePath, Path.Combine("C:\\Windows\\SysWOW64\\Lenovo\\PowerMgr", inifilename), true);
        }
        RestoreIsPICapable = GetIniFileValue("IsPICapable");
        RestoreIsDLSCapable = GetIniFileValue("IsDLSCapable");
        RestoreCurrentOperatingMode = GetIniFileValue("CurrentOperatingMode");
        Thread.Sleep(TimeSpan.FromSeconds(3));
        RestartProcess();
        Thread.Sleep(TimeSpan.FromSeconds(3));
    }
    public static void RestartProcess()
    {
        Process[] psList = Process.GetProcessesByName("PowerMgr");
        if (psList.Length > 0)
        {
            Common.KillProcess("PowerMgr", true);
        }
        Thread.Sleep(TimeSpan.FromSeconds(3));
        Process psPowerMgr = new Process();
        psPowerMgr.StartInfo.FileName = @"C:\Windows\SysWOW64\Lenovo\PowerMgr\PowerMgr.exe";
        psPowerMgr.StartInfo.CreateNoWindow = true;
        psPowerMgr.Start();
    }

    [Then(@"Delete Ini Settings File")]
    public void ThenDeleteIniSettingsFile()
    {
        if (File.Exists(inifilepath))
        {
            File.Delete(inifilepath);
        }
        else
        {
            MessageBox.Show("Delete Failed");
        }
    }

    [Given(@"Turn (.*) Vantage Usage Statistics")]
    public void GivenTurnVantageUsageStatistics(String Status)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.VantageUsageStatistics);
        if (Status.Equals("on"))
        {
            if (VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics) == ToggleState.Off)
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics, ToggleState.On);
                Assert.IsTrue(result);
            }
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics), ToggleState.On);
        }
        if (Status.Equals("off"))
        {
            if (VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics) == ToggleState.On)
            {
                bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics, ToggleState.Off);
                Assert.IsTrue(result);
            }
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.VantageUsageStatistics), ToggleState.Off);
        }
    }

    public static string GetIniFileValue(string key)
    {
        StringBuilder stringBuilder = new StringBuilder(1024);
        if (File.Exists(inifilepath))
        {
            GetPrivateProfileString("GetBatteryPiStatus", key, "", stringBuilder, 1024, inifilepath);
        }
        else
        {
            MessageBox.Show("GetIniFileValue Null");
        }

        return stringBuilder.ToString();
    }
    public static void SetIniFileValue(string key, string value)
    {
        try
        {

            WritePrivateProfileString("GetBatteryPiStatus", key, value, inifilepath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

}