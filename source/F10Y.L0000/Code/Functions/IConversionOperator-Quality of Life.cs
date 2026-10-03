using System;


namespace F10Y.L0000
{
    public partial interface IConversionOperator
    {
        /// <inheritdoc cref="To_Int32(char)"/>
        int To_Integer(char character)
            => this.To_Int32(character);

        /// <inheritdoc cref="To_Int64(ulong)"/>
        long To_Long(ulong value)
            => this.To_Int64(value);
    }
}
