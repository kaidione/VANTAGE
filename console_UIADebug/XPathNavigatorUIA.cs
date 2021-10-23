using interop.UIAutomationCore;
using System;
using System.Xml.XPath;
namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author: Marcus
    /// </summary>
    public class XPathNavigatorUIA : XPathNavigator
    {
        private XPathItem _item;

        /// <summary>
        /// Constructs a new instance of the file system XPath navigator rooted at the specified file or folder
        /// </summary>
        /// <param name="fileName">A path to the local file system item, 
        /// which will be the root element in the traversed XPath document model</param>
        public XPathNavigatorUIA(IUIAutomationElement uIAutomationElement)
        {
            _item = RootItem.CreateItem(uIAutomationElement);
        }

        private XPathNavigatorUIA(XPathItem item)
        {
            _item = item;
        }

        public override string BaseURI
        {
            get { return string.Empty; }
        }

        public override XPathNavigator Clone()
        {
            return new XPathNavigatorUIA(_item);
        }

        public override bool IsEmptyElement
        {
            get { return _item.IsEmptyElement; }
        }

        public override bool IsSamePosition(XPathNavigator other)
        {
            var o = other as XPathNavigatorUIA;
            return o != null && o._item.IsSamePosition(_item);
        }

        public override string LocalName
        {
            get { return _item.Name; }
        }

        public override bool MoveTo(XPathNavigator other)
        {
            var o = other as XPathNavigatorUIA;
            if (o != null)
            {
                _item = o._item;
                return true;
            }
            return false;
        }

        public override bool MoveToFirstAttribute()
        {
            return MoveToItem(_item.MoveToFirstAttribute());
        }

        private bool MoveToItem(XPathItem newItem)
        {
            if (newItem == null) return false;

            _item = newItem;
            return true;
        }

        public override bool MoveToFirstChild()
        {
            return MoveToItem(_item.MoveToFirstChild());
        }

        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
        {
            return false;
        }

        public override bool MoveToId(string id)
        {
            return false;
        }

        public override bool MoveToNext()
        {
            return MoveToItem(_item.MoveToNext());
        }

        public override bool MoveToNextAttribute()
        {
            return MoveToItem(_item.MoveToNextAttribute());
        }

        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
        {
            return false;
        }

        public override bool MoveToParent()
        {
            return MoveToItem(_item.MoveToParent());
        }

        public override bool MoveToPrevious()
        {
            return MoveToItem(_item.MoveToPrevious());
        }

        public override string Name
        {
            get { return LocalName; }
        }

        public override System.Xml.XmlNameTable NameTable
        {
            get { return null; }
        }

        public override string NamespaceURI
        {
            get { return string.Empty; }
        }

        public override XPathNodeType NodeType
        {
            get { return _item.NodeType; }
        }

        public override string Prefix
        {
            get { return string.Empty; }
        }

        public override string Value
        {
            get { return _item.Value; }
        }
        public override object UnderlyingObject { get { return _item.uIAutomationElement; } }
        public override bool MoveToAttribute(string localName, string namespaceURI)
        {
            if (namespaceURI != String.Empty) return false;
            return MoveToItem(_item.MoveToAttribute(localName));
        }
    }
}
