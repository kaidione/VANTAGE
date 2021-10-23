using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

[Binding]
public class KeyboardTopRowForIdeaPadQuickRegression
{
    private InformationalWebDriver _webDriver;
    private HSInputPage _hSInputPage;
    public KeyboardTopRowForIdeaPadQuickRegression(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check Display Keyboard top-row function Title")]
    public void ThenCheckDisplayKeyboardTopRowFunctionTitle()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionTitleID, "Element Keyboard Top Row Function Title Is Not Found");
    }

    [Then(@"Check Title Display '(.*)'")]
    public void ThenCheckTitleDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionTitleID);
        Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.KeyboardTopRowFunctionTitleID).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Display Keyboard top-row function Description")]
    public void ThenCheckDisplayKeyboardTopRowFunctionDescription()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionDescriptionID, "Element Keyboard Top Row Function Description Is Not Found");
    }

    [Then(@"Check Description Display '(.*)'")]
    public void ThenCheckDescriptionDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionDescriptionID);
        Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.KeyboardTopRowFunctionDescriptionID).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Two Buttons Under The Description")]
    public void ThenCheckTwoButtonsUnderTheDescription()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionSpecialFunction, "Element Keyboard Top Row Function 'Special function' Is Not Found");
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionF1F12Function, "Element Keyboard Top Row Function 'F1-F12 function' Is Not Found");
    }

    [Given(@"Select '(.*)' Button")]
    public void WhenTurnRapidChargeToggle(string selectElement)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        if (selectElement.ToLower().Equals("special function"))
        {
            if (_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionSpecialFunction) == ToggleState.Off)
            {
                _hSInputPage.KeyboardTopRowFunctionSpecialFunction.Click();
            }
            Assert.AreEqual(_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionSpecialFunction), ToggleState.On);
        }
        else if (selectElement.ToLower().Equals("f1-f12 function"))
        {
            if (_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionF1F12Function) == ToggleState.Off)
            {
                _hSInputPage.KeyboardTopRowFunctionF1F12Function.Click();
            }
            Assert.AreEqual(_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionF1F12Function), ToggleState.On);
        }
    }

    [Then(@"Check Tip Text Display '(.*)'")]
    public void ThenCheckTipTextDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        if (jsonPath.Equals("$.InputPage.KeyboardTopRowFunctionTip1Text"))
        {
            Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionTip1);
            Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.KeyboardTopRowFunctionTip1).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
        else if (jsonPath.Equals("$.InputPage.KeyboardTopRowFunctionTip2Text"))
        {
            Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionTip2);
            Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.KeyboardTopRowFunctionTip2).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }
    }

    [Then(@"Check Button '(.*)' Is Highlighted")]
    public void ThenCheckButtonIsHighlighted(string buttonName)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        if (buttonName.ToLower().Equals("special function"))
        {
            Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionSpecialFunction);
            Assert.AreEqual(_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionSpecialFunction), ToggleState.On);
        }
        else if (buttonName.ToLower().Equals("f1-f12 function"))
        {
            Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionF1F12Function);
            Assert.AreEqual(_hSInputPage.GetCheckBoxStatus(_hSInputPage.KeyboardTopRowFunctionF1F12Function), ToggleState.On);
        }
    }

    [Then(@"Keyboard top-row function UI Elements Not Change")]
    public void ThenKeyboardTopRowFunctionUIElementsNotChange()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionTitleID, "Element Keyboard Top Row Function Title Is Not Found");
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionDescriptionID, "Element Keyboard Top Row Function Description Is Not Found");
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionSpecialFunction, "Element Keyboard Top Row Function SpecialFunction Is Not Found");
        Assert.IsNotNull(_hSInputPage.KeyboardTopRowFunctionF1F12Function, "Element Keyboard Top Row Function F1F12Function Is Not Found");
    }
}

