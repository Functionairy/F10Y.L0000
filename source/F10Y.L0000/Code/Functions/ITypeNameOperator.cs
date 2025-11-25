using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface ITypeNameOperator
    {
        string Append_NestedTypeName(
            string nestedParentTypeName,
            string typeName)
        {
            var output = $"{nestedParentTypeName}{Instances.TokenSeparators.NestedTypeNameTokenSeparator}{typeName}";
            return output;
        }

        string Get_TypeName_Full(Type type)
        {
            var output = type.FullName;
            return output;
        }

        string Get_TypeName_Short(Type type)
        {
            var output = type.Name;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_TypeName_Full(Type)"/> as the default.
        /// </summary>
        string Get_TypeName(Type type)
        {
            var output = this.Get_TypeName_Full(type);
            return output;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_ImplementationType{T}(T)"/>
        string Get_TypeName_OfImplementationType<T>(T value)
        {
            var type = Instances.TypeOperator.Get_Type_ImplementationType(value);

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_ImplementationType{T}(T)"/>
        string Get_TypeName_Short_OfImplementationType<T>(T value)
        {
            var type = Instances.TypeOperator.Get_Type_ImplementationType(value);

            var typeName = this.Get_TypeName_Short(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}()"/>
        string Get_TypeName_OfDeclaredType<T>()
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType<T>();

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}()"/>
        string Get_TypeName_Short_OfDeclaredType<T>()
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType<T>();

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}(T)"/>
        string Get_TypeName_OfDeclaredType<T>(T instance)
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType(instance);

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}(T)"/>
        string Get_TypeName_Short_OfDeclaredType<T>(T instance)
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType(instance);

            var typeName = this.Get_TypeName_Short(type);
            return typeName;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_TypeName_OfDeclaredType{T}()"/>.
        /// <para>
        /// <inheritdoc cref="Get_TypeName_OfDeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        string Get_TypeName_Of<T>()
        {
            var output = this.Get_TypeName_OfDeclaredType<T>();
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_TypeName_OfDeclaredType{T}()"/>.
        /// <para>
        /// <inheritdoc cref="Get_TypeName_OfDeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        string Get_TypeName_Short_Of<T>()
        {
            var output = this.Get_TypeName_Short_OfDeclaredType<T>();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_TypeName_OfImplementationType{T}(T)"/> as the default.
        /// <para>
        /// <inheritdoc cref="Get_TypeName_OfImplementationType{T}(T)" path="/summary"/>
        /// </para>
        /// </summary>
        string Get_TypeNameOf<T>(T instance)
        {
            var output = this.Get_TypeName_OfImplementationType(instance);
            return output;
        }

        /// <summary>
        /// NOTE: will return "T"!
        /// </summary>
        string Get_NameOf<T>()
            => nameof(T);

        /// <summary>
        /// NOTE: will return "T"!
        /// </summary>
        string Get_NameOf<T>(T value)
            => nameof(T);

        bool Is_TypeName<T>(
            string typeName,
            out string typeName_OfTypeParameter)
        {
            typeName_OfTypeParameter = this.Get_TypeName_Of<T>();

            var output = typeName_OfTypeParameter == typeName;
            return output;
        }

        void Verify_TypeName<T>(string typeName)
        {
            var is_TypeName = this.Is_TypeName<T>(
                typeName,
                out var typeName_OfTypeParameter);

            if (!is_TypeName)
            {
                throw new Exception($"Type name mismatch. Expected: {typeName_OfTypeParameter}, found: {typeName}");
            }
        }
    }
}
