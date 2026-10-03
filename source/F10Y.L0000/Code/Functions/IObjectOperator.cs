using System;
using System.Runtime.CompilerServices;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IObjectOperator
    {
        /// <summary>
        /// A select method inspired by the LINQ select method, but for individual objects.
        /// </summary>
        TOut Convert<TIn, TOut>(
            TIn input,
            Func<TIn, TOut> converter)
            => converter(input);

        /// <summary>
        /// A select method inspired by the LINQ select method, but for individual objects.
        /// </summary>
        TOut Convert<TIn, T, TOut>(
            TIn input,
            Func<TIn, T> converter,
            Func<T, TOut> converter_TOut)
        {
            var value = converter(input);
            var output = converter_TOut(value);
            return output;
        }

        /// <summary>
        /// Uses the object's virtual <see cref="object.GetHashCode"/> method, that can be overridden.
        /// </summary>
        int Get_HashCode_ViaVirtualMethod(object @object)
            => @object.GetHashCode();

        /// <summary>
        /// Uses the default object hash code method (<see cref="RuntimeHelpers.GetHashCode(object)"/>).
        /// </summary>
        int Get_HashCode_ViaRuntimeHelper(object @object)
            => RuntimeHelpers.GetHashCode(@object);

        /// <summary>
        /// Chooses <see cref="Get_HashCode_ViaVirtualMethod(object)"/> as the default.
        /// </summary>
        int Get_HashCode(object @object)
            => this.Get_HashCode_ViaVirtualMethod(@object);

        /// <summary>
        /// The <see cref="Get_HashCode_ViaRuntimeHelper(object)"/> is the default method for objects of types that have not overridden <see cref="object.GetHashCode"/>.
        /// </summary>
        int Get_HashCode_Default(object @object)
            => this.Get_HashCode_ViaRuntimeHelper(@object);

        void Modify_If<T>(
            T @object,
            bool condition,
            Action<T> modifyAction)
        {
            if (condition)
            {
                modifyAction(@object);
            }
        }

        object New()
            => new object();

        string To_String(object @object)
            => @object.ToString();

        string To_String<T>(T value)
            => value.ToString();

        T Verify_IsType<T>(object @object)
        {
            if (@object is T output)
            {
                return output;
            }
            else
            {
                throw new Exception("Type verification failed.");
            }
        }
    }
}
