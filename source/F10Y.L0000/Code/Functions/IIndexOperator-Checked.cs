using System;

using F10Y.T0002;


namespace F10Y.L0000.Checked
{
    [FunctionsMarker]
    public partial interface IIndexOperator
    {
        /// <inheritdoc cref="L0000.IIndexOperator.Get_Index_FromLength_ZeroBased(int)"/>
        /// <remarks>
        /// Checked in the sense that the length is confirmed to be greater than or equal to zero.
        /// </remarks>
        public int Get_Index_FromLength_ZeroBased_Checked(int length)
        {
            var output = length - 1;
            return output;
        }
    }
}
