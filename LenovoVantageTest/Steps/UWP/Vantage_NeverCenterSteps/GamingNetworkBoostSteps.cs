using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingNetworkBoostSteps
    {
        private ToggleState _toggleStatus = ToggleState.Indeterminate;
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string _driverName = "netfilterDriver";
        private string _netEaseCloudDec = "NetEase Cloud Music";
        private string _netEaseCloudName = "cloudmusic.exe";
        private string _netEaseCloudElement = null;
        private List<string> _popupAppList = new List<string>();
        private List<string> _appName = new List<string> { "WindowsStore", "IE", "MicrosoftEdge", "WindowsMaps", "WindowsWeather", "WindowsGrooveMusic", "WindowsPeople" };

        public GamingNetworkBoostSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Machine support Network boost")]
        public void GivenMachineSupportNetworkBoost()
        {
            Assert.IsTrue(NerveCenterHelper.GetMachineIsGaming());
            Assert.IsTrue(NerveCenterHelper.JudgeDriverExist(_driverName));
        }

        [Given(@"Launch Vantage network boost")]
        public void GivenLaunchVantageNetworkBoost()
        {
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
        }

        [When(@"Click network boost gear icon")]
        public void WhenClickNetworkBoostGearIcon()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var networkBoostIconEle = _nerveCenterPages.LegionEdgeNetworkBoostIcon;
            Assert.IsNotNull(networkBoostIconEle, "LegionEdgeNetworkBoostIcon is null");
            networkBoostIconEle.Click();
        }

        [When(@"Click back button")]
        public void WhenClickBackButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageBack);
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageBack.Click();
        }

        [When(@"Turn off network boost")]
        public void WhenTurnOffNetworkBoost()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOff == null)
            {
                Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn);
                _nerveCenterPages.LegionEdgeNetworkBoostToggleOn.Click();
            }
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff);
        }

        [When(@"Switch network boost toggle")]
        public void WhenSwitchNetworkBoostToggle()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            bool result = _nerveCenterPages.SwitchNetworkBoostStatus();
            Assert.IsTrue(result);
        }

        [When(@"Turn on network boost")]
        public void WhenTurnOnNetworkBoost()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOff != null)
            {
                if (_nerveCenterPages.ShowTextbox(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff).Contains("networkboost off"))
                {
                    _nerveCenterPages.LegionEdgeNetworkBoostToggleOff.Click();
                }
            }
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn);
        }

        [When(@"Turn off network boost in subpage")]
        public void WhenTurnOffNetworkBoostInSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState != null)
            {
                if (_nerveCenterPages.ShowTextbox(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState).Contains("networkBoost on"))
                {
                    _nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState.Click();
                }
            }
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleOff);
        }

        [When(@"Turn on network boost in subpage")]
        public void WhenTurnOnNetworkBoostInSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState != null)
            {
                string currentState = _nerveCenterPages.ShowTextbox(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState);
                if (currentState.Contains("networkBoost off"))
                {
                    _nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleState.Click();
                }
            }
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleOn);
        }

        [Then(@"Network Boost is displayed in Legion edge")]
        public void ThenNetworkBoostIsDisplayedInLegionEdge()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(SettingsBase.WindowsParentContainString(_webDriver.Session, NerveCenterPages.GamingLegionEdgeListChild, "Network Boost"));
        }

        [Then(@"The gear icon is displayed before the toggle")]
        public void ThenTheGearIconIsDisplayedBeforeTheToggle()
        {
            string togglePositioni = string.Empty;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostIcon);
            string gearPosition = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.LegionEdgeNetworkBoostIcon, "ClickablePoint");
            if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOff != null)
            {
                togglePositioni = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "ClickablePoint");
            }
            else if (_nerveCenterPages.LegionEdgeNetworkBoostToggleOn != null)
            {
                togglePositioni = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "ClickablePoint");

            }
            Assert.Less(Convert.ToInt32(gearPosition.Split(',')[0]), Convert.ToInt32(togglePositioni.Split(',')[0]));
        }

        [Then(@"jump to network boost subpage")]
        public void ThenJumpToNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageTitle, "LegionEdgeNetworkBoostSubpageTitle");
        }

        [When(@"Click Network Boost Header Title")]
        public void WhenClickNetworkBoostHeaderTitle()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageTitle, "Fail to find network boost header title.");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageTitle.Click();
        }

        [Then(@"The toggle display off status in network boost subpage")]
        public void ThenTheToggleDisplayOffStatusInNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleOff, "LegionEdgeNetworkBoostSubpageToggleOff");
        }

        [Then(@"jump to homepage")]
        public void ThenJumpToHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingLegionEdge, "GamingLegionEdge");
        }

        [Then(@"Network boost toggle status is on")]
        public void ThenNetworkBoostToggleStatusIsOn()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOn, "LegionEdgeNetworkBoostToggleOn");
        }

        [Then(@"The toggle display on status in network boost subpage")]
        public void ThenTheToggleDisplayOnStatusInNetworkBoostSubpage()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageToggleOn, "LegionEdgeNetworkBoostSubpageToggleOn");
        }

        [Then(@"Network boost toggle status is off")]
        public void ThenNetworkBoostToggleStatusIsOff()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostToggleOff, "LegionEdgeNetworkBoostToggleOff");
        }

        [When(@"Get toggle status from network boost subpage")]
        public void WhenGetToggleStatusFromNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _toggleStatus = _nerveCenterPages.NetworkBoostStatusFromSubpage();
        }

        [Then(@"Network boost subpage toggle not charge")]
        public void ThenNetworkBoostSubpageToggleNotCharge()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(_toggleStatus, _nerveCenterPages.NetworkBoostStatusFromSubpage(), "NetworkBoostStatusFromSubpage");
        }

        [When(@"Switch toggle from network boost subpage")]
        public void WhenSwitchToggleFromNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            bool result = _nerveCenterPages.SwitchNetworkBoostStatusFromSubpage();
            Assert.IsTrue(result);
        }

        [Then(@"Network boost subpage toggle will be charge")]
        public void ThenNetworkBoostSubpageToggleWillBeCharge()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreNotEqual(_toggleStatus, _nerveCenterPages.NetworkBoostStatusFromSubpage(), "NetworkBoostStatusFromSubpage");
        }

        [When(@"Click the add icon")]
        public void WhenClickTheAddIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int appListCount = _nerveCenterPages.NetworkBoostAppList.Count - 2;
            if (appListCount >= 5)
            {
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                Assert.IsNotNull(_nerveCenterPages.NetworkBoostAddRemove0, "NetworkBoostAddRemove0");
                _nerveCenterPages.NetworkBoostAddRemove0.Click();
            }
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageAddBtn, "LegionEdgeNetworkBoostSubpageAddBtn");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageAddBtn.Click();
        }

        [Then(@"The network boost dialog is displayed")]
        public void ThenTheNetworkBoostDialogIsDisplayed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialog, "LegionEdgeNetworkBoostSubpageDialog");
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox, "LegionEdgeNetworkBoostSubpageDialogCheckbox");
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCloseBtn, "LegionEdgeNetworkBoostSubpageDialogCloseBtn");
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn, "LegionEdgeNetworkBoostSubpageDialogNotNowBtn");
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogTurnonBtn, "LegionEdgeNetworkBoostSubpageDialogTurnonBtn");
        }

        [Then(@"The network boost dialog checkbox status is unselected")]
        public void ThenTheNetworkBoostDialogCheckboxStatusIsUnselected()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox, "LegionEdgeNetworkBoostSubpageDialogCheckbox");
            Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox), "LegionEdgeNetworkBoostSubpageDialogCheckbox");
        }

        [When(@"Close network boost dialog")]
        public void WhenCloseNetworkBoostDialog()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCloseBtn, "LegionEdgeNetworkBoostSubpageDialogCloseBtn");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCloseBtn.Click();
        }

        [When(@"Close network boost add apps pop window")]
        public void WhenCloseNetworkBoostAddDialog()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageCloseAddBtn != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostSubpageCloseAddBtn.Click();
            }
            else if (_nerveCenterPages.NetworkBoostAddAppNoRunningClose != null)
            {
                _nerveCenterPages.NetworkBoostAddAppNoRunningClose.Click();
            }
            else
            {
                Assert.Fail("Fail to close network boost add apps pop window");
            }
        }

        [When(@"Unselect don't ask agin in network boost checkbox")]
        public void WhenUnselectDonTAskAginInNetworkBoostCheckbox()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox, "LegionEdgeNetworkBoostSubpageDialogCheckbox");
            if (VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox) == ToggleState.On)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox.Click();
            }
            Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox), "LegionEdgeNetworkBoostSubpageDialogCheckbox");
        }

        [Then(@"The add apps network boost pop window is displayed")]
        public void ThenTheAddAppsNetworkBoostPopWindowIsDisplayed()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(_nerveCenterPages.LegionEdgeNetworkBoostSubpageAddAppsCloseBtn != null || _nerveCenterPages.NetworkBoostAddAppNoRunningClose != null, "The add apps network boost pop window is displayed");
        }

        [When(@"Click the not now link")]
        public void WhenClickTheNotNowLink()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn, "LegionEdgeNetworkBoostSubpageDialogNotNowBtn");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn.Click();
        }

        [When(@"Click turn on button")]
        public void WhenClickTurnOnButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogTurnonBtn, "LegionEdgeNetworkBoostSubpageDialogTurnonBtn");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogTurnonBtn.Click();
        }

        [Then(@"The network boost turn on dialog will be not displayed")]
        public void ThenTheNetworkBoostSubpageDialogWillBeClose()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialog, "LegionEdgeNetworkBoostSubpageDialog");
            Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox, "LegionEdgeNetworkBoostSubpageDialogCheckbox");
            Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCloseBtn, "LegionEdgeNetworkBoostSubpageDialogCloseBtn");
            Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn, "LegionEdgeNetworkBoostSubpageDialogNotNowBtn");
            Assert.IsNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogTurnonBtn, "LegionEdgeNetworkBoostSubpageDialogTurnonBtn");
        }

        [When(@"Select don't ask agin checkbox in network boost subpage")]
        public void WhenSelectDonTAskAginCheckboxInNetworkBoostSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox, "LegionEdgeNetworkBoostSubpageDialogCheckbox");
            if (VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox) == ToggleState.Off)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox.Click();
            }
            Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox), "LegionEdgeNetworkBoostSubpageDialogCheckbox");
        }

        [Then(@"The checkbox status is selected")]
        public void ThenTheCheckboxStatusIsSelected()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox), "LegionEdgeNetworkBoostSubpageDialogCheckbox");
        }

        [When(@"Set pop window no app is running")]
        public void WhenSetPopWindowNoAppIsRunning()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            _nerveCenterPages.SetPopWindowNoRunning();
        }

        [Then(@"Pop window display no app running")]
        public void ThenPopWindowDisplayNoAppRunning()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostNoAppRunning, "LegionEdgeNetworkBoostNoAppRunning");
        }

        [When(@"Set pop window is running")]
        public void WhenSetPopWindowIsRunning()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsTrue(_nerveCenterPages.SetPopWindowIsRunning());
        }

        [Then(@"Icon under the app name")]
        public void ThenIconUnderTheAppName()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotZero(_nerveCenterPages.NetworkBoostRunningEdgeList.Count);
            // List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostRunningEdgeList)
            {
                Assert.IsNotNull(element);
                Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(element));
                element.Click();
                Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(element));
            }
        }

        [When(@"Install NetEase Cloud Music app")]
        public void WhenInstallKugouApp()
        {
            bool result = SettingsBase.InstallApps();
            Thread.Sleep(TimeSpan.FromSeconds(10));
        }

        [Then(@"NetEase Cloud Music app can not be displayed in pop window")]
        public void ThenKugouAppCanNotBeDisplayedInPopWindow()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = true;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            // List<WindowsElement> runningApps = _nerveCenterPages.NetworkBoostRunningEdgeList;
            foreach (WindowsElement runningApp in _nerveCenterPages.NetworkBoostRunningEdgeList)
            {
                if (VantageCommonHelper.GetAttributeValue(runningApp, "Name").Contains(_netEaseCloudDec))
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [When(@"Start NetEase Cloud Music app")]
        public void WhenStartKugouApp()
        {
            bool result = SettingsBase.StartApp();
            if (result == false) // try again
            {
                result = SettingsBase.StartApp();
            }
            Assert.IsTrue(result, "Start NetEase Cloud Music app fail");
            IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", "Lenovo Vantage");
            UnManagedAPI.SetWindowPos(intPtr, UnManagedAPI.HWND_TOPMOST, 0, 0, 0, 0, UnManagedAPI.SWP_NOSIZE);
        }

        [When(@"Set some running for add apps list")]
        public void WhenSetSomeRunningForAddAppsList()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            List<WindowsElement> appsList = _nerveCenterPages.NetworkBoostAppList;
            foreach (WindowsElement app in appsList)
            {
                if (VantageCommonHelper.GetAttributeValue(app, "Name").Contains(_netEaseCloudDec))
                {
                    return;
                }
            }
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeNetworkBoostSubpageAddBtn, "LegionEdgeNetworkBoostSubpageAddBtn");
            //Assert.IsNotNull(_nerveCenterPages.NetworkBoostPopWindowAddBtn, "NetworkBoostPopWindowAddBtn");
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageAddBtn.Click();
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            Assert.NotZero(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, "NetworkBoostRunningEdgeList");
            List<WindowsElement> elements = _nerveCenterPages.NetworkBoostRunningEdgeList;// _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            foreach (WindowsElement element in elements)
            {
                if (VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudDec))
                {
                    element.Click();
                }
            }
            _nerveCenterPages.LegionEdgeNetworkBoostSubpageAddAppsCloseBtn.Click();
            appsList = _nerveCenterPages.NetworkBoostAppList;
            foreach (WindowsElement app in appsList)
            {
                if (VantageCommonHelper.GetAttributeValue(app, "Name").Contains(_netEaseCloudDec))
                {
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }


        [Then(@"The app displayed in add app list")]
        public void ThenTheAppDisplayedInAddAppList()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            // List<WindowsElement> appsList = _nerveCenterPages.NetworkBoostAppList;
            foreach (WindowsElement app in _nerveCenterPages.NetworkBoostAppList)
            {
                string a = VantageCommonHelper.GetAttributeValue(app, "Name");
                if (VantageCommonHelper.GetAttributeValue(app, "Name").Contains(_netEaseCloudDec))
                {
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [When(@"Remove NetEase Cloud Music from add app list")]
        public void WhenRemoveNetEaseCloudMusicFromAddAppList()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostPopWindowRemoveBtn, "NetworkBoostPopWindowRemoveBtn");
            // List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostAppList.Count - 3, _nerveCenterPages.NetworkBoostPopWindowRemoveBtn);
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostAppList)
            {
                if (VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudDec) || VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudName))
                {
                    element.Click();
                    break;
                }
            }
        }

        [When(@"Select NetEase Cloud Music app")]
        public void WhenSelectNetEaseCloudMusicApp()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            //List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostRunningEdgeList)
            {
                if (VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudDec))
                {
                    element.Click();
                    _netEaseCloudElement = VantageCommonHelper.GetAttributeValue(element, "AutomationId");
                    result = true;
                }
            }
            Assert.IsTrue(result);
        }

        [When(@"Hover the mouse on the NetEase Cloud Music icon")]
        public void WhenHoverTheMouseOnTheNetEaseCloudMusicIcon()
        {
            bool result = false;
            for (int i = 0; i < 5; i++)
            {
                WhenClickTheAddIcon();
                _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                //List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
                foreach (WindowsElement element in _nerveCenterPages.NetworkBoostRunningEdgeList)
                {
                    if (VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudDec))
                    {
                        Actions action = new Actions(_webDriver.Session);
                        action.MoveToElement(element).Perform();
                        result = true;
                        break;
                    }
                }
                if (result)
                {
                    break;
                }
                WhenCloseNetworkBoostAddDialog();
            }
            Assert.IsTrue(result);
        }

        [When(@"Uninstall NetEase Cloud Music")]
        public void WhenUninstallNetEaseCloudMusic()
        {
            SettingsBase.UninstallApps();
        }

        [When(@"Minimized vantage")]
        public void WhenMinimizedVantage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.VantageMinimize, "VantageMinimize");
            _nerveCenterPages.VantageMinimize.Click();
            Thread.Sleep(TimeSpan.FromSeconds(1));
            _webDriver.Session.Manage().Window.Maximize();
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }

        [When(@"Max vantage")]
        public void WhenMaxVantage()
        {
            _webDriver.Session.Manage()?.Window?.Maximize();
        }

        [Then(@"Select icon will be changed")]
        public void ThenSelectIconWillBeChanged()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            //List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostRunningEdgeList)
            {
                if (VantageCommonHelper.GetAttributeValue(element, "Name").Contains(_netEaseCloudDec))
                {
                    var tickAutomationid = VantageCommonHelper.GetAttributeValue(element, "AutomationId");
                    tickAutomationid = tickAutomationid.Insert(16, "_tick");
                    element.Click();
                    SettingsBase settingsBase = new SettingsBase();
                    if (settingsBase.GetElement(_webDriver.Session, "AutomationId", tickAutomationid) != null)
                    {
                        result = true;
                        break;
                    }
                }
            }
            Assert.IsTrue(result);
        }

        [Then(@"The app displayed in pop up window")]
        public void ThenTheAppDisplayedInPopUpWindow()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = false;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            //List<WindowsElement> appsList = _nerveCenterPages.NetworkBoostRunningEdgeList;
            foreach (WindowsElement app in _nerveCenterPages.NetworkBoostRunningEdgeList)
            {
                string a = VantageCommonHelper.GetAttributeValue(app, "Name");
                if (VantageCommonHelper.GetAttributeValue(app, "Name").Contains(_netEaseCloudDec))
                {
                    result = true;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [Then(@"The app can not bedisplayed in add app list")]
        public void ThenTheAppCanNotBedisplayedInAddAppList()
        {
            bool result = true;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostBackLink, "NetworkBoostBackLink");
            List<WindowsElement> appsList = _nerveCenterPages.NetworkBoostAppList;
            foreach (WindowsElement app in appsList)
            {
                string a = VantageCommonHelper.GetAttributeValue(app, "Name");
                if (VantageCommonHelper.GetAttributeValue(app, "Name").Contains(_netEaseCloudDec))
                {
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result);
        }

        [When(@"Remove all app from add app list")]
        public void WhenRemoveAllAppFromAddAppList()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            while (true)
            {
                if (_nerveCenterPages.NetworkBoostAppList.Count > 2)
                {
                    _nerveCenterPages.NetworkBoostAppList[2]?.Click();
                    Thread.Sleep(500);
                }
                else
                {
                    break;
                }
            }
            Assert.AreEqual(2, _nerveCenterPages.NetworkBoostAppList.Count, "Remove all app from add app list fail");
        }

        [When(@"Select (.*) icon for network bosst pop up window")]
        public void WhenSelectIconForNetworkBosstPopUpWindow(int number)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            //List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            for (int i = 0; i < number; i++)
            {
                _nerveCenterPages.NetworkBoostRunningEdgeList[i].Click();
            }
        }

        [Then(@"Pop up window decription remainding")]
        public void ThenPopUpWindowDecriptionRemainding(string multilineText)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(multilineText, VantageCommonHelper.GetAttributeValue(_nerveCenterPages.NetworkBoostPopupWindowDescription, "Name"));
        }

        [When(@"Click The Network Boost Popup Window Description")]
        public void WhenClickTheNetworkBoostPopupWindowDescription()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostPopupWindowDescription, "Failed to find the network boost popup window description.");
            _nerveCenterPages.NetworkBoostPopupWindowDescription.Click();
        }

        [When(@"Set The number of pop up window apps is no less than (.*)")]
        public void WhenSetTheNumberOfPopUpWindowAppsIsGreaterThan(int number)
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            List<WindowsElement> elements = _nerveCenterPages.NetworkBoostRunningEdgeList;//; _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            if (number > elements.Count)
            {
                for (int i = 0; i < number - elements.Count; i++)
                {
                    foreach (var app in Enum.GetNames(typeof(NerveCenterHelper.AppName)))
                    {
                        if (app == _appName[i])
                        {
                            bool tag = NerveCenterHelper.LaunchAppAsCurrentUser(NerveCenterHelper.GetCommonAppInformation(app).File);
                            Assert.IsTrue(tag, "Please set password is '1',or run other app");
                            break;
                        }
                    }
                }
                for (int i = 0; i < 10; i++)
                {
                    WhenCloseNetworkBoostAddDialog();
                    WhenClickTheAddIcon();
                    _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
                    Assert.IsNotNull(_nerveCenterPages.NetworkBoostRunningEdgeList, "NetworkBoostRunningEdgeList");
                    if (_nerveCenterPages.NetworkBoostRunningEdgeList.Count >= number)
                    {
                        break;
                    }
                }
            }
            elements = _nerveCenterPages.NetworkBoostRunningEdgeList;// neverCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            foreach (WindowsElement element in elements)
            {
                _popupAppList.Add(VantageCommonHelper.GetAttributeValue(element, "Name"));
            }
            Assert.GreaterOrEqual(elements.Count, number);
        }

        [When(@"Kill process for app list")]
        public void WhenKillProcessForAppList()
        {
            foreach (var app in _appName)
            {
                Common.KillProcess(NerveCenterHelper.GetCommonAppInformation(app).ProcessName, true);
            }
            Common.KillProcess("CrashRepoter", true); // cloudmusic crash process
            Common.KillProcess("orpheus_install", true);  // cloudmusic install fail
        }

        [When(@"Kill (.*) by processName")]
        public void WhenKillbyprocessName(string processName)
        {
            Common.KillProcess(processName, true);
        }

        [When(@"Set app list is (.*)")]
        public void WhenSetAppListIs(int number)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostAppList, "NetworkBoostAppList");
            int appList = _nerveCenterPages.NetworkBoostAppList.Count - 2;
            if (number >= appList)
            {
                WhenClickTheAddIcon();
                WhenSetTheNumberOfPopUpWindowAppsIsGreaterThan(number - appList);
                WhenSelectIconForNetworkBosstPopUpWindow(number - appList);
                WhenCloseNetworkBoostAddDialog();
            }
            else
            {
                for (int i = 0; i < appList - number; i++)
                {
                    Assert.IsNotNull(_nerveCenterPages.NetworkBoostAddRemove0, "NetworkBoostAddRemove0");
                    _nerveCenterPages.NetworkBoostAddRemove0.Click();
                }
            }
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.GreaterOrEqual(_nerveCenterPages.NetworkBoostAppList.Count - 2, number, "NetworkBoostAppList");
        }

        [Then(@"Remove apps effects")]
        public void ThenRemoveAppsEffects()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostAppList, "NetworkBoostAppList");
            int appNumber = _nerveCenterPages.NetworkBoostAppList.Count - 2;
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostAddRemove0, "NetworkBoostAddRemove0");
            _nerveCenterPages.NetworkBoostAddRemove0.Click();
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(appNumber - 1, _nerveCenterPages.NetworkBoostAppList.Count - 2, "NetworkBoostAppList");
        }

        [Then(@"Select icon Restore")]
        public void ThenSelectIconRestore()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            List<WindowsElement> elements = _nerveCenterPages.NetworkBoostRunningEdgeList;// neverCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            Assert.Greater(elements.Count, 0);
            var tickAutomationid = VantageCommonHelper.GetAttributeValue(elements[0], "AutomationId");
            var beforAutomationid = tickAutomationid;
            tickAutomationid = tickAutomationid.Insert(16, "_tick");
            elements[0].Click();
            SettingsBase settingsBase = new SettingsBase();
            Assert.IsNotNull(settingsBase.GetElement(_webDriver.Session, "AutomationId", tickAutomationid), tickAutomationid);
            settingsBase.GetElement(_webDriver.Session, "AutomationId", tickAutomationid).Click();
            Assert.IsNotNull(settingsBase.GetElement(_webDriver.Session, "AutomationId", beforAutomationid), beforAutomationid);
        }

        [When(@"Hover the remove icon")]
        public void WhenHoverTheRemoveIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostAddRemove0, "NetworkBoostAddRemove0");
            Actions action = new Actions(_webDriver.Session);
            action.MoveToElement(_nerveCenterPages.NetworkBoostAddRemove0).Perform();
        }

        [When(@"Unselect NetEase Cloud Music app")]
        public void WhenUnselectNetEaseCloudMusicApp()
        {
            SettingsBase settingsBase = new SettingsBase();
            WindowsElement netEaseTickElement = settingsBase.GetElement(_webDriver.Session, "AutomationId", _netEaseCloudElement);
            Assert.IsNotNull(netEaseTickElement);
            netEaseTickElement.Click();
        }

        [Then(@"Network boost app list is empty")]
        public void ThenNetworkBoostAppListIsEmpty()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int appListCount = _nerveCenterPages.NetworkBoostAppList.Count - 2;
            Assert.AreEqual(appListCount, 0);
        }

        [When(@"Network boost back to the homepage")]
        public void WhenNetworkBoostBackToTheHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.NetworkBoostBackLink, "NetworkBoostBackLink");
            _nerveCenterPages.NetworkBoostBackLink.Click();
        }

        [When(@"OOBE dialog")]
        public void WhenOOBEDialog()
        {
            WhenClickTheAddIcon();
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox != null)
            {
                if (VantageCommonHelper.GetToggleStatus(_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox) == ToggleState.Off)
                {
                    _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogCheckbox.Click();
                }
            }
            if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn != null)
            {
                _nerveCenterPages.LegionEdgeNetworkBoostSubpageDialogNotNowBtn.Click();
            }
            WhenCloseNetworkBoostAddDialog();
        }

        [Then(@"Apps name in add apps window are the running apps name")]
        public void ThenAppsNameInAddAppsWindowAreTheRunningAppsName()
        {
            //Thread.Sleep(TimeSpan.FromSeconds(5));
            bool result = true;
            string msg = string.Empty;
            List<string> appNameList = new List<string> { };
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotZero(_nerveCenterPages.NetworkBoostRunningEdgeList.Count);
            List<WindowsElement> elements = _nerveCenterPages.NetworkBoostRunningEdgeList; // _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn);
            Process[] process = Process.GetProcesses();
            foreach (Process ps in process)
            {
                try
                {
                    string psDec = _nerveCenterPages.GetProcessDescription(ps.ProcessName);
                    //string psDec = ps.MainModule.FileVersionInfo.FileDescription;
                    appNameList.Add(psDec);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            foreach (WindowsElement element in elements)
            {
                if (appNameList.Contains(VantageCommonHelper.GetAttributeValue(element, "Name").Substring(4)))
                {
                    continue;
                }
                else
                {
                    msg = VantageCommonHelper.GetAttributeValue(element, "Name").Substring(4);
                    result = false;
                    break;
                }
            }
            Assert.IsTrue(result, msg);
        }

        [StepDefinition(@"Minimize vantage")]
        public void WhenMinimizeVantage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.VantageMinimize);
            _nerveCenterPages.VantageMinimize.Click();
        }

        [Then(@"Apps list not charge")]
        public void ThenAppsListNotCharge()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            List<string> popupNameList = new List<string>();
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostRunningEdgeList) //_nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostRunningEdgeList.Count, _nerveCenterPages.NetworkBoostPopWindowAddBtn)
            {
                popupNameList.Add(VantageCommonHelper.GetAttributeValue(element, "Name"));
            }
            Assert.IsTrue(popupNameList.All(_popupAppList.Contains));
            Assert.IsTrue(popupNameList.Count == _popupAppList.Count);
        }

        [Then(@"Navigation bar cannot click")]
        public void ThenNavigationBarCannotClick()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "GamingDeviceMenu not found");
            Point GamingDeviceMenuPoint = VantageCommonHelper.GetWindowsElementPoint(_nerveCenterPages.GamingDeviceMenu);
            Assert.IsNotNull(_nerveCenterPages.SecurityLink, "SecurityLink not found");
            Point SecurityLinkPoint = VantageCommonHelper.GetWindowsElementPoint(_nerveCenterPages.SecurityLink);
            Assert.IsNotNull(_nerveCenterPages.SupportLink, "SupportLink not found");
            Point SupportLinkPoint = VantageCommonHelper.GetWindowsElementPoint(_nerveCenterPages.SupportLink);
            WhenClickTheAddIcon();
            VantageCommonHelper.SetMouseClick(GamingDeviceMenuPoint.X.ToString(), GamingDeviceMenuPoint.Y.ToString());
            Assert.IsNull(_nerveCenterPages.HomePageHeaderLegion, "HomePageHeaderLegion show");
            VantageCommonHelper.SetMouseClick(SecurityLinkPoint.X.ToString(), SecurityLinkPoint.Y.ToString());
            HSPowerSettingsPage hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            Assert.IsNull(hSPowerSettingsPage.WifiSecurityTitle, "WifiSecurityTitle show");
            VantageCommonHelper.SetMouseClick(SupportLinkPoint.X.ToString(), SupportLinkPoint.Y.ToString());
            Assert.IsNull(_nerveCenterPages.SupportTitle, "SupportTitle");
        }

        [When(@"Kill process for add app list")]
        public void WhenKillProcessForAddAppList()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            List<string> appNameList = new List<string>();
            //List<WindowsElement> elements = _nerveCenterPages.GetXpathValue(_nerveCenterPages.NetworkBoostAppList.Count - 3, _nerveCenterPages.NetworkBoostPopWindowRemoveBtn);
            foreach (WindowsElement element in _nerveCenterPages.NetworkBoostAppList)
            {
                appNameList.Add(VantageCommonHelper.GetAttributeValue(element, "Name").Substring(6));
            }
            Process[] process = Process.GetProcesses();
            foreach (Process ps in process)
            {
                try
                {
                    string psDec = ps.MainModule.FileVersionInfo.FileDescription;
                    if (appNameList.Contains(psDec))
                    {
                        ps.Kill();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        [When(@"Pop up window apps is no running")]
        public void WhenPopUpWindowAppsIsNoRunning()
        {
            for (int i = 0; i < 3; i++)
            {
                WhenSetPopWindowNoAppIsRunning();
                if (_nerveCenterPages.LegionEdgeNetworkBoostSubpageCloseAddBtn != null)
                {
                    _nerveCenterPages.LegionEdgeNetworkBoostSubpageCloseAddBtn.Click();
                }
                else if (_nerveCenterPages.NetworkBoostAddAppNoRunningClose != null)
                {
                    _nerveCenterPages.NetworkBoostAddAppNoRunningClose.Click();
                }
            }
        }

    }
}
