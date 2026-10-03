using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDateTimeFormats
    {
#pragma warning disable IDE1006 // Naming Styles

        /// <summary>
        /// <para><value>yyyyMMdd</value></para>
        /// </summary>
        string yyyyMMdd => "yyyyMMdd";

        /// <summary>
        /// <para><value>yyyyMMdd</value></para>
        /// </summary>
        string yyyy_MM_dd_Dashed => "yyyy-MM-dd";

#pragma warning restore IDE1006 // Naming Styles
    }
}
