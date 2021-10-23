using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class VAN26055_HDR4SMBSteps
    {
        private SMBCreatorsettingsPage _creatorsettingsPage;
        private InformationalWebDriver _webDriver;
        private HSQuickSettingsPage _hsQuickSettingsPage;

        public VAN26055_HDR4SMBSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Vantage has Creator settings page")]
        public void GivenVantageHasCreatorSettingsPage()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            _creatorsettingsPage.GotoProductivityCreatorsetting();

        }

        [Given(@"Vantage has no Creator settings page")]
        public void GivenVantageHasNoCreatorSettingsPage()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            if (_creatorsettingsPage.ProductivityEle != null)
            {
                _creatorsettingsPage.ProductivityEle.Click();
                Assert.IsNull(_creatorsettingsPage.Creatorsettings, "The system is creator system, it is not suitable for this case.");
            }
            else
            {
                Assert.IsNotNull(_creatorsettingsPage.ProductivityEle, "The system is not SMB system, it is not suitable for this case.");
            }
        }

        [Then(@"The Creator Settings page is opened")]
        public void ThenTheCreatorSettingsPageIsOpened()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            Assert.IsNotNull(_creatorsettingsPage.Creatorsettings, "The system is creator system, it is suitable for this case.");
        }

        [Then(@"HDR shouldn't show")]
        public void ThenHDRShouldnTShow()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            _creatorsettingsPage.ProductivityEle.Click();
            Assert.IsNull(_creatorsettingsPage.HDRtitle, "HDR can show");
            Assert.IsNull(_creatorsettingsPage.HDRdescription, "HDR can show");
        }

        [When(@"Check HDR exist or not")]
        public void WhenCheckHDRExistOrNot()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            Assert.IsNotNull(_creatorsettingsPage.HDRtitle, "HDR doesn't exist");
            Assert.IsNotNull(_creatorsettingsPage.HDRdescription, "HDR doesn't exist");
        }

        [When(@"Click here of HDR feature")]
        public void WhenClickHereOfHDRFeature()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            if (_creatorsettingsPage.HDRlanucher != null)
            {
                _creatorsettingsPage.HDRlanucher.Click();
            }
            else
            {
                Console.WriteLine("HDR here doesn't exist");
            }
        }
        [When(@"Refresh the page")]
        public void WhenRefreshThePage()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            _creatorsettingsPage.GoToMyDevicesSettings();
            _creatorsettingsPage.GotoProductivityCreatorsetting();

        }

        [Then(@"HDR Title and description should be correct")]
        public void ThenHDRTitleAndDescriptionShouldBeCorrect(Table table)
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "title":
                        Assert.NotNull(_creatorsettingsPage.HDRtitle, "The HDR title is null");
                        Assert.AreEqual(table.Rows[i][1], _creatorsettingsPage.HDRtitle.Text, "The HPD title is not correct");
                        break;
                    case "paragraph1":
                        Assert.NotNull(_creatorsettingsPage.HDRdescription, "The HDR description 1st paragraph is null");
                        Assert.AreEqual(table.Rows[i][1], _creatorsettingsPage.HDRdescription.Text, "The HDR description 1st paragraph is not correct");
                        break;
                    case "paragraph2":
                        Assert.NotNull(_creatorsettingsPage.HDRlanuchertext, "The HDR description 2nd paragraph is null");
                        Assert.AreEqual(table.Rows[i][1], string.Concat(_creatorsettingsPage.HDRlanuchertext.Text, _creatorsettingsPage.HDRlanucher.GetAttribute("Name").Insert(0, " ").Insert(5, ".")), "The HDR description 2nd paragraph is not correct");
                        break;
                    default:
                        Assert.Fail("ThenHDRTitleanddescriptionshouldbecorrect() not run" + table.Rows[i][1]);
                        break;
                }
            }
        }

        [Then(@"HDR should not show")]
        public void ThenHDRShouldNotShow()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            Assert.IsNull(_creatorsettingsPage.HDRtitle);
            Assert.IsNull(_creatorsettingsPage.HDRdescription);
            Assert.IsNull(_creatorsettingsPage.HDRlanuchertext);
            Assert.IsNull(_creatorsettingsPage.HDRlanucher);
        }

        [Then(@"It will open Windows Display settings page")]
        public void ThenItWillOpenWindowsDisplaySettingsPage()
        {
            AutomationElement DisplayBrightnessSlider = VantageCommonHelper.FindElementByIdIsEnabled(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.OS.Display.DisplayBrightnessSettings").ToString());
            Assert.IsNotNull(DisplayBrightnessSlider, "Display settings page hasn't been open");
        }

        [When(@"Resize the page")]
        public void WhenResizeThePage()
        {
            _creatorsettingsPage = new SMBCreatorsettingsPage(_webDriver.Session);
            _creatorsettingsPage.ResizeButton.Click();
        }
    }
}
