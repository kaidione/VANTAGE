using interop.UIAutomationCore;
using LenovoVantageTest.Utility.UIAImplementation;
using System;
using System.Collections.Generic;
namespace console_UIADebug
{

    class RawTreeTraverser
    {
        static CUIAutomation8 cUIAutomation8 = new CUIAutomation8();
        static IUIAutomationTreeWalker rawTreeWalker = cUIAutomation8.CreateTreeWalker(cUIAutomation8.RawViewCondition);
        public static bool SearchNameInAnApp(int _processId, string _expectedName, int _timeoutInSeconds = 10)
        {
            DateTime past = DateTime.Now;
            List<IUIAutomationElement> result = new List<IUIAutomationElement>();
            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                IUIAutomationElement app = rawTreeWalker.GetFirstChildElement(cUIAutomation8.GetRootElement());
                while (app.CurrentProcessId != _processId)
                {
                    app = rawTreeWalker.GetNextSiblingElement(app);
                }
                if (app.CurrentProcessId != _processId)
                {
                    System.Threading.Thread.Sleep(500);
                    continue;
                }
                result = SearchNameInApp(app, _expectedName);
                if (result.Count > 0)
                {
                    break;
                }
            }
            return result.Count > 0;
        }
        public static bool SearchNameInAnApp(string _windowName, string _expectedName, int _timeoutInSeconds = 10)
        {
            DateTime past = DateTime.Now;
            List<IUIAutomationElement> result = new List<IUIAutomationElement>();
            while (past.AddSeconds(_timeoutInSeconds) > DateTime.Now)
            {
                IUIAutomationElement app = rawTreeWalker.GetFirstChildElement(cUIAutomation8.GetRootElement());
                while (app != null && app.CurrentName != null && !app.CurrentName.Equals(_windowName))
                {
                    app = rawTreeWalker.GetNextSiblingElement(app);
                }
                if (app != null && app.CurrentName != null && !app.CurrentName.Equals(_windowName))
                {
                    System.Threading.Thread.Sleep(500);
                    continue;
                }
                if (app == null)
                {
                    continue;
                }
                result = SearchNameInApp(app, _expectedName);
                if (result.Count > 0)
                {
                    break;
                }
            }
            return result.Count > 0;
        }

        public static List<IUIAutomationElement> SearchNameInApp(IUIAutomationElement _app, string _expectedName)
        {
            IUIAutomationElement firstChild = rawTreeWalker.GetFirstChildElement(_app);
            List<IUIAutomationElement> caughtList = new List<IUIAutomationElement>();
            try
            {
                printAllChildren(firstChild, _expectedName, ref caughtList);
            }
            catch (Exception)
            {
                return new List<IUIAutomationElement>();
            }
            return caughtList;
        }

        static void printAllChildren(IUIAutomationElement _element, string _expectedName, ref List<IUIAutomationElement> _caughtList)
        {
            /*先打印可用于debug的info*/
            try
            {

                if (_element.CurrentName != null && _element.CurrentName.Equals(_expectedName))
                {
                    _caughtList.Add(_element);
                    return;
                }
                else if (_element.CurrentName != null)
                {
                    //Under some circumstance , a GUI element may contains a very long text. Name doesNOT contains the entire text while Text would.
                    IUIAutomationTextPattern textPattern = _element.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_TextPatternId);
                    if (textPattern != null)
                    {
                        string text = textPattern.DocumentRange.GetText(-1);
                        if (text != null && text.Equals(_expectedName))
                        {
                            _caughtList.Add(_element);
                            return;
                        }
                    }
                }
            }
            catch (System.Exception)
            {
                return;
            }
            /*深度优先*/
            /*先看看有没有children，有的话继续找children，一直到最深的那个child*/
            IUIAutomationElement child = rawTreeWalker.GetFirstChildElement(_element);
            if (child != null)
            {
                printAllChildren(child, _expectedName, ref _caughtList);
            }
            /*广度第二，此时从最深的那个child往上，看看有没有sibling，有的话检查每个sibling以及他们的children*/
            IUIAutomationElement sibling = rawTreeWalker.GetNextSiblingElement(_element);
            if (sibling != null)
            {
                printAllChildren(sibling, _expectedName, ref _caughtList);
            }
        }
    }
}
