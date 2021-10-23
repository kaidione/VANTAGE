namespace LenovoVantageTest.Steps.UWP
{
    using HttpAnalyzerHelper;
    using LenovoVantageTest.Helper;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Pages.HardwareSettingsPages;
    using LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps;
    using LenovoVantageTest.Utility;
    using Microsoft.Win32;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using System;
    using System.IO;
    using System.Reflection;
    using System.Threading;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using TechTalk.SpecFlow;
    using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

    [Binding]
    public class HSIdeaBacklight : SettingsBase
    {

        private InformationalWebDriver _webDriver;
        private HSInputPage _inputPage;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HttpAnalyzerAgent _httpAnalyzerAgent;
        private string _driverKeyboardLevel;
        private string _driverKeyboardValue;

        public HSIdeaBacklight(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            base.session = _webDriver.Session;
        }

        [Given(@"Open Vantage")]
        public void GivenOpenVantage()
        {
            var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            _webDriver = new InformationalWebDriver(session, session);
            VantageCommonHelper.OObeNetVantage30(session, true);
        }

        [Given(@"Go to input page")]
        public void GivenGoToInputPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage.GotoInputPage();
        }

        [Then(@"input and accessories not show on the menu")]
        public void ThenInputAndAccessoriesNotShowOnTheMenu()
        {
            Assert.IsNull(MySettingsInputTab, "MySettingsInputTab is not null");
        }


        [StepDefinition(@"Go to display page")]
        public void GoToDisplayPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage.GotoMySettingsDisplayCameraPage();
        }

        [Given(@"Start http analyzer")]
        public void GivenStartHttpAnalyzer()
        {
            Common.KillProcess("HTTPAnalyzerStdV7", true);
            _httpAnalyzerAgent = new HttpAnalyzerAgent("chifsr.lenovomm.com", true);
            _httpAnalyzerAgent.Start();
        }

        [Given(@"Turn on the toggle of keyboard backlight feature")]
        public void GivenTurnOnTheToggleOfKeyboardBacklightFeature()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On)
            {
                _inputPage.keyboardBacklightCheckBox.Click();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                _inputPage.keyboardBacklightCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off)
            {
                _inputPage.keyboardBacklightCheckBox.Click();
            }
        }

        [Given(@"Turn off the toggle of keyboard backlight feature")]
        public void GivenTurnOffTheToggleOfKeyboardBacklightFeature()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCheckBox);
            if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off)
            {
                _inputPage.keyboardBacklightCheckBox.Click();
                _inputPage.keyboardBacklightCheckBox.Click();
            }
            else if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On)
            {
                _inputPage.keyboardBacklightCheckBox.Click();
            }
        }

        [Given(@"Machine is IdeaPad/Yoga/Gaming models and do not support keyboard backlight\.")]
        public void GivenMachineIsIdeaPadYogaGamingModelsAndDoNotSupportKeyboardBacklight_()
        {
            //var currentMachineType = VantageCommonHelper.GetCurrentMachineType();
            //if (!currentMachineType.ToLower().Contains("v530s") && !currentMachineType.ToLower().Contains("14ikb") && !currentMachineType.ToLower().Contains("y750"))
            //{
            //    throw new Exception("This machine should not support keyboard backlight");
            //}
            //There are some machine that will not support KBBL,but we don't have a list, so now this step is testing at YOGA 530-14ARR
        }

        [When(@"Go to input page")]
        public void WhenGoToInputPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.deviceTab);
            Assert.IsTrue(_hsQuickSettingsPage.GotoInputPage());

        }
        [When(@"Turn (.*) the toggle of keyboard backlight feature")]
        public void WhenTurnOnTheToggleOfKeyboardBacklightFeature(String Status)
        {
            if (Status.Equals("on"))
            {
                _inputPage = new HSInputPage(_webDriver.Session);
                if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On)
                {
                    _inputPage.keyboardBacklightCheckBox.Click();
                    _inputPage.keyboardBacklightCheckBox.Click();
                }
                else if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off)
                {
                    _inputPage.keyboardBacklightCheckBox.Click();
                }
            }
            if (Status.Equals("off"))
            {
                _inputPage = new HSInputPage(_webDriver.Session);
                if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off)
                {
                    _inputPage.keyboardBacklightCheckBox.Click();
                    _inputPage.keyboardBacklightCheckBox.Click();
                }
                else if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On)
                {
                    _inputPage.keyboardBacklightCheckBox.Click();
                }
            }
        }

        [When(@"Clikck the toggle of keyboard backlight feature")]
        public void WhenClikckTheToggleOfKeyboardBacklightFeature()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            _inputPage.keyboardBacklightCheckBox.Click();
        }

        [When(@"click keyboard backlight caption")]
        public void WhenClickKeyboardBacklightCaption()
        {
            var backlightCaption = VantageCommonHelper.FindElementByXPathAndEnabled(_webDriver.Session, VantageConstContent.HSIdeaBacklightCaption);
            Assert.IsNotNull(backlightCaption);
            backlightCaption.Click();
        }

        [When(@"stop http analyzer")]
        public void WhenStopHttpAnalyzer()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _httpAnalyzerAgent.Stop();
        }

        [StepDefinition("the toggle for backlight shows up")]
        public void ToggleShowsUp()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCheckBox);
        }

        [Then(@"The toggle should keep what user set (.*) before")]
        public void ThenTheToggleShouldKeepWhatUserSetBefore(string toggleState)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCheckBox);
            if (toggleState == "on")
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On);
            }
            else if (toggleState == "off")
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off);
            }
        }

        [Then(@"The toggle should resume to default value off")]
        public void ThenTheToggleShouldResumeToDefaultValueOff()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCheckBox);
            Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off);
        }


        [Then(@"There shows the Keyboard backlight feature")]
        public void ThenThereShowsTheKeyboardBacklightFeature()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightCaption);
            _inputPage.keyboardBacklightCaption.Click();
            Assert.AreEqual("Keyboard backlight", _inputPage.keyboardBacklightTitle.Text);
        }

        [Then(@"There should not show the Keyboard backlight feature")]
        public void ThenThereShouldNotShowTheKeyboardBacklightFeature()
        {
            var backlightTitle = VantageCommonHelper.FindElementByXPathAndEnabled(_webDriver.Session, VantageConstContent.HSIdeaBacklightTitle);
            Assert.IsNull(backlightTitle);
        }


        [StepDefinition(@"On (No|2 level) backlight machine, We do NOT see '(.*)' toggles")]
        public void NoOptionsKeyboardBacklightFeature(string _useless_Param, string _toggleNames)
        {
            string[] toggleNames = _toggleNames.Trim().Split(',');
            string xpath = $"/Window[]//*[@Name='{toggleNames[0]}']";
            string combinedXPath = string.Empty;
            for (int i = 0; i < toggleNames.Length; i++)
            {
                if (i == 0)
                {
                    combinedXPath = $"/Window[@Name='{Constants.VantageTitle}']//*[@Name='{toggleNames[0]}']";
                }
                else
                {
                    combinedXPath = combinedXPath + "|" + $"/Window[@Name='{Constants.VantageTitle}']//*[@Name='{toggleNames[i]}']";
                }

            }
            Assert.IsTrue(!VantageUI.instance.ElementExistUsingCustomXPath(combinedXPath));
        }

        [Then(@"state of the toggle is on/off")]
        public void ThenStateOfTheToggleIsOnOff()
        {
            _inputPage = new HSInputPage(_webDriver.Session);

            if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On)
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On);
            }
            else if (VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off)
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off);
            }
            else
            {
                throw new Exception("The state of toggle is not right.");
            }
        }

        [Then(@"the description should follow the UI SPEC")]
        public void ThenTheDescriptionShouldFollowTheUISPEC()
        {
            _inputPage = new HSInputPage(_webDriver.Session);

            Assert.AreEqual(_inputPage.expect_keyboardBacklight_Description, _inputPage.keyboardBacklightCaption.Text);
        }

        [When(@"turn (.*) Keyboard backlight from Toolbar")]
        public void WhenTurnOffKeyboardBacklightFromToolbar(String Status)
        {
            if (Status.Equals("on"))
            {
                if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.Off)
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                }
                Assert.AreEqual(ToggleState.On, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()));
            }
            if (Status.Equals("off"))
            {
                if (SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()) == ToggleState.On)
                {
                    VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString());
                }
                Assert.AreEqual(ToggleState.Off, SettingsBase.GetFeatureStatusFromToolbar(Convert.ToInt32(ToolBarAutoEnum.KeyboardBacklight).ToString()));
            }
        }

        [Then(@"Check Keyboard backlight toggle state in Vantage is (.*)")]
        public void ThenCheckKeyboardBacklightToggleStateInVantageIsOff(String Status)
        {
            _inputPage = new HSInputPage(_webDriver.Session);

            if (Status.Equals("on"))
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.On);
            }
            if (Status.Equals("off"))
            {
                Assert.IsTrue(VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox) == ToggleState.Off);
            }
        }

        [Given(@"Set Vantage Size Width '(.*)' Height '(.*)'")]
        public void GivenSetVantageSize(int width, int height)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            _inputPage.SetVantageSize(width, height);
        }


        [StepDefinition(@"Set the KBBL value in EM driver to (.*)")]
        public void WhenSetTheKBBLValueInEMDriver(string mode)
        {
            switch (mode.ToLower())
            {
                case "on":
                    IdeaPluginHelper.SetKeyboardBacklightLevel1();
                    break;
                case "auto":
                    IdeaPluginHelper.SetKeyboardBacklightLevelAuto();
                    break;
                case "low":
                    IdeaPluginHelper.SetKeyboardBacklightLevel1();
                    break;
                case "high":
                    IdeaPluginHelper.SetKeyboardBacklightLevel2();
                    break;
                case "off":
                    IdeaPluginHelper.SetKeyboardBacklightLevelOff();
                    break;
                default:
                    throw new Exception("invalid option for EM driver");
            }
        }


        [StepDefinition(@"Get the KBBL value in EM driver")]
        public void WhenGetTheKBBLValueInEMDriver()
        {
            Thread.Sleep(3000);
            IdeaPluginHelper ideaKeyboard = new IdeaPluginHelper();
            ideaKeyboard.GetBacklightStatus();
            _driverKeyboardLevel = ideaKeyboard.getKeyboardBacklightDriverLevel();
            _driverKeyboardValue = ideaKeyboard.getKeyboardBacklightDriverValue();
        }

        [StepDefinition(@"Get the KBBL value in EM driver without delay")]
        public void GetTheKBBLValueInEMDriver()
        {
            IdeaPluginHelper ideaKeyboard = new IdeaPluginHelper();
            ideaKeyboard.GetBacklightStatus();
            _driverKeyboardLevel = ideaKeyboard.getKeyboardBacklightDriverLevel();
            _driverKeyboardValue = ideaKeyboard.getKeyboardBacklightDriverValue();
        }

        [StepDefinition(@"The KBBL value in EM driver is (.*)")]
        public void ThenTheKBBLValueInEMDriverIs(string mode)
        {
            switch (mode.ToLower())
            {
                case "on":
                    if (_driverKeyboardLevel.Equals("OneLevel"))
                    {
                        Assert.AreEqual("Level_1", _driverKeyboardValue);
                    }
                    return;
                case "off":
                    Assert.AreEqual("Off", _driverKeyboardValue);
                    return;
                case "low":
                    mode = "Level_1";
                    Assert.IsTrue(_driverKeyboardValue.Trim().Equals(mode), $"backlight NOT low ?? _driverKeyboardLevel={_driverKeyboardValue} ");
                    return;
                case "high":
                    mode = "Level_2";
                    Assert.IsTrue(_driverKeyboardValue.Trim().Equals(mode), $"backlight NOT high ?? _driverKeyboardLevel={_driverKeyboardValue} ");
                    return;
                case "onoff":
                    if (_driverKeyboardLevel.Equals("OneLevel"))
                    {
                        if (_driverKeyboardValue.Equals("Level_1") || _driverKeyboardValue.Equals("Off"))
                        {
                            Assert.IsTrue(true);
                        }
                        else
                        {
                            Assert.Fail("The ON/OFF KBBL value in EM is not on or off");
                        }
                    }
                    return;

                case "auto":
                    Assert.IsTrue(_driverKeyboardValue.Trim().Equals(mode), $"backlight NOT auto ?? _driverKeyboardLevel={_driverKeyboardValue} ");
                    return;
                default:
                    break;
            }
            Assert.IsTrue(false, $"NO matched backlight level?_driverKeyboardLevel={_driverKeyboardLevel}");
        }


        [Then(@"The ONOFF KBBL value in UI match the EM driver value")]
        public void ThenTheONOFFKBBLValueInUIMatchTheEMDriverValue()
        {
            Assert.AreEqual("OneLevel", _driverKeyboardLevel);
            ToggleState kbblToggle = VantageCommonHelper.GetToggleStatus(_inputPage.keyboardBacklightCheckBox);
            if (kbblToggle == ToggleState.On)
            {
                Assert.AreEqual("Level_1", _driverKeyboardValue);
            }
            else if (kbblToggle == ToggleState.Off)
            {
                Assert.AreEqual("Off", _driverKeyboardValue);
            }
            else
            {
                Assert.Fail("Cannot get the Vantage UI KBBL toggle state");
            }
        }

        [Given(@"Copy dependacy file to debug path")]
        public void GivenCopyDependacyFileToDebugPath()
        {
            string dirPath = AppDomain.CurrentDomain.BaseDirectory;
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string sourcePath = Path.Combine(projectDiectory, "lib", "IdeaPadNoteBookPluginDll");
            SmartStandbyTestSteps sst = new SmartStandbyTestSteps(_webDriver);
            sst.CopyFolder(sourcePath, dirPath);
        }

        [StepDefinition(@"click backlight option '(.*)'")]
        public void clickBacklightOption(string _option)
        {
            HSInputPage hSInputPage = new HSInputPage(_webDriver.Session);
            switch (_option)
            {
                case "Auto":
                    hSInputPage.backlightOptionAuto?.Click();
                    break;
                case "Low":
                    hSInputPage.backlightOptionLow?.Click();
                    break;
                case "High":
                    hSInputPage.backlightOptionHigh?.Click();
                    break;
                case "Off":
                    hSInputPage.backlightOptionOff?.Click();
                    break;
                default:
                    throw new Exception("Invalid backlight option");
            }
            //below code is for performance test . VAN16517 want to know how much time it takes to write value into EM driver
            if (!ScenarioContext.Current.ContainsKey("startTimer"))
            {
                ScenarioContext.Current.Add("startTimer", DateTime.Now);
            }
            else
            {
                ScenarioContext.Current["startTimer"] = DateTime.Now;
            }

        }

        [StepDefinition(@"verify backlight option '(.*)' toggled")]
        public void BacklightOption(string _option)
        {
            HSInputPage hSInputPage = new HSInputPage(_webDriver.Session);
            ToggleState kbblToggle;
            switch (_option)
            {
                case "Auto":
                    kbblToggle = VantageCommonHelper.GetToggleStatus(hSInputPage.backlightOptionAuto);
                    break;
                case "Low":
                    kbblToggle = VantageCommonHelper.GetToggleStatus(hSInputPage.backlightOptionLow);
                    break;
                case "High":
                    kbblToggle = VantageCommonHelper.GetToggleStatus(hSInputPage.backlightOptionHigh);
                    break;
                case "Off":
                    kbblToggle = VantageCommonHelper.GetToggleStatus(hSInputPage.backlightOptionOff);
                    break;
                default:
                    throw new Exception("Invalid backlight option");
            }
            Assert.IsTrue(kbblToggle == ToggleState.On, $"required {_option} NOT toggle");
        }

        [Then(@"Backlight Feature Could be Opened within (.*) s")]
        public void ThenBacklightFeatureCouldBeOpenedWithinS(int seconds)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            var startTime = DateTime.Now;
            Assert.IsNotNull(_inputPage.KeyboardBacklightTitleInputIsPresent);
            Assert.IsNotNull(_inputPage.KeyboardBacklightDescInputIsPresent);
            Assert.IsNotNull(_inputPage.KeyboardBacklightOptionsOffInputIsPresent);
            Assert.IsNotNull(_inputPage.KeyboardBacklightOptionsLowInputIsPresent);
            Assert.IsNotNull(_inputPage.KeyboardBacklightOptionsHighInputIsPresent);
            Assert.IsTrue((DateTime.Now - startTime).TotalSeconds <= seconds);
        }

        [Then(@"Backlight option '(.*)' within (.*) s")]
        public void ThenBacklightOptionWithinS(string option, int seconds)
        {
            var startTime = DateTime.Now;
            _inputPage = new HSInputPage(_webDriver.Session);
            switch (option)
            {
                case "Low":
                    Assert.IsNotNull(_inputPage.backlightOptionLow);
                    break;
                case "High":
                    Assert.IsNotNull(_inputPage.backlightOptionHigh);
                    break;
                case "Off":
                    Assert.IsNotNull(_inputPage.backlightOptionOff);
                    break;
                default:
                    throw new Exception("Invalid backlight option");
            }
            Assert.IsTrue((DateTime.Now - startTime).TotalSeconds <= seconds);
        }

        [When(@"check the title, option, icon and description of UI")]
        public void WhenCheckTheTitleOptionIconAndDescriptionOfUI()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.IsNotNull(_inputPage.keyboardBacklightTitle);
            Assert.IsNotNull(_inputPage.keyboardBacklightCaption);
        }

        [Then(@"title, option,icon and description should be correct")]
        public void ThenTitleOptionIconAndDescriptionShouldBeCorrect()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.AreEqual(_inputPage.expect_autokeyboardBacklight_Description, _inputPage.keyboardBacklightCaption.GetAttribute("Name"));
            Assert.AreEqual("Keyboard backlight", _inputPage.keyboardBacklightTitle.GetAttribute("Name"));
            Assert.AreEqual("Auto", _inputPage.AutoModeofkeyboardbacklight.GetAttribute("Name"));
            Assert.AreEqual("Low", _inputPage.LowModeofkeyboardbacklight.GetAttribute("Name"));
            Assert.AreEqual("High", _inputPage.HighModeofkeyboardbacklight.GetAttribute("Name"));
            Assert.AreEqual("Off", _inputPage.OffModeofkeyboardbacklight.GetAttribute("Name"));
        }

        [Then(@"Title Option Icon and Description should be correct On Idea")]
        public void ThenTitleOptionIconAndDescriptionShouldBeCorrectOnIdea()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Assert.AreEqual(_inputPage.ExpectKeyboardBacklightDescriptionOnIdea, _inputPage.keyboardBacklightCaption.GetAttribute("Name"));
            Assert.AreEqual("Keyboard backlight", _inputPage.keyboardBacklightTitle.GetAttribute("Name"));
            Assert.AreEqual("Low", _inputPage.LowModeofkeyboardbacklight.GetAttribute("Name"));
            Assert.AreEqual("High", _inputPage.HighModeofkeyboardbacklight.GetAttribute("Name"));
            Assert.AreEqual("Off", _inputPage.OffModeofkeyboardbacklight.GetAttribute("Name"));
        }

        [Then(@"The Backlight option same to EM driver")]
        public void ThenTheBacklightOptionSameToEMDriver()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            string selectOptionsName = string.Empty;
            foreach (WindowsElement element in _inputPage.AllBacklightMode)
            {

                if (ToggleState.On == _inputPage.GetCheckBoxStatus(element))
                {
                    selectOptionsName = _inputPage.ShowTextbox(element).ToLower();
                }
            }

            string mode = string.Empty;

            switch (selectOptionsName)
            {
                case "off":
                    Assert.AreEqual("Off", _driverKeyboardValue);
                    return;
                case "low":
                    mode = "Level_1";
                    Assert.IsTrue(_driverKeyboardValue.Trim().Equals(mode), $"backlight NOT low ?? _driverKeyboardLevel={_driverKeyboardValue} ");
                    return;
                case "high":
                    mode = "Level_2";
                    Assert.IsTrue(_driverKeyboardValue.Trim().Equals(mode), $"backlight NOT high ?? _driverKeyboardLevel={_driverKeyboardValue} ");
                    return;
            }
        }


        [When(@"click auto mode and check the UI")]
        public void WhenClickAutoModeAndCheckTheUI()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            _inputPage.AutoModeofkeyboardbacklight.Click();
        }

        [Then(@"(.*) mode should be selected")]
        public void ThenModeShouldBeSelected(string SelectModeName)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            Console.WriteLine("Info:" + _inputPage.AutoModeofkeyboardbacklight.GetAttribute("Toggle.ToggleState"));
            if (SelectModeName == "Auto")
            {
                Assert.AreEqual("1", _inputPage.AutoModeofkeyboardbacklight.GetAttribute("Toggle.ToggleState"));
            }
            if (SelectModeName == "Low")
            {
                Assert.AreEqual("1", _inputPage.LowModeofkeyboardbacklight.GetAttribute("Toggle.ToggleState"));
            }
            if (SelectModeName == "High")
            {
                Assert.AreEqual("1", _inputPage.HighModeofkeyboardbacklight.GetAttribute("Toggle.ToggleState"));
            }
            if (SelectModeName == "Off")
            {
                Assert.AreEqual("1", _inputPage.OffModeofkeyboardbacklight.GetAttribute("Toggle.ToggleState"));
            }
        }
        [Then(@"click More to take the screenshot as below")]
        public void ThenClickMoreToTakeTheScreenshotAsBelow()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            _inputPage.moreSection_Title.Click();
        }

        [When(@"click (.*) mode and go to audio page and go to input page")]
        public void WhenClickModeAndGoToAudioPageAndGoToInputPage(string Modename)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            WindowsElement element = null;
            switch (Modename.ToLower())
            {
                case "auto":
                    element = _inputPage.AutoModeofkeyboardbacklight;
                    break;
                case "low":
                    element = _inputPage.LowModeofkeyboardbacklight;
                    break;
                case "high":
                    element = _inputPage.HighModeofkeyboardbacklight;
                    break;
                case "off":
                    element = _inputPage.OffModeofkeyboardbacklight;
                    break;
                default:
                    Assert.Fail("WhenClickModeAndGoToAudioPageAndGoToInputPage() parameter not found");
                    break;
            }
            Assert.NotNull(element, "Keyboard mode can't found," + Modename);
            element.Click();
            Thread.Sleep(3000);
            _inputPage.AudioPage.Click();
            _inputPage.InputPage.Click();
        }

        [When(@"Change the Status of the '(.*)'")]
        public void WhenChangeTheStatusOfThe(string p0)
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) < 22000)
            {
                var appSession = _inputPage.GetControlPanelSession(true);
                string batteryAutomationId = "{7820AE75-23E3-4229-82C1-E41CB67D5B9C}";
                string batterySliderId = "ACPowerOverlaySlider";
                WindowsElement element = FindElementByTimes(appSession, "AutomationId", batteryAutomationId, 10);
                element.Click();
                var slider = FindElementByTimes(appSession, "AutomationId", batterySliderId, 10);
                var position = slider.Rect;
                var x = ((int)position.Left + (int)position.Width / 2).ToString();
                var y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y);
                Thread.Sleep(1000);
                SendKeys.SendWait("{PgUp}");
                Actions action = new Actions(appSession);
                action.MoveByOffset(position.Left + position.Width / 3, position.Bottom - position.Height / 2);
                action.Click();
                action.SendKeys("{PgDn}");
                switch (p0)
                {
                    case "Power Saver":
                        VantageCommonHelper.MoveDown();
                        break;
                }
            }
            else
            {
                var appSession = _inputPage.GetControlPanelSession(true);
                WindowsElement SystemTrayIcon = FindElementByTimes(appSession, "Name", "System Volume State Button Speakers (Realtek(R) Audio): Muted", 10);
                SystemTrayIcon.Click();
                WindowsElement BatterySaver = FindElementByTimes(appSession, "AutomationId", "Microsoft.QuickAction.BatterySaver", 10);
                string initToggleState = BatterySaver.GetAttribute("Toggle.ToggleState");
                //Off = 0  On = 1
                if (initToggleState == "0")
                {
                    BatterySaver.Click();
                    initToggleState = BatterySaver.GetAttribute("Toggle.ToggleState");
                }
                Assert.AreEqual(initToggleState, "1", "battery saver is off");
            }
        }

        [When(@"Disable EM Driver")]
        public void WhenDisableEMDriver()
        {
            _inputPage = new HSInputPage(_webDriver.Session);
            string driverId = _inputPage.GetDeviceID("Lenovo ACPI-Compliant Virtual Power Controller");
            _inputPage.ActionDriver(driverId, "Disable");
            Thread.Sleep(5000);

        }

        [Given(@"Get the KBBL value in EM driver Not (.*) Options")]
        public void GivenGetTheKBBLValueInEMDriverNotOptions(int p0)
        {
            IdeaPluginHelper ideaKeyboard = new IdeaPluginHelper();
            ideaKeyboard.GetBacklightStatus();
            _driverKeyboardLevel = ideaKeyboard.getKeyboardBacklightDriverLevel();
            _driverKeyboardValue = ideaKeyboard.getKeyboardBacklightDriverValue();
            string level = "Two";
            if (p0 == 4)
            {
                level = "Three";
            }
            Assert.IsTrue(_driverKeyboardLevel.Contains(level), string.Format("The Expect is Not {0}Levels, but Actual is {1}", level, _driverKeyboardLevel));
        }

        [Then(@"Get the KBBL value in EM driver is (.*) Options")]
        public void ThenGetTheKBBLValueInEMDriverIsOptions(int p0)
        {
            IdeaPluginHelper ideaKeyboard = new IdeaPluginHelper();
            ideaKeyboard.GetBacklightStatus();
            _driverKeyboardLevel = ideaKeyboard.getKeyboardBacklightDriverLevel();
            _driverKeyboardValue = ideaKeyboard.getKeyboardBacklightDriverValue();
            string level = "Two";
            if (p0 == 4)
            {
                level = "Three";
            }
            Assert.IsTrue(!_driverKeyboardLevel.Contains(level), string.Format("The Expect is {0}Levels, but Actual is {1}", level, _driverKeyboardLevel));

        }

    }
}
