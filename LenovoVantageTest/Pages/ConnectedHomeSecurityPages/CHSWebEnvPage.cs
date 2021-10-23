using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages.ConnectedHomeSecurityPages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Automation;
using System.Xml;
using TangramTest.Utility;
using ToggleState = System.Windows.Automation.ToggleState;

namespace LenovoVantageTest.Pages
{
    public class CHSWebEnvPage : SettingsBase
    {
        private static IWebDriver _webSession = null;
        private static Actions _action = null;
        protected static RemoteTouchScreen touchScreen;
        private WindowsDriver<WindowsElement> session;
        public static string CHSAccountPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Pages\ConnectedHomeSecurityPages\CHSAccount.xml");
        public static string DefaultGooglePath = @"C:\Users\" + Environment.UserName + @"\AppData\Local\Google\Chrome\Application";
        public Language SetFirstLanguage = new Language();
        public WindowsElement DropDownCHS => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-home-security-1");
        public WindowsElement CHSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement HSWIFISecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-device-security-2");
        public WindowsElement VisitButton => base.GetElement(session, "AutomationId", "sa-ws-btn-goToChs", 10);
        public WindowsElement CHSTitle => base.GetElement(session, "AutomationId", "connected-home-security-header-title");
        public WindowsElement VantageUserBtn => base.GetElement(session, "AutomationId", "navbarDropdown");
        public WindowsElement VantageLogCloseBtn => base.GetElement(session, "AutomationId", "btnClose", 1);
        public WindowsElement LogVantage => base.GetElement(session, "AutomationId", "menu-main-lnk-open-lenovoid-login", 5);
        public WindowsElement LogVantageInputID => base.GetElement(session, "AutomationId", "emailOrPhoneInput");
        public WindowsElement LogVantageInputPsw => base.GetElement(session, "AutomationId", "emailOrPhonePswInput");
        public WindowsElement LogOutVantageBtn => base.GetElement(session, "AutomationId", "menu-main-lnk-user-logout");
        public WindowsElement LogVantageNext => base.GetElement(session, "AutomationId", "emailOrPhoneBtn");
        public WindowsElement LogVantageNext2 => base.GetElement(session, "AutomationId", "loginPwsNextBtn");
        public List<WindowsElement> CHSTextList => base.FindElementsByTimes(session, "XPath", "//*[@AutomationId='connected-home-security-header-title']//..//Text");
        public ReadOnlyCollection<IWebElement> HomeDeviceList => CHSHelper.FindElementsByXpathFromWeb(_webSession, "//*//ul//div[contains(@class,'MuiButtonBase-root MuiListItem-root')]");

