using interop.UIAutomationCore;
using System;
using System.Xml.XPath;
namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author:  Marcus
    /// </summary>
    internal abstract class XPathItem
    {
        protected static CUIAutomation8 cUIAutomation8 = new CUIAutomation8();
        protected static IUIAutomationTreeWalker rawTreeWalker = cUIAutomation8.CreateTreeWalker(cUIAutomation8.RawViewCondition);
        protected internal IUIAutomationElement uIAutomationElement { set; get; }
        public abstract string Name { get; }
        public abstract XPathItem MoveToFirstAttribute();
        public abstract XPathItem MoveToNextAttribute();
        public abstract XPathItem MoveToFirstChild();
        public abstract XPathItem MoveToNext();
        public abstract XPathItem MoveToPrevious();
        public abstract XPathNodeType NodeType { get; }
        public virtual string Value { get { return string.Empty; } }
        public abstract bool IsEmptyElement { get; }
        public abstract XPathItem MoveToParent();
        public abstract XPathItem MoveToAttribute(string name);
        public abstract bool IsSamePosition(XPathItem item);
        public virtual object ValueAs(Type returnType) { return null; }
    }
}
