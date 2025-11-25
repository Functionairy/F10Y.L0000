using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    /// <summary>
    /// Returns count values for various data types.
    /// </summary>
    /// <remarks>
    /// See also: <see cref="ICountOperator"/>.
    /// <para>.NET Standard 2.1 Foundation Library</para>
    /// </remarks>
    [FunctionsMarker]
    public partial interface ICountOperator
    {
        int Count<T>(ICollection<T> collection)
            => this.Get_CountOf(collection);

        int Count<T>(IEnumerable<T> enumerable)
            => this.Get_CountOf(enumerable);

        int Get_CountOf<T>(IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Get_Count(enumerable);

        Dictionary<TKey, int> Get_Counts_ByKey<TKey, TElement>(IDictionary<TKey, TElement[]> arrays_ByKey)
            => Instances.DictionaryOperator.Get_Counts_ByKey(arrays_ByKey);

        int Get_CountOf<T>(ICollection<T> collection)
            => Instances.CollectionOperator.Get_Count(collection);
    }
}
