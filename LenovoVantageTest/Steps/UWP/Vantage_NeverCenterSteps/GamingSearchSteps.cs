using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_NeverCenterSteps
{
    [Binding]
    public class GamingSearchSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private InformationalWebDriver _webDriver;
        private NerveCenterPages _nerveCenterPages;
        private IntelligentCoolingPages _intelligentcoolingPages;
        WindowsElement searchPageResultItemRow;

        public GamingSearchSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"Enter Search Page By Click The Search Icon In The Navigation Bar")]
        public void GivenEnterSearchPageByClickTheSearchIconInTheNavigationBar()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_nerveCenterPages.SearchIcon, "Search icon not found in the navigation bar.");
            _nerveCenterPages.SearchIcon.Click();
            Thread.Sleep(1000);
            Assert.IsNotNull(_nerveCenterPages.SearchInput, "Search input text box not found in the navigation bar.");
            _nerveCenterPages.SearchInput.Click();
            Thread.Sleep(1000);
        }

        [Given(@"Click The Search Button")]
        public void GivenClickTheSearchButton()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            if (NerveCenterHelper.GetMachineIsGaming())
                Assert.IsNotNull(_nerveCenterPages.SearchButton, "Search button not found in the Search page.");
            _nerveCenterPages.SearchButton.Click();
            Thread.Sleep(5000);
        }

        [Given(@"Click The Searched Result")]
        public void ThenClickTheSearchedResult()
        {
            Assert.IsNotNull(searchPageResultItemRow, "Search result is null.");
            searchPageResultItemRow.Click();
        }

        [Then(@"Check The Search Icon")]
        public void ThenCheckTheSearchIcon()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.SearchIcon, "Search icon not found in the navigation bar.");
        }

        [Then(@"The Search Result Feature Name Is '(.*)' Category Is '(.*)'")]
        public void ThenTheSearchResultFeatureNameIsCategoryIs(string p0, string p1)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            List<WindowsElement> elements = null;
            bool isSearched = false;
            int noSearchCount = 0;
            int searchCount = 0;
            int count = 0;
            if (_nerveCenterPages.SearchPageResultItemRows.Count == 0 && p1.Trim().ToLower() == "null")
            {
                return;
            }
            while (_nerveCenterPages.WaitText != null && count < 20)
            {
                count++;
            }
            Assert.IsTrue(_nerveCenterPages.SearchPageResultItemRows.Count > 0, "Search page result is empty.");
            elements = _nerveCenterPages.SearchPageResultItemRows;
            foreach (WindowsElement element in elements)
            {
                if (element.GetAttribute("Name").Contains(p0.Trim()) && element.GetAttribute("Name").Contains(p1.Trim()))
                {
                    isSearched = true;
                    searchPageResultItemRow = element;
                    break;
                }
                if (!element.GetAttribute("Name").Contains(p0.Trim()) && p1.Trim().ToLower() == "null")
                {
                    noSearchCount += 1;
                }
                if (element.GetAttribute("Name").Contains(p0.Trim()) && p1.Trim().ToLower() == "null")
                {
                    searchCount += 1;
                }
            }
            if (noSearchCount >= 1)
            {
                Assert.IsTrue(searchCount < 1, "Feature Name " + p0 + " is not null.");
                return;
            }
            Assert.IsTrue(isSearched, p0 + " or " + p1 + " is not searched.");
        }

        [Then(@"The Search Result Feature Name Is Not '(.*)' Category Is Not '(.*)'")]
        public void ThenTheSearchResultFeatureNameIsNotCategoryIsNot(string p0, string p1)
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            List<WindowsElement> elements = null;
            bool isSearched = false;
            if (_nerveCenterPages.SearchPageResultItemRows.Count == 0 && p1.Trim().ToLower() == "null")
            {
                return;
            }
            Assert.IsTrue(_nerveCenterPages.SearchPageResultItemRows.Count > 0, "Search page result is empty.");
            elements = _nerveCenterPages.SearchPageResultItemRows;
            foreach (WindowsElement element in elements)
            {
                if (element.GetAttribute("Name").Contains(p1.Trim()) && element.GetAttribute("Name").Contains(p0.Trim()))
                {
                    Assert.Fail("The search result feature name is " + p0 + "category is " + p1);
                }
            }
            Assert.IsTrue(true, p0 + " or " + p1 + " is searched.");
        }

        [Then(@"The Search Result Is Null")]
        public void TheSearchResultIsNull()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsTrue(_nerveCenterPages.SearchPageResultItemRows.Count == 0, "Search page reslut is not null!");
        }

        [Then(@"Macro Key Should Be Opened")]
        public void ThenMacroKeyShouldBeOpened()
        {
            _nerveCenterPages = new NerveCenterPages(_session);
            Assert.IsNotNull(_nerveCenterPages.MacroKeyTitle, "Fail to enter the macro key subpage.");
            Assert.IsTrue(_nerveCenterPages.MacroKeyTitle.GetAttribute("Name") == "Macro Key", "Fail to enter the macro key subpage.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyBackLink, "Fail to enter the macro key subpage.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeySettingsDropMenu, "Fail to enter the macro key subpage.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyStartRecording, "Start recording button is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad0, "The macro key number pad 0 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad1, "The macro key number pad 1 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad2, "The macro key number pad 2 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad3, "The macro key number pad 3 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad4, "The macro key number pad 4 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad5, "The macro key number pad 5 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad6, "The macro key number pad 6 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad7, "The macro key number pad 7 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad8, "The macro key number pad 8 is not show.");
            Assert.IsNotNull(_nerveCenterPages.MacroKeyNumPad9, "The macro key number pad 9 is not show.");
        }

    }
}
