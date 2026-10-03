using System;
using System.Globalization;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDecimalOperator
    {
        bool Are_Equal(decimal a, decimal b)
            => Decimal.Equals(a, b);

        decimal From(double value)
            => Convert.ToDecimal(value);

        decimal From(string value)
            => this.Parse(value);

        decimal Get_AbsoluteValue(decimal value)
            => value < Instances.Decimals.Zero
                ? this.Negate(value)
                : value
                ;

        bool Is_Zero(decimal value)
            => value == Instances.Decimals.Zero;

        bool Is_NotZero(decimal value)
            => !this.Is_Zero(value);

        decimal Multiply(decimal a, decimal b)
            => a * b;

        decimal Negate(decimal value)
            => -value;

        bool Not_AreEqual(decimal a, decimal b)
            => !this.Are_Equal(a, b);

        /// <inheritdoc cref="Decimal.Parse(string)"/>
        decimal Parse(string value)
        {
            var output = Decimal.Parse(value);
            return output;
        }

        decimal Parse(
            string value,
            NumberStyles numberStyles,
            CultureInfo cultureInfo)
            => Decimal.Parse(value, numberStyles, cultureInfo);

        /// <summary>
        /// Works for strings like "-$9.26".
        /// </summary>
        /// <remarks>
        /// Uses <see cref="INumberStylesSets.Currency"/> and <see cref="ICultureInfos.en_US"/>.
        /// </remarks>
        decimal Parse_FromDollars(string value_Currency)
            => this.Parse(value_Currency, Instances.NumberStylesSets.Currency, Instances.CultureInfos.en_US);

        /// <summary>
        /// a - b
        /// </summary>
        decimal Subtract(decimal a, decimal b)
            => a - b;

        string To_String_0_00(decimal value)
            => $"{value:0.00}";

        string To_String_Dollars(decimal value)
            => $"{value:$#,##0.00}";

        string To_String_Percent_0_00(decimal value)
            => $"{value:0.00%}";

        string To_String_Percent_PlusAndMinus_0_00(decimal value)
            => $"{value:+0.00%;-0.00%}";

        string To_String(decimal value)
            => value.ToString();

        bool Try_Parse(
            string value,
            NumberStyles numberStyles,
            CultureInfo cultureInfo,
            out decimal value_OrDefault)
            => Decimal.TryParse(value, numberStyles, cultureInfo,
                out value_OrDefault);

        /// <inheritdoc cref="Parse_FromDollars(string)"/>
        bool Try_Parse_FromDollars(
            string value,
            out decimal value_OrDefault)
            => this.Try_Parse(value, Instances.NumberStylesSets.Currency, Instances.CultureInfos.en_US,
                out value_OrDefault);
    }
}
