using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class ECourseForDolbySteps : SettingsBase
    {
        private HSAudioSettingsPage _hsAudioSettingsPage;
        private readonly InformationalWebDriver _webDriver;
        private string _dolbyProcess = "DAXUIDolbyAudio";
        private ToggleState AudioAutomaticDolbyCheckBoxState = ToggleState.Indeterminate;
        private ToggleState EntertainmentCheckboxState = ToggleState.Indeterminate;
        private ToggleState ECourseCheckboxState = ToggleState.Indeterminate;
        private ToggleState AutomaticVoipCheckBoxState = ToggleState.Indeterminate;

        public ECourseForDolbySteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"go to Audio page")]
        [When(@"go to Audio page")]
        public void GivenGoToAudioPage()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            bool result = _hsAudioSettingsPage.GotoAudioPage();
            Assert.IsTrue(result, "GivenGoToAudioPage() fail");
        }

        [Given(@"Jump to audio smart settings section")]
        public void GivenJumpToAudioSmartSettingsSection()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.AudioSmartSettingsJumpLink, "The AudioSmartSettingsJumpLink not found");
            _hsAudioSettingsPage.AudioSmartSettingsJumpLink.Click();
        }

        [Then(@"ECourse can show or hide '(.*)'")]
        public void ThenECourseCanShowOrHide(string status)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(_hsAudioSettingsPage.ECourseCheckbox, "The ECourseCheckbox not show");
                    Assert.IsNotNull(_hsAudioSettingsPage.ECourseTitle, "The ECourseTitle not show");
                    Assert.IsNotNull(_hsAudioSettingsPage.ECourseDescription, "The ECourse Description not show");
                    Assert.AreEqual("Interactive E-course mode", _hsAudioSettingsPage.ECourseTitle.GetAttribute("Name"));
                    break;
                case "hide":
                    Assert.IsNull(_hsAudioSettingsPage.ECourseCheckbox, "The ECourseCheckbox still show");
                    Assert.IsNull(_hsAudioSettingsPage.ECourseTitle, "The ECourseTitle still show");
                    Assert.IsNull(_hsAudioSettingsPage.ECourseDescription, "The ECourse Description still show");
                    break;
                default:
                    Assert.Fail("ThenECourseCanShowOrHide not found");
                    break;
            }
        }

        [Then(@"The UI of Dolby Audio and eCourse mode for first time launch Vantage")]
        public void ThenTheUIOfDolbyAudioAndECourseModeForFirstTimeLaunchVantage()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(ToggleState.On, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AudioAutomaticDolbyCheckBox), "The Dolby audio toggle status incorrect.");
            Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.EntertainmentCheckbox), "The Automatically optimize audio for entertainment checkbox status incorrect.");
            Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.ECourseCheckbox), "The e-Course mode toggle status incorrect.");
        }

        [Then(@"The Audio Smart settings description should be correct")]
        public void ThenTheAudioSmartSettingsDescriptionShouldBeCorrect(Table table)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "E-Course":
                        Assert.NotNull(_hsAudioSettingsPage.ECourseDescription, "The ECourse Description not show");
                        Assert.AreEqual(table.Rows[i][1], _hsAudioSettingsPage.ECourseDescription.GetAttribute("Name"), "The E-Course Description incorrect. by Name");
                        Assert.AreEqual(table.Rows[i][1], _hsAudioSettingsPage.ECourseDescription.Text, "The E-Course Description incorrect. by Text");
                        break;
                    case "Dolby audio":
                        Assert.NotNull(_hsAudioSettingsPage.HSDolbyDescription, "The Dolby audio Description not show");
                        Assert.AreEqual(table.Rows[i][1], _hsAudioSettingsPage.HSDolbyDescription.Text, "The Dolby audio Description incorrect");
                        break;
                    default:
                        Assert.Fail("ThenTheAudioSmartSettingsDescriptionShouldBeCorrect() no run.");
                        break;
                }
            }
        }

        [Then(@"The UI display position of eCourse mode")]
        public void ThenTheUIDisplayPositionOfECourseMode()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsAudioSettingsPage.HSDolbyAudioSection, "The HSDolbyAudioSection not found");
            Assert.NotNull(_hsAudioSettingsPage.ECourseSection, "The ECourseSection not found");
            Assert.NotNull(_hsAudioSettingsPage.ECourseTitle, "The ECourseTitle not found");
            Assert.NotNull(_hsAudioSettingsPage.ECourseCheckbox, "The ECourseCheckbox not found");
            Assert.IsTrue(_hsAudioSettingsPage.HSDolbyAudioSection.Location.Y < _hsAudioSettingsPage.ECourseSection.Location.Y, "The ECourse Section show incorrect");
            Assert.IsTrue(_hsAudioSettingsPage.ECourseTitle.Location.X < _hsAudioSettingsPage.ECourseCheckbox.Location.X, "The ECourse toggle show incorrect");
            //Assert.IsTrue(_hsAudioSettingsPage.ECourseTitle.Location.X < _hsAudioSettingsPage.ECourseCheckbox.Location.X, "The ECourse toggle show incorrect");
        }

        [Given(@"Resize the window")]
        public void GivenResizeTheWindow(Table table)
        {
            Size size = new Size(int.Parse(table.Rows[0][1]), int.Parse(table.Rows[0][2]));
            if (table.Rows[0][0] == "yes")
            {
                _webDriver.Session.Manage().Window.Size = size;
                Console.WriteLine("Info: GivenResizeTheWindow() by session");
            }
            else
            {
                string classname = table.Rows[0][3];
                string windowsname = table.Rows[0][4];
                IntPtr intPtr = IntPtr.Zero;
                if (!string.IsNullOrEmpty(classname) && !string.IsNullOrEmpty(windowsname))
                {
                    intPtr = UnManagedAPI.FindWindow(classname, windowsname);
                }
                else if (string.IsNullOrEmpty(classname) && !string.IsNullOrEmpty(windowsname))
                {
                    intPtr = UnManagedAPI.FindWindowByCaption(IntPtr.Zero, windowsname);
                }
                else
                {
                    intPtr = UnManagedAPI.GetForegroundWindow();
                }
                if (intPtr == IntPtr.Zero)
                {
                    Assert.Fail("Error: not found window, class name is" + classname + ",windows name is" + windowsname);
                }
                UnManagedAPI.SetWindowPos(intPtr, 0, 0, 0, size.Width, size.Height, 0x46);
                Console.WriteLine("Info: GivenResizeTheWindow() by windows api");
            }
            Thread.Sleep(2000);
        }

        [When(@"Turn on or off the master toggle within Audio smart settings")]
        [Given(@"Turn on or off the master toggle within Audio smart settings")]
        public void GivenTurnOnOrOffTheMasterToggleWithinAudioSmartSettings(Table table)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement element = null;
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "Dolby audio":
                        element = _hsAudioSettingsPage.AudioAutomaticDolbyCheckBox;
                        break;
                    case "Dynamic":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeDynamic;
                        break;
                    case "Movie":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeMovie;
                        break;
                    case "Music":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeMusic;
                        break;
                    case "Game":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeGames;
                        break;
                    case "Voice":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeVoip;
                        break;
                    case "Automatic Voip":
                        element = _hsAudioSettingsPage.AutomaticVoipCheckBox;
                        break;
                    case "Automatic Entertainment":
                        element = _hsAudioSettingsPage.EntertainmentCheckbox;
                        break;
                    case "E-Course":
                        element = _hsAudioSettingsPage.ECourseCheckbox;
                        break;
                    case "Multiple voices":
                        element = _hsAudioSettingsPage.MicroPhoneMultipleVoices;
                        break;
                    case "Only my voice":
                        element = _hsAudioSettingsPage.MicroPhoneOnlyMyVoice;
                        break;
                    case "Normal":
                        element = _hsAudioSettingsPage.MicroPhoneNormal;
                        break;
                    case "Voice recognition":
                        element = _hsAudioSettingsPage.MicroPhoneVoiceRecognition;
                        break;
                    case "Suppress Keyboard Noise":
                        element = _hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle;
                        break;
                    case "Acoustic Echo Cancellation":
                        element = _hsAudioSettingsPage.AcousticEchoCancellationToggle;
                        break;
                    default:
                        Assert.Fail("WhenTurnOnOrOffTheMasterToggle() not run, the toggle name parameter incorrect");
                        break;
                }
                Assert.NotNull(element, "WhenTurnOnOrOffTheMasterToggle() The toggle not found," + table.Rows[i][0]);
                switch (table.Rows[i][1])
                {
                    case "on":
                        if (ToggleState.On != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                        {
                            element.Click();
                        }
                        Thread.Sleep(1000);
                        if (ToggleState.On != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                        {
                            _webDriver.Session.Mouse.Click(element.Coordinates);
                        }
                        Thread.Sleep(1000);
                        Assert.AreEqual(ToggleState.On, _hsAudioSettingsPage.GetCheckBoxStatus(element), "Turn on toggle fail." + table.Rows[i][0]);
                        break;
                    case "off":
                        if (ToggleState.Off != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                        {
                            element.Click();
                        }
                        Thread.Sleep(1000);
                        if (ToggleState.Off != _hsAudioSettingsPage.GetCheckBoxStatus(element))
                        {
                            _webDriver.Session.Mouse.Click(element.Coordinates);
                        }
                        Thread.Sleep(1000);
                        Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(element), "Turn off toggle fail." + table.Rows[i][0]);
                        break;
                    default:
                        Assert.Fail("WhenTurnOnOrOffTheMasterToggle() not run, the toggle status parameter incorrect");
                        break;
                }
            }
        }

        [Then(@"only keep the description of Dolby Audio other elements of Dolby Audio will hide or show '(.*)'")]
        public void ThenOnlyKeepTheDescriptionOfDolbyAudioOtherElementsOfDolbyAudioWillHideOrShow(string status)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            switch (status)
            {
                case "show":
                    Assert.IsNotNull(_hsAudioSettingsPage.HSRadioDolbyModeMovie, "HSRadioDolbyModeMovie is not find");
                    Assert.IsNotNull(_hsAudioSettingsPage.HSRadioDolbyModeVoip, "HSRadioDolbyModeVoip is not find");
                    Assert.IsNotNull(_hsAudioSettingsPage.HSRadioDolbyModeMusic, "HSRadioDolbyModeMusic is not find");
                    Assert.IsNotNull(_hsAudioSettingsPage.HSRadioDolbyModeGames, "HSRadioDolbyModeGames is not find");
                    Assert.NotNull(_hsAudioSettingsPage.AutomaticVoipCheckBox, "The Automatically optimize audio for VoIP checkbox not show");
                    Assert.IsNotNull(_hsAudioSettingsPage.EntertainmentCheckbox, "The Automatically optimize audio for entertainment checkbox not show");
                    break;
                case "hide":
                    Assert.IsNull(_hsAudioSettingsPage.HSRadioDolbyModeMovie, "HSRadioDolbyModeMovie is find");
                    Assert.IsNull(_hsAudioSettingsPage.HSRadioDolbyModeVoip, "HSRadioDolbyModeVoip is find");
                    Assert.IsNull(_hsAudioSettingsPage.HSRadioDolbyModeMusic, "HSRadioDolbyModeMusic is find");
                    Assert.IsNull(_hsAudioSettingsPage.HSRadioDolbyModeGames, "HSRadioDolbyModeGames is find");
                    Assert.Null(_hsAudioSettingsPage.AutomaticVoipCheckBox, "The Automatically optimize audio for VoIP checkbox still show");
                    Assert.IsNull(_hsAudioSettingsPage.EntertainmentCheckbox, "The Automatically optimize audio for entertainment checkbox still show");
                    break;
                default:
                    Assert.Fail("ThenOnlyKeepTheDescriptionOfDolbyAudioOtherElementsOfDolbyAudioWillHideOrShow not run");
                    break;
            }
            Assert.NotNull(_hsAudioSettingsPage.HSDolbyDescription, "The Dolby audio desc not show");
        }

        [Then(@"the master toggle is on or off or enable or disable within Audio smart settings")]
        public void ThenTheMasterToggleIsOnOrOffOrEnableOrDisableWithinAudioSmartSettings(Table table)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement element = null;
            for (int i = 0; i < table.RowCount; i++)
            {
                switch (table.Rows[i][0])
                {
                    case "Dolby audio":
                        element = _hsAudioSettingsPage.AudioAutomaticDolbyCheckBox;
                        break;
                    case "Dynamic":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeDynamic;
                        break;
                    case "Movie":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeMovie;
                        break;
                    case "Music":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeMusic;
                        break;
                    case "Game":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeGames;
                        break;
                    case "Voice":
                        element = _hsAudioSettingsPage.HSRadioDolbyModeVoip;
                        break;
                    case "Automatic Voip":
                        element = _hsAudioSettingsPage.AutomaticVoipCheckBox;
                        break;
                    case "Automatic Entertainment":
                        element = _hsAudioSettingsPage.EntertainmentCheckbox;
                        break;
                    case "E-Course":
                        element = _hsAudioSettingsPage.ECourseCheckbox;
                        break;
                    case "Multiple voices":
                        element = _hsAudioSettingsPage.MicroPhoneMultipleVoices;
                        break;
                    case "Only my voice":
                        element = _hsAudioSettingsPage.MicroPhoneOnlyMyVoice;
                        break;
                    case "Normal":
                        element = _hsAudioSettingsPage.MicroPhoneNormal;
                        break;
                    case "Voice recognition":
                        element = _hsAudioSettingsPage.MicroPhoneVoiceRecognition;
                        break;
                    case "Suppress Keyboard Noise":
                        element = _hsAudioSettingsPage.KeystrokeSuppressionCheckBoxEle;
                        break;
                    case "Acoustic Echo Cancellation":
                        element = _hsAudioSettingsPage.AcousticEchoCancellationToggle;
                        break;
                    default:
                        Assert.Fail("ThenTheMasterToggleIsOnOrOffOrEnableOrDisable() not run, the toggle name parameter incorrect");
                        break;
                }
                Assert.NotNull(element, "ThenTheMasterToggleIsOnOrOffOrEnableOrDisable() The toggle not found," + table.Rows[i][0]);
                Thread.Sleep(2000);
                switch (table.Rows[i][1])
                {
                    case "on":
                        Assert.AreEqual(ToggleState.On, _hsAudioSettingsPage.GetCheckBoxStatus(element), "toggle status incorrect." + table.Rows[i][0]);
                        break;
                    case "off":
                        Assert.AreEqual(ToggleState.Off, _hsAudioSettingsPage.GetCheckBoxStatus(element), "toggle status incorrect." + table.Rows[i][0]);
                        break;
                    case "enable":
                        Assert.IsTrue(element.Enabled, "toggle status incorrect." + table.Rows[i][0]);
                        break;
                    case "disable":
                        Assert.IsFalse(element.Enabled, "toggle status incorrect." + table.Rows[i][0]);
                        break;
                    default:
                        Assert.Fail("ThenTheMasterToggleIsOnOrOffOrEnableOrDisable() not run, the toggle status parameter incorrect");
                        break;
                }
            }
        }

        [When(@"check the ECourse Feature on the supported system")]
        [Given(@"check the ECourse Feature on the supported system")]
        public void WhenCheckTheECourseFeatureOnTheSupportedSystem()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsAudioSettingsPage.SupportECourseMode(), "The system does not support E-Course");
        }

        [When(@"check the ECourse Feature on the not supported system")]
        [Given(@"check the ECourse Feature on the not supported system")]
        public void WhenCheckTheECourseFeatureOnTheNotSupportedSystem()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hsAudioSettingsPage.SupportECourseMode(), "The system supports E-Course");
        }

        [When(@"Turn on or off the Dolby Audio button within Dolby Audio app '(.*)'")]
        public void WhenTurnOnOrOffTheDolbyAudioButtonWithinDolbyAudioApp(string status)
        {
            WindowsDriver<WindowsElement> dolbysession = VantageCommonHelper.LaunchDolbyUwp();
            dolbysession.Manage().Window.Maximize();
            Thread.Sleep(3000);
            IntelligentCoolingBaseHelper helper = new IntelligentCoolingBaseHelper();
            string toggle = "//*[@AutomationId='IDS_MENU_POWER']";
            WindowsElement element = dolbysession.FindElementByXPath(toggle);
            Assert.NotNull(element, "the dolby app power btn not null");
            switch (status)
            {
                case "on":
                    if (status != helper.GetAttributesByPageSource(null, "ToggleState", dolbysession, toggle).ToLower())
                    {
                        element.Click();
                    }
                    Thread.Sleep(2000);
                    Assert.IsTrue(status == helper.GetAttributesByPageSource(null, "ToggleState", dolbysession, toggle).ToLower(), "Turn on toggle fail.");
                    break;
                case "off":
                    if (status != helper.GetAttributesByPageSource(null, "ToggleState", dolbysession, toggle).ToLower())
                    {
                        element.Click();
                    }
                    Thread.Sleep(2000);
                    Assert.IsTrue(status == helper.GetAttributesByPageSource(null, "ToggleState", dolbysession, toggle).ToLower(), "Turn off toggle fail.");
                    break;
                default:
                    Assert.Fail("WhenTurnOnOrOffTheDolbyAudioApp() not run");
                    break;
            }
            Common.KillProcess(_dolbyProcess, true);
            Assert.Zero(Process.GetProcessesByName(_dolbyProcess).Length, "The stop dolby app fail.");
        }

        [When(@"Select one mode within Dolby Audio app '(.*)'")]
        public void WhenSelectOneModeWithinDolbyAudioApp(string modes)
        {
            WindowsDriver<WindowsElement> dolbysession = VantageCommonHelper.LaunchDolbyUwp();
            dolbysession.Manage().Window.Maximize();
            Thread.Sleep(3000);
            string modexpath = string.Empty;
            switch (modes)
            {
                case "Dynamic":
                    modexpath = "//*[@AutomationId='ID_DYNAMIC']";
                    break;
                case "Movie":
                    modexpath = "//*[@AutomationId='ID_MOVIE']";
                    break;
                case "Voice":
                    modexpath = "//*[@AutomationId='ID_VOICE']";
                    break;
                case "Game":
                    modexpath = "//*[@AutomationId='ID_GAME']";
                    break;
                case "Music":
                    modexpath = "//*[@AutomationId='ID_MUSIC']";
                    break;
                default:
                    Assert.Fail("WhenSelectOneModeWithinDolbyAudioApp() parameter incorrect." + modes);
                    break;
            }
            WindowsElement element = dolbysession.FindElementByXPath(modexpath);
            Assert.NotNull(element, "the dolby app modes not found");
            if (!element.Selected)
            {
                element.Click();
            }
            Thread.Sleep(2000);
            Assert.IsTrue(element.Selected, "select mode within dolby app fail.modes:" + modes);
            Common.KillProcess(_dolbyProcess, true);
            Assert.Zero(Process.GetProcessesByName(_dolbyProcess).Length, "The stop dolby app fail.");
        }

        [Then(@"the ECourse toggle status is on or off within toolbar '(.*)'")]
        public void ThenTheECourseToggleStatusIsOnOrOffWithinToolbar(string status)
        {
            try
            {
                switch (status)
                {
                    case "on":
                        Assert.AreEqual(ToggleState.On, GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()), "the e-course toggle status incorrect within toolbar");
                        break;
                    case "off":
                        Assert.AreEqual(ToggleState.Off, GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()), "the e-course toggle status incorrect within toolbar");
                        break;
                    default:
                        Assert.Fail("ThenTheECourseToggleStatusIsOnOrOffWithinToolbar() not run");
                        break;
                }
            }
            catch (Exception ex)
            {
                GivenTurnOnOrOffTheNarrator("off");
                Assert.Fail("ThenTheECourseToggleStatusIsOnOrOffWithinToolbar() Exception Info:" + ex.ToString());
            }
        }

        [Then(@"E-course mode button displays same as with Vantage")]
        public void ThenE_CourseModeButtonDisplaysSameAsWithVantage()
        {
            ToggleState status = GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString());
            GivenGoToAudioPage();
            GivenJumpToAudioSmartSettingsSection();
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement element = _hsAudioSettingsPage.ECourseCheckbox;
            Assert.AreEqual(status, _hsAudioSettingsPage.GetCheckBoxStatus(element), "E-course mode button displays not same as with Vantage");
        }

        [When(@"Turn on or off the ECourse toggle within toolbar '(.*)'")]
        public void WhenTurnOnOrOffTheECourseToggleWithinToolbar(string status)
        {
            switch (status)
            {
                case "on":
                    if (GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()) != ToggleState.On)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString());
                    }
                    Assert.AreEqual(GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()), ToggleState.On, "Turn on e-course toggle fail within toolbar");
                    break;
                case "off":
                    if (GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()) != ToggleState.Off)
                    {
                        VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString());
                    }
                    Assert.AreEqual(GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString()), ToggleState.Off, "Turn off e-course toggle fail within toolbar");
                    break;
                default:
                    Assert.Fail("WhenTurnOnOrOffTheE_CourseToggleWithinToolbar() not run");
                    break;
            }
        }

        [Then(@"The '(.*)' function shown or hidden '(.*)' within toolbar")]
        public void ThenTheFunctionShownOrHiddenWithinToolbar(string func, string status)
        {
            AutomationElement element = null;
            bool isShow = status == "shown" ? true : false;
            switch (func.ToLower())
            {
                case "ecourse":
                    element = VantageCommonHelper.FindElementByIdIsEnabled(Convert.ToInt32(ToolBarAutoEnum.ECourseIcon).ToString());
                    break;
                default:
                    Assert.Fail("The ThenTheFunctionShownOrHiddenWithinToolbar no run");
                    break;
            }
            if (isShow)
            {
                Assert.NotNull(element, "The element not found," + func);
            }
            else
            {
                Assert.Null(element, "The element still show," + func);
            }
        }

        [StepDefinition(@"Turn on or off the narrator '(.*)'")]
        public void GivenTurnOnOrOffTheNarrator(string status)
        {
            switch (status)
            {
                case "on":
                    // Process.Start(@"%windir%\system32\narrator.exe");
                    /* */
                    int times = 5;
                    do
                    {
                        KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 0, 0);
                        KeyboardMouse.keybd_event((byte)Keys.ControlKey, 0, 0, 0);
                        KeyboardMouse.keybd_event((byte)Keys.Enter, 0, 0, 0);
                        KeyboardMouse.keybd_event((byte)Keys.LWin, 0, 2, 0);
                        KeyboardMouse.keybd_event((byte)Keys.ControlKey, 0, 2, 0);
                        KeyboardMouse.keybd_event((byte)Keys.Enter, 0, 2, 0);
                        Thread.Sleep(4000);
                        if (Process.GetProcessesByName("Narrator").Length > 0)
                        {
                            break;
                        }
                        times--;
                    } while (times > 0);
                    Assert.NotZero(Process.GetProcessesByName("Narrator").Length, "The turn on narrator fail.");
                    UnManagedAPI.ShowWindow(UnManagedAPI.FindWindow("ApplicationFrameWindow", "Narrator"), UnManagedAPI.SW_SHOWMINIMIZED);
                    //Process.Start("shell:AppsFolder\\Microsoft.Windows.NarratorQuickStart_8wekyb3d8bbwe!App");
                    //Thread.Sleep(3000);
                    //Assert.NotZero(Process.GetProcessesByName("NarratorQuickStart").Length, "The turn on narrator fail.");
                    break;
                case "off":
                    Common.KillProcess("Narrator", true);
                    Common.KillProcess("NarratorQuickStart", true);
                    Thread.Sleep(3000);
                    Assert.Zero(Process.GetProcessesByName("Narrator").Length, "The turn off narrator fail.");
                    Assert.Zero(Process.GetProcessesByName("NarratorQuickStart").Length, "The turn off narrator fail.");
                    break;
                default:
                    Assert.Fail("GivenTurnOnOrOffTheNarrator() not run");
                    break;
            }
        }

        [Then(@"The Dolby Audio app ui is enable or disable '(.*)'")]
        public void ThenTheDolbyAudioAppUiIsEnableOrDisable(string status)
        {
            WindowsDriver<WindowsElement> dolbysession = VantageCommonHelper.LaunchDolbyUwp();
            dolbysession.Manage().Window.Maximize();
            Thread.Sleep(3000);
            string menuxpath = "//*[@AutomationId='lvMenu']";
            WindowsElement element = dolbysession.FindElementByXPath(menuxpath);
            Assert.NotNull(element, "the dolby app menu not found");
            switch (status)
            {
                case "enable":
                    Assert.IsTrue(element.Enabled, "The Dolby app ui disable.");
                    break;
                case "disable":
                    Assert.IsFalse(element.Enabled, "The Dolby app ui enable.");
                    break;
                default:
                    Assert.Fail("ThenTheDolbyAudioAppUiIsEnableOrDisable() not run");
                    break;
            }
            Common.KillProcess(_dolbyProcess, true);
            Assert.Zero(Process.GetProcessesByName(_dolbyProcess).Length, "The stop dolby app fail.");
        }

        [Then(@"Stop play music movie game voice app etc")]
        public void ThenStopPlayMusicMovieGameVoiceAppEtc()
        {
            Common.KillProcess("Music.UI", true);
            Common.KillProcess("Video.UI", true);
            Common.KillProcess("wmplayer", true);
            Common.KillProcess("SoundRec", true);
            Common.KillProcess(_dolbyProcess, true);
            Common.KillProcess("Narrator", true);
            Common.KillProcess("NarratorQuickStart", true);
        }

        [When(@"The user make a voip call via voice recorder app")]
        public void WhenTheUserMakeAVoipCall()
        {
            Process.Start(@"shell:AppsFolder\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe!App");
            Thread.Sleep(5000);
            SendKeys.SendWait("{TAB}");
            Thread.Sleep(1000);
            SendKeys.SendWait("{Enter}");
            ThenStopPlayMusicMovieGameVoiceAppEtc();
            Process.Start(@"shell:AppsFolder\Microsoft.WindowsSoundRecorder_8wekyb3d8bbwe!App");
            Thread.Sleep(5000);
            SendKeys.SendWait("{Enter}");
            IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", "Voice Recorder");
            UnManagedAPI.SetWindowPos(intPtr, UnManagedAPI.HWND_TOP, Screen.PrimaryScreen.Bounds.Width - 500, Screen.PrimaryScreen.Bounds.Height / 2, 500, 500, UnManagedAPI.SWP_NOSIZE);
            UnManagedAPI.SetWindowsActivatedViaClick(intPtr);
        }

        [When(@"Lunch Smart microphone settings")]
        public void WhenLunchSmartMicrophoneSettings()
        {
            UwpAppInfo uwp = UwpAppManagement.SearchUwpAppByName("*FMAPOControl*");
            string commond = "shell:AppsFolder\\" + uwp.PackageFamilyName.Trim() + "!App";
            Process.Start(commond);
        }

        [When(@"Select ""(.*)"" on Smart microphone settings")]
        public void WhenSelectOnSmartMicrophoneSettings(string p0)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement SMSelement = null;
            WindowsDriver<WindowsElement> _appsion = _hsAudioSettingsPage.GetControlPanelSession(true);
            switch (p0)
            {
                case "Environmental Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSEnvMode);
                    break;
                case "Private Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSPrivateMode);
                    break;
                case "Shared Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSShardMode);
                    break;
                default:
                    break;
            }
            Assert.IsNotNull(SMSelement, "The SMSToggle is not find or the SMS dont open");
            var sms = SMSelement.GetAttribute("SelectionItem.IsSelected");
            if (sms != "True")
            {
                SMSelement.Click();
            }

            CommandBase.RunCmd("taskkill /f /t /im Smart Microphone Settings.exe");
        }

        [Then(@"Smart microphone settings ""(.*)"" is select")]
        public void ThenSmartMicrophoneSettingsIsSelect(string p0)
        {
            WhenLunchSmartMicrophoneSettings();
            Thread.Sleep(2000);
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsElement SMSelement = null;
            WindowsDriver<WindowsElement> _appsion = _hsAudioSettingsPage.GetControlPanelSession(true);
            switch (p0)
            {
                case "Environmental Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSEnvMode);
                    break;
                case "Private Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSPrivateMode);
                    break;
                case "Shared Mode":
                    SMSelement = FindElementByTimes(_appsion, "AutomationId", _hsAudioSettingsPage.SMSShardMode);
                    break;
                default:
                    break;
            }
            Assert.IsNotNull(SMSelement, "The SMSToggle is not find or the SMS dont open");
            var sms = SMSelement.GetAttribute("SelectionItem.IsSelected");
            if (sms != "True")
            {
                Assert.Fail("The" + p0 + "Toggle is not select");
            }
        }

        [Then(@"Close Smart Microphone settings")]
        public void ThenCloseSmartMicrophoneSettings()
        {
            BasePage bs = new BasePage();
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = _hsAudioSettingsPage.GetControlPanelSession(true);
            WindowsElement SMSelement = bs.FindElementByTimes(_appsion, "Name", "Close Smart Microphone Settings");
            if (SMSelement != null)
            {
                SMSelement.Click();
            }
        }

        [When(@"Get audio smart settings section toggle states")]
        public void ThenGetAudioSmartSettingsSectionToggleStates()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            AudioAutomaticDolbyCheckBoxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AudioAutomaticDolbyCheckBox);
            EntertainmentCheckboxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.EntertainmentCheckbox);
            ECourseCheckboxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.ECourseCheckbox);
            AutomaticVoipCheckBoxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AutomaticVoipCheckBox);
        }

        [Then(@"audio smart settings section toggle states not change")]
        public void ThenAudioSmartSettingsSectionToggleStatesNotChange()
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            Assert.AreEqual(AudioAutomaticDolbyCheckBoxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AudioAutomaticDolbyCheckBox), "The Dolby audio toggle status changed.");
            Assert.AreEqual(EntertainmentCheckboxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.EntertainmentCheckbox), "The Automatically optimize audio for entertainment checkbox status changed.");
            Assert.AreEqual(ECourseCheckboxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.ECourseCheckbox), "The e-Course mode toggle status changed.");
            Assert.AreEqual(AutomaticVoipCheckBoxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AutomaticVoipCheckBox), "The AutomaticVoipCheckBoxState  toggle status changed.");
        }

        [Given(@"""(.*)"" Dolby audio two checkbox states")]
        public void GivenDolbyAudioTwoCheckboxStates(string p0)
        {
            _hsAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
            if (p0 == "Get")
            {
                EntertainmentCheckboxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.EntertainmentCheckbox);
                AutomaticVoipCheckBoxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AutomaticVoipCheckBox);
                ECourseCheckboxState = _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.ECourseCheckbox);
            }
            else
            {
                Assert.AreEqual(EntertainmentCheckboxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.EntertainmentCheckbox), "The Automatically optimize audio for entertainment checkbox status changed.");
                Assert.AreEqual(ECourseCheckboxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.ECourseCheckbox), "The e-Course mode toggle status changed.");
                Assert.AreEqual(AutomaticVoipCheckBoxState, _hsAudioSettingsPage.GetCheckBoxStatus(_hsAudioSettingsPage.AutomaticVoipCheckBox), "The AutomaticVoipCheckBoxState  toggle status changed.");
            }
        }

    }
}
