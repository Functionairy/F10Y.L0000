using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IUInt64Operator
    {
        /// <inheritdoc cref="UInt64.Parse(string)"/>
        UInt64 Parse(string uint64String)
        {
            var output = UInt64.Parse(uint64String);
            return output;
        }
    }
}
