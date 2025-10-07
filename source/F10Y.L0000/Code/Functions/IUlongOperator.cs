using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IUlongOperator
    {
        /// <inheritdoc cref="IUInt64Operator.Parse(string)"/>
        ulong Parse(string ulongString)
            => Instances.UInt64Operator.Parse(ulongString);
    }
}
