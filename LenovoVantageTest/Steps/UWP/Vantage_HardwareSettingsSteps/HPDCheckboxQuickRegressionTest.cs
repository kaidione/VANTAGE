using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class HPDCheckboxQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSSmartAssistPage _hSSmartAssistPage;

    public HPDCheckboxQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Given(@"Scroll To Zero Touch Lock Section")]
    public void GivenScrollToZeroTouchLockSection()
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        _hSSmartAssistPage.ScrollScreenToWindowsElement(_webDriver.Session, _hSSmartAssistPage.ZeroTouchLocktitle);
    }

    [Then(@"Show Checkbox Override Windows Screen Timeout Settings")]
    public void ThenShowCheckboxOverrideWindowsScreenTimeoutSettings()
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        Assert.IsNotNull(_hSSmartAssistPage.AutoScreenTimeoutCheckbox, "Element 'Auto Screen Timeout Checkbox' Is Not Found");
        Assert.IsNotNull(_hSSmartAssistPage.AutoScreenTimeoutCheckboxtitle, "Element 'Auto Screen Timeout Checkbox title' Is Not Found");
        Assert.IsNotNull(_hSSmartAssistPage.AutoScreenTimeoutCheckboxLink, "Element 'Auto Screen Timeout Checkbox Link' Is Not Found");
    }

    [Then(@"Zero Touch Lock Section Checkbox is '(.*)'")]
    public void ThenZeroTouchLockSectionCheckboxis(string Status)
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        Assert.IsNotNull(_hSSmartAssistPage.AutoScreenTimeoutCheckbox, "Element 'Auto Screen Timeout Checkbox' Is Not Found");
        if (Status.ToLower().Equals("on"))
        {
            Assert.AreEqual(_hSSmartAssistPage.GetCheckBoxStatus(_hSSmartAssistPage.AutoScreenTimeoutCheckbox), ToggleState.On);
        }
        else if (Status.ToLower().Equals("off"))
        {
            Assert.AreEqual(_hSSmartAssistPage.GetCheckBoxStatus(_hSSmartAssistPage.AutoScreenTimeoutCheckbox), ToggleState.Off);
        }
    }

    [Then(@"Check Windows Settings Power and Sleep Page Is Open")]
    public void ThenCheckWindowsSettingsPowerAndSleepPageIsOpen()
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.WindowsSettingsPowerAndSleepPage").ToString(), 1);
        Assert.IsNotNull(automationElement, "Element 'Windows Settings Power and Sleep Page' Is Not Found");
    }

    [Given(@"Click Windows Screen time-out Settings Link")]
    public void GivenClickWindowsScreenTimeOutSettingsLink()
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        Assert.IsNotNull(_hSSmartAssistPage.AutoScreenTimeoutCheckboxLink, "Element 'Auto Screen Timeout Checkbox Link' Is Not Found");
        _hSSmartAssistPage.AutoScreenTimeoutCheckboxLink.Click();
    }

    [Given(@"Turn '(.*)' The Toggle of Zero Touch Lock")]
    public void GivenTurnTheToggleOfZeroTouchLock(ToggleState Status)
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        bool toolbar = _hSSmartAssistPage.SetCheckBoxStatus(_hSSmartAssistPage.zeroTouchLockButton, Status);
        Assert.IsTrue(toolbar);
    }

    [Given(@"'(.*)' Zero Touch Lock Section Checkbox")]
    public void GivenZeroTouchLockSectionCheckbox(ToggleState Status)
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        bool toolbar = _hSSmartAssistPage.SetCheckBoxStatus(_hSSmartAssistPage.AutoScreenTimeoutCheckbox, Status);
        Assert.IsTrue(toolbar);
    }

    [Then(@"The Checkbox And The Context Should be Grayed Out")]
    public void ThenTheCheckboxAndTheContextShouldBeGrayedOut()
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        Assert.IsFalse(_hSSmartAssistPage.AutoScreenTimeoutCheckbox.Enabled, "The Auto Screen Timeout Checkbox is not greyout");
    }

    [Then(@"This Tip Show The Description '(.*)'")]
    public void ThenThisTipShowTheDescription(string jsonPath)
    {
        _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
        Assert.IsNotNull(_hSSmartAssistPage.SmartAssistScreenTimeoutDesc, "Element 'Auto Screen Timeout Checkbox Link' Is Not Found");
        Assert.IsTrue(_hSSmartAssistPage.ShowTextbox(_hSSmartAssistPage.SmartAssistScreenTimeoutDesc).Equals(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }
}
