using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public sealed class GamingAutoCloseAllTestSteps
    {
        private InformationalWebDriver _webDriver;
        private NerveCenterPages _nerveCenterPages;
        private List<string> _curApplist = new List<string>();

        public GamingAutoCloseAllTestSteps(InformationalWebDriver appDriver)
        {
            this._webDriver = appDriver;
        }

        [Then(@"The auto close will be shown within legion home page")]
        public void ThenTheAutoCloseWillBeShownWithinLegionHomePage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            bool tag = false;
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "The auto close gear not show");
            if (_nerveCenterPages.LegionEdgeAutoCloseToggleOn != null && _nerveCenterPages.LegionEdgeAutoCloseIcon.Location.X < _nerveCenterPages.LegionEdgeAutoCloseToggleOn.Location.X)
            {
                tag = true;
            }
            if (_nerveCenterPages.LegionEdgeAutoCloseToggleOff != null && _nerveCenterPages.LegionEdgeAutoCloseIcon.Location.X < _nerveCenterPages.LegionEdgeAutoCloseToggleOff.Location.X)
            {
                tag = true;
            }
            Assert.IsTrue(tag, "The auto close toggle show");
        }

        [Then(@"The auto close will be shown within subpage")]
        public void ThenTheAutoCloseWillBeShownWithinSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoCloseDescription, "The Auto close description not show");
            if (_nerveCenterPages.AutoCloseToggleOff != null || _nerveCenterPages.AutoCloseToggleOn != null)
            {
                Assert.IsTrue(true, "The auto close toggle show");
            }
            else
            {
                Assert.IsTrue(false, "The auto close toggle not show");
            }
        }

        [Given(@"Go to auto close subpage")]
        public void GivenGoToAutoCloseSubpage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseIcon, "GivenGoToAutoCloseSubpage() ,The auto close gear not show");
            _nerveCenterPages.LegionEdgeAutoCloseIcon.Click();
            Thread.Sleep(2000);
            if (_nerveCenterPages.AutoCloseBackLink == null)
            {
                _nerveCenterPages.LegionEdgeAutoCloseIcon.Click();
                Thread.Sleep(2000);
            }
            Assert.NotNull(_nerveCenterPages.AutoCloseBackLink, "GivenGoToAutoCloseSubpage() ,go to auto close page fail!");
        }

        [When(@"The user turn (.*) auto close toggle within home page")]
        public void WhenTheUserTurnAutoCloseToggleWithinHomePage(string togglestatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (togglestatus.ToLower())
            {
                case "on":
                    if (_nerveCenterPages.LegionEdgeAutoCloseToggleOn == null)
                    {
                        _nerveCenterPages.LegionEdgeAutoCloseToggleOff?.Click();
                    }
                    break;
                case "off":
                    if (_nerveCenterPages.LegionEdgeAutoCloseToggleOff == null)
                    {
                        _nerveCenterPages.LegionEdgeAutoCloseToggleOn?.Click();
                    }
                    break;
                default:
                    Assert.Fail("The WhenTheUserTurnAutoCloseToggleWithinHomePage not run");
                    break;
            }
        }

        [Then(@"The auto close toggle status is on or off within home page (.*)")]
        public void ThenTheAutoCloseToggleStatusIsOnOrOffWithinHomePage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseToggleOn, "The auto close toggle is on not found");
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.LegionEdgeAutoCloseToggleOff, "The auto close toggle is off not found");
                    break;
                default:
                    Assert.Fail("The ThenTheAutoCloseToggleStatusIsOnOrOffWithinHomePage not run");
                    break;
            }
        }

        [When(@"The user turn (.*) auto close toggle within subpage")]
        public void WhenTheUserTurnAutoCloseToggleWithinSubpage(string togglestatus)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (togglestatus.ToLower())
            {
                case "on":
                    if (_nerveCenterPages.AutoCloseToggleOn == null)
                    {
                        _nerveCenterPages.AutoCloseToggleOff?.Click();
                    }
                    break;
                case "off":
                    if (_nerveCenterPages.AutoCloseToggleOff == null)
                    {
                        _nerveCenterPages.AutoCloseToggleOn?.Click();
                    }
                    break;
                default:
                    Assert.Fail("The WhenTheUserTurnAutoCloseToggleWithinSubpage not run");
                    break;
            }
        }

        [Then(@"The auto close toggle status is on or off within subpage (.*)")]
        public void ThenTheAutoCloseToggleStatusIsOnOrOffWithinSubpage(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "on":
                    Assert.IsNotNull(_nerveCenterPages.AutoCloseToggleOn, "The auto close toggle is on not found");
                    break;
                case "off":
                    Assert.IsNotNull(_nerveCenterPages.AutoCloseToggleOff, "The auto close toggle is off not found");
                    break;
                default:
                    Assert.Fail("The henTheAutoCloseToggleStatusIsOnOrOffWithinSubpage not run");
                    break;
            }
        }

        [When(@"The user click auto close back button")]
        public void WhenTheUserClickAutoCloseBackButton()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoCloseBackLink, "The auto close back btn not found");
            _nerveCenterPages.AutoCloseBackLink.Click();
            Thread.Sleep(1500);
        }

        [Then(@"The current page is home or subpage for auto close (.*)")]
        public void ThenTheCurrentPageIsHomeOrSubpageForAutoClose(string obj)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (obj.ToLower())
            {
                case "home":
                    ThenTheAutoCloseWillBeShownWithinLegionHomePage();
                    break;
                case "subpage":
                    ThenTheAutoCloseWillBeShownWithinSubpage();
                    break;
                default:
                    Assert.Fail("The ThenTheCurrentPageIsHomeOrSubpageForAutoClose not run");
                    break;
            }
        }

        [When(@"The user Click add button for auto close")]
        public void WhenTheUserClickAddButtonForAutoClose()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoCloseAddBtn, "The auto close add app btn not found");
            _nerveCenterPages.AutoCloseAddBtn?.Click();
            Thread.Sleep(1500);
        }

        [Then(@"The turn on auto close popup window show or hide (.*)")]
        public void ThenTheTurnOnAutoClosePopupWindowShowOrHide(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindow, "The Popup windows not show");
                    Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowCloseBtn, "The Popup windows close button not show");
                    Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowCheckbox, "The Popup windows check box button not show");
                    Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowTurnOnBtn, "The Popup windows TurnOn button not show");
                    Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowNotNowBtn, "The Popup windows NotNow button not show");
                    break;
                case "hide":
                    Assert.IsNull(_nerveCenterPages.AutoClosePopupWindow, "The Popup windows still show");
                    Assert.IsNull(_nerveCenterPages.AutoClosePopupWindowCloseBtn, "The Popup windows close button still show");
                    Assert.IsNull(_nerveCenterPages.AutoClosePopupWindowCheckbox, "The Popup windows check box button still show");
                    Assert.IsNull(_nerveCenterPages.AutoClosePopupWindowTurnOnBtn, "The Popup windows TurnOn button still show");
                    Assert.IsNull(_nerveCenterPages.AutoClosePopupWindowNotNowBtn, "The Popup windows NotNow button still show");
                    break;
                default:
                    Assert.Fail("The ThenTheTurnOnAutoClosePopupWindowShowOrHide not run");
                    break;
            }
        }

        [Then(@"The turn on auto close popup window dont ask again checkbox status (.*)")]
        public void ThenTheTurnOnAutoClosePopupWindowDontAskAgainCheckboxStatus(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            ToggleState state = VantageCommonHelper.GetToggleStatus(_nerveCenterPages.AutoClosePopupWindowCheckbox);
            switch (status.ToLower())
            {
                case "selected":
                    Assert.AreEqual(ToggleState.On, state, "The dont ask again checkbox status is " + state + " Expect :" + status);
                    break;
                case "unselected":
                    Assert.AreEqual(ToggleState.Off, state, "The dont ask again checkbox status is " + state + " Expect :" + status);
                    break;
                default:
                    Assert.Fail("The ThenTheTurnOnAutoClosePopupWindowDontAskAgainCheckboxStatus not run");
                    break;
            }
        }

        [When(@"The user (.*) dont ask again checkbox on auto close popup window")]
        public void WhenTheUserDontAskAgainCheckboxOnAutoClosePopupWindow(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            ToggleState state = VantageCommonHelper.GetToggleStatus(_nerveCenterPages.AutoClosePopupWindowCheckbox);
            switch (status.ToLower())
            {
                case "selected":
                    if (state == ToggleState.Off)
                    {
                        _nerveCenterPages.AutoClosePopupWindowCheckbox?.Click();
                    }
                    Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.AutoClosePopupWindowCheckbox), "The Dont Ask Again Checkbox unselected.");
                    break;
                case "unselected":
                    if (state == ToggleState.On)
                    {
                        _nerveCenterPages.AutoClosePopupWindowCheckbox?.Click();
                    }
                    Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(_nerveCenterPages.AutoClosePopupWindowCheckbox), "The Dont Ask Again Checkbox selected.");
                    break;
                default:
                    Assert.Fail("The WhenTheUserDontAskAgainCheckboxOnAutoClosePopupWindow not run");
                    break;
            }
        }


        [Then(@"The auto close description is correct")]
        public void ThenTheAutoCloseDescriptionIsCorrect(string multilineText)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.AreEqual(multilineText, _nerveCenterPages.AutoCloseDescription.Text, "The Auto Close Description text incorrect");
        }

        [When(@"The user click X button on turn on auto close popup window")]
        public void WhenTheUserClickXButtonOnTurnOnAutoClosePopupWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowCloseBtn, "The auto close popup window X btn not found");
            _nerveCenterPages.AutoClosePopupWindowCloseBtn?.Click();
            Thread.Sleep(1500);
        }

        [When(@"The user click X button on add apps popup window")]
        public void WhenTheUserClickXButtonOnAddAppsPopupWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.AutoCloseAddappWindows != null)
            {
                Assert.IsNotNull(_nerveCenterPages.AutoCloseAddappWindowsCloseBtn, "The add apps popup window X btn not found");
                _nerveCenterPages.AutoCloseAddappWindowsCloseBtn?.Click();
                return;
            }
            if (_nerveCenterPages.AutoCloseNoRuningAppsWindow != null)
            {
                Assert.IsNotNull(_nerveCenterPages.AutoCloseNoRuningAppsWindowCloseBtn, "The No Running Apps Popup winodws Close Btn not found.");
                _nerveCenterPages.AutoCloseNoRuningAppsWindowCloseBtn?.Click();
                return;
            }
            Assert.Fail("The WhenTheUserClickXButtonOnAddAppsPopupWindow() not run");
        }

        [Then(@"The add apps to auto close popup window show or hide (.*)")]
        public void ThenTheAddAppsToAutoClosePopupWindowShowOrHide(string status)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (status.ToLower())
            {
                case "show":
                    for (int i = 0; i < 15; i++)
                    {
                        if (_nerveCenterPages.AutoCloseAddappWindows != null)
                        {
                            Assert.IsNotNull(_nerveCenterPages.AutoCloseAddappWindows, "The add apps Popup windows not show");
                            Assert.IsNotNull(_nerveCenterPages.AutoCloseAddappWindowsCloseBtn, "The add apps Popup windows close button not show");
                            return;
                        }
                        if (_nerveCenterPages.AutoCloseNoRuningAppsWindow != null)
                        {
                            Assert.IsNotNull(_nerveCenterPages.AutoCloseNoRuningAppsWindow, "The No Running Apps Popup winodws not found.");
                            Assert.IsNotNull(_nerveCenterPages.AutoCloseNoRuningAppsWindowCloseBtn, "The No Running Apps Popup winodws Close Btn not found.");
                            return;
                        }
                        Thread.Sleep(1000);
                    }
                    Assert.Fail("The ThenTheAddAppsToAutoClosePopupWindowShowOrHide() not run! Time Out");
                    break;
                case "hide":
                    Assert.IsNull(_nerveCenterPages.AutoCloseAddappWindows, "The add apps Popup windows still show");
                    Assert.IsNull(_nerveCenterPages.AutoCloseAddappWindowsCloseBtn, "The add apps Popup windows close button still show");
                    break;
                default:
                    Assert.Fail("The ThenTheAddAppsToAutoClosePopupWindowShowOrHide not run");
                    break;
            }
        }

        [When(@"The user click Not Now link on turn on auto close popup window")]
        public void WhenTheUserClickNotNowLinkOnTurnOnAutoClosePopupWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowNotNowBtn, "The add apps popup window not now link not found");
            _nerveCenterPages.AutoClosePopupWindowNotNowBtn?.Click();
            Thread.Sleep(1500);
        }

        [When(@"The user click turn on button on auto close popup window")]
        public void WhenTheUserClickTurnOnButtonOnAutoClosePopupWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AutoClosePopupWindowTurnOnBtn, "The add apps popup window turn on btn not found");
            _nerveCenterPages.AutoClosePopupWindowTurnOnBtn?.Click();
            Thread.Sleep(1500);
        }

        [Given(@"The user add all or one apps to auto close (.*)")]
        public void GivenTheUserAddAllOrOneAppsToAutoClose(string obj)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            switch (obj.ToLower())
            {
                case "all":
                    while (true)
                    {
                        if (_nerveCenterPages.AutoCloseNoRuningAppsWindow != null && _nerveCenterPages.AutoCloseNoRuningAppsWindowCloseBtn != null)
                        {
                            break;
                        }
                        else
                        {
                            foreach (WindowsElement app in _nerveCenterPages.AutoCloseAddappList)
                            {
                                app?.Click();
                                Thread.Sleep(500);
                            }
                            WhenTheUserClickXButtonOnAddAppsPopupWindow();
                            WhenTheUserClickAddButtonForAutoClose();
                        }
                    }
                    break;
                case "one":
                    if (_nerveCenterPages.AutoCloseAddappList.Count == 0)
                    {
                        _nerveCenterPages.AutoCloseAddappWindowsCloseBtn.Click();
                        WhenLaunchTheSpecifiedAppAsCurrentUser("IE");
                        WhenTheUserClickAddButtonForAutoClose();
                    }
                    Assert.NotZero(_nerveCenterPages.AutoCloseAddappList.Count, "The app total is 0 on add app window");
                    _nerveCenterPages.AutoCloseAddappList[0]?.Click();
                    break;
                case "more":
                    if (_nerveCenterPages.AutoCloseAddappList.Count < 2)
                    {
                        Assert.Fail("The run app total < 2 on add app window");
                    }
                    _nerveCenterPages.AutoCloseAddappList[0]?.Click();
                    break;
                default:
                    Assert.Fail("The GivenTheUserAddAllOrOneAppsToAutoClose() not run");
                    break;
            }
        }

        [Then(@"The app count is zero on add apps popup window")]
        public void ThenTheAppCountIsZeroOnAddAppsPopupWindow()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.Zero(_nerveCenterPages.AutoCloseAddappList.Count, "There are apps exist on Add app popup window");
            Assert.IsNotNull(_nerveCenterPages.AutoCloseNoRuningAppsWindow, "The No Running Apps Popup winodws not found.");
            Assert.IsNotNull(_nerveCenterPages.AutoCloseNoRuningAppsWindowCloseBtn, "The No Running Apps Popup winodws Close Btn not found.");
        }

        [Given(@"The user remove one or all apps from auto close (.*)")]
        public void GivenTheUserRemoveOneOrAllAppsFromAutoClose(string obj)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Thread.Sleep(3000);
            switch (obj.ToLower())
            {
                case "all":
                    while (true)
                    {
                        if (_nerveCenterPages.AutoCloseAddedAppList.Count > 2)
                        {
                            _nerveCenterPages.AutoCloseAddedAppList[2]?.Click();
                            Thread.Sleep(500);
                        }
                        else
                        {
                            break;
                        }
                    }
                    break;
                case "one":
                    if (_nerveCenterPages.AutoCloseAddedAppList.Count > 2)
                    {
                        _nerveCenterPages.AutoCloseAddedAppList[2]?.Click();
                    }
                    else
                    {
                        Assert.Fail("The added app total is 0");
                    }
                    break;
                default:
                    Assert.Fail("The GivenTheUserRemoveOneOrAllAppsFromAutoClose() not run");
                    break;
            }
        }

        [Then(@"The app total on popup windows is the same as plugin contract request total")]
        public void ThenTheAppTotalOnPopupWindowsIsTheSameAsPluginContractRequestTotal()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            int uitotal = _nerveCenterPages.AutoCloseAddappList.Count;
            int plugintotal = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAppCount).Count;
            Assert.AreEqual(uitotal, plugintotal, "Tips: UI apps total:" + uitotal + " Plugin apps total:" + plugintotal);
        }

        [Then(@"The app icon change or unchange on add app popup window is correct")]
        public void ThenTheAppIconChangeOrUnchangeOnAddAppPopupWindowIsCorrect()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            for (int i = 0; i < _nerveCenterPages.AutoCloseAddappList.Count; i++)
            {
                ToggleState state = VantageCommonHelper.GetToggleStatus(_nerveCenterPages.AutoCloseAddappList[i]);
                if (i == 0)
                {
                    Assert.AreEqual(ToggleState.On, state, "Tips: Default the frist app checked. Current No:" + i + 1);
                }
                else
                {
                    Assert.AreEqual(ToggleState.Off, state, "Tips: Default the frist app checked. Current No:" + i + 1);
                }
            }
        }

        [Then(@"The checked app will be disappeared")]
        public void ThenTheCheckedAppWillBeDisappeared()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string checkedApp = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAppCount)[0];
            WhenTheUserClickXButtonOnAddAppsPopupWindow();
            WhenTheUserClickAddButtonForAutoClose();
            foreach (WindowsElement appname in _nerveCenterPages.AutoCloseAddappList)
            {
                Assert.AreNotEqual(checkedApp, appname.GetAttribute("Name").Substring(4), "The checked app still show");
            }
            foreach (string app in NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded))
            {
                Assert.AreNotEqual(checkedApp, app, "The checked app still show");
            }
        }

        [Then(@"The checked app added to auto close area")]
        public void ThenTheCheckedAppAddedToAutoCloseArea()
        {
            string checkedApp = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAppCount)[0];
            WhenTheUserClickXButtonOnAddAppsPopupWindow();
            string addedApp = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded)[0];
            Assert.AreEqual(checkedApp, addedApp, "tips:The checked app not added to autoclose");
        }

        [Then(@"The unchecked app not added to auto close area")]
        public void ThenTheUncheckedAppNotAddedToAutoCloseArea()
        {
            var addedlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded);
            var noaddlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
            foreach (string added in addedlist)
            {
                foreach (string noadded in noaddlist)
                {
                    //Debug Assert.Warn("Added AppName:" + added + "Not Added AppName" + noadded);
                    Assert.AreNotEqual(added, noadded, "Added AppName:" + added + "Not Added AppName" + noadded);
                }
            }
        }

        [Given(@"The user selected one app and unchecked")]
        public void GivenTheUserSelectedOneAppAndUnchecked()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.NotZero(_nerveCenterPages.AutoCloseAddappList.Count, "The app total is 0 on add app window");
            var element = _nerveCenterPages.AutoCloseAddappList[0];
            if (ToggleState.On == VantageCommonHelper.GetToggleStatus(element))
            {
                Assert.Fail("The app should not be selected is fail");
            }
            if (ToggleState.Off == VantageCommonHelper.GetToggleStatus(element))
            {
                element?.Click();
            }
            Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(element), "the selected app checked is fail");
            if (ToggleState.On == VantageCommonHelper.GetToggleStatus(element))
            {
                element?.Click();
            }
            Assert.AreEqual(ToggleState.Off, VantageCommonHelper.GetToggleStatus(element), "the selected app unchecked is fail");
        }

        [Then(@"The selected app and unchecked not added to auto close area")]
        public void ThenTheSelectedAppAndUncheckedNotAddedToAutoCloseArea()
        {
            var addedlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded);
            var uncheckedapp = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAppCount)[0];
            foreach (string app in addedlist)
            {
                //Debug Assert.Warn("Added AppName:" + app + "Not Added AppName" + uncheckedapp);
                Assert.AreNotEqual(app, uncheckedapp, "Added AppName:" + app + " Not Added AppName:" + uncheckedapp);
            }
        }

        [When(@"Launch the specified app as current user (.*)")]
        public void WhenLaunchTheSpecifiedAppAsCurrentUser(string obj)
        {
            foreach (var app in Enum.GetNames(typeof(NerveCenterHelper.AppName)))
            {
                if (app == obj)
                {
                    bool tag = NerveCenterHelper.LaunchAppAsCurrentUser(NerveCenterHelper.GetCommonAppInformation(app).File);
                    Assert.IsTrue(tag, "Please set password is '1',or run other app");
                }
            }
            Thread.Sleep(2000);
        }

        [When(@"Stop the specified app (.*)")]
        public void WhenStopTheSpecifiedApp(string path)
        {
            bool stopTag = false;
            if (path == "all")
            {
                stopTag = true;
            }
            foreach (var app in Enum.GetNames(typeof(NerveCenterHelper.AppName)))
            {
                if (stopTag == false)
                {
                    if (app != path)
                    {
                        continue;
                    }
                }
                string proName = string.Empty;
                if (app != NerveCenterHelper.AppName.GameWorldOfWarcraft.ToString()) //Stop app list
                {
                    proName = NerveCenterHelper.GetCommonAppInformation(app).ProcessName;
                    if (proName.Contains(";"))
                    {
                        foreach (var item in proName.Split(';'))
                        {
                            SettingsBase.KillProcess(item);
                        }
                    }
                    else
                    {
                        SettingsBase.KillProcess(proName);
                    }
                }
                if (app == NerveCenterHelper.AppName.GameWorldOfWarcraft.ToString()) //Stop Gaming
                {
                    proName = NerveCenterHelper.GetCommonAppInformation(NerveCenterHelper.AppName.GameWorldOfWarcraft.ToString(), NerveCenterHelper.NerveCenterGamingAppIniFileCopy).ProcessName;
                    if (proName.Contains(";"))
                    {
                        foreach (var item in proName.Split(';'))
                        {
                            SettingsBase.KillProcess(item);
                        }
                    }
                    else
                    {
                        SettingsBase.KillProcess(proName);
                    }
                }
                if (stopTag == false)
                {
                    break;
                }
            }
        }

        [Given(@"The current run app list for auto close")]
        public void GivenTheCurrentRunAppListForAutoClose()
        {
            _curApplist.Clear();
            _curApplist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
        }

        [Then(@"Stop the specified app will not show on add appp to auto close (.*)")]
        public void ThenStopTheSpecifiedAppWillNotShowOnAddApppToAutoClose(string appName)
        {
            var templist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
            bool flag = false;
            var endlist = _curApplist.Except(templist).ToList();
            appName = NerveCenterHelper.GetCommonAppInformation(appName).DescName;
            foreach (string app in endlist)
            {
                if (appName.ToLower() == app.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            Assert.IsTrue(flag, "The ThenStopTheSpecifiedAppWillNotShowOnAddApppToAutoClose() is Fail");
            flag = false;
            foreach (string app in _curApplist)
            {
                if (appName.ToLower() == app.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            Assert.IsTrue(flag, "The App is not shown Pop up windows");
            flag = false;
            foreach (string app in templist)
            {
                if (appName.ToLower() == app.ToLower())
                {
                    flag = true;
                    break;
                }
            }
            Assert.IsFalse(flag, "Stop app and the App is still shown Pop up windows");
        }

        [When(@"The user add specified app to auto close (.*)")]
        public void WhenTheUserAddSpecifiedAppToAutoClose(string appName)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var templist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
            appName = NerveCenterHelper.GetCommonAppInformation(appName).DescName;
            foreach (WindowsElement appname in _nerveCenterPages.AutoCloseAddappList)
            {
                if (appName == appname.GetAttribute("Name").Substring(4))
                {
                    appname?.Click();
                    Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(appname), "the selected app is fail");
                }
            }
        }

        [Then(@"The select app added to auto close subpage (.*)")]
        public void ThenTheSelectAppAddedToAutoCloseSubpage(string appName)
        {
            var templist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded);
            bool tag = false;
            appName = NerveCenterHelper.GetCommonAppInformation(appName).DescName;
            foreach (var item in templist)
            {
                if (item.ToLower() == appName.ToLower())
                {
                    tag = true;
                    break;
                }
            }
            Assert.IsTrue(tag, "The selected app not added to auto close subpage");
        }

        [When(@"Launch the specifie game (.*)")]
        public void WhenLaunchTheSpecifieGame(string game)
        {
            int count = 30;
            var fileName = NerveCenterHelper.GetCommonAppInformation(game, NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            bool runstatus = false;
            while (true)
            {
                if (runstatus == false)
                {
                    if (File.Exists(fileName.File))
                    {
                        Process.Start(fileName.File);
                    }
                    if (File.Exists(fileName.Package))
                    {
                        Process.Start(fileName.Package);
                    }
                    foreach (var pro in Process.GetProcesses())
                    {
                        if (fileName.ProcessName.Contains(";") && fileName.ProcessName.ToLower().Contains(pro.ProcessName.ToLower()))
                        {
                            runstatus = true;
                        }
                        if (pro.ProcessName.ToLower() == fileName.ProcessName.ToLower())
                        {
                            runstatus = true;
                        }
                    }
                }
                Thread.Sleep(2000);
                if (NerveCenterHelper.GetGameRunningState())
                {
                    Thread.Sleep(4000);
                    break;
                }
                if (count < 0)
                {
                    Assert.Warn("Check game is running Time Out,It will try again");
                    Common.StopService(VantageConstContent.IMCServiceName);  //Stop IMC Service
                    Common.StartService(VantageConstContent.IMCServiceName);  //Start IMC Service
                    Thread.Sleep(4000);
                    if (NerveCenterHelper.GetGameRunningState())
                    {
                        Thread.Sleep(4000);
                        break;
                    }
                    else
                    {
                        Assert.Fail("Check game is running Time Out and try again,still fail");
                    }
                }
                count--;
            }
        }

        [Then(@"The added app run or not run (.*) (.*)")]
        public void ThenTheAddedAppRunOrNotRun(string appName, string status)
        {
            Process[] ps = Process.GetProcesses();
            appName = NerveCenterHelper.GetCommonAppInformation(appName).ProcessName;
            bool tag = false;
            switch (status.ToLower())
            {
                case "run":
                    foreach (var p in ps)
                    {
                        if (appName.Contains(";") && appName.ToLower().Contains(p.ProcessName.ToLower()))
                        {
                            tag = true;
                            break;
                        }
                        if (p.ProcessName.ToLower() == appName.ToLower())
                        {
                            tag = true;
                            break;
                        }
                    }
                    Assert.IsTrue(tag, "The Added app not run." + appName);
                    break;
                case "norun":
                    foreach (var p in ps)
                    {
                        if (appName.Contains(";") && appName.ToLower().Contains(p.ProcessName.ToLower()) == false)
                        {
                            tag = true;
                            break;
                        }
                        if (p.ProcessName.ToLower() == appName.ToLower())
                        {
                            tag = true;
                            break;
                        }
                    }
                    Assert.IsFalse(tag, "The Added app is running." + appName);
                    break;
                default:
                    Assert.Fail("The ThenTheAddedAppRunOrNotRun() not run");
                    break;
            }
        }

        [When(@"Launch the specified (.*) app as current user")]
        public void WhenLaunchTheSpecifiedAppAsCurrentUser(int total)
        {
            _curApplist.Clear();
            int runTotal = 0;
            foreach (var app in Enum.GetNames(typeof(NerveCenterHelper.AppName)))
            {
                var fileName = NerveCenterHelper.GetCommonAppInformation(app);
                if (fileName.No < 9000)
                {
                    bool tag = NerveCenterHelper.LaunchAppAsCurrentUser(fileName.File);
                    Assert.IsTrue(tag, "Please set password is '1',or run other app,appInfo:" + fileName.File);
                    Thread.Sleep(600);
                    foreach (var pro in Process.GetProcesses())
                    {
                        tag = false;
                        if (fileName.ProcessName.Contains(";") && fileName.ProcessName.ToLower().Contains(pro.ProcessName.ToLower()))
                        {
                            _curApplist.Add(fileName.DescName);
                            runTotal++;
                            tag = true;
                            Console.WriteLine("WhenLaunchTheSpecifiedAppAsCurrentUser pass Info:" + app + " > " + fileName.File);
                            break;
                        }
                        if (pro.ProcessName.ToLower() == fileName.ProcessName.ToLower())
                        {
                            _curApplist.Add(fileName.DescName);
                            runTotal++;
                            tag = true;
                            Console.WriteLine("WhenLaunchTheSpecifiedAppAsCurrentUser pass Info:" + app + " > " + fileName.File);
                            break;
                        }
                    }
                    if (!tag)
                    {
                        Console.WriteLine("WhenLaunchTheSpecifiedAppAsCurrentUser fail Info:" + app + " > " + fileName.File);
                    }
                }
                if (_curApplist.Count >= total && runTotal >= total)
                {
                    break;
                }
            }
            var applist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
            if (applist.Count < total)
            {
                Console.WriteLine("WhenLaunchTheSpecifiedAppAsCurrentUser running app Info (IMC):" + string.Join("\r\n", applist));
                Assert.Fail("The launch App total < " + total + " run sucessful total >>" + applist.Count);
            }
        }

        [Then(@"The running (.*) apps show on add app to auto close popup windows")]
        public void ThenTheRunningAppsShowOnAddAppToAutoClosePopupWindows(int total)
        {
            var firstlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseNoAdded);
            foreach (var app in _curApplist)
            {
                var tag = false;
                foreach (var item in firstlist)
                {
                    if (app == item)
                    {
                        total--;
                        tag = true;
                    }
                }
                if (tag == false)
                {
                    Assert.Warn(app + "Not found.");
                }
            }
            if (total > 0)
            {
                Assert.Fail("The added app total < " + total);
            }
        }

        [When(@"The user add specified applist to auto close")]
        public void WhenTheUserAddSpecifiedApplistToAutoClose()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            foreach (var item in _curApplist)
            {
                foreach (WindowsElement appname in _nerveCenterPages.AutoCloseAddappList)
                {
                    if (item == appname.GetAttribute("Name").Substring(4))
                    {
                        appname?.Click();
                        Assert.AreEqual(ToggleState.On, VantageCommonHelper.GetToggleStatus(appname), "the selected app is fail");
                    }
                }
            }
        }

        [Then(@"The select applist added to auto close subpage")]
        public void ThenTheSelectApplistAddedToAutoCloseSubpage()
        {
            var firstlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded);
            foreach (var app in _curApplist)
            {
                bool tag = false;
                foreach (var item in firstlist)
                {
                    if (app == item)
                    {
                        tag = true;
                    }
                }
                Assert.IsTrue(tag, "The Selected app not added to auto close subpage");
            }
        }

        [When(@"The user hover to added app on auto close subpage (.*)")]
        public void WhenTheUserHoverToAddedAppOnAutoCloseSubpage(string appName)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Thread.Sleep(3000);
            var ele = _nerveCenterPages.AutoCloseAddedAppList[2];
            ele.SendKeys("hover");
            Thread.Sleep(3000);
        }

        [Then(@"The remove app will not show on auto close subpage")]
        public void ThenTheRemoveAppWillNotShowOnAutoCloseSubpage()
        {
            var firstlist = NerveCenterHelper.GetApplistHelper(NerveCenterHelper.GamingAppList.AutoCloseAdded);
            Assert.Zero(firstlist.Count, "Remove app fail");
        }

        [Then(@"The added applist run or not run (.*)")]
        public void ThenTheAddedApplistRunOrNotRun(string status)
        {
            foreach (var app in Enum.GetNames(typeof(NerveCenterHelper.AppName)))
            {
                var fileName = NerveCenterHelper.GetCommonAppInformation(app);
                foreach (var item in _curApplist)
                {
                    if (fileName.DescName == item)
                    {
                        ThenTheAddedAppRunOrNotRun(app, status);
                    }
                }
            }
        }

        [When(@"wait (.*) seconds for loading")]
        public void WhenWaitSecondsForLoading(int sec)
        {
            Thread.Sleep(sec * 1000);
        }

    }
}
