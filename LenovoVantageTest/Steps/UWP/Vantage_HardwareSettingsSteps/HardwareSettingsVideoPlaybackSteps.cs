using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using System;
using System.Windows.Automation;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class HardwareSettingsVideoPlaybackSteps : SettingsBase
    {
        private HSHPDPage hsHPDPage;
        private InformationalWebDriver webDriver;
        private String HPDParentRegedit = @"SYSTEM\CurrentControlSet\Services\SmartSense\Parameters";

        public HardwareSettingsVideoPlaybackSteps(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
            hsHPDPage = new HSHPDPage(webDriver.Session);
        }

        [When(@"Smart Assist page shows Video Playback Toggle")]
        public void WhenSmartAssistPageShowsVideoPlaybackToggle()
        {
            Assert.IsNotNull(hsHPDPage.VideoPalybackToggle, "Video Playback toggle is not displayed in Smart Assist Page, please check the UI");
        }

        [Then(@"The Video Playback Toggle default value is ""(.*)""")]
        public void ThenTheVideoPlaybackToggleDefaultValueIs(string Status)
        {
            switch (Status.ToLower().Trim())
            {
                case "on":
                    Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle), "The default value of VideoPlayback toggle is not on");
                    break;
                case "off":
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle), "The default value of VideoPlayback toggle is not off");
                    break;
                default:
                    Assert.Fail("ThenTheVideoPlaybackToggleDefaultValueIs() no run,info:" + Status);
                    break;
            }
            return;
        }

        [Then(@"The video playback UI is following UISPEC")]
        public void ThenTheVideoPlaybackUIIsFollowingUISPEC(Table table)
        {
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0].Trim())
                {
                    case "title":
                        Assert.NotNull(hsHPDPage.VideoPlaybackTitle, "The Video Playback title not found");
                        Assert.AreEqual(table.Rows[i][1], hsHPDPage.VideoPlaybackTitle.Text, "The Video Playback title text incorrect");
                        break;
                    case "description":
                        Assert.NotNull(hsHPDPage.VideoPlaybackDescription, "The Video playback desc not found");
                        Assert.AreEqual(table.Rows[i][1], hsHPDPage.VideoPlaybackDescription.Text, "The Video Playback desc text incorrect");
                        break;
                    case "list":
                        Assert.NotNull(hsHPDPage.VideoPlaybackSupportList, "The Video playback supportlist not found");
                        Assert.AreEqual(table.Rows[i][1], hsHPDPage.VideoPlaybackSupportList.Text, "The Video Playback supportlist text incorrect");
                        break;
                    case "note":
                        Assert.NotNull(hsHPDPage.VideoPlaybackNote, "The Video playback note not found");
                        Assert.AreEqual(table.Rows[i][1], hsHPDPage.VideoPlaybackNote.Text, "The Video Playback note text incorrect");
                        break;
                    default:
                        Assert.Fail("the ThenTheVideoResolutionUpscalingTextIsCorerect() not run,the paramter incorrect。" + table.Rows[i][0]);
                        break;
                }
            }
        }

        [When(@"Turn ""(.*)"" the Video Playback Toggle")]
        public void WhenTurnTheVideoPlaybackToggle(string Status)
        {
            ToggleState tarToggle = GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle);
            switch (Status.ToLower().Trim())
            {
                case "on":
                    UnSelectElement(hsHPDPage.VideoPalybackToggle, tarToggle);
                    SelectElement(hsHPDPage.VideoPalybackToggle, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle));
                    Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle), "The VideoPlayback toggle value is not on");
                    break;
                case "off":
                    SelectElement(hsHPDPage.VideoPalybackToggle, tarToggle);
                    UnSelectElement(hsHPDPage.VideoPalybackToggle, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle));
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(hsHPDPage.VideoPalybackToggle), "The VideoPlayback toggle value is not off");
                    break;
                default:
                    Assert.Fail("WhenTurnTheVideoPlaybackToggle() no run,info:" + Status);
                    break;
            }
            return;
        }


        [Given(@"Delect the related HPD Regedit Value")]
        public void GivenDelectTheRelatedHPDRegeditValue()
        {
            try
            {
                RegistryKey localMachineRegidtry = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32);
                RegistryKey reg = localMachineRegidtry?.OpenSubKey(HPDParentRegedit, true);
                foreach (string HPDValue in reg.GetSubKeyNames())
                {
                    if (HPDValue.Equals("HPD"))
                    {
                        reg.DeleteSubKeyTree(HPDValue);
                    }
                }
            }
            catch
            {
                Assert.Fail("Cannot delect the related key or open the regedit error");
            }
        }
    }
}
