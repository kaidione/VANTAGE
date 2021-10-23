
using interop.UIAutomationCore;
using System;
using System.Xml.XPath;

namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author: Marcus
    /// </summary>
    class UIAItem : XPathItem
    {
        string UIAControlType(int _controlType)
        {
            switch (_controlType)
            {
                case 0:
                    //invalid control type !!!
                    return "";
                case 50000:
                    return "Button";
                case 50001:
                    return "Calendar";
                case 50002:
                    return "CheckBox";
                case 50003:
                    return "ComboBox";
                case 50004:
                    return "Edit";
                case 50005:
                    return "HyperLink";
                case 50006:
                    return "Image";
                case 50007:
                    return "ListItem";
                case 50008:
                    return "List";
                case 50009:
                    return "Menu";
                case 50010:
                    return "MenuBar";
                case 50011:
                    return "MenuItem";
                case 50012:
                    return "ProgressBar";
                case 50013:
                    return "RadioButton";
                case 50014:
                    return "ScrollBar";
                case 50015:
                    return "Slider";
                case 50016:
                    return "Spinner";
                case 50017:
                    return "StatusBar";
                case 50018:
                    return "Tab";
                case 50019:
                    return "TabItem";
                case 50020:
                    return "Text";
                case 50021:
                    return "ToolBar";
                case 50022:
                    return "ToolTip";
                case 50023:
                    return "Tree";
                case 50024:
                    return "TreeItem";
                case 50025:
                    return "Custom";
                case 50026:
                    return "Group";
                case 50027:
                    return "Thumb";
                case 50028:
                    return "DataGrid";
                case 50029:
                    return "DataItem";
                case 50030:
                    return "Document";
                case 50031:
                    return "SplitButton";
                case 50032:
                    return "Window";
                case 50033:
                    return "Pane";
                case 50034:
                    return "Header";
                case 50035:
                    return "HeaderItem";
                case 50036:
                    return "Table";
                case 50037:
                    return "TitleBar";
                case 50038:
                    return "Separator";
                case 50039:
                    return "SemanticZoom";
                case 50040:
                    return "AppBar";
                /*  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return "";
                  case 50040:
                      return ""; */
                default:
                    throw new Exception("Unknown UIA control type");
            }
        }
        private XPathItem parent;
        public override XPathNodeType NodeType
        {
            get { return XPathNodeType.Element; }
        }
        public override string Name
        {
            get
            {

                return UIAControlType(uIAutomationElement.GetCurrentPropertyValue((int)AutomationPropertyIdentifiers.UIA_ControlTypePropertyId));


            }
        }
        public UIAItem(IUIAutomationElement _uIAutomationElement, XPathItem _parent)
        {
            uIAutomationElement = _uIAutomationElement;
            parent = _parent;
        }


        public override XPathItem MoveToFirstAttribute()
        {
            return new UIAAttributeItem(this);
        }
        public override XPathItem MoveToNextAttribute()
        {
            return null;
        }
        public override XPathItem MoveToFirstChild()
        {
            IUIAutomationElement child = null;
            string name = uIAutomationElement.CurrentName;
            child = rawTreeWalker.GetFirstChildElement(uIAutomationElement);

            if (child != null)
            {
                return new UIAItem(child, this);
            }
            else
            {
                child = uIAutomationElement.FindFirst(interop.UIAutomationCore.TreeScope.TreeScope_Children, cUIAutomation8.CreateTrueCondition());
                IUIAutomationElementArray iarrary = uIAutomationElement.FindAll(interop.UIAutomationCore.TreeScope.TreeScope_Children, cUIAutomation8.CreateTrueCondition());
                try
                {
                    if (iarrary != null)
                    {
                        int len = iarrary.Length;
                    }
                }
                catch (Exception)
                {

                }

                if (child != null)
                {
                    return new UIAItem(child, this);
                }
            }
            return null;
        }

        public override XPathItem MoveToAttribute(string name)
        {
            var attr = AttributeInfo.GetAttribute(name);
            if (attr == null) return null;
            var value = attr.GetValue(uIAutomationElement);
            if (value == null) return null;
            return new UIAAttributeItem(this, attr, value);
        }

        public override bool IsEmptyElement
        {
            get
            {
                return uIAutomationElement == null;
            }
        }

        public override XPathItem MoveToNext()
        {
            IUIAutomationElement sib = null;
            sib = rawTreeWalker.GetNextSiblingElement(uIAutomationElement);

            if (sib == null)
            {
                return null;
            }
            return new UIAItem(sib, parent);
        }
        public override XPathItem MoveToPrevious()
        {
            IUIAutomationElement sib = null;
            sib = rawTreeWalker.GetPreviousSiblingElement(uIAutomationElement);

            if (sib == null)
            {
                return null;
            }
            return new UIAItem(sib, parent);
        }
        public override bool IsSamePosition(XPathItem item)
        {
            return string.Join(",", uIAutomationElement.GetRuntimeId()).Equals(string.Join(",", item.uIAutomationElement.GetRuntimeId()));
        }
        public override XPathItem MoveToParent()
        {
            return parent;
        }
    }
}
