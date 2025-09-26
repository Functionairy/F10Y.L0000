using System;
using System.Collections.Generic;


namespace F10Y.L0000.Extensions
{
    public static class CollectionExtensions
    {
        public static bool Has_Multiple<T>(this ICollection<T> collection)
            => Instances.CollectionOperator.Has_Multiple(collection);
    }
}
