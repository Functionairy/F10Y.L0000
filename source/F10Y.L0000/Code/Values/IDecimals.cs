using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDecimals
    {
        /// <summary>
        /// <para><value>1</value></para>
        /// </summary>
        const decimal One_Constant = 1M;

        /// <inheritdoc cref="One_Constant"/>
        decimal One => One_Constant;

        /// <summary>
        /// <para><value>0</value></para>
        /// </summary>
        const decimal Zero_Constant = 0M;

        /// <inheritdoc cref="Zero_Constant"/>
        decimal Zero => Zero_Constant;
    }
}
