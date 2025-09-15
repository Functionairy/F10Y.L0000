using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IKeyValuePairOperations
    {
        public Func<KeyValuePair<TKey, TValue>, TOut> Get_Value<TKey, TValue, TOut>(Func<TValue, TOut> selector)
            => pair => selector(pair.Value);
    }
}
