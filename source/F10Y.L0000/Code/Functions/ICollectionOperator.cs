using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICollectionOperator
    {
        public int Get_Count<T>(ICollection<T> collection)
            => collection.Count;
    }
}
