using System;


namespace F10Y.L0000.Extensions
{
    public static class ObjectExtensions
    {
        public static T Modify_If<T>(this T @object,
           bool condition,
           Action<T> modifyAction)
        {
            Instances.ObjectOperator.Modify_If(
                @object,
                condition,
                modifyAction);

            return @object;
        }
    }
}
