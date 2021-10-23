namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using System.Drawing;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class Dashboard_NarrowWindow_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public CmdCommands cmdCommands;

        //private readonly InformationalWebDriver webDriver;
        private Utility.InformationalWebDriver webDriver;

        private DasheboardPage_NarrowWindow dasheboardPage_NarrowWindow;

        public Dashboard_NarrowWindow_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Narrow the shell window")]
        public void GivenNarrowTheShellWindow()
        {
            int newWidth = 700;
            int newHight = 700;
            webDriver.Session.Manage().Window.Size = new Size(newWidth, newHight);
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);

        }

        [Then(@"The menus on common header will be collapsed into a hamburger button")]
        public void ThenTheMenusOnCommonHeaderWillBeCollapsedIntoAHamburgerButton()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.IsTrue(dasheboardPage_NarrowWindow.hamburgerButton.Displayed);
        }

        [When(@"Click on the hamburger button")]
        public void WhenClickOnTheHamburgerButton()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            dasheboardPage_NarrowWindow.hamburgerButton.Click();
        }

        [Then(@"Verify Dashboard menu list correctly in hamburger style")]
        public void ThenVerifyDashboardMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Thread.Sleep(8000);
            Assert.IsTrue(dasheboardPage_NarrowWindow.dashboardMenu.Enabled);
        }

        [Then(@"Verify Device menu list correctly in hamburger style")]
        public void ThenVerifyDeviceMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.IsTrue(dasheboardPage_NarrowWindow.deviceMenu.Displayed);
            Assert.IsTrue(dasheboardPage_NarrowWindow.deviceMenu_MyDevice.Displayed);
            Assert.IsTrue(dasheboardPage_NarrowWindow.deviceMenu_MyDeviceSettings.Displayed);
            Assert.IsTrue(dasheboardPage_NarrowWindow.deviceMenu_SystemUpdate.Displayed);
        }

        [Then(@"Verify Security menu list correctly in hamburger style")]
        public void ThenVerifySecurityMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.IsTrue(dasheboardPage_NarrowWindow.securityMenu.Enabled);
            Assert.IsTrue(dasheboardPage_NarrowWindow.securityMenu_MySecurity.Enabled);
            Assert.IsTrue(dasheboardPage_NarrowWindow.securityMenu_AntiVirus.Enabled);
            Assert.IsTrue(dasheboardPage_NarrowWindow.securityMenu_PasswordHealth.Enabled);
            Assert.IsTrue(dasheboardPage_NarrowWindow.securityMenu_VPNSecurity.Enabled);
        }

        [Then(@"Verify Support menu list correctly in hamburger style")]
        public void ThenVerifySupportMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.IsTrue(dasheboardPage_NarrowWindow.supportMenu.Enabled);
        }

        [Then(@"Verify Hardware Scan menu list correctly in hamburger style")]
        public void ThenVerifyHardwareScanMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.IsTrue(dasheboardPage_NarrowWindow.hardwareScanMenu.Enabled);
        }

        [Then(@"Verify User menu list correctly in hamburger style")]
        public void ThenVerifyUserMenuListCorrectlyInHamburgerStyle()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            Assert.AreEqual("Hello, User!", dasheboardPage_NarrowWindow.userMenuText.GetAttribute("Name"));
            Assert.AreEqual("Preference Settings", dasheboardPage_NarrowWindow.userMenu_PreferenceSettings.GetAttribute("Name"));
            Assert.AreEqual("Lenovo Migration Assistant", dasheboardPage_NarrowWindow.userMenu_LenovoMigrationAssistant.GetAttribute("Name"));
            Assert.AreEqual("Give Feedback", dasheboardPage_NarrowWindow.userMenu_GivenFeedback.GetAttribute("Name"));
            Assert.AreEqual("Unlock Exclusives", dasheboardPage_NarrowWindow.userMenu_UnlockExclusive.GetAttribute("Name"));
            //string ulockText = dasheboardPage_NarrowWindow.userMenu_UnlockExclusive.GetAttribute("Name");
            // Console.WriteLine("{0}", ulockText);
            // dasheboardPage_NarrowWindow.ScrollScreen();
            // Assert.IsTrue(dasheboardPage_NarrowWindow.userMenu_PreferenceSettings.Displayed);

        }

        [When(@"Click on the rest area of the vantage page, outside the its dropdown menu")]
        public void WhenClickOnTheRestAreaOfTheVantagePageOutsideTheItsDropdownMenu()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            dasheboardPage_NarrowWindow.PageTitle.Click();
        }

        [Then(@"The hamburger menu will be closed")]
        public void ThenTheHamburgerMenuWillBeClosed()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
        }

        [When(@"Scroll the screen in miniWindow")]
        public void WhenScrollTheScreenInMiniWindow()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            dasheboardPage_NarrowWindow.ScrollScreenInNarrowWindow();
        }

        [Then(@"Scroll the screen in miniWindow")]
        public void ThenScrollTheScreenInMiniWindow()
        {
            dasheboardPage_NarrowWindow = new DasheboardPage_NarrowWindow(webDriver.Session);
            dasheboardPage_NarrowWindow.ScrollScreenInNarrowWindow();
            //dasheboardPage_NarrowWindow.ScrollScreen();
        }


    }
}
