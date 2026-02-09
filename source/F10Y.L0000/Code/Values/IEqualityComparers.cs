using System;
using System.Collections.Generic;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IEqualityComparers<TValue>
    {
        EqualityComparer<TValue> Default
            => Instances.EqualityComparerOperator.Get_Default<TValue>();
    }


    [ValuesMarker]
    public partial interface IEqualityComparers
    {
        IEqualityComparers<TValue> For<TValue>()
            => EqualityComparers<TValue>.Instance;
    }
}
