using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnumerableOperator
    {
        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
            => this.Append_Many(
                enumerable,
                appendix);

        public IEnumerable<T> Append_Many<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
            => Enumerable.Concat(
                enumerable,
                appendix);

        public IEnumerable<T> Empty<T>()
            => Enumerable.Empty<T>();

        public IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

        /// <summary>
        /// Returns a new, empty enumerable.
        /// </summary>
        public IEnumerable<T> New<T>()
            => this.Empty<T>();

        /// <summary>
        /// Sorts the elements of a sequence in ascending order.
        /// </summary>
        /// <remarks>
        /// As-of .NET 7, this method is a provided by a built-in extension method.
        /// <para>See: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.order?view=net-7.0"/></para>
        /// </remarks>
        public IOrderedEnumerable<T> Order_Ascending<T>(IEnumerable<T> enumerable)
            => enumerable.OrderBy(x => x);

        /// <summary>
        /// Sorts the elements of a sequence in descending order.
        /// </summary>
        /// <remarks>
        /// As-of .NET 7, this method is a provided by a built-in extension method.
        /// <para>See: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderdescending?view=net-7.0"/></para>
        /// </remarks>
        public IOrderedEnumerable<T> Order_Descending<T>(IEnumerable<T> enumerable)
            => enumerable.OrderByDescending(x => x);

        /// <summary>
        /// Chooses <see cref="Order_Ascending{T}(IEnumerable{T})"/> as the default.
        /// </summary>
        public IOrderedEnumerable<T> Order<T>(IEnumerable<T> enumerable)
            => enumerable.OrderBy(x => x);

        public IEnumerable<(T, T)> Zip<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
        {
            var output = a.Zip(
                b,
                (a, b) => (a, b));

            return output;
        }
    }
}
