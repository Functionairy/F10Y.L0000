using System;
using System.Collections;

using F10Y.T0002;


namespace F10Y.L0000.Implementations
{
    [FunctionsMarker]
    public partial interface IHashCodeOperator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Cannot handle null.
        /// </remarks>
        public int Get_HashCode_ViaGetHashCode_AsObject(object value)
        {
            var output = value.GetHashCode();
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Cannot handle null.
        /// </remarks>
        public int Get_HashCode_ViaGetHashCode_AsType<T>(T value)
        {
            var output = value.GetHashCode();
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_HashCode_ViaCombine_AsObject(object)"/> since whether the type information is included or not makes no difference.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Get_HashCode_ViaCombine(object value)
            => this.Get_HashCode_ViaCombine_AsObject(value);

        /// <summary>
        /// Uses the <see cref="HashCode.Combine{T1}(T1)"/> method (single argument combine).
        /// </summary>
        /// <remarks>
        /// Note: including the type information or not (<see cref="Get_HashCode_ViaCombine_AsObject(object)"/>) makes no difference.
        /// Includes the type information.
        /// Can handle null.
        /// </remarks>
        public int Get_HashCode_ViaCombine_AsType<T>(T value)
        {
            var output = HashCode.Combine(value);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="HashCode.Combine{T1}(T1)"/> method (single argument combine).
        /// </summary>
        /// <remarks>
        /// Note: including the type information or not (<see cref="Get_HashCode_ViaCombine_AsType{T}(T)"/>) makes no difference.
        /// Does not include type information, just as an object.
        /// Can handle null.
        /// </remarks>
        public int Get_HashCode_ViaCombine_AsObject(object value)
        {
            var output = HashCode.Combine(value);
            return output;
        }

        /// <summary>
        /// Uses <see cref="IEqualityComparer.GetHashCode(object)"/>.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public int Get_HashCode_ViaEqualityComparer_AsObject(object value)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default(value);

            var output = Instances.EqualityComparerOperator.Get_HashCode_OfObject(
                value,
                equalityComparer);

            return output;
        }

        /// <summary>
        /// Uses <see cref="IEqualityComparer.GetHashCode(object)"/>.
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        public int Get_HashCode_ViaEqualityComparer_AsType<T>(T value)
        {
            var equalityComparer = Instances.EqualityComparerOperator.Get_Default(value);

            var output = Instances.EqualityComparerOperator.Get_HashCode(
                value,
                equalityComparer);

            return output;
        }
    }
}
