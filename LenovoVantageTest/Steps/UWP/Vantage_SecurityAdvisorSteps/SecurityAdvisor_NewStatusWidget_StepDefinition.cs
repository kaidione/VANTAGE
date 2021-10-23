namespace LenovoVantageTest.Steps.UWP
{
    using LenovoVantageTest.Commands;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Utility;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System.Collections.Generic;
    using TechTalk.SpecFlow;

    [Binding]
    public sealed class SecurityAdvisor_NewStatusWidget_StepDefinition
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver webDriver;

        private SecurityPage securityPage;
        private List<WindowsElement> list;

        public SecurityAdvisor_NewStatusWidget_StepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [Given(@"Enabled FireWall")]
        public void GivenEnabledFireWall()
        {
            CmdCommands.TurnOnFireWall();
        }

        [Then(@"The Security Level Is No Protection")]
        public void ThenTheSecurityLevelIsNoProtection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            list = securityPage.GetWindowsElementList(securityPage.noPPath);
            Assert.AreEqual("No protection", list[0].Text);
        }

        [Then(@"The Text Above The Description Is No Protection")]
        public void ThenTheTextAboveTheDescriptionIsNoProtection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            list = securityPage.GetWindowsElementList(securityPage.noPPath);
            Assert.AreEqual("No protection", list[1].Text);
        }

        [Then(@"The No Protection Description Text Is Correct")]
        public void ThenTheDescriptionTextIsCorrect()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Your device has no security protection, so we enable Windows Defender for you as a minimum protection. To protect your device from incoming threats, try installing anti-virus software.", securityPage.noProtectionDescription);
        }

        [Then(@"The Security Level Is Basic")]
        public void ThenTheSecurityLevelIsBasic()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("BASIC", securityPage.basicText);
        }

        [Then(@"The Text Above The Description Is Basic Protection")]
        public void ThenTheTextAboveTheDescriptionIsBasicProtection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Basic protection", securityPage.basicProtection);
        }

        [Then(@"The Basic Protection Description Text Is Correct")]
        public void ThenTheBasicProtectionDescriptionTextIsCorrect()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Your device has only basic security protection enabled. For better protection, try enabling UAC notifications and using a password manager.", securityPage.basicProtectionDescription);
        }


        [Then(@"The Security Level Is Intermediate")]
        public void ThenTheSecurityLevelIsIntermediate()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.AreEqual(securityPage.expect_IntermediateSecurityLevel, securityPage.intermediateSecurityLevel.GetAttribute("Name"));
        }

        [Then(@"The Text Above The Description Is Intermediate Protection")]
        public void ThenTheTextAboveTheDescriptionIsIntermediateProtection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            Assert.AreEqual(securityPage.expect_IntermediateProtectionTitle, securityPage.intermediateProtectionTitle.GetAttribute("Name"));
        }

        [Then(@"The Intermediate Protection Description Text Is Correct")]
        public void ThenTheIntermediateProtectionDescriptionTextIsCorrect()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual(securityPage.expect_intermediateProtectionDescription, securityPage.intermediateProtectionDescription);
        }

        [Then(@"The Security Level Is Advanced")]
        public void ThenTheSecurityLevelIsAdvanced()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("ADVANCED", securityPage.advancedSecurityLevel);
        }


        [Then(@"The Text Above The Description Is Advanced Protection")]
        public void ThenTheTextAboveTheDescriptionIsAdvancedProtection()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Advanced protection", securityPage.advancedProtection);
        }

        [Then(@"The Advanced Protection Description Text Is Correct")]
        public void ThenTheIAdvancedProtectionDescriptionTextIsCorrect()
        {
            securityPage = new SecurityPage(webDriver.Session);
            securityPage.VerifyContentAreEqual("Congratulations! Your device has basic, intermediate and advanced security protection enabled, great job!", securityPage.advancedProtectionDescription);
        }


        [Given(@"Disabled FireWall")]
        public void GivenDisabledFireWall()
        {
            CmdCommands.TurnOffFireWall();
        }
    }
}
