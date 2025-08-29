using System;

using F10Y.T0002;


namespace F10Y.L0000.Implementations
{
    [FunctionsMarker]
    public partial interface IFlagsOperator
    {
        /// <summary>
        /// Uses the standard library's <see cref="Enum.HasFlag(Enum)"/> method.
        /// </summary>
        /// <remarks>
        /// For source, see: <see href="https://source.dot.net/#System.Private.CoreLib/src/libraries/System.Private.CoreLib/src/System/Enum.cs,9cd73f33d2df3074"/>.
        /// </remarks>
        public bool Has_Flag_StandardLibrary<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            var output = value.HasFlag(flags);
            return output;
        }
    }
}
