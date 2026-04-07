using System;
using System.Collections.Generic;
using System.Linq;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnumerationOperator
    {
        bool Are_Equal<TEnum>(
            TEnum a,
            TEnum b)
            where TEnum : Enum
        {
            var output = a.Equals(b);
            return output;
        }

        /// <summary>
        /// Gets a message indicating the the input value of the <typeparamref name="TEnum"/> enumeration was unexpected.
        /// This is useful in producing an error in the default case for switch statements based on enumeration values.
        /// </summary>
        /// <remarks>
        /// See: https://stackoverflow.com/questions/13645149/what-is-the-correct-exception-to-throw-for-unhandled-enum-values
        /// </remarks>
        string Get_UnexpectedEnumerationValueExceptionMessage<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var output = $"Unexpected enumeration value: '{unexpectedValue}' for enumeration type {typeof(TEnum).FullName}";
            return output;
        }

        Exception Get_UnexpectedEnumerationValueException<TEnum>(TEnum unexpectedValue)
            where TEnum : Enum
        {
            var message = this.Get_UnexpectedEnumerationValueExceptionMessage(unexpectedValue);

            var output = new Exception(message);
            return output;
        }

        /// <inheritdoc cref="ISwitchOperator.Get_DefaultCaseException{TEnum}(TEnum)"/>
        Exception Get_DefaultCaseException<TEnum>(TEnum value)
            where TEnum : Enum
            => Instances.SwitchOperator.Get_DefaultCaseException(value);

        string Get_Name<TEnum>(TEnum @enum)
            where TEnum : Enum
            => this.Get_StringRepresentation(@enum);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Same as <see cref="To_String{TEnum}(TEnum)"/>.
        /// </remarks>
        string Get_StringRepresentation<TEnum>(TEnum @enum)
            where TEnum : Enum
        {
            var output = @enum.ToString();
            return output;
        }

        Type Get_Type<TEnum>(TEnum value)
            where TEnum : Enum
            => Instances.TypeOperator.Get_Type_DeclaredType(value);

        Type Get_UnderlyingType(Type enumerationType)
        {
            var output = Enum.GetUnderlyingType(enumerationType);
            return output;
        }

        TEnum Get_Value<TEnum>(string valueString)
            where TEnum : Enum
        {
            var value = (TEnum)Enum.Parse(typeof(TEnum), valueString);
            return value;
        }

        TEnum[] Get_ValuesOf<TEnum>(TEnum value)
            where TEnum : Enum
            => this.Get_Values<TEnum>();

        TEnum[] Get_Values<TEnum>()
            where TEnum : Enum
        {
            var enumerationType = Instances.TypeOperator.Get_Type<TEnum>();

            var output = this.Get_Values<TEnum>(enumerationType);
            return output;
        }

        TEnum[] Get_Values<TEnum>(Type enumerationType)
            where TEnum : Enum
        {
            var array = this.Get_Values_AsArray(enumerationType);

            var values = Instances.ArrayOperator.Cast_To<TEnum>(array);
            return values;
        }

        Array Get_Values_AsArray(Type enuemrationType)
            => Enum.GetValues(enuemrationType);

        bool Has_FirstOrDefault<T>(
            IEnumerable<T> enumerable,
            Func<T, bool> predicate,
            T @default,
            IEqualityComparer<T> equalityComparer,
            out T first_OrDefault)
        {
            first_OrDefault = enumerable
                .Where(predicate)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_Default(
                first_OrDefault,
                @default,
                equalityComparer);

            return output;
        }

        bool Has_FirstOrDefault<T>(
            IEnumerable<T> enumerable,
            Func<T, bool> predicate,
            out T first_OrDefault)
        {
            first_OrDefault = enumerable
                .Where(predicate)
                .FirstOrDefault();

            var output = Instances.DefaultOperator.Is_NotDefault(first_OrDefault);
            return output;
        }

        TOut Switch_OnValue<TEnum, TOut>(
            TEnum value,
            IDictionary<TEnum, TOut> outputs_ByEnumeration,
            TOut @default)
        {
            var output = Instances.DictionaryOperator.Get_Value_OrDefault(
                value,
                outputs_ByEnumeration,
                @default);

            return output;
        }

        TEnum From<TEnum>(int value)
            where TEnum : Enum
            => (TEnum)Enum.ToObject(typeof(TEnum), value);

        int To_Int32<TEnum>(TEnum value)
            where TEnum : Enum
        {
            // Boxing is lame, but it happened when the the enumeration was made into an Enum class instance.
            var output = (int)(IConvertible)value;
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Same as <see cref="Get_StringRepresentation{TEnum}(TEnum)"/>.
        /// </remarks>
        string To_String<TEnum>(TEnum value)
            => value.ToString();
    }
}
