using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingSegmentLayoutSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private NerveCenterPages _nerveCenterPages;

        public GamingSegmentLayoutSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"The Machine Type is DT or NB '(.*)'")]
        public void GivenTheMachineTypeIsDTOrNB(string type)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            Assert.AreEqual(type, machine.Type, "The machine type is not " + type);
        }

        [Given(@"The Machine is X Series '(.*)'")]
        public void GivenTheMachineIsXSeries(string series)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            Assert.IsTrue(series.ToLower().Contains(machine.Series.ToString().ToLower()), "the machine is not special series." + series);
        }

        [Given(@"Machine is non-Gaming")]
        public void GivenMachineIsNon_Gaming()
        {
            Assert.IsFalse(NerveCenterHelper.GetMachineIsGaming(), "The machine is Gaming machine!");
            Thread.Sleep(2000);
        }

        [Then(@"The system status banner is shown or hidden in homepage '(.*)'")]
        public void ThenTheSystemStatusBannerIsShownOrHiddenInHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    string familyname = VantageCommonHelper.GetCurrentMachineType();
                    NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
                    NerveCenterHelper.GamingFeatureValues gpu = machine.GetValues(machine.GamingLegionStatus.GPU);
                    NerveCenterHelper.GamingFeatureValues cpu = machine.GetValues(machine.GamingLegionStatus.CPU);
                    NerveCenterHelper.GamingFeatureValues info = machine.GetValues(machine.GamingLegionStatus.INFO);
                    NerveCenterHelper.GamingFeatureValues ram = machine.GetValues(machine.GamingLegionStatus.RAM);
                    Assert.NotNull(_nerveCenterPages.GamingSystemStatus, "the GamingSystemStatus not found");
                    Assert.NotNull(_nerveCenterPages.SystemStatusInfoLink, "the SystemStatusInfoLink not found");
                    Assert.IsTrue(_nerveCenterPages.SystemStatusInfoLink.GetAttribute("Name").ToUpper().Contains(info.Text), "the SystemStatusInfoLink Text is incorrect");
                    Assert.NotNull(_nerveCenterPages.SystemStatusGPUInfo, "the SystemStatusGPUInfo not found");
                    Assert.IsTrue(_nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name").ToUpper().Contains(gpu.Text), "the SystemStatusGPUInfo Text is incorrect");
                    Assert.NotNull(_nerveCenterPages.SystemStatusCPUInfo, "the SystemStatusCPUInfo not found");
                    Assert.IsTrue(_nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name").ToUpper().Contains(cpu.Text), "the SystemStatusCPUInfo Text is incorrect");
                    Assert.NotNull(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo not found");
                    Assert.IsTrue(_nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name").ToUpper().Contains(ram.Text), "the SystemStatusRAMInfo Text is incorrect");
                    Assert.NotNull(_nerveCenterPages.SystemStatusDiskInfo, "the SystemStatusDiskInfo not found");
                    Console.WriteLine("Info: System Status banner show");
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.GamingSystemStatus, "the GamingSystemStatus still show");
                    Assert.Null(_nerveCenterPages.SystemStatusInfoLink, "the SystemStatusInfoLink still show");
                    Assert.Null(_nerveCenterPages.SystemStatusGPUInfo, "the SystemStatusGPUInfo still show");
                    Assert.Null(_nerveCenterPages.SystemStatusCPUInfo, "the SystemStatusCPUInfo still show");
                    Assert.Null(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo still show");
                    Assert.Null(_nerveCenterPages.SystemStatusDiskInfo, "the SystemStatusDiskInfo still show");
                    Console.WriteLine("Info: System Status banner hidden");
                    break;
                default:
                    Assert.Fail("ThenTheSystemStatusBannerIsShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [Then(@"The GPU CPU VRAM and HardDisk information should be shown or hidden in homepage '(.*)'")]
        public void ThenGPUCPUVRAMAndHardDiskInformationShouldBeShownOrHiddenInHomepage(string status)
        {
            switch (status.ToLower())
            {
                case "shown":
                    _nerveCenterPages = new NerveCenterPages(_session);
                    ThenTheSystemStatusBannerIsShownOrHiddenInHomepage(status);
                    Assert.IsTrue(_nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name").ToUpper().Contains("VRAM"), "the SystemStatusRAMInfo Text is incorrect");
                    break;
                case "hidden":
                    ThenTheSystemStatusBannerIsShownOrHiddenInHomepage(status);
                    break;
                default:
                    Assert.Fail("ThenGPUCPUVRAMAndHardDiskInformationShouldBeShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [StepDefinition(@"Hover the GPU CPU VRAM or HardDisk area '(.*)'")]
        public void GivenHoverTheGPUCPUVRAMHardDiskArea(string area)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (area.ToLower())
            {
                case "gpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusGPUInfo, "the SystemStatusGPUInfo not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusGPUInfo, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusGPUInfo);
                    break;
                case "cpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusCPUInfo, "the SystemStatusCPUInfo not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusCPUInfo, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusCPUInfo);
                    break;
                case "ram":
                case "vram":
                    Assert.NotNull(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusRAMInfo, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusRAMInfo);
                    break;
                case "harddisk":
                    Assert.NotNull(_nerveCenterPages.SystemStatusDiskInfo, "the SystemStatusDiskInfo not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusDiskInfo, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusDiskInfo);
                    break;
                case "hdd":
                    Assert.NotNull(_nerveCenterPages.SystemStatusDisk0Info, "the SystemStatusDisk0Info not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusDisk0Info, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusDisk0Info);
                    break;
                case "sdd":
                    Assert.NotNull(_nerveCenterPages.SystemStatusDisk1Info, "the SystemStatusDisk1Info not found");
                    VantageCommonHelper.HoverOnElement(_nerveCenterPages.SystemStatusDisk1Info, true);
                    VantageCommonHelper.HoverOnVantage(_session, _nerveCenterPages.SystemStatusDisk1Info);
                    break;
                default:
                    Assert.Fail("GivenHoverTheGPUCPUVRAMHardDiskArea() no run");
                    break;
            }
        }

        [StepDefinition(@"The '(.*)' model Usage rate should be shown or hidden '(.*)'")]
        public void GivenTheModelUsageRateShouldBeShownOrHidden(string model, string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            string info = null;
            switch (model.ToLower())
            {
                case "gpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusGPUInfo, "the SystemStatusGPUInfo not found");
                    info = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name");
                    break;
                case "cpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusCPUInfo, "the SystemStatusCPUInfo not found");
                    info = _nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name");
                    break;
                case "vram":
                    Assert.NotNull(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo not found");
                    info = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name");
                    break;
                default:
                    Assert.Fail("GivenTheModelUsageRateShouldBeShownOrHidden() no run," + model);
                    break;
            }
            switch (status.ToLower())
            {
                case "shown":
                    Assert.AreEqual(true, info.Contains("Used"), "The Usage rate not shown," + model);
                    break;
                case "hidden":
                    Assert.AreEqual(false, info.Contains("Used"), "The Usage rate still shown," + model);
                    break;
                default:
                    Assert.Fail("GivenTheModelUsageRateShouldBeShownOrHidden() no run," + status);
                    break;
            }
        }

        [StepDefinition(@"The GPU CPU VRAM or HardDisk model should be consistent with '(.*)' name in the Task manager")]
        public void GivenTheGPUCPUVRAMOrHardDiskModelShouldBeConsistentWithNameInTheTaskManager(string type)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            string vantageName = string.Empty;
            switch (type.ToLower())
            {
                case "gpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusGPUInfo, "the SystemStatusGPUInfo not found");
                    Console.WriteLine("Info:" + _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name"));
                    vantageName = _nerveCenterPages.SystemStatusGPUInfo.GetAttribute("Name").Split(new string[] { "Model :", "Frequency :" }, StringSplitOptions.None)[1].Trim();
                    Assert.AreEqual(vantageName, NerveCenterHelper.GetGPUCPURAMInfoCorrect(vantageName, "GPU"), "The GPU model should not consistent with gpu namein the Task manager");
                    break;
                case "cpu":
                    Assert.NotNull(_nerveCenterPages.SystemStatusCPUInfo, "the SystemStatusCPUInfo not found");
                    Console.WriteLine("Info:" + _nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name"));
                    vantageName = _nerveCenterPages.SystemStatusCPUInfo.GetAttribute("Name").Split(new string[] { "Model :", "Frequency :" }, StringSplitOptions.None)[1].Trim();
                    Assert.AreEqual(vantageName, NerveCenterHelper.GetGPUCPURAMInfoCorrect(vantageName, "CPU"), "The CPU model should not consistent with cpu namein the Task manager");
                    break;
                case "ram":
                    Assert.NotNull(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo not found");
                    Console.WriteLine("Info:" + _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name"));
                    vantageName = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name").Split(new string[] { "Model :", "Frequency :" }, StringSplitOptions.None)[1].Trim();
                    Assert.AreEqual(vantageName, NerveCenterHelper.GetGPUCPURAMInfoCorrect(vantageName, "RAM"), "The RAM model should not consistent with ram namein the Task manager");
                    break;
                case "vram":
                    Assert.NotNull(_nerveCenterPages.SystemStatusRAMInfo, "the SystemStatusRAMInfo not found");
                    Console.WriteLine("Info:" + _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name"));
                    vantageName = _nerveCenterPages.SystemStatusRAMInfo.GetAttribute("Name").Split(new string[] { "Model :", "Frequency :" }, StringSplitOptions.None)[1].Trim();
                    Assert.AreEqual(vantageName, NerveCenterHelper.GetGPUCPURAMInfoCorrect(vantageName, "VRAM"), "The GPU model should not consistent with gpu namein the Task manager");
                    break;
                case "harddisk":
                    Assert.Warn("GivenTheGPUCPUVRAMOrHardDiskModelShouldBeConsistentWithNameInTheTaskManager() temp code,info:" + type);
                    Assert.NotNull(_nerveCenterPages.SystemStatusDiskInfo, "the SystemStatusDiskInfo not found");
                    //Assert.AreEqual(vantageName,NerveCenterHelper.GetGPUCPURAMInfoCorrect(vantageName, "VRAM"), "The GPU model should not consistent with gpu namein the Task manager");
                    break;
                default:
                    Assert.Fail("GivenHoverTheGPUCPUVRAMHardDiskArea() no run");
                    break;
            }
        }

        [Then(@"The system tools banner is shown or hidden in homepage '(.*)'")]
        public void ThenTheSystemToolsBannerIsShownOrHiddenInHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    string familyname = VantageCommonHelper.GetCurrentMachineType();
                    NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
                    NerveCenterHelper.GamingFeatureValues systemUpdate = machine.GetValues(machine.GamingSystemTools.SystemUpdate);
                    NerveCenterHelper.GamingFeatureValues hardwareScan = machine.GetValues(machine.GamingSystemTools.HardwareScan);
                    NerveCenterHelper.GamingFeatureValues macroKey = machine.GetValues(machine.GamingSystemTools.MacroKey);
                    NerveCenterHelper.GamingFeatureValues media = machine.GetValues(machine.GamingSystemTools.Media);
                    NerveCenterHelper.GamingFeatureValues power = machine.GetValues(machine.GamingSystemTools.Power);
                    NerveCenterHelper.GamingFeatureValues legionAccessoryCentral = machine.GetValues(machine.GamingSystemTools.LegionAccessoryCentral);
                    Assert.NotNull(_nerveCenterPages.GamingSystemTools, "the GamingSystemTools still show");
                    //Assert.NotNull(_nerveCenterPages.GamingSystemToolsTitle, "the GamingSystemToolsTitle still show");
                    //Assert.AreEqual(machine.GamingSystemTools.Title,_nerveCenterPages.GamingSystemToolsTitle.Text,"");
                    Assert.IsTrue(_session.PageSource.Contains(machine.GamingSystemTools.Title), "The GamingSystemTools Text not found!");
                    if (systemUpdate.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.SystemToolsSystemUpdate, "the SystemToolsSystemUpdate not found");
                        Assert.IsTrue(_nerveCenterPages.SystemToolsSystemUpdate.GetAttribute("Name").ToLower().Contains(systemUpdate.Text.ToLower()), "The SystemToolsSystemUpdate Text is incorrect.");
                        Console.WriteLine("Info:SystemTools SystemUpdate show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsSystemUpdate, "the SystemToolsSystemUpdate still show");
                        Console.WriteLine("Info:SystemTools SystemUpdate not show");
                    }

                    if (macroKey.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.SystemToolsMacroKey, "the SystemToolsMacroKey not found");
                        Assert.IsTrue(_nerveCenterPages.SystemToolsMacroKey.GetAttribute("Name").ToLower().Contains(macroKey.Text.ToLower()), "The SystemToolsMacroKey Text is incorrect.");
                        Console.WriteLine("Info:SystemTools MacroKey show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsMacroKey, "the SystemToolsMacroKey still show");
                        Console.WriteLine("Info:SystemTools MacroKey not show");
                    }

                    if (power.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.SystemToolsPower, "the SystemToolsPower not found");
                        Assert.IsTrue(_nerveCenterPages.SystemToolsPower.GetAttribute("Name").ToLower().Contains(power.Text.ToLower()), "The SystemToolsPower Text is incorrect.");
                        Console.WriteLine("Info:SystemTools Power show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsPower, "the SystemToolsPower still show");
                        Console.WriteLine("Info:SystemTools Power not show");
                    }

                    if (media.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.SystemToolsMedia, "the SystemToolsMedia not found");
                        Assert.IsTrue(_nerveCenterPages.SystemToolsMedia.GetAttribute("Name").ToLower().Contains(media.Text.ToLower()), "The SystemToolsMedia Text is incorrect.");
                        Console.WriteLine("Info:SystemTools Media show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsMedia, "the SystemToolsMedia still show");
                        Console.WriteLine("Info:SystemTools Media not show");
                    }

                    if (hardwareScan.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.SystemToolsHWScan, "the SystemToolsHWScan not found");
                        Assert.IsTrue(_nerveCenterPages.SystemToolsHWScan.GetAttribute("Name").ToLower().Contains(hardwareScan.Text.ToLower()), "The SystemToolsHWScan Text is incorrect.");
                        Console.WriteLine("Info:SystemTools HardwareScan show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsHWScan, "the SystemToolsHWScan still show");
                        Console.WriteLine("Info:SystemTools HardwareScan not show");
                    }

                    if (legionAccessoryCentral.Support == true)
                    {
                        if (machine.GamingSystemTools.LegionAccessoryCentralInstallStatus == true)
                        {
                            Assert.NotNull(_nerveCenterPages.SystemToolsLegionAccessoryCentral, "the SystemToolsLegionAccessoryCentral not found");
                            Assert.IsTrue(_nerveCenterPages.SystemToolsLegionAccessoryCentral.GetAttribute("Name").ToLower().Contains(legionAccessoryCentral.Text.ToLower()), "The SystemToolsLegionAccessoryCentral Text is incorrect.");
                            Console.WriteLine("Info:SystemTools LegionAccessoryCentral show");
                        }
                        else
                        {
                            Assert.Warn("Info: Please Install LegionAccessoryCentral APP.");
                        }
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.SystemToolsLegionAccessoryCentral, "the SystemToolsLegionAccessoryCentral still show");
                        Console.WriteLine("Info:SystemTools LegionAccessoryCentral not show");
                    }
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.GamingSystemTools, "the GamingSystemTools still show");
                    //Assert.Null(_nerveCenterPages.GamingSystemToolsTitle, "the GamingSystemToolsTitle still show");
                    Assert.Null(_nerveCenterPages.SystemToolsHWScan, "the SystemToolsHWScan still show");
                    Assert.Null(_nerveCenterPages.SystemToolsMacroKey, "the SystemToolsMacroKey still show");
                    Assert.Null(_nerveCenterPages.SystemToolsMedia, "the SystemToolsMedia still show");
                    Assert.Null(_nerveCenterPages.SystemToolsSystemUpdate, "the SystemToolsSystemUpdate still show");
                    Assert.Null(_nerveCenterPages.SystemToolsPower, "the SystemToolsPower still show");
                    Assert.Null(_nerveCenterPages.SystemToolsLegionAccessoryCentral, "the SystemToolsLegionAccessoryCentral still show");
                    Console.WriteLine("Info: SystemTools system update power media hardwarescan macrokey legionaccessorycentral hidden");
                    break;
                default:
                    Assert.Fail("ThenTheSystemToolsBannerIsShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [Then(@"The legion edge banner is shown or hidden in homepage '(.*)'")]
        public void ThenTheLegionEdgeBannerIsShownOrHiddenInHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    //CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock
                    string familyname = VantageCommonHelper.GetCurrentMachineType();
                    NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
                    NerveCenterHelper.GamingFeatureValues cpuOverclock = machine.GetValues(machine.GamingLegionEdge.CPUOverclock);
                    NerveCenterHelper.GamingFeatureValues thermalModeNew = machine.GetValues(machine.GamingLegionEdge.ThermalMode);
                    NerveCenterHelper.GamingFeatureValues thermalModeOld = machine.GetValues(machine.GamingQuickSettings.ThermalMode);
                    NerveCenterHelper.GamingFeatureValues ramOverclock = machine.GetValues(machine.GamingLegionEdge.RAMOverclock);
                    NerveCenterHelper.GamingFeatureValues networkBoost = machine.GetValues(machine.GamingLegionEdge.NetworkBoost);
                    NerveCenterHelper.GamingFeatureValues autoClose = machine.GetValues(machine.GamingLegionEdge.AutoClose);
                    NerveCenterHelper.GamingFeatureValues hybridMode = machine.GetValues(machine.GamingLegionEdge.HybridMode);
                    NerveCenterHelper.GamingFeatureValues overDrive = machine.GetValues(machine.GamingLegionEdge.OverDrive);
                    NerveCenterHelper.GamingFeatureValues touchpadLock = machine.GetValues(machine.GamingLegionEdge.TouchpadLock);

                    Assert.NotNull(_nerveCenterPages.GamingLegionEdge, "The GamingLegionEdge not found");
                    Assert.NotNull(_nerveCenterPages.LegionEdgeHelpIcon, "The LegionEdgeHelpIcon not found");
                    if (cpuOverclock.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeCPUOverclock, "The CPUOverclock not found");
                        Assert.IsTrue(_session.PageSource.Contains(cpuOverclock.Text), "The CPUOverclock Text not found!");
                        Console.WriteLine("Info: LegionEdge CPUOverclock show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeCPUOverclock, "The CPUOverclock still show");
                        Console.WriteLine("Info: LegionEdge CPUOverclock not show");
                    }

                    if (thermalModeNew.Support == true)
                    {
                        if (thermalModeNew.Value.ToLower() == "new")
                        {
                            if (_nerveCenterPages.LegionEdgeThermalModeNewPerformance != null || _nerveCenterPages.LegionEdgeThermalModeNewBalance != null || _nerveCenterPages.LegionEdgeThermalModeNewQuiet != null)
                            {
                                Assert.IsTrue(true); //Assert.Pass();
                            }
                            else
                            {
                                Assert.Fail("The LegionEdgeThermalModeNew not found!");
                            }
                            Assert.IsTrue(_session.PageSource.Contains(thermalModeNew.Text), "The ThermalModeNew Text not found!");
                            Console.WriteLine("Info: LegionEdge ThermalModeNew show");
                        }
                        else if (thermalModeNew.Value.ToLower() == "old")
                        {
                            Assert.Fail("The ThermalModeNew Config Value error!");
                        }
                        else
                        {
                            Assert.Fail("The ThermalModeNew Config Value error!");
                        }
                    }
                    else
                    {
                        if (thermalModeOld.Support == true)
                        {
                            if (thermalModeOld.Value.ToLower() == "old")
                            {
                                Assert.NotNull(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld not found!");
                                Assert.IsTrue(_session.PageSource.Contains(thermalModeOld.Text), "The ThermalModeOld Text not found!");
                                Console.WriteLine("Info: ThermalModeOld show");
                            }
                            else if (thermalModeOld.Value.ToLower() == "new")
                            {
                                Assert.Fail("The ThermalModeOld Config Value error!");
                            }
                            else
                            {
                                Assert.Fail("The ThermalMode Config Value error!");
                            }
                        }
                        else
                        {
                            Assert.Null(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld still show!");
                            Console.WriteLine("Info: LegionEdge ThermalModeOld not show");
                        }
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "The ThermalModeNewPerformance still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "The ThermalModeNewQuiet still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "The ThermalModeNewBalance still show!");
                        Console.WriteLine("Info: LegionEdge ThermalModeNew not show");
                    }

                    if (ramOverclock.Support == true)
                    {
                        if (_nerveCenterPages.LegionEdgeRAMOverclockToggleOff != null || _nerveCenterPages.LegionEdgeRAMOverclockToggleOn != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The RAMOverclock toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(ramOverclock.Text), "The RAMOverclock Text not found!");
                        Console.WriteLine("Info: LegionEdge RAMOverclock show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff, "The RAMOverclock toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn, "The RAMOverclock toggle on still show!");
                        Console.WriteLine("Info: LegionEdge RAMOverclock not show");
                    }

                    if (networkBoost.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "The NetworkBoost Icon not found!");
                        if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOn != null || _nerveCenterPages.LegionEdgeNetworkBoostToggleOff != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The NetworkBoost toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(networkBoost.Text), "The NetworkBoost Text not found!");
                        Console.WriteLine("Info: LegionEdge NetworkBoost show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "The NetworkBoost Icon still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "The NetworkBoost toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "The NetworkBoost toggle on still show!");
                        Console.WriteLine("Info: LegionEdge NetworkBoost not show");
                    }

                    if (autoClose.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "The AutoClose Icon not found!");
                        if (_nerveCenterPages.LegionEdgeAutoCloseToggleOff != null || _nerveCenterPages.LegionEdgeAutoCloseToggleOn != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The AutoClose toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(autoClose.Text), "The AutoClose Text not found!");
                        Console.WriteLine("Info: LegionEdge AutoClose show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseIcon, "The AutoClose Icon still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseToggleOff, "The AutoClose toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseToggleOn, "The AutoClose toggle on still show!");
                        Console.WriteLine("Info: LegionEdge AutoClose not show");
                    }

                    if (hybridMode.Support == true)
                    {
                        if (_nerveCenterPages.LegionEdgeHybridModeToggleOff != null || _nerveCenterPages.LegionEdgeHybridModeToggleOn != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The HybridMode toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(hybridMode.Text), "The HybridMode Text not found!");
                        Console.WriteLine("Info: LegionEdge HybridMode show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeHybridModeToggleOff, "The HybridMode toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeHybridModeToggleOn, "The HybridMode toggle on still show!");
                        Console.WriteLine("Info: LegionEdge HybridMode not show");
                    }

                    if (overDrive.Support == true)
                    {
                        if (_nerveCenterPages.LegionEdgeOverDriveToggleOff != null || _nerveCenterPages.LegionEdgeOverDriveToggleOn != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The OverDrive toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(overDrive.Text), "The OverDrive Text not found!");
                        Console.WriteLine("Info: LegionEdge OverDrive show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeOverDriveToggleOff, "The OverDrive toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeOverDriveToggleOn, "The OverDrive toggle on still show!");
                        Console.WriteLine("Info: LegionEdge OverDrive not show");
                    }

                    if (touchpadLock.Support == true)
                    {
                        if (_nerveCenterPages.LegionEdgeTouchpadLockToggleOff != null || _nerveCenterPages.LegionEdgeTouchpadLockToggleOn != null)
                        {
                            Assert.IsTrue(true); //Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The TouchpadLock toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(touchpadLock.Text), "The TouchpadLock Text not found!");
                        Console.WriteLine("Info: LegionEdge TouchpadLock show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.LegionEdgeTouchpadLockToggleOff, "The TouchpadLock toggle off still show!");
                        Assert.Null(_nerveCenterPages.LegionEdgeTouchpadLockToggleOn, "The TouchpadLock toggle on still show!");
                        Console.WriteLine("Info: LegionEdge TouchpadLock not show");
                    }
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.LegionEdgeCPUOverclock, "The CPUOverclock still show");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "The ThermalModeNewPerformance still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "The ThermalModeNewQuiet still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "The ThermalModeNewBalance still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff, "The RAMOverclock toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn, "The RAMOverclock toggle on still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "The NetworkBoost Icon still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "The NetworkBoost toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "The NetworkBoost toggle on still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseIcon, "The AutoClose Icon still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseToggleOff, "The AutoClose toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeAutoCloseToggleOn, "The AutoClose toggle on still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeHybridModeToggleOff, "The HybridMode toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeHybridModeToggleOn, "The HybridMode toggle on still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeOverDriveToggleOff, "The OverDrive toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeOverDriveToggleOn, "The OverDrive toggle on still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeTouchpadLockToggleOff, "The TouchpadLock toggle off still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeTouchpadLockToggleOn, "The TouchpadLock toggle on still show!");
                    Console.WriteLine("Info: LegionEdge CPU Overclock Thermal Mode RAM Overclock Network Boost Auto Close Hybrid Mode Over Drive Touchpad Lock hidden");
                    break;
                default:
                    Assert.Fail("ThenTheLegionEdgeBannerIsShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [Then(@"The Lighting banner is shown or hidden in homepage '(.*)'")]
        public void ThenTheLightingBannerIsShownOrHiddenInHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    string familyname = VantageCommonHelper.GetCurrentMachineType();
                    NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
                    if (machine.GamingLighting.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.GamingLightingImage, "The GamingLightingImage not found!");
                        Assert.NotNull(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff not found!");
                        Assert.NotNull(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne not found!");
                        Assert.NotNull(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo not found!");
                        Assert.NotNull(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree not found!");
                        Assert.NotNull(_nerveCenterPages.LightingCustomizeIcon, "The LightingCustomizeIcon not found!");
                        Assert.NotNull(_nerveCenterPages.LightingCustomize, "The LightingCustomize not found!");
                        Assert.IsTrue(_session.PageSource.Contains(machine.GamingLighting.Title), "The Lighting Text not found");
                        Assert.IsTrue(_session.PageSource.Contains("Customize"), "The Lighting Customize Text not found");
                        Assert.IsTrue(_session.PageSource.Contains("Select Profile:"), "The Lighting Select Profile: Text not found");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.GamingLightingImage, "The GamingLightingImage still show!");
                        Assert.Null(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff still show!");
                        Assert.Null(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne still show!");
                        Assert.Null(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo still show!");
                        Assert.Null(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree still show!");
                        Assert.Null(_nerveCenterPages.LightingCustomizeIcon, "The LightingCustomizeIcon still show!");
                        Assert.Null(_nerveCenterPages.LightingCustomize, "The LightingCustomize still show!");
                    }
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.GamingLightingImage, "The GamingLightingImage still show!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff still show!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne still show!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo still show!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree still show!");
                    Assert.Null(_nerveCenterPages.LightingCustomizeIcon, "The LightingCustomizeIcon still show!");
                    Assert.Null(_nerveCenterPages.LightingCustomize, "The LightingCustomize still show!");
                    Console.WriteLine("Info: Lighting card hidden");
                    break;
                default:
                    Assert.Fail("ThenTheLightingBannerIsShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [Then(@"The Quick settings card is shown or hidden in homepage '(.*)'")]
        public void ThenTheQuickSettingsCardIsShownOrHiddenInHomepage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (status.ToLower())
            {
                case "shown":
                    string familyname = VantageCommonHelper.GetCurrentMachineType();
                    NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
                    NerveCenterHelper.GamingFeatureValues thermalModeNew = machine.GetValues(machine.GamingLegionEdge.ThermalMode);
                    NerveCenterHelper.GamingFeatureValues thermalModeOld = machine.GetValues(machine.GamingQuickSettings.ThermalMode);
                    NerveCenterHelper.GamingFeatureValues rapidCharge = machine.GetValues(machine.GamingQuickSettings.RapidCharge);
                    NerveCenterHelper.GamingFeatureValues wifiSecurity = machine.GetValues(machine.GamingQuickSettings.WiFiSecurity);
                    NerveCenterHelper.GamingFeatureValues dolby = machine.GetValues(machine.GamingQuickSettings.Dolby);

                    if (thermalModeOld.Support == true)
                    {
                        if (thermalModeOld.Value.ToLower() == "old")
                        {
                            Assert.NotNull(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld not found!");
                            Assert.IsTrue(_session.PageSource.Contains(thermalModeOld.Text), "The ThermalModeOld Text not found!");
                            Console.WriteLine("Info: ThermalModeOld show");
                        }
                        else if (thermalModeOld.Value.ToLower() == "new")
                        {
                            Assert.Fail("The ThermalModeOld Config Value error!");
                        }
                        else
                        {
                            Assert.Fail("The ThermalModeOld Config Value error!");
                        }
                    }
                    else
                    {
                        if (thermalModeNew.Support == true)
                        {
                            if (thermalModeNew.Value.ToLower() == "new")
                            {
                                if (_nerveCenterPages.LegionEdgeThermalModeNewPerformance != null || _nerveCenterPages.LegionEdgeThermalModeNewBalance != null || _nerveCenterPages.LegionEdgeThermalModeNewQuiet != null)
                                {
                                    Assert.IsTrue(true);//Assert.Pass();
                                }
                                else
                                {
                                    Assert.Fail("The ThermalModeNew not found!");
                                }
                                Assert.IsTrue(_session.PageSource.Contains(thermalModeNew.Text), "The ThermalModeNew Text not found!");
                                Console.WriteLine("Info: ThermalModeNew show");
                            }
                            else if (thermalModeNew.Value.ToLower() == "old")
                            {
                                Assert.Fail("The ThermalModeNew Config Value error!");
                            }
                            else
                            {
                                Assert.Fail("The ThermalModeNew Config Value error!");
                            }
                        }
                        else
                        {
                            Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "The ThermalModeNewPerformance still show!");
                            Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "The ThermalModeNewQuiet still show!");
                            Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "The ThermalModeNewBalance still show!");
                            Console.WriteLine("Info:  QuickSettings ThermalModeNew not show");
                        }
                        Assert.Null(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld still show!");
                        Console.WriteLine("Info: ThermalModeOld not show");
                    }

                    if (rapidCharge.Support == true)
                    {
                        if (_nerveCenterPages.QuickSettingsRapidChargeToggleOff != null || _nerveCenterPages.QuickSettingsRapidChargeToggleOn != null)
                        {
                            Assert.IsTrue(true);//Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The RapidCharge toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(rapidCharge.Text), "The RapidCharge Text not found!");
                        Console.WriteLine("Info: QuickSettings RapidCharge show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.QuickSettingsRapidChargeToggleOff, "The RapidCharge toggle off still show");
                        Assert.Null(_nerveCenterPages.QuickSettingsRapidChargeToggleOn, "The RapidCharge toggle on still show");
                        Console.WriteLine("Info: QuickSettings RapidCharge not show");
                    }

                    if (wifiSecurity.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.QuickSettingsWiFiSecurityIcon, "The Dolby Icon not found!");
                        if (_nerveCenterPages.QuickSettingsWiFiSecurityToggleOff != null || _nerveCenterPages.QuickSettingsWiFiSecurityToggleOn != null)
                        {
                            Assert.IsTrue(true);//Assert.Pass();
                        }
                        else
                        {
                            Assert.Fail("The WiFiSecurity toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(wifiSecurity.Text), "The WiFiSecurity Text not found!");
                        Console.WriteLine("Info: QuickSettings WiFiSecurity show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityIcon, "The WiFiSecurity Icon still show!");
                        Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOff, "The WiFiSecurity toggle off still show");
                        Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOn, "The WiFiSecurity toggle on still show");
                        Console.WriteLine("Info: QuickSettings WiFiSecurity not show");
                    }

                    if (dolby.Support == true)
                    {
                        Assert.NotNull(_nerveCenterPages.QuickSettingsDolbyIcon, "The Dolby Icon not found!");
                        if (_nerveCenterPages.QuickSettingsDolbyToggleOff != null || _nerveCenterPages.QuickSettingsDolbyToggleOn != null)
                        {
                            Assert.IsTrue(true);//Assert.Pass(); 
                        }
                        else
                        {
                            Assert.Fail("The Dolby toggle not found");
                        }
                        Assert.IsTrue(_session.PageSource.Contains(dolby.Text), "The Dolby Text not found!");
                        Console.WriteLine("Info: QuickSettings Dolby show");
                    }
                    else
                    {
                        Assert.Null(_nerveCenterPages.QuickSettingsDolbyIcon, "The Dolby Icon still show!");
                        Assert.Null(_nerveCenterPages.QuickSettingsDolbyToggleOff, "The Dolby toggle off still show");
                        Assert.Null(_nerveCenterPages.QuickSettingsDolbyToggleOn, "The Dolby toggle on still show");
                        Console.WriteLine("Info: QuickSettings Dolby not show");
                    }
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeOld, "The ThermalModeOld still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewPerformance, "The ThermalModeNewPerformance still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewQuiet, "The ThermalModeNewQuiet still show!");
                    Assert.Null(_nerveCenterPages.LegionEdgeThermalModeNewBalance, "The ThermalModeNewBalance still show!");
                    Assert.Null(_nerveCenterPages.QuickSettingsRapidChargeToggleOff, "The RapidCharge toggle still show");
                    Assert.Null(_nerveCenterPages.QuickSettingsRapidChargeToggleOn, "The RapidCharge toggle still show");
                    Assert.Null(_nerveCenterPages.QuickSettingsDolbyIcon, "The Dolby Icon still show!");
                    Assert.Null(_nerveCenterPages.QuickSettingsDolbyToggleOff, "The Dolby toggle off still show");
                    Assert.Null(_nerveCenterPages.QuickSettingsDolbyToggleOn, "The Dolby toggle on still show");
                    Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityIcon, "The WiFiSecurity Icon still show!");
                    Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOff, "The WiFiSecurity toggle off still show");
                    Assert.Null(_nerveCenterPages.QuickSettingsWiFiSecurityToggleOn, "The WiFiSecurity toggle on still show");
                    Console.WriteLine("Info: QuickSettings Thermal Mode Rapid Charge WiFi Security Dolby hidden");
                    break;
                default:
                    Assert.Fail("ThenTheQuickSettingsCardIsShownOrHiddenInHomepage() not run!");
                    break;
            }
        }

        [Given(@"Legion Accessory Central App Install or Uninstall '(.*)'")]
        public void GivenLegionAccessoryCentralAppInstallOrUninstall(string status)
        {
            if (NerveCenterHelper.GetMachineIsGaming())
            {
                switch (status.ToLower())
                {
                    case "install":
                        Assert.IsTrue(NerveCenterHelper.LegionAccessoryCentralAppIsExist(), "The LegionAccessoryCentralApp() install fail!");
                        break;
                    case "uninstall":
                        Assert.IsTrue(NerveCenterHelper.LegionAccessoryCentralAppIsExist(false), "The LegionAccessoryCentralApp() uninstall fail!");
                        break;
                    default:
                        Assert.Fail("The GivenLegionAccessoryCentralAppInstallOrUninstall() not run! info:" + status);
                        break;
                }
            }
            else
            {
                Assert.Warn("Non-Gaming Machine will not install Legion Accessory Central App");
            }
        }
    }
}
