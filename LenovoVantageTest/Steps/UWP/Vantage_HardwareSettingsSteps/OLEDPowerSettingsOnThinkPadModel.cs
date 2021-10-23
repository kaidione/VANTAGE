using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class OLEDPowerSettingsOnThinkPadModel
{
    private InformationalWebDriver _webDriver;
    private HSDispalyCameraPage _hSDispalyCameraPage;
    public OLEDPowerSettingsOnThinkPadModel(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check OLED Title Display '(.*)'")]
    public void ThenCheckOLEDTitleDisplay(string jsonPath)
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsTitleID);
        Assert.IsTrue(_hSDispalyCameraPage.ShowTextbox(_hSDispalyCameraPage.OLEDPowerSettingsTitleID).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check description1 Text Display '(.*)'")]
    public void ThenCheckDescription1TextDisplay(string jsonPath)
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsDescription1ID);
        Assert.IsTrue(_hSDispalyCameraPage.ShowTextbox(_hSDispalyCameraPage.OLEDPowerSettingsDescription1ID).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check description2 Text Display '(.*)'")]
    public void ThenCheckDescription2TextDisplay(string jsonPath)
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsDescription2ID);
        Assert.IsTrue(_hSDispalyCameraPage.ShowTextbox(_hSDispalyCameraPage.OLEDPowerSettingsDescription2ID).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Display 'TASKBAR DIMMER' Title")]
    public void ThenCheckDisplayTASKBARDIMMERTitle()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsTASKBARDIMMER);
    }

    [Then(@"Check 'TASKBAR DIMMER Menu List' Exists")]
    public void ThenCheckTASKBARDIMMERMenuListExists()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsTASKBARDIMMERMenuList);
    }

    [Then(@"Check Display 'BACKGROUND DIMMER' Title")]
    public void ThenCheckDisplayBACKGROUNDDIMMERTitle()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsBACKGROUNDDIMMER);
    }

    [Then(@"Check 'BACKGROUND DIMMER Menu List' Exists")]
    public void ThenCheckBACKGROUNDDIMMERMenuListExists()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsBACKGROUNDDIMMERMenuList);
    }

    [Then(@"Check Display 'DISPLAY DIMMER' Title")]
    public void ThenCheckDisplayDISPLAYDIMMERTitle()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsDISPLAYDIMMER);
    }

    [Then(@"Check 'DISPLAY DIMMER Menu List' Exists")]
    public void ThenCheckDISPLAYDIMMERMenuListExists()
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsDISPLAYDIMMERMenuList);
    }

    [Then(@"Check '(.*)' Value")]
    public void ThenCheckMenuListValue(string listName)
    {
        _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
        switch (listName.ToLower())
        {
            case "taskbar dimmer menu list":
                Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsTASKBARDIMMERMenuList);
                _hSDispalyCameraPage.OLEDPowerSettingsTASKBARDIMMERMenuList.Click();
                break;
            case "background dimmer menu list":
                Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsBACKGROUNDDIMMERMenuList);
                _hSDispalyCameraPage.OLEDPowerSettingsBACKGROUNDDIMMERMenuList.Click();
                break;
            case "display dimmer menu list":
                Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsDISPLAYDIMMERMenuList);
                _hSDispalyCameraPage.OLEDPowerSettingsDISPLAYDIMMERMenuList.Click();
                break;
        }
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList1, "Element 'Always on' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList2, "Element '30 seconds' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList3, "Element '1 minute' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList4, "Element '2 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList5, "Element '3 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList6, "Element '5 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList7, "Element '10 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList8, "Element '15 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList9, "Element '20 minutes' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList10, "Element 'Never' Is Not Found");
        Assert.IsNotNull(_hSDispalyCameraPage.OLEDPowerSettingsMenuList11, "Element 'Half time of display off timer' Is Not Found");
    }
}





