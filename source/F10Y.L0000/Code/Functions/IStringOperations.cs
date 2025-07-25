using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStringOperations
    {
        public Func<string, bool> Equals_AnyOf(params string[] values)
            => @string => Instances.ArrayOperator.Contains(
                values,
                @string);
    }
}
