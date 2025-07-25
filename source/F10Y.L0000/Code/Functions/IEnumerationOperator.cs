using System;

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
    }
}
