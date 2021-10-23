using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.IO;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingUICapabilityCheckSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private NerveCenterPages _nerveCenterPages;
        private string _lenovoGamingSystemPlugin = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoGamingSystemPlugin";
        private string _lenovoGamingUserPlugin = @"C:\ProgramData\Lenovo\ImController\Plugins\LenovoGamingUserPlugin";

        public GamingUICapabilityCheckSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }


        [Given(@"Delete The Gaming Tag")]
        public void GivenDeleteTheGamingTag()
        {
            if (RegistryHelp.IsRegistrySubKeyExist(VantageConstContent.GamingTag))
            {
                RegistryHelp.DeleteRegistrySubKey(VantageConstContent.GamingTag);
            }
        }

        [Then(@"The GamingPlugins Should Not Be Found")]
        public void ThenTheGamingPluginsShouldNotBeFound()
        {
            Assert.IsFalse(Directory.Exists(_lenovoGamingSystemPlugin), "LenovoGamingSystemPlugin Folder should not be found");
            Assert.IsFalse(Directory.Exists(_lenovoGamingUserPlugin), "LenovoGamingUserPlugin Folder should not be found");
        }

        [Then(@"The GamingPlugins Should Be Found")]
        public void ThenTheGamingPluginsShouldBeFound()
        {
            Assert.IsTrue(Directory.Exists(_lenovoGamingSystemPlugin), "LenovoGamingSystemPlugin Folder should be found");
            Assert.IsTrue(Directory.Exists(_lenovoGamingUserPlugin), "LenovoGamingUserPlugin Folder should be found");
        }

        [Given(@"The machine support '(.*)' Logo")]
        public void GivenTheMachineSupportLogo(string type)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            NerveCenterHelper.GamingFeatureValues logoicon = machine.GetValues(machine.GamingUITitle.LogoIcon);
            switch (type)
            {
                case "Y":
                    Assert.AreEqual("Y Logo", logoicon.Text, "The machine is not " + type + " Logo");
                    break;
                case "L":
                    Assert.AreEqual("L Logo", logoicon.Text, "The machine is not " + type + " Logo");
                    break;
                default:
                    Assert.Fail("the GivenTheMachineSupportLogo no run");
                    break;
            }
        }

        [Then(@"Gaming Logo Should Be Shown or Hidden '(.*)'")]
        public void ThenGamingLogoShouldBeShownOrHidden(string option)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            switch (option.ToLower())
            {
                case "shown":
                    Assert.NotNull(_nerveCenterPages.YLogo, "The Gaming Logo not found!");
                    break;
                case "hidden":
                    Assert.Null(_nerveCenterPages.YLogo, "The Gaming Logo still shown!");
                    break;
                default:
                    Assert.Fail("the ThenGamingLogoShouldBeShownOrHidden no run");
                    break;
            }
        }

        [Then(@"The '(.*)' Header Should Be Shown or Hidden '(.*)'")]
        public void ThenTheHeaderShouldBeShownOrHidden(string header, string option)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            _nerveCenterPages = new NerveCenterPages(_session);
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            NerveCenterHelper.GamingFeatureValues headname = machine.GetValues(machine.GamingUITitle.HeaderName);
            Assert.AreEqual(headname.Text.ToLower(), header.ToLower(), "The machine not support headname," + option);
            string target = header.Trim() + "_" + option.Trim();
            switch (target.ToLower())
            {
                case "legion_shown":
                    Assert.NotNull(_nerveCenterPages.LegionHeaderIMG, "The LegionHeaderIMG not found!");
                    break;
                case "legion_hidden":
                    Assert.Null(_nerveCenterPages.LegionHeaderIMG, "The LegionHeaderIMG still show!");
                    break;
                case "ideapadgaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadHeaderIMG, "The IdeapadHeaderIMG not found!");
                    break;
                case "ideapadgaming_hidden":
                    Assert.Null(_nerveCenterPages.LegionHeaderIMG, "The IdeapadHeaderIMG still show!");
                    break;
                case "ideacentregaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadCentreHeaderIMG, "The IdeapadCentreHeaderIMG not found!");
                    break;
                case "ideacentregaming_hidden":
                    Assert.Null(_nerveCenterPages.IdeapadCentreHeaderIMG, "The IdeapadCentreHeaderIMG still show!");
                    break;
                default:
                    Assert.Fail("The ThenTheHeaderShouldBeShownOrHidden no run.");
                    break;
            }
        }

        [Then(@"The '(.*)' Should Be Shown or Hidden '(.*)' in the Right Section")]
        public void ThenTheShouldBeShownOrHiddenInTheRightSection(string header, string option)
        {
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            _nerveCenterPages = new NerveCenterPages(_session);
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            NerveCenterHelper.GamingFeatureValues headname = machine.GetValues(machine.GamingUITitle.HeaderName);
            Assert.AreEqual(headname.Text.ToLower(), header.ToLower(), "The machine not support headname," + option);
            string target = header.Trim() + "_" + option.Trim();
            switch (target.ToLower())
            {
                case "legion_shown":
                    Assert.NotNull(_nerveCenterPages.LegionRightSectionIMG, "The LegionRightSectionIMG not found!");
                    break;
                case "legion_hidden":
                    Assert.Null(_nerveCenterPages.LegionRightSectionIMG, "The LegionRightSectionIMG still show!");
                    break;
                case "ideapadgaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadRightSectionIMG, "The IdeapadRightSectionIMG not found!");
                    break;
                case "ideapadgaming_hidden":
                    Assert.Null(_nerveCenterPages.IdeapadRightSectionIMG, "The IdeapadRightSectionIMG still show!");
                    break;
                case "ideacentregaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadCentreRightSectionIMG, "The IdeapadCentreRightSectionIMG not found!");
                    break;
                case "ideacentregaming_hidden":
                    Assert.Null(_nerveCenterPages.IdeapadCentreRightSectionIMG, "The IdeapadCentreRightSectionIMG still show!");
                    break;
                default:
                    Assert.Fail("The ThenTheShouldBeShownOrHiddenInTheRightSection no run.");
                    break;
            }
        }

        [Then(@"The '(.*)' Should Be Shown or Hidden '(.*)' in Help page")]
        public void ThenTheShouldBeShownOrHiddenInHelpPage(string header, string option)
        {
            return; //temp method
            string familyname = VantageCommonHelper.GetCurrentMachineType();
            _nerveCenterPages = new NerveCenterPages(_session);
            NerveCenterHelper.GamingMachine machine = NerveCenterHelper.GetGamingMachineInfo(familyname);
            NerveCenterHelper.GamingFeatureValues headname = machine.GetValues(machine.GamingUITitle.HeaderName);
            Assert.AreEqual(headname.Text.ToLower(), header.ToLower(), "The machine not support headname," + option);
            string target = header.Trim() + "_" + option.Trim();
            switch (target.ToLower())
            {
                case "legion_shown":
                    Assert.NotNull(_nerveCenterPages.LegionHelpPageIMG, "The LegionHelpPageIMG not found!");
                    break;
                case "legion_hidden":
                    Assert.Null(_nerveCenterPages.LegionHelpPageIMG, "The LegionHelpPageIMG still show!");
                    break;
                case "ideapadgaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadHelpPageIMG, "The IdeapadHelpPageIMG not found!");
                    break;
                case "ideapadgaming_hidden":
                    Assert.Null(_nerveCenterPages.IdeapadHelpPageIMG, "The IdeapadHelpPageIMG still show!");
                    break;
                case "ideacentregaming_shown":
                    Assert.NotNull(_nerveCenterPages.IdeapadCentreHelpPageIMG, "The IdeapadCentreHelpPageIMG not found!");
                    break;
                case "ideacentregaming_hidden":
                    Assert.Null(_nerveCenterPages.IdeapadCentreHelpPageIMG, "The IdeapadCentreHelpPageIMG still show!");
                    break;
                default:
                    Assert.Fail("The ThenTheShouldBeShownOrHiddenInHelpPage no run.");
                    break;
            }
        }
    }
}
