using System;
using System.Globalization;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICultureInfoOperator
    {
        CultureInfo Get_For(string name)
            => CultureInfo.GetCultureInfo(name);
    }
}
