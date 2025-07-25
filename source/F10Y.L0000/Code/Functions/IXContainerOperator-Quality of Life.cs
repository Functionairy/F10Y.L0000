using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;
using System.Runtime.CompilerServices;


namespace F10Y.L0000
{
    public partial interface IXContainerOperator
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="Has_ChildOfChild(XContainer, string, string, out XElement)"/>.
        /// </summary>
        public bool Has_Grandchild(
            XContainer container,
            string childName,
            string grandchildName,
            out XElement child_OrDefault)
        {
            var output = this.Has_ChildOfChild(
                container,
                childName,
                grandchildName,
                out child_OrDefault);

            return output;
        }
    }
}
