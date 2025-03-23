using System;
using System.Collections.Generic;

using Instances = F10Y.L0000.Instances;


namespace System.Linq
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T, T)> Zip<T>(this IEnumerable<T> items,
            IEnumerable<T> b)
        {
            var output = Instances.EnumerableOperator.Zip(
                items,
                b);

            return output;
        }
    }
}
