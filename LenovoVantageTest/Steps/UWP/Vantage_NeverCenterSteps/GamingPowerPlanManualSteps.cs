using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingPowerPlanManualSteps : SettingsBase
    {
        private WindowsDriver<WindowsElement> _session;
        private WindowsDriver<WindowsElement> _appsession;

        public GamingPowerPlanManualSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"Choose A Power Plan '(.*)' Is '(.*)'")]
        public void GivenChooseAPowerPlan(string p0, string p1)
        {
            _appsession = this.GetControlPanelSession();
            WindowsElement typeElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerOptions);
            Assert.NotNull(typeElement, "The Power Options type not found.");
            typeElement.Click();
            Thread.Sleep(1000);
            WindowsElement optionElement = FindElementByTimes(_appsession, "Name", p0);
            Assert.NotNull(optionElement, "The Power Plan option not found.");
            if (p1.Trim() == "Not Selected")
            {
                optionElement.Click();
            }
            else if (p1.Trim() == "Selected")
            {
                Assert.IsTrue(optionElement.Selected, "Power Plan " + p0 + " is not selected.");
            }
        }

        [Given(@"Go To Power Options Page")]
        public void GivenGoToPowerOptionsPage()
        {
            _appsession = this.GetControlPanelSession();
            WindowsElement typeElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerOptions);
            Assert.NotNull(typeElement, "The Power Options type not found.");
            typeElement.Click();
            Thread.Sleep(1000);
        }

        [Given(@"Change Plan Settings For The '(.*)' Plan")]
        public void GivenChangePlanSettingsForThePlan(string p0)
        {
            string settingsName = "Change plan settings for the " + p0 + " plan";
            WindowsElement optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerChangePlanSettingsMap[settingsName]);
            Assert.NotNull(optionElement, "The Change plan settings not found.");
            optionElement.Click();
            Thread.Sleep(1000);
        }

        [Given(@"Modify And Save The Plan Settings")]
        public void GivenModifyAndSaveThePlanSettings()
        {
            WindowsElement optionElement;
            Random random = new Random();
            int settingsRandom = 0, itemRandom = 0, count = 0;
            do
            {
                settingsRandom = random.Next(0, VantageConstContent.PowerDisplaySleepMap.Count);
                optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerDisplaySleepMap[settingsRandom]);
                Assert.NotNull(optionElement, "The Display or Sleep combo box not found.");
                optionElement.Click();
                Thread.Sleep(1000);
                itemRandom = random.Next(0, VantageConstContent.PowerDisplaySleepTimeMap.Count);
                optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerDisplaySleepTimeMap[itemRandom]);
                Assert.NotNull(optionElement, "The list item not found.");
                optionElement.Click();
                Thread.Sleep(1000);
                optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerSaveChangesBtn);
                count += 1;
            } while (optionElement == null && count <= 3);

            Assert.NotNull(optionElement, "The Save changes button not found.");
            optionElement.Click();
            Thread.Sleep(1000);
        }

        [Given(@"Reset The Plan Settings")]
        public void GivenResetThePlanSettings()
        {
            WindowsElement optionElement;
            int count = 0;
            do
            {
                optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerDisplaySleepMap[count]);
                Assert.NotNull(optionElement, "The Display or Sleep combo box not found.");
                optionElement.Click();
                Thread.Sleep(1000);
                optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerDisplaySleepTimeMap[0]);
                Assert.NotNull(optionElement, "The list item not found.");
                optionElement.Click();
                Thread.Sleep(1000);
                count += 1;
            } while (count < VantageConstContent.PowerDisplaySleepMap.Count);

            optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerSaveChangesBtn);
            Assert.NotNull(optionElement, "The Save changes button not found.");
            optionElement.Click();
            Thread.Sleep(1000);
        }


        [Given(@"Modify The Name Of '(.*)' to '(.*)'")]
        public void GivenModifyTheNameOfTo(string p0, string p1)
        {
            bool found = false;
            string guid = string.Empty;
            foreach (var item in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (item.SCHEME_GUID_NAME == p0)
                {
                    found = true;
                    guid = item.SCHEME_GUID;
                    break;
                }
            }
            //Assert.IsTrue(found, "Power plan " + p0 + " is not found in the system power plan.");
            if (found)
            {
                DesktopPowerManagementHelper.RunCmd("powercfg -changename " + guid + " \"" + p1 + "\"");
            }
            found = false;
            foreach (var item in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (item.SCHEME_GUID_NAME == p1)
                {
                    found = true;
                    guid = item.SCHEME_GUID;
                    break;
                }
            }
            Assert.IsTrue(found, "Failed to modify power plan " + p0 + " to " + p1);
        }

        [Then(@"Close The Power Options Page")]
        public void ThenCloseThePowerOptionsPage()
        {
            WindowsElement optionElement = FindElementByTimes(_appsession, "XPath", VantageConstContent.PowerOptionsCloseBtn);
            Assert.NotNull(optionElement, "The Power Options Close button not found.");
            optionElement.Click();
        }

        [Then(@"Power Plan Or GUID '(.*)' Is '(.*)'")]
        public void ThenPowerPlanIs(string p0, string p1)
        {
            bool active = false;
            bool found = false;
            foreach (var item in DesktopPowerManagementHelper.GetPowerPlanSchemesInfo())
            {
                if (item.SCHEME_GUID_NAME.Trim() == p0.Trim())
                {
                    found = true;
                    active = item.SCHEME_GUID_STATUS;
                    if (p1 != "Active" && p1 != "Shown" && p1 != "Hidden")
                    {
                        Assert.AreEqual(p1, item.SCHEME_GUID, p1 + " is not the GUID of " + p0);
                    }
                    break;
                }
                else if (item.SCHEME_GUID == p0)
                {
                    found = true;
                    active = item.SCHEME_GUID_STATUS;
                    break;
                }
            }
            if (p1 == "Hidden")
            {
                Assert.IsFalse(found, "Power plan or GUID " + p0 + " is found in the system power plan.");
            }
            else
            {
                Assert.IsTrue(found, "Power plan or GUID " + p0 + " is not found in the system power plan.");
                if (p1 == "Active")
                {
                    Assert.IsTrue(active, "Power plan or GUID" + p0 + " should be active.");
                }
            }
        }
    }
}
