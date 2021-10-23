using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class KeyboardTopRowFunctionSteps : SettingsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private InformationalWebDriver _webDriver;
        private HSInputPage _hsInput;
        private bool _isException = false;

        public KeyboardTopRowFunctionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to Keyboard top row function section")]
        public void GivenGoToKeyboardTopRowFunctionSection()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.KBDTopRowAdvanceSettinsLinkXpath, "The KBDTopRowAdvanceSettinsLinkXpath not found");
            ScrollScreenToWindowsElement(_webDriver.Session, _hsInput.KBDTopRowAdvanceSettinsLinkXpath);
        }

        [Then(@"The top row title show '(.*)'")]
        public void ThenTheTopRowTitleShow(string text)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.KBDTopRowTitle, "The KBDTopRowTitle not found");
            Assert.AreEqual(text, _hsInput.KBDTopRowTitle.Text, "The top row title text show incorrect");
        }

        [Then(@"The Advance Settings Link show on the bottom")]
        public void ThenTheAdvanceSettingsLinkShowOnTheBottom()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.KBDTopRowTitle, "The KBDTopRowTitle not found");
            Assert.NotNull(_hsInput.KBDTopRowAdvanceSettinsLinkXpath, "The KBDTopRowAdvanceSettinsLinkXpath not found");
            Assert.LessOrEqual(_hsInput.KBDTopRowTitle.Location.Y, _hsInput.KBDTopRowAdvanceSettinsLinkXpath.Location.Y, "Advance Settings Link not show on the bottom");
        }

        [When(@"Click Advance Link within top row function")]
        public void WhenClickAdvanceLinkWithinTopRowFunction()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.KBDTopRowAdvanceSettinsLinkXpath, "The KBDTopRowAdvanceSettinsLinkXpath not found");
            _hsInput.KBDTopRowAdvanceSettinsLinkXpath.Click();
            ScrollScreenToWindowsElement(_webDriver.Session, _hsInput.KBDTopRowAdvanceSettinsLinkXpath);
        }


        [Then(@"The Special key and Function key show")]
        public void ThenTheSpecialKeyAndFunctionKeyShow()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.FunctionKeyRadio, "The FunctionKeyRadio not show");
            Assert.NotNull(_hsInput.SpecialKeyRadio, "The SpecialKeyRadio not show");
        }

        [Then(@"The top row description show correct")]
        public void ThenTheTopRowDescriptionShowCorrect(Table table)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "top row desc":
                        Assert.NotNull(_hsInput.KBDTopRowDesc, "The KBDTopRowDesc not show");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.KBDTopRowDesc.Text, "The KBDTopRowDesc text incorrect");
                        break;
                    case "top row subdesc":
                        if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan != Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
                        {
                            Assert.NotNull(_hsInput.KBDTopRowSubDesc, "The KBDTopRowSubDesc not show");
                            Assert.AreEqual(table.Rows[i][1], _hsInput.KBDTopRowSubDesc.Text, "The KBDTopRowSubDesc text incorrect");
                        }
                        break;
                    case "top row subdescl le":
                        if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan == Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
                        {
                            Assert.NotNull(_hsInput.KBDTopRowSubDesc, "The KBDTopRowSubDesc not show");
                            Assert.AreEqual(table.Rows[i][1], _hsInput.KBDTopRowSubDesc.Text, "The KBDTopRowSubDesc text incorrect");
                        }
                        break;
                    case "reversing default primary function desc":
                        Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionDesc, "The ReversingDefaultPrimaryFunctionDesc not show");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.ReversingDefaultPrimaryFunctionDesc.Text, "The ReversingDefaultPrimaryFunctionDesc text incorrect");
                        break;
                    case "fn key combinations desc":
                        Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsDesc, "The KBDTopRowFnKeyCombinationsDesc not show");
                        Assert.IsTrue(_hsInput.KBDTopRowFnKeyCombinationsDesc.GetAttribute("Name").Contains(table.Rows[i][1]), "The KBDTopRowFnKeyCombinationsDesc text incorrect");
                        break;
                    case "fn sticky key method desc":
                        Assert.NotNull(_hsInput.KBDTopRowFnStickyKeyMethodNote, "The KBDTopRowFnStickyKeyMethodNote not show");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.KBDTopRowFnStickyKeyMethodNote.Text.Replace("Note,", "Note:"), "The KBDTopRowFnStickyKeyMethodNote text incorrect");
                        break;
                    default:
                        Assert.Fail("ThenTheAudioSmartSettingsDescriptionShouldBeCorrect() no run.");
                        break;
                }
            }
        }

        [When(@"The select '(.*)' function within top row function")]
        public void WhenTheSelectFunctionWithinTopRowFunction(string func)
        {
            try
            {
                _hsInput = new HSInputPage(_webDriver.Session);
                switch (func.ToLower())
                {
                    case "special key":
                        Assert.NotNull(_hsInput.KBDTopRowSpecialKeyRadio, "The KBDTopRowSpecialKeyRadio not found");
                        if (!_hsInput.KBDTopRowSpecialKeyRadio.Enabled)
                        {
                            WhenClickAdvanceLinkWithinTopRowFunction();
                            SetCheckBoxStatus(_hsInput.KBDTopRowNormalMethodRadio, ToggleState.On, _webDriver.Session);
                        }
                        SetCheckBoxStatus(_hsInput.KBDTopRowSpecialKeyRadio, ToggleState.On, _webDriver.Session);
                        Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hsInput.KBDTopRowSpecialKeyRadio), "Select KBDTopRowSpecialKeyRadio fail." + func);
                        break;
                    case "function key":
                        ScrollScreenToWindowsElement(_webDriver.Session, _hsInput.KBDTopRowTitle, 30);
                        if (!_hsInput.KBDTopRowFunctionKeyRadio.Enabled)
                        {
                            WhenClickAdvanceLinkWithinTopRowFunction();
                            SetCheckBoxStatus(_hsInput.KBDTopRowNormalMethodRadio, ToggleState.On, _webDriver.Session);
                        }
                        Assert.NotNull(_hsInput.KBDTopRowFunctionKeyRadio, "The KBDTopRowFunctionKeyRadio not found");
                        SetCheckBoxStatus(_hsInput.KBDTopRowFunctionKeyRadio, ToggleState.On, _webDriver.Session);
                        Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hsInput.KBDTopRowFunctionKeyRadio), "Select KBDTopRowFunctionKeyRadio fail." + func);
                        break;
                    case "normal method":
                        Assert.NotNull(_hsInput.KBDTopRowNormalMethodRadio, "The KBDTopRowNormalMethodRadio not found");
                        SetCheckBoxStatus(_hsInput.KBDTopRowNormalMethodRadio, ToggleState.On, _webDriver.Session);
                        Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hsInput.KBDTopRowNormalMethodRadio), "Select KBDTopRowNormalMethodRadio fail." + func);
                        break;
                    case "fn sticky key method":
                        Assert.NotNull(_hsInput.KBDTopRowFnStickyKeyMethodRadio, "The KBDTopRowFnStickyKeyMethodRadio not found");
                        SetCheckBoxStatus(_hsInput.KBDTopRowFnStickyKeyMethodRadio, ToggleState.On, _webDriver.Session);
                        Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hsInput.KBDTopRowFnStickyKeyMethodRadio), "Select KBDTopRowFnStickyKeyMethodRadio fail." + func);
                        break;
                    default:
                        Assert.Fail("The WhenTheSelectFunctionWithinTopRowFucntion() no run.");
                        break;
                }
                _isException = false;
            }
            catch
            {
                if (_isException)
                {
                    _isException = false;
                    return;
                }
                _isException = true;
                WhenTheSelectFunctionWithinTopRowFunction(func);
            }
        }

        [Then(@"The '(.*)' function within top row fucntion status is correct '(.*)'")]
        public void ThenTheFunctionWithinTopRowFucntionStatusIsCorrect(string func, string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            ToggleState toggle = status == "selected" ? ToggleState.On : ToggleState.Off;
            switch (func.ToLower())
            {
                case "special key":
                    Assert.NotNull(_hsInput.KBDTopRowSpecialKeyRadio, "The KBDTopRowSpecialKeyRadio not found");
                    Assert.AreEqual(toggle, GetCheckBoxStatus(_hsInput.KBDTopRowSpecialKeyRadio), "The KBDTopRowSpecialKeyRadio status incorrect.Info:" + status);
                    break;
                case "function key":
                    Assert.NotNull(_hsInput.KBDTopRowFunctionKeyRadio, "The KBDTopRowFunctionKeyRadio not found");
                    Assert.AreEqual(toggle, GetCheckBoxStatus(_hsInput.KBDTopRowFunctionKeyRadio), "The KBDTopRowFunctionKeyRadio status incorrect.Info:" + status);
                    break;
                case "normal method":
                    Assert.NotNull(_hsInput.KBDTopRowNormalMethodRadio, "The KBDTopRowNormalMethodRadio not found");
                    Assert.AreEqual(toggle, GetCheckBoxStatus(_hsInput.KBDTopRowNormalMethodRadio), "Select KBDTopRowNormalMethodRadio fail." + status);
                    break;
                case "fn sticky key method":
                    Assert.NotNull(_hsInput.KBDTopRowFnStickyKeyMethodRadio, "The KBDTopRowFnStickyKeyMethodRadio not found");
                    Assert.AreEqual(toggle, GetCheckBoxStatus(_hsInput.KBDTopRowFnStickyKeyMethodRadio), "Select KBDTopRowFnStickyKeyMethodRadio fail." + status);
                    break;
                default:
                    Assert.Fail("The ThenTheFunctionWithinTopRowFucntionStatusIsCorrect() no run.");
                    break;
            }
        }

        [Then(@"The Reversing the default primary function will be shown or hidden '(.*)'")]
        public void ThenTheReversingTheDefaultPrimaryFunctionWillBeShownOrHidden(string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "shown":
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionTitle, "The ReversingDefaultPrimaryFunctionTitle not found");
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionTipsIcon, "The ReversingDefaultPrimaryFunctionTipsIcon not found");
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionDesc, "The ReversingDefaultPrimaryFunctionDesc not found");
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionToggle, "The ReversingDefaultPrimaryFunctionToggle not found");
                    break;
                case "hidden":
                    Assert.Null(_hsInput.ReversingDefaultPrimaryFunctionTitle, "The ReversingDefaultPrimaryFunctionTitle still show");
                    Assert.Null(_hsInput.ReversingDefaultPrimaryFunctionTipsIcon, "The ReversingDefaultPrimaryFunctionTipsIcon still show");
                    Assert.Null(_hsInput.ReversingDefaultPrimaryFunctionDesc, "The ReversingDefaultPrimaryFunctionDesc still show");
                    Assert.Null(_hsInput.ReversingDefaultPrimaryFunctionToggle, "The ReversingDefaultPrimaryFunctionToggle still show");
                    break;
                default:
                    Assert.Fail("The ThenTheReversingTheDefaultPrimaryFunctionWillBeShownOrHidden() no run," + status);
                    break;
            }

        }

        [Then(@"The How to use Fn key combinations will be shown or hidden '(.*)'")]
        public void ThenTheHowToUseFnKeyCombinationsWillBeShownOrHidden(string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "shown":
                    Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsTitle, "The KBDTopRowFnKeyCombinationsTitle not found");
                    if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan == Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
                    {
                        Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsDescs, "The KBDTopRowFnKeyCombinationsDesc not found");
                    }
                    else
                    {
                        Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsDesc, "The KBDTopRowFnKeyCombinationsDesc not found");
                    }
                    Assert.NotNull(_hsInput.KBDTopRowNormalMethodRadio, "The KBDTopRowNormalMethodRadio not found");
                    Assert.NotNull(_hsInput.KBDTopRowFnStickyKeyMethodRadio, "The KBDTopRowFnStickyKeyMethodRadio not found");
                    break;
                case "hidden":
                    Assert.Null(_hsInput.KBDTopRowFnKeyCombinationsTitle, "The KBDTopRowFnKeyCombinationsTitle still show");
                    if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan == Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
                    {
                        Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsDescs, "The KBDTopRowFnKeyCombinationsDesc not found");
                    }
                    else
                    {
                        Assert.NotNull(_hsInput.KBDTopRowFnKeyCombinationsDesc, "The KBDTopRowFnKeyCombinationsDesc not found");
                    }
                    Assert.Null(_hsInput.KBDTopRowNormalMethodRadio, "The KBDTopRowNormalMethodRadio still show");
                    Assert.Null(_hsInput.KBDTopRowFnStickyKeyMethodRadio, "The KBDTopRowFnStickyKeyMethodRadio still show");
                    break;
                default:
                    Assert.Fail("The ThenTheHowToUseFnKeyCombinationsWillBeShownOrHidden() no run," + status);
                    break;
            }
        }

        [When(@"Turn on or off Reversing the default primary function '(.*)'")]
        public void WhenTurnOnOrOffReversingTheDefaultPrimaryFunction(string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionToggle, "The ReversingDefaultPrimaryFunctionToggle not found");
                    _hsInput.ReversingDefaultPrimaryFunctionToggle.Click();
                    Assert.NotNull(_hsInput.KBDTopRowPopupWindowTitle, "The KBDTopRowPopupWindowTitle not found");
                    Assert.NotNull(_hsInput.KBDTopRowPopupWindowNotNowBtn, "The KBDTopRowPopupWindowNotNowBtn not found");
                    break;
                case "off":
                    Assert.NotNull(_hsInput.ReversingDefaultPrimaryFunctionToggle, "The ReversingDefaultPrimaryFunctionToggle not found");
                    SetCheckBoxStatus(_hsInput.ReversingDefaultPrimaryFunctionToggle, ToggleState.Off, _webDriver.Session);
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(_hsInput.ReversingDefaultPrimaryFunctionToggle), "Set ReversingDefaultPrimaryFunctionToggle status fail.");
                    break;
                default:
                    Assert.Fail("The WhenTurnOnOrOffReversingTheDefaultPrimaryFunction() no run," + status);
                    break;
            }
        }

        [Then(@"The Reversing the default primary function pop up show correct")]
        public void ThenTheReversingTheDefaultPrimaryFunctionPopUpShowCorrect(string text)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.KBDTopRowPopupWindowDesc, "The KBDTopRowPopupWindowDesc not found");
            Assert.AreEqual(text, _hsInput.KBDTopRowPopupWindowDesc.Text, "The KBDTopRowPopupWindowDesc pop up Text incorect");
            Assert.NotNull(_hsInput.KBDTopRowPopupWindowCloseBtn, "The KBDTopRowPopupWindowCloseBtn not found");
            Assert.NotNull(_hsInput.KBDTopRowPopupWindowTitle, "The KBDTopRowPopupWindowTitle not found");
            Assert.NotNull(_hsInput.KBDTopRowPopupWindowNotNowBtn, "The KBDTopRowPopupWindowNotNowBtn not found");
            if (LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent.VantageTypePlan == Pages.HardwareSettingsPages.VantageConstContent.VantageType.LE)
            {
                Assert.NotNull(_hsInput.KBDTopRowPopupWindowYesBtns, "The KBDTopRowPopupWindowYesBtn not found");
            }
            else
            {
                Assert.NotNull(_hsInput.KBDTopRowPopupWindowYesBtn, "The KBDTopRowPopupWindowYesBtn not found");
            }
        }

        [Then(@"The How to use Fn key combinations note show or hide '(.*)'")]
        public void ThenTheHowToUseFnKeyCombinationsNoteShowOrHide(string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.NotNull(_hsInput.KBDTopRowFnStickyKeyMethodNote, "The KBDTopRowFnStickyKeyMethodNote not found");
                    break;
                case "hide":
                    Assert.Null(_hsInput.KBDTopRowFnStickyKeyMethodNote, "The KBDTopRowFnStickyKeyMethodNote still show");
                    break;
                default:
                    Assert.Fail("The ThenTheHowToUseFnKeyCombinationsNoteShowOrHide() no run," + status);
                    break;
            }
        }

    }
}
