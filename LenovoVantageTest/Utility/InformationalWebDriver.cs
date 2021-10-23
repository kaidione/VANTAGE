using interop.UIAutomationCore;
using LenovoVantageTest.Pages.HardwareSettingsPages;
using LenovoVantageTest.Utility.UIAImplementation;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace LenovoVantageTest.Utility
{
    public class InformationalWebDriver : IInformationalWebDriver
    {
        WindowsDriver<WindowsElement> session;
        IWebDriver winAppDriver;
        public InformationalWebDriver(IWebDriver _driver, WindowsDriver<WindowsElement> _session)
        {
            winAppDriver = _driver;
            session = _session;
        }

        public IWebDriver WinAppDriver
        {
            get;
            private set;
        }


        public WindowsDriver<WindowsElement> Session
        {
            get
            {
                /*Marcus临时代码：现在不少code还在使用WinAppDriver。在Vantage被relaunch后没有mechanism重新bind ，这会导致后面任何GUI操作exception
                * 直接尝试访问webdriver，出错就说明需要重新binding
                */
                bool commonVantage = VantageConstContent.VantageTypePlan != VantageConstContent.VantageType.LE;

                string appXpath = string.Format("/Window[@Name='{0}']", commonVantage ? Constants.VantageTitle : Constants.VantageLETitle);

                try
                {
                    string handle = session.CurrentWindowHandle;
                    return session;
                }
                catch (System.NullReferenceException)
                {

                    List<interop.UIAutomationCore.IUIAutomationElement> list = UIAHelper.SearchForElementsAndDoSth(appXpath, 1);
                    if (list.Count > 0)
                    {
                        winAppDriver = session = rebind(list[0].CurrentNativeWindowHandle.ToInt32());
                    }
                }
                catch (OpenQA.Selenium.WebDriverException)
                {
                    List<interop.UIAutomationCore.IUIAutomationElement> list = UIAHelper.SearchForElementsAndDoSth(appXpath, 1);
                    if (list.Count > 0)
                    {
                        winAppDriver = session = rebind(list[0].CurrentNativeWindowHandle.ToInt32());
                    }
                }
                return session;
            }
            private set
            {
                winAppDriver = session = value;
            }
        }
        /*Auhtor: Marcus
        * Date: 2020/07/08
        * Desc: For reference for now. Since Vantage would be relaunched , old session is invalid . In launch Vantage , we may refresh the stored driver ???
        */
        WindowsDriver<WindowsElement> rebind(int _topWinHandle = 0)
        {
            /*Auhtor: Fangdq
            * Date: 2021/08/11
            * Desc: 如果运行过程中winappdriver被kill了 rebind的时候会抛出异常。在rebind的时候先查winappdriver 的process是否存在 不存在的时候重新将Winappdriver launch起来 
            */
            Process[] processes = Process.GetProcessesByName("WinAppDriver");
            if (processes.Length == 0)
            {
                BaseTestClass.StartWinAppDriver();
            }
            WindowsDriver<WindowsElement> Session = null;
            AppiumOptions desktopCapabilities = new AppiumOptions();
            desktopCapabilities.AddAdditionalCapability("platformName", "Windows");
            desktopCapabilities.AddAdditionalCapability("app", "Root");
            desktopCapabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            string hexMainWindowHandle = "";
            if (_topWinHandle == 0)
            {
                List<IUIAutomationElement> list = UIAHelper.SearchForElementsAndDoSth("/Window[@Name='Lenovo Vantage']");
                if (list.Count == 0)
                {
                    Console.WriteLine("Error: failed to rebind WinAppDriver to Vantage");
                    return null;
                }
                hexMainWindowHandle = list[0].CurrentNativeWindowHandle.ToString("X");
            }
            else
            {
                hexMainWindowHandle = _topWinHandle.ToString("X");
            }

            AppiumOptions capabilities = new AppiumOptions();
            capabilities.AddAdditionalCapability("deviceName", "WindowsPC");
            capabilities.AddAdditionalCapability("appTopLevelWindow", hexMainWindowHandle);
            Thread.Sleep(5000);
            Session = new WindowsDriver<WindowsElement>(new Uri("http://127.0.0.1:4723"), capabilities);
            return Session;
        }

    }
}
