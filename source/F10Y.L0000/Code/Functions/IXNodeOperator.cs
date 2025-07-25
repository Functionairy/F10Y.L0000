using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXNodeOperator
    {
        public void Remove(XNode node)
            => node.Remove();

        /// <summary>
        /// Quality-of-life over for <see cref="Remove(XNode)"/>.
        /// </summary>
        public void Remove_FromParent(XNode node)
            => this.Remove(node);
    }
}
