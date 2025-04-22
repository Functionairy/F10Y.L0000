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

        /// <summary>
        /// Returns a new, empty enumerable.
        /// </summary>
        public IEnumerable<T> New<T>()
            => this.Empty<T>();

        public IEnumerable<T> From<T>(T instance)
        {
            yield return instance;
        }

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
