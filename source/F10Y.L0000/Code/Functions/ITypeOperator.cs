using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITypeOperator
    {
        public string Get_TypeName(Type type)
        {
            var output = type.FullName;
            return output;
        }

        /// <inheritdoc cref="Get_TypeName(Type)"/>
        public string Get_TypeNameOf<T>()
        {
            var type = this.Get_TypeOf<T>();

            // The full name corresponds to our concept of type name.
            var typeName = this.Get_TypeName(type);
            return typeName;
        }

        /// <summary>
		/// Gets the type of the <typeparamref name="T"/>.
		/// Note: same as the typeof() operator.
		/// </summary>
		public Type Get_TypeOf<T>()
        {
            var output = typeof(T);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_TypeOf_ImplementationType{T}(T)"/>.
        /// </summary>
        public Type Get_TypeOf<T>(T instance)
            => this.Get_TypeOf_ImplementationType(instance);

        public Type Get_TypeOf_ImplementationType<T>(T instance)
        {
            var output = instance.GetType();
            return output;
        }

        /// <summary>
        /// Identical to <see cref="Get_TypeOf{T}()"/>.
        /// </summary>
        public Type Get_TypeOf_DeclaredType<T>(T instance)
            => this.Get_TypeOf<T>();
    }
}
