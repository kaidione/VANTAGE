using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;

namespace LenovoVantageTest.Pages
{
    class SmartAssistPageObject : SettingsBase
    {
        private InformationalWebDriver session;
        static SmartAssistPageObject _instance;
        public SmartAssistPageObject(InformationalWebDriver session)
        {
            this.session = session;
        }
        public static SmartAssistPageObject instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new SmartAssistPageObject(new InformationalWebDriver(null, null));
                }
                return _instance;
            }
        }

        public WindowsElement IntelligentSensing => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.IntelligentSensing"), 10);
        public WindowsElement SmartMotionAlarm => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarm"));
        public WindowsElement AlarmTimeDuration => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.AlarmTimeDuration"));
        public WindowsElement EnableFeature => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.EnableFeature"));
        public WindowsElement Photonum => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.PhotoNum"));
        public WindowsElement Photolink => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.Photolink"));
        public WindowsElement link2GoToWindowsSettingsToGetCameraAccess => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.link2CameraAccess"), 10);
        public WindowsElement descNoAccess => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.NOAccessDesc"), 10);
        public WindowsElement link2GoToCameraPrivacy => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.link2CameraPrivacy"), 10);
        public WindowsElement linkGoToWindowsSettingsToGetFileSystemAccess => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.link2FileSystem"));

        public WindowsElement descPrivacyOn => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.PrivacyOnDesc"), 10);
        public WindowsElement SmartMotionAlarmTitle => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmTitle"), 10);
        public WindowsElement SmartMotionAlarmDescribe1 => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmDescribe1"), 10);
        public WindowsElement SmartMotionAlarmDescribe2 => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmDescribe2"), 10);
        public WindowsElement SmartMotionAlarmAttention => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmAttention"), 10);
        public WindowsElement SmartMotionAlarmAttention1 => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmAttention1"), 10);
        public WindowsElement SmartMotionAlarmAttention2 => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmAttention2"), 10);
        public WindowsElement SmartMotionAlarmTimeTitle => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmTimeTitle"), 10);
        public WindowsElement SmartMotionAlarmTakePhotosTitle => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmTakePhotosTitle"), 10);
        public WindowsElement SmartMotionAlarmDescribe3 => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmDescribe3"), 10);
        public WindowsElement SmartMotionAlarmPhotoLinkTitle => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartMotionAlarmPhotoLinkTitle"), 10);
        public WindowsElement noFileAccess => base.FindElementByTimes(session.Session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.NOFileAccessDesc"), 10);
        public WindowsElement GetAlarmAndPhotoDropDownItemForSmartAssistPage(string option)
        {
            string dropdownlist = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.alarmAndphoto").ToString();
            List<WindowsElement> elements = base.FindElementsByTimes(session.Session, "XPath", "//*[@AutomationId=\'" + dropdownlist + "\']//ListItem");
            WindowsElement element = null;
            if (elements.Count > 0)
            {
                foreach (var item in elements)
                {
                    if (item.GetAttribute("AutomationId") == option)
                    {
                        element = item;
                        break;
                    }
                }
                Console.WriteLine("The GetAlarmAndPhotoDropDownItemForSmartAssistPage(), not found specfic option," + option);
            }
            else
            {
                Console.WriteLine("The GetAlarmAndPhotoDropDownItemForSmartAssistPage() item total is 0");
            }
            return element;
        }

        public bool SetEnableOrDisableTakingPhotosFeature(bool isEnable, int trytimes = 3)
        {
            if (EnableFeature == null)
            {
                Console.WriteLine("Info: The EnableFeature not found");
                return false;
            }
            ToggleState toggle = base.GetCheckBoxStatus(EnableFeature);
            for (int i = 0; i < trytimes; i++)
            {
                if (isEnable)
                {
                    if (toggle != ToggleState.On)
                    {
                        //EnableFeature.Click();
                        session.Session.Mouse.Click(EnableFeature.Coordinates);
                        Thread.Sleep(1000);
                    }
                    toggle = base.GetCheckBoxStatus(EnableFeature);
                    if (toggle == ToggleState.On)
                    {
                        return true;
                    }
                }
                else
                {
                    if (toggle != ToggleState.Off)
                    {
                        //EnableFeature.Click();
                        session.Session.Mouse.Click(EnableFeature.Coordinates);
                        Thread.Sleep(1000);
                    }
                    toggle = base.GetCheckBoxStatus(EnableFeature);
                    if (toggle == ToggleState.Off)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool ShowOrHideAlarmAndPhotoDropDown(bool isAlam, bool isShow, int trytimes = 3)
        {
            for (int i = 0; i < trytimes; i++)
            {
                if (isAlam)
                {
                    if (isShow)
                    {
                        session.Session.Mouse.Click(AlarmTimeDuration.Coordinates);
                        Thread.Sleep(1000);
                        if (GetAlarmAndPhotoDropDownListForSmartAssistPage().Count > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (GetAlarmAndPhotoDropDownListForSmartAssistPage().Count == 0)
                        {
                            return true;
                        }
                        session.Session.Mouse.Click(AlarmTimeDuration.Coordinates);
                        Thread.Sleep(1000);
                    }
                }
                else
                {
                    if (isShow)
                    {
                        session.Session.Mouse.Click(Photonum.Coordinates);
                        Thread.Sleep(1000);
                        if (GetAlarmAndPhotoDropDownListForSmartAssistPage().Count > 0)
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (GetAlarmAndPhotoDropDownListForSmartAssistPage().Count == 0)
                        {
                            return true;
                        }
                        session.Session.Mouse.Click(Photonum.Coordinates);
                        Thread.Sleep(1000);
                    }
                }
            }
            return false;
        }

        public List<WindowsElement> GetAlarmAndPhotoDropDownListForSmartAssistPage()
        {
            string dropdownlist = VantageAutomationIDCollector.Instance.GetVantageAutomationID("$.SmartAssist.alarmAndphoto").ToString();
            List<WindowsElement> elements = base.FindElementsByTimes(session.Session, "XPath", "//*[@AutomationId=\'" + dropdownlist + "\']//ListItem");
            if (elements.Count > 0)
            {
                return elements;
            }
            else
            {
                Console.WriteLine("The GetAlarmAndPhotoDropDownListForSmartAssistPage() total is 0");
            }
            return elements;
        }
    }
}
