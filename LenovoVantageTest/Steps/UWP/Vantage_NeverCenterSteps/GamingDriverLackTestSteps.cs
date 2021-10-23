using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingDriverLackTestSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;

        public GamingDriverLackTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Uninstall Lenovo Gaming LED Driver")]
        public void WhenUninstallLenovoGamingLEDDriver()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string devcon = Environment.Is64BitOperatingSystem ? "devcon_64.exe" : "devcon_32.exe";
            VantageCommonHelper.RunCmd(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\" + devcon) + @"  remove Root\LED");
        }

        [When(@"Uninstall Lenovo Gaming NetFilter Device Driver")]
        public void WhenUninstallLenovoGamingNetFilterDeviceDriver()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string devcon = Environment.Is64BitOperatingSystem ? "devcon_64.exe" : "devcon_32.exe";
            VantageCommonHelper.RunCmd(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\" + devcon) + @"  remove Root\{A8E2977E-B102-4C80-A01F-C162DEF2E495}");
        }

        [When(@"DT Lighting Driver exist or not exist '(.*)'")]
        public void WhenDTLightingDriverExistOrNotExist(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            IntelligentCoolingBaseHelper driverstatus = new IntelligentCoolingBaseHelper();
            bool isInstall = (driverstatus.isSupportIntelligentCooling("Root\\LED") == "1") ? true : false;
            bool isExist = (status == "exist") ? true : false;
            Assert.AreEqual(isExist, isInstall, "The Lighting Driver expected result is " + status + ", but it is" + isInstall);
        }

        [Then(@"The Lighting section is display or not display in homepage '(.*)'")]
        public void ThenTheLightingSectionIsDisplayOrNotDisplayInHomepage(string LightingStatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (LightingStatus.ToLower())
            {
                case "display":
                    Assert.NotNull(_nerveCenterPages.GamingLightingImage, "The GamingLightingImage not found!");
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff not found!");
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne not found!");
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo not found!");
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree not found!");
                    Assert.NotNull(_nerveCenterPages.LightingCustomizeIcon, "The LightingCustomizeIcon not found!");
                    Assert.NotNull(_nerveCenterPages.LightingCustomize, "The LightingCustomize not found!");
                    break;
                case "not display":
                    Assert.Null(_nerveCenterPages.GamingLightingImage, "The GamingLightingImage not found!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff not found!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne not found!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo not found!");
                    Assert.Null(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree not found!");
                    Assert.Null(_nerveCenterPages.LightingCustomizeIcon, "The LightingCustomizeIcon not found!");
                    Assert.Null(_nerveCenterPages.LightingCustomize, "The LightingCustomize not found!");
                    break;
                default:
                    Assert.Fail("The ThenTheLightingSectionIsDisplayOrNotDisplayInHomepage not run");
                    break;
            }
        }

        [When(@"Click Profile '(.*)' in homepage")]
        public void WhenClickProfileInHomepage(string profileOption)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (profileOption.ToLower())
            {
                case "off":
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileOff, "The LightingSelectProfileOff not found!");
                    _nerveCenterPages.LightingSelectProfileOff.Click();
                    Thread.Sleep(3000);
                    break;
                case "1":
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileOne, "The LightingSelectProfileOne not found!");
                    _nerveCenterPages.LightingSelectProfileOne.Click();
                    Thread.Sleep(3000);
                    break;
                case "2":
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileTwo, "The LightingSelectProfileTwo not found!");
                    _nerveCenterPages.LightingSelectProfileTwo.Click();
                    Thread.Sleep(3000);
                    break;
                case "3":
                    Assert.NotNull(_nerveCenterPages.LightingSelectProfileThree, "The LightingSelectProfileThree not found!");
                    _nerveCenterPages.LightingSelectProfileThree.Click();
                    Thread.Sleep(3000);
                    break;
                default:
                    Assert.Fail("The WhenClickProfileInHomepage not run");
                    break;
            }
        }

        [Then(@"The lighting driver lack window will pop up")]
        public void ThenTheLightingDriverLackWindowWillPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowTitle, "The LightingDriverLackWindowTitle not found!");
            Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowInstallButton, "The LightingDriverLackWindowInstallButton not found!");
            Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowCancelButton, "The LightingDriverLackWindowCancelButton not found!");
            Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowCloseButton, "The LightingDriverLackWindowCloseButton not found!");
        }

        [Then(@"Lighting driver lack window is closed and stay current page")]
        public void ThenLightingDriverLackWindowIsClosedAndStayCurrentPage()
        {
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowTitle, "The LightingDriverLackWindowTitle still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowInstallButton, "The LightingDriverLackWindowInstallButton still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowCancelButton, "The LightingDriverLackWindowCancelButton still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowCloseButton, "The LightingDriverLackWindowCloseButton still show!");
            Assert.NotNull(_nerveCenterPages.HomePageHeaderLegion, "The HomePageHeaderLegion not found!");
            Assert.NotNull(_nerveCenterPages.GamingSystemStatus, "The GamingSystemStatus not found!");
            Assert.NotNull(_nerveCenterPages.GamingSystemTools, "The GamingSystemTools not found!");
            Assert.NotNull(_nerveCenterPages.GamingLegionEdge, "The GamingLegionEdge not found!");
        }

        [When(@"Click ""(.*)"" on lighting driver lack window")]
        public void WhenClickOnLightingDriverLackWindow(string Lackbutton)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (Lackbutton.Trim())
            {
                case "X":
                    Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowCloseButton, "The LightingDriverLackWindowCloseButton not found!");
                    _nerveCenterPages.LightingDriverLackWindowCloseButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "INSTALL":
                    Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowInstallButton, "The LightingDriverLackWindowInstallButton not found!");
                    _nerveCenterPages.LightingDriverLackWindowInstallButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "Cancel":
                    Assert.NotNull(_nerveCenterPages.LightingDriverLackWindowCancelButton, "The LightingDriverLackWindowCancelButton not found!");
                    _nerveCenterPages.LightingDriverLackWindowCancelButton.Click();
                    Thread.Sleep(3000);
                    break;
                default:
                    Assert.Fail("The WhenClickOnLightingDriverLackWindow not run");
                    break;
            }
        }

        [Then(@"System subpage will be opened")]
        public void ThenSystemSubpageWillBeOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.SystemUpdateTitle, "The SystemUpdateTitle not found!");
        }

        [Then(@"The lighting driver lack window will not pop up")]
        public void ThenTheLightingDriverLackWindowWillNotPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowTitle, "The LightingDriverLackWindowTitle still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowInstallButton, "The LightingDriverLackWindowInstallButton still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowCancelButton, "The LightingDriverLackWindowCancelButton still show!");
            Assert.Null(_nerveCenterPages.LightingDriverLackWindowCloseButton, "The LightingDriverLackWindowCloseButton still show!");
        }

        [When(@"Install Gaming driver")]
        public void WhenInstallLightingDriver()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Process.Start(VantageConstContent.GamingFeatureDriverSetup);
            Thread.Sleep(10000);
        }

        [When(@"Click lighting Customize Icon in homepage")]
        public void WhenClickLightingCustomizeIconInHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.LightingCustomizeIcon, "The GamingLightingTitle not found!");
            _nerveCenterPages.LightingCustomizeIcon.Click();
        }

        [When(@"Click the Customize button")]
        public void WhenClickTheCustomizeButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.LightingCustomize, "The GamingLightingTitle not found!");
            _nerveCenterPages.LightingCustomize.Click();
        }

        [Then(@"The Lighting subpage will show")]
        public void ThenTheLightingSubpageWillShow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLightingSubpageHeaderTitle, "The GamingLightingSubpageTitle not found!");
        }

        [When(@"Click Profile '(.*)' in Lighting subpage")]
        public void WhenClickProfileInLightingSubpage(string _ProfileOption)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (_ProfileOption.ToLower())
            {
                case "off":
                    Assert.NotNull(_nerveCenterPages.GamingLightingSubpageProfileOff, "The GamingLightingSubpageProfileOff not found!");
                    _nerveCenterPages.GamingLightingSubpageProfileOff.Click();
                    Thread.Sleep(3000);
                    break;
                case "1":
                    Assert.NotNull(_nerveCenterPages.GamingLightingSubpageProfileOne, "The GamingLightingSubpageProfileOne not found!");
                    _nerveCenterPages.GamingLightingSubpageProfileOne.Click();
                    Thread.Sleep(3000);
                    break;
                case "2":
                    Assert.NotNull(_nerveCenterPages.GamingLightingSubpageProfileTwo, "The GamingLightingSubpageProfileTwo not found!");
                    _nerveCenterPages.GamingLightingSubpageProfileTwo.Click();
                    Thread.Sleep(3000);
                    break;
                case "3":
                    Assert.NotNull(_nerveCenterPages.GamingLightingSubpageProfileThree, "The GamingLightingSubpageProfileThree not found!");
                    _nerveCenterPages.GamingLightingSubpageProfileThree.Click();
                    Thread.Sleep(3000);
                    break;
                default:
                    Assert.Fail("The WhenClickProfileInLightingSubpage not run");
                    break;
            }
        }

        [Then(@"The brightness slider will not show")]
        public void ThenTheBrightnessSliderWillNotShow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.GamingLightingSubpageBrightnessSlider);
        }

        [Then(@"The brightness slider will show")]
        public void ThenTheBrightnessSliderWillShow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLightingSubpageBrightnessSlider);
        }

        [When(@"NetFilter Driver exist or not exist '(.*)'")]
        public void WhenNetFilterDriverExistOrNotExist(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            IntelligentCoolingBaseHelper driverstatus = new IntelligentCoolingBaseHelper();
            bool isInstall = (driverstatus.isSupportIntelligentCooling("Root\\{A8E2977E-B102-4C80-A01F-C162DEF2E495}") == "1") ? true : false;
            bool isExist = (status == "exist") ? true : false;
            Assert.AreEqual(isExist, isInstall, "The NetFilter Driver expected result is " + status + ", but it is" + isInstall);
        }

        [Then(@"The toggle of network boost can display within Vantage homepage")]
        public void ThenTheToggleOfNetworkBoostCanDisplayWithinVantageHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggle, "The toggle of network boost cannot display within Vantage homepage");
        }

        [Then(@"The toggle of network boost can display within Network Boost subpage")]
        public void ThenTheToggleOfNetworkBoostCanDisplayWithinNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState, "The toggle of network boost cannot display within Network Boost subpage");
        }

        [Then(@"Close add apps network boost pop window")]
        public void ThenCloseAddAppsNetworkBoostPopWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageAddAppsCloseBtn != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostSubpageAddAppsCloseBtn.Click();
                Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageAddAppsCloseBtn);
            }
            else if (_nerveCenterPages.NetworkBoostAddAppNoRunningClose != null)
            {
                _nerveCenterPages.NetworkBoostAddAppNoRunningClose.Click();
                Assert.IsNull(_nerveCenterPages.NetworkBoostAddAppNoRunningClose);
            }
            else
            {
                Assert.Fail("ThenCloseAddAppsNetworkBoostPopWindow is not running!");
            }
        }

        [When(@"Click Network Boost toggle")]
        public void WhenClickNetworkBoostToggle()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggle);
            _nerveCenterPages.LegionEdgeNetworkBoostToggle.Click();
        }

        [Then(@"Network Boost Toggle Cannot Be Changed After Click")]
        public void ThenNetworkBoostToggleCannotBeChangedAfterClick()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOn != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostToggleOn.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "The Network Boost toggle will be changed from on to off!");
            }
            else if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOff != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostToggleOff.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "The Network Boost toggle will be changed from off to on!");
            }
            else
            {
                Assert.Fail("The ThenNetworkBoostToggleCannotBeChangedAfterClick not run!");
            }
        }

        [Then(@"Network Boost Toggle Can Be Changed After Click")]
        public void ThenNetworkBoostToggleCanBeChangedAfterClick()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOn != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostToggleOn.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "The Network Boost toggle cannot be changed from on to off!");
            }
            else if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOff != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostToggleOff.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "The Network Boost toggle cannot be changed from off to on!");
            }
            else
            {
                Assert.Fail("The ThenNetworkBoostToggleCanBeChangedAfterClick not run!");
            }
        }

        [Then(@"The NetFilter driver lack window will pop up")]
        public void ThenTheNetFilterDriverLackWindowWillPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowTitle, "The NetFilterDriverLackWindowTitle not found!");
            Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowInstallButton, "The NetFilterDriverLackWindowInstallButton not found!");
            Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowCancelButton, "The NetFilterDriverLackWindowCancelButton not found!");
            Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowCloseButton, "The NetFilterDriverLackWindowCloseButton not found!");
        }

        [When(@"Click '(.*)' in NetFilter driver lack window")]
        public void WhenClickInNetFilterDriverLackWindow(string button)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (button.Trim())
            {
                case "X":
                    Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowCloseButton, "The NetFilterDriverLackWindowCloseButton not found!");
                    _nerveCenterPages.NetFilterDriverLackWindowCloseButton.Click();
                    break;
                case "INSTALL":
                    Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowInstallButton, "The NetFilterDriverLackWindowInstallButton not found!");
                    _nerveCenterPages.NetFilterDriverLackWindowInstallButton.Click();
                    break;
                case "Cancel":
                    Assert.NotNull(_nerveCenterPages.NetFilterDriverLackWindowCancelButton, "The NetFilterDriverLackWindowCancelButton not found!");
                    _nerveCenterPages.NetFilterDriverLackWindowCancelButton.Click();
                    break;
                default:
                    Assert.Fail("The WhenClickInNetFilterDriverLackWindow not run");
                    break;
            }
        }

        [Then(@"NetFilter driver lack window will be closed and stay current page")]
        public void ThenNetFilterDriverLackWindowWillBeClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindow, "The NetFilterDriverLackWindow still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowTitle, "The NetFilterDriverLackWindowTitle still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowInstallButton, "The NetFilterDriverLackWindowInstallButton still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowCancelButton, "The NetFilterDriverLackWindowCancelButton still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowCloseButton, "The NetFilterDriverLackWindowCloseButton still show!");
            Assert.NotNull(_nerveCenterPages.HomePageHeaderLegion, "The HomePageHeaderLegion not found!");
            Assert.NotNull(_nerveCenterPages.GamingSystemStatus, "The GamingSystemStatus not found!");
            Assert.NotNull(_nerveCenterPages.GamingSystemTools, "The GamingSystemTools not found!");
            Assert.NotNull(_nerveCenterPages.GamingLegionEdge, "The GamingLegionEdge not found!");
        }

        [Then(@"The NetFilter driver lack window will not pop up")]
        public void ThenTheNetFilterDriverLackWindowWillNotPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindow, "The NetFilterDriverLackWindow still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowTitle, "The NetFilterDriverLackWindowTitle still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowInstallButton, "The NetFilterDriverLackWindowInstallButton still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowCancelButton, "The NetFilterDriverLackWindowCancelButton still show!");
            Assert.Null(_nerveCenterPages.NetFilterDriverLackWindowCloseButton, "The NetFilterDriverLackWindowCloseButton still show!");
        }

        [When(@"Uninstall XTU Driver")]
        public void WhenUninstallXTUDriver()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (File.Exists("C:\\Program Files\\Lenovo\\Intel(R) Extreme Tuning Utility\\unins000.exe"))
            {
                Process.Start("C:\\Program Files\\Lenovo\\Intel(R) Extreme Tuning Utility\\unins000.exe");
                Thread.Sleep(8000);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(3000);
                SendKeys.SendWait("{ENTER}"); //uninstalling
                Thread.Sleep(8000);
                SendKeys.SendWait("{TAB}");
                Thread.Sleep(3000);
                SendKeys.SendWait("{ENTER}");  //no restart
                Thread.Sleep(3000);
            }
        }

        [Then(@"CPU OC display")]
        public void ThenCPUOCDisplay()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotNull(_nerveCenterPages.CPUOverClockingMenu, "The CPUOverClockingMenu not found!");
        }

        [Then(@"RAM OC display")]
        public void ThenRAMOCDisplay()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggle, "The RAM OC cannot display in homepage!");
        }

        [Then(@"There is no OC driver lack window pop up")]
        public void ThenThereIsNoOCDriverLackWindowPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Null(_nerveCenterPages.CPUOverClockDriverLackWindow, "The CPUOverClockDriverLackWindow still show!");
            Assert.Null(_nerveCenterPages.RAMOverClockDriverLackWindow, "The RAMOverClockDriverLackWindow still show!");
        }

        [When(@"Click CPU area within homepage")]
        public void WhenClickCPUAreaWithinHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _nerveCenterPages.LegionEdgeCPUOverclock.Click();
            Thread.Sleep(3000);
        }

        [Then(@"CPU OC driver lack window pop up")]
        public void ThenCPUOCDriverLackWindowPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowCancelButton, "The CPUOverClockDriverLackWindowCancelButton not found!");
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowCloseButton, "The CPUOverClockDriverLackWindowCloseButton not found!");
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowInstallButton, "The CPUOverClockDriverLackWindowInstallButton not found!");
            Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowTitle, "The CPUOverClockDriverLackWindowTitle not found!");
        }

        [When(@"Click RAM OC toggle within homepage")]
        public void WhenClickRAMOCToggleWithinHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggle);
            _nerveCenterPages.LegionEdgeRAMOverclockToggle.Click();
            Thread.Sleep(3000);
        }

        [Then(@"RAM OC driver lack window pop up")]
        public void ThenRAMOCDriverLackWindowPopUp()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowCancelButton, "The RAMOverClockDriverLackWindowCancelButton not found!");
            Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowCloseButton, "The RAMOverClockDriverLackWindowCloseButton not found!");
            Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowInstallButton, "The RAMOverClockDriverLackWindowInstallButton not found!");
            Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowTitle, "The RAMOverClockDriverLackWindowTitle not found!");
        }

        [Then(@"RAM OC toggle will not change after click")]
        public void ThenRAMOCToggleWillNotChangeAfterClick()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeRAMOverclockToggleOn != null)
            {
                _nerveCenterPages.LegionEdgeRAMOverclockToggleOn.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOn, "The RAM OC toggle will be changed from on to off!");
            }
            else if (_nerveCenterPages.LegionEdgeRAMOverclockToggleOff != null)
            {
                _nerveCenterPages.LegionEdgeRAMOverclockToggleOff.Click();
                Thread.Sleep(3000);
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeRAMOverclockToggleOff, "The RAM OC toggle will be changed from off to on!");
            }
            else
            {
                Assert.Fail("The ThenRAMOCToggleWillNotChangeAfterClick not run!");
            }
        }

        [Then(@"Click '(.*)' button in CPU OC driver lack window")]
        public void ThenClickButtonInCPUOCDriverLackWindow(string CPULackButton)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (CPULackButton.Trim())
            {
                case "X":
                    Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowCloseButton);
                    _nerveCenterPages.CPUOverClockDriverLackWindowCloseButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "INSTALL":
                    Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowInstallButton);
                    _nerveCenterPages.CPUOverClockDriverLackWindowInstallButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "Cancel":
                    Assert.IsNotNull(_nerveCenterPages.CPUOverClockDriverLackWindowCancelButton);
                    _nerveCenterPages.CPUOverClockDriverLackWindowCancelButton.Click();
                    break;
                default:
                    Assert.Fail("The ThenClickButtonInCPUOCDriverLackWindow not run!");
                    break;
            }
        }

        [Then(@"Click '(.*)' button in RAM OC driver lack window")]
        public void ThenClickButtonInRAMOCDriverLackWindow(string RAMLackButton)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (RAMLackButton.Trim())
            {
                case "X":
                    Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowCloseButton);
                    _nerveCenterPages.RAMOverClockDriverLackWindowCloseButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "INSTALL":
                    Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowInstallButton);
                    _nerveCenterPages.RAMOverClockDriverLackWindowInstallButton.Click();
                    Thread.Sleep(3000);
                    break;
                case "Cancel":
                    Assert.IsNotNull(_nerveCenterPages.RAMOverClockDriverLackWindowCancelButton);
                    _nerveCenterPages.RAMOverClockDriverLackWindowCancelButton.Click();
                    break;
                default:
                    Assert.Fail("The ThenClickButtonInRAMOCDriverLackWindow not run!");
                    break;
            }
        }
    }
}
