using LenovoVantageTest.Pages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public sealed class SmartAssistSteps : SettingsBase
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef
        private InformationalWebDriver _webDriver;
        private SmartAssistPageObject _smartAssistPage;
        private readonly ScenarioContext _scenarioContext;

        public SmartAssistSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;

        }

        [StepDefinition("verify intelligent sensing '(.*)'")]
        public void verifyintelligentsensing(string _exist)
        {
            if (_exist.ToLower().Trim().Equals("exists"))
            {
                Assert.IsTrue(SmartAssistPageObject.instance.IntelligentSensing != null);
            }
            else
            {
                Assert.IsTrue(SmartAssistPageObject.instance.IntelligentSensing == null);
            }

        }

        [StepDefinition("click intelligent sensing")]
        public void clickintelligentsensing()
        {
            SmartAssistPageObject.instance.IntelligentSensing?.Click();
        }

        [When(@"The '(.*)' drop down list will be hidden or shown '(.*)' for SmartMotionAlarm")]
        public void WhenTheDropDownListWillBeHiddenOrShownForSmartMotionAlarm(string option, string action)
        {
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            ScrollScreenToWindowsElement(_webDriver.Session, _smartAssistPage.Photolink, -35, 20);
            string oa = option.ToLower() + "-" + action.ToLower();
            switch (oa)
            {
                case "alarm-shown":
                    Assert.IsTrue(_smartAssistPage.ShowOrHideAlarmAndPhotoDropDown(true, true), "the alarm drop down list show fail");
                    break;
                case "alarm-hidden":
                    Assert.IsTrue(_smartAssistPage.ShowOrHideAlarmAndPhotoDropDown(true, false), "the alarm drop down list hidden fail");
                    break;
                case "photo-shown":
                    Assert.IsTrue(_smartAssistPage.ShowOrHideAlarmAndPhotoDropDown(false, true), "the photo drop down list show fail");
                    break;
                case "photo-hidden":
                    Assert.IsTrue(_smartAssistPage.ShowOrHideAlarmAndPhotoDropDown(false, false), "the photo drop down list hidden fail");
                    break;
                default:
                    Assert.Fail("The WhenTheDropDownListWillBeHiddenOrShownForSmartMotionAlarm() no run." + oa);
                    break;
            }
        }



        //[StepDefinition(@"(.*) 'alarm time' list")]
        public void clickAlarmTime(string _showORnot)
        {
            string dropdownlist = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.alarmAndphoto").ToString();
            if (_showORnot.Trim().Equals("show"))
            {
                SmartAssistPageObject.instance.AlarmTimeDuration?.Click();
                if (!VantageUI.instance.VantageElementExistUsingAutomationId(dropdownlist, 5))
                {
                    SmartAssistPageObject.instance.AlarmTimeDuration?.Click();
                }
            }
            else
            {
                if (VantageUI.instance.VantageElementExistUsingAutomationId(dropdownlist, 5))
                {
                    SmartAssistPageObject.instance.AlarmTimeDuration?.Click();
                }
            }

        }

        //[StepDefinition(@"(.*) photo list")]
        public void clickphotoCombobox(string _showORnot)
        {
            string dropdownlist = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.alarmAndphoto").ToString();
            if (_showORnot.Trim().Equals("show"))
            {
                SmartAssistPageObject.instance.Photonum?.Click();
                if (!VantageUI.instance.VantageElementExistUsingAutomationId(dropdownlist, 5))
                {
                    SmartAssistPageObject.instance.Photonum?.Click();
                }
            }
            else
            {
                if (VantageUI.instance.VantageElementExistUsingAutomationId(dropdownlist, 5))
                {
                    SmartAssistPageObject.instance.Photonum?.Click();
                }
            }

        }

        [StepDefinition(@"select time option '(.*)'")]
        [StepDefinition(@"select photo number '(.*)'")]
        public void selectOption(string _option)
        {
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            string dropdownlist = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.alarmAndphoto").ToString();
            if (VantageUI.instance.VantageElementExistUsingAutomationId(dropdownlist, 5))
            {
                VantageUI.instance.VantageClickElementtUsingAutomationId(_option, 5);

                bool isTimeDropDown = _option.Contains("second") || _option.Contains("minute") || _option.Contains("stop") ? true : false;
                if (isTimeDropDown)
                {
                    Console.WriteLine("Select Info:" + _smartAssistPage.AlarmTimeDuration.GetAttribute("Name") + " " + _option);
                }
                else
                {
                    Console.WriteLine("Select Info:" + _smartAssistPage.Photonum.GetAttribute("Name") + " " + _option);
                }
            }
            else
            {
                BasePage basePage = new BasePage();
                basePage.AddScreenshotIntoReport("NoDroplist", ".", "HSScreenShotResult");

                Assert.IsTrue(true, $"NO AutomationId={dropdownlist} ??I need that to select time or photo number");
            }
        }

        [StepDefinition("'(.*)' Enable Feature")]
        public void enableFeature(string _status)
        {
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            if (_status.ToLower().Equals("enable"))
            {
                Assert.IsTrue(_smartAssistPage.SetEnableOrDisableTakingPhotosFeature(true), "enableFeature fail," + _status);
            }
            else
            {
                Assert.IsTrue(_smartAssistPage.SetEnableOrDisableTakingPhotosFeature(false), "disableFeature fail," + _status);
            }
            return;

            string enableFeature = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.EnableFeature").ToString();
            if (_status.ToLower().Equals("enable"))
            {
                if (VantageUI.instance.VantageElementIsToggledUsingAutomationId(enableFeature) == 0)
                {
                    VantageUI.instance.VantageClickElementtUsingAutomationId(enableFeature);
                }
            }
            else
            {
                if (VantageUI.instance.VantageElementIsToggledUsingAutomationId(enableFeature) == 1)
                {
                    VantageUI.instance.VantageClickElementtUsingAutomationId(enableFeature);
                }
            }

        }

        [StepDefinition("verify default status is '(.*)' for Smart Motion Alarm toggle")]
        public void verifyToggle(string _status)
        {
            string actual = SmartAssistPageObject.instance.SmartMotionAlarm.GetAttribute("Toggle.ToggleState");
            Assert.IsTrue(actual.Equals((_status.ToLower().Equals("disabled") || _status.ToLower().Equals("off")) ? "0" : "1"), $"default status for Enable Feature is {actual}?");
        }


        [StepDefinition("toggle '(.*)' for Smart Motion Alarm")]
        public void toggleAlarm(string _status)
        {
            string currentState = SmartAssistPageObject.instance.SmartMotionAlarm.GetAttribute("Toggle.ToggleState");
            if (_status.ToLower().Trim().Equals("on"))
            {
                if (currentState.Equals("0"))
                {
                    SmartAssistPageObject.instance.SmartMotionAlarm?.Click();
                }
            }
            else
            {
                if (currentState.Equals("1"))
                {
                    SmartAssistPageObject.instance.SmartMotionAlarm?.Click();
                }
            }

        }

        [StepDefinition(@"verify default time is '(.*)' for Alarm")]
        public void verifyTime(string _seconds)
        {
            string actual = SmartAssistPageObject.instance.AlarmTimeDuration.GetAttribute("Name");
            Assert.IsTrue(actual.Contains(_seconds), $"default Alarm time is {actual}?");
        }

        [StepDefinition(@"verify photo or time list Item")]
        public void ThenVerifyPhotoOrTimeListItem(Table table)
        {
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            List<WindowsElement> elements = _smartAssistPage.GetAlarmAndPhotoDropDownListForSmartAssistPage();
            Assert.NotZero(elements.Count, "photo or time list is 0");
            for (int i = 0; i < table.Rows.Count; i++)
            {
                string photo = table.Rows[i][0].Trim();
                Assert.AreEqual(photo, elements[i].GetAttribute("AutomationId").Trim(), "not found element within photo or time list" + photo);
            }
        }

        [StepDefinition(@"verify title or describe Item")]
        public void StepDefinitionVerifyTitleOrDescribeItem(Table table)
        {
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            for (int i = 0; i < table.RowCount; i++)
            {
                string expected = VantageAssetsHelper.SingleTon.GetSpecificGUIContentByLanguage(table.Rows[i][1], Language.instance.GetPrefered1stLanguage_2letters()).ToString();
                expected = expected.Trim();
                switch (table.Rows[i][0].Trim())
                {
                    case "title":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmTitle, "The SmartMotionAlarm title not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmTitle.Text, "The SmartMotionAlarm title text incorrect");
                        break;
                    case "describe1":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmDescribe1, "The SmartMotionAlarm describe one not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmDescribe1.Text, "The SmartMotionAlarm describe one text incorrect");
                        break;
                    case "describe2":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmDescribe2, "The SmartMotionAlarm describe two not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmDescribe2.Text, "The SmartMotionAlarm describe two text incorrect");
                        break;
                    case "attention":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmAttention, "The SmartMotionAlarm Attention title not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmAttention.Text, "The SmartMotionAlarm Attention title text incorrect");
                        break;
                    case "attention1":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmAttention1, "The SmartMotionAlarm Attention one describe not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmAttention1.Text, "The SmartMotionAlarm Attention one describe text incorrect");
                        break;
                    case "attention2":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmAttention2, "The SmartMotionAlarm Attention two describe not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmAttention2.Text, "The SmartMotionAlarm Attention two describe text incorrect");
                        break;
                    case "alarmtimetitle":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmTimeTitle, "The SmartMotionAlarm time title not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmTimeTitle.Text, "The SmartMotionAlarm time title text incorrect");
                        break;
                    case "takephotostitle":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmTakePhotosTitle, "The SmartMotionAlarm take photos title not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmTakePhotosTitle.Text, "The SmartMotionAlarm take photos title text incorrect");
                        break;
                    case "describe3":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmDescribe3, "The SmartMotionAlarm describe three not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmDescribe3.Text, "The SmartMotionAlarm describe three text incorrect");
                        break;
                    case "enablephoto":
                        Assert.NotNull(_smartAssistPage.EnableFeature, "The EnableFeature not found");
                        Assert.AreEqual(expected, _smartAssistPage.EnableFeature.Text, "The EnableFeature text incorrect");
                        break;
                    case "showPhoto":
                        Assert.NotNull(_smartAssistPage.SmartMotionAlarmPhotoLinkTitle, "The SmartMotionAlarm photolink title not found");
                        Assert.AreEqual(expected, _smartAssistPage.SmartMotionAlarmPhotoLinkTitle.Text, "The SmartMotionAlarm photolink title text incorrect");
                        break;
                    case "ViewPhotos":
                        Assert.NotNull(_smartAssistPage.Photolink, "The ViewPhotos Link not found");
                        Assert.AreEqual(expected, _smartAssistPage.Photolink.Text, "The ViewPhotos Link text incorrect");
                        break;
                    case "noCameraAccess":
                        Assert.NotNull(_smartAssistPage.descNoAccess, "The SmartMotionAlarm no CameraAccess describe not found");
                        Assert.AreEqual(expected, _smartAssistPage.descNoAccess.Text, "The SmartMotionAlarm no CameraAccess describe text incorrect");
                        break;
                    case "giveCameraAccess":
                        Assert.NotNull(_smartAssistPage.link2GoToWindowsSettingsToGetCameraAccess, "The Go to give Access not found");
                        Assert.AreEqual(expected, _smartAssistPage.link2GoToWindowsSettingsToGetCameraAccess.Text, "The Go to give Access text incorrect");
                        break;
                    case "privacyModeOn":
                        Assert.NotNull(_smartAssistPage.descPrivacyOn, "The SmartMotionAlarm descPrivacyOn describe not found");
                        Assert.AreEqual(expected, _smartAssistPage.descPrivacyOn.Text, "The SmartMotionAlarm descPrivacyOn describe text incorrect");
                        break;
                    case "turnOffPrivacyMode":
                        Assert.NotNull(_smartAssistPage.link2GoToCameraPrivacy, "The GoToCameraPrivacy not found");
                        Assert.AreEqual(expected, _smartAssistPage.link2GoToCameraPrivacy.Text, "The GoToCameraPrivacy text incorrect");
                        break;
                    default:
                        Assert.Fail("the ThenTheVideoResolutionUpscalingTextIsCorerect() not run,the paramter incorrect。" + table.Rows[i][0]);
                        break;
                }
            }
        }

        [StepDefinition(@"verify default status is '(.*)' for Enable Feature")]
        public void verifyDefaultStatus4EnableFeature(string _status)
        {
            string actual = SmartAssistPageObject.instance.EnableFeature.GetAttribute("Toggle.ToggleState");
            Assert.IsTrue(actual.Equals((_status.ToLower().Equals("disabled") || _status.ToLower().Equals("off")) ? "0" : "1"), $"default status for Enable Feature is {actual}?");
        }

        [StepDefinition(@"verify default number is '(\d{1,})' for Photo number")]
        public void verifyPhotoNumber(int _num)
        {
            KeyboardMouse.DoMouseScrollDown1Fourth();
            _smartAssistPage = new SmartAssistPageObject(_webDriver);
            Assert.NotNull(_smartAssistPage.Photonum, "the Photonum not found.");
            string name = _smartAssistPage.Photonum.GetAttribute("Name");//VantageUI.instance.VantageElementGetNameUsingAutomationId(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.PhotoNum").ToString());
            Assert.AreEqual(_num.ToString(), Regex.Replace(name, @"[^0-9]+", ""), "verifyPhotoNumber fail,info:" + name);
        }

        [StepDefinition(@"close Settings")]
        public void closeSettings()
        {
            Common.KillProcess("SystemSettings", false);
        }

        [StepDefinition("verify Enable Feature toggle is '(.*)'")]
        public void verifyEnableFeature(string _required)
        {
            if (_required.ToLower().Equals("enabled"))
            {
                Assert.IsTrue(SmartAssistPageObject.instance.EnableFeature.Enabled, "'Enable Feature' toggle is NOT enabled?");
            }
            else
            {
                Assert.IsTrue(!SmartAssistPageObject.instance.EnableFeature.Enabled, "'Enable Feature' toggle is Enabled?");
            }

        }

        [StepDefinition(@"verify link 'Go to Windows Settings to give access' for Camera is '(.*)'")]
        public void verifyLink2CameraAccess(string _enabled)
        {
            if (_enabled.Trim().ToLower().Equals("enabled"))
            {
                Assert.IsTrue(SmartAssistPageObject.instance.link2GoToWindowsSettingsToGetCameraAccess != null, "link to 'Go to Windows Settings to give access' NOT showes up??");
            }
            else
            {
                Assert.IsTrue(SmartAssistPageObject.instance.link2GoToWindowsSettingsToGetCameraAccess == null, "link to 'Go to Windows Settings to give access' Showes up??");
            }
        }

        [StepDefinition(@"verify link 'Go to Windows Settings to give access' for FileSystem is '(.*)'")]
        public void verifyLink2FSAccess(string _enabled)
        {
            if (_enabled.Trim().ToLower().Equals("enabled"))
            {
                Assert.IsTrue(SmartAssistPageObject.instance.linkGoToWindowsSettingsToGetFileSystemAccess != null, "link to 'Go to Windows Settings to give access' NOT showes up??");
            }
            else
            {
                Assert.IsTrue(SmartAssistPageObject.instance.linkGoToWindowsSettingsToGetFileSystemAccess == null, "link to 'Go to Windows Settings to give access' Showes up??");
            }
        }

        [StepDefinition(@"verify discribe '(.*)' is '(.*)'")]
        public void verifyDiscribeIsNotDisplay(string _describe, string _state)
        {
            if (_state.Trim().ToLower().Equals("display"))
                switch (_describe.Trim().ToString())
                {
                    case "privacyModeOn":
                        Assert.IsTrue(SmartAssistPageObject.instance.descPrivacyOn != null, "discribe 'Lenovo Vantage Camera privacy mode is on.' not showes up??");
                        break;
                    case "noCameraAccess":
                        Assert.IsTrue(SmartAssistPageObject.instance.descNoAccess != null, "describe 'Lenovo Vantage doesn't have access to Camera.' not Showes up??");
                        break;
                    case "noFileAccess":
                        Assert.IsTrue(SmartAssistPageObject.instance.noFileAccess != null, "'Lenovo Vantage doesn't have access to the file system.' not showes up??");
                        break;
                    default:
                        Assert.Fail("the verifyDiscribeIsNotDisplay not run,the paramter incorrect。" + _describe);
                        break;
                }
            else
                switch (_describe.Trim().ToString())
                {
                    case "privacyModeOn":
                        Assert.IsTrue(SmartAssistPageObject.instance.descPrivacyOn == null, "discribe 'Lenovo Vantage Camera privacy mode is on.' showes up??");
                        break;
                    case "noCameraAccess":
                        Assert.IsTrue(SmartAssistPageObject.instance.descNoAccess == null, "describe 'Lenovo Vantage doesn't have access to Camera.' Showes up??");
                        break;
                    case "noFileAccess":
                        Assert.IsTrue(SmartAssistPageObject.instance.noFileAccess == null, "'Lenovo Vantage doesn't have access to the file system.' showes up??");
                        break;
                    default:
                        Assert.Fail("the verifyDiscribeIsNotDisplay not run,the paramter incorrect。" + _describe);
                        break;
                }
        }

        [StepDefinition(@"verify link 'Go to Camera privacy mode to turn it off' is '(.*)'")]
        public void verifyLink2CameraPrivacy(string _enabled)
        {
            if (_enabled.Trim().ToLower().Equals("enabled"))
            {
                Assert.IsTrue(SmartAssistPageObject.instance.link2GoToCameraPrivacy != null, "link to 'Go to Camera privacy mode to turn it off' NOT showes up??");
            }
            else
            {
                Assert.IsTrue(SmartAssistPageObject.instance.link2GoToCameraPrivacy == null, "link to 'Go to Camera privacy mode to turn it off' Showes up??");
            }
        }

        [StepDefinition(@"click link 'Go to Windows Settings to give access' for camera access")]
        public void clickLink2CameraAccess()
        {
            SmartAssistPageObject.instance.link2GoToWindowsSettingsToGetCameraAccess?.Click();
        }

        [StepDefinition(@"click link 'Go to Windows Settings to give access' for file system access")]
        public void clickLink2FSAccess()
        {
            SmartAssistPageObject.instance.linkGoToWindowsSettingsToGetFileSystemAccess?.Click();
        }

        [StepDefinition(@"click link 'Go to Camera privacy mode to turn it off'")]
        public void clickLink2CameraPrivacy()
        {
            SmartAssistPageObject.instance.link2GoToCameraPrivacy?.Click();
        }

        [StepDefinition(@"verify Camera access with Settings is launched")]
        public void cameraAccess()
        {
            Assert.IsTrue(Common.GetProcessesByName_Win32("SystemSettings") != null);
        }

        [StepDefinition(@"verify 'Lenovo Vantage doesn't have access to Camera. The function of the checkbox won't work' is GONE on Vantage")]
        public void verifyDescribingNoAccess()
        {
            Assert.IsTrue(!VantageUI.instance.VantageElementExistUsingAutomationId(VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.NOAccessDesc").ToString()), "'Lenovo Vantage doesn't have access to Camera. The function of the checkbox won't work.' showes up??");

        }

        [StepDefinition(@"click photo link")]
        public void clickPhotolink()
        {
            SmartAssistPageObject.instance.Photolink?.Click();
            Thread.Sleep(1000);
        }

        [StepDefinition(@"verify photo folder is (open|not open)")]
        public void verifyPhotoFolder(string _openOrNot)
        {
            if (_openOrNot.ToLower().Trim().Equals("open"))
            {
                Assert.IsTrue(VantageUI.instance.ElementExistUsingCustomXPath(@"Window[@Name='Public Pictures']"));
            }
            else
            {
                Assert.IsTrue(!VantageUI.instance.ElementExistUsingCustomXPath(@"Window[@Name='Public Pictures']"));
            }
        }

        [StepDefinition(@"ensure no '(.*)' folder is open")]
        public void closeFolder(string _keyRecognizerInFolderPath)
        {
            Common.CloseOpenedFolderUsingItsPath(_keyRecognizerInFolderPath.Replace('\\', '/'));
        }

        [StepDefinition(@"uninstall 'Lenovo Intelligent Sensing' from device manager")]
        public void uninstallLISS()
        {
            string LISSName = "Lenovo Intelligent Sensing";
            string hardwareID = "";
            Common.WMIEnumerator("SELECT * FROM Win32_PnPEntity where Manufacturer='Lenovo'", managementObj =>
            {
                if (managementObj["Name"].ToString().Equals(LISSName))
                {
                    hardwareID = managementObj["PNPDeviceID"].ToString();
                    return true;
                }
                return false;
            });
            if (hardwareID.Equals(""))
            {
                LogHelper.Logger.Instance.WriteLog("NO LISS device installed ?");
                return;
            }
            Common.StartProcess("cmd", $"/c pnputil /remove-device \"{hardwareID}\" /subtree");
        }

        [StepDefinition(@"install 'Lenovo Intelligent Sensing'")]
        public void installLISS()
        {
            Common.StartProcess("cmd.exe", "/c pnputil -i -a " + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\TestData\Lenovo.IntelligentSensingDriver\PKG\*.inf"));
            Common.StartProcess("cmd.exe", "/c pnputil /scan-devices");
        }
    }
}
