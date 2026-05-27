using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IKeyValuePairOperator
    {
        KeyValuePair<TKey, TValue> From<TKey, TValue>(TKey key, TValue value)
            => new KeyValuePair<TKey, TValue>(key, value);

        KeyValuePair<TKey, TValue> From_KeyAndValue<TKey, TValue>(TKey key, TValue value)
            => this.From(key, value);

        KeyValuePair<TKey, TValue> From<TKey, TValue>((TKey key, TValue value) tuple)
            => this.From(
                tuple.key,
                tuple.value);

        KeyValuePair<TKey, TValue> From_Tuple<TKey, TValue>((TKey key, TValue value) tuple)
            => this.From(tuple);

        IEnumerable<KeyValuePair<TKey, TValue>> From<TKey, TValue>(IEnumerable<(TKey, TValue)> tuples)
            => tuples
                .Select(this.From_Tuple)
                ;

        KeyValuePair<TKey, TValue>[] From<TKey, TValue>(params (TKey, TValue)[] tuples)
            => this.From(tuples.AsEnumerable())
                .Now();

        TKey Get_Key<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
            => pair.Key;

        TValue Get_Value<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
            => pair.Value;
    }
}
