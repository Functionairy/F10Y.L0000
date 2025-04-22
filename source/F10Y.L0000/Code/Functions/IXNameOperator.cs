using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXNameOperator
    {
        public string Get_LocalName(XName name)
            => name.LocalName;

        /// <summary>
        /// Chooses <see cref="Get_LocalName(XName)"/> as the default to avoid namespace nonsense.
        /// </summary>
        public string Get_Name(XName name)
            => this.Get_LocalName(name);

        /// <summary>
        /// Uses <see cref="XName.LocalName"/>.
        /// </summary>
        public bool Is_LocalName(XName name, string localName)
        {
            var output = name.LocalName == localName;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Is_LocalName(XName, string)"/> as the default to avoid namespace nonsense.
        /// </summary>
        public bool Is_Name(XName xName, string name)
            => this.Is_LocalName(
                xName,
                name);
    }
}
