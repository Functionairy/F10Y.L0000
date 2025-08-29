using System;
using System.Reflection;
using System.Threading.Tasks.Sources;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITypeOperator
    {
        public bool Are_Equal(
            Type a,
            Type b)
        {
            var output = a.Equals(b);
            return output;
        }

        public Assembly Get_AssemblyForType(Type type)
        {
            var output = type.Assembly;
            return output;
        }

        /// <summary>
        /// Note, includes the generic parameter count. Example: ExampleClass01`1.
        /// <para>Gets the <see cref="MemberInfo.Name"/> of the type.</para>
        /// </summary>
        public string Get_Name(Type type)
            => type.Name;

        /// <summary>
        /// Includes the generic parameter count (example: R5T.T0140.ExampleClass01`1),
        /// and handles nested types (example: R5T.T0225.T000.NestedType_001_Parent+NestedType_001_Child).
        /// <para>This replicates the behavior of <see cref="Type.FullName"/>.</para>
        /// </summary>
        /// <remarks>
        /// Can handle nested types, using the nested type name separator used by <see cref="Type.FullName"/> (which is <see cref="ITokenSeparators.NestedTypeNameTokenSeparator"/>).
        /// </remarks>
        public string Get_NamespacedTypeName(Type type)
        {
            var isNestedType = this.Is_NestedType(type);
            if (isNestedType)
            {
                var parentNamespacedTypeName = this.Get_NamespacedTypeName(type.DeclaringType);

                var basicTypeName = this.Get_Name(type);

                var output = $"{parentNamespacedTypeName}{Instances.TokenSeparators.NestedTypeNameTokenSeparator}{basicTypeName}";
                return output;
            }
            else
            {
                var namespaceName = this.Get_NamespaceName(type);
                var typeName = this.Get_Name(type);

                var namespacedTypeName = Instances.NamespacedTypeNameOperator.Get_NamespacedTypeName(
                    namespaceName,
                    typeName);

                return namespacedTypeName;
            }
        }

        public string Get_NamespaceName(Type type)
            => type.Namespace;

        public string Get_TypeName_Full(Type type)
        {
            var output = Instances.TypeNameOperator.Get_TypeName_Full(type);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_TypeName_Full(Type)"/> as the default.
        /// </summary>
        public string Get_TypeName(Type type)
        {
            var output = Instances.TypeNameOperator.Get_TypeName(type);
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf_ImplementationType{T}(T)"/>
        public string Get_TypeName_OfImplementationType<T>(T value)
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf_ImplementationType(value);
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf_DeclaredType{T}()"/>
        public string Get_TypeName_OfDeclaredType<T>()
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf_DeclaredType<T>();
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf_DeclaredType{T}(T)"/>
        public string Get_TypeName_OfDeclaredType<T>(T instance)
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf_DeclaredType(instance);
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf{T}()"/>
        public string Get_TypeName<T>()
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf<T>();
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf{T}()"/>
        public string Get_TypeNameOf<T>()
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf<T>();
            return output;
        }

        /// <inheritdoc cref="ITypeNameOperator.Get_TypeNameOf{T}(T)"/>
        public string Get_TypeName<T>(T instance)
        {
            var output = Instances.TypeNameOperator.Get_TypeNameOf(instance);
            return output;
        }

        /// <summary>
		/// Gets the type of the <typeparamref name="T"/>.
        /// (Returns the value from the typeof operator.)
		/// </summary>
		public Type Get_Type_DeclaredType<T>()
        {
            var output = typeof(T);
            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Type_DeclaredType{T}()"/>
        /// (allows specifying the type parameter using an instance).
        /// <para>
        /// <inheritdoc cref="Get_Type_DeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        public Type Get_Type_DeclaredType<T>(T instance)
            => this.Get_Type_DeclaredType<T>();

        /// <summary>
        /// Gets the type of the given <paramref name="instance"/>.
        /// (Returns the result of <see cref="object.GetType"/>.)
        /// </summary>
        public Type Get_Type_ImplementationType<T>(T instance)
        {
            var output = instance.GetType();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Type_ImplementationType{T}(T)"/> as the default for the provided instance.
        /// <para>
        /// <inheritdoc cref="Get_Type_ImplementationType{T}(T)" path="/summary"/>
        /// </para>
        /// </summary>
        public Type Get_Type<T>(T instance)
            => this.Get_Type_ImplementationType(instance);

        /// <summary>
        /// Returns <see cref="Get_Type_ImplementationType{T}(T)"/> of the instance is not null,
        /// else returns <see cref="Get_Type_DeclaredType{T}()"/>.
        /// </summary>
        public Type Get_Type_AllowNull<T>(T instance)
        {
            var value_IsNull = Instances.NullOperator.Is_Null(instance);

            var type = value_IsNull
                ? this.Get_Type_DeclaredType<T>()
                : this.Get_Type_ImplementationType(instance)
                ;

            return type;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Type_DeclaredType{T}()"/>.
        /// <para>
        /// <inheritdoc cref="Get_Type_DeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        public Type Get_Type<T>()
            => this.Get_Type_DeclaredType<T>();

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Type_DeclaredType{T}()"/>.
        /// <para>
        /// <inheritdoc cref="Get_Type_DeclaredType{T}()" path="/summary"/>
        /// </para>
        /// </summary>
        public Type Get_TypeOf<T>()
            => this.Get_Type_DeclaredType<T>();

        public Func<Type, bool> Get_TypeEquals_Predicate(Type type)
        {
            bool Internal(Type other)
            {
                var output = this.Are_Equal(
                    type,
                    other);

                return output;
            }

            return Internal;
        }

        public void If_TypeIs<T>(
            object @object,
            Action<T> action)
        {
            var is_Type = Instances.TypeOperator.Type_Is<T>(
                @object,
                out var object_IsT);

            if(is_Type)
            {
                action(object_IsT);
            }
        }

        public bool Is_DeclaredType<T>(
            T instance,
            Type type,
            out Type declaredType)
        {
            declaredType = this.Get_Type_DeclaredType(instance);

            var output = this.Are_Equal(
                declaredType,
                type);

            return output;
        }

        public bool Is_DeclaredType<T>(
            T instance,
            Type type)
        {
            var output = this.Is_DeclaredType(
                instance,
                type,
                out _);

            return output;
        }

        /// <summary>
        /// Allows testing that the type parameter <typeparamref name="T"/> as declared in code is the type given by the type parameter <paramref name="type"/>.
        /// </summary>
        public bool Is_DeclaredType<T>(
            Type type,
            out Type declaredType)
        {
            declaredType = this.Get_Type_DeclaredType<T>();

            var output = this.Are_Equal(
                declaredType,
                type);

            return output;
        }

        public bool Is_DeclaredType<T>(Type type)
        {
            var output = this.Is_DeclaredType<T>(
                type,
                out _);

            return output;
        }

        /// <summary>
        /// Returns <see cref="Type.IsGenericParameter"/>,
        /// whic is true for both generic type parameter types and generic method parameter types.
        /// </summary>
        public bool Is_GenericParameter(Type type)
        {
            var output = type.IsGenericParameter;
            return output;
        }

        public bool Is_ImplementationType(
            object @object,
            Type type,
            out Type implementationType)
        {
            implementationType = this.Get_Type_ImplementationType(@object);

            var output = this.Are_Equal(
                implementationType,
                type);

            return output;
        }

        public bool Is_ImplementationType<T>(
            object @object,
            out Type implementationType)
        {
            var type = this.Get_Type_DeclaredType<T>();

            var output = this.Is_ImplementationType(
                @object,
                type,
                out implementationType);

            return output;
        }

        public bool Is_ImplementationType<T>(object @object)
        {
            var output = this.Is_ImplementationType<T>(
                @object,
                out _);

            return output;
        }

        public bool Is_ImplementationType<T>(
            T instance,
            Type type,
            out Type implementationType)
        {
            implementationType = this.Get_Type_ImplementationType(instance);

            var output = this.Are_Equal(
                implementationType,
                type);

            return output;
        }

        public bool Is_ImplementationType<T>(
            T instance,
            Type type)
        {
            var output = this.Is_ImplementationType(
                instance,
                type,
                out _);

            return output;
        }

        public bool Is_OfType<TInstance>(
            TInstance instance,
            Type type)
        {
            var type_OfInstance = this.Get_Type_ImplementationType(instance);

            var output = this.Are_Equal(
                type_OfInstance,
                type);

            return output;
        }

        public bool Is_NestedType(Type type)
        {
            var output = Instances.NullOperator.Is_NotNull(type.DeclaringType);
            return output;
        }

        public bool Is_Type<T>(Type type)
        {
            var declaredType = this.Get_Type_DeclaredType<T>();

            var output = this.Is_Type(
                type,
                declaredType);

            return output;
        }

        public bool Is_Type(Type a, Type b)
        {
            var output = a == b;
            return output;
        }

        public bool Is_Type<T>(object @object)
        {
            var output = this.Is_ImplementationType<T>(
                @object);

            return output;
        }

        /// <summary>
        /// Implements the is-operator such that the object "is" of type <typeparamref name="T"/>.
        /// </summary>
        public bool Type_Is<T>(object @object)
        {
            var output = @object is T;
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: the is-operator returns false for null values.
        /// </remarks>
        public bool Type_Is<T>(
            object @object,
            out T object_IsT)
        {
            if(@object is T temp)
            {
                object_IsT = temp;

                return true;
            }
            else
            {
                object_IsT = default;

                return false;
            }
        }

        /// <summary>
        /// Implements the is-operator such that the instance of type <typeparamref name="T1"/> "is" of type <typeparamref name="T2"/>.
        /// </summary>
        public bool Type_Is<T1, T2>(T1 instance)
        {
            var output = instance is T2;
            return output;
        }

        public bool Type_Is<T1, T2>(
            T1 instance,
            out T2 instance_IsType)
        {
            if (instance is T2 temp)
            {
                instance_IsType = temp;

                return true;
            }
            else
            {
                instance_IsType = default;

                return false;
            }
        }

        public void Verify_Is_ImplementationType<T>(
            T instance,
            Type type)
        {
            var is_ImplementationType = this.Is_ImplementationType(
                instance,
                type,
                out var implementationType);

            if(!is_ImplementationType)
            {
                var implementationType_TypeName = this.Get_TypeName(implementationType);
                var type_TypeName = this.Get_TypeName(type);

                var message = $"Implementation type failure.\nExpected: {type_TypeName}\nFound: {implementationType_TypeName}";

                throw new Exception(message);
            }
        }

        /// <summary>
        /// Use the type returned by the <see cref="Get_Type_ImplementationType{T}(T)"/> method of each instance to determine type by equality.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0000.Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality_Instance<T>(
            T a,
            T b,
            out bool typesAreEqual)
        {
            var typeA = this.Get_Type_ImplementationType(a);
            var typeB = this.Get_Type_ImplementationType(b);

            typesAreEqual = typeA == typeB;

            var typeDeterminesEquality = !typesAreEqual;
            return typeDeterminesEquality;
        }

        /// <summary>
        /// Chooses <see cref="TypeCheckDeterminesEquality_Instance{T}(T, T, out bool)"/> as the default.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Y0000.Documentation.TypeCheckDeterminesEquality" path="/summary"/>
        /// </remarks>
        public bool TypeCheckDeterminesEquality<T>(
            T a,
            T b,
            out bool typesAreEqual)
        {
            var output = this.TypeCheckDeterminesEquality_Instance(a, b, out typesAreEqual);
            return output;
        }

        public void Verify_Is_DeclaredType<T>(
            T instance,
            Type type)
        {
            var is_DeclaredType = this.Is_DeclaredType(
                instance,
                type,
                out var declaredType);

            if (!is_DeclaredType)
            {
                var declaredType_TypeName = this.Get_TypeName(declaredType);
                var type_TypeName = this.Get_TypeName(type);

                var message = $"Declared type failure.\nExpected: {type_TypeName}\nFound: {declaredType_TypeName}";

                throw new Exception(message);
            }
        }

        public void Verify_Is_DeclaredType<T>(Type type)
        {
            var is_DeclaredType = this.Is_DeclaredType<T>(
                type,
                out var declaredType);

            if (!is_DeclaredType)
            {
                var declaredType_TypeName = this.Get_TypeName(declaredType);
                var type_TypeName = this.Get_TypeName(type);

                var message = $"Declared type failure.\nExpected: {type_TypeName}\nFound: {declaredType_TypeName}";

                throw new Exception(message);
            }
        }

        /// <inheritdoc cref="Type_Is{T}(object)"/>
        public void Verify_Type_Is<T>(
            object @object)
        {
            var typeIs = this.Type_Is<T>(@object);
            if(!typeIs)
            {
                var implementationType_TypeName = Instances.TypeNameOperator.Get_TypeNameOf_ImplementationType(@object);
                var type_TypeName = Instances.TypeNameOperator.Get_TypeNameOf<T>();

                var message = $"Type failure.\nExpected object type is: {type_TypeName}\nFound: {implementationType_TypeName}";

                throw new Exception(message);
            }
        }

        /// <inheritdoc cref="Type_Is{T1, T2}(T1)"/>
        public void Verify_Type_Is<T1, T2>(T1 instance)
        {
            var typeIs = this.Type_Is<T1, T2>(instance);
            if (!typeIs)
            {
                var implementationType_TypeName = Instances.TypeNameOperator.Get_TypeNameOf_ImplementationType(instance);
                var type_TypeName = Instances.TypeNameOperator.Get_TypeNameOf<T2>();

                var message = $"Type failure.\nExpected to be of type: {type_TypeName}\nFound: {implementationType_TypeName}";

                throw new Exception(message);
            }
        }

        public void Verify_Type_Is<T1, T2>(
            T1 instance,
            out T2 instance_IsType)
        {
            var typeIs = this.Type_Is(
                instance,
                out instance_IsType);

            if (!typeIs)
            {
                var implementationType_TypeName = Instances.TypeNameOperator.Get_TypeNameOf_ImplementationType(instance);
                var type_TypeName = Instances.TypeNameOperator.Get_TypeNameOf<T2>();

                var message = $"Type failure.\nExpected to be of type: {type_TypeName}\nFound: {implementationType_TypeName}";

                throw new Exception(message);
            }
        }
    }
}
