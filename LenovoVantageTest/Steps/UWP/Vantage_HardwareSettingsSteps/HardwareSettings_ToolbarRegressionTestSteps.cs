using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using Windows.UI.Notifications;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class ToolbarRegressionTestSteps : SettingsBase
    {
        private SecurityPage _securityPage;
        private HSAudioSettingsPage _hSAudioSettingsPage;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private DashBoardPage _dashBoardPage;
        private MyDeviceSettingObject _myDeviceSettingObject;
        private InformationalWebDriver _webDriver;
        private InformationalWebDriver desktopSession;
        private ToggleState _toolbarStatus = ToggleState.Indeterminate;
        private SupportPage _supportPage;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HSToolbarPage _hsToolbarPage;
        private HSInputPage _hsInputPage;
        private NerveCenterPages _nerveCenterPages;
        private HSDispalyCameraPage _hSDisplayCameraPage;
        private HSSmartAssistPage _hSSmartAssist;
        private VantageUI vantageUI = new VantageUI();
        private BaseTestClass baseTestClass = new BaseTestClass();
        private object _typeF4ValueInit;
        private string toolType = null;
        ToggleState toolBtnState = ToggleState.Indeterminate;
        private string backlightValue = null;
        static string MachineInformationPath = @"C:\ProgramData\Lenovo\ImController\shared\MachineInformation.xml";
        static private string _regUserDefinedKey = @"SYSTEM\CurrentControlSet\Services\IBMPMSVC\Parameters\Notification";

        public ToolbarRegressionTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Turn (.*) permission")]
        public void GivenTurnOnPermission(string p0)
        {
            SettingsBase.SetLocationService(p0);
            //Assert.IsTrue(result);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"Pin toolbar to taskbar")]
        public void GivenPinToolbarToTaskbar()
        {
            SettingsBase.PinToolbar();
        }

        [Given(@"Pin DT toolbar to taskbar")]
        public void GivenPinDTToolbarToTaskbar()
        {
            SettingsBase.PinDTToolbar();
        }

        [StepDefinition(@"Launch toolbar")]
        [StepDefinition(@"Click toolbar")]
        [StepDefinition(@"launch toolbar")]
        [StepDefinition(@"Launch toolbar do not wait")]
        public void WhenLaunchToolbar()
        {
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) < 22000)
            {
                HSAudioSettingsPage _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
                WindowsDriver<WindowsElement> _appsion = _hsAudioSettingsPage.GetControlPanelSession(true);
                WindowsElement automationElement = FindElementByTimes(_appsion, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.GoToVantage).ToString(), 1, 1);
                if (automationElement != null)
                {
                    LogHelper.Logger.Instance.WriteLog("Vantage Toolbar has been opened");
                }
                else
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
                }
                if (ScenarioStepContext.Current.StepInfo.Text.Contains("Launch toolbar do not wait") == false)
                {
                    Thread.Sleep(TimeSpan.FromSeconds(6));
                }
            }
            else
            {
                VantageHardwareSettingsITSontoolbarfunctiontestStep op = new VantageHardwareSettingsITSontoolbarfunctiontestStep(_webDriver);
                op.GivenLaunchToolbarOnNewOS();
            }

        }

        [Given(@"Multiple launch and close Toolbar")]
        public void GivenMultiplePinAndUnpinToolbar()
        {
            for (int i = 0; i < 10; i++)
            {
                AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.GoToVantage).ToString(), 2);
                if (automationElement != null)
                {
                    LogHelper.Logger.Instance.WriteLog("Vantage Toolbar has been opened");
                }
                else
                {
                    if (VantageCommonHelper.CurrentMachineThanVersion(21300))
                    {
                        var _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
                        var _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
                        WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", "Lenovo Vantage Toolbar", 10);
                        toolbarElement?.Click();
                    }
                    else
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
                    }
                }
                WhenCloseToolbar();
            }
        }
        [Then(@"The Toolbar do not throw exceptions")]
        public void ThenTheToolbarDoNotThrowExceptions()
        {
            Assert.AreEqual("Toolbar has no throw exceptions in eventlog", DesktopPowerManagementHelper.GetToolbarEventErrorLog(), "The Toolbar throw exceptions");
        }

        [When(@"Launch DT toolbar")]
        public void WhenLaunchDTToolbar()
        {
            AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.GoToVantage).ToString(), 2);
            if (automationElement != null)
            {
                LogHelper.Logger.Instance.WriteLog("Vantage Toolbar has been opened");
            }
            else
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.DTToolBar).ToString());
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }


        [Then(@"The Microphone button on dashboard display off status")]
        public void ThenTheMicrophoneButtonOnDashboardDisplayOffStatus()
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            Assert.IsTrue(_dashBoardPage.microphoneSetOff.Displayed);
        }

        [Then(@"The Microphone button on dashboard display '(.*)' status")]
        public void ThenTheMicrophoneButtonOnDashboardDisplayStatus(string p0)
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            if (p0.ToLower().Equals("on"))
            {
                Assert.IsTrue(_dashBoardPage.microphoneSetOn.Displayed);
            }
            else
            {
                Assert.IsTrue(_dashBoardPage.microphoneSetOff.Displayed);
            }
        }


        [StepDefinition(@"Turn Airplane power mode (.*) in Vantage")]
        public void TurnAirplanePowerModeİnVantage(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            if (_myDeviceSettingObject.airplaneModetoggle.GetAttribute("Toggle.ToggleState") != re)
                _myDeviceSettingObject.airplaneModetoggle.Click();
            Assert.IsTrue(_myDeviceSettingObject.airplaneModetoggle.GetAttribute("Toggle.ToggleState") == re);
        }

        [Given(@"Machine support WIFISecurity")]
        public void GivenMachineSupportWIFISecurity()
        {
            RegistryHelp.CreateRegistry(NarratorRegistry);
        }


        [When(@"Hover the mouse on the keyboard backlight button")]
        public void WhenHoverTheMouseOnTheKeyboardBacklightButton()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
        }

        [When(@"Hover the mouse on the Conservation mode button")]
        public void WhenHoverTheMouseOnTheConservationModeButton()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
        }

        [When(@"Hover the mouse on the Battery charge threshold button")]
        public void WhenHoverTheMouseOnTheBatteryChargeThresholdButton()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
        }

        [When(@"Hover the mouse on the Airplane power mode button")]
        public void WhenHoverTheMouseOnTheAirplanePowerModeButton()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
        }

        [When(@"Hover the mouse on the Rapid charge button")]
        public void WhenHoverTheMouseOnTheRapidChargeButton()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
        }

        [When(@"Turn on wifi security from toolbar")]
        public void WhenTurnOnWifiSecurityFromToolbar()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()), ToggleState.On);
        }

        [When(@"Turn on the Keyboard backlight")]
        public void WhenTurnOnTheKeyboardBacklight()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()), ToggleState.On);
        }

        [Given(@"Turn (.*) privacy guard from toolbar")]
        public void GivenTurnOnPrivacyGuardFromToolbar(string status)
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.Off)
            {
                if (status.ToLower().Equals("on"))
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                }
                else
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                    Thread.Sleep(3000);
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                }

            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.On)
            {
                if (status.ToLower().Equals("on"))
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                    Thread.Sleep(3000);
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                }
                else
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                }
            }
        }

        [Then(@"The Privacy guard button displays (.*) status from toolbar")]
        public void ThenThePrivacyGuardButtonDisplaysOnStatusFromToolbar(string status)
        {
            if (status.ToLower() == "on")
                Assert.IsTrue(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.On);
            else
                Assert.IsTrue(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString()) == ToggleState.Off);
        }

        [StepDefinition(@"Select (.*) of keyboard backlight on toolbar")]
        public void SelectKeyboardBacklightOnToolbar(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
            int i = 4;
            switch (status.ToLower())
            {
                case "off":
                    while (_toolbarBacklight.IndexOf("off", StringComparison.OrdinalIgnoreCase) < 0 && i > 0)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                        _hSPowerSettingsPage.AddScreenshotIntoReport("SelectOff", "27994", "ToolbarScreenShotResult");
                        i--;
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
                    }
                    break;
                case "low":
                    while (_toolbarBacklight.IndexOf("low", StringComparison.OrdinalIgnoreCase) < 0 && i > 0)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                        _hSPowerSettingsPage.AddScreenshotIntoReport("SelectLow", "10210", "ToolbarScreenShotResult");
                        i--;
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
                    }
                    break;
                case "high":
                    while (_toolbarBacklight.IndexOf("high", StringComparison.OrdinalIgnoreCase) < 0 && i > 0)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                        _hSPowerSettingsPage.AddScreenshotIntoReport("SelectHigh", "27994", "ToolbarScreenShotResult");
                        i--;
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
                    }
                    break;
                case "auto":
                    while (_toolbarBacklight.IndexOf("auto", StringComparison.OrdinalIgnoreCase) < 0 && i > 0)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                        _hSPowerSettingsPage.AddScreenshotIntoReport("SelectAuto", "10210", "ToolbarScreenShotResult");
                        i--;
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
                    }
                    break;
                default:
                    throw new Exception("keyboard backlight status out of range");
            }
            Assert.IsTrue(_toolbarBacklight.IndexOf(status, StringComparison.OrdinalIgnoreCase) >= 0, _toolbarBacklight + " " + status);
        }

        [When(@"Select (.*) of keyboard backlight on vantage input page")]
        public void WhenSelectHighOfKeyboardBacklightOnVantageİnputPage(string status)
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "low":
                    _hsInputPage.backlightLow.Click();
                    break;
                case "high":
                    _hsInputPage.backlightHigh.Click();
                    break;
                case "off":
                    _hsInputPage.backlightOff.Click();
                    break;
                case "auto":
                    _hsInputPage.backlightAuto.Click();
                    break;
                default:
                    throw new Exception("keyboard backlight status out of range");
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        [Then(@"The Keyboard backlight button display (.*) status from toolbar")]
        public void ThenTheKeyboardBacklightButtonDisplayLowStatus(string status)
        {
            int timeout = 0;
            var backlightBtn = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            while (true)
            {
                if (backlightBtn.Current.Name.IndexOf(status, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    break;
                }
                else if (timeout >= 30)
                {
                    Assert.Fail("The " + backlightBtn.Current.Name + " button fail to display " + status + " status from toolbar in 30 seconds, should be a bug.");
                }
                timeout++;
                Thread.Sleep(TimeSpan.FromSeconds(1));
                backlightBtn = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            }
            Assert.IsTrue(backlightBtn.Current.Name.IndexOf(status, StringComparison.OrdinalIgnoreCase) >= 0, "backlightBtn Name" + backlightBtn.Current.Name + "\n expect status:" + status);
        }

        [Then(@"The Keyboard backlight button display (.*) status on vantage input page")]
        public void ThenTheKeyboardBacklightButtonDisplayLowStatusOnVantageİnputPage(string status)
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "low":
                    Assert.IsTrue(_hsInputPage.backlightLow.Enabled, "backlightLow display");
                    break;
                case "high":
                    Assert.IsTrue(_hsInputPage.backlightHigh.Enabled, "backlightHigh display");
                    break;
                case "off":
                    Assert.IsTrue(_hsInputPage.backlightOff.Enabled, "backlightOff display");
                    break;
                case "auto":
                    Assert.IsTrue(_hsInputPage.backlightAuto.Enabled, "backlightAuto display");
                    break;
                default:
                    throw new Exception("keyboard backlight status out of range");
            }
        }

        [Then(@"Check The Keyboard backlight button displays same as with Vantage")]
        public void ThenCheckTheKeyboardBacklightButtonDisplaysSameAsWithVantage()
        {
            String status = "";
            WhenLaunchToolbar();
            var _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
            switch (_toolbarBacklight)
            {
                case "Keyboard backlight low.":
                    status = "low";
                    break;
                case "Keyboard backlight high.":
                    status = "high";
                    break;
                case "Keyboard backlight off.":
                    status = "off";
                    break;
                case "Keyboard backlight auto.":
                    status = "auto";
                    break;
            }
            WhenCloseToolbar();
            _hsInputPage = new HSInputPage(_webDriver.Session);
            _hsInputPage.GotoInputPage();
            ThenTheKeyboardBacklightButtonDisplayLowStatusOnVantageİnputPage(status);
        }

        [Then(@"Check The Keyboard backlight button displays same as with Vantage On NewOS")]
        public void ThenCheckTheKeyboardBacklightButtonDisplaysSameAsWithVantageOnNewOS()
        {
            String status = "";
            //lunch toolbar on NewOS
            var _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            var closeToolbar = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString(), 1, 2);
            if (closeToolbar == null)
            {
                WindowsElement toolbarElement = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "Name", "Lenovo Vantage Toolbar", 10);
                toolbarElement?.Click();
                Thread.Sleep(3000);
            }
            var _toolbarBacklight = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()).Current.Name;
            switch (_toolbarBacklight)
            {
                case "Keyboard backlight low.":
                    status = "low";
                    break;
                case "Keyboard backlight high.":
                    status = "high";
                    break;
                case "Keyboard backlight off.":
                    status = "off";
                    break;
                case "Keyboard backlight auto.":
                    status = "auto";
                    break;
            }
            GivenCloseToolbarBackground();
            _hsInputPage = new HSInputPage(_webDriver.Session);
            _hsInputPage.GotoInputPage();
            ThenTheKeyboardBacklightButtonDisplayLowStatusOnVantageİnputPage(status);
        }

        [When(@"Turn on the Conservation mode")]
        public void WhenTurnOnTheConservationMode()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()), ToggleState.On);
        }

        [When(@"Turn on the Battery charge threshold")]
        public void WhenTurnOnTheBatteryChargeThreshold()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()), ToggleState.On);
        }

        [When(@"Turn on the Airplane power mode")]
        public void WhenTurnOnTheAirplanePowerMode()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.On);
        }

        [When(@"Turn off the Airplane power mode")]
        public void WhenTurnOffTheAirplanePowerMode()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.Off);
        }

        [Then(@"the Airplane power mode status is '(.*)' within Toolbar")]
        public void ThenTheAirplanePowerModeStatusIsWithinToolbar(string status)
        {
            switch (status.ToLower())
            {
                case "on":
                    Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.On, "the Airplane power mode status is incorrect within toolbar," + status);
                    break;
                case "off":
                    Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.Off, "the Airplane power mode status is incorrect within toolbar," + status);
                    break;
                default:
                    Assert.Fail("ThenTheAirplanePowerModeStatusIsWithinToolbar() parameter incorrect,info:" + status);
                    break;
            }
        }


        [When(@"Turn off the Battery charge threshold")]
        public void WhenTurnOffTheBatteryChargeThreshold()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()), ToggleState.Off);
        }

        [When(@"Turn on the Rapid charge")]
        public void WhenTurnOnTheRapidCharge()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()), ToggleState.On);
        }

        [When(@"Turn off the Rapid charge")]
        public void WhenTurnOffTheRapidCharge()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()), ToggleState.Off);
        }

        [When(@"Turn off the Conservation mode")]
        public void WhenTurnOffTheConservationMode()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            }
            else if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()), ToggleState.Off);
        }

        [When(@"Turn off the Conservation mode and Battery charge threshold")]
        public void WhenTurnOffTheConservationModeAndBatteryChargeThreshold()
        {
            if (VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()) != null)
            {
                WhenTurnOffTheConservationMode();
            }

            if (VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()) != null)
            {
                WhenTurnOffTheBatteryChargeThreshold();
            }
        }


        [Then(@"The Wi-fi security button displays same as with Vantage")]
        public void ThenTheWi_FiSecurityButtonDisplaysSameAsWithVantage()
        {
            _securityPage = new SecurityPage(_webDriver.Session);
            Assert.NotNull(_securityPage.WifiSecurityCheckbox);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_securityPage.WifiSecurityCheckbox), _toolbarStatus);
        }
        [Then(@"The Wi-fi security button displays on with Vantage")]
        public void ThenTheWi_FiSecurityButtonDisplaysOnWithVantage()
        {
            _securityPage = new SecurityPage(_webDriver.Session);
            Assert.NotNull(_securityPage.WifiSecurityCheckbox);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_securityPage.WifiSecurityCheckbox), ToggleState.On);
        }
        [Then(@"The wifi security display on status")]
        public void ThenTheWifiSecurityDisplayOnStatus()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()), ToggleState.On);
        }

        [Then(@"The keyboard backlight button display on statue")]
        public void ThenTheKeyboardBacklightButtonDisplayOnStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()), ToggleState.On);
        }

        [Then(@"The Conservation mode button display on statue")]
        public void ThenTheConservationModeButtonDisplayOnStatue()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            Assert.AreEqual(_toolbarStatus, ToggleState.On);
        }

        [Then(@"The Battery charge threshold button display on statue")]
        public void ThenTheBatteryChargeThresholdButtonDisplayOnStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()), ToggleState.On);
        }

        [Then(@"The Airplane power mode button display on statue")]
        public void ThenTheAirplanePowerModeButtonDisplayOnStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.On);
        }

        [Then(@"The Rapid charge button display on statue")]
        public void ThenTheRapidChargeButtonDisplayOnStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()), ToggleState.On);
        }

        [Then(@"The Conservation mode button display off statue")]
        public void ThenTheConservationModeButtonDisplayOffStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString()), ToggleState.Off);
        }

        [Then(@"The Battery charge threshold button display off statue")]
        public void ThenTheBatteryChargeThresholdButtonDisplayOffStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()), ToggleState.Off);
        }

        [Then(@"The Battery charge threshold button display on and grey out status")]
        public void ThenTheBatteryChargeThresholdButtonDisplayOnAndGreyOutStatus()
        {
            Assert.IsTrue(SettingsBase.GetGreyOutStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString()));
        }

        [Then(@"The Rapid charge button display off statue")]
        public void ThenTheRapidChargeButtonDisplayOffStatue()
        {
            Assert.AreEqual(ToggleState.Off, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString()));
        }

        [When(@"Turn off wifi security from toolbar")]
        public void WhenTurnOffWifiSecurityFromToolbar()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()), ToggleState.Off);
        }

        [When(@"Turn off the Keyboard backlight")]
        public void WhenTurnOffTheKeyboardBacklight()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            }
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                Thread.Sleep(3000);
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()), ToggleState.Off);
        }

        [When(@"Get wifi secirity status from toolbar")]
        public void WhenGetWifiSecirityStatusFromToolbar()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [StepDefinition(@"Close toolbar")]
        public void WhenCloseToolbar()
        {
            var closeToolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString());
            Assert.NotNull(closeToolbar, "ToolBarCloseBtn not found");
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString());
        }

        [Given(@"Close Toolbar Background")]
        public void GivenCloseToolbarBackground()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString());
        }

        [When(@"Get wifi security status from toolbar")]
        public void WhenGetWifiSecurityStatusFromToolbar()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [When(@"Turn on wifi security from vantage")]
        public void WhenTurnOnWifiSecurityFromVantage()
        {
            Thread.Sleep(3000);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hSPowerSettingsPage.WifiSecurityDialogAgreeButton != null)
            {
                _hSPowerSettingsPage.WifiSecurityDialogAgreeButton.Click();
            }
            else
            {
                Assert.NotNull(_hSPowerSettingsPage.WifiSecurityCheckbox);
                bool result = VantageCommonHelper.SwitchToggleStatus(_hSPowerSettingsPage.WifiSecurityCheckbox, ToggleState.On, false);
                Assert.IsTrue(result);
            }
        }

        [When(@"Turn off wifi security from vantage")]
        public void WhenTurnOffWifiSecurityFromVantage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.WifiSecurityCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hSPowerSettingsPage.WifiSecurityCheckbox, ToggleState.Off);
            //Assert.IsTrue(result);
        }

        [Given(@"turn off Keyboard backlight on input page")]
        public void GivenTurnOffKeyboardBacklightOnInputPage()
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInputPage.keyboardBacklightCheckBox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsInputPage.keyboardBacklightCheckBox, ToggleState.Off);
            Assert.IsTrue(result);
        }

        [Given(@"turn on Keyboard backlight on input page")]
        public void GivenTurnOnKeyboardBacklightOnInputPage()
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInputPage.keyboardBacklightCheckBox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hsInputPage.keyboardBacklightCheckBox, ToggleState.On);
            Assert.IsTrue(result);
        }

        [Given(@"turn on Conservation mode from power page")]
        public void GivenTurnOnConservationModeFromPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hSPowerSettingsPage.ConservationModeCheckbox, ToggleState.On);
            Assert.IsTrue(result);
        }

        [Given(@"turn off Conservation mode from power page")]
        public void GivenTurnOffConservationModeFromPowerPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSPowerSettingsPage.ConservationModeCheckbox);
            bool result = VantageCommonHelper.SwitchToggleStatus(_hSPowerSettingsPage.ConservationModeCheckbox, ToggleState.Off);
            Assert.IsTrue(result);
        }

        [Then(@"The wifi security display off status")]
        public void ThenTheWifiSecurityDisplayOffStatus()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString()), ToggleState.Off);
        }

        [Then(@"The keyboard backlight button display off statue")]
        public void ThenTheKeyboardBacklightButtonDisplayOffStatue()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()), ToggleState.Off);
        }

        [When(@"Click wifi security from toolbar")]
        public void WhenClickWifiSecurityFromToolbar()
        {
            var wifiSecurity = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            Assert.IsNotNull(wifiSecurity);
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [When(@"Click close in the security pop-up box")]
        public void WhenClickCloseInTheSecurityPop_UpBox()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            if (_hSPowerSettingsPage.WifiSecurityDialogAgreeButton != null)
            {
                _hSPowerSettingsPage.WifiSecurityDialogAgreeButton.Click();
            }
        }

        [Then(@"Click wifi security jump to wifi security page")]
        public void ThenClickWifiSecurityJumpToWifiSecurityPage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            bool goToWIFIPage = _hSPowerSettingsPage.WifiSecuritySigninButton != null || _hSPowerSettingsPage.WifiSecurityTitle != null;
            Assert.IsTrue(goToWIFIPage);
        }

        [When(@"Click Agreee in the security pop-up box")]
        public void WhenClickAgreeeInTheSecurityPop_UpBox()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.WifiSecurityDialogAgreeButton);
            _hSPowerSettingsPage.WifiSecurityDialogAgreeButton.Click();
        }
        [Given(@"Clean toast history")]
        public void GivenCleanToastHistory()
        {
            ToastNotificationManager.History.Clear(VantageUwpAppid);
        }

        [When(@"Click the toast and turn on wifi security")]
        public void WhenClickTheToastAndTurnOnWifiSecurity()
        {
            Thread.Sleep(TimeSpan.FromSeconds(6));
            //FindAndClickNotificationCenter(20);
            WindowsDriver<WindowsElement> deskSession = GetControlPanelSession(true);
            WindowsElement toolBarElement = FindElementByTimes(deskSession, "Name", "Re-enable now");
            toolBarElement.Click();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"Uninstall the lenovo vatage")]
        [Given(@"Uninstall the Lenovo Vantage")]
        public void GivenUninstallTheLenovoVatage()
        {
            VantageCommonHelper.UninstallVantage();
        }

        [Then(@"Jump to store page")]
        public void ThenJumpToStorePage()
        {
            var popupWindow = VantageCommonHelper.FindElementByIdIsEnabled("HeadText");
            Assert.IsNotNull(popupWindow);
        }

        //Microphone toolbar
        [Given(@"Machine support microphone")]
        public void GivenMachineSupportMicrophone()
        {
            RegistryHelp.CreateRegistry(NarratorRegistry);
        }

        [Given(@"Turn (.*) microphone access")]
        public void GivenTurnOnMicrophoneAccess(string p0)
        {
            SettingsBase.SetLocationService(p0, "ms-settings:privacy-microphone", "Microphone");
            //Assert.IsTrue(result);
        }

        [Given(@"Turn (.*) microphone from dashboad")]
        public void GivenTurnOnMicrophoneFromDashboad(string status)
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            WindowsElement microphoneSetOn = _dashBoardPage.microphoneSetOn;
            WindowsElement microphoneSetOff = _dashBoardPage.microphoneSetOff;
            if (status.ToLower() == "on")
            {
                if (microphoneSetOff != null)
                {
                    _dashBoardPage.microphoneSetOff.Click();
                }
                else
                {
                    Assert.IsNotNull(microphoneSetOn);
                }
            }
            if (status.ToLower() == "off")
            {
                if (microphoneSetOn != null)
                {
                    _dashBoardPage.microphoneSetOn.Click();
                }
                else
                {
                    Assert.IsNotNull(microphoneSetOff);
                }
            }
        }

        [StepDefinition(@"Record (.*) status get from toolbar")]
        public void RecordStatusGetFromToolbar(string btn)
        {
            List<ToggleState> btnStatusList = new List<ToggleState>();
            btnStatusList.Clear();
            switch (btn.ToLower())
            {
                case "microphone":
                    _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    break;
                case "top-row function":
                    _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
                    break;
                case "privacy guard":
                    _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                    break;
                default:
                    throw new Exception("out of range");
            }
            Console.WriteLine("_toolbarStatus:" + _toolbarStatus);
            btnStatusList.Add(_toolbarStatus);
            ScenarioContext.Current.Set(btnStatusList, "_toolbarStatus");
        }

        [Then(@"The Privacy guard button displays same as with Vantage")]
        public void ThenThePrivacyGuardButtonDisplaysSameAsWithVantage()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
            _hSDisplayCameraPage = new HSDispalyCameraPage(_webDriver.Session);
            _hSDisplayCameraPage.GotoMySettingsDisplayCameraPage();
            Assert.NotNull(_hSDisplayCameraPage.privacyGaugeToggle, "The privacyGaugeToggle not found");
            Assert.AreEqual(_toolbarStatus, GetCheckBoxStatus(_hSDisplayCameraPage.privacyGaugeToggle), "Privacy guard button displays not same as with Vantage");
        }

        [StepDefinition(@"The (.*) button status displayed same as Before")]
        public void TheButtonStatusDisplayedSameAsBefore(string btn)
        {
            switch (btn.ToLower())
            {
                case "microphone":
                    _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    break;
                case "top-row function":
                    _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
                    break;
                default:
                    throw new Exception("out of range");
            }
            Assert.AreEqual(ScenarioContext.Current.Get<List<ToggleState>>("_toolbarStatus")[0], _toolbarStatus);

        }

        [StepDefinition(@"Click (.*) button on toolbar")]
        public void ClickButtonOnToolbar(string btn)
        {
            switch (btn.ToLower())
            {
                case "microphone":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    break;
                case "camera":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    break;
                case "batterydetails":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString());
                    break;
                default:
                    throw new Exception("out of range");
            }
        }

        [Given(@"Click the ""(.*)"" button on toolbar and save states")]
        public void GivenClickTheButtonOnToolbarAndSaveStates(string p0)
        {
            ToolBarAutoEnum toolBtn = ToolBarAutoEnum.Nothing;
            if (p0 == "backlight")
            {
                toolType = "Features.Toolbar.QuickSettings.KeyboardBacklight";
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                string backlightValues = GetManyStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                if (backlightValues == "high")
                {
                    backlightValue = "Level_2";
                }
                else if (backlightValues == "low")
                {
                    backlightValue = "Level_1";
                }
                else if (backlightValues == "off")
                {
                    backlightValue = "Off";
                }
                else
                {
                    backlightValue = "Auto";
                }
            }
            else
            {

                _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                switch (p0.ToLower())
                {
                    case "microphone":
                        toolBtn = ToolBarAutoEnum.Microphone;
                        toolType = "Features.Toolbar.QuickSettings.Micphone";
                        break;
                    case "camera":
                        toolBtn = ToolBarAutoEnum.Camera;
                        toolType = "Features.Toolbar.QuickSettings.Camera";
                        break;
                    case "airplane":
                        //如果是ideapad 就检查conservationmode按钮
                        if (_hSPowerSettingsPage.IsIdeaPad())
                        {
                            toolBtn = ToolBarAutoEnum.ConservationMode;
                            toolType = "Features.Toolbar.QuickSettings.ConservationMode";
                        }
                        else
                        {
                            toolBtn = ToolBarAutoEnum.AirplanePowerMode;
                            toolType = "Features.Toolbar.QuickSettings.AirplanePowerMode";
                        }
                        break;
                    case "wifi":
                        toolBtn = ToolBarAutoEnum.WIFISecurity;
                        toolType = "Features.Toolbar.QuickSettings.WiFiSecurityEnable";
                        break;
                    case "batterychargethreshold":
                        //如果是ideapad 就检查RapidCharge按钮
                        if (_hSPowerSettingsPage.IsIdeaPad())
                        {
                            toolBtn = ToolBarAutoEnum.RapidCharge;
                            toolType = "Features.Toolbar.QuickSettings.RapidCharge";
                        }
                        else
                        {
                            toolBtn = ToolBarAutoEnum.BatteryChargeThreshold;
                            toolType = "Features.Toolbar.QuickSettings.BatteryChargeThreshold";
                        }
                        break;
                }
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(toolBtn).ToString());
                toolBtnState = GetFeatureStatusFromToolbar(Convert.ToInt32(toolBtn).ToString());
            }
        }

        [Then(@"HeartBeat Has Send ""(.*)"" value")]
        public void ThenHeartBeatHasSendValue(string p0)
        {
            string sendValue = "Off";
            List<string> eventRecordContext = new List<string>();
            using (var reader = new EventLogReader(@"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx", PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains(toolType))
                        {
                            eventRecordContext.Add(record.FormatDescription());
                        }
                    }
                }
                foreach (string eventLog in eventRecordContext)
                {
                    string str = eventLog;
                    if (p0 == "backlight")
                    {
                        if (!(str.Contains(backlightValue) && str.Contains(toolType)))
                        {
                            Assert.Fail("The toolbar send value is not true");
                        }
                    }
                    else
                    {
                        if (toolBtnState == ToggleState.On)
                        {
                            sendValue = "On";
                        }
                        if (!(str.Contains(sendValue) && str.Contains(toolType)))
                        {
                            Assert.Fail("The toolbar send value is not true");
                        }
                    }
                }
            }
        }

        [When(@"Get microphone status from toolbar")]
        public void WhenGetMicrophoneStatusFromToolbar()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [Then(@"The microphone button displays same as with Vantage")]
        public void WhenTheMicrophoneButtonDisplaysSameAsWithVantage()
        {
            _hSAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hSAudioSettingsPage.MicrophoenCheckbox);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hSAudioSettingsPage.MicrophoenCheckbox), _toolbarStatus);
        }

        [StepDefinition(@"Hover the mouse on the button (.*)")]
        public void HoverTheMouseOnTheButton(string btn)
        {
            switch (btn.ToLower())
            {
                case "microphone":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    break;
                case "camera":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    break;
                case "toprowkey":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
                    break;
                case "wifisecurity":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
                    break;
                case "privacy guard":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.PrivacyGuard).ToString());
                    break;
                case "ecourse":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString());
                    break;
                case "airplane power mode":
                    VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                    break;
                default:
                    throw new Exception("out of range");
            }
        }

        [When(@"Turn off microphone from toolbar")]
        public void WhenTurnOffMicrophoneFromToolbar()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()) == ToggleState.On)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
            }
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()), ToggleState.Off);
        }

        [When(@"Get microphone '(.*)' state from toolbar")]
        public void WhenGetMicrophoneStateFromToolbar(string p0)
        {
            string currentState = "on";
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()) == ToggleState.Off)
            {
                currentState = "off";
            }
            Assert.AreEqual(p0, currentState);
        }

        [When(@"Turn on microphone from toolbar")]
        public void WhenTurnOnMicrophoneFromToolbar()
        {
            if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()) == ToggleState.Off)
            {
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
            }
            Assert.AreEqual(ToggleState.On, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
        }

        [StepDefinition(@"(.*) the Microphone driver")]
        public void WhenDisableTheMicrophoneDriver(string action)
        {
            int i = 3;
            System.Diagnostics.Process.Start("ms-settings:sound");
            while (!Common.GetRunningProcess("SystemSettings") && i > 0)
            {
                System.Diagnostics.Process.Start("ms-settings:sound");
                i--;
            }
            Thread.Sleep(TimeSpan.FromSeconds(2));

            desktopSession = baseTestClass.DesktopSession();
            desktopSession.Session.FindElementByAccessibilityId("SystemSettings_Audio_ManageInputLink_HyperlinkButton").Click();

            Thread.Sleep(TimeSpan.FromSeconds(2));
            vantageUI.SimulateMouseClickGUIElement(string.Format("/Window[@Name='Settings']//*[@Name='Microphone Array']"), 8);

            Thread.Sleep(TimeSpan.FromSeconds(2));
            string disableBtnxpath = string.Format("/Window[@Name='Settings']//*[@AutomationId='SystemSettings_Audio_DisableDevice_Button_Button']");
            string enableBtnxpath = string.Format("/Window[@Name='Settings']//*[@AutomationId='SystemSettings_Audio_EnableDevice_Button_Button']");
            if (action.ToLower() == "disable")
            {
                if (vantageUI.ElementExistUsingCustomXPath(disableBtnxpath))
                    vantageUI.ClickElementUsingCustomXPath(disableBtnxpath);
            }
            else
            {
                if (vantageUI.ElementExistUsingCustomXPath(enableBtnxpath))
                    vantageUI.ClickElementUsingCustomXPath(enableBtnxpath);
            }
            Common.KillProcess("SystemSettings", true);
        }

        [StepDefinition(@"Turn (.*) airplane power mode from toolbar")]
        public void GivenTurnOnAirplanePowerModeFromToolbar(string status)
        {
            if (status.ToLower() == "on")
            {
                if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.Off)
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                }
                Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.On);
            }
            else
            {
                if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()) == ToggleState.On)
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                }
                Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString()), ToggleState.Off);
            }
        }

        [Then(@"The microhone button doesn't display on toolbar")]
        public void ThenTheMicrohoneButtonNoDisplayOnToolbar()
        {
            var toolbarMicrohoneBtn = vantageUI.ElementExistUsingCustomXPath(string.Format("/Dialog[@Name='Lenovo Vantage Toolbar. ']//*[@AutomationId='{0}']", Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
            Assert.IsFalse(toolbarMicrohoneBtn);
        }

        [Then(@"The camera button doesn't display on toolbar")]
        public void ThenTheCameraButtonDoesnTDisplayOnToolbar()
        {
            var toolbarMicrohoneBtn = vantageUI.ElementExistUsingCustomXPath(string.Format("/Dialog[@Name='Lenovo Vantage Toolbar. ']//*[@AutomationId='{0}']", Convert.ToInt32(ToolBarAutoEnum.Camera).ToString()));
            Assert.IsFalse(toolbarMicrohoneBtn);
        }

        [Then(@"The (.*) button display on toolbar")]
        public void TheButtonDisplayOnToolbar(string btn)
        {
            switch (btn.ToLower())
            {
                case "microhone":
                    Assert.IsNotNull(VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
                    break;
                case "camera":
                    Assert.IsNotNull(VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString()));
                    break;
                default:
                    throw new Exception("out of range");
            }

        }

        [Then(@"My Device settings Display page is opened")]
        public void ThenMyDeviceSettingsDisplayPageİsOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.MediaLevel2Tiltle);
            Assert.IsNotNull(_nerveCenterPages.MediaLevel2captionTiltle);
        }

        [Then(@"My Device settings Smart Assist page is opened")]
        public void ThenMyDeviceSettingsSmartAssistPageİsOpened()
        {
            SettingsBase seb = new SettingsBase(_webDriver.Session);
            Assert.IsNotNull(seb.SmartAssistitle);
            Assert.IsNotNull(seb.SmartAssiscaption);
        }

        [Then(@"The camera button display (.*) status from toolbar")]
        public void ThenTheCameraButtonDisplayOnStatusFromToolbar(string status)
        {
            if (status == "on")
            {
                Assert.IsTrue(new SettingsBase().GetCameraStatusFromToolbarUsingLonName() == ToggleState.On);
            }
            else
                Assert.IsTrue(new SettingsBase().GetCameraStatusFromToolbarUsingLonName() == ToggleState.Off);
        }

        [Then(@"The Camera privacy display (.*) status from vantage display page")]
        public void ThenTheCameraPrivacyDisplayOnStatusOnVantageDisplayPage(string status)
        {
            HSQuickSettingsPage hSQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);

            if (status == "on")
            {
                Assert.IsTrue(hSQuickSettingsPage.cameraPrivacyMode_Toggle.GetAttribute("Toggle.ToggleState") == "1");
            }
            else
                Assert.IsTrue(hSQuickSettingsPage.cameraPrivacyMode_Toggle.GetAttribute("Toggle.ToggleState") == "0");
        }

        [Then(@"The Camera privacy mode button on displays same as with Vantage Settings Page")]
        public void ThenTheCameraPrivacyModeButtonOnDisplaysSameAsWithVantageSettingsPage()
        {
            Assert.AreEqual(ToggleState.On, new SettingsBase().GetCameraStatusFromToolbarUsingLonName());
            HSQuickSettingsPage hSQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            hSQuickSettingsPage.GotoMySettingsDisplayCameraPage();
            Assert.IsTrue(hSQuickSettingsPage.cameraPrivacyMode_Toggle.GetAttribute("Toggle.ToggleState") == "1");

        }

        [Then(@"The microhone display off status")]
        public void ThenTheMicrohoneDisplayOffStatus()
        {
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()), ToggleState.Off);
        }

        [Then(@"The microphone button displays same as with Vantage dashboard")]
        public void ThenTheMicrophoneButtonDisplaysSameAsWithVantageDashboard()
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            Assert.NotNull(_dashBoardPage.microphoneSetOn);
            Assert.AreEqual(ToggleState.On, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
        }

        [Then(@"The microphone button off displays same as with Vantage dashboard")]
        public void ThenTheMicrophoneButtonOffDisplaysSameAsWithVantageDashboard()
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            Assert.NotNull(_dashBoardPage.microphoneSetOff);
            Assert.AreEqual(ToggleState.Off, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
        }

        [Then(@"The microhone display on status")]
        public void ThenTheMicrohoneDisplayOnStatus()
        {
            Assert.AreEqual(ToggleState.On, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString()));
        }

        [Then(@"The Camera privacy display (.*) status on dashboard page")]
        public void ThenTheCameraPrivacyModeButtonOnDisplaysSameAsWithVantageDashboard(string status)
        {
            _dashBoardPage = new DashBoardPage(_webDriver.Session);
            if (status == "on")
                Assert.IsTrue(_dashBoardPage.cameraSetOffIsPresent, "cameraSetOff should IsPresent");
            else
                Assert.IsTrue(_dashBoardPage.cameraSetOnIsPresent, "cameraSetOn should IsPresent");

        }

        [When(@"Turn on (.*) function from toolbar")]
        public void WhenTurnOnSpecialFunctionFromToolbar(string func)
        {
            Thread.Sleep(1000);
            string TopRowKeyName = GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
            if (func == "Special")
            {
                if (!(TopRowKeyName == "Special function enabled."))
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
                }
            }
            else
            {
                if (!(TopRowKeyName == "F1-F12 function enabled."))
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
                }
            }
        }

        [When(@"Turn on (.*) function on vantage input page")]
        public void WhenTurnOnSpecialFunctionOnVantageİnputPage(string func)
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatusSpecialKey = _hsInputPage.SpecialKeyRadio.GetAttribute("Toggle.ToggleState");
            var toggleStatusFunctionKey = _hsInputPage.FunctionKeyRadio.GetAttribute("Toggle.ToggleState");
            if (func == "Special")
            {
                if (toggleStatusSpecialKey != "1")
                    _hsInputPage.SpecialKeyRadio.Click();
            }

            else
            {
                if (toggleStatusFunctionKey != "1")
                    _hsInputPage.FunctionKeyRadio.Click();
            }
        }

        [When(@"Turn on (.*) function on vantage input page for ideapad")]
        public void WhenTurnOnSpecialFunctionOnVantageİnputPageForIdeapad(string func)
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatusSpecialKey = _hsInputPage.SpecialKeyRadioIdeapad.GetAttribute("Toggle.ToggleState");
            var toggleStatusFunctionKey = _hsInputPage.FunctionKeyRadioIdeapad.GetAttribute("Toggle.ToggleState");
            if (func == "Special")
            {
                if (toggleStatusSpecialKey != "1")
                    _hsInputPage.SpecialKeyRadioIdeapad.Click();
            }

            else
            {
                if (toggleStatusFunctionKey != "1")
                    _hsInputPage.FunctionKeyRadioIdeapad.Click();
            }
        }

        [Then(@"The Top-row function button display (.*) function status on toolbar")]
        public void ThenTheTop_RowFunctionButtonDisplaySpecialFunctionStatue(string func)
        {
            string topRowButtonName = GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString());
            if (func == "Special")
                Assert.AreEqual("Special function enabled.", topRowButtonName, "The toprowbutton in toolbar is not Special");
            else
                Assert.AreEqual("F1-F12 function enabled.", topRowButtonName, "The toprowbutton in toolbar is not F1-F12");
        }

        [Then(@"The Top-row function button display (.*) function status on vantage input page")]
        public void ThenTheTop_RowFunctionButtonDisplaySpecialFunctionStatueOnVantageİnputPage(string func)
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            if (func.ToLower() == "special")
            {
                Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_hsInputPage.SpecialKeyRadio), "SpecialKeyRadio should selected");
            }
            else
            {
                Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_hsInputPage.FunctionKeyRadio), "FunctionKeyRadio should selected");
            }
        }

        [Then(@"The Top-row function button is disabled")]
        public void ThenTheTop_RowFunctionButtonİsDisabled()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            Assert.AreEqual("Keyboard top-row function DISABLED.", GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString()));
        }

        //Liu Yang
        [Given(@"Install the Lenovo Vantage")]
        public void GivenInstallTheLenovoVantage()
        {
            VantageCommonHelper.InstallVantage();
            var session = VantageCommonHelper.LaunchSystemUwp(VantageUwpAppid);
            var windowsElement = VantageCommonHelper.FindElementByXPath(session, OoBeNextButton, 30);
            if (windowsElement != null)
            {
                windowsElement.Click();
                windowsElement = VantageCommonHelper.FindElementByXPath(session, OoBeNextButton, 1);
                windowsElement?.Click();
            }
            _webDriver = new InformationalWebDriver(session, session);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [Given(@"click OOBE")]
        [When(@"click OOBE")]
        public void GivenClickOOBE()
        {
            VantageCommonHelper.OObeNetVantage30(_webDriver.Session, true);
        }

        [Given(@"Open the My Device Settings and into Power page")]
        public void GivenOpenTheMyDeviceSettingsAndIntoPowerPage()
        {
            if (!NerveCenterHelper.GetMachineIsGaming())
            {
                _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                _hSPowerSettingsPage.GoToMyDevicesSettings();
            }
            else
            {
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "don't found DeviceMenu");
                _nerveCenterPages.GamingDeviceMenu.Click();
                Assert.IsNotNull(_nerveCenterPages.SystemToolsPower, "Powerbutton doesn't display");
                _nerveCenterPages.SystemToolsPower.Click();
            }

        }

        [Given(@"get machine type is idea or yoga")]
        public void GivenGetMachineTypeIsIdeaOrYoga()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsFalse(!currentMachineType.ToLower().Contains("idea") && !currentMachineType.ToLower().Contains("yoga") && !currentMachineType.ToLower().Contains("xiaoxin"));
        }

        [Given(@"turn (.*) Rapid charge from power page on Lenovo Vantgae")]
        public void GivenTurnRapidChargeFromPowerPageOnLenovoVantgae(string state)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox) == ToggleState.Off && state == "on")
            {
                _hSPowerSettingsPage.RapidChargeCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox) == ToggleState.On && state == "off")
            {
                _hSPowerSettingsPage.RapidChargeCheckBox.Click();
            }
        }

        [Given(@"turn (.*) Conservative mode from power page on Lenovo Vantage")]
        public void GivenTurnOnConservativeModeFromPowerPageOnLenovoVantage(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.ConservationCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox) == ToggleState.Off && status == "on")
            {
                _hSPowerSettingsPage.ConservationCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox) == ToggleState.On && status == "off")
            {
                _hSPowerSettingsPage.ConservationCheckBox.Click();
            }
        }

        [Given(@"plug in charging adapter")]
        public void GivenPlugInChargingAdapter()
        {
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn());
        }

        [Given(@"unselect the Enable the Lenovo Vantage toolbar checkbox")]
        public void GivenUnselectTheEnableTheLenovoVantageToolbarCheckbox()
        {
            //ObBeSegmentChoose
            WindowsElement windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.ObBeSegmentChoose, 5);
            windowsElement?.Click();
            windowsElement?.Click();

            _hsToolbarPage = new HSToolbarPage(_webDriver.Session);
            int i = 0;
            if (_hsToolbarPage.doneButton != null)
            {
                while (VantageCommonHelper.GetToggleStatus(_hsToolbarPage.vantageToolbarCheckBox) == ToggleState.On)
                {
                    if (i == 3)
                        break;
                    _hsToolbarPage.vantageToolbarCheckBox.Click();
                    i++;
                }
                _hsToolbarPage.doneButton.Click();
            }
            else if (_hsToolbarPage.nextButton != null)
            {
                _hsToolbarPage.nextButton.Click();
                while (VantageCommonHelper.GetToggleStatus(_hsToolbarPage.vantageToolbarCheckBox) == ToggleState.On)
                {
                    if (i == 3)
                        break;
                    _hsToolbarPage.vantageToolbarCheckBox.Click();
                    i++;
                }
                _hsToolbarPage.doneButton.Click();
            }
            try
            {
                VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [Given(@"Click Vantage Toolbar Link by jump to settings on Powerpage")]
        [Given(@"Jump to Other settings")]
        public void GivenJumpToOtherSettings()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToOtherSettings);
            _hSPowerSettingsPage.JumpToOtherSettings.Click();
        }

        [Given(@"Jump to Battery settings")]
        public void GivenJumpToBatterySettings()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToBatterySettings);
            _hSPowerSettingsPage.JumpToBatterySettings.Click();
        }

        [Given(@"Jump to Power settings")]
        public void GivenJumpToPowerSettings()
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.JumpToPowerSettings);
            _hSPowerSettingsPage.JumpToPowerSettings.Click();
        }

        [Given(@"enable battery gauge reset")]
        public void GivenEnableBatteryGaugeReset()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGuageResetPrimary);
            _hSPowerSettingsPage.BatteryGuageResetPrimary.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGuageResetContinue);
            _hSPowerSettingsPage.BatteryGuageResetContinue.Click();
        }

        [Given(@"stop battery gauge reset")]
        public void GivenStopBatteryGaugeReset()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGuageResetPrimary);
            _hSPowerSettingsPage.BatteryGuageResetPrimary.Click();
            Thread.Sleep(3000);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryGuageResetYes);
            _hSPowerSettingsPage.BatteryGuageResetYes.Click();
        }

        [When(@"pin toolbar on Taskbar settings")]
        public void WhenPinToolbarOnTaskbarSettings()
        {
            VantageCommonHelper.OpenToolBar();
        }

        [When(@"unpin toolbar on Taskbar settings")]
        public void WhenUnpinToolbarOnTaskbarSettings()
        {
            VantageCommonHelper.UnpinToolBar();
        }

        [When(@"Unpin Toolbar By Right_Click Toolbar Icon")]
        public void WhenUnpinToolbarByContext_ClickToolbarIcon()
        {
            desktopSession = baseTestClass.DesktopSession();
            var showhidden = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString(), 3, 1);
            var overflowarea = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Overflowarea).ToString());
            if (showhidden != null && overflowarea != null)
            {
                showhidden.Click();
            }
            var toolbar = FindElementByTimes(desktopSession.Session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NEWOSToolbar"), 3, 1);
            Assert.IsNotNull(toolbar, "Toolbar doesn't display");
            Actions action = new Actions(desktopSession.Session);
            action.ContextClick(toolbar).Build().Perform();
            var unpinconfirm = desktopSession.Session.FindElementByName("Unpin from taskbar");
            Assert.IsNotNull(unpinconfirm, "Toolbar doesn't be clicked");
            unpinconfirm.Click();

        }

        [StepDefinition(@"select the Enable the Lenovo Vantage toolbar checkbox")]
        public void WhenSelectTheEnableTheLenovoVantageToolbarCheckbox()
        {
            //ObBeSegmentChoose
            WindowsElement windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.ObBeSegmentChoose, 5);
            windowsElement?.Click();
            windowsElement?.Click();

            WindowsElement checkbox = null;
            _hsToolbarPage = new HSToolbarPage(_webDriver.Session);
            if (!NerveCenterHelper.GetMachineIsGaming())
            {
                checkbox = _hsToolbarPage.vantageToolbarCheckBox;
            }
            else
            {
                checkbox = _hsToolbarPage.vantageToolbarCheckBoxGaming;
            }

            if (_hsToolbarPage.doneButton != null)
            {

                if (VantageCommonHelper.GetToggleStatus(checkbox) == ToggleState.Off)
                {
                    _hsToolbarPage.vantageToolbarCheckBox.Click();
                }
                _hsToolbarPage.doneButton.Click();
            }
            else if (_hsToolbarPage.nextButton != null)
            {
                _hsToolbarPage.nextButton.Click();

                if (VantageCommonHelper.GetToggleStatus(checkbox) == ToggleState.Off)
                {
                    _hsToolbarPage.vantageToolbarCheckBox.Click();
                }
                _hsToolbarPage.doneButton.Click();
            }
            try
            {
                VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [When(@"Click the battery gauge x button")]
        public void WhenClickTheBatteryGaugeXButton()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString());
        }

        [Then(@"toolbar close button should (.*)")]
        public void ThenToolbarCloseButtonShow(string str)
        {
            Thread.Sleep(TimeSpan.FromSeconds(3));
            var toolbarCloseBtn = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString(), 2);
            if (str.ToLower() == "show")
                Assert.IsNotNull(toolbarCloseBtn);
            else
                Assert.IsNull(toolbarCloseBtn);
        }

        [StepDefinition(@"toolbar is launched")]
        public void ToolbarIsLaunched()
        {
            //var toolbarCloseBtn = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBarCloseBtn).ToString(), 2);
            if (!(new NLSStepDefinition(_webDriver).toolbarElementExistUsingLonName("MY BATTERY", true)))
                VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(VantageConstContent.ToolBarAutoEnum.ToolBar).ToString());
        }

        [StepDefinition(@"The title name according to the machine and vantage display")]
        public void TheTitleNameAccordingToTheMachineAndVantageDisplay()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement toolbarTitleEle = desktopSession.Session.FindElementByAccessibilityId("1000");
            string toolbarTitle = toolbarTitleEle.GetAttribute("Name");

            NerveCenterPages nerverCenterPages = new NerveCenterPages(_webDriver.Session);
            string vantageTitle = nerverCenterPages.machineFamilyNameText.Text;

            string machineName = Common.GetMachineInformationFromFile().Family;
            Console.WriteLine("toolbarTitle: " + toolbarTitle + "\nvantageTitle: " + vantageTitle + "\nmachineName: " + machineName);

            Assert.IsTrue((vantageTitle == machineName && toolbarTitle.Contains(machineName)), "vantageTitle: " + vantageTitle + "\nmachineName: " + machineName + "\ntoolbarTitle: " + toolbarTitle);
        }

        [Given(@"Nerver pin toolbar to taskbar")]
        public void GivenNerverPinToolbarToTaskbar()
        {
            if (RegistryHelp.IsRegistryKeyExist(@"HKCU\SOFTWARE\Lenovo\BatteryGaugeToast\DisplayTimes"))
                RegistryHelp.DeleteRegistryKeyValue(@"HKCU\SOFTWARE\Lenovo\BatteryGaugeToast\DisplayTimes");
            if (RegistryHelp.IsRegistryKeyExist(@"HKCU\SOFTWARE\Lenovo\BatteryGaugeToast\LastDisplayTime"))
                RegistryHelp.DeleteRegistryKeyValue(@"HKCU\SOFTWARE\Lenovo\BatteryGaugeToast\LastDisplayTime");
        }

        [When(@"the Machine access adapter")]
        public void WhenTheMachineAccessAdapter()
        {
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn());
        }

        [When(@"the Machine unconnected adapter")]
        public void WhenTheMachineUnconnectedAdapter()
        {
            Assert.IsFalse(VantageCommonHelper.JudgeInsertStatusIsOn());
        }

        [When(@"unplug in charging adapter")]
        public void WhenUnplugInChargingAdapter()
        {
            Assert.IsFalse(VantageCommonHelper.JudgeInsertStatusIsOn());
        }

        [When(@"turn (.*) Rapid charge from power page on Lenovo Vantgae")]
        public void WhenTurnRapidChargeFromPowerPageOnLenovoVantgae(string state)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.RapidChargeCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox) == ToggleState.Off && state == "on")
            {
                _hSPowerSettingsPage.RapidChargeCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox) == ToggleState.On && state == "off")
            {
                _hSPowerSettingsPage.RapidChargeCheckBox.Click();
            }
        }

        [When(@"turn (.*) Battery charge threshold from power page on Lenovo Vantage")]
        public void WhenTurnBatteryChargeThresholdFromPowerPageOnLenovoVantage(string state)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.BatteryChargeThresholdCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.BatteryChargeThresholdCheckBox) == ToggleState.Off && state == "on")
            {
                _hSPowerSettingsPage.BatteryChargeThresholdCheckBox.Click();
                Thread.Sleep(3000);
                _hSPowerSettingsPage.BatteryChargeThresholdEnable.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.BatteryChargeThresholdCheckBox) == ToggleState.On && state == "off")
            {
                _hSPowerSettingsPage.BatteryChargeThresholdCheckBox.Click();
            }
        }

        [When(@"turn (.*) Conservative mode")]
        public void WhenTurnConservativeMode(string status)
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.ConservationCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox) == ToggleState.Off && status == "on")
            {
                _hSPowerSettingsPage.ConservationCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox) == ToggleState.On && status == "off")
            {
                _hSPowerSettingsPage.ConservationCheckBox.Click();
            }
        }

        [When(@"Launch the Lenovo Vantage Toolbar")]
        public void WhenLaunchTheLenovoVantageToolbar()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.OtherSettingstoolBarCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.OtherSettingstoolBarCheckBox) == ToggleState.Off)
            {
                _hSPowerSettingsPage.OtherSettingstoolBarCheckBox.Click();
            }
        }

        [When(@"Close the Lenovo Vantage Toolbar")]
        public void WhenCloseTheLenovoVantageToolbar()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hSPowerSettingsPage.OtherSettingstoolBarCheckBox, "Settings Power page Toolbar section is null!!");
            if (VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.OtherSettingstoolBarCheckBox) == ToggleState.On)
            {
                _hSPowerSettingsPage.OtherSettingstoolBarCheckBox.Click();
            }
        }

        [When(@"the battery is more than (.*)%")]
        public void WhenTheBatteryIsMoreThan(int batteryPercent)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent < batteryPercent)
            {
                VantageCommonHelper.MoreThanPowerValue(27);
            }
            //CmdCommands.StartChargeBattery();
            //ConnectAdapterInsert();
        }

        [When(@"The battery is more than (.*)% via ACDC")]
        public void WhenTheBatteryIsMoreThanViaACDC(int batteryPercent)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent < batteryPercent)
            {
                Assert.IsTrue(VantageCommonHelper.SetBatteryPercent(batteryPercent, false), "set the battery is more than " + batteryPercent + "fail");
            }
        }

        [When(@"The battery is from (.*)% to (.*)% via ACDC")]
        public void WhenTheBatteryIsFromToViaACDC(int lowBatteryPercent, int highBatteryPercent)
        {
            WhenTheBatteryIsMoreThanViaACDC(lowBatteryPercent);
            WhenTheBatteryIsLowerThanViaACDC(highBatteryPercent);
        }

        [When(@"the battery is lower than (.*)% via ACDC")]
        public void WhenTheBatteryIsLowerThanViaACDC(int batteryPercent)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent > batteryPercent)
            {
                Assert.IsTrue(VantageCommonHelper.SetBatteryPercent(batteryPercent, true), "set the battery is lower than " + batteryPercent + "fail");
            }
        }

        [When(@"the battery is from (.*)% to (.*)%")]
        public void WhenTheBatteryIsFromTo(int lowBatteryPercent, int highBatteryPercent)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent < lowBatteryPercent)
            {
                VantageCommonHelper.MoreThanPowerValue(18);
            }
            else if (currentPercent > highBatteryPercent)
            {
                VantageCommonHelper.LowerThanBatteryValue(22);
            }
            //CmdCommands.StartChargeBattery();
        }

        [When(@"the battery is lower than (.*)%")]
        public void WhenTheBatteryIsLowerThan(int batteryPercent)
        {
            int currentPercent = VantageCommonHelper.GetCurrentBatteryPercent();
            if (currentPercent > batteryPercent)
            {
                VantageCommonHelper.LowerThanBatteryValue(12);
            }
            //ConnectAdapterInsert();
        }

        [When(@"check the Keyboard backlight display")]
        public void WhenCheckTheKeyboardBacklightDisplay()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [When(@"check the Conservation mode display")]
        public void WhenCheckTheConservationModeDisplay()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [When(@"check the Battery charge threshold display")]
        public void WhenCheckTheBatteryChargeThresholdDisplay()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
            Assert.AreNotEqual(ToggleState.Indeterminate, _toolbarStatus);
        }

        [When(@"check the Airplane power mode display")]
        public void WhenCheckTheAirplanePowerModeDisplay()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
            Assert.AreNotEqual(ToggleState.Indeterminate, _toolbarStatus);
        }

        [When(@"check the Rapid charge display")]
        public void WhenCheckTheRapidChargeDisplay()
        {
            _toolbarStatus = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
            Assert.AreNotEqual(_toolbarStatus, ToggleState.Indeterminate);
        }

        [Then(@"the toolbar should only display (.*) icon")]
        public void ThenTheToolbarShouldOnlyDisplayIcon(string p0)
        {
            desktopSession = baseTestClass.DesktopSession();
            var showhidden = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString(), 3, 1);
            //= desktopSession.Session.FindElementByAccessibilityId(Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString());
            var overflowarea = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Overflowarea).ToString());
            if (showhidden != null && overflowarea != null)
            {
                showhidden.Click();
            }
            var toolbar = FindElementsByTimes(desktopSession.Session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NEWOSToolbar"), 10, 1);
            Assert.IsTrue(toolbar.Count == 1, "toolbar icon not equals 1");
        }

        [Then(@"the toolbar ""(.*)"" pin to taskbar in New OS Within ""(.*)"" Seconds")]
        public void ThenTheToolbarPinToTaskbarInNewOS(string p0, int seconds)
        {
            Thread.Sleep(TimeSpan.FromSeconds(seconds));
            desktopSession = baseTestClass.DesktopSession();
            var showhidden = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ShowHiddenIcon).ToString(), 3, 1);
            var overflowarea = FindElementByTimes(desktopSession.Session, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Overflowarea).ToString());
            if (showhidden != null && overflowarea != null)
            {
                showhidden.Click();
            }

            if (p0.ToLower().Equals("should"))
            {
                var toolbar = FindElementByTimes(desktopSession.Session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NEWOSToolbar"), 1, 1);
                Assert.IsNotNull(toolbar, "Toolbar doesn't display");
            }
            else
            {
                var toolbar = FindElementByTimes(desktopSession.Session, "Name", GetAutomationIdFromPredefinedJsonFile("$.PowerPage.NEWOSToolbar"), 3, 1);
                Assert.IsNull(toolbar, "Toolbar shouldn't display");
            }

        }

        [Then(@"Check Toolbar Word has been updated")]
        public void ThenCheckToolbarWordHasBeenUpdated()
        {
            HSToolbarPage _hsToobarPage = new HSToolbarPage(_webDriver.Session);
            Assert.IsNotNull(_hsToobarPage.NOSToolbardescriptionContexts, "tips is not update");
            Assert.IsNotNull(_hsToobarPage.NOSToolbardescriptionTips, "description is not update");
            Assert.IsNotNull(_hsToobarPage.ToolbarWindowsNextIcon, "toolbaricon is not update");
        }


        [Then(@"the toolbar pin to taskbar")]
        public void ThenTheToolbarPinToTaskbar()
        {
            Thread.Sleep(TimeSpan.FromSeconds(6));
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2);
            Assert.IsNotNull(toolbar);
        }

        [Then(@"the taskbar doesn't display the toolbar")]
        public void ThenTheTaskbarDoesnTDisplayTheToolbar()
        {
            Thread.Sleep(TimeSpan.FromSeconds(6));
            var toolbar = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2);
            Assert.IsNull(toolbar);
        }

        [Then(@"display the battery detail on the thinkpad ,the Ideapad doesn't display")]
        public void ThenDisplayTheBatteryDetailOnTheThinkpadTheIdeapadDoesnTDisplay()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            if (currentMachineType.ToLower().Contains("think"))
            {
                var batteryDetail = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString());
                Assert.IsTrue(batteryDetail.Current.Name.Contains("TIME TO FULL CHARGE"));
            }
            else if (currentMachineType.ToLower().Contains("idea"))
            {
                var batteryDetail = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString());
                bool isContains = batteryDetail.Current.Name.Contains("TIME TO FULL CHARGE");
                Assert.IsFalse(isContains);
            }
        }

        [Then(@"display the Remaining Time on the Ideapad and Thinkpad")]
        public void ThenDisplayPlayTheBatteryDetailsOnTheIdeapadAndThinkpad()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            var batteryDetail = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.BatteryDetails).ToString());
            Assert.IsTrue(batteryDetail.Current.Name.Contains("REMAINING TIME"));
        }

        [Then(@"the my battery of toolbar and battery gauge display express charge icon")]
        public void ThenTheMyBatteryOfToolbarAndBatteryGaugeDisplayExpressChargeIcon()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [Then(@"the my battery of toolbar and battery gauge display Conservation mode icon")]
        public void ThenTheMyBatteryOfToolbarAndBatteryGaugeDisplayConservationModeIcon()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString());
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [Then(@"the battery gauge doesn't display the Rapid charge icon")]
        public void ThenTheBatteryGaugeDoesnTDisplayTheRapidChargeIcon()
        {
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [Then(@"the battery gauge doesn't display the Conservative mode icon")]
        public void ThenTheBatteryGaugeDoesnTDisplayTheConservativeModeIcon()
        {
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [Then(@"the battery gauge display charge but not Airplane power mode icon")]
        [Then(@"the battery gauge display Airplane power mode icon")]
        public void ThenTheBatteryGaugeDisplayAirplanePowerModeİcon()
        {
            Assert.IsNotNull(VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.chargeIcon).ToString(), 2));
        }

        [Then(@"the battery gauge doesnot display the Airplane Power Mode icon")]
        public void ThenTheBatteryGaugeDoesnotDisplayTheAirplanePowerModeIcon()
        {
            Assert.IsNull(VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.chargeIcon).ToString(), 2));
        }

        [Then(@"The Keyboard backlight button displays same as with Vantage")]
        public void ThenTheKeyboardBacklightButtonDisplaysSameAsWithVantage()
        {
            _hsInputPage = new HSInputPage(_webDriver.Session);
            Assert.AreEqual(_toolbarStatus, VantageCommonHelper.GetToggleStatus(_hsInputPage.keyboardBacklightCheckBox));
        }

        [Then(@"The Conservation mode button displays same as with Vantage")]
        public void ThenTheConservationModeButtonDisplaysSameAsWithVantage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox);
            if (togglestatus == ToggleState.Indeterminate)
            {
                Thread.Sleep(2000);
                togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.ConservationCheckBox);
            }
            Assert.AreEqual(_toolbarStatus, togglestatus);
        }

        [Then(@"The Battery charge threshold button displays same as with Vantage")]
        public void ThenTheBatteryChargeThresholdButtonDisplaysSameAsWithVantage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.BatteryChargeThresholdCheckBox);
            if (togglestatus == ToggleState.Indeterminate)
            {
                Thread.Sleep(2000);
                togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.BatteryChargeThresholdCheckBox);
            }
            Assert.AreEqual(_toolbarStatus, togglestatus);
        }

        [Then(@"The Airplane power mode button displays same as with Vantage")]
        public void ThenTheAirplanePowerModeButtonDisplaysSameAsWithVantage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.AreEqual(_toolbarStatus, VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.BatteryAirplaneCheckBox));
        }

        [Then(@"The Rapid charge button displays same as with Vantage")]
        public void ThenTheRapidChargeButtonDisplaysSameAsWithVantage()
        {
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            var togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox);
            if (togglestatus == ToggleState.Indeterminate)
            {
                Thread.Sleep(2000);
                togglestatus = VantageCommonHelper.GetToggleStatus(_hSPowerSettingsPage.RapidChargeCheckBox);
            }
            Assert.AreEqual(_toolbarStatus, togglestatus);
        }

        [StepDefinition(@"Switch the KBBL value to '(.*)'")]
        public void SwitchBacklight(string _requiredOption)
        {
            string toolbarXPath = @"/Pane[@ProcessId='{0}' and @ClassName='#32770']";
            Process[] processes = Process.GetProcessesByName("QuickSettingEx");
            if (processes.Length == 0)
            {
                Assert.IsTrue(false, "NO GUI element for toolbar ? generated by Keyboard backlight.exe");
            }
            toolbarXPath = string.Format(toolbarXPath, processes[0].Id);
            if (!VantageUI.instance.ElementExistUsingCustomXPath(toolbarXPath))
            {
                Assert.IsTrue(false, "NO toobar???");
            }

            for (int i = 0; i < 4; i++)
            {
                if (VantageUI.instance.ElementExistUsingCustomXPath($"{toolbarXPath}//*[@Name='{_requiredOption}']"))
                {
                    return;
                }
                VantageUI.instance.ClickElementUsingCustomXPath($"{toolbarXPath}//*[@AutomationId='{VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Toolbar.Backlight").ToString()}']");
            }
            Assert.IsTrue(false, $"NO Backlight option {_requiredOption}???");
        }

        [StepDefinition(@"click backlight on toolbar")]
        public void clickBacklight()
        {
            string toolbarXPath = @"/Pane[@ProcessId='{0}' and @ClassName='#32770']";
            Process[] processes = Process.GetProcessesByName("QuickSettingEx");
            if (processes.Length == 0)
            {
                Assert.IsTrue(false, "NO GUI element for toolbar ? generated by Keyboard backlight.exe");
            }
            toolbarXPath = string.Format(toolbarXPath, processes[0].Id);
            if (!VantageUI.instance.ElementExistUsingCustomXPath(toolbarXPath))
            {
                Assert.IsTrue(false, "NO toobar???");
            }

            VantageUI.instance.ClickElementUsingCustomXPath($"{toolbarXPath}//*[@AutomationId='{VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Toolbar.Backlight").ToString()}']");

        }

        [StepDefinition(@"next backlight option on toolbar is '(.*)'")]
        public void verifyBacklight(string _requiredOption)
        {
            string toolbarXPath = @"/Pane[@ProcessId='{0}' and @ClassName='#32770']";
            Process[] processes = Process.GetProcessesByName("QuickSettingEx");
            if (processes.Length == 0)
            {
                Assert.IsTrue(false, "NO GUI element for toolbar ? generated by Keyboard backlight.exe");
            }
            toolbarXPath = string.Format(toolbarXPath, processes[0].Id);
            if (!VantageUI.instance.ElementExistUsingCustomXPath(toolbarXPath))
            {
                Assert.IsTrue(false, "NO toobar???");
            }
            if (VantageUI.instance.ElementExistUsingCustomXPath($"{toolbarXPath}//*[@Name='{_requiredOption}']"))
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.IsTrue(false, $"next backlight is NOT {_requiredOption} ?");

        }

        [StepDefinition(@"Launch Vantage from Toolbar")]
        public void launchVantage()
        {
            WhenLaunchToolbar();
            string toolbarXPath = @"/Pane[@ProcessId='{0}' and @ClassName='#32770']";
            Process[] processes = Process.GetProcessesByName("QuickSettingEx");
            if (processes.Length == 0)
            {
                Assert.IsTrue(false, "NO GUI element for toolbar ? generated by Keyboard backlight.exe");
            }
            toolbarXPath = string.Format(toolbarXPath, processes[0].Id);
            if (!VantageUI.instance.ElementExistUsingCustomXPath(toolbarXPath))
            {
                Assert.IsTrue(false, "NO toobar???");
            }
            VantageUI.instance.MouseFocusElementUsingCustomXPath($"{toolbarXPath}//*[@AutomationId='{VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Toolbar.GoToLenovoVantage").ToString()}']");
            VantageUI.instance.SimulateMouseClickGUIElement($"{toolbarXPath}//*[@AutomationId='{VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.Toolbar.GoToLenovoVantage").ToString()}']");
        }

        [Given(@"Launch Vantage from Toolbar Click '(.*)' Link")]
        public void GivenLaunchVantageFromToolbarClickLink(string p0)
        {
            _hsToolbarPage = new HSToolbarPage(_webDriver.Session);
            switch (p0)
            {
                case "All Settings":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AllSettingsBtn).ToString());
                    break;
                case "Go to Lenovo Vantage":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.GoToVantage).ToString());
                    break;
                case "Battery details":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryDetailsLink).ToString());
                    break;
                default:
                    Assert.Fail("GivenLaunchVantageFromToolbarViaLink,parameter error" + p0);
                    break;
            }
        }

        [Given(@"Multiple clicks icons within Toolbar")]
        public void GivenMultipleClicksIconsWithinToolbar()
        {
            for (int i = 0; i < 10; i++)
            {
                GivenLaunchVantageFromToolbarViaLink("Wi-Fi security");
                GivenLaunchVantageFromToolbarViaLink("Camera");
                GivenLaunchVantageFromToolbarViaLink("Microphone");
                if (VantageCommonHelper.IsThinkPad())
                {
                    GivenLaunchVantageFromToolbarViaLink("Battery Charge Threshold");
                    GivenLaunchVantageFromToolbarViaLink("Airplane Power Mode");
                }
                if (VantageCommonHelper.IsIdeaPad())
                {
                    GivenLaunchVantageFromToolbarViaLink("Conservation Mode");
                    GivenLaunchVantageFromToolbarViaLink("Rapid Charge");
                }
            }
        }

        [Given(@"MTM End With CD")]
        public void GivenMTMEndWithCD_()
        {
            string MTM = CHSWebEnvPage.GetXmlSingleNode("/MachineInformation/MTM", MachineInformationPath);
            Assert.IsTrue(MTM.EndsWith("CD"), "MachineInforemation is not End with CD");
        }

        [Then(@"There is No '(.*)' Link")]
        public void ThenThereIsNoLink(string p0)
        {
            var _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            var _desktopSession = _intelligentcoolingPages.GetControlPanelSession(true);
            switch (p0)
            {
                case "Comments & feedback":
                    var feedbacklink = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.CommentsFeedBackLink).ToString(), 5, 2);
                    Assert.IsNull(feedbacklink, "shouldn't have feedbacklink");
                    break;
                case "View warranty option":
                    var viewlink = _intelligentcoolingPages.FindElementByTimes(_desktopSession, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.ViewWarrantyOptionLink).ToString(), 5, 2);
                    Assert.IsNull(viewlink, "shouldn't have feedbacklink");
                    break;
            }
        }

        [Given(@"Launch Vantage from Toolbar Via '(.*)' Link")]
        public void GivenLaunchVantageFromToolbarViaLink(string link)
        {
            _hsToolbarPage = new HSToolbarPage(_webDriver.Session);
            SettingsBase settings = new SettingsBase(_webDriver.Session);
            switch (link)
            {
                case "All Settings":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AllSettingsBtn).ToString());
                    Thread.Sleep(3000);
                    Assert.NotNull(settings.MySettingsPower, "GivenLaunchVantageFromToolbarViaLink >> MySettingsPower not found");
                    break;
                case "All Settings OOBE":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AllSettingsBtn).ToString());
                    Thread.Sleep(7000);
                    break;
                case "Go to Lenovo Vantage":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.GoToVantage).ToString());
                    Assert.Null(settings.MySettingsPower, "GivenLaunchVantageFromToolbarViaLink >> MySettingsPower still show");
                    break;
                case "Battery details":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryDetailsLink).ToString());
                    Assert.NotNull(_hsToolbarPage.BatteryDetailsCloseBtn, "the BatteryDetailsCloseBtn not found");
                    _hsToolbarPage.BatteryDetailsCloseBtn.Click();
                    break;
                case "View warranty option":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ViewWarrantyOptionLink).ToString());
                    break;
                case "Comments & feedback":
                    AutomationElement automationElement = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ViewWarrantyOptionLink).ToString());
                    if (automationElement != null)
                    {
                        var position = automationElement.Current.BoundingRectangle;
                        string x = ((int)position.Left + (int)position.Width / 2).ToString();
                        string y = (((int)position.Bottom - (int)position.Height / 2) + 20).ToString();
                        VantageCommonHelper.SetMouseClick(x, y, false);
                    }
                    break;
                case "Go to Lenovo Vantage via right menu":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2, false);
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{DOWN}");
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{Enter}");
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2, false);
                    VantageCommonHelper.keybd_event(Keys.Down, 0, 0, 0);
                    VantageCommonHelper.keybd_event(Keys.Down, 0, 2, 0);
                    Thread.Sleep(1000);
                    VantageCommonHelper.keybd_event(Keys.Enter, 0, 0, 0);
                    VantageCommonHelper.keybd_event(Keys.Enter, 0, 2, 0);
                    break;
                case "Toolbar right menu":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ToolBar).ToString(), 2, false);
                    Thread.Sleep(1000);
                    break;
                case "Camera":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    break;
                case "Microphone":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    break;
                case "Wi-Fi security":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.WIFISecurity).ToString());
                    break;
                case "Battery Charge Threshold":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.BatteryChargeThreshold).ToString());
                    break;
                case "Airplane Power Mode":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.AirplanePowerMode).ToString());
                    break;
                case "Conservation Mode":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ConservationMode).ToString());
                    break;
                case "Rapid Charge":
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.RapidCharge).ToString());
                    break;
                case "Comments & feedback blank":
                    VantageCommonHelper.ClickBelowTheElement(Convert.ToInt32(ToolBarAutoEnum.ViewWarrantyOptionLink).ToString(), 30);
                    break;
                default:
                    Assert.Fail("GivenLaunchVantageFromToolbarViaLink,parameter error," + link);
                    break;
            }
            Thread.Sleep(3000);
            //string windowsName = VantageConstContent.NotLEMask == true ? "Lenovo Vantage" : "Commercial Vantage";
            //IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", windowsName);
            // Assert.AreNotEqual(IntPtr.Zero,intPtr, "GivenLaunchVantageFromToolbarViaLink fail.");
        }

        [Given(@"The microphone permission toast pop up")]
        public void GivenTheMicrophonePermissionToastPopUp()
        {
            VantageCommonHelper.OObeNetVantage30(_webDriver.Session, false, false);
        }

        [Given(@"The select '(.*)' button on '(.*)' permission toast pop up")]
        public void GivenTheSelectButtonOnPermissionToastPopUp(string btntype, string func)
        {
            string id = btntype == "yes" ? "//Button[@AutomationId='Button1']" : "//Button[@AutomationId='Button0']";
            WindowsElement windowsElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, id, 15);
            switch (func.ToLower())
            {
                case "shown":
                    Assert.NotNull(windowsElement, "The  PermissionToastPopUp element not found,info:" + func + btntype);
                    break;
                case "hidden":
                    Assert.Null(windowsElement, "The  PermissionToastPopUp element still found,info:" + func + btntype);
                    break;
                default:
                    Assert.NotNull(windowsElement, "The  PermissionToastPopUp element not found,info:" + func + btntype);
                    windowsElement.Click();
                    break;
            }
        }

        [When(@"Press F4 Event")]
        public void WhenPressF4Event()
        {
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.F4, 0, 0, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.F4, 0, 2, 0);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [When(@"Simulate PressKey (.*) Event")]
        public void WhenSimulatePressF4Event(string simulateKey)
        {
            if (simulateKey.Equals("F4"))
            {
                uint value = Convert.ToUInt32(_typeF4ValueInit);
                value = value ^ 0x04000000;
                int tempInt = 0;
                unchecked
                {
                    tempInt = Convert.ToInt32(value);
                }
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey tmp = rk.OpenSubKey(_regUserDefinedKey, true);
                tmp.SetValue("Default", tempInt, RegistryValueKind.DWord);
            }
        }

        [Then(@"The machine no battery and check display text")]
        public void ThenTheMachineNoBatteryAndCheckDisplayText()
        {
            Assert.IsNotNull(_hsQuickSettingsPage.NoBatteryText);
        }

        [Given(@"Machine is DT")]
        public void GivenMachineIsDT()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(currentMachineType.ToLower().Contains("lenovo product"));
        }

        [Given(@"Turn '(.*)' Action Center for '(.*)'")]
        public void GivenTurnActionCenter(string status, string mode)
        {
            bool isNewOs = VantageCommonHelper.JudgeMachineNewOS();
            if (isNewOs)
            {
                KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 0, 0);
                KeyboardMouse.keybd_event((byte)Keys.A, 0, 0, 0);
                KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 2, 0);
                KeyboardMouse.keybd_event((byte)Keys.A, 0, 2, 0);
            }
            else
            {
                Process.Start("ms-actioncenter:");
            }
            Thread.Sleep(1000);
            HSSmartAssistPage hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> appsession = hSSmartAssist.GetControlPanelSession(true);
            string xpath = null;
            VantageConstContent.WindowsActionCenterMap.TryGetValue(mode, out xpath);
            WindowsElement element = FindElementByTimes(appsession, "XPath", xpath);
            Assert.NotNull(element, "The " + xpath + " not found.");
            IntelligentCooling.IntelligentCoolingBaseHelper helper = new IntelligentCooling.IntelligentCoolingBaseHelper();
            helper.GetAttributesByPageSource(null, "ToggleState", appsession, xpath);
            switch (status.ToLower())
            {
                case "on":
                    if (helper.GetAttributesByPageSource(null, "ToggleState", appsession, xpath).ToLower() != status.ToLower())
                    {
                        element.Click();
                    }
                    break;
                case "off":
                    if (helper.GetAttributesByPageSource(null, "ToggleState", appsession, xpath).ToLower() != status.ToLower())
                    {
                        element.Click();
                    }
                    break;
                default:
                    Assert.Fail("GivenTurnActionCenter() no run");
                    break;
            }
            Assert.AreEqual(helper.GetAttributesByPageSource(null, "ToggleState", appsession, xpath).ToLower(), status.ToLower(), "GivenTurnActionCenter() Fail");
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.Escape, 0, 0, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.Escape, 0, 2, 0);
            if (isNewOs)
            {
                KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 0, 0);
                KeyboardMouse.keybd_event((byte)Keys.A, 0, 0, 0);
                KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 2, 0);
                KeyboardMouse.keybd_event((byte)Keys.A, 0, 2, 0);
                Thread.Sleep(2000);
            }
        }

        [Then(@"The '(.*)' display within toolbar and text is correct '(.*)'")]
        public void ThenTheDisplayWithinToolbarAndTextIsCorrect(string func, string desc)
        {
            _hSSmartAssist = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> appsession = _hSSmartAssist.GetControlPanelSession(true);
            WindowsElement element = null;
            switch (func)
            {
                case "View warranty option":
                    element = FindElementByTimes(appsession, "XPath", "//*[@AutomationId='" + Convert.ToInt32(ToolBarAutoEnum.ViewWarrantyOptionLink).ToString() + "']");
                    break;
                case "Comments & feedback":
                    element = FindElementByTimes(appsession, "XPath", "//*[@AutomationId='" + Convert.ToInt32(ToolBarAutoEnum.CommentsFeedBackLink).ToString() + "']");
                    break;
                default:
                    Assert.Fail("ThenTheDisplayWithinToolbarAndTextIsCorrect no run");
                    break;
            }
            Assert.NotNull(element, "The element not found.info:" + func);
            Assert.AreEqual(desc, element.Text, "The function text display incorect,Info:" + func);
        }

        [Then(@"The Comments feedback Nodisplay")]
        public void ThenTheCommentsFeedbackDisplay()
        {
            _supportPage = new SupportPage(_webDriver.Session);
            Assert.IsNull(_supportPage.DialogGiveFeedBackTitle, "The DialogGiveFeedBackTitle not found");
            Assert.IsNull(_supportPage.DialogGiveFeedBackCloseBtn, "The DialogGiveFeedBackCloseBtn not found");
            Assert.IsNull(_supportPage.DialogSendFeedBackBtn, "The DialogSendFeedBackBtn not found");
        }

        [Then(@"The Comments feedback Doesn't Display")]
        public void ThenTheCommentsFeedbacknotDisplay()
        {
            _supportPage = new SupportPage(_webDriver.Session);
            Assert.IsNull(_supportPage.DialogGiveFeedBackTitle, "The DialogGiveFeedBackTitle not found");
            Assert.IsNull(_supportPage.DialogGiveFeedBackCloseBtn, "The DialogGiveFeedBackCloseBtn not found");
            Assert.IsNull(_supportPage.DialogSendFeedBackBtn, "The DialogSendFeedBackBtn not found");
        }

        [Then(@"Toolbar priority and order of the settings button is correct")]
        public void ThenToolbarPriorityAndOrderOfTheSettingsButtonIsCorrect()
        {
            //temp method
        }


    }
}
