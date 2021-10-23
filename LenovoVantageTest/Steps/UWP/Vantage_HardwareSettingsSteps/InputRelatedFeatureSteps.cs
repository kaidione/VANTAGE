using LenovoVantageTest.Helper;
using LenovoVantageTest.Pages;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility;
using Microsoft.Win32;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Automation;
using System.Windows.Forms;
using TechTalk.SpecFlow;

namespace LenovoVantageTest.Steps.UWP.Vantage_HardwareSettingsSteps
{
    [Binding]
    public class InputRelatedFeatureSteps : SettingsBase
    {
        private InformationalWebDriver _webDriver;
        static private string _regUserDefinedKey = @"SYSTEM\CurrentControlSet\Services\IBMPMSVC\Parameters2\Type10\Notification";
        SmartStandbyTestSteps ssts;
        private object _typeF12ValueInit;
        private bool _privacyGauge = false;
        private ToggleState _toggleState = ToggleState.Off;
        private int _countTime = 5;
        public HSInputPage hSInputPage;
        private GamingThermalModePages _gamingThermalModePages;

        public InputRelatedFeatureSteps(InformationalWebDriver appDriver)
        {
            _webDriver = appDriver;
            ssts = new SmartStandbyTestSteps(_webDriver);
        }

        [Given(@"Machine support User defined key")]
        public void GivenMachineSupportUserDefinedKey()
        {
            string FnDriverVer = GetDriverVersion("Fn and function");
            if (FnDriverVer == "UnknownVersion")
            {
                Assert.Fail("Machine Not install Fn and Function Driver");
            }
            object typeF12Value = ssts.GetRegistryValue(_regUserDefinedKey, "Type13");
            if (typeF12Value != null)
            {
                _typeF12ValueInit = typeF12Value;
            }
            else
            {
                Assert.Fail("The machine not support UserDefinedKey");
            }
        }

        [When(@"Click the (.*) Input Page Element")]
        public void WhenClickThePleaseSelectOptionInputPageElement(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            //ClickVantageElements(GetElement(_webDriver.Session, "XPath", targetID));
            ClickVantageElements(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID));
        }

