using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnumerationOperator
    {
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
