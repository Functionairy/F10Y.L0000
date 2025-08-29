using System;
using System.Collections.Generic;



namespace F10Y.L0000.Extensions
{
    public static class IDictionaryExtensions
    {
        public static Dictionary<TKey, TValue> Clone_ToDictionary<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Clone_ToDictionary(dictionary);

        public static Dictionary<TValue, TKey> Invert<TKey, TValue>(this IDictionary<TKey, TValue> dictionary)
            => Instances.DictionaryOperator.Invert(dictionary);
    }
}
