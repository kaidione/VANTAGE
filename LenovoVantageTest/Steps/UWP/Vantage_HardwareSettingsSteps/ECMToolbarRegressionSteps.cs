using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Windows.Automation;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class ECMToolbarRegressionSteps : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        public ECMToolbarRegressionSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Turn (.*) the ECM icon")]
        public void GivenTurnOnTheECMIcon(string state)
        {
            ToggleState toggle = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString());
            switch (state)
            {
                case "On":
                    if (toggle == ToggleState.Off)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString());
                    }
                    Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString()), ToggleState.On);
                    break;
                case "Off":
                    if (toggle == ToggleState.On)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString());
                    }
                    Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString()), ToggleState.Off);
                    break;
            }
        }

        [When(@"hover on the ECM icon")]
        public void WhenHoverOnTheECMIcon()
        {
            VantageCommonHelper.HoverElement(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString());
        }

        [StepDefinition(@"There should be a ECM toggle in Toolbar within (.*)s (.*) launch")]
        public void GivenThereShouldBeAECMToggleInToolbarWithinSFirstLaunch(int p0, string type)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.IsNotNull(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString()), "EyeCareMode is null");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, p0, "The UI should show completely in " + p0 + " seconds");
        }

        [Then(@"The ECM icon's value is (.*)")]
        public void ThenTheECMIconSValueIsOn(string type)
        {
            ToggleState tarToggle = SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString());
            switch (type)
            {
                case "On":
                    Assert.AreEqual(tarToggle, ToggleState.On, "EyeCareMode is not on");
                    break;
                case "Off":
                    Assert.AreEqual(tarToggle, ToggleState.Off, "EyeCareMode is not off");
                    break;
            }
        }

        [Then(@"The ECM toggle should be on within (.*)s")]
        public void ThenTheECMToggleShouldBeOnWithinS(int p0)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.AreEqual(SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString()), ToggleState.On, "EyeCareMode is off");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, p0, "The UI should show completely in " + p0 + " seconds");
        }

        [Then(@"The ECM icon is disabled and can not be clicked")]
        public void ThenTheECMIconIsDisabledAndCanNotBeClicked()
        {
            Assert.AreEqual(GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.EyeCareMode).ToString()), "Eye care mode DISABLED.");
        }
    }
}