        [Then(@"There is no (.*) Element")]
        public void ThenThereIsNoUserDefinedFeatureDescriptionElement(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            Assert.IsNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID));
        }

        [When(@"Resize Vantage to (.*) and (.*) windows")]
        public void WhenResizeVantageToAndWindows(int p0, int p1)
        {
            _webDriver.Session.Manage().Window.Size = new System.Drawing.Size(p0, p1);
        }


        [When(@"Simulate Press (.*) Event")]
        public void WhenSimulatePressFEvent(string simulateKey)
        {
            object typeF12Value = ssts.GetRegistryValue(_regUserDefinedKey, "Type13");
            if (typeF12Value != null)
            {
                _typeF12ValueInit = typeF12Value;
            }
            else
            {
                Assert.Fail("The machine not support F10/F11/F12");
            }
            uint value = Convert.ToUInt32(_typeF12ValueInit);
            switch (simulateKey.ToLower())
            {
                case "f12":
                    value = value ^ 0x00010000;
                    break;
                case "f10":
                    value = value ^ 0x00800000;
                    break;
                case "f11":
                    value = value ^ 0x01000000;
                    break;
            }
            int tempInt = 0;
            unchecked
            {
                tempInt = Convert.ToInt32(value);
            }
            RegistryKey rk = Registry.LocalMachine;
            RegistryKey tmp = rk.OpenSubKey(_regUserDefinedKey, true);
            tmp.SetValue("Type13", tempInt, RegistryValueKind.DWord);
        }

        [Then(@"(.*) will be Launched")]
        public void ThenDashboardWillBeLaunched(string targetApp)
        {
            Thread.Sleep(30 * 1000);
            switch (targetApp)
            {
                case "Dashboard or Privacy Gauge":
                    if (_privacyGauge == false)
                    {
                        Process[] process = Process.GetProcessesByName(VantageConstContent.VantageProcessName);
                        if (process.Length > 0)
                        {
                            var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                            _webDriver = new InformationalWebDriver(session, session);
                            string targetID = VantageConstContent.AutomationIDKeyMap["QuickSettingsTitle"];
                            //Assert.IsNotNull(GetElement(_webDriver.Session, "XPath", targetID));
                            Assert.IsNotNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID));
                        }
                        else
                        {
                            Assert.Fail("Dashboard not be launched after press F12");
                        }
                    }
                    else
                    {
                        Process.Start("lenovo-vantage3:device-settings");
                        //var session = VantageCommonHelper.LaunchSystemUwp(VantageConstContent.VantageUwpAppid);
                        //_webDriver = new InformationalWebDriver(session, session);
                        Thread.Sleep(10000);
                        //string notInProductionTip = "7601BE32-D46C-4CCD-85BB-EC869A0B24A8 Created with sketchtool.";
                        //ClickVantageElements(GetElement(_webDriver.Session, "Name", notInProductionTip));
                        //string DeviceButton = VantageConstContent.AutomationIDKeyMap["DeviceButton"];
                        //ClickVantageElements(GetElement(_webDriver.Session, "XPath", DeviceButton));
                        //string MyDevicePage = VantageConstContent.AutomationIDKeyMap["MyDevicePage"];
                        //ClickVantageElements(GetElement(_webDriver.Session, "XPath", MyDevicePage));
                        string DisplayCameraPage = VantageConstContent.AutomationIDKeyMap["DisplayCameraPage"];
                        //ClickVantageElements(GetElement(_webDriver.Session, "XPath", DisplayCameraPage));
                        ClickVantageElements(VantageCommonHelper.FindElementByXPath(_webDriver.Session, DisplayCameraPage));
                        Thread.Sleep(10000);
                        string privacyGuardToggle = VantageConstContent.AutomationIDKeyMap["PrivacyGuardToggle"];
                        if (_toggleState == ToggleState.Off)
                        {
                            //Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(GetElement(_webDriver.Session, "XPath", privacyGuardToggle)));
                            Assert.AreEqual(ToggleState.On, GetCheckBoxStatus(VantageCommonHelper.FindElementByXPath(_webDriver.Session, privacyGuardToggle)));
                        }
                        else
                        {
                            //Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(GetElement(_webDriver.Session, "XPath", privacyGuardToggle)));
                            Assert.AreEqual(ToggleState.Off, GetCheckBoxStatus(VantageCommonHelper.FindElementByXPath(_webDriver.Session, privacyGuardToggle)));
                        }
                    }
                    break;
                case "Teams":
                    Process[] processT = Process.GetProcesses();
                    Boolean flag = false;
                    foreach (Process p in processT)
                    {
                        if (p.GetCommandLine() != null && p.GetCommandLine().Trim().Equals(@"""C:\Users\" + Environment.UserName + @"\AppData\Local\Microsoft\Teams\current\Teams.exe"""))
                        {
                            flag = true;
                            p.Kill();
                            break;
                        }
                    }
                    Assert.IsTrue(flag, "Teams not launching after we simulate to press F10/F11");
                    break;
                default:
                    Process[] processApp = Process.GetProcessesByName(targetApp);
                    if (processApp.Length > 0)
                    {
                        Assert.IsTrue(true);
                        Common.KillProcess(targetApp, true);
                    }
                    else
                    {
                        Assert.Fail(targetApp + " not be launched after press FKey");
                    }
                    break;
            }
        }

        [Then(@"Check the (.*) Element")]
        public void ThenCheckThePleaseSelectOptionElement(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            //Assert.IsNotNull(GetElement(_webDriver.Session, "XPath", targetID));
            Assert.IsNotNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), targetElement + " element is not found.");
        }

        [Then(@"Check the (.*) UIElement")]
        public void ThenCheckThePleaseSelectOptionUIElement(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            string uispecText = VantageConstContent.UISpecKeyMap[targetElement];
            //CheckUIWithSPEC(GetElement(_webDriver.Session, "XPath", targetID), uispecText);
            CheckUIWithSPEC(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), uispecText);
        }

        [Then(@"The DropDown List Title is (.*)")]
        public void ThenTheDropDownListTitleIsOpenAppFileOption(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["UserDefinedKeyDropdownBtn"];
            string uispecText = VantageConstContent.UISpecKeyMap[targetElement];
            //string currentUI = VantageCommonHelper.GetAttributeValue(GetElement(_webDriver.Session, "XPath", targetID), "Name");
            string currentUI = VantageCommonHelper.GetAttributeValue(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), "Name");
            Assert.IsTrue(currentUI.Contains(uispecText));
        }

        [When(@"Get the PrivacyGuardToggle Elements State")]
        public void WhenGetThePrivacyGuardToggleElementsState()
        {
            _countTime = 5;
            GetThePrivacyGuardToggleElementsState();
        }

        private void GetThePrivacyGuardToggleElementsState()
        {
            try
            {
                string targetID = VantageConstContent.AutomationIDKeyMap["PrivacyGuardToggle"];
                //WindowsElement privateGuardToggle = GetElement(_webDriver.Session, "XPath", targetID);
                WindowsElement privateGuardToggle = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
                if (privateGuardToggle != null)
                {
                    _privacyGauge = true;
                    _toggleState = GetCheckBoxStatus(privateGuardToggle);
                }
            }
            catch (Exception e)
            {
                if (_countTime > 0 && e.ToString().Contains("An element command failed because the referenced element is no longer attached to the DOM"))
                {
                    _countTime--;
                    GetThePrivacyGuardToggleElementsState();

                }
            }
        }

        [When(@"Wait the App displayed")]
        public void WhenWaitTheAppDisplayed()
        {
            _countTime = 10;
            WaitTheAppDisplayed();
        }

        [Then(@"The ADD link state is (.*)")]
        public void ThenTheADDLinkCanBeClicked(string state)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["UserDefinedKeyApplicationsADDLink"];
            //WindowsElement targetElement =  GetElement(_webDriver.Session, "XPath", targetID);
            WindowsElement targetElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            if (state == "unclicked")
            {
                Assert.IsFalse(targetElement.Enabled);
            }
            else
            {
                Assert.IsTrue(targetElement.Enabled);
            }
        }

        [Then(@"The (.*) element is in (.*) state")]
        public void ThenTheInvokeKeySequenceApplyButtonElementIsInGreyoutState(string targetElement, string state)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            WindowsElement tElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            if (state == "Greyout")
            {
                Assert.IsFalse(tElement.Enabled);
            }
            else
            {
                Assert.IsTrue(tElement.Enabled);
            }
        }

        [When(@"Add the LongFile in Vantage")]
        public void WhenAddTheLongFileInVantage()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["LongFile"];
            ClickVantageElements(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID));
        }

        [When(@"Hover the mouse on the (.*) Element")]
        public void WhenHoverTheMouseOnTheUserDefinedKeyApplicationsADDLinkElement(string targetElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            //WindowsElement tElement = GetElement(_webDriver.Session, "XPath", targetID);
            WindowsElement tElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            VantageCommonHelper.HoverOnVantage(_webDriver.Session, tElement);
        }

        [When(@"Copy UserDefinedKeyFile")]
        public void WhenCopyUserDefinedKeyFile()
        {
            SmartStandbyTestSteps sst = new SmartStandbyTestSteps(_webDriver);
            string dirPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Data\Tools\UserDefinedKey");
            if (!Directory.Exists(@"C:\UserDefinedKey"))
            {
                Directory.CreateDirectory(@"C:\UserDefinedKey");
            }
            sst.CopyFolder(dirPath, @"C:\UserDefinedKey");
        }


        [When(@"Click all The Delete Button Element")]
        public void WhenClickAllTheDeleteButtonElement()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["DeleteButton"];
            ReadOnlyCollection<WindowsElement> tElements = GetElements(_webDriver.Session, "XPath", targetID);
            foreach (WindowsElement te in tElements)
            {
                if (te != null)
                {
                    ClickVantageElements(te);
                }
            }
        }

        [Then(@"There is noly (.*) (.*) Element")]
        public void ThenThereIsNolyPaintAppElement(int num, string tarElement)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[tarElement];
            ReadOnlyCollection<WindowsElement> tElements = GetElements(_webDriver.Session, "XPath", targetID);
            Assert.AreEqual(num, tElements.Count);
        }

        [Then(@"Check the (.*) has been opened")]
        public void ThenCheckTheOneTextHasBeenOpened(string fileName)
        {
            Assert.IsTrue(CheckTargetFileStatus(fileName));
        }


        [DllImport("kernel32.dll")]
        public static extern IntPtr _lopen(string lpPathName, int iReadWrite);

        [DllImport("kernel32.dll")]
        public static extern bool CloseHandle(IntPtr hObject);

        public const int OF_READWRITE = 2;
        public const int OF_SHARE_DENY_NONE = 0x40;
        public readonly IntPtr HFILE_ERROR = new IntPtr(-1);

        public bool CheckTargetFileStatus(string fileName)
        {
            string workingDirectory = Assembly.GetExecutingAssembly().Location;
            string projectDiectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            var file = Path.Combine(projectDiectory, "UserDefinedKeyTxt") + "\\" + fileName + ".txt";
            if (!File.Exists(file))
            {
                return false;
            }
            IntPtr vHandle = _lopen(file, OF_READWRITE | OF_SHARE_DENY_NONE);//windows Api上面有定义扩展方法
            if (vHandle == HFILE_ERROR)
            {
                return true;
            }
            CloseHandle(vHandle);
            return false;

        }

        [When(@"Add the File (.*) in Vantage")]
        public void WhenAddTheFileInVantage(string fileNmuber)
        {
            Thread.Sleep(2000);
            string fileName = Path.Combine(@"C:\UserDefinedKey", "File" + fileNmuber + ".txt");
            SendKeys.SendWait(fileName);
        }

        [Then(@"Check the (.*) UIElement Display (.*)")]
        public void ThenCheckTheInvokeKeySequenceInputFormUIElementDisplay(string targetElement, string UIText)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap[targetElement];
            CheckUIWithSPEC(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), UIText);
        }


        private void WaitTheAppDisplayed()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["ProgramsApp"];
            //WindowsElement ProgramsApp = GetElement(_webDriver.Session, "XPath", targetID);
            WindowsElement ProgramsApp = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            if (_countTime > 0 && ProgramsApp == null)
            {
                _countTime--;
                Thread.Sleep(5000);
                WaitTheAppDisplayed();
            }
        }

        [Then(@"Check Fn and Ctrl key swap feature (.*) show")]
        public void ThenCheckFnAndCtrlKeySwapFeatureNotShow(String Status)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            Thread.Sleep(3000);
            if (Status.Equals("Not"))
            {
                Assert.IsNull(hSInputPage.fnCtrlKey_Title);
            }
            if (Status.Equals("Should"))
            {
                Assert.IsTrue(hSInputPage.fnCtrlKey_Title.Enabled);
                Assert.IsTrue(hSInputPage.fnCtrlKey_Toggle.Enabled);
                Assert.IsTrue(hSInputPage.fnCtrlKey_TexDescription.Enabled);
            }
        }

        [Given(@"Go to Fn and Ctrl key swap section")]
        public void GivenGoToFnAndCtrlKeySwapSection()
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            Thread.Sleep(3000);
            //hSInputPage.moreSection_Title.Click();
            ScrollScreenToWindowsElement(_webDriver.Session, hSInputPage.fnCtrlKey_TexDescription, -30, 30, true);
        }

        [Given(@"Turn (.*) the the toggle for Swap feature")]
        public void GivenTurnOnTheTheToggleForSwapFeature(String Status)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            Thread.Sleep(3000);
            Assert.NotNull(hSInputPage.fnCtrlKey_Toggle);
            if (Status.Equals("on"))
            {
                if (VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle) == ToggleState.Off)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(hSInputPage.fnCtrlKey_Toggle, ToggleState.On);
                    Assert.IsTrue(result);
                }
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle), ToggleState.On);
            }
            if (Status.Equals("off"))
            {
                if (VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle) == ToggleState.On)
                {
                    bool result = VantageCommonHelper.SwitchToggleStatus(hSInputPage.fnCtrlKey_Toggle, ToggleState.Off);
                    Assert.IsTrue(result);
                }
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle), ToggleState.Off);
            }
        }

        [Then(@"The default state of the toggle is off")]
        public void ThenTheDefaultStateOfTheToggleIsOff()
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            Thread.Sleep(3000);
            Assert.NotNull(hSInputPage.fnCtrlKey_Toggle);
            Assert.AreEqual(VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle), ToggleState.Off);
        }

        [Then(@"Check the state of the toggle for Swap feature is (.*)")]
        public void ThenCheckTheStateOfTheToggleForSwapFeatureIsOn(String Status)
        {
            hSInputPage = new HSInputPage(_webDriver.Session);
            Thread.Sleep(3000);
            Assert.NotNull(hSInputPage.fnCtrlKey_Toggle);
            if (Status.Equals("on"))
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle), ToggleState.On);
            }
            if (Status.Equals("off"))
            {
                Assert.AreEqual(VantageCommonHelper.GetToggleStatus(hSInputPage.fnCtrlKey_Toggle), ToggleState.Off);
            }
        }

        [When(@"Remane the Edge exe")]
        public void WhenRemaneTheEdgeExe()
        {
            FileInfo fi = new FileInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
            if (fi.Exists)
            {
                fi.MoveTo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedgee.exe");
            }
            else
            {
                FileInfo fiN = new FileInfo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedgee.exe");
                fiN.MoveTo(@"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe");
            }
        }

        [When(@"Remane the File (.*) name to (.*)")]
        public void WhenRemaneTheFileNameToX(string fileNum, string fileNew)
        {
            string oriStr = Path.Combine(@"C:\UserDefinedKey", "File" + fileNum + ".txt");
            string newStr = Path.Combine(@"C:\UserDefinedKey", "File" + fileNew + ".txt");
            FileInfo fi = new FileInfo(oriStr);
            if (fi.Exists)
            {
                if (File.Exists(newStr))
                {
                    File.Delete(newStr);
                }
                fi.MoveTo(newStr);
            }
            else
            {
                Assert.Fail("There is no " + oriStr);
            }
        }

        [When(@"Remove the File (.*) to C")]
        public void WhenRemoveTheFileToC(int fileNum)
        {
            string oriStr = Path.Combine(@"C:\UserDefinedKey", "File" + fileNum + ".txt");
            string newStr = Path.Combine(@"C:\", "File" + fileNum + ".txt");
            FileInfo fi = new FileInfo(oriStr);
            if (fi.Exists)
            {
                if (File.Exists(newStr))
                {
                    File.Delete(newStr);
                }
                fi.MoveTo(newStr);
            }
        }

        [When(@"Created a long file")]
        public void WhenCreatedALongFile()
        {
            string strPath = @"C:\UserDefinedKey";
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
            string longFile = strPath + @"\FileLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLLA.txt";
            if (!File.Exists(longFile))
            {
                File.Create(longFile);
            }
        }

        [When(@"Detele File (.*)")]
        public void WhenDeteleFile(string fileNumber)
        {
            string fileName = @"C:\UserDefinedKey\File" + fileNumber + ".txt";
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
        }


        [Then(@"The Keyboard Manager Windows will be pupped up")]
        public void ThenTheKeyboardManagerWindowsWillBePuppedUp()
        {
            AutomationElement CloseButton = VantageCommonHelper.FindElementByIdIsEnabled("CloseErrorMsg");
            Assert.IsNotNull(CloseButton, "Keyboard Error not launched");
            if (CloseButton != null)
            {
                var position = CloseButton.Current.BoundingRectangle;
                string x = ((int)position.Left + (int)position.Width / 2).ToString();
                string y = ((int)position.Bottom - (int)position.Height / 2).ToString();
                VantageCommonHelper.SetMouseClick(x, y, false);
            }
        }

        [Then(@"File (.*) will be launched")]
        public void ThenFileWillBeLaunched(string fileNum)
        {
            bool openedFile = false;
            Process[] processT = Process.GetProcesses();
            foreach (Process p in processT)
            {
                if (p.GetCommandLine() != null && p.GetCommandLine().Contains(@"C:\UserDefinedKey\File" + fileNum + ".txt"))
                {
                    openedFile = true;
                    p.Kill();
                    break;
                }
            }
            Assert.IsTrue(openedFile, fileNum + " file was not be opened");
        }

        [Then(@"""(.*)"" Web will be launched")]
        public void ThenWebWillBeLaunched(string webURL)
        {
            bool openedWeb = false;
            Process[] processT = Process.GetProcesses();
            foreach (Process p in processT)
            {
                if (p.GetCommandLine() != null && p.GetCommandLine().Contains(webURL))
                {
                    openedWeb = true;
                    p.Kill();
                    break;
                }
            }
            Assert.IsTrue(openedWeb, webURL + " was not be opened");
        }

        [Then(@"The Apply button for URL is Greyout")]
        public void ThenTheApplyButtonForURLIsGreyout()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["WebsiteApplyButton"];
            WindowsElement ApplyButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            Assert.IsFalse(ApplyButton.Enabled, "ApplyButton not in Greyout state");
        }

        [Then(@"The Apply button for Text is Greyout")]
        public void ThenTheApplyButtonForTextIsGreyout()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["EnterTextApplyButton"];
            WindowsElement ApplyButton = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            Assert.IsFalse(ApplyButton.Enabled, "ApplyButton not in Greyout state");
        }


        [Then(@"The default Help Tips should follow the UISPEC")]
        public void ThenTheDefaultHelpTipsShouldFollowTheUISPEC()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["WebsiteHelpTip"];
            WindowsElement Helptip = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            Assert.IsNotNull(Helptip, "WebsiteHelpTip elements is null");
            string HelpTipText = Helptip.GetAttribute("HelpText");
            Assert.AreEqual(VantageConstContent.UISpecKeyMap["WebsiteHelpTip"], HelpTipText);
        }

        [Then(@"The EnterText default Help Tip follow UISPEC")]
        public void ThenTheEnterTextDefaultHelpTipFollowUISPEC()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["EnterTextHelpTip"];
            WindowsElement Helptip = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            Assert.IsNotNull(Helptip, "EnterTextHelpTip elements is null");
            string HelpTipText = Helptip.GetAttribute("HelpText");
            Assert.AreEqual(VantageConstContent.UISpecKeyMap["EnterTextHelpTip"], HelpTipText);
        }


        [Then(@"The InvalidURLTip will Disapperaed")]
        public void ThenTheInvalidURLTipWillDisapperaed()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["InvalidURLTip"];
            Assert.IsNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), "InvalidURLTip elements is not null");
        }

        [Then(@"The SuccURLTip will Disapperaed")]
        public void ThenTheSuccURLTipWillDisapperaed()
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["SuccURLTip"];
            Assert.IsNull(VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID), "SuccURLTip elements is not null");
        }

        [Then(@"Check the Text ""(.*)"" has Entered correctly")]
        public void ThenCheckTheTextHasEnteredCorrectly(string targetText)
        {
            string targetID = VantageConstContent.AutomationIDKeyMap["EnterTextHelpTip"];
            WindowsElement textElement = VantageCommonHelper.FindElementByXPath(_webDriver.Session, targetID);
            CheckUIWithSPEC(textElement, targetText);
        }

        [When(@"Press (.*) Backspace button")]
        public void WhenPressBackspaceButton(int timeNum)
        {
            for (int i = 0; i < timeNum; i++)
            {
                SendKeys.SendWait("{BS}");
            }
        }

        [When(@"Scrool (.*) times screen (.*)")]
        public void WhenScroolTimesScreen(int p0, int p1)
        {
            if (VantageConstContent.VantageTypePlan == VantageConstContent.VantageType.LE)
            {
                _gamingThermalModePages = new GamingThermalModePages(_webDriver.Session);
                _gamingThermalModePages.ScrollScreen(p0 * p1 + p1);
            }
        }
    }
}
