using System;
using System.Globalization;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface INumberStylesSets
    {
        /// <inheritdoc cref="NumberStyles.Currency"/>
        NumberStyles Currency => NumberStyles.Currency;
    }
}
