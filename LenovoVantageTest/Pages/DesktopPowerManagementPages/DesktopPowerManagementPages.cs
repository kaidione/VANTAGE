using LenovoVantageTest.Pages.Helper;
using LenovoVantageTest.Steps.UWP.IntelligentCooling;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;

namespace LenovoVantageTest.Pages
{
    class DesktopPowerManagementPages : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        public DesktopPowerManagementPages(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public WindowsElement LenovoVantageLogo => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='vantage_image_L']");
        public WindowsElement DPMFeatureDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='myDevice-settings-dpm-header-caption']");
        public WindowsElement DPMCollapseExpandTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-dpm-settings-collapse-card-title']");
        public WindowsElement DPMCollapseExpandLink => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='device-settings-dpm-settings-collapse-link']");

        //DPM Power use
        public WindowsElement DPMPowerUseTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-title']");
        public WindowsElement DPMPowerUseDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-description']");
        public WindowsElement DPMPowerUseDisplayLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-turnoffdisplay-label']");
        public WindowsElement DPMPowerUseDisplayDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-display-dropdown']");
        public List<WindowsElement> DPMPowerUseDisplayDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-display-dropdown']//..//ListItem");
        public WindowsElement DPMPowerUseHDDLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-turnoffhdd-label']");
        public WindowsElement DPMPowerUseHDDDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-hdd-dropdown']");
        public List<WindowsElement> DPMPowerUseHDDDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-hdd-dropdown']//..//ListItem");
        public WindowsElement DPMPowerUseSleepLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-sleep-label']");
        public WindowsElement DPMPowerUseSleepDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-sleep-dropdown']");
        public List<WindowsElement> DPMPowerUseSleepDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-sleep-dropdown']//..//ListItem");
        public WindowsElement DPMPowerUseHibernateLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-hibernate-label']");
        public WindowsElement DPMPowerUseHibernateDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-hibernate-dropdown']");
        public List<WindowsElement> DPMPowerUseHibernateDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-poweruse-hibernate-dropdown']//..//ListItem");

        //DPM Power Plan
        public WindowsElement DPMPowerPlanTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-title']");
        public WindowsElement DPMPowerPlanDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-caption']");
        public WindowsElement DPMPowerPlanLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-currentpowerplan-label']");
        public WindowsElement DPMPowerPlanDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-action-dropdown']");
        public List<WindowsElement> DPMPowerPlanDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-action-dropdown']//..//ListItem");
        public WindowsElement DPMPowerPlanProfileLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-profile-label']");
        public WindowsElement DPMPowerPlanPerformanceLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-profile-performance-label']");
        public WindowsElement DPMPowerPlanTemperatureLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-profile-temperature-label']");
        public WindowsElement DPMPowerPlanUsageLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powerplan-profile-usage-label']");

        // DPM Global Power settings
        public WindowsElement DPMPowerSettingsTitle => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-title']");
        public WindowsElement DPMPowerSettingsDescription => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-caption']");
        public WindowsElement DPMPowerButtonLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-powerbutton-label']");
        public WindowsElement DPMPowerButtonDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-powerbutton-dropdown']");
        public List<WindowsElement> DPMPowerButtonDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-powerbutton-dropdown']//..//ListItem");
        public WindowsElement DPMRequiredSignInLabel => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-requiredsignin-label']");
        public WindowsElement DPMRequiredSignInDropdown => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-requiredsignin-dropdown']");
        public List<WindowsElement> DPMRequiredSignInDropdownList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-requiredsignin-dropdown']//..//ListItem");
        public WindowsElement DPMRequiredSignInNote => base.FindElementByTimes(session, "XPath", "//*[@AutomationId='dpm-powersetting-requiredsignin-note']");

        #region Get Set DPM ExpandCollapseState

        public ExpandCollapseState GetDPMExpandCollapseState()
        {
            IntelligentCoolingBaseHelper intelligentCoolingBaseHelper = new IntelligentCoolingBaseHelper();
            if (DPMCollapseExpandLink == null)
            {
                Console.WriteLine("Info: GetDPMExpandCollapseState() => DPMCollapseExpandLink not Found! ");
                return ExpandCollapseState.LeafNode;
            }
            string status = intelligentCoolingBaseHelper.GetAttributesByPageSource(null, "ExpandCollapseState", session, "//*[@AutomationId='device-settings-dpm-settings-collapse-link']"); // DPMCollapseExpandLink.GetAttribute("ExpandCollapseState");  //DPMCollapseExpandLink.Text
            Console.WriteLine("Info: GetDPMExpandCollapseState() => " + status);
            if (status.ToLower().Contains("collapse"))
            {
                return ExpandCollapseState.Collapsed;
            }
            else if (status.ToLower().Contains("expand"))
            {
                return ExpandCollapseState.Expanded;
            }
            else
            {
                return ExpandCollapseState.LeafNode;
            }
        }

        public bool SetDPMExpandCollapseState(ExpandCollapseState state)
        {
            for (int i = 0; i < 5; i++)
            {
                if (GetDPMExpandCollapseState() != state)
                {
                    if (DPMCollapseExpandLink != null)
                    {
                        DPMCollapseExpandLink.Click();
                    }
                    else
                    {
                        Console.WriteLine("Info: SetDPMExpandCollapseState() => DPMCollapseExpandLink not Found! ");
                        return false;
                    }
                }
                Thread.Sleep(1000);
                if (GetDPMExpandCollapseState() == state)
                {
                    Console.WriteLine("Info: SetDPMExpandCollapseState() => set Sucess! ");
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Get DPM element attributes

        public enum DropDownElements
        {
            PowerUseDisplay,
            PowerUseHdd,
            PowerUseSleep,
            PowerUseHibernate,
            PowerUse,
            PowerPlan,
            PowerButton,
            RequiredSignIn
        }

        public string GetDPMDropDownMenuItemElementAttributesValue(DropDownElements dropDown, WindowsElement element)
        {
            string value = string.Empty;
            switch (dropDown)
            {
                case DropDownElements.PowerUseDisplay:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerUseHdd:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerUseSleep:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerUseHibernate:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerButton:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerPlan:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.RequiredSignIn:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                case DropDownElements.PowerUse:
                    if (element.GetAttribute("Name").Contains("selected"))
                    {
                        value = element.GetAttribute("Name").Split(new string[] { "selected" }, StringSplitOptions.None)[0].Trim();
                    }
                    else
                    {
                        value = element.GetAttribute("Name").Trim();
                    }
                    break;
                default:
                    value = "GetDPMDropDownMenuItemElementAttributesValue() not run!";
                    break;
            }
            return value;
        }

        public string GetDPMDropDownMenuElementAttributesValue(DropDownElements dropDown)
        {
            string value = string.Empty;
            switch (dropDown)
            {
                case DropDownElements.PowerUseDisplay:
                    if (DPMPowerUseDisplayDropdown.GetAttribute("Name").Contains("-display-"))
                    {
                        value = DPMPowerUseDisplayDropdown.GetAttribute("Name").Split(new string[] { "-display-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerUseDisplayDropdown.GetAttribute("Name").Split(new string[] { "TURN OFF DISPLAY AFTER:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.PowerUseHdd:
                    if (DPMPowerUseHDDDropdown.GetAttribute("Name").Contains("-hdd-"))
                    {
                        value = DPMPowerUseHDDDropdown.GetAttribute("Name").Split(new string[] { "-hdd-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerUseHDDDropdown.GetAttribute("Name").Split(new string[] { "TURN OFF HDD AFTER:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.PowerUseSleep:
                    if (DPMPowerUseSleepDropdown.GetAttribute("Name").Contains("-sleep-"))
                    {
                        value = DPMPowerUseSleepDropdown.GetAttribute("Name").Split(new string[] { "-sleep-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerUseSleepDropdown.GetAttribute("Name").Split(new string[] { "SLEEP AFTER:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.PowerUseHibernate:
                    if (DPMPowerUseHibernateDropdown.GetAttribute("Name").Contains("-hibernate-"))
                    {
                        value = DPMPowerUseHibernateDropdown.GetAttribute("Name").Split(new string[] { "-hibernate-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerUseHibernateDropdown.GetAttribute("Name").Split(new string[] { "HIBERNATE AFTER:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.PowerButton:
                    if (DPMPowerButtonDropdown.GetAttribute("Name").Contains("-powerbutton-"))
                    {
                        value = DPMPowerButtonDropdown.GetAttribute("Name").Split(new string[] { "-powerbutton-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerButtonDropdown.GetAttribute("Name").Split(new string[] { "POWER BUTTON:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.PowerPlan:
                    if (DPMPowerPlanDropdown.GetAttribute("Name").Contains("-action-"))
                    {
                        value = DPMPowerPlanDropdown.GetAttribute("Name").Split(new string[] { "-action-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMPowerPlanDropdown.GetAttribute("Name").Split(new string[] { "CURRENT PLAN" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                case DropDownElements.RequiredSignIn:
                    if (DPMRequiredSignInDropdown.GetAttribute("Name").Contains("-requiredsignin-"))
                    {
                        value = DPMRequiredSignInDropdown.GetAttribute("Name").Split(new string[] { "-requiredsignin-" }, StringSplitOptions.None)[1].Trim();
                    }
                    else
                    {
                        value = DPMRequiredSignInDropdown.GetAttribute("Name").Split(new string[] { "REQUIRED SIGN IN:" }, StringSplitOptions.None)[1].Trim();
                    }
                    break;
                default:
                    value = "GetDPMDropDownMenuElementAttributesValue() not run!";
                    break;
            }
            return value;
        }

        #endregion

        public bool TakeScreenShotsForEachPredefinedPowerPlanProfile()
        {
            try
            {
                if (DPMPowerPlanDropdownList.Count <= 0)
                {
                    DPMPowerPlanDropdown.Click();
                }
                Thread.Sleep(2000);
                foreach (var item in DesktopPowerManagementHelper.DPMPowerPlanDefault)
                {

                    UserSelectOnePowerPlanInDropDownMenu(item);
                    AddScreenshotIntoReport("Plan_Profile_Predefined_VAN17320_TestStep04_" + item, "DPM", "DPM");
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("TakeScreenShotsForEachPredefinedPowerPlanProfile,Exception Info: " + ex.Message);
                return false;
            }
        }

        public bool UserSelectOnePowerPlanInDropDownMenu(string plan)
        {
            try
            {
                if (DPMPowerPlanDropdownList.Count <= 0)
                {
                    DPMPowerPlanDropdown.Click();
                }
                Thread.Sleep(2000);
                foreach (var item in DPMPowerPlanDropdownList)
                {
                    if (GetDPMDropDownMenuItemElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerPlan, item) == plan)
                    {
                        item.Click();
                        Thread.Sleep(1000);
                        break;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("User select one power plan in drop down menu,Exception Info: " + ex.Message);
                return false;
            }
        }

        public Tuple<string, string, string, string, bool> GetDPMPagePowerPlantValues()
        {
            Tuple<string, string, string, string, bool> tuple;
            try
            {
                string displayvalue = GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseDisplay);
                string hddvalue = GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHdd);
                string sleepvalue = GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseSleep);
                string hibernatevalue = GetDPMDropDownMenuElementAttributesValue(DesktopPowerManagementPages.DropDownElements.PowerUseHibernate);
                tuple = new Tuple<string, string, string, string, bool>(displayvalue, hddvalue, sleepvalue, hibernatevalue, true);
                return tuple;
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetDPMPagePowerPlantValues(),Exception Info: " + ex.Message);
                tuple = new Tuple<string, string, string, string, bool>("null", "null", "null", "null", false);
                return tuple;
            }
        }

    }
}