        public CHSWebEnvPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        public static void SetLocationServiceAndPermisson(string state, string perstate, string commond = "ms-settings:privacy-location", string globalPar = "Location")
        {
            Thread.Sleep(1500);
            Process.Start("ms-settings:privacy-webcam");
            Thread.Sleep(1000);
            Process.Start(commond);
            Thread.Sleep(1500);
            AutomationElement checkBox = SetLocationServiceInSettings(state, globalPar);
            Thread.Sleep(2000);
            UIAutomationControl control = new UIAutomationControl();
            AutomationElement toggle = null;
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                toggle = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, "ToggleSwitch"), new PropertyCondition(AutomationElement.AutomationIdProperty, VantageConstContent.VantageLELocationPermission)));
            }
            else
            {
                toggle = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, "ToggleSwitch"), new PropertyCondition(AutomationElement.AutomationIdProperty, VantageConstContent.VantageLocationPermission)));
            }
            if (perstate == "On")
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.On);
            }
            else
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.Off);
            }
            KillProcess("SystemSettings");
        }

        public static void RemoveDevice(string status, bool issecond = false)
        {
            var account = GetAccount(status);
            _webSession = LoginLenovoWeb((account[0]), account[1]);
            var deviceSetting = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebDevicesSetting, 10);
            var seconddevice = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSecondnDevices, 10);
            if (issecond == true && seconddevice != null)
            {
                _action = new Actions(_webSession);
                _action.MoveToElement(seconddevice).Perform();
                Thread.Sleep(1000);
                seconddevice.Click();
            }
            else if (deviceSetting != null)
            {
                _action = new Actions(_webSession);
                _action.MoveToElement(deviceSetting).Perform();
                Thread.Sleep(1000);
                deviceSetting.Click();
            }
            var removeBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebRemoveBtn, 10);
            if (removeBtn != null)
            {
                removeBtn.Click();
            }
            Thread.Sleep(1000);
            var confirmRemove = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebConfirmRemoveBtn, 10);
            if (confirmRemove != null)
            {
                confirmRemove.Click();
            }
            confirmRemove = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebConfirmRemoveBtn, 10, true, 60);
            _webSession.Close();

        }

        public static IWebDriver LoginLenovoWeb(string userName, string passwd)
        {
            string homeSecurityUrl = "https://chs.lenovo.com";
            _webSession = CHSHelper.OpenPageFromChrome(homeSecurityUrl, DefaultGooglePath);
            var loginHomeSecurity = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebLoginInLIDBtn);
            loginHomeSecurity.Click();
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
            Thread.Sleep(3000);
            var inputPssword = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputPssword, 60);
            if (inputPssword != null)
            {
                inputPssword.SendKeys(passwd);
            }
            var next2Btn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNext2Btn, 60);
            try
            {
                next2Btn.Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            _webSession.Manage().Window.Minimize();
            _webSession.Manage().Window.Maximize();
            return _webSession;
        }

        public static void RemoveFamilyFromCHSWeb(bool isTrial = true)
        {
            if (isTrial)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var familysetting = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebFamilySetting, 60);
            if (familysetting != null)
            {
                _action = new Actions(_webSession);
                _action.MoveToElement(familysetting).Perform();
                Thread.Sleep(3000);
                familysetting.Click();
            }
            var settingBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebFamilySettingBtn);
            if (settingBtn != null)
            {
                Thread.Sleep(3000);
                settingBtn.Click();
            }
            Thread.Sleep(1000);
            var removefamily = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebRemoveFamilyBtn);
            if (removefamily != null)
            {
                removefamily.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }

        public static void RemovePlacesNumber(bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var placeSetting = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebPlaceHomePic, 60);
            var placeMore = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebPlaceMoreBtn, 60);
            if (placeSetting != null)
            {
                _action = new Actions(_webSession);
                _action.MoveToElement(placeSetting).Perform();
                Thread.Sleep(1000);
                placeMore.Click();
            }
            var settingBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebFamilySettingBtn);
            if (settingBtn != null)
            {
                Thread.Sleep(3000);
                settingBtn.Click();
            }
            Thread.Sleep(1000);
            var RemovePlaceYesBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.RemovePlaceYesBtn);
            if (RemovePlaceYesBtn != null)
            {
                RemovePlaceYesBtn.Click();
            }
            RemovePlaceYesBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.RemovePlaceYesBtn, 10, true, 60);
            _webSession.Close();
        }

        public static void RemoveWifiNetworkNumber(bool isTrial = true, bool isTrial2 = false)
        {
            if (isTrial)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrial2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var networkName = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.NetworkName, 60);
            var networkMoreBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.NetworkMoreBtn, 60);
            if (networkName != null)
            {
                _action = new Actions(_webSession);
                _action.MoveToElement(networkName).Perform();
                Thread.Sleep(1000);
                networkMoreBtn.Click();
            }
            var networkRemoveBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.NetworkRemoveBtn, 60);
            if (networkRemoveBtn != null)
            {
                Thread.Sleep(2000);
                networkRemoveBtn.Click();
            }
            Thread.Sleep(1000);
            var removeNetworkYesBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.RemoveNetworkYesBtn);
            if (removeNetworkYesBtn != null)
            {
                removeNetworkYesBtn.Click();
            }
            Thread.Sleep(4000);
            _webSession.Close();
        }
        public static void SetLocationSerAndPerInSetting(string state, string perstate)
        {
            SetLocationServiceInSettings(state);
            UIAutomationControl control = new UIAutomationControl();
            var toggle = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, "ToggleSwitch"), new PropertyCondition(AutomationElement.AutomationIdProperty, VantageConstContent.VantageLocationPermission)));
            if (perstate == "On")
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.On);
            }
            else
            {
                control.SetOrCheckToggleStatusByAutomationElement(toggle, true, ToggleState.Off);
            }
            KillProcess("SystemSettings");
        }

        public static void AddFamilyNumber(bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var newnumber = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNewNumberBtn);
            if (newnumber != null)
            {
                newnumber.Click();
            }
            var inputname = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputName);
            if (inputname != null)
            {
                inputname.SendKeys("asdfasdf");
            }
            var savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
            if (savebtn != null)
            {
                savebtn.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }

        public static void AddPlacesNumber(bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial == true)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var newplace = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNewPlaceBtn);
            if (newplace != null)
            {
                newplace.Click();
            }
            var inputname = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputName);
            if (inputname != null)
            {
                inputname.SendKeys("asdfasdf");
            }
            var savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
            if (savebtn != null)
            {
                savebtn.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }

        public static void AddWifiNetworkNumber(bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial == true)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var addWifiNetwork = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddWifiNetwork);
            if (addWifiNetwork != null)
            {
                addWifiNetwork.Click();
            }
            Thread.Sleep(10000);
            var chooseNetwork = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.ChooseNetwork);
            if (chooseNetwork != null)
            {
                chooseNetwork.Click();
            }
            Thread.Sleep(5000);
            var addBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddBtn);
            if (addBtn != null)
            {
                addBtn.Click();
            }
            Thread.Sleep(3000);
            var maybeLaterBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.MaybeLaterBtn);
            if (maybeLaterBtn != null)
            {
                maybeLaterBtn.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }

        public void AddHomeDeviceNumber(int homeDevice, bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial == true)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            var homeDeviceBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.HomeDeviceBtn);
            if (homeDeviceBtn != null)
            {
                homeDeviceBtn.Click();
            }
            Thread.Sleep(10000);
            foreach (IWebElement EachHomeDevice in HomeDeviceList.Take(homeDevice))
            {
                if (EachHomeDevice != null)
                {
                    EachHomeDevice.Click();
                    Thread.Sleep(1000);
                }
            }
            var addHomeDeviceBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddHomeDeviceBtn);
            if (addHomeDeviceBtn != null)
            {
                addHomeDeviceBtn.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }

        public void ScrollScreen(int x)
        {
            try
            {
                touchScreen = new RemoteTouchScreen(session);
                touchScreen.Scroll(0, x);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public static string[] GetAccount(string account)
        {
            string[] arr = new string[2];
            List<string> Account = new List<string>(arr);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(CHSAccountPath);
            XmlNodeList nodeList = xmlDoc.SelectNodes("/Settings/SettingsList");
            foreach (var node in nodeList)
            {
                var nodeChild = node as XmlNode;
                var settingList = nodeChild.FirstChild;
                var setting = settingList?.InnerText;
                if (nodeChild.Attributes[0].Value.Equals(account, StringComparison.CurrentCultureIgnoreCase))
                {
                    Account[0] = nodeChild.ChildNodes[0].FirstChild.InnerText;
                    Account[1] = nodeChild.ChildNodes[1].FirstChild.InnerText;
                    arr = Account.ToArray();
                    return arr;
                }
            }
            return arr;
        }

        public static string GetXmlSingleNode(string xmlnode, string path)
        {
            string xmlContent = File.ReadAllText(path);
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlContent);
            XmlNode node = xmlDoc.SelectSingleNode(xmlnode);
            string value = node?.InnerText;
            return value;
        }

        public void LogInVantage(string account, string status)
        {
            var Account = GetAccount(account);
            if (status != "On")
            {
                VantageUserBtn.Click();

                if (LogVantage != null)
                {
                    LogVantage.Click();
                    Assert.IsNotNull(LogVantageInputID, "The LogVantageInputID Btn not found");
                    LogVantageInputID.SendKeys(Account[0]);
                    LogVantageNext.Click();
                    LogVantageInputPsw.SendKeys(Account[1]);
                    LogVantageNext2.Click();
                    Thread.Sleep(10000);
                }
            }
            else
            {
                Assert.IsNotNull(LogVantageInputID, "The LogVantageInputID Btn not found");
                LogVantageInputID.SendKeys(Account[0]);
                LogVantageNext.Click();
                LogVantageInputPsw.SendKeys(Account[1]);
                LogVantageNext2.Click();
                Thread.Sleep(10000);
            }
            while (VantageLogCloseBtn != null)
            {
                VantageLogCloseBtn?.Click();
                VantageUserBtn.Click();
                Thread.Sleep(3000);
                LogVantage?.Click();
                Thread.Sleep(10000);
            }
        }

        public List<string> GetOverviewList()
        {
            List<string> components = new List<string>();
            components.Clear();
            try
            {
                for (int i = 0; i < CHSTextList.Count; i++)
                {
                    if (CHSTextList[i].GetAttribute("Name") == "Overview")
                    {
                        //family member nummber
                        components.Add(CHSTextList[i + 1].GetAttribute("Name"));
                        //places nummber
                        components.Add(CHSTextList[i + 3].GetAttribute("Name"));
                        //persomal device nummber
                        components.Add(CHSTextList[i + 5].GetAttribute("Name"));
                        //wifi networks nummber
                        components.Add(CHSTextList[i + 7].GetAttribute("Name"));
                        //home devices nummber
                        components.Add(CHSTextList[i + 9].GetAttribute("Name"));
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("GetOverviewList() " + ex.Message);
            }
            return components;
        }

        public static void RemoveFamilyNumber(string Index, string Account)
        {
            var account = GetAccount(Account);
            _webSession = LoginLenovoWeb((account[0]), account[1]);
            switch (Index.ToLower())
            {
                case "third":
                    var secondfamilysetting = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.RemoveFamilySecond, 60);
                    if (secondfamilysetting != null)
                    {
                        _action = new Actions(_webSession);
                        _action.MoveToElement(secondfamilysetting).Perform();
                        Thread.Sleep(1000);
                        secondfamilysetting.Click();
                    }
                    break;
            }
            var settingBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebFamilySettingBtn);
            if (settingBtn != null)
            {
                settingBtn.Click();
            }
            Thread.Sleep(1000);
            var removefamily = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebRemoveFamilyBtn);
            if (removefamily != null)
            {
                removefamily.Click();
            }
            Thread.Sleep(3000);
            _webSession.Close();
        }
        public void AddComponentInCHSWebPage(bool family, bool places, bool wifinetwork, bool homedevice, int homeDevice = 0, bool isTrial = true, bool isTrila2 = false)
        {
            if (isTrial == true)
            {
                var account = GetAccount("Trial1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else if (isTrila2 == true)
            {
                var account = GetAccount("Trial2");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            else
            {
                var account = GetAccount("Subscription1");
                _webSession = LoginLenovoWeb((account[0]), account[1]);
            }
            //add family
            if (family == true)
            {
                var newnumber = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNewNumberBtn);
                if (newnumber != null)
                {
                    newnumber.Click();
                }
                var inputname = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputName);
                if (inputname != null)
                {
                    inputname.SendKeys("asdfasdf");
                }
                var savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
                if (savebtn != null)
                {
                    savebtn.Click();
                    for (int i = 0; i < 60; i++)
                    {
                        savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
                        Thread.Sleep(1000);
                        if (savebtn == null)
                        {
                            Console.WriteLine("There's no add family part");
                            break;
                        }

                    }
                }
                Thread.Sleep(3000);
            }
            //add places
            if (places == true)
            {
                var newplace = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebNewPlaceBtn);
                if (newplace != null)
                {
                    newplace.Click();
                }
                var inputname = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebInputName);
                if (inputname != null)
                {
                    inputname.SendKeys("asdfasdf");
                }
                var savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
                if (savebtn != null)
                {
                    savebtn.Click();
                    for (int i = 0; i < 60; i++)
                    {
                        savebtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.WebSaveBtn);
                        Thread.Sleep(1000);
                        if (savebtn == null)
                        {
                            Console.WriteLine("There's no add places part");
                        }
                        break;
                    }
                }
                Thread.Sleep(3000);
            }
            //add wifinetwork
            if (wifinetwork == true)
            {
                var addWifiNetwork = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddWifiNetwork);
                if (addWifiNetwork != null)
                {
                    addWifiNetwork.Click();
                }
                Thread.Sleep(10000);
                var chooseNetwork = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.ChooseNetwork);
                if (chooseNetwork != null)
                {
                    chooseNetwork.Click();
                }
                Thread.Sleep(5000);
                var addBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddBtn);
                if (addBtn != null)
                {
                    addBtn.Click();
                }
                Thread.Sleep(3000);
                var maybeLaterBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.MaybeLaterBtn);
                if (maybeLaterBtn != null)
                {
                    maybeLaterBtn.Click();
                    for (int i = 0; i < 60; i++)
                    {
                        maybeLaterBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.MaybeLaterBtn);
                        Thread.Sleep(1000);
                        if (maybeLaterBtn == null)
                        {
                            Console.WriteLine("There's no add wifi network part");
                        }
                        break;
                    }
                }
                Thread.Sleep(3000);
            }
            //add homeDevice
            if (homedevice == true)
            {
                if (homeDevice == 0)
                {
                    Console.WriteLine("No need to add homeDevice");
                }
                else
                {
                    var homeDeviceBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.HomeDeviceBtn);
                    if (homeDeviceBtn != null)
                    {
                        homeDeviceBtn.Click();
                    }
                    Thread.Sleep(10000);
                    foreach (IWebElement EachHomeDevice in HomeDeviceList.Take(homeDevice))
                    {
                        if (EachHomeDevice != null)
                        {
                            EachHomeDevice.Click();
                            Thread.Sleep(1000);
                        }
                    }
                    var addHomeDeviceBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddHomeDeviceBtn);
                    if (addHomeDeviceBtn != null)
                    {
                        addHomeDeviceBtn.Click();
                        for (int i = 0; i < 60; i++)
                        {
                            addHomeDeviceBtn = CHSHelper.FindElementByXpathFromWeb(_webSession, CHSWebXpath.AddHomeDeviceBtn);
                            Thread.Sleep(1000);
                            if (addHomeDeviceBtn == null)
                            {
                                Console.WriteLine("There's no add homeDevices part");
                            }
                            break;
                        }
                    }
                    Thread.Sleep(3000);
                }
            }
            _webSession.Close();
        }
    }
}


