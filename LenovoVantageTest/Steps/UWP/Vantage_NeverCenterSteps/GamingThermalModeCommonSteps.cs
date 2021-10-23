using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingThermalModeCommonSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private NerveCenterPages _nerveCenterPages;
        private GamingThermalModePages _thermalModePages;

        public GamingThermalModeCommonSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"Thermal Mode is existing in LEGION EDGE")]
        public void ThenThermalModeIsExistingInLEGIONEDGE()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
        }

        [Given(@"The Machine support Specific function '(.*)'")]
        public void GivenTheMachineSupportSpecificFunction(NerveCenterHelper.GamingFeature function)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            bool support = NerveCenterHelper.GetGamingFeatureIsSupport(function, familyname);
            Assert.IsTrue(support, "The machine doesn't support this function:" + function.ToString() + " familyname:" + familyname);
        }

        [When(@"user click new thermal mode button")]
        public void WhenUserClickNewThermalModeButton()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.ThermalMode, "The legion edge new thermal mode button not found");
            _nerveCenterPages.ThermalMode.Click();
        }

        [Then(@"The Thermal Mode is shown in Legion Edge")]
        public void ThenTheThermalModeIsShownInLegionEdge()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            NerveCenterHelper.GamingFeatureValues thermalModeNew = machine.GetValues(machine.GamingLegionEdge.ThermalMode);
            if (thermalModeNew.Value.ToLower() == "new")
            {
                if (_nerveCenterPages.LegionEdgeThermalModeNewPerformance != null || _nerveCenterPages.LegionEdgeThermalModeNewBalance != null || _nerveCenterPages.LegionEdgeThermalModeNewQuiet != null)
                {
                    Assert.IsTrue(_session.PageSource.Contains(thermalModeNew.Text), "The ThermalModeNew Text not found!");
                    Assert.IsTrue(true); //Assert.Pass();
                }
                else
                {
                    Assert.Fail("The LegionEdgeThermalModeNew not found!");
                }
            }
            else
            {
                Assert.Fail("The ThermalModeNew Config Value error!");
            }
        }

        [Then(@"The LEGION EDGE Section priority is displayed correctly")]
        public void ThenTheLEGIONEDGESectionPriorityIsDisplayedCorrectly()
        {
            //CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock
            WindowsElement element = null;
            _nerveCenterPages = new NerveCenterPages(_session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            List<string> priority = machine.GamingLegionEdge.Priority;
            NerveCenterHelper.GamingFeatureValues cpuOverclock = machine.GetValues(machine.GamingLegionEdge.CPUOverclock);
            NerveCenterHelper.GamingFeatureValues thermalModeNew = machine.GetValues(machine.GamingLegionEdge.ThermalMode);
            NerveCenterHelper.GamingFeatureValues ramOverclock = machine.GetValues(machine.GamingLegionEdge.RAMOverclock);
            NerveCenterHelper.GamingFeatureValues networkBoost = machine.GetValues(machine.GamingLegionEdge.NetworkBoost);
            NerveCenterHelper.GamingFeatureValues autoClose = machine.GetValues(machine.GamingLegionEdge.AutoClose);
            NerveCenterHelper.GamingFeatureValues hybridMode = machine.GetValues(machine.GamingLegionEdge.HybridMode);
            NerveCenterHelper.GamingFeatureValues overDrive = machine.GetValues(machine.GamingLegionEdge.OverDrive);
            NerveCenterHelper.GamingFeatureValues touchpadLock = machine.GetValues(machine.GamingLegionEdge.TouchpadLock);
            Console.WriteLine("Info:Legion Edge priority Before >>" + string.Join(";", priority));

            if (cpuOverclock.Support == false)
            {
                priority.Remove(cpuOverclock.Text);
            }
            if (thermalModeNew.Support == false)
            {
                priority.Remove(thermalModeNew.Text);
            }
            else
            {
                if (_nerveCenterPages.LegionEdgeThermalModeNewPerformance != null)
                {
                    element = _nerveCenterPages.LegionEdgeThermalModeNewPerformance;
                }
                else if (_nerveCenterPages.LegionEdgeThermalModeNewBalance != null)
                {
                    element = _nerveCenterPages.LegionEdgeThermalModeNewBalance;
                }
                else if (_nerveCenterPages.LegionEdgeThermalModeNewQuiet != null)
                {
                    element = _nerveCenterPages.LegionEdgeThermalModeNewQuiet;
                }
            }
            if (ramOverclock.Support == false)
            {
                priority.Remove(ramOverclock.Text);
            }
            if (networkBoost.Support == false)
            {
                priority.Remove(networkBoost.Text);
            }
            if (autoClose.Support == false)
            {
                priority.Remove(autoClose.Text);
            }
            if (hybridMode.Support == false)
            {
                priority.Remove(hybridMode.Text);
            }
            if (overDrive.Support == false)
            {
                priority.Remove(overDrive.Text);
            }
            if (touchpadLock.Support == false)
            {
                priority.Remove(touchpadLock.Text);
            }

            if (element != null)
            {
                priority.Remove(thermalModeNew.Text);
                Console.WriteLine("Info:Legion Edge Remove >>" + thermalModeNew.Text);
                Assert.Less(element.Location.Y, _nerveCenterPages.LegionEdgeNetworkBoostIcon.Location.Y, "The Thermal Mode Position show incorrect");
            }
            Console.WriteLine("Info:Legion Edge priority After >>" + string.Join(";", priority));
            Assert.NotZero(_nerveCenterPages.GamingLegionEdgeList.Count, "The Legion Edge list get fail");
            foreach (var item in _nerveCenterPages.GamingLegionEdgeList)
            {
                Console.WriteLine(item.GetAttribute("Name"));
            }
            for (int i = 0; i < priority.Count; i++)
            {
                if (priority.Count == _nerveCenterPages.GamingLegionEdgeList.Count && _nerveCenterPages.GamingLegionEdgeList[i].GetAttribute("Name").Contains(priority[i]))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.Fail("Error Info:" + priority[i] + " >> " + _nerveCenterPages.GamingLegionEdgeList[i].GetAttribute("Name"));
                }
            }
        }

        [Then(@"The Thermal Mode Setting popup is shown or hidden '(.*)'")]
        public void ThenTheThermalModeSettingPopupIsShownOrHidden(string status)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    Assert.NotNull(_thermalModePages.ThermalModeQuietSettingsPopup, "The Thermal Mode Settings popup not found");
                    Assert.NotNull(_thermalModePages.ThermalModeBananceInSettingsCloseBtn, "The Thermal Mode Settings popup close btn not found");
                    break;
                case "hidden":
                    Assert.IsNull(_thermalModePages.ThermalModeQuietSettingsPopupDismiss, "The Thermal Mode Settings popup show");
                    break;
                default:
                    Assert.Fail("ThenTheThermalModeSettingPopupIsShownOrHidden() not run");
                    break;
            }
        }

        [Given(@"Show Warn Info '(.*)'")]
        public void GivenShowWarnInfo(string p0)
        {
            Assert.Warn(p0);
        }

        [Then(@"Thermal Mode Setting All the descriptions are consistent with the gaming designed descriptions")]
        public void ThenThermalModeSettingAllTheDescriptionsAreConsistentWithTheGamingDesignedDescriptions(Table table)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            bool gpusupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.GPUOverclockNew, familyname);
            bool gpucpusupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.CPUGPUOverclockNew, familyname);
            bool twomode = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.ThermalModeOnlyTwoMode, familyname);
            bool notsupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.NotSupportOverclock, familyname);
            string section = string.Empty;
            string desc = string.Empty;
            for (int i = 0; i < table.RowCount; i++)
            {
                section = table.Rows[i][0].Trim();
                desc = table.Rows[i][1].Trim();
                switch (section)
                {
                    case "popupTitle":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsTitle.Text, "ThermalModeSettings popupTitle text incorrect");
                        break;
                    case "popupDescCommon":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsDescriptionCommon.Text, "ThermalModeSettings popupDescCommon text incorrect");
                        break;
                    case "popupDescFNQ":
                        if (machine.Type == "NB")
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsDescriptionFnQ.Text, "ThermalModeSettings popupDescFNQ text incorrect");
                        }
                        else if (machine.Type == "DT")
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.Fail("The machine type incorrect,Info:" + familyname);
                        }
                        break;
                    case "performanceTitle":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsPerformanceTitle.Text, "ThermalModeSettings performanceTitle text incorrect");
                        break;
                    case "performanceDescNB":
                        if (machine.Type == "NB")
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsPerformanceDescription.Text, "ThermalModeSettings performanceDesc NB text incorrect");
                        }
                        else if (machine.Type == "DT")
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.Fail("The machine type incorrect,Info:" + familyname);
                        }
                        break;
                    case "performanceDescDT":
                        if (machine.Type == "DT")
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsPerformanceDescription.Text, "ThermalModeSettings performanceDesc DT text incorrect");
                        }
                        else if (machine.Type == "NB")
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.Fail("The machine type incorrect,Info:" + familyname);
                        }
                        break;
                    case "enableOCDesc":
                        if (gpucpusupport)
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsEnableOCDescription.Text, "ThermalModeSettings EnableOCDesc text incorrect");
                        }
                        else
                        {
                            Assert.IsTrue(true);
                        }
                        if (notsupport)
                        {
                            Assert.Null(_thermalModePages.ThermalModeSettingsEnableOCDescription, "does not oc,the EnableOCDescription show");
                        }
                        break;
                    case "onlyGPUOCDesc":
                        if (gpusupport)
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsEnableOCDescription.Text, "ThermalModeSettings onlyGPUOCDesc text incorrect");
                        }
                        else
                        {
                            Assert.IsTrue(true);
                        }
                        if (notsupport)
                        {
                            Assert.Null(_thermalModePages.ThermalModeSettingsEnableOCDescription, "does not oc,the EnableOCDescription show");
                        }
                        break;
                    case "balanceTitle":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsBalanceTitle.Text, "ThermalModeSettings balanceTitle text incorrect");
                        break;
                    case "balanceDesc":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsBalanceDescription.Text, "ThermalModeSettings balanceDesc text incorrect");
                        break;
                    case "autoadjustDesc":
                        var element = _thermalModePages.ThermalModeSettingsAutoAdjustCheckBoxDescription;
                        string descEle = _thermalModePages.ShowTextbox(element);
                        Assert.AreEqual(desc, descEle, "ThermalModeSettings balanceTitle text incorrect");
                        break;
                    case "quietTitle":
                        if (twomode)
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsQuietTitle.Text, "ThermalModeSettings quietTitle text incorrect");
                        }
                        break;
                    case "quietDesc":
                        if (twomode)
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsQuietDescription.Text, "ThermalModeSettings quietDesc text incorrect");
                        }
                        break;
                    case "autoswitchDesc":
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsAutoPerformanceSwitchDescription.Text, "ThermalModeSettings AutoPerformanceSwitchDescription text incorrect");
                        break;
                    default:
                        Assert.Fail("ThenThermalModeSettingAllTheDescriptionsAreConsistentWithTheGamingDesignedDescriptions() not run, info:" + section);
                        break;
                }
            }
        }

        [Then(@"It Will show some modes in Thermal Mode Setting popup")]
        public void ThenItWillShowSomeModesInThermalModeSettingPopup(Table table)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            bool twomode = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.ThermalModeOnlyTwoMode, familyname);
            string section = string.Empty;
            string desc = string.Empty;
            for (int i = 0; i < table.RowCount; i++)
            {
                section = table.Rows[i][0].Trim();
                desc = table.Rows[i][1].Trim();
                switch (section)
                {
                    case "performance":
                        Assert.NotNull(_thermalModePages.ThermalModePerformanceInSettings, "The performance not found");
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsPerformanceTitle.Text, "ThermalModeSettings performanceTitle text incorrect");
                        break;
                    case "balance":
                        Assert.NotNull(_thermalModePages.ThermalModeBananceInSettings, "The balance not found");
                        Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsBalanceTitle.Text, "ThermalModeSettings balanceTitle text incorrect");
                        break;
                    case "quiet":
                        if (twomode)
                        {
                            Assert.Null(_thermalModePages.ThermalModeQuietInSettings, "The quiet still show");
                        }
                        else
                        {
                            Assert.NotNull(_thermalModePages.ThermalModeQuietInSettings, "The quiet not found");
                            Assert.AreEqual(desc, _thermalModePages.ThermalModeSettingsQuietTitle.Text, "ThermalModeSettings quietTitle text incorrect");
                        }
                        break;
                    default:
                        Assert.Fail("ThenItWillShowSomeModesInThermalModeSettingPopup() not run");
                        break;
                }
            }
        }

        [Then(@"The specific mode checked or unchecked or shown or hidden for gaming new thermal mode")]
        public void ThenTheSpecificModeCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode(Table table)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            _nerveCenterPages = new NerveCenterPages(_session);
            string mode = table.Rows[0][0].Trim();
            string status = table.Rows[0][1].Trim();  //checked uncheck
            string ispop = table.Rows[0][2].Trim();
            switch (mode.ToLower())
            {
                case "performance":
                    if (ispop.ToLower() == "yes")
                    {
                        Assert.NotNull(_thermalModePages.ThermalModePerformanceInSettings, "The pop window performance not found");
                        if ((_thermalModePages.ThermalModePerformanceInSettings.Selected && status.ToLower() == "checked") || (_thermalModePages.ThermalModePerformanceInSettings.Selected == false && status.ToLower() == "unchecked"))
                        {
                            Assert.IsTrue(true, "The thermal mode select status incorrect." + status);
                        }
                        else
                        {
                            Assert.IsTrue(false, "The thermal mode select status incorrect." + status + ";" + _thermalModePages.ThermalModePerformanceInSettings.Selected);
                        }
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "shown")
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "the legion edge performance not found");
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "hidden")
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "the legion edge performance still show");
                    }
                    else
                    {
                        Assert.Fail("The ThenTheSpecificModeCheckedOrUnchecked() not found");
                    }
                    break;
                case "balance":
                    if (ispop.ToLower() == "yes")
                    {
                        Assert.NotNull(_thermalModePages.ThermalModeBananceInSettings, "The pop window balance not found");
                        if ((_thermalModePages.ThermalModeBananceInSettings.Selected && status.ToLower() == "checked") || (_thermalModePages.ThermalModeBananceInSettings.Selected == false && status.ToLower() == "unchecked"))
                        {
                            Assert.IsTrue(true, "The thermal mode select status incorrect." + status);
                        }
                        else
                        {
                            Assert.IsTrue(false, "The thermal mode select status incorrect." + status + ";" + _thermalModePages.ThermalModeBananceInSettings.Selected);
                        }
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "shown")
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "the legion edge balance not found");
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "hidden")
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "the legion edge balance still show");
                    }
                    else
                    {
                        Assert.Fail("The ThenTheSpecificModeCheckedOrUnchecked() not found");
                    }
                    break;
                case "quiet":
                    if (ispop.ToLower() == "yes")
                    {
                        Assert.NotNull(_thermalModePages.ThermalModeQuietInSettings, "The pop window quiet not found");
                        if ((_thermalModePages.ThermalModeQuiet.Selected && status.ToLower() == "checked") || (_thermalModePages.ThermalModeQuiet.Selected == false && status.ToLower() == "unchecked"))
                        {
                            Assert.IsTrue(true, "The thermal mode select status incorrect." + status);
                        }
                        else
                        {
                            Assert.IsTrue(false, "The thermal mode select status incorrect." + status + ";" + _thermalModePages.ThermalModeQuiet.Selected);
                        }
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "shown")
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "the legion edge quiet not found");
                    }
                    else if (ispop.ToLower() == "no" && status.ToLower() == "hidden")
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "the legion edge quiet still show");
                    }
                    else
                    {
                        Assert.Fail("The ThenTheSpecificModeCheckedOrUnchecked() not found");
                    }
                    break;
                default:
                    Assert.Fail("ThenTheSpecificModeCheckedOrUnchecked() not run");
                    break;
            }
        }

        [When(@"user click Thermal Mode Setting popup other place")]
        public void WhenUserClickThermalModeSettingPopupOtherPlace()
        {
            _thermalModePages = new GamingThermalModePages(_session);
            var element = _thermalModePages.ThermalModeBananceInSettingsCloseBtn;
            int x = element.Location.X + element.Rect.Width + 50;
            int y = element.Location.Y;
            VantageCommonHelper.SetCursorPos(x, y);
            Thread.Sleep(1000);
            VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
            Thread.Sleep(1000);
        }

        [Then(@"The Enable OverClocking checked or unchecked or shown or hidden for gaming new thermal mode '(.*)'")]
        public void ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode(string status)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            bool gpusupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.GPUOverclockNew, familyname);
            bool gpucpusupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.CPUGPUOverclockNew, familyname);
            bool notsupport = NerveCenterHelper.GetGamingFeatureIsSupport(NerveCenterHelper.GamingFeature.NotSupportOverclock, familyname);
            switch (status.ToLower())
            {
                case "shown":
                    if (gpucpusupport || gpusupport)
                    {
                        Assert.NotNull(_thermalModePages.EnableOCCheckboxElement, "The  Enable OverClocking not found");
                    }
                    else
                    {
                        Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    }
                    break;
                case "hidden":
                    if (gpusupport || gpucpusupport)
                    {
                        Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    }
                    else if (notsupport && gpusupport == false && gpucpusupport == false)
                    {
                        Assert.Null(_thermalModePages.EnableOCCheckboxElement, "The  Enable OverClocking still show");
                    }
                    else
                    {
                        Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    }
                    break;
                case "checked":
                    if (gpucpusupport || gpusupport)
                    {
                        Assert.NotNull(_thermalModePages.EnableOCCheckboxElement, "The  Enable OverClocking not found");
                        Assert.AreEqual(System.Windows.Automation.ToggleState.On, _thermalModePages.GetEnableOCStatusInThermalModeSettings(), "the EnableOCCheckbox status incorrect");
                    }
                    else
                    {
                        Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    }
                    break;
                case "unchecked":
                    if (gpusupport || gpucpusupport)
                    {
                        Assert.AreEqual(System.Windows.Automation.ToggleState.Off, _thermalModePages.GetEnableOCStatusInThermalModeSettings(), "the EnableOCCheckbox status incorrect");
                    }
                    else
                    {
                        Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    }
                    break;
                default:
                    Assert.Fail("ThenTheEnableOverClockingCheckedOrUncheckedOrShownOrHiddenForGamingNewThermalMode() parameter incorrect!");
                    break;
            }
        }

        [Then(@"The ADVANCED link button is at the right of Enable OverClocking description")]
        public void ThenTheADVANCEDLinkButtonIsAtTheRightOfEnableOverClockingDescription()
        {
            _thermalModePages = new GamingThermalModePages(_session);
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.Less(_thermalModePages.ThermalModeSettingsEnableOCDescription.Location.X, _nerveCenterPages.ThermalModeAdvancedBtn.Location.X, "The Advance btn Position show incorrect in thermal mode settings");
        }

        [Then(@"The ADVANCED link button should shown or hidden in Performance Mode '(.*)'")]
        public void ThenTheADVANCEDLinkButtonShouldShownOrHiddenInPerformanceMode(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.NotNull(_nerveCenterPages.ThermalModeAdvancedBtn, "the Advanced btn not found!");
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.ThermalModeAdvancedBtn, "the Advanced btn still show!");
                    break;
                default:
                    Assert.Fail("ThenTheADVANCEDLinkButtonShouldShownOrHiddenInPerformanceMode() not run!");
                    break;
            }
        }

        [Then(@"The status of Auto switch toggle is ON or OFF '(.*)'")]
        public void ThenTheStatusOfAutoSwitchToggleIsONOrOFF(string status)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            if (status.ToLower() == "on")
            {
                StringAssert.Contains("toggle_on", _thermalModePages.GetThermalModeAutoPerformanceSwitch.GetAttribute("AutomationId"), "ThenTheStatusOfAutoSwitchToggleIsONOrOFF()");
            }
            else if (status.ToLower() == "off")
            {
                StringAssert.Contains("toggle_off", _thermalModePages.GetThermalModeAutoPerformanceSwitch.GetAttribute("AutomationId"), "ThenTheStatusOfAutoSwitchToggleIsONOrOFF()");
            }
            else
            {
                Assert.Fail("ThenTheStatusOfAutoSwitchToggleIsONOrOFF() parameter incorrect," + status);
            }
        }

        [Then(@"The status of Auto Adjust Checkbox is ON or OFF '(.*)'")]
        public void ThenTheStatusOfAutoAdjustCheckboxIsONOrOFF(string status)
        {
            _thermalModePages = new GamingThermalModePages(_session);
            if (status.ToLower() == "on")
            {
                StringAssert.Contains("checked", _thermalModePages.GetThermalModeAutoAdjustCheckBox.GetAttribute("AutomationId"), "ThestatusofAutoAdjustCheckboxisONorOFF()");
            }
            else if (status.ToLower() == "off")
            {
                StringAssert.Contains("unchecked", _thermalModePages.GetThermalModeAutoAdjustCheckBox.GetAttribute("AutomationId"), "ThestatusofAutoAdjustCheckboxisONorOFF()");
            }
            else
            {
                Assert.Fail("ThenTheStatusOfAutoAdjustCheckboxIsONOrOFF() parameter incorrect," + status);
            }
        }
    }
}
