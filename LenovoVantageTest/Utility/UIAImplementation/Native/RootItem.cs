using interop.UIAutomationCore;
using System.Xml.XPath;
namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author :Marcus
    /// </summary>
    class RootItem : XPathItem
    {

        public UIAItem child { set; get; }
        private RootItem()
        {
        }

        public static XPathItem CreateItem(IUIAutomationElement rootElement = null)
        {
            var root = new RootItem();
            IUIAutomationElement firstAPP = rawTreeWalker.GetFirstChildElement(cUIAutomation8.GetRootElement());
            root.child = new UIAItem((rootElement == null) ? firstAPP : rootElement, root);
            return root;
        }


        public override bool IsEmptyElement
        {
            get { return false; }
        }

        public override XPathItem MoveToAttribute(string name)
        {
            return null;
        }

        public override XPathItem MoveToFirstAttribute()
        {
            return null;
        }

        public override XPathItem MoveToFirstChild()
        {
            return child;
        }

        public override XPathItem MoveToNext()
        {
            return null;
        }

        public override XPathItem MoveToNextAttribute()
        {
            return null;
        }

        public override XPathItem MoveToParent()
        {
            return null;
        }

        public override XPathItem MoveToPrevious()
        {
            return null;
        }

        public override string Name
        {
            get { return string.Empty; }
        }

        public override System.Xml.XPath.XPathNodeType NodeType
        {
            get { return XPathNodeType.Root; }
        }

        public override bool IsSamePosition(XPathItem item)
        {
            var ri = item as RootItem;
            return ri != null && string.Join(",", child.uIAutomationElement.GetRuntimeId()).Equals(string.Join(",", item.uIAutomationElement.GetRuntimeId()));
        }
    }
}
