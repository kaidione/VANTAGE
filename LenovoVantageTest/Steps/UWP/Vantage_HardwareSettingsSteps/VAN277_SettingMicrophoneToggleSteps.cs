using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP
{
    [Binding]
    public class SettingMicrophoneToggleSteps
    {
        private InformationalWebDriver _webDriver;
        private DashBoardPage _dashBoardPage;
        private HSAudioSettingsPage _hsAudioSettingsPage;
        private HSPowerSettingsPage _hSPowerSettingsPage;
        private ToggleState _toggleStatus = ToggleState.On;
        private bool _verifyPerformance = false;

        public SettingMicrophoneToggleSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Go to audio section")]
        public void GivenGoToAudioSection()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            if (result == false)
            {
                Console.WriteLine("Go to audio section() try Again");
                _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
                result = _hsAudioSettingsPage.GotoAudioPage();
            }
            Assert.IsTrue(result, " GivenGoToAudioSection() fail.");
        }

        [Given(@"Go to Microphone Panel")]
        public void GivenGoToMicrophonePanel()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.JumpMicrophoneLink);
            _hsAudioSettingsPage.JumpMicrophoneLink.Click();
        }

        [When(@"check the ui of microphone")]
        public void WhenCheckTheUiOfMicrophone()
        {
        }

        [When(@"Quickly switch toggle")]
        public void WhenQuicklySwitchToggle()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
            _verifyPerformance = VantageCommonHelper.PerformanceSwitchToggle(_hsAudioSettingsPage.MicrophoenCheckbox);
        }

        [Then(@"the header is microphone, there is toggle on the right")]
        public void ThenTheHeaderIsMicrophoneThereIsToggleOnTheRight()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.MicrophoneTitle);
            Assert.IsNotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
        }
        [Then(@"The toggle will not change")]
        public void ThenTheToggleWillNotChange()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicrophoenCheckbox), _toggleStatus);
            bool featureNormal = _hsAudioSettingsPage.CheckMuteState(_hsAudioSettingsPage.MicrophoenCheckbox);
            //bool featureNormal = _hsAudioSettingsPage.CompareToggle();
            Assert.IsTrue(featureNormal);
        }

        [When(@"Get microphone toggle status")]
        public void WhenGetMicrophoneToggleStatus()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
            _toggleStatus = VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicrophoenCheckbox);
        }

        [Then(@"Check '(.*)' function status is right within Audio page '(.*)'")]
        public void ThenCheckFunctionStatusIsRightWithinAudioPage(string func, string status)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState toggle = status == "on" ? ToggleState.On : ToggleState.Off;
            switch (func.ToLower())
            {
                case "microphone":
                    Assert.AreEqual(toggle, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.MicrophoenCheckbox), "Microphone Status incorrect within Audio page," + status);
                    break;
                default:
                    Assert.Fail("ThenCheckFunctionStatusIsRightWithinAudioPage() parameter incorrect,info:" + func);
                    break;
            }
        }

        [Then(@"The toggle button should quickly respond to the turn on/off action")]
        public void ThenTheToggleButtonShouldQuicklyRespondToTheTurnOnOffAction()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsTrue(_verifyPerformance);
        }

        [When(@"Enter sleep")]
        [When(@"enter sleep")]
        public void WhenEnterSleep()
        {
            //Assert.IsTrue(SettingsBase.Sleep());
            WhenEnterSleepViaThreadWay();
        }

        [When(@"Enter hibernate")]
        [When(@"enter hibernate")]
        public void WhenEnterHibernate()
        {
            //Assert.IsTrue(SettingsBase.Hibernate());
            WhenEnterHibernateViaThreadWay();
        }

        [When(@"Enter hibernate via thread way")]
        public void WhenEnterHibernateViaThreadWay()
        {
            SettingsBase.OptionType = "hibernate";
            Assert.IsTrue(SettingsBase.SystemOptionDefault(), "WhenEnterHibernateViaThreadWay() Wake up Fail");
        }

        [When(@"Enter sleep via thread way")]
        public void WhenEnterSleepViaThreadWay()
        {
            SettingsBase.OptionType = "sleep";
            Assert.IsTrue(SettingsBase.SystemOptionDefault(), "WhenEnterHibernateViaThreadWay() Wake up Fail");
        }

        [StepDefinition(@"Wait '(.*)' seconds until the machine enters the system")]
        public void WhenWaitSecondsUntilTheMachineEntersTheSystem(int seconds)
        {
            do
            {
                try
                {
                    seconds--;
                    Thread.Sleep(1000);
                    SendKeys.SendWait("{Enter}");
                    if (!SettingsBase.ComputerScreenIsLocked())
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            Thread.Sleep(2000);
                            SendKeys.SendWait("{Enter}");
                        }
                        Console.WriteLine("the machine enters the system sucess!");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("WhenWaitSecondsUntilTheMachineEntersTheSystem Error Info:" + ex.Message);
                }

            } while (seconds > 0);
            Console.WriteLine("the machine enters the system Time out!");
        }

        [When(@"Switch vantage page micophone toggle")]
        public void WhenSwitchVantagePageMicophoneToggle()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hSPowerSettingsPage.GoToMyDevicesSettings();
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            Assert.IsTrue(result);
        }

        [When(@"Minimize vantage micophone toggle")]
        public void WhenMinimizeVantageMicophoneToggle()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioSettingsPage.VantageMinizeElement.Click();
            _webDriver.Session.Manage()?.Window?.Maximize();
        }
        [When(@"Relaungh vantage micophone toggle")]
        public void WhenRelaunghVantageMicophoneToggle()
        {
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
            var factory = new BaseTestClass();
            var appInstance = factory.LaunchWinApplication(VantageConstContent.VantageUwpAppid);
            _webDriver = appInstance;
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            Assert.IsTrue(result);
            VantageCommonHelper.CloseAlertWindow(_webDriver.Session);
        }

        [When(@"turn (.*) the microphone toggle")]
        public void WhenTurnMicrophoneToggle(string status)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
            _toggleStatus = VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicrophoenCheckbox);
            if (status == "on")
            {
                if (_toggleStatus.Equals(ToggleState.On))
                {
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                    Thread.Sleep(3000);
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                }
                else if (_toggleStatus.Equals(ToggleState.Off))
                {
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                }
            }
            else if (status == "off")
            {
                if (_toggleStatus.Equals(ToggleState.On))
                {
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                }
                else if (_toggleStatus.Equals(ToggleState.Off))
                {
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                    Thread.Sleep(3000);
                    _hsAudioSettingsPage.MicrophoenCheckbox.Click();
                }
            }
            else
            {
                Assert.Fail("Microphone toggle has no such status");
            }
        }

        [Then(@"the microphonr toggle is (.*)")]
        public void ThenCheckToggleAndOSD(string tgstatus)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.MicrophoenCheckbox);
            if (tgstatus == "on")
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicrophoenCheckbox), ToggleState.On);
            }
            else if (tgstatus == "off")
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsAudioSettingsPage.MicrophoenCheckbox), ToggleState.Off);
            }
            else
            {
                Assert.Fail("microphone has no such status");
            }
        }
    }
}
