using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX50CPUPackageCoreOCSteps
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingX50CPUPackageCoreOCSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"click the Thermal mode area")]
        public void GivenClickTheThermalModeArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalMode, "Thermal mode area should not be null.");
            _nerveCenterPages.ThermalMode.Click();
        }

        [Given(@"CPU name and contains the 'K/HK/KF' characters")]
        public void GivenCPUNameAndContainsTheCharacters()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.SaveChangeCloseBtn != null)
            {
                _nerveCenterPages.SaveChangeCloseBtn.Click();
            }
            if (_nerveCenterPages.OverclockCloseBtn != null)
            {
                _nerveCenterPages.OverclockCloseBtn.Click();
                if (_nerveCenterPages.SaveChangeDialogNotSaveBtn != null)
                {
                    _nerveCenterPages.SaveChangeDialogNotSaveBtn.Click();
                }
            }
            if (_nerveCenterPages.GamingDeviceMenu != null)
            {
                _nerveCenterPages.GamingDeviceMenu.Click();
            }
            var cpuInfo = RegistryHelp.GetValueFromRegedit(VantageConstContent.ProcessorName, VantageConstContent.RegistryCentralProcessor);
            Assert.IsTrue(cpuInfo.Contains("HK") || cpuInfo.Contains("K") || cpuInfo.Contains("KF"), "CPU name should contains the 'K/HK/KF' characters,info:" + cpuInfo);
        }

        [Given(@"driver is installed")]
        public void GivenDriverIsInstalled()
        {
            Assert.IsTrue(File.Exists(VantageConstContent.XtuServicePath), "XtuService.exe is not exist.");
            Process[] processes = Process.GetProcessesByName(VantageConstContent.XtuServiceProcess);
            if (processes.Length == 0)
            {
                VantageCommonHelper.ServiceControl(VantageConstContent.XtuServiceName, 0);
            }
        }

        [Given(@"click the Advance OC button in the Thermal mode settings page")]
        public void ClickTheAdvanceOCButtonInTheThermalModeSettingsPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "The Advance OC button in the Thermal mode settings page should not be null.");
            _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            if (_nerveCenterPages.ThermalModeProceedBtn == null)
            {
                Console.WriteLine("Click ThermalModeAdvancedBtn try again...");
                _nerveCenterPages.ThermalModeAdvancedBtn.Click();
            }
        }

        [Given(@"click the proceed button in the Warning dialog")]
        public void GivenClickTheProceedButtonInTheWarningDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.ThermalModeProceedBtn, "The proceed button in the Warning dialog should not be null.");
            _nerveCenterPages.ThermalModeProceedBtn.Click();
        }

        [When(@"click set to default link in the Overclock Advanced Settings page")]
        public void WhenClickSetToDefaultLinkInTheOverclockAdvancedSettingsPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault, "The OverclockSetToDefault element not found");
            _nerveCenterPages.OverclockSetToDefault.Click();
            Assert.IsNotNull(_nerveCenterPages.SetToDefaultOkBtn, "The SetToDefaultOkBtn element not found");
            _nerveCenterPages.SetToDefaultOkBtn.Click();
        }

        [When(@"Hover (.*) Core Ratio/Active Core\(s\) Ratio title")]
        public void WhenHoverCoreRatioActiveCoreSRatioTitle(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.OneActiveCoreRatio);
                    break;
                case "2":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.TwoActiveCoreRatio);
                    break;
                case "3":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.ThreeActiveCoreRatio);
                    break;
                case "4":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.FourActiveCoreRatio);
                    break;
                case "5":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.FiveActiveCoreRatio);
                    break;
                case "6":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.SixActiveCoreRatio);
                    break;
                case "7":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.SevenActiveCoreRatio);
                    break;
                case "8":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.EightActiveCoreRatio);
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [When(@"Hover Core Voltage offset title")]
        public void WhenHoverCoreVoltageOffsetTitle()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.CoreVoltageOffset);
        }

        [When(@"Hover ""(.*)"" title")]
        public void WhenHoverTitle(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.Trim().ToLower())
            {
                case "core voltage offset":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.CoreVoltageOffset);
                    break;
                case "avx ratio offset":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.AvxRatioOffset);
                    break;
                case "cache ratio":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.CacheRatio);
                    break;
                case "cache voltage offset":
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.CacheVoltageOffset);
                    break;
                default:
                    Assert.Fail("Please input Core Voltage Offset, AVX Ratio Offset, Cache Ratio, Cache Voltage Offset.");
                    break;
            }
        }

        [Given(@"In the (.*) core ratio / Active Core Ratio item, drag the blocker on the slider bar to the '(.*)' level (.*)")]
        public void GivenInTheCoreRatioActiveCoreRatioItemDragTheBlockerOnTheSliderBarToTheFarRight(int item, string direction, int level)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(level >= 0 && level <= 12, "Please input level 0-12.");
            if (direction.ToLower().Contains("right"))
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioSlider, "The OneActiveCoreRatioSlider element not found");
                        _nerveCenterPages.OneActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioSlider, "The TwoActiveCoreRatioSlider element not found");
                        _nerveCenterPages.TwoActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioSlider, "The ThreeActiveCoreRatioSlider element not found");
                        _nerveCenterPages.ThreeActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioSlider, "The FourActiveCoreRatioSlider element not found");
                        _nerveCenterPages.FourActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioSlider, "The FiveActiveCoreRatioSlider element not found");
                        _nerveCenterPages.FiveActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioSlider, "The SixActiveCoreRatioSlider element not found");
                        _nerveCenterPages.SixActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioSlider, "The SevenActiveCoreRatioSlider element not found");
                        _nerveCenterPages.SevenActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioSlider, "The EightActiveCoreRatioSlider element not found");
                        _nerveCenterPages.EightActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{UP}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else if (direction.ToLower().Contains("left"))
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioSlider, "The OneActiveCoreRatioSlider element not found");
                        _nerveCenterPages.OneActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioSlider, "The TwoActiveCoreRatioSlider element not found");
                        _nerveCenterPages.TwoActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioSlider, "The ThreeActiveCoreRatioSlider element not found");
                        _nerveCenterPages.ThreeActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioSlider, "The FourActiveCoreRatioSlider element not found");
                        _nerveCenterPages.FourActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioSlider, "The FiveActiveCoreRatioSlider element not found");
                        _nerveCenterPages.FiveActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioSlider, "The SixActiveCoreRatioSlider element not found");
                        _nerveCenterPages.SixActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioSlider, "The SevenActiveCoreRatioSlider element not found");
                        _nerveCenterPages.SevenActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioSlider, "The EightActiveCoreRatioSlider element not found");
                        _nerveCenterPages.EightActiveCoreRatioSlider.Click();
                        while (level > 0)
                        {
                            SendKeys.SendWait("{DOWN}");
                            Thread.Sleep(100);
                            level--;
                        }
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input 'left' or 'right' for direction.");
            }
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"In the (.*) core ratio / Active Core Ratio item, click the '(.*)' icon")]
        public void GivenInTheCoreRatioActiveCoreRatioItemClickTheIcon(int item, string icon)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "+")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioPlusIcon);
                        _nerveCenterPages.OneActiveCoreRatioPlusIcon.Click();
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioPlusIcon);
                        _nerveCenterPages.TwoActiveCoreRatioPlusIcon.Click();
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioPlusIcon);
                        _nerveCenterPages.ThreeActiveCoreRatioPlusIcon.Click();
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioPlusIcon);
                        _nerveCenterPages.FourActiveCoreRatioPlusIcon.Click();
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioPlusIcon);
                        _nerveCenterPages.FiveActiveCoreRatioPlusIcon.Click();
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioPlusIcon);
                        _nerveCenterPages.SixActiveCoreRatioPlusIcon.Click();
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioPlusIcon);
                        _nerveCenterPages.SevenActiveCoreRatioPlusIcon.Click();
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioPlusIcon);
                        _nerveCenterPages.EightActiveCoreRatioPlusIcon.Click();
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else if (icon == "-")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioMinusIcon);
                        _nerveCenterPages.OneActiveCoreRatioMinusIcon.Click();
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioMinusIcon);
                        _nerveCenterPages.TwoActiveCoreRatioMinusIcon.Click();
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioMinusIcon);
                        _nerveCenterPages.ThreeActiveCoreRatioMinusIcon.Click();
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioMinusIcon);
                        _nerveCenterPages.FourActiveCoreRatioMinusIcon.Click();
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioMinusIcon);
                        _nerveCenterPages.FiveActiveCoreRatioMinusIcon.Click();
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioMinusIcon);
                        _nerveCenterPages.SixActiveCoreRatioMinusIcon.Click();
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioMinusIcon);
                        _nerveCenterPages.SevenActiveCoreRatioMinusIcon.Click();
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioMinusIcon);
                        _nerveCenterPages.EightActiveCoreRatioMinusIcon.Click();
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input '+' or '-'.");
            }
        }

        [Then(@"check the CPU area in the Advance OC page")]
        public void ThenCheckTheCPUAreaInTheAdvanceOCPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatio);
            Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffset);
            Assert.IsNotNull(_nerveCenterPages.AvxRatioOffset);
            Assert.IsNotNull(_nerveCenterPages.CacheRatio);
            Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffset);

        }

        [Then(@"check the CPU Core clock area")]
        public void ThenCheckTheCPUCoreClockArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioSlider);
            Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioSlider);

            Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioLevelDefault);
            Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioLevelDefault);

            Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioMinusIcon);
            Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioMinusIcon);

            Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioPlusIcon);
            Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioPlusIcon);

        }

        [Then(@"the (.*) Active Core Ratio default value in the CPU Overclock area should be consistent with Spec definition")]
        public void ThenTheActiveCoreRatioDefaultValueInTheCPUOverclockAreaShouldBeConsistentWithSpecDefinition(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("53"), "The default value of 1 Active Core Ratio is 53.");
                    break;
                case "2":
                    Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("53"), "The default value of 2 Active Core Ratio is 53.");
                    break;
                case "3":
                    Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 3 Active Core Ratio is 50.");
                    break;
                case "4":
                    Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 4 Active Core Ratio is 50.");
                    break;
                case "5":
                    Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 5 Active Core Ratio is 50.");
                    break;
                case "6":
                    Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 6 Active Core Ratio is 50.");
                    break;
                case "7":
                    Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 7 Active Core Ratio is 50.");
                    break;
                case "8":
                    Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatio);
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("50"), "The default value of 8 Active Core Ratio is 50.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [Then(@"the Core Voltage Offset and Cache Voltage Offset default value in the CPU Overclock area should be same and consistent with Spec definition")]
        public void ThenTheCoreVoltageOffsetAndCacheVoltageOffsetDefaultValueInTheCPUOverclockAreaShouldBeSameAndConsistentWithSpecDefinition()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffset);
            Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffset);
            Assert.AreEqual(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text, _nerveCenterPages.CacheVoltageOffsetLevelDefault.Text);
            Assert.IsTrue(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Contains("0"), "The default value of Core Voltage Offset is 0.");
            Assert.IsTrue(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Contains("0"), "The default value of Core Voltage Offset is 0.");
        }

        [Then(@"the ""(.*)"" default value in the CPU Overclock area should be consistent with Spec definition")]
        public void ThenTheDefaultValueInTheCPUOverclockAreaShouldBeConsistentWithSpecDefinition(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.Trim().ToLower())
            {
                case "avx ration offset":
                    Assert.IsNotNull(_nerveCenterPages.AvxRatioOffset);
                    Assert.IsTrue(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Contains("1"), "The default value of AVX Ratio Offset is 1.");
                    break;
                case "cache ratio":
                    Assert.IsNotNull(_nerveCenterPages.CacheRatio);
                    Assert.IsTrue(_nerveCenterPages.CacheRatioLevelDefault.Text.Contains("47"), "The default value of Cache Ratio is 47.");
                    break;
                default:
                    Assert.Fail("Please input 'AVX Ratio Offset or Cache Ratio'.");
                    break;
            }
        }

        [Then(@"the (.*) Active Core Ratio value should be the maximum value")]
        public void ThenTheActiveCoreRatioValueShouldBeTheMaximumValue(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 1 Active Core Ratio is 54.");
                    break;
                case "2":
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 2 Active Core Ratio is 54.");
                    break;
                case "3":
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 3 Active Core Ratio is 54.");
                    break;
                case "4":
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 4 Active Core Ratio is 54.");
                    break;
                case "5":
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 5 Active Core Ratio is 54.");
                    break;
                case "6":
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 6 Active Core Ratio is 54.");
                    break;
                case "7":
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 7 Active Core Ratio is 54.");
                    break;
                case "8":
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("54"), "The maximum value of 8 Active Core Ratio is 54.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [Then(@"the (.*) Active Core Ratio value should be the minimize value")]
        public void ThenTheActiveCoreRatioValueShouldBeTheMinimizeValue(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 1 Active Core Ratio is 42.");
                    break;
                case "2":
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 2 Active Core Ratio is 42.");
                    break;
                case "3":
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 3 Active Core Ratio is 42.");
                    break;
                case "4":
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 4 Active Core Ratio is 42.");
                    break;
                case "5":
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 5 Active Core Ratio is 42.");
                    break;
                case "6":
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 6 Active Core Ratio is 42.");
                    break;
                case "7":
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 7 Active Core Ratio is 42.");
                    break;
                case "8":
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 8 Active Core Ratio is 42.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [Then(@"the (.*) core ratio value should be less than before")]
        public void ThenTheCoreRatioValueShouldBeLessThanBefore(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("52"), "The less value of 1 Active Core Ratio is 52.");
                    break;
                case "2":
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("52"), "The less value of 2 Active Core Ratio is 52.");
                    break;
                case "3":
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 3 Active Core Ratio is 49.");
                    break;
                case "4":
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 4 Active Core Ratio is 49.");
                    break;
                case "5":
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 5 Active Core Ratio is 49.");
                    break;
                case "6":
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 6 Active Core Ratio is 49.");
                    break;
                case "7":
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 7 Active Core Ratio is 49.");
                    break;
                case "8":
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("49"), "The less value of 8 Active Core Ratio is 49.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [Then(@"the (.*) core ratio value should be larger than before")]
        public void ThenTheCoreRatioValueShouldBeLargerThanBefore(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("54"), "The larger value of 1 Active Core Ratio is 54.");
                    break;
                case "2":
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("54"), "The larger value of 2 Active Core Ratio is 54.");
                    break;
                case "3":
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 3 Active Core Ratio is 51.");
                    break;
                case "4":
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 4 Active Core Ratio is 51.");
                    break;
                case "5":
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 5 Active Core Ratio is 51.");
                    break;
                case "6":
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 6 Active Core Ratio is 51.");
                    break;
                case "7":
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 7 Active Core Ratio is 51.");
                    break;
                case "8":
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("51"), "The larger value of 8 Active Core Ratio is 51.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

        [Then(@"'(.*)' icon (.*) should be gery and unclickable")]
        public void ThenIconShouldBeGeryAndUnclickable(string icon, int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "+")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioPlusIconGrey);
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioPlusIconGrey);
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioPlusIconGrey);
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioPlusIconGrey);
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioPlusIconGrey);
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioPlusIconGrey);
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioPlusIconGrey);
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioPlusIconGrey);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else if (icon == "-")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioMinusIconGrey);
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioMinusIconGrey);
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioMinusIconGrey);
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioMinusIconGrey);
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioMinusIconGrey);
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioMinusIconGrey);
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioMinusIconGrey);
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioMinusIconGrey);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input '+' or '-'.");
            }
        }

        [Then(@"'(.*)' icon (.*) should not be grey and clickable")]
        public void ThenIconShouldNotBeGreyAndClickable(string icon, int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "+")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioPlusIcon);
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioPlusIcon);
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioPlusIcon);
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioPlusIcon);
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioPlusIcon);
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioPlusIcon);
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioPlusIcon);
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioPlusIcon);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else if (icon == "-")
            {
                switch (item.ToString())
                {
                    case "1":
                        Assert.IsNotNull(_nerveCenterPages.OneActiveCoreRatioMinusIcon);
                        break;
                    case "2":
                        Assert.IsNotNull(_nerveCenterPages.TwoActiveCoreRatioMinusIcon);
                        break;
                    case "3":
                        Assert.IsNotNull(_nerveCenterPages.ThreeActiveCoreRatioMinusIcon);
                        break;
                    case "4":
                        Assert.IsNotNull(_nerveCenterPages.FourActiveCoreRatioMinusIcon);
                        break;
                    case "5":
                        Assert.IsNotNull(_nerveCenterPages.FiveActiveCoreRatioMinusIcon);
                        break;
                    case "6":
                        Assert.IsNotNull(_nerveCenterPages.SixActiveCoreRatioMinusIcon);
                        break;
                    case "7":
                        Assert.IsNotNull(_nerveCenterPages.SevenActiveCoreRatioMinusIcon);
                        break;
                    case "8":
                        Assert.IsNotNull(_nerveCenterPages.EightActiveCoreRatioMinusIcon);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input '+' or '-'.");
            }
        }

        [Then(@"'(.*)' Core Ratio items values after '(.*)' core ratio should be consistent and is the minimum, the value '(.*)' before is not change")]
        public void ThenAllCoreRatioItemsValuesAfterCoreRatioShouldBeConsistentAndIsTheMinimumTheValueBeforeIsNotChange(string items, string current, string stables)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsFalse(items.Contains(current.Trim()) || stables.Contains(current.Trim()), "The verfied items should not contain current item.");
            foreach (char item in items.Trim())
            {
                switch (item.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "8", "Current item should be 8 Active Core Ratio.");
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 8 Active Core Ratio is 42.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 1 Active Core Ratio is 42.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 2 Active Core Ratio is 42.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 3 Active Core Ratio is 42.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 4 Active Core Ratio is 42.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 5 Active Core Ratio is 42.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 6 Active Core Ratio is 42.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 7 Active Core Ratio is 42.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("42"), "The minimize value of 8 Active Core Ratio is 42.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            foreach (char stable in stables.Trim())
            {
                switch (stable.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "1", "Current item should be 1 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("53"), "The value of 1 Active Core Ratio is 53.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("53"), "The value of 2 Active Core Ratio is 53.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 3 Active Core Ratio is 50.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 4 Active Core Ratio is 50.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 5 Active Core Ratio is 50.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 6 Active Core Ratio is 50.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 7 Active Core Ratio is 50.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 8 Active Core Ratio is 50.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
        }

        [Then(@"'(.*)' Core Ratio items values after '(.*)' core ratio should be consistent, the value '(.*)' before is not change")]
        public void ThenAllCoreRatioItemsValuesAfterCoreRatioShouldBeConsistentTheValueBeforeIsNotChange(string items, string current, string stables)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsFalse(items.Contains(current.Trim()) || stables.Contains(current.Trim()), "The verfied items should not contain current item.");
            WindowsElement element = _nerveCenterPages.OneActiveCoreRatioLevelDefault;
            switch (current.Trim())
            {
                case "1":
                    element = _nerveCenterPages.OneActiveCoreRatioLevelDefault;
                    break;
                case "2":
                    element = _nerveCenterPages.TwoActiveCoreRatioLevelDefault;
                    break;
                case "3":
                    element = _nerveCenterPages.ThreeActiveCoreRatioLevelDefault;
                    break;
                case "4":
                    element = _nerveCenterPages.FourActiveCoreRatioLevelDefault;
                    break;
                case "5":
                    element = _nerveCenterPages.FiveActiveCoreRatioLevelDefault;
                    break;
                case "6":
                    element = _nerveCenterPages.SixActiveCoreRatioLevelDefault;
                    break;
                case "7":
                    element = _nerveCenterPages.SevenActiveCoreRatioLevelDefault;
                    break;
                case "8":
                    element = _nerveCenterPages.EightActiveCoreRatioLevelDefault;
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
            foreach (char item in items.Trim())
            {
                switch (item.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "8", "Current item should be 8 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.AreEqual(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "2":
                        Assert.AreEqual(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "3":
                        Assert.AreEqual(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "4":
                        Assert.AreEqual(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "5":
                        Assert.AreEqual(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "6":
                        Assert.AreEqual(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "7":
                        Assert.AreEqual(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "8":
                        Assert.AreEqual(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
            foreach (char stable in stables.Trim())
            {
                switch (stable.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "1", "Current item should be 1 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("53"), "The value of 1 Active Core Ratio is 53.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("53"), "The value of 2 Active Core Ratio is 53.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 3 Active Core Ratio is 50.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 4 Active Core Ratio is 50.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 5 Active Core Ratio is 50.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 6 Active Core Ratio is 50.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 7 Active Core Ratio is 50.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("50"), "The value of 8 Active Core Ratio is 50.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
        }

        [Then(@"'(.*)' Core Ratio items values before '(.*)' core ratio should be consistent, the value '(.*)' after is not change")]
        public void ThenCoreRatioItemsValuesBeforeCoreRatioShouldBeConsistentTheValueAfterIsNotChange(string stables, string current, string items)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsFalse(items.Contains(current.Trim()) || stables.Contains(current.Trim()), "The verfied items should not contain current item.");
            WindowsElement element = _nerveCenterPages.OneActiveCoreRatioLevelDefault;
            switch (current.Trim())
            {
                case "1":
                    element = _nerveCenterPages.OneActiveCoreRatioLevelDefault;
                    break;
                case "2":
                    element = _nerveCenterPages.TwoActiveCoreRatioLevelDefault;
                    break;
                case "3":
                    element = _nerveCenterPages.ThreeActiveCoreRatioLevelDefault;
                    break;
                case "4":
                    element = _nerveCenterPages.FourActiveCoreRatioLevelDefault;
                    break;
                case "5":
                    element = _nerveCenterPages.FiveActiveCoreRatioLevelDefault;
                    break;
                case "6":
                    element = _nerveCenterPages.SixActiveCoreRatioLevelDefault;
                    break;
                case "7":
                    element = _nerveCenterPages.SevenActiveCoreRatioLevelDefault;
                    break;
                case "8":
                    element = _nerveCenterPages.EightActiveCoreRatioLevelDefault;
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
            foreach (char stable in stables.Trim())
            {
                switch (stable.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "1", "Current item should be 1 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.AreEqual(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "2":
                        Assert.AreEqual(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "3":
                        Assert.AreEqual(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "4":
                        Assert.AreEqual(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "5":
                        Assert.AreEqual(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "6":
                        Assert.AreEqual(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "7":
                        Assert.AreEqual(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    case "8":
                        Assert.AreEqual(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text, element.Text);
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }

            foreach (char item in items.Trim())
            {
                switch (item.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "8", "Current item should be 1 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("48"), "1 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("48"), "2 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("48"), "3 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("48"), "4 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("48"), "5 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("48"), "6 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("48"), "7 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("48"), "8 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
        }

        [Then(@"'(.*)' Core Ratio items values before '(.*)' core ratio should not be changed, the value '(.*)' after is not change")]
        public void ThenCoreRatioItemsValuesBeforeCoreRatioShouldNotBeChangedTheValueAfterIsNotChange(string stables, string current, string items)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsFalse(items.Contains(current.Trim()) || stables.Contains(current.Trim()), "The verfied items should not contain current item.");
            foreach (char stable in stables.Trim())
            {
                switch (stable.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "1", "Current item should be 1 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("53"), "1 Active Core Ratio item value should not be changed and should be default value 53.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("53"), "2 Active Core Ratio item value should not be changed and should be default value 53.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("50"), "3 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("50"), "4 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("50"), "5 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("50"), "6 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("50"), "7 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("50"), "8 Active Core Ratio item value should not be changed and should be default value 50.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }

            foreach (char item in items.Trim())
            {
                switch (item.ToString())
                {
                    case "0":
                        Assert.IsTrue(current.Trim() == "8", "Current item should be 8 Active Core Ratio.");
                        break;
                    case "1":
                        Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("48"), "1 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "2":
                        Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("48"), "2 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "3":
                        Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("48"), "3 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "4":
                        Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("48"), "4 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "5":
                        Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("48"), "5 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "6":
                        Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("48"), "6 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "7":
                        Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("48"), "7 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    case "8":
                        Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("48"), "8 Active Core Ratio item value should not be changed and should be value 48.");
                        break;
                    default:
                        Assert.Fail("Please input number 1-8.");
                        break;
                }
            }
        }

        [Then(@"the value should be the currect value")]
        public void ThenTheValueShouldBeTheCurrectValue()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 1 Active Core Ratio is 54.");
        }

        [Then(@"the (.*) core ratio value should be the currect value")]
        public void ThenTheCoreRatioValueShouldBeTheCurrectValue(int item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToString())
            {
                case "1":
                    Assert.IsTrue(_nerveCenterPages.OneActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 1 Active Core Ratio is 50.");
                    break;
                case "2":
                    Assert.IsTrue(_nerveCenterPages.TwoActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 2 Active Core Ratio is 50.");
                    break;
                case "3":
                    Assert.IsTrue(_nerveCenterPages.ThreeActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 3 Active Core Ratio is 50.");
                    break;
                case "4":
                    Assert.IsTrue(_nerveCenterPages.FourActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 4 Active Core Ratio is 50.");
                    break;
                case "5":
                    Assert.IsTrue(_nerveCenterPages.FiveActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 5 Active Core Ratio is 50.");
                    break;
                case "6":
                    Assert.IsTrue(_nerveCenterPages.SixActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 6 Active Core Ratio is 50.");
                    break;
                case "7":
                    Assert.IsTrue(_nerveCenterPages.SevenActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 7 Active Core Ratio is 50.");
                    break;
                case "8":
                    Assert.IsTrue(_nerveCenterPages.EightActiveCoreRatioLevelDefault.Text.Contains("50"), "The current value of 8 Active Core Ratio is 50.");
                    break;
                default:
                    Assert.Fail("Please input number 1-8.");
                    break;
            }
        }

    }
}