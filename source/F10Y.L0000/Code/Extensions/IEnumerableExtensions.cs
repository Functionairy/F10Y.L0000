using System;
using System.Collections.Generic;
using System.Linq;

//using Instances = F10Y.L0000.Instances;


/// Note: do not put extension in system namespaces in this library. See notes in project plan.
//namespace System.Linq

namespace F10Y.L0000.Extensions
{
    public static class IEnumerableExtensions
    {
        public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            var output = Instances.EnumerableOperator.Append(
                enumerable,
                appendix);

            return output;
        }

        public static IEnumerable<T> Append_Many<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            var output = Instances.EnumerableOperator.Append_Many(
                enumerable,
                appendix);

            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.Order_Ascending{T}(IEnumerable{T})"/>
        public static IOrderedEnumerable<T> Order_Ascending<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Order_Ascending(enumerable);

        /// <inheritdoc cref="IEnumerableOperator.Order_Descending{T}(IEnumerable{T})"/>
        public static IOrderedEnumerable<T> Order_Descending<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Order_Descending(enumerable);

        /// <inheritdoc cref="IEnumerableOperator.Order{T}(IEnumerable{T})"/>
        public static IOrderedEnumerable<T> Order<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Order(enumerable);

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