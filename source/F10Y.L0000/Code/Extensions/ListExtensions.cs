using System;
using System.Collections.Generic;


namespace F10Y.L0000.Extensions
{
    public static class ListExtensions
    {
        public static T Get_First<T>(this IList<T> list)
            => Instances.ListOperator.Get_First(list);

        public static T Get_Second<T>(this IList<T> list)
            => Instances.ListOperator.Get_Second(list);

        public static T Get_Last<T>(this IList<T> list)
            => Instances.ListOperator.Get_Last(list);
    }
}
