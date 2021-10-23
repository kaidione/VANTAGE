using LenovoVantageTest.LogHelper;
using LenovoVantageTest.Utility;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Automation;

namespace TangramTest.Utility
{
    /*
    * this partial class is to define fuzzy matching methods
    */
    public partial class UIAutomationControl
    {
        public AutomationElement FindElement(string appName, string automationId = null, string name = null, int timeout = 6)
        {
            AutomationElement targetElement = null;
            try
            {

                if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    return targetElement;
                }
                timeout *= 10;
                do
                {
                    AutomationElement targetProcess;
                    if (string.IsNullOrEmpty(appName))
                        targetProcess = AutomationElement.RootElement;
                    else
                        targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, appName));
                    if (targetProcess != null)
                    {
                        if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, name), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name), new PropertyCondition(AutomationElement.IsEnabledProperty, true)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(500);
                    timeout--;
                }
                while (timeout > 0);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FindElement() exception: " + ex.Message, LogType.Error);
            }

            return targetElement;
        }

        // <summary>
        // 获取某个APP/进程下的所有子孙元素.若automationId和name均为null或String.empty,则返回所有子孙元素
        // </summary>
        // <param name="appName"></param>
        // <param name="automationId"></param>
        // <param name="name"></param>
        // <param name="timeout"></param>
        // <returns></returns>
        public AutomationElementCollection FindAllElementsInApp(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            AutomationElementCollection targetElement = null;
            try
            {
                AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, appName));
                if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    return targetProcess.FindAll(TreeScope.Subtree, Condition.TrueCondition);
                }
                timeout *= 10;
                do
                {
                    if (targetProcess != null)
                    {
                        if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, name));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindAll(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    timeout--;
                }
                while (timeout > 0);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FindAllElements() exception: " + ex.Message, LogType.Error);
            }

            return targetElement;
        }

        public List<AutomationElement> FindAllElementsInRootElementPlus(AutomationElement rootElement, string automationId = null, string name = null, int timeout = 30)
        {
            List<AutomationElement> elements = new List<AutomationElement>();

            bool autoIdEnabled = InitialNullField(ref automationId);
            bool nameEnabled = InitialNullField(ref name);

            if (!autoIdEnabled && !nameEnabled)
            {
                //若为空，返回所有子孙元素
                return CovertToAutomationElementList(rootElement.FindAll(TreeScope.Subtree, Condition.TrueCondition));
            }

            DateTime now = DateTime.Now;
            do
            {
                foreach (AutomationElement element in rootElement.FindAll(TreeScope.Subtree, Condition.TrueCondition))
                {
                    if (autoIdEnabled && element.Current.AutomationId.ToLower().Contains(automationId.ToLower()) ||
                        nameEnabled && element.Current.Name.ToLower().Contains(name.ToLower()))
                    {
                        elements.Add(element);
                    }
                }

                if (elements.Count > 0)
                    break;

                Thread.Sleep(100);
            }
            while (DateTime.Now < now.AddSeconds(timeout));
            return elements;
        }

        private List<AutomationElement> CovertToAutomationElementList(AutomationElementCollection collection)
        {
            List<AutomationElement> target = new List<AutomationElement>();
            foreach (AutomationElement element in collection)
            {
                target.Add(element);
            }

            return target;
        }

        private bool InitialNullField(ref string field)
        {
            if (string.IsNullOrEmpty(field))
            {
                field = string.Empty;
                return false;
            }
            else
            {
                return true;
            }
        }


        // <summary>
        // 获取某个元素下的符合条件的所有子孙元素。若automationId和name均为null或String.empty,则返回所有子孙元素
        // </summary>
        // <param name="rootElement"></param>
        // <param name="automationId"></param>
        // <param name="name"></param>
        // <param name="timeout"></param>
        // <returns></returns>
        public AutomationElementCollection FindAllElementsInRootElement(AutomationElement rootElement, string automationId = null, string name = null, int timeout = 30)
        {
            AutomationElementCollection targetElement = null;
            try
            {
                if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    return rootElement.FindAll(TreeScope.Subtree, Condition.TrueCondition);
                }
                timeout *= 10;
                do
                {
                    if (rootElement != null)
                    {
                        if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                        {
                            targetElement = rootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = rootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, name));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = rootElement.FindAll(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    timeout--;
                }
                while (timeout > 0);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FindAllElementsInElement() exception: " + ex.Message, LogType.Error);
            }

            return targetElement;
        }

        // <summary>
        // 根据多个限定条件筛选元素，当有多个不为空(NULL或String.Empty)条件时，各条件之间是"与"关系
        // </summary>
        // <param name="parentAppName"></param>
        // <param name="automationId"></param>
        // <param name="name"></param>
        // <param name="timeout"></param>
        // <param name="className"></param>
        // <param name="controlType"></param>
        // <returns></returns>
        public AutomationElement FindElementEx(string parentAppName, string automationId = null, string name = null, int timeout = 5, string className = null, string controlType = null)
        {
            AutomationElement targetElement = null;
            if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
            {
                return targetElement;
            }

            try
            {
                timeout *= 10;
                do
                {
                    AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, parentAppName));
                    if (targetProcess != null)
                    {
                        if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }

                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(className))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.NameProperty, name), new PropertyCondition(AutomationElement.ClassNameProperty, className)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }

                        if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, name));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                        if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(className) && !string.IsNullOrEmpty(controlType))
                        {
                            targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, className), new PropertyCondition(AutomationElement.ControlTypeProperty, controlType)));
                            if (targetElement != null)
                            {
                                break;
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    timeout--;
                }
                while (timeout > 0);
            }
            catch (Exception ex)
            {
                Logger.Instance.WriteLog("FindElementEx() exception: " + ex.Message, LogType.Error);
            }

            return targetElement;
        }

        public AutomationElement FindElementInRootElementPlus(AutomationElement rootElement, string automationId = null, string name = null, int timeout = 30)
        {
            bool autoIdEnabled = InitialNullField(ref automationId);
            bool nameEnabled = InitialNullField(ref name);
            if (!autoIdEnabled && !nameEnabled)
            {
                return rootElement.FindFirst(TreeScope.Subtree, Condition.TrueCondition);
            }
            DateTime now = DateTime.Now;
            do
            {
                AutomationElementCollection elements = rootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, "ListViewItem"));
                for (int i = 0; i < elements.Count; i++)
                {
                    AutomationElement targetElement = elements[i];
                    if (targetElement.Current.Name.Contains(name))
                    {
                        return targetElement;
                    }
                }
                Thread.Sleep(100);
            }
            while (DateTime.Now < now.AddSeconds(timeout));
            return null;

        }

        // <summary>
        // 统计某祖先元素中包含某种类型的子孙集合
        // </summary>
        // <param name="rootElement">祖先元素</param>
        // <param name="type">子孙类型</param>
        // <returns>子孙集合/null</returns>
        public AutomationElementCollection FindElementsInAElementByControlType(AutomationElement rootElement, ControlType type)
        {
            if (rootElement != null)
            {
                return rootElement.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ControlTypeProperty, type));
            }
            return null;
        }

        public AutomationElementCollection FindElementsByClass(string appName, string className, int timeout = 30)
        {
            AutomationElementCollection targetElements = null;
            if (string.IsNullOrEmpty(className))
            {
                return targetElements;
            }
            timeout *= 10;
            do
            {
                AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, appName));
                if (targetProcess != null)
                {
                    if (!string.IsNullOrEmpty(className))
                    {
                        targetElements = targetProcess.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, className));
                        if (targetElements.Count > 0)
                        {
                            return targetElements;
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElements;
        }

        public AutomationElement FindElementByClass(string appName, string automationId, string name, string className, int timeout = 30)
        {
            AutomationElement targetElement = null;
            if (string.IsNullOrEmpty(className))
            {
                return targetElement;
            }
            timeout *= 10;
            do
            {
                AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, appName));
                if (targetProcess != null)
                {
                    if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                    {
                        targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, className), new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                    }
                    if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                    {
                        targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, className), new PropertyCondition(AutomationElement.AutomationIdProperty, automationId)));
                    }
                    if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                    {
                        targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, className), new PropertyCondition(AutomationElement.NameProperty, name)));
                    }
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        internal InvokePattern FindAppBarButton(string appName, string automationId, string name, int timeout)
        {
            InvokePattern targetButton = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetButton = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetButton;
        }

        public AutomationElementCollection FindChildElementsInAutomationElementByClass(AutomationElement parentElement, string className, int timeout = 30)
        {
            AutomationElementCollection targetElement = null;
            timeout *= 10;
            do
            {
                if (!string.IsNullOrEmpty(className))
                {
                    targetElement = parentElement.FindAll(TreeScope.Children, new PropertyCondition(AutomationElement.ClassNameProperty, className));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        public AutomationElementCollection FindChildElementsInAutomationElement(AutomationElement parentElement, int timeout = 30)
        {
            AutomationElementCollection targetElement = null;
            timeout *= 10;
            do
            {
                if (parentElement != null)
                {
                    targetElement = parentElement.FindAll(TreeScope.Children, Condition.TrueCondition);
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        // <summary>
        // 获取根元素下的第一个符合条件的元素
        // </summary>
        // <param name="parentElement"></param>
        // <param name="automationId"></param>
        // <param name="name"></param>
        // <param name="timeout"></param>
        // <returns></returns>
        public AutomationElement FindElementInRootElement(AutomationElement rootElement, string automationId = null, string name = null, int timeout = 30)
        {
            AutomationElement targetElement = null;
            if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
            {
                return targetElement;
            }
            timeout *= 10;
            do
            {
                if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    targetElement = rootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                {
                    targetElement = rootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, name));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                {
                    targetElement = rootElement.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        // <summary>
        // 获取某元素下的符合条件的第一个子元素
        // </summary>
        // <param name="parentElement"></param>
        // <param name="automationId"></param>
        // <param name="name"></param>
        // <param name="timeout"></param>
        // <returns></returns>
        public AutomationElement FindChildElementInParentElement(AutomationElement parentElement, string automationId = null, string name = null, int timeout = 30)
        {
            AutomationElement targetElement = null;
            if (string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
            {
                return parentElement.FindFirst(TreeScope.Children, Condition.TrueCondition); ;
            }
            timeout *= 10;
            do
            {
                if (!string.IsNullOrEmpty(automationId) && string.IsNullOrEmpty(name))
                {
                    targetElement = parentElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, automationId));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                if (string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                {
                    targetElement = parentElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, name));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(automationId) && !string.IsNullOrEmpty(name))
                {
                    targetElement = parentElement.FindFirst(TreeScope.Children, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, automationId), new PropertyCondition(AutomationElement.NameProperty, name)));
                    if (targetElement != null)
                    {
                        break;
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        // <summary>
        // 获取包含指定URL的元素
        // </summary>
        // <param name="appName">浏览器名，如”Microsoft Edge“</param>
        // <param name="addressBoxAutomationId">浏览器的地址输入栏</param>
        // <param name="value">待验证的URL</param>
        // <param name="timeout">超时/秒</param>
        // <returns>包含URL的对象/null</returns>
        public AutomationElement FindUrl(string appName, string addressBoxAutomationId = null, string value = null, int timeout = 30)
        {
            AutomationElement targetElement = null;
            ValuePattern targetUrl = null;
            if (string.IsNullOrEmpty(addressBoxAutomationId) && string.IsNullOrEmpty(value))
            {
                return targetElement;
            }
            timeout *= 10;
            do
            {
                AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, appName));
                if (targetProcess != null)
                {
                    if (!string.IsNullOrEmpty(addressBoxAutomationId))
                    {
                        targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, addressBoxAutomationId), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
                        if (targetElement != null)
                        {
                            targetUrl = targetElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                            if (targetUrl.Current.Value.Contains(value))
                            {
                                return targetElement;
                            }
                        }
                    }
                }
                Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return null;
        }

        // <summary>
        // 获取浏览器地址栏URL
        // </summary>
        // <param name="appName">浏览器名，如”Microsoft Edge“</param>
        // <param name="addressBoxAutomationId">浏览器的地址输入栏</param>
        // <param name="timeout">超时/秒</param>
        // <returns>url</returns>
        public string FindUrlString(string appName, string addressBoxAutomationId = null, int timeout = 30)
        {
            AutomationElement targetElement = null;
            ValuePattern targetUrl = null;
            if (string.IsNullOrEmpty(addressBoxAutomationId))
            {
                return String.Empty;
            }
            timeout *= 10;
            do
            {
                AutomationElement targetProcess = AutomationElement.RootElement.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, appName));
                if (targetProcess != null)
                {
                    targetElement = targetProcess.FindFirst(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.AutomationIdProperty, addressBoxAutomationId), new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Edit)));
                    if (targetElement != null)
                    {
                        targetUrl = targetElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                        return targetUrl.Current.Value;
                    }
                }
                Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return String.Empty;
        }

        public InvokePattern FindButton(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            InvokePattern targetButton = null;
            AutomationElement targetElement = FindElementByClass(appName, automationId, name, "Button", timeout);
            if (targetElement == null)
            {
                targetElement = FindElement(appName, automationId, name, timeout);
            }
            if (targetElement != null)
            {
                targetButton = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetButton;
        }

        public ValuePattern FindTextbox(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            ValuePattern targetTextbox = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetTextbox = targetElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
            }
            return targetTextbox;
        }

        public InvokePattern FindHyperlink(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            InvokePattern targetHyperlink = null;
            //AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            AutomationElement targetElement = FindElementByClass(appName, automationId, name, "Hyperlink", timeout);
            if (targetElement != null)
            {
                targetHyperlink = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetHyperlink;
        }

        public InvokePattern FindLink(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            InvokePattern targetHyperlink = null;
            //AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetHyperlink = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetHyperlink;
        }

        public InvokePattern FindHyperlinkByChildElement(string appName, string childName, int timeout = 20)
        {
            var links = FindElementsByClass(appName, "Hyperlink", timeout);
            foreach (AutomationElement lk in links)
            {
                if (string.IsNullOrEmpty(lk.Current.Name))
                {
                    AutomationElement text = FindChildElementInParentElement(lk, null, childName);
                    if (text != null)
                    {
                        return lk.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                    }
                }

            }
            return null;
        }

        public TogglePattern FindCheckbox(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            TogglePattern targetChkbox = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetChkbox = targetElement.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            }
            return targetChkbox;
        }

        public TogglePattern FindToggleSwitch(string appName, string automationId = null, string name = null, int timeout = 30, string className = null)
        {
            TogglePattern targetToggle = null;
            AutomationElement targetElement = FindElementEx(appName, automationId, name, timeout, className);
            if (targetElement != null)
            {
                targetToggle = targetElement.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
            }
            return targetToggle;
        }

        public SelectionPattern FindComboBox(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            SelectionPattern combobox = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                combobox = targetElement.GetCurrentPattern(SelectionPattern.Pattern) as SelectionPattern;
            }
            return combobox;
        }

        public SelectionItemPattern FindListViewItem(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            SelectionItemPattern listViewItem = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                listViewItem = targetElement.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
            }
            return listViewItem;
        }

        public InvokePattern FindListItem(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            InvokePattern targetListItem = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetListItem = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetListItem;
        }

        public InvokePattern FindTextControl(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            InvokePattern targetTextControl = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                targetTextControl = targetElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
            }
            return targetTextControl;
        }

        // If the selection field is an edit control, the user can enter information that is not in the list; otherwise, the user can only select items in the list.
        public void SelectComboboxItem(AutomationElement comboxbox, string item, int timeout = 5)
        {
            ExpandCollapsePattern exPat = comboxbox.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
            exPat.Expand();
            System.Threading.Thread.Sleep(1000);    // wait to expand
            KeyboardMouse.InputText(item);
            timeout *= 10;
            do
            {
                AutomationElement itemToSelect = comboxbox.FindFirst(TreeScope.Descendants, new AndCondition(
                    new PropertyCondition(AutomationElement.NameProperty, item),
                    new PropertyCondition(AutomationElement.ClassNameProperty, "ComboBoxItem")));
                if (itemToSelect != null)
                {
                    SelectionItemPattern sPat = itemToSelect.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                    sPat.Select();
                    return;
                }
                timeout--;
                System.Threading.Thread.Sleep(100);
            } while (timeout > 0);
            Logger.Instance.WriteLog($"Cannot find combobox item:{item} in {timeout}s", LogType.Error);
        }


        public AutomationElement FindElementByPreviousText(string appName, string previousAutomationId, string previousTextName, int timeout = 30)
        {
            AutomationElement siblingText = null;
            AutomationElement targetElement = null;

            //Find [appName] Window under desktop, e.g. find [Lenovo Vantage] window first
            AutomationElement targetWindow = AutomationElement.RootElement.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, appName));
            if (targetWindow != null)
            {
                timeout *= 10;

                do
                {
                    //Find the sibling textblock which has a specified name, e.g find [Max RAM] text
                    siblingText = FindElement(appName, previousAutomationId, previousTextName, timeout);
                    if (siblingText != null)
                    {
                        targetElement = TreeWalker.ControlViewWalker.GetNextSibling(siblingText);
                        if (targetElement != null)
                        {
                            break;
                        }
                    }
                    System.Threading.Thread.Sleep(100);
                    timeout--;
                }
                while (timeout > 0);
            }


            return targetElement;
        }


        public ScrollItemPattern FindScrollItem(string appName, string automationId = null, string name = null, int timeout = 30)
        {
            ScrollItemPattern scrollItem = null;
            AutomationElement targetElement = FindElement(appName, automationId, name, timeout);
            if (targetElement != null)
            {
                scrollItem = targetElement.GetCurrentPattern(ScrollItemPattern.Pattern) as ScrollItemPattern;

            }

            return scrollItem;
        }

        public ScrollPattern FindScroll(string appName, string automationId = null, string name = null, int timeout = 30, string className = null)
        {
            ScrollPattern scroll = null;
            AutomationElement targetElement = FindElementsByClass(appName, className, timeout)[0];
            if (targetElement != null)
            {
                scroll = targetElement.GetCurrentPattern(ScrollPattern.Pattern) as ScrollPattern;

            }

            return scroll;
        }

        public string getString(AutomationElement autoElement)
        {
            string text = "Unknow Text";
            try
            {
                TextPattern textBlock = null;
                textBlock = autoElement.GetCurrentPattern(TextPattern.Pattern) as TextPattern;
                text = textBlock.DocumentRange.GetText(1000);
            }
            catch
            {
                //Logger.Instance.WriteLog(@"getString("+autoElement+") exception: "+e.Message, ConsoleColor.DarkYellow);
            }

            return text;

        }


        public AutomationElement getNextSiblingElement(AutomationElement startElement, int nextSteps)
        {
            AutomationElement targetElement = null;
            AutomationElement next = null;
            try
            {
                next = TreeWalker.ControlViewWalker.GetNextSibling(startElement);

                if (next != null)
                {
                    if (nextSteps == 1)
                    {
                        targetElement = next;
                    }

                    if (nextSteps > 1)
                    {
                        for (int i = 1; i < nextSteps; i++)
                        {
                            if (next != null)
                            {
                                next = TreeWalker.ControlViewWalker.GetNextSibling(next);
                            }
                        }

                        targetElement = next;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }


            return targetElement;
        }

        public AutomationElement getPreviousSiblingElement(AutomationElement startElement, int previousSteps)
        {
            AutomationElement targetElement = null;
            AutomationElement previous = null;
            try
            {
                previous = TreeWalker.ControlViewWalker.GetPreviousSibling(startElement);

                if (previous != null)
                {
                    if (previousSteps == 1)
                    {
                        targetElement = previous;
                    }

                    if (previousSteps > 1)
                    {
                        for (int i = 1; i < previousSteps; i++)
                        {
                            if (previous != null)
                            {
                                previous = TreeWalker.ControlViewWalker.GetPreviousSibling(previous);
                            }
                        }

                        targetElement = previous;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Instance.WriteLog(e.Message, LogType.Error);
            }


            return targetElement;
        }

        public void clickObjectByXY(AutomationElement element)
        {
            object _Objectpos = element.GetCurrentPropertyValue(AutomationProperty.LookupById(30001));
            string _str = _Objectpos.ToString();
            String[] _objpos = _str.Split(new char[] { ',' });
            int _x = int.Parse(_objpos[0]) + int.Parse(_objpos[2]) / 2;
            int _y = int.Parse(_objpos[1]) + int.Parse(_objpos[3]) / 2;
            KeyboardMouse.DoMouseClick(_x, _y);
            Thread.Sleep(1000);
            Logger.Instance.WriteLog("Click object[" + _x + ", " + _y + "]", LogType.Error);
        }

        public void moveToObjectByXY(AutomationElement element)
        {
            object _Objectpos = element.GetCurrentPropertyValue(AutomationProperty.LookupById(30001));
            string _str = _Objectpos.ToString();
            String[] _objpos = _str.Split(new char[] { ',' });
            int _x = int.Parse(_objpos[0]) + int.Parse(_objpos[2]) / 2;
            int _y = int.Parse(_objpos[1]) + int.Parse(_objpos[3]) / 2;
            KeyboardMouse.DoMouseMove(_x, _y);
            Thread.Sleep(1000);
            Logger.Instance.WriteLog("Move to object[" + _x + ", " + _y + "]", LogType.Error);
        }

        public AutomationElement FindParentByChildElement(AutomationElement childElement)
        {
            AutomationElement targetElement = null;

            targetElement = TreeWalker.ControlViewWalker.GetParent(childElement);

            return targetElement;
        }

        public AutomationElement FindElementByName(AutomationElement element, string Name, int timeout = 300)
        {
            AutomationElement targetElements = null;
            if (string.IsNullOrEmpty(Name))
            {
                return targetElements;
            }
            do
            {
                if (element != null)
                {
                    targetElements = element.FindFirst(TreeScope.Subtree, new PropertyCondition(AutomationElement.NameProperty, Name));
                    if (targetElements != null)
                    {
                        return targetElements;
                    }

                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElements;
        }

        public AutomationElementCollection FindElementsByClass(AutomationElement element, string className, int timeout = 300)
        {
            AutomationElementCollection targetElements = null;
            if (string.IsNullOrEmpty(className))
            {
                return targetElements;
            }
            do
            {
                if (element != null)
                {
                    if (!string.IsNullOrEmpty(className))
                    {
                        targetElements = element.FindAll(TreeScope.Subtree, new PropertyCondition(AutomationElement.ClassNameProperty, className));
                        if (targetElements.Count > 0)
                        {
                            return targetElements;
                        }
                    }
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElements;
        }

        public AutomationElementCollection FindElementsByClasssNameAndAutomationIDCollection(AutomationElement element, string _autoID, string _classname, int timeout = 300)
        {
            AutomationElementCollection targetElement = null;
            if (string.IsNullOrEmpty(_autoID) | string.IsNullOrEmpty(_classname))
            {
                return targetElement;
            }
            do
            {
                targetElement = element.FindAll(TreeScope.Subtree, new AndCondition(new PropertyCondition(AutomationElement.ClassNameProperty, _classname), new PropertyCondition(AutomationElement.AutomationIdProperty, _autoID)));
                if (targetElement != null)
                {
                    return targetElement;
                }
                System.Threading.Thread.Sleep(100);
                timeout--;
            }
            while (timeout > 0);
            return targetElement;
        }

        public string SelectComBoxByAutomationElement(AutomationElement element)
        {
            try
            {
                SelectionItemPattern selectionItem = element.GetCurrentPattern(SelectionItemPattern.Pattern) as SelectionItemPattern;
                selectionItem.Select();
                return "sucess";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string ReadSetTextByAutomationElement(AutomationElement automationElement, string SetText, bool isReadText = false)
        {
            try
            {
                ValuePattern vpTextEdit = null;
                vpTextEdit = automationElement.GetCurrentPattern(ValuePattern.Pattern) as ValuePattern;
                if (isReadText)
                {
                    if (vpTextEdit.Current.Value != null)
                    {
                        return vpTextEdit.Current.Value;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    vpTextEdit.SetValue(SetText);
                    return "sucess";
                }
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public string InvokeByAutomationElement(AutomationElement automationElement)
        {
            try
            {
                var invokePattern = automationElement.GetCurrentPattern(InvokePattern.Pattern) as InvokePattern;
                invokePattern.Invoke();
                return "sucess";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }

        public bool ExpandOrCollapseByAutomationElement(AutomationElement element, bool IsExpand = true, int times = 20)
        {
            try
            {
                do
                {
                    ExpandCollapsePattern expand = element.GetCurrentPattern(ExpandCollapsePattern.Pattern) as ExpandCollapsePattern;
                    if (IsExpand == true)
                    {
                        expand.Expand();
                        Thread.Sleep(100);
                        if (element.GetCurrentPropertyValue(AutomationElement.IsExpandCollapsePatternAvailableProperty).ToString().ToLower().Trim() == "true")
                        {
                            return true;
                        }
                    }
                    else
                    {
                        expand.Collapse();
                        Thread.Sleep(100);
                        if (element.GetCurrentPropertyValue(AutomationElement.IsExpandCollapsePatternAvailableProperty).ToString().ToLower().Trim() == "false")
                        {
                            return true;
                        }
                    }
                    times--;
                } while (times > 0);
                return false;
            }
            catch
            {
                return false;
            }
        }
        public string ToggleSwitchByAutomationElement(AutomationElement element)
        {
            try
            {
                TogglePattern toggle = element.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                toggle.Toggle();
                return "sucess";
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public bool SetOrCheckToggleStatusByAutomationElement(AutomationElement element, bool isSet = true, ToggleState state = ToggleState.Indeterminate, int times = 20)
        {
            try
            {
                TogglePattern toggle = element.GetCurrentPattern(TogglePattern.Pattern) as TogglePattern;
                do
                {
                    if (isSet == true)
                    {
                        switch (state)
                        {
                            case ToggleState.On:
                                if (toggle.Current.ToggleState != ToggleState.On)  //set toggle is on
                                {
                                    toggle.Toggle();
                                }
                                break;
                            case ToggleState.Off:
                                if (toggle.Current.ToggleState != ToggleState.Off) // set toggle is off
                                {
                                    toggle.Toggle();
                                }
                                break;
                        }
                        if (toggle.Current.ToggleState == state) //set sucess
                        {
                            return true;
                        }
                    }
                    else
                    {
                        switch (state)
                        {
                            case ToggleState.On:
                                if (toggle.Current.ToggleState == ToggleState.On)   // get toggle is on
                                {
                                    return true;
                                }
                                break;
                            case ToggleState.Off:
                                if (toggle.Current.ToggleState == ToggleState.Off) // get toggle is off
                                {
                                    return true;
                                }
                                break;
                        }
                        return false;
                    }
                    Thread.Sleep(100);
                    times--;
                } while (times > 0);
                return false;
            }
            catch
            {
                return false;
            }
        }

    }
}
