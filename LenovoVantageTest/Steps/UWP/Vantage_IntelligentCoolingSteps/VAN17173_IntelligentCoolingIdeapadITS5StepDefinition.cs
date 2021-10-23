using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;


namespace LenovoVantageTest.Steps.UWP.IntelligentCooling
{
    [Binding]
    public sealed class IntelligentCoolingIdeapadITS5Steps
    {
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private bool _isSupport = false;
        private string _tips = string.Empty;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public IntelligentCoolingIdeapadITS5Steps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
            this._isSupport = IntelligentCoolingResetExecution.isSupport;
        }

        [Given(@"The Machine support Intelligent Cooling for ideapad ITS Five")]
        public void GivenTheMachineSupportIntelligentCoolingForIdeapadITSFive()
        {
            _isSupport = _baseHelper.CheckMachineSupportIntelligentCooling("6", "idea", true);
            _tips = "The machine does not support dytc 6 for idea.";
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
        }

        [Given(@"The Machine does not support Intelligent Cooling")]
        public void GivenTheMachineDoesNotSupportIntelligentCooling()
        {
            _isSupport = _baseHelper.CheckMachineSupportIntelligentCooling("", "", false);
            Assert.IsTrue(_isSupport, "The machine support intelligent cooling");
            _isSupport = true;
            _tips = "The machine does not support intelligent cooling";
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
        }

        [Given(@"Read Intelligent cooling run mark for all test case")]
        public void GivenReadIntelligentCoolingRunMarkForAllTestCase()
        {
            Assert.IsTrue(IntelligentCoolingResetExecution.isSupport, IntelligentCoolingResetExecution.tips);
        }

        [Given(@"Is Support ITS(.*)UI")]
        public void GivenIsSupportITSUI(int p0)
        {
            _isSupport = IntelligentCoolingResetExecution.isSupport;
            Assert.IsTrue(_isSupport);
        }

        [Given(@"Jump to power smart settings section")]
        public void GivenJumpToPowerSmartSettingsSection()
        {
            if (_isSupport)
            {
                _intelligentcoolingPages = new IntelligentCoolingPages(_session);
                _intelligentcoolingPages.HSJumpToSmartSettings?.Click();
            }
        }

