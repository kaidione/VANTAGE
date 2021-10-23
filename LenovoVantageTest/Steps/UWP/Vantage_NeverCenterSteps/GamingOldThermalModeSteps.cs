using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingOldThermalModeSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private object currentMachineType;

        public GamingOldThermalModeSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"UnSupport Old Thermal Mode")]
        public void WhenUnSupportOldThermalMode()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            if ((currentMachineType.Contains("Legion Y740-17ICHg") || currentMachineType.Contains("Legion Y9000K 2019") || currentMachineType.Contains("Legion Y740-17IRH") || currentMachineType.Contains("Legion Y740-17IRHg") || currentMachineType.Contains("Legion Y9000K 2019 SE") || currentMachineType.Contains("Legion Y9000P 2019") || currentMachineType.Contains("Legion Y740-15ICHg") || currentMachineType.Contains("Legion Y740-15IRH") || currentMachineType.Contains("Legion Y740-15IRHg")))
            {
                Assert.Fail("This machine should not support the Old Thermal mode.");
            }
        }

        [When(@"Click the Thermal mode area")]
        public void WhenClickTheThermalModeArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
            _nerveCenterPages.OTMDropDownMenu.Click();
        }

        [When(@"Click the other area")]
        public void WhenClickTheOtherArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingSystemStatus);
            _nerveCenterPages.GamingSystemStatus.Click();
        }

        [When(@"Select the Performance mode in the menu")]
        public void WhenSelectThePerformanceModeInTheMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDPPerfomanceMode);
            _nerveCenterPages.OTMDPPerfomanceMode.Click();
        }

        [When(@"Click Home Page Header Legion")]
        public void WhenClickHomePageHeaderLegion()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.HomePageHeaderLegion, "Fail to find home page header legion.");
            _nerveCenterPages.HomePageHeaderLegion.Click();
        }

        [When(@"Performance mode should be shown")]
        public void WhenPerformanceModeShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
            Assert.IsNotNull(_nerveCenterPages.OTMPerfomanceContainer);
            Assert.IsNotNull(_nerveCenterPages.OTMPerfomanceText);
        }

        [Then(@"Thermal Mode should not be shown")]
        public void ThenThermalModeShouldNotBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.OTMBalanceContainer);
            Assert.Null(_nerveCenterPages.OTMPerfomanceContainer);
            Assert.Null(_nerveCenterPages.OTMQuietContainer);
            Assert.Null(_nerveCenterPages.OTMBalanceText);
            Assert.Null(_nerveCenterPages.OTMPerfomanceText);
            Assert.Null(_nerveCenterPages.OTMQuietText);
            Assert.Null(_nerveCenterPages.OTMDropDownMenu);
            Assert.Null(_nerveCenterPages.OTMDPBalanceText);
            Assert.Null(_nerveCenterPages.OTMDPPerfomanceText);
            Assert.Null(_nerveCenterPages.OTMDPQuietText);
            Assert.Null(_nerveCenterPages.OTMDPBalanceMode);
            Assert.Null(_nerveCenterPages.OTMDPPerfomanceMode);
        }

        [Then(@"Thermal Mode should be shown")]
        public void ThenThermalModeShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
        }

        [Then(@"Three modes should be found")]
        public void ThenThreeModesShouldBeFound()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDPPerfomanceText);
            Assert.IsNotNull(_nerveCenterPages.OTMDPBalanceText);
            Assert.IsNotNull(_nerveCenterPages.OTMDPQuietText);
            Assert.IsNotNull(_nerveCenterPages.OTMDPPerfomanceMode);
            Assert.IsNotNull(_nerveCenterPages.OTMDPBalanceMode);
            Assert.IsNotNull(_nerveCenterPages.OTMDPQuietMode);
        }

        [Then(@"Thermal mode menu should be closed")]
        public void ThenThermalModeMenuShouldBeClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.OTMDPPerfomanceText);
            Assert.Null(_nerveCenterPages.OTMDPBalanceText);
            Assert.Null(_nerveCenterPages.OTMDPQuietText);
            Assert.Null(_nerveCenterPages.OTMDPPerfomanceMode);
            Assert.Null(_nerveCenterPages.OTMDPBalanceMode);
            Assert.Null(_nerveCenterPages.OTMDPQuietMode);
        }

        [Then(@"Performance mode should be shown")]
        public void ThenPerformanceModeShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
            Assert.IsNotNull(_nerveCenterPages.OTMPerfomanceContainer);
            Assert.IsNotNull(_nerveCenterPages.OTMPerfomanceText);
        }

        [Then(@"The mode value is (.*)")]
        public void ThenTheModeValueIs(int p0)
        {
            Assert.IsTrue(NerveCenterHelper.GetThermalModeValue(p0), "Get Thermal Mode Value is " + p0);
        }

        [Then(@"The Gaming mode value is (.*) And the Method is (.*)")]
        public void ThenTheGamingModeValueIsAndTheMethodIs(int p0, string p1)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            Assert.IsTrue(NerveCenterHelper.GetThermalModeValue(p0, p1), string.Format("Get {0} Value is ", p1) + p0);
        }

        [Then(@"The Gaming Mode Value (.*) Is Or Not (.*) And The Method Is (.*)")]
        public void ThenTheGamingModeValueIsOrNotAndTheMethodIsGetProductInfo(string p0, string p1, string p2)
        {
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string modeValue = NerveCenterHelper.GetMachineThermalModeValue(p2).ToString();
            if (p0 == "is")
            {
                Assert.IsTrue(p1.Contains(modeValue), "Get " + p2 + " Value should be " + p1 + " , but current mode value is " + modeValue);
            }
            else if (p0 == "not")
            {
                Assert.IsFalse(p1.Contains(modeValue), "Get " + p2 + " Value should not be " + p1 + " , but current mode value is " + modeValue);
            }
        }

        [StepDefinition(@"Get CPU Overclock Frequency And the Method is (.*) When (.*)")]
        public void GivenGetCPUOverclockFrequencyAndTheMethodIs(string p0, string p1)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string overclockFrequency = NerveCenterHelper.GetMachineThermalModeValue(p0).ToString();
            string cpuInfoUISpec = _nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name");
            Assert.AreNotEqual(overclockFrequency, string.Empty, "Failed to get maximum clocks CPU OC value.");
            string stringDecimalResult = NerveCenterHelper.ConvertMaximumCPUFrequencyFromWMITool(overclockFrequency, p1);
            Assert.IsTrue(cpuInfoUISpec.Contains(stringDecimalResult), "CPU frequency strings " + cpuInfoUISpec + " should contain Maximum clocks CPU OC value " + stringDecimalResult);
        }

        [StepDefinition(@"Frequency Strings Should Be Consistent With Current Clocks '(.*)' Value In The GPU Boost Tool")]
        public void GivenFrequencyStringsShouldBeConsistentWithCurrentClocksValueInTheGPUBoostTool(string p0)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Thread.Sleep(TimeSpan.FromSeconds(2));
            string gpuInfoUISpec = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            string vramInfoUISpec = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
            string gpuGrapicsValue = DesktopPowerManagementHelper.RunCmd(VantageConstContent.GPUBoostPath + " clocks");
            string[] gpuInfo = gpuGrapicsValue.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string gpuInfoUISpec2 = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            string vramInfoUISpec2 = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
            Thread.Sleep(8000);
            string gpuInfoUISpec3 = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            string vramInfoUISpec3 = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
            string graphicsValue = string.Empty;
            string memoryValue = string.Empty;
            string clocksValue = string.Empty;
            string[] result;
            for (int i = 0; i < gpuInfo.Length; i++)
            {
                if (gpuInfo[i] == "Current clocks")
                {
                    result = gpuInfo[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    graphicsValue = gpuInfo[i + 1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                    memoryValue = gpuInfo[i + 3].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
                }
            }
            if (p0 == "Graphics")
            {
                Assert.AreNotEqual(graphicsValue, string.Empty, "Failed to get current clocks Graphics value in the GPU boost tool.");
                clocksValue = NerveCenterHelper.ConvertClocksValueFromGPUBoostTool(graphicsValue);
                Assert.IsTrue(gpuInfoUISpec.Contains(clocksValue) || gpuInfoUISpec2.Contains(clocksValue) || gpuInfoUISpec3.Contains(clocksValue), p0 + " frequency strings " + gpuInfoUISpec + " should contain Current clocks GRAPHICS or Memory value " + clocksValue + " in the GPU boost tool.");
            }
            else if (p0 == "Memory")
            {
                Assert.AreNotEqual(memoryValue, string.Empty, "Failed to get Current clocks Memory value in the GPU boost tool.");
                clocksValue = NerveCenterHelper.ConvertClocksValueFromGPUBoostTool(memoryValue);
                Assert.IsTrue(vramInfoUISpec.Contains(clocksValue) || vramInfoUISpec2.Contains(clocksValue) || vramInfoUISpec3.Contains(clocksValue), p0 + " frequency strings " + gpuInfoUISpec + " should contain Current clocks GRAPHICS or Memory value " + clocksValue + " in the GPU boost tool.");
            }
            else
            {
                Assert.Fail("The input parameter should be Graphics or Memory.");
            }
        }

        [StepDefinition(@"Maximum Frequency Should Be Shown And Consistent With Maximum Clocks '(.*)' Value")]
        public void GivenMaximumFrequencyShouldBeShownAndConsistentWithValue(string p0)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string gpuMaximumValue = DesktopPowerManagementHelper.RunCmd(VantageConstContent.GPUBoostPath + " ps20e");
            string gpuInfoUISpec = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
            string vramInfoUISpec = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
            string[] maximumInfo = gpuMaximumValue.Replace("\r\n", ":").Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
            string graphicsMaximumValue = string.Empty;
            string memoryMaximumValue = string.Empty;
            string clocksValue = string.Empty;
            for (int i = 0; i < maximumInfo.Length; i++)
            {
                if (maximumInfo[i].Contains("GRAPHICS CLOCK"))
                {
                    graphicsMaximumValue = maximumInfo[i + 3].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[4];
                }
                else if (maximumInfo[i].Contains("MEMORY CLOCK"))
                {
                    memoryMaximumValue = maximumInfo[i + 3].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[4];
                }
            }
            if (p0 == "Graphics")
            {
                Assert.AreNotEqual(graphicsMaximumValue, string.Empty, "Failed to get maximum clocks Graphics value in the GPU boost tool.");
                clocksValue = NerveCenterHelper.ConvertClocksValueFromGPUBoostTool(graphicsMaximumValue);
                Assert.IsTrue(gpuInfoUISpec.Contains(clocksValue), p0 + " frequency strings " + gpuInfoUISpec + " should contain Maximum clocks GRAPHICS or Memory value " + clocksValue + " in the GPU boost tool.");
            }
            else if (p0 == "Memory")
            {
                Assert.AreNotEqual(memoryMaximumValue, string.Empty, "Failed to get maximum clocks Memory value in the GPU boost tool.");
                clocksValue = NerveCenterHelper.ConvertClocksValueFromGPUBoostTool(memoryMaximumValue);
                Assert.IsTrue(vramInfoUISpec.Contains(clocksValue), p0 + " frequency strings " + gpuInfoUISpec + " should contain Maximum clocks GRAPHICS or Memory value " + clocksValue + " in the GPU boost tool.");
            }
            else
            {
                Assert.Fail("The input parameter should be Graphics or Memory.");
            }
        }

        [When(@"Select the Balance mode in the menu")]
        public void WhenSelectTheBalanceModeInTheMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDPBalanceMode);
            _nerveCenterPages.OTMDPBalanceMode.Click();
        }

        [Then(@"Balance mode should be shown")]
        public void ThenBalanceModeShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
            Assert.IsNotNull(_nerveCenterPages.OTMBalanceContainer);
            Assert.IsNotNull(_nerveCenterPages.OTMBalanceText);
        }

        [When(@"Select the Quiet mode in the menu")]
        public void WhenSelectTheQuietModeInTheMenu()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDPQuietMode);
            _nerveCenterPages.OTMDPQuietMode.Click();
        }

        [Then(@"Quiet mode should be shown")]
        public void ThenQuietModeShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OTMDropDownMenu);
            Assert.IsNotNull(_nerveCenterPages.OTMQuietContainer);
            Assert.IsNotNull(_nerveCenterPages.OTMQuietText);
        }
    }
}