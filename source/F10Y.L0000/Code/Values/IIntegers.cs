using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IIntegers
    {
        /// <summary>
        /// <para><value>01</value></para>
        /// </summary>
        public const int NegativeOne_Const = -1;

        /// <inheritdoc cref="NegativeOne_Const"/>
        public int NegativeOne => NegativeOne_Const;

        /// <summary>
        /// <para><value>0</value></para>
        /// </summary>
        public const int Zero_Constant = 0;

        /// <inheritdoc cref="Zero_Constant"/>
        public int Zero => Zero_Constant;

        /// <summary>
        /// <para><value>1</value></para>
        /// </summary>
        public const int One_Constant = 1;

        /// <inheritdoc cref="One_Constant"/>
        public int One => One_Constant;
    }
}
