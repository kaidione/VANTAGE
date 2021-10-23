using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_DesktopPowerManagementSteps
{
    [Binding]
    public sealed class PowerUseOptionsAndSettingsSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private List<WindowsElement> _windowsElementList;
        private DesktopPowerManagementPages _desktopPowerManagementPages;

        public PowerUseOptionsAndSettingsSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"The collapse text is showing normally in power settings page")]
        public void ThenTheCollapseTextIsShowingNormallyInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink not found");
            Assert.AreEqual(ExpandCollapseState.Expanded, _desktopPowerManagementPages.GetDPMExpandCollapseState(), "The Collapse Expand status is error");
        }

        [Then(@"The expand text is showing normally in power settings page")]
        public void ThenTheExpandTextIsShowingNormallyInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink not found");
            Assert.AreEqual(ExpandCollapseState.Collapsed, _desktopPowerManagementPages.GetDPMExpandCollapseState(), "The Collapse Expand status is error");
        }

        [When(@"User Change Collapse Expand status in power settings page '(.*)'")]
        public void WhenUserChangeCollapseExpandStatusInPowerSettingsPage(string status)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink not found");
            switch (status.ToLower())
            {
                case "expand":
                    _desktopPowerManagementPages.SetDPMExpandCollapseState(ExpandCollapseState.Expanded);
                    break;
                case "collapse":
                    _desktopPowerManagementPages.SetDPMExpandCollapseState(ExpandCollapseState.Collapsed);
                    break;
                default:
                    Assert.Fail("WhenUserClickCollapseExpandButtonInPowerSettingsPage");
                    break;
            }
        }


        [Then(@"The all contents below the Power are collapsed in power settings page")]
        public void ThenTheAllContentsBelowThePowerAreCollapsedInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseTitle, "The DPMPowerUseTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanTitle, "The DPMPowerPlanTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanDropdown, "The DPMPowerPlanDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerSettingsTitle, "The DPMPowerSettingsTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The DPMPowerButtonDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The DPMRequiredSignInDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMRequiredSignInNote, "The DPMRequiredSignInNote still show");
        }

        [When(@"Back to the homepage via vantage L logo for Power settings")]
        public void WhenBackToTheHomepageViaVantageLLogoForPowerSettings()
        {
            //_desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            //Assert.NotNull(_desktopPowerManagementPages.LenovoVantageLogo, "The LenovoVantageLogo not found");
            //_desktopPowerManagementPages.LenovoVantageLogo.Click();
            DasheboardPage_NarrowWindow _dasheboardPage = new DasheboardPage_NarrowWindow(_session);
            Assert.NotNull(_dasheboardPage.dashboardMenu, "The dashboardMenu not found");
            _dasheboardPage.dashboardMenu.Click();
        }

        [Then(@"The all contents below the Power are showing in power settings page")]
        public void ThenTheAllContentsBelowThePowerAreShowingInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseTitle, "The DPMPowerUseTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanTitle, "The DPMPowerPlanTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanDropdown, "The DPMPowerPlanDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerSettingsTitle, "The DPMPowerSettingsTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The DPMPowerButtonDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The DPMRequiredSignInDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMRequiredSignInNote, "The DPMRequiredSignInNote not found");
        }

        [When(@"The user random modify power plan valus")]
        public void WhenTheUserRandomModifyPowerPlanValus()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Random random = new Random();
            WhenTheUserClickSpecialDropDownMenuInPowerUseSection("hdd");
            WhenTheUserSelectedSpecialValusInPowerUseSection(random.Next(2, 16), "hdd");
            WhenTheUserClickSpecialDropDownMenuInPowerUseSection("display");
            WhenTheUserSelectedSpecialValusInPowerUseSection(random.Next(2, 16), "display");
            WhenTheUserClickSpecialDropDownMenuInPowerUseSection("sleep");
            WhenTheUserSelectedSpecialValusInPowerUseSection(random.Next(2, 16), "sleep");
            WhenTheUserClickSpecialDropDownMenuInPowerUseSection("hibernate");
            WhenTheUserSelectedSpecialValusInPowerUseSection(random.Next(2, 16), "hibernate");
        }

        [When(@"The user click special drop down menu in power use section '(.*)'")]
        public void WhenTheUserClickSpecialDropDownMenuInPowerUseSection(string dropmenu)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            switch (dropmenu)
            {
                case "hdd":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown not found");
                    _desktopPowerManagementPages.DPMPowerUseHDDDropdown.Click();
                    break;
                case "display":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown not found");
                    _desktopPowerManagementPages.DPMPowerUseDisplayDropdown.Click();
                    break;
                case "sleep":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown not found");
                    _desktopPowerManagementPages.DPMPowerUseSleepDropdown.Click();
                    break;
                case "hibernate":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown not found");
                    _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Click();
                    break;
                default:
                    Assert.Fail("WhenTheUserClickSpecialDropDownMenuInPowerUse not run");
                    break;
            }
        }

        [When(@"The user selected special valus '(.*)' in power use section '(.*)'")]
        public void WhenTheUserSelectedSpecialValusInPowerUseSection(int index, string dropmenu)
        {
            Random random = new Random();
            if (index >= 15)
            {
                index = random.Next(2, 16);
            }
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string value = string.Empty;
            switch (dropmenu)
            {
                case "hdd":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseHDDDropdownList.Count, "The DPMPowerUseHDDDropdown item total is zero");
                    value = _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd, _desktopPowerManagementPages.DPMPowerUseHDDDropdownList[index]);
                    _desktopPowerManagementPages.DPMPowerUseHDDDropdownList[index].Click();
                    break;
                case "display":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseDisplayDropdownList.Count, "The DPMPowerUseDisplayDropdown item total is zero");
                    value = _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay, _desktopPowerManagementPages.DPMPowerUseDisplayDropdownList[index]);
                    _desktopPowerManagementPages.DPMPowerUseDisplayDropdownList[index].Click();
                    break;
                case "sleep":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseSleepDropdownList.Count, "The DPMPowerUseSleepDropdown item total is zero");
                    value = _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep, _desktopPowerManagementPages.DPMPowerUseSleepDropdownList[index]);
                    _desktopPowerManagementPages.DPMPowerUseSleepDropdownList[index].Click();
                    break;
                case "hibernate":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseHibernateDropdownList.Count, "The DPMPowerUseHibernateDropdown item total is zero");
                    value = _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate, _desktopPowerManagementPages.DPMPowerUseHibernateDropdownList[index]);
                    _desktopPowerManagementPages.DPMPowerUseHibernateDropdownList[index].Click();
                    break;
                default:
                    Assert.Fail("WhenTheUserSelectedSpecialValusInPowerUseSection not run");
                    break;
            }
            Console.WriteLine("Power Use set values Info:" + "Menu:" + dropmenu + " Index:" + index + " Value:" + value);
        }

        [Given(@"Get Session for Power Use")]
        public void GivenGetSessionForPowerUse()
        {
            _session = DesktopPowerManagementHelper.Session;
        }

        [Then(@"The '(.*)' options in the drop down menu list")]
        public void ThenTheOptionsInTheDropDownMenuList(string dropmenu)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            _windowsElementList = new List<WindowsElement>();
            switch (dropmenu)
            {
                case "hdd":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseHDDDropdownList.Count, "The DPMPowerUseHDDDropdown item total is zero");
                    _windowsElementList = _desktopPowerManagementPages.DPMPowerUseHDDDropdownList;
                    break;
                case "display":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseDisplayDropdownList.Count, "The DPMPowerUseDisplayDropdown item total is zero");
                    _windowsElementList = _desktopPowerManagementPages.DPMPowerUseDisplayDropdownList;
                    break;
                case "sleep":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseSleepDropdownList.Count, "The DPMPowerUseSleepDropdown item total is zero");
                    _windowsElementList = _desktopPowerManagementPages.DPMPowerUseSleepDropdownList;
                    break;
                case "hibernate":
                    Assert.NotZero(_desktopPowerManagementPages.DPMPowerUseHibernateDropdownList.Count, "The DPMPowerUseHibernateDropdown item total is zero");
                    _windowsElementList = _desktopPowerManagementPages.DPMPowerUseHibernateDropdownList;
                    break;
                default:
                    Assert.Fail("ThenTheOptionsInTheDropDownMenuList not run");
                    break;
            }
            for (int i = 0; i < _windowsElementList.Count; i++)
            {

                Assert.AreEqual(DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[i], _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUse, _windowsElementList[i]), "The " + dropmenu + " options not show.");
            }
        }

        [Then(@"The drop down menu only show current value '(.*)'")]
        public void ThenTheDropDownMenuOnlyShowCurrentValue(string dropmenu)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string actual = string.Empty;
            string expected = string.Empty;
            switch (dropmenu)
            {
                case "hdd":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown not found");
                    actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
                    expected = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo()).Item2;
                    Assert.AreEqual(expected, actual, "The valus is error" + dropmenu);
                    break;
                case "display":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown not found");
                    actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
                    expected = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo()).Item1;
                    Assert.AreEqual(expected, actual, "The valus is error " + dropmenu);
                    break;
                case "sleep":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown not found");
                    actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
                    expected = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo()).Item3;
                    Assert.AreEqual(expected, actual, "The valus is error " + dropmenu);
                    break;
                case "hibernate":
                    Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown not found");
                    actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
                    expected = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo()).Item4;
                    Assert.AreEqual(expected, actual, "The valus is error " + dropmenu);
                    break;
                default:
                    Assert.Fail("ThenTheDropDownMenuOnlyShowCurrentValue not run");
                    break;
            }
        }

        [Then(@"The two values in Windows Settings are consistent with the values in DPM page '(.*)'")]
        public void ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage(string dropmenu)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            DesktopPowerManagementHelper.PowerPlanScheme scheme = DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo();
            switch (dropmenu)
            {
                case "hdd":
                    string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
                    Assert.AreEqual(DesktopPowerManagementHelper.GetPowerPlanTimeInfo(scheme).Item2, hddvalue, "The hdd value show are not consistent. windows value:" + scheme.SCHEM_DISK_AC_Setting_Second);
                    break;
                case "display":
                    string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
                    Assert.AreEqual(DesktopPowerManagementHelper.GetPowerPlanTimeInfo(scheme).Item1, displayvalue, "The display value show are not consistent. windows value:" + scheme.SCHEM_DISPLAY_AC_Setting_Second);
                    break;
                case "sleep":
                    string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
                    Assert.AreEqual(DesktopPowerManagementHelper.GetPowerPlanTimeInfo(scheme).Item3, sleepvalue, "The sleep value show are not consistent. windows value:" + scheme.SCHEM_SLEEP_AC_Setting_Second);
                    break;
                case "hibernate":
                    string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
                    Assert.AreEqual(DesktopPowerManagementHelper.GetPowerPlanTimeInfo(scheme).Item4, hibernatevalue, "The hibernate show are not consistent. windows value:" + scheme.SCHEM_HIBERNATE_AC_Setting_Second);
                    break;
                case "all":
                    ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage("hdd");
                    ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage("display");
                    ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage("sleep");
                    ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage("hibernate");
                    break;
                default:
                    Assert.Fail("ThenTheTwoValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage not run");
                    break;
            }
        }

        [Then(@"The values will show previous value in window settings")]
        public void ThenTheValuesWillShowPreviousValueInWindowSettings()
        {
            var before = PowerPlanSettingsSteps.Powerplantvalues;
            var now = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo());
            Assert.AreEqual(before, now, "The values will not show previous value in window settings");
        }

        [Then(@"The current value is consistent with the previous value or changed '(.*)'")]
        public void ThenTheCurrentValueIsConsistentWithThePreviousValueOrChanged(string values)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            string displaychangevalue = DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[0])];
            string hddchangevalue = DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[1])];
            string sleepchangevalue = DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[2])];
            string hibernatechangevalue = DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[3])];
            var lastvalues = PowerPlanSettingsSteps.Powerplantvalues;
            VantageConstContent.ShowTips = "The Display,Hdd,Sleep,Hibernate Values before IMC Stop:" + lastvalues.Item1 + " ; " + lastvalues.Item2 + " ; " + lastvalues.Item3 + " ; " + lastvalues.Item4 +
                "\r\nThe Display,Hdd,Sleep,Hibernate change Values after IMC Stop:" + displaychangevalue + " ; " + hddchangevalue + " ; " + sleepchangevalue + " ; " + hibernatechangevalue +
                "\r\nThe Display,Hdd,Sleep,Hibernate Values after IMC Start:" + displayvalue + " ; " + hddvalue + " ; " + sleepvalue + " ; " + hibernatevalue;
        }

        [Then(@"The current value is consistent with the previous value in windows settings or changed '(.*)'")]
        public void ThenTheCurrentValueIsConsistentWithThePreviousValueInWindowsSettingsOrChanged(string values)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            var lastvalues = PowerPlanSettingsSteps.Powerplantvalues;
            var nowvalues = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo());
            VantageConstContent.ShowTips = "The Display,Hdd,Sleep,Hibernate Values before IMC Stop:" + lastvalues.Item1 + " ; " + lastvalues.Item2 + " ; " + lastvalues.Item3 + " ; " + lastvalues.Item4 +
                "\r\nThe Display,Hdd,Sleep,Hibernate change Values after IMC Stop:" + nowvalues.Item1 + " ; " + nowvalues.Item2 + " ; " + nowvalues.Item3 + " ; " + nowvalues.Item4 +
                "\r\nThe Display,Hdd,Sleep,Hibernate Values after IMC Start:" + displayvalue + " ; " + hddvalue + " ; " + sleepvalue + " ; " + hibernatevalue;
        }


        [Then(@"The items are showing changed values '(.*)'")]
        public void ThenTheItemsAreShowingChangedValues(string values)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            Assert.AreEqual(DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[0])], displayvalue, "The display value not change");
            Assert.AreEqual(DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[1])], hddvalue, "The hdd value not change");
            Assert.AreEqual(DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[2])], sleepvalue, "The sleep value not change");
            Assert.AreEqual(DesktopPowerManagementHelper.DPMPowerUseDropDownMenuList[int.Parse(values.Split(',')[3])], hibernatevalue, "The hibernate value not change");
        }

        [When(@"User set power plan values in windows settings '(.*)'")]
        public void WhenUserSetPowerPlanValuesInWindowsSettings(string values)
        {
            var tag = false;
            tag = DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DisplayAC, int.Parse(values.Split(',')[0]));
            Assert.IsTrue(tag, "display set fail");
            tag = DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DiskAC, int.Parse(values.Split(',')[1]));
            Assert.IsTrue(tag, "disk set fail");
            tag = DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.SleepAC, int.Parse(values.Split(',')[2]));
            Assert.IsTrue(tag, "sleep set fail");
            tag = DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.HibernateAC, int.Parse(values.Split(',')[3]));
            Assert.IsTrue(tag, "hibernate set fail");
        }

        [Then(@"The set values not included in list in Windows Settings and values show as blank")]
        public void ThenTheSetValuesNotIncludedInListInWindowsSettingsAndValuesShowAsBlank()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            var nowvalues = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo());
            Console.WriteLine("The Display,Hdd,Sleep,Hibernate Values:" + nowvalues.Item1 + " ; " + nowvalues.Item2 + " ; " + nowvalues.Item3 + " ; " + nowvalues.Item4);
            Assert.IsEmpty(displayvalue, "The display value not null");
            Assert.IsEmpty(hddvalue, "The hdd value not null");
            Assert.IsEmpty(sleepvalue, "The sleep value not null");
            Assert.IsEmpty(hibernatevalue, "The hibernate value not null");
        }

    }
}
