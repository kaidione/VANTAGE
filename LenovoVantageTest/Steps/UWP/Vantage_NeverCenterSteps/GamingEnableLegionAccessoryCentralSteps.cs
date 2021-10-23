using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingEnableLegionAccessoryCentralSteps
    {
        private NerveCenterPages _nerveCenterPages;
        private InformationalWebDriver _webDriver;
        private string _driverName = "netfilterDriver";
        private string _netEaseCloudDec = "NetEase Cloud Music";
        public GamingEnableLegionAccessoryCentralSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"Legion Accessory Central Should Not Be Shown")]
        public void ThenLegionAccessoryCentralShouldNotBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.AccessoryIconName);
            Assert.IsNull(_nerveCenterPages.AccessoryIcon);
        }

        [Then(@"Legion Accessory Central Should Be Shown")]
        public void ThenLegionAccessoryCentralShouldBeShown()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryIconName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryIcon);
        }

        [Given(@"Click the Legion Accessory Central Icon")]
        public void GivenClickTheLegionAccessoryCentralIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryIconName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryIcon);
            _nerveCenterPages.AccessoryIcon.Click();
        }

        [Then(@"Legion Accessory Central App Should Be Opened")]
        public void ThenLegionAccessoryCentralAppShouldBeOpened()
        {
            Common.GetRunningProcess("legion_hid");
        }

        [Then(@"Legion Accessory Central Install Popup Should Be Opened")]
        public void ThenLegionAccessoryCentralInstallPopupShouldBeOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryInstallPopup);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCloseName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCloseIcon);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupInstallName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupInstallBtn);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCancelName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCancelBtn);
        }

        [Given(@"Click the Close button in the install popup")]
        public void GivenClickTheCloseButtonInTheInstallPopup()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCloseName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCloseIcon);
            _nerveCenterPages.AccessoryPopupCloseIcon.Click();
        }

        [Then(@"Install popup should be closed")]
        public void ThenInstallPopupShouldBeClosed()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNull(_nerveCenterPages.AccessoryInstallPopup);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupCloseName);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupCloseIcon);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupInstallName);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupInstallBtn);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupCancelName);
            Assert.IsNull(_nerveCenterPages.AccessoryPopupCancelBtn);
        }

        [Given(@"Click the Cancel button in the install popup")]
        public void GivenClickTheCancelButtonInTheInstallPopup()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCancelName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupCancelBtn);
            _nerveCenterPages.AccessoryPopupCancelBtn.Click();
        }

        [Given(@"Click the Install button in the install popup")]
        public void GivenClickTheInstallButtonInTheInstallPopup()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupInstallName);
            Assert.IsNotNull(_nerveCenterPages.AccessoryPopupInstallBtn);
            _nerveCenterPages.AccessoryPopupInstallBtn.Click();
        }

        [Then(@"Install Web page should be opened")]
        public void ThenInstallWebPageShouldBeOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            var openEdgeName = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, "Chrome_WidgetWin_1"));
            Assert.IsTrue(openEdgeName.Current.Name.Contains(_nerveCenterPages.AccessoryWebName));
        }
    }
}
