namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using TechTalk.SpecFlow;
    using OpenQA.Selenium.Appium.Windows;
    using System.Diagnostics;
    using System.Threading;

    [Binding]
    public sealed class WindowsRelatedSettingPage_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        /*private DashBoardPage dashBoardPage;
        private SecurityPage securityPage;
        private AntiVirusPage antiVirusPage;
        private PasswordHealthPage passwordHealthPage;
        private InternetProtectionPage internetProtectionPage;
        private VPNPage vpnPage;
        private WIFISecurityPage wifiSecurityPage;*/

        private InformationalWebDriver desktopSession;

        private BaseTestClass baseTestClass = new BaseTestClass();

        public WindowsRelatedSettingPage_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Verify it open corresponding feature ffor Windows Actication")]
        public void ThenVerifyItOpenCorrespondingFeatureFforWindowsActication()
        {
            {
                desktopSession = baseTestClass.DesktopSession();
                WindowsElement url = desktopSession.Session.FindElementByAccessibilityId("addressEditBox");
                Assert.AreEqual(WebSiteUrl.antiVirusSubScribeUrl, url.Text);
            }
        }

        [Then(@"Verify it open Setting page")]
        public void ThenVerifyItOpenSettingPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(5000);
            string actualSettingsLabel = desktopSession.Session.FindElementByAccessibilityId("SettingsLabel").Text;
            Assert.AreEqual(WindowsRelatedData.expect_WindowsSettingsPageTitle, actualSettingsLabel);
        }

        [Then(@"Close the Setting page")]
        public void ThenCloseTheSettingPage()
        {
            Process[] processes = Process.GetProcessesByName("SystemSettings");

            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }

        [Then(@"Verify it open corresponding feature for User Account Control")]
        public void ThenVerifyItOpenCorrespondingFeatureForUserAccountControl()
        {
            desktopSession = baseTestClass.DesktopSession();
            Thread.Sleep(20000);
            WindowsElement settingForUACPage = desktopSession.Session.FindElementByClassName("NativeHWNDHost");
            Assert.IsTrue(settingForUACPage.Enabled);     
        }

        [Then(@"Close the User Account Control Setting page")]
        public void ThenCloseTheUserAccountControlSettingPage()
        {
            Thread.Sleep(20000);
            Process[] processes = Process.GetProcessesByName("dllhost");

            foreach (Process process in processes)
            {
                process.Kill();
                process.WaitForExit();
                process.Dispose();
            }
        }

        [Then(@"Click the Cancel  button on the User Account Control Setting page")]
        public void ThenClickTheCancelButtonOnTheUserAccountControlSettingPage()
        {
            desktopSession = baseTestClass.DesktopSession();
            WindowsElement cancelButtonOnUACSettingPage = desktopSession.Session.FindElementByAccessibilityId("Button_Cancel");
            cancelButtonOnUACSettingPage.Click();
        }

    }
}

