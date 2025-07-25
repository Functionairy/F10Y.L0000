using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDictionaryOperator
    {
        public bool Contains_Key<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary.ContainsKey(key);

        public TValue Get_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary[key];

        public Dictionary<TKey, TValue> New<TKey, TValue>()
            => new Dictionary<TKey, TValue>();

        public Dictionary<TKey, TValue> New<TKey, TValue>(
            IEnumerable<TKey> keys,
            TValue value_Initial)
        {
            var output = this.New<TKey, TValue>();

            foreach (var key in keys)
            {
                output.Add(key, value_Initial);
            }

            return output;
        }

        public void Verify_ContainsKey<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
        {
            var containsKey = this.Contains_Key(
                dictionary,
                key);

            if(!containsKey)
            {
                var message = $"{key}: Key not found.";

                Instances.ExceptionOperator.Throw(message);
            }
        }
    }
}
