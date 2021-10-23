using OpenQA.Selenium.Appium.Windows;

namespace LenovoVantageTest.Pages.HardwareSettingsPages
{
    class HSSmartAssistPage : SettingsBase
    {

        private WindowsDriver<WindowsElement> session;

        public WindowsElement AutoScreenOffToggle => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.IntelligentScreen.AutoScreenOffToggle"), 10);
        public WindowsElement IntelligentScreenlink => base.GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.IntelligentScreen.IntelligentScreenlink"), 10);
        public WindowsElement AutoScreenOffNeverTip => base.GetElement(session, "Name", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.IntelligentScreen.AutoScreenOffNeverTip"), 10);
        public WindowsElement AutoScreenOffNeverTipHD => base.GetElement(session, "Name", "This feature is not available if your Power Plan settings are set to \"never turn off the screen on battery\" in the Windows Settings \"System section\". Please select a value other than \"Never\" to enable this feature.", 10);

        //ActiveProtectionSystem Section
        public WindowsElement APSJumpLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSJumpLink"));
        public WindowsElement APSDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSDesc"));
        public WindowsElement APSToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSToggle"));
        public WindowsElement ActiveProtectionDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ActiveProtectionDesc"));
        public WindowsElement ActiveProtectionSlider => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ActiveProtectionSlider"));
        public WindowsElement ActiveProtectionCheckBox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ActiveProtectionCheckBox"));
        public WindowsElement ManualActiveProtectionSuspensionTitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ManualActiveProtectionSuspensionTitle"));
        public WindowsElement ManualActiveProtectionSuspensionDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ManualActiveProtectionSuspensionDesc"));
        public WindowsElement ManualActiveProtectionSuspensionToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ManualActiveProtectionSuspensionToggle"));
        public WindowsElement ManualSnoozeTimeDropDown => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ManualSnoozeTimeDropDown"));
        public WindowsElement ManualActiveProtectionSuspensionBtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.ManualActiveProtectionSuspensionBtn"));
        public WindowsElement APSPenInputToggle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSPenInputToggle"));
        public WindowsElement APSAdvanceSettingsLinkXpath => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSAdvanceSettingsLinkXpath"));
        public WindowsElement APSPenIntervalsDropDown => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSPenIntervalsDropDown"));
        public WindowsElement APSAdvanceSettingsDesc => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSAdvanceSettingsDesc"));
        public WindowsElement APSAdvancedHandTitle => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSAdvancedHandTitle"));
        public WindowsElement APSAdvancedHandToggle => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSAdvancedHandToggle"));
        public WindowsElement APSTouchInputTitle => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSTouchInputTitle"));
        public WindowsElement APSTouchInputToggle => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.APS.APSTouchInputToggle"));
        public WindowsElement DisplayCollapse => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayCollapse"));
        public WindowsElement DisplayintelligentScreen => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayintelligentScreen"));
        public WindowsElement DisplayAutSscreenOff => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayAutSscreenOff"));
        public WindowsElement DisplayKeepMyDisplay => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayKeepMyDisplay"));
        public WindowsElement DisplayContextDescription => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayContextDescription"));
        public WindowsElement DisplayAutoScreenOfCaption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayAutoScreenOfCaption"));
        public WindowsElement DisplayContextDescriptionred => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayContextDescriptionred"));
        public WindowsElement DisplayKeepMyDisplayCaption => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayKeepMyDisplayCaption"));
        public WindowsElement DisplaySlidertitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplaySlidertitle"));
        public WindowsElement DisplaySlider => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplaySlider"));
        public WindowsElement DisplayCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.DisplayCheckbox"));
        public WindowsElement Keepmydisplaybtn => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.Keepmydisplaybtn"));
        public WindowsElement MinMinutes => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.MinMinutes"));
        public WindowsElement MaxMinutes => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.MaxMinutes"));

        //Zero Touch Lock
        public WindowsElement ZeroTouchLocktitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.ZeroTouchLocktitle"));
        public WindowsElement zeroTouchLockButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.zeroTouchLockButton"));
        public WindowsElement AutoScreenTimeoutCheckbox => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.AutoScreenTimeoutCheckbox"));
        public WindowsElement AutoScreenTimeoutCheckboxtitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.AutoScreenTimeoutCheckboxtitle"));
        public WindowsElement AutoScreenTimeoutCheckboxText => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.AutoScreenTimeoutCheckboxText"));
        public WindowsElement AutoScreenTimeoutCheckboxLink => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.AutoScreenTimeoutCheckboxLink"));
        public WindowsElement SmartAssistScreenTimeoutDesc => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartAssistScreenTimeoutDesc"));
        public WindowsElement SmartAssistScreenTimeoutDescNever => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartAssistScreenTimeoutDescNever"));
        public WindowsElement SmartAssistScreenTimeoutDescNoNever => base.FindElementByTimes(session, "XPath", GetAutomationIdFromPredefinedJsonFile("$.SmartAssist.SmartAssistScreenTimeoutDescNoNever"));

        public HSSmartAssistPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public WindowsElement GetAPSToggleWindowsElement(string apsToggle)
        {
            switch (apsToggle.ToLower())
            {
                case "aps":
                    return APSToggle;
                case "manualsuspension":
                    return ManualActiveProtectionSuspensionToggle;
                case "pen":
                    return APSPenInputToggle;
                case "touch":
                    return APSTouchInputToggle;
                case "hand":
                    return APSAdvancedHandToggle;
                default:
                    return null;
            }
        }




    }
}
