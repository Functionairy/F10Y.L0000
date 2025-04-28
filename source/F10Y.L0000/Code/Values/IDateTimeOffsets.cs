using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDateTimeOffsets
    {
        /// <inheritdoc cref="DateTimeOffset.MinValue"/>
        public DateTimeOffset Minimum => DateTimeOffset.MinValue;
    }
}
