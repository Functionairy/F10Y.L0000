using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXElementOperator
    {
        public XElement Create_Element_FromName(string elementName)
        {
            var output = new XElement(elementName);
            return output;
        }

        public XElement Create_Element(string elementName)
        {
            var output = this.Create_Element_FromName(elementName);
            return output;
        }
    }
}
