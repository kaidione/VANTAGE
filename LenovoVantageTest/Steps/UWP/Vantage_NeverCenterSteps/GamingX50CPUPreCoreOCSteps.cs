using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingX50CPUPreCoreOCSteps
    {
        private Dictionary<string, double> _cpusliderbarvalues = new Dictionary<string, double>();
        private Dictionary<string, double> _lastcpusliderbarvalues = new Dictionary<string, double>();
        private WindowsDriver<WindowsElement> _session;
        private NerveCenterPages _nerveCenterPages;
        private GamingThermalModePages _gamingThermalModePages;
        private double _previousvalue = 0;
        private double _currentvalue = 0;

        public GamingX50CPUPreCoreOCSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"The CPU area items should be shown in the Advance OC page")]
        public void ThenTheCPUAreaItemsShouldBeShownInTheAdvanceOCPage(Table table)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "1":  //Core Voltage 
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltage, "The Core Voltage not found");
                        break;
                    case "2":   // 1 - 10 Core Ratio
                        Assert.IsNotNull(_nerveCenterPages.OneCoreRatio, "The 1 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.TwoCoreRatio, "The 2 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatio, "The 3 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.FourCoreRatio, "The 4 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.FiveCoreRatio, "The 5 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.SixCoreRatio, "The 6 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.SevenCoreRatio, "The 7 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.EightCoreRatio, "The 8 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.NineCoreRatio, "The 9 Core Ratio not found");
                        Assert.IsNotNull(_nerveCenterPages.TenCoreRatio, "The 10 Core Ratio not found");
                        break;
                    case "3":   //Core Voltage offset
                        Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffset, "The Core Voltage offset not found");
                        break;
                    case "4":   //Core ICCMAX 
                        Assert.IsNotNull(_nerveCenterPages.CoreICCMAX, "The Core ICCMAX not found");
                        break;
                    case "5":   //AVX Ratio offset
                        Assert.IsNotNull(_nerveCenterPages.AvxRatioOffset, "The AVX Ratio offset not found");
                        break;
                    case "6":   // Cache Ratio 
                        Assert.IsNotNull(_nerveCenterPages.CacheRatio, "The Cache Ratio not found");
                        break;
                    case "7":   //Cache Voltage 
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltage, "The Cache Voltage not found");
                        break;
                    case "8":   //Cache Voltage offset
                        Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffset, "The Cache Voltage offset not found");
                        break;
                    case "9":   //Cache ICCMAX
                        Assert.IsNotNull(_nerveCenterPages.CacheICCMAX, "The Cache ICCMAX not found");
                        break;
                    case "10":  //1-10 Core Ratio,the slider bar ' - ' icon and '+' icon 
                        Assert.IsNotNull(_nerveCenterPages.OneCoreRatioSlider, "The 1 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.TwoCoreRatioSlider, "The 2 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatioSlider, "The 3 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.FourCoreRatioSlider, "The 4 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.FiveCoreRatioSlider, "The 5 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.SixCoreRatioSlider, "The 6 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.SevenCoreRatioSlider, "The 7 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.EightCoreRatioSlider, "The 8 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.NineCoreRatioSlider, "The 9 Core Ratio slider not found");
                        Assert.IsNotNull(_nerveCenterPages.TenCoreRatioSlider, "The 10 Core Ratio slider not found");

                        Assert.IsNotNull(_nerveCenterPages.OneCoreRatioMinusIcon, "The 1 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.TwoCoreRatioMinusIcon, "The 2 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatioMinusIcon, "The 3 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.FourCoreRatioMinusIcon, "The 4 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.FiveCoreRatioMinusIcon, "The 5 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.SixCoreRatioMinusIcon, "The 6 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.SevenCoreRatioMinusIcon, "The 7 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.EightCoreRatioMinusIcon, "The 8 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.NineCoreRatioMinusIcon, "The 9 Core Ratio minus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.TenCoreRatioMinusIcon, "The 10 Core Ratio minus icon not found");

                        Assert.IsNotNull(_nerveCenterPages.OneCoreRatioPlusIcon, "The 1 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.TwoCoreRatioPlusIcon, "The 2 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatioPlusIcon, "The 3 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.FourCoreRatioPlusIcon, "The 4 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.FiveCoreRatioPlusIcon, "The 5 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.SixCoreRatioPlusIcon, "The 6 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.SevenCoreRatioPlusIcon, "The 7 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.EightCoreRatioPlusIcon, "The 8 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.NineCoreRatioPlusIcon, "The 9 Core Ratio plus icon not found");
                        Assert.IsNotNull(_nerveCenterPages.TenCoreRatioPlusIcon, "The 10 Core Ratio plus icon not found");
                        break;
                    default:
                        Assert.Fail("ThenTheCPUAreaEighteenItemsShouldBeShownInTheAdvanceOCPage() not run");
                        break;
                }
            }
        }

        [Then(@"The '(.*)' value in the CPU Overclock area should be same and consistent with Spec definition '(.*)'")]
        public void ThenTheValueInTheCPUOverclockAreaShouldBeSameAndConsistentWithSpecDefinition(string slider, string value)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            _gamingThermalModePages = new GamingThermalModePages(_session);
            GivenGetSliderBarValueInTheCPUOverclock();
            if (value == "Default" || value == "MaxValue" || value == "MinValue")
            {
                List<OCValueItem> CPUOCValues = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuCoreOCListPath);
                List<OCValueItem> DefaultCPUOCValues = _gamingThermalModePages.GetOCValueListByFaimlyname(_gamingThermalModePages.CpuOCListPath);
                double ValueTemp = 0;
                bool existflag = false;
                foreach (OCValueItem valueItem in CPUOCValues)
                {
                    string tag = (slider.ToLower().Contains("core ratio") ? true : false) ? "core " + System.Text.RegularExpressions.Regex.Replace(slider, @"[^0-9]+", "") : slider.ToLower();
                    if (valueItem.Name.ToLower() == tag && value != "Default")
                    {
                        switch (value)
                        {
                            case "MaxValue":
                                ValueTemp = Convert.ToDouble(valueItem.MaxValue);
                                existflag = true;
                                break;
                            case "MinValue":
                                ValueTemp = Convert.ToDouble(valueItem.MinValue);
                                existflag = true;
                                break;
                            default:
                                Assert.Warn("the ThenTheValueInTheCPUOverclockAreaShouldBeSameAndConsistentWithSpecDefinition(),the parameter not found");
                                break;
                        }
                        break;
                    }
                    else if (valueItem.Name.ToLower() == tag && value == "Default")
                    {
                        tag = (slider.ToLower().Contains("core iccmax") || slider.ToLower().Contains("cache ratio")) ? "processor " + tag : tag;
                        foreach (OCValueItem defaultValue in DefaultCPUOCValues)
                        {
                            if (defaultValue.Name.ToLower() == tag)
                            {
                                ValueTemp = Convert.ToDouble(defaultValue.OCValue);
                                existflag = true;
                                break;
                            }
                        }
                    }
                }
                if (!existflag)
                {
                    Assert.Warn("The " + slider + " value not found from OC json file.");
                }
                _cpusliderbarvalues.TryGetValue(slider, out _currentvalue);
                Assert.AreEqual(ValueTemp, _currentvalue, "The " + slider + " incorrect,info:" + value);
            }
            else
            {
                _cpusliderbarvalues.TryGetValue(slider, out _currentvalue);
                Assert.AreEqual(double.Parse(value), _currentvalue, "The " + slider + " incorrect,info:" + value);
            }
        }

        [When(@"user hover specific title in the CPU Overclock area '(.*)'")]
        public void WhenUserHoverSpecificTitleInTheCPUOverclockArea(string title)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.NotNull(_nerveCenterPages.OverclockAdvanceSettingCPUTitle, "The Overclock Advance Setting CPUTitle not found");
            switch (title)
            {
                case "1 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.OneCoreRatio, "The 1 Core Ratio not found");
                    _nerveCenterPages.OneCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.OneCoreRatio);
                    break;
                case "2 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.TwoCoreRatio, "The 2 Core Ratio not found");
                    _nerveCenterPages.TwoCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.TwoCoreRatio);
                    break;
                case "3 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.ThreeCoreRatio, "The 3 Core Ratio not found");
                    _nerveCenterPages.ThreeCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.ThreeCoreRatio);
                    break;
                case "4 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.FourCoreRatio, "The 4 Core Ratio not found");
                    _nerveCenterPages.FourCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.FourCoreRatio);
                    break;
                case "5 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.FiveCoreRatio, "The 5 Core Ratio not found");
                    _nerveCenterPages.FiveCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.FiveCoreRatio);
                    break;
                case "6 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.SixCoreRatio, "The 6 Core Ratio not found");
                    _nerveCenterPages.SixCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SixCoreRatio);
                    break;
                case "7 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.SevenCoreRatio, "The 7 Core Ratio not found");
                    _nerveCenterPages.SevenCoreRatioLevelDefault.Click();
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SevenCoreRatio);
                    break;
                case "8 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.EightCoreRatio, "The 8 Core Ratio not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.EightCoreRatio);
                    break;
                case "9 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.NineCoreRatio, "The 9 Core Ratio not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.NineCoreRatio);
                    break;
                case "10 Core Ratio":
                    Assert.IsNotNull(_nerveCenterPages.TenCoreRatio, "The 10 Core Ratio not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.TenCoreRatio);
                    break;
                case "Core Voltage":
                    Assert.IsNotNull(_nerveCenterPages.CoreVoltage, "The Core Voltage not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CoreVoltage);
                    break;
                case "Cache Voltage":
                    Assert.IsNotNull(_nerveCenterPages.CacheVoltage, "The Cache Voltage not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CacheVoltage);
                    break;
                case "Core Voltage offset":
                    Assert.IsNotNull(_nerveCenterPages.CoreVoltageOffset, "The Core Voltage Offset not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CoreVoltageOffset);
                    break;
                case "Cache Voltage offset":
                    Assert.IsNotNull(_nerveCenterPages.CacheVoltageOffset, "The Cache Voltage offset not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CacheVoltageOffset);
                    break;
                case "Core ICCMAX":
                    Assert.IsNotNull(_nerveCenterPages.CoreICCMAX, "The Core ICCMAX not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CoreICCMAX);
                    break;
                case "Cache ICCMAX":
                    Assert.IsNotNull(_nerveCenterPages.CacheICCMAX, "The Cache ICCMAX not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CacheICCMAX);
                    break;
                case "AVX Ratio offset":
                    Assert.IsNotNull(_nerveCenterPages.AvxRatioOffset, "The AVX Ratio offset not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.AvxRatioOffset);
                    break;
                case "Cache Ratio":
                    Assert.IsNotNull(_nerveCenterPages.CacheRatio, "The AVX Ratio offset not found");
                    _nerveCenterPages.OverclockAdvanceSettingCPUTitle.Click();
                    SendKeys.SendWait("{PGDN}");
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.CacheRatio);
                    break;
                default:
                    Assert.Fail("WhenUserHoverSpecificTitleInTheCPUOverclockArea() not run");
                    break;
            }
            Thread.Sleep(1000);
        }

        [When(@"user drag the '(.*)' blocker on the slider bar to the specific location '(.*)' in the CPU Overclock")]
        public void WhenUserDragTheBlockerOnTheSliderBarToTheSpecificLocationInTheCPUOverclock(string key, string setlocation)
        {
            WindowsElement sliderelement = null;
            int setlevel = 0;
            int maxlevel = 0;
            _nerveCenterPages = new NerveCenterPages(_session);
            _nerveCenterPages.GetCPUPreCoreOCSlider().TryGetValue(key, out sliderelement);
            Assert.NotNull(sliderelement, "The slider not found," + key);
            _lastcpusliderbarvalues.Clear();
            foreach (var keyValue in _cpusliderbarvalues)
            {
                _lastcpusliderbarvalues.Add(keyValue.Key, keyValue.Value); //get all slider previous value
            }
            _cpusliderbarvalues.TryGetValue(key, out _previousvalue);   // get slider previous value via blocker

            //UnManagedAPI.RECT rect = new UnManagedAPI.RECT();  
            //UnManagedAPI.GetWindowRect(UnManagedAPI.GetForegroundWindow(), ref rect);
            //Console.WriteLine(sliderelement.Location.X+","+ sliderelement.Location.Y + sliderelement.Rect.Height);

            int x = sliderelement.Location.X;
            int y = sliderelement.Location.Y + sliderelement.Rect.Height / 2;

            if (setlocation != "right" && setlocation != "center" && setlocation != "left")
            {
                setlevel = int.Parse(setlocation);
                // maxlevel = int.Parse(setlocation.Split('/')[1]);
                VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());   // default left
                // x += (sliderelement.Rect.Width - 4) / maxlevel * setlevel;
                //VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());   // set level
                //VantageCommonHelper.SetCursorPos(x,y);
                //VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                //VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                /**/
                do
                {
                    SendKeys.SendWait("{Right}");
                    Thread.Sleep(500);
                    setlevel--;
                } while (setlevel > 0);
            }
            else
            {
                switch (setlocation)
                {
                    case "right":
                        x += sliderelement.Rect.Width - 4;
                        VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());
                        break;
                    case "left":
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
            GivenGetSliderBarValueInTheCPUOverclock(); //get all slider current value 
            _cpusliderbarvalues.TryGetValue(key, out _currentvalue); // get slider current value via blocker
        }

        [Then(@"The '(.*)' plus icon status '(.*)'or minus icon status '(.*)' in the CPU Overclock area")]
        public void ThenThePlusIconStatusOrMinusIconStatusInTheCPUOverclockArea(string key, string plusiconstatus, string minusiconstatus)
        {
            WindowsElement pluslement = null;
            WindowsElement minuslement = null;
            _nerveCenterPages = new NerveCenterPages(_session);
            _nerveCenterPages.GetCPUPreCoreOCItemsIcon(true).TryGetValue(key, out minuslement);
            _nerveCenterPages.GetCPUPreCoreOCItemsIcon(false).TryGetValue(key, out pluslement);
            Assert.NotNull(minuslement, "the " + key + " - icon not found");
            Assert.NotNull(pluslement, "the " + key + " + icon not found");
            Assert.AreEqual(minusiconstatus.ToLower(), minuslement.GetAttribute("AutomationId").Split('_').ToList().Last().ToLower(), "the " + key + " status incorrect" + minusiconstatus);
            Assert.AreEqual(plusiconstatus.ToLower(), pluslement.GetAttribute("AutomationId").Split('_').ToList().Last().ToLower(), "the " + key + " status incorrect" + plusiconstatus);
        }

        [When(@"user click '(.*)' times '(.*)' plus or minus '(.*)' icon in the CPU Overclock area")]
        public void WhenUserClickTimesPlusOrMinusIconInTheCPUOverclockArea(int clicktimes, string key, string icon)
        {
            WindowsElement elementicon = null;
            bool isMinusIcon = (icon == "-") ? true : false;
            _nerveCenterPages = new NerveCenterPages(_session);
            _currentvalue = 0;
            _previousvalue = 0;
            _nerveCenterPages.GetCPUPreCoreOCItemsIcon(isMinusIcon).TryGetValue(key, out elementicon);
            Assert.NotNull(elementicon, "The element not found." + key + "; isMinusIcon:" + isMinusIcon);
            GivenGetSliderBarValueInTheCPUOverclock();
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
            GivenGetSliderBarValueInTheCPUOverclock(); //get all slider current value 
            _cpusliderbarvalues.TryGetValue(key, out _currentvalue); // get slider current value via + or - icon
        }

        [Then(@"the value should be less or larger than before in the CPU Overclock area '(.*)'")]
        public void ThenTheValueShouldBeLessOrLargerThanBeforeInTheCPUOverclockArea(string action)
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
                    Assert.Fail("ThenTheValueShouldBeLessOrLargerThanBeforeInTheCPUOverclockArea() not run");
                    break;
            }
        }

        [Then(@"the current silder bar value should be consistent '(.*)'")]
        public void ThenTheCurrentSilderBarValueShouldBeConsistent(string status)
        {
            double value = 0;
            GivenGetSliderBarValueInTheCPUOverclock();
            _cpusliderbarvalues.TryGetValue(status, out value);
            Assert.AreEqual(_currentvalue, value, "The Current Silder Bar Value not Consistent.");
        }

        [Given(@"Get slider bar value in the CPU Overclock")]
        public void GivenGetSliderBarValueInTheCPUOverclock()
        {
            Console.WriteLine("Info: Get slider bar value in the CPU Overclock starting...!");
            _nerveCenterPages = new NerveCenterPages(_session);
            _cpusliderbarvalues.Clear();
            _cpusliderbarvalues.Add("1 Core Ratio", double.Parse(_nerveCenterPages.OneCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("2 Core Ratio", double.Parse(_nerveCenterPages.TwoCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("3 Core Ratio", double.Parse(_nerveCenterPages.ThreeCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("4 Core Ratio", double.Parse(_nerveCenterPages.FourCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("5 Core Ratio", double.Parse(_nerveCenterPages.FiveCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("6 Core Ratio", double.Parse(_nerveCenterPages.SixCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("7 Core Ratio", double.Parse(_nerveCenterPages.SevenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("8 Core Ratio", double.Parse(_nerveCenterPages.EightCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("9 Core Ratio", double.Parse(_nerveCenterPages.NineCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("10 Core Ratio", double.Parse(_nerveCenterPages.TenCoreRatioLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Core Voltage", double.Parse(_nerveCenterPages.CoreVoltageLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Cache Voltage", double.Parse(_nerveCenterPages.CacheVoltageLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Core Voltage offset", double.Parse(_nerveCenterPages.CoreVoltageOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Cache Voltage offset", double.Parse(_nerveCenterPages.CacheVoltageOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Core ICCMAX", double.Parse(_nerveCenterPages.CoreICCMAXLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Cache ICCMAX", double.Parse(_nerveCenterPages.CacheICCMAXLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("AVX Ratio offset", double.Parse(_nerveCenterPages.AVXRatioOffsetLevelDefault.Text.Split(' ')[0].Trim()));
            _cpusliderbarvalues.Add("Cache Ratio", double.Parse(_nerveCenterPages.CacheRatioLevelDefault.Text.Split(' ')[0].Trim()));
            Console.WriteLine("Info: Get slider bar value in the CPU Overclock sucess!");
        }

        [Then(@"the items values should not be changed or changed")]
        public void ThenTheItemsValuesShouldNotBeChangedOrChanged(Table table)
        {
            double lastvalue;
            double currentvalue;
            for (int i = 0; i < table.RowCount; i++)
            {
                _lastcpusliderbarvalues.TryGetValue(table.Rows[0][0], out lastvalue);
                _cpusliderbarvalues.TryGetValue(table.Rows[0][0], out currentvalue);
                bool isChange = (table.Rows[0][1] == "yes") ? true : false;
                if (isChange)
                {
                    Assert.AreNotEqual(lastvalue, currentvalue, "the items values should not be changed or changed," + table.Rows[0][0] + ":" + isChange);
                }
                else
                {
                    Assert.AreEqual(lastvalue, currentvalue, "the items values should not be changed or changed," + table.Rows[0][0] + ":" + isChange);
                }
            }
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext _scenarioContext)
        {
            if (_scenarioContext.ScenarioInfo.Title.Contains("VAN21722") || _scenarioContext.ScenarioInfo.Title.Contains("VAN21720"))
            {
                LogHelper.Logger.Instance.WriteLog("Restart IMC for VAN21722 、VAN21720 Test Cases Start...");
                Common.StopService(VantageConstContent.IMCServiceName);  //Stop IMC Service
                Common.StartService(VantageConstContent.IMCServiceName);  //Start IMC Service
                LogHelper.Logger.Instance.WriteLog("Restart IMC for VAN21722 、VAN21720 Test Cases End...");
            }
        }

    }
}