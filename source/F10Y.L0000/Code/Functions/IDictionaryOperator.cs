using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDictionaryOperator
    {
        public Dictionary<TKey, TValue> New<TKey, TValue>()
            => new Dictionary<TKey, TValue>();
    }
}
