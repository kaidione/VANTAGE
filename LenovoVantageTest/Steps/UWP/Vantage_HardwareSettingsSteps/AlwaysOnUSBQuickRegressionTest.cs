using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class AlwaysOnUSBQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;
    private bool _voipStateFlag;

    public AlwaysOnUSBQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check Power Settings Display Always On USB Elements")]
    public void ThenCheckPowerSettingsDisplayAlwaysOnUSBElements()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBTitle, "Always On USB Title Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCaptionId, "Always On USB CaptionId Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBToggle, "Always On USB Toggle Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCheckbox, "Always On USB Checkbox Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCheckboxLabel, "Always On USB CheckboxLabel Is Null");
    }

    [Then(@"Check Power Settings Always On USB Section Display '(.*)'")]
    public void ThenCheckPowerSettingsAlwaysOnUSBSectionDisplay(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (jsonPath.Equals("$.PowerPage.AlwaysUSBDescriptionText"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCaptionId);
            Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.AlwaysUSBCaptionId).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
        else if (jsonPath.Equals("$.PowerPage.AlwaysUSBCheckboxText"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCheckbox);
            Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.AlwaysUSBCheckbox).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
    }

    [Then(@"Check Power Settings No Always On USB Feature")]
    public void ThenCheckPowerSettingsNoAlwaysOnUSBFeature()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBTitle, "Always On USB Title Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCaptionId, "Always On USB CaptionId Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBToggle, "Always On USB Toggle Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckbox, "Always On USB Checkbox Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckboxLabel, "Always On USB CheckboxLabel Is Not Null");
    }

    [Then(@"Check Power Settings No Checkbox Elements")]
    public void ThenCheckPowerSettingsNoCheckboxElements()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBTitle, "Always On USB Title Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCaptionId, "Always On USB CaptionId Is Null");
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBToggle, "Always On USB Toggle Is Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckbox, "Always On USB Checkbox Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckboxLabel, "Always On USB CheckboxLabel Is Not Null");
    }
    [Given(@"Turn (.*) Always On USB toggle")]
    public void GivenTurnOnAlwaysOnUSBToggle(ToggleState Status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        bool toolbar = _hSPowerSettingsPage.SetCheckBoxStatus(_hSPowerSettingsPage.AlwaysUSBToggle, Status);
        Assert.IsTrue(toolbar);
    }

    [Then(@"The Checkbox is (.*)")]
    public void ThenTheCheckboxIsGreyedOut(string tp)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        switch (tp)
        {
            case "greyout":
                Assert.IsTrue(_hSPowerSettingsPage.AlwaysUSBCheckbox.Enabled, "The AlwaysUSBCheckbox is not greyout");
                break;
            case "nogreyout":
                Assert.IsFalse(_hSPowerSettingsPage.AlwaysUSBCheckbox.Enabled, "The AlwaysUSBCheckbox is  greyout");
                break;
        }
    }
    [Then(@"The AlwaysOnUSBUI should show completely in (.*) seconds")]
    public void ThenTheAlwaysOnUSBUIShouldShowCompletelyInSeconds(int p0)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBTitle);
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCaptionId);
        Assert.IsNotNull(_hSPowerSettingsPage.AlwaysUSBCheckbox);
        sw.Stop();
        TimeSpan ts = sw.Elapsed;
        double spendTime = ts.TotalSeconds;
        Assert.LessOrEqual(spendTime, 2, "The UI should show completely in 2 seconds");
    }

    [Then(@"The checkbox description shoule display as '(.*)'")]
    public void ThenTheCheckboxDescriptionShouleDisplayAs(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckboxLabel, "Always On USB CheckboxLabel Is Not Null");
        Assert.IsNull(_hSPowerSettingsPage.AlwaysUSBCheckbox, "Always On USB CheckboxLabel Is Not Null");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.AlwaysUSBCheckbox).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

}
