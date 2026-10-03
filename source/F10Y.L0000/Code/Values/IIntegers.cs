using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IIntegers
    {
        /// <summary>
        /// <para><value>-1</value></para>
        /// </summary>
        const int NegativeOne_Const = -1;

        /// <inheritdoc cref="NegativeOne_Const"/>
        int NegativeOne => NegativeOne_Const;

        /// <summary>
        /// <para><value>0</value></para>
        /// </summary>
        const int Zero_Constant = 0;

        /// <inheritdoc cref="Zero_Constant"/>
        int Zero => Zero_Constant;

        /// <summary>
        /// <para><value>1</value></para>
        /// </summary>
        const int One_Constant = 1;

        /// <inheritdoc cref="One_Constant"/>
        int One => One_Constant;

        /// <summary>
        /// <para><value>2</value></para>
        /// </summary>
        const int Two_Constant = 2;

        /// <inheritdoc cref="Two_Constant"/>
        int Two => Two_Constant;
    }
}
