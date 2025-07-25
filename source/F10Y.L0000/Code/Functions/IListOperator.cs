using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IListOperator
    {
        public int Get_Count<T>(IList<T> list)
            => list.Count;

        public T Get_First<T>(IList<T> list)
        {
            // IList<T> is always zero based.
            var output = list[0];
            return output;
        }

        public T Get_Last<T>(IList<T> list)
        {
            var output = list[^1];
            return output;
        }

        public List<T> New<T>()
            => new List<T>();
    }
}
