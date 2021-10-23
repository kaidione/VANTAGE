using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System.Threading;

namespace LenovoVantageTest.Pages
{
    public class CHSMarketingPage : SettingsBase
    {
        protected static RemoteTouchScreen touchScreen;
        private WindowsDriver<WindowsElement> session;
        public static string AdminJoinCode = "OFUHTM";
        public static string SecondJoinCode = "LHWZCE";
        public static string SubscriptionAdminCode = "FHWUVM";
        public static string SubscriptionSecondCode = "KBUMMA";
        //mengpingsecondary
        public static string SecondJoinCodeB = "XGEAFU";

        public WindowsElement alertWindowCloseButton => base.FindElementByTimes(session, "XPath", "//*[@LocalizedControlType='group']//Button[@Name='Close']", 10, 3);
        public WindowsElement ErrorInput => base.GetElement(session, "Name", "Incorrect code entered!");
        public WindowsElement JoinSuccessfulText => base.GetElement(session, "Name", "You have successfully joined your family's Connected Home Security");
        public WindowsElement VantageCloseBth => base.GetElement(session, "AutomationId", "Close");
        public WindowsElement CHSEnableLocation => base.GetElement(session, "Name", "Enable Location");
        public WindowsElement CHSInputCancel => base.GetElement(session, "AutomationId", "chs-btn-inviatation-cancel", 10);
        public WindowsElement PasswordProtection => base.GetElement(session, "Name", "Password Protection");
        public WindowsElement CHSoobeDone => base.GetElement(session, "AutomationId", "chs-tour-btn-done", 30);
        public WindowsElement CHSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement HSWIFISecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-device-security-2");
        public WindowsElement DropDownCHS => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-home-security-1", 10);
        public WindowsElement CHSStartTrival => base.GetElement(session, "AutomationId", "chs-card-btn-startTrial");
        public WindowsElement CHSJoin => base.GetElement(session, "AutomationId", "chs-card-btn-joinGroup", 5);
        public WindowsElement CHSInput => base.GetElement(session, "AutomationId", "chs-btn-inviatation-input", 10);
        public WindowsElement JoinFamilyInput => base.GetElement(session, "AutomationId", "chs-btn-inviatation-input");
        public WindowsElement JoinFamilyConnect => base.GetElement(session, "AutomationId", "chs-btn-inviatation-connect");
        public WindowsElement CHSTitle => base.GetElement(session, "AutomationId", "connected-home-security-header-title");
        public WindowsElement CHSOobeNext => base.GetElement(session, "AutomationId", "chs-tour-btn-next", 30);
        public WindowsElement CHSOobeAllow => base.GetElement(session, "AutomationId", "chs-tour-btn-openLocation");
        public WindowsElement CHSOobeNotNow => base.GetElement(session, "AutomationId", "chs-tour-btn-cancelLocation");
        public WindowsElement StatTrialDescriptionTitle => base.GetElement(session, "Name", "Create your own Connected Home Security");
        public WindowsElement StatTrialDescriptionText => base.GetElement(session, "Name", "Activate your own Connected Home Security environment, and start protecting your home and family today.");
        public WindowsElement StartTrialAllow => base.GetElement(session, "AutomationId", "chs-tour-btn-openLocation");
        public WindowsElement StartTrialNotAllow => base.GetElement(session, "AutomationId", "chs-tour-btn-cancelLocation");
        public WindowsElement GoNowButton => base.GetElement(session, "AutomationId", "chs-trialModal-btn-countdownGoNow");
        public WindowsElement CHSBlueBarYes => base.GetElement(session, "AutomationId", "Button1", 10);
        public WindowsElement CHSBlueBarNo => base.GetElement(session, "AutomationId", "Button0", 10);
        public WindowsElement CancelButton => base.GetElement(session, "AutomationId", "chs-trialModal-btn-countdownCancel");
        public WindowsElement GoToDashboardButton => base.GetElement(session, "AutomationId", "chs-btn-goToDashboard");
        public WindowsElement OfflineDialogCloseBtn => base.GetElement(session, "AutomationId", "chs-btn-offlineDialogcancle");

        public CHSMarketingPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public void JoinCHSGroup(string status)
        {
            CHSWebEnvPage.SetLocationServiceAndPermisson("On", "On");
            alertWindowCloseButton?.Click();
            if (CHSJoin != null)
            {
                CHSJoin?.Click();
                Thread.Sleep(3000);
                switch (status.ToLower())
                {
                    case "trialadmin":
                        CHSInput.SendKeys(AdminJoinCode);
                        break;
                    case "trialsecond":
                        CHSInput.SendKeys(SecondJoinCode);
                        break;
                    case "subscriptionadmin":
                        CHSInput.SendKeys(SubscriptionAdminCode);
                        break;
                    case "subscriptionsecond":
                        CHSInput.SendKeys(SubscriptionSecondCode);
                        break;
                    case "secondjoincodeb":
                        CHSInput.SendKeys(SecondJoinCodeB);
                        break;

                }
                JoinFamilyConnect?.Click();
                Thread.Sleep(3000);
            }
        }

        public void OObeCHS()
        {
            if (CHSOobeNext != null)
            {
                CHSOobeNext.Click();
                CHSOobeNotNow.Click();
            }
            else { CHSoobeDone?.Click(); }
        }

    }
}

