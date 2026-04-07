using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ISwitchOperator
    {
        /// <summary>
        /// Produces an exception for use in the default case of a switch statement based on values of the <typeparamref name="TEnum"/> enumeration.
        /// Note: there is no method just throwing the exception, as the VS linter does not detect that a method call will always produce an exception, and thus demands that switch default case behavior cannot fall through one default case to another. The throw keyword in the switch default case must be present.
        /// </summary>
        Exception Get_DefaultCaseException_ForEnumeration<TEnum>(TEnum value)
            where TEnum : Enum
        {
            var exception = this.Get_UnexpectedEnumerationValueException(value);
            return exception;
        }

        Exception Get_DefaultCaseException<TValue>(TValue switchValue)
        {
            var message = $"{switchValue}: unhandled switch value";

            var output = Instances.ExceptionOperator.From(message);
            return output;
        }

        /// <summary>
        /// Returns an exception with a message generated using the type (<see cref="ITypeOperator.Get_Type{T}(T)"/>) of the given value.
        /// </summary>
        Exception Get_DefaultCaseException_ForType<T>(
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
        Exception Get_DefaultCaseException_ForType<T>(
            T value,
            Func<string, string> message_FromTypeName_Generator)
        {
            var typeName = Instances.TypeOperator.Get_TypeName(value);

            var message = message_FromTypeName_Generator(typeName);

            var output = Instances.ExceptionOperator.From(message);
            return output;
        }

        /// <inheritdoc cref="IEnumerationOperator.Get_UnexpectedEnumerationValueException{TEnum}(TEnum)"/>
        Exception Get_UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = Instances.EnumerationOperator.Get_UnexpectedEnumerationValueException(unexpectedValue);
            return output;
        }

        ArgumentException Get_UnrecognizedSwitchTypeExpression<T>(T value)
        {
            var typeName = Instances.TypeOperator.Get_TypeNameOf(value);

            var exception = new ArgumentException($"{typeName} - Unrecognized type.");
            return exception;
        }
    }
}
