namespace LenovoVantageTest.Pages
{
    using LenovoVantageTest.Helper;
    using LenovoVantageTest.Utility;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Chrome;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Management.Automation;
    using System.Management.Automation.Runspaces;
    using System.Runtime.InteropServices;
    using System.Threading;
    using System.Windows.Automation;
    using System.Windows.Forms;
    using TangramTest.Utility;

    public class HSConnectedHomeSecurityPage : SettingsBase
    {
        private WindowsDriver<WindowsElement> session;
        private static IWebDriver _webSession = null;
        private static string _defaultGooglePath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Google\Chrome\Application";
        private readonly UIAutomationControl _control = new UIAutomationControl();
        private readonly Dictionary<string, string> _nlsTableInSettings = new Dictionary<string, string>();
        public WindowsElement GamingWSLink => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-0");
        public WindowsElement HSCHS => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-home-security");
        public WindowsElement HSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement HSWIFISecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-device-security-2");
        public WindowsElement CHSBadge => base.GetElement(session, "Name", "Not Protected");
        public WindowsElement CHSProtected => base.GetElement(session, "Name", "Protected");
        public WindowsElement VisitButton => base.GetElement(session, "AutomationId", "sa-ws-btn-goToChs");
        public WindowsElement CHSStartTrival => base.GetElement(session, "AutomationId", "chs-card-btn-startTrial");
        public WindowsElement CHSJoin => base.GetElement(session, "AutomationId", "chs-card-btn-joinGroup");
        public WindowsElement CHSInput => base.GetElement(session, "AutomationId", "chs-btn-inviatation-input");
        public WindowsElement JoinFamilyInput => base.GetElement(session, "AutomationId", "chs-btn-inviatation-input");
        public WindowsElement JoinFamilyConnect => base.GetElement(session, "AutomationId", "chs-btn-inviatation-connect");
        public WindowsElement CHSTitle => base.GetElement(session, "AutomationId", "connected-home-security-header-title");
        public WindowsElement CHSTab => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-home-security");
        public WindowsElement CHSOobeNext => base.GetElement(session, "AutomationId", "chs-tour-btn-next");
        public WindowsElement Vantageoobe_next => base.GetElement(session, "AutomationId", "tutorial_next_btn");
        public WindowsElement Vantageoobe_done => base.GetElement(session, "AutomationId", "tutorial_done_btn");


        public UIAutomationControl contrl = new UIAutomationControl();


        private string realtekPath = @"C:\Program Files\Realtek\Audio\HDA\RAVCpl64.exe";

        public HSConnectedHomeSecurityPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public bool SupportMachine()
        {
            return true;
        }

        [DllImport("winmm.dll")]
        private static extern long mciSendString(
            string command,
            string returnString,
            int returnSize,
            IntPtr hwndCallback
            );

        public void GoToWIFISecurity()
        {
            HSSecurity?.Click();
            if (!NerveCenterHelper.GetMachineIsGaming())
            {
                HSWIFISecurity?.Click();
            }
        }

        public void JoinDevice(string invitationCode)
        {
            var joinBtn = CHSJoin;
            if (joinBtn != null)
            {
                joinBtn.Click();
            }
            var joinInput = CHSInput;
            if (joinInput != null)
            {
                joinInput.Click();
                SendKeys.SendWait(invitationCode);
            }
            var joinConnect = JoinFamilyConnect;
            if (joinConnect != null)
            {
                joinConnect.Click();
            }

        }

        public static void ChangeOutTrialPeriod()
        {
            var outtrialday = "0";
            _webSession = OpenChangeDayPage(_webSession);
            Thread.Sleep(120000);
            var TrialDay = FindElementByXpathFromWeb(_webSession, "//*[@id=\"numberOfDaysUntilEndOfTrial\"]", 240);
            if (TrialDay != null)
            {
                TrialDay.SendKeys(outtrialday);
            }
            var TrialChangeBtn = FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/button", 240);
            if (TrialChangeBtn != null)
            {
                TrialChangeBtn.Click();
            }
        }

        public void Login(string userName, string passwd)
        {
            string homeSecurityUrl = "https://chs.lenovo.com";
            _webSession = HSConnectedHomeSecurityPage.OpenPageFromChrome(homeSecurityUrl, _defaultGooglePath);
            var loginHomeSecurity = HSConnectedHomeSecurityPage.FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div/div[2]/div/div[4]/div[2]/div/div/button");
            if (loginHomeSecurity != null)
            {
                loginHomeSecurity.Click();
            }
            var inputId = HSConnectedHomeSecurityPage.FindElementByXpathFromWeb(_webSession, "/html/body/div[1]/div[1]/div[1]/input", 60);
            if (inputId != null)
            {
                inputId.SendKeys(userName);
            }
            var next1Btn = HSConnectedHomeSecurityPage.FindElementByXpathFromWeb(_webSession, "/html/body/div[1]/div[1]/button", 60);
            if (next1Btn != null)
            {
                next1Btn.Click();
            }
            var inputPssword = HSConnectedHomeSecurityPage.FindElementByXpathFromWeb(_webSession, "/html/body/div[1]/div[2]/form/div[1]/input", 60);
            if (inputPssword != null)
            {
                inputPssword.SendKeys(passwd);
            }
            var next2Btn = HSConnectedHomeSecurityPage.FindElementByXpathFromWeb(_webSession, "/html/body/div[1]/div[2]/form/div[4]/button[2]", 60);
            if (next2Btn != null)
            {
                next2Btn.Click();
            }
        }

