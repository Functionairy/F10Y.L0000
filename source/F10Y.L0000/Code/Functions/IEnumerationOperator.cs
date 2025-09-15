using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnumerationOperator
    {
        public string Get_StringRepresentation<TEnum>(TEnum @enum)
            where TEnum : Enum
        {
            var output = @enum.ToString();
            return output;
        }

        public TEnum Get_Value<TEnum>(string valueString)
            where TEnum : Enum
        {
            var value = (TEnum)Enum.Parse(typeof(TEnum), valueString);
            return value;
        }

        public TOut Switch_OnValue<TEnum, TOut>(
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
    }
}
