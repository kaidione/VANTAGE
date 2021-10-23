using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

[Binding]
public class HiddenKeyboardFunctions : SettingsBase
{
    private InformationalWebDriver _webDriver;
    private HSInputPage _hSInputPage;
    public HiddenKeyboardFunctions(InformationalWebDriver appDriver)
    {
        _webDriver = appDriver;
    }

    [Then(@"Check Hidden Keyboard Functions Title Display '(.*)'")]
    public void ThenCheckHiddenKeyboardFunctionsTitleDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.HiddenKeyboardFunctionsTitleId);
        Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.HiddenKeyboardFunctionsTitleId).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check Hidden Keyboard Functions Text Display '(.*)'")]
    public void ThenCheckHiddenKeyboardFunctionsTextDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.HiddenKeyboardFunctionsTextId);
        Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.HiddenKeyboardFunctionsTextId).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Check hidden Keys functions tips and exclusive keyboard map")]
    public void ThenCheckHiddenKeysFunctionsTipsAndExclusiveKeyboardMap()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.Fn4Title, "The Fn4Title is not find");
        //Assert.IsNotNull(_hSInputPage.FnDTitle, "The FnDTitle is not find");
        if (!(VantageConstContent.VantageTypePlan == VantageType.LE))
        {
            Assert.IsNotNull(_hSInputPage.Fn4Description, "The Fn4Description is not find");
            Assert.IsNotNull(_hSInputPage.FnDDescription, "The FnDDescription is not find");
        }
        else
        {
            Assert.IsNotNull(_hSInputPage.Fn4DescriptionLe, "The Fn4DescriptionLe is not find");
            Assert.IsNotNull(_hSInputPage.FnDDescriptionLe, "The FnDDescriptionLe is not find");
            Assert.IsTrue(_hSInputPage.Fn4DescriptionLe.Text.ToLower().Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.Fn4Description").ToString().ToLower()), "The Fn4Description is not find");
            Assert.IsTrue(_hSInputPage.FnDDescriptionLe.Text.ToLower().Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.InputPage.FnDDescription").ToString().ToLower()), "The FnDDescription is not find");
        }
    }

    [Then(@"No hidden keyboard feature")]
    public void ThenNoHiddenKeyboardFeature()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNull(_hSInputPage.HiddenKeyboardFunctionsTitleId, "The HiddenKeyboard function found");
    }

    [Then(@"Fn Tab is shown")]
    public void ThenFnTabIsShown()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.FnTabTitle, "The FnTab was not found");
    }

    [Then(@"Check Fn Tab display '(.*)'")]
    public void ThenCheckFnTabDisplay(string jsonPath)
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.IsNotNull(_hSInputPage.FnTabDescription, "The FnTab was not found");
        Assert.IsTrue(_hSInputPage.ShowTextbox(_hSInputPage.FnTabDescription).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
    }

    [Then(@"Fn Tab is not shown")]
    public void ThenFnTabIsNotShown()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.NotNull(_hSInputPage.Fn4Title, "The Fn4 was not found");
        ScrollScreenToWindowsElement(_webDriver.Session, _hSInputPage.Fn4Title);
        Assert.IsNull(_hSInputPage.FnTabTitle, "The FnTab is found");
    }

    [When(@"Scroll to Fn Tab")]
    public void WhenScrollToFnTab()
    {
        _hSInputPage = new HSInputPage(_webDriver.Session);
        Assert.NotNull(_hSInputPage.FnTabTitle, "The FnTab was not found");
        ScrollScreenToWindowsElement(_webDriver.Session, _hSInputPage.FnTabTitle);
    }

}



