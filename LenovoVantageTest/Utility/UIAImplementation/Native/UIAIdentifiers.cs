using interop.UIAutomationCore;
using System;

#if Vantage
using TangramTest.Logging;
using TangramTest.Utility;
#endif
namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Auhtor: Marcus
    /// </summary>
    //https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-control-pattern-propids
    //https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-control-pattern-availability-propids
    public enum AutomationPropertyIdentifiers
    {
        UIA_RuntimeIdPropertyId = 30000,
        UIA_BoundingRectanglePropertyId = 30001,
        UIA_ProcessIdPropertyId = 30002,
        UIA_ControlTypePropertyId = 30003,
        UIA_NamePropertyId = 30005,
        UIA_HasKeyboardFocusPropertyId = 3008,
        UIA_IsEnabledPropertyId = 30010,
        UIA_AutomationIdPropertyId = 30011,
        UIA_ClassNamePropertyId = 30012,
        UIA_ClickablePointPropertyId = 30014,
        UIA_NativeWindowhandlePropertyId = 30020,
        UIA_IsOffscreenPropertyId = 30022,
        UIA_FrameworkIdPropertyId = 30024,
        UIA_IsDockPatternAvailablePropertyId = 30027,
        UIA_IsExpandCollapsePatternAvailablePropertyId = 30028,
        UIA_IsGridItemPatternAvailablePropertyId = 30029,
        UIA_IsGridPatternAvailablePropertyId = 30030,
        UIA_IsInvokePatternAvailablePropertyId = 30031,
        UIA_IsRangeValuePatternAvailablePropertyId = 30033,
        UIA_IsScrollPatternAvailablePropertyId = 30034,
        UIA_IsScrollItemPatternAvailablePropertyId = 30035,
        UIA_IsSelectionItemPatternAvailablePropertyId = 30036,
        UIA_IsSelectionPatternAvailablePropertyId = 30037,
        UIA_IsTablePatternAvailablePropertyId = 30038,
        UIA_IsTableItemPatternAvailablePropertyId = 30039,
        UIA_IsTextPatternAvailablePropertyId = 30040,
        UIA_IsTogglePatternAvailablePropertyId = 30041,
        UIA_IsValuePatternAvailablePropertyId = 30043,
        UIA_IsWindowPatternAvailablePropertyId = 30044,
        UIA_AriaPropertiesPropertyId = 30102,
        UIA_AriaRolePropertyId = 30101,
        UIA_IsAnnotationPatternAvailablePropertyId = 30118,
        UIA_IsDragPatternAvailablePropertyId = 30137,
        UIA_IsDropTargetPatternAvailablePropertyId = 30141,
        UIA_IsTextEditPatternAvailablePropertyId = 30149,
        UIA_CenterPointPropertyId = 30165,
        UIA_isDialogPropertyId = 30174
    };
    //https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-controlpattern-ids
    public enum ControlPatternIdentifiers
    {
        UIA_InvokePatternId = 10000,
        UIA_SelectionPatternId = 10001,
        UIA_ValuePatternId = 10002,
        UIA_ScrollPatternId = 10004,
        UIA_ExpandCollapsePatternId = 10005,
        UIA_GridPatternId = 10006,
        UIA_GridItemPatternId = 10007,
        UIA_WindowPatternId = 10009,
        UIA_SelectionItemPatternId = 10010,
        UIA_DockPatternId = 10011,
        UIA_TablePatternId = 10012,
        UIA_TableItemPatternId = 10013,
        UIA_TogglePatternId = 10015,
        UIA_ScrollItemPatternId = 10017,
        UIA_StylesPatternId = 10025,
        UIA_TextChildPatternId = 10029,
        UIA_DragPatternId = 10030,
        UIA_DropTargetPatternId = 10031,
        UIA_TextEditPatternId = 10032,
        UIA_TextPatternId = 10014,

    }

    public class UIAActions
    {
        /// <summary>
        /// Author:Marcus
        /// 99%的情况下，自动化的行为都是click某个GUI对象。这里默认点击第一个匹配的对象。
        /// 对于人来说，无论是在Button上，还是MenuItem的东西上点一下，我们只是发起了Click行为，
        ///但对于UIA来说，它要在[Invoke,Expand,Collapse,Toggle]之内区分。所以为了满足人的需要，我们要屏蔽这些区别。
        ///在下面的代码中，我会依次检查GUI对象具有哪些Pattern，有类似click的就调用。
        /// </summary>
        /// 

        static tagRECT root_RECT = new CUIAutomation8().GetRootElement().CurrentBoundingRectangle;

        //Marcus:Vantage现在的设计是，只有mouse悬停在GUI处，Menu才会collapse，否则Menu即使被InvokePattern强制collapse了，也会立即sprint back。
        public static Func<IUIAutomationElement, bool> mouseMove = x =>
        {

            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = x.CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * zoomfactor)
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * zoomfactor)
            {
                return false;
            }
            /*2020/06/24 , 今天发现一个情况。mouse move到指定位置没有触发menu collapse行为，所以我增加为三次到位的behavior
             * 易于点击目标在中心点，所以超出边界的可能很小，我就不考虑了
             */
            KeyboardMouse.DoMouseMove(0, 0);
            KeyboardMouse.DoMouseMove(centeric[0] + 2, centeric[1] + 2);
            KeyboardMouse.DoMouseMove(centeric[0] - 2, centeric[1] - 2);
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            return true;
        };
        public static Func<IUIAutomationElement, bool> click = x =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_InvokePatternId);
            if (pattern != null)
            {
                ((IUIAutomationInvokePattern)pattern).Invoke();
                System.Threading.Thread.Sleep(2500);
                return true;
            }
            pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ExpandCollapsePatternId);
            if (pattern != null)
            {
                if (((IUIAutomationExpandCollapsePattern)pattern).CurrentExpandCollapseState == 0)
                {
                    ((IUIAutomationExpandCollapsePattern)pattern).Expand();
                }
                else
                {
                    ((IUIAutomationExpandCollapsePattern)pattern).Collapse();
                }
                System.Threading.Thread.Sleep(2500);
                return true;
            }
            pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_TogglePatternId);
            if (pattern != null)
            {
                ((IUIAutomationTogglePattern)pattern).Toggle();
                System.Threading.Thread.Sleep(1500);
                return true;
            }

            // TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information,"NOT clickable.");
            return mouseClick(x);

        };
        static bool mouseClick(IUIAutomationElement x)
        {
            //Last chance , is it in the clickable range ?
            float zoomfactor = CaptureScreen.GetScalingFactor();
            tagRECT boundRectangle = x.CurrentBoundingRectangle;
            int[] centeric = { (int)((boundRectangle.left + boundRectangle.right) * zoomfactor) / 2, (int)((boundRectangle.top + boundRectangle.bottom) * zoomfactor) / 2 };

            if (centeric[0] < 0 || centeric[1] < 0)
            {
                return false;
            }
            if (centeric[0] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * zoomfactor)
            {
                return false;
            }
            if (centeric[1] > System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * zoomfactor)
            {
                return false;
            }
            KeyboardMouse.DoMouseMove(0, 0);
            KeyboardMouse.DoMouseMove(centeric[0], centeric[1]);
            KeyboardMouse.DoMouseClick(centeric[0], centeric[1]);
            return true;
        }


        public static Func<IUIAutomationElement, bool> expand = x =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ExpandCollapsePatternId);
            if (pattern == null)
            {
#if Vantage
                TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information, "Unable to expand.");
