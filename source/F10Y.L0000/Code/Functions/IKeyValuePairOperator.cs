using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IKeyValuePairOperator
    {
        public TKey Get_Key<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
            => pair.Key;

        //public TKey Get_Key<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
        //    => pair.Key;
    }
}
