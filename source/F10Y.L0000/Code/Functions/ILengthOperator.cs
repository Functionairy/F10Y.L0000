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
    public partial interface ILengthOperator
    {
        public int Get_Length<T>(IList<T> list)
            => Instances.ListOperator.Get_Count(list);

        public int Get_Length<T>(ICollection<T> collection)
            => Instances.CollectionOperator.Get_Count(collection);
    }
}
