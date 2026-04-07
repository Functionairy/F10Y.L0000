using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXElementOperations
    {
        Func<XElement, bool> Has_AttributeWithValue(
            string attributeName,
            string attributeValue)
            => element => Instances.XElementOperator.Has_AttributeWithValue(
                element,
                attributeName,
                attributeValue);

        Func<XElement, bool> Is_Named_Local(string elementName)
            => element => Instances.XElementOperator.Is_LocalName(
                element,
                elementName);

        Func<XElement, bool> Is_Named(string elementName)
            => this.Is_Named_Local(elementName);

        Func<XElement, bool> Name_Is(string element_Name)
            => this.Is_Named_Local(element_Name);
    }
}
