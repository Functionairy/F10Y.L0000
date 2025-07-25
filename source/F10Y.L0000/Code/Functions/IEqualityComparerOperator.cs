using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEqualityComparerOperator
    {
        public EqualityComparer<T> Get_Default<T>()
        {
            var output = EqualityComparer<T>.Default;
            return output;
        }

        public EqualityComparer<T> Get_Default<T>(T value)
            => this.Get_Default<T>();
    }
}
