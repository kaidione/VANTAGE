using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX50OCCheckSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private GamingThermalModePages _gamingThermalModePages;
        private bool _supportXtu = true;
        private string _getGPUKeyName = "gpu core offset";
        public GamingX50OCCheckSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"all parameters in the Advance OC dialog are not changed")]
        public void NoChangeGPUvalue()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "the ThermalModeAdvancedBtn not found");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "the ThermalModeProceedBtn not found");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
            Assert.True(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetMinus != null, "the GPUOCAreaOffset Minus and Plus not found");
        }

        [Given(@"all parameters in the Advance OC dialog are changed and saved")]
        public void ChangeSaveGPUvalue()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "the ThermalModeAdvancedBtn not found");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "the .ThermalModeProceedBtn not found");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
            Assert.True(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetMinus != null, "the GPUOCAreaOffset Minus and Plus not found");
            WindowsElement element = _nerveCenterPages.GPUOCAreaOffsetPlus != null ? _nerveCenterPages.GPUOCAreaOffsetPlus : _nerveCenterPages.GPUOCAreaOffsetMinus;
            Assert.IsNotNull(element, "the GPUOCAreaOffset Plus or Minus not found");
            element.Click();
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn, "the OverclockCloseBtn not found");
            _nerveCenterPages.OverclockCloseBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.SaveChangeDialogSaveBtn, "the SaveChangeDialogSaveBtn not found");
            _nerveCenterPages.SaveChangeDialogSaveBtn.Click();
        }

        [Given(@"Open overclock Advance Setting")]
        public void OpenGPUvalue()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalMode, "the ThermalMode not found");
            _nerveCenterPages.ThermalMode.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "the ThermalModeAdvancedBtn not found");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "the ThermalModeProceedBtn not found");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
        }

        [Given(@"all parameters in the Advance OC dialog are changed and not saved")]
        public void ChangeNoSaveGPUvalue()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "the ThermalModeAdvancedBtn not found");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "the ThermalModeProceedBtn not found");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
            Assert.True(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetMinus != null, "the GPUOCAreaOffset Minus and Plus not found");
            WindowsElement element = _nerveCenterPages.GPUOCAreaOffsetPlus != null ? _nerveCenterPages.GPUOCAreaOffsetPlus : _nerveCenterPages.GPUOCAreaOffsetMinus;
            Assert.IsNotNull(element, "the GPUOCAreaOffset Plus or Minus not found");
            element.Click();
        }

        [Then(@"Two values should be (.*) consistent")]
        public void ItconsistentOCvalues(string p0)
        {
            _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            WindowsElement element = _nerveCenterPages.GPUOCAreaOffsetPlus != null ? _nerveCenterPages.GPUOCAreaOffsetPlus : _nerveCenterPages.GPUOCAreaOffsetMinus;
            string OCvalueText = System.Text.RegularExpressions.Regex.Replace(element.Text, @"[^0-9]+", "");
            Assert.IsNotNull(element, "the GPUOCAreaOffset Plus or Minus not found");
            string gpuValue = _gamingThermalModePages.GetGPUOCValue();
            Dictionary<string, string> xtuValues = null;
            if (_supportXtu)
            {
                xtuValues = _gamingThermalModePages.GetXtuOCValueFromXtuTool();
            }
            List<OCValueItem> cpuOcValueItem = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuOCListPath);
            string defaultVal = string.Empty;
            string currentMachineType = VantageCommonHelper.GetCurrentMachineType();

            foreach (string machineType in NerveCenterHelper.GetGPUInformation("Y750IN").Keys)
            {
                if (currentMachineType == machineType)
                {
                    defaultVal = NerveCenterHelper.GetGPUInformation("Y750IN").DefaultVal;
                    break;
                }
            }

            foreach (string machineType in NerveCenterHelper.GetGPUInformation("Y750sIN").Keys)
            {
                if (currentMachineType == machineType)
                {
                    defaultVal = NerveCenterHelper.GetGPUInformation("Y750sIN").DefaultVal;
                    break;
                }
            }

            foreach (string machineType in NerveCenterHelper.GetGPUInformation("T750").Keys)
            {
                if (currentMachineType == machineType)
                {
                    defaultVal = NerveCenterHelper.GetGPUInformation("T750").DefaultVal;
                    break;
                }
            }

            if (p0.ToLower().Equals("not"))
            {
                Assert.AreNotEqual(Convert.ToDouble(OCvalueText), Convert.ToDouble(gpuValue));
            }
            else if (p0.ToLower().Equals("yes"))
            {
                Assert.AreEqual(Convert.ToDouble(OCvalueText), Convert.ToDouble(gpuValue) / 1000);
            }
            else if (p0.ToLower().Equals("default"))
            {
                Assert.AreEqual(Convert.ToDouble(gpuValue) / 1000, Convert.ToDouble(defaultVal));
                double DefaultValue = 0;
                foreach (OCValueItem cpuOCValueItem in cpuOcValueItem)
                {
                    string ocItemName = cpuOCValueItem.Name.Trim().ToLower();
                    string getToolOcValue = string.Empty;
                    xtuValues?.TryGetValue(ocItemName, out getToolOcValue);
                    DefaultValue = Convert.ToDouble(cpuOCValueItem.OCValue);
                    switch (ocItemName)
                    {
                        case "1 active core":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "2 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "3 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "4 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "5 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "6 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "7 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "8 active cores":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "core voltage offset":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "avx ratio offset":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "processor cache ratio":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheRatioLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "cache voltage offset":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "core iccmax":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "cache voltage":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "cache iccmax":
                            Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheICCMAXLevelDefault.Text.Split(' ')[0]), DefaultValue);
                            break;
                        case "gpu core offset":
                            break;
                        case "core 1":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.OneCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 2":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.TwoCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 3":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.ThreeCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 4":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.FourCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 5":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.FiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 6":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.SixCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 7":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.SevenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 8":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.EightCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 9":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.NineCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core 10":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.TenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "core voltage":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.CoreVoltageLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        case "processor core iccmax":
                            Assert.AreEqual(double.Parse(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Split(' ')[0].Trim()), DefaultValue);
                            break;
                        default:
                            Assert.Fail("Please input 1-8 Active Cores, Core Voltage Offset, AVX Ratio Offset, Cache Ratio, Cache Voltage Offset, Core ICCMAX, Cache Voltage or Cache ICCMAX.info:" + ocItemName);
                            break;
                    }
                }
            }
        }

        [Given(@"set to default OC values")]
        public void SetDefault()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault, "The OverclockSetToDefault not found");
            _nerveCenterPages.OverclockSetToDefault.Click();
            Assert.IsNotNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn not found");
            _nerveCenterPages.SetToDefaultOkBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn, "The OverclockCloseBtn not found");
            _nerveCenterPages.OverclockCloseBtn.Click();
        }


        [Given(@"click set to default OC values")]
        public void ClickSetDefault()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalMode, "The ThermalMode not found");
            _nerveCenterPages.ThermalMode.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "The ThermalModeAdvancedBtn not found");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "The ThermalModeProceedBtn not found");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault, "The OverclockSetToDefault not found");
            _nerveCenterPages.OverclockSetToDefault.Click();
            Assert.IsNotNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn not found");
            _nerveCenterPages.SetToDefaultOkBtn.Click();
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn, "The OverclockCloseBtn not found");
            _nerveCenterPages.OverclockCloseBtn.Click();
        }

        [Given(@"mouse hover the all clickable areas and elements")]
        public void HoverClickableArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.True(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetMinus != null, "the GPUOCAreaOffset Minus and Plus not found");
            WindowsElement element = _nerveCenterPages.GPUOCAreaOffsetPlus != null ? _nerveCenterPages.GPUOCAreaOffsetPlus : _nerveCenterPages.GPUOCAreaOffsetMinus;
            Assert.IsNotNull(element, "the GPUOCAreaOffset Plus or Minus not found");
            VantageCommonHelper.HoverOnElement(element, true);
        }
    }
}
