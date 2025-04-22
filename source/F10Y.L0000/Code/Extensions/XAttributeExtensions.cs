using System;
using System.Collections.Generic;
using System.Xml.Linq;


namespace F10Y.L0000.Extensions
{
    public static class XAttributeExtensions
    {
        public static IEnumerable<XAttribute> Where_NameIs(this IEnumerable<XAttribute> attributes,
            string attributeName)
        {
            return Instances.XAttributeOperator.Where_NameIs(
                attributes,
                attributeName);
        }
    }
}
