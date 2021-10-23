using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest
{
    [Binding]
    public class GamingMacroKeyStepDefinition : SettingsBase
    {

        private WindowsDriver<WindowsElement> _session;
        private InformationalWebDriver _webDriver;
        private bool _isSupport = false;
        private NerveCenterPages _nerveCenterPages;
        private List<string> _curApplist = new List<string>();
        static private int _KEYDOWN = 0;
        static private int _KEYUP = 2;
        private IntelligentCoolingBaseHelper _iMCService;
        private HSSmartAssistPage _hSSmartAssist;
        private WindowsDriver<WindowsElement> _appsession;

        public GamingMacroKeyStepDefinition(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"Launch Vantage for MacroKey")]
        public void GivenLaunchVantageForMacroKey()
        {
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _session = _webDriver.Session;
            _session.Manage().Window.Maximize();
            var windowsElement = VantageCommonHelper.FindElementByXPath(_session, VantageConstContent.OoBeNextButton, 3);
            windowsElement?.Click();
            windowsElement = VantageCommonHelper.FindElementByXPath(_session, VantageConstContent.OoBeDoneButton, 3);
            windowsElement?.Click();
        }

        [Given(@"Judge gaming machine not support macro key")]
        public void GivenJudgeGamingMachineNotSupportMacroKey()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            var machine = NerveCenterHelper.GetGamingMachineInfo(currentMachineType);
            if (machine.GetValues(machine.GamingSystemTools.MacroKey).Support)
            {
                Assert.Fail("Gaming machine should not be Y740 sample.");
            }
        }

        [Given(@"Select the number (.*)")]
        public void GivenSelectTheNumber(string number)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (number.ToLower())
            {
                case "m1":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPadM1, "The Macro Key number pad M1 is not show.");
                    _nerveCenterPages.MacroKeyNumPadM1.Click();
                    break;
                case "m2":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPadM2, "The Macro Key number pad M2 is not show.");
                    _nerveCenterPages.MacroKeyNumPadM2.Click();
                    break;
                case "0":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad0, "The Macro Key number pad 0 is not show.");
                    _nerveCenterPages.MacroKeyNumPad0.Click();
                    break;
                case "1":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad1, "The Macro Key number pad 1 is not show.");
                    _nerveCenterPages.MacroKeyNumPad1.Click();
                    break;
                case "2":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad2, "The Macro Key number pad 2 is not show.");
                    _nerveCenterPages.MacroKeyNumPad2.Click();
                    break;
                case "3":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad3, "The Macro Key number pad 3 is not show.");
                    _nerveCenterPages.MacroKeyNumPad3.Click();
                    break;
                case "4":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad4, "The Macro Key number pad 4 is not show.");
                    _nerveCenterPages.MacroKeyNumPad4.Click();
                    break;
                case "5":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad5, "The Macro Key number pad 5 is not show.");
                    _nerveCenterPages.MacroKeyNumPad5.Click();
                    break;
                case "6":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad6, "The Macro Key number pad 6 is not show.");
                    _nerveCenterPages.MacroKeyNumPad6.Click();
                    break;
                case "7":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad7, "The Macro Key number pad 7 is not show.");
                    _nerveCenterPages.MacroKeyNumPad7.Click();
                    break;
                case "8":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad8, "The Macro Key number pad 8 is not show.");
                    _nerveCenterPages.MacroKeyNumPad8.Click();
                    break;
                case "9":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad9, "The Macro Key number pad 9 is not show.");
                    _nerveCenterPages.MacroKeyNumPad9.Click();
                    break;
                default:
                    Assert.Fail("Please input number pad 0-9, M1, M2.");
                    break;
            }
        }

        [Given(@"Click the START RECORDING button")]
        public void GivenClickTheSTARTRECORDINGButton()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            if (_nerveCenterPages.MacroKeyClearRecords != null)
            {
                _nerveCenterPages.MacroKeyClearRecords.Click();
                Thread.Sleep(1000);
                if (_nerveCenterPages.MacrokeyClearRecordsDialogClearBtn != null)
                {
                    _nerveCenterPages.MacrokeyClearRecordsDialogClearBtn.Click();
                    Thread.Sleep(3000);
                }
            }
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "The Macro Key start recording button is not show.");
            _nerveCenterPages.MacroKeyStartRecording?.Click();
        }

        [Given(@"Type in ""(.*)""")]
        public void GivenTypeIn(string keys)
        {
            SendKeys.SendWait(keys);
        }

        [Given(@"Click The Macro Key Title")]
        public void GivenClickTheMacroKeyTitle()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyTitle, "Failed to find the Macro Key title.");
            _nerveCenterPages.MacroKeyTitle?.Click();
        }

        [Given(@"Type in ""(.*)"" with interval ""(.*)"" seconds")]
        public void GivenTypeInSlowly(string keys, double seconds)
        {
            foreach (char key in keys)
            {
                SendKeys.SendWait(key.ToString());
                Thread.Sleep(TimeSpan.FromSeconds(seconds));
            }
        }

        [Given(@"Click the STOP RECORDING button")]
        public void GivenClickTheSTOPRECORDINGButton()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStopRecording, "The Macro Key stop recording button is not show.");
            _nerveCenterPages.MacroKeyStopRecording?.Click();
        }

        [StepDefinition(@"Waiting (.*) seconds")]
        public void GivenWaitingSeconds(int seconds)
        {
            Thread.Sleep(1000 * seconds);
        }

        [Given(@"Click the CLEAR button under the macro key subpage.")]
        public void GivenClickTheCLEARButtonUnderTheMacroKeySubpage_()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecords, "Clear button is not show.");
            _nerveCenterPages.MacroKeyClearRecords?.Click();
        }

        [Given(@"Open Vantage to the home page")]
        public void GivenOpenVantageToTheHomePage()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The Device Menu button not show.");
            _nerveCenterPages.GamingDeviceMenu?.Click();
        }

        [When(@"Click the macrokey icon in the System tools area")]
        public void WhenClickTheMacrokeyIconInTheSystemToolsArea()
        {
            Thread.Sleep(3000);
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The Device Menu button not show.");
            _nerveCenterPages.GamingDeviceMenu?.Click();
            Assert.IsNotNull(_nerveCenterPages.SystemToolsMacroKey, "The Macro Key not show.");
            _nerveCenterPages.SystemToolsMacroKey?.Click();
        }

        [When(@"Hovering the c row")]
        public void WhenHoveringTheRow()
        {
            VantageCommonHelper.ChangeDPI("100%");
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsTrue(_nerveCenterPages.Key4.Text.ToLower().Contains("c "), "The c row is not show.");
            VantageCommonHelper.HoverOnElement(_nerveCenterPages.Key4);
        }

        [When(@"Hovering on the delete icon")]
        public void WhenHoveringOnTheDeleteIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsTrue(_nerveCenterPages.Key4.Text.ToLower().Contains("c "), "The c row is not show.");
            _nerveCenterPages.Key4?.Click();
            var position = _nerveCenterPages.Key4.Location;
            var size = _nerveCenterPages.Key4.Size;
            string x = (position.X + size.Width * 31 / 32).ToString();
            string y = (position.Y + size.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y, true);
        }

        [When(@"Scroll the screen in macrokey subpage")]
        public void WhenScrollTheScreenInMacrokeySubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            _nerveCenterPages.ScrollScreen();
        }

        [When(@"Drag and drop the macro key subpage window")]
        public void WhenDragAndDropTheMacroKeySubpageWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.VantageMaximize, "The Vantage Maximize button not show.");
            _nerveCenterPages.VantageMaximize?.Click();
            _nerveCenterPages.VantageMaximize?.Click();
        }

        [When(@"Set to ""(.*)"" option")]
        public void WhenSetToOption(string option)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsDropMenu, "The Macro Key setting drop menu is not show.");
            _nerveCenterPages.MacroKeySettingsDropMenu?.Click();
            switch (option.ToLower())
            {
                case "always enable":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsOn, "The Macro Key setting on option is not show.");
                    _nerveCenterPages.MacroKeySettingsOn?.Click();
                    break;
                case "enabled only when gaming":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsEnabledWhenGaming, "The Macro Key setting enabled when gaming option is not show.");
                    _nerveCenterPages.MacroKeySettingsEnabledWhenGaming?.Click();
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsOff, "The Macro Key setting off option is not show.");
                    _nerveCenterPages.MacroKeySettingsOff?.Click();
                    break;
                default:
                    Assert.Fail("Please input following options: Always Enable, Enabled Only When Gaming, Off.");
                    break;
            }
        }

        [When(@"Stop the IMC service in the task manager")]
        public void WhenStopTheIMCServiceInTheTaskManager()
        {
            _iMCService = new IntelligentCoolingBaseHelper();
            _iMCService.IntelligentCoolinggIMCServiceControl(3);
        }

        [When(@"Start the IMC service in the task manager")]
        public void WhenStartTheIMCServiceInTheTaskManager()
        {
            _iMCService = new IntelligentCoolingBaseHelper();
            _iMCService.IntelligentCoolinggIMCServiceControl(2);
        }

        [Given(@"Pin Lenovo Vantage To Start")]
        public void GivenPinLenovoVantageToStart()
        {
            _hSSmartAssist = new HSSmartAssistPage(_session);
            _appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement win = FindElementByTimes(_appsession, "XPath", @"//*[@Name='Start']");
            win.Click();
            GivenTypeIn("Lenovo Vantage");
            WindowsElement pinbutton = FindElementByTimes(_appsession, "XPath", @"//*[@Name='Pin to Start']");
            if (pinbutton != null)
            {
                pinbutton.Click();
            }
            win.Click();
            Thread.Sleep(2000);
            win.Click();
        }

        [When(@"Click start Vantage")]
        public void WhenClickStartVantage()
        {
            _hSSmartAssist = new HSSmartAssistPage(_session);
            _appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement win = FindElementByTimes(_appsession, "XPath", @"//*[@Name='Start']");
            win.Click();
            WindowsElement appbutton = FindElementByTimes(_appsession, "XPath", "//*[contains(@Name, 'Lenovo Vantage')]");
            appbutton.Click();
        }

        [When(@"If Disabled Enable The CapsLK Lock")]
        public void WhenEnableTheCapsLKLock()
        {
            Thread.Sleep(1000);
            if (!Control.IsKeyLocked(Keys.CapsLock))
            {
                VantageCommonHelper.keybd_event(Keys.CapsLock, 0, _KEYDOWN, 0);
                VantageCommonHelper.keybd_event(Keys.CapsLock, 0, _KEYUP, 0);
            }
            Thread.Sleep(1000);
        }

        [When(@"Disable the CapsLK lock")]
        public void WhenDisableTheCapsLKLock()
        {
            Thread.Sleep(1000);
            if (Control.IsKeyLocked(Keys.CapsLock))
            {
                VantageCommonHelper.keybd_event(Keys.CapsLock, 0, _KEYDOWN, 0);
                VantageCommonHelper.keybd_event(Keys.CapsLock, 0, _KEYUP, 0);
            }
            Thread.Sleep(1000);
        }

        [When(@"Click the ""(.*)"" drop-down arrow and select ""(.*)""")]
        public void WhenClickTheDrop_DownArrowAndSelect(string drop, string item)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            if (drop.Trim().ToLower() == "repeat time")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsRepeatDrop, "Repeat times drop down is not show.");
                _nerveCenterPages.MacroKeySettingsRepeatDrop?.Click();
                switch (item.Trim().ToLower())
                {
                    case "repeat 2 times":
                        Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsRepeat2, "Repeat 2 times is not show.");
                        _nerveCenterPages.MacroKeySettingsRepeat2?.Click();
                        break;
                    case "repeat 3 times":
                        Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsRepeat3, "Repeat 3 times is not show.");
                        _nerveCenterPages.MacroKeySettingsRepeat3?.Click();
                        break;
                    default:
                        Assert.Fail("Please input Repeat n times.");
                        break;
                }
            }
            else if (drop.Trim().ToLower() == "delay status")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsDelayDrop, "Delay status drop down is not show.");
                _nerveCenterPages.MacroKeySettingsDelayDrop?.Click();
                switch (item.Trim().ToLower())
                {
                    case "keep delay":
                        Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsKeepDelay, "Keep Delay is not show.");
                        _nerveCenterPages.MacroKeySettingsKeepDelay?.Click();
                        break;
                    case "ignore delay":
                        Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsIgnoreDelay, "Ignore Delay is not show.");
                        _nerveCenterPages.MacroKeySettingsIgnoreDelay?.Click();
                        break;
                    default:
                        Assert.Fail("Please input Keep Delay or Ignore Delay.");
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input Repeat time or Delay status.");
            }
            Thread.Sleep(3000);
        }

        [When(@"Click the ""(.*)"" drop-down arrow")]
        public void WhenClickTheDrop_DownArrow(string drop)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            if (drop.Trim().ToLower() == "repeat time")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsRepeatDrop, "Repeat times drop down is not show.");
                _nerveCenterPages.MacroKeySettingsRepeatDrop?.Click();
            }
            else
            {
                Assert.Fail("Please input Repeat time or Delay status.");
            }

        }

        [Then(@"It will enter the macro key subpage")]
        public void ThenItWillEnterTheMacroKeySubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyTitle, "Fail to enter the macro key subpage.");
            Assert.IsTrue(_nerveCenterPages.MacroKeyTitle.Text == "Macro Key", "Fail to enter the macro key subpage.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyBackLink, "Fail to enter the macro key subpage.");
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            var machine = NerveCenterHelper.GetGamingMachineInfo(currentMachineType);
            Console.WriteLine(machine.GetValues(machine.GamingSystemTools.MacroKey).Support + ";" + currentMachineType);
            Assert.IsTrue(machine.GetValues(machine.GamingSystemTools.MacroKey).Support, "Current machine " + currentMachineType + "not support Macro Key.");
            if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "NumpadKey")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsDropMenu, "Fail to enter the macro key subpage.");
            }
            if (_nerveCenterPages.MacroKeyClearRecords != null)
            {
                _nerveCenterPages.MacroKeyClearRecords.Click();
                if (_nerveCenterPages.MacrokeyClearRecordsDialogClearBtn != null)
                {
                    _nerveCenterPages.MacrokeyClearRecordsDialogClearBtn.Click();
                }
            }
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "Start recording button is not show.");
            if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "NumpadKey")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad0, "The macro key number pad 0 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad1, "The macro key number pad 1 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad2, "The macro key number pad 2 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad3, "The macro key number pad 3 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad4, "The macro key number pad 4 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad5, "The macro key number pad 5 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad6, "The macro key number pad 6 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad7, "The macro key number pad 7 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad8, "The macro key number pad 8 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad9, "The macro key number pad 9 is not show.");
            }
            else if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "MKey")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPadM1, "The macro key number pad M1 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPadM2, "The macro key number pad M2 is not show.");
            }
            else
            {
                Assert.Fail("Please select a machine that has 17 keyboard layout or 15 keyboard layout.");
            }
        }

        [Then(@"For 17 keyboard layout, they are 10 keys can be set as macro key")]
        public void ThenForKeyboardLayoutTheyAreKeysCanBeSetAsMacroKey()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            var machine = NerveCenterHelper.GetGamingMachineInfo(currentMachineType);
            if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "NumpadKey")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad0, "The macro key number pad 0 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad1, "The macro key number pad 1 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad2, "The macro key number pad 2 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad3, "The macro key number pad 3 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad4, "The macro key number pad 4 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad5, "The macro key number pad 5 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad6, "The macro key number pad 6 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad7, "The macro key number pad 7 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad8, "The macro key number pad 8 is not show.");
                Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad9, "The macro key number pad 9 is not show.");
            }
        }

        [Then(@"As for the first time to launch this subpage, only number 0 and M1 are selected")]
        public void ThenAsForTheFirstTimeToLaunchThisSubpageOnlyNumberAndMAreSelected()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            var machine = NerveCenterHelper.GetGamingMachineInfo(currentMachineType);
            if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "NumpadKey")
            {
                Assert.IsTrue(_nerveCenterPages.MacroKeyNumPad0.Text.Contains("is selected"), "Only number 0 is selected.");
            }
            else if (machine.GetValues(machine.GamingSystemTools.MacroKey).Value == "MKey")
            {
                Assert.IsTrue(_nerveCenterPages.MacroKeyNumPadM1.Text.Contains("is selected"), "Only numpad M1 is selected.");
            }
            else
            {
                Assert.Fail("Please select a machine that has 17 keyboard layout or 15 keyboard layout.");
            }
        }

        [Then(@"Check that the binding number ""(.*)"" is consistent with SPEC before recording")]
        public void ThenCheckThatTheBindingNumberIsConsistentWithSPECBeforeRecording(string number)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            if (_nerveCenterPages.MacroKeyClearRecords != null)
            {
                _nerveCenterPages.MacroKeyClearRecords.Click();
                if (_nerveCenterPages.MacrokeyClearRecordsDialogClearBtn != null)
                {
                    _nerveCenterPages.MacrokeyClearRecordsDialogClearBtn.Click();
                }
            }
            if (number == "3")
            {
                Assert.IsNotNull(_nerveCenterPages.CreateAMacroKeyFor, "CREATE A MACRO KEY FOR is not show.");
                Assert.IsNotNull(_nerveCenterPages.Num, "NUM is not show.");
                Assert.IsNotNull(_nerveCenterPages.Number3, "3 is not show.");
                Assert.IsTrue(_nerveCenterPages.Number3.Text.Trim() == number, "The binding number 3 is not show.");
            }
            else if (number.ToLower() == "m2")
            {
                Assert.IsNotNull(_nerveCenterPages.CreateAMacroKeyFor, "CREATE A MACRO KEY FOR is not show.");
                Assert.IsNotNull(_nerveCenterPages.M2, "M2 is not show.");
                Assert.IsTrue(_nerveCenterPages.M2.Text.Trim() == number, "The prompt messages M2 is not show.");
            }
        }

        [Then(@"Check that the binding number ""(.*)"" is consistent with SPEC end record")]
        public void ThenCheckThatTheBindingNumberIsConsistentWithSPECEndRecord(string number)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            if (number == "3")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeyFor, "MACRO KEY FOR is not show.");
                Assert.IsNotNull(_nerveCenterPages.Num, "NUM is not show.");
                Assert.IsNotNull(_nerveCenterPages.Number3, "3 is not show.");
                Assert.IsTrue(_nerveCenterPages.Number3.Text.Trim() == number, "The binding number 3 is not show.");
            }
            else if (number.ToLower() == "m2")
            {
                Assert.IsNotNull(_nerveCenterPages.MacroKeyFor, "MACRO KEY FOR is not show.");
                Assert.IsNotNull(_nerveCenterPages.M2, "M2 is not show.");
                Assert.IsTrue(_nerveCenterPages.M2.Text.Trim() == number, "The prompt messages M2 is not show.");
            }
        }

        [Then(@"Check if there will pop-up the clear window")]
        public void ThenCheckIfThereWillPop_UpTheClearWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecordsDialog, "The clear window is not show.");
        }

        [Then(@"Check that the characters recorded under number are cleared")]
        public void ThenCheckThatTheCharactersRecordedUnderNumberAreCleared()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecordsDialogCloseButton, "Close button is not show.");
            _nerveCenterPages.MacroKeyClearRecordsDialogCloseButton?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecords, "Macrokey clear button is not show.");
            _nerveCenterPages.MacroKeyClearRecords?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecordsDialogCancelButton, "Cancel button is not show.");
            _nerveCenterPages.MacroKeyClearRecordsDialogCancelButton?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecords, "Macrokey clear button is not show.");
            _nerveCenterPages.MacroKeyClearRecords?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacrokeyClearRecordsDialogClearBtn, "Clear button is not show.");
            _nerveCenterPages.MacrokeyClearRecordsDialogClearBtn?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "The characters recorded under number are not cleared.");
        }

        [Then(@"Pop up the Time Out For Recording window")]
        public void ThenPopUpTheTimeOutForRecordingWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.Macrokey10sTimeoutDialog, "Time Out For Recording window is not show.");
            Assert.IsTrue(_nerveCenterPages.Macrokey10sTimeoutTitle.Text == "Time Out For Recording.", "Time Out For Recording window title is not right.");
            Assert.IsNotNull(_nerveCenterPages.Macrokey10sTimeoutDialogCloseBtn, "Time Out For Recording window close button is not show.");
            Assert.IsNotNull(_nerveCenterPages.Macrokey10sTimeoutDialogobBtn, "Time Out For Recording window ok button is not show.");
        }

        [Then(@"Show time out dialog if no input for 20s")]
        public void ThenShowTimeOutDialogIfNoInputForS()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.Macrokey20sTimeoutDialog, "Time Out For Recording for 20s window is not show.");
            Assert.IsTrue(_nerveCenterPages.Macrokey20sTimeoutTitle.Text == "Time Out For Recording.", "Time Out For Recording for 20s  title is not right.");
            Assert.IsNotNull(_nerveCenterPages.Macrokey20sTimeoutDialogCloseBtn, "Time Out For Recording for 20s window close button is not show.");
            Assert.IsNotNull(_nerveCenterPages.Macrokey20sTimeoutDialogobBtn, "Time Out For Recording for 20s window ok button is not show.");
        }

        [Then(@"The Maximum Input Reached dialog shows when key action reaches 40")]
        public void ThenTheMaximumInputReachedDialogShowsWhenKeyActionReaches()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacrokeyMaximumInputDialog, "The Maximum Input Reached dialog is not show.");
        }

        [Then(@"Go back to empty state after clicking OK")]
        public void ThenGoBackToEmptyStateAfterClickingOK()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.Macrokey10sTimeoutDialogobBtn, "Timeout Dialog ok button is not show.");
            _nerveCenterPages.Macrokey10sTimeoutDialogobBtn?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "Macrokey start recording button is not show.");
        }

        [Then(@"Go back to empty state after clicking OK for 20s dialog")]
        public void ThenGoBackToEmptyStateAfterClickingOKForSDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.Macrokey20sTimeoutDialogobBtn, "Timeout Dialog ok button for 20s is not show.");
            _nerveCenterPages.Macrokey20sTimeoutDialogobBtn?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "Macrokey start recording button is not show.");
        }

        [Then(@"clicking OK in Maximum Input Reached dialog to finish recording")]
        public void ThenClickingOKInMaximumInputReachedDialogToFinishRecording()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacrokeyMaximumInputDialogobBtn, "Maximum Input Reached dialog ok button is not show.");
            _nerveCenterPages.MacrokeyMaximumInputDialogobBtn?.Click();
            Assert.IsNotNull(_nerveCenterPages.MacroKeyClearRecords, "Macrokey subpage clear button is not show.");
        }

        [Then(@"The recording is canceled")]
        public void ThenTheRecordingIsCanceled()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "Macrokey start recording button is not show.");
        }

        [Then(@"clicking the icon and both rows of pressing and releasing will be deleted")]
        public void ThenClickingTheIconAndBothRowsOfPressingAndReleasingWillBeDeleted()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsTrue(_nerveCenterPages.Key4.Text.ToLower().Contains("c"), "The c row is not show.");
            _nerveCenterPages.Key4?.Click();
            var position = _nerveCenterPages.Key4.Location;
            var size = _nerveCenterPages.Key4.Size;
            string x = (position.X + size.Width * 31 / 32).ToString();
            string y = (position.Y + size.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y);
            Assert.IsFalse(_nerveCenterPages.Key4.Text.ToLower().Contains("c "), "The c row is not delete.");
            Assert.IsFalse(_nerveCenterPages.Key5.Text.ToLower().Contains("c "), "The c row is not delete.");
        }

        [Then(@"the speed of deleting is normally")]
        public void ThenTheSpeedOfDeletingIsNormally()
        {
            VantageCommonHelper.ChangeDPI("100%");
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyTitle, "The Macro Key Title is not show.");
            _nerveCenterPages.MacroKeyTitle.Click();
            Assert.IsNotNull(_nerveCenterPages.Key0, "The first row is not show.");
            var position = _nerveCenterPages.Key0.Location;
            var size = _nerveCenterPages.Key0.Size;
            string x = (position.X + size.Width * 31 / 32).ToString();
            string y = (position.Y + size.Height / 2).ToString();
            VantageCommonHelper.SetMouseClick(x, y);
            for (int i = 0; i < 19; i++)
            {
                VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTDOWN, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
                VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTUP, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
                Thread.Sleep(500);
            }
            Assert.IsNull(_nerveCenterPages.Key0, "The first row is not delete.");
        }

        [Then(@"The macro key page should be shown and recording will not be stopped")]
        public void ThenTheMacroKeyPageShouldBeShownAndRecordingWillNotBeStopped()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartTypingText, "START TYPING is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKey20InputsWithin20Seconds, "20 inputs within 20 seconds can be recorded. is not show");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStopRecording, "Stop Recording button is not show.");
        }

        [Then(@"The Macro key section will not be displayed")]
        public void ThenTheMacroKeySectionWillNotBeDisplayed()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNull(_nerveCenterPages.SystemToolsMacroKey, "The Macro key section should not be displayed if gaming machine is not Y740 sample.");
        }

        [Then(@"""(.*)"" will be output whenever ""(.*)"" is pressed")]
        public void ThenWillBeOutputWheneverIsPressed(string keys, string number)
        {
            SendKeys.SendWait("%");
            var systemVersion = Common.GetSystemVersion().ToString();
            AutomationElement windowsSearch = null;
            UIAutomationControl uIAutomationControl = new UIAutomationControl();
            Rect position;
            string x = string.Empty;
            string y = string.Empty;
            Process.Start("explorer.exe");
            Thread.Sleep(3000);
            if (systemVersion.Contains("19041"))
            {
                SendKeys.SendWait("^f");
                Thread.Sleep(3000);
                SendKeys.SendWait("{DELETE}");
            }
            else
            {
                windowsSearch = uIAutomationControl.FindElementsByClass(VantageConstContent.FileExplorer, VantageConstContent.ClassModernSearchBox)[0];
                position = windowsSearch.Current.BoundingRectangle;
                x = ((int)position.Left + (int)position.Width / 2).ToString();
                y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y);
            }
            Thread.Sleep(3000);

            number = number.ToLower();
            foreach (char num in number)
            {
                if (number.Contains("m1") || number.Contains("m2"))
                {
                    break;
                }
                else if (num < '0' || num > '9')
                {
                    Assert.Fail("Please input number pad 0-9.");
                }
                VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num.ToString()], 0, _KEYDOWN, 0);
                VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num.ToString()], 0, _KEYUP, 0);
                Thread.Sleep(5 * 1000);
            }
            if (number.Contains("m1") || number.Contains("m2"))
            {
                string num;
                for (int i = 0; i < number.Length; i += 2)
                {
                    num = number[i].ToString() + number[i + 1].ToString();
                    if (num == "m1" || num == "m2")
                    {
                        VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num], 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num], 0, _KEYUP, 0);
                    }
                    else
                    {
                        Assert.Fail("Please input M1, M2.");
                    }
                    Thread.Sleep(5 * 1000);
                }
            }
            Thread.Sleep(10 * 1000);

            string text = string.Empty;
            if (systemVersion.Contains("19041"))
            {
                windowsSearch = VantageCommonHelper.FindElementByIdIsEnabled(VantageConstContent.FileSearchTextBox);
                ValuePattern textPattern = windowsSearch.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                text = textPattern.Current.Value;
            }
            else
            {
                windowsSearch = uIAutomationControl.FindElementsByClass(VantageConstContent.FileExplorer, VantageConstContent.ClassRichEditBox)[0];
                ValuePattern textPattern = windowsSearch.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                text = textPattern.Current.Value;
            }

            _iMCService = new IntelligentCoolingBaseHelper();
            _iMCService.IntelligentCoolinggIMCServiceControl(2);

            Assert.AreEqual(keys, text);
        }

        [Then(@"Check if ""(.*)"" will be output in ""(.*)"" seconds whenever ""(.*)"" is pressed and ""(.*)"" is selected")]
        public void ThenCheckIfWillBeOutputWheneverIsPressedAndIsSelected(string keys, double seconds, string number, string delayStatus)
        {
            string lastKey = string.Empty;
            if (keys.Length > 0)
            {
                lastKey = keys[keys.Length - 1].ToString();
            }
            else
            {
                lastKey = keys;
            }
            SendKeys.SendWait("%");
            var systemVersion = Common.GetSystemVersion().ToString();
            AutomationElement windowsSearch = null;
            UIAutomationControl uIAutomationControl = new UIAutomationControl();
            Rect position;
            string x = string.Empty;
            string y = string.Empty;
            Process.Start("explorer.exe");
            Thread.Sleep(3000);
            if (systemVersion.Contains("19041"))
            {
                SendKeys.SendWait("^f");
                Thread.Sleep(3000);
                SendKeys.SendWait("{DELETE}");
            }
            else
            {
                windowsSearch = uIAutomationControl.FindElementsByClass(VantageConstContent.FileExplorer, VantageConstContent.ClassModernSearchBox)[0];
                position = windowsSearch.Current.BoundingRectangle;
                x = ((int)position.Left + (int)position.Width / 2).ToString();
                y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y);
            }
            Thread.Sleep(3000);

            number = number.ToLower();
            var startTime = DateTime.Now;
            foreach (char num in number)
            {
                if (number.Contains("m1") || number.Contains("m2"))
                {
                    break;
                }
                else if (num < '0' || num > '9')
                {
                    Assert.Fail("Please input number pad 0-9.");
                }
                VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num.ToString()], 0, _KEYDOWN, 0);
                VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num.ToString()], 0, _KEYUP, 0);
            }
            if (number.Contains("m1") || number.Contains("m2"))
            {
                string num;
                for (int i = 0; i < number.Length; i += 2)
                {
                    num = number[i].ToString() + number[i + 1].ToString();
                    if (num == "m1" || num == "m2")
                    {
                        VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num], 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(VantageConstContent.KeyboardKeyMap[num], 0, _KEYUP, 0);
                    }
                    else
                    {
                        Assert.Fail("Please input M1, M2.");
                    }
                }
            }

            var endTime = DateTime.Now;
            string text = string.Empty;
            int timeOut = 0;
            ValuePattern textPattern;

            while (true)
            {
                if (systemVersion.Contains("19041"))
                {
                    windowsSearch = VantageCommonHelper.FindElementByIdIsEnabled(VantageConstContent.FileSearchTextBox);
                    textPattern = windowsSearch.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    text = textPattern.Current.Value;
                }
                else
                {
                    windowsSearch = uIAutomationControl.FindElementsByClass(VantageConstContent.FileExplorer, VantageConstContent.ClassRichEditBox)[0];
                    textPattern = windowsSearch.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                    text = textPattern.Current.Value;
                }
                if (text.Contains(lastKey))
                {
                    endTime = DateTime.Now;
                    break;
                }
                if (timeOut > 20)
                {
                    Assert.Fail("Failed to find the last input key: " + lastKey);
                }
                timeOut += 1;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }

            var costTime = (endTime - startTime).TotalSeconds;

            _iMCService = new IntelligentCoolingBaseHelper();
            _iMCService.IntelligentCoolinggIMCServiceControl(3);
            _iMCService.IntelligentCoolinggIMCServiceControl(2);

            if (delayStatus.Trim().ToLower() == "keep delay")
            {
                Assert.AreEqual(keys, text, "The output key should be equal to expected key.");
                Assert.IsTrue(costTime < seconds, "Select keep delay, the expected keys: " + keys + " is failed to output in " + seconds + " seconds. It cost " + costTime.ToString() + "seconds.");
            }
            else if (delayStatus.Trim().ToLower() == "ignore delay")
            {
                Assert.AreEqual(keys, text, "The output key should be equal to expected key.");
                Assert.IsTrue(costTime < seconds, "Select ignore delay, the expected keys: " + keys + " is failed to output in " + seconds + " seconds. It cost " + costTime.ToString() + "seconds.");
            }
            else
            {
                Assert.Fail("Please input Keep Delay or Ignore Delay");
            }
        }

        [Then(@"Press the number ""(.*)""")]
        public void ThenPressTheNumber(string number)
        {
            Thread.Sleep(3000);
            foreach (char num in number.ToString())
            {
                if (number.ToLower().Contains("m1") || number.ToLower().Contains("m2"))
                {
                    break;
                }
                switch (num.ToString())
                {
                    case "0":
                        VantageCommonHelper.keybd_event(Keys.NumPad0, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad0, 0, _KEYUP, 0);
                        break;
                    case "1":
                        VantageCommonHelper.keybd_event(Keys.NumPad1, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad1, 0, _KEYUP, 0);
                        break;
                    case "2":
                        VantageCommonHelper.keybd_event(Keys.NumPad2, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad2, 0, _KEYUP, 0);
                        break;
                    case "3":
                        VantageCommonHelper.keybd_event(Keys.NumPad3, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad3, 0, _KEYUP, 0);
                        break;
                    case "4":
                        VantageCommonHelper.keybd_event(Keys.NumPad4, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad4, 0, _KEYUP, 0);
                        break;
                    case "5":
                        VantageCommonHelper.keybd_event(Keys.NumPad5, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad5, 0, _KEYUP, 0);
                        break;
                    case "6":
                        VantageCommonHelper.keybd_event(Keys.NumPad6, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad6, 0, _KEYUP, 0);
                        break;
                    case "7":
                        VantageCommonHelper.keybd_event(Keys.NumPad7, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad7, 0, _KEYUP, 0);
                        break;
                    case "8":
                        VantageCommonHelper.keybd_event(Keys.NumPad8, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad8, 0, _KEYUP, 0);
                        break;
                    case "9":
                        VantageCommonHelper.keybd_event(Keys.NumPad9, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.NumPad9, 0, _KEYUP, 0);
                        break;
                    default:
                        Assert.Fail("Please input number pad 0-9.");
                        break;
                }
                Thread.Sleep(5 * 1000);
            }
            if (number.ToLower().Contains("m1") || number.ToLower().Contains("m2"))
            {
                string num;
                for (int i = 0; i < number.Length; i += 2)
                {
                    num = number[i].ToString() + number[i + 1].ToString();
                    if (num.ToLower() == "m1")
                    {
                        VantageCommonHelper.keybd_event(Keys.F14, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.F14, 0, _KEYUP, 0);
                    }
                    else if (num.ToLower() == "m2")
                    {
                        VantageCommonHelper.keybd_event(Keys.F15, 0, _KEYDOWN, 0);
                        VantageCommonHelper.keybd_event(Keys.F15, 0, _KEYUP, 0);
                    }
                    else
                    {
                        Assert.Fail("Please input M1, M2.");
                    }
                    Thread.Sleep(5 * 1000);
                }
            }
            Thread.Sleep(10 * 1000);
        }

        [Then(@"The Vantage window will be closed")]
        public void ThenTheVantageWindowWillBeClosed()
        {
            Assert.AreNotEqual(VantageConstContent.VantageProcessName, "LenovoVantage");
        }

    }
}
