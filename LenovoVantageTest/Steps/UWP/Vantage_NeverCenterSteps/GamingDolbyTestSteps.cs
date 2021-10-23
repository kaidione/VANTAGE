using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingDolbyTestSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        string toggleStatus = string.Empty;
        string doblyToggleStatus = string.Empty;

        public GamingDolbyTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [When(@"Switch Dobly toggle(.*)")]
        public void WhenSwitchDoblyToggle(string page)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (page.Trim().Equals("homepage"))
            {
                if (_nerveCenterPages.QuickSettingsDolbyToggleOff != null)
                {
                    _nerveCenterPages.QuickSettingsDolbyToggleOff.Click();
                    Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOn);
                    Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOn.GetAttribute("Name").ToString(), "quicksettings dolby on");
                }
                else if (_nerveCenterPages.QuickSettingsDolbyToggleOn != null)
                {
                    _nerveCenterPages.QuickSettingsDolbyToggleOn.Click();
                    Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOff);
                    Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOff.GetAttribute("Name").ToString(), "quicksettings dolby off");
                }
            }
            else if (page.Trim().Equals("audiopage"))
            {
                Assert.IsNotNull(_nerveCenterPages.DoblyCheckbox);
                doblyToggleStatus = VantageCommonHelper.GetToggleStatus(_nerveCenterPages.DoblyCheckbox).ToString();
                _nerveCenterPages.DoblyCheckbox.Click();
            }
        }

        [When(@"Click Dobly gear icon")]
        public void WhenClickDoblyGearIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon);
            _nerveCenterPages.QuickSettingsDolbyIcon.Click();
        }

        [Then(@"Dolby is displayed(.*)")]
        public void ThenDolbyIsDisplayed(string dobly)
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Thread.Sleep(500);
            if (dobly.Trim().ToString().Equals("exist"))
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon, "The QuickSettingsDolbyIcon not found");
                _nerveCenterPages.QuickSettingsDolbyIcon.Click();
                Assert.IsNotNull(_nerveCenterPages.DoblyCheckbox, "The DolbyCheckbox not found");
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The GamingDeviceMenu not found");
                _nerveCenterPages.GamingDeviceMenu.Click();
                Thread.Sleep(500);
                Assert.IsTrue(_nerveCenterPages.QuickSettingsDolbyToggleOff != null || _nerveCenterPages.QuickSettingsDolbyToggleOn != null, "The Dolby toggle not found");
            }
            else if (dobly.Trim().Equals("no"))
            {
                Assert.IsNull(_nerveCenterPages.QuickSettingsDolbyIcon, "The QuickSettingsDolbyIcon still show");
                Assert.IsNull(_nerveCenterPages.DoblyCheckbox, "The DolbyCheckbox still shown");
                Assert.IsNotNull(_nerveCenterPages.GamingDeviceMenu, "The GamingDeviceMenu not found!");
                _nerveCenterPages.GamingDeviceMenu.Click();
                Thread.Sleep(500);
                Assert.IsTrue(_nerveCenterPages.QuickSettingsDolbyToggleOff == null || _nerveCenterPages.QuickSettingsDolbyToggleOn == null, "The Dolby toggle still shown");
            }
        }

        [Then(@"Dolby gear icon is displayed before the Dobly toggle")]
        public void ThenDolbyGearIconIsDisplayedBeforeTheDoblyToggle()
        {
            string togglePositionX = string.Empty;
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon);
            string gearPosition = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.QuickSettingsDolbyIcon, "ClickablePoint");
            if (_nerveCenterPages.QuickSettingsDolbyToggleOff != null)
            {
                togglePositionX = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.QuickSettingsDolbyToggleOff, "ClickablePoint");
            }
            else if (_nerveCenterPages.QuickSettingsDolbyToggleOn != null)
            {
                togglePositionX = VantageCommonHelper.GetAttributeValue(_nerveCenterPages.QuickSettingsDolbyToggleOn, "ClickablePoint");

            }
            Assert.Less(Convert.ToInt32(gearPosition.Split(',')[0]), Convert.ToInt32(togglePositionX.Split(',')[0]));
        }

        [Then(@"Dolby toggle status on homepage is consistent with audio page")]
        public void ThenDolbyToggleStatusOnHomepageIsConsistentWithAudioPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon);
            _nerveCenterPages.QuickSettingsDolbyIcon.Click();
            Assert.IsNotNull(_nerveCenterPages.DoblyAudioPageTitle);
            Assert.IsNotNull(_nerveCenterPages.DoblyAudioText);
            string doblyCheckboxStatus = VantageCommonHelper.GetToggleStatus(_nerveCenterPages.DoblyCheckbox).ToString().ToLower();
            _nerveCenterPages.GamingDeviceMenu.Click();
            Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyIcon);
            if (doblyCheckboxStatus.Equals("on"))
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOn);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOn.GetAttribute("Name").ToString(), "quicksettings dolby on");
            }
            else if (doblyCheckboxStatus.Equals("off"))
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOff);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOff.GetAttribute("Name").ToString(), "quicksettings dolby off");
            }
        }

        [Then(@"Dobly toggle status is changed on homepage")]
        public void ThenDoblyToggleStatusIsChangedOnHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (_nerveCenterPages.QuickSettingsDolbyToggleOn != null)
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOn);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOn.GetAttribute("Name").ToString(), "quicksettings dolby on");
                toggleStatus = "on";
            }
            else if (_nerveCenterPages.QuickSettingsDolbyToggleOff != null)
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOff);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOff.GetAttribute("Name").ToString(), "quicksettings dolby off");
                toggleStatus = "off";
            }
        }

        [Then(@"Dobly toggle status is not changed")]
        public void ThenDoblyToggleStatusIsNotChanged()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            string doblyHomepage = string.Empty;
            if (_nerveCenterPages.QuickSettingsDolbyToggleOn != null)
            {
                doblyHomepage = "on";
                Assert.AreEqual(doblyHomepage, toggleStatus);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOn.GetAttribute("Name").ToString(), "quicksettings dolby on");
            }
            else
            {
                doblyHomepage = "off";
                Assert.AreEqual(doblyHomepage, toggleStatus);
                Assert.AreEqual(_nerveCenterPages.QuickSettingsDolbyToggleOff.GetAttribute("Name").ToString(), "quicksettings dolby off");
            }
        }

        [Then(@"My Device settings-Audio page is opened")]
        public void ThenMyDeviceSettings_AudioPageIsOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.DoblyAudioPageTitle);
            Assert.IsNotNull(_nerveCenterPages.DoblyAudioText);
        }

        [Then(@"Dobly audio page toggle status is consistent with homepage")]
        public void ThenDoblyAudioPageToggleStatusIsConsistentWithHomepage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.DoblyCheckbox);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_nerveCenterPages.DoblyCheckbox).ToString().ToLower(), toggleStatus);
        }

        [Then(@"Dobly toggle status on audio page is changed")]
        public void ThenDoblyToggleStatusOnAudioPageIsChanged()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.DoblyCheckbox);
            Assert.AreNotEqual(VantageCommonHelper.GetToggleStatus(_nerveCenterPages.DoblyCheckbox).ToString().ToLower(), doblyToggleStatus.ToLower());
        }

        [Then(@"Dobly toggle status is consistent with audio page")]
        public void ThenDoblyToggleStatusIsConsistentWithAudioPage()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            if (doblyToggleStatus.ToLower().Equals("on"))
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOff);
            }
            else
            {
                Assert.IsNotNull(_nerveCenterPages.QuickSettingsDolbyToggleOn);
            }
        }
    }
}
