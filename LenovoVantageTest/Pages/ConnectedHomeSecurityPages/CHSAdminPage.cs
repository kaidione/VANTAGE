using LenovoVantageTest.Helper;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NetFwTypeLib;
using OpenQA.Selenium.Appium.Windows;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Management;
using System.Text;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using System.Xml;
using TangramTest.Utility;

namespace LenovoVantageTest.Pages
{
    public class CHSAdminPage : SettingsBase
    {
        private string _SecurityHealthContractPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Vantage\SecurityHealthContract.txt");
        protected static RemoteTouchScreen touchScreen;
        private WindowsDriver<WindowsElement> session;
        public static string AdminJoinCode = "FTMIZX";
        public static string SecondJoinCode = "KBUMMA";
        public static string Sideload = "Sideload apps. Install apps from other sources that you trust, like your workplace.";
        public WindowsElement CHSDisconnectPromptBtn => base.GetElement(session, "AutomationId", "chs-modal-btn-disconnect");
        public WindowsElement CHSDisconnectCancelBtn => base.GetElement(session, "AutomationId", "chs-modal-btn-cancel");
        public WindowsElement CHSDisconnectPromotCloseBtn => base.GetElement(session, "AutomationId", "chs-trialModal-btn-close");
        public WindowsElement CHSLess30DaysRemain => base.GetElement(session, "Name", "28 days remaining");
        public WindowsElement CHSOver30DaysTitle => base.GetElement(session, "Name", "Paid Subscription");
        public WindowsElement CHSOver30DaysDescri => base.GetElement(session, "Name", "You have an active subscription of Connected Home Security. Good job protecting your home and family!", 20);
        public WindowsElement CHSNewOver30DaysDescri => base.GetElement(session, "Name", "You have an active subscription of Connected Home Security.");
        public WindowsElement CHSNewOutTrialText => base.GetElement(session, "Name", "Your trial period has expired.");
        public WindowsElement CHSOutTrialText => base.GetElement(session, "Name", "Your trial period has expired. Please purchase a subscription to keep your home and family protected!");
        public WindowsElement CHSExtendbtn => base.GetElement(session, "AutomationId", "chs-btn-extendNow", 20);
        public WindowsElement CHSOfflineDialog => base.GetElement(session, "AutomationId", "chs-btn-offlineDialogcancle");
        public WindowsElement CHSComponentNumber => base.GetElement(session, "Name", "2");
        public WindowsElement CHSGoToSetting => base.GetElement(session, "Name", "Go To Location Settings");
        public WindowsElement VantageCloseBth => base.GetElement(session, "AutomationId", "Close");
        public WindowsElement CHSEnableLocation => base.GetElement(session, "Name", "Enable Location");
        public WindowsElement PasswordProtection => base.GetElement(session, "Name", "Password Protection");
        public WindowsElement CHSSecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-toggle-security");
        public WindowsElement HSWIFISecurity => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-device-security-2");
        public WindowsElement DropDownCHS => base.GetElement(session, "AutomationId", "menu-main-nav-lnk-dropdown-menu-security-home-security-1");
        public WindowsElement CHSFamilyMember => base.GetElement(session, "Name", "Family members");
        public WindowsElement CHSDisconnectBtn => base.GetElement(session, "AutomationId", "chs-btn-disconnect");
        public WindowsElement CHSGoToDashBoard => base.GetElement(session, "AutomationId", "chs-btn-goToDashboard");
        public WindowsElement CHSTitle => base.GetElement(session, "AutomationId", "connected-home-security-header-title");
        public WindowsElement CHSBuyNow => base.GetElement(session, "AutomationId", "chs-btn-buyNow", 20);
        public WindowsElement CHSLenovoIDText => base.GetElement(session, "Name", "Lenovo ID:");
        public WindowsElement CHSOverview => base.GetElement(session, "Name", "Overview");
        public WindowsElement CHSHereLink => base.GetElement(session, "AutomationId", "chs-lnk-sh-learnmore");
        public WindowsElement CHSArticle => base.GetElement(session, "AutomationId", "article-title");
        public static Dictionary<string, string> SecurityList = new Dictionary<string, string>()
        {
            {"HardDriveEncryption","0"},
            {"AppFromUnknownSource", "1"},
            {"AntiVirus","2" },
            {"PasswordProtection", "3"},
            {"DeveloperMode", "4"},
            {"NotActivatedWindows", "5"},
            {"Firewall", "6"},
            {"UAC", "7"},
            {"SystemUpdate", "8"},
            {"AutomaticUpdateService", "9"},
        };
        string windowsResult = "C:\\result.txt";

