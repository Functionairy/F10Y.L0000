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
        CultureInfo Default => this.Invariant;

        /// <inheritdoc cref="CultureInfo.InvariantCulture"/>
        CultureInfo Invariant => CultureInfo.InvariantCulture;

#pragma warning disable IDE1006 // Naming Styles

        CultureInfo en_US => Instances.CultureInfoOperator.Get_For(
            Instances.CultureNames.en_US);

#pragma warning restore IDE1006 // Naming Styles
    }
}
