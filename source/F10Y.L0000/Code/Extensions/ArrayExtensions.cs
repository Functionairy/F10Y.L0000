using System;


namespace F10Y.L0000.Extensions
{
    public static class ArrayExtensions
    {
        public static bool Contains<T>(this T[] array,
            T value)
            => Instances.ArrayOperator.Contains(
                array,
                value);

        public static T[] Empty_IfNull<T>(this T[] array)
            => Instances.ArrayOperator.Empty_IfNull(array);

        public static int Get_IndexOfLast(this Array array)
            => Instances.ArrayOperator.Get_IndexOfLast(array);

        public static T[] Null_IfEmpty<T>(this T[] array)
            => Instances.ArrayOperator.Null_IfEmpty(array);
    }
}
