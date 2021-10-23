using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Pages.WifiSecurityPages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_WifiSecuritySteps
{
    [Binding]
    public sealed class RemoveExcessLUDPMetricsForCHSStepDefinition
    {
        private InformationalWebDriver webDriver;
        private LenovoWifiSecurityPage _lenovoWifiSecurityPage;
        public string ExceptValue = "old state: [False,True,True,False,(Allow, Allow, Allow, , )] new state: [True,True,True,True,(Allow, Allow, Allow, , )]";

        public RemoveExcessLUDPMetricsForCHSStepDefinition(InformationalWebDriver appDriver)
        {
            webDriver = appDriver;
        }

        [When(@"Relaunch Wifi Plugin")]
        public void WhenRelaunchWifiPlugin()
        {
            Common.KillProcess("Lenovo.Modern.ImController.PluginHost.CompanionApp", true);
            VantageUI.instance.LaunchVantageWithProtocol();
        }

        [Then(@"Check (.*) ""(.*)"" Metric Data")]
        public void ThenGetEventInformationForCHS(string p0, string p1)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            List<string> contextxml = new List<string>();
            bool index = false;
            using (var reader = new EventLogReader(LenovoWifiSecurityPage.EventLogFile, PathType.FilePath))
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
                            if (name == p0)
                            {
                                string value = IntelligentCoolingBaseHelper.GetXMLValue(str, "/event/variables/var/value");
                                switch (p1)
                                {
                                    case "Get-State":
                                        index = true;
                                        Assert.AreNotEqual("Get-State", value, "There's Get-State metric data");
                                        break;
                                    case "Set-State":
                                        index = true;
                                        Assert.AreNotEqual("Set-State", value, "There's Set-State metric data");
                                        break;
                                    case "Get-WifiHistory":
                                        index = true;
                                        Assert.AreNotEqual("Get-WifiHistory", value, "There's Get-WifiHistory metric data");
                                        break;
                                    case "Get-DeviceConfig":
                                        index = true;
                                        Assert.AreNotEqual("Get-DeviceConfig", value, "There's Get-DeviceConfig metric data");
                                        break;
                                    case "Message-Clicked":
                                        index = true;
                                        Assert.AreNotEqual("Message-Clicked", value, "There's click yellow change connection metric data");
                                        break;
                                    case "Receive-MessageAction":
                                        index = true;
                                        Assert.AreNotEqual("Receive-MessageAction", value, "There's click yellow change connection metric data");
                                        break;
                                    default:
                                        throw new Exception("Please check your input text status");
                                }
                            }
                        }
                    }
                }
            }
            if (p1 == "Set-State" && index == true)
            {
                Console.WriteLine("Metric contains LenovoWiFiSecurityPlugin!");
            }
            else if ((p1 == "Get-State" || p1 == "Get-WifiHistory" || p1 == "Get-DeviceConfig" || p1 == "Message-Clicked" || p1 == "Receive-MessageAction") && index == false)
            {
                Console.WriteLine("Metric contains LenovoWiFiSecurityPlugin!");
            }
            else
            {
                Assert.Fail("LenovoWiFiSecurityPlugin metric data not correct!");
            }
        }

        [Then(@"Check Wifi Toggle (.*) Metric")]
        public void ThenCheckWifiToggleMetric(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "on":
                    _lenovoWifiSecurityPage.CheckWifiToggleMetric("enabled");
                    break;
                case "off":
                    _lenovoWifiSecurityPage.CheckWifiToggleMetric("disabled");
                    break;
                default:
                    throw new Exception("Please check your input wifi status");
            }
        }

        [Then(@"Check Wifi (.*) Toast Metric")]
        public void ThenCheckWifiToastMetric(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            _lenovoWifiSecurityPage.ReadWifiToastEventLog(p0, ExceptValue);
        }

        [StepDefinition(@"Check Wifi (.*) Toast Pop up")]
        public void WhenCheckToast(string p0)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "green":
                    int greenToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "green", "1");
                    Assert.AreEqual(1, greenToastCount, "There's no green toast pop up");
                    break;
                case "yellow":
                    int yellowToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "yellow", "1");
                    Assert.AreEqual(1, yellowToastCount, "There's no yellow toast pop up");
                    break;
                case "reenable":
                    int reenableToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "disable", "1");
                    Assert.AreEqual(1, reenableToastCount, "There's no reenable toast pop up");
                    break;
                case "red":
                    bool GetCriticalMessage = _lenovoWifiSecurityPage.GetCriticalMessage();
                    Assert.IsTrue(GetCriticalMessage, "The critical window is not shown up");
                    break;
                case "no":
                    int ToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "", "0");
                    Assert.AreEqual(0, ToastCount, "There's toast pop up");
                    break;
                default:
                    throw new Exception("Please check your input wifi status");
            }
        }

        [StepDefinition(@"Check Wifi ""(.*)"" Toast Pop up ""(.*)""")]
        public void WhenCheckWifiToastPopUp(string p0, string p1)
        {
            _lenovoWifiSecurityPage = new LenovoWifiSecurityPage(webDriver.Session);
            switch (p0)
            {
                case "green":
                    int greenToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "green", p1);
                    Assert.AreEqual(Convert.ToInt32(p1), greenToastCount, "There's no green toast pop up");
                    break;
                case "yellow":
                    int yellowToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "yellow", p1);
                    Assert.AreEqual(Convert.ToInt32(p1), yellowToastCount, "There's no yellow toast pop up");
                    break;
                case "reenable":
                    int reenableToastCount = LenovoWifiSecurityPage.LWSGetHistory("", "disable", p1);
                    Assert.AreEqual(Convert.ToInt32(p1), reenableToastCount, "There's no reenable toast pop up");
                    break;
                case "red":
                    bool GetCriticalMessage = _lenovoWifiSecurityPage.GetCriticalMessage(10);
                    if (p1.Equals("0"))
                    {
                        Assert.IsFalse(GetCriticalMessage, "The critical window should not shown up");
                    }
                    else
                    {
                        Assert.IsTrue(GetCriticalMessage, "The critical window is not shown up");
                    }
                    break;
                default:
                    throw new Exception("Please check your input wifi status");
            }
        }

        [StepDefinition(@"Check Current Network Is ""(.*)""")]
        public void ThenCheckCurrentNetworkIs(string p0)
        {
            Assert.IsTrue(DesktopPowerManagementHelper.RunCmd("netsh wlan show interface", false, true).Contains(p0));

        }

    }
}
