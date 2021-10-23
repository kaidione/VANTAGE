using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_DesktopPowerManagementSteps
{
    [Binding]
    public sealed class PowerPlanSettingsSteps
    {
        private bool _isSupport = false;
        private WindowsDriver<WindowsElement> _session;
        private DesktopPowerManagementPages _desktopPowerManagementPages;
        public static Tuple<string, string, string, string> Powerplantvalues;
        public PowerPlanSettingsSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"The Machine support DPM")]
        public void GivenTheMachineSupportDPM()
        {
            _isSupport = DesktopPowerManagementHelper.GetMachineIsDPM();
            Assert.IsTrue(_isSupport, "The Machine does not support DPM Feature,Info:" + DesktopPowerManagementHelper.DPMTips);
        }

        [Given(@"The All Power plans default value")]
        public void GivenTheAllPowerPlansDefaultValue()
        {
            DesktopPowerManagementHelper.SetDefaultValuesForAllPowerPlans();
        }

        [When(@"Go to Power Plan Section for DPM")]
        public void WhenGoToPowerPlanSectionForDPM()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanTitle, "Power Plan Title not found");
            _desktopPowerManagementPages.DPMPowerPlanTitle.Click();
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerSettingsTitle, "Power Settings Title not found");
            _desktopPowerManagementPages.DPMPowerSettingsTitle.Click();
        }

        [Then(@"The Power Plan section is below Power use section")]
        public void ThenThePowerPlanSectionIsBelowPowerUseSection()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanTitle, "Power Plan Title not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerUseTitle, "Power Use Title not found");
            if (_desktopPowerManagementPages.DPMPowerPlanTitle.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanDescription.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanLabel.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanDropdown.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanProfileLabel.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanPerformanceLabel.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanTemperatureLabel.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y < _desktopPowerManagementPages.DPMPowerUseHibernateDropdown.Location.Y)
            {
                Assert.Fail("The Power Plan Section Is not Below Power Use");
            }
        }

        [Then(@"The Power Plan text is correct")]
        public void ThenThePowerPlanTextIsCorrect(string multilineText)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.AreEqual(multilineText, _desktopPowerManagementPages.DPMPowerPlanDescription.Text, "The Power Plan Text Is Not Correct");
        }

        [Then(@"The Power Plan Section only current plan showing")]
        public void ThenThePowerPlanSectionOnlyCurrentPlanShowing()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan);
            Assert.AreEqual(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeInfo().SCHEME_GUID_NAME, actual, "The Current Power Plan Scheme is not Correct");
            Assert.Zero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "There is extra content is shown");
        }

        [When(@"User click power plan in drop down menu")]
        public void WhenUserClickPowerPlanInDropDownMenu()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanDropdown, "The PowerPlanDropdown not found");
            _desktopPowerManagementPages.DPMPowerPlanDropdown.Click();
            if (_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count <= 0)
            {
                _desktopPowerManagementPages.DPMPowerPlanDropdown.Click();
            }
            Thread.Sleep(2000);
            Assert.NotZero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "The PowerPlanDropdown item total is zero");
        }

        [Then(@"The all predefined power plan in drop down menu should be showing")]
        public void ThenTheAllPredefinedPowerPlanInDropDownMenuShouldBeShowing()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = false;
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                flag = false;
                foreach (DesktopPowerManagementHelper.PowerPlanScheme scheme in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
                {
                    if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item) == scheme.SCHEME_GUID_NAME)
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag, "The " + item + "Not found");
            }
            foreach (var powerplan in DesktopPowerManagementHelper.DPMPowerPlanDefault)
            {
                flag = false;
                foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
                {
                    if (_desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item) == powerplan)
                    {
                        flag = true;
                        break;
                    }
                }
                Assert.IsTrue(flag, "The power plan （default）" + powerplan + "Not found");
            }
        }

        [When(@"User select one power plan in drop down menu '(.*)'")]
        public void WhenUserSelectOnePowerPlanInDropDownMenu(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotZero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "The PowerPlanDropdown item total is zero");
            if (_desktopPowerManagementPages.UserSelectOnePowerPlanInDropDownMenu(plan) == false)
            {
                Console.WriteLine("Try again >> User select one power plan in drop down menu");
                _desktopPowerManagementPages.UserSelectOnePowerPlanInDropDownMenu(plan);
            }
        }

        [Then(@"The power plan dropdown list is collapsed normally")]
        public void ThenThePowerPlanDropdownListIsCollapsedNormally()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.Zero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "There is extra content is shown");
        }

        [Then(@"The power plan only showing the chosed power plan just now '(.*)'")]
        public void ThenThePowerPlanOnlyShowingTheChosedPowerPlanJustNow(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.Zero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "The PowerPlanDropdown item total is not zero");
            string curplanname = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan);
            Assert.AreEqual(plan, curplanname, "The chosed power plan not show");
        }

        [Then(@"The values in Power use section also changed accordingly when choose another power plan")]
        public void ThenTheValuesInPowerUseSectionAlsoChangedAccordinglyWhenChooseAnotherPowerPlan()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string curdisplayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string curhddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string cursleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string curhibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            if (Powerplantvalues.Item1 != curdisplayvalue || Powerplantvalues.Item2 != curhddvalue || Powerplantvalues.Item3 != cursleepvalue || Powerplantvalues.Item4 != curhibernatevalue)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("The Values In Power Use Section not change!");
        }

        [Then(@"The values in Windows Settings are consistent with the values in DPM page '(.*)'")]
        public void ThenTheValuesInWindowsSettingsAreConsistentWithTheValuesInDPMPage(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            Tuple<string, string, string, string, bool> DPMPowerplantvalues;
            DPMPowerplantvalues = _desktopPowerManagementPages.GetDPMPagePowerPlantValues();
            if (DPMPowerplantvalues.Item5 == false)
            {
                Console.WriteLine("Try again > TGetDPMPagePowerPlantValues");
                DPMPowerplantvalues = _desktopPowerManagementPages.GetDPMPagePowerPlantValues();
            }
            DesktopPowerManagementHelper.PowerPlanScheme scheme = DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo();
            Assert.AreEqual(plan, scheme.SCHEME_GUID_NAME, "The current power plan is incorrect");
            string curplanname = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan);
            Assert.AreEqual(plan, curplanname, "The chosed power plan not show");
            Powerplantvalues = DesktopPowerManagementHelper.GetPowerPlanTimeInfo(scheme);
            Assert.AreEqual(Powerplantvalues.Item1, DPMPowerplantvalues.Item1, "The display value show are not consistent. windows value:" + scheme.SCHEM_DISPLAY_AC_Setting_Second);
            Assert.AreEqual(Powerplantvalues.Item2, DPMPowerplantvalues.Item2, "The hdd value show are not consistent. windows value:" + scheme.SCHEM_DISK_AC_Setting_Second);
            Assert.AreEqual(Powerplantvalues.Item3, DPMPowerplantvalues.Item3, "The sleep value show are not consistent. windows value:" + scheme.SCHEM_SLEEP_AC_Setting_Second);
            Assert.AreEqual(Powerplantvalues.Item4, DPMPowerplantvalues.Item4, "The hibernate show are not consistent. windows value:" + scheme.SCHEM_HIBERNATE_AC_Setting_Second);
        }

        [When(@"User select one power plan in windows settings '(.*)'")]
        public void WhenUserSelectOnePowerPlanInWindowsSettings(string plan)
        {
            foreach (var item in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (item.SCHEME_GUID_NAME == plan)
                {
                    DesktopPowerManagementHelper.PowerPlanOptionsControl(DesktopPowerManagementHelper.PowerPlanOptions.SetPowerPlan, item);
                    break;
                }
            }
            Assert.AreEqual(plan, DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeInfo().SCHEME_GUID_NAME, "User select one power plan in windows settings fail");
        }

        [Then(@"The values in Power use section also changed accordingly when choose another power plan in windows settings '(.*)'")]
        public void ThenTheValuesInPowerUseSectionAlsoChangedAccordinglyWhenChooseAnotherPowerPlanInWindowsSettings(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            DesktopPowerManagementHelper.PowerPlanScheme planScheme = DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo();
            WhenUserSelectOnePowerPlanInWindowsSettings(plan);
            Thread.Sleep(2000);
            DesktopPowerManagementHelper.PowerPlanScheme curplanScheme = DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeSettingsInfo();

            if (planScheme.SCHEM_DISK_AC_Setting_Second != curplanScheme.SCHEM_DISK_AC_Setting_Second || planScheme.SCHEM_DISPLAY_AC_Setting_Second != curplanScheme.SCHEM_DISPLAY_AC_Setting_Second ||
                planScheme.SCHEM_SLEEP_AC_Setting_Second != curplanScheme.SCHEM_DISPLAY_AC_Setting_Second || planScheme.SCHEM_HIBERNATE_AC_Setting_Second != curplanScheme.SCHEM_HIBERNATE_AC_Setting_Second)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("The Values In Windows Settings not change!");
        }

        [When(@"User create new power plan in windows settings '(.*)'")]
        public void WhenUserCreateNewPowerPlanInWindowsSettings(string plan)
        {
            if (plan.Length > 128)
            {
                var tag = DesktopPowerManagementHelper.ManualCreatePowerPlan(plan);
                Assert.IsTrue(tag, "Manual Create Power Plan Fail");
            }
            else
            {
                DesktopPowerManagementHelper.PowerPlanOptionsControl(DesktopPowerManagementHelper.PowerPlanOptions.CreatePowerPlan, DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeInfo(), plan);
            }
        }

        [Then(@"The current power plan name is new create power plan")]
        public void ThenTheCurrentPowerPlanNameIsNewCreatePowerPlan()
        {
            Thread.Sleep(30000);
            ThenThePowerPlanSectionOnlyCurrentPlanShowing();
        }

        [Then(@"The new power plan is show in power plan drop down menu '(.*)'")]
        public void ThenTheNewPowerPlanIsShowInPowerPlanDropDownMenu(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = false;
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                if (plan == _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item))
                {
                    flag = true;
                    item.SendKeys("hover");
                    break;
                }
            }
            Assert.IsTrue(flag, "The new create power plan not show");
        }

        [Then(@"The new power plan is hover in power plan drop down menu '(.*)'")]
        public void ThenTheNewPowerPlanIsHoverInPowerPlanDropDownMenu(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = false;
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                if (plan == _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item))
                {
                    flag = true;
                    SendKeys.SendWait("{PGDN}");
                    Thread.Sleep(1000);
                    int x = item.Location.X + item.Rect.Width / 4;
                    int y = item.Location.Y + item.Rect.Height / 2;
                    VantageCommonHelper.SetCursorPos(x, y);
                    VantageCommonHelper.mouse_event(VantageCommonHelper.MOUSEEVENTF_ABSOLUTE | VantageCommonHelper.MOUSEEVENTF_LEFTDOWN, Convert.ToInt32(x), Convert.ToInt32(y), 0, 0);
                    Thread.Sleep(1500);
                    break;
                }
            }
            Assert.IsTrue(flag, "The new create power plan not show");
        }

        [Then(@"The new power plan only has 128 characters is show in tips '(.*)'")]
        public void ThenTheNewPowerPlanOnlyHas128CharactersIsShowInTips(string plan)
        {
            plan = plan.Substring(0, 128);
            bool flag = false;
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                if (plan == _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item))
                {
                    flag = true;
                    break;
                }
            }
            Assert.IsTrue(flag, "The new create power plan not show and the name length > 128");
            ThenTheNewPowerPlanIsHoverInPowerPlanDropDownMenu(plan);
        }

        [When(@"User delete one power plan in windows settings '(.*)'")]
        public void WhenUserDeleteOnePowerPlanInWindowsSettings(string plan)
        {
            bool flag = false;
            foreach (var powerPlan in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (plan == powerPlan.SCHEME_GUID_NAME)
                {
                    DesktopPowerManagementHelper.PowerPlanOptionsControl(DesktopPowerManagementHelper.PowerPlanOptions.DeletePowerPlan, powerPlan);
                    flag = true;
                    break;
                }
            }
            Assert.IsTrue(flag, "The power plan not delete");
        }

        [Then(@"Current power plan will refreshed to real power plan '(.*)'")]
        public void ThenCurrentPowerPlanWillRefreshedToRealPowerPlan(string plan)
        {
            Thread.Sleep(5000);
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            if (_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count != 0)
            {
                _desktopPowerManagementPages.DPMPowerPlanDropdown.Click();
                Thread.Sleep(5000);
            }
            Assert.Zero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "The PowerPlanDropdown item total is not zero");
            string curplanname = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan);
            Assert.AreEqual(plan, curplanname, "The chosed power plan not show");
        }

        [Then(@"The deleted power plan in Windows Settings will not be shown '(.*)'")]
        public void ThenTheDeletedPowerPlanInWindowsSettingsWillNotBeShown(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = true;
            Assert.NotZero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "The PowerPlanDropdown item total is zero");
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                if (plan == _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item))
                {
                    flag = false;
                    break;
                }
            }
            Assert.IsTrue(flag, "The delete power plan still show in Windows Settings");
        }

        [Then(@"The deleted power plan in power plan drop down menu will not be shown '(.*)'")]
        public void ThenTheDeletedPowerPlanInPowerPlanDropDownMenuWillNotBeShown(string plan)
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = true;
            foreach (var item in _desktopPowerManagementPages.DPMPowerPlanDropdownList)
            {
                if (plan == _desktopPowerManagementPages.GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item))
                {
                    flag = false;
                    item.SendKeys("hover");
                    break;
                }
            }
            Assert.IsTrue(flag, "The delete power plan still show in power plan drop down menu");
        }

        [Given(@"Get current power plan values in power plan page")]
        public void GivenGetCurrentPowerPlanValuesInPowerPlanPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string displayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string hddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string sleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string hibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            Powerplantvalues = new Tuple<string, string, string, string>(displayvalue, hddvalue, sleepvalue, hibernatevalue);
            Console.WriteLine("The current power plan values[display-hdd-sleep-hibernate]:" + displayvalue + ";" + hddvalue + ";" + sleepvalue + ";" + hibernatevalue);
        }

        [Given(@"Set special value for new power plan '(.*)'")]
        public void GivenSetSpecialValueForNewPowerPlan(string plan)
        {
            foreach (var item in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (item.SCHEME_GUID_NAME == plan)
                {
                    DesktopPowerManagementHelper.PowerPlanOptionsControl(DesktopPowerManagementHelper.PowerPlanOptions.SetPowerPlan, item);
                    DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DiskAC, 10);
                    DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DisplayAC, 5);
                    DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.SleepAC, 45);
                    DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.HibernateAC, 0);
                }
            }
        }

        [Given(@"Get Session for Power Plan Settings")]
        public void GivenSessionForPowerPlanSettings()
        {
            //DesktopPowerManagementHelper.RelaunchVantageToMyDevicePage();
            _session = DesktopPowerManagementHelper.Session;
        }

    }
}
