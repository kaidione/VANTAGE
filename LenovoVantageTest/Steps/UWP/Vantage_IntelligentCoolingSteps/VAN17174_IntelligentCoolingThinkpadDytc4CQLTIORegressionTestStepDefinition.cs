using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public sealed class IntelligentCoolingThinkpadDytc4CQLTIORegressionTestStepDefinition
    {
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private bool _isSupport = false;
        private string _tips = string.Empty;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public IntelligentCoolingThinkpadDytc4CQLTIORegressionTestStepDefinition(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
            this._isSupport = IntelligentCoolingResetExecution.isSupport;
        }

        [Given(@"The Machine support Intelligent Cooling for thinkpad DYTC Four")]
        public void GivenTheMachineSupportIntelligentCoolingForThinkpadDYTCFour()
        {
            _isSupport = _baseHelper.CheckMachineSupportIntelligentCooling("4", "think", true);
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
            _tips = "Get the machine if support dytc 4 for thinkpad.";
        }

        [Given(@"The Machine support CQL TIO")]
        public void GivenTheMachineSupportCQLTIO()
        {
            Assert.IsTrue(_isSupport, _tips + " Note:The machine doesn't support thinkpad dytc4");
            string type = VantageCommonHelper.GetCurrentMachineType();
            bool itsCQL = _baseHelper.GetMachineSupportIntelligentCoolingCQL();
            if (type == "Thinkpad X1 Tablet Gen 3" || itsCQL == true)
            {
                _isSupport = true;
                _tips = "The Machine support Dytc4 and it is CQL TIO machine";
            }
            else
            {
                _isSupport = false;
                _tips = "The Machine support Dytc4 and it isn't CQL TIO machine";
            }
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
        }

        [When(@"The User Turn (.*) Intelligent Cooling toggle for JP")]
        public void WhenTheUserTurnIntelligentCoolingToggleForJP(string status)
        {
            switch (status.ToLower())
            {
                case "on":
                    _baseHelper.TurnOnIntelligentCoolingToggleJP(_session);
                    break;
                case "off":
                    _baseHelper.TurnOffIntelligentCoolingToggleJP(_session);
                    break;
                default:
                    Assert.Fail("The WhenTheUserTurnIntelligentCoolingToggleForJP not run");
                    break;
            }
        }

        [Then(@"The Performance and Cool quiet mode will be hide or show for DYTC Four (.*)")]
        public void ThenThePerformanceAndCoolQuietModeWillBeHideOrShowForDYTCFour(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingPerformanceMode, "The performance mode is null");
                    Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingCoolQuietMode, "The quiet mode is null");
                    break;
                case "hide":
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingPerformanceMode, "The performance mode is null");
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingCoolQuietMode, "The quiet mode is null");
                    break;
                default:
                    Assert.Fail("The ThenThePerformanceAndCoolQuietModeWillBeHideOrShowForDYTCFour not run");
                    break;
            }
        }

        [Then(@"The Intelligent Cooling descrition will be display as below for DYTC Four")]
        public void ThenTheIntelligentCoolingDescritionWillBeDisplayAsBelowForDYTCFour(string multilineText)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingDescription, "Name");
            Assert.AreEqual(multilineText, desc, "Verify Intelligent Cooling Description");
            //string[] tempobj = multilineText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        }

        [Then(@"The Intelligent Cooling feature will show or hide for all intelligent cooling (.*)")]
        public void ThenTheIntelligentCoolingFeatureWillShowOrHideForAllIntelligentCooling(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings, "The Jump link not found.");
                    if (_intelligentcoolingPages.IntelligentCoolingTitleThink != null || _intelligentcoolingPages.IntelligentCoolingTitle != null)
                    {
                        Assert.IsTrue(true, "The Intelligent Cooling Title not found");
                    }
                    else
                    {
                        Assert.IsTrue(false, "The Intelligent Cooling Title not found");
                    }
                    break;
                case "hide":
                    Assert.IsNull(_intelligentcoolingPages.HSJumpToSmartSettings, "The Jump link still show.");
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingTitleThink, "The Intelligent Cooling Title still show");
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingTitle, "The Intelligent Cooling Title still show");
                    break;
                default:
                    Assert.Fail("ThenTheIntelligentCoolingFeatureWillShowOrHide not run");
                    break;
            }
        }

        [When(@"Stop services for intelligent cooling (.*)")]
        public void WhenStopServicesForIntelligentCooling(string servicename)
        {
            switch (servicename.ToLower())
            {
                case "imc":
                    _baseHelper.IntelligentCoolinggIMCServiceControl(3);
                    break;
                case "its":
                    _baseHelper.IntelligentCoolinggIMCServiceControl(1);
                    break;
                case "both":
                    _baseHelper.IntelligentCoolinggIMCServiceControl(4);
                    break;
                case "skip":
                    break;
                default:
                    Assert.Fail("The WhenStopServicesForIntelligentCooling() not run");
                    break;
            }
        }

        [When(@"Start services for intelligent cooling (.*)")]
        public void WhenStartServicesForIntelligentCooling(string servicename)
        {
            switch (servicename.ToLower())
            {
                case "imc":
                    _baseHelper.IntelligentCoolinggIMCServiceControl(2);
                    break;
                case "its":
                    _baseHelper.IntelligentCoolinggIMCServiceControl(0);
                    break;
                case "both":
                    _baseHelper.IntelligentCoolinggIMCServiceControl();
                    break;
                case "skip":
                    break;
                default:
                    Assert.Fail("The WhenStartServicesForIntelligentCooling() not run");
                    break;
            }
        }

        [When(@"The user delete plugin for intelligent cooling (.*)")]
        public void WhenTheUserDeletePluginForIntelligentCooling(string language)
        {
            bool tag = false;
            bool resettag = false;
            switch (language.ToLower())
            {
                case "cn":
                    tag = _baseHelper.DeleteIntelligentCoolingPluginCN();
                    break;
                case "jp":
                    tag = _baseHelper.DeleteIntelligentCoolingPluginJP();
                    break;
                default:
                    Assert.Fail("The WhenTheUserDeletePluginForIntelligentCooling not run");
                    break;
            }
            if (tag == false)
            {
                switch (language.ToLower())
                {
                    case "cn":
                        resettag = _baseHelper.ResetIntelligentCoolingPluginCN();
                        break;
                    case "jp":
                        resettag = _baseHelper.ResetIntelligentCoolingPluginJP();
                        break;
                    default:
                        Assert.Fail("The WhenTheUserDeletePluginForIntelligentCooling not run");
                        break;
                }
            }
            Assert.IsTrue(tag, "Note:delete plugin error");
        }

        [Then(@"Reset plugin for intelligent cooling (.*)")]
        public void ThenResetPluginForIntelligentCooling(string language)
        {
            bool resettag = false;
            switch (language.ToLower())
            {
                case "cn":
                    resettag = _baseHelper.ResetIntelligentCoolingPluginCN();
                    break;
                case "jp":
                    resettag = _baseHelper.ResetIntelligentCoolingPluginJP();
                    break;
                default:
                    Assert.Fail("The ThenResetPluginForIntelligentCooling not run");
                    break;
            }
            Assert.IsTrue(resettag, "Note:reset plugin error");
        }

        [Then(@"The Intelligent Cooling toggle status is on or off for JP (.*)")]
        public void ThenTheIntelligentCoolingToggleStatusIsOnOrOffForJP(string status)
        {
            bool tag = false;
            switch (status.ToLower())
            {
                case "on":
                    tag = _baseHelper.VerifyToggleStatusIsOnJP(_session);
                    break;
                case "off":
                    tag = _baseHelper.VerifyToggleStatusIsOffJP(_session);
                    break;
                default:
                    Assert.Fail("The ThenTheIntelligentCoolingToggleStatusIsOnOrOffForJP() not run");
                    break;
            }
            Assert.IsTrue(tag, "The toggle status incorrect, Expect:" + status);
        }

        [Then(@"The Intelligent Cooling mode is performance or cool quiet for JP (.*)")]
        public void ThenTheIntelligentCoolingModeIsPerformanceOrCoolQuietForJP(string mode)
        {
            bool tag = false;
            switch (mode.ToLower())
            {
                case "icq":
                    tag = _baseHelper.VerifyCurrentModeIsCoolQuietModeJP(_session);
                    break;
                case "ipm":
                    tag = _baseHelper.VerifyCurrentModeIsPerformanceModeJP(_session);
                    break;
                default:
                    Assert.Fail("The ThenTheIntelligentCoolingModeIsPerformanceOrCoolQuietForJP() not run");
                    break;
            }
            Assert.IsTrue(tag, "Verify current mode incorrect. Expect:" + mode);
        }

        [When(@"The user select performance or cool quiet for JP (.*)")]
        public void WhenTheUserSelectPerformanceOrCoolQuietForJP(string mode)
        {
            switch (mode.ToLower())
            {
                case "icq":
                    _baseHelper.SelectCoolQuietMode(_session);
                    break;
                case "ipm":
                    _baseHelper.SelectPerformanceMode(_session);
                    break;
                default:
                    Assert.Fail("The ThenTheIntelligentCoolingModeIsPerformanceOrCoolQuietForJP() not run");
                    break;
            }
        }

        [When(@"The user Fast switch mode for JP (.*)")]
        public void WhenTheUserFastSwitchModeForJP(int times)
        {
            Random rd = new Random();
            for (int i = 0; i < times; i++)
            {
                if (rd.Next(0, 100) % 2 == 0)
                {
                    _baseHelper.SelectCoolQuietMode(_session);
                }
                else
                {
                    _baseHelper.SelectPerformanceMode(_session);
                }
            }
        }











    }
}
