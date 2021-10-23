using OpenQA.Selenium.Appium.Windows;
using TangramTest.Utility;

namespace LenovoVantageTest.Pages
{
    public class SMBCreatorsettingsPage : SettingsBase
    {
        public WindowsDriver<WindowsElement> session;
        public WindowsElement HDRtitle => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Productivity.Creatorsettings.HDRtitle"));
        public WindowsElement HDRdescription => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Productivity.Creatorsettings.HDRdescription"));
        public WindowsElement HDRlanuchertext => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Productivity.Creatorsettings.HDRlanuchertext"));
        public WindowsElement HDRlanucher => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Productivity.Creatorsettings.HDRlanucher"));
        public WindowsElement ResizeButton => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.Productivity.Creatorsettings.RestoreButton"));

        //public WindowsElement WindowsSettingsDisplay => base.FindElementByTimes(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile("$.OS.Display.DisplayBrightnessSettings").ToString());

        //public WindowsElement WindowsSettingsDisplayHDR => base.FindElementByTimes(session, "Name", "Windows HD Color");

        public UIAutomationControl contrl = new UIAutomationControl();

        public SMBCreatorsettingsPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

    }
}
