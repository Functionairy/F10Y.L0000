using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace F10Y.L0000.Extensions
{
    public static class XElementExtensions
    {
        public static IEnumerable<XElement> Enumerate_Children(this XElement element)
            => Instances.XElementOperator.Enumerate_Children(element);

        public static IEnumerable<XElement> Where_NameIs(this IEnumerable<XElement> elements,
            string elementName)
            => Instances.XElementOperator.Where_NameIs(
                elements,
                elementName);
    }
}
