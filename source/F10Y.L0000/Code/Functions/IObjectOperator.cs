using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IObjectOperator
    {
        public void Modify_If<T>(
            T @object,
            bool condition,
            Action<T> modifyAction)
        {
            if (condition)
            {
                modifyAction(@object);
            }
        }

        object New()
            => new object();

        string To_String(object @object)
            => @object.ToString();

        string To_String<T>(T value)
            => value.ToString();

        T Verify_IsType<T>(object @object)
        {
            if (@object is T output)
            {
                return output;
            }
            else
            {
                throw new Exception("Type verification failed.");
            }
        }
    }
}
