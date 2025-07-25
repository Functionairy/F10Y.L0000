using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IComparisonResults
    {
        /// <summary>
        /// Indicates that x is less than y.
        /// <para>Value: <value>-1</value></para>
        /// <para><inheritdoc cref="Y0000.Documentation.CompareTo_XtoY" path="/summary"/></para>
        /// </summary>
        public int LessThan => -1;

        /// <summary>
        /// Indicates that x is greater than y.
        /// <para>Value: <value>1</value></para>
        /// <para><inheritdoc cref="Y0000.Documentation.CompareTo_XtoY" path="/summary"/></para>
        /// </summary>
        public int GreaterThan => 1;

        /// <summary>
        /// Indicates that x is equal to y.
        /// <para>Value: <value>0</value></para>
        /// <para><inheritdoc cref="Y0000.Documentation.CompareTo_XtoY" path="/summary"/></para>
        /// </summary>
        public int EqualTo => 0;
    }
}
