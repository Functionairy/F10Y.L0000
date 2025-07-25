using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ISwitchOperator
    {
        public Exception Get_DefaultCaseException<TValue>(TValue switchValue)
        {
            var message = $"{switchValue}: unhandled switch value";

            var output = Instances.ExceptionOperator.From(message);
            return output;
        }

        /// <summary>
        /// Returns an exception with a message generated using the type (<see cref="ITypeOperator.Get_Type{T}(T)"/>) of the given value.
        /// </summary>
        public Exception Get_DefaultCaseException_ForType<T>(
            T value,
            Func<Type, string> message_Generator)
        {
            var type = Instances.TypeOperator.Get_Type(value);

            var message = message_Generator(type);

            var output = Instances.ExceptionOperator.From(message);
            return output;
        }

        /// <summary>
        /// Returns an exception with a message generated using the type name (<see cref="ITypeOperator.Get_TypeName{T}(T)"/>) of the given value.
        /// </summary>
        public Exception Get_DefaultCaseException_ForType<T>(
            T value,
            Func<string, string> message_FromTypeName_Generator)
        {
            var typeName = Instances.TypeOperator.Get_TypeName(value);

            var message = message_FromTypeName_Generator(typeName);

            var output = Instances.ExceptionOperator.From(message);
            return output;
        }
    }
}
