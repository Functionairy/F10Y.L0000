using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDictionaryOperator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: as of .NET 8.0, this is a built-in extension.
        /// </remarks>
        public Dictionary<TKey, TValue> Clone_ToDictionary<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary)
        {
            var output = dictionary.ToDictionary(
                x => x.Key,
                x => x.Value);

            return output;
        }

        public Dictionary<TKey, TValue> Clone<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary)
            => this.Clone_ToDictionary(dictionary);

        public Dictionary<TKey, TValue> Clone<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary)
            => this.Clone_ToDictionary(dictionary);

        public bool Contains_Key<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary.ContainsKey(key);

        /// <summary>
        /// Quality-of-life overload for <see cref="New{TKey, TValue}()"/>
        /// </summary>
        public Dictionary<TKey, TValue> Empty<TKey, TValue>()
            => this.New<TKey, TValue>();

        public TValue Get_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary[key];

        public Dictionary<TValue, TKey> Invert<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
            => dictionary.ToDictionary(
                pair => pair.Value,
                pair => pair.Key);

        public Dictionary<TKey, TValue> New<TKey, TValue>()
            => new Dictionary<TKey, TValue>();

        public Dictionary<TKey, TValue> New<TKey, TValue>(IEqualityComparer<TKey> keyEqualityComparer)
            => new Dictionary<TKey, TValue>(keyEqualityComparer);

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
