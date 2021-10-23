using LenovoVantageTest.Utility;
using OpenQA.Selenium.Appium.Windows;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace BambooMultipleServer
{
    public class Common
    {
        private BaseSessionTestClass baseTestClass = new BaseSessionTestClass();

        public void RunCmd(string automationId)
        {
            try
            {
                var desktopSession = baseTestClass.DesktopSession();
                var windowsElement = FindElementsByTime(desktopSession, "AutomationId", automationId);
                if (windowsElement != null)
                {
                    windowsElement.Click();
                    Console.WriteLine(windowsElement.Id);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        public static bool KillProcess(string processName, bool needVerify)
        {
            try
            {
                Process[] ps0 = Process.GetProcessesByName(processName);
                if (ps0.Length == 0)
                {
                    Logger.Instance.WriteLog(string.Format("No process named: \"{0}\" found.", processName), LogType.Warning);
                    return false;
                }
                foreach (Process p in ps0)
                {
                    Logger.Instance.WriteLog(string.Format("To kill Process {0}", processName), LogType.Warning);
                    p.Kill();
                    p.WaitForExit();
                    System.Threading.Thread.Sleep(1500);
                    Logger.Instance.WriteLog(string.Format("Process {0} is killed", processName), LogType.Warning);
                }
                if (needVerify)
                {
                    //Verify
                    Process[] ps1 = Process.GetProcessesByName(processName);
                    if (ps1.Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("kill process error: " + ex.Message, LogType.Warning);
                return false;
            }
        }

        public static WindowsElement FindElementsByTime(WindowsDriver<WindowsElement> session, string elementClass, string locator, int timeOut = 30, int checktime = 10)
        {
            session.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeOut);
            WindowsElement elelist = null;

            while (checktime > 0)
            {
                try
                {
                    switch (elementClass)
                    {
                        case "XPath":
                            elelist = session.FindElementByXPath(locator);
                            break;
                        case "Name":
                            elelist = session.FindElementByName(locator);
                            break;
                        case "AutomationId":
                            elelist = session.FindElementByAccessibilityId(locator);
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
                    Console.WriteLine("FindElementsByTimes() Exception Info:" + locator + ex.ToString());
                }
                checktime--;
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
            return elelist;
        }

        public static void DeleteFolder(string dir)
        {
            foreach (string d in Directory.GetFileSystemEntries(dir))
            {
                if (File.Exists(d))
                {
                    try
                    {
                        FileInfo fi = new FileInfo(d);
                        if (fi.Attributes.ToString().IndexOf("ReadOnly") != -1)
                            fi.Attributes = FileAttributes.Normal;
                        File.Delete(d);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    try
                    {
                        DirectoryInfo d1 = new DirectoryInfo(d);
                        if (d1.GetFiles().Length != 0)
                        {
                            DeleteFolder(d1.FullName);
                        }
                        Directory.Delete(d);
                    }
                    catch
                    {

                    }
                }
            }
            Console.WriteLine("Delete Succeed!Time：" + DateTime.Now.ToString());
        }


    }
}
