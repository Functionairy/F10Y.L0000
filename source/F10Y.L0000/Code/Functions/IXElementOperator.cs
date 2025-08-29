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
    [FunctionsMarker]
    public partial interface IXElementOperator :
        IXContainerOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public IXContainerOperator _XContainerOperator => XContainerOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Acquires an attribute with the specified name.
        /// </summary>
        public XAttribute Acquire_Attribute(
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

        public XElement Acquire_Child(
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

        public XElement Acquire_ChildOfChild(
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

        public XElement Acquire_Child(
            XElement element,
            string childElementName)
            => Instances.XContainerOperator.Acquire_Child(
                element,
                childElementName);

        public XAttribute Add_Attribute(
            XElement element,
            string attributeName)
        {
            var attribute = Instances.XAttributeOperator.New_Attribute(attributeName);

            element.Add(attribute);

            return attribute;
        }

        public XAttribute Add_Attribute(
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
        public void Add_Child(
            XElement parent,
            XElement child)
            => this.Append_Child(
                parent,
                child);

        public void Append_Child(
            XElement parent,
            XElement child)
            => Instances.XContainerOperator.Append_Child(
                parent,
                child);

        public XElement Append_Child(
            XElement parent,
            string childName)
            => Instances.XContainerOperator.Append_Child(
                parent,
                childName);

        public XElement Append_Child(
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

        public XElement Append_Child(
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
        public XElement Add_Child(
            XElement parent,
            string childName,
            string childValue)
            => this.Append_Child(
                parent,
                childName,
                childValue);

        public Action<XElement> Get_Add_Child(
            string childName,
            string childValue)
            => parent => this.Add_Child(
                parent,
                childName,
                childValue);

        /// <summary>
        /// Quality-of-life overload for <see cref="Add_Child(XElement, string, IEnumerable{Action{XElement}})"/>.
        /// </summary>
        public XElement Add_Child(
            XElement parent,
            string childName,
            IEnumerable<Action<XElement>> childActions)
            => this.Append_Child(
                parent,
                childName,
                childActions);

        public IEnumerable<XAttribute> Enumerate_Attrbutes(XElement element)
            => element.Attributes();

        public IEnumerable<XAttribute> Enumerate_Attrbutes(
            XElement element,
            string attributeName)
            => element.Attributes(attributeName);

        public IEnumerable<XAttribute> Enumerate_Attrbutes(
            XElement element,
            XName attributeName)
            => element.Attributes(attributeName);

        public IEnumerable<XElement> Enumerate_ChildElements(XElement element)
        {
            var output = element.Elements();
            return output;
        }

        public IEnumerable<XNode> Enumerate_ChildNodes(XElement element)
        {
            var output = element.Nodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_ChildNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_ChildNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public IEnumerable<XElement> Enumerate_DescendantElements(XElement element)
        {
            var output = element.Descendants();
            return output;
        }

        public IEnumerable<XNode> Enumerate_DescendantNodes(XElement element)
        {
            var output = element.DescendantNodes();
            return output;
        }

        public IEnumerable<TNode> Enumerate_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodes(element)
                .OfType<TNode>()
                ;

            return output;
        }

        public IEnumerable<XText> Enumerate_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantNodesOfType<XText>(element);
            return output;
        }

        public Action<XElement> Get_Add_Child(
            string childName,
            params Action<XElement>[] childActions)
            => this.Get_Add_Child(
                childName,
                childActions.AsEnumerable());

        public Action<XElement> Get_Add_Child(
            string childName,
            IEnumerable<Action<XElement>> childActions)
            => parent => this.Add_Child(
                parent,
                childName,
                childActions);

        public XAttribute Get_Attribute(
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

        public TValue Get_Attribute_Value<TValue>(
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

        public string Get_Attribute_Value(
            XElement element,
            string attributeName)
            => this.Get_Attribute_Value(
                element,
                attributeName,
                Instances.XAttributeOperator.Get_Value_AsString);

        public IEnumerable<XAttribute> Get_Attributes(XElement element)
            => element.Attributes();

        public bool Has_Attribute_First(
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
        public bool Has_Attribute(
            XElement element,
            string attributeName,
            out XAttribute attribute_OrDefault)
            => this.Has_Attribute_First(
                element,
                attributeName,
                out attribute_OrDefault);

        public bool Has_AttributeValue(
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

        public bool Has_AttributeValue<TValue>(
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

        public bool Has_AttributeWithValue_Any(
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
        public bool Has_AttributeWithValue(
            XElement element,
            string attributeName,
            string attributeValue)
            => this.Has_AttributeWithValue_Any(element, attributeName, attributeValue);

        public bool Has_AttributeWithValue_First(
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

        public bool Has_FirstChildNode(
            XElement element,
            out XNode firstChildNode_OrDefault)
        {
            firstChildNode_OrDefault = this.Enumerate_ChildNodes(element)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(firstChildNode_OrDefault);
            return output;
        }

        /// <inheritdoc cref="Is_Name(XElement, string)"/>
        public bool Name_Is(XElement element, string elementName)
        {
            return this.Is_Name(element, elementName);
        }

        /// <summary>
        /// Constructs a new <see cref="XElement"/> using the default XElement name (<see cref="IValues.XElementName_Default"/>).
        /// XElements cannot be constructed without a name, but you can change the name after construction.
        /// You might want to just construct an element, then set its name (as in this method).
        /// The default name is used to allow this.
        /// </summary>
        public XElement New()
            => new XElement(
                Instances.Values.XElementName_Default);

        public XElement New(string elementName)
            => new XElement(elementName);

        public XElement New(
            string elementName,
            params Action<XElement>[] elementActions)
            => this.New(
                elementName,
                elementActions.AsEnumerable());

        public XElement New(
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
        public XElement Clone(XElement element)
        {
            // Use the constructor.
            var output = new XElement(element);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="New(string)"/>.
        /// </summary>
        public XElement Create_Element_FromName(string elementName)
            => this.New(elementName);

        /// <summary>
        /// Chooses <see cref="Create_Element_FromName(string)"/> as the default.
        /// </summary>
        public XElement Create_Element(string elementName)
            => this.Create_Element_FromName(elementName);

        public XElement Create_Element(
            string elementName,
            IEnumerable<Action<XElement>> elementActions)
            => this.New(
                elementName,
                elementActions);

        public XElement Create_Element(
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
        public XElement Deep_Copy(XElement element)
        {
            return this.Clone(element);
        }

        /// <summary>
        /// Loads while preserving insignificant whitespace. (<see cref="LoadOptions.PreserveWhitespace"/>)
        /// </summary>
        public Task<XElement> Load_PreserveWhitespace(string xmlFilePath)
            => this.Load(
                xmlFilePath,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Load_PreserveWhitespace(string)"/> as the default.
        /// </summary>
        public Task<XElement> Load(string xmlFilePath)
            => this.Load_PreserveWhitespace(xmlFilePath);

        public async Task<XElement> Load(
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

        public XElement Load_PreserveWhitespace_Synchronous(string xmlFilePath)
            => this.Load_Synchronous(
                xmlFilePath,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Load_PreserveWhitespace_Synchronous(string)"/> as the default.
        /// </summary>
        public XElement Load_Synchronous(string xmlFilePath)
            => this.Load_PreserveWhitespace_Synchronous(xmlFilePath);

        /// <summary>
        /// The default <see cref="LoadOptions.PreserveWhitespace"/> value removes (insignificant) whitespace.
        /// </summary>
        public XElement Load_WithoutInsignificantWhitespace_Synchronous(string xmlFilePath)
            => XElement.Load(xmlFilePath);

        public XElement Load_Synchronous(
            string xmlFilePath,
            LoadOptions loadOptions)
            => XElement.Load(
                xmlFilePath,
                loadOptions);

        public XElement Parse(
            string text,
            LoadOptions loadOptions)
            => XElement.Parse(
                text,
                loadOptions);

        public XElement Parse_PreserveWhitespace(string text)
            => this.Parse(
                text,
                Instances.LoadOptionsSet.PreserveWhitespace);

        /// <summary>
        /// Chooses <see cref="Parse_PreserveWhitespace(string)"/> as the default.
        /// </summary>
        public XElement Parse(string xmlText)
            => this.Parse_PreserveWhitespace(xmlText);

        /// <summary>
        /// Uses <see cref="IXmlWriterSettingsSet.OmitXmlDeclaration_Asynchronous"/>.
        /// </summary>
        public Task Save_WithoutXmlDeclaration(
            XElement element,
            string xmlFilePath)
            => this.Save(
                element,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Asynchronous);

        /// <summary>
        /// Uses <see cref="IXmlWriterSettingsSet.OmitXmlDeclaration_Fragment_Asynchronous"/>.
        /// </summary>
        public Task Save_WithoutXmlDeclaration(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            => this.Save(
                elements,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Fragment_Asynchronous);

        /// <summary>
        /// Chooses <see cref="Save_WithoutXmlDeclaration(XElement, string)"/> as the default.
        /// </summary>
        public Task Save(
            XElement element,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        public async Task Save(
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

        public async Task Save(
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
        public Task Save(
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
        public Task Save(
            IEnumerable<XElement> elements,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                elements,
                xmlFilePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Save(XElement, string, XmlWriterSettings)"/>.
        /// </summary>
        public Task To_File(
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
        public void Save_Synchronous(
            XElement element,
            string xmlFilePath)
            => this.Save_Synchronous(
                element,
                xmlFilePath,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        public void Save_Synchronous(
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
        public void Save_WithReformattingAndAddedDeclaration_Synchronous(
            XElement element,
            string xmlFilePath)
            => element.Save(xmlFilePath);

        public void Save_Synchronous(
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
        public XAttribute Set_Attribute_Value_Acquire(
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
        public XAttribute Set_Attribute_Value_Get(
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
        public XAttribute Set_Attribute_Value(
            XElement element,
            string attributeName,
            string attributeValue)
            => this.Set_Attribute_Value_Acquire(
                element,
                attributeName,
                attributeValue);

        public void Set_Name(
            XElement element,
            string name)
            => element.Name = name;

        public void Set_Value(
            XElement element,
            string value)
            => element.Value = value;

        public void Set_Value<TValue>(
            XElement element,
            TValue value,
            Func<TValue, string> converter)
        {
            var value_AsString = converter(value);

            this.Set_Value(
                element,
                value_AsString);
        }

        public Action<XElement> Get_Set_Attribute_Value(
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
        public string Get_Value(XElement element)
        {
            var output = element.Value;
            return output;
        }

        public bool Get_Value_AsBoolean(XElement element)
        {
            var value = this.Get_Value(element);

            var output = Instances.BooleanOperator.From(value);
            return output;
        }

        public Version Get_Value_AsVersion(XElement element)
        {
            var value = this.Get_Value(element);

            var output = Instances.VersionOperator.From(value);
            return output;
        }

        /// <summary>
        /// Overload of <see cref="Get_Value(XElement)"/>.
        /// </summary>
        public string Get_Value_AsString(XElement element)
            => this.Get_Value(element);

        /// <summary>
        /// Chooses <see cref="Get_ChildElement_ByLocalName(XElement, string)"/> as the default.
        /// </summary>
        public XElement Get_ChildElement(
            XElement element,
            string childName)
        {
            var output = this.Get_ChildElement_ByLocalName(
                element,
                childName);

            return output;
        }

        public XElement Get_ChildElement_ByLocalName(
            XElement element,
            string childName)
        {
            var output = this.Enumerate_ChildElements(element)
                .Where_NameIs(childName)
                .FirstOrDefault();

            return output;
        }

        public TNode[] Get_DescendantNodesOfType<TNode>(XElement element)
            where TNode : XNode
        {
            var output = this.Enumerate_DescendantNodesOfType<TNode>(element)
                .ToArray();

            return output;
        }

        public XText[] Get_DescendantTextNodes(XElement element)
        {
            var output = this.Enumerate_DescendantTextNodes(element)
                .ToArray();

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Value(XElement)"/>
        /// </summary>
        public string Get_InnerText(XElement element)
            => this.Get_Value(element);

        /// <summary>
        /// Gets the inner XML of the element (text including XML tags).
        /// To get the inner text of the element, without any XML tags, use <see cref="Get_Value(XElement)"/>.
        /// </summary>
        /// <remarks>
        /// Source: https://stackoverflow.com/questions/3793/best-way-to-get-innerxml-of-an-xelement
        /// </remarks>
        public string Get_InnerXml(XElement element)
        {
            using var reader = element.CreateReader();

            reader.MoveToContent();

            var output = reader.ReadInnerXml();
            return output;
        }

        /// <summary>
        /// A quality-of-life overload for <see cref="Save_WithoutXmlDeclaration(XElement, string)"/>.
        /// </summary>
        public Task To_File_WithoutXmlDeclaration(
            XElement element,
            string xmlFilePath)
            => this.Save_WithoutXmlDeclaration(
                element,
                xmlFilePath);

        public string To_Text(
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

        public string To_Text_WithoutXmlDeclaration(XElement element)
            => this.To_Text(
                element,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        /// <summary>
        /// Chooses <see cref="To_Text_WithoutXmlDeclaration(XElement)"/> as the default.
        /// </summary>
        public string To_Text(XElement element)
            => this.To_Text_WithoutXmlDeclaration(element);

        public string[] To_Text_AsLines(
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

        public string[] To_Text_AsLines_WithoutXmlDeclaration(XElement element)
            => this.To_Text_AsLines(
                element,
                Instances.XmlWriterSettingsSet.OmitXmlDeclaration_Synchronous);

        /// <summary>
        /// Chooses <see cref="To_Text_AsLines_WithoutXmlDeclaration(XElement)"/> as the default.
        /// </summary>
        public string[] To_Text_AsLines(XElement element)
            => this.To_Text_AsLines_WithoutXmlDeclaration(element);

        public string To_String(XElement xElement)
            => xElement.ToString();

        public Func<XElement, bool> Get_Is_Name(string elementName)
            => this.Get_Is_LocalName(elementName);

        public Func<XElement, bool> Get_Is_LocalName(string elementName)
            => element => this.Is_LocalName(
                element,
                elementName);

        /// <summary>
        /// Chooses <see cref="Get_Name_AsString(XElement)"/> as the default.
        /// </summary>
        public string Get_Name(XElement element)
            => this.Get_Name_AsString(element);

        public XName Get_Name_AsXName(XElement element)
            => element.Name;

        public string Get_Name_AsString(XElement element)
        {
            var name = this.Get_Name_AsXName(element);

            var output = Instances.XNameOperator.Get_Name(name);
            return output;
        }

        public bool Is_LocalName(XElement element, string elementName)
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
        public bool Is_Name(XElement element, string elementName)
            => this.Is_LocalName(element, elementName);

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, string elementName)
        {
            var predicate = this.Get_Is_Name(elementName);

            var output = elements
                .Where(predicate)
                ;

            return output;
        }

        public void Verify_NameIs(
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

        //public IEnumerable<XElement> Where_HasAttibuteWithValue(
        //    IEnumerable<XElement> elements,
        //    string attributeName,
        //    string attibuteValue)
        //{

        //}
    }
}
