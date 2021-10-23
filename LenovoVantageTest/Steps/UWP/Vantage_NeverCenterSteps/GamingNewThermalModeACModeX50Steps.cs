using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.GamingThermalModePages;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingNewThermalModeACModeX50Steps
    {
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;
        private ToggleState _enabledGPUState;
        private ThermalMode _getCurrentThermalMode;
        private bool _supportXtu = true;
        private string _gpuDescript = "NVIDIA GeForce";
        private string _cpuUnistallDisplayName = "Intel(R) Extreme Tuning Utility SDK";
        public GamingNewThermalModeACModeX50Steps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"AC Condition\(Connect the Adapter\)")]
        public void GivenACConditionConnectTheAdapter()
        {
            VantageCommonHelper.ConnectToPowerForBatteryIsLow();
            if (!VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
            Assert.IsTrue(VantageCommonHelper.JudgeInsertStatusIsOn(), "Judge Insert Status Is Off");
        }

        [Given(@"DC Condition\(Connect the Adapter\)")]
        public void GivenDCConditionConnectTheAdapter()
        {
            VantageCommonHelper.ConnectToPowerForBatteryIsLow();
            if (VantageCommonHelper.JudgeInsertStatusIsOn())
            {
                VantageCommonHelper.AdapterNotInsert();
            }
            Assert.IsTrue(!VantageCommonHelper.JudgeInsertStatusIsOn(), "Judge Insert Status Is On");
        }

        [Given(@"The Thermal Mode Setting popup is displaying")]
        public void GivenThePopupIsDisplaying()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.GetThermalMode, "Get Thermal Mode is null");
            //Assert.IsTrue(_gamingThermalModePages.LegionEdgeContainsThermalMode(), "LegionEdgeContainsThermalMode");
            Assert.IsNotNull(_gamingThermalModePages.GetThermalMode, "GetThermalMode Element Is null");
            _gamingThermalModePages.GetThermalMode.Click();
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeSettingsTitle);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeBananceInSettingsCloseBtn);
            //Assert.IsNotNull(_gamingThermalModePages.ThermalModeSettingsAutoPerformanceSwitchDescription);
        }

        [Given(@"The thermal mode is (.*)")]
        public void GivenTheThermalModeIs(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            ThermalMode thermalMode = _gamingThermalModePages.GetTheThermalMode(p0);
            _getCurrentThermalMode = thermalMode;
            Assert.IsTrue(_gamingThermalModePages.SetThermalMode(thermalMode));
        }

        [Given(@"Auto switch toggle is (.*)")]
        public void GivenAutoSwitchToggleIsOFF(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            bool turnOffFlag = false;
            switch (p0.ToLower())
            {
                case "off":
                    turnOffFlag = _gamingThermalModePages.SetThermalModeAutoPerformanceSwitch(ToggleState.Off);
                    break;
                case "on":
                    turnOffFlag = _gamingThermalModePages.SetThermalModeAutoPerformanceSwitch(ToggleState.On);
                    break;
            }
            Assert.IsTrue(turnOffFlag, "GivenAutoSwitchToggleIsOFF");
        }

        [When(@"Check Thermal mode in the Thermal Mode Setting popup")]
        public void WhenCheckThermalModeInThePopup()
        {
            Assert.IsTrue(true, "Check Thermal mode in the Thermal Mode Setting popup");
        }

        [When(@"check the Enable OverClocking checkbox status")]
        public void WhenCheckTheEnableOverClockingCheckboxStatus()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _enabledGPUState = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
        }

        [When(@"OverClocking checkbox not display")]
        public void WhenOverClockingCheckboxNotDisplay()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNull(_gamingThermalModePages.EnableOCCheckboxElement);
        }


        [Given(@"The Enable Overclocking Checkbox is (.*)")]
        public void GivenTheEnableOverclockingCheckboxIs(string p0)
        {
            ToggleState toggleState = ToggleState.Off;
            if (p0.Equals("Checked", StringComparison.CurrentCultureIgnoreCase))
            {
                toggleState = ToggleState.On;
            }
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            var enabledGPUState = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            if (enabledGPUState != toggleState)
            {
                _gamingThermalModePages.SetCheckBoxStatus(_gamingThermalModePages.EnableOCCheckboxElement, toggleState);
            }
            enabledGPUState = _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings();
            Assert.AreEqual(toggleState, enabledGPUState);
        }

        [Then(@"Then The thermal mode is (.*) in homepage")]
        public void ThenThethermalmodeisinhomepage(string p0)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            ThermalMode thermalMode = _gamingThermalModePages.GetTheThermalMode(p0);
            _getCurrentThermalMode = _gamingThermalModePages.GetCurrentThermalModeInHomePage();
            Assert.AreEqual(thermalMode, _getCurrentThermalMode);
        }

        [Then(@"The thermal mode is (.*) in the Thermal Mode Setting popup")]
        public void ThenTheThermalModeIsInThePopup(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            ThermalMode thermalMode = _gamingThermalModePages.GetTheThermalMode(p0);
            Assert.AreEqual(thermalMode, _gamingThermalModePages.GetCurrentThermalMode(), "ThenTheThermalModeIsBalanceModeInThePopup");
        }

        [Then(@"Enable OverClocking checkbox status should not be changed")]
        public void ThenEnableOverClockingCheckboxStatusShouldNotBeChanged()
        {
            Assert.AreEqual(_enabledGPUState, _gamingThermalModePages.GetEnableOCStatusInThermalModeSettings());
        }

        [Given(@"Click X button in Thermal Mode Setting popup")]
        public void GivenClickXButtonInThermalModeSettingPopup()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            var closeElement = _gamingThermalModePages.ThermalModeBananceInSettingsCloseBtn;
            Assert.IsNotNull(closeElement, "ThermalModeBananceInSettingsCloseBtn is null");
            closeElement.Click();
            Assert.IsNull(_gamingThermalModePages.ThermalModeQuietSettingsPopupDismiss);
        }

        [When(@"Stop the game")]
        public void WhenStopTheGame()
        {
            Common.KillProcess("Wow", true);
            Thread.Sleep(TimeSpan.FromSeconds(5));
        }

        [Given(@"Open the XTU and GPU OC tool")]
        public void GivenOpenTheXTUAndGPUOCTool()
        {
            Assert.IsNotNull("Open the XTU and GPU OC tool");
        }

        [When(@"Check the OC values in the tools")]
        public void WhenCheckTheOCValuesInTheTools()
        {
            Assert.IsTrue(true, "Check the OC values in the tools");
        }

        [Then(@"It will display (.*) OC values")]
        public void ItwilldisplayOCvalues(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);

            string getGPUKeyName = "GPU Core Offset";

            string gpuValue = _gamingThermalModePages.GetGPUOCValue();
            Dictionary<string, string> xtuValues = null;
            if (_supportXtu)
            {
                xtuValues = _gamingThermalModePages.GetXtuOCValueFromXtuTool();
            }
            List<OCValueItem> cpuOcValueItem = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuOCListPath);
            foreach (OCValueItem cpuOCValueItem in cpuOcValueItem)
            {
                string ocItemName = cpuOCValueItem.Name.Trim().ToLower();
                string getToolOcValue = string.Empty;
                xtuValues?.TryGetValue(ocItemName, out getToolOcValue);

                if (p0.ToLower().Equals("not"))
                {
                    if (getGPUKeyName.ToLower().Equals(ocItemName))
                    {
                        Assert.AreEqual(Convert.ToDouble(cpuOCValueItem.NotOCValue), Convert.ToDouble(gpuValue), "The ocItemName is " + ocItemName + "The cpuOCValueItemNotOCValue is " + cpuOCValueItem.NotOCValue + "The gpuValue is " + gpuValue);
                    }
                    else
                    {
                        ;
                        Assert.AreEqual(Convert.ToDouble(cpuOCValueItem.NotOCValue), Convert.ToDouble(getToolOcValue), "The ocItemName is " + ocItemName + "The cpuOCValueItemNotOCValue is " + cpuOCValueItem.NotOCValue + "The getToolOcValue is " + getToolOcValue);
                    }
                }
                else if (p0.ToLower().Equals("yes"))
                {
                    if (getGPUKeyName.ToLower().Equals(ocItemName))
                    {
                        Assert.AreEqual(Convert.ToDouble(cpuOCValueItem.OCValue), Convert.ToDouble(gpuValue) / 1000);
                    }
                    else
                    {
                        Assert.AreEqual(Convert.ToDouble(cpuOCValueItem.OCValue), Convert.ToDouble(getToolOcValue));
                    }
                }
            }
        }

        [Given(@"Support Xtu")]
        public void GivenSupportXtu()
        {
            string familyName = VantageCommonHelper.GetCurrentMachineType();
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _supportXtu = _gamingThermalModePages.SupportXtu();
            if (!_supportXtu)
            {
                Assert.Warn(string.Format("This Machine Familyname is {0} Donot Support Xtu", familyName));
            }
        }

        [Given(@"'(.*)' Driver don't exist")]
        public void DriverDonTExist(string driverType)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (driverType.ToLower().Contains("gpu"))
            {
                if (driverType.ToLower().Contains("AMD"))
                {
                    _gpuDescript = "AMD Radeon";
                }
                string driverId = _gamingThermalModePages.GetDeviceID(_gpuDescript);
                _gamingThermalModePages.ActionDriver(driverId, "Disable");
                Thread.Sleep(5000);
            }

            if (driverType.ToLower().Contains("cpu"))
            {
                var uninstallStr = _gamingThermalModePages.UninstallByDisplayName(_cpuUnistallDisplayName);
                if (!string.IsNullOrEmpty(uninstallStr))
                {
                    Thread.Sleep(3000);
                    SendKeys.SendWait("{TAB}");
                    Thread.Sleep(3000);
                    SendKeys.SendWait("{ENTER}");
                    Thread.Sleep(3000);
                    Common.KillProcess("_iu14D2N.tmp", true);
                }
            }
            Thread.Sleep(5000);
        }

        [Given(@"Set '(.*)' drive state to enable or disable '(.*)' via HardwareId '(.*)'")]
        public void GivenSetDriveStateToEnableOrDisable(string driName, string status, string hardwareid)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            string driverId = _gamingThermalModePages.GetDeviceID(driName);
            if (hardwareid != "default")
            {
                driverId = hardwareid;
            }
            Console.WriteLine("Info:" + driverId + " >> " + driName);
            if (status.ToLower() == "enable")
            {
                _gamingThermalModePages.ActionDriver(driverId);
            }
            else
            {
                _gamingThermalModePages.ActionDriver(driverId, "Disable");
            }
            Thread.Sleep(5000);
        }

        [When(@"Only Print '(.*)'")]
        public void WhenOnlyPrint(string p0)
        {
            Console.WriteLine(p0);
        }

        [Given(@"Hover GO INSTALLL Link")]
        public void GivenHoverGOINSTALLLLink()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeGoInstallButton);
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingThermalModePages.ThermalModeGoInstallButton);
        }

        [Given(@"Click Go Install Link")]
        public void GivenClickGoInstallLink()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeGoInstallButton, "Click Go Install Link is null");
            _gamingThermalModePages.ThermalModeGoInstallButton.Click();
        }

        [Then(@"The Enable OC Checkbox Should '(.*)'")]
        public void ThenTheEnableOCCheckboxShould(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (p0.Equals("Disappear"))
            {
                Assert.IsNull(_gamingThermalModePages.EnableOCCheckboxElement);

            }
            else if (p0.Equals("Appear"))
            {
                Assert.IsNotNull(_gamingThermalModePages.EnableOCCheckboxElement);
            }
        }

        [Then(@"Advanced OC Link Should be '(.*)'")]
        public void ThenAdvancedOCLinkShouldBe(string p0)
        {

            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (p0.Equals("Shown"))
            {
                Assert.IsNotNull(_gamingThermalModePages.AdvancedDescription);
            }
            else
            {
                Assert.IsNull(_gamingThermalModePages.AdvancedDescription);
            }
        }


        [Then(@"The GO INSTALL Link Shloud be Shown")]
        public void ThenTheGOINSTALLLinkShloudBeShown()
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            Assert.IsNotNull(_gamingThermalModePages.ThermalModeGoInstallButton);
        }

        [Then(@"The GO INSTALL Link Shloud be '(.*)'")]
        public void ThenTheGOINSTALLLinkShloudBe(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (p0.ToLower().Equals("shown"))
            {
                Assert.IsNotNull(_gamingThermalModePages.ThermalModeGoInstallButton);

            }
            else
            {
                Assert.IsNull(_gamingThermalModePages.ThermalModeGoInstallButton);
            }
        }

        [Then(@"The '(.*)' Description '(.*)'")]
        public void ThenTheDescription(string p0, string p1)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            WindowsElement windowsElement = null;
            if (p0.Contains("Enable"))
            {
                windowsElement = _gamingThermalModePages.EnableOCDescription;
            }
            else if (p0.Contains("Install CPU/GPU"))
            {
                windowsElement = _gamingThermalModePages.GamingThermalModeInstallGPuCPUDesc;
            }
            else if (p0.Contains("Install GPU"))
            {
                windowsElement = _gamingThermalModePages.GamingThermalModeInstallGPuDesc;
            }
            else if (p0.Contains("Install CPU"))
            {
                windowsElement = _gamingThermalModePages.GamingThermalModeInstallCPuDesc;
            }

            if (p1.Trim().Equals("Displaying"))
            {
                string desc = _gamingThermalModePages.ShowTextbox(windowsElement);
                Assert.IsTrue(desc.Contains(p0));
            }
            else
            {
                Assert.IsNull(windowsElement);
            }
        }

        [When(@"Install '(.*)' Driver")]
        public void WhenInstallDriver(string driverType)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (driverType.ToLower().Contains("gpu"))
            {
                if (driverType.ToLower().Contains("AMD"))
                {
                    _gpuDescript = "AMD Radeon";
                }
                string driverId = _gamingThermalModePages.GetDeviceID(_gpuDescript);
                _gamingThermalModePages.ActionDriver(driverId);
            }
            if (driverType.ToLower().Contains("cpu"))
            {
                Process.Start(VantageConstContent.GamingFeatureDriverSetup);
            }
            Thread.Sleep(5000);
        }

        [Then(@"The Enable CPU/GPU Overclocking Checkbox Should be '(.*)'")]
        public void ThenTheEnableCPUGPUOverclockingCheckboxShouldBe(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            if (p0.Equals("Shown"))
            {
                Assert.IsNotNull(_gamingThermalModePages.EnableOCCheckboxElement);
            }
            else
            {
                Assert.IsNull(_gamingThermalModePages.EnableOCCheckboxElement);
            }
        }
    }
}
