using OpenQA.Selenium.Appium.Windows;

namespace LenovoVantageTest.Pages
{
    class MyDeviceSettingObject : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        public MyDeviceSettingObject(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public WindowsElement setBattary => base.GetElement(session, "AutomationId", "myDevice-settings-battery-details-btn");
        public WindowsElement qaSecond => base.GetElement(session, "AutomationId", "widget-support-detail-2-title");
        public WindowsElement contentTitle => base.GetElement(session, "AutomationId", "device-settings-container-card-title");
        public WindowsElement contentOfflineIcon => base.GetElement(session, "AutomationId", "device-settings-container-card-offline-icon");
        public WindowsElement batteryPercentage => base.GetElement(session, "AutomationId", "batteryPercentage");
        public WindowsElement batteryDetailsClose => base.GetElement(session, "AutomationId", "myDevice-settings-battery-details-card-close-icon");
        public WindowsElement primaryBattery => base.GetElement(session, "AutomationId", "primary-battery");

        public WindowsElement contentArticleTitle => base.GetElement(session, "AutomationId", "article-title");
        public WindowsElement contentArticleClose => base.GetElement(session, "AutomationId", "article-close-button");

        public WindowsElement input_accessories_Title => base.GetElement(session, "AutomationId", "myDevice-settings-header-menu-input-accessories-title");

        public WindowsElement airplaneModetoggle => base.GetElement(session, "AutomationId", "ds-power-battery-airplane_checkbox");


    }
}
