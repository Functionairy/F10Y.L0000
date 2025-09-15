using System;
using System.Collections.Generic;


namespace F10Y.L0000.Extensions
{
    public static class IDictionaryExtensions
    {
        public static void Add<TKey, TValue>(this IDictionary<TKey, List<TValue>> dictionary,
            TKey key,
            TValue value)
            => Instances.DictionaryOperator.Add(
                dictionary,
                key,
                value);

        public static void Add_OrReplace<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            TKey key,
            TValue value)
            => Instances.DictionaryOperator.Add_OrReplace(
                dictionary,
                key,
                value);

        public static void Add_Range<TKey, TValue>(this IDictionary<TKey, TValue> dictionary,
            IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => Instances.DictionaryOperator.Add_Range(
                dictionary,
                pairs);

        public static Dictionary<TKey, TValue> Clone_ToDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Invert(dictionary);

        public static Dictionary<TKey, TValue> To_Dictionary<TKey, TValue>(this IEnumerable<KeyValuePair<TKey, TValue>> pairs)
            => Instances.DictionaryOperator.To_Dictionary(pairs);

        public static Dictionary<TKey, TValue[]> To_Dictionary_OfArrays<TKey, TValue, TValueList>(this IDictionary<TKey, TValueList> valueLists_ByKey)
            where TValueList : IList<TValue>
            => Instances.DictionaryOperator.To_Dictionary_OfArrays<TKey, TValue, TValueList>(valueLists_ByKey);

        public static Dictionary<TKey, TValue[]> To_Dictionary_OfArrays<TKey, TValue>(this IDictionary<TKey, List<TValue>> valueLists_ByKey)
            => Instances.DictionaryOperator.To_Dictionary_OfArrays<TKey, TValue, List<TValue>>(valueLists_ByKey);
    }
}