        public static IWebDriver OpenChangeDayPage(IWebDriver webDriver)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)webDriver;
            js.ExecuteScript("window.open()");
            webDriver.SwitchTo().Window(webDriver.WindowHandles[webDriver.WindowHandles.Count - 1]);
            webDriver.Navigate().GoToUrl("https://chs.lenovo.com/lab");
            return webDriver;
        }

        public static IWebDriver OpenPageFromChrome(string homeSecurityUrl, string webdriverPath)
        {
            IWebDriver webDriver = new ChromeDriver(webdriverPath);
            webDriver.Navigate().GoToUrl(homeSecurityUrl);
            return webDriver;
        }

        public static IWebElement FindElementByXpathFromWeb(IWebDriver webSession, string xPath, int timeout = 30)
        {
            IWebElement targetElement = null;
            try
            {
                while (targetElement == null)
                {
                    targetElement = webSession.FindElement(By.XPath(xPath));
                    Thread.Sleep(1000);
                    if (timeout < 0)
                    {
                        break;
                    }
                    timeout--;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return targetElement;
        }
        public static void SetSystemRegion(string geoId)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            string scriptText = "Set-WinHomeLocation -GeoId" + geoId;
            runspace.Open();
            Pipeline pipeline = runspace.CreatePipeline();
            pipeline.Commands.AddScript(scriptText);
            pipeline.Commands.AddScript("Out-String");
            Collection<PSObject> result = pipeline.Invoke();
            runspace.Close();
        }
        public static void SetSystemLanguage(string language)
        {
            var cmds = new List<string>
            {
                $"Set-WinUILanguageOverride -Language \"{language}\""
             };
            RunPowershellCmslet(cmds);
        }

        private static void RunPowershellCmslet(List<string> cmdlets)
        {
            Runspace runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
            Pipeline pipe = runspace.CreatePipeline();
            foreach (string cmd in cmdlets)
            {
                pipe.Commands.AddScript(cmd);
            }
            pipe.Invoke();
            runspace.Close();
        }

        public void SetSystemLanguageByUIA(string language)
        {
            var appName = "Settings";
            var autoIdOfmMoveUpBtn = "SystemSettings_Language_MoveUp_ButtonMoveUp";
            Common.StartProtocol("ms-settings:regionlanguage", "SystemSettings");

            AutomationElement moveUp;
            while (true)
            {
                ClickLanguageItem(language);
                Thread.Sleep(100);

                moveUp = _control.FindElement(appName, autoIdOfmMoveUpBtn, "", 3);
                if (moveUp == null) { return; }
                if (moveUp.Current.IsEnabled)
                {
                    ClickMoveUpButton(language);
                    Thread.Sleep(200);
                }
                else { return; }
            }
        }

        private void ClickMoveUpButton(string language)
        {
            var appName = "Settings";
            var autoIdOfmMoveUpBtn = "SystemSettings_Language_MoveUp_ButtonMoveUp";
            var moveUp = _control.FindElement(appName, autoIdOfmMoveUpBtn, "", 5);
            if (moveUp != null)
            {
                var targetButton = moveUp.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                targetButton.Invoke();
            }
        }

        private void ClickLanguageItem(string language)
        {
            var appName = "Settings";
            SelectionItemPattern languageItem = null;
            if (language.Equals("en-US"))
            {
                languageItem = FindLanguageListViewItem(appName, "", "English (United States)");
            }
            else if (language.Equals("zh-CN"))
            {
                languageItem = FindLanguageListViewItem(appName, "", "Chinese (Simplified, China)");
            }
            else
            {
                languageItem = FindLanguageListViewItem(appName, "", _nlsTableInSettings[language]);

            }
            if (language != null)
            {
                languageItem.Select();
            }
        }

        private SelectionItemPattern FindLanguageListViewItem(string appName, string automationId = null, string language = null, int timeout = 30)
        {
            SelectionItemPattern listViewItem = null;
            var settingsWindow = AutomationElement.RootElement.FindFirst(System.Windows.Automation.TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Settings"));
            var targetItem = _control.FindElementInRootElementPlus(settingsWindow, "", language, timeout);
            if (targetItem != null)
            {
                var now = DateTime.Now;
                while (!targetItem.Current.IsEnabled && DateTime.Now < now.AddSeconds(timeout))
                { Thread.Sleep(1000); }
                listViewItem = targetItem.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            }
            return listViewItem;
        }
    }
}
