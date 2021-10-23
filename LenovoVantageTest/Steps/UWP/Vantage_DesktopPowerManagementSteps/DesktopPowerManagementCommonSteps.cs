using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.Helper.ProgrammableLogicControllersHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_DesktopPowerManagementSteps
{
    [Binding]
    public sealed class DesktopPowerManagementCommonSteps
    {

        private string _startTime = string.Empty;
        private string _pageSource = string.Empty;
        private string _backupDPMFolder = @"C:\ThinkDPMPlugin";
        private WindowsDriver<WindowsElement> _session;
        private DesktopPowerManagementPages _desktopPowerManagementPages;
        private static VantageUI vantageUI = new VantageUI();

        public DesktopPowerManagementCommonSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Then(@"The all DPM contents are showing in power settings page")]
        public void ThenTheAllDPMContentsAreShowingInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            Assert.NotNull(_desktopPowerManagementPages.DPMFeatureDescription, "The DPMFeatureDescription not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMCollapseExpandTitle, "The DPMCollapseExpandTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink not found");

            //power use section
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseTitle, "The DPMPowerUseTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseDescription, "The .DPMPowerUseDescription not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseDisplayLabel, "The DPMPowerUseDisplayLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHDDLabel, "The DPMPowerUseHDDLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseSleepLabel, "The DPMPowerUseSleepLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHibernateLabel, "The DPMPowerUseHibernateLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown not found");

            //power plan section
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanTitle, "The DPMPowerPlanTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanDescription, "The DPMPowerPlanDescription not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanLabel, "The DPMPowerPlanLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanDropdown, "The DPMPowerPlanDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanProfileLabel, "The DPMPowerPlanProfileLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanPerformanceLabel, "The DPMPowerPlanPerformanceLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanTemperatureLabel, "The DPMPowerPlanTemperatureLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerPlanUsageLabel, "The DPMPowerPlanUsageLabel not found");

            //global power settings
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerSettingsTitle, "The DPMPowerSettingsTitle not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerSettingsDescription, "The DPMPowerSettingsDescription not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerButtonLabel, "The DPMPowerButtonLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The DPMPowerButtonDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMRequiredSignInLabel, "The DPMRequiredSignInLabel not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The DPMRequiredSignInDropdown not found");
            Assert.NotNull(_desktopPowerManagementPages.DPMRequiredSignInNote, "The DPMRequiredSignInNote not found");
        }

        [Then(@"The all DPM contents are hidden in power settings page")]
        public void ThenTheAllDPMContentsAreHiddenInPowerSettingsPage()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            int count = 0;
            while (_desktopPowerManagementPages.DPMCollapseExpandTitle != null || _desktopPowerManagementPages.DPMCollapseExpandLink != null && count < 5)
            {
                count++;
                vantageUI.ResetVantageThroughSettings();
                GivenOOBEForDPM();
                VantageUI.instance.LaunchVantageWithProtocol();
                VantageCommonHelper.FlushGifContainer(_session);
                VantageCommonHelper.CloseAlertWindow(_session);
                InformationalWebDriver _webDriver = new InformationalWebDriver(_session, _session);
                VantageHardwareSettingsQuickSettingsRegressionfunction deviceSettingsPages = new VantageHardwareSettingsQuickSettingsRegressionfunction(_webDriver);
                deviceSettingsPages.GivenGoToMyDeviceSettingsPage();
                PowerPlanSettingsSteps powerPlanSettings = new PowerPlanSettingsSteps(_webDriver);
                powerPlanSettings.GivenSessionForPowerPlanSettings();
                GivenGetSessionForDPMCommon();
                ThenTheAllDPMContentsAreHiddenInPowerSettingsPage();
            }
            //Assert.Null(_desktopPowerManagementPages.DPMFeatureDescription, "The DPMFeatureDescription still show");
            Assert.Null(_desktopPowerManagementPages.DPMCollapseExpandTitle, "The DPMCollapseExpandTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink still show");

            //power use section
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseTitle, "The DPMPowerUseTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseDescription, "The .DPMPowerUseDescription still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseDisplayLabel, "The DPMPowerUseDisplayLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHDDLabel, "The DPMPowerUseHDDLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseSleepLabel, "The DPMPowerUseSleepLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHibernateLabel, "The DPMPowerUseHibernateLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown still show");

            //power plan section
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanTitle, "The DPMPowerPlanTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanDescription, "The DPMPowerPlanDescription still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanLabel, "The DPMPowerPlanLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanDropdown, "The DPMPowerPlanDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanProfileLabel, "The DPMPowerPlanProfileLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanPerformanceLabel, "The DPMPowerPlanPerformanceLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanTemperatureLabel, "The DPMPowerPlanTemperatureLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerPlanUsageLabel, "The DPMPowerPlanUsageLabel still show");

            //global power settings
            Assert.Null(_desktopPowerManagementPages.DPMPowerSettingsTitle, "The DPMPowerSettingsTitle still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerSettingsDescription, "The DPMPowerSettingsDescription still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerButtonLabel, "The DPMPowerButtonLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMPowerButtonDropdown, "The DPMPowerButtonDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMRequiredSignInLabel, "The DPMRequiredSignInLabel still show");
            Assert.Null(_desktopPowerManagementPages.DPMRequiredSignInDropdown, "The DPMRequiredSignInDropdown still show");
            Assert.Null(_desktopPowerManagementPages.DPMRequiredSignInNote, "The DPMRequiredSignInNote still show");
        }


        [Then(@"The all DPM contents are showing in page source")]
        public void ThenTheAllDPMContentsAreShowingInPageSource()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            bool flag = false;
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMFeatureDescription, "The DPMFeatureDescription not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMCollapseExpandTitle, "The DPMCollapseExpandTitle not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMCollapseExpandLink, "The DPMCollapseExpandLink not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");

            //power use section
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseTitle, "The DPMPowerUseTitle not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseDescription, "The .DPMPowerUseDescription not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseDisplayLabel, "The DPMPowerUseDisplayLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseDisplayDropdown, "The DPMPowerUseDisplayDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseHDDLabel, "The DPMPowerUseHDDLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseHDDDropdown, "The DPMPowerUseHDDDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseSleepLabel, "The DPMPowerUseSleepLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseSleepDropdown, "The DPMPowerUseSleepDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseHibernateLabel, "The DPMPowerUseHibernateLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerUseHibernateDropdown, "The DPMPowerUseHibernateDropdown not found");

            //power plan section
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanTitle, "The DPMPowerPlanTitle not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanDescription, "The DPMPowerPlanDescription not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanLabel, "The DPMPowerPlanLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanDropdown, "The DPMPowerPlanDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanProfileLabel, "The DPMPowerPlanProfileLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanPerformanceLabel, "The DPMPowerPlanPerformanceLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanTemperatureLabel, "The DPMPowerPlanTemperatureLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerPlanUsageLabel, "The DPMPowerPlanUsageLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");

            //global power settings
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerSettingsTitle, "The DPMPowerSettingsTitle not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerSettingsDescription, "The DPMPowerSettingsDescription not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerButtonLabel, "The DPMPowerButtonLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMPowerButtonDropdown, "The DPMPowerButtonDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMRequiredSignInLabel, "The DPMRequiredSignInLabel not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMRequiredSignInDropdown, "The DPMRequiredSignInDropdown not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
            flag = DesktopPowerManagementHelper.FindWindowsElementExistWithPageSource(_pageSource, _desktopPowerManagementPages.DPMRequiredSignInNote, "The DPMRequiredSignInNote not found");
            Assert.IsTrue(flag, "The all DPM contents are not showing in page source");
        }


        [Given(@"Get Session for DPM Common")]
        public void GivenGetSessionForDPMCommon()
        {
            _session = DesktopPowerManagementHelper.Session;
        }

        [Given(@"OOBE for DPM")]
        public void GivenOOBEForDPM()
        {
            _session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            _session.Manage().Window.Maximize();
            DesktopPowerManagementHelper.Session = _session;
            Thread.Sleep(5000);
            if (DesktopPowerManagementHelper.ResetVantage)
            {
                DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.Default);
                InformationalWebDriver _webDriver = new InformationalWebDriver(_session, _session);
                VantageHardwareSettingsQuickSettingsRegressionfunction _vantageHardwareSettings = new VantageHardwareSettingsQuickSettingsRegressionfunction(_webDriver);
                _vantageHardwareSettings.WhenCloseLenovoVantage();
                _session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                _session.Manage().Window.Maximize();
                DesktopPowerManagementHelper.Session = _session;
                Thread.Sleep(5000);
                _session = DesktopPowerManagementHelper.Session;
            }
            var common = VantageCommonHelper.FindElementByXPath(_session, VantageConstContent.OoBeNextButton, 10);
            var le = VantageCommonHelper.FindElementByXPath(_session, VantageConstContent.LeOobeLicenceCheckBox, 10);
            if (common != null || le != null)
            {
                VantageCommonHelper.OObeNetVantage30(_session, false);
            }
            DesktopPowerManagementHelper.ResetVantage = false;
        }

        [Given(@"The Machine does not support DPM")]
        public void GivenTheMachineDoesNotSupportDPM()
        {
            bool flag = DesktopPowerManagementHelper.GetMachineIsDPM();
            Assert.IsFalse(flag, "The machine support DPM,please run on Brand is not Think,Lenovo or SubBrand is not ThinkCentre machine");
        }

        [When(@"The user execute the command '(.*)'")]
        public void WhenTheUserExecuteTheCommand(string comamnd)
        {
            Process.Start(comamnd);
        }

        [When(@"Remove DPM Plugin")]
        public void WhenRemoveDPMPlugin()
        {
            if (Directory.Exists(DesktopPowerManagementHelper.DPMFolder))
            {
                if (Directory.Exists(_backupDPMFolder))
                {
                    Directory.Delete(_backupDPMFolder, true);
                }
                try
                {
                    Directory.Move(DesktopPowerManagementHelper.DPMFolder, _backupDPMFolder);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Remove plugin fail," + ex.ToString());
                }
            }
            else
            {
                Assert.Fail("The DPM plugin folder not found." + DesktopPowerManagementHelper.DPMFolder);
            }
        }

        [Then(@"the DPM Plugin not found")]
        public void ThenTheDPMPluginNotFound()
        {
            if (!Directory.Exists(DesktopPowerManagementHelper.DPMFolder))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("delete DPM Plugin Folder fail.");
            }
        }

        [Then(@"Restore DPM Plugin")]
        public void ThenRestoreDPMPlugin()
        {
            if (Directory.Exists(_backupDPMFolder))
            {
                try
                {
                    if (Directory.Exists(DesktopPowerManagementHelper.DPMFolder))
                    {
                        Directory.Delete(DesktopPowerManagementHelper.DPMFolder, true);
                    }
                    Thread.Sleep(3000);
                    Directory.Move(_backupDPMFolder, DesktopPowerManagementHelper.DPMFolder);
                }
                catch (Exception ex)
                {
                    Assert.Fail("Restore plugin fail," + ex.ToString());
                }
            }
            else
            {
                Assert.Fail("Restore plugin fail");
            }
        }

        [Given(@"Restore DPM Plugin")]
        public void GivenRestoreDPMPlugin()
        {
            if (!Directory.Exists(DesktopPowerManagementHelper.DPMFolder))
            {
                ThenRestoreDPMPlugin();
            }
        }

        [When(@"Do Vantage coverage installation")]
        public void WhenDoVantageCoverageInstallation()
        {
            Console.WriteLine("The method not available");
            VantageCommonHelper.InstallVantage();
            var _session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            _session.Manage().Window.Maximize();
            VantageCommonHelper.OObeNetVantage30(_session, true);
        }

        [When(@"Change Vantage Service '(.*)'")]
        public void WhenChangeVantageService(string service)
        {
            switch (service.ToLower())
            {
                case "qa":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.QA);
                    break;
                case "qa-2":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.QA2);
                    break;
                case "stage":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.Stage);
                    break;
                case "product":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.Product);
                    break;
                case "sit":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.SITBeta);
                    break;
                case "beta":
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.SITBeta);
                    break;
                default:
                    DesktopPowerManagementHelper.ChangeVantageService(DesktopPowerManagementHelper.VantageServiceOption.Default);
                    break;
            }
        }

        [Then(@"The Power Plan Section only current plan showing for performance")]
        public void ThenThePowerPlanSectionOnlyCurrentPlanShowingForPerformance()
        {
            _desktopPowerManagementPages = new DesktopPowerManagementPages(_session);
            string actual = string.Empty;
            for (int i = 0; i < 30; i++)
            {
                actual = _desktopPowerManagementPages.GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan);
                if (DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeInfo().SCHEME_GUID_NAME == actual)
                {
                    break;
                }
                Thread.Sleep(1000);
            }
            Assert.AreEqual(DesktopPowerManagementHelper.GetCurrentPowerPlanSchemeInfo().SCHEME_GUID_NAME, actual, "The Current Power Plan Scheme is not Correct");
            Assert.Zero(_desktopPowerManagementPages.DPMPowerPlanDropdownList.Count, "There is extra content is shown");
        }

        [Given(@"Get Now Time for DPM performance test")]
        public void GivenGetNowTimeForDPMPerformanceTest()
        {
            _startTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        [Then(@"The DPM loading and show correctly for performance test '(.*)'")]
        public void ThenTheDPMLoadingAndShowCorrectlyForPerformanceTest(int delay)
        {
            string endTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int time = IntelligentCooling.IntelligentCoolingBaseHelper.GetDiffTime(_startTime, endTime);
            if (time >= delay)
            {
                Assert.Fail("The DPM can shown,but the DPM Page Loading Time out. Time Info:" + _startTime + ";" + endTime + ";" + time);
            }
            else
            {
                Assert.IsTrue(true);
            }
        }

        [Given(@"Get Page Source Info for DPM performance test")]
        public void GivenGetPageSourceInfoForDPMPerformanceTest()
        {
            _pageSource = _session.PageSource;
        }

        [Given(@"Set Sleep Hdd Display Hibernate to Nerver")]
        public void GivenSetSleepHddDisplayHibernateToNerver()
        {
            DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DiskAC, 0);
            DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.DisplayAC, 0);
            DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.SleepAC, 0);
            DesktopPowerManagementHelper.PowerSettingsOptionsControl(DesktopPowerManagementHelper.PowerSettingsOptions.HibernateAC, 0);
            Common.StopService(VantageConstContent.IMCServiceName);  //Stop IMC Service
            Common.StartService(VantageConstContent.IMCServiceName);  //Start IMC Service
        }

        [Then(@"Write log '(.*)' to report for '(.*)' type")]
        public void ThenWriteLogToReportForFeature(string detail, string type)
        {
            string info = DesktopPowerManagementHelper.WriteLogToTestReport(detail, type);
            Hooks.WriteInfoReport(info);
            VantageConstContent.ShowTips = string.Empty;
        }

        [Given(@"Set System Power Status '(.*)' via PLC")]
        public void GivenSetSystemPowerStatusViaPLC(string status)
        {
            ProgrammableLogicControllersHelper plc = new ProgrammableLogicControllersHelper();
            PLCStatus plcStatus = status == "on" ? PLCStatus.Start : PLCStatus.Stop;
            bool powerAcDc = status == "on" ? true : false;
            plc.StarPLC(plcStatus);
            plc.StartPLCViaOptionPanel(plcStatus);
            Assert.AreEqual(powerAcDc, VantageCommonHelper.JudgeInsertStatusIsOn(), "GivenSetSystemPowerStatusViaPLC Fail,info: " + status);
        }


    }
}
