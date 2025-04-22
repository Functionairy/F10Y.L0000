using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXContainerOperator
    {
        public XElement Acquire_Child(
            XContainer container,
            string elementName)
        {
            var hasChild = this.Has_Child(
                container,
                elementName,
                out var child);

            if (!hasChild)
            {
                child = this.Append_Child(
                    container,
                    elementName);
            }

            return child;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Append_Child(XContainer, XElement)"/>.
        /// </summary>
        public void Add_Child(
            XContainer parent,
            XElement child)
            => this.Append_Child(
                parent,
                child);

        public void Append_Child(
            XContainer parent,
            XElement child)
        {
            parent.Add(child);
        }

        public XElement Append_Child(
            XContainer parent,
            string childName)
        {
            var child = Instances.XElementOperator.New(childName);

            this.Append_Child(
                parent,
                child);

            return child;
        }

        /// <summary>
        /// A better named quality-of-life method for <see cref="XContainer.Elements()"/>.
        /// </summary>
        public IEnumerable<XElement> Enumerate_Children(XContainer container)
        {
            return container.Elements();
        }

        /// <summary>
        /// Chooses <see cref="Has_Child_First(XContainer, string, out XElement)"/> as the default.
        /// </summary>
        public bool Has_Child(
            XContainer container,
            string childName,
            out XElement child)
        {
            return this.Has_Child_First(
                container,
                childName,
                out child);
        }

        public bool Has_Child_First(XContainer container, string childName, out XElement childOrDefault)
        {
            childOrDefault = this.Enumerate_Children(container)
                .Where_NameIs(childName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(childOrDefault);
            return output;
        }
    }
}
