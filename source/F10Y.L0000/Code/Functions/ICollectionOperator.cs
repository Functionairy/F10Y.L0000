using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICollectionOperator
    {
        bool Are_Equal_Counts<T1, T2>(
            ICollection<T1> a,
            ICollection<T2> b)
        {
            var count_OfA = this.Get_Count(a);
            var count_OfB = this.Get_Count(b);

            var output = Instances.EqualityOperator.Are_Equal(count_OfA, count_OfB);
            return output;
        }

        int Get_Count<T>(ICollection<T> collection)
            => collection.Count;

        bool Has_Multiple<T>(ICollection<T> collection)
            => collection.Count > 1;
    }
}
