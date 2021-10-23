using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class DolbyModeAndProfilesforVantageSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly InformationalWebDriver _webDriver;
        private ToggleState _voipOldValue = ToggleState.Off;
        private ToggleState _entertainmentOldValue = ToggleState.Off;
        private WindowsDriver<WindowsElement> _recordSession;
        private WindowsDriver<WindowsElement> _dolbyUwpDCHAppIdSession;
        private NerveCenterPages _nerveCenterPages;

        private HSAudioSettingsPage _hsAudioPage;
        private string _currentDolbyModeName = string.Empty;
        private bool _voipStateFlag;

        private string _dolbyUwpDynamicXpath = "//*[@AutomationId='ID_DYNAMIC']";
        private string _dolbyUwpMovieXpath = "//*[@AutomationId='ID_MOVIE']";
        private string _dolbyUwpVoiceXpath = "//*[@AutomationId='ID_VOICE']";
        private string _dolbyUwpGameXpath = "//*[@AutomationId='ID_GAME']";
        private string _dolbyUwpMusicXpath = "//*[@AutomationId='ID_MUSIC']";

        private string _dolbyUwpDynamicNameXpath = "//*[@Name='Dynamic']";
        private string _dolbyUwpMovieNameXpath = "//*[@Name='Movie']";
        private string _dolbyUwpVoiceNameXpath = "//*[@Name='Voice']";
        private string _dolbyUwpGameNameXpath = "//*[@Name='Game']";
        private string _dolbyUwpMusicNameXpath = "//*[@Name='Music']";

        public DolbyModeAndProfilesforVantageSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Dolby audio is off")]
        public void GivenDolbyAudioIsOff()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.AudioAutomaticDolbyCheckBox, ToggleState.Off);
            Assert.IsTrue(turnFlag, "GivenDolbyAudioIsOff");
        }

        [Given(@"Dolby audio is on")]
        public void GivenDolbyAudioIsOn()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.AudioAutomaticDolbyCheckBox, ToggleState.On);
            Assert.IsTrue(turnFlag, "GivenDolbyAudioIsOff");
        }

        [Given(@"go to Dolby section")]
        public void GivenGoToDolbySection()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioPage.GotoAudioPage();
            Assert.IsTrue(result);
        }

        [When(@"check the UI of Dolby mode")]
        public void WhenCheckTheUIOfDolbyMode()
        {
            Assert.IsTrue(true, "check the UI of Dolby mode");
        }

        [When(@"check Dolby options")]
        public void WhenCheckDolbyOptions()
        {
            Assert.IsTrue(true, "check Dolby options");
        }

        [Then(@"some machine provide (.*) options of Dolby modes: Dynamic, Movie, Music, Gaming, Voice")]
        public void ThenSomeMachineProvideOptionsOfDolbyModesDynamicMovieMusicGamingVoice(int p0)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool supportDolbyDynamic = _hsAudioPage.SupportDolbyDynamic();

            if (supportDolbyDynamic)
            {
                Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeDynamic, "Support Dolby Mode Dynamic");
            }
            else
            {
                Assert.IsNull(_hsAudioPage.HSRadioDolbyModeDynamic, "Not Support Dolby Dynamic");
            }

            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMovie, "Support Dolby Mode Movie");
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeVoip, "Support Dolby Mode Voip");
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMusic, "Support Dolby Mode Music");
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeGames, "Support Dolby Mode Games");
        }

        [Then(@"The Dolby options will be hidden")]
        public void ThenTheDolbyOptionsWillBeHidden()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsAudioPage.HSRadioDolbyModeMovie);
            Assert.IsNull(_hsAudioPage.HSRadioDolbyModeVoip);
            Assert.IsNull(_hsAudioPage.HSRadioDolbyModeMusic);
            Assert.IsNull(_hsAudioPage.HSRadioDolbyModeGames);
        }

        [Then(@"The Dolby options will show")]
        public void ThenTheDolbyOptionsWillShow()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMovie);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeVoip);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMusic);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeGames);
        }

        [Then(@"The Dolby mode should not change and should work normally")]
        public void ThenTheDolbyModeShouldNotChangeAndShouldWorkNormally()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_currentDolbyModeName);
            Assert.AreEqual(_currentDolbyModeName, _hsAudioPage.ShowTextbox(_hsAudioPage.GetCurrentDolbyModeElement()));
        }

        [Given(@"turn on the voip toggle")]
        public void GivenTurnOnTheVoipToggle()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioPage.TurnElementState(_hsAudioPage.AutomaticVoipCheckBox, ToggleState.On);
            _voipStateFlag = true;
            Assert.IsTrue(result, "GivenTurnOnTheVoipToggle: Turn Voip State On");
        }

        [Given(@"select (.*) mode")]
        public void GivenSelectMode(string dolbyMode)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement windowsElement = null;
            switch (dolbyMode.ToLower())
            {
                case "music":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeMusic;
                    break;
                case "voip":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeVoip;
                    break;
                case "movie":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeMovie;
                    break;
                case "dynamic":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeDynamic;
                    break;
            }
            Assert.IsTrue(_hsAudioPage.SelectDolbyMode(windowsElement), "select mode " + dolbyMode);
        }

        [When(@"switch pages/reopen Vantage/minimize")]
        public void WhenSwitchPagesReopenVantageMinimize()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _voipOldValue = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticVoipCheckBox);
            _entertainmentOldValue = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.EntertainmentCheckbox);
            _hsAudioPage.GotoAudioPage();
        }

        [Given(@"turn off the voip toggle")]
        public void GivenAndTurnOffTheVoipToggle()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            VantageCommonHelper.MoveDown(1);
            _voipStateFlag = false;
            bool result = _hsAudioPage.TurnElementState(_hsAudioPage.AutomaticVoipCheckBox, ToggleState.Off);
            Assert.IsTrue(result, "GivenAndTurnOffTheVoipToggle: Turn Voip State Off");
        }

        [Given(@"turn on Automatica Dolby Audio toggle")]
        public void GivenTurnOnAutomaticaDolbyAudioToggle()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.HSRadioDolbyModeVoip, ToggleState.On);
            Assert.IsTrue(turnFlag, "turn on Automatica Dolby Audio toggle");
        }

        [Given(@"go to Automatic Audio Optimization")]
        public void GivenGoToAutomaticAudioOptimization()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.SupportMachine();
        }

        [When(@"check the UI of Automatic Audio Optimization")]
        public void WhenCheckTheUIOfAutomaticAudioOptimization()
        {
            Assert.IsTrue(true, "check the UI of Automatic Audio Optimization");
        }

        [When(@"make a voice connection via Lync or use Voice Recorder")]
        public void WhenMakeAVoiceConnectionViaLyncOrUseVoiceRecorder()
        {
            _recordSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.WindowsSoundRecorderAppId);
            string recordXpth = "//*[@AutomationId='Record']";
            string stopXpth = "//*[@AutomationId='Stop']";
            WindowsElement stopButton = VantageCommonHelper.FindElementByXPath(_recordSession, stopXpth);
            stopButton?.Click();
            WindowsElement ele = VantageCommonHelper.FindElementByXPath(_recordSession, recordXpth);
            ele?.Click();
        }

        [StepDefinition(@"wait (.*) seconds")]
        public void WhenWaitSeconds(int p0)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.Wait(p0);
        }

        [When(@"check performance of the feature")]
        public void WhenCheckPerformanceOfTheFeature()
        {
            Assert.IsTrue(true, "check performance of the feature");
        }

        [Then(@"the header is Automatic Audio Optimization for VoIP a toggle and a question mark on the right")]
        public void ThenTheHeaderIsAutomaticAudioOptimizationForVoIPAToggleAndAQuestionMarkOnTheRight()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.VoipRightIcon);
            Assert.IsNotNull(_hsAudioPage.AudioAutomaticDolbyCheckBox);
        }

        [When(@"open Dolby Atmos Speaker System")]
        public void WhenOpenDolbyAtmosSpeakerSystem()
        {
            _dolbyUwpDCHAppIdSession = VantageCommonHelper.LaunchDolbyUwp();
        }

        [Then(@"open Dolby Atmos Speaker System\(Dolby audio app\), Dolby mode will automatically turn to (.*) mode")]
        public void ThenOpenDolbyAtmosSpeakerSystemDolbyAudioAppDolbyModeWillAutomaticallyTurnToMode(string dolbyMode)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            string dolbyUwpXpath = string.Empty;
            switch (dolbyMode)
            {
                case "Dynamic":
                    dolbyUwpXpath = _dolbyUwpDynamicXpath;
                    break;
                case "Movie":
                    dolbyUwpXpath = _dolbyUwpMovieXpath;
                    break;
                case "Voice":
                    dolbyUwpXpath = _dolbyUwpVoiceXpath;
                    break;
                case "Game":
                    dolbyUwpXpath = _dolbyUwpGameXpath;
                    break;
                case "Music":
                    dolbyUwpXpath = _dolbyUwpMusicXpath;
                    break;
            }
            Thread.Sleep(2000);
            var dolbyUwpElement = VantageCommonHelper.FindElementByXPath(_dolbyUwpDCHAppIdSession, dolbyUwpXpath);
            string isSelected = dolbyUwpElement.GetAttribute("SelectionItem.IsSelected");
            bool isSelectedFlag;
            bool.TryParse(isSelected.ToLower(), out isSelectedFlag);
            Assert.IsTrue(isSelectedFlag);
        }

        [Then(@"open Dolby Atmos Speaker System\(Dolby audio app\), Dolby mode will not automatically turn to Voice mode")]
        public void ThenOpenDolbyAtmosSpeakerSystemDolbyAudioAppDolbyModeWillNotAutomaticallyTurnToVoiceMode()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            var dolbyUwpElement = VantageCommonHelper.FindElementByXPath(_dolbyUwpDCHAppIdSession, _dolbyUwpVoiceXpath);
            string isSelected = dolbyUwpElement.GetAttribute("SelectionItem.IsSelected");
            bool isSelectedFlag;
            bool.TryParse(isSelected.ToLower(), out isSelectedFlag);
            Assert.IsFalse(isSelectedFlag, "Dolby mode will not automatically turn to Voice mode");
        }

        [Then(@"the UI should not change and the feature should work normally")]
        public void ThenTheUIShouldNotChangeAndTheFeatureShouldWorkNormally()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            var voipNewValue = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticVoipCheckBox);
            var entertainmentNewValue = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.EntertainmentCheckbox);
            Assert.IsTrue(_hsAudioPage.HSRadioDolbyModeDynamic.Enabled);
            Assert.IsTrue(_hsAudioPage.HSRadioDolbyModeMusic.Enabled);
            Assert.IsTrue(_hsAudioPage.HSRadioDolbyModeMovie.Enabled);
            Assert.IsTrue(_hsAudioPage.HSRadioDolbyModeGames.Enabled);
            Assert.IsTrue(_hsAudioPage.HSRadioDolbyModeVoip.Enabled);
            Assert.AreEqual(_voipOldValue, voipNewValue);
            Assert.AreEqual(_entertainmentOldValue, entertainmentNewValue);
        }

        [Then(@"Dolby mode not change")]
        public void ThenDolbyModeNotChange()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState state = _hsAudioPage.GetCurrentDynamicMode();
            Assert.AreEqual(ToggleState.On, state);
        }

        [Then(@"open Dolby Atmos Speaker System, the Dolby mode will not automatically turn to Voice mode")]
        public void ThenOpenDolbyAtmosSpeakerSystemTheDolbyModeWillNotAutomaticallyTurnToVoiceMode()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState result = _hsAudioPage.GetCurrentDolbyMode();
            if (_recordSession == null)
            {
                _recordSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.WindowsSoundRecorderAppId);
            }
            _recordSession.Quit();
            Assert.AreEqual(ToggleState.Off, result);
        }

        [Then(@"the mode only change to Voice")]
        public void ThenTheModeOnlyChangeToVoice()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (_recordSession == null)
            {
                _recordSession = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.WindowsSoundRecorderAppId);
            }
            Thread.Sleep(TimeSpan.FromSeconds(30));
            Assert.AreEqual("Voice", _hsAudioPage.ShowTextbox(_hsAudioPage.GetCurrentDolbyModeElement()));
            if (_recordSession != null)
            {
                _recordSession.Quit();
            }
        }

        [Then(@"the mode only change to Music")]
        public void ThenTheModeOnlyChangeToMusic()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            string modeName = _hsAudioPage.ShowTextbox(_hsAudioPage.GetCurrentDolbyModeElement());
            Assert.AreEqual("music", modeName.ToLower());
            if (_recordSession != null)
            {
                _recordSession.Quit();
            }
        }

        [Then(@"The UI should show completely in (.*) seconds")]
        public void ThenTheUIShouldShowCompletelyInSeconds(int p0)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState voipStae;
            Stopwatch sw = new Stopwatch();
            sw.Start();
            voipStae = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticVoipCheckBox);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMovie);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeVoip);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMusic);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeGames);
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            if (_voipStateFlag)
            {
                Assert.AreEqual(voipStae, ToggleState.On);
            }
            else
            {
                Assert.AreEqual(voipStae, ToggleState.Off);
            }
            Assert.LessOrEqual(spendTime, 2, "The UI should show completely in 2 seconds");
        }

        [When(@"click the (.*) question mark")]
        public void WhenClickTheQuestionMark(string elementName)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement windowsElement = null;
            switch (elementName)
            {
                case "voip":
                    windowsElement = _hsAudioPage.VoipRightIcon;
                    break;
                case "entertainment":
                    windowsElement = _hsAudioPage.EntertainmentRightIcon;
                    break;
            }
            bool clickFlag = _hsAudioPage.ClickElement(windowsElement);
            Assert.IsTrue(clickFlag, "click the voip question mark");
        }

        [Then(@"it will show a textbox to introduce the feature for (.*)")]
        public void ThenItWillShowATextboxToIntroduceTheFeatureFor(string elementName, string multilineText)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement windowsElement = null;
            switch (elementName)
            {
                case "voiptooltip":
                    windowsElement = _hsAudioPage.VoipRightToolTip;
                    break;
                case "entertainmenttooltip":
                    windowsElement = _hsAudioPage.EntertainmentToolTip;
                    break;
            }
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            string getActualInroc = _hsAudioPage.ShowTextbox(windowsElement);
            Assert.AreEqual(multilineText, getActualInroc);
        }

        [Given(@"turn on Automatica Entertainment Audio toggle")]
        public void GivenTurnOnAutomaticaEntertainmentAudioToggle()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.TurnElementState(_hsAudioPage.EntertainmentCheckbox, ToggleState.On);
        }

        [Given(@"supported Dolby machine")]
        public void GivenSupportedDolbyMachine()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool supportDolby = _hsAudioPage.SupportMachine();
            Assert.IsTrue(supportDolby, "This Machine Support Dolby");
        }

        [Given(@"go to Audio section")]
        [When(@"go to Audio section")]
        public void GivenGoToAudioSection()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioPage.GotoAudioPage();
            Assert.IsTrue(result);
        }

        [Given(@"go to Audio section Page")]
        public void GivenGoToAudioSectionPage()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.GoToAudioPage();
        }
        [When(@"Click (.*) Link")]
        public void GivenClickAudioSmartSettings(String type)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (type)
            {
                case "Audio Smart Settings":
                    _hsAudioPage.ClickElement(_hsAudioPage.AudioSmartSettingsJumpLink);
                    break;
                case "question mark":
                    _hsAudioPage.ClickElement(_hsAudioPage.AudioAutomaticDolbyQuesttion);
                    break;
            }
        }

        [When(@"check the UI of Automatic Dolby Audio Settings")]
        public void WhenCheckTheUIOfAutomaticDolbyAudioSettings()
        {
            Assert.IsTrue(true, "check the UI of Automatic Dolby Audio Settings");
        }

        [Then(@"the header is Automatically optimize audio for entertainment\. a checkbox in front\. a question mark on the right")]
        public void ThenTheHeaderIsAutomaticallyOptimizeAudioForEntertainment_ACheckboxInFront_AQuestionMarkOnTheRight()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.AudiosmartSettingsCollapseCardTitle);
            Assert.IsNotNull(_hsAudioPage.VoipRightIcon);
            Assert.IsNotNull(_hsAudioPage.EntertainmentRightIcon);
            Assert.IsNotNull(_hsAudioPage.AudioAutomaticDolbyCheckBox);
            Assert.IsNotNull(_hsAudioPage.EntertainmentCheckbox);
        }

        [Then(@"open Dolby Audio app and check the options\. The options in Vantage should be the same with Dolby Audio app\. support (.*) modes:Dynamic/Movie/Music/Game/Voice support (.*) modes: Movie/Music/Game/Voice")]
        public void ThenOpenDolbyAudioAppAndCheckTheOptions_TheOptionsInVantageShouldBeTheSameWithDolbyAudioApp_SupportModesDynamicMovieMusicGameVoiceSupportModesMovieMusicGameVoice(int p0, int p1)
        {
            WindowsDriver<WindowsElement> dolbyDriver = VantageCommonHelper.LaunchDolbyUwp();
            Assert.IsNotNull(dolbyDriver, "Dolby Driver is null");

            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);

            Assert.AreEqual(VantageCommonHelper.GetElementName(_hsAudioPage.HSRadioDolbyModeDynamic),
                VantageCommonHelper.GetElementName(VantageCommonHelper.FindElementByXPath(dolbyDriver, _dolbyUwpDynamicNameXpath)), "Dynamic");

            Assert.AreEqual(VantageCommonHelper.GetElementName(_hsAudioPage.HSRadioDolbyModeGames),
                VantageCommonHelper.GetElementName(VantageCommonHelper.FindElementByXPath(dolbyDriver, _dolbyUwpGameNameXpath)), "Games");

            Assert.AreEqual(VantageCommonHelper.GetElementName(_hsAudioPage.HSRadioDolbyModeMusic),
                VantageCommonHelper.GetElementName(VantageCommonHelper.FindElementByXPath(dolbyDriver, _dolbyUwpMusicNameXpath)), "Music");

            Assert.AreEqual(VantageCommonHelper.GetElementName(_hsAudioPage.HSRadioDolbyModeVoip),
                VantageCommonHelper.GetElementName(VantageCommonHelper.FindElementByXPath(dolbyDriver, _dolbyUwpVoiceNameXpath)), "Voice");

            Assert.AreEqual(VantageCommonHelper.GetElementName(_hsAudioPage.HSRadioDolbyModeMovie),
                VantageCommonHelper.GetElementName(VantageCommonHelper.FindElementByXPath(dolbyDriver, _dolbyUwpMovieNameXpath)), "Movie");

            if (dolbyDriver != null)
            {
                dolbyDriver.Quit();
            }
        }

        [Given(@"not supported Dolby machine")]
        public void GivenNotSupportedDolbyMachine()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool supportDolby = _hsAudioPage.SupportMachine();
            Assert.IsFalse(supportDolby, "This Machine Not Support Dolby");
        }

        [Then(@"no checkbox and question mark")]
        public void ThenNoCheckboxAndQuestionMark()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hsAudioPage.ClickElement(_hsAudioPage.VoipRightIcon), "no checkbox and question mark");
        }

        [Given(@"click the question mark")]
        public void GivenClickTheQuestionMark()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsAudioPage.ClickElement(_hsAudioPage.EntertainmentRightIcon), "checkbox and question mark");
        }

        [Given(@"Check the entertainment checkbox")]
        public void GivenCheckTheCheckbox()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.EntertainmentCheckbox, ToggleState.On);
            Assert.IsTrue(turnFlag, "Check the Entertainment checkbox");
        }

        [Given(@"uncheck the entertainment checkbox")]
        public void GivenUncheckTheCheckbox()
        {
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.EntertainmentCheckbox, ToggleState.Off);
            Assert.IsTrue(turnFlag, "UnCheck the Entertainment checkbox");
        }

        [When(@"Play (.*)")]
        public void WhenPlay(string mode)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.PlayMode(mode);
        }

        [Then(@"the Dolby mode should automatically switch to (.*) mode")]
        public void ThenTheDolbyModeShouldAutomaticallySwitchToMode(string mode)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement windowsElement = null;
            switch (mode)
            {
                case "music":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeMusic;
                    break;
                case "game":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeGames;
                    break;
                case "movie":
                    windowsElement = _hsAudioPage.HSRadioDolbyModeMovie;
                    break;
            }

            Thread.Sleep(5000);

            ToggleState modeFlag = _hsAudioPage.GetCheckBoxStatus(windowsElement);
            string log = string.Format("the Dolby mode should automatically switch to {0} mode", mode);
            Assert.AreEqual(ToggleState.On, modeFlag, log);
            Common.KillProcess("Battle.net", true);
        }

        [Then(@"the Dolby mode should not automatically switch mode")]
        public void ThenTheDolbyModeShouldNotAutomaticallySwitchMode()
        {

        }

        [When(@"switch pages")]
        public void WhenSwitchPages()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _currentDolbyModeName = _hsAudioPage.ShowTextbox(_hsAudioPage.GetCurrentDolbyModeElement());
            bool result = _hsAudioPage.GotoAudioPage();
            Assert.IsTrue(result);
        }

        [When(@"Get Current Dolby Mode Name")]
        public void WhenGetCurrentDolbyModeName()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _currentDolbyModeName = _hsAudioPage.ShowTextbox(_hsAudioPage.GetCurrentDolbyModeElement());
        }

        [Then(@"Dolby options not hidden")]
        public void ThenDolbyOptionsNotHidden()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMovie);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeVoip);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeMusic);
            Assert.IsNotNull(_hsAudioPage.HSRadioDolbyModeGames);
        }

        [When(@"minimize Vantage")]
        public void WhenMinimizeVantage()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            //_hsAudioPage.session.Manage().Window.Minimize();
            _webDriver.Session.Manage().Window.Minimize();
        }

        [When(@"resize Vantage")]
        public void WhenResizeVantage()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _hsAudioPage.session.Manage().Window.Size = new System.Drawing.Size(600, 800);
        }

        [Then(@"The entertainment checkbox is unchecked")]
        public void ThenTheEntertainmentCheckboxIsUnchecked()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            ToggleState entertainmentCheckbox = _hsAudioPage.GetCheckBoxStatus(_hsAudioPage.EntertainmentCheckbox);
            Assert.AreEqual(ToggleState.Off, entertainmentCheckbox);
        }

        [Given(@"Stop Dolby Driver")]
        public void GivenStopDolbyDriver()
        {
            try
            {
                Common.KillProcess("Music.UI", true);
                Common.KillProcess("Video.UI", true);
                Common.KillProcess("Battle.net", true);
                _recordSession?.Quit();
                _dolbyUwpDCHAppIdSession?.Quit();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        [Then(@"the title is Automatic Dolby Audio Settings there is a toggle off by default there is a question mark beside the toggle")]
        public void ThenTheTitleIsAutomaticDolbyAudioSettingsThereIsAToggleOffByDefaultThereIsAQuestionMarkBesideTheToggle()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            _nerveCenterPages = new NerveCenterPages(_webDriver.Session);
            Assert.IsNotNull(_nerveCenterPages.DoblyAudioText);
            bool turnFlag = _hsAudioPage.TurnElementState(_hsAudioPage.AudioAutomaticDolbyCheckBox, ToggleState.Off);
            Assert.IsTrue(turnFlag, "GivenDolbyAudioIsO");
            Assert.IsNotNull(_hsAudioPage.AudioAutomaticDolbyQuesttion, "AudioAutomaticDolbyQuesttion is null");
        }

        [Then(@"Check question mark text")]
        public void ThenCheckQuestionMarkText()
        {
            Assert.IsNotNull(_hsAudioPage.AudioAutomaticDolbyQuesttiontext, "Intelligent screen' Is Not Found");
            Assert.IsTrue(_hsAudioPage.ShowTextbox(_hsAudioPage.AudioAutomaticDolbyQuesttiontext).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.MyDeviceSettings.AudioPage.AudioAutomaticDolbyQuesttiontexts").ToString()));
        }

        [Then(@"Check Automatic Audio Optimization For VoIP Elements")]
        public void ThenCheckAutomaticAudioOptimizationForVoIPElements()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.AutomaticAudioOptimizationForVoIPTitle, "Element 'Automatic Audio Optimization For VoIP Title' Is Not Found");
            Assert.IsNotNull(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle, "Element 'Automatic Audio Optimization For VoIP Toggle' Is Not Found");
            Assert.IsNotNull(_hsAudioPage.AutomaticAudioOptimizationForVoIPQuestionMark, "Element 'Automatic Audio Optimization For VoIP QuestionMark' Is Not Found");
        }

        [Then(@"Check Automatic Audio Optimization For VoIP Toggle is '(.*)'")]
        public void ThenEasyResumeStatusIs(string status)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (status.ToLower().Equals("on"))
            {
                Assert.AreEqual(_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle), ToggleState.On);
            }
            if (status.ToLower().Equals("off"))
            {
                Assert.AreEqual(_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle), ToggleState.Off);
            }
        }

        [When(@"Click Automatic Audio Optimization For VoIP QuestionMark")]
        public void WhenClickAutomaticAudioOptimizationForVoIPQuestionMark()
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.AutomaticAudioOptimizationForVoIPQuestionMark, "Element 'Automatic Audio Optimization For VoIP QuestionMark' Is Not Found");
            _hsAudioPage.AutomaticAudioOptimizationForVoIPQuestionMark.Click();
        }

        [Then(@"Check Question Mark Tip DisPlay '(.*)'")]
        public void ThenCheckQuestionMarkTipDisPlay(string jsonPath)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsAudioPage.AutomaticAudioOptimizationForVoIPTip, "Element 'Automatic Audio Optimization For VoIP Tip' Is Not Found");
            Assert.IsTrue(_hsAudioPage.ShowTextbox(_hsAudioPage.AutomaticAudioOptimizationForVoIPTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }

        [Given(@"Turn (.*) Automatic Audio Optimization For VoIP Toggle")]
        public void GivenAutomaticAudioOptimizationForVoIPToggle(string status)
        {
            _hsAudioPage = new HSAudioSettingsPage(_webDriver.Session);
            if (status.ToLower().Equals("on"))
            {
                if (_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle) == ToggleState.Off)
                {
                    _hsAudioPage.AutomaticAudioOptimizationForVoIPToggle.Click();
                }
                Assert.AreEqual(_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle), ToggleState.On);
            }
            if (status.ToLower().Equals("off"))
            {
                if (_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle) == ToggleState.On)
                {
                    _hsAudioPage.AutomaticAudioOptimizationForVoIPToggle.Click();
                }
                Assert.AreEqual(_hsAudioPage.GetCheckBoxStatus(_hsAudioPage.AutomaticAudioOptimizationForVoIPToggle), ToggleState.Off);
            }
        }

        [Then(@"no toggle and question mark")]
        public void ThenNoToggleAndQuestionMark()
        {
            Assert.IsNull(_hsAudioPage.AudioAutomaticDolbyCheckBox, "AudioAutomaticDolbyCheckBox is not null");
            Assert.IsNull(_hsAudioPage.AudioAutomaticDolbyQuesttion, "AudioAutomaticDolbyQuesttion is not null");
        }

    }
}
