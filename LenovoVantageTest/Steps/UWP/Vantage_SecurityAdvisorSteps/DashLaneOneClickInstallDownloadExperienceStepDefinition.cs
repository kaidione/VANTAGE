namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using System.Threading;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class DashLaneOneClickInstallDownloadExperienceStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private AntiVirusPage antivirusPage;
        private PasswordHealthPage passwordHealthPage;
        private WIFISecurityPage wifisecurityPage;
        private VPNPage vpnPage;
        private SecurityPage mysecurityPage;

        public DashLaneOneClickInstallDownloadExperienceStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [When(@"Click the Get DashLine Button")]
        public void WhenClickTheGetDashLineButton()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.getDashLaneButton.Click();
        }

        [Then(@"the dashlane password health manager and SA password health status are installing")]
        public void ThenTheDashlanePasswordHealthManagerAndSAPasswordHealthStatusAreInstalling()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.IsTrue(passwordHealthPage.dashLaneNotInstalledStatus.Enabled);
            Assert.IsTrue(passwordHealthPage.getDashLaneButton.Enabled);
            Assert.IsTrue(passwordHealthPage.saPasswordHealthStatus.Enabled);
        }

        [Then(@"Password Health is installing")]
        public void ThenPasswordHealthIsInstalling()
        {
            mysecurityPage = new SecurityPage(webDriver.Session);
            mysecurityPage.VerifyContentAreEqual("INSTALLING", mysecurityPage.passwordHealthInstallingText);
        }

        [Then(@"Password Health is installing in Anti-Virus SA Widget")]
        public void ThenPasswordHealthIsInstallingInAnti_VirusSAWidget()
        {
            antivirusPage = new AntiVirusPage(webDriver.Session);
            Assert.AreEqual(antivirusPage.passwordHealthInstalling_saWidget, antivirusPage.pAsswordHealthLink.GetAttribute("Name").Trim());
            //antivirusPage.VerifyContentAreEqual("Password Health INSTALLING",antivirusPage.passwordHealthInstalling);
        }

        [Then(@"Password Health is installing in Password Health SA Widget")]
        public void ThenPasswordHealthIsInstallingInPasswordHealthSAWidget()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            Assert.AreEqual(passwordHealthPage.passwordHealthInstalling_saWidget, passwordHealthPage.pAsswordHealthLink.GetAttribute("Name").Trim());
            //passwordHealthPage.VerifyContentAreEqual("Password Health INSTALLING",passwordHealthPage.passwordHealthInstalling);
        }

        [Then(@"Password Health is installing in WiFi Security SA Widget")]
        public void ThenPasswordHealthIsInstallingInWiFiSecuritySAWidget()
        {
            wifisecurityPage = new WIFISecurityPage(webDriver.Session);
            Assert.AreEqual(wifisecurityPage.passwordHealthInstalling_saWidget, wifisecurityPage.passwordHealthLink.GetAttribute("Name").Trim());
            //wifisecurityPage.VerifyContentAreEqual("Password Health INSTALLING",wifisecurityPage.passwordHealthInstalling);
        }

        [Then(@"Password Health is installing in VPN Security SA Widget")]
        public void ThenPasswordHealthIsInstallingInVPNSecuritySAWidget()
        {
            vpnPage = new VPNPage(webDriver.Session);
            Assert.AreEqual(vpnPage.passwordHealthInstalling_saWidget, vpnPage.pAsswordHealthLink.GetAttribute("Name").Trim());
            //vpnPage.VerifyContentAreEqual("Password Health INSTALLING", vpnPage.passwordHealthInstalling);
        }

        [Then(@"DASHLANE PASSWORD MANAGER is INSTALLING")]
        public void ThenDASHLANEPASSWORDMANAGERIsINSTALLING()
        {
            passwordHealthPage = new PasswordHealthPage(webDriver.Session);
            passwordHealthPage.VerifyContentAreEqual("DASHLANE PASSWORD MANAGER INSTALLING", passwordHealthPage.dashLaneIsInstalling);
        }

        [When(@"wait ten seconds")]
        public void WhenWaitTenSeconds()
        {
            Thread.Sleep(10 * 1000);
        }

        //[When(@"wait (.*) seconds")]
        //public void WhenWaitSeconds(int p0)
        //{
        //    Thread.Sleep(p0 * 1000);
        //}


    }
}