        public CHSAdminPage(WindowsDriver<WindowsElement> session)
        {
            this.session = session;
            base.session = session;
        }

        private static NetFwTypeLib.INetFwMgr GetFirewallManager()
        {
            const string CLSID_FIREWALL_MANAGER = "{304CE942-6E39-40D8-943A-B913C40C9CD4}";
            Type objType = Type.GetTypeFromCLSID(new Guid(CLSID_FIREWALL_MANAGER));
            return Activator.CreateInstance(objType) as NetFwTypeLib.INetFwMgr;
        }

        public void ChangeWinPassword(string oldpassword, string newpassword)
        {
            try
            {
                var username = System.Environment.UserName;
                DirectoryEntry localmachine = new DirectoryEntry("WinNT://" + Environment.MachineName + ",computer");
                DirectoryEntry user = localmachine.Children.Find(username, "user");
                object[] password = new object[] { oldpassword, newpassword };
                object ret = user.Invoke("ChangePassword", password);
                user.CommitChanges();
                localmachine.Close();
                user.Close();
                Thread.Sleep(2000);
            }
            catch
            {
                LogHelper.Logger.Instance.WriteLog($"*************************** Change password failed! ************************");
            }
        }
        public bool GetFirewallStatus()
        {
            bool result = false;
            INetFwMgr netFwMgr = GetFirewallManager();
            if (netFwMgr.LocalPolicy.CurrentProfile.FirewallEnabled == true)
            {
                result = true;
            }
            return result;
        }

        public bool GetWindowsActiveStatus()

