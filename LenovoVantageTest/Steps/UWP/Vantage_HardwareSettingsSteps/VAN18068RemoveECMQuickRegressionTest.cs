using BoDi;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class RemoveECMQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSQuickSettingsPage _hsQuickSettingsPage;
    public HSSystemUpdatePage _systemUpdatePage;
    public readonly IObjectContainer objectContainer;
    bool haveECMFlag = true;
    public static List<string> EcmWhiteList = new List<string>() {"M2RKT","M38KT","M29KT","M20KT","M1QKT","M1PKT",
            "M12KT","M1BKT","M1EKT","M1CKT","M1NKT","M1MKT","M38KT","M1RKT","M2DKT","M2DKT","M2EKT","M1QMF","EHCN3"};

    public RemoveECMQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    public bool GetECMFlag()
    {
        VantageCommonHelper vantageCommonHelper = new VantageCommonHelper();
        var osBiosValue = vantageCommonHelper.GetWMIValue("\\\\.\\root\\cimv2", "select * from Win32_BIOS", "SMBIOSBIOSVersion").Substring(0, 5);
        if (EcmWhiteList.Contains(osBiosValue))
        {
            haveECMFlag = true;
        }
        else
        {
            haveECMFlag = false;
        }
        return haveECMFlag;
    }

    [Given(@"Machine support Remove ECM feature")]
    public void GivenMachineSupportRemoveECMFeature()
    {
        Assert.IsFalse(GetECMFlag());
    }

    [Given(@"Machine not support Remove ECM feature")]
    public void GivenMachineNotSupportRemoveECMFeature()
    {
        Assert.IsTrue(GetECMFlag());
    }

    [Then(@"Check title display with json path '(.*)'")]
    public void ThenCheckTitleDisplayWithJsonPath(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DisplayLink);
        _hsQuickSettingsPage.DisplayLink.Click();
        Assert.IsNotNull(_hsQuickSettingsPage.ECMTitle);
        Assert.IsTrue(_hsQuickSettingsPage.ECMTitle.Text.Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Check text display with json path '(.*)'")]
    public void ThenCheckTextDisplayWithJsonPath(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DisplayLink);
        _hsQuickSettingsPage.DisplayLink.Click();
        Assert.IsNotNull(_hsQuickSettingsPage.ECMTextId);
        Assert.IsTrue(_hsQuickSettingsPage.ECMTextId.Text.Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [When(@"User click 'here' link")]
    public void WhenUserClickHereLink()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DisplayLink);
        _hsQuickSettingsPage.DisplayLink.Click();
        Assert.IsNotNull(_hsQuickSettingsPage.ECMHere);
        _hsQuickSettingsPage.ECMHere.Click();
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"The Night Light windows will be popped up")]
    public void ThenNightLightWindowsWillBePoppedUp()
    {
        AutomationElement sliderToggle = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.DisplayAndCamera.RemoveColorTemperatureSliderSettings").ToString());
        Assert.IsNotNull(sliderToggle, "The RemoveColorTemperatureSliderSettings is not find");
        VantageCommonHelper.FindElementByIdAndMouseClick(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.DisplayAndCamera.ECMWinClose").ToString());
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Check the New UI with the latest UISPEC")]
    public void ThenCheckTheNewUIWithTheLatestUISPEC()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DisplayLink);
        _hsQuickSettingsPage.DisplayLink.Click();
        Assert.IsNotNull(_hsQuickSettingsPage.ECMTitle);
        Assert.IsNotNull(_hsQuickSettingsPage.ECMColor);
        Assert.IsNotNull(_hsQuickSettingsPage.ScheduleECMlabel);
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Check the title is ""(.*)""")]
    public void ThenCheckTheTitleIs(string p0)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.RemoveECMTitle, "The removeECM title is not find");
        Assert.AreEqual(_hsQuickSettingsPage.RemoveECMTitle.Text, p0, "The title is not true");
    }

    [Then(@"Check the description is '(.*)'")]
    public void ThenCheckTheDescriptionIs(string p0)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.RemoveECMTextId, "The RemoveECMTextId title is not find");
        Assert.AreEqual(_hsQuickSettingsPage.RemoveECMTextId.Text, VantageAutomationIDCollector.Instance.GetVantageAutomationID(p0).ToString(), "The title is not true");
    }

}
