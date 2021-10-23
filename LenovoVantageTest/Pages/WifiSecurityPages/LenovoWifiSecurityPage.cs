using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Threading;
using System.Windows.Automation;
using Windows.UI.Notifications;

namespace LenovoVantageTest.Pages.WifiSecurityPages
{
    class LenovoWifiSecurityPage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private InvokePattern invokePattern;

        public LenovoWifiSecurityPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }
        public WindowsElement GamingSetIcon => base.FindElementByTimes(session, "AutomationId", "quicksettings_wifisecurity");
        public WindowsElement GamingWiFiSecurityToggleOff => base.FindElementByTimes(session, "AutomationId", "gaming.dashboard.device.quickSettings.wifiSecurity_toggle_off", 30, 2);
        public WindowsElement GamingDevice => base.FindElementByTimes(session, "AutomationId", "menu-main-nav-lnk-device");
        public WindowsElement GamingWiFiSecurityToggleOn => base.FindElementByTimes(session, "AutomationId", "gaming.dashboard.device.quickSettings.wifiSecurity_toggle_on", 30, 2);
        public WindowsElement WSStatusText => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='security-wifi-header-title']//..//Text[5]");
        public WindowsElement WifiCheckThreatBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-openlocator", 10);
        public WindowsElement WifiEnableWifiSecurityBtn => base.FindElementByTimes(session, "XPath", "//Button[@Name='Enable Wifi security']");
        public WindowsElement WifiNetworkHistoryTitle => base.FindElementByTimes(session, "AutomationId", "sa-ws-lnk-panel-expansion-panel-header-customize");
        public WindowsElement WifiExpandBtn => base.FindElementByTimes(session, "XPath", "//Button[@Name='Network History Expand']");
        public WindowsElement WifiIntroduction => base.FindElementByTimes(session, "AutomationId", "widget-security-content-card");
        public WindowsElement LocationDialogCloseBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-locationClose");
        public WindowsElement LocationDialogAgreeBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-locationAgree");
        public WindowsElement LocationDialogCancelnBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-locationCancel");
        public WindowsElement WifiToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.WifiSecurity.WiFiSecurityToggle"));
        public WindowsElement ShowMoreBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-wh-showmore");
        public WindowsElement ShowLessBtn => base.FindElementByTimes(session, "AutomationId", "sa-ws-btn-wh-showless");
        public WindowsElement WifiTab => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.WifiSecurity.tab"));
        public WindowsElement WifiStatusInAdvanceSecurity => base.FindElementByTimes(session, "AutomationId", "sa-ov-widget-security-status-1");
        public WindowsElement AdvancedSecurity => base.FindElementByTimes(session, "AutomationId", "sa-ov-nav-advanced");
        public WindowsElement WifiLinkInAS => base.FindElementByTimes(session, "AutomationId", "sa-ov-link-wifiSecurity");
        public static string RedToastIgnore = "//*[@AutomationId='ExpanderMoreInfo']//..//Text[2]";
        public static string RedToastChangeConnect = "//*[@AutomationId='ExpanderMoreInfo']//..//Text[1]";
        public static string RedToastMoreInfo = "//*[@AutomationId='ExpanderMoreInfo']";
        public static string HomepageToggleGaming = "gaming.dashboard.device.quickSettings.wifiSecurity_toggle_off";
        public static string CriticalMoreInfo = "HeaderSite";
        public static string EventLogFile = @"C:\Windows\System32\winevt\Logs\Lenovo-Sif-Companion%4Operational.evtx";
        public static string AppUserModelId = "E046963F.LenovoCompanion_k1h2ywk1493x8!App";
        public static string GreenToastTitle = "Lenovo WiFi SecurityLenovo WiFi Security is monitoring your connection";
        public static string YellowToastTitle = "Lenovo WiFi Security has detected potentially malicious activity on";
        public static string ReenableTitle = "Lenovo WiFi SecurityLenovo WiFi Security has been disabled and is no longer monitoring your network safety.";
        public static string DisabledToast = "has been disabled";

        public void ClickCriticalButton(string button)
        {
            AutomationElement target = null;
            if (button.ToLower().Equals("moreinfo"))
            {
                target = VantageCommonHelper.FindElementByIdIsEnabled(CriticalMoreInfo);
                string x = target.Current.BoundingRectangle.X + target.Current.BoundingRectangle.Width / 2 + "";
                string y = target.Current.BoundingRectangle.Y + target.Current.BoundingRectangle.Height / 2 + "";
                VantageCommonHelper.SetMouseClick(x, y);
            }
            else
            {
                target = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, (new PropertyCondition(AutomationElement.NameProperty, button)));
                if (target != null)
                {
                    invokePattern = target.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    invokePattern.Invoke();
                }
            }
        }

        public bool GetCriticalMessage(int index = 300)
        {
            WindowsDriver<WindowsElement> appSession = base.GetControlPanelSession(true);
            for (int i = 0; i < index; i++)
            {
                Thread.Sleep(1000);
                WindowsElement element1 = FindElementByTimes(appSession, "XPath", "//*[@AutomationId='ExpanderMoreInfo']//..//Text[2]", 10);
                if (element1 == null)
                {
                    continue;
                }
                WindowsElement element2 = FindElementByTimes(appSession, "XPath", RedToastIgnore, 10);
                WindowsElement element3 = FindElementByTimes(appSession, "XPath", RedToastChangeConnect, 10);
                WindowsElement element4 = FindElementByTimes(appSession, "XPath", RedToastMoreInfo, 10);
                if (element1 != null && element2 != null && element3 != null && element4 != null)
                {
                    return true;
                }
            }
            return false;
        }

        public void CheckWifiToggleMetric(string ToggleStatus)
        {
            List<string> contextxml = new List<string>();
            using (var reader = new EventLogReader(EventLogFile, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoWiFiSecurityPlugin"))
                        {
                            contextxml.Add(record.FormatDescription());
                            string str = record.FormatDescription();
                            string name = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/name");
                            string value = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value");
                            if (name == "TaskAction" && value == "Set-State")
                            {
                                string taskResultDec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/name", "", 3);
                                string stateResult = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 3);
                                if (taskResultDec == "TaskParm")
                                {
                                    switch (ToggleStatus)
                                    {
                                        case "enabled":
                                            Assert.AreEqual("True", stateResult, "Turn on toggle and wifi metric not correct.");
                                            break;
                                        case "disabled":
                                            Assert.AreEqual("False", stateResult, "Turn off toggle and wifi metric not correct.");
                                            break;
                                        default:
                                            throw new Exception("Please check your input wifi status");
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }

        public void ReadWifiToastEventLog(string button, string ExceptValue)
        {
            bool index = false;
            List<string> contextxml = new List<string>();
            using (var reader = new EventLogReader(EventLogFile, PathType.FilePath))
            {
                EventRecord record;
                while ((record = reader.ReadEvent()) != null)
                {
                    using (record)
                    {
                        if (record.FormatDescription().Contains("LenovoWiFiSecurityPlugin"))
                        {
                            contextxml.Add(record.FormatDescription());
                            Debug.WriteLine("{0} {1}: {2}", record.TimeCreated, record.LevelDisplayName, record.FormatDescription());
                            string str = record.FormatDescription();
                            string name = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/name");
                            string value = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value");
                            if (button == "reenable Set-State")
                            {
                                if (name == "TaskAction" && value == "Set-State")
                                {
                                    string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 5);
                                    Assert.AreEqual(ExceptValue, taskresultdec, "Except value not equal actully result");
                                    index = true;
                                }
                            }
                            else if (button == "IMC and Plugin")
                            {
                                if (name == "GetEnvInfo")
                                {
                                    index = true;
                                    string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 1);
                                    var LWSConfig = CHSWebEnvPage.GetAccount("LWSConfig");
                                    string IMCVersion = LWSConfig[0];
                                    string PluginVersion = LWSConfig[1];
                                    Assert.AreEqual(IMCVersion, value, "IMC version is not " + IMCVersion);
                                    Assert.AreEqual(PluginVersion, taskresultdec, "Plugin version is not " + PluginVersion);
                                }
                            }
                            else if (button == "Receive-MessageAction")
                            {
                                if (name == "TaskAction" && value.Equals("Receive-MessageAction"))
                                {
                                    index = true;
                                    string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 1);
                                    Assert.AreEqual("request", taskresultdec, "There's no Receive-MessageAction metric data");
                                }
                            }
                            else if (button == "msm-Connected" && name == "TaskAction" && value == "msm-Connected")
                            {
                                index = true;
                                string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 1);
                                Assert.AreEqual("event", taskresultdec, "There's no nomsm-Disconnected metric data");
                            }
                            else if (button == "msm-Disconnected" && name == "TaskAction" && value == "msm-Disconnected")
                            {
                                index = true;
                                string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 1);
                                Assert.AreEqual("event", taskresultdec, "There's no msm-Disconnected metric data");
                            }
                            else if (value == "Popup-Message")
                            {
                                index = true;
                                string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 3);
                                switch (button)
                                {
                                    case "green":
                                        Assert.AreEqual("1BD7303D-804D-488E-8F2D-4F5798734D61", taskresultdec, "There's no green toast metric data");
                                        break;
                                    case "yellow":
                                        Assert.AreEqual("D13FC316-87AD-4B99-817E-D0BC4668D236", taskresultdec, "There's no yellow toast metric data");
                                        break;
                                    case "red":
                                        Assert.AreEqual("BF6B32E3-5113-4436-AE89-CC8793FCD222", taskresultdec, "There's no yellow toast metric data");
                                        break;
                                    case "reenable":
                                        Assert.AreEqual("F67C52D4-5401-46D8-9248-A03DF7E2C2D3", taskresultdec, "There's no yellow toast metric data");
                                        break;
                                    default:
                                        throw new Exception("Please check your input wifi status");
                                }
                            }
                            else if (value.Equals("Message-Clicked"))
                            {
                                index = true;
                                string taskresultdec = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value", "", 3);
                                switch (button)
                                {
                                    case "reenable":
                                        Assert.AreEqual("reenable", taskresultdec, "There's no click reenable metric data");
                                        break;
                                    case "yellow ignore":
                                        Assert.AreEqual("cancel", taskresultdec, "There's no click cancel metric data");
                                        break;
                                    case "content":
                                        Assert.AreEqual("content", taskresultdec, "There's no click content metric data");
                                        break;
                                    case "ok":
                                        Assert.AreEqual("ok", taskresultdec, "There's no click ok metric data");
                                        break;
                                    case "no thanks":
                                        Assert.AreEqual("no", taskresultdec, "There's no click no-thanks metric data");
                                        break;
                                    case "red change connection":
                                        Assert.AreEqual("Change connection", taskresultdec, "There's no click change connecton metric data");
                                        break;
                                    case "red ignore":
                                        Assert.AreEqual("cancel", taskresultdec, "There's no click ignore metric data");
                                        break;
                                    default:
                                        throw new Exception("Please check your input wifi status");
                                }
                            }
                        }
                    }
                }
            }
            if (index == true)
            {
                Console.WriteLine("Metric contains LenovoWiFiSecurityPlugin!");
            }
            else
            {
                Assert.Fail("LenovoWiFiSecurityPlugin metric data not correct!");
            }
        }

        public static int LWSGetHistory(string timeOut, string compareType, string expectCount)
        {
            var notifs = ToastNotificationManager.History.GetHistory(AppUserModelId);
            int oldHistorycount = ToastNotificationManager.History.GetHistory(AppUserModelId).Count;
            int newHistorycount = 0;
            int index = 100;
            if (expectCount != "0")
            {
                index = 600;
            }
            else { index = 10; }
            if (!string.IsNullOrEmpty(timeOut))
            {
                index = Convert.ToInt32(timeOut);
            }
            int currentExpectCount = 0;
            string compareText = GreenToastTitle;
            if (!string.IsNullOrEmpty(compareType))
            {
                switch (compareType)
                {
                    case "green":
                        compareText = GreenToastTitle;
                        break;
                    case "yellow":
                        compareText = YellowToastTitle;
                        break;
                    case "disable":
                        compareText = DisabledToast;
                        break;
                    default:
                        break;
                }
            }
            bool flag = false;
            while (index > 0)
            {
                newHistorycount = ToastNotificationManager.History.GetHistory(AppUserModelId).Count;
                if (newHistorycount >= oldHistorycount)
                {

                    Thread.Sleep(1000);
                    notifs = ToastNotificationManager.History.GetHistory(AppUserModelId);
                    foreach (ToastNotification notify in notifs)
                    {
                        if (notify.Content.InnerText.Contains(compareText))
                        {
                            flag = true;
                            currentExpectCount++;
                        }
                    }
                    if (flag)
                    {
                        break;
                    }
                }
                else
                {
                    notifs = ToastNotificationManager.History.GetHistory(AppUserModelId);
                    foreach (ToastNotification notify in notifs)
                    {
                        if (notify.Content.InnerText.Contains(compareText))
                        {
                            currentExpectCount++;
                        }
                    }
                }
                Thread.Sleep(500);
                index--;
            }

            if (!string.IsNullOrEmpty(expectCount) && currentExpectCount == Convert.ToInt32(expectCount))
            {
                return currentExpectCount;
            }
            else
            {
                return currentExpectCount;
            }
        }

        public void ClickContentButton()
        {
            string conent = "Lenovo WiFi Security has been disabled and is no longer monitoring your network safety.";
            HSSmartAssistPage hSSmartAssist = new HSSmartAssistPage(null);
            WindowsDriver<WindowsElement> appsession = hSSmartAssist.GetControlPanelSession(true);
            WindowsElement element = FindElementByTimes(appsession, "Name", conent);
            Assert.NotNull(element, "The " + conent + " not found.");
            element.Click();
        }
    }
}
