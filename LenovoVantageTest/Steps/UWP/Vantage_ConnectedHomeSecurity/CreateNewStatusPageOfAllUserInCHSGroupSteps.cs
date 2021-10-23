using AventStack.ExtentReports.Gherkin.Model;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_ConnectedHomeSecurity
{
    [Binding]
    public sealed class CreateNewStatusPageOfAllUserInCHSGroupSteps
    {
        private InformationalWebDriver _webDriver;
        private CHSWebEnvPage _CHSWebEnvPage;
        private CHSMarketingPage _CHSMarketingPage;

        public CreateNewStatusPageOfAllUserInCHSGroupSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Change CHS Component From Web Consle Subscription Account (.*)")]
        public void GivenChangeCHSComponentFromWebConsleSubscriptionAccount(string p0)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            switch (p0)
            {
                case "AddFamilyNumber":
                    _CHSWebEnvPage.AddComponentInCHSWebPage(true, false, false, false, 0, false);
                    Thread.Sleep(4000);
                    break;
                case "RemoveFamilyNumber":
                    CHSWebEnvPage.RemoveFamilyFromCHSWeb(false);
                    Thread.Sleep(4000);
                    break;
                case "AddPlacesNumber":
                    _CHSWebEnvPage.AddComponentInCHSWebPage(false, true, false, false, 0, false);
                    Thread.Sleep(4000);
                    break;
                case "RemovePlacesNumber":
                    CHSWebEnvPage.RemovePlacesNumber(false);
                    Thread.Sleep(4000);
                    break;
                case "AddWifiNetworkNumber":
                    _CHSWebEnvPage.AddComponentInCHSWebPage(false, false, true, false, 0, false);
                    Thread.Sleep(4000);
                    break;
                case "RemoveWifiNetworkNumber":
                    CHSWebEnvPage.RemoveWifiNetworkNumber(false);
                    Thread.Sleep(4000);
                    break;
                case "AddHomeDeviceNumber":
                    _CHSWebEnvPage.AddComponentInCHSWebPage(false, false, false, true, 3, false);
                    Thread.Sleep(4000);
                    break;
                case "RemoveSubscribtionAccount":
                    CHSWebEnvPage.RemoveDevice("Subscription1");
                    break;
                case "ChangeCHSComponentFromWeb":
                    _CHSWebEnvPage.AddComponentInCHSWebPage(true, true, true, true, 3, false);
                    break;
                default:
                    Assert.Fail("The GivenChangeCHSComponentFromWebConsleSubscriptionAccount() paramter incorrect.info:" + p0);
                    break;
            }
        }
        [Then(@"Check CHS Group (.*) has (.*) number")]
        public void ThenCheckCHSGroupHasNumber(string p0, string p1)
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            //LogHelper.Logger.Instance.WriteLog(_webDriver.Session.PageSource);
            //Assert.NotZero(_CHSWebEnvPage.CHSTextList.Count,"can't find CHSTextList");
            List<string> CHSComponentsList = _CHSWebEnvPage.GetOverviewList();
            for (int i = 0; i < 5; i++)
            {
                if (CHSComponentsList.Count == 5)
                {
                    break;
                }
                Thread.Sleep(3000);
                CHSComponentsList = _CHSWebEnvPage.GetOverviewList();
            }
            switch (p0)
            {
                case "Family member":
                    string familyMemberNumber = CHSComponentsList[0];
                    Assert.AreEqual(p1, familyMemberNumber, "family member number not equal");
                    break;
                case "Places member":
                    string PlacesNumber = CHSComponentsList[1];
                    Assert.AreEqual(p1, PlacesNumber, "Places number not equal");
                    break;
                case "Personal device member":
                    string PersonalDeviceNumber = CHSComponentsList[2];
                    Assert.AreEqual(p1, PersonalDeviceNumber, "PersonalDevice number not equal");
                    break;
                case "Wifi network":
                    string WifiNetworkNumber = CHSComponentsList[3];
                    Assert.AreEqual(p1, WifiNetworkNumber, "Wifi network number not equal");
                    break;
                case "Home devices":
                    string HomeDevicesNumber = CHSComponentsList[4];
                    Assert.AreEqual(p1, HomeDevicesNumber, "Home devices number not equal");
                    break;
                case "Offline":
                    Assert.AreEqual(p1.Split('-')[0], CHSComponentsList[0], "family member number not equal");
                    Assert.AreEqual(p1.Split('-')[1], CHSComponentsList[1], "Places number not equal");
                    Assert.AreEqual(p1.Split('-')[2], CHSComponentsList[3], "Wifi network number not equal");
                    Assert.AreEqual(p1.Split('-')[3], CHSComponentsList[4], "Home devices number not equal");
                    break;
                default:
                    Assert.Fail("The GivenChangeCHSComponentFromWebConsleSubscriptionAccount() paramter incorrect.info:" + p0);
                    break;
            }
        }
        [When(@"Click Offline Dialog Close Button")]
        public void WhenClickOfflineDialogCloseButton()
        {
            _CHSMarketingPage = new CHSMarketingPage(_webDriver.Session);
            if (_CHSMarketingPage.OfflineDialogCloseBtn != null)
            {
                _CHSMarketingPage.OfflineDialogCloseBtn.Click();
            }
        }

        [When(@"Add Web CHS")]
        public void WhenAddWebCHS()
        {
            _CHSWebEnvPage = new CHSWebEnvPage(_webDriver.Session);
            _CHSWebEnvPage.AddComponentInCHSWebPage(true, true, true, true, 3);
        }
    }
}
