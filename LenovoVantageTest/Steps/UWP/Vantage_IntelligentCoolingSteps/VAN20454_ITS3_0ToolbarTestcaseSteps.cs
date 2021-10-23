using LenovoVantageTest.Pages;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using TangramTest.Utility;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_IntelligentCoolingSteps
{
    [Binding]
    public class VAN20454_ITS3_0ToolbarTestcaseSteps
    {
        private WindowsDriver<WindowsElement> _session;
        private IntelligentCoolingPages _intelligentcoolingPages;
        IntelligentCoolingBaseHelper _baseHelper = new IntelligentCoolingBaseHelper();
        public static string NarratorRegistry = "SOFTWARE\\Microsoft\\Windows NT\\CurrentVersion\\Accessibility\\ATConfig\\narrator";
        public VAN20454_ITS3_0ToolbarTestcaseSteps(InformationalWebDriver appDriver)
        {
            this._session = appDriver.Session;
        }

        [Given(@"change DPI (.*)")]
        public void GivenChangeDPI(string num)
        {
            ChangeDPI(num);
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
            IntelligentCoolingBaseHelper.DeleteFile();
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
                ExpandCollapsePattern comboxSelect = IntelligentCoolingBaseHelper.GetSelectionPattern(combox);
                comboxSelect.Expand();
                Thread.Sleep(TimeSpan.FromSeconds(1));
                AutomationElementCollection selectionList = combox.FindAll(TreeScope.Children, Condition.TrueCondition);
                int maxLen = selectionList.Count - 2;
                switch (dpiValue)
                {
                    case "max":
                        IntelligentCoolingBaseHelper.GetSelectionItemPattern(selectionList[maxLen]).Select();
                        break;
                    case "min":
                        IntelligentCoolingBaseHelper.GetSelectionItemPattern(selectionList[0]).Select();
                        break;
                    case "125":
                        IntelligentCoolingBaseHelper.GetSelectionItemPattern(selectionList[1]).Select();
                        break;
                    case "150":
                        IntelligentCoolingBaseHelper.GetSelectionItemPattern(selectionList[2]).Select();
                        break;
                    case "175":
                        IntelligentCoolingBaseHelper.GetSelectionItemPattern(selectionList[3]).Select();
                        break;
                    default:
                        foreach (AutomationElement e in selectionList)
                        {
                            if (e.Current.Name.ToLower().Contains(dpiValue))
                            {
                                IntelligentCoolingBaseHelper.GetSelectionItemPattern(e).Select();
                            }
                        }
                        break;
                }
            }
            KillProcess();
            return dpiValue;
        }

    }
}
