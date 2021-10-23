namespace LenovoVantageTest.Pages
{
    using NUnit.Framework;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Interactions;
    using OpenQA.Selenium.Remote;
    using OpenQA.Selenium.Support.UI;

    public class MySecurityPage : BasePage
    {
        private WindowsDriver<WindowsElement> session;
        private WebDriverWait wait;
        private Actions action;

        public string WindowsHello_widget = "Windows Hello";

        public string AS_YourThreatProtectionReport = "Your Threat Protection Report";

        public string expect_MySecurityPageName = "My security";

        public string expect_QATitle = "Q&A";

        public string expect_QAQuestion1_Title = "What is UAC?";
        public string expect_QAQuestion1_Content = "What is UAC? User Account Control is a very important security feature of Windows helps prevent potentially harmful programs from making changes to your system.";

        public string expect_QAQuestion2_Title = "Why do I need to activate Windows?";
        public string expect_QAQuestion2_Content = "Why do I need to activate Windows? Running a non-genuine copy of Windows can put you at greater risk for virus and other security threats.";

        public string expect_QAQuestion3_Title = "What is Hard Drive Encryption?";
        public string expect_QAQuestion3_Content = "What is Hard Drive Encryption? It helps to protect your data by providing encryption for entire hard drive from unauthorized access even though the drive is removed from current PC and put into other devices.";

        public string expect_QAQuestion4_Title = "How do I protect passwords better?";
        public string expect_QAQuestion4_Content = "How do I protect passwords better? Securely store and manage all your passwords encrypted by a professional digital protection app instead of simply storing in your browsers which can be easily accessed by 3rd parties without your knowledge.";

        public string expect_QAQuestion5_Title = "What should I do to enhance security protection?";
        public string expect_QAQuestion5_Content = "What should I do to enhance security protection? We highly recommend you to have your devices protected by anti-virus software and firewall, set up UAC notification at minimum protection. And create strong passwords and manage in a secure way, encrypt your data while using public network as advanced protection.";

        /// <summary>
        /// My Security Title
        /// </summary>
        public WindowsElement mySecurityTitle => base.GetElement(session, "AutomationId", "security-header-title");

        /// <summary>
        /// The Back Link on My security page
        /// </summary>
        /// <param name="session"></param>
        public WindowsElement backLink_MySecurityPage => base.GetElement(session, "AutomationId", "sa-ov-btn-back");

        /// <summary>
        /// Q&A
        /// </summary>
        public WindowsElement qATitle => base.GetElement(session, "Name", "Q&A");


        /// <summary>
        /// Q&A question 1
        /// </summary>
        public WindowsElement qAQuestion1_Title => base.GetElement(session, "AutomationId", "sa-ov-widget-link-question-1");


        /// <summary>
        /// Q&A question 1 Content
        /// </summary>
        //public WindowsElement qAQuestion1_Content => base.GetElement(session, "Name", "User Account Control is a very important security feature of Windows helps prevent potentially harmful programs from making changes to your system.");

        public WindowsElement qAQuestion1_Content => base.GetElement(session, "Name", "What is UAC? User Account Control is a very important security feature of Windows helps prevent potentially harmful programs from making changes to your system.");
        /// <summary>
        /// Q&A question 2
        /// </summary>
        public WindowsElement qAQuestion2_Title => base.GetElement(session, "AutomationId", "sa-ov-widget-link-question-2");

        /// <summary>
        /// Q&A question 2 Content
        /// </summary>
        public WindowsElement qAQuestion2_Content => base.GetElement(session, "Name", "Why do I need to activate Windows? Running a non-genuine copy of Windows can put you at greater risk for virus and other security threats.");

        /// <summary>
        /// Q&A question 3
        /// </summary>
        public WindowsElement qAQuestion3_Title => base.GetElement(session, "AutomationId", "sa-ov-widget-link-question-3");

        /// <summary>
        /// Q&A question 3 Content
        /// </summary>
        public WindowsElement qAQuestion3_Content => base.GetElement(session, "Name", "What is Hard Drive Encryption? It helps to protect your data by providing encryption for entire hard drive from unauthorized access even though the drive is removed from current PC and put into other devices.");


        /// <summary>
        /// Q&A question 4
        /// </summary>
        public WindowsElement qAQuestion4_Title => base.GetElement(session, "AutomationId", "sa-ov-widget-link-question-4");

        /// <summary>
        /// Q&A question 4 Content
        /// </summary>
        public WindowsElement qAQuestion4_Content => base.GetElement(session, "Name", "How do I protect passwords better? Securely store and manage all your passwords encrypted by a professional digital protection app instead of simply storing in your browsers which can be easily accessed by 3rd parties without your knowledge.");

        /// <summary>
        /// Q&A question 5
        /// </summary>
        public WindowsElement qAQuestion5_Title => base.GetElement(session, "AutomationId", "sa-ov-widget-link-question-5");

        /// <summary>
        /// Q&A question 5 Content
        /// </summary>
        public WindowsElement qAQuestion5_Content => base.GetElement(session, "Name", "What should I do to enhance security protection? We highly recommend you to have your devices protected by anti-virus software and firewall, set up UAC notification at minimum protection. And create strong passwords and manage in a secure way, encrypt your data while using public network as advanced protection.");


        public MySecurityPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
        }

        public override void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -100);
        }

        public override void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        private bool IsPresent(string locator)
        {
            try
            {
                session.FindElementByName(locator);
                return true;
            }
            catch (WebDriverException)
            {
                return false;
            }
        }
    }
}
