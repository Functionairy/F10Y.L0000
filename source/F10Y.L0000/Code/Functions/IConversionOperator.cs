using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IConversionOperator
    {
        /// <inheritdoc cref="Convert.ToInt32(char)"/>
        int To_Int32(char character)
            => Convert.ToInt32(character);

        /// <inheritdoc cref="Convert.ToInt64(ulong)"/>
        long To_Int64(ulong value)
            => Convert.ToInt64(value);
    }
}
