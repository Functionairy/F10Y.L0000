using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAnyOperator
    {
        public bool Any<T>(IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Any(enumerable);
    }
}
