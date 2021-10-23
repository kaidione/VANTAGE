using LenovoVantageTest;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class EasyResumeRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;
    private VantageBase _vantageBase = new VantageBase();
    private ToggleState _beforeHibernateResult;
    private ToggleState _beforeSleepResult;
    public EasyResumeRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Given(@"Click Power Settings Link")]
    public void GivenClickPowerSettingsLink()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.JumpToPowerSettings);
        _hSPowerSettingsPage.JumpToPowerSettings.Click();
    }

    [Then(@"Check Easy Resume UI Elements")]
    public void ThenCheckEasyResumeUIElements()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeTitle);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeToggle);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeDescriptionId);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeQuestionMark);
    }

    [Given(@"Click Easy Resume Question Mark")]
    public void GivenClickEasyResumeQuestionMark()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeQuestionMark);
        _hSPowerSettingsPage.EasyResumeQuestionMark.Click();
    }

    [Then(@"Check Easy Resume Question Mark ToolTip display '(.*)'")]
    public void ThenCheckTooltipDisplay(string _jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.EasyResumeQuestionMarkToolTip);
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.EasyResumeQuestionMarkToolTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
    }

    [Given(@"Turn (.*) Easy Resume")]
    public void WhenTurnEasyResume(String Status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (Status.ToLower().Equals("on"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle) == ToggleState.Off)
            {
                _hSPowerSettingsPage.EasyResumeToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle), ToggleState.On);
        }
        if (Status.ToLower().Equals("off"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle) == ToggleState.On)
            {
                _hSPowerSettingsPage.EasyResumeToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle), ToggleState.Off);
        }
    }

    [Then(@"Easy Resume status is '(.*)'")]
    public void ThenEasyResumeStatusIs(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (status.ToLower().Equals("on"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle), ToggleState.On);
        }
        if (status.ToLower().Equals("off"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle), ToggleState.Off);
        }
    }

    [When(@"Hibernate system and get Easy Resume ToggleState")]
    public void WhenHibernateSystemAndGetEasyResumeToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _beforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle);
        _vantageBase.EnterS4();
    }

    [When(@"Sleep system and get Easy Resume ToggleState")]
    public void WhenSleepSystemAndGetEasyResumeToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _beforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle);
        _vantageBase.EnterS3();
    }

    [Then(@"The Easy Resume toggle state is '(.*)'")]
    public void ThenTheEasyResumeToggleStateIs(String Status)
    {
        if (Status.ToLower().Equals("on") || Status.ToLower().Equals("off"))
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState AfterHibernateOrSleepResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.EasyResumeToggle);
            Assert.IsTrue(_beforeHibernateResult == AfterHibernateOrSleepResult || _beforeSleepResult == AfterHibernateOrSleepResult);
        }
    }
}



