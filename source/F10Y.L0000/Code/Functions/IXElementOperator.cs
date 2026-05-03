using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0002;
using F10Y.T0011;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IXElementOperator :
        IXContainerOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        IXContainerOperator _XContainerOperator => XContainerOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Acquires an attribute with the specified name.
        /// </summary>
        XAttribute Acquire_Attribute(
            XElement element,
            string attributeName)
        {
            var hasAttribute = this.Has_Attribute(
                element,
                attributeName,
                out var attribute);

            if (!hasAttribute)
            {
                attribute = this.Add_Attribute(
                    element,
                    attributeName);
            }

            return attribute;
        }

        XElement Acquire_Child(
            XElement element,
            Func<XElement, XElement> select_Child_OrDefault,
            string childName)
        {
            var child_OrDefault = select_Child_OrDefault(element);

            var is_Default = Instances.DefaultOperator.Is_Default(child_OrDefault);

            var output = is_Default
                ? this.Append_Child(
                    element,
                    childName)
                : child_OrDefault
                ;

            return output;
        }

        XElement Acquire_ChildOfChild(
            XElement element,
            Func<XElement, XElement> select_Child_OrDefault,
            string childName,
            string childOfChildName)
        {
            var child = this.Acquire_Child(
                element,
                select_Child_OrDefault,
                childName);

            var output = this.Acquire_Child(
                child,
                childOfChildName);

            return output;
        }

        XElement Acquire_Child(
            XElement element,
            string childElementName)
            => Instances.XContainerOperator.Acquire_Child(
                element,
                childElementName);

        XAttribute Add_Attribute(
            XElement element,
            string attributeName)
        {
            var attribute = Instances.XAttributeOperator.Create(attributeName);

            this.Add_Attribute(
                element,
                attribute);

            return attribute;
        }

        void Add_Attribute(
            XElement element,
            XAttribute attribute)
            => element.Add(attribute);

        XAttribute Add_Attribute(
            XElement element,
            string attributeName,
            string attributeValue)
        {
            var output = this.Add_Attribute(
                element,
                attributeName);

            Instances.XAttributeOperator.Set_Value(
                output,
                attributeValue);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Append_Child(XElement, XElement)"/>.
        /// </summary>
        void Add_Child(
            XElement parent,
            XElement child)
            => this.Append_Child(
                parent,
                child);

        void Append_Child(
            XElement parent,
            XElement child)
            => Instances.XContainerOperator.Append_Child(
                parent,
                child);

        XElement Append_Child(
            XElement parent,
            string childName)
            => Instances.XContainerOperator.Append_Child(
                parent,
                childName);

        XElement Append_Child(
            XElement parent,
            string childName,
            IEnumerable<Action<XElement>> childActions)
        {
            var output = Instances.XElementOperator.New(
                childName,
                childActions);

            this.Append_Child(
                parent,
                output);

            return output;
        }

        XElement Append_Child(
            XElement parent,
            string childName,
            string childValue)
        {
            var output = this.Append_Child(
                parent,
                childName);

            Instances.XElementOperator.Set_Value(
                output,
                childValue);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Append_Child(XElement, string, string)"/>.
        /// </summary>
        XElement Add_Child(
            XElement parent,
            string childName,
            string childValue)
            => this.Append_Child(
                parent,
                childName,
                childValue);

        Action<XElement> Get_Add_Child(
            string childName,
            string childValue)
            => parent => this.Add_Child(
                parent,
                childName,
                childValue);

        /// <summary>
        /// Quality-of-life overload for <see cref="Add_Child(XElement, string, IEnumerable{Action{XElement}})"/>.
        /// </summary>
        XElement Add_Child(
            XElement parent,
            string childName,
            IEnumerable<Action<XElement>> childActions)
            => this.Append_Child(
                parent,
                childName,
                childActions);

        IEnumerable<XAttribute> Enumerate_Attrbutes(XElement element)
            => element.Attributes();

        IEnumerable<XAttribute> Enumerate_Attrbutes(
            XElement element,
            string attributeName)
            => element.Attributes(attributeName);

        IEnumerable<XAttribute> Enumerate_Attrbutes(
            XElement element,
            XName attributeName)
            => element.Attributes(attributeName);

        IEnumerable<XElement> Enumerate_ChildElements(XElement element)
        {
            var output = element.Elements();
            return output;
        }

        /// <summary>
        /// Clones child elements.
        /// </summary>
        IEnumerable<XElement> Enumerate_ChildElements_Cloned(XElement element)
            => this.Enumerate_ChildElements(element)
                .Select(this.Clone);

        IEnumerable<XNode> Enumerate_ChildNodes(XElement element)
        {
            var output = element.Nodes();
            return output;
        }

        IEnumerable<TNode> Enumerate_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        IEnumerable<XElement> Enumerate_DescendantElements(XElement element)
        {
            var output = element.Descendants();
            return output;
        }

        IEnumerable<XNode> Enumerate_DescendantNodes(XElement element)
        {
            var output = element.DescendantNodes();
            return output;
        }

        IEnumerable<TNode> Enumerate_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        IEnumerable<XText> Enumerate_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantNodesOfType<XText>(element);
            return output;
        }

        Action<XElement> Get_Add_Child(
            string childName,
            params Action<XElement>[] childActions)
            => this.Get_Add_Child(
                childName,
                childActions.AsEnumerable());

        Action<XElement> Get_Add_Child(
            string childName,
            IEnumerable<Action<XElement>> childActions)
            => parent => this.Add_Child(
                parent,
                childName,
                childActions);

        XAttribute Get_Attribute(
            XElement element,
            string attributeName)
        {
            var hasAttribute = this.Has_Attribute(
                element,
                attributeName,
                out var attribute);

            if (!hasAttribute)
            {
                throw Instances.ExceptionOperator.Get_AttributeNotFoundException(attributeName);
            }

            return attribute;
        }

        TValue Get_Attribute_Value<TValue>(
            XElement element,
            string attributeName,
            Func<XAttribute, TValue> valueSelector)
        {
            var attribute = this.Get_Attribute(
                element,
                attributeName);

            var output = valueSelector(attribute);
            return output;
        }

        string Get_Attribute_Value(
            XElement element,
            string attributeName)
            => this.Get_Attribute_Value(
                element,
                attributeName,
                Instances.XAttributeOperator.Get_Value_AsString);

        IEnumerable<XAttribute> Get_Attributes(XElement element)
            => element.Attributes();

        bool Has_Attribute_First(
            XElement element,
            string attributeName,
            out XAttribute attribute_OrDefault)
        {
            attribute_OrDefault = this.Get_Attributes(element)
                .Where_NameIs(attributeName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attribute_OrDefault);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_Attribute_First(XElement, string, out XAttribute)"/> as the default.
        /// </summary>
        bool Has_Attribute(
            XElement element,
            string attributeName,
            out XAttribute attribute_OrDefault)
            => this.Has_Attribute_First(
                element,
                attributeName,
                out attribute_OrDefault);

        bool Has_AttributeValue(
            XElement element,
            string attributeName,
            out string value_OrDefault)
        {
            var has_Attribute = this.Has_Attribute(
                element,
                attributeName,
                out var attribute_OrDefault);

            value_OrDefault = has_Attribute
                ? Instances.XAttributeOperator.Get_Value(attribute_OrDefault)
                : default
                ;

            return has_Attribute;
        }

        bool Has_AttributeValue<TValue>(
            XElement element,
            string attributeName,
            out TValue value_OrDefault,
            Func<string, TValue> converter)
        {
            var has_Attribute = this.Has_AttributeValue(
                element,
                attributeName,
                out var value_OrDefault_AsString);

            value_OrDefault = has_Attribute
                ? converter(value_OrDefault_AsString)
                : default
                ;

            return has_Attribute;
        }

        bool Has_AttributeWithValue_Any(
            XElement element,
            string attributeName,
            string attributeValue)
        {
            var attibutes = this.Enumerate_Attrbutes(
                element,
                attributeName);

            var output = attibutes
                .Where(Instances.XAttributeOperations.Is_Value(attributeValue))
                .Any();

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_AttributeWithValue_Any(XElement, string, string)"/> as the default.
        /// </summary>
        bool Has_AttributeWithValue(
            XElement element,
            string attributeName,
            string attributeValue)
            => this.Has_AttributeWithValue_Any(element, attributeName, attributeValue);

        bool Has_AttributeWithValue_First(
            XElement element,
            string attributeName,
            string attributeValue,
            out XAttribute attribute_OrDefault)
        {
            var attibutes = this.Enumerate_Attrbutes(
                element,
                attributeName);

            attribute_OrDefault = attibutes
                .Where(Instances.XAttributeOperations.Is_Value(attributeValue))
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attribute_OrDefault);
            return output;
        }

        bool Has_Children_Any(XElement element)
            => element.HasElements;

        bool Has_DescendantElement_FirstOrDefault(
            XElement element,
            Func<XElement, bool> predicate,
            out XElement descendant_FirstOrDefault)
            => Instances.EnumerationOperator.Has_FirstOrDefault(
                this.Enumerate_DescendantElements(element),
                predicate,
                out descendant_FirstOrDefault);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Has_DescendantElement_FirstOrDefault(XElement, Func{XElement, bool}, out XElement)"/> as the default.
        /// </remarks>
        bool Has_DescendantElement(
            XElement element,
            Func<XElement, bool> predicate,
            out XElement descendant_FirstOrDefault)
            => this.Has_DescendantElement_FirstOrDefault(
                element,
                predicate,
                out descendant_FirstOrDefault);

        bool Has_DescendantElement_OfName_FirstOrDefault(
            XElement element,
            string descendantElement_Name,
            out XElement descendant_FirstOrDefault)
        {
            var predicate = Instances.XElementOperations.Name_Is(descendantElement_Name);

            var output = this.Has_DescendantElement_FirstOrDefault(
                element,
                predicate,
                out descendant_FirstOrDefault);

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Has_DescendantElement_OfName_FirstOrDefault(XElement, string, out XElement)"/> as the default.
        /// </remarks>
        bool Has_DescendantElement_OfName(
            XElement element,
            string descendantElement_Name,
            out XElement descendant_FirstOrDefault)
            => this.Has_DescendantElement_OfName_FirstOrDefault(
                element,
                descendantElement_Name,
                out descendant_FirstOrDefault);

        bool Has_FirstChildNode(
            XElement element,
            out XNode firstChildNode_OrDefault)
        {
            firstChildNode_OrDefault = this.Enumerate_ChildNodes(element)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(firstChildNode_OrDefault);
            return output;
        }

        /// <inheritdoc cref="Is_Name(XElement, string)"/>
        bool Name_Is(XElement element, string elementName)
        {
            return this.Is_Name(element, elementName);
        }

        /// <summary>
        /// Constructs a new <see cref="XElement"/> using the default XElement name (<see cref="IValues.XElementName_Default"/>).
        /// XElements cannot be constructed without a name, but you can change the name after construction.
        /// You might want to just construct an element, then set its name (as in this method).
        /// The default name is used to allow this.
        /// </summary>
        XElement New()
            => new XElement(
                Instances.Values.XElementName_Default);

        XElement New(string elementName)
            => new XElement(elementName);

        XElement New(
            string elementName,
            params Action<XElement>[] elementActions)
            => this.New(
                elementName,
                elementActions.AsEnumerable());

        XElement New(
            string elementName,
            IEnumerable<Action<XElement>> elementActions)
        {
            var output = this.New(elementName);

            Instances.ActionOperator.Run_Actions(
                output,
                elementActions);

            return output;
        }

        /// <summary>
        /// Creates a separate, but identical instance.
        /// <para>Same as <see cref="Deep_Copy(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0000.Documentation.For_Xml.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        XElement Clone(XElement element)
        {
            // Use the constructor.
            var output = new XElement(element);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="New(string)"/>.
        /// </summary>
        XElement Create_Element_FromName(string elementName)
            => this.New(elementName);

        /// <summary>
        /// Chooses <see cref="Create_Element_FromName(string)"/> as the default.
        /// </summary>
        XElement Create_Element(string elementName)
            => this.Create_Element_FromName(elementName);

        XElement Create_Element(
            string elementName,
            IEnumerable<Action<XElement>> elementActions)
            => this.New(
                elementName,
                elementActions);

        XElement Create_Element(
            string elementName,
            params Action<XElement>[] elementActions)
            => this.New(
                elementName,
                elementActions);

        /// <summary>
        /// Creates a copy of the element, and all child-nodes.
        /// <para>Same as <see cref="Clone(XElement)"/></para>
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0000.Documentation.For_Xml.WhichXObjectsAreCloneable" path="/summary"/>
        /// </remarks>
        XElement Deep_Copy(XElement element)
        {
            return this.Clone(element);
        }

        /// <summary>
        /// Loads while preserving insignificant whitespace. (<see cref="LoadOptions.PreserveWhitespace"/>)
        /// </summary>
        Task<XElement> Load_PreserveWhitespace(string xmlFilePath)
            => this.Load(
                xmlFilePath,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Load_PreserveWhitespace(string)"/> as the default.
        /// </summary>
        Task<XElement> Load(string xmlFilePath)
            => this.Load_PreserveWhitespace(xmlFilePath);

        async Task<XElement> Load(
            string xmlFilePath,
            LoadOptions loadOptions)
        {
            var fileStream = Instances.FileStreamOperator.Open_Read(xmlFilePath);

            var output = await XElement.LoadAsync(
                fileStream,
                loadOptions,
                Instances.CancellationTokens.None);

            return output;
        }

        XElement Load_PreserveWhitespace_Synchronous(string xmlFilePath)
            => this.Load_Synchronous(
                xmlFilePath,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Load_PreserveWhitespace_Synchronous(string)"/> as the default.
        /// </summary>
        XElement Load_Synchronous(string xmlFilePath)
            => this.Load_PreserveWhitespace_Synchronous(xmlFilePath);

        /// <summary>
        /// The default <see cref="LoadOptions.PreserveWhitespace"/> value removes (insignificant) whitespace.
        /// </summary>
        XElement Load_WithoutInsignificantWhitespace_Synchronous(string xmlFilePath)
            => XElement.Load(xmlFilePath);

        XElement Load_Synchronous(
            string xmlFilePath,
            LoadOptions loadOptions)
            => XElement.Load(
                xmlFilePath,
                loadOptions);

        XElement Parse(
            string text,
            LoadOptions loadOptions)
            => XElement.Parse(
                text,
                loadOptions);

        XElement Parse_PreserveWhitespace(string text)
            => this.Parse(
                text,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Parse_PreserveWhitespace(string)"/> as the default.
        /// </summary>
        XElement Parse(string xmlText)
            => this.Parse_PreserveWhitespace(xmlText);

        /// <summary>
        /// Uses <see cref="IXmlWriterSettingsSet.OmitXmlDeclaration_Asynchronous"/>.
        /// </summary>
        Task Save_WithoutXmlDeclaration(
            XElement element,
            string xmlFilePath)
            => this.Save(
                element,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Asynchronous);

        /// <summary>
        /// Uses <see cref="IXmlWriterSettingsSet.OmitXmlDeclaration_Fragment_Asynchronous"/>.
        /// </summary>
        Task Save_WithoutXmlDeclaration(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            => this.Save(
                elements,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Fragment_Asynchronous);

        /// <summary>
        /// Chooses <see cref="Save_WithoutXmlDeclaration(XElement, string)"/> as the default.
        /// </summary>
        Task Save(
            XElement element,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        async Task Save(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
        {
            using var xmlWriter = Instances.XmlWriterOperator.Create(
                xmlFilePath,
                xmlWriterSettings);

            await element.SaveAsync(
                xmlWriter,
                Instances.CancellationTokens.None);
        }

        async Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings,
            XText elementSeparator)
        {
            using var xmlWriter = Instances.XmlWriterOperator.Create(
                xmlFilePath,
                xmlWriterSettings);

            var elements_Joined = Instances.EnumerableOperator.Join<XNode>(
                elements,
                elementSeparator);

            foreach (var element in elements_Joined)
            {
                element.WriteTo(xmlWriter);
            }

            await xmlWriter.FlushAsync();
        }

        /// <summary>
        /// Uses <see cref="F10Y.L0000.IStrings.NewLine_ForEnvironment"/> as the element separator.
        /// </summary>
        Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => this.Save(
                elements,
                xmlFilePath,
                xmlWriterSettings,
                Instances.XTextOperator.From(
                    Instances.Strings.NewLine_ForEnvironment));

        /// <summary>
        /// Chooses <see cref="Save_WithoutXmlDeclaration(IEnumerable{XElement}, string)"/> as the default.
        /// </summary>
        Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                elements,
                xmlFilePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        Task To_File(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
            => this.Save(
                element,
                xmlFilePath,
                xmlWriterSettings);

        /// <summary>
        /// Uses <see cref="IXmlWriterSettingsSet.OmitXmlDeclaration_Synchronous"/>.
        /// </summary>
        void Save_Synchronous(
            XElement element,
            string xmlFilePath)
            => this.Save_Synchronous(
                element,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        void Save_Synchronous(
            XElement element,
            string xmlFilePath,
            XmlWriterSettings xmlWriterSettings)
        {
            using var xmlWriter = Instances.XmlWriterOperator.Create(
                xmlFilePath,
                xmlWriterSettings);

            element.Save(xmlWriter);
        }

        /// <summary>
        /// The default <see cref="SaveOptions.DisableFormatting"/> value reformats (indents) the XML, and adds an XML declaration.
        /// </summary>
        void Save_WithReformattingAndAddedDeclaration_Synchronous(
            XElement element,
            string xmlFilePath)
            => element.Save(xmlFilePath);

        void Save_Synchronous(
            XElement element,
            string xmlFilePath,
            SaveOptions saveOptions)
            => element.Save(
                xmlFilePath,
                saveOptions);

        /// <summary>
        /// Acquires the attribute and sets its value.
        /// (No exception is thrown if the attribute does not exist.)
        /// </summary>
        XAttribute Set_Attribute_Value_Acquire(
            XElement element,
            string attributeName,
            string attributeValue)
        {
            var attribute = this.Acquire_Attribute(
                element,
                attributeName);

            Instances.XAttributeOperator.Set_Value(
                attribute,
                attributeValue);

            return attribute;
        }

        /// <summary>
        /// Get the attribute and sets its value.
        /// (An exception is thrown if the attribute does not exist.)
        /// </summary>
        XAttribute Set_Attribute_Value_Get(
            XElement element,
            string attributeName,
            string attributeValue)
        {
            var attribute = this.Get_Attribute(
                element,
                attributeName);

            Instances.XAttributeOperator.Set_Value(
                attribute,
                attributeValue);

            return attribute;
        }

        /// <summary>
        /// Chooses <see cref="Set_Attribute_Value_Acquire(XElement, string, string)"/> as the default.
        /// </summary>
        XAttribute Set_Attribute_Value(
            XElement element,
            string attributeName,
            string attributeValue)
            => this.Set_Attribute_Value_Acquire(
                element,
                attributeName,
                attributeValue);

        void Set_Name(
            XElement element,
            string name)
            => element.Name = name;

        void Set_Value(
            XElement element,
            string value)
            => element.Value = value;

        void Set_Value<TValue>(
            XElement element,
            TValue value,
            Func<TValue, string> converter)
        {
            var value_AsString = converter(value);

            this.Set_Value(
                element,
                value_AsString);
        }

        Action<XElement> Get_Set_Attribute_Value(
            string attributeName,
            string attributeValue)
            => element => this.Set_Attribute_Value(
                element,
                attributeName,
                attributeValue);

        /// <summary>
        /// Gets the inner text of the element, without any XML tags.
        /// To get the inner XML of the element (text including XML tags), use <see cref="Get_InnerXml(XElement)"/>.
        /// </summary>
        string Get_Value(XElement element)
        {
            var output = element.Value;
            return output;
        }

        bool Get_Value_AsBoolean(XElement element)
        {
            var value = this.Get_Value(element);

            var output = Instances.BooleanOperator.From(value);
            return output;
        }

        Version Get_Value_AsVersion(XElement element)
        {
            var value = this.Get_Value(element);

            var output = Instances.VersionOperator.From(value);
            return output;
        }

        /// <summary>
        /// Overload of <see cref="Get_Value(XElement)"/>.
        /// </summary>
        string Get_Value_AsString(XElement element)
            => this.Get_Value(element);

        /// <summary>
        /// Chooses <see cref="Get_ChildElement_ByLocalName(XElement, string)"/> as the default.
        /// </summary>
        XElement Get_ChildElement(
            XElement element,
            string childName)
        {
            var output = this.Get_ChildElement_ByLocalName(
                element,
                childName);

            return output;
        }

        XNode[] Get_ChildNodes(XElement element)
        {
            var output = this.Enumerate_ChildNodes(element)
                .ToArray();

            return output;
        }

        XElement Get_ChildElement_ByLocalName(
            XElement element,
            string childName)
        {
            var output = this.Enumerate_ChildElements(element)
                .Where_NameIs(childName)
                .FirstOrDefault();

            return output;
        }

        TNode[] Get_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodesOfType<TNode>(element)
                .ToArray();

            return output;
        }

        XText[] Get_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantTextNodes(element)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Value(XElement)"/>
        /// </summary>
        string Get_InnerText(XElement element)
            => this.Get_Value(element);

        /// <summary>
        /// Gets the inner XML of the element (text including XML tags).
        /// To get the inner text of the element, without any XML tags, use <see cref="Get_Value(XElement)"/>.
        /// </summary>
        /// <remarks>
        /// Source: https://stackoverflow.com/questions/3793/best-way-to-get-innerxml-of-an-xelement
        /// </remarks>
        string Get_InnerXml(XElement element)
        {
            using var reader = element.CreateReader();

            reader.MoveToContent();

            var output = reader.ReadInnerXml();
            return output;
        }

        /// <summary>
        /// A quality-of-life overload for <see cref="Save_WithoutXmlDeclaration(XElement, string)"/>.
        /// </summary>
        Task To_File_WithoutXmlDeclaration(
            XElement element,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        string To_Text(
            XElement element,
            XmlWriterSettings xmlWriterSettings)
        {
            var stringBuilder = new StringBuilder();

            using (var xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
            {
                element.WriteTo(xmlWriter);
            }

            var output = stringBuilder.ToString();
            return output;
        }

        string To_Text_WithoutXmlDeclaration(XElement element)
            => this.To_Text(
                element,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        /// <summary>
        /// Chooses <see cref="To_Text_WithoutXmlDeclaration(XElement)"/> as the default.
        /// </summary>
        string To_Text(XElement element)
            => this.To_Text_WithoutXmlDeclaration(element);

        string[] To_Text_AsLines(
            XElement element,
            XmlWriterSettings xmlWriterSettings)
        {
            var text = this.To_Text(
                element,
                xmlWriterSettings);

            var lines = Instances.StringOperator.Split_Lines(
                text,
                xmlWriterSettings.NewLineChars);

            return lines;
        }

        string[] To_Text_AsLines_WithoutXmlDeclaration(XElement element)
            => this.To_Text_AsLines(
                element,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        /// <summary>
        /// Chooses <see cref="To_Text_AsLines_WithoutXmlDeclaration(XElement)"/> as the default.
        /// </summary>
        string[] To_Text_AsLines(XElement element)
            => this.To_Text_AsLines_WithoutXmlDeclaration(element);

        string To_String(XElement xElement)
            => xElement.ToString();

        Func<XElement, bool> Get_Is_Name(string elementName)
            => this.Get_Is_LocalName(elementName);

        Func<XElement, bool> Get_Is_LocalName(string elementName)
            => element => this.Is_LocalName(
                element,
                elementName);

        /// <summary>
        /// Chooses <see cref="Get_Name_AsString(XElement)"/> as the default.
        /// </summary>
        string Get_Name(XElement element)
            => this.Get_Name_AsString(element);

        XName Get_Name_AsXName(XElement element)
            => element.Name;

        string Get_Name_AsString(XElement element)
        {
            var name = this.Get_Name_AsXName(element);

            var output = Instances.XNameOperator.Get_Name(name);
            return output;
        }

        XElement Get_Parent(XElement element)
            => element.Parent;

        bool Is_LocalName(XElement element, string elementName)
        {
            var name = this.Get_Name_AsXName(element);

            var output = Instances.XNameOperator.Is_LocalName(
                name,
                elementName);

            return output;
        }

        /// <summary>
        /// Uses the <see cref="XName.LocalName"/> property to avoid the crazed namespace BS.
        /// </summary>
        bool Is_Name(XElement element, string elementName)
            => this.Is_LocalName(element, elementName);

        IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, string elementName)
        {
            var predicate = this.Get_Is_Name(elementName);

            var output = elements
                .Where(predicate)
                ;

            return output;
        }

        void Verify_NameIs(
            XElement element,
            string name)
        {
            var nameIs = this.Name_Is(
                element,
                name);

            if (!nameIs)
            {
                var actualName = this.Get_Name(element);

                throw new Exception($"Element did not have expected name '{name}'; name was '{actualName}'.");
            }
        }
    }
}
