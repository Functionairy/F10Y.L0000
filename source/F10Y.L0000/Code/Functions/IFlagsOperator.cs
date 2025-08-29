using System;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFlagsOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Implementations.IFlagsOperator _Implementations => Implementations.FlagsOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Works for an enumeration value of a single flag.
        /// </summary>
        public bool Has_Flag<TEnum>(TEnum value, TEnum flag)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = _Implementations.Has_Flag_StandardLibrary(
                value,
                flag);

            return output;
        }

        /// <summary>
        /// Works for an enumeration value of combined flags.
        /// </summary>
        public bool Has_Flags<TEnum>(TEnum value, TEnum flags)
            where TEnum : Enum
        {
            // Use the standard library's implementation, it works for both flag and flags (since both are actually just an integer value).
            var output = _Implementations.Has_Flag_StandardLibrary(
                value,
                flags);

            return output;
        }
    }
}