#endif
                return false;
            }
            ((IUIAutomationExpandCollapsePattern)pattern).Expand();
            System.Threading.Thread.Sleep(1500);
            return true;
        };


        public static Func<IUIAutomationElement, bool> collapse = x =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ExpandCollapsePatternId);
            if (pattern == null)
            {
#if Vantage
                TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information, "Unable to collpase.");
#endif
                return false;
            }
           ((IUIAutomationExpandCollapsePattern)pattern).Collapse();
            System.Threading.Thread.Sleep(1500);
            return true;
        };


        public static Func<IUIAutomationElement, object[], bool> setValue = (x, _additionalParams) =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ValuePatternId);
            if (pattern == null)
            {
#if Vantage
                TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information, "Unable to Edit.");
#endif
                return false;
            }
            if (_additionalParams.Length == 0)
            {
                return false;
            }
            ((IUIAutomationValuePattern)pattern).SetValue(_additionalParams[0].ToString());
            System.Threading.Thread.Sleep(1500);
            return true;
        };


        public static Func<IUIAutomationElement, bool> toggle = x =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_TogglePatternId);
            if (pattern == null)
            {
#if Vantage
                TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information, "Unable to toggle.");
#endif
                return false;
            }
             ((IUIAutomationTogglePattern)pattern).Toggle();
            System.Threading.Thread.Sleep(1500);
            return true;
        };


        public static Func<IUIAutomationElement, ScrollAmount, ScrollAmount, bool> scroll = (x, horizontalScrollAmount, verticalScrollAmount) =>
        {
            var pattern = x.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ScrollPatternId);
            if (pattern == null)
            {
#if Vantage
                TangramTest.Logging.Logger.Instance.WriteLog(Logging.Logger.Instance.WriteLogSeverity.Information, "Unable to toggle.");
#endif
                return false;
            }
               ((IUIAutomationScrollPattern)pattern).Scroll(horizontalScrollAmount, verticalScrollAmount);
            System.Threading.Thread.Sleep(1500);
            return true;
        };
    }
}