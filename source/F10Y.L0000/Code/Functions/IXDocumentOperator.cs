using System;
using System.Xml.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXDocumentOperator
    {
        /// <summary>
        /// Gets the root element of the given document,
        /// throwing an exception if the document does not have a root element.
        /// </summary>
        public XElement Get_Root(XDocument document)
        {
            var hasRoot = this.Has_Root(
                document,
                out var root_OrDefault);

            if (!hasRoot)
            {
                throw new Exception("XML document did not have a root.");
            }

            return root_OrDefault;
        }

        /// <summary>
        /// Gets the root element of the given document,
        /// verifying that the root element exists and has the given name.
        /// </summary>
        public XElement Get_Root(
            XDocument document,
            string rootName)
        {
            var rootElement = this.Get_Root(document);

            Instances.XElementOperator.Verify_NameIs(
                rootElement,
                rootName);

            return rootElement;
        }

        /// <summary>
        /// Gets the root element of the document, or default if it does not exist.
        /// </summary>
        public XElement Get_Root_OrDefault(XDocument document)
            => document.Root;

        public bool Has_Root(
            XDocument document,
            out XElement root_OrDefault)
        {
            root_OrDefault = this.Get_Root_OrDefault(document);

            var output = Instances.NullOperator.Is_NotNull(root_OrDefault);
            return output;
        }
    }
}
