using LenovoVantageTest.Helper;
using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using TechTalk.SpecFlow;
using static LenovoVantageTest.Steps.UWP.IntelligentCooling.IntelligentCoolingBaseHelper;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public sealed class IntelligentCoolingThinkpadDytc6MWSUIStepDefinition
    {
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        private bool _isSupport = false;
        private string _tips = string.Empty;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();

        public IntelligentCoolingThinkpadDytc6MWSUIStepDefinition(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"click power smart settings")]
        public void GivenClickPowerSmartSettings()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            _intelligentcoolingPages.HSJumpToSmartSettings?.Click();
        }

        [Given(@"adjusts window size")]
        public void GivenAdjustsWindowSize()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            _intelligentcoolingPages.VangtageMax?.Click();
        }

        [Given(@"change DPI (.*)")]
        public void GivenChangeDPI(string num)
        {
            ChangeDPI(num);
        }

        [Given(@"change resolution (.*) to (.*)")]
        public void GivenChangeResolutionTo(int width, int height)
        {
            string info = ChangeResolution(width, height);
            Console.WriteLine("GivenChangeResolutionTo info:" + info);
            Thread.Sleep(6000);
        }

        [Given(@"recover DPI")]
        public void GivenRecoverDPI()
        {
            ChangeDPI("recommended");
        }

        public void KillProcess()
        {
            Process[] processes = Process.GetProcessesByName("SystemSettings");
            if (processes.Length > 0)
            {
                foreach (Process ps in processes)
                {
                    ps.Kill();
                }
            }
        }

        public string ChangeDPI(string dpiValue)
        {
            DeleteFile();
            KillProcess();
            Common.StartProcess("desk.cpl");
            AutomationElement mainWindow = null;
            do
            {
                mainWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
            } while (mainWindow == null);

            UIAutomationControl ua = new UIAutomationControl();
            List<AutomationElement> settinglist = ua.FindAllElementsInRootElementPlus(mainWindow, "SystemSettings_Display_Scaling_ItemSizeOverride_ComboBox");
            if (settinglist.Count > 0)
            {
                AutomationElement combox = settinglist[0];
                ExpandCollapsePattern comboxSelect = GetSelectionPattern(combox);
                comboxSelect.Expand();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                AutomationElementCollection selectionList = combox.FindAll(TreeScope.Children, Condition.TrueCondition);
                int maxLen = selectionList.Count - 2;
                switch (dpiValue)
                {
                    case "max":
                        GetSelectionItemPattern(selectionList[maxLen]).Select();
                        break;
                    case "min":
                        GetSelectionItemPattern(selectionList[0]).Select();
                        break;
                    case "125":
                        GetSelectionItemPattern(selectionList[1]).Select();
                        break;
                    case "150":
                        GetSelectionItemPattern(selectionList[2]).Select();
                        break;
                    case "175":
                        GetSelectionItemPattern(selectionList[3]).Select();
                        break;
                    default:
                        foreach (AutomationElement e in selectionList)
                        {
                            if (e.Current.Name.ToLower().Contains(dpiValue))
                            {
                                GetSelectionItemPattern(e).Select();
                            }
                        }
                        break;
                }
            }
            KillProcess();
            return dpiValue;
        }

        [Given(@"The Machine support Intelligent Cooling for Thinkpad DYTC Six")]
        public void GivenTheMachineSupportIntelligentCoolingForThinkpadDYTCSix()
        {
            _isSupport = _baseHelper.CheckMachineSupportIntelligentCooling("6", "think", true);
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
            _tips = "Get the machine if support dytc 6 for thinkpad.";
        }

        [Given(@"The Machine is CS20 CS21 Machine")]
        public void GivenTheMachineIsCS20CS21Machine()
        {
            Assert.IsTrue(_isSupport);
            string type = VantageCommonHelper.GetCurrentMachineType();
            if (type == "ThinkPad P15v Gen 1")
            {
                _isSupport = true;
                _tips += "\r\nThe machine support dytc6 and it's CS20 CS21 mobile workstations. Machine：" + type;
            }
            else
            {
                _isSupport = false;
                _tips += "\r\nThe machine support dytc6 and it not CS20 CS21 mobile workstations. Machine：" + type;
            }
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
        }

        [Given(@"The Machine does not support Intelligent Cooling for CS20 CS21 Machine")]
        public void GivenTheMachineDoesNotSupportIntelligentCoolingForCS20CS21Machine()
        {
            Assert.IsFalse(_isSupport, _tips);
            _isSupport = true;
            _tips = "The machine  isn't CS20 CS21 mobile workstations. ";
            IntelligentCoolingResetExecution.isSupport = _isSupport;
            IntelligentCoolingResetExecution.tips = _tips;
        }

        [Then(@"The Intelligent Cooling feature will not show for Thinkpad DYTC Six CS20 CS21")]
        public void ThenTheIntelligentCoolingFeatureWillNotShowForThinkpadDYTCSixCS20CS21()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            if (_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink == null && _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20LessLink == null)
            {
                return;
            }
            else
            {
                _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink?.Click();
            }
            Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20QuietModeDesc, "The Quiet mode still show \r\n" + _tips);
        }


        [Then(@"The Intelligent Cooling feature will show for Thinkpad DYTC Six CS20 CS21")]
        public void ThenTheIntelligentCoolingFeatureWillShowForThinkpadDYTCSixCS20CS21()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            if (_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink == null && _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20LessLink == null)
            {
                Assert.Fail("The more link not show");
            }
            else
            {
                _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink?.Click();
            }
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20QuietModeDesc, "The Ultra-performance mode not show \r\n" + _tips);
        }

        [Then(@"The Intelligent Cooling feature will show or hide for container collapse expand (.*)")]
        public void ThenTheIntelligentCoolingFeatureWillShowOrHideForContainerCollapseExpand(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings, "The Jump link not found.");
                    if (_intelligentcoolingPages.IntelligentCoolingTitleThink != null || _intelligentcoolingPages.IntelligentCoolingTitle != null)
                    {
                        Assert.IsTrue(true, "The Intelligent Cooling Title not found");
                    }
                    else
                    {
                        Assert.IsTrue(false, "The Intelligent Cooling Title not found");
                    }
                    break;
                case "hide":
                    Assert.IsNotNull(_intelligentcoolingPages.HSJumpToSmartSettings, "The Jump link not found.");
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingTitleThink, "The Intelligent Cooling Title still show");
                    Assert.IsNull(_intelligentcoolingPages.IntelligentCoolingTitle, "The Intelligent Cooling Title still show");
                    break;
                default:
                    Assert.Fail("ThenTheIntelligentCoolingFeatureWillShowOrHide not run");
                    break;
            }
        }


        [Then(@"Intelligent Cooling container card Collapse or Expand (.*)")]
        public void ThenIntelligentCoolingContainerCardCollapseOrExpand(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingCollapseExpand, "ExpandCollapse.ExpandCollapseState");
            switch (status.ToLower())
            {
                case "collapse":
                    Assert.IsTrue(desc.Contains(status.ToLower()), "The Intelligent Cooling Container Card Collapse is null");
                    break;
                case "expand":
                    Assert.IsTrue(desc.Contains(status.ToLower()), "The Intelligent Cooling Container Card Expand is null");
                    break;
                default:
                    Assert.Fail("ThenIntelligentCoolingContainerCardCollapseOrExpand not run");
                    break;
            }
        }

        [When(@"The User click Intelligent Cooling container to (.*) card")]
        public void WhenTheUserClickIntelligentCoolingContainerToCard(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            var desc = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingCollapseExpand, "Name");
            switch (status.ToLower())
            {
                case "collapse":
                    if (desc.Contains(status.ToLower()) == false)
                    {
                        _intelligentcoolingPages.IntelligentCoolingCollapseExpand.Click();
                    }
                    break;
                case "expand":
                    if (desc.Contains(status.ToLower()) == false)
                    {
                        _intelligentcoolingPages.IntelligentCoolingCollapseExpand.Click();
                    }
                    break;
                default:
                    Assert.Fail("WhenTheUserClickIntelligentCoolingContainerCard not run");
                    break;
            }
        }

        [When(@"The User click Intelligent Cooling (.*) link for Thinkpad DYTC Six CS20 CS21")]
        public void WhenTheUserClickIntelligentCoolingLinkForThinkpadDYTCSixCS20CS21(string infostatus)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            switch (infostatus.ToLower())
            {
                case "less":
                    _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20LessLink?.Click();
                    break;
                case "more":
                    _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20MoreLink?.Click();
                    break;
                default:
                    Assert.Fail("WhenTheUserClickIntelligentCoolingLinkForThinkpadDYTCSixCS20CS21 not run");
                    break;
            }
        }

        [Then(@"The Intelligent Cooling will (.*) all descriptions on Power Smart Settings section")]
        public void ThenTheIntelligentCoolingWillAllDescriptionsOnPowerSmartSettingsSection(string status)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            WindowsElement quiet = null;
            WindowsElement ultraperformance = null;
            if (VantageConstContent.NotLEMask)
            {
                //Common version 
                quiet = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20QuietModeDesc;
                ultraperformance = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20UltraPerformanceModeDesc;
            }
            else
            {
                //LE version
                quiet = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20QuietModeDescLE;
            }
            var blance = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20BalancedModeDesc;
            var performance = _intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20PerformanceModeDesc;
            switch (status.ToLower())
            {
                case "show":
                    Assert.IsNotNull(quiet, "The Quiet Mode is Null");
                    Assert.IsNotNull(blance, "The Balanced Mode is Null");
                    Assert.IsNotNull(performance, "The Performance Mode is Null");
                    if (VantageConstContent.NotLEMask)
                    {
                        Assert.IsNotNull(ultraperformance, "The Ultra Performance Mode is Null");
                    }
                    break;
                case "hide":
                    Assert.IsNull(quiet, "The Quiet Mode is not Null");
                    Assert.IsNull(blance, "The Balanced Mode is not Null");
                    Assert.IsNull(performance, "The Performance Mode is not Null");
                    Assert.IsNull(ultraperformance, "The Ultra Performance Mode is not Null");
                    break;
                default:
                    Assert.Fail("ThenTheIntelligentCoolingWillAllDescriptionsOnPowerSmartSettingsSection not run");
                    break;
            }
        }

        [Then(@"The intelligent cooling Read more description will be display for Thinkpad DYTC Six CS20 CS21")]
        public void ThenTheIntelligentCoolingReadMoreDescriptionWillBeDisplayForThinkpadDYTCSixCS20CS21(string multilineText)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string[] tempobj = multilineText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var quiet = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20QuietModeDesc, "Name");
            var ultraperformance = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20UltraPerformanceModeDesc, "Name");
            var balance = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20BalancedModeDesc, "Name");
            var performance = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20PerformanceModeDesc, "Name");
            if (VantageConstContent.NotLEMask)
            {
                Assert.AreEqual(tempobj[0], quiet, "Verify Quiet Mode Desc");
                Assert.AreEqual(tempobj[1], balance, "Verify Balanced Mode Desc");
                Assert.AreEqual(tempobj[2], performance, "Verify Performance Mode Desc");
                Assert.AreEqual(tempobj[3], ultraperformance, "Verify Ultra Performance Mode Desc");
            }
            else
            {
                Assert.AreEqual(tempobj[4], quiet, "Verify Quiet Mode Desc");
                Assert.AreEqual(tempobj[1], balance, "Verify Balanced Mode Desc");
                Assert.AreEqual(tempobj[2], performance, "Verify Performance Mode Desc");
                Assert.AreEqual(null, ultraperformance, "Verify Ultra Performance Mode Desc");
            }
        }

        [Then(@"The intelligent cooling description will be display for Thinkpad DYTC Six CS20 CS21")]
        public void ThenTheIntelligentCoolingDescriptionWillBeDisplayForThinkpadDYTCSixCS20CS21(string multilineText)
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            string[] tempobj = multilineText.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            var desc01 = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc01, "Name");
            var desc02 = _baseHelper.GetAttributesByPageSource(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Desc02, "Name");
            Assert.AreEqual(tempobj[0], desc01, "Verify Intelligent Cooling Description 01");
            Assert.AreEqual(tempobj[1], desc02, "Verify Intelligent Cooling Description 02");
        }

        [Then(@"The Intelligent Cooling feature images will show for Thinkpad DYTC Six CS20 CS21")]
        public void ThenTheIntelligentCoolingFeatureImagesWillShowForThinkpadDYTCSixCS20CS21()
        {
            _intelligentcoolingPages = new IntelligentCoolingPages(_session);
            Assert.IsNotNull(_intelligentcoolingPages.IntelligentCoolingThinkDYTC6CS20Images, "The Intelligent Cooling images not found.");
        }

        [When(@"The user connect or disconnect WiFi (.*) (.*)")]
        public void WhenTheUserConnectOrDisconnectWiFi(string status, string wifiname)
        {
            bool tag = false;
            int index = 0;
            switch (status.ToLower())
            {
                case "on":
                    tag = DesktopPowerManagementHelper.RunCmd("netsh wlan show interface", false, true).Contains(wifiname);
                    while (!tag && index <= 10)
                    {
                        _baseHelper.ConnectWiFi(wifiname);
                        Logger.Instance.WriteLog($"connectwifi {wifiname}", LogType.Information);
                        Thread.Sleep(2000);
                        tag = DesktopPowerManagementHelper.RunCmd("netsh wlan show interface", false, true).Contains(wifiname);
                        index++;
                    };
                    if (!tag)
                    {
                        Logger.Instance.WriteLog($"connectwifi {wifiname} fail", LogType.Information);
                    }
                    break;
                case "off":
                    tag = DesktopPowerManagementHelper.RunCmd("netsh wlan show interface", false, true).Contains("disconnected");
                    while (!tag && index <= 10)
                    {
                        _baseHelper.DisconnectWiFi();
                        Thread.Sleep(3000);
                        tag = DesktopPowerManagementHelper.RunCmd("netsh wlan show interface", false, true).Contains("disconnected");
                        index++;
                    };
                    break;
                default:
                    Assert.Fail("The WhenTheUserConnectOrDisconnectWiFi not Run");
                    break;
            }
        }


    }
}
