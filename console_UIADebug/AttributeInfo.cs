
using interop.UIAutomationCore;
using System;
using System.Collections.Generic;
using System.Linq;
namespace LenovoVantageTest.Utility.UIAImplementation
{
    ///Author:Marcus 
    /// <summary>
	/// A flyweight class for the attributes, applied to the file system elements
	/// </summary>
	class AttributeInfo
    {
        private Func<IUIAutomationElement, string> _getValueFunc;

        /// <summary>
        /// Contains a list of all posible attributes of elements, representing files and folders
        /// </summary>
        public static readonly AttributeInfo[] AttributeList = new[]{
            new AttributeInfo("Name", fi => fi.CurrentName),
            new AttributeInfo("ControlType", fi => fi.CurrentControlType.ToString()),
            new AttributeInfo("AutomationId", fi => fi.CurrentAutomationId),
            new AttributeInfo("ProcessId", fi => fi.CurrentProcessId.ToString()),
            new AttributeInfo("FrameworkId", fi => fi.CurrentFrameworkId),
            new AttributeInfo("RuntimeId", fi =>string.Join(",", fi.GetRuntimeId().Select(p=>p.ToString()).ToArray())),
            new AttributeInfo("ClassName", fi => fi.CurrentClassName),
            new AttributeInfo("NativeWindowHandle", fi =>fi.CurrentNativeWindowHandle.ToString()),
            new AttributeInfo("BoundingRectangle", fi=>fi.CurrentBoundingRectangle.left+","+fi.CurrentBoundingRectangle.top+","+fi.CurrentBoundingRectangle.right+","+fi.CurrentBoundingRectangle.bottom),
            new AttributeInfo("IsEnabled", fi=>fi.CurrentIsEnabled.ToString()),
            new AttributeInfo("IsOffscreen",fi=>fi.CurrentIsOffscreen.ToString()),
            new AttributeInfo("IsKeyboardFocusable", fi=>fi.CurrentIsKeyboardFocusable.ToString()),
            new AttributeInfo("IsPassword", fi=>fi.CurrentIsPassword.ToString()),
            new AttributeInfo("Toggle.ToggleState", fi=>{
              var pattern = fi.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_TogglePatternId);
                if (pattern == null)
                 {
                     return "NO Toggle Pattern available";
                 }
                 int currentState= (int)((IUIAutomationTogglePattern)pattern).CurrentToggleState;
                 return currentState.ToString();
            }),
            new AttributeInfo("Value.Value", fi=>{
              var pattern = fi.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ValuePatternId);
            if (pattern == null)
            {

                return "NO Value pattern available";
            }
            return ((IUIAutomationValuePattern)pattern).CurrentValue;
            }),
            new AttributeInfo("ExpandCollapse.ExpandCollapseState", fi=>{
              var pattern = fi.GetCurrentPattern((int)ControlPatternIdentifiers.UIA_ExpandCollapsePatternId);
                if (pattern == null)
                 {
                     return "NO UIA_ExpandCollapsePatternId Pattern available";
                 }
                 int currentState= (int)((IUIAutomationExpandCollapsePattern)pattern).CurrentExpandCollapseState;
                 return currentState.ToString();
            }),
            new AttributeInfo("IsAnnotationPatternAvailable",fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsAnnotationPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsDragPatternAvailable",fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsDragPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsDockPatternAvailable",fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsDockPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsDropTargetPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsDropTargetPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsExpandCollapsePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsExpandCollapsePatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsGridItemPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsGridItemPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsGridPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsGridPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsDialog", fi=>{
                try{
                return fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_isDialogPropertyId)?"true":"false";
                }catch(Exception ex)
                {
                    //Marcus:这是一个很奇怪的exception ,目前只发生在RS4上。当IsDialogProperty 被试图访问时，系统就会throw这个exception。
                    //而且我不知道何时XPathNavigation正式完全完成，因为当navigation.evaluate()完成后，似乎Tree还没有完全iterate完。
                    if (!ex.Message.Contains("Value does not fall within the expected range"))
                    {
                        throw ex;
                    }
                }
                return "";
                }),
            new AttributeInfo("IsInvokePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsInvokePatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsRangeValuePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsRangeValuePatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsScrollItemPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsScrollItemPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsScrollPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsScrollPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsSelectionItemPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsSelectionItemPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsSelectionPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsSelectionPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsTableItemPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsTableItemPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsTablePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsTablePatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsTogglePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsTogglePatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsTextPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsTextPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsTextEditPatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsTextEditPatternAvailablePropertyId)?"true":"false"),
            new AttributeInfo("IsValuePatternAvailable", fi=>fi.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_IsValuePatternAvailablePropertyId)?"true":"false"),
        };

        private static readonly Dictionary<string, AttributeInfo> AttributeDictionary;

        static AttributeInfo()
        {
            AttributeDictionary = AttributeList.ToDictionary(a => a.Name);
        }

        internal static AttributeInfo GetAttribute(string name)
        {
            AttributeInfo attr;
            if (AttributeDictionary.TryGetValue(name, out attr))
            {
                return attr;
            }
            return null;
        }

        /// <summary>
        /// Initialized a new instance of the class
        /// </summary>
        /// <param name="name">Attribute name</param>
        /// <param name="getValue">A delegate, that returns the attribute value for the given <see cref="FileSystemItem"/> object</param>
        public AttributeInfo(string name, Func<IUIAutomationElement, string> getValue
           )
        {
            Name = name;
            _getValueFunc = getValue;
        }



        /// <summary>
        /// Attribute name
        /// </summary>
        public string Name { get; private set; }


        /// <summary>
        /// Returns the value of this attribute, applied to the specific file system item. 
        /// If this method returns <c>null</c>, the attribute should not be added
        /// </summary>
        /// <param name="fileSystemInfo">Info object for a file or a folder</param>
        /// <returns>Attribute's string value</returns>
        public string GetValue(IUIAutomationElement _uIAutomationElement)
        {
            return _getValueFunc(_uIAutomationElement);
        }
    }
}