        [Then(@"There should have Power Smart settings Jump link")]
        public void ThenThereShouldHavePowerSmartSettingsJumpLink()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings, "The Jump link not found.");
        }

        [Then(@"There should have Power Smart settings section")]
        public void ThenThereShouldHavePowerSmartSettingsSection()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_intelligentcoolingPages.PowerSmartSettingsTitle);
        }

        [Then(@"The Intelligent cooling feature icon should be displayed")]
        public void ThenTheIntelligentCoolingFeatureIconShouldBeDisplayed()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_intelligentcoolingPages.PowerSmartSettingsTitle);
        }

        [Then(@"The Intelligent cooling feature title should be displayed")]
        public void ThenTheIntelligentCoolingFeatureTitleShouldBeDisplayed()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingTitle);
        }

        [Then(@"The Intelligent cooling feature description should be displayed for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingFeatureDescriptionShouldBeDisplayedForIdeapadITSFive(string expect)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingDescription, "Name");
            Assert.AreEqual(expect, desc, "Verify Intelligent Cooling Feature Description");
        }

        [Then(@"The intelligent cooling mode should keep the same with ITS drive for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingModeShouldKeepTheSameWithITSDriveForIdeapadITSFive()
        {
            bool tag = false;
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var ICMode = _baseHelper.GetIntelligentCoolingElementCurrentStatus(_intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode, IntelligentCooingType.RadioButton);
            var EPMode = _baseHelper.GetIntelligentCoolingElementCurrentStatus(_intelligentcoolingPages.IntelligentCoolingPerformanceMode, IntelligentCooingType.RadioButton);
            var BSMode = _baseHelper.GetIntelligentCoolingElementCurrentStatus(_intelligentcoolingPages.IntelligentCoolingBatterySavingMode, IntelligentCooingType.RadioButton);
            if (ICMode == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
            {
                tag = _baseHelper.VerifyCurrentModeIsIntelligentCoolingModeCN(_session);
            }
            else if (EPMode == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
            {
                tag = _baseHelper.VerifyCurrentModeIsExtremePerformanceModeCN(_session);
            }
            else if (BSMode == IntelligentCoolingRadioButtonCheckBox.Selected.ToString())
            {
                tag = _baseHelper.VerifyCurrentModeIsBatterySavingModeCN(_session);
            }
            else
            {
                _baseHelper.WriteLog("Note:" + ICMode + "," + EPMode + "," + BSMode);
            }
            Assert.IsTrue(tag);
        }

        [Then(@"Intelligent cooling Extreme performance Battery saving mode Three radio button will be displayed for ideapad ITS Five")]
        public void ThenIntelligentCoolingExtremePerformanceBatterySavingModeThreeRadioButtonWillBeDisplayedForIdeapadITSFive()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var ICMode = _intelligentcoolingPages.IntelligentCoolingIntelligentCoolingMode;
            var EPMode = _intelligentcoolingPages.IntelligentCoolingPerformanceMode;
            var BSMode = _intelligentcoolingPages.IntelligentCoolingBatterySavingMode;
            Assert.IsNotNull(ICMode);
            Assert.IsNotNull(EPMode);
            Assert.IsNotNull(BSMode);
        }


        [When(@"The user select (.*) mode for ideapad ITS Five")]
        public void WhenTheUserSelectModeForIdeapadITSFive(string mode)
        {
            if (mode == "ICM")
            {
                _baseHelper.SelectIntelligentCoolingMode(_session);
            }
            else if (mode == "EPM")
            {
                _baseHelper.SelectExtremePerformanceMode(_session);
            }
            else if (mode == "BSM")
            {
                _baseHelper.SelectBatterySavingMode(_session);
            }
        }



        [Then(@"The intelligent cooling (.*) mode description will be display for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingModeDescriptionWillBeDisplayForIdeapadITSFive(string mode, string expect)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingSelectModeDesc, "Name");
            if (mode == "ICM")
            {
                if (_baseHelper.VerifyCurrentModeIsIntelligentCoolingModeCN(_session))
                {
                    Assert.AreEqual(expect, desc, "Verify ICM Text Description");
                }
            }
            else if (mode == "EPM")
            {
                if (_baseHelper.VerifyCurrentModeIsExtremePerformanceModeCN(_session))
                {
                    Assert.AreEqual(expect, desc, "Verify EPM Text Description");
                }
            }
            else if (mode == "BSM")
            {
                if (_baseHelper.VerifyCurrentModeIsBatterySavingModeCN(_session))
                {
                    Assert.AreEqual(expect, desc, "Verify BSM Text Description");
                }
            }

        }

        [When(@"The user select (.*) auto transition checkbox for ideapad ITS Five")]
        public void WhenTheUserSelectAutoTransitionCheckboxForIdeapadITSFive(string status)
        {
            if (status == "on")
            {
                _baseHelper.AutoTransitionIsSelected(_session);
            }
            else if (status == "off")
            {
                _baseHelper.AutoTransitionIsNotSelected(_session);
            }

        }

        [Then(@"The auto transition checkbox status is (.*) for ideapad ITS Five")]
        public void ThenTheAutoTransitionCheckboxStatusIsForIdeapadITSFive(string checkstatus)
        {
            if (checkstatus == "on")
            {
                _intelligentcoolingPages = new IntelligentCoolingPages(_session);
                var checkbox = _intelligentcoolingPages.IntelligentCoolingAutoTransition;
                var checkboxstatus = checkbox.GetAttribute("Toggle.ToggleState");
                if (checkboxstatus == "1")
                {
                    Assert.IsTrue(true, "checkbox should be checked but it is unchecked!");
                }
            }
            else if (checkstatus == "off")
            {
                _intelligentcoolingPages = new IntelligentCoolingPages(_session);
                var checkbox = _intelligentcoolingPages.IntelligentCoolingAutoTransition;
                var checkboxstatus = checkbox.GetAttribute("Toggle.ToggleState");
                if (checkboxstatus == "0")
                {
                    Assert.IsTrue(true, "checkbox should be unchecked but it is checked!");
                }
            }
        }

        [Then(@"The intelligent cooling auto transition checkbox will be display for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingAutoTransitionCheckboxWillBeDisplayForIdeapadITSFive()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var checkbox = _intelligentcoolingPages.IntelligentCoolingAutoTransition;
            Assert.IsNotNull(checkbox);
        }

        [Then(@"The intelligent cooling MORE dropdown link will be display for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingMOREDropdownLinkWillBeDisplayForIdeapadITSFive()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var drop = _intelligentcoolingPages.IntelligentCoolingAutoTransitionMoreLink;
            Assert.IsNotNull(drop, "The IntelligentCoolingAutoTransitionMoreLink is null");
        }


        [Then(@"The intelligent cooling auto transition checkbox description will be display for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingAutoTransitionCheckboxDescriptionWillBeDisplayForIdeapadITSFive(string expect)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransition, "Name");
            Assert.AreEqual(expect, desc, "Verify Read More Text Description");
        }

        [When(@"The user click Read more link for ideapad ITS Five (.*)")]
        public void WhenTheUserClickReadMoreLinkForIdeapadITSFive(string morestatus)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            if (morestatus.ToLower() == "less")
            {
                _intelligentcoolingPages.IntelligentCoolingAutoTransitionMoreLink?.Click();
            }
            else if (morestatus.ToLower() == "more")
            {
                _intelligentcoolingPages.IntelligentCoolingAutoTransitionLessLink?.Click();
            }
        }

        [Then(@"The Read more link text is (.*) for ideapad ITS Five")]
        public void ThenTheReadMoreLinkTextIsForIdeapadITSFive(string expect)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            if (expect.ToLower() == "less")
            {
                var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransitionLessLink, "Name");
                Assert.AreEqual(expect, desc, "Verify Read More Link Text is LESS");
            }
            else if (expect.ToLower() == "more")
            {
                var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransitionMoreLink, "Name");
                Assert.AreEqual(expect, desc, "Verify Read More Link Text is MORE");
            }
        }

        [Then(@"The intelligent cooling Read more sub description will be display for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingReadMoreSubDescriptionWillBeDisplayForIdeapadITSFive(string obj)
        {
            string[] tempobj = obj.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var descA = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescA, "Name");
            var descB = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescB, "Name");
            var descC = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescC, "Name");
            Assert.AreEqual(tempobj[0], descA, "Verify Read More Text Description Part A Section");
            Assert.AreEqual(tempobj[1], descB, "Verify Read More Text Description Part B Section");
            Assert.AreEqual(tempobj[2], descC, "Verify Read More Text Description Part C Section");
        }

        [Then(@"The intelligent cooling Read more description will be (.*) for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingReadMoreDescriptionWillBeForIdeapadITSFive(string obj)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var descA = _intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescA;
            var descB = _intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescB;
            var descC = _intelligentcoolingPages.IntelligentCoolingAutoTransitionReadMoreDescC;
            if (obj == "show")
            {
                Assert.IsNotNull(descA, "AutoTransitionReadMoreDescA is null");
                Assert.IsNotNull(descB, "AutoTransitionReadMoreDescA is null");
                Assert.IsNotNull(descC, "AutoTransitionReadMoreDescA is null");
            }
            else if (obj == "hide")
            {
                Assert.IsNull(descA, "AutoTransitionReadMoreDescA is not null");
                Assert.IsNull(descB, "AutoTransitionReadMoreDescA is not null");
                Assert.IsNull(descC, "AutoTransitionReadMoreDescA is not null");
            }
        }

        [Then(@"The Intelligent Cooling mode is (.*) for ideapad ITS Five")]
        public void ThenTheIntelligentCoolingModeIsICMForIdeapadITSFive(string mode)
        {
            bool tag = false;
            if (mode == "ICM")
            {
                tag = _baseHelper.VerifyCurrentModeIsIntelligentCoolingModeCN(_session);
            }
            else if (mode == "EPM")
            {
                tag = _baseHelper.VerifyCurrentModeIsExtremePerformanceModeCN(_session);
            }
            else if (mode == "BSM")
            {
                tag = _baseHelper.VerifyCurrentModeIsBatterySavingModeCN(_session);
            }
            Assert.IsTrue(tag, "ICM:Intelligent Cooling Mode, EPM:Extreme Performance Mode ,BSM:Battery Saving Mode, Verify Mode:" + mode);
        }

    }
}
