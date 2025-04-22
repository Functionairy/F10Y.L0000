using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IXElementOperator
    {
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
            string childElementName)
            => Instances.XContainerOperator.Acquire_Child(
                element,
                childElementName);

        public XAttribute Add_Attribute(XElement element, string attributeName)
        {
            var attribute = Instances.XAttributeOperator.New_Attribute(attributeName);

            element.Add(attribute);

            return attribute;
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

        public IEnumerable<XAttribute> Get_Attributes(XElement element)
        {
            return element.Attributes();
        }

        /// <summary>
        /// Chooses <see cref="Has_Attribute_First(XElement, string, out XAttribute)"/> as the default.
        /// </summary>
        public bool Has_Attribute(
            XElement element,
            string attributeName,
            out XAttribute attribute_OrDefault)
        {
            return this.Has_Attribute_First(element, attributeName, out attribute_OrDefault);
        }

        public bool Has_Attribute_First(
            XElement element,
            string attributeName,
            out XAttribute attributeOrDefault)
        {
            attributeOrDefault = this.Get_Attributes(element)
                .Where_NameIs(attributeName)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(attributeOrDefault);
            return output;
        }

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
        /// Quality-of-life overload for <see cref="New(string)"/>.
        /// </summary>
        public XElement Create_Element_FromName(string elementName)
            => this.New(elementName);

        /// <summary>
        /// Chooses <see cref="Create_Element_FromName(string)"/> as the default.
        /// </summary>
        public XElement Create_Element(string elementName)
            => this.Create_Element_FromName(elementName);

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
        public XElement Parse(string text)
            => this.Parse_PreserveWhitespace(text);

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

        public Action<XElement> Get_Set_Attribute_Value(
            string attributeName,
            string attributeValue)
            => element => this.Set_Attribute_Value(
                element,
                attributeName,
                attributeValue);

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

        public string To_String(XElement xElement)
            => xElement.ToString();

        public IEnumerable<XElement> Where_NameIs(IEnumerable<XElement> elements, string elementName)
        {
            var predicate = this.Get_Is_Name(elementName);

            var output = elements
                .Where(predicate)
                ;

            return output;
        }

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
    }
}
