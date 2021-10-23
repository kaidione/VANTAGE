using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public sealed class HideWifiSecurityIfNoDriverInstalledStepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        public DashBoardPage dashBoardPage;
        public SecurityPage securitypage;
        public AntiVirusPage antiviruspage;
        public PasswordHealthPage passwordhealthpage;
        public VPNPage vpnpage;

        private readonly InformationalWebDriver webDriver;

        public HideWifiSecurityIfNoDriverInstalledStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Then(@"Security drop down list is no wifi security")]
        public void ThenSecurityDropDownListIsNoWifiSecurity()
        {
            dashBoardPage = new DashBoardPage(webDriver.Session);
            dashBoardPage.IsAutoIDNoPresent(dashBoardPage.wifiSecurityAutoId);
            //Assert.IsFalse(dashBoardPage.wifiSecurityLink.Enabled);
        }

        [Then(@"Verify the WiFi Security Text is not here")]
        public void ThenVerifyTheWiFiSecurityTextIsNotHere()
        {
            securitypage = new SecurityPage(webDriver.Session);
            securitypage.elementIsNoPresent(securitypage.wifiSecurityText, "Name");
            //Assert.IsFalse(securitypage.wifisecurityText.Enabled);
        }

        [Then(@"There is no wifi security on Anti-virus SA widget")]
        public void ThenThereIsNoWifiSecurityOnAnti_VirusSAWidget()
        {
            antiviruspage = new AntiVirusPage(webDriver.Session);
            antiviruspage.elementIsNoPresent(antiviruspage.wsLink_aid, "AutomationId");
            //Assert.IsFalse(antiviruspage.wifisecurityLink.Enabled);
        }

        [Then(@"There is no wifi security on Password Health SA widget")]
        public void ThenThereIsNoWifiSecurityOnPasswordHealthSAWidget()
        {
            passwordhealthpage = new PasswordHealthPage(webDriver.Session);
            passwordhealthpage.elementIsNoPresent(passwordhealthpage.wsLink_aid, "AutomationId");
            //Assert.IsFalse(passwordhealthpage.wifisecurityLink.Enabled);
        }

        [Then(@"There is no wifi security on VPN SA widget")]
        public void ThenThereIsNoWifiSecurityOnVPNSAWidget()
        {
            vpnpage = new VPNPage(webDriver.Session);
            vpnpage.elementIsNoPresent(vpnpage.wsLink_aid, "AutomationId");
            //Assert.IsFalse(vpnpage.wIFISecurityLink.Enabled);
        }

        [Then(@"Click VPN link on Password Health page")]
        public void ThenClickVPNLinkOnPasswordHealthPage()
        {
            passwordhealthpage = new PasswordHealthPage(webDriver.Session);
            passwordhealthpage.vpnsecurityLink.Click();
        }
    }
}
