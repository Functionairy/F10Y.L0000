using System;
using System.Globalization;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ICultureInfos
    {
        /// <summary>
        /// Chooses <see cref="Invariant"/> as the default.
        /// </summary>
        public CultureInfo Default => this.Invariant;


        /// <inheritdoc cref="CultureInfo.InvariantCulture"/>
        public CultureInfo Invariant => CultureInfo.InvariantCulture;
    }
}
