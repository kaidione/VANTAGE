using BoDi;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class BatteryConditionOnThinkPadFunction : BasePage
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;
    public readonly IObjectContainer objectContainer;
    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(string section, string key, string val, string filepath);
    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retval, int size, string filePath);
    private static string _iniFileName = "PWMSIMDF.INI";
    private static string _localIniFilePath = @"C:\Windows\SysWOW64\Lenovo\PowerMgr\" + _iniFileName;
    private static string _dataServerIniFilePath = Path.Combine(VantageConstContent.DataPath, @"Data\Tools\Battery tools\battery condition think\Modify\*\PWMSIMDF.INI");
    private static string[] _batteryConditionList = { "Fair", "Good", "High temperature", "HW authentication error", "Over heated", "Permanent error", "Poor", "Trickle charge" };
    private static string _backUpIniFilePath = @"C:\";
    private static string DischargeStatusPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\DischargeStatus.exe");

    public BatteryConditionOnThinkPadFunction(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    public static bool BackupVantagePowerSettingsINIFile()
    {
        try
        {
            if (File.Exists(_localIniFilePath))
            {
                File.Copy(_localIniFilePath, Path.Combine(_backUpIniFilePath, _iniFileName), true);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool DeleteVantagePowerSettingsINIFile()
    {
        try
        {
            if (File.Exists(_localIniFilePath))
            {
                File.Delete(_localIniFilePath);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static bool RestoreVantagePowerSettingsINIFile()
    {
        try
        {
            if (File.Exists(_backUpIniFilePath + _iniFileName))
            {
                File.Copy(_backUpIniFilePath + _iniFileName, Path.Combine(@"C:\Windows\SysWOW64\Lenovo\PowerMgr\", _iniFileName), true);
                return true;
            }
            return false;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public static void RestartPowerMgrProcess()
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
    public static string GetIniFileValue(string key)
    {
        StringBuilder stringBuilder = new StringBuilder(1024);
        if (File.Exists(_localIniFilePath))
        {
            GetPrivateProfileString("GetBatteryPiStatus", key, "", stringBuilder, 1024, _localIniFilePath);
        }
        return stringBuilder.ToString();
    }
    public static void SetIniFileValue(string key, string value)
    {
        try
        {
            WritePrivateProfileString("GetBatteryPiStatus", key, value, _localIniFilePath);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [Given(@"Backup Vantage Power Settings INI File")]
    public void GivenBackupVantagePowerSettingsINIFile()
    {
        BackupVantagePowerSettingsINIFile();
    }

    [AfterFeature("CheckBatteryConditionLE")]
    public static void AfterFeature()
    {
        RestoreVantagePowerSettingsINIFile();
    }

    [Given(@"Delete Vantage Power Settings INI File")]
    public void GivenDeleteVantagePowerSettingsINIFile()
    {
        DeleteVantagePowerSettingsINIFile();
    }

    [Then(@"Restore Vantage Power Settings INI File")]
    public void ThenRestoreVantagePowerSettingsINIFile()
    {
        RestoreVantagePowerSettingsINIFile();
    }

    [Then(@"Check Display '(.*)' Icon")]
    public void ThenCheckDisplayGreenCheckmarkIcon(string iconStatus)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan != LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
        {
            switch (iconStatus)
            {
                case "Green":
                    Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionGreenIcon, "Element 'Green Icon' Is Not Found");
                    break;
                case "Yellow":
                    Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionYellowIcon, "Element 'Yellow Icon' Is Not Found");
                    break;
                case "Red":
                    Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionRedIcon, "Element 'Red Icon' Is Not Found");
                    break;
            }
        }
    }

    [Then(@"Check '(.*)' Tip Text Display")]
    public void ThenCheckTipTextDisplay(string batteryCondition)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        switch (batteryCondition)
        {
            case "Good Condition":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionGoodTip, "Element 'Battery Condition Good Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionGoodTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionGoodTipText").ToString()));
                break;
            case "Fair Condition":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionFairTip, "Element 'Battery Condition Fair Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionFairTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionFairTipText1").ToString()));
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionFairTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionFairTipText2").ToString()));
                break;
            case "Poor Condition":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionPoorTip, "Element 'Battery Condition Poor Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionPoorTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionPoorTipText1").ToString()));
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionPoorTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionPoorTipText2").ToString()));
                break;
            case "Missing Driver":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionMissingDriverTip, "Element 'Battery Condition Missing Driver Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionMissingDriverTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionMissingDriverTipText").ToString()));
                break;
            case "Permanent Error":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionPermanentErrorTip, "Element 'Battery Condition Permanent Error Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionPermanentErrorTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionPermanentErrorTipText").ToString()));
                break;
            case "High Temperature":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionHighTemperatureTip, "Element 'Battery Condition High Temperature Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionHighTemperatureTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionHighTemperatureTipText").ToString()));
                break;
            case "Trickle Charge":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionTrickleChargeTip, "Element 'Battery Condition Trickle Charge Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionTrickleChargeTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionTrickleChargeTipText").ToString()));
                break;
            case "Over Heated":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionOverheatedBatteryTip, "Element 'Battery Condition Over heated Battery Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionOverheatedBatteryTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionOverheatedBatteryTipText").ToString()));
                break;
            case "HW Authentication Error":
                Assert.IsNotNull(_hSPowerSettingsPage.BatteryConditionHWAuthenticationErrorTip, "Element 'Battery Condition HW Authentication Error Tip' Is Not Found");
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryConditionHWAuthenticationErrorTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionHWAuthenticationErrorTipText").ToString()));
                break;
        }
    }

    [Then(@"Check Battery Detail Button Can Not Click")]
    public void ThenCheckBatteryDetailButtonCanNotClick()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsFalse(_hSPowerSettingsPage.BatteryDetailButton.Enabled, "Element 'Battery Detail Button' Is Can Click");
    }

    [Given(@"Change ThinkPad Machine Battery Condition To '(.*)'")]
    public void GivenChangeThinkPadMachineBatteryConditionTo(string batteryCondition)
    {
        if (File.Exists(_localIniFilePath))
        {
            DeleteVantagePowerSettingsINIFile();
        }
        for (int i = 0; i < _batteryConditionList.Length; i++)
        {
            if (batteryCondition.Equals(_batteryConditionList[i]))
            {
                File.Copy(_dataServerIniFilePath.Replace("*", _batteryConditionList[i]), Path.Combine("C:\\Windows\\SysWOW64\\Lenovo\\PowerMgr", _iniFileName), true);
            }
            else if (batteryCondition.Equals("Missing Driver"))
            {
                Process[] psList = Process.GetProcessesByName("PowerMgr");
                if (psList.Length > 0)
                {
                    Common.KillProcess("PowerMgr", true);
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));
            }
        }
        if (batteryCondition.Equals("Missing Driver") != true)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            RestartPowerMgrProcess();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
    }

    [Then(@"Clear Battery Condition Alert")]
    public void ThenClearBatteryConditionAlert()
    {
        int sysnSeconds = 0;
        try
        {
            while (sysnSeconds <= 90)
            {
                DateTime starttime = DateTime.Now;
                AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionAlertId").ToString(), 1);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                int interval = (DateTime.Now - starttime).Seconds;
                sysnSeconds += interval;
                if (automationElement != null || sysnSeconds > 90)
                {
                    if (automationElement != null && (automationElement.Current.Name.Contains("确定") || automationElement.Current.Name.Contains("OK")))
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.BatteryConditionAlertId").ToString());
                        DeleteVantagePowerSettingsINIFile();
                        RestartPowerMgrProcess();
                    }
                    break;
                }
            }
        }
        catch (Exception ee)
        {
            throw new Exception("Get ThinkPad Machine Battery Condition Alert Exception:" + ee.ToString());
        }
    }

    [Then(@"Check No Battery Tip Text Display")]
    public void ThenCheckNoBatteryTipTextDisplay()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.ThinkPadNoBatteryTip, "Element 'No Battery Tip' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.ThinkPadNoBatteryTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.ThinkPadNoBatteryTipText").ToString()));
    }

    [Then(@"Check QuestionMark Icon And Text Display")]
    public void ThenCheckQuestionMarkIconAndTextDisplay()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.ThinkPadNoBatteryQuestionMarkIcon, "Element 'No Battery QuestionMark Icon' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.ThinkPadNoBatteryQuestionMarkTip, "Element 'No Battery QuestionMark Tip' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.ThinkPadNoBatteryQuestionMarkTip.FindElementsByName(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.PowerPage.ThinkPadNoBatteryQuestionMarkTipChild").ToString()), "Element 'No Battery QuestionMark Tip Child' Is Not Found");
    }

    [Then(@"The ""(.*)"" is show")]
    public void ThenTheIsShow(string p0)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (p0 == "AcDcIcon")
        {
            Assert.IsNotNull(_hSPowerSettingsPage.FullACAdapterSupportIcon, "The ACDC icon is not find");
        }
        if (p0 == "AcDcIconTip")
        {
            Assert.IsNotNull(_hSPowerSettingsPage.FullACAdapterSupportText, "The ACDC icon Tip is not find");
            Assert.IsTrue(_hSPowerSettingsPage.FullACAdapterSupportText.Text.Contains("W USB-C power is connected.") || _hSPowerSettingsPage.FullACAdapterSupportText.Text.Contains("65 W ac power is connected.") || _hSPowerSettingsPage.FullACAdapterSupportText.Text.Contains("95 W ac power is connected."), "The tip notice is not true");
        }
    }

    [Then(@"The AcDcIconTip is hidden")]
    public void ThenTheAcDcIconTipIsHidden()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNull(_hSPowerSettingsPage.FullACAdapterSupportIcon, "The ACDC icon is find");
        Assert.IsNull(_hSPowerSettingsPage.FullACAdapterSupportText, "The ACDC icon Tip is find");
    }

    [Given(@"""(.*)"" DischargeStatus")]
    public void GivenDischargeStatus(string p0)
    {
        Thread.Sleep(2000);
        if (p0.ToLower() == "open")
        {
            VantageCommonHelper.RunCmd(DischargeStatusPath + " start 1 ");
        }
        else if (p0.ToLower() == "close")
        {
            VantageCommonHelper.RunCmd(DischargeStatusPath + " stop 1 ");
        }
    }

    [Then(@"The message ""(.*)"" in battery component")]
    public void ThenTheMessageInBatteryComponent(string p0)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        WindowsElement ele = FindElementByTimes(_webDriver.Session, "Name", VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString());
        Assert.IsNotNull(ele, "The FullACAdapterSupportText is not find!!!");
        //string title = _hSPowerSettingsPage.FullACAdapterSupportText.Text;
        ///Assert.AreEqual(VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString(), title, "The tip is not true now is " + title + "But expect" + VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString());
    }

    [Then(@"The ""(.*)"" message is show")]
    public void ThenTheMessageIsShow(string p0)
    {
        string title = null;
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (p0 == "95 W" || p0 == "65 W")
        {
            title = p0 + " USB-C power is connected.";
        }
        else
        {
            title = p0 + " ac power is connected.";
        }
        Assert.AreEqual(title, _hSPowerSettingsPage.FullACAdapterSupportText.Text, "The tilte is not ture now is " + _hSPowerSettingsPage.FullACAdapterSupportText.Text + "But expect" + title);
    }
}