using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class IntelligentKeyboardSteps
    {
        private readonly InformationalWebDriver _AppDriver;
        private HSInputPage _HSInputPage;
        private SettingsBase _SettingsBase;

        public IntelligentKeyboardSteps(InformationalWebDriver appDriver)
        {
            _AppDriver = appDriver;
            _HSInputPage = new HSInputPage(appDriver.Session);
        }

        #region BeforeScenario
        [BeforeScenario("IntelligentKeyboard_AdPolicy")]
        [BeforeScenario("IntelligentKeyboard_NoSupport_AdPolicy")]
        public static void BeforeScenario()
        {
            DeleteAdPolicyKey(Constants.vantage_adpolicy_intelligent_keyboard);
        }
        #endregion

        #region AfterScenario
        [AfterScenario("IntelligentKeyboard_AdPolicy")]
        [AfterScenario("IntelligentKeyboard_NoSupport_AdPolicy")]
        public void AfterScenario()
        {
            UpdateAdPolicyForSection("not configured");
        }
        #endregion

        public static void DeleteAdPolicyKey(string keyToDelete)
        {
            AdPolicyRegistryHelper.DeleteKey(keyToDelete);
        }

        public bool IsThinkPad()
        {
            return VantageCommonHelper.IsThinkPad();
        }

        [StepDefinition(@"Intelligent Keyboard AdPolicy is set to (enabled|disabled|not configured)")]
        public void UpdateAdPolicyForSection(string status)
        {
            if (status == "not configured")
            {
                DeleteAdPolicyKey(Constants.vantage_adpolicy_intelligent_keyboard);
            }
            else
            {
                bool booleanValue = status == "enabled" ? true : false;
                AdPolicyRegistryHelper.SetAdPolicy(Constants.vantage_adpolicy_intelligent_keyboard, booleanValue);
            }
        }

        [Then(@"Intelligent Keyboard and Jump to Settings should be (visible|not visible)")]
        public void ThenIntelligentKeyboardSectionVisible(string visibility)
        {
            _HSInputPage = new HSInputPage(_AppDriver.Session);

            bool shouldBeVisible = visibility == "visible" ? true : false;

            if (shouldBeVisible)
            {
                Assert.IsNotNull(_HSInputPage.keyboard_title, "Intelligent keyboard title should be visibile");
                Assert.IsNotNull(_HSInputPage.KBDTopRowTitle, "Keyboard top row function title should be visibile");
                Assert.IsNotNull(_HSInputPage.KBDTopRowDesc, "Keyboard top row function description should be visibile");
                Assert.IsNotNull(_HSInputPage.Touchpadlink, "Thouchpad Controls link should be visibile");
                Assert.IsNotNull(_HSInputPage.Trackpointlink, "Trackpoint Controls link should be visibile");
                if (IsThinkPad())
                {
                    Assert.IsNotNull(_HSInputPage.keyboardBacklightTitleOfThinkPad, "Keyboard backlight title for ThinkPad should be visibile");
                    Assert.IsNotNull(_HSInputPage.HiddenKeyboardFunctionsTitleId, "Hidden keyboard functions title should be visibile");
                    Assert.IsNotNull(_HSInputPage.HiddenKeyboardFunctionsTextId, "Hidden keyboard functions text should be visibile");
                    Assert.IsNotNull(_HSInputPage.VOIPFeatureTitle, "VOIP function title should be visibile");
                    Assert.IsNotNull(_HSInputPage.VOIPfeatureDesc, "VOIP function description should be visibile");
                    Assert.IsNotNull(_HSInputPage.fnCtrlKey_Title, "FnCtrl Key Swap function text should be visibile");
                    Assert.IsNotNull(_HSInputPage.fnCtrlKey_TexDescription, "FnCtrl Key Swap function description should be visibile");
                    Assert.IsNotNull(_HSInputPage.userDefinedKey_Title, "User Defined Key title should be visibile");
                }
                else
                {
                    Assert.IsNotNull(_HSInputPage.keyboardBacklightTitle, "Keyboard backlight title should be visibile");
                }
            }
            else
            {
                List<Task> allTasks = new List<Task>()
                {
                    Task.Run(() => Assert.IsNull(_HSInputPage.keyboard_title, "Input page title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSInputPage.KBDTopRowTitle, "Keyboard top row function title should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSInputPage.KBDTopRowDesc, "Keyboard top row function description should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSInputPage.Touchpadlink, "Touchpad controls link should be not visibile")),
                    Task.Run(() => Assert.IsNull(_HSInputPage.Trackpointlink, "Trackpoint controls link should be not visibile")),
                    Task.Run(() => {
                        if (IsThinkPad())
                        {
                            Assert.IsNull(_HSInputPage.keyboardBacklightTitleOfThinkPad, "Keyboard backlight title for ThinkPad should be not visibile");
                            Assert.IsNull(_HSInputPage.HiddenKeyboardFunctionsTitleId, "Hidden keyboard functions title should be not visibile");
                            Assert.IsNull(_HSInputPage.HiddenKeyboardFunctionsTextId, "Hidden keyboard functions text should be not visibile");
                            Assert.IsNull(_HSInputPage.VOIPFeatureTitle, "VOIP function title should be not visibile");
                            Assert.IsNull(_HSInputPage.VOIPfeatureDesc, "VOIP function description should be not visibile");
                            Assert.IsNull(_HSInputPage.fnCtrlKey_Title, "FnCtrl Key Swap function text should be not visibile");
                            Assert.IsNull(_HSInputPage.fnCtrlKey_TexDescription, "FnCtrl Key Swap function description should be not visibile");
                            Assert.IsNull(_HSInputPage.userDefinedKey_Title, "User Defined Key title should be not visibile");
                        }
                        else
                        {
                            Assert.IsNull(_HSInputPage.keyboardBacklightTitle, "Keyboard backlight title should be not visibile");
                        }
                    })
                };

                Task.WaitAll(allTasks.ToArray());
            }
        }

        [StepDefinition(@"Navigate to Input Page")]
        public bool GoToInputPageIfAvailable()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            try
            {
                _SettingsBase.MySettingsMenuDropClickFunction();
                if (_SettingsBase.InputSettingsPageMenuLink == null)
                {
                    WindowsElement windowsElement = VantageCommonHelper.FindElementByXPath(_AppDriver.Session, "//*[contains(@AutomationId,'menu-main-nav-lnk-dropdown-menu-device-device-settings-')]", 10);
                    if (windowsElement != null)
                    {
                        windowsElement.Click();
                    }
                }
                else
                {
                    _SettingsBase.InputSettingsPageMenuLink.Click();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input page was not present because AD Policy is enabled, and machine only has Intelligent Keyboard under Input & Accessories");
                return true;
            }
        }

        [StepDefinition(@"Open Device dropdown menu to check Input Link")]
        public void ClickDeviceMenu()
        {
            _SettingsBase = new SettingsBase(_AppDriver.Session);
            _SettingsBase.MySettingsMenuDropClickFunction();
        }

        [Then(@"Input & Accessories (Link|Tab) should be (visible|not visible)")]
        public void CheckTabVisibility(string element, string visibility)
        {
            bool shouldBeVisible = visibility == "visible" ? true : false;
            WindowsElement elementToCheck = element == "Tab" ? _SettingsBase.MySettingsInputTab : _SettingsBase.InputSettingsPageMenuLink;
            if (shouldBeVisible)
            {
                Assert.IsNotNull(elementToCheck);
            }
            else
            {
                Assert.IsNull(elementToCheck);
            }
        }
    }
}