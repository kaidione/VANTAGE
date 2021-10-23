namespace LenovoVantageTest.Pages
{
    using LenovoVantageTest.Helper;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows.Automation;
    using TangramTest.Utility;
    using Keys = System.Windows.Forms.Keys;

    public class HSInputPage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;
        private Hashtable _inputHT = new Hashtable();
        private Hashtable _inputHTSpec = new Hashtable();

        /// <summary>
        /// Q&A question 5
        /// </summary>
        public WindowsElement qAQuestion5Label => base.FindElementByTimes(session, "AutomationId", "sa-ov-widget-link-question-5");
        public WindowsElement qAQuestion5 => base.FindElementByTimes(session, "Name", "What should I do to enhance security protection?");

        /// <summary>
        /// Q&A question 5 Content
        /// </summary>

        public WindowsElement qAQuestion5_Content => base.FindElementByTimes(session, "Name", "What should I do to enhance security protection? We highly recommend you to have your devices protected by anti-virus software and firewall, set up UAC notification at minimum protection. And create strong passwords and manage in a secure way, encrypt your data while using public network as advanced protection.");

        /// <summary>
        /// Keyboard Backlight Title
        /// </summary>

        public WindowsElement keyboardBacklightTitle => base.FindElementByTimes(session, "AutomationId", "inputAccessories-backlight-title");
        public WindowsElement keyboardBacklightTitleOfThinkPad => base.FindElementByTimes(session, "AutomationId", "inputAccessories-backlight-thinkpad-title");
        public bool KeyboardBacklightTitleInputIsPresent => IsPresent(session, GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightTitleOnIdea"), 25);
        public bool KeyboardBacklightDescInputIsPresent => IsPresent(session, GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightDescOnIdea"), 25);
        public bool KeyboardBacklightOptionsOffInputIsPresent => IsPresent(session, GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightOffOnIdea"), 25);
        public bool KeyboardBacklightOptionsLowInputIsPresent => IsPresent(session, GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightLowOnIdea"), 25);
        public bool KeyboardBacklightOptionsHighInputIsPresent => IsPresent(session, GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightHighOnIdea"), 25);


        public WindowsElement KeyboardBacklightTitleOnIdea => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.IdeaKeyboardlight.KeyboardBacklightTitleOnIdea"));
        //backlightMode
        public List<WindowsElement> AllBacklightMode => base.FindElementsByTimes(session, "XPath", "//*[contains(@AutomationId, 'backlightMode')]");

        /// <summary>
        /// Keyboard Backlight Description
        /// </summary>

        public WindowsElement keyboardBacklightCaption => base.FindElementByTimes(session, "AutomationId", "inputAccessories-backlight-caption");
        public string expect_keyboardBacklight_Description = "Activate the keyboard backlight to facilitate typing in a dark or poor light condition. You also can change the keyboard backlight settings by pressing the Fn+Space key combinations.";
        public string expect_autokeyboardBacklight_Description = "Activate the keyboard backlight to facilitate typing in a dark or poor light condition. You can change the backlight settings by pressing the Fn+Space key combinations or set it as \"Auto\". In \"Auto\" mode, the system automatically adjusts the keyboard backlight according to the ambient light.";
        public string ExpectKeyboardBacklightDescriptionOnIdea = "Activate the keyboard backlight to facilitate typing in a dark or poor light condition. You also can change the keyboard backlight settings by pressing the Fn+Space key combinations.";

        public WindowsElement KBCaptionOfThinkPad => base.FindElementByTimes(session, "AutomationId", "inputAccessories-backlight-thinkpad-caption");
        public WindowsElement KBCaptionContentOfThinkPad => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBCaptionContentOfThinkPad"));

        /// <summary>
        /// Keyboard Backlight Description
        /// </summary>

        public WindowsElement keyboardBacklightCheckBox => base.FindElementByTimes(session, "AutomationId", "inputAccessories-backlight_checkbox");
        /// Auto keyboard backlight mode

        public WindowsElement AutoModeofkeyboardbacklight => base.FindElementByTimes(session, "AutomationId", "backlightModeauto");
        public WindowsElement LowModeofkeyboardbacklight => base.FindElementByTimes(session, "AutomationId", "backlightModelevel_1");
        public WindowsElement HighModeofkeyboardbacklight => base.FindElementByTimes(session, "AutomationId", "backlightModelevel_2");
        public WindowsElement OffModeofkeyboardbacklight => base.FindElementByTimes(session, "AutomationId", "backlightModeoff");

        /// <summary>
        /// User Defined Key Related AutomationID
        /// </summary>

        public WindowsElement DeviceButton => base.FindElementByTimes(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-device");
        public WindowsElement MyDevicePage => base.FindElementByTimes(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-device-1");
        public WindowsElement InputPage => base.FindElementByTimes(session, "AutomationId", "myDevice-settings-header-menu-input-accessories");
        public WindowsElement QuickSettings => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Dashboard.QuickSettings"));
        public WindowsElement AudioPage => base.FindElementByTimes(session, "AutomationId", "myDevice-settings-header-menu-audio");
        //Fn and Ctrl key swap feature

        public WindowsElement fnCtrlKey_Title => base.FindElementByTimes(session, "AutomationId", "inputAccessories-fnCtrlKey-title");


        public WindowsElement fnCtrlKey_TexDescription => base.FindElementByTimes(session, "AutomationId", "inputAccessories-fnCtrlKey-caption");

        public WindowsElement fnCtrlKey_Toggle => base.FindElementByTimes(session, "AutomationId", "inputAccessories-fnCtrlKey_checkbox");

        public WindowsElement fnCtrlKey_img => base.FindElementByTimes(session, "Name", "Fn and Ctrl key swap");


        public WindowsElement userDefinedKey_Title => base.FindElementByTimes(session, "AutomationId", "ds-ip-userdefined-key-title");

        public WindowsElement userDefinedKey_caption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.UserDefinedKey.userDefinedKey_caption"));
        public WindowsElement userDefinedKey_img => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.UserDefinedKey.userDefinedKey_img"));
        public WindowsElement userDefinedKey_dropdownbtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.UserDefinedKey.UserDefinedKeyDropDown_Btn"));


        public WindowsElement moreSection_Title => base.FindElementByTimes(session, "AutomationId", "inputAccessories.controlOptions.more");


        public WindowsElement backlightOptions => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.KeyboardBacklightOptions"));


        public WindowsElement backlightOptionAuto => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightAuto"));
        public WindowsElement backlightOptionLow => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightLow"));
        public WindowsElement backlightOptionHigh => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightHigh"));
        public WindowsElement backlightOptionOff => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightOff"));




        //Keyboard top-row function feature
        //public WindowsElement ReversingDefaultPrimaryFunctionToggle => base.FindElementByTimes(session, "AutomationId", "inputAccessories-reversing-primary-function_checkbox");
        public WindowsElement normalMethodRadio => base.FindElementByTimes(session, "AutomationId", "nMehod_show");
        public WindowsElement FnStickyKeyMethodRadio => base.FindElementByTimes(session, "AutomationId", "fnKeyMehod_show");
        public WindowsElement SpecialKeyRadio => base.FindElementByTimes(session, "AutomationId", "thinkpad-special-key-radio-button", 60);
        public WindowsElement FunctionKeyRadio => base.FindElementByTimes(session, "AutomationId", "thinkpad-function-key-radio-button", 60);
        public WindowsElement SpecialKeyRadioIdeapad => base.FindElementByTimes(session, "AutomationId", "ideapad-special-key-radio-button");
        public WindowsElement FunctionKeyRadioIdeapad => base.FindElementByTimes(session, "AutomationId", "ideapad-function-key-radio-button");
        public WindowsElement AdvSettings_link => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.AdvSettings_link"));
        public WindowsElement keyboard_title => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.keyboard_title"));

        public WindowsElement KBDTopRowTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowTitle"));
        public WindowsElement KBDTopRowDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowDesc"));
        public WindowsElement KBDTopRowSubDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowSubDesc"));
        public WindowsElement KBDTopRowAdvanceSettinsLinkXpath => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowAdvanceSettinsLinkXpath"));
        public WindowsElement KBDTopRowSpecialKeyRadio => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowSpecialFunctionRadioBtn"));
        public WindowsElement KBDTopRowFunctionKeyRadio => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowF1ToF12FunctionRadioBtn"));
        public WindowsElement ReversingDefaultPrimaryFunctionTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.ReversingDefaultPrimaryFunctionTitle"));
        public WindowsElement ReversingDefaultPrimaryFunctionTips => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.ReversingDefaultPrimaryFunctionTips"));
        public WindowsElement ReversingDefaultPrimaryFunctionTipsIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.ReversingDefaultPrimaryFunctionTipsIcon"));
        public WindowsElement ReversingDefaultPrimaryFunctionDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.ReversingDefaultPrimaryFunctionDesc"));
        public WindowsElement ReversingDefaultPrimaryFunctionToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.ReversingDefaultPrimaryFunctionToggle"));
        public WindowsElement KBDTopRowFnKeyCombinationsTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowFnKeyCombinationsTitle"));
        public WindowsElement KBDTopRowFnKeyCombinationsDesc => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowFnKeyCombinationsDesc"));
        public WindowsElement KBDTopRowFnKeyCombinationsDescs => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowFnKeyCombinationsDesc"));
        public WindowsElement KBDTopRowNormalMethodRadio => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowNormalMethodRadio"));
        public WindowsElement KBDTopRowFnStickyKeyMethodRadio => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowFnStickyKeyMethodRadio"));
        public WindowsElement KBDTopRowFnStickyKeyMethodNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowFnStickyKeyMethodNote"));
        public WindowsElement KBDTopRowPopupWindowTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowTitle"));
        public WindowsElement KBDTopRowPopupWindowDesc => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowDesc"));
        public WindowsElement KBDTopRowPopupWindowYesBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowYesBtn"));
        public WindowsElement KBDTopRowPopupWindowYesBtns => base.FindElementByTimes(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowYesBtn"));
        public WindowsElement KBDTopRowPopupWindowNotNowBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowNotNowBtn"));
        public WindowsElement KBDTopRowPopupWindowCloseBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KBDTopRow.KBDTopRowPopupWindowCloseBtn"));


        public WindowsElement backlightOff => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightOff"));
        public WindowsElement backlightLow => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightLow"));
        public WindowsElement backlightHigh => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightHigh"));
        public WindowsElement backlightAuto => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.backlightAuto"));

        //HiddenKeyboardFunctions

        public WindowsElement HiddenKeyboardFunctionsTitleId => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.HiddenKeyboardFunctionsTitleId"));
        public WindowsElement HiddenKeyboardFunctionsTextId => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.HiddenKeyboardFunctionsTextId"));
        public WindowsElement HiddenKeyboardFunctionsMap => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.HiddenKeyboardFunctionsMap"));
        public WindowsElement Fn4Title => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.Fn4Title"));
        public WindowsElement Fn4Description => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.Fn4Description"));
        public WindowsElement FnDTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnDTitle"));
        public WindowsElement FnDDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnDDescription"));
        public WindowsElement Fn4DescriptionLe => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyBoardAllText"));
        public WindowsElement FnDDescriptionLe => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyBoardAllText"));
        public WindowsElement FnSTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnSTitle"));
        public WindowsElement FnSDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnSDescription"));

        public WindowsElement FnTabTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnTabTitle"));
        public WindowsElement FnTabDescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.FnTabDescription"));

        //Voip feature ID created by Jiajt3

        public WindowsElement VOIPFeatureTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipfeatureTitle"), 10);
        public WindowsElement VOIPHasInstallNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipHasInstallNote"), 10);
        public WindowsElement VOIPfeatureDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipfeatureDesc"));
        public WindowsElement VOIPfeatureTooltipsIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipfeatureTooltipsIcon"));
        public WindowsElement VOIPfeatureTooltipsDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipfeatureTooltipsDesc"));
        public WindowsElement VOIPHotkeysDescF10 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipHotkeysDescF10"));
        public WindowsElement VOIPHotkeysDescF11 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipHotkeysDescF11"));
        public WindowsElement VOIPHotkeysInstalledAppsDescXpath => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipHotkeysInstalledAppsDescXpath"));
        public WindowsElement VoipTeamsAppIcon => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipTeamsAppIcon"));
        public WindowsElement VOIPAppNoteXpth => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipAppNoteXpth"));
        public WindowsElement VOIPMicrosoftTeamsOption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipMicrosoftTeamsOption"));
        public WindowsElement VOIPSkypeOption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipSkypeOption"));
        public WindowsElement VOIPMicrosoftTeamsAppName => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipTeamsAppDesc"));
        public WindowsElement VOIPSkypeAppName => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.MyDeviceSettings.InputAndAccessories.VOIP.VoipSkypeAppDesc"));

        //Keyboard Top Row Function
        public WindowsElement KeyboardTopRowFunctionTitleID => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionTitleID"));
        public WindowsElement KeyboardTopRowFunctionDescriptionID => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionDescriptionID"));
        public WindowsElement KeyboardTopRowFunctionSpecialFunction => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionSpecialFunction"));
        public WindowsElement KeyboardTopRowFunctionF1F12Function => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionF1F12Function"));
        public WindowsElement KeyboardTopRowFunctionTip1 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionTip1"));
        public WindowsElement KeyboardTopRowFunctionTip2 => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.KeyboardTopRowFunctionTip2"));
        public WindowsElement InputLarkKeyBoardNote => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.InputLarkKeyBoardNote"));
        public WindowsElement Touchpadlink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.Touchpadlink"), 2, 1);
        public WindowsElement Trackpointlink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.InputPage.Trackpointlink"), 2, 1);

        public HSInputPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -100);
        }

        //public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        //{
        //    Assert.AreEqual(expected, windowsElement.Text);
        //}

        private bool IsPresent(string locator)
        {
            try
            {
                session.FindElementByName(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }

        #region Teams 、Skype Install、Uninstall

        //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\VoIP\\Teams_windows_x64.exe");
        //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Tools\\VoIP\\lyncentryEnglish.exe");
        public string GetSkypeTeamsInstallStatus(string type)
        {
            NerveCenterHelper.CommonAppInfo teamsInfo = NerveCenterHelper.GetCommonAppInformation("VoipTeamsApp", NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            NerveCenterHelper.CommonAppInfo skypeInfo = NerveCenterHelper.GetCommonAppInformation("VoipSkypeApp", NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            teamsInfo.File = teamsInfo.File.Replace("@StartMenu", Environment.GetFolderPath(System.Environment.SpecialFolder.StartMenu));
            teamsInfo.UninstallExe = teamsInfo.UninstallExe.Replace("@LocalApplicationData", Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            switch (type.ToLower())
            {
                case "teams":
                    if (File.Exists(teamsInfo.File) && !File.Exists(skypeInfo.File))
                    {
                        return "true";
                    }
                    break;
                case "skype":
                    if (!File.Exists(teamsInfo.File) && File.Exists(skypeInfo.File))
                    {
                        return "true";
                    }
                    break;
                case "both":
                    if (File.Exists(teamsInfo.File) && File.Exists(skypeInfo.File))
                    {
                        return "true";
                    }
                    break;
                case "noapps":
                    if (!File.Exists(teamsInfo.File) && !File.Exists(skypeInfo.File))
                    {
                        return "true";
                    }
                    break;
                default:
                    return "GetSkypeTeamsInstallStatus(),no run,status is unknown.";
            }
            return "false";
        }

        public bool InstallSkypeTeamsForVoip(string app, bool isInstall)
        {
            NerveCenterHelper.CommonAppInfo teamsInfo = NerveCenterHelper.GetCommonAppInformation("VoipTeamsApp", NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            NerveCenterHelper.CommonAppInfo skypeInfo = NerveCenterHelper.GetCommonAppInformation("VoipSkypeApp", NerveCenterHelper.NerveCenterGamingAppIniFileCopy);
            teamsInfo.File = teamsInfo.File.Replace("@StartMenu", Environment.GetFolderPath(System.Environment.SpecialFolder.StartMenu));
            teamsInfo.UninstallExe = teamsInfo.UninstallExe.Replace("@LocalApplicationData", Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData));
            UIAutomationControl control = new UIAutomationControl();
            switch (app.ToLower())
            {
                case "teams":
                    if (isInstall) // teams install
                    {
                        if (File.Exists(teamsInfo.File))
                        {
                            return true;
                        }
                        else
                        {
                            CommandBase.RunCmdException(teamsInfo.Package);
                            for (int i = 0; i < 60; i++)
                            {
                                if (File.Exists(teamsInfo.File))
                                {
                                    Console.WriteLine("install " + i);
                                    return true;
                                }
                                Thread.Sleep(1000);
                            }
                            Console.WriteLine("Info: Install Teams Time out!");
                            return false;
                        }
                    }
                    else //teams uninstall
                    {
                        if (!File.Exists(teamsInfo.File))
                        {
                            return true;
                        }
                        else
                        {
                            CommandBase.RunCmdException(teamsInfo.UninstallExe);
                            for (int i = 0; i < 60; i++)
                            {
                                if (!File.Exists(teamsInfo.File))
                                {
                                    Console.WriteLine("Uninstall " + i);
                                    return true;
                                }
                                Thread.Sleep(1000);
                            }
                            Console.WriteLine("Info: Uninstall Teams Time out!");
                            return false;
                        }
                    }
                case "skype":
                    if (isInstall) //install skype
                    {
                        if (File.Exists(skypeInfo.File))
                        {
                            return true;
                        }
                        else
                        {
                            Process.Start(skypeInfo.Package);
                            Thread.Sleep(3000);
                            AutomationElement installSkype = control.FindElement("Skype for Business Basic 2016", "", "Install Now");
                            if (installSkype != null)
                            {
                                var position = installSkype.Current.BoundingRectangle;
                                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                                string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                                VantageCommonHelper.SetMouseClick(x, y);
                                Thread.Sleep(TimeSpan.FromSeconds(300));
                                var closeInstall = control.FindElement("Skype for Business Basic 2016", "", "Close");
                                if (closeInstall != null)
                                {
                                    VantageCommonHelper.keybd_event(Keys.Alt, 0, 0, 0);
                                    VantageCommonHelper.keybd_event(Keys.C, 0, 0, 0);
                                    VantageCommonHelper.keybd_event(Keys.C, 0, 2, 0);
                                    VantageCommonHelper.keybd_event(Keys.Alt, 0, 2, 0);
                                }
                            }
                            if (File.Exists(skypeInfo.File))
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                    else //uninstall skype
                    {
                        if (!File.Exists(skypeInfo.File))
                        {
                            return true;
                        }
                        else
                        {
                            Process.Start(skypeInfo.Package);
                            Thread.Sleep(3000);
                            AutomationElement installSkype = control.FindElement("Skype for Business Basic 2016", "", "Remove");
                            if (installSkype != null)
                            {
                                var position = installSkype.Current.BoundingRectangle;
                                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                                string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                                VantageCommonHelper.SetMouseClick(x, y);
                                VantageCommonHelper.keybd_event(Keys.Alt, 0, 0, 0);
                                VantageCommonHelper.keybd_event(Keys.C, 0, 0, 0);
                                VantageCommonHelper.keybd_event(Keys.C, 0, 2, 0);
                                VantageCommonHelper.keybd_event(Keys.Alt, 0, 2, 0);
                                Thread.Sleep(TimeSpan.FromSeconds(10));
                                VantageCommonHelper.keybd_event(Keys.Alt, 0, 0, 0);
                                VantageCommonHelper.keybd_event(Keys.Y, 0, 0, 0);
                                VantageCommonHelper.keybd_event(Keys.Y, 0, 2, 0);
                                VantageCommonHelper.keybd_event(Keys.Alt, 0, 2, 0);
                                Thread.Sleep(TimeSpan.FromSeconds(300));
                                var closeUninstall = control.FindElement("Skype for Business Basic 2016", "", "Close");
                                if (closeUninstall != null)
                                {
                                    VantageCommonHelper.keybd_event(Keys.Alt, 0, 0, 0);
                                    VantageCommonHelper.keybd_event(Keys.C, 0, 0, 0);
                                    VantageCommonHelper.keybd_event(Keys.C, 0, 2, 0);
                                    VantageCommonHelper.keybd_event(Keys.Alt, 0, 2, 0);
                                }
                            }
                            if (!File.Exists(skypeInfo.File))
                            {
                                return true;
                            }
                            return false;
                        }
                    }
                default:
                    Console.WriteLine("InstallSkypeTeamsForVoip(),no run," + app + isInstall);
                    break;
            }
            return false;
        }

        #endregion

        public void SetBlueToothState(string state)
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:bluetooth");
            Thread.Sleep(2000);
            UIAutomationControl control = new UIAutomationControl();
            AutomationElement toggle = VantageCommonHelper.FindElementByIdIsEnabled(GetAutomationIdFromPredefinedJsonFile("$.InputPage.BlueTooth"));
            if (state == "On")
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.On);
            }
            else
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.Off);
            }
            Thread.Sleep(2000);
            KillProcess("SystemSettings");
        }
    }
}
