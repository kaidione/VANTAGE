using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;


namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingLightingT750T550AMDSixligthsRear : SettingsBase
    {

        private InformationalWebDriver _webDriver;
        private GamingLightingPages _gamingMachineListPage;
        private List<string> _curApplist = new List<string>();
        static LightingBlockIdTypeItem lightingBlockIdItemFromBaseFile;
        private int _blockIndex;
        private static string RegistryLightingProfile = @"HKLM\SOFTWARE\Lenovo\ImController\PluginData\GamingPlugin\Data\LedSettingsPlugin\Profile\LedProfileID";

        private int profileIndex = 0;
        private LedProfileList _originalLedProfileList;

        private string _readFormLogStr;

        private string _selectLightingTypeName;
        private bool isCompareFile;

        public GamingLightingT750T550AMDSixligthsRear(InformationalWebDriver appDriver)
        {
            this._webDriver = appDriver;
        }

        [BeforeFeature(@"GetLightingFile")]
        public static void GetLightingFile()
        {
            lightingBlockIdItemFromBaseFile = GamingLightingPages.GetLightingBlockIdTypeItem();
        }

        [Given(@"Need Compare File is '(.*)'")]
        public void GivenNeedCompareFileIs(string p0)
        {
            if (p0.ToLower().Contains("true"))
            {
                isCompareFile = true;
            }
            else
            {
                isCompareFile = false;
            }
        }

        [Given(@"click the the customize")]
        public void GivenClickTheTheCustomize()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement customizeElement = _gamingMachineListPage.CustomizeElement;
            Assert.IsNotNull(customizeElement, "Gaming CustomizeElement is null");
            customizeElement.Click();
        }

        [Given(@"click right arrow (.*) times")]
        public void GivenClickRightArrow(int p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement rightarrowElement = _gamingMachineListPage.GamingLightingRightArrow;
            Assert.IsNotNull(rightarrowElement, "Gaming GamingLightingRightArrow is null");
            if (rightarrowElement != null)
                for (int i = 0; i < p0; i++)
                {
                    rightarrowElement.Click();
                }
        }

        [Given(@"Click Left Arrow (.*) Times")]
        public void GivenClickLeftArrowTimes(int p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement leftArrowElement = _gamingMachineListPage.GamingLightingLeftArrow;
            Assert.IsNotNull(leftArrowElement, "Gaming GamingLightingLeftArrow is null");
            for (int i = 0; i < p0; i++)
            {
                leftArrowElement.Click();
            }
        }

        [Given(@"Hover The Effect Item")]
        public void GivenHoverTheEffectItem()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            Assert.IsNotNull(_gamingMachineListPage.LightingEffectDropMenu, "The Effect Item not found");
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingMachineListPage.LightingEffectDropMenu);
        }

        [Given(@"Lighting page is opened")]
        public void GivenLightingPageIsOpened()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement customizeTitleElement = _gamingMachineListPage.LightingcustomizeTitle;
            Assert.IsNotNull(customizeTitleElement, "Gaming CustomizeElement is null");
        }

        [Then(@"Click ""(.*)"" and Show ""(.*)""")]
        public void ThenClickAndShow(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement customizeTitleElement = _gamingMachineListPage.LightingcustomizeTitle;
            Assert.IsNotNull(customizeTitleElement, "Gaming CustomizeElement is null");
            _selectLightingTypeName = p0;
        }

        [Then(@"Click ""(.*)"" and Hide ""(.*)""")]
        public void ThenClickAndHide(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement customizeTitleElement = _gamingMachineListPage.LightingcustomizeTitle;
            Assert.IsNotNull(customizeTitleElement, "Gaming CustomizeElement is null");
            _selectLightingTypeName = p0;
        }

        [Given(@"select the profile (.*)")]
        public void GivenSelectTheProfile(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            switch (p0)
            {
                case "off":
                    _gamingMachineListPage.StyleOffElement.Click();
                    p0 = "0";
                    break;
                case "1":
                    _gamingMachineListPage.Style1Element.Click();
                    break;
                case "2":
                    _gamingMachineListPage.Style2Element.Click();
                    break;
                case "3":
                    _gamingMachineListPage.Style3Element.Click();
                    break;
            }
            profileIndex = int.Parse(p0);
        }

        [Given(@"at homepage select the profile (.*)")]
        public void GivenAtHomepageSelectTheProfileAt(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            switch (p0)
            {
                case "off":
                    _gamingMachineListPage.StyleOffElementHomepage.Click();
                    return;
                case "1":
                    _gamingMachineListPage.Style1ElementHomepage.Click();
                    break;
                case "2":
                    _gamingMachineListPage.Style2ElementHomepage.Click();
                    break;
                case "3":
                    _gamingMachineListPage.Style3ElementHomepage.Click();
                    break;
            }
            profileIndex = int.Parse(p0);
        }

        [When(@"Set to default effect")]
        public void WhenSetToDefaultEffect()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement setToDefault = _gamingMachineListPage.LightingSetToDefaultElement;
            Assert.IsNotNull(setToDefault, "Gaming Set To Default is null");
            Common.ClearLogsFolderFile();
            setToDefault.Click();
            if (isCompareFile)
            {
                Thread.Sleep(2000);
                _originalLedProfileList = _gamingMachineListPage.GetLedProfileListFromLocal();
                _readFormLogStr = _gamingMachineListPage.ReadFormLog();
            }
        }

        [Then(@"Click The ""(.*)""")]
        public void ThenClick(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _blockIndex = _gamingMachineListPage.SelectBock(p0);
            _selectLightingTypeName = p0;
        }

        [Then(@"Click The Install Button")]
        public void ThenClickTheInstallButton()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            Assert.IsNotNull(_gamingMachineListPage.InstallButton, "The install button is null.");
            _gamingMachineListPage.InstallButton.Click();
        }

        [Then(@"effect dropdown menu should be expanded and effects should be shown:")]
        public void ThenEffectDropdownMenuShouldBeExpandedAndEffectsShouldBeShown(Table table)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _gamingMachineListPage.LightingEffectDropMenu?.Click();

            for (int i = 0; i < table.RowCount; i++)
            {
                string effectName = table.Rows[i][0];
                _gamingMachineListPage.LightingEffectAutomationId = effectName;
                Assert.IsNotNull(_gamingMachineListPage.LightingEffectElement, effectName + " is null ");
            }

        }

        [Then(@"Click ""(.*)"" and ""(.*)""")]
        public void ThenClickAnd(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _gamingMachineListPage.SelectBock(p0);
            if (p1.Contains("Hide"))
            {
                p1 = p1.Replace("Hide", "").Trim();
                _gamingMachineListPage.CurrentLightingSelectionAreaText = p1;
                Assert.IsNull(_gamingMachineListPage.CurrentGamingLightingSelectionAreaText);
            }
            else
            {
                Assert.AreEqual(_gamingMachineListPage.ShowTextbox(_gamingMachineListPage.LightingEffectDropMenu).ToLower(), p1.ToLower());
            }
            _selectLightingTypeName = p0;
        }

        [Then(@"The light name should be ""(.*)""")]
        public void ThenTheLightNameShouldBe(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _gamingMachineListPage.CurrentLightingSelectionAreaText = p0;
            WindowsElement currentSelectionArea = _gamingMachineListPage.CurrentGamingLightingSelectionAreaText;
            string currentSelectionAreaText = _gamingMachineListPage.ShowTextbox(currentSelectionArea);
            Assert.IsTrue(currentSelectionAreaText.Contains(p0));
        }

        [Then(@"Click ""(.*)"" and Select ""(.*)""")]
        public void ThenClickAndSelect(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            string compareName = "lightingType";
            int blockIndex = 0;
            if (!string.IsNullOrEmpty(p0))
            {
                blockIndex = _gamingMachineListPage.SelectBock(p0);
            }

            if (string.IsNullOrEmpty(p1))
            {
                return;
            }
            if (p1.Contains(":"))
            {
                compareName = p1.Split(':')[0];
                p1 = p1.Split(':')[1].Trim();
            }

            if (!_gamingMachineListPage.ShowTextbox(_gamingMachineListPage.LightingEffectDropMenu).ToLower().Equals(p1.ToLower()))
            {
                _gamingMachineListPage.LightingEffectDropMenu.Click();
                _gamingMachineListPage.LightingEffectAutomationId = p1;
                _gamingMachineListPage.LightingEffectElement.Click();
            }

            if (isCompareFile)
            {

                _selectLightingTypeName = p0;

                LightingItem compareLightingItem;
                string selectCompreValue;

                List<LightingItem> newCompareLightingStyle;

                List<LightingItem> oldCompareLightingStyle;
                oldCompareLightingStyle = _originalLedProfileList.style1;
                switch (profileIndex)
                {
                    case 2:
                        oldCompareLightingStyle = _originalLedProfileList.style2;
                        break;
                    case 3:
                        oldCompareLightingStyle = _originalLedProfileList.style3;
                        break;
                }
                // 比较set to default 默认值，
                // 比较BASE 和 XML
                int blockValue;
                bool compareBaseFile = _gamingMachineListPage.LightingComparisonBaseFile(
                    profileIndex, blockIndex, p1, lightingBlockIdItemFromBaseFile, compareName,
                    out compareLightingItem, out selectCompreValue, out blockValue, out newCompareLightingStyle);
                Assert.IsTrue(compareBaseFile, "Compare Base File is Failed");

                // 比较LOG 和 XML
                bool compareDeveloperLog = _gamingMachineListPage.ReadFormLogGenerate(compareLightingItem,
                    _selectLightingTypeName, p1);
                Assert.IsTrue(compareDeveloperLog, "Compare Developer Set Log is Failed");

                // 比较变化的值(XML And XML)
                bool compareLightingXmlFile = _gamingMachineListPage.LightingComparisonLocalFile(profileIndex,
                    blockIndex, lightingBlockIdItemFromBaseFile,
                    compareName, _originalLedProfileList);
                Assert.IsTrue(compareLightingXmlFile, "Compare Lighting Xml File is Failed");

                // 不一样  log and log

                bool changed = false;
                string[] changedEffects = GamingMachineListPage.ChangedListEffect.Split('/');
                List<string> effectList = new List<string>(changedEffects);
                string changedEffect = effectList.Find(item => item.Equals(p1.Trim()));
                if (!string.IsNullOrWhiteSpace(changedEffect))
                {
                    changed = true;
                }

                // 比较Type变化的值(New Type And Old Type) changed = true  代表其他block 和新的 Type 一致
                // 比较Type变化的值(New Type And Old Type) changed = false 代表之前block 和旧的 Type 一致

                bool compareLightingXmlTypeFile = _gamingMachineListPage.LightingComparsionXMLAndLog(
                    newCompareLightingStyle, oldCompareLightingStyle,
                    changed, _readFormLogStr, selectCompreValue, _selectLightingTypeName, blockValue.ToString());
                Assert.IsTrue(compareLightingXmlTypeFile, "Compare Type Lighting Xml File is Failed");

            }
        }

        [Then(@"Click ""(.*)"" and Hover ""(.*)""")]
        public void ThenClickAndHover(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            if (string.IsNullOrEmpty(p0))
            {
                _gamingMachineListPage.LightingEffectDropMenu.Click();
                _gamingMachineListPage.LightingEffectAutomationId = p1;
                VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingMachineListPage.LightingEffectElement);
            }
            else
            {
                int blockIndex = _gamingMachineListPage.SelectBock(p0);

                if (string.IsNullOrEmpty(p1))
                {
                    return;
                }
                string compareName = "lightingType";
                if (p1.Contains(":"))
                {
                    compareName = p1.Split(':')[0];
                    p1 = p1.Split(':')[1].Trim();
                }

                if (!_gamingMachineListPage.ShowTextbox(_gamingMachineListPage.LightingEffectDropMenu).ToLower().Equals(p1.ToLower()))
                {
                    _gamingMachineListPage.LightingEffectDropMenu.Click();
                    _gamingMachineListPage.LightingEffectAutomationId = p1;
                    VantageCommonHelper.HoverOnVantage(_webDriver.Session, _gamingMachineListPage.LightingEffectElement);
                }
            }
        }

        [Then(@"(.*) bar should be shown and the value should be '(.*)'")]
        public void ThenBrightnessBarShouldBeShownAndTheValueShouldBe(string p0, string p1)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            switch (p0.ToLower())
            {
                case "brightness":
                    _gamingMachineListPage.BrightnessLevel = p1;
                    Assert.IsNotNull(_gamingMachineListPage.BrightnessLevelElement);
                    break;

                case "speed":
                    _gamingMachineListPage.SpeedLevel = p1;
                    Assert.IsNotNull(_gamingMachineListPage.SpeedLevelElement);
                    break;
            }
        }

        [Then(@"Color should be RGB ""(.*)""")]
        public void ThenColorShouldBeRGB(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            int selectColorId;
            Assert.AreEqual(p0, _gamingMachineListPage.GetSelectedColorValue(out selectColorId));

            if (isCompareFile)
            {
                List<int> colorId = _gamingMachineListPage.GetLightingColorId();
                int compareValue = colorId[selectColorId];
                _gamingMachineListPage.CompareColorBaseFileLogXml(profileIndex, _blockIndex, lightingBlockIdItemFromBaseFile, _originalLedProfileList, compareValue.ToString(), _selectLightingTypeName);

            }
        }

        [Then(@"The ""(.*)"" is show in Lighting")]
        public void ThenTheIsShowInLighting(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _gamingMachineListPage.LightingEffectAutomationId = p0;
            Assert.IsNotNull(_gamingMachineListPage.LightingEffectElement, p0 + " is not show in Lighting");
        }

        [Then(@"The Left Arrow In The Switch Lights Bar Is ""(.*)""")]
        public void ThenTheLeftArrowInTheSwitchLightsBarIs(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            if (p0 == "Clickable")
            {
                Assert.IsNotNull(_gamingMachineListPage.GamingLightingLeftArrow, "The left arrow is not clickable.");
            }
            else if (p0 == "Grey And Cannot Be Clickable")
            {
                Assert.IsNotNull(_gamingMachineListPage.GamingLightingLeftArrowGrey, "The left arrow is not grey.");
            }
            else
            {
                Assert.Fail("Please input Clickable or Grey And Cannot Be Clickable.");
            }
        }

        [Then(@"The Right Arrow In The Switch Lights Bar Is ""(.*)""")]
        public void ThenTheRightArrowInTheSwitchLightsBarIs(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            if (p0 == "Clickable")
            {
                Assert.IsNotNull(_gamingMachineListPage.GamingLightingRightArrow, "The right arrow is not clickable.");
            }
            else if (p0 == "Grey And Cannot Be Clickable")
            {
                Assert.IsNotNull(_gamingMachineListPage.GamingLightingRightArrowGrey, "The right arrow is not grey.");
            }
            else
            {
                Assert.Fail("Please input Clickable or Grey And Cannot Be Clickable.");
            }
        }

        [Then(@"Lighting section display normally at homepage")]
        public void ThenLightingSectionDisplayNormally()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement customizeElement = _gamingMachineListPage.CustomizeElement;
            WindowsElement lightingElement = _gamingMachineListPage.LightingSectionHomepageElement;
            WindowsElement lightingProfileOffElement = _gamingMachineListPage.LightingProfileOffHomepageElement;
            WindowsElement lightingProfile1Element = _gamingMachineListPage.LightingProfile1HomepageElement;
            WindowsElement lightingProfile2Element = _gamingMachineListPage.LightingProfile2HomepageElement;
            WindowsElement lightingProfile3Element = _gamingMachineListPage.LightingProfile3HomepageElement;
            Assert.IsNotNull(customizeElement, "Gaming CustomizeElement is null");
            Assert.IsNotNull(lightingElement, "Gaming Homepgae Lighting Section is null");
            Assert.IsTrue(lightingProfileOffElement != null && lightingProfile1Element != null && lightingProfile2Element != null && lightingProfile3Element != null, "Gaming Homepage Profile is null");
        }

        [Then(@"four lighting profiles dispaly")]
        public void ThenFourLightingProfilesDispaly()
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            WindowsElement lightingSubpageProfileOff = _gamingMachineListPage.StyleOffElement;
            WindowsElement lightingSubpageProfile1 = _gamingMachineListPage.Style1Element;
            WindowsElement lightingSubpageProfile2 = _gamingMachineListPage.Style2Element;
            WindowsElement lightingSubpageProfile3 = _gamingMachineListPage.Style3Element;
            Assert.IsTrue(lightingSubpageProfileOff != null && lightingSubpageProfile1 != null && lightingSubpageProfile2 != null && lightingSubpageProfile3 != null, "Gaming Subpage Profile is null");
        }

        [Then(@"lighting profile (.*) is selected")]
        public void ThenLightingProfileIsSelected(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            switch (p0)
            {
                case "off":
                    p0 = "off";
                    break;
                case "1":
                    p0 = "first";
                    break;
                case "2":
                    p0 = "second";
                    break;
                case "3":
                    p0 = "third";
                    break;
            }
            var windowsElement = FindElementsByTimes(_webDriver.Session, "XPath", "//*[@AutomationId='profile_" + p0 + "_radio']");
            if (windowsElement != null)
            {
                Assert.IsTrue(windowsElement[0].Selected, "The current selected profile is not Profile " + p0);
            }
        }

        [Then(@"lighting profile (.*) is selected at homepage")]
        public void ThenLightingProfileIsSelectedAtHomepage(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            switch (p0)
            {
                case "1":
                    p0 = "first";
                    break;
                case "2":
                    p0 = "second";
                    break;
                case "3":
                    p0 = "third";
                    break;
            }
            var windowsElement = FindElementsByTimes(_webDriver.Session, "XPath", "//*[@AutomationId='" + p0 + "_radio']");
            if (windowsElement != null)
            {
                Assert.IsTrue(windowsElement[0].Selected, "The current selected profile is not Profile " + p0);
            }
        }

        [When(@"set lighting profile to default")]
        public void WhenSetLightingProfileToDefault()
        {
            if (RegistryHelp.IsRegistryKeyExist(RegistryLightingProfile))
            {
                RegistryHelp.DeleteRegistryKeyValue(RegistryLightingProfile);
            }
        }

        [Then(@"The ""(.*)"" is not show in Lighting")]
        public void ThenTheIsNotShowInLighting(string p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            _gamingMachineListPage.LightingEffectAutomationId = p0;
            Assert.IsNull(_gamingMachineListPage.LightingEffectElement, p0 + " is show");
        }

        [Then(@"profile tips shows normally")]
        public void ThenProfileTipsShowsNormally(string text)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            var windowsElement = FindElementsByTimes(_webDriver.Session, "Name", text);
            Assert.IsNotNull(windowsElement, "profile off tips is null");
        }

        [Then(@"Lighting subpage profile(.*) CPU default page is consisent with UI")]
        public void ThenLightingSubpageProfileCPUDefaultPageIsConsisentWithUI(int p0)
        {
            _gamingMachineListPage = new GamingLightingPages(_webDriver.Session);
            // profile3的CPU lighting比profile1和2多一个color色块
            ThenFourLightingProfilesDispaly();
            if (p0 == 3)
            {
                _gamingMachineListPage.BrightnessLevel = "3";
                _gamingMachineListPage.SpeedLevel = "2";
                Assert.IsNotNull(_gamingMachineListPage.ColorBtnElement, "Color Button is null");
                Assert.IsNotNull(_gamingMachineListPage.ColorText, "Color Text is null");
            }
            Assert.IsNotNull(_gamingMachineListPage.BrightnessLevelElement, "Brightness Level is null");
            Assert.IsNotNull(_gamingMachineListPage.BrightnessText, "Brightness Text is null");
            Assert.IsNotNull(_gamingMachineListPage.SpeedLevelElement, "Speed Level is null");
            Assert.IsNotNull(_gamingMachineListPage.SpeedLevelText, "Speed Text is null");
            Assert.IsNotNull(_gamingMachineListPage.GamingLightingRightArrow, "Right Arrow is null");
            Assert.IsNotNull(_gamingMachineListPage.GamingLightingLeftArrow, "Left Arrow is null");
            Assert.IsNotNull(_gamingMachineListPage.LightingSetToDefaultElement, "Set To Default is null");
            Assert.IsNotNull(_gamingMachineListPage.LightingEffectDropMenu, "EffectDropMenu is null");
            Assert.IsNotNull(_gamingMachineListPage.LightingEffectText, "Effect Text is null");

        }

    }
}
