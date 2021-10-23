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
public class FlipToBootQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;
    private VantageBase _vantageBase = new VantageBase();
    private ToggleState _beforeHibernateResult;
    private ToggleState _beforeSleepResult;
    public FlipToBootQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check Power Settings '(.*)'")]
    public void ThenCheckPowerSettings(string checkElements)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (checkElements.ToLower().Equals("not display flip to start elements"))
        {
            Assert.IsNull(_hSPowerSettingsPage.FlipToStartTitleId, "Flip To Start Title Is Not Null");
            Assert.IsNull(_hSPowerSettingsPage.FlipToStartDescriptionId, "Flip To Start Description Is Not Null");
            Assert.IsNull(_hSPowerSettingsPage.FlipToStartToggle, "Flip To Start Toggle Is Not Null");
            Assert.IsNull(_hSPowerSettingsPage.FlipToStartQuestionMark, "Flip To Start QuestionMark Is Not Null");
        }
        if (checkElements.ToLower().Equals("display flip to start elements"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartTitleId, "Flip To Start Title Is Null");
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartDescriptionId, "Flip To Start Description Is Null");
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartToggle, "Flip To Start Toggle Is Null");
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartQuestionMark, "Flip To Start QuestionMark Is Null");
        }
    }

    [Then(@"Check Power Settings Section Display '(.*)'")]
    public void ThenCheckPowerSettingsSectionDisplay(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        switch (jsonPath)
        {
            case "$.PowerPage.FlipToStartTitleText":
                Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartTitleId);
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.FlipToStartTitleId).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
                break;
            case "$.PowerPage.FlipToStartDescriptionText":
                Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartDescriptionId);
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.FlipToStartDescriptionId).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
                break;
            case "$.PowerPage.FlipToStartQuestionMarkToolTipText":
                Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartQuestionMarkToolTip);
                Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.FlipToStartQuestionMarkToolTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
                break;
        }
    }

    [Then(@"Flip To Start Section Display '(.*)'")]
    public void ThenFlipToStartSectionDisplay(string checkElement)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (checkElement.ToLower().Equals("toggle button"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartToggle, "Flip To Start Toggle Is Null");
        }
        if (checkElement.ToLower().Equals("question mark"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartQuestionMark, "Flip To Start QuestionMark Is Null");
        }
    }

    [Given(@"Click Flip To Start QuestionMark")]
    public void GivenClickFlipToStartQuestionMark()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartQuestionMark);
        _hSPowerSettingsPage.FlipToStartQuestionMark.Click();
    }

    [Given(@"Turn (.*) Flip To Start Toggle")]
    public void WhenTurnFlipToStartToggle(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (status.ToLower().Equals("on"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle) == ToggleState.Off)
            {
                _hSPowerSettingsPage.FlipToStartToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle), ToggleState.On);
        }
        if (status.ToLower().Equals("off"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle) == ToggleState.On)
            {
                _hSPowerSettingsPage.FlipToStartToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle), ToggleState.Off);
        }
    }

    [Then(@"The Flip To Start Toggle State Is '(.*)'")]
    public void ThenTheFlipToStartToggleStateIs(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.FlipToStartToggle, "Flip To Start Toggle Is Null");
        if (status.ToLower().Equals("on"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle), ToggleState.On);
        }
        if (status.ToLower().Equals("off"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle), ToggleState.Off);
        }
    }

    [When(@"Get Flip To Start Toggle State")]
    public void WhenGetFlipToStartToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _beforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle);
    }

    [Then(@"Back From Hibernate Or Sleep The Flip To Start Toggle State Is '(.*)'")]
    public void ThenBackFromHibernateOrSleepTheFlipToStartToggleStateIs(string status)
    {
        if (status.ToLower().Equals("on") || status.ToLower().Equals("off"))
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState afterHibernateOrSleepResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.FlipToStartToggle);
            Assert.IsTrue(_beforeHibernateResult == afterHibernateOrSleepResult || _beforeSleepResult == afterHibernateOrSleepResult);
        }
    }
}
