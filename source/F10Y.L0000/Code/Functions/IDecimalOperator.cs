using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDecimalOperator
    {
        /// <inheritdoc cref="Decimal.Parse(string)"/>
        Decimal Parse(string decimalString)
        {
            var output = Decimal.Parse(decimalString);
            return output;
        }
    }
}
