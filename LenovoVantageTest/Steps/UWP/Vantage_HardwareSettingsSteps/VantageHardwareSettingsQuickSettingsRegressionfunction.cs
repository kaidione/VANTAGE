namespace LenovoVantageTest.Steps.UWP
{
    using BoDi;
    using LenovoVantageTest.Helper;
    using LenovoVantageTest.Pages;
    using LenovoVantageTest.Pages.HardwareSettingsPages;
    using LenovoVantageTest.Pages.Helper;
    using LenovoVantageTest.Pages.WifiSecurityPages;
    using LenovoVantageTest.Utility;
    using Microsoft.Win32;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium.Windows;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using TechTalk.SpecFlow;
    using static LenovoVantageTest.Pages.HardwareSettingsPages.VantageConstContent;

    [Binding]
    public class VantageHardwareSettingsQuickSettingsRegressionfunction : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        private HSQuickSettingsPage _hsQuickSettingsPage;
        private HSPowerSettingsPage _hsPowerSettingsPage;
        public HSSystemUpdatePage _systemUpdatePage;
        private HSToolbarPage _hSToolbarPage;
        private SupportPage _supportPage;
        private HSAudioSettingsPage _hSAudioSettingsPage;
        private LenovoWifiSecurityPage _lenovoWifiSecurityPage;
        private HSDispalyCameraPage _hSDispalyCameraPage;
        public readonly IObjectContainer objectContainer;
        private VantageBase _vantageBase = new VantageBase();

        private InformationalWebDriver desktopSession;
        private HSInputPage hSInputPage;

        public VantageHardwareSettingsQuickSettingsRegressionfunction(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
        }

        [Given(@"Change DPI to (.*)")]
        public void GivenChangeDPITo(String num)
        {
            string currentDPI = string.Empty;
            if (num.Trim().ToLower() == "recommend")
            {
                currentDPI = VantageCommonHelper.GetDPIScaling().Replace("%", "").Trim();
                VantageCommonHelper.ChangeDPI(currentDPI);
            }
            else
            {
                VantageCommonHelper.ChangeDPI(num);
            }
        }

        [Given(@"into Dashboard page")]
        public void GivenIntoDashboarPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage.dashboardLink.Click();
        }

        [Given(@"Go to My Device Settings page")]
        [When(@"Go to My Device Settings page")]
        public void GivenGoToMyDeviceSettingsPage()
        {
            _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            _hsPowerSettingsPage.GoToMyDevicesSettings();
            Thread.Sleep(TimeSpan.FromSeconds(2));
            WindowsElement element = FindElementByTimes(_webDriver.Session, "XPath", VantageConstContent.MenuPowerTitle);
            if (element == null)
            {
                Console.WriteLine("Try GoToMyDeviceSettingsPage again");
                _hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                _hsPowerSettingsPage.GoToMyDevicesSettings();
                Thread.Sleep(TimeSpan.FromSeconds(2));
            }
            element = FindElementByTimes(_webDriver.Session, "XPath", VantageConstContent.MenuPowerTitle);
            Assert.IsNotNull(element, "GivenGoToMyDeviceSettingsPage() fail");
            DesktopPowerManagementHelper.Session = _webDriver.Session;
        }

        [Given(@"Go to My Device")]
        public void GivenGoToMyDevice()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.deviceTab, "The deviceTab not found");
            _hsQuickSettingsPage.GoToMyDevicesSettings();
        }

        [When(@"Go to More Settings section")]
        public void WhenGoToMoreSettingsSection()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.NotNull(_hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard, "The myDeviceSettingsLinkOnDashboard not found");
            ScrollScreenToWindowsElement(_webDriver.Session, _hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard, -30, 20);
        }

        [Given(@"Maxmize Vantage")]
        public void GivenMaxmizeVantage()
        {
            _webDriver.Session.Manage().Window.Maximize();
        }

        [Given(@"click Update button")]
        public void GivenClickUpdateButton()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.updateButton);
            _hsQuickSettingsPage.updateButton.Click();
        }

        [Given(@"turn ""(.*)"" critical updates")]
        public void GivenTurnCriticalUpdates(string checkbox)
        {
            _systemUpdatePage = new HSSystemUpdatePage(_webDriver.Session);
            Assert.IsNotNull(_systemUpdatePage.criticalUpdatesCheckBox);
            if (checkbox == "on" && VantageCommonHelper.GetToggleStatus(_systemUpdatePage.criticalUpdatesCheckBox) == ToggleState.Off)
            {
                _systemUpdatePage.criticalUpdatesCheckBox.Click();
            }
            else if (checkbox == "off" && VantageCommonHelper.GetToggleStatus(_systemUpdatePage.criticalUpdatesCheckBox) == ToggleState.On)
            {
                _systemUpdatePage.criticalUpdatesCheckBox.Click();
            }
        }

        [Given(@"turn ""(.*)"" recommended updates")]
        public void GivenTurnRecommendedUpdates(string checkbox)
        {
            _systemUpdatePage = new HSSystemUpdatePage(_webDriver.Session);
            Assert.IsNotNull(_systemUpdatePage.recommendedUpdatesCheckBox);
            if (checkbox == "on" && VantageCommonHelper.GetToggleStatus(_systemUpdatePage.recommendedUpdatesCheckBox) == ToggleState.Off)
            {
                _systemUpdatePage.recommendedUpdatesCheckBox.Click();
            }
            else if (checkbox == "off" && VantageCommonHelper.GetToggleStatus(_systemUpdatePage.recommendedUpdatesCheckBox) == ToggleState.On)
            {
                _systemUpdatePage.recommendedUpdatesCheckBox.Click();
            }
        }

        [Given(@"Install the Lenovo Vantage Without Launch Vantage")]
        public void GivenInstallTheLenovoVantageWithoutLaunchVantage()
        {
            VantageCommonHelper.InstallVantage(true);
        }

        [Given(@"Launch Lenovo Vantage")]
        public void GivenLaunchLenovoVantage()
        {
            var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            _webDriver = new InformationalWebDriver(session, session);
            VantageCommonHelper.OObeNetVantage30(session, true);
        }

        [StepDefinition(@"Launch vantage without OOBE")]
        public void LaunchVantageWithProtocol()
        {
            //VantageUI.instance.modifyConfigJsonFile(GetValueFromConfig("Server"));//确保server指向正确
            var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
            _webDriver = new InformationalWebDriver(session, session);
            Thread.Sleep(2000);
            UnManagedAPI.MaxmizeWindow("ApplicationFrameHost");
            VantageCommonHelper.FlushGifContainer(session);
        }

        private static string GetValueFromConfig(String value)
        {
            string environment = "";
            using (FileStream fileStream = new FileStream(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestCycleRequirement.json"), FileMode.Open, FileAccess.Read))
            using (StreamReader sr = new StreamReader(fileStream))
            {
                environment = sr.ReadToEnd();
            }
            JObject joEnvironmentRequirement = JObject.Parse(environment);
            string VantagePackagePath = joEnvironmentRequirement.GetValue(value).ToString();
            return VantagePackagePath;
        }

        [Given(@"turn (.*) the Allow access to the camera toggle on this device")]
        public void GivenTurnOffTheAllowAccessToTheCameraToggleOnThisDevice(String Status)
        {
            if (Status.Equals("off"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(Constants.Camera_Regitky64, "Deny", false);
            }
            if (Status.Equals("on"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(Constants.Camera_Regitky64, "Allow", false);
            }
        }

        [Given(@"turn (.*) the Allow access to the microphone toggle on this device")]
        public void GivenTurnOffTheAllowAccessToTheMicrophoneToggleOnThisDevice(String Status)
        {
            if (Status.Equals("off"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(Constants.Microphone_Regitky64, "Deny", false);
            }
            if (Status.Equals("on"))
            {
                RegistryHelp.SetRegistryKeyValuePlus(Constants.Microphone_Regitky64, "Allow", false);
            }
        }

        [Given(@"(.*) camera driver")]
        public void DisableCameraDriver(string status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            string driverId = _hsQuickSettingsPage.GetDeviceID("Integrated Camera");
            if (status == "disable")
            {
                _hsQuickSettingsPage.ActionDriver(driverId, "Disable");
            }
            else
            {
                _hsQuickSettingsPage.ActionDriver(driverId);
            }
        }

        [StepDefinition(@"turn (.*) the Allow apps to access your camera")]
        public void GivenTurnOnTheAllowAppsToAccessYourCamera(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetLocationService("on", "ms-settings:privacy-webcam", "Camera");
            }
            else
            {
                SettingsBase.SetLocationService("off", "ms-settings:privacy-webcam", "Camera");
            }
        }

        [StepDefinition(@"turn (.*) the Allow apps to access your Location")]
        public void GivenTurnOnTheAllowAppsToAccessYourLocation(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetLocationService("on", "ms-settings:privacy-location", "Location");
            }
            else
            {
                SettingsBase.SetLocationService("off", "ms-settings:privacy-location", "Location");
            }
        }

        [StepDefinition(@"turn (.*) the Allow apps to access your microphone")]
        public void GivenTurnOnTheAllowAppsToAccessYourMicrophone(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetLocationService("on", "ms-settings:privacy-microphone", "Microphone");
            }
            else
            {
                SettingsBase.SetLocationService("off", "ms-settings:privacy-microphone", "Microphone");
            }
        }

        [StepDefinition(@"turn (.*) the Allow apps to access your file system")]
        public void allowAppsToAccessYourFileSystem(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetLocationService("on", "ms-settings:privacy-broadfilesystemaccess", "FileSystem");
            }
            else
            {
                SettingsBase.SetLocationService("off", "ms-settings:privacy-broadfilesystemaccess", "FileSystem");
            }
        }

        [Given(@"turn (.*) the Allow desktop apps to access your camera")]
        public void GivenTurnOnTheAllowDesktopAppsToAccessYourCamera(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetAllowDestopAppToAccess("on", "ms-settings:privacy-webcam", "Camera_ClassicGlobal");
            }
            else
            {
                SettingsBase.SetAllowDestopAppToAccess("off", "ms-settings:privacy-webcam", "Camera_ClassicGlobal");
            }
        }

        [Given(@"turn (.*) the Allow desktop apps to access your microphone")]
        public void GivenTurnOnTheAllowDesktopAppsToAccessYourMicrophone(String Status)
        {
            if (Status.Equals("on"))
            {
                SettingsBase.SetAllowDestopAppToAccess("on", "ms-settings:privacy-microphone", "Microphone_ClassicGlobal");
            }
            else
            {
                SettingsBase.SetAllowDestopAppToAccess("off", "ms-settings:privacy-microphone", "Microphone_ClassicGlobal");
            }
        }

        [Given(@"turn (.*) Lenovo Vantage permission for Camera from system settings")]
        public void GivenTurnOnLenovoVantagePermissionForCameraFromSystemSettings(String Status)
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:privacy-webcam");
            Thread.Sleep(5000);
            if (Status.Equals("on"))
            {
                VantageCommonHelper.SetVantageLocationToggleSwitchStatus("On");
            }
            if (Status.Equals("off"))
            {
                VantageCommonHelper.SetVantageLocationToggleSwitchStatus("Off");
            }
        }

        [Given(@"turn (.*) Lenovo Vantage permission for Microphonefrom system settings")]
        public void GivenTurnOffLenovoVantagePermissionForMicrophonefromSystemSettings(String Status)
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:privacy-microphone");
            Thread.Sleep(5000);
            if (Status.Equals("on"))
            {
                VantageCommonHelper.SetVantageLocationToggleSwitchStatus("On");
            }
            if (Status.Equals("off"))
            {
                VantageCommonHelper.SetVantageLocationToggleSwitchStatus("Off");
            }
        }

        [Given(@"turn (.*) Airplane on Quick settings")]
        public void GivenTurnOnAirplaneOnQuickSettings(string Status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            WindowsElement cameraOnButton = _hsQuickSettingsPage.cameraOnButton;
            WindowsElement cameraOffButton = _hsQuickSettingsPage.cameraOffButton;
            if (Status.Equals("on"))
            {
                if (cameraOffButton != null)
                {
                    _hsQuickSettingsPage.cameraOffButton.Click();
                }
                else
                {
                    Assert.IsNotNull(cameraOnButton);
                }
            }
            if (Status.Equals("off"))
            {
                if (cameraOnButton != null)
                {
                    _hsQuickSettingsPage.cameraOnButton.Click();
                }
                else
                {
                    Assert.IsNotNull(cameraOffButton);
                }
            }
        }

        [Given(@"turn (.*) Camera on Quick settings")]
        [When(@"turn (.*) Camera on Quick settings")]
        public void WhenTurnOnCameraOnQuickSettings(String Status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            WindowsElement cameraOnButton = _hsQuickSettingsPage.cameraOnButton;
            WindowsElement cameraOffButton = _hsQuickSettingsPage.cameraOffButton;
            if (Status.Equals("on"))
            {
                if (VantageTypePlan == VantageType.LE)
                {
                    _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                    Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.On);
                    Assert.IsTrue(result, "Turn on is failed");
                }
                else
                {
                    if (cameraOffButton != null)
                    {
                        _hsQuickSettingsPage.cameraOffButton.Click();
                    }
                    else
                    {
                        Assert.IsNotNull(cameraOnButton);
                    }
                }
            }
            if (Status.Equals("off"))
            {
                if (VantageTypePlan == VantageType.LE)
                {
                    _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                    Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.Off);
                    Assert.IsTrue(result, "Turn off is failed");
                }
                else
                {
                    if (cameraOnButton != null)
                    {
                        _hsQuickSettingsPage.cameraOnButton.Click();
                    }
                    else
                    {
                        Assert.IsNotNull(cameraOffButton);
                    }
                }
            }
        }

        [StepDefinition(@"turn (.*) Camera Privacy from Display and Camera page")]
        public void WhenTurnOffCameraPrivacyFromDisplayAndCameraPage(String Status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            _hsQuickSettingsPage.HSDispalyCameraPage_Title.Click();
            _hsQuickSettingsPage.CameraLink.Click();
            Assert.NotNull(_hsQuickSettingsPage.cameraPrivacyMode_Toggle, "The cameraPrivacyMode_Toggle not found");
            ToggleState toggleState = VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle);
            switch (Status.ToLower())
            {
                case "on":
                    SetCheckBoxStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle, ToggleState.On, _webDriver.Session);
                    Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle), "Turn on toggle fail.");
                    break;
                case "off":
                    SetCheckBoxStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle, ToggleState.Off, _webDriver.Session);
                    Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle), "Turn off toggle fail.");
                    break;
                default:
                    Assert.Fail("WhenTurnOffCameraPrivacyFromDisplayAndCameraPage() no run,info:" + Status);
                    break;
            }
            return;
            if (Status.Equals("on"))
            {
                if (toggleState == ToggleState.Off)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle, ToggleState.On);
                    Assert.IsTrue(result, "Failed to switch Camera Privacy toggle status to " + ToggleState.On.ToString());
                }
                Assert.AreEqual(ToggleState.On, toggleState, "From Display and Camera page, The expected status of Camera Privacy is " + ToggleState.On + ". But actual was " + toggleState);
            }
            if (Status.Equals("off"))
            {
                if (toggleState == ToggleState.On)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.cameraPrivacyMode_Toggle, ToggleState.Off);
                    Assert.IsTrue(result, "Failed to switch Camera Privacy toggle status to " + ToggleState.Off.ToString());
                }
                Assert.AreEqual(ToggleState.Off, toggleState, "From Display and Camera page, The expected status of Camera Privacy is " + ToggleState.Off + ". But actual was " + toggleState);
            }
        }

        [StepDefinition(@"verify 'Camera Privacy Mode' toggle shows up")]
        public void verifyCameraPrivacyModeToggle()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsTrue(_hsQuickSettingsPage.cameraPrivacyMode_Toggle != null);

        }

        [Given(@"turn on camera")]
        public void GivenTurnOnCamera()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.cameraButtonOff);
            _hsQuickSettingsPage.cameraOffButton.Click();
        }

        [Given(@"turn on microphone")]
        public void GivenTurnOnMicrophone()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            WindowsElement microphoneButtonOff = _hsQuickSettingsPage.microphoneButtonOff;
            WindowsElement microphoneButtonOn = _hsQuickSettingsPage.microphoneButtonOn; ;
            if (microphoneButtonOff != null)
            {
                _hsQuickSettingsPage.microphoneOffButton.Click();
            }
            else
            {
                Assert.IsNotNull(microphoneButtonOn);
            }
        }

        [Given(@"Set '(.*)' function status is on or off '(.*)'")]
        public void GivenSetFunctionStatusIsOnOrOff(string func, string status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            bool result = false;
            if (!(VantageTypePlan == VantageType.LE))
            {
                status = status.ToLower() + "-state";
            }
            switch (func.ToLower())
            {
                case "camera":
                    Assert.NotNull(VantageTypePlan == VantageType.LE ? _hsQuickSettingsPage.QuickSettingsCameraToggle : _hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found");
                    if (VantageTypePlan == VantageType.LE)
                    {
                        if (status.ToLower() == "on")
                        {
                            try
                            {
                                result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.On);
                            }
                            catch (Exception ex)
                            {
                                if (ex.ToString() == "An element command failed because the referenced element is no longer attached to the DOM.")
                                {
                                    result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.On);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.Off);
                            }
                            catch (Exception ex)
                            {
                                if (ex.ToString() == "An element command failed because the referenced element is no longer attached to the DOM.")
                                {
                                    result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle, ToggleState.Off);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId").Contains(status.ToLower()) == false)
                        {
                            _hsQuickSettingsPage.QuickSettingsCameraXpath.Click();
                        }
                        Thread.Sleep(1000);
                        Assert.True(_hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId").Contains(status.ToLower()), "GivenSetFunctionStatusIsOnOrOff fail,info:" + _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"));
                    }
                    break;
                case "microphone":
                    Assert.NotNull(VantageTypePlan == VantageType.LE ? _hsQuickSettingsPage.QuickSettingsMicrphoneToggle : _hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found");
                    if (VantageTypePlan == VantageType.LE)
                    {
                        if (status.ToLower() == "on")
                        {
                            try
                            {
                                result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, ToggleState.On);
                            }
                            catch (Exception ex)
                            {
                                if (ex.ToString() == "An element command failed because the referenced element is no longer attached to the DOM.")
                                {
                                    result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, ToggleState.On);
                                }
                            }
                        }
                        else
                        {
                            try
                            {
                                result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, ToggleState.Off);
                            }
                            catch (Exception ex)
                            {
                                if (ex.ToString() == "An element command failed because the referenced element is no longer attached to the DOM.")
                                {
                                    result = VantageCommonHelper.SwitchToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, ToggleState.Off);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (_hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId").Contains(status.ToLower()) == false)
                        {
                            _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.Click();
                        }
                        Thread.Sleep(1000);
                        Assert.True(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId").Contains(status.ToLower()), "GivenSetFunctionStatusIsOnOrOff fail,info:" + _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"));
                    }
                    break;
                default:
                    Assert.Fail("The GivenSetFunctionStatusIsOnOrOff() no run,info:" + func);
                    break;
            }
        }

        [Then(@"Check '(.*)' function status is right '(.*)'")]
        public void ThenCheckFunctionStatusIsRight(string func, string status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (!(VantageTypePlan == VantageType.LE))
            {
                status = status.ToLower() + "-state";
            }
            switch (func.ToLower())
            {
                case "camera":
                    if (VantageTypePlan == VantageType.LE)
                    {
                        if (status.ToLower() == "on")
                        {
                            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle), ToggleState.On, "The QuickSettingsCameraToggle state is not on");
                        }
                        else
                        {
                            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle), ToggleState.Off, "The QuickSettingsCameraToggle state is on");
                        }
                    }
                    else
                    {
                        Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found");
                        Assert.True(_hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId").Contains(status.ToLower()), "GivenSetFunctionStatusIsOnOrOff fail,info:" + _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"));
                    }
                    break;
                case "microphone":
                    if (VantageTypePlan == VantageType.LE)
                    {
                        if (status.ToLower() == "on")
                        {
                            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle), ToggleState.On, "The QuickSettingsMicrphoneToggle state is not on");
                        }
                        else
                        {
                            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle), ToggleState.Off, "The QuickSettingsMicrphoneToggle state is on");
                        }
                    }
                    else
                    {
                        Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found");
                        Assert.True(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId").Contains(status.ToLower()), "GivenSetFunctionStatusIsOnOrOff fail,info:" + _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"));
                    }
                    break;
                default:
                    Assert.Fail("The GivenSetFunctionStatusIsOnOrOff() no run,info:" + func);
                    break;
            }
        }

        [Then(@"Check '(.*)' function status is right within toolbar '(.*)'")]
        public void ThenCheckFunctionStatusIsRightWithinToolbar(string func, string status)
        {
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            switch (func.ToLower())
            {
                case "camera":
                    WindowsElement camera = FindElementByTimes(_appsion, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    Assert.NotNull(camera, "The camera element not found within toolbar");
                    Assert.AreEqual(status.ToLower() == "on" ? "Camera privacy mode on." : "Camera privacy mode off.", camera.GetAttribute("Name"), "Camera status incorrect.");
                    break;
                case "microphone":
                    WindowsElement microphone = FindElementByTimes(_appsion, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Microphone).ToString());
                    Assert.NotNull(microphone, "The microphone element not found within toolbar");
                    Assert.AreEqual(status.ToLower() == "on" ? "Microphone on." : "Microphone off.", microphone.GetAttribute("Name"), "Microphone status incorrect.");
                    break;
                default:
                    Assert.Fail("ThenCheckFunctionStatusIsRightWithinToolbar() no run,info:" + func);
                    break;
            }
        }

        [StepDefinition(@"close lenovo vantage")]
        public void WhenCloseLenovoVantage()
        {
            //string windowsName = VantageConstContent.VantageTypePlan != VantageConstContent.VantageType.LE ? "Lenovo Vantage" : "Commercial Vantage";
            //IntPtr intPtr = UnManagedAPI.FindWindow("ApplicationFrameWindow", windowsName);
            //UnManagedAPI.SendMessage(intPtr, UnManagedAPI.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
            Common.KillProcess(VantageConstContent.VantageProcessName, true);
        }

        [When(@"click camera access no button")]
        public void WhenClickCameraAccessNoButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var cameraccessnobtn = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.CHSWindowNoBtn);
            Assert.IsNotNull(cameraccessnobtn);
            cameraccessnobtn.Click();
        }

        [When(@"click camera access yes button")]
        public void WhenClickCameraAccessYesButton()
        {
            var cameraccessyesbtn = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.CHSWindowYesBtn);
            Assert.IsNotNull(cameraccessyesbtn);
            cameraccessyesbtn.Click();
        }

        [When(@"click microphone access no button")]
        public void WhenClickMicrophoneAccessNoButton()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            var microphoneaccessnobtn = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.CHSWindowNoBtn);
            Assert.IsNotNull(microphoneaccessnobtn);
            microphoneaccessnobtn.Click();
        }

        [When(@"Maxmize Vantage")]
        public void WhenMaxmizeVantage()
        {
            _webDriver.Session.Manage().Window.Maximize();
        }

        [StepDefinition(@"enable camera total access")]
        public void WhenEnableCameraTotalAccess()
        {
            SettingsBase.SetLocationService("on", "ms-settings:privacy-webcam", "Camera");
        }

        [StepDefinition(@"disable camera total access")]
        public void WhenDisableCameraTotalAccess()
        {
            SettingsBase.SetLocationService("off", "ms-settings:privacy-webcam", "Camera");
        }

        [StepDefinition(@"enable microphone total access")]
        public void WhenEnableMicrophoneTotalAccess()
        {
            SettingsBase.SetLocationService("on", "ms-settings:privacy-microphone", "Microphone");
        }

        [StepDefinition(@"disable microphone total access")]
        public void WhenDisableMicrophoneTotalAccess()
        {
            SettingsBase.SetLocationService("off", "ms-settings:privacy-microphone", "Microphone");
        }

        [StepDefinition(@"enable camera access")]
        public void WhenEnableCameraAccess()
        {
            //VantageCommonHelper.OpenCmdRunCommand("ms-settings:privacy-webcam");
            Process.Start("ms-settings:privacy-webcam");
            VantageCommonHelper.SetVantageLocationToggleSwitchStatus("On");
            VantageCommonHelper.CloseSettingsWindow();
        }

        [StepDefinition(@"enable microphone access")]
        public void WhenEnableMicrophoneAccess()
        {
            //VantageCommonHelper.OpenCmdRunCommand("ms-settings:privacy-microphone");
            Process.Start("ms-settings:privacy-microphone");
            VantageCommonHelper.SetVantageLocationToggleSwitchStatus("On");
            VantageCommonHelper.CloseSettingsWindow();
        }

        [StepDefinition(@"disable camera access")]
        public void WhenDisableCameraAccess()
        {
            //VantageCommonHelper.OpenCmdRunCommand("ms-settings:privacy-webcam");
            Process.Start("ms-settings:privacy-webcam");
            VantageCommonHelper.SetVantageLocationToggleSwitchStatus("Off");
            VantageCommonHelper.CloseSettingsWindow();

        }

        [StepDefinition(@"disable microphone access")]
        public void WhenDisableMicrophoneAccess()
        {
            //VantageCommonHelper.OpenCmdRunCommand("ms-settings:privacy-microphone");
            Process.Start("ms-settings:privacy-microphone");
            VantageCommonHelper.SetVantageLocationToggleSwitchStatus("Off");
            VantageCommonHelper.CloseSettingsWindow();
        }

        [When(@"click Update button")]
        public void WhenClickUpdateButton()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.updateButton, "the updateButton not found");
            _hsQuickSettingsPage.updateButton.Click();
        }

        [When(@"into Dashboard page")]
        public void WhenIntoDashboardPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.dashboardLink, "the dashboardLink not found");
            _hsQuickSettingsPage.dashboardLink.Click();
        }

        [When(@"Click camera access tips")]
        public void WhenClickCameraAccessTips()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.cameraAccessTip, "the cameraAccessTip not found");
            _hsQuickSettingsPage.cameraAccessTip.Click();
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [When(@"Click microphone access tips")]
        public void WhenClickMicrophoneAccessTips()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.microphoneAccessTip, "the microphoneAccessTip not found");
            _hsQuickSettingsPage.microphoneAccessTip.Click();
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [When(@"Click microphone camera access tips")]
        public void WhenClickMicrophoneCameraAccessTips()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.microphoneCameraAccessTip, "the microphoneCameraAccessTip not found");
            _hsQuickSettingsPage.microphoneCameraAccessTip.Click();
            Thread.Sleep(TimeSpan.FromSeconds(6));
        }

        [When(@"Click My Device Settings Link on dashboard")]
        public void WhenClickMyDeviceSettingsLinkOnDashboard()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard);
            _hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard.Click();
        }

        [Then(@"The Text Display '(.*)' on Dashboard")]
        public void ThenTheTextDisplayOnDashboard(string p0)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.AreEqual(p0, _hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard));
        }

        [When(@"Double click My Device Settings Link on dashboard")]
        public void WhenDoubleClickMyDeviceSettingsLinkOnDashboard()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.myDeviceSettingsLinkElementOnDashboard);
            Thread.Sleep(5000);
            //VantageCommonHelper.DoubleClick(_hsQuickSettingsPage.myDeviceSettingsLinkElementOnDashboard);
            WindowsElement myDeviceSettingsLinkElementOnDashboard = _hsQuickSettingsPage.myDeviceSettingsLinkElementOnDashboard;
            VantageCommonHelper.DoubleClick(myDeviceSettingsLinkElementOnDashboard);
            Thread.Sleep(5000);
        }

        [Then(@"support Microphone function")]
        public void ThenSupportMicrophoneFunction()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (VantageTypePlan == VantageType.LE)
            {
                Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle, "The microphone element not found.");
            }
            else
            {
                Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found.");
            }
        }

        [Given(@"support Camera function")]
        [Then(@"support Camera function")]
        public void ThenSupportCameraFunction()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (VantageTypePlan == VantageType.LE)
            {
                Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The camera element not found.");
            }
            else
            {
                Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found.");
            }
        }

        [Then(@"Switch '(.*)' times Settings To Dashboard")]
        public void ThenSwitchTimesSettingsToDashboard(int p0)
        {
            var hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            hsPowerSettingsPage.GoToMyDevicesSettings();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            for (int i = 0; i < p0; i++)
            {
                var hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                hsQuickSettingsPage.dashboardLink.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Assert.IsNotNull(hsQuickSettingsPage.dashboardLink);
                hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                hsPowerSettingsPage.GoToMyDevicesSettings();
                Assert.IsNotNull(hsQuickSettingsPage.JumptoBatterySettingsEle);

            }

        }

        [Then(@"Switch '(.*)' times Settings To Dashboard Click Update button")]
        public void ThenSwitchTimesSettingsToDashboardClickUpdateButton(int p0)
        {
            var hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
            hsPowerSettingsPage.GoToMyDevicesSettings();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            for (int i = 0; i < p0; i++)
            {
                var hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                hsQuickSettingsPage.dashboardLink.Click();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                Assert.IsNotNull(_hsQuickSettingsPage.updateButton);
                hsQuickSettingsPage.updateButton.Click();
                var systemUpdatePage = new HSSystemUpdatePage(_webDriver.Session);
                Assert.IsNotNull(_systemUpdatePage.updateHeaderTitle);
                Assert.IsNotNull(_systemUpdatePage.checkForUpdateButton);
                Assert.IsNotNull(hsQuickSettingsPage.dashboardLink);
                hsPowerSettingsPage = new HSPowerSettingsPage(_webDriver.Session);
                hsPowerSettingsPage.GoToMyDevicesSettings();
                Assert.IsNotNull(hsQuickSettingsPage.JumptoBatterySettingsEle);
            }
        }


        [Then(@"check Camera clickable")]
        public void ThenCheckCameraClickable()
        {
            var enablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
            var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
            if (enablecamera != null)
            {
                enablecamera.Click();
                var disablecamera2 = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
                Assert.IsNotNull(disablecamera2);
            }
            else if (disablecamera != null)
            {
                disablecamera.Click();
                var enablecamera2 = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
                Assert.IsNotNull(enablecamera2);
            }
            else if (enablecamera == null && disablecamera == null)
            {
                Assert.IsNotNull(enablecamera);
            }
            Thread.Sleep(5 * 1000);
        }

        [Then(@"check Microphone clickable")]
        public void ThenCheckMicrophoneClickable()
        {
            var enablemicrophone = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.MicrophoneOnBtnXpath);
            var disablemicrophone = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.MicrophoneOffBtnXpath);
            if (enablemicrophone != null)
            {
                enablemicrophone.Click();
                disablemicrophone = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.MicrophoneOffBtnXpath);
                Assert.IsNotNull(disablemicrophone);
            }
            else if (disablemicrophone != null)
            {
                disablemicrophone.Click();
                enablemicrophone = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.MicrophoneOnBtnXpath);
                Assert.IsNotNull(enablemicrophone);
            }
            else if (enablemicrophone == null && disablemicrophone == null)
            {
                Assert.IsNotNull(enablemicrophone);
            }
            Thread.Sleep(5 * 1000);
        }

        [Then(@"unsupport Camera function")]
        public void ThenUnsupportCameraFunction()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsFalse(_hsQuickSettingsPage.cameraFunction.Displayed);
        }

        [Then(@"Check camera disable")]
        public void ThenCheckCameraDisable()
        {
            Thread.Sleep(TimeSpan.FromSeconds(5));
            var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.CameraBtnXpath);
            Assert.IsNotNull(disablecamera);
        }

        [Then(@"Check Camera button not show under Quick Settings")]
        public void ThenCheckCameraButtonNotShowUnderQuickSettings()
        {
            var enablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
            var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
            Assert.IsNull(enablecamera);
            Assert.IsNull(disablecamera);
        }

        [Then(@"The Quick Settings display the Camera button")]
        public void ThenTheQuickSettingsDisplayTheCameraButton()
        {
            if (VantageConstContent.VantageTypePlan == VantageType.LE)
            {
                _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
            }
            else
            {
                var enablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
                var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
                if (enablecamera != null)
                {
                    Assert.IsNotNull(enablecamera);
                }
                else
                {
                    Assert.IsNotNull(disablecamera);
                }
            }
        }

        [When(@"Set System To '(.*)'")]
        public void WhenSetSystemTo(string action)
        {
            if (action.ToLower().Equals("hibernate"))
            {
                _vantageBase.EnterS4();
            }
            else if (action.ToLower().Equals("sleep"))
            {
                _vantageBase.EnterS3();
            }
        }

        [Given(@"The button display normal")]
        public void GivenTheButtonDisplayNormal()
        {
            if (VantageTypePlan == VantageType.LE)
            {
                _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
            }
            else
            {
                var enablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
                var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
                if (enablecamera != null)
                {
                    Assert.IsNotNull(enablecamera);
                }
                else
                {
                    Assert.IsNotNull(disablecamera);
                }
            }
        }

        [Then(@"The Quick Settings display the Camera as (.*) status")]
        public void ThenTheQuickSettingsDisplayTheCameraAsOnStatus(String Status)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (Status.Equals("On"))
            {
                if (VantageConstContent.VantageTypePlan == VantageType.LE)
                {
                    Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
                    Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle), ToggleState.On, "The togglestate is not on");
                }
                else
                {
                    var enablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OnCameraXpath);
                    Assert.IsNotNull(enablecamera);
                }
            }
            else
            {
                if (VantageConstContent.VantageTypePlan == VantageType.LE)
                {
                    Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettings cameratoggle is not display.");
                    Assert.AreEqual(VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsCameraToggle), ToggleState.Off, "The togglestate is not off");
                }
                else
                {
                    var disablecamera = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.OffCameraXpath);
                    Assert.IsNotNull(disablecamera);
                }
            }
        }

        [Then(@"Check microphone disable")]
        public void ThenCheckMicrophoneDisable()
        {
            Thread.Sleep(5000);
            var disablemicrophone = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.MicrophoneBtnXpath);
            Assert.IsNotNull(disablemicrophone);
        }

        [Then(@"Check '(.*)' Function status is correct '(.*)' and tips shown or hidden '(.*)'")]
        public void ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden(string func, string status, string display)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            bool isShow = display.ToLower() == "shown" ? true : false;
            bool isNormalShow = status.ToLower() == "disable" ? false : true;
            switch (func.ToLower())
            {
                case "camera":
                    if (!(VantageTypePlan == VantageType.LE))
                    {
                        Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found");
                    }
                    if (isNormalShow)
                    {
                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettingsCameraToggle is not find");
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraTitle, "The QuickSettingsCameraTitle is not find");
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsCameraIcon, "The QuickSettingsCameraIcon is not find");
                        }
                        else
                        {
                            Assert.False(_hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId").Contains("disable-state"), "ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden fail,info:" + _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"));
                        }
                    }
                    else
                    {

                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.IsNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The QuickSettingsCameraToggle is find");
                            Assert.IsNull(_hsQuickSettingsPage.QuickSettingsCameraTitle, "The QuickSettingsCameraTitle is find");
                            Assert.IsNull(_hsQuickSettingsPage.QuickSettingsCameraIcon, "The QuickSettingsCameraIcon is find");
                        }
                        else
                        {
                            Assert.True(_hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId").Contains(status.ToLower() + "-state"), "ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden fail,info:" + _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"));
                        }
                    }
                    if (isShow)
                    {
                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.IsNull(_hsQuickSettingsPage.QuickSettingsCameraAccessTipDesc, "the QuickSettingsCameraAccessTipDesc is found");
                            Assert.IsNull(_hsQuickSettingsPage.cameraAccessTip, "the cameraAccessTip is found");
                        }
                        else
                        {
                            Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraAccessTipDesc, "the QuickSettingsCameraAccessTipDesc not found");
                            Assert.NotNull(_hsQuickSettingsPage.cameraAccessTip, "the cameraAccessTip not found");
                            Assert.AreEqual("Go to Windows settings to give access", _hsQuickSettingsPage.cameraAccessTip.GetAttribute("Name"), "Camera Access link text incorrect");
                        }
                    }
                    else
                    {
                        Assert.Null(_hsQuickSettingsPage.cameraAccessTip, "the cameraAccessTip still show");
                    }
                    break;
                case "microphone":
                    Assert.NotNull(VantageTypePlan == VantageType.LE ? _hsQuickSettingsPage.QuickSettingsMicrphoneToggle : _hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found");
                    if (isNormalShow)
                    {
                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneTitle, "The QuickSettingsMicrphoneTitle is not find");
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneIcon, "The QuickSettingsMicrphoneIcon is not find");
                            Assert.IsTrue(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle.Enabled, "The mircophone toggle is grey out");
                        }
                        else
                        {
                            Assert.False(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId").Contains("disable-state"), "ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden fail,info:" + _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"));
                        }
                    }
                    else //disabled
                    {
                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneTitle, "The QuickSettingsMicrphoneTitle is not find");
                            Assert.IsNotNull(_hsQuickSettingsPage.QuickSettingsMicrphoneIcon, "The QuickSettingsMicrphoneIcon is not find");
                            Assert.IsFalse(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle.Enabled, "The mircophone toggle is not grey out");
                        }
                        else
                        {
                            Assert.True(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId").Contains(status.ToLower() + "-state"), "ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden fail,info:" + _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"));
                        }
                    }
                    if (isShow)
                    {
                        if (VantageTypePlan == VantageType.LE)
                        {
                            Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrophoneAccessTipDescLe, "the QuickSettingsMicrophoneAccessTipDesc not found");
                            Assert.NotNull(_hsQuickSettingsPage.microphoneAccessTip, "the microphoneAccessTip not found");
                            Assert.AreEqual("Go to Windows settings to give access", _hsQuickSettingsPage.microphoneAccessTip.GetAttribute("Name"), "Microphone Access link text incorrect");
                        }
                        else
                        {
                            Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrophoneAccessTipDesc, "the QuickSettingsMicrophoneAccessTipDesc not found");
                            Assert.NotNull(_hsQuickSettingsPage.microphoneAccessTip, "the microphoneAccessTip not found");
                            Assert.AreEqual("Go to Windows settings to give access", _hsQuickSettingsPage.microphoneAccessTip.GetAttribute("Name"), "Microphone Access link text incorrect");
                        }
                    }
                    else
                    {
                        Assert.Null(_hsQuickSettingsPage.microphoneAccessTip, "the microphoneAccessTip still show");
                    }
                    break;
                case "camera not exist":
                    Assert.Null(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element still shown");
                    Assert.Null(_hsQuickSettingsPage.cameraAccessTip, "the cameraAccessTip still show");
                    break;
                case "microphone not exist":
                    Assert.Null(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element still shown");
                    Assert.Null(_hsQuickSettingsPage.microphoneAccessTip, "the microphoneAccessTip still show");
                    break;
                default:
                    Assert.Fail("The ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden() no run,info:" + func);
                    break;
            }
        }
        [Then(@"The '(.*)' button is clickable or unclickable '(.*)'")]
        public void ThenTheButtonIsClickableOrUnclickable(string func, string clickstatus)
        {
            string autoid = null;
            ToggleState st = ToggleState.Indeterminate;
            bool isClick = clickstatus == "clickable" ? true : false;
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            switch (func.ToLower())
            {
                case "camera":
                    if (!(VantageTypePlan == VantageType.LE))
                    {
                        Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found");
                    }
                    if (VantageTypePlan == VantageType.LE)
                    {
                        Assert.IsNull(_hsQuickSettingsPage.QuickSettingsCameraToggle, "The quicksettingscameratoggle is find");
                    }
                    else
                    {
                        autoid = _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId");
                        _hsQuickSettingsPage.QuickSettingsCameraXpath.Click();
                        if (isClick)
                        {
                            Assert.AreNotEqual(autoid, _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"), "The QuickSettingsCameraXpath unclickable");
                        }
                        else
                        {
                            Assert.AreEqual(autoid, _hsQuickSettingsPage.QuickSettingsCameraXpath.GetAttribute("AutomationId"), "The QuickSettingsCameraXpath clickable");
                        }
                    }
                    break;
                case "microphone":
                    Assert.NotNull(VantageTypePlan == VantageType.LE ? _hsQuickSettingsPage.QuickSettingsMicrphoneToggle : _hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found");
                    if (VantageTypePlan == VantageType.LE)
                    {
                        st = VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle);
                        _hsQuickSettingsPage.QuickSettingsMicrphoneToggle.Click();
                        if (isClick)
                        {
                            Assert.AreNotEqual(st, VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle), "The QuickSettingsMicrphoneToggle unclickable");
                        }
                        else
                        {
                            Assert.AreEqual(st, VantageCommonHelper.GetToggleStatus(_hsQuickSettingsPage.QuickSettingsMicrphoneToggle), "The QuickSettingsMicrphoneToggle clickable");
                        }
                    }
                    else
                    {
                        autoid = _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId");
                        _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.Click();
                        if (isClick)
                        {
                            Assert.AreNotEqual(autoid, _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"), "The QuickSettingsCameraXpath unclickable");
                        }
                        else
                        {
                            Assert.AreEqual(autoid, _hsQuickSettingsPage.QuickSettingsMicrophoneXpath.GetAttribute("AutomationId"), "The QuickSettingsCameraXpath clickable");
                        }
                    }
                    break;
                default:
                    Assert.Fail("The ThenCheckFunctionStatusIsCorrectAndTipsShownOrHidden() no run,info:" + func);
                    break;
            }
        }


        [Then(@"Judge camera button cannot click")]
        public void ThenJudgeCameraButtonCannotClick()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.disableCamera);
            _hsQuickSettingsPage.disableCamera.Click();
            Assert.IsNotNull(_hsQuickSettingsPage.disableCamera);
        }

        [Then(@"Judge microphone button cannot click")]
        public void ThenJudgeMicrophoneButtonCannotClick()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.disableMicrophone);
            _hsQuickSettingsPage.disableMicrophone.Click();
            Assert.IsNotNull(_hsQuickSettingsPage.disableMicrophone);
        }

        [Then(@"Judge camera button clickable")]
        public void ThenJudgeCameraButtonClickable()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.cameraFunction);
            _hsQuickSettingsPage.cameraFunction.Click();
            Assert.IsNotNull(_hsQuickSettingsPage.cameraFunction);
        }

        [Then(@"Judge microphone button clickable")]
        public void ThenJudgeMicrophoneButtonClickable()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (_hsQuickSettingsPage.microphoneButtonOff != null)
            {
                _hsQuickSettingsPage.microphoneOffButton.Click();
                Assert.IsNotNull(_hsQuickSettingsPage.microphoneOnButton);
            }
            else if (_hsQuickSettingsPage.microphoneButtonOn != null)
            {
                _hsQuickSettingsPage.microphoneOnButton.Click();
                Assert.IsNotNull(_hsQuickSettingsPage.microphoneOffButton);
            }
        }

        [Then(@"Check Camera Access Tip Text '(.*)'")]
        public void ThenCheckBatteryHealthTitleDisplay(string jsonPath)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.CameraAccessTip, "Element 'Camera Access Tip' Is Not Found");
            Assert.IsTrue(_hsQuickSettingsPage.ShowTextbox(_hsQuickSettingsPage.CameraAccessTip).Contains(VantageAutomationIDCollector.Instance.GetVantageAutomationID(jsonPath).ToString()));
        }

        [Given(@"Close System Settings")]
        public void GivenCloseSystemSettings()
        {
            KillProcess("SystemSettings");
        }

        [Then(@"camera access tip exists")]
        public void ThenCameraAccessTipExists()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.cameraAccessTip);
        }

        [Then(@"Microphone access tip exists")]
        public void ThenMicrophoneAccessTipExists()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.microphoneAccessTip);
        }

        [Then(@"microphone camera access tip exists")]
        public void ThenMicrophoneCameraAccessTipExists()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.microphoneCameraAccessTip);
        }

        [Then(@"Microphones access tip exists")]
        public void ThenMicrophonesAccessTipExists()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.microphoneAccessTip);
        }

        [Then(@"Jump camera system access page")]
        public void ThenJumpCameraSystemAccessPage()
        {
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) < 22000)
            {
                var cameraPage = VantageCommonHelper.FindElementByIdAndMouseClick("SystemSettings_CapabilityAccess_Camera_UserGlobal_Group_GroupTitleTextBlock");
                Assert.IsNotNull(cameraPage);
            }
            else
            {
                //camera icon
                var cameraPage = VantageCommonHelper.FindElementByIdAndMouseClick("SystemSettings_CapabilityAccess_Camera_SystemGlobal_EntityItem");
                Assert.IsNotNull(cameraPage);
            }
        }

        [Then(@"Jump microphone system access page")]
        public void ThenJumpMicrophoneSystemAccessPage()
        {
            RegistryKey softwareRegedit = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            if (Convert.ToInt32(softwareRegedit.GetValue("CurrentBuildNumber")) < 22000)
            {
                var microphonePage = VantageCommonHelper.FindElementByIdAndMouseClick("SystemSettings_CapabilityAccess_Microphone_UserGlobal_Group_GroupTitleTextBlock");
                Assert.IsNotNull(microphonePage);
            }
            else
            {
                //microphone icon
                var microphonePage = VantageCommonHelper.FindElementByIdAndMouseClick("SystemSettings_CapabilityAccess_Microphone_SystemGlobal_EntityItem");
                Assert.IsNotNull(microphonePage);
            }
        }

        [Then(@"camera access confirm window exists")]
        public void ThenCameraAccessConfirmWindowExists()
        {
            var cameratitle = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.ConfirmWindow);
            Assert.IsNotNull(cameratitle);
            Assert.AreEqual("Let Lenovo Vantage access your camera?", cameratitle.Text);
        }

        [Then(@"microphone access confirm window exists")]
        public void ThenMicrophoneAccessConfirmWindowExists()
        {
            var microphonetitle = VantageCommonHelper.FindElementByXPath(_webDriver.Session, VantageConstContent.ConfirmWindow);
            Assert.IsNotNull(microphonetitle);
            Assert.AreEqual("Let Lenovo Vantage access your microphone?", microphonetitle.Text);
        }

        [Then(@"Camera button on Quick Setting always display off state for (.*)")]
        public void ThenCameraButtonOnQuickSettingAlwaysDisplayOffStateFor(int taskId)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _hsPowerSettingsPage.AddScreenshotIntoReport(taskId.ToString(), ".", "HSScreenShotResult");
        }

        [Then(@"Camera button on Quick Setting always display gray and Not show On Or Off text for (.*)")]
        public void ThenCameraButtonOnQuickSettingAlwaysDisplayGrayAndNotShowOnOrOffTextForVAN_Step(int taskId)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _hsPowerSettingsPage.AddScreenshotIntoReport(taskId.ToString(), ".", "HSScreenShotResult");
        }

        [Then(@"Microphone button on Quick Setting always display off state for (.*)")]
        public void ThenMicrophoneButtonOnQuickSettingAlwaysDisplayOffStateFor(int taskId)
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            _hsPowerSettingsPage.AddScreenshotIntoReport(taskId.ToString(), ".", "HSScreenShotResult");
        }

        [Then(@"Check My Device Settings Link on dashboard")]
        public void ThenCheckMyDeviceSettingsLinkOnDashboard()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.myDeviceSettingsLinkOnDashboard);
        }

        [Then(@"jump to the My Device Settings page")]
        public void ThenJumpToTheMyDeviceSettingsPage()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNotNull(_hsQuickSettingsPage.myDeviceSettingsHeaderTitle);
        }

        [Given(@"click AdvanceSettings link")]
        public void GivenClickAdvanceSettingsLink()
        {
            Thread.Sleep(TimeSpan.FromSeconds(10));
            hSInputPage = new HSInputPage(_webDriver.Session);
            hSInputPage.KBDTopRowTitle.Click();
            SendKeys.SendWait("{PGDN}");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            hSInputPage.AdvSettings_link.Click();
        }

        [Given(@"Reversing the default primary function toggle is (.*)")]
        public void GivenTurnOffReversingTheDefaultPrimaryFunctionToggle(string status)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatus = hSInputPage.ReversingDefaultPrimaryFunctionToggle.GetAttribute("Toggle.ToggleState");
            if (status.ToLower() == "on")
            {
                Assert.IsTrue(toggleStatus == "1", "ReversingTheDefaultPrimaryFunctionToggle should on");
            }
            else
            {
                Assert.IsTrue(toggleStatus == "0", "ReversingTheDefaultPrimaryFunctionToggle should off");
            }
        }

        [Given(@"turn on (.*) method")]
        public void GivenTurnOnNormalMethod(string status)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatus = hSInputPage.normalMethodRadio.GetAttribute("Toggle.ToggleState");
            if (status.ToLower() == "normal")
            {
                if (toggleStatus == "0")
                    hSInputPage.normalMethodRadio.Click();
            }
            else
            {
                if (toggleStatus == "1")
                    hSInputPage.FnStickyKeyMethodRadio.Click();
            }
        }


        [Then(@"the Top-row function button status is displayed same as Vantage")]
        public void ThenTheTop_RowFunctionButtonİsDisplayedAccordingToTheUISPEC()
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatusSpecialKey = hSInputPage.SpecialKeyRadio.GetAttribute("Toggle.ToggleState");
            var toggleStatusFunctionKey = hSInputPage.FunctionKeyRadio.GetAttribute("Toggle.ToggleState");
            if (toggleStatusSpecialKey == "1")
            {
                Assert.AreEqual("Special function enabled.", GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString()), "SpecialKeyRadio should display");
            }
            else if (toggleStatusFunctionKey == "1")
                Assert.AreEqual("F1-F12 function enabled.", GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString()), "F1-F12 should display");
            else
            {
                Assert.IsTrue(false, "SpecialKeyRadio and FunctionKeyRadio all not selected");
            }
        }

        [Then(@"the Top-row function button status is displayed same as Vantage for ideapad")]
        public void ThenTheTop_RowFunctionButtonStatusİsDisplayedSameAsVantageForİdeapad()
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            var toggleStatusSpecialKey = hSInputPage.SpecialKeyRadioIdeapad.GetAttribute("Toggle.ToggleState");
            var toggleStatusFunctionKey = hSInputPage.FunctionKeyRadioIdeapad.GetAttribute("Toggle.ToggleState");
            if (toggleStatusSpecialKey == "1")
            {
                Assert.AreEqual("Special function enabled.", GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString()), "SpecialKeyRadio should display");
            }
            else if (toggleStatusFunctionKey == "1")
                Assert.AreEqual("F1-F12 function enabled.", GetToolBarButtonName(Convert.ToInt32(ToolBarAutoEnum.TopRowKey).ToString()), "F1-F12 should display");
            else
            {
                Assert.IsTrue(false, "SpecialKeyRadio and FunctionKeyRadio all not selected");
            }
        }


        [Then(@"The Top-row function button display (.*) function status on vantage input page for ideapad")]
        public void ThenTheTop_RowFunctionButtonDisplaySpecialFunctionStatusOnVantageİnputPageForİdeapad(string func)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            if (func.ToLower() == "special")
                Assert.IsTrue(hSInputPage.SpecialKeyRadioIdeapad.GetAttribute("Toggle.ToggleState") == "1", "SpecialKeyRadio should selected");
            else
                Assert.IsTrue(hSInputPage.FunctionKeyRadioIdeapad.GetAttribute("Toggle.ToggleState") == "1", "FunctionKeyRadio should selected");
        }

        [Then(@"""(.*)"" Update function")]
        public void ThenUpdateFunction(string p0)
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            if (p0 == "support")
            {
                Assert.IsNotNull(_hsQuickSettingsPage.updateButton, "The update element not found");
                //Assert.AreEqual("Update",_hsQuickSettingsPage.updateButton.Text);
                Assert.IsTrue(_hsQuickSettingsPage.updateButton.Enabled, "The update status is disable");
            }
            else
            {
                Assert.IsNull(_hsQuickSettingsPage.updateButton, "The update element is found");
            }
        }


        [Then(@"check Update header title")]
        public void ThenCheckUpdateHeaderTitle()
        {
            _systemUpdatePage = new HSSystemUpdatePage(_webDriver.Session);
            Assert.IsNotNull(_systemUpdatePage.updateHeaderTitle, "The updateHeaderTitle not found");
            Assert.AreEqual("System Update", _systemUpdatePage.updateHeaderTitle.Text, "The updateHeaderTitle Text incorrect");
        }

        [Then(@"check completion degree")]
        public void ThenCheckCompletionDegree()
        {
            _systemUpdatePage = new HSSystemUpdatePage(_webDriver.Session);
            WindowsElement update = _systemUpdatePage.checkForUpdateButton;
            WindowsElement process = _systemUpdatePage.progressbar;
            WindowsElement install = _systemUpdatePage.SystemUpdateInstallNow;
            Assert.IsTrue(update != null || process != null || install != null, "The update、process、install element is null");
        }

        [When(@"turn (.*) Camera Privacy from Toolbar")]
        public void WhenTurnOffCameraPrivacyFromToolbar(String Status)
        {
            int i = 0;
            AutomationElement element = null;
            ToggleState toggleState = ToggleState.Indeterminate;
            HSSmartAssistPage hs = new HSSmartAssistPage(_webDriver.Session);
            WindowsDriver<WindowsElement> _appsion = hs.GetControlPanelSession(true);
            WindowsElement camera = FindElementByTimes(_appsion, "AutomationId", Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
            Assert.NotNull(camera, "The camera element not found within toolbar");
            switch (Status.ToLower())
            {
                case "on":
                    for (int trytime = 0; trytime < 5; trytime++)
                    {
                        if (camera.GetAttribute("Name") == "Camera privacy mode on.")
                        {
                            break;
                        }
                        camera.Click();
                        Thread.Sleep(500);
                    }
                    Assert.AreEqual("Camera privacy mode on.", camera.GetAttribute("Name"), "Turn on toggle fail.");
                    break;
                case "off":
                    for (int trytime = 0; trytime < 5; trytime++)
                    {
                        if (camera.GetAttribute("Name") == "Camera privacy mode off.")
                        {
                            break;
                        }
                        camera.Click();
                        Thread.Sleep(500);
                    }
                    Assert.AreEqual("Camera privacy mode off.", camera.GetAttribute("Name"), "Turn off toggle fail.");
                    break;
                default:
                    Assert.Fail("WhenTurnOffCameraPrivacyFromToolbar() no run,info:" + Status);
                    break;
            }
            return;
            if (Status.Equals("off"))
            {
                while (new SettingsBase().GetCameraStatusFromToolbarUsingLonName() == ToggleState.On && i < 3)
                {
                    element = VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    i++;
                }
                Assert.IsNotNull(element, "Fail to find Camera Privacy from toolbar.");
                toggleState = new SettingsBase().GetCameraStatusFromToolbarUsingLonName();
                Assert.AreEqual(ToggleState.Off, toggleState, "The expected Camera Privacy status from toolbar is " + ToggleState.Off.ToString() + ". But actual was: " + toggleState.ToString());
            }
            else
            {
                while (new SettingsBase().GetCameraStatusFromToolbarUsingLonName() == ToggleState.Off && i < 3)
                {
                    element = VantageCommonHelper.FindElementByIdAndMouseClick(Convert.ToInt32(ToolBarAutoEnum.Camera).ToString());
                    i++;
                }
                Assert.IsNotNull(element, "Fail to find Camera Privacy from toolbar.");
                toggleState = new SettingsBase().GetCameraStatusFromToolbarUsingLonName();
                Assert.AreEqual(ToggleState.On, toggleState, "The expected Camera Privacy status from toolbar is " + ToggleState.On.ToString() + ". But actual was: " + toggleState.ToString());
            }
        }

        [When(@"Press Win and D to Switch Page")]
        public void WhenPressWinAndDToSwitchPage()
        {
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.LWin, 0, 0, 0);
            Thread.Sleep(1000);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.D, 0, 0, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.LWin, 0, 2, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.D, 0, 2, 0);
            Thread.Sleep(3000);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.LWin, 0, 0, 0);
            Thread.Sleep(1000);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.D, 0, 0, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.LWin, 0, 2, 0);
            VantageCommonHelper.keybd_event(System.Windows.Forms.Keys.D, 0, 2, 0);
            Thread.Sleep(3000);
        }

        [Then(@"The Quick Settings title name show '(.*)'")]
        public void ThenTheQuickSettingsTitleNameShow(string text)
        {
            HSInputPage hSInputPage = new HSInputPage(_webDriver.Session);
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.NotNull(hSInputPage.QuickSettings, "The QuickSettings not found");
            Assert.AreEqual(text, hSInputPage.QuickSettings.Text, "The Quick Settings title name incorrect");
        }

        [Then(@"The Machine not display the Quick Settings Widget")]
        public void ThenTheMachineNotDisplayTheQuickSettingsWidget()
        {
            _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
            Assert.IsNull(_hsQuickSettingsPage.cameraOnButton, "cameraOnButton is not null");
            Assert.IsNull(_hsQuickSettingsPage.microphoneOnButton, "microphoneOnButton is not null");
            Assert.IsNull(_hsQuickSettingsPage.updateButton, "updateButton is not null");
        }

        [When(@"Mouse Hover on Button '(.*)' in Vantage")]
        public void WhenMouseHoverOnButtonInVantage(string p0)
        {
            WindowsElement tElement = null;
            switch (p0)
            {
                case "camera":
                    var audioPage = new HSAudioSettingsPage(_webDriver.Session);
                    tElement = audioPage.MicrophoenCheckbox;
                    Assert.IsFalse(tElement.Enabled);
                    break;
                case "microphone":
                    tElement = _hsQuickSettingsPage.microphoneOnButton;
                    break;
            }
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, tElement);
        }

        [Then(@"The Current page display correct '(.*)'")]
        public void ThenTheCurrentPageDisplayCorrect(string page)
        {
            switch (page.ToLower())
            {
                case "dashboard":
                    _hsQuickSettingsPage = new HSQuickSettingsPage(_webDriver.Session);
                    Assert.NotNull(_hsQuickSettingsPage.updateButton, "The update element not found");
                    Assert.NotNull(_hsQuickSettingsPage.QuickSettingsCameraXpath, "The camera element not found.");
                    Assert.NotNull(_hsQuickSettingsPage.QuickSettingsMicrophoneXpath, "The microphone element not found.");
                    break;
                case "power":
                    _hSToolbarPage = new HSToolbarPage(_webDriver.Session);
                    Assert.NotNull(_hSToolbarPage.JumpToToolbar, "The JumpToToolbar not found");
                    Assert.NotNull(_hSToolbarPage.ToolbardescriptionContext, "The ToolbardescriptionContexts not found");
                    Assert.NotNull(_hSToolbarPage.ToolbarToggle, "The ToolbarToggle not found");
                    break;
                case "comments & feedback":
                    _supportPage = new SupportPage(_webDriver.Session);
                    Assert.NotNull(_supportPage.DialogGiveFeedBackTitle, "The DialogGiveFeedBackTitle not found");
                    Assert.NotNull(_supportPage.DialogGiveFeedBackCloseBtn, "The DialogGiveFeedBackCloseBtn not found");
                    Assert.NotNull(_supportPage.DialogSendFeedBackBtn, "The DialogSendFeedBackBtn not found");
                    break;
                case "wi-fi security":
                    _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(_webDriver.Session);
                    if (_lenovoWifiSecurityPage.WSStatusText != null)
                    {
                        Assert.NotNull(_lenovoWifiSecurityPage.WSStatusText, "The WifiText not found");
                        Assert.NotNull(_lenovoWifiSecurityPage.WifiToggle, "The WifiToggle not found");
                    }
                    else
                    {
                        Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogAgreeBtn, "Location dialog has not pop up");
                        Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogCloseBtn, "Location dialog has not pop up");
                        Assert.IsNotNull(_lenovoWifiSecurityPage.LocationDialogCancelnBtn, "Location dialog has not pop up");
                    }
                    break;
                case "audio":
                    _hSAudioSettingsPage = new HSAudioSettingsPage(_webDriver.Session);
                    Assert.NotNull(_hSAudioSettingsPage.JumpMicrophoneLink, "The JumpMicrophoneLink not found");
                    Assert.NotNull(_hSAudioSettingsPage.AudioSmartSettingsJumpLink, "The AudioSmartSettingsJumpLink not found");
                    break;
                case "camera & display":
                    _hSDispalyCameraPage = new HSDispalyCameraPage(_webDriver.Session);
                    Assert.NotNull(_hSDispalyCameraPage.CameraLink, "The CameraLink not found");
                    Assert.NotNull(_hSDispalyCameraPage.CameraTitle, "The CameraTitle not found");
                    break;
                case "store":
                    Assert.True(Common.GetRunningProcess("WinStore.App"), "The WinStore App not open");
                    break;
                default:
                    Assert.Fail("ThenTheCurrentPageDisplayCorrect no run,info:" + page);
                    break;
            }
        }


    }
}
