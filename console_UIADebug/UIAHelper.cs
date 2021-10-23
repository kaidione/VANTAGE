using interop.UIAutomationCore;
using LenovoVantageTest.LogHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author: Marcus
    /// Desc: stackoverflow.com/questions/14187110/uiautomation-wont-retrieve-children-of-an-element
    /// </summary>
    public class UIAHelper
    {
        const string VantageTitle = "Lenovo Vantage";
        #region Vantage Specific

        /*Author:Marcus*/
        public static bool VantageElementExistUsingXPath(string _xpath)
        {
            return VantageElementExistUsingXPath(_xpath);

        }
        public static bool VantageElementExistUsingXPath(string _xpath, int _timeout = 10)
        {
            return ElementExistUsingCustomXPath(Path.Combine(VantageTitle, _xpath), _timeout);

        }
        /*Author:Marcus*/
        public static bool VantageElementExistUsingAutomationId(string _autoid)
        {
            return VantageElementExistUsingAutomationId(_autoid, 10);

        }

        /*Author:Marcus*/
        public static bool VantageElementExistUsingAutomationId(string _autoid, int _timeoutInSeconds = 10)
        {
            return ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), _timeoutInSeconds);

        }

        /*Author:Marcus*/
        public static bool VantageElementExistUsingName(string _name)
        {
            return VantageElementExistUsingName(_name, 10);

        }

        /*Author:Marcus*/
        public static bool VantageElementExistUsingName(string _name, int _timeoutInSeconds = 10)
        {
            return UIAHelper.ElementExistUsingCustomXPath(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@Name='{0}']", _name), _timeoutInSeconds);

        }
        public static string VantageClickElementtUsingAutomationId(string _autoid, int timeout = 90)
        {
            return ClickElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), timeout);

        }

        /*Author: Marcus*/
        public static string VantageClickElementtUsingName(string _name4GUIElement)
        {
            return VantageClickElementtUsingName(_name4GUIElement, 10);

        }
        /*Author: Marcus*/
        public static string VantageClickElementtUsingName(string _name4GUIElement, int _timeoutInSeconds = 10)
        {
            return ClickElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@Name='{0}']", _name4GUIElement), _timeoutInSeconds);

        }

        public static string VantageMouseFocusElementtUsingAutomationId(string _autoid)
        {
            return VantageMouseFocusElementtUsingAutomationId(_autoid, 5);

        }
        public static string VantageMouseFocusElementtUsingAutomationId(string _autoid, int _timeoutInSeconds = 5)
        {
            return MouseFocusElementUsingCustomXPath(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), _timeoutInSeconds);

        }


        public static string VantageMouseClickElementtUsingAutomationId(string _autoid)
        {
            return VantageMouseClickElementtUsingAutomationId(_autoid, 5);

        }

        public static string VantageMouseClickElementtUsingAutomationId(string _autoid, int _timeoutInSeconds = 5)
        {
            return SimulateMouseClickGUIElement(string.Format("/Window[@Name='{0}']", VantageTitle) + string.Format("//*[@AutomationId='{0}']", _autoid), _timeoutInSeconds).ToString();

        }

        public static int VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _AutomationIds)
        {

            return VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(_AutomationIds, 10);
        }

        public static int VantageElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _AutomationIds, int _timeoutInSeconds = 10)
        {
            string[] xpathes = new string[_AutomationIds.Length];
            for (int ctr = 0; ctr < _AutomationIds.Length; ctr++)
            {
                xpathes[ctr] = $"/Window[@Name='{VantageTitle}']//*[@AutomationId='{_AutomationIds[ctr]}']";
            }
            return UIAHelper.ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(xpathes, _timeoutInSeconds);
        }
        /* Author: Marcus
        * Desc: Variant of VantageElementAnyExistUsingAutomationId(). Giving default timeout limit of 10 seconds
        */
        public static bool VantageElementAnyExistUsingAutomationId(string[] _AutomationIds)
        {
            return VantageElementAnyExistUsingAutomationId(_AutomationIds, 10);
        }
        /* Author: Marcus
         * Desc: Variant of ElementAnyExistUsingCustomXPath(). It's a convenient way for anyone who only need search any GUI element on Vantage
         */
        public static bool VantageElementAnyExistUsingAutomationId(string[] _AutomationIds, int _timeoutInSeconds = 10)
        {
            string[] xpathes = new string[_AutomationIds.Length];
            for (int ctr = 0; ctr < _AutomationIds.Length; ctr++)
            {
                xpathes[ctr] = $"/Window[@Name='{VantageTitle}']//*[@AutomationId='{_AutomationIds[ctr]}']";
            }
            return ElementAnyExistUsingCustomXPath(xpathes, _timeoutInSeconds);
        }

        public static int VantageElementIsToggledUsingAutomationId(string _automationID)
        {
            return ElementIsToggledUsingCustomXPath($"/Window[@Name='{VantageTitle}']//*[@AutomationId='{_automationID}']");
        }
        public static int VantageElementIsToggledUsingName(string _name)
        {
            return ElementIsToggledUsingCustomXPath($"/Window[@Name='{VantageTitle}']//*[@Name='{_name}']");
        }
        #endregion
        #region Keyboard & Mouse
        /*有些GUI可能没有正确暴露接口，导致无法invoke或setValue，这时用鼠标点击可以临时workaround.缺点是任何一个window挡住要操作的GUI，click()就错误了。*/
        public static bool SimulateMouseClickGUIElement(string _xpath, int _timeoutInSeconds = 5)
        {

            List<IUIAutomationElement> uIAUtomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds);
            if (uIAUtomationElements.Count == 0)
            {
                return false;
            }
            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = uIAUtomationElements[0].CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            {
                return false;
            }
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            KeyboardMouse.DoMouseClick(centeric[0], centeric[1]);
            return true;
        }
        public static bool SimulateMouseClickGUIElementAndInput(string _xpath, string _input, int _timeoutInSeconds = 5)
        {

            List<IUIAutomationElement> uIAUtomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds);
            if (uIAUtomationElements.Count == 0)
            {
                return false;
            }
            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = uIAUtomationElements[0].CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width)
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height)
            {
                return false;
            }
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            KeyboardMouse.DoMouseClick(centeric[0], centeric[1]);
            KeyboardMouse.InputText(_input);
            return true;
        }
        /*有些GUI必须要通过process name找到，但UIA只提供了用ProcessId的方式查找，要转换一次. 可是会出现同名process的情况，每个都要处理*/
        public static bool SimulateMouseClickGUIElementAgainstSpecificProcess(string _xpath, string _processName, int _timeoutInSeconds = 5)
        {
            if (!_xpath.Contains("{0}"))
            {
                return false;
            }
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (Process process in processes)
            {
                SimulateMouseClickGUIElement(string.Format(_xpath, process.Id), _timeoutInSeconds);
            }
            return true;
        }
        public static bool SimulateMouseClickGUIElementAndInputAgainstSpecificProcess(string _xpath, string _processName, string _input, int _timeoutInSeconds)
        {
            if (!_xpath.Contains("{0}"))
            {
                return false;
            }
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (Process process in processes)
            {
                SimulateMouseClickGUIElementAndInput(string.Format(_xpath, process.Id), _input, _timeoutInSeconds);
            }
            return true;
        }
        public static bool SimulateMouseClickGUIElement4Vantage(string _xpath, int _timeoutInSeconds = 5)
        {
            return SimulateMouseClickGUIElement(Path.Combine("/Window[@Name='Lenovo Vantage']", _xpath), _timeoutInSeconds);
        }
        public static bool SimulateMouseClickGUIElementAndInput4Vantage(string _xpath, string _input, int _timeoutInSeconds)
        {

            return SimulateMouseClickGUIElementAndInput(Path.Combine("/Window[@Name='Lenovo Vantage']", _xpath), _input, _timeoutInSeconds);
        }
        public static bool SimulateMouseClickGUIElementUsingAutomationId4Vantage(string _automationId, int _timeoutInSeconds = 5)
        {
            return SimulateMouseClickGUIElement(string.Format("/Window[@Name='Lenovo Vantage']//*[@AutomationId='{0}']", _automationId), _timeoutInSeconds);
        }
        public static bool SimulateMouseClickGUIElementAndInputUsingAutomationId4Vantage(string _automationId, string _input, int _timeoutInSeconds = 5)
        {

            return SimulateMouseClickGUIElementAndInput(string.Format("/Window[@Name='Lenovo Vantage']//*[@AutomationId='{0}']", _automationId), _input, _timeoutInSeconds);
        }
        #endregion
        #region higher interface to expose,使用COM UIA的功能 . Any function with DB is specific to Vantage , not a common solution

        public static int ElementIsEnabledUsingCustomXPath(string _xpath)
        {
            return ElementIsEnabledUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Enable了
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public static int ElementIsEnabledUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {

            int isenabled = -1;
            if (UIAHelper.SearchForElementsAndDoSth(_xpath, foundElement =>
            {
                isenabled = foundElement.CurrentIsEnabled;
                return isenabled == 1;

            }, _timeoutInSeconds).Count > 0)
            {
                return isenabled;
            }
            Logger.Instance.WriteLog(string.Format("NOT Found element by XPath= {0}", _xpath), LogType.Warning);
            return -1;
        }

        public static int ElementIsToggledUsingCustomXPath(string _xpath)
        {
            return ElementIsToggledUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用DB里指定的XPath搜索一个GUI element，判断他是否Checked了
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>0=Disabled, 1=Enabled , -1=NO Element found</returns>
        public static int ElementIsToggledUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {

            int isenabled = -1;
            if (UIAHelper.SearchForElementsAndDoSth(_xpath, (foundElement) =>
            {
                isenabled = Convert.ToInt32(UIAHelper.IsChecked(foundElement));
                return true;
            }, _timeoutInSeconds).Count > 0)
            {
                return isenabled;
            }
            Logger.Instance.WriteLog(string.Format("NOT Found element by XPath= {0}", _xpath), LogType.Warning);
            return -1;
        }

        #region identify GUI element existence
        //Marcus:有时我们想检查一个GUI在指定时间内不存在。
        public static bool ElementNotExistUsingCustomXPathInSecondsWithSpecificProcessName(string _fullXpath, int _sec, string _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                return false;
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                return false;
            }
            return ElementNotExistUsingCustomXPathInSeconds(string.Format(_fullXpath, processId), _sec);
        }
        public static bool ElementNotExistUsingCustomXPathInSeconds(string _xpath, int _sec)
        {
            DateTime past = DateTime.Now;
            //至少3次看不到，才有信心element是gone了。
            int belief = 3;
            while ((DateTime.Now - past).TotalSeconds < _sec)
            {
                if (ElementExistUsingCustomXPath(_xpath, 1))
                {
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    if (belief > 0)
                    {
                        Logger.Instance.WriteLog((DateTime.Now - past).TotalSeconds + " Seconds later ,Element seems vanished");
                        System.Threading.Thread.Sleep(200);
                        belief--;
                        continue;
                    }
                    Logger.Instance.WriteLog((DateTime.Now - past).TotalSeconds + " Seconds later ,Element vanished");
                    break;
                }
            }
            if ((DateTime.Now - past).TotalSeconds >= _sec)
            {
                Logger.Instance.WriteLog("Timeout to wait for a GUI element to vanish ", LogType.Failure);
                return false;
            }
            bool result = ElementExistUsingCustomXPath(_xpath);
            if (result)
            {
                Logger.Instance.WriteLog(_xpath + " still exists . ", LogType.Failure);
            }
            return !result;

        }

        /* Author: Marcus
        * Desc: Variant of ElementAnyExistUsingCustomXPath(). Giving default timeout limit of 10 seconds
        */
        public static bool ElementAnyExistUsingCustomXPath(string[] _xpathes)
        {
            return ElementAnyExistUsingCustomXPath(_xpathes, 10);
        }
        /* Author: Marcus
        * Desc:  Given a few elements which may be mutually exclusive ,Any element is shown , then the job is DONE.
        *       For example .  Tutorial and Dashboard ar emutally exclusive , Either Tutorial page is shown , or Dashboard page is shown . Anyone is shown , it is considered Vantage is ready to use.
        */
        public static bool ElementAnyExistUsingCustomXPath(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            Task<bool>[] tasks = new Task<bool>[_xpathes.Length];
            for (int ctr = 0; ctr < _xpathes.Length; ctr++)
            {
                string xpath = _xpathes[ctr];
                tasks[ctr] = Task.Run(() => ElementExistUsingCustomXPath(xpath, _timeoutInSeconds));
            }
            int index = Task.WaitAny(tasks);
            return tasks[index].Result;

        }

        public static int ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _xpathes)
        {
            return ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(_xpathes, 10);
        }
        /* Author: Marcus
        * Desc:  Given a few elements which may be mutually exclusive ,Any element is shown , then the job is DONE.
        *       For example .  Tutorial and Dashboard ar emutally exclusive , Either Tutorial page is shown , or Dashboard page is shown . Anyone is shown , it is considered Vantage is ready to use.
        *       But , we need to know who is shown ,return the index in XPath array.
        */
        public static int ElementAnyExistUsingCustomXPath_WhichOneMeetsCondition(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            Task<bool>[] tasks = new Task<bool>[_xpathes.Length];
            System.Diagnostics.Debug.WriteLine("Start searching:" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss.sss"));
            for (int ctr = 0; ctr < _xpathes.Length; ctr++)
            {
                string xpath = _xpathes[ctr];
                tasks[ctr] = Task.Run(() => ElementExistUsingCustomXPath(xpath, _timeoutInSeconds));
            }
            int index = Task.WaitAny(tasks);
            System.Diagnostics.Debug.WriteLine("Stop searching:" + DateTime.Now.ToString("yyyy-MM-dd HH:MM:ss.sss"));
            return tasks[index].Result ? index : -1;

        }
        /*Author: Marcus
         *Desc:   Variant of ElementAllExistUsingCustomXPath() , Giving default timeout limit
         */
        public static bool ElementAllExistUsingCustomXPath(string[] _xpathes)
        {
            return ElementAllExistUsingCustomXPath(_xpathes, 10);
        }
        /* Author: Marcus
       * Desc: Given a few elements which may co-exist ,So long as all elements are shown , then the job is DONE.
       *       For example .  on Dashboard page , only when Dashboar | Device | Security | Support are shown ,it is considered Vantage is ready to use.
       */
        public static bool ElementAllExistUsingCustomXPath(string[] _xpathes, int _timeoutInSeconds = 10)
        {
            Task<bool>[] tasks = new Task<bool>[_xpathes.Length];
            for (int ctr = 0; ctr <= _xpathes.Length; ctr++)
            {
                tasks[ctr] = Task.Run(() => ElementExistUsingCustomXPath(_xpathes[ctr], _timeoutInSeconds));
            }
            Task.WaitAll(tasks);
            foreach (Task<bool> item in tasks)
            {
                if (!item.Result)
                {
                    return false;
                }
            }
            return true;

        }
        public static bool ElementExistUsingCustomXPath(string _xpath)
        {
            return ElementExistUsingCustomXPath(_xpath, 10);

        }



        public static bool ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(string _fullXpath, int _timeout, String _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                return false;
            }
            String processId = "";
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                return false;
            }
            foreach (var item in processes)
            {
                processId = item.Id.ToString(); //fix bug, troy

                if (ElementExistUsingCustomXPath(string.Format(_fullXpath, processId), _timeout))
                {
                    return true;
                }
            }
            return false;

        }
        public static bool ElementExistUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {
            return ElementExistUsingCustomXPathInSecondsWithSpecificProcessName(_fullXpath, 10, _processName);

        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public static bool ElementExistUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            return UIAHelper.SearchForElementsAndDoSth(_xpath, x => { return true; }, _timeoutInSeconds).Count > 0;
        }
        #endregion
        #region click GUI element using UIA

        public static string ClickElementUsingCustomXPath(string _xpath)
        {
            return ClickElementUsingCustomXPath(_xpath, 5);
        }

        //Marcus:一些Window本身的是没有AutomationId的，而Name会根据语言变化。比如Win10本身的Settings。
        //为了定位，就要在Xpath中用到ProcessId，而ProcessId则要在C#中根据ProcessName替换。
        public static string ClickElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {

            return ClickElementUsingCustomXPathWithSpecificProcessName(_fullXpath, 10, _processName);
        }
        public static string ClickElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, int _timeoutInSeconds, String _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , incorrect placeholder", LogType.Error);
                return false.ToString();
            }
            String processId = "";
            Process[] processes = Process.GetProcessesByName(_processName);
            if (processes.Length == 0)
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , NO such process running at background ", LogType.Warning);
                return false.ToString();
            }
            foreach (var item in processes)
            {
                string result = ClickElementUsingCustomXPath(string.Format(_fullXpath, processId), _timeoutInSeconds);
                if (result.Equals(true.ToString()))
                {
                    return result;
                }

            }
            return false.ToString();

        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public static string ClickElementUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            bool result = SearchForElementsAndDoSth(_xpath, UIAActions.click, _timeoutInSeconds).Count > 0;
            return result.ToString();
        }


        public static bool ElementIsCollapseUsingCustomXPath(string _xpath, int _timeoutInSeconds)
        {
            int state = -1;
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath,
                (founElement) =>
                {
                    state = Convert.ToInt32(UIAHelper.GetCollapseState(founElement));
                    return true;
                }
            , _timeoutInSeconds).Count > 0;
            return state == 0;
        }

        #endregion
        #region Move mouse to GUI element with information from UIA

        public static string MouseFocusElementUsingCustomXPath(string _xpath)
        {
            return MouseFocusElementUsingCustomXPath(_xpath, 5);
        }

        //Marcus:一些Window本身的是没有AutomationId的，而Name会根据语言变化。比如Win10本身的Settings。
        //为了定位，就要在Xpath中用到ProcessId，而ProcessId则要在C#中根据ProcessName替换。
        public static string MouseFocusElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, String _processName)
        {

            return MouseFocusElementUsingCustomXPathWithSpecificProcessName(_fullXpath, 10, _processName);
        }
        public static string MouseFocusElementUsingCustomXPathWithSpecificProcessName(string _fullXpath, int _timeoutInSeconds, String _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , incorrect placeholder", LogType.Error);
                return false.ToString();
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                Logger.Instance.WriteLog("ClickElementUsingCustomXPathWithSpecificProcessName() , NO such process at background running", LogType.Warning);
                return false.ToString();
            }
            string result = MouseFocusElementUsingCustomXPath(string.Format(_fullXpath, processId), _timeoutInSeconds);
            return result;
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public static string MouseFocusElementUsingCustomXPath(string _xpath, int _timeoutInSeconds = 5)
        {
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath, UIAActions.mouseMove, _timeoutInSeconds).Count > 0;
            return result.ToString();
        }
        public static string SetValue4ElementUsingCustomXPath(string _xpath, string _value, int _timeoutInSeconds = 5)
        {
            bool result = UIAHelper.SearchForElementsAndDoSth(_xpath, UIAActions.setValue, _timeoutInSeconds, _value).Count > 0;
            return result.ToString();
        }
        #endregion
        #region Retrieve value
        public static string ElementGetValueUsingCustomXPathWithProcessName(string _fullXpath, string _processName)
        {
            return ElementGetValueUsingCustomXPathWithProcessName(_fullXpath, _processName, 5);
        }
        public static string ElementGetValueUsingCustomXPathWithProcessName(string _fullXpath, string _processName, int _timeoutInSeconds)
        {
            string res = "";
            if (!_fullXpath.Contains("{0}"))
            {
                return "Invalid XPath , NO {0} in XPath";
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                res = ElementGetValueUsingCustomXPath(string.Format(_fullXpath, processId), _timeoutInSeconds);
                if (res != null)
                    break;
            }
            if (processId.Equals(""))
            {
                return "NO such process found.";
            }
            return res;
        }

        public static string ElementGetValueUsingCustomXPath(string _xpath)
        {
            return ElementGetValueUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element，读取它的value并返回
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public static string ElementGetValueUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            List<IUIAutomationElement> uIAutomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, _timeoutInSeconds);
            if (uIAutomationElements.Count > 0)
            {
                return UIAHelper.getValue(uIAutomationElements[0]);
            }
            return null;
        }
        public static string ElementGetNameUsingCustomXPath(string _xpath)
        {
            return ElementGetNameUsingCustomXPath(_xpath, 5);
        }
        /// <summary>
        /// 简化版。使用自定义XPath搜索一个GUI element，读取它的value并返回
        /// </summary>
        /// <param name="_xpath">完整的自定义XPath</param>
        /// <param name="_timeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns>true=找到了 ,false=没找到</returns>
        public static string ElementGetNameUsingCustomXPath(string _xpath, int _timeoutInSeconds = 10)
        {
            List<IUIAutomationElement> uIAutomationElements = UIAHelper.SearchForElementsAndDoSth(_xpath, _timeoutInSeconds);
            if (uIAutomationElements.Count > 0)
            {
                return uIAutomationElements[0].CurrentName;
            }
            return "";
        }
        #endregion
        #region Set value

        //对于某些需要通过ProcessName去定位Window的情况，如下处理
        public static bool ElementSetValueUsingCustomXPathWithSpecificProcessName(string _value, string _fullXpath, string _processName)
        {
            if (!_fullXpath.Contains("{0}"))
            {
                return false;
            }
            String processId = "";
            foreach (var item in Process.GetProcessesByName(_processName))
            {
                processId = item.Id.ToString();
                break;
            }
            if (processId.Equals(""))
            {
                return false;
            }
            return ElementSetValueUsingCustomXPath(string.Format(_fullXpath, processId), _value, 5);
        }
        public static bool ElementSetValueUsingCustomXPath(string _Xpath, string value)
        {
            return ElementSetValueUsingCustomXPath(_Xpath, value);
        }
        public static bool ElementSetValueUsingCustomXPath(string _Xpath, string value, int _timeoutInSeconds = 5)
        {
            object[] param = { value };
            DateTime now = DateTime.Now;
            bool result = UIAHelper.SearchForElementsAndDoSth(_Xpath, UIAActions.setValue, _timeoutInSeconds, param).Count > 0;
            return result;
        }

        #endregion

        #endregion
        static List<IUIAutomationElement> ApplyXPathExpression(string _XPathExpression, Func<IUIAutomationElement, bool> _callback, int _defaultTimeoutInSeconds = 10)
        {

            Object evaResult = null;
            XPathNodeIterator iterator = null;
            DateTime past = DateTime.Now;
            XPathNavigatorUIA nav = new XPathNavigatorUIA(null);
            while ((DateTime.Now - past).TotalSeconds < _defaultTimeoutInSeconds)
            {
                System.Threading.Thread.Sleep(100);
                try
                {
                    evaResult = nav.Evaluate(_XPathExpression);
                    iterator = evaResult as XPathNodeIterator;
                    if (iterator != null && iterator.Count > 0)
                    {
                        List<IUIAutomationElement> result = WalkThroughIterator(iterator, _callback);
                        if (result.Count > 0)
                        {
                            return result;
                        }
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    //ref: https://social.msdn.microsoft.com/Forums/en-US/36cbac92-cdb1-4c60-b4fd-54fc6b72c75e/an-event-was-unable-to-invoke-any-of-the-subscribers-ui-automation
                    // 0x80040201 here means  UIA_E_ELEMENTNOTAVAILABLE
                    // System.Runtime.InteropServices.COMException: Operation timed out. (Exception from HRESULT: 0x80131505)
                    // Weird issue :HRESULT: 0x80040200, DllRegister server failure.
                    if (ex.Message.Contains("HRESULT: 0x80040201") || ex.Message.Contains("HRESULT: 0x80131505") || ex.Message.Contains("HRESULT: 0x80040200"))
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    if (ex.Message.Contains("HRESULT E_FAIL"))
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    throw ex;
                }
                catch (InvalidOperationException ex)
                {
                    //System.InvalidOperationException: Operation is not valid due to the current state of the object.
                    //https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception?view=netcore-3.1

                }

            }
            return new List<IUIAutomationElement>();

        }

        static List<IUIAutomationElement> WalkThroughIterator(XPathNodeIterator _iterator, Func<IUIAutomationElement, bool> _callback)
        {
            List<IUIAutomationElement> caughtItems = new List<IUIAutomationElement>();
            if (_iterator != null && _iterator.Count > 0)
            {
                foreach (XPathNavigator item in _iterator)
                {

                    IUIAutomationElement caughtUIAIem = (IUIAutomationElement)item.UnderlyingObject;
                    //print Name的原因是有时候即使element找到了，但是返回后被调用会出现0x80040201 COM exception。为了避免这个问题，在找到后立即尝试读取Name，要是出错正好continue。
                    string currentName = caughtUIAIem.CurrentName;
                    System.Diagnostics.Debug.WriteLine("Find IUIAutomationElement , name=" + (currentName != null ? currentName : "NO name"));
                    caughtItems.Add(caughtUIAIem);

                }
            }
            if (caughtItems.Count > 0)
            {
                for (int i = 0; i < caughtItems.Count; i++)
                {
                    try
                    {
                        _callback?.Invoke(caughtItems[i]);
                    }
                    catch (Exception ex)
                    {
                        return caughtItems;
                    }
                }
                return caughtItems;
            }
            return caughtItems;
        }
        static List<IUIAutomationElement> ApplyXPathExpression(string XPathExpression, Func<IUIAutomationElement, object[], bool> _callback, int _defaultTimeoutInSeconds = 10, params object[] _additionalParams)
        {

            Object evaResult = null;
            XPathNodeIterator iterator = null;
            DateTime past = DateTime.Now;
            XPathNavigatorUIA nav = new XPathNavigatorUIA(null);
            while ((DateTime.Now - past).Seconds < _defaultTimeoutInSeconds)
            {
                System.Threading.Thread.Sleep(100);
                try
                {
                    evaResult = nav.Evaluate(XPathExpression);
                    iterator = evaResult as XPathNodeIterator;
                    if (iterator != null && iterator.Count > 0)
                    {
                        List<IUIAutomationElement> result = WalkThroughIterator(iterator, _callback, _additionalParams);
                        if (result.Count > 0)
                        {
                            return result;
                        }
                    }
                }
                catch (System.Runtime.InteropServices.COMException ex)
                {
                    //Marcus:03/30,在一台机器上看到operation timeout，但却不明白为什么，根据https://github.com/FlaUI/FlaUI/issues/90 类似问题，怀疑是GUI没响应
                    // System.Runtime.InteropServices.COMException: Operation timed out. (Exception from HRESULT: 0x80131505)
                    if (ex.Message.Contains("HRESULT: 0x80040201") || ex.Message.Contains("HRESULT: 0x80131505") || ex.Message.Contains("HRESULT: 0x80040200"))
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    else if (ex.Message.Contains("HRESULT E_FAIL"))
                    {
                        System.Threading.Thread.Sleep(100);
                        continue;
                    }
                    else if (!ex.Message.Contains("0x80040201"))
                    {
                        throw ex;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    //System.InvalidOperationException: Operation is not valid due to the current state of the object.
                    //https://docs.microsoft.com/en-us/dotnet/api/system.invalidoperationexception?view=netcore-3.1

                }

            }
            return new List<IUIAutomationElement>();

        }
        static List<IUIAutomationElement> WalkThroughIterator(XPathNodeIterator iterator, Func<IUIAutomationElement, object[], bool> _callback, params object[] _additionalParams)
        {
            List<IUIAutomationElement> caughtItems = new List<IUIAutomationElement>();
            if (iterator != null && iterator.Count > 0)
            {
                foreach (XPathNavigator item in iterator)
                {
                    try
                    {
                        IUIAutomationElement caughtUIAIem = (IUIAutomationElement)item.UnderlyingObject;
                        //print Name的原因是有时候即使element找到了，但是返回后被调用会出现0x80040201 COM exception。为了避免这个问题，在找到后立即尝试读取Name，要是出错正好continue。
                        string currentName = caughtUIAIem.CurrentName;
                        System.Diagnostics.Debug.WriteLine("Find IUIAutomationElement , name=" + (currentName != null ? currentName : "NO name"));
                        caughtItems.Add(caughtUIAIem);

                    }
                    catch (System.Runtime.InteropServices.COMException ex)
                    {
                        //ref: https://social.msdn.microsoft.com/Forums/en-US/36cbac92-cdb1-4c60-b4fd-54fc6b72c75e/an-event-was-unable-to-invoke-any-of-the-subscribers-ui-automation
                        // 0x80040201 here means  UIA_E_ELEMENTNOTAVAILABLE
                        if (ex.Message.Contains("An event was unable to invoke any of the subscribers (Exception from HRESULT: 0x80040201)"))
                        {
                            System.Threading.Thread.Sleep(100);
                            continue;
                        }
                        throw ex;
                    }

                }
                if (_callback != null && caughtItems.Count > 0)
                {
                    for (int i = 0; i < caughtItems.Count; i++)
                    {
                        try
                        {
                            _callback(caughtItems[0], _additionalParams);
                        }
                        catch (Exception ex)
                        {
                            return caughtItems;
                        }
                    }

                    //對於GUI element的操作只有一次
                    return caughtItems;
                }
            }
            return caughtItems;
        }
        /// <summary>
        /// 当我们搜索到某个GUI对象时就想立即处理时，用这个版本。返回值可以判断是否找到了至少一个符合条件的GUI对象。
        /// 传入的XPath一定要是UIAItem.cs=>UIAControlType中的控件, 属性必须在AttributeInfo.cs中。
        /// </summary>
        /// <param name="_cannoicalXpath">使用XPath搜索UIA对象</param>
        /// <param name="_doSthWhenFind">一个callback function。找到了符合条件的GUI对象，我们可以选择做点什么，比如click。返回true表示不对下一个符合条件的对象执行操作了。</param>
        /// <param name="_defaultTimeoutInSeconds">默认在5秒不断搜索符合条件的GUI对象,找到就再搜索，</param>
        /// <returns>如果在_doSthWhenFind()里返回了true，最终会返回之前搜索符合条件的GUI对象。
        /// 如果_doSthWhenFind()返回false，最终会返回所有符合条件的GUI对象。 
        /// </returns>
        /// <example>
        /// case 1 :List<IUIAutomationElement> all= SearchForElementsAndDoSth("/Window[@Name='Lenovo Vantage']//HyperLink[@AutomationId='dashboard-ss-systemupdate']", UIAActions.click,6)
        /// case 2 :List<IUIAutomationElement> all= SearchForElementsAndDoSth("/Window[@Name='Lenovo Vantage']//HyperLink[@AutomationId='dashboard-ss-systemupdate']", x=>{
        /// var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_InvokePatternId);
        ///    if (pattern==null)
        ///    {
        ///         throw new Exception("NOT clickable.");
        /// }
        /// ((IUIAutomationInvokePattern) pattern).Invoke();
        ///System.Threading.Thread.Sleep(2500);
        /// },6)
        /// </example>
        public static List<IUIAutomationElement> SearchForElementsAndDoSth(string _cannoicalXpath, Func<IUIAutomationElement, object[], bool> _doSthWhenFind, int _defaultTimeoutInSeconds = 5, params object[] _additionalParams)
        {

            return ApplyXPathExpression(_cannoicalXpath, _doSthWhenFind, _defaultTimeoutInSeconds, _additionalParams);
        }
        public static List<IUIAutomationElement> SearchForElementsAndDoSth(string _cannoicalXpath, Func<IUIAutomationElement, bool> _doSthWhenFind, int _defaultTimeoutInSeconds = 10)
        {

            return ApplyXPathExpression(_cannoicalXpath, _doSthWhenFind, _defaultTimeoutInSeconds);
        }
        /// <summary>
        /// 这个是一个简化版本，找到GUI对象时不做任何处理。适用于当我们需要把找到的对象返回给其他function。
        /// </summary>
        /// <param name="_cannoicalXpath"></param>
        /// <param name="_defaultTimeoutInSeconds">默认搜索超时时间5秒</param>
        /// <returns></returns>
        public static List<IUIAutomationElement> SearchForElementsAndDoSth(string _cannoicalXpath, int _defaultTimeoutInSeconds = 10)
        {

            return ApplyXPathExpression(_cannoicalXpath, x => { return true; }, _defaultTimeoutInSeconds);
        }
        public static int IsChecked(IUIAutomationElement uIAutomationElement)
        {
            var pattern = uIAutomationElement.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_TogglePatternId);
            if (pattern == null)
            {
                throw new Exception("Taggle Pattern unavailable");
            }
            int currentState = (int)((IUIAutomationTogglePattern)pattern).CurrentToggleState;
            return currentState;
        }
        public static string getValue(IUIAutomationElement uIAutomationElement)
        {
            var pattern = uIAutomationElement.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ValuePatternId);
            if (pattern == null)
            {

                return uIAutomationElement.CurrentName;
            }
            return ((IUIAutomationValuePattern)pattern).CurrentValue;
        }

        public static interop.UIAutomationCore.ExpandCollapseState GetCollapseState(IUIAutomationElement uIAutomationElement)
        {
            var pattern = uIAutomationElement.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ExpandCollapsePatternId);
            if (pattern == null)
            {
                throw new Exception("Taggle Pattern unavailable");
            }
            return ((IUIAutomationExpandCollapsePattern)pattern).CurrentExpandCollapseState;
        }


    }
}
