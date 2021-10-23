using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class ITSGpuOcMethods
    {
        private IntelligentCoolingPages _intelligentcoolingPages;
        private GamingThermalModePages _gamingThermalModePages;
        private InformationalWebDriver _webDriver;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public static string NarratorRegistry = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Accessibility\\ATConfig\\narrator";
        public ITSGpuOcMethods(InformationalWebDriver appDriver)
        {
            this._webDriver = appDriver;
        }

        [Given(@"machine is not gaming")]
        public void GivenMachineIsNotGaming()
        {
            var outputValue = IntelligentCoolingPages.GetNonGamingMachineValue();
            Assert.AreEqual(outputValue, 1792, "The test machine is not Non-Gaming!");
        }

        [Given(@"ITS machine support GPUOC")]
        public void GivenITSMachineSupportGPUOC()
        {
            var supportValue = IntelligentCoolingPages.GetITSMachineSupportGPUOC();
            Assert.AreEqual(supportValue, 1, "The test machine doesn't support GPU OC form BIOS output!");
        }

        [Then(@"ITS GPU OC will be set to (.*) values")]
        public void ThenITSGPUOCWillBeSetToValues(string value)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            string gpuValue = _gamingThermalModePages.GetGPUOCValue(5, "memory offset");
            Assert.AreEqual(gpuValue, value, "GPU OC value is wrong!");
        }

        [Then(@"Check EPM GPU OC check box exist")]
        public void ThenCheckEPMGPUOCCheckBoxExist()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            WindowsElement GpuOcCheckBoxEle = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBox;
            Assert.IsNotNull(GpuOcCheckBoxEle, "GPU OC checkbox is null.");
        }

        [Then(@"The value of GPU OC checkbox is (.*)")]
        public void ThenTheValueOfGPUOCCheckboxIsUnchecked(string checkboxstatus)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            WindowsElement GpuOcCheckBoxEle = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBox;
            var GpuOcCheckBoxStatus = GpuOcCheckBoxEle.GetAttribute("Toggle.ToggleState");
            if (checkboxstatus == "checked")
            {
                Assert.AreEqual(GpuOcCheckBoxStatus, "1", "GPU OC checkbox is not selected!");
            }
            else if (checkboxstatus == "unchecked")
            {
                Assert.AreEqual(GpuOcCheckBoxStatus, "0", "GPU OC checkbox is not unselected!");
            }
        }

        [Given(@"Select ITS GPU OC checkbox (.*)")]
        public void GivenSelectGPUOCCheckbox(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_webDriver.Session);
            WindowsElement GpuOcCheckBoxEle = _intelligentcoolingPages.IntelligentCooling5GpuOcCheckBox;
            var GpuOcCheckBoxStatus = GpuOcCheckBoxEle.GetAttribute("Toggle.ToggleState");
            if (GpuOcCheckBoxStatus == "0" && status == "checked")
            {
                GpuOcCheckBoxEle.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                GpuOcCheckBoxStatus = GpuOcCheckBoxEle.GetAttribute("Toggle.ToggleState");
                if (GpuOcCheckBoxStatus == "0")
                {
                    GpuOcCheckBoxEle.Click();
                }
            }
            else if (GpuOcCheckBoxStatus == "1" && status == "unchecked")
            {
                GpuOcCheckBoxEle.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                GpuOcCheckBoxStatus = GpuOcCheckBoxEle.GetAttribute("Toggle.ToggleState");
                if (GpuOcCheckBoxStatus == "1")
                {
                    GpuOcCheckBoxEle.Click();
                }
            }
            else
            {
                return;
            }
        }
    }
}
