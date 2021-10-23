using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class BatteryHealthQuickRegressionTest
{
    private InformationalWebDriver _webDriver;
    private HSPowerSettingsPage _hSPowerSettingsPage;

    public BatteryHealthQuickRegressionTest(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check Battery Health Title Display '(.*)'")]
    public void ThenCheckBatteryHealthTitleDisplay(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthTitle, "Element 'Battery Health Title' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryHealthTitle).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Battery Health Description Text '(.*)'")]
    public void ThenCheckBatteryHealthDescriptionText(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthDescription, "Element 'Battery Health Description' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryHealthDescription).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Battery Health Feature Should Hidden")]
    public void ThenBatteryHealthFeatureShouldHidden()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNull(_hSPowerSettingsPage.BatteryHealthTitle, "Element 'Battery Health Title' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryHealthDescription, "Element 'Battery Health Description' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryHealthStatus, "Element 'Battery Health Status' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryHealthStatusStars, "Element 'Battery Health Status Stars' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTitle, "Element 'Battery Capacity Title' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "Element 'Battery Capacity Question Mark' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityCircle, "Element 'Battery Capacity Circle' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTipLine1, "Element 'Battery Capacity Tip Line1' Is Not Hidden");
        Assert.IsNull(_hSPowerSettingsPage.BatteryCapacityTipLine2, "Element 'Battery Capacity Tip Line2' Is Not Hidden");
    }

    [Then(@"Check Battery Health Should Display Correctly")]
    public void ThenCheckBatteryHealthShouldDisplayCorrectly()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthTitle, "Element 'Battery Health Title' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthDescription, "Element 'Battery Health Description' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthStatus, "Element 'Battery Health Status' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthStatusStars, "Element 'Battery Health Status Stars' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTitle, "Element 'Battery Capacity Title' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "Element 'Battery Capacity Question Mark' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityCircle, "Element 'Battery Capacity Circle' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine1, "Element 'Battery Capacity Tip Line1' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine2, "Element 'Battery Capacity Tip Line2' Is Not Found");
    }

    [Then(@"Check The Title Battery Health Status Is '(.*)'")]
    public void ThenCheckTheTitleBatteryHealthStatusIs(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthStatus, "Element 'Battery Health Status' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryHealthStatus).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Display Five Stars")]
    public void ThenDisplayFiveStars()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthStatusStars, "Element 'Five Stars' Is Not Found");
    }

    [Then(@"All The Five Stars are Green")]
    public void ThenAllTheFiveStarsAreGreen()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryHealthStatusStars, "Element 'Battery Health Status Stars' Is Not Found");
    }

    [Then(@"Check The Title Battery Capacity Is '(.*)'")]
    public void ThenCheckTheTitleBatteryCapacityIs(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTitle, "Element 'Battery Capacity Title' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryCapacityTitle).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Question Mark On Battery Capacity Right")]
    public void ThenCheckQuestionMarkOnBatteryCapacityRight()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "Element 'Battery Capacity Question Mark' Is Not Found");
    }

    [Then(@"Show Circle Under The Battery Capacity")]
    public void ThenShowCircleUnderTheBatteryCapacity()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityCircle, "Element 'Battery Capacity Circle' Is Not Found");
    }

    [Then(@"Show '(.*)' Under The Circle")]
    public void ThenShowUnderTheCircle(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        if (jsonPath.Equals("$.PowerPage.BatteryCapacityTipLine1Text"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine1, "Element 'Battery Capacity Tip Line1' Is Not Found");
            Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryCapacityTipLine1).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
        else if (jsonPath.Equals("$.PowerPage.BatteryCapacityTipLine2Text"))
        {
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityTipLine2, "Element 'Battery Capacity Tip Line2' Is Not Found");
            Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryCapacityTipLine2).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
    }

    [When(@"Click Question Mark On Battery Capacity")]
    public void ThenClickQuestionMarkOnBatteryCapacityRight()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityQuestionMark, "Element 'Battery Capacity Question Mark' Is Not Found");
        _hSPowerSettingsPage.BatteryCapacityQuestionMark.Click();
    }

    [Then(@"Check Question Mark Tip Show Text '(.*)'")]
    public void ThenCheckQuestionMarkTipShowText(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryCapacityQuestionMarkTip, "Element 'Battery Capacity Question Mark Tip' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryCapacityQuestionMarkTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Battery Temperature Title Is '(.*)'")]
    public void ThenCheckBatteryTemperatureTitleIs(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureTitle, "Element 'Battery Temperature Title' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryTemperatureTitle).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Display Temperature Icon and Current Temperature")]
    public void ThenDisplayTemperatureIconAndCurrentTemperature()
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorImage, "Element 'Battery Temperature Indicator Image' Is Not Found");
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureIndicatorText, "Element 'Battery Temperature Indicator Text' Is Not Found");
    }

    [Then(@"Current Temperature Status '(.*)'")]
    public void ThenCurrentTemperatureStatus(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureDescription, "Element 'Battery Temperature Description' Is Not Found");
        Assert.AreEqual(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryTemperatureDescription), VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString(), "The description now is " + _hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryTemperatureDescription) + "But except is" + VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString());
    }

    [Given(@"Set Battery Health ""(.*)""")]
    public void GivenSetBatteryHealth(string p0)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        _hSPowerSettingsPage.SetBatteryHealthValue(p0);
    }

    [Then(@"Check Temperature Tip Show Text '(.*)'")]
    public void ThenCheckTemperatureTipShowText(string jsonPath)
    {
        _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
        Assert.IsNotNull(_hSPowerSettingsPage.BatteryTemperatureDescription, "Element 'Battery Temperature Description' Is Not Found");
        Assert.IsTrue(_hSPowerSettingsPage.ShowTextbox(_hSPowerSettingsPage.BatteryTemperatureDescription).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }
}
