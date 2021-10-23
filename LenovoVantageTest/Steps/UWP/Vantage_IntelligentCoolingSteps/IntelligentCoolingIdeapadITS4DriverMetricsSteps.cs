using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class IntelligentCoolingIdeapadITS4DriverMetricsSteps
    {
        public string _ITSRegistryValuePath = "hklm\\SYSTEM\\CurrentControlSet\\Services\\LITSSVC\\LNBITS\\IC\\DATACOLLECTION\\Data";
        public string _ITSYMCRegistryPath = "hklm\\SOFTWARE\\Lenovo\\MoccaMode\\Mode";
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();


        public IntelligentCoolingIdeapadITS4DriverMetricsSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }


        [Then(@"check last mode is (.*)")]
        public void ThenCheckLastModeIs(string p)
        {
            Thread.Sleep(1000);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string temp = _intelligentcoolingPages.getInfoFromLog();
            var lastmode = temp.Split(',')[1];
            if (lastmode.Contains(p))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("last mode is: " + lastmode.ToString());
            }
        }

        [When(@"change ITS mode to (.*) via Vantage")]
        public void WhenChangeITSModeToISTDViaVantage(string mode)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var icon = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
            switch (mode)
            {
                case "ISTD":
                case "ICM":
                    icon = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
                    break;
                case "EPM":
                    icon = _intelligentcoolingPages.IntelligentCoolingExtremePerformanceMode;
                    break;
                case "BSM":
                    icon = _intelligentcoolingPages.IntelligentCoolingBatterySavingMode;
                    break;
            }
            if (icon != null)
            {
                icon.Click();
            }
        }

        [Then(@"check current mode is (.*)")]
        public void ThenCheckCurrentModeIs(string p)
        {
            Thread.Sleep(1000);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string temp = _intelligentcoolingPages.getInfoFromLog();
            var lastmode = temp.Split(',')[0];
            if (lastmode.Contains(p))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("current mode is: " + lastmode.ToString());
            }
        }

        [When(@"change machine to (.*) mode")]
        public void WhenChangeMachineToMode(string p)
        {
            object value = 1;
            if (p == "NB")
            {
                value = 1;
            }
            else if (p == "TENT")
            {
                value = 3;
            }
            else if (p == "PAD")
            {
                value = 2;
            }
            else if (p == "Stand")
            {
                value = 4;
            }
            RegistryHelp.SetRegistryKeyValue(_ITSYMCRegistryPath, value);
        }

        [Then(@"check switch type is (.*)")]
        public void ThenCheckSwitchTypeIs(string p)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string temp = _intelligentcoolingPages.getInfoFromLog();
            var lastmode = temp.Split(',')[2];
            if (lastmode.Contains(p))
            {
                Assert.IsTrue(true);
            }
            else
            {
                Assert.Fail("The Switch Type is" + lastmode);
            }
        }

        [When(@"open (.*) and keep 30s")]
        public void WhenOpenAGameAndKeep30s(string p)
        {
            if (p == "DNF")
            {
                Process.Start("C:\\Program Files\\DNF\\TCLS\\Client.exe");
            }
            if (p == "farmgame")
            {
                Process.Start("shell:AppsFolder\\king.com.FarmHeroesSaga_kgqvnymyfvs32!App");
            }
            if (p == "ie")
            {
                string path = "iexplore.exe";
                Process.Start(path);
            }
            Thread.Sleep(60000);
        }

        [When(@"restart ITSservice")]
        public void WhenRestartITSservice()
        {
            _baseHelper.IntelligentCoolinggIMCServiceControl(1);
            Thread.Sleep(2000);
            _baseHelper.IntelligentCoolinggIMCServiceControl(0);
        }

        [StepDefinition(@"open toolbar")]
        public void WhenOpenToolbar()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick("2000");
        }

        [When(@"click ITSicon")]
        public void WhenClickITSicon()
        {
            VantageCommonHelper.FindElementByIdAndMouseClick("1070");
        }

        [When(@"kill (.*) and wait (.*) second")]
        public void WhenKillAndWaitSecond(string proc, int time)
        {
            Common.KillProcess(proc, true);
            Thread.Sleep(TimeSpan.FromSeconds(time));
        }

        [Then(@"check regedit value about ITS")]
        public void ThenCheckRegeditValueAboutITS()
        {
            var ITSkey = RegistryHelp.GetRegistryKeyValue(_ITSRegistryValuePath);
            Assert.IsNotNull(ITSkey);
        }
    }
}
