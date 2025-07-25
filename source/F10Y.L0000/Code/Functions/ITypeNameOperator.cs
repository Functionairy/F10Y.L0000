using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITypeNameOperator
    {
        public string Get_TypeName_Full(Type type)
        {
            var output = type.FullName;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_TypeName_Full(Type)"/> as the default.
        /// </summary>
        public string Get_TypeName(Type type)
        {
            var output = this.Get_TypeName_Full(type);
            return output;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_ImplementationType{T}(T)"/>
        public string Get_TypeNameOf_ImplementationType<T>(T value)
        {
            var type = Instances.TypeOperator.Get_Type_ImplementationType(value);

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}()"/>
        public string Get_TypeNameOf_DeclaredType<T>()
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType<T>();

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <inheritdoc cref="ITypeOperator.Get_Type_DeclaredType{T}(T)"/>
        public string Get_TypeNameOf_DeclaredType<T>(T instance)
        {
            var type = Instances.TypeOperator.Get_Type_DeclaredType(instance);

            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_TypeNameOf_DeclaredType{T}()"/>.
        /// <para>
        /// <inheritdoc cref="Get_TypeNameOf_DeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        public string Get_TypeNameOf<T>()
        {
            var output = this.Get_TypeNameOf_DeclaredType<T>();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_TypeNameOf_ImplementationType{T}(T)"/> as the default.
        /// <para>
        /// <inheritdoc cref="Get_TypeNameOf_ImplementationType{T}(T)" path="/summary"/>
        /// </para>
        /// </summary>
        public string Get_TypeNameOf<T>(T instance)
        {
            var output = this.Get_TypeNameOf_ImplementationType(instance);
            return output;
        }

        public bool Is_TypeName<T>(
            string typeName,
            out string typeName_OfTypeParameter)
        {
            typeName_OfTypeParameter = this.Get_TypeNameOf<T>();

            var output = typeName_OfTypeParameter == typeName;
            return output;
        }

        public void Verify_TypeName<T>(string typeName)
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
