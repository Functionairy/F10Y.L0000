using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IListOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        Implementations.IListOperator _Implementations => Implementations.ListOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public int Get_Count<T>(IList<T> list)
            => list.Count;

        public T Get_First<T>(IList<T> list)
        {
            // IList<T> is always zero based.
            var output = list[0];
            return output;
        }

        public T Get_Second<T>(IList<T> list)
        {
            var output = _Implementations.Get_Second_ViaIndex(list);
            return output;
        }

        public T Get_Last<T>(IList<T> list)
        {
            var output = list[^1];
            return output;
        }

        public T Get_Nth<T>(IList<T> list, int n)
        {
            var wasFound = this.Has_Nth(
                list,
                n,
                out var nth);

            if (!wasFound)
            {
                throw new InvalidOperationException($"List did not have an Nth (N = {n}) element.");
            }

            return nth;
        }

        public bool Has_Nth<T>(
            IList<T> list,
            int n,
            out T nthOrDefault)
        {
            var count = list.Count;

            if (n > count)
            {
                nthOrDefault = default;

                return false;
            }

            nthOrDefault = list[n - 1];

            return true;
        }

        public bool Has_Second<T>(
            IList<T> list,
            out T secondOrDefault)
        {
            var output = this.Has_Nth(
                list,
                2,
                out secondOrDefault);

            return output;
        }

        public List<T> New<T>()
            => new List<T>();

        public T[] To_Array<T>(IList<T> list)
            => list.ToArray();
    }
}
