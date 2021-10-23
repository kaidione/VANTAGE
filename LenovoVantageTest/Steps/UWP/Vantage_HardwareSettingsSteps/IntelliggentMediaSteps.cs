using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class IntelliggentMediaSteps
    {
        private HSHPDPage _hsHPDPage;
        private HSAudioSettingsPage _hsAudioSettingsPage;
        private readonly InformationalWebDriver _webDriver;
        public IntelliggentMediaSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Jump to Intelligent Media section")]
        [When(@"Jump to Intelligent Media section")]
        public void GivenJumpToIntelligentMediaSection()
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.NotNull(_hsHPDPage.IntelligentMediaJumpLink, "The Intelligent Media jump link not found!");
            _hsHPDPage.IntelligentMediaJumpLink.Click();
        }

        [When(@"Minimize vantage HSHPD page")]
        public void WhenMinimizeVantageHSHPDPage()
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            _hsHPDPage.VantageMinizeElement.Click();
            Thread.Sleep(10000);
            _webDriver.Session.Manage()?.Window?.Maximize();
        }

        [Then(@"the video resolution upscaling is below Zero touch video playback")]
        public void ThenTheVideoResolutionUpscalingIsBelowZeroTouchVideoPlayback()
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.NotNull(_hsHPDPage.ZeroTouchVideoPlaybackTitle, "The Zero Touch Video Playback not found");
            Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingTitle, "The Video Resolution Upscaling not found");
            Assert.Less(_hsHPDPage.ZeroTouchVideoPlaybackTitle.Location.Y, _hsHPDPage.VideoResolutionUpscalingTitle.Location.Y, "The video resolution upscaling show position incorrect");
        }

        [Then(@"the video resolution upscaling text is correct")]
        public void ThenTheVideoResolutionUpscalingTextIsCorrect(Table table)
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "title":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingTitle, "The Video Resolution Upscaling title not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingTitle.Text, "The Video Resolution Upscaling title text incorrect");
                        break;
                    case "desc1":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingDescOne, "The Video Resolution Upscaling desc one not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingDescOne.Text, "The Video Resolution Upscaling desc one text incorrect");
                        break;
                    case "desc2":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingDescTwo, "The Video Resolution Upscaling desc two not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingDescTwo.Text, "The Video Resolution Upscaling desc two text incorrect");
                        break;
                    case "notedesc":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingNote, "The Video Resolution Upscaling note not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingNote.Text, "The Video Resolution Upscaling note desc text incorrect");
                        break;
                    case "notedesc1":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingNoteDescOne, "The Video Resolution Upscaling note desc one not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingNoteDescOne.Text, "The Video Resolution Upscaling note desc one text incorrect");
                        break;
                    case "notedesc2":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingNoteDescTwo, "The Video Resolution Upscaling note desc two not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingNoteDescTwo.Text, "The Video Resolution Upscaling note desc two text incorrect");
                        break;
                    case "notedesc3":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingNoteDescThree, "The Video Resolution Upscaling note desc one not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingNoteDescThree.Text, "The Video Resolution Upscaling note desc three text incorrect");
                        break;
                    case "notedesc4":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingNoteDescFour, "The Video Resolution Upscaling note desc two not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingNoteDescFour.Text, "The Video Resolution Upscaling note desc four text incorrect");
                        break;
                    case "tooltips1":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToolTips, "The Video Resolution Upscaling tool tips not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingToolTipsText[0].Text, "The Video Resolution Upscaling tool tips desc one text incorrect");
                        break;
                    case "tooltips2":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToolTips, "The Video Resolution Upscaling tool tips not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingToolTipsText[1].Text, "The Video Resolution Upscaling tool tips desc teo text incorrect");
                        break;
                    case "tooltipsnew":
                        Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToolTips, "The Video Resolution Upscaling tool tips not found");
                        Assert.AreEqual(table.Rows[i][1], _hsHPDPage.VideoResolutionUpscalingToolTips.Text, "The Video Resolution Upscaling tool tips desc one text incorrect");
                        break;
                    default:
                        Assert.Fail("the ThenTheVideoResolutionUpscalingTextIsCorerect() not run,the paramter incorrect。" + table.Rows[i][0]);
                        break;
                }
            }
        }

        [When(@"user click question mark within video resolution upscaling")]
        public void WhenUserClickQuestionMarkWithinVideoResolutionUpscaling()
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingQuestionIcon, "The Video Resolution Upscaling Question Icon not found");
            _hsHPDPage.VideoResolutionUpscalingQuestionIcon.Click();
            Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToolTips, "WhenUserClickQuestionMarkWithinVideoResolutionUpscaling() option fail!");
        }

        [When(@"Turn on or off video resolution upscaling toggle '(.*)'")]
        public void WhenTurnOnOrOffVideoResolutionUpscalingToggle(string status)
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToggle, "the Video Resolution Upscaling Toggle not found!");
            var element = _hsHPDPage.VideoResolutionUpscalingToggle;
            switch (status)
            {
                case "on":
                    if (ToggleState.On != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                    {
                        element.Click();
                    }
                    Thread.Sleep(2000);
                    Assert.AreEqual(ToggleState.On, _hsAudioSettingsPage.GetCheckBoxStatus(element), "Turn on Video Resolution Upscaling toggle fail.");
                    break;
                case "off":
                    if (ToggleState.Off != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                    {
                        element.Click();
                    }
                    Thread.Sleep(2000);
                    Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(element), "Turn off Video Resolution Upscaling toggle fail.");
                    break;
                default:
                    Assert.Fail("WhenTurnOnOrOffVideoResolutionUpscalingToggle() not run!");
                    break;
            }
        }

        [Then(@"The video resolution upscaling toggle status is on or off '(.*)'")]
        public void ThenTheVideoResolutionUpscalingToggleStatusIsOnOrOff(string status)
        {
            _hsHPDPage = new HSHPDPage(_webDriver.Session);
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsHPDPage.VideoResolutionUpscalingToggle, "the Video Resolution Upscaling Toggle not found!");
            var element = _hsHPDPage.VideoResolutionUpscalingToggle;
            switch (status)
            {
                case "on":
                    Assert.AreEqual(ToggleState.On, _hsAudioSettingsPage.GetCheckBoxStatus(element), "the Video Resolution Upscaling toggle status incorrect");
                    break;
                case "off":
                    Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(element), "Turn off Video Resolution Upscaling toggle status incorrect.");
                    break;
                default:
                    Assert.Fail("WhenTurnOnOrOffVideoResolutionUpscalingToggle() not run!");
                    break;
            }
        }

        [Given(@"Open the test video and task manager")]
        public void VerifyTheSRTakeEffectOrNot()
        {
            //should make sure the video is exist and the name is correct and in the right place.
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\testvideo.mp4");
            ProcessStartInfo startInfo = new ProcessStartInfo(@path);
            startInfo.WindowStyle = ProcessWindowStyle.Maximized;
            Process.Start(startInfo);
            UnManagedAPI.ShowWindow(UnManagedAPI.GetForegroundWindow(), UnManagedAPI.SW_SHOWMAXIMIZED);
            Thread.Sleep(3000);
            ProcessStartInfo startInfotask = new ProcessStartInfo(@"C:\WINDOWS\system32\taskmgr.exe");
            Process.Start(startInfotask);
            Thread.Sleep(20000);
        }

        [Given(@"close task manager")]
        public void GivenCloseTaskManager()
        {
            CommandBase.RunCmd("taskkill /f /t /im Taskmgr.exe");
        }

        [Given(@"close the test video")]
        public void GivenCloseTheTestVideo()
        {
            CommandBase.RunCmd("taskkill /f /t /im wmplayer.exe");
        }

    }
}
