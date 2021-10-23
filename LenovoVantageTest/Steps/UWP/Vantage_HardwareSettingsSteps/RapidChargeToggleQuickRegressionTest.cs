using LenovoVantageTest;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

[Binding]
public class RapidChargeToggleQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;
    private VantageBase _vantageBase = new VantageBase();
    private ToggleState _beforeHibernateResult;
    private static int _onRapidChargeFullChargeTime = 0;
    private static int _offRapidChargeFullChargeTime = 0;

    public RapidChargeToggleQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    public void GetFullChargeTime(string isRapidChargeStatus)
    {
        int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
        if (currentPercent < 100)
        {
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
            DateTime starttime = DateTime.Now;
            while (currentPercent < 100)
            {
                Thread.Sleep(TimeSpan.FromMinutes(1));
                currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            }
            int interval = (DateTime.Now - starttime).Seconds;
            if (isRapidChargeStatus.ToLower().Equals("on"))
            {
                _onRapidChargeFullChargeTime += interval;
            }
            else if (isRapidChargeStatus.ToLower().Equals("off"))
            {
                _offRapidChargeFullChargeTime += interval;
            }
        }
    }

    [Given(@"Click Battery Settings Link")]
    public void GivenClickBatterySettingsLink()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (VantageTypePlan != VantageType.LE)
        {
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToBatterySettings);
            _hSPowerSettingsPage.JumpToBatterySettings.Click();
        }
    }

    [Then(@"Check Battery Settings '(.*)'")]
    public void ThenCheckBatterySettings(string checkElements)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (checkElements.ToLower().Equals("not display rapid charge elements"))
        {
            Assert.IsNull(_hSPowerSettingsPage.RapidChargeTitle, "Rapid Charge Title Is Not Null");
            Assert.IsNull(_hSPowerSettingsPage.RapidChargeCaptionId, "Rapid Charge Description Is Not Null");
            Assert.IsNull(_hSPowerSettingsPage.RapidChargeCheckbox, "Rapid Charge Toggle Is Not Null");
        }
        else if (checkElements.ToLower().Equals("display rapid charge elements"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeTitle, "Rapid Charge Title Is Null");
            Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeCaptionId, "Rapid Charge Description Is Null");
            Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeCheckbox, "Rapid Charge Toggle Is Null");
        }
    }

    [Given(@"Turn (.*) Rapid Charge Toggle")]
    public void WhenTurnRapidChargeToggle(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (status.ToLower().Equals("on"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox) == ToggleState.Off)
            {
                _hSPowerSettingsPage.RapidChargeCheckbox.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox), ToggleState.On);
        }
        else if (status.ToLower().Equals("off"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox) == ToggleState.On)
            {
                _hSPowerSettingsPage.RapidChargeCheckbox.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox), ToggleState.Off);
        }
    }

    [Then(@"The Rapid Charge Toggle State Is '(.*)'")]
    public void ThenTheRapidChargeToggleStateIs(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeCheckbox, "Rapid Charge Toggle Is Null");
        if (status.ToLower().Equals("on"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox), ToggleState.On);
        }
        else if (status.ToLower().Equals("off"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox), ToggleState.Off);
        }
    }

    [Given(@"Turn (.*) Conservation Mode Toggle")]
    public void WhenTurnConservationModeToggle(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (status.ToLower().Equals("on"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId) == ToggleState.Off)
            {
                _hSPowerSettingsPage.ConservationModeCheckboxId.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId), ToggleState.On);
        }
        else if (status.ToLower().Equals("off"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId) == ToggleState.On)
            {
                _hSPowerSettingsPage.ConservationModeCheckboxId.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId), ToggleState.Off);
        }
    }

    [Then(@"The Conservation Mode Toggle State Is '(.*)'")]
    public void ThenTheConservationModeToggleStateIs(string status)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.ConservationModeCheckboxId, "Conservation Mode Toggle Is Null");
        if (status.ToLower().Equals("on"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId), ToggleState.On);
        }
        else if (status.ToLower().Equals("off"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.ConservationModeCheckboxId), ToggleState.Off);
        }
    }

    [Then(@"Get Rapid Charge State Is '(.*)' Full Charge Time")]
    public void GivenBatteryLevelIsBelow(string status)
    {
        if (status.ToLower().Equals("on"))
        {
            GetFullChargeTime("On");
        }
        else if (status.ToLower().Equals("off"))
        {
            GetFullChargeTime("Off");
        }
    }

    [Then(@"The Full Charge Time Is Shorter Than Normal Charge")]
    public void ThenTheFullChargeTimeIsShorterThanNormalCharge()
    {
        Assert.IsTrue(_onRapidChargeFullChargeTime < _offRapidChargeFullChargeTime, "The Full Charge Time Is Not Shorter Than Normal Charge");
    }

    [When(@"Hibernate System And Get Rapid Charge Toggle State")]
    public void WhenHibernateSystemAndGetRapidChargeToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _beforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox);
        _vantageBase.EnterS4();
    }

    [Then(@"Back From Hibernate Rapid Charge Toggle State Is '(.*)'")]
    public void ThenBackFromHibernateRapidChargeToggleStateIs(string status)
    {
        if (status.ToLower().Equals("on") || status.ToLower().Equals("off"))
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            ToggleState afterHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hSPowerSettingsPage.RapidChargeCheckbox);
            Assert.IsTrue(_beforeHibernateResult == afterHibernateResult);
        }
    }

}
