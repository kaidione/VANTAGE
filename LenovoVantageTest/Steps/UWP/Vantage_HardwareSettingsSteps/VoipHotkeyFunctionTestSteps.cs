using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class VoipHotkeyFunctionTestSteps : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSInputPage _hsInput;

        public VoipHotkeyFunctionTestSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            _hsInput = new HSInputPage(_webDriver.Session);
        }

        [Given(@"Machine support VOIP (.*)")]
        public void GivenMachineSupportVOIP(string flag)
        {
            string FnDriverVer = GetDriverVersion("Lenovo Fn and function");
            if (flag.ToLower().Equals("true"))
            {
                Assert.AreNotEqual("UnknownVersion", FnDriverVer);
            }
            else
            {
                Assert.AreEqual("UnknownVersion", FnDriverVer);
            }
        }

        [Then(@"There is no VOIP feature")]
        public void ThenThereIsNoVOIPFeature()
        {
            Assert.IsNull(_hsInput.VOIPFeatureTitle);
        }

        [When(@"Go to Voip Section witin Input page")]
        public void WhenGoToVoipSectionWitinInputPage()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.fnCtrlKey_Title, "The VoipTeamsAppIcon not found");
            ScrollScreenToWindowsElement(_webDriver.Session, _hsInput.fnCtrlKey_Title);
        }

        [Given(@"The '(.*)' app will be installed or uninstalled '(.*)'")]
        public void GivenTheAppWillBeInstalledOrUninstalled(string app, string action)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            bool isInstall = (action.ToLower() == "installed") ? true : false;
            switch (app.ToLower())
            {
                case "teams":
                    if (isInstall)  //install
                    {
                        Assert.IsTrue(_hsInput.InstallSkypeTeamsForVoip(app.ToLower(), true), "The teams install fail.");
                    }
                    else //uninstall
                    {
                        Assert.IsTrue(_hsInput.InstallSkypeTeamsForVoip(app.ToLower(), false), "The teams uninstall fail.");
                    }
                    break;
                case "skype":
                    if (isInstall)  //install
                    {
                        Assert.IsTrue(_hsInput.InstallSkypeTeamsForVoip(app.ToLower(), true), "The skype install fail.");
                    }
                    else //uninstall
                    {
                        Assert.IsTrue(_hsInput.InstallSkypeTeamsForVoip(app.ToLower(), false), "The skype uninstall fail.");
                    }
                    break;
                default:
                    Assert.Fail("GivenTheAppWillBeInstalledOrUninstalled() no run");
                    break;
            }
        }

        [When(@"The MS Teams and Skype install status '(.*)'")]
        public void WhenTheMSTeamsAndSkypeInstallStatus(string status)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (status.ToLower())
            {
                case "skype":
                    Assert.AreEqual("true", _hsInput.GetSkypeTeamsInstallStatus(status.ToLower()), "The MS Teams and Skype install stutus incorrect.info:" + status.ToLower());
                    break;
                case "teams":
                    Assert.AreEqual("true", _hsInput.GetSkypeTeamsInstallStatus(status.ToLower()), "The MS Teams and Skype install stutus incorrect.info:" + status.ToLower());
                    break;
                case "both":
                    Assert.AreEqual("true", _hsInput.GetSkypeTeamsInstallStatus(status.ToLower()), "The MS Teams and Skype install stutus incorrect.info:" + status.ToLower());
                    break;
                case "noapps":
                    Assert.AreEqual("true", _hsInput.GetSkypeTeamsInstallStatus(status.ToLower()), "The MS Teams and Skype install stutus incorrect.info:" + status.ToLower());
                    break;
                default:
                    Assert.Fail("WhenTheMSTeamsAndSkypeInstallStutus() no run.info:" + status);
                    break;
            }
        }

        [When(@"The MS Teams and Skype running status '(.*)'")]
        public void WhenTheMSTeamsAndSkypeRunningStatus(string status)
        {
            Process[] processSkype = Process.GetProcessesByName("lync");
            Process[] processT = Process.GetProcesses();
            string skypePath = @"C:\Program Files\Microsoft Office\Office16\lync.exe";
            string teamsPath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Teams\current\Teams.exe";
            Process pT = new Process();
            pT.StartInfo.FileName = teamsPath;
            pT.StartInfo.CreateNoWindow = true;
            Process pS = new Process();
            pS.StartInfo.FileName = skypePath;
            pS.StartInfo.CreateNoWindow = true;
            switch (status.ToLower())
            {
                case "skype":
                    try
                    {
                        pS.Start();
                    }
                    catch
                    {
                        Assert.Fail("Skype cannot be launched");
                    }
                    foreach (Process p in processT)
                    {
                        if (p.GetCommandLine() != null && p.GetCommandLine().Equals(@"""C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Teams\current\Teams.exe"""))
                        {
                            p.Kill();
                            break;
                        }
                    }
                    break;
                case "teams":
                    try
                    {
                        pT.Start();
                    }
                    catch
                    {
                        Assert.Fail("Teams cannot be launched");
                    }
                    if (processSkype.Length > 0)
                    {
                        Assert.IsTrue(true);
                        Common.KillProcess("lync", true);
                    }
                    break;
                case "both":
                    try
                    {
                        pT.Start();
                    }
                    catch
                    {
                        Assert.Fail("Teams cannot be launched");
                    }
                    try
                    {
                        pS.Start();
                    }
                    catch
                    {
                        Assert.Fail("Skype cannot be launched");
                    }
                    break;
                case "noapps":
                    if (processSkype.Length > 0)
                    {
                        Assert.IsTrue(true);
                        Common.KillProcess("lync", true);
                    }
                    foreach (Process p in processT)
                    {
                        Debug.WriteLine(@"""C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Teams\current\Teams.exe""");
                        if (p.GetCommandLine() != null && p.GetCommandLine().Trim().Equals(@"""C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Teams\current\Teams.exe"""))
                        {
                            p.Kill();
                            break;
                        }
                    }
                    break;
                default:
                    Assert.Fail("WhenTheMSTeamsAndSkypeRunningStatus() no run.info:" + status);
                    break;
            };
        }


        [Then(@"The VOIP feature display is the same as UI")]
        public void ThenTheVOIPFeatureDisplayIsTheSameAsUI(Table table)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            for (int i = 0; i < table.Rows.Count; i++)
            {
                switch (table.Rows[i][0].ToLower())
                {
                    case "title":
                        Assert.NotNull(_hsInput.VOIPFeatureTitle, "The VOIPFeatureTitle not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPFeatureTitle.Text, "The VOIPFeatureTitle desc incorect.");
                        break;
                    case "desc":
                        Assert.NotNull(_hsInput.VOIPfeatureDesc, "The VOIPfeatureDesc not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPfeatureDesc.Text, "The VOIPfeatureDesc desc incorect.");
                        break;
                    case "f10":
                        Assert.NotNull(_hsInput.VOIPHotkeysDescF10, "The VOIPHotkeysDescF10 not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPHotkeysDescF10.Text, "The VOIPHotkeysDescF10 desc incorect.");
                        break;
                    case "f11":
                        Assert.NotNull(_hsInput.VOIPHotkeysDescF11, "The VOIPHotkeysDescF11 not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPHotkeysDescF11.Text, "The VOIPHotkeysDescF11 desc incorect.");
                        break;
                    case "option":
                        Assert.NotNull(_hsInput.VOIPHotkeysInstalledAppsDescXpath, "The VOIPHotkeysInstalledAppsDescXpath not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPHotkeysInstalledAppsDescXpath.Text, "The VOIPHotkeysInstalledAppsDescXpath desc incorect.");
                        break;
                    case "note":
                        Assert.NotNull(_hsInput.VOIPAppNoteXpth, "The VoipAppNoteXpth not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPAppNoteXpth.Text, "The VoipAppNoteXpth desc incorect.");
                        break;
                    case "tips":
                        Assert.NotNull(_hsInput.VOIPfeatureTooltipsDesc, "The VOIPfeatureTooltipsDesc not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPfeatureTooltipsDesc.Text, "The VOIPfeatureTooltipsDesc desc incorect.");
                        break;
                    case "skypename":
                        Assert.NotNull(_hsInput.VOIPSkypeAppName, "The VOIPSkypeAppName not found");
                        Assert.IsTrue(table.Rows[i][1] == _hsInput.VOIPSkypeAppName.GetAttribute("Name") || table.Rows[i][1].Replace("for", "For") == _hsInput.VOIPSkypeAppName.GetAttribute("Name"), "The VOIPSkypeAppName incorect.");
                        break;
                    case "teamsname":
                        Assert.NotNull(_hsInput.VOIPMicrosoftTeamsAppName, "The VOIPMicrosoftTeamsAppName not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPMicrosoftTeamsAppName.GetAttribute("Name"), "The VOIPMicrosoftTeamsAppName incorect.");
                        break;
                    case "skypeoption":
                        Assert.NotNull(_hsInput.VOIPSkypeOption, "The VOIPSkypeOption not found");
                        Assert.IsTrue(table.Rows[i][1] == _hsInput.VOIPSkypeOption.GetAttribute("Name") || table.Rows[i][1].Replace("for", "For") == _hsInput.VOIPSkypeOption.GetAttribute("Name"), "The VOIPSkypeOption incorect.");
                        break;
                    case "teamsoption":
                        Assert.NotNull(_hsInput.VOIPMicrosoftTeamsOption, "The VOIPMicrosoftTeamsOption not found");
                        Assert.AreEqual(table.Rows[i][1], _hsInput.VOIPMicrosoftTeamsOption.GetAttribute("Name"), "The VOIPMicrosoftTeamsOption incorect.");
                        break;
                    default:
                        Assert.Fail("ThenTheVOIPFeatureDisplayIsTheSameAsUI() no run,info:" + table.Rows[i][0].ToLower());
                        break;
                }
            }
        }

        [When(@"The user click question icon within VoIP Hotkey Functions")]
        public void WhenTheUserClickQuestionIconWithinVoIPHotkeyFunctions()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.VOIPfeatureTooltipsIcon, "the VOIPfeatureTooltipsIcon not found");
            _hsInput.VOIPfeatureTooltipsIcon.Click();
            if (_hsInput.VOIPfeatureTooltipsDesc == null)
            {
                _webDriver.Session.Mouse.Click(_hsInput.VOIPfeatureTooltipsIcon.Coordinates);
            }
        }

        [When(@"User Selcect App '(.*)' Option")]
        public void WhenUserSelcectAppOption(string app)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            switch (app.ToLower())
            {
                case "skype":
                    Assert.NotNull(_hsInput.VOIPSkypeOption, "The VOIPSkypeOption not found");
                    if (_hsInput.VOIPSkypeOption.Selected != true)
                    {
                        _hsInput.VOIPSkypeOption.Click();
                    }
                    Thread.Sleep(1000);
                    if (_hsInput.VOIPSkypeOption.Selected != true)
                    {
                        _webDriver.Session.Mouse.Click(_hsInput.VOIPSkypeOption.Coordinates);
                    }
                    Assert.IsTrue(_hsInput.VOIPSkypeOption.Selected, "Select App fail,Info:" + app + "Status:" + _hsInput.VOIPSkypeOption.Selected);
                    break;
                case "teams":
                    Assert.NotNull(_hsInput.VOIPMicrosoftTeamsOption, "The VOIPMicrosoftTeamsOption not found");
                    if (_hsInput.VOIPMicrosoftTeamsOption.Selected != true)
                    {
                        _hsInput.VOIPMicrosoftTeamsOption.Click();
                    }
                    Thread.Sleep(1000);
                    if (_hsInput.VOIPMicrosoftTeamsOption.Selected != true)
                    {
                        _webDriver.Session.Mouse.Click(_hsInput.VOIPMicrosoftTeamsOption.Coordinates);
                    }
                    Assert.IsTrue(_hsInput.VOIPMicrosoftTeamsOption.Selected, "Select App fail,Info:" + app + "Status:" + _hsInput.VOIPMicrosoftTeamsOption.Selected);
                    break;
                default:
                    Assert.Fail("WhenUserSelcectAppOption() no run, info:" + app);
                    break;
            }
        }

        [Then(@"The feature show options of the Apps '(.*)' will be '(.*)'")]
        public void ThenTheFeatureShowOptionsOfTheAppsWillBe(string app, string sel)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            bool isSelected = sel.ToLower() == "selected" ? true : false;
            switch (app.ToLower())
            {
                case "skype":
                    Assert.NotNull(_hsInput.VOIPSkypeOption, "The VOIPSkypeOption not found");
                    Assert.AreEqual(isSelected, _hsInput.VOIPSkypeOption.Selected, "The App status incorrect,Info:" + app + "Status:" + _hsInput.VOIPSkypeOption.Selected);
                    if (_hsInput.GetSkypeTeamsInstallStatus("both") == "true")
                    {
                        Assert.NotNull(_hsInput.VOIPMicrosoftTeamsOption, "The VOIPMicrosoftTeamsOption not found");
                        Assert.AreEqual(!isSelected, _hsInput.VOIPMicrosoftTeamsOption.Selected, "The App status incorrect,Info:" + app + "Status:" + _hsInput.VOIPMicrosoftTeamsOption.Selected);
                    }
                    else
                    {
                        Assert.Null(_hsInput.VOIPMicrosoftTeamsOption, "The VOIPMicrosoftTeamsOption still show");
                    }
                    break;
                case "teams":
                    Assert.NotNull(_hsInput.VOIPMicrosoftTeamsOption, "The VOIPMicrosoftTeamsOption not found");
                    Assert.AreEqual(isSelected, _hsInput.VOIPMicrosoftTeamsOption.Selected, "The App status incorrect,Info:" + app + "Status:" + _hsInput.VOIPMicrosoftTeamsOption.Selected);
                    if (_hsInput.GetSkypeTeamsInstallStatus("both") == "true")
                    {
                        Assert.NotNull(_hsInput.VOIPSkypeOption, "The VOIPSkypeOption not found");
                        Assert.AreEqual(!isSelected, _hsInput.VOIPSkypeOption.Selected, "The App status incorrect,Info:" + app + "Status:" + _hsInput.VOIPSkypeOption.Selected);
                    }
                    else
                    {
                        Assert.Null(_hsInput.VOIPSkypeOption, "The VOIPSkypeOption still show");
                    }
                    break;
                default:
                    Assert.Fail("ThenTheFeatureShowOptionsOfTheAppsWillBeSelected() no run, info:" + app);
                    break;
            }
        }

        [Then(@"The UI Should Be Display Cirrectky")]
        public void ThenTheUIShouldBeDisplayCirrectky()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.VOIPFeatureTitle, "The VOIPFeatureTitle not found");
            Assert.NotNull(_hsInput.VOIPfeatureDesc, "The VOIPfeatureDesc not found");
            Assert.NotNull(_hsInput.VOIPHotkeysDescF10, "The VOIPHotkeysDescF10 not found");
            Assert.NotNull(_hsInput.VOIPHotkeysDescF11, "The VOIPHotkeysDescF11 not found");
            Assert.NotNull(_hsInput.VOIPHotkeysInstalledAppsDescXpath, "The VOIPHotkeysInstalledAppsDescXpath not found");
            Assert.NotNull(_hsInput.VOIPMicrosoftTeamsAppName, "The VOIPMicrosoftTeamsAppName not found");
        }

        [Then(@"The UI VoIP should be displayed within (.*) seconds when (.*) launch")]
        public void ThenTheUIVoIPShouldBeDisplayedWithinSecondsWhenFirstLaunch(int p0, string P1)
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Assert.NotNull(_hsInput.VOIPFeatureTitle, "The VOIPFeatureTitle not found");
            Assert.NotNull(_hsInput.VOIPfeatureDesc, "The VOIPfeatureDesc not found");
            Assert.NotNull(_hsInput.VOIPHotkeysDescF10, "The VOIPHotkeysDescF10 not found");
            Assert.NotNull(_hsInput.VOIPHotkeysDescF11, "The VOIPHotkeysDescF11 not found");
            Assert.NotNull(_hsInput.VOIPHotkeysInstalledAppsDescXpath, "The VOIPHotkeysInstalledAppsDescXpath not found");
            Assert.NotNull(_hsInput.VOIPMicrosoftTeamsAppName, "The VOIPMicrosoftTeamsAppName not found");
            sw.Stop();
            TimeSpan ts = sw.Elapsed;
            double spendTime = ts.TotalSeconds;
            Assert.LessOrEqual(spendTime, p0, "The UI should show completely in " + p0 + " seconds when " + P1 + " launch");
        }

        [Then(@"Microsoft Teams image shows under the description")]
        public void ThenMicrosoftTeamsImageShowsUnderTheDescription()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.VOIPHotkeysInstalledAppsDescXpath, "The VOIPHotkeysInstalledAppsDescXpath not found");
            Assert.NotNull(_hsInput.VoipTeamsAppIcon, "The VoipTeamsAppIcon not found");
            Assert.IsTrue(_hsInput.VOIPHotkeysInstalledAppsDescXpath.Location.Y < _hsInput.VoipTeamsAppIcon.Location.Y, "Microsoft Teams image is not under the description Element");
            Assert.AreEqual("img", _hsInput.VoipTeamsAppIcon.GetAttribute("AriaRole"), "img can be click"); ;
        }

        [Then(@"A Note under the image")]
        public void ThenANoteUnderTheImage()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.NotNull(_hsInput.VOIPAppNoteXpth, "The VOIPAppNoteXpth not found");
            Assert.NotNull(_hsInput.VoipTeamsAppIcon, "The VoipTeamsAppIcon not found");
            Assert.IsTrue(_hsInput.VoipTeamsAppIcon.Location.Y < _hsInput.VOIPAppNoteXpth.Location.Y, "Microsoft Teams image is not under the description Element");

        }

        [Then(@"The note is hidden")]
        public void ThenTheNoteIsHidden()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            Assert.IsNull(_hsInput.VOIPAppNoteXpth, "The VoipAppNoteXpth is not found");
        }

        [Then(@"Input Page Show All")]
        public void ThenInputPageShowAll()
        {
            _hsInput = new HSInputPage(_webDriver.Session);
            //Hidden Keyboard Functions
            Assert.IsNotNull(_hsInput.keyboard_title, "Intelligent keyboard title should be visibile");
            Assert.IsNotNull(_hsInput.HiddenKeyboardFunctionsTextId, "Intelligent keyboard title should be visibile");
            Assert.IsNotNull(_hsInput.HiddenKeyboardFunctionsMap, "Intelligent keyboard HiddenKeyboardFunctionsMap should be visibile");
            Assert.IsNotNull(_hsInput.Fn4Title, "Fn4Title title should be visibile");
            Assert.IsNotNull(_hsInput.Fn4Description, "Fn4Description should be visibile");
            Assert.IsNotNull(_hsInput.FnTabTitle, "FnTabTitle should be visibile");
            Assert.IsNotNull(_hsInput.FnTabDescription, "FnTabDescription should be visibile");
            Assert.IsNotNull(_hsInput.FnSTitle, "FnSTitle should be visibile");
            Assert.IsNotNull(_hsInput.FnSDescription, "FnSDescription should be visibile");
            //Keyboard top-row function
            Assert.IsNotNull(_hsInput.KBDTopRowTitle, "Keyboard top row function title should be visibile");
            Assert.IsNotNull(_hsInput.KBDTopRowDesc, "Keyboard top row function description should be visibile");
            Assert.IsNotNull(_hsInput.SpecialKeyRadio, "Keyboard top row function SpecialKeyRadio should be visibile");
            Assert.IsNotNull(_hsInput.FunctionKeyRadio, "Keyboard top row function FunctionKeyRadio should be visibile");
            Assert.IsNotNull(_hsInput.KBDTopRowSubDesc, "KBDTopRowSubDesc should be visibile");
            Assert.IsNotNull(_hsInput.AdvSettings_link, "AdvSettings_link should be visibile");
            //keyboard backlight
            Assert.IsNotNull(_hsInput.keyboardBacklightTitleOfThinkPad, "The keyboardBacklightTitleOfThinkPad not found");
            Assert.IsNotNull(_hsInput.KBCaptionOfThinkPad, "The KBCaptionOfThinkPad not found");
            Assert.IsNotNull(_hsInput.backlightLow, "The KBCaptionOfThinkPad not found");
            Assert.IsNotNull(_hsInput.backlightHigh, "The KBCaptionOfThinkPad not found");
            Assert.IsNotNull(_hsInput.backlightOff, "The KBCaptionOfThinkPad not found");
            //VoIP function
            Assert.IsNotNull(_hsInput.VOIPFeatureTitle, "The VOIPFeatureTitle not found");
            Assert.IsNotNull(_hsInput.VOIPfeatureDesc, "The VOIPfeatureDesc not found");
            Assert.IsNotNull(_hsInput.VOIPHotkeysDescF10, "The VOIPHotkeysDescF10 not found");
            Assert.IsNotNull(_hsInput.VOIPHotkeysDescF11, "The VOIPHotkeysDescF11 not found");
            Assert.IsNotNull(_hsInput.VOIPHotkeysInstalledAppsDescXpath, "The VOIPHotkeysInstalledAppsDescXpath not found");
            Assert.IsNotNull(_hsInput.VOIPMicrosoftTeamsAppName, "The VOIPMicrosoftTeamsAppName not found");
            Assert.IsNotNull(_hsInput.VoipTeamsAppIcon, "The VoipTeamsAppIcon not found");
            //Fn-ctrl key swap
            Assert.IsNotNull(_hsInput.fnCtrlKey_Title, "The Fn-ctrl key swap fnCtrlKey_Title is not find");
            Assert.IsNotNull(_hsInput.fnCtrlKey_TexDescription, "The Fn-ctrl key swap fnCtrlKey_TexDescription is not find");
            Assert.IsNotNull(_hsInput.fnCtrlKey_Toggle, "The Fn-ctrl key swap fnCtrlKey_Toggle is not find");
            Assert.IsNotNull(_hsInput.fnCtrlKey_img, "The Fn-ctrl key swap fnCtrlKey_img is not find");
            //User-defined key 
            Assert.IsNotNull(_hsInput.userDefinedKey_Title, "The user defined key userDefinedKey_Title is not find");
            Assert.IsNotNull(_hsInput.userDefinedKey_caption, "The user defined key userDefinedKey_caption is not find");
            Assert.IsNotNull(_hsInput.userDefinedKey_img, "The user defined key userDefinedKey_img is not find");
            Assert.IsNotNull(_hsInput.userDefinedKey_dropdownbtn, "The user defined key userDefinedKey_dropdownbtn is not find");
            //Touchpad link
            Assert.IsNotNull(_hsInput.Touchpadlink, "Thouchpad Controls link should be visibile");
            //trackpoint link
            Assert.IsNotNull(_hsInput.Trackpointlink, "Trackpoint Controls link should be visibile");
        }
    }
}
