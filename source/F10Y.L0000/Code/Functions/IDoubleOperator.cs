using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDoubleOperator
    {
        /// <summary>
        /// Converts a double to a string representation with three decimal places.
        /// </summary>
        public string To_String_WithThreeDecimalPlaces(double value)
        {
            var output = $"{value:0.000}";
            return output;
        }
    }
}
