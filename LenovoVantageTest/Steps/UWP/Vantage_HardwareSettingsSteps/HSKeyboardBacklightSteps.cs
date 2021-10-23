using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HSKeyboardBacklightSteps : SettingsBase
    {
        private HSInputPage _HSInputPage;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private InformationalWebDriver _webDriver;
        private ToggleState _KBDLowOption = ToggleState.On;
        private ToggleState _KBDHighOption = ToggleState.Off;
        private ToggleState _KBDOffOption = ToggleState.Off;

        static private string _regFnSpaceKey = @"SYSTEM\CurrentControlSet\Services\IBMPMSVC\Parameters\Notification";
        private object _typeFnSpaceValueInit;
        SmartStandbyTestSteps ssts;

        public HSKeyboardBacklightSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            ssts = new SmartStandbyTestSteps(_webDriver);
        }
        [When(@"Click (.*) option of KBD Backlight")]
        public void WhenClickOptionOfKBDBacklight(string status)
        {
            _HSInputPage = new HSInputPage(_webDriver.Session);
            if (status == "Low")
            {
                _HSInputPage.backlightOptionLow.Click();
            }
            else if (status == "High")
            {
                _HSInputPage.backlightOptionHigh.Click();
            }
            else if (status == "Off")
            {
                _HSInputPage.backlightOptionOff.Click();
            }
            else
            {
                Assert.Fail("KBD has no such option");
            }
        }

        [Given(@"support keyboard backlight section")]
        public void GivenSupportKBbacklight()
        {
            _HSInputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_HSInputPage.keyboardBacklightTitleOfThinkPad, "The keyboardBacklightTitleOfThinkPad not found");
            Assert.IsNotNull(_HSInputPage.KBCaptionOfThinkPad, "The KBCaptionOfThinkPad not found");
            Assert.IsNotNull(_HSInputPage.KBCaptionContentOfThinkPad, "The KBCaptionContentOfThinkPad not found");
            ScrollScreenToWindowsElement(_webDriver.Session, _HSInputPage.backlightOptionLow, -30, 10, true);
        }

        [Then(@"check KBD option change")]
        public void ThenCheckKBbacklightOptionValue()
        {
            Thread.Sleep(3000);
            _HSInputPage = new HSInputPage(_webDriver.Session);
            _KBDLowOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionLow);
            _KBDHighOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionHigh);
            _KBDOffOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionOff);

            if (_KBDLowOption == ToggleState.On)
            {
                Assert.AreEqual(ToggleState.Off, _KBDHighOption);
                Assert.AreEqual(ToggleState.Off, _KBDOffOption);
            }
            else if (_KBDHighOption == ToggleState.On)
            {
                Assert.AreEqual(ToggleState.Off, _KBDOffOption);
                Assert.AreEqual(ToggleState.Off, _KBDLowOption);
            }
            else if (_KBDOffOption == ToggleState.On)
            {
                Assert.AreEqual(ToggleState.Off, _KBDLowOption);
                Assert.AreEqual(ToggleState.Off, _KBDHighOption);
            }

        }

        [Then(@"check KBD option (.*) change")]
        public void ThenCheckKBbacklightOptionValue(string optionval)
        {
            Thread.Sleep(3000);
            _HSInputPage = new HSInputPage(_webDriver.Session);
            _KBDLowOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionLow);
            _KBDHighOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionHigh);
            _KBDOffOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionOff);

            if (optionval == "Low")
            {
                Assert.AreEqual(ToggleState.Off, _KBDHighOption);
                Assert.AreEqual(ToggleState.Off, _KBDOffOption);
                Assert.AreEqual(ToggleState.On, _KBDLowOption);
            }
            else if (optionval == "High")
            {
                Assert.AreEqual(ToggleState.Off, _KBDOffOption);
                Assert.AreEqual(ToggleState.Off, _KBDLowOption);
                Assert.AreEqual(ToggleState.On, _KBDHighOption);
            }
            else if (optionval == "Off")
            {
                Assert.AreEqual(ToggleState.Off, _KBDLowOption);
                Assert.AreEqual(ToggleState.Off, _KBDHighOption);
                Assert.AreEqual(ToggleState.On, _KBDOffOption);
            }
            else
            {

                Assert.Fail("KBD Option has no such option");
            }

        }

        [Then(@"The keyboard backlight button displays same as with Vantage")]
        public void ThenTheKeyboardBacklightButtonDisplaysSameAsWithVantage()
        {
            string backlightStatus = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
            _HSInputPage = new HSInputPage(_webDriver.Session);
            _HSInputPage.GotoInputPage();
            GivenSupportKBbacklight();
            _KBDLowOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionLow);
            _KBDHighOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionHigh);
            _KBDOffOption = _HSInputPage.GetCheckBoxStatus(_HSInputPage.backlightOptionOff);
            if (_KBDHighOption == ToggleState.On)
            {
                Assert.AreEqual(backlightStatus, "keyboard backlight high.", "The keyboard backlight button displays not same as with Vantage");
            }
            else if (_KBDLowOption == ToggleState.On)
            {
                Assert.AreEqual(backlightStatus, "keyboard backlight low.", "The keyboard backlight button displays not same as with Vantage");
            }
            else if (_KBDOffOption == ToggleState.On)
            {
                Assert.AreEqual(backlightStatus, "keyboard backlight off.", "The keyboard backlight button displays not same as with Vantage");
            }
            else
            {
                Assert.Fail("keyboard backlight status error");
            }
        }

        [When(@"Press (.*) and (.*) Event")]
        public void WhenPressFEvent(string Key1, string Key2)
        {
            object typeFnSpaceValue = ssts.GetRegistryValue(_regFnSpaceKey, "Default");
            if (typeFnSpaceValue != null)
            {
                _typeFnSpaceValueInit = typeFnSpaceValue;
            }
            else
            {
                Assert.Fail("The machine not support UserDefinedKey");
            }
            if (Key1.Equals("Fn") && Key2.Equals("Space"))
            {
                uint value = Convert.ToUInt32(_typeFnSpaceValueInit);
                value = value ^ 0x00020000;
                int tempInt = 0;
                unchecked
                {
                    tempInt = Convert.ToInt32(value);
                }
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey tmp = rk.OpenSubKey(_regFnSpaceKey, true);
                tmp.SetValue("Default", tempInt, RegistryValueKind.DWord);
            }

        }

        [When(@"Switch to other page and back to input page")]
        public void WhenSwitchtoOtherpageandBacktoInputpage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.MySettingsAudio);
            _hsQuickSettingsPage.GotoInputPage();
        }
    }
}
