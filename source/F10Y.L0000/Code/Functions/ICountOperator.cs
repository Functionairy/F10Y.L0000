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
        public int Count<T>(IEnumerable<T> enumerable)
            => this.Get_CountOf(enumerable);

        public int Get_CountOf<T>(IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Get_Count(enumerable);

        public int Get_CountOf<T>(ICollection<T> collection)
            => Instances.CollectionOperator.Get_Count(collection);
    }
}
