using LenovoVantageTest;
using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

[Binding]
public class PrivacyGuardQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSQuickSettingsPage _hsQuickSettingsPage;
    private VantageBase _vantageBase = new VantageBase();
    private ToggleState _BeforeHibernateResult;
    private ToggleState _BeforeSleepResult;
    private ToggleState _ToolbarResult;
    public PrivacyGuardQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Given(@"Click DisplayLink")]
    public void GivenClickDisplayLink()
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.DisplayLink);
        _hsQuickSettingsPage.DisplayLink.Click();
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Check title display '(.*)'")]
    public void ThenCheckTitleDisplay(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardTitleId);
        Assert.IsTrue(_hsQuickSettingsPage.PrivacyGuardTitleId.Text.Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Check description display '(.*)'")]
    public void ThenCheckDescriptionDisplay(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (VantageConstContent.VantageTypePlan == VantageType.LE)
        {
            Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardDescriptionNameforLe);
        }
        else
        {
            Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardDescriptionId);
            Assert.IsTrue(_hsQuickSettingsPage.PrivacyGuardDescriptionId.Text.Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }

    [Then(@"Check note display '(.*)'")]
    public void ThenCheckNoteDisplay(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (VantageConstContent.VantageTypePlan == VantageType.LE)
        {
            Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardNoteNameforLe);
        }
        else
        {
            Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardNoteId);
            Assert.IsTrue(_hsQuickSettingsPage.PrivacyGuardNoteId.Text.Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }
    }

    [Then(@"Check checkbox display '(.*)'")]
    public void ThenCheckCheckboxDisplay(string _jsonPath)
    {
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hsQuickSettingsPage.PrivacyGuardCBId);
        Assert.IsTrue(_hsQuickSettingsPage.PrivacyGuardCheckbox.GetAttribute("Name").Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString()));
        Thread.Sleep(TimeSpan.FromSeconds(2));
    }

    [Then(@"Turn (.*) Privacy Guard")]
    public void WhenTurnPrivacyGuard(String Status)
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.Equals("on"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle) == ToggleState.Off)
            {
                _hsQuickSettingsPage.PrivacyGuardToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle), ToggleState.On);
        }
        if (Status.Equals("off"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle) == ToggleState.On)
            {
                _hsQuickSettingsPage.PrivacyGuardToggle.Click();
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle), ToggleState.Off);
        }
    }

    [Then(@"Check Privacy Guard toggle is '(.*)'")]
    public void ThenCheckPrivacyGuardToggle(String Status)
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.Equals("on"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle), ToggleState.On);
        }
        else if (Status.Equals("off"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle), ToggleState.Off);
        }
        else
        {
            Assert.Fail("ThenCheckPrivacyGuardToggle() parameter fail,info" + Status);
        }
    }

    [Given(@"Send '(.*)' Checkbox")]
    public void GivenSendCheckbox(String Status)
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.Equals("Select"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox) == ToggleState.Off)
            {
                if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle) == ToggleState.On)
                {
                    _hsQuickSettingsPage.PrivacyGuardToggle.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    _hsQuickSettingsPage.PrivacyGuardCBId.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                else
                {
                    _hsQuickSettingsPage.PrivacyGuardCBId.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox), ToggleState.On);
        }
        if (Status.Equals("Not Select"))
        {
            if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox) == ToggleState.On)
            {
                if (_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle) == ToggleState.On)
                {
                    _hsQuickSettingsPage.PrivacyGuardToggle.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                    _hsQuickSettingsPage.PrivacyGuardCBId.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
                else
                {
                    _hsQuickSettingsPage.PrivacyGuardCBId.Click();
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }
            }
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox), ToggleState.Off);
        }
    }

    [Then(@"Check checkbox is '(.*)'")]
    public void ThenCheckCheckboxIsSelected(String Status)
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (Status.Equals("Selected"))
        {
            Assert.AreEqual(_hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox), ToggleState.On);
        }
    }

    [When(@"Hibernate system and get ToggleState")]
    public void WhenHibernateSystemAndGetToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _BeforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle);
        _vantageBase.EnterS4();
    }

    [When(@"Sleep system and get ToggleState")]
    public void WhenSleepSystemAndGetToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _BeforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle);
        _vantageBase.EnterS3();
    }

    [When(@"Hibernate system and get Checkbox ToggleState")]
    public void WhenHibernateSystemAndGetCheckboxToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _BeforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox);
        _vantageBase.EnterS4();
    }

    [When(@"Sleep system and get Checkbox ToggleState")]
    public void WhenSleepSystemAndGetCheckboxToggleState()
    {
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        _BeforeHibernateResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox);
        _vantageBase.EnterS3();
    }

    [Then(@"The toggle state is '(.*)'")]
    public void ThenTheToggleStateIs(String Status)
    {
        if (Status.Equals("On"))
        {
            HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            ToggleState AfterHibernateOrSleepResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle);
            Assert.IsTrue(_BeforeHibernateResult == AfterHibernateOrSleepResult || _BeforeSleepResult == AfterHibernateOrSleepResult);
        }
    }

    [Then(@"The Checkbox toggle state is '(.*)'")]
    public void ThenTheCheckboxToggleStateIs(String Status)
    {
        if (Status.Equals("On"))
        {
            HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            ToggleState AfterHibernateOrSleepResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardCheckbox);
            Assert.IsTrue(_BeforeHibernateResult == AfterHibernateOrSleepResult || _BeforeSleepResult == AfterHibernateOrSleepResult);
        }
    }

    [Then(@"Turn '(.*)' Privacy guard by Toolbar and Display page sync in 30s")]
    public void ThenTurnOnOrOffPrivacyGuardByToolbarAndDisplayPageSyncIn30s(string status)
    {
        int sysnSeconds = 0;
        HSPowerSettingsPage _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
        if (status.Equals("On"))
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _ToolbarResult = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
            }
        }
        else if (status.Equals("Off"))
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _ToolbarResult = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
            }
        }
        try
        {
            while (sysnSeconds <= 30)
            {
                DateTime starttime = DateTime.Now;
                ToggleState DisplayPageResult = _hSPowerSettingsPage.GetCheckBoxStatus(_hsQuickSettingsPage.PrivacyGuardToggle);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                int interval = (DateTime.Now - starttime).Seconds;
                sysnSeconds += interval;
                if (_ToolbarResult == DisplayPageResult || sysnSeconds > 30)
                {
                    break;
                }
            }
        }
        catch (Exception ee)
        {
            throw new Exception("GetToggleStateSyncIn30S Exception:" + ee.ToString());
        }
    }

}
