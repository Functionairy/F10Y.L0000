using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IConverter
    {
        /// <inheritdoc cref="IDecimalOperator.Parse(string)"/>
        Decimal To_Decimal(string decimalString)
            => Instances.DecimalOperator.Parse(decimalString);

        /// <inheritdoc cref="Convert.ToDouble(long)"/>
        double To_Double(long value)
            => Convert.ToDouble(value);

        /// <inheritdoc cref="Convert.ToDouble(ulong)"/>
        double To_Double(ulong value)
            => Convert.ToDouble(value);

        /// <inheritdoc cref="IUlongOperator.Parse(string)"/>
        ulong To_Ulong(string ulongString)
            => Instances.UlongOperator.Parse(ulongString);

        /// <inheritdoc cref="Convert.ToUInt64(object)"/>
        ulong To_Ulong(object value)
            => Convert.ToUInt64(value);

        /// <inheritdoc cref="Convert.ToUInt64(uint)"/>
        ulong To_Ulong(uint value)
            => Convert.ToUInt64(value);
    }
}
