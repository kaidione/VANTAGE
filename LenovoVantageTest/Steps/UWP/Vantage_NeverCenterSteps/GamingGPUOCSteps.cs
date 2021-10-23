using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingGPUOCSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        string iniFilename = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\NerveCenterDocument\\GPUSpec.ini");
        public GamingGPUOCSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"CPU And GPU area should be shown in the Advanced OC page")]
        public void ThenCheckTheCOUGPUAreaInTheAdvanceOCPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.GPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.CPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            Assert.IsNotNull(_nerveCenterPages.AdvancedOCTitle);
            Assert.AreEqual("Overclock Advanced Settings", _nerveCenterPages.AdvancedOCTitle.GetAttribute("Name"));
            Assert.AreEqual("Set advanced custom parameters when Overclocking is on. It could be Risky.", _nerveCenterPages.AdvancedOCContent.GetAttribute("Name"));
        }

        [Then(@"Only GPU area should be shown in the Advanced OC page")]
        public void ThenCheckTheGPUAreaInTheAdvanceOCPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.GPUOCArea);
            Assert.IsNull(_nerveCenterPages.CPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            Assert.IsNotNull(_nerveCenterPages.AdvancedOCTitle);
            Assert.AreEqual("Overclock Advanced Settings", _nerveCenterPages.AdvancedOCTitle.GetAttribute("Name"));
            Assert.AreEqual("Set advanced custom parameters when Overclocking is on. It could be Risky.", _nerveCenterPages.AdvancedOCContent.GetAttribute("Name"));
        }

        [Then(@"GPU Clock Offset should not be shown in Advanced OC Page")]
        public void ThenGPUClockOffsetShouldNotBeShownInAdvancedOCPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.GPUOCAreaClockOffset);
        }

        [Then(@"Only GPU Clock Offset showing in Advanced OC Page")]
        public void ThenCheckTheGPUAreOnlyClockOffsetshowing()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.GPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaClockOffset);
            Assert.IsNull(_nerveCenterPages.GPUOCAreaVRAMClockOffset);
            Assert.IsNull(_nerveCenterPages.CPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            Assert.IsNotNull(_nerveCenterPages.AdvancedOCTitle);
            Assert.AreEqual("Overclock Advanced Settings", _nerveCenterPages.AdvancedOCTitle.GetAttribute("Name"));
            Assert.AreEqual("Set advanced custom parameters when Overclocking is on. It could be Risky.", _nerveCenterPages.AdvancedOCContent.GetAttribute("Name"));
        }

        [Then(@"GPU Clock Offset default value should be consistent with Spec definition")]
        public void ThenClockOffsetDefaultValueConsistentWithSpecDefinition()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }
            Assert.IsNotNull(_nerveCenterPages.OverclockSetToDefault);
            Assert.IsNotNull(_nerveCenterPages.OverclockCloseBtn);
            Assert.IsNotNull(_nerveCenterPages.AdvancedOCTitle);
            Assert.AreEqual("Overclock Advanced Settings", _nerveCenterPages.AdvancedOCTitle.GetAttribute("Name"));
            Assert.AreEqual("Set advanced custom parameters when Overclocking is on. It could be Risky.", _nerveCenterPages.AdvancedOCContent.GetAttribute("Name"));
        }

        [Then(@"Check GPU Core Clock Area")]
        public void ThenCheckGPUCoreClockArea()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GPUOCArea);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaClockOffset);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetSlider);

            int sliderrecX = _nerveCenterPages.GPUOCAreaOffsetSlider.Location.X;
            int sliderrecY = _nerveCenterPages.GPUOCAreaOffsetSlider.Location.Y;

            int minusrecX = _nerveCenterPages.GPUOCAreaOffsetMinus.Location.X;
            int minusrecY = _nerveCenterPages.GPUOCAreaOffsetMinus.Location.Y;

            int plusrecX = 0;
            int plusrecY = 0;

            if (_nerveCenterPages.GPUOCAreaOffsetPlus == null && _nerveCenterPages.GPUOCAreaOffsetPlusUnclickable != null)
            {
                plusrecX = _nerveCenterPages.GPUOCAreaOffsetPlusUnclickable.Location.X;
                plusrecY = _nerveCenterPages.GPUOCAreaOffsetPlusUnclickable.Location.Y;

            }
            else if (_nerveCenterPages.GPUOCAreaOffsetPlus != null)
            {
                plusrecX = _nerveCenterPages.GPUOCAreaOffsetPlus.Location.X;
                plusrecY = _nerveCenterPages.GPUOCAreaOffsetPlus.Location.Y;
            }

            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            int defvalX = _nerveCenterPages.GPUOCAreaOffsetValueDefault30.Location.X;
                            int defvalY = _nerveCenterPages.GPUOCAreaOffsetValueDefault30.Location.Y;
                            //' - ' icon should be shown on the left side of the value ; 
                            Assert.IsTrue((minusrecY == defvalY) && (minusrecX < defvalX));
                            //' + ' icon should be shown  on the right side of the value;
                            Assert.IsTrue((defvalY == plusrecY) && (plusrecX > defvalX));
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            int defvalX = _nerveCenterPages.GPUOCAreaOffsetValueDefault100.Location.X;
                            int defvalY = _nerveCenterPages.GPUOCAreaOffsetValueDefault100.Location.Y;
                            //' - ' icon should be shown on the left side of the value ; 
                            Assert.IsTrue((minusrecY == defvalY) && (minusrecX < defvalX));
                            //' + ' icon should be shown  on the right side of the value;
                            Assert.IsTrue((defvalY == plusrecY) && (plusrecX > defvalX));
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file Or This family has no GPU area");
            }
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetPlus != null || _nerveCenterPages.GPUOCAreaOffsetPlusUnclickable != null);
            Assert.IsTrue((minusrecX > sliderrecX));
        }

        [When(@"Hover the (.*) title")]
        public void WhenHoverGPUOffsetTitle(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.GPUOCAreaClockOffset);
            }
            else if (item == "VRAM Clock Offset")
            {
                VantageCommonHelper.HoverOnVantage(_webDriver.Session, _nerveCenterPages.GPUOCAreaVRAMClockOffset);
            }
            else
            {
                Assert.Fail("GPU OverClock find an section never defined except GPU and VRAM ");
            }

        }

        [When(@"Drag the blocker on the (.*) slider bar to far-left")]
        public void WhenDragSliderBarFarLeft(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus, "_nerveCenterPages.GPUOCAreaOffsetMinus is null");
                _nerveCenterPages.GPUOCAreaOffsetSlider.Click();
                Thread.Sleep(TimeSpan.FromSeconds(3));
                int count = 198;
                while (_nerveCenterPages.GPUOCAreaOffsetMinus != null || count < -1)
                {
                    SendKeys.SendWait("{DOWN}");
                    Thread.Sleep(200);
                    count--;
                }
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinusUnclickable);
            }

        }

        [Then(@"The (.*) value should be the minimize value that consistent with definition")]
        public void ThenCheckMinimumBarValueEqualwithSpecOnFarLeft(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string minimum = inifile.ReadIniData(sec, "minimum", "");
                        if (minimum == "0")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMinium);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMinium.Text.Contains("0"), "The minimum value of GPU Clock Offset is 0.");
                            getdefault = true;
                            break;
                        }
                        if (minimum == "-200")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueminusMinium);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMinium.Text.Contains("-200"), "The minimum value of GPU Clock Offset is -200.");
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the minimum val not in the INI file ");
            }

        }


        [Then(@"The (.*) value should be the maximize value that consistent with definition")]
        public void ThenCheckMamimumBarValueEqualwithSpecOnFarLeft(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string maximum = inifile.ReadIniData(sec, "maximum", "");
                        if (maximum == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum30);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum30.Text.Contains("30"), "The Maximum value of GPU Clock Offset is 30.");
                            getdefault = true;
                            break;
                        }
                        if (maximum == "150")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum150);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum150.Text.Contains("150"), "The Maximum value of GPU Clock Offset is 150.");
                            getdefault = true;
                            break;
                        }
                        if (maximum == "200")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum200);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum200.Text.Contains("200"), "The Maximum value of GPU Clock Offset is 200.");
                            getdefault = true;
                            break;
                        }
                        if (maximum == "300")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum300);
                            Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum300.Text.Contains("300"), "The Maximum  value of GPU Clock Offset is 300.");
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the  Maximum val not in the INI file ");
            }
        }

        [When(@"Drag the blocker on the (.*) slider bar to far-right")]
        public void WhenDragSliderBarFarRight(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                string familyname = VantageCommonHelper.GetCurrentMachineType();
                Assert.IsTrue(File.Exists(iniFilename));
                OperateIniFile inifile = new OperateIniFile(iniFilename);
                List<string> allSection = inifile.ReadSections();
                bool getdefault = false;
                foreach (string sec in allSection)
                {
                    List<string> sectionKeys = inifile.ReadKeys(sec);
                    foreach (string key in sectionKeys)
                    {
                        string keyval = inifile.ReadIniData(sec, key, "");
                        if (keyval == familyname)
                        {
                            string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                            if (defaultval == "30")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                                Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                getdefault = true;
                                break;
                            }
                            if (defaultval == "100")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                _nerveCenterPages.GPUOCAreaOffsetSlider.Click();
                                int count = 202;
                                while (_nerveCenterPages.GPUOCAreaOffsetPlus != null || count < -1)
                                {
                                    SendKeys.SendWait("{UP}");
                                    Thread.Sleep(200);
                                    count--;
                                }
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                        }
                    }
                }
                if (!getdefault)
                {
                    Assert.Fail("Find the default val not in the INI file");
                }
            }

        }

        [When(@"Drag the blocker on the (.*) slider bar to right")]
        public void WhenDragSliderBarRight(string item)
        {
            // press minus until the default value =0 and minus button id change as gpu_clock_offset_minus_icon_unclickable
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                string familyname = VantageCommonHelper.GetCurrentMachineType();
                Assert.IsTrue(File.Exists(iniFilename));
                OperateIniFile inifile = new OperateIniFile(iniFilename);
                List<string> allSection = inifile.ReadSections();
                bool getdefault = false;
                foreach (string sec in allSection)
                {
                    List<string> sectionKeys = inifile.ReadKeys(sec);
                    foreach (string key in sectionKeys)
                    {
                        string keyval = inifile.ReadIniData(sec, key, "");
                        if (keyval == familyname)
                        {
                            string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                            if (defaultval == "30")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                                Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                            if (defaultval == "100")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                _nerveCenterPages.GPUOCAreaOffsetSlider.Click();
                                Thread.Sleep(TimeSpan.FromSeconds(3));
                                int count = 2;
                                while (count > 0)
                                {
                                    SendKeys.SendWait("{UP}");
                                    Thread.Sleep(100);
                                    count--;
                                }
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                getdefault = true;
                                break;
                            }
                        }
                    }
                }
                if (!getdefault)
                {
                    Assert.Fail("Find the default val not in the INI file");
                }
            }

        }

        [When(@"Drag the blocker on the (.*) slider bar to left")]
        public void WhenDragSliderBarLeft(string item)
        {
            // press minus until the default value =0 and minus button id change as gpu_clock_offset_minus_icon_unclickable
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                string familyname = VantageCommonHelper.GetCurrentMachineType();
                Assert.IsTrue(File.Exists(iniFilename));
                OperateIniFile inifile = new OperateIniFile(iniFilename);
                List<string> allSection = inifile.ReadSections();
                bool getdefault = false;
                foreach (string sec in allSection)
                {
                    List<string> sectionKeys = inifile.ReadKeys(sec);
                    foreach (string key in sectionKeys)
                    {
                        string keyval = inifile.ReadIniData(sec, key, "");
                        if (keyval == familyname)
                        {
                            string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                            if (defaultval == "30")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                                _nerveCenterPages.GPUOCAreaOffsetSlider.Click();
                                int count = 2;
                                while (count > 0)
                                {
                                    SendKeys.SendWait("{PGDN}");
                                    count--;
                                }
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                getdefault = true;
                                break;
                            }
                            if (defaultval == "100")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                                _nerveCenterPages.GPUOCAreaOffsetSlider.Click();
                                int count = 2;
                                while (count > 0)
                                {
                                    SendKeys.SendWait("{PGDN}");
                                    count--;
                                }
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                getdefault = true;
                                break;
                            }
                        }
                    }
                }
                if (!getdefault)
                {
                    Assert.Fail("Find the default val not in the INI file");
                }
            }

        }

        [Then(@"The (.*) minus icon should be gery and unclickable plus icon should not be grey and clickable")]
        public void ThenCheckIconsSliderBaronFarLeft(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);

            if (item == "GPU Clock Offset")
            {
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinusUnclickable);
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                string familyname = VantageCommonHelper.GetCurrentMachineType();
                Assert.IsTrue(File.Exists(iniFilename));
                OperateIniFile inifile = new OperateIniFile(iniFilename);
                List<string> allSection = inifile.ReadSections();
                bool getdefault = false;
                foreach (string sec in allSection)
                {
                    List<string> sectionKeys = inifile.ReadKeys(sec);
                    foreach (string key in sectionKeys)
                    {
                        string keyval = inifile.ReadIniData(sec, key, "");
                        if (keyval == familyname)
                        {
                            string minimum = inifile.ReadIniData(sec, "minimum", "");
                            if (minimum == "0")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMinium);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMinium.Text.Contains("0"), "The minimum value of GPU Clock Offset is 0.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinusUnclickable);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                getdefault = true;
                                break;
                            }
                            if (minimum == "-200")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueminusMinium);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMinium.Text.Contains("-200"), "The minimum value of GPU Clock Offset is -200.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinusUnclickable);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                                getdefault = true;
                                break;
                            }
                        }
                    }
                }
                if (!getdefault)
                {
                    Assert.Fail("Find the minimum val not in the INI file ");
                }
            }

        }

        [Then(@"The (.*) plus icon should be gery and unclickable minus icon should not be grey and clickable")]
        public void ThenCheckIconsSliderBaronFarRight(string item)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (item == "GPU Clock Offset")
            {
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                string familyname = VantageCommonHelper.GetCurrentMachineType();
                Assert.IsTrue(File.Exists(iniFilename));
                OperateIniFile inifile = new OperateIniFile(iniFilename);
                List<string> allSection = inifile.ReadSections();
                bool getdefault = false;
                foreach (string sec in allSection)
                {
                    List<string> sectionKeys = inifile.ReadKeys(sec);
                    foreach (string key in sectionKeys)
                    {
                        string keyval = inifile.ReadIniData(sec, key, "");
                        if (keyval == familyname)
                        {
                            string maximum = inifile.ReadIniData(sec, "maximum", "");
                            if (maximum == "30")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum30);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum30.Text.Contains("30"), "The Maximum value of GPU Clock Offset is 30.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                            if (maximum == "150")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum150);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum150.Text.Contains("150"), "The Maximum value of GPU Clock Offset is 150.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                            if (maximum == "200")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum200);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum200.Text.Contains("200"), "The Maximum value of GPU Clock Offset is 200.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                            if (maximum == "300")
                            {
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueMaximum300);
                                Assert.IsTrue(_nerveCenterPages.GPUOCAreaOffsetValueMaximum300.Text.Contains("300"), "The Maximum  value of GPU Clock Offset is 300.");
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
                                Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                                getdefault = true;
                                break;
                            }
                        }
                    }
                }
                if (!getdefault)
                {
                    Assert.Fail("Find the  Maximum val not in the INI file ");
                }
            }

        }

        [Then(@"The value bar should be the current value and the value should be lower than before dragging to left")]
        public void ThenCheckValueBarAfterBragleft()
        {

            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue10);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue80);
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }
        }

        [Then(@"The value bar should be the current value and the value should be greater than before dragging to right")]
        public void ThenCheckValueBarAfterBragright()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue120);
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }
        }

        [Then(@"Minus and plus icon should not be grey and clickable")]
        public void ThenCheckMinusAndPlusIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
        }

        [When(@"Click minus icon of GPU Clock Offset")]
        public void WhenClickMinusIconofGPUClockOffset()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetMinus);
            _nerveCenterPages.GPUOCAreaOffsetMinus.Click();
        }

        [When(@"Click plus icon of GPU Clock Offset")]
        public void WhenClickPlusIconofGPUClockOffset()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);
                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlusUnclickable);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetPlus);
                            _nerveCenterPages.GPUOCAreaOffsetPlus.Click();
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }
        }

        [Then(@"Value bar should minus one")]
        public void ThenCheckValueAfterClickMinus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);

                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue29);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue99);
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }
        }

        [Then(@"Value bar should plus one")]
        public void ThenCheckValueAfterClickPlus()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            Assert.IsTrue(File.Exists(iniFilename));
            OperateIniFile inifile = new OperateIniFile(iniFilename);
            List<string> allSection = inifile.ReadSections();
            bool getdefault = false;
            foreach (string sec in allSection)
            {
                List<string> sectionKeys = inifile.ReadKeys(sec);

                foreach (string key in sectionKeys)
                {
                    string keyval = inifile.ReadIniData(sec, key, "");
                    if (keyval == familyname)
                    {
                        string defaultval = inifile.ReadIniData(sec, "defaultval", "");
                        if (defaultval == "30")
                        {
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault30);
                            getdefault = true;
                            break;
                        }
                        if (defaultval == "100")
                        {
                            Assert.IsNull(_nerveCenterPages.GPUOCAreaOffsetValueDefault100);
                            Assert.IsNotNull(_nerveCenterPages.GPUOCAreaOffsetValue101);
                            getdefault = true;
                            break;
                        }
                    }
                }
            }
            if (!getdefault)
            {
                Assert.Fail("Find the default val not in the INI file");
            }

        }
    }
}

