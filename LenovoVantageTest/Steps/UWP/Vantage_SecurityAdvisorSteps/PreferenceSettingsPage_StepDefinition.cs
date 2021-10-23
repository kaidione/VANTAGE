using LenovoVantageTest.Metrics;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class PreferenceSettingsPage_StepDefinition
    {
        private readonly InformationalWebDriver webDriver;
        private PreferenceSettingPage preferSettingPage;
        private DasheboardPage_NarrowWindow navMenu;
        public PreferenceSettingsPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [When(@"go to preference page")]
        public void WhenGoToPreferencePage()
        {
            navMenu = new DasheboardPage_NarrowWindow(webDriver.Session);
            navMenu.navL.Click();
            navMenu.userMenu_PreferenceSettings.Click();
        }

        [Then(@"check device metric toggle show")]
        public void ThenCheckDeviceMetricToggleShow()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.IsNotNull(preferSettingPage.deviceMetricToggle);
        }

        [Then(@"check the device metric toggle status is (.*)")]
        public void ThenCheckTheDeviceMetricToggleStatusIs(string status)
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            string value = preferSettingPage.deviceMetricToggle.GetAttribute("Toggle.ToggleState");
            Assert.AreEqual(status, value);
        }

        [When(@"click device metric toggle")]
        public void WhenClickDeviceMetricToggle()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.deviceMetricToggle.Click();

        }


        [Then(@"it goes to preference setting app landing page and this page within vantage")]
        public void ThenItGoesToPreferenceSettingAppLandingPageAndThisPageWithinVantage()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.IsTrue(preferSettingPage.myDevicesettingsheadertitle.Displayed);
        }

        [Given(@"turn (.*) App features")]
        public void GivenTurnOffAppFeatures(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            if (preferSettingPage.AppFeaturesToggle.GetAttribute("Toggle.ToggleState") != re)
                preferSettingPage.AppFeaturesToggle.Click();
        }

        [Then(@"App features toggle switch is (.*)")]
        public void ThenAppFeaturesToggleSwitchIsOff(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.AreEqual(re, preferSettingPage.AppFeaturesToggle.GetAttribute("Toggle.ToggleState"));
        }

        [Then(@"user (.*) receive the message from this category for App features")]
        public void ThenUserCanTReceiveTheMessageFromThisCategoryForAppFeatures(string args)
        {
            string res = "";
            SQLiteHelper sqlHelper = new SQLiteHelper(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lenovo\ImController\PluginData\GenericMessagingPlugin\db\MessagingHistory.sqlite", "");
            DataTable dt = sqlHelper.ExecuteDataTable("select IsEnabled from MessagePreference where PreferenceType = 'AppFeatures'", null);
            sqlHelper.CloseConnection();
            if (dt.Rows.Count > 0)
            {
                res = dt.Rows[0][0].ToString();
            }
            if (args == "can't")
                Assert.AreEqual("0", res);
            else if (args == "can")
            {
                Assert.AreEqual("1", res);
            }
        }

        [Given(@"turn (.*) Marketing")]
        public void GivenTurnOnMarketing(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            if (preferSettingPage.MarketingToggle.GetAttribute("Toggle.ToggleState") != re)
                preferSettingPage.MarketingToggle.Click();

        }


        [Then(@"the dm related reg key value is (.*)")]
        public void ThenTheDmRelatedRegKeyValueIs(int p0)
        {
            string regkey = @"HKLM\SOFTWARE\Wow6432Node\Lenovo\AnonymousMetrics\Enabled";
            int value = (int)RegistryHelp.GetRegistryKeyValue(regkey, false);
            Assert.AreEqual(value, p0);
        }

        [Given(@"the metric toggle status is (.*)")]
        public void GivenTheMetricToggleStatusIs(string status)
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            string value = preferSettingPage.deviceMetricToggle.GetAttribute("Toggle.ToggleState");
            if (!value.Equals(status))
            {
                preferSettingPage.deviceMetricToggle.Click();
            }
        }

        [Then(@"marketing toggle switch is (.*)")]
        public void ThenMarketingToggleSwitchIsOn(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.AreEqual(re, preferSettingPage.MarketingToggle.GetAttribute("Toggle.ToggleState"));
        }

        [Then(@"user (.*) receive the message from this category for Marketing")]
        public void ThenUserCanReceiveTheMessageFromThisCategoryForMarketing(string args)
        {
            string res = "";
            SQLiteHelper sqlHelper = new SQLiteHelper(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lenovo\ImController\PluginData\GenericMessagingPlugin\db\MessagingHistory.sqlite", "");
            DataTable dt = sqlHelper.ExecuteDataTable("select IsEnabled from MessagePreference where PreferenceType = 'Marketing'", null);
            sqlHelper.CloseConnection();
            if (dt.Rows.Count > 0)
            {
                res = dt.Rows[0][0].ToString();
            }
            if (args == "can't")
                Assert.AreEqual("0", res);
            else if (args == "can")
            {
                Assert.AreEqual("1", res);
            }
        }

        [Given(@"turn (.*) Action Triggered")]
        public void GivenTurnOffActionTriggered(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            if (preferSettingPage.ActionTriggeredToggle.GetAttribute("Toggle.ToggleState") != re)
                preferSettingPage.ActionTriggeredToggle.Click();
        }

        [Then(@"Action Triggered toggle switch is (.*)")]
        public void ThenActionTriggeredToggleSwitchIsOff(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.AreEqual(re, preferSettingPage.ActionTriggeredToggle.GetAttribute("Toggle.ToggleState"));
        }

        [Then(@"user (.*) receive the message from this category for Action Triggered")]
        public void ThenUserCanTReceiveTheMessageFromThisCategoryForActionTriggered(string args)
        {
            string res = "";
            SQLiteHelper sqlHelper = new SQLiteHelper(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\Lenovo\ImController\PluginData\GenericMessagingPlugin\db\MessagingHistory.sqlite", "");
            DataTable dt = sqlHelper.ExecuteDataTable("select IsEnabled from MessagePreference where PreferenceType = 'ActionTriggered'", null);
            sqlHelper.CloseConnection();
            if (dt.Rows.Count > 0)
            {
                res = dt.Rows[0][0].ToString();
            }
            if (args == "can't")
                Assert.AreEqual("0", res);
            else if (args == "can")
            {
                Assert.AreEqual("1", res);
            }
        }

        [Given(@"turn (.*) Usage statistics")]
        public void GivenTurnOffUsageStatistics(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.ScrollScreen();
            if (preferSettingPage.UsageStatisticsToggle.GetAttribute("Toggle.ToggleState") != re)
                preferSettingPage.UsageStatisticsToggle.Click();
        }

        [Then(@"Usage statistics toggle switch is (.*)")]
        public void ThenUsageStatisticsToggleSwitchIsOff(string status)
        {
            var re = "0";
            if (status == "on")
                re = "1";
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.ScrollScreen();
            Assert.AreEqual(re, preferSettingPage.UsageStatisticsToggle.GetAttribute("Toggle.ToggleState"));
        }

        [Then(@"(.*) vantage to collect usage data")]
        public void ThenForbidVantageToCollectUsageData(string args)
        {
            DeviceMetricCommon dm = new DeviceMetricCommon("chifsr.lenovomm.com");
            DashBoardPage dashBoardPage = new DashBoardPage(webDriver.Session);
            dm.StartHttpAnalyzer();
            dm.WaitForResult(5);
            for (int i = 0; i < 5; i++)
            {
                dashBoardPage.navlnkdashboard.Click();
                dashBoardPage.deviceTab.Click();
                dashBoardPage.securityTab.Click();
            }
            dm.WaitForResult(90);
            dm.StopHttpAnalyzer();
            List<IDictionary<string, object>> re = dm.GetResult();
            Console.WriteLine("re:" + re.Count);
            if (args == "allow")
                Assert.IsTrue(re.Count > 0);
            else if (args == "forbid")
                Assert.AreEqual(0, re.Count);

        }
        [Given(@"click back button")]
        public void GivenClickBackButton()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            //preferSettingPage.Settingbackbtn.Click();
            Assert.NotNull(preferSettingPage.CommonBackbtn, "CommonBackbtn not found");
            preferSettingPage.CommonBackbtn.Click();
        }

        [Then(@"it will take user back to the last page where they were")]
        public void ThenItWillTakeUserBackToTheLastPageWhereTheyWere()
        {
            DashBoardPage dashBoardPage = new DashBoardPage(webDriver.Session);
            Assert.IsTrue(dashBoardPage.heroBanner.Displayed);
        }

        [Then(@"make sure all the section will expand by default except user profile block")]
        public void ThenMakeSureAllTheSectionWillExpandByDefaultExceptUserProfileBlock()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            Assert.AreEqual("Expanded", preferSettingPage.SettingsMessageCollapseLink.GetAttribute("ExpandCollapse.ExpandCollapseState"));
            preferSettingPage.ScrollScreen();
            Assert.AreEqual("Expanded", preferSettingPage.SettingsOtherCollapseLink.GetAttribute("ExpandCollapse.ExpandCollapseState"));
            Assert.AreEqual("Collapsed", preferSettingPage.SettingsUserProfileCollapseLink.GetAttribute("ExpandCollapse.ExpandCollapseState"));
        }



        [Given(@"Device Metric value is (.*)")]
        public void GivenDeviceMetricValueIs(int status)
        {
            string regkey = @"HKLM\SOFTWARE\Wow6432Node\Lenovo\AnonymousMetrics\Enabled";
            RegistryHelp.SetRegistryKeyValuePlus(regkey, (object)status, RegistryValueKind.DWord);
        }


        [Then(@"the metric data can be reported (.*)")]
        public void WhenTheMetricDataCanBeReported(string bSent)
        {
            List<IDictionary<string, object>> result = GetMetricData();
            if (bSent.Equals("yes"))
            {
                Assert.IsTrue(result.Count > 1);
            }
            else if (bSent.Equals("no"))
            {
                Assert.IsTrue(result.Count == 1);
            }

        }

        /// <summary>
        /// get device metric data using httpanalyzer
        /// </summary>
        /// <returns></returns>
        private List<IDictionary<string, object>> GetMetricData()
        {
            DeviceMetricCommon metric = new DeviceMetricCommon("chifsr.lenovomm.com");
            metric.StartHttpAnalyzer();
            string syssettingfile = Common.FileConverter(DeviceMetricCommon.systemSettingsfile);
            if (File.Exists(syssettingfile))
            {
                File.Delete(syssettingfile);
            }
            DeviceMetricCommon.RunDmSchedule();
            metric.WaitForResult(90);
            metric.StopHttpAnalyzer();
            List<IDictionary<string, object>> result = metric.GetResult();

            return result;

        }

        [Given(@"Click on the expand button")]
        public void GivenClickOnTheExpandButton()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.userProfileExpand.Click();
        }

        [Given(@"Click on the Business use button")]
        public void GivenClickOnTheBusinessUseButton()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.ScrollScreen();
            string smb = preferSettingPage.businessUseBar.Text;
            Assert.AreEqual("Business Use", smb);
            preferSettingPage.businessUseBar.Click();
            //preferSettingPage.ClickOnSMBButton();
        }

        [Given(@"Scroll the screen on prefrence setting page")]
        public void GivenScrollTheScreenOnPrefrenceSettingPage()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.ScrollScreen();
        }

        [Given(@"Click on the Save button")]
        public void GivenClickOnTheSaveButton()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.saveButton.Click();
        }

        [Given(@"Click on the Personal use button")]
        public void GivenClickOnThePersonalUseButton()
        {
            preferSettingPage = new PreferenceSettingPage(webDriver.Session);
            preferSettingPage.ScrollScreen();
            preferSettingPage.personalUseBar.Click();
        }

    }
}
