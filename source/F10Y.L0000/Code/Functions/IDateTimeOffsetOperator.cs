using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOffsetOperator
    {
        /// <inheritdoc cref="DateTimeOffset.MinValue"/>
        public DateTimeOffset Get_Minimum() => DateTimeOffset.MinValue;
    }
}
