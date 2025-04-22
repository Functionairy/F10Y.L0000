using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXAttributeOperator
    {
        /// <summary>
        /// Chooses <see cref="Get_Name_AsString(XAttribute)"/> as the default.
        /// </summary>
        public string Get_Name(XAttribute attribute)
            => this.Get_Name_AsString(attribute);

        public XName Get_Name_AsXName(XAttribute attribute)
            => attribute.Name;

        public string Get_Name_AsString(XAttribute attribute)
        {
            var name = this.Get_Name_AsXName(attribute);

            var output = Instances.XNameOperator.Get_Name(name);
            return output;
        }

        public string Get_Value(XAttribute attribute)
        {
            var output = attribute.Value;
            return output;
        }

        /// <summary>
        /// A helpfully named wrapper for <see cref="XAttribute.SetValue(object)"/>.
        /// </summary>
        public void Set_Value(XAttribute attribute, object value)
        {
            attribute.SetValue(value);
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        public bool Is_Name(XAttribute attribute, string attributeName)
        {
            var name = this.Get_Name_AsXName(attribute);

            var output = Instances.XNameOperator.Is_Name(
                name,
                attributeName);

            return output;
        }

        public XAttribute New_Attribute(string attributeName, object value)
        {
            var output = new XAttribute(attributeName, value);
            return output;
        }

        public XAttribute New_Attribute(string attributeName)
        {
            var output = this.New_Attribute(
                attributeName,
                // Use the empty string for the attribute value, since a value must be specified when creating an XAttribute,
                // but we don't want to specify the value just yet.
                Instances.Values.Empty_XAttribute_Value);

            return output;
        }

        public IEnumerable<XAttribute> Where_NameIs(IEnumerable<XAttribute> attributes, string attributeName)
        {
            var output = attributes
                .Where(attribute => this.Is_Name(attribute, attributeName))
                ;

            return output;
        }
    }
}
