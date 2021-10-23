using LenovoVantageTest.Pages.ConnectedHomeSecurityPages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace LenovoVantageTest.Helper
{
    public class CHSHelper
    {
        private static string _vantagePath = string.Empty;
        public static string installFolder = @"C:\Fitnesse\vantageinstallpath\AppPackages";
        public static string LWSVantageoldPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data\\Vantage\\bj_store");

        public static IWebDriver _webSession = null;
        private static string _defaultGooglePath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Google\Chrome\Application";
        public static IWebDriver OpenPageFromChrome(string homeSecurityUrl, string webdriverPath, int index = 3)
        {
            IWebDriver webDriver = new ChromeDriver(webdriverPath);
            IWebElement element = null;
            webDriver.Manage().Window.Maximize();
            while (index > 0 && element == null)
            {
                try
                {
                    webDriver.Navigate().GoToUrl(homeSecurityUrl);
                    webDriver.FindElement(By.XPath(CHSWebXpath.WebLoginInLIDBtn));
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    element = FindElementByXpathFromWeb(webDriver, CHSWebXpath.WebLoginInLIDBtn, 60);
                    index--;
                }
            }
            return webDriver;
        }

        public static void ChangeOutTrialPeriod(IWebDriver websession)
        {
            var outtrialday = "0";
            _webSession = OpenChangeDayPage(websession);
            var TrialDay = FindElementByXpathFromWeb(_webSession, "//*[@id=\"numberOfDaysUntilEndOfTrial\"]", 240);
            if (TrialDay != null)
            {
                TrialDay.SendKeys(outtrialday);
            }
            var TrialChangeBtn = FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/button", 240);
            if (TrialChangeBtn != null)
            {
                TrialChangeBtn.Click();
                Thread.Sleep(2000);
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

        public static IWebElement FindElementByXpathFromWeb(IWebDriver webSession, string xPath, int timeout = 30, bool assertnull = false, int times = 30)
        {
            IWebElement targetElement = null;
            while (targetElement == null)
            {
                try
                {
                    targetElement = webSession.FindElement(By.XPath(xPath));
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(ex.Message);
                }
                if (timeout < 0)
                {
                    break;
                }
                timeout--;
            }
            if (assertnull == true)
            {
                while (targetElement != null)
                {
                    try
                    {
                        targetElement = webSession.FindElement(By.XPath(xPath));
                        Thread.Sleep(1000);
                        if (times < 0)
                        {
                            break;
                        }
                        times--;
                    }
                    catch (Exception ex)
                    {
                        targetElement = null;
                    }
                }
            }
            return targetElement;
        }

        public static ReadOnlyCollection<IWebElement> FindElementsByXpathFromWeb(IWebDriver webSession, string xPath, int timeout = 30)
        {
            ReadOnlyCollection<IWebElement> targetElements = null;
            while (targetElements == null)
            {
                try
                {
                    targetElements = webSession.FindElements(By.XPath(xPath));
                }
                catch (Exception ex)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine(ex.Message);
                }
                if (timeout < 0)
                {
                    break;
                }
                timeout--;

            }
            return targetElements;
        }

        public static void Login(string userName, string passwd)
        {
            string homeSecurityUrl = "https://chs.lenovo.com";
            _webSession = CHSHelper.OpenPageFromChrome(homeSecurityUrl, _defaultGooglePath);
            var loginHomeSecurity = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebLoginInLIDBtn);
            if (loginHomeSecurity != null)
            {
                loginHomeSecurity.Click();
            }
            var inputId = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputID, 60);
            if (inputId != null)
            {
                inputId.SendKeys(userName);
            }
            var next1Btn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNext1Btn, 60);
            if (next1Btn != null)
            {
                next1Btn.Click();
            }
            Thread.Sleep(1000);
            var inputPssword = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputPssword, 60);
            if (inputPssword != null)
            {
                inputPssword.SendKeys(passwd);
            }
            var next2Btn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNext2Btn, 60);
            if (next2Btn != null)
            {
                next2Btn.Click();
            }
            Thread.Sleep(3000);
        }

        public static void ChangeInTrialPeriod(IWebDriver websession)
        {
            var intrialday = "29";
            _webSession = OpenChangeDayPage(websession);
            var TrialDay = FindElementByXpathFromWeb(_webSession, "//*[@id=\"numberOfDaysUntilEndOfTrial\"]", 240);
            if (TrialDay != null)
            {
                TrialDay.SendKeys(intrialday);
            }
            var TrialChangeBtn = FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div[2]/div[2]/div[1]/div[2]/div/button", 240);
            if (TrialChangeBtn != null)
            {
                TrialChangeBtn.Click();
                Thread.Sleep(2000);
            }
        }

        public static void ChangeSubscriptionOver30Days(IWebDriver websession)
        {
            var Over30Days = "365";
            _webSession = OpenChangeDayPage(websession);
            var SubscriptionDays = FindElementByXpathFromWeb(_webSession, "//*[@id=\"numberOfDaysUntilEndOfSubscription\"]", 120);
            if (SubscriptionDays != null)
            {
                SubscriptionDays.SendKeys(Over30Days);
            }
            var SupscriptionChangeBtn = FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div[2]/div[2]/div[2]/div[2]/div/button", 120);
            if (SupscriptionChangeBtn != null)
            {
                SupscriptionChangeBtn.Click();
                Thread.Sleep(2000);
            }
        }

        public static void ChangeSubscriptionLess30Days(IWebDriver websession)
        {
            var Over30Days = "28";
            _webSession = OpenChangeDayPage(websession);
            var SubscriptionDays = FindElementByXpathFromWeb(_webSession, "//*[@id=\"numberOfDaysUntilEndOfSubscription\"]", 120);
            if (SubscriptionDays != null)
            {
                SubscriptionDays.SendKeys(Over30Days);
            }
            var SupscriptionChangeBtn = FindElementByXpathFromWeb(_webSession, "//*[@id=\"root\"]/div/div[2]/div[2]/div[2]/div[2]/div/button", 120);
            if (SupscriptionChangeBtn != null)
            {
                SupscriptionChangeBtn.Click();
                Thread.Sleep(2000);
            }
        }

    }
}
