using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICollectionOperator
    {
        int Get_Count<T>(ICollection<T> collection)
            => collection.Count;

        bool Has_Multiple<T>(ICollection<T> collection)
            => collection.Count > 1;
    }
}