        {
            bool result = false;
            var cmds = new List<string>();
            cmds = new List<string>
            {
            string.Format("Start-Process -FilePath \"{0}\" -Wait -passthru ", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Vantage\CheckWindowsAuthStatus.bat"))
            };
            Common.RunPowershellCmdlet(cmds);
            StreamReader sr = new StreamReader(windowsResult, Encoding.Default);
            string line = sr.ReadLine();
            if (line.Contains("Licensed"))
            {
                result = true;
            }
            return result;
        }

        public bool GetBitlockerStatus()
        {
            bool result = false;
            ManagementObjectSearcher Encryption = new ManagementObjectSearcher(@"root\cimv2\Security\MicrosoftVolumeEncryption", "SELECT * FROM Win32_EncryptableVolume");
            foreach (ManagementObject QueryObj in Encryption.Get())
            {
                string EncryptionStatus = QueryObj.GetPropertyValue("ProtectionStatus").ToString();
                if (EncryptionStatus == "0")
                {
                    LogHelper.Logger.Instance.WriteLog($"***************************Not encryption ************************");
                }
                else if (EncryptionStatus == "1")
                {
                    result = true;
                }
                else if (EncryptionStatus == "2")
                {
                    LogHelper.Logger.Instance.WriteLog($"***************************There is no certain result for bitlocker ************************");
                }
            }
            return result;
        }

        public bool GetPasswordStatus()
        {
            bool result = false;
            string password = "Password Sign in with your account’s password";
            Process.Start(Constants.passwordProtocol);
            Thread.Sleep(2000);
            Process.Start(Constants.passwordProtocol);
            Thread.Sleep(2000);
            AutomationElement settings = VantageCommonHelper.FindElement(null, null, password);
            if (settings != null)
            {
                double x = settings.Current.BoundingRectangle.Left + settings.Current.BoundingRectangle.Width / 2;
                double y = settings.Current.BoundingRectangle.Bottom - settings.Current.BoundingRectangle.Height / 2;
                VantageCommonHelper.SetMouseClick(x.ToString(), y.ToString());
                AutomationElement button1 = VantageCommonHelper.FindElement(null, null, "Change");
                AutomationElement button2 = VantageCommonHelper.FindElement(null, null, "Add");

                if (button1 != null && button2 == null)
                {
                    result = true;
                }
                else if (button1 == null && button2 != null)
                {
                }
            }
            else
            {
                throw new Exception("Can not find password status");
            }
            return result;
        }

        public bool GetSecurityHealthResult(string SecurityPart)
        {
            Thread.Sleep(10000);
            bool result = false;
            string number = string.Empty;
            SecurityList.TryGetValue(SecurityPart, out number);
            FileStream file = new FileStream(_SecurityHealthContractPath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(file, Encoding.Default);
            string str = sr.ReadToEnd();
            string info = NerveCenterHelper.GetRequestInfomationFromImController("SystemManagement.WiFiSecurity", "Get-DeviceConfig", "", str);
            if (!(string.IsNullOrEmpty(info)))
            {
                string ItemName = GetXMLCtadaValue(info, "//ContractResponse/Response/Data/text()", "/DeviceSecurityDeviceConfigResponse/DeviceConfigList/SettingList", number);
                Debug.WriteLine(ItemName);
                if (ItemName.Equals("False"))
                {
                    result = true;
                }
            }
            return result;
        }

        public static string GetXMLCtadaValue(string xmlStr, string value, string cdata, string getvalue)
        {
            string result = string.Empty;
            if (string.IsNullOrEmpty(xmlStr))
            {
                return string.Empty;
            }
            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument SecurityHealthDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            var CdataContent = (XmlCDataSection)xmlDoc.SelectSingleNode(value);
            string text = CdataContent.InnerText.Trim();
            SecurityHealthDoc.LoadXml(text);
            XmlNodeList nodeList = SecurityHealthDoc.SelectNodes(cdata);
            int nodeIndex = 0;
            foreach (var node in nodeList)
            {
                var nodeChild = node as XmlNode;
                var settingList = nodeChild.FirstChild;
                var setting = settingList?.InnerText;
                if (string.IsNullOrEmpty(setting))
                {
                    nodeIndex++;
                    continue;
                }
                if (setting.ToString().Equals(getvalue))
                {
                    result = nodeChild.LastChild.InnerText;
                }
            }
            return result;
        }

        public bool GetSystemResult(string part)
        {
            bool systemresult = false;
            if (!string.IsNullOrEmpty(part))
            {
                switch (part)
                {
                    case "NotActivatedWindows":
                        systemresult = GetWindowsActiveStatus();
                        return systemresult;
                    case "HardDriveEncryption":
                        systemresult = GetBitlockerStatus();
                        return systemresult;
                    case "PasswordProtection":
                        systemresult = GetPasswordStatus();
                        return systemresult;
                    case "Firewall":
                        systemresult = GetFirewallStatus();
                        return systemresult;
                    case "DeveloperMode":
                        systemresult = GetDeveloperStatus();
                        return !systemresult;
                    case "AntiVirus":
                        systemresult = GetAntivirusStatus();
                        return systemresult;
                    case "AppFromUnknownSource":
                        systemresult = GetSideloadStatus();
                        return systemresult;
                }
            }
            return systemresult;
        }

        public void ChangeFireWallStatus(string setfirewall)
        {
            RegistryKey key = Registry.LocalMachine;
            int domainState = 1;
            int publicState = 1;
            int standardState = 1;
            try
            {
                if (setfirewall.Equals("Disable"))
                {
                    domainState = 0;
                    publicState = 0;
                    standardState = 0;
                }
                string path = "hklm\\SYSTEM\\ControlSet001\\Services\\SharedAccess\\Defaults\\FirewallPolicy";
                RegistryKey firewall = key.OpenSubKey(path, true);
                var result = RegistryHelp.GetRegistryKeyValue(path, true);

                RegistryKey domainProfile = firewall.OpenSubKey("DomainProfile", true);
                RegistryKey publicProfile = firewall.OpenSubKey("PublicProfile", true);
                RegistryKey standardProfile = firewall.OpenSubKey("StandardProfile", true);
                domainProfile.SetValue("EnableFirewall", domainState, RegistryValueKind.DWord);
                publicProfile.SetValue("EnableFirewall", publicState, RegistryValueKind.DWord);
                standardProfile.SetValue("EnableFirewall", standardState, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                string error = $"registry error：{e.Message}";
                throw new Exception(error);
            }
        }

        public void ChangeDeveloperMode(string status)
        {
            int developerStatus = 1;
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\AppModelUnlock", true);
                if (status.ToLower().Equals("disable"))
                {
                    developerStatus = 0;
                }
                key.SetValue("AllowDevelopmentWithoutDevLicense", developerStatus, RegistryValueKind.DWord);
            }
            catch (Exception e)
            {
                string error = $"注册表修改出错：{e.Message}";
                throw new Exception(error);
            }
        }
        public bool GetDeveloperStatus()
        {
            bool result = false;
            var osVersion = System.Environment.OSVersion;
            Process.Start(Constants.developermodeProtocol);
            Thread.Sleep(2000);
            if (osVersion.ToString().Contains("18363"))
            {
                var page = new CHSAdminPage(session);
                WindowsDriver<WindowsElement> appSession = page.GetControlPanelSession(true);
                WindowsElement element = FindElementByTimes(appSession, "Name", "Developer mode. Install any signed and trusted app and use advanced development features.", 10);
                result = element.Selected;
            }
            else
            {
                UIAutomationControl control = new UIAutomationControl();
                var toggle = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, "ToggleSwitch"), new PropertyCondition(AutomationElement.AutomationIdProperty, "SystemSettings_Developer_Mode_ToggleSwitch")));
                result = control.SetOrCheckToggleStatusByAutomationElement(toggle, false, ToggleState.On);
            }
            return result;

        }
        public bool GetAntivirusStatus()
        {
            List<string> cmds = new List<string>
            {
                $"Get-MpPreference | Select-Object DisableRealtimeMonitoring"
            };
            string anti = CommandBase.GetPowershellCmdletResult(cmds);
            if (anti.Contains("True"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool GetSideloadStatus()
        {
            Process.Start(Constants.developermodeProtocol);
            Thread.Sleep(2000);
            var page = new CHSAdminPage(session);
            WindowsDriver<WindowsElement> appSession = page.GetControlPanelSession(true);
            WindowsElement element = FindElementByTimes(appSession, "Name", "Microsoft Store apps. Only install apps from the Microsoft Store.", 10);
            bool selected = element.Selected;
            return selected;
        }

        public void EnableSideloadStatus(string status)
        {
            Process.Start(Constants.developermodeProtocol);
            Thread.Sleep(2000);
            var page = new CHSAdminPage(session);
            WindowsDriver<WindowsElement> appSession = page.GetControlPanelSession(true);
            switch (status.ToLower())
            {
                case "windows":
                    WindowsElement sideload = FindElementByTimes(appSession, "Name", "Microsoft Store apps. Only install apps from the Microsoft Store.", 10);
                    bool sideloadSelected = sideload.Selected;
                    if (sideloadSelected == false)
                    {
                        sideload.Click();
                        Thread.Sleep(2000);
                    }
                    break;
                case "developer":
                    WindowsElement developer = FindElementByTimes(appSession, "Name", "Developer mode. Install any signed and trusted app and use advanced development features.", 10);
                    bool devSelected = developer.Selected;
                    if (devSelected == false)
                    {
                        developer.Click();
                        Thread.Sleep(3000);
                        SendKeys.SendWait("{ENTER}");
                        Thread.Sleep(2000);
                    }
                    break;
            }
        }

        public void ChangeFirewallStatus(string status)
        {
            string cmd = "Netsh advfirewall set allprofile state " + status.ToLower();
            CommandBase.RunCmd(cmd);
        }

    }
}
