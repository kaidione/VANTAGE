namespace LenovoVantageTest.Pages
{
    using LenovoVantageTest.Helper;
    using LenovoVantageTest.Pages.HardwareSettingsPages;
    using LenovoVantageTest.Utility;
    using Microsoft.Win32;
    using Newtonsoft.Json.Linq;
    using NUnit.Framework;
    using OpenQA.Selenium.Appium;
    using OpenQA.Selenium.Appium.Windows;
    using OpenQA.Selenium.Remote;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Management;
    using System.Threading;

    public class BasePage
    {
        protected WindowsDriver<WindowsElement> session;
        //protected static RemoteTouchScreen touchScreen;
        public RemoteTouchScreen touchScreen;
        public BasicReport basicReport;
        public BasePage()
        {
            basicReport = Hooks.basicReport;
        }
        /// <summary>
        /// Get element from the UI
        /// </summary>
        /// <param name="session"></param>
        /// <param name="elementClass"></param>
        /// <param name="locator"></param>
        /// <param name="timeOut">Set time out to 1 min for checking update</param>
        /// <returns></returns>

        public WindowsElement GetElement(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 60)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement element = null;
            try
            {
                switch (elementClass)
                {
                    case "XPath":
                        element = session.FindElementByXPath(locator);
                        break;
                    case "Name":
                        element = session.FindElementByName(locator);
                        break;
                    case "AutomationId":
                        element = session.FindElementByAccessibilityId(locator);
                        break;
                    default:
                        break;
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine("FindElementByTimes() Exception Info:" + locator + ex.ToString());
            }
            return element;
        }

        /// <summary>
        /// <param name="type">small/large/category</param>
        /// </summary>
        public WindowsDriver<WindowsElement> GetControlPanelSession(bool isDesktopSession = false)
        {
            WindowsDriver<WindowsElement> session = null;
            try
            {
                string WindowsApplicationDriverUrl = "http://127.0.0.1:4723";
                AppiumOptions opt = new AppiumOptions();
                opt.AddAdditionalCapability("app", "Root");
                WindowsDriver<WindowsElement> desktopSession = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), opt);
                if (isDesktopSession)
                {
                    return desktopSession;
                }

                string controlAppFile = @"C:\Windows\System32\Control.exe";
                Process.Start(controlAppFile);
                Thread.Sleep(2000);
                var controlWindos = desktopSession.FindElementByClassName("CabinetWClass");
                var controlwindowsHandle = controlWindos.GetAttribute("NativeWindowHandle");
                controlwindowsHandle = (int.Parse(controlwindowsHandle)).ToString("x");
                AppiumOptions appopt = new AppiumOptions();
                appopt.AddAdditionalCapability("appTopLevelWindow", controlwindowsHandle);
                session = new WindowsDriver<WindowsElement>(new Uri(WindowsApplicationDriverUrl), appopt);
                session.Manage().Window.Maximize();
                return desktopSession;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Control Excep:" + ex.Message);
            }
            return null;
        }

        public WindowsElement GetElementNew(WindowsDriver<WindowsElement> session, string elementClass, string elementToken, string locator, int timeOut = 60)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement element = null;

            JObject elementNode = LoadSpecificElementFile.elementData;
            string locatorNew = elementToken + "." + locator;
            string local = elementNode.SelectToken(locatorNew).Value<string>();

            switch (elementClass)
            {
                case "XPath":
                    element = session.FindElementByXPath(local);
                    break;
                case "Name":
                    element = session.FindElementByName(local);
                    break;
                case "AutomationId":
                    element = session.FindElementByAccessibilityId(local);
                    break;
                default:
                    break;
            };

            return element;
        }

        public void AddScreenshotIntoReport(string imageName, string pathName, string component, bool needTakeScreenforPart = false, int srcX = 0, int srcY = 0, int width = 0, int height = 0)
        {
            basicReport.AddScreenshotToReport(imageName, pathName, component, needTakeScreenforPart, srcX, srcY, width, height);
        }

        public WindowsElement FindElementByApp(WindowsDriver<WindowsElement> session, string elementClass, string elementToken, string locator, int timeOut = 30, int checktime = 2, bool notExists = false)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement element = null;

            JObject elementNode = LoadSpecificElementFile.elementData;
            string locatorNew = elementToken + "." + locator;
            string local = elementNode.SelectToken(locatorNew).Value<string>();

            while (checktime > 0)
            {
                try
                {
                    switch (elementClass)
                    {
                        case "XPath":
                            element = session.FindElementByXPath(local);
                            break;
                        case "Name":
                            element = session.FindElementByName(local);
                            break;
                        case "AutomationId":
                            element = session.FindElementByAccessibilityId(local);
                            break;
                        default:
                            break;
                    };
                    if (notExists && element == null)
                    {
                        break;
                    }
                    if (element != null && !notExists)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + ": " + local);
                }
                checktime--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return element;
        }

        public WindowsElement FindElementByTimes(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 30, int checktime = 10)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement element = null;
            while (checktime > 0)
            {
                try
                {
                    switch (elementClass)
                    {
                        case "XPath":
                            element = session.FindElementByXPath(locator);
                            break;
                        case "Name":
                            element = session.FindElementByName(locator);
                            break;
                        case "AutomationId":
                            element = session.FindElementByAccessibilityId(locator);
                            break;
                        default:
                            Console.WriteLine("FindElementByTimes() elementClass parameter error," + elementClass);
                            break;
                    };
                    if (element != null)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("FindElementByTimes() Exception Info:" + locator + ex.ToString());
                }
                checktime--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return element;
        }


        public List<WindowsElement> GetWindowsElementList(WindowsDriver<WindowsElement> session, string xpath, int timeout = 20)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            List<WindowsElement> elelist = null;
            try
            {
                elelist = new List<WindowsElement>(session.FindElementsByXPath(xpath));
            }
            catch (Exception e)
            {
                Console.WriteLine("The Element can be found" + e.Message);
            }
            return elelist;
        }

        public List<WindowsElement> FindElementsByTimes(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 30, int checktime = 10)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            List<WindowsElement> elelist = null;

            while (checktime > 0)
            {
                try
                {
                    switch (elementClass)
                    {
                        case "XPath":
                            elelist = new List<WindowsElement>(session.FindElementsByXPath(locator));
                            break;
                        case "Name":
                            elelist = new List<WindowsElement>(session.FindElementsByName(locator));
                            break;
                        case "AutomationId":
                            elelist = new List<WindowsElement>(session.FindElementsByAccessibilityId(locator));
                            break;
                        default:
                            Console.WriteLine("FindElementsByTimes() elementClass parameter error," + elementClass);
                            break;
                    };
                    if (elelist != null)
                    {
                        break;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("FindElementsByTimes() Exception Info:" + locator + ex.ToString());
                }
                checktime--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return elelist;
        }

        public virtual List<WindowsElement> GetWindowsElementList(string xpath)
        {
            List<WindowsElement> elelist = new List<WindowsElement>(session.FindElementsByXPath(xpath));
            return elelist;
        }

        public virtual void ScrollScreen()
        {
            touchScreen = new RemoteTouchScreen(session);
            touchScreen.Scroll(0, -500);
        }

        public virtual void VerifySAWidgetNotExist()
        {
            Assert.IsFalse(false);
        }


        public virtual void VerifyVPNSecurityNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyFingerPrintNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyUACNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyWindowsActivationNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyTheWiFiSecurityIsNoExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyTheYourThreatProtectionReportIsNoExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyErrorIsNoExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyArmLogoNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifynoInternetConnectionPaneNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyGOTOPASSWORDHEALTHButtonNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyGoToWifiSecurityButtonNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifGoToVPNButtonNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyContentAreEqual(string expected, WindowsElement windowsElement)
        {
            Assert.AreEqual(expected, windowsElement.Text);
        }

        public virtual void VerifyWindowsHelloIsNotExist()
        {
            Assert.IsFalse(false);
        }

        public virtual void VerifyHamburgerMenuNoExist()
        {
            Assert.IsFalse(false);
        }

        public string GetDeviceID(string description)
        {
            try
            {
                ManagementObjectSearcher mos = new ManagementObjectSearcher("select * from Win32_PnPSignedDriver");
                foreach (ManagementObject mo in mos.Get())
                {
                    if (null == mo["Description"])
                    {
                        continue;
                    }
                    if (mo["Description"].ToString().Contains(description))
                    {
                        string str = mo["DeviceID"].ToString();
                        string[] sdd = str.Split(new string[] { "", "\\" }, StringSplitOptions.RemoveEmptyEntries);
                        return sdd[0] + "\\" + sdd[1];
                    }
                }
                return "0";
            }
            catch
            {
                return "nodeviceid";
            }
        }

        public void ActionDriver(string deviceId, string actionType = "enable")
        {
            if (File.Exists(VantageConstContent.DevCon64FilePath))
            {
                string args = string.Format("{0} {1} \"{2}\"", VantageConstContent.DevCon64FilePath, actionType, deviceId);
                CommandBase.RunCmd(args);
            }
        }

        public string UninstallByDisplayName(string displayName)
        {
            string productGuid = string.Empty;

            string bit32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            //'string bit64 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey unistall = localMachine.OpenSubKey(bit32, true);

            var subNames = unistall.GetSubKeyNames();

            foreach (string subkey in subNames)
            {
                RegistryKey product = unistall.OpenSubKey(subkey);
                try
                {
                    if (product.GetValueNames().Any(n => n == "DisplayName") == true)
                    {
                        string tempDisplayName = product.GetValue("DisplayName").ToString();
                        if (tempDisplayName == displayName && product.GetValueNames().Any(n => n == "QuietUninstallString") == true)
                        {
                            var unitstallStr = product.GetValue("QuietUninstallString").ToString();

                            //注意：如果不包含MsiExec，可以返回unitstallStr   
                            if (unitstallStr.Contains("MsiExec.exe"))
                            {
                                string[] strs = unitstallStr.Split(new char[2] { '{', '}' });
                                productGuid = strs[1];
                                break;
                            }
                            else
                            {
                                productGuid = unitstallStr;
                                break;
                            }
                        }
                    }
                }
                catch
                {
                    return string.Empty;
                }
            }

            if (!string.IsNullOrEmpty(productGuid))
            {
                Common.RunCmdWithShell(productGuid);
            }

            return productGuid;
        }

        public bool automationIdNotPresent(string automationId)
        {
            Boolean result = false;
            try
            {
                session.FindElementByAccessibilityId(automationId);
            }
            catch (Exception e)
            {
                Console.WriteLine("The Element can be found");
                result = true;
            }
            return result;
        }

        public string GetAutomationIdFromPredefinedJsonFile(string _jsonPath)
        {
            return VantageAutomationIDCollector.Instance.GetVantageAutomationID(_jsonPath).ToString();
        }

        public WindowsElement getElementByAutoIdJSON(WindowsDriver<WindowsElement> session, String jsonPath)
        {
            return GetElement(session, "AutomationId", GetAutomationIdFromPredefinedJsonFile(jsonPath));
        }

        public bool IsPresent(WindowsDriver<WindowsElement> session, string automationId, int timeout = 3)
        {
            bool result;
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
            try
            {
                session.FindElementByAccessibilityId(automationId);
                Console.WriteLine($"Found the Element with automationId({automationId})");
                result = true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"The Element with automationId({automationId}) can not be found.");
                result = false;
            }
            return result;
        }

        public void CloseVantage(WindowsDriver<WindowsElement> session)
        {
            var xpath = "//*[@AutomationId='Close']";
            try
            {
                var vantageCloseBth = VantageCommonHelper.FindElementByXPath(session, xpath);
                if (vantageCloseBth != null)
                {
                    vantageCloseBth.Click();
                }
                else
                {
                    session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                    session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
                    vantageCloseBth = VantageCommonHelper.FindElementByXPath(session, xpath);
                    vantageCloseBth?.Click();
                    session.CloseApp();
                    session.Quit();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
