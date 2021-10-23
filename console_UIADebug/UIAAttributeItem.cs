using System;
using System.Xml.XPath;
namespace LenovoVantageTest.Utility.UIAImplementation
{
    /// <summary>
    /// Author: Marcus
    /// </summary>
    class UIAAttributeItem : XPathItem
    {
        private int _currentIndex = -1;
        private readonly UIAItem uIAItem;
        private string _value;

        public UIAAttributeItem(UIAItem _uIAItem)
        {
            uIAItem = _uIAItem;
            MoveToNextAttribute();
        }

        public UIAAttributeItem(UIAItem _uIAItem, AttributeInfo attr, string value)
        {
            uIAItem = _uIAItem;
            _currentIndex = Array.IndexOf(AttributeInfo.AttributeList, attr);
            _value = value;
        }

        public override string Name
        {
            get { return GetCurrent().Name; }
        }

        private AttributeInfo GetCurrent()
        {
            return AttributeInfo.AttributeList[_currentIndex];
        }

        public override XPathItem MoveToFirstAttribute()
        {
            _currentIndex = 0;
            _value = AttributeInfo.AttributeList[_currentIndex].GetValue(uIAItem.uIAutomationElement);
            return this;
        }

        public override XPathItem MoveToNextAttribute()
        {
            if (++_currentIndex >= AttributeInfo.AttributeList.Length)
                return null;
            var current = GetCurrent();
            var value = current.GetValue(uIAItem.uIAutomationElement);
            if (value == null)
                return MoveToNextAttribute();
            _value = value;
            return this;
        }

        public override XPathItem MoveToFirstChild()
        {
            return null;
        }

        public override XPathItem MoveToNext()
        {
            if (++_currentIndex >= AttributeInfo.AttributeList.Length)
                return null;
            var current = GetCurrent();
            var value = current.GetValue(uIAItem.uIAutomationElement);
            if (value == null)
                return MoveToNext();
            _value = value;
            return this;
        }

        public override XPathItem MoveToPrevious()
        {
            if (--_currentIndex < 0)
                return null;
            var current = GetCurrent();
            var value = current.GetValue(uIAItem.uIAutomationElement);
            if (value == null)
                return MoveToPrevious();
            _value = value;
            return this;
        }

        public override XPathNodeType NodeType
        {
            get { return XPathNodeType.Attribute; }
        }

        public override bool IsEmptyElement
        {
            get { return false; }
        }

        public override XPathItem MoveToParent()
        {
            return uIAItem;
        }

        public override string Value
        {
            get { return _value; }
        }

        public override XPathItem MoveToAttribute(string name)
        {
            int tmpIndex = 0;
            foreach (AttributeInfo item in AttributeInfo.AttributeList)
            {
                if (item.Name.Equals(name))
                {
                    _currentIndex = tmpIndex;
                    _value = AttributeInfo.AttributeList[_currentIndex].GetValue(uIAItem.uIAutomationElement);
                    return this;
                }
                tmpIndex++;
            }
            return null;
        }

        public override bool IsSamePosition(XPathItem item)
        {
            var fsai = item as UIAAttributeItem;
            return fsai != null && _currentIndex == fsai._currentIndex;
        }
    }
}
