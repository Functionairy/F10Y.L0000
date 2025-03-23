using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IIndexOperator
    {
        /// <summary>
        /// Uses <see cref="Get_LastIndex_FromLength_ZeroBased(int)"/> (assumes a zero-based index).
        /// </summary>
        public int Get_LastIndex_FromLength(int length)
            => this.Get_LastIndex_FromLength_ZeroBased(length);

        /// <summary>
        /// The last index of a zero-based array the the length minus one.
        /// </summary>
        public int Get_LastIndex_FromLength_ZeroBased(int length)
            => length - 1;
    }
}
