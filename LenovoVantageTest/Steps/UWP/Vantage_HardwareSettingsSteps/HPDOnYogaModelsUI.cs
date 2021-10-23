using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class HPDOnYogaModelsUI : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSSmartAssistPage _hSSmartAssistPage;
        private HSHPDPage _hSHPDPage;

        public HPDOnYogaModelsUI(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Then(@"HPD Check the sensing Title")]
        public void ThenHPDCheckTheTitle()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            string titleName = _hSHPDPage.IntelligentSensingTitle.GetAttribute("Name");
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.IntelligentSecurityTitleText"), titleName, "The Sensing title is not true");
        }

        [Then(@"The ZerotouchVideoPlayback is in Intelligent sensing")]
        public void ThenTheZerotouchVideoPlaybackIsInIntelligentSensing()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            String mesage = _hSHPDPage.IntelligentSecurityCollapseLink.GetAttribute("AriaProperties");
            String isopen = mesage.Split(';')[0].Split('=')[1];
            if (isopen == "true")
            {
                _hSHPDPage.IntelligentSecurityCollapseLink.Click();
                Thread.Sleep(1000);
            }
            Assert.IsNull(_hSHPDPage.VideoPlaybackTitle, "The VideoPlaybackTitle is not in Intellingent sensing");
            _hSHPDPage.IntelligentSecurityCollapseLink.Click();
            mesage = _hSHPDPage.IntelligentSecurityCollapseLink.GetAttribute("AriaProperties");
            if (!mesage.Contains("true"))
            {
                _hSHPDPage.IntelligentSecurityCollapseLink.Click();
            }
        }

        [Then(@"The ""(.*)"" is display next to ""(.*)""")]
        public void ThenTheIsDisplayNextTo(string p0, string p1)
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            String videoBack = _hSHPDPage.VideoPlaybackTitle.GetAttribute("ClickablePoint");
            if (p1 == "Zero touch lock")
            {
                String ztoloc = _hSHPDPage.HPDZeroTouchLockTitle.GetAttribute("ClickablePoint");
                Assert.Less(Convert.ToInt32(ztoloc.Split(',')[1]), Convert.ToInt32(videoBack.Split(',')[1]));
            }
            if (p0 == "Global settings")
            {
                String global = _hSHPDPage.GlobalSettingsTitle.GetAttribute("ClickablePoint");
                Assert.Less(Convert.ToInt32(videoBack.Split(',')[1]), Convert.ToInt32(global.Split(',')[1]));
            }
        }

        [Then(@"The HPD static image at the bottom of intelligent sensing")]
        public void ThenTheHPDStaticImageAtTheBottomOfIntelligentSensing()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            String image = _hSHPDPage.HPDImage.GetAttribute("ClickablePoint");
            String global = _hSHPDPage.GlobalSettingsTitle.GetAttribute("ClickablePoint");
            Assert.Less(Convert.ToInt32(global.Split(',')[1]), Convert.ToInt32(image.Split(',')[1]));
        }

        [Then(@"Scroll to HPDResetButton")]
        public void ThenScrollToHPDResetButton()
        {
            _hSSmartAssistPage = new HSSmartAssistPage(_webDriver.Session);
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            _hSSmartAssistPage.ScrollScreenToWindowsElement(_webDriver.Session, _hSHPDPage.HPDResetButton);
        }

        [Then(@"Check HPDGlobalSettingsCaption")]
        public void ThenCheckHPDGlobalSettingsCaption()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsCaptionText"), _hSHPDPage.GlobalSettingsCaption.GetAttribute("Name"), "The GlobalSettingsCaption title is not true");
        }

        [Then(@"Check The HPD GlobalSettings checkbox default value")]
        public void ThenCheckTheHPDGlobalSettingsCheckboxDeaultValue()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hSHPDPage.ClamshellCheckBox), "The ClamshellCheckBox defalut value is not true");
            Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hSHPDPage.SandCheckBox), "The SandCheckBox defalut value is not true");
            Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hSHPDPage.TentCheckBox), "The TentCheckBox defalut value is not true");
            Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(_hSHPDPage.PadCheckBox), "The PadCheckBox defalut value is not true");
        }

        [When(@"""(.*)"" the ""(.*)"" HPD checkbox")]
        public void WhenTheHPDCheckbox(string p0, string p1)
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            ToggleState ts = ToggleState.On;
            if (p0 == "unchecked")
            {
                ts = ToggleState.Off;
            }
            if (p1 == "all")
            {
                SetCheckBoxStatus(_hSHPDPage.ClamshellCheckBox, ts);
                SetCheckBoxStatus(_hSHPDPage.SandCheckBox, ts);
                SetCheckBoxStatus(_hSHPDPage.TentCheckBox, ts);
                SetCheckBoxStatus(_hSHPDPage.PadCheckBox, ts);
            }
            else if (p1 == "ClamshellCheckBox")
            {
                SetCheckBoxStatus(_hSHPDPage.ClamshellCheckBox, ts);
            }
            else if (p1 == "SandCheckBox")
            {
                SetCheckBoxStatus(_hSHPDPage.SandCheckBox, ts);
            }
            else if (p1 == "TentCheckBox")
            {
                SetCheckBoxStatus(_hSHPDPage.TentCheckBox, ts);
            }
            else if (p1 == "PadCheckBox")
            {
                SetCheckBoxStatus(_hSHPDPage.PadCheckBox, ts);
            }
        }

        [Then(@"The HPD red tip under four checkbox is ""(.*)""")]
        public void ThenTheHPDRedTipUnderFourCheckboxIs(string p0)
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            if (p0 == "show")
            {
                _hSHPDPage = new HSHPDPage(_webDriver.Session);
                Assert.NotNull(_hSHPDPage.GlobalSettingsUncheckTip, "The GlobalSettingsUncheckTip is not find");
                Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsUncheckTipText"), _hSHPDPage.GlobalSettingsUncheckTip.GetAttribute("Name"), "The GlobalSettingsCaption title is not true");
            }
            else
            {
                Assert.IsNull(_hSHPDPage.GlobalSettingsUncheckTip, "The GlobalSettingsUncheckTip is not find");
            }
        }

        [Then(@"Check GlobalSettings ""(.*)""")]
        public void ThenCheckGlobalSettingsContext(string p0)
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            if (p0 == "note")
            {
                Assert.NotNull(_hSHPDPage.GlobalSettingsContextOne, "The GlobalSettingsContextOne is not find");
                Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextOneText"), _hSHPDPage.GlobalSettingsContextOne.GetAttribute("Name"), "The GlobalSettingsContextOne title is not true");
                Assert.NotNull(_hSHPDPage.GlobalSettingsContextTwo, "The GlobalSettingsContextTwo is not find");
                Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextTwoText"), _hSHPDPage.GlobalSettingsContextTwo.GetAttribute("Name"), "The GlobalSettingsContextTwo title is not true");
            }
            else
            {
                Assert.NotNull(_hSHPDPage.GlobalSettingsContextThree, "The GlobalSettingsContextThree is not find");
                Assert.AreEqual(GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.HPD.GlobalSettingsContextThreeText"), _hSHPDPage.GlobalSettingsContextThree.GetAttribute("Name"), "The GlobalSettingsContextThree title is not true");
            }

        }

        [Then(@"Intelligent sensing all value change to defalut")]
        public void ThenIntelligentSensingAllValueChangeToDefalut()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDZeroTouchLoginCheckBox), "The HPDZeroTouchLoginCheckBox default ToggleState is not true");
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDZeroTouchLockCheckbox), "The HPDZeroTouchLockCheckbox default ToggleState is not true");
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.VideoPalybackToggle), "The VideoPalybackToggle default ToggleState is not true");
            _hSHPDPage.HPDZeroTouchLoginADVSettings?.Click();
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDZeroTouchLoginADSACheckBox), "The HPDZeroTouchLoginADSACheckBox default ToggleState is not true");
            _hSHPDPage.HPDZeroTouchLockADVSettings?.Click();
            Assert.AreEqual(ToggleState.Off, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDZeroTouchLockFacialRecogoitionCheckbox), "The HPDZeroTouchLockFacialRecogoitionCheckbox default ToggleState is not true");
            Assert.AreEqual(ToggleState.Off, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDAutoScreenLockTimerFast), "The HPDAutoScreenLockTimerFast default ToggleState is not true");
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDAutoScreenLockTimerMedium), "The HPDAutoScreenLockTimerMedium default ToggleState is not true");
            Assert.AreEqual(ToggleState.Off, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDAutoScreenLockTimerSlow), "The HPDAutoScreenLockTimerSlow default ToggleState is not true");
            Assert.AreEqual(ToggleState.On, _hSHPDPage.GetCheckBoxStatus(_hSHPDPage.HPDZeroTouchLockADSACheckBox), "The HPDZeroTouchLockADSACheckBox default ToggleState is not true");
        }

        [When(@"Click IntelligentSensing link")]
        public void WhenClickIntelligentSensingLink()
        {
            _hSHPDPage = new HSHPDPage(_webDriver.Session);
            _hSHPDPage.IntelligentSecurity?.Click();
        }

        [Then(@"Check The GlobalSettings regedit value")]
        public void ThenCheckTheGlobalSettingsRegeditValue(Table table)
        {
            string regValue;
            int expectValue = 0;
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\SmartSense\\Parameters\\HPD", true);
                regValue = reg.GetValue("EnabledYogaMode").ToString();
                reg.Close();
                for (int i = 0; i <= 3; i++)
                {
                    expectValue += Convert.ToInt32(table.Rows[0][i]);
                }
                Assert.AreEqual(expectValue.ToString(), regValue);
            }
            catch (Exception ErroMessage)
            {

            }
        }

        [When(@"Machine is under ""(.*)"" mode")]
        public void WhenMachineIsUnderMode(string p0)
        {
            try
            {
                RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Lenovo\MoccaMode", true);
                if (p0 == "Clamshell")
                {
                    reg.SetValue("Mode", "1");
                }
                else if (p0 == "Stand")
                {
                    reg.SetValue("Mode", "3");
                }
                else if (p0 == "Tent")
                {
                    reg.SetValue("Mode", "4");
                }
                else if (p0 == "Pad")
                {
                    reg.SetValue("Mode", "2");
                }
                reg.Close();
            }
            catch (Exception ErroMessage)
            {

            }
        }


    }
}
