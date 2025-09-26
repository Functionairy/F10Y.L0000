using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDictionaryOperator
    {
        void Add<TKey, TValue>(
            IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
        {
            var list = dictionary[key];

            list.Add(value);
        }

        /// <summary>
        /// Adds the key-value pair if the key does not exist, else replaces the value for the given key if the key already exists.
        /// </summary>
        void Add_OrReplace<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
        {
            var wasAdded = dictionary.TryAdd(key, value);
            if (!wasAdded)
            {
                dictionary[key] = value;
            }
        }

        void Add_Range<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
        {
            foreach (var pair in pairs)
            {
                dictionary.Add(pair);
            }
        }

        /// <summary>
        /// If there is an expandable list of values for each key, add the value to either a new list (if the key does not already exist), or the existing list.
        /// </summary>
        public void Add_Value<TKey, TValue>(
            IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
        {
            var hasValue = dictionary.TryGetValue(key, out List<TValue> list);
            if (!hasValue)
            {
                list = new List<TValue>();

                dictionary.Add(key, list);
            }

            list.Add(value);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Note: as of .NET 8.0, this is a built-in extension.
        /// </remarks>
        Dictionary<TKey, TValue> Clone_ToDictionary<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary)
        {
            var output = dictionary.ToDictionary(
                x => x.Key,
                x => x.Value);

            return output;
        }

        Dictionary<TKey, TValue> Clone<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary)
            => this.Clone_ToDictionary(dictionary);

        Dictionary<TKey, TValue> Clone<TKey, TValue>(
            Dictionary<TKey, TValue> dictionary)
            => this.Clone_ToDictionary(dictionary);

        bool Contains_Key<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary.ContainsKey(key);

        /// <summary>
        /// Quality-of-life overload for <see cref="New{TKey, TValue}()"/>
        /// </summary>
        Dictionary<TKey, TValue> Empty<TKey, TValue>()
            => this.New<TKey, TValue>();

        TKey Get_Key<TKey, TValue>(KeyValuePair<TKey, TValue> pair)
            => Instances.KeyValuePairOperator.Get_Key(pair);

        TValue Get_Value<TKey, TValue>(
            IDictionary<TKey, TValue> dictionary,
            TKey key)
            => dictionary[key];

        TValue Get_Value_OrDefault<TKey, TValue>(
            TKey key,
            IDictionary<TKey, TValue> dictionary,
            TValue @default)
        {
            var hasValue = this.Has_Value(
                key,
                dictionary,
                out var value_OrDefault);

            var output = hasValue
                ? value_OrDefault
                : @default
                ;

            return output;
        }

        bool Has_Value<TKey, TValue>(
            TKey key,
            IDictionary<TKey, TValue> dictionary,
            out TValue value_OrDefault)
        {
            var output = dictionary.TryGetValue(
                key,
                out value_OrDefault);

            return output;
        }

        Dictionary<TValue, TKey> Invert<TKey, TValue>(IDictionary<TKey, TValue> dictionary)
            => dictionary.ToDictionary(
                pair => pair.Value,
                pair => pair.Key);

        Dictionary<TKey, TValue> New<TKey, TValue>()
            => new Dictionary<TKey, TValue>();

        Dictionary<TKey, TValue> New<TKey, TValue>(IEqualityComparer<TKey> keyEqualityComparer)
            => new Dictionary<TKey, TValue>(keyEqualityComparer);

        Dictionary<TKey, TValue> New<TKey, TValue>(
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

        Dictionary<TKey, TValue> New<TKey, TValue>(IEnumerable<TKey> keys)
            => this.New<TKey, TValue>(
                keys,
                default);

        Dictionary<TKey, TValue> To_Dictionary<TKey, TValue>(IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => pairs
                .ToDictionary(
                    pair => pair.Key,
                    pair => pair.Value);

        Dictionary<TKey, TValue[]> To_Dictionary_OfArrays<TKey, TValue, TValueList>(IDictionary<TKey, TValueList> valueLists_ByKey)
            where TValueList : IList<TValue>
            => valueLists_ByKey.ToDictionary(
                //this.Get_Key,
                x => x.Key,
                //Instances.KeyValuePairOperations.Get_Value<TKey, List<TValue>, TValue[]>(Instances.ListOperator.To_Array)
                x => x.Value.ToArray()
                );

        void Verify_ContainsKey<TKey, TValue>(
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
