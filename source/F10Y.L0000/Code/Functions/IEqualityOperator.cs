using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEqualityOperator
    {
        public Func<T, T, bool> Get_Equality<T>()
            where T : IEquatable<T>
            => (a, b) => a.Equals(b);

        public EqualityComparer<T> Get_EqualityComparer_Default<T>()
        {
            var output = Instances.EqualityComparerOperator.Get_Default<T>();
            return output;
        }
    }
}
