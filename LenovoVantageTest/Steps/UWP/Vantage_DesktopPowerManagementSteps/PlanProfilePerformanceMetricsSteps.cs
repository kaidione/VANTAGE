using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_DesktopPowerManagementSteps
{
    [Binding]
    public sealed class PlanProfilePerformanceMetricsSteps
    {
        private InformationalWebDriver _appDriver;
        private WindowsDriver<WindowsElement> _session;
        private PowerPlanSettingsSteps _powerPlanSettingsSteps;
        private DesktopPowerManagementPages _desktopPowerManagementPages;

        public PlanProfilePerformanceMetricsSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
            this._appDriver = appDriver;
        }

        [Then(@"The PLAN PROFILE text is showing below the Power Plan dropdown list")]
        public void ThenThePLANPROFILETextIsShowingBelowThePowerPlanDropDownList()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            if (_desktopPowerManagementPages.DPMPowerPlanDropdown.Location.Y > _desktopPowerManagementPages.DPMPowerPlanProfileLabel.Location.Y || _desktopPowerManagementPages.DPMPowerPlanDropdown.Location.Y > _desktopPowerManagementPages.DPMPowerPlanPerformanceLabel.Location.Y ||
               _desktopPowerManagementPages.DPMPowerPlanDropdown.Location.Y > _desktopPowerManagementPages.DPMPowerPlanTemperatureLabel.Location.Y || _desktopPowerManagementPages.DPMPowerPlanDropdown.Location.Y > _desktopPowerManagementPages.DPMPowerPlanUsageLabel.Location.Y)
            {
                Assert.Fail("The PLAN PROFILE text isn't showing below the Power Plan dropdown list");
            }
        }

        [Then(@"The PLAN PROFILE options are showing normally")]
        public void ThenThePLANPROFILEOptionsAreShowingNormally()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanProfileLabel, "The Plan Profile text not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanPerformanceLabel, "The Max performance option not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanTemperatureLabel, "The Max system temperature option not found");
            Assert.IsNotNull(_desktopPowerManagementPages.DPMPowerPlanUsageLabel, "The Max power usage option not found");
        }

        [Then(@"Take Screen shots for each predefined power plan profile")]
        public void ThenTakeScreenShotsForEachPredefinedPowerPlanProfile()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_appDriver.Session);
            if (_desktopPowerManagementPages.TakeScreenShotsForEachPredefinedPowerPlanProfile() == false)
            {
                Console.WriteLine("Try agagin > ThenTakeScreenShotsForEachPredefinedPowerPlanProfile");
                _desktopPowerManagementPages.TakeScreenShotsForEachPredefinedPowerPlanProfile();
            }
        }

        [Given(@"The user create one new power plan with the same configuration as the existing plan '(.*)'")]
        public void GivenTheUserCreateOneNewPowerPlanWithTheSameConfigurationAsTheExistingPlan(string plan)
        {
            foreach (DesktopPowerManagementHelper.PowerPlanScheme scheme in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                foreach (string planname in DesktopPowerManagementHelper.DPMPowerPlanDefault)
                {
                    if (planname == scheme.SCHEME_GUID_NAME && plan == planname)
                    {
                        DesktopPowerManagementHelper.PowerPlanOptionsControl(DesktopPowerManagementHelper.PowerPlanOptions.CopyPowerPlan, scheme);
                        break;
                    }
                }
            }
        }

        [Then(@"The new power plan profile is consistent with the each existing plan profile and values not changed")]
        public void ThenTheNewPowerPlanProfileIsConsistentWithTheEachExistingPlanProfileAndValuesNotChanged()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string curdisplayvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
            string curhddvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
            string cursleepvalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
            string curhibernatevalue = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
            if (PowerPlanSettingsSteps.Powerplantvalues.Item1 == curdisplayvalue && PowerPlanSettingsSteps.Powerplantvalues.Item2 == curhddvalue && PowerPlanSettingsSteps.Powerplantvalues.Item3 == cursleepvalue && PowerPlanSettingsSteps.Powerplantvalues.Item4 == curhibernatevalue)
            {
                Assert.IsTrue(true);
                return;
            }
            Assert.Fail("The Values In Power Use Section change!");
        }

    }
}
