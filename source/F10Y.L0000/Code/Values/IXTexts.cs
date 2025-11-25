using System;
using System.Xml.Linq;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IXTexts
    {
        /// <inheritdoc cref="NewLine_Environment"/>
        /// <remarks>
        /// Chooses <see cref="NewLine_Environment"/> as the default.
        /// </remarks>
        XText NewLine => this.NewLine_Environment;

        XText NewLine_Environment => Instances.XTextOperator.From(
            Instances.NewLines.Environment);

        XText NewLine_NonWindows => Instances.XTextOperator.From(
            Instances.NewLines.NonWindows);

        XText NewLine_Windows => Instances.XTextOperator.From(
            Instances.NewLines.Windows);
    }
}
