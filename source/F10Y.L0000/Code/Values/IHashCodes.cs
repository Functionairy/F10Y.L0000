using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IHashCodes
    {
        /// <summary>
        /// <para><value>0 (zero)</value></para>
        /// <para>
        /// <description>
        /// A fixed (not run-specific) value for the hashcode of null.
        /// </description>
        /// </para>
        /// </summary>
        /// <remarks>
        /// Useful if you need a hashcode of a property of an instance to combine with other values, but the property value is null.
        /// <para>
        /// Note that the <see cref="System.Collections.IEqualityComparer.GetHashCode(object)"/> method returns the same value (0, zero) for null.
        /// However, the <see cref="HashCode.Combine{T1}(T1)"/> method does <strong>not</strong>; instead, it provides a value that varies with each run.
        /// </para>
        /// </remarks>
        int For_Null_Fixed => 0;

        int For_Null_Variable => HashCode.Combine<object>(null);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Choosees <see cref="For_Null_Fixed"/> as the default.
        /// </remarks>
        int For_Null => For_Null_Fixed;
    }
}
