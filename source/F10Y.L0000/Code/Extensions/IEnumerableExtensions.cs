using System;
using System.Collections.Generic;
using System.Linq;


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

        public static IEnumerable<T> Append_If<T>(this IEnumerable<T> enumerable,
            bool condition,
            IEnumerable<T> appendix)
            => Instances.EnumerableOperator.Append_If(
                enumerable,
                condition,
                appendix);

        public static IEnumerable<T> Append_If<T>(this IEnumerable<T> enumerable,
            bool condition,
            params T[] appendix)
            => Instances.EnumerableOperator.Append_If(
                enumerable,
                condition,
                appendix);

        public static IEnumerable<T> Append_If<T>(this IEnumerable<T> enumerable,
            bool condition,
            IEnumerable<T> appendix_IfTrue,
            IEnumerable<T> appendix_IfFalse)
            => Instances.EnumerableOperator.Append_If(
                enumerable,
                condition,
                appendix_IfTrue,
                appendix_IfFalse);

        public static IEnumerable<T> Append_Many<T>(this IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
        {
            var output = Instances.EnumerableOperator.Append_Many(
                enumerable,
                appendix);

            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.Except_First{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Except_First<T>(this IEnumerable<T> enumerable)
            => Instances.EnumerableOperator.Except_First(enumerable);

        /// <inheritdoc cref="IEnumerableOperator.Except_Last{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Except_Last<T>(this IEnumerable<T> enumerable)
        {
            var output = Instances.EnumerableOperator.Except_Last(enumerable);
            return output;
        }

        /// <inheritdoc cref="IEnumerableOperator.Except_Last{T}(IEnumerable{T}, int)"/>
        public static IEnumerable<T> Except_Last<T>(this IEnumerable<T> enumerable, int numberOfElements)
        {
            var output = Instances.EnumerableOperator.Except_Last(enumerable, numberOfElements);
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

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            IEnumerable<string> orderedNames)
        {
            var output = Instances.OrderOperator.Order_ByNames(
                items,
                nameSelector,
                orderedNames);

            return output;
        }

        public static IEnumerable<T> OrderByNames<T>(this IEnumerable<T> items,
            Func<T, string> nameSelector,
            params string[] orderedNames)
        {
            return items.OrderByNames(
                nameSelector,
                orderedNames.AsEnumerable());
        }

        public static HashSet<T> To_HashSet<T>(this IEnumerable<T> values)
            => Instances.EnumerableOperator.To_HashSet(values);

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