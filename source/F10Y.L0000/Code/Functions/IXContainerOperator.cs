using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXContainerOperator :
        IXNodeOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public IXNodeOperator _XNodeOperator => XNodeOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public XElement Acquire_Child<TContainer>(
            TContainer parent,
            Func<TContainer, (bool, XElement)> has_Child_Operation,
            Func<XElement> child_Constructor)
            where TContainer : XContainer
        {
            var has_Child = has_Child_Operation(parent);
            if (has_Child.Item1)
            {
                return has_Child.Item2;
            }
            else
            {
                var output = child_Constructor();

                this.Append_Child(
                    parent,
                    output);

                return output;
            }
        }

        public XElement Acquire_Child(
            XContainer container,
            Func<XContainer, XElement> select_Child_OrDefault,
            string childName)
        {
            var child_OrDefault = select_Child_OrDefault(container);

            var is_Default = Instances.DefaultOperator.Is_Default(child_OrDefault);

            var output = is_Default
                ? this.Append_Child(
                    container,
                    childName)
                : child_OrDefault
                ;

            return output;
        }

        public XElement Acquire_Child(
            XContainer container,
            string childName)
        {
            var hasChild = this.Has_Child(
                container,
                childName,
                out var child);

            if (!hasChild)
            {
                child = this.Append_Child(
                    container,
                    childName);
            }

            return child;
        }

        public XElement Acquire_ChildOfChild(
            XContainer container,
            string childName,
            string childOfChildName)
        {
            var child = this.Acquire_Child(
                container,
                childName);

            var output = this.Acquire_Child(
                child,
                childOfChildName);

            return output;
        }

        public XElement Acquire_ChildOfChild<TContainer>(
            TContainer parent,
            Func<TContainer, XElement> acquire_Child_Operation,
            string childOfChildName)
            where TContainer : XContainer
        {
            var child = acquire_Child_Operation(parent);

            var output = this.Acquire_Child(
                child,
                childOfChildName);

            return output;
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
            XText child)
        {
            parent.Add(child);
        }

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
            => container.Elements();

        /// <summary>
        /// A better named quality-of-life method for <see cref="XContainer.Elements()"/>.
        /// </summary>
        public IEnumerable<XElement> Enumerate_Children(
            XContainer container,
            string childName)
            => this.Enumerate_Children(container)
                .Where_NameIs(childName)
                ;

        public IEnumerable<XElement> Enumerate_ChildrenOfChildren(XContainer container)
            => this.Enumerate_Children(container)
                .SelectMany(this.Enumerate_Children)
                ;

        public IEnumerable<XElement> Enumerate_ChildrenOfChildren(
            XContainer container,
            string childOfChildName)
            => this.Enumerate_ChildrenOfChildren(container)
                .Where(Instances.XElementOperations.Is_Named(childOfChildName))
                ;

        public XElement Get_Child_First(
            XContainer container,
            string childName)
        {
            var has_Child = this.Has_Child_First(
                container,
                childName,
                out var child_OrDefault);

            if(!has_Child)
            {
                throw new Exception($"{childName} : Child element not found.");
            }

            return child_OrDefault;
        }

        /// <summary>
        /// Chooses <see cref="Get_Child_First(XContainer, string)"/> as the default.
        /// </summary>
        public XElement Get_Child(
            XContainer container,
            string childName)
            => this.Get_Child_First(
                container,
                childName);

        public TValue Get_Child_Value<TValue>(
            XContainer container,
            string childName,
            Func<XElement, TValue> valueSelector)
        {
            var has_ChildValue = this.Has_Child_Value(
                container,
                childName,
                valueSelector,
                out var value_OrDefault);

            if(!has_ChildValue)
            {
                throw new Exception($"{childName}: no child found.");
            }

            return value_OrDefault;
        }

        public string Get_Child_Value(
            XContainer container,
            string childName)
            => this.Get_Child_Value(
                container,
                childName,
                Instances.XElementOperator.Get_Value_AsString);

        public bool Remove_Child_First(
            XContainer container,
            string childName,
            out XElement child_OrDefault)
        {
            var has_Child = this.Has_Child(
                container,
                childName,
                out child_OrDefault);

            if(has_Child)
            {
                this.Remove(child_OrDefault);
            }

            return has_Child;
        }

        /// <summary>
        /// Chooses <see cref="Remove_Child_First(XContainer, string, out XElement)"/> as the default.
        /// </summary>
        public bool Remove_Child(
            XContainer container,
            string childName,
            out XElement child_OrDefault)
        {
            var output = this.Remove_Child_First(
                container,
                childName,
                out child_OrDefault);

            return output;
        }

        public bool Remove_Child(
            XContainer container,
            string childName)
            => this.Remove_Child(
                container,
                childName,
                out _);

        public void Set_Child_Value(
            XContainer container,
            string childName,
            string value)
        {
            var child_Element = this.Acquire_Child(
               container,
               childName);

            Instances.XElementOperator.Set_Value(
                child_Element,
                value);
        }

        public void Set_Child_Value<TValue>(
            XContainer container,
            string childName,
            TValue value,
            Func<TValue, string> value_ToString)
        {
            var value_AsString = value_ToString(value);

            this.Set_Child_Value(
                container,
                childName,
                value_AsString);
        }

        public bool Has_Child_First(
            IEnumerable<XContainer> containers,
            string childName,
            out XElement child_OrDefault)
        {
            foreach (var container in containers)
            {
                var has_Child = this.Has_Child_First(
                    container,
                    childName,
                    out child_OrDefault);

                if (has_Child)
                {
                    return true;
                }
            }

            child_OrDefault = default;

            return false;
        }

        public bool Has_Child(
            IEnumerable<XContainer> containers,
            string childName,
            out XElement child_OrDefault)
            => this.Has_Child_First(
                containers,
                childName,
                out child_OrDefault);

        public bool Has_Child_First(
            XContainer container,
            string childName,
            out XElement child_OrDefault)
        {
            child_OrDefault = this.Enumerate_Children(container)
                .Where_NameIs(childName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(child_OrDefault);
            return output;
        }

        public bool Has_Child_First(
            XContainer container,
            string childName)
            => this.Has_Child_First(
                container,
                childName,
                out _);

        /// <summary>
        /// Chooses <see cref="Has_Child_First(XContainer, string, out XElement)"/> as the default.
        /// </summary>
        public bool Has_Child(
            XContainer container,
            string childName,
            out XElement child_OrDefault)
        {
            var output = this.Has_Child_First(
                container,
                childName,
                out child_OrDefault);

            return output;
        }

        public bool Has_Child_Value<TValue>(
            XContainer container,
            string childName,
            Func<XElement, TValue> valueSelector,
            out TValue value_OrDefault)
        {
            var output = this.Has_Child(
                container,
                childName,
                out var child_OrDefault);

            value_OrDefault = output
                ? valueSelector(child_OrDefault)
                : default
                ;

            return output;
        }

        public bool Has_Child_Value(
            XContainer container,
            string childName,
            out string value_OrDefault)
            => this.Has_Child_Value(
                container,
                childName,
                Instances.XElementOperator.Get_Value_AsString,
                out value_OrDefault);

        public bool Has_ChildOfChild_First(
            XContainer container,
            string childOfChildName,
            out XElement childOfChild_OrDefault)
        {
            childOfChild_OrDefault = this.Enumerate_ChildrenOfChildren(
                container,
                childOfChildName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(childOfChild_OrDefault);
            return output;
        }

        public bool Has_ChildOfChild_Value_First<TValue>(
            XContainer container,
            string childOfChildName,
            out TValue value_OrDefault,
            Func<XElement, TValue> valueSelector)
        {
            var has_ChildOfChild = this.Has_ChildOfChild_First(
                container,
                childOfChildName,
                out var childOfChild_OrDefault);

            value_OrDefault = has_ChildOfChild
                ? valueSelector(childOfChild_OrDefault)
                : default
                ;

            return has_ChildOfChild;
        }

        public bool Has_ChildOfChild_Value_First(
            XContainer container,
            string childOfChildName,
            out string value_OrDefault)
            => this.Has_ChildOfChild_Value_First(
                container,
                childOfChildName,
                out value_OrDefault,
                Instances.XElementOperator.Get_Value_AsString);

        public bool Has_ChildOfChild_First(
            XContainer container,
            string childName,
            string childOfChildName,
            out XElement childOfChild_OrDefault)
        {
            var children = this.Enumerate_Children(
                container,
                childName);

            var output = this.Has_Child_First(
                children,
                childOfChildName,
                out childOfChild_OrDefault);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_ChildOfChild_First(XContainer, string, string, out XElement)"/> as the default.
        /// </summary>
        public bool Has_ChildOfChild(
            XContainer container,
            string childName,
            string childOfChildName,
            out XElement childOfChild_OrDefault)
        {
            var output = this.Has_ChildOfChild_First(
                container,
                childName,
                childOfChildName,
                out childOfChild_OrDefault);

            return output;
        }

        public bool Has_ChildOfChild_Value_First<TValue>(
            XContainer container,
            string childName,
            string childOfChildName,
            Func<XElement, TValue> valueSelector,
            out TValue value_OrDefault)
        {
            var output = this.Has_ChildOfChild_First(
                container,
                childName,
                childOfChildName,
                out var childOfChild_OrDefault);

            value_OrDefault = output
                ? valueSelector(childOfChild_OrDefault)
                : default
                ;

            return output;
        }

        public bool Has_ChildWithAttributeValue_First(
            XContainer container,
            string attributeName,
            string attributeValue,
            out XElement child_OrDefault)
        {
            var children = this.Enumerate_Children(container);

            child_OrDefault = children
                .Where(Instances.XElementOperations.Has_AttributeWithValue(
                    attributeName,
                    attributeValue))
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(child_OrDefault);
            return output;
        }

        public bool Has_ChildWithAttributeValue_First(
            XContainer container,
            string childName,
            string attributeName,
            string attributeValue,
            out XElement child_OrDefault)
        {
            var children = this.Enumerate_Children(
                container,
                childName);

            child_OrDefault = children
                .Where(Instances.XElementOperations.Has_AttributeWithValue(
                    attributeName,
                    attributeValue))
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(child_OrDefault);
            return output;
        }

        public bool Has_ChildWithChild_First(
            XContainer container,
            string childName,
            string childOfChildName,
            out XElement child_OrDefault)
        {
            var children = this.Enumerate_Children(
                container,
                childName);

            foreach (var child in children)
            {
                var has_Child = this.Has_Child_First(
                    child,
                    childOfChildName);

                if(has_Child)
                {
                    child_OrDefault = child;

                    return true;
                }
            }

            // Failure.
            child_OrDefault = default;

            return false;
        }
    }
}
