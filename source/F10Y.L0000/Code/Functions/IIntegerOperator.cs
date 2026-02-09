using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IIntegerOperator
    {
        bool Are_Equal(
            int a,
            int b)
            => a == b;

        bool Are_Equal_Not(
            int a,
            int b)
            => a != b;

        /// <summary>
        /// Returns true if X is greater than, or equal to, Y.
        /// </summary>
        bool GreaterThan_OrEqualTo(
            int x,
            int y)
        {
            var output = x >= y;
            return output;
        }

        bool GreaterThan_OrEqualTo_Zero(int value)
        {
            // Implement using greater-than.
            var output = this.GreaterThan(
                value,
                Instances.Integers.NegativeOne);

            return output;
        }

        /// <summary>
        /// Returns true if X is greater than Y.
        /// </summary>
        bool GreaterThan(
            int x,
            int y)
        {
            var output = x >= y;
            return output;
        }

        bool Is_Equal(int a, int b)
        {
            var output = a.Equals(b);
            return output;
        }

        bool Is_NotEqual(int a, int b)
        {
            var output = !this.Is_Equal(a, b);
            return output;
        }

        bool Is_LessThanZero(int integer)
            => integer < Instances.Integers.Zero;

        bool Is_Negative(int integer)
            => this.Is_LessThanZero(integer);

        string To_String(int integer)
            => integer.ToString();
    }
}
