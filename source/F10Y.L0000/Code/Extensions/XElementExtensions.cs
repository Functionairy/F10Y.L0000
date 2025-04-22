using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace F10Y.L0000.Extensions
{
    public static class XElementExtensions
    {
        public static IEnumerable<XElement> Where_NameIs(this IEnumerable<XElement> elements,
            string elementName)
        {
            return Instances.XElementOperator.Where_NameIs(
                elements,
                elementName);
        }
    }
}
