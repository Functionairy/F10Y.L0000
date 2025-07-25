using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IComparerOperator
    {
        public Comparer<T> New<T>(Comparison<T> comparison)
            => Comparer<T>.Create(comparison);
    }
}
