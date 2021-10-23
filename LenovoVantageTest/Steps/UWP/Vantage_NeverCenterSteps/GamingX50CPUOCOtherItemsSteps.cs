using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingX50CPUOCOtherItemsSteps : SettingsBase
    {

        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string _currentMachineType;
        private IntelligentCoolingBaseHelper _iMCService;
        private Dictionary<string, double> _cpusliderbarvalues = new Dictionary<string, double>();
        private Dictionary<string, double> _lastcpusliderbarvalues = new Dictionary<string, double>();
        private double _previousvalue = 0;
        private double _currentvalue = 0;

        public GamingX50CPUOCOtherItemsSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }


        [Given(@"Machine is Y750 or Y750S or T750")]
        public void GivenMachineIsYOrYS()
        {
            var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            if (currentMachineType.Contains("Legion 7 15IMHg05") || currentMachineType.Contains("Legion 7 15IMH05") || currentMachineType.Contains("Legion Y9000K 2020") || currentMachineType.Contains("Legion Y9000K2020H") || currentMachineType.Contains("Legion S7 15IMH05") || currentMachineType.Contains("Legion Y9000X 2021"))
            {
                _currentMachineType = "Y750";
            }
            else if (currentMachineType.Contains("ZHENGJIUZHE REN9000K-34IMZ") || currentMachineType.Contains("ZHENGJIUZHE REN9000-34IMZ") || currentMachineType.Contains("Legion T7 34IMZ05") || currentMachineType.Contains("Legion T7 34IMZ5"))
            {
                _currentMachineType = "T750";
            }
            else
            {
                Assert.Fail("This machine should support Y750, Y750S and T750.");
            }
        }

        [Given(@"Change Gaming Machine (.*) DPI to (.*)")]
        public void GivenChangeTDPITo(string type, string num)
        {
            switch (type)
            {
                case "T750":
                    if (_currentMachineType == "T750")
                    {
                        VantageCommonHelper.ChangeDPI(num);
                    }
                    break;
                case "VAN21722":
                    VantageCommonHelper.ChangeDPI(num);
                    break;
                default:
                    break;
            }
        }

        [Given(@"In the '(.*)' item, drag the blocker on the slider bar to the '(.*)' level (.*)")]
        public void GivenInTheItemDragTheBlockerOnTheSliderBarToTheLevel(string item, string direction, int level)
        {
            WindowsElement sliderelement = null;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _nerveCenterPages.GetCPUPreCoreOCSlider(_currentMachineType).TryGetValue(item, out sliderelement);
            if (null == sliderelement)
            {
                sliderelement = base.FindElementByTimes(session, "AutomationId", item);
            }
            Assert.NotNull(sliderelement, "The slider not found," + item);
            ScrollScreenToWindowsElement(_webDriver.Session, sliderelement, -30, 10, true);
            int x = sliderelement.Location.X;
            int y = sliderelement.Location.Y + sliderelement.Rect.Height / 2;
            if (level == 0)
            {
                direction = "center";
            }
            if (direction != "far right" && direction != "center" && direction != "far left")
            {
                if (direction.ToLower().Contains("right"))
                {
                    sliderelement.Click();
                    while (level > 0)
                    {
                        SendKeys.SendWait("{UP}");
                        Thread.Sleep(200);
                        level--;
                    }
                }
                else if (direction.ToLower().Contains("left"))
                {
                    sliderelement.Click();
                    while (level > 0)
                    {
                        SendKeys.SendWait("{DOWN}");
                        Thread.Sleep(200);
                        level--;
                    }
                }
                else
                {
                    Assert.Fail("Please input 'left' or 'right' for direction.");
                }
            }
            else
            {
                switch (direction)
                {
                    case "far right":
                        x += sliderelement.Rect.Width - 4;
                        VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());
                        break;
                    case "far left":
                        x += 4;
                        VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());
                        break;
                    case "center":
                        sliderelement.Click();
                        break;
                    default:
                        Assert.Fail("WhenUserDragTheBlockerOnTheSliderBarToTheSpecificLocationInTheCPUOverclock() not run!");
                        break;
                }
            }

            _iMCService = new IntelligentCoolingBaseHelper();
            _iMCService.IntelligentCoolinggIMCServiceControl(3);
            _iMCService.IntelligentCoolinggIMCServiceControl(2);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [Given(@"In the '(.*)' item, click the '(.*)' icon level (.*)")]
        public void GivenInTheItemClickTheIconLevel(string item, string icon, int level)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "-")
            {
                switch (item.ToLower())
                {
                    case "core iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAXMinusIcon);
                        while (level > 0)
                        {
                            _nerveCenterPages.CoreICCMAXMinusIcon.Click();
                            level--;
                        }
                        break;
                    default:
                        Assert.Fail("Please input Core ICCMAX.");
                        break;
                }
            }
        }

        [When(@"Click '(.*)' Times The '(.*)' Icon In The '(.*)' Item")]
        public void WhenClickTimesTheIconInTheItem(int clicktimes, string icon, string key)
        {
            WindowsElement elementicon = null;
            WindowsElement sliderelement = null;
            bool isMinusIcon = (icon == "-") ? true : false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _currentvalue = 0;
            _previousvalue = 0;
            _nerveCenterPages.GetCPUPreCoreOCItemsIcon(isMinusIcon, _currentMachineType).TryGetValue(key, out elementicon);
            Assert.NotNull(elementicon, "The element not found." + key + "; isMinusIcon:" + isMinusIcon);
            _nerveCenterPages.GetCPUPreCoreOCSlider(_currentMachineType).TryGetValue(key, out sliderelement);
            Assert.NotNull(sliderelement, "The slider not found," + key);
            sliderelement.Click();
            _cpusliderbarvalues = _nerveCenterPages.GetCPUPreCoreOCSliderBarValue(_currentMachineType);
            _cpusliderbarvalues.TryGetValue(key, out _previousvalue);   // get slider previous value via + or - icon
            _lastcpusliderbarvalues.Clear();
            foreach (var keyValue in _cpusliderbarvalues)
            {
                _lastcpusliderbarvalues.Add(keyValue.Key, keyValue.Value); //get all slider previous value
            }
            for (int i = 0; i < clicktimes; i++)
            {
                elementicon.Click();
                Thread.Sleep(500);
            }
            _cpusliderbarvalues = _nerveCenterPages.GetCPUPreCoreOCSliderBarValue(_currentMachineType); //get all slider current value 
            _cpusliderbarvalues.TryGetValue(key, out _currentvalue); // get slider current value via + or - icon
        }

        [When(@"Scroll the screen in Overclock Advanced Settings subpage")]
        public void WhenScrollTheScreenInOverclockAdvancedSettingsSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _nerveCenterPages.ScrollScreen();
        }

        [Then(@"The Value Should Be '(.*)' Than Before")]
        public void ThenTheValueShouldBeThanBefore(string action)
        {
            switch (action)
            {
                case "less":
                    Assert.Less(_currentvalue, _previousvalue, "the value should be less than before");
                    break;
                case "larger":
                    Assert.Greater(_currentvalue, _previousvalue, "the value should be larger than before");
                    break;
                case "equal":
                    Assert.AreEqual(_currentvalue, _previousvalue, "The value not Equal.");
                    break;
                default:
                    Assert.Fail("ThenTheValueShouldBeThanBefore() not run");
                    break;
            }
        }

        [Then(@"the '(.*)' value should be the maximum value")]
        public void ThenTheValueShouldBeTheMaximumValue(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            List<OCValueItem> cpuOcValueItem = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuCoreOCListPath);
            double MaxValue = 0;
            foreach (OCValueItem cpuOCValueItem in cpuOcValueItem)
            {
                string ocItemName = cpuOCValueItem.Name.Trim().ToLower();
                if (item.Trim().ToLower().Equals(ocItemName))
                {
                    MaxValue = Convert.ToDouble(cpuOCValueItem.MaxValue);
                    break;
                }
            }
            switch (item.ToLower())
            {
                case "core voltage offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "avx ratio offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "cache ratio":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheRatioLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "cache voltage offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "core iccmax":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "cache voltage":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                case "cache iccmax":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheICCMAXLevelDefault.Text.Split(' ')[0]), MaxValue);
                    break;
                default:
                    Assert.Fail("Please input Core Voltage Offset, AVX Ratio Offset, Cache Ratio, Cache Voltage Offset, Core ICCMAX, Cache Voltage or Cache ICCMAX.");
                    break;
            }
        }

        [Then(@"the '(.*)' value should be the minimize value")]
        public void ThenTheValueShouldBeTheMinimizeValue(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
            List<OCValueItem> cpuOcValueItem = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuCoreOCListPath);
            double MinValue = 0;
            foreach (OCValueItem cpuOCValueItem in cpuOcValueItem)
            {
                string ocItemName = cpuOCValueItem.Name.Trim().ToLower();
                if (item.Trim().ToLower().Equals(ocItemName))
                {
                    MinValue = Convert.ToDouble(cpuOCValueItem.MinValue);
                    break;
                }
            }
            switch (item.ToLower())
            {
                case "core voltage offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "avx ratio offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "cache ratio":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheRatioLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "cache voltage offset":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "core iccmax":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "cache voltage":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheVoltageLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                case "cache iccmax":
                    Assert.AreEqual(Convert.ToDouble(_nerveCenterPages.CacheICCMAXLevelDefault.Text.Split(' ')[0]), MinValue);
                    break;
                default:
                    Assert.Fail("Please input Core Voltage Offset, AVX Ratio Offset, Cache Ratio, Cache Voltage Offset, Core ICCMAX, Cache Voltage or Cache ICCMAX.");
                    break;
            }
        }

        [Then(@"'(.*)' icon should be gery and unclickable for '(.*)'")]
        public void ThenIconShouldBeGeryAndUnclickableFor(string icon, string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "+")
            {
                switch (item.ToLower())
                {
                    case "core voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetPlusIconGrey);
                        break;
                    case "avx ratio offset":
                        Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetPlusIconGrey);
                        break;
                    case "cache ratio":
                        Assert.IsNotNull(_nerveCenterPages.CacheRatioPlusIconGrey);
                        break;
                    case "cache voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffsetPlusIconGrey);
                        break;
                    case "core iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAXPlusIcon);
                        break;
                    case "cache voltage":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltagePlusIcon);
                        break;
                    case "cache iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CacheICCMAXPlusIcon);
                        break;
                    default:
                        var findElement = _nerveCenterPages.FindElementByTimes(_webDriver.Session, "AutomationId", item);
                        Assert.IsNotNull(findElement, string.Format("The {0} Element is null", item));
                        break;
                }
            }
            else if (icon == "-")
            {
                switch (item.ToLower())
                {
                    case "core voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetMinusIconGrey);
                        break;
                    case "avx ratio offset":
                        Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetMinusIconGrey);
                        break;
                    case "cache ratio":
                        Assert.IsNotNull(_nerveCenterPages.CacheRatioMinusIconGrey);
                        break;
                    case "cache voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffsetMinusIconGrey);
                        break;
                    case "core iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAXMinusIcon);
                        break;
                    case "cache voltage":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageMinusIcon);
                        break;
                    case "cache iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CacheICCMAXMinusIcon);
                        break;
                    default:
                        var findElement = _nerveCenterPages.FindElementByTimes(_webDriver.Session, "AutomationId", item);
                        Assert.IsNotNull(findElement, string.Format("The {0} Element is null", item));
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input '+' or '-'.");
            }
        }

        [Then(@"'(.*)' icon should not be grey and clickable for '(.*)'")]
        public void ThenIconShouldNotBeGreyAndClickableFor(string icon, string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (icon == "+")
            {
                switch (item.ToLower())
                {
                    case "core voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetPlusIcon);
                        break;
                    case "avx ratio offset":
                        Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetPlusIcon);
                        break;
                    case "cache ratio":
                        Assert.IsNotNull(_nerveCenterPages.CacheRatioPlusIcon);
                        break;
                    case "cache voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffsetPlusIcon);
                        break;
                    case "core iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAXPlusIcon);
                        break;
                    case "cache voltage":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltagePlusIcon);
                        break;
                    case "cache iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CacheICCMAXPlusIcon);
                        break;
                    default:
                        var findElement = _nerveCenterPages.FindElementByTimes(_webDriver.Session, "AutomationId", item);
                        Assert.IsNotNull(findElement, string.Format("The {0} Element is null", item));
                        break;
                }
            }
            else if (icon == "-")
            {
                switch (item.ToLower())
                {
                    case "core voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffsetMinusIcon);
                        break;
                    case "avx ratio offset":
                        Assert.IsNotNull(_nerveCenterPages.AVXRatioOffsetMinusIcon);
                        break;
                    case "cache ratio":
                        Assert.IsNotNull(_nerveCenterPages.CacheRatioMinusIcon);
                        break;
                    case "cache voltage offset":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffsetMinusIcon);
                        break;
                    case "core iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAXMinusIcon);
                        break;
                    case "cache voltage":
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageMinusIcon);
                        break;
                    case "cache iccmax":
                        Assert.IsNotNull(_nerveCenterPages.CacheICCMAXMinusIcon);
                        break;
                    default:
                        var findElement = _nerveCenterPages.FindElementByTimes(_webDriver.Session, "AutomationId", item);
                        Assert.IsNotNull(findElement, string.Format("The {0} Element is null", item));
                        break;
                }
            }
            else
            {
                Assert.Fail("Please input '+' or '-'.");
            }
        }

        [Then(@"check the Cache Core Voltage offset item value should be consistent")]
        public void ThenCheckTheCacheCoreVoltageOffsetItemValueShouldBeConsistent()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text, _nerveCenterPages.CacheVoltageOffsetLevelDefault.Text);
        }

        [Then(@"check the Cache Core ICCMAX item value should be consistent")]
        public void ThenCheckTheCacheCoreICCMAXItemValueShouldBeConsistent()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(_nerveCenterPages.CoreICCMAXLevelDefault.Text, _nerveCenterPages.CacheICCMAXLevelDefault.Text);
        }

        [Then(@"check the Cache Core Voltage item value should be consistent")]
        public void ThenCheckTheCacheCoreVoltageItemValueShouldBeConsistent()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(_nerveCenterPages.CoreVoltageLevelDefault.Text, _nerveCenterPages.CacheVoltageLevelDefault.Text);
        }

        [Then(@"the '(.*)' value should be the current value")]
        public void ThenTheValueShouldBeTheCurrentValue(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (item.ToLower())
            {
                case "core voltage offset":
                    if (_currentMachineType == "Y750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Contains("0.02 V"), "The current value of Core Voltage offset is 0.02 V.");
                    }
                    else if (_currentMachineType == "T750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Contains("0.12 V"), "The current value of Core Voltage offset is 0.12 V.");
                    }
                    break;
                case "avx ratio offset":
                    Assert.IsTrue(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Contains("18 x"), "The current value of AVX Ratio Offset is 18 x.");
                    break;
                case "cache ratio":
                    if (_currentMachineType == "Y750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CacheRatioLevelDefault.Text.Contains("50 x"), "The current value of 3 Active Core Ratio is 50 x.");
                    }
                    else if (_currentMachineType == "T750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CacheRatioLevelDefault.Text.Contains("49 x"), "The current value of 3 Active Core Ratio is 49 x.");
                    }
                    break;
                case "cache voltage offset":
                    if (_currentMachineType == "Y750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Contains("0.02 V"), "The current value of 4 Active Core Ratio is 0.02 V.");
                    }
                    else if (_currentMachineType == "T750")
                    {
                        Assert.IsTrue(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Contains("0.12 V"), "The current value of 4 Active Core Ratio is 0.12 V.");
                    }
                    break;
                case "core iccmax":
                    Assert.IsTrue(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Contains("228.5 A"), "The current value of Core ICCMAX is 228.5 A.");
                    break;
                case "cache voltage":
                    Assert.IsTrue(_nerveCenterPages.CacheVoltageLevelDefault.Text.Contains("1.28 V"), "The current value of Cache Voltage is 1.28 V.");
                    break;
                case "cache iccmax":
                    Assert.IsTrue(_nerveCenterPages.CacheICCMAXLevelDefault.Text.Contains("228.5 A"), "The current value of Cache ICCMAX is 228.5 A.");
                    break;
                default:
                    Assert.Fail("Please input Core Voltage Offset, AVX Ratio Offset, Cache Ratio, Cache Voltage Offset, Core ICCMAX, Cache Voltage or Cache ICCMAX.");
                    break;
            }
        }

    }
}
