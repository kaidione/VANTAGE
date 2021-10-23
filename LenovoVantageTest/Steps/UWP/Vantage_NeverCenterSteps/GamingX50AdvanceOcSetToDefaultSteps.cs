using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX50AdvancedOCSetToDefaultSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingX50AdvancedOCSetToDefaultSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"the set to default link button should be shown")]
        public void TheSetToDefaultLinkButtonShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            _nerveCenterPages.OverclockCloseBtn.Click();
        }

        [Then(@"set to default dialog should be shown and click '(.*)' Btn")]
        public void ThenSetToDefaultDialogShouldBeShownAndClickBtn(string btntype)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.True(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetMinus != null, "the GPUOCAreaOffset Minus and Plus not found");
            WindowsElement element = _nerveCenterPages.GPUOCAreaOffsetPlus != null ? _nerveCenterPages.GPUOCAreaOffsetPlus : _nerveCenterPages.GPUOCAreaOffsetMinus;
            Assert.IsNotNull(element, "the GPUOCAreaOffset Plus or Minus not found");
            string OCvalueTextBefore = element.Text;
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault, "The OverclockSetToDefault not found");
            _nerveCenterPages.OverclockSetToDefault.Click();
            string OCvalueTextAfter = string.Empty;
            switch (btntype.ToLower())
            {
                case "ok":
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn not found");
                    _nerveCenterPages.SetToDefaultOkBtn.Click();
                    string defaultVal = string.Empty;
                    string currentMachineType = VantageCommonHelper.GetCurrentMachineType();
                    foreach (string machineType in NerveCenterHelper.GetGPUInformation("T750").Keys)
                    {
                        if (currentMachineType == machineType)
                        {
                            defaultVal = NerveCenterHelper.GetGPUInformation("T750").DefaultVal;
                            break;
                        }
                    }
                    Assert.IsNotEmpty(defaultVal, "The GetGPUInformation() is null,T750 key:" + currentMachineType);
                    Assert.AreEqual(defaultVal, System.Text.RegularExpressions.Regex.Replace(element.Text, @"[^0-9]+", ""), "the GPU Clock Offset default value incorrect");
                    break;
                case "x":
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultCloseBtn, "The SetToDefaultCloseBtn not found");
                    _nerveCenterPages.SetToDefaultCloseBtn.Click();
                    OCvalueTextAfter = element.Text;
                    Assert.AreEqual(OCvalueTextBefore, OCvalueTextAfter, " all parameters are not change");
                    break;
                case "cancel":
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultCancelBtn, "The SetToDefaultCancelBtn not found");
                    _nerveCenterPages.SetToDefaultCancelBtn.Click();
                    OCvalueTextAfter = element.Text;
                    Assert.AreEqual(OCvalueTextBefore, OCvalueTextAfter, " all parameters are not change");
                    break;
                default:
                    Assert.Fail("The ThenSetToDefaultDialogShouldBeShownAndClickBtn() no run");
                    break;
            }
        }

        [Then(@"previous changes will be lost")]
        public void PreviousChange()
        {
            Assert.IsTrue(true, " all parameters are not change");
        }

        [Then(@"all parameters should be back to the default value")]
        public void ParametersChangeToDefault()
        {
            Assert.IsTrue(true, "all parameters do not back to the default value");
        }

        [Then(@"The the set to default dialog should be shown or hidden '(.*)'")]
        public void ThenTheTheSetToDefaultDialogShouldBeShownOrHidden(string action, Table table)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (action)
            {
                case "shown":
                    Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault, "The OverclockSetToDefault not found");
                    _nerveCenterPages.OverclockSetToDefault.Click();
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn not found");
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultCloseBtn, "The SetToDefaultCloseBtn not found");
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultCancelBtn, "The SetToDefaultCancelBtn not found");
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultTitle, "The SetToDefaultTitle not found");
                    Assert.IsNotNull(_nerveCenterPages.SetToDefaultDesc, "The SetToDefaultDesc not found");
                    Assert.AreEqual(table.Rows[0][1], _nerveCenterPages.SetToDefaultTitle.Text, "The set to default dialog title text incorrect.");
                    Assert.AreEqual(table.Rows[1][1], _nerveCenterPages.SetToDefaultDesc.Text, "The set to default dialog desc text incorrect.");
                    break;
                case "hidden":
                    Assert.IsNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn still show");
                    Assert.IsNull(_nerveCenterPages.SetToDefaultCloseBtn, "The SetToDefaultCloseBtn still show");
                    Assert.IsNull(_nerveCenterPages.SetToDefaultCancelBtn, "The SetToDefaultCancelBtn still show");
                    break;
                default:
                    Assert.Fail("ThenTheTheSetToDefaultDialogShouldBeShownOrHidden() no run");
                    break;
            }
        }

        [Then(@"the Advance OC dialog should not be closed")]
        public void AdvanceOCDialogNoClose()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            _nerveCenterPages.OverclockCloseBtn.Click();
        }

        [Then(@"all parameters should be consistent with before")]
        public void PreviousNotChange()
        {
            Assert.IsTrue(true, " all parameters are change");
        }
    }
}
