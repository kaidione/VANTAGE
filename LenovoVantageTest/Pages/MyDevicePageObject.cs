using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace LenovoVantageTest.Pages
{
    class MyDevicePage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private RemoteTouchScreen touchScreen;


        public MyDevicePage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }
        public WindowsElement serial => base.GetElement(session, "AutomationId", "myDevice-serial");
        public WindowsElement serialValue => base.GetElement(session, "AutomationId", "myDevice-serial-value");
        public WindowsElement productNumber => base.GetElement(session, "AutomationId", "myDevice-product-number");
        public WindowsElement productNumberValue => base.GetElement(session, "AutomationId", "myDevice-product-number-value");
        public WindowsElement biosVersion => base.GetElement(session, "AutomationId", "myDevice-bios-version");
        public WindowsElement biosVersionValue => base.GetElement(session, "AutomationId", "myDevice-bios-version-value");
        public WindowsElement processorMore => base.GetElement(session, "AutomationId", "myDevice-status-learn-more-processor");
        public WindowsElement processerDetails => base.GetElement(session, "AutomationId", "myDevice-system-details-processor");
        public WindowsElement memoryMore => base.GetElement(session, "AutomationId", "myDevice-status-learn-more-memory");
        public WindowsElement memoryDetails => base.GetElement(session, "AutomationId", "myDevice-system-details-memory");
        public WindowsElement diskMore => base.GetElement(session, "AutomationId", "myDevice-status-learn-more-disk");
        public WindowsElement diskDetails => base.GetElement(session, "AutomationId", "myDevice-system-details-disk");
        public WindowsElement suMore => base.GetElement(session, "AutomationId", "myDevice-status-learn-more-systemupdate");
        public WindowsElement suDetails => base.GetElement(session, "AutomationId", "myDevice-system-details-systemupdate");
        public WindowsElement warrantlyMore => base.GetElement(session, "AutomationId", "myDevice-status-learn-more-warranty");
        public WindowsElement warrantlyDetails => base.GetElement(session, "AutomationId", "myDevice-system-details-warranty");
        public WindowsElement qaFirst => base.GetElement(session, "AutomationId", "widget-support-detail-1-title");//（1，2，3，4，5，6）
        public WindowsElement qaSecond => base.GetElement(session, "AutomationId", "widget-support-detail-1-title");//（1，2，3，4，5，6）
        public WindowsElement qaThird => base.GetElement(session, "AutomationId", "widget-support-detail-1-title");//（1，2，3，4，5，6
        public WindowsElement qaForth => base.GetElement(session, "AutomationId", "widget-support-detail-1-title");//（1，2，3，4，5，6）
        public WindowsElement qa1fifth => base.GetElement(session, "AutomationId", "widget-support-detail-1-title");//（1，2，3，4，5，6）
        public WindowsElement contextBoxOfflineIcon => base.GetElement(session, "AutomationId", "myDevice-container-card-offline-icon");
        public string offlineIconAutomationId = "myDevice-container-card-offline-icon";

        public WindowsElement containerCardOnline => base.GetElement(session, "AutomationId", "myDevice-container-card-article_link");

    }
}