using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IIntegerOperator
    {
        /// <summary>
        /// Returns true if X is greater than, or equal to, Y.
        /// </summary>
        public bool GreaterThan_OrEqualTo(
            int x,
            int y)
        {
            var output = x >= y;
            return output;
        }

        public bool GreaterThan_OrEqualTo_Zero(int value)
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
        public bool GreaterThan(
            int x,
            int y)
        {
            var output = x >= y;
            return output;
        }

        public bool Is_Equal(int a, int b)
        {
            var output = a.Equals(b);
            return output;
        }

        public bool Is_NotEqual(int a, int b)
        {
            var output = !this.Is_Equal(a, b);
            return output;
        }

        public bool Is_LessThanZero(int integer)
            => integer < Instances.Integers.Zero;

        public bool Is_Negative(int integer)
            => this.Is_LessThanZero(integer);

        public string To_String(int integer)
            => integer.ToString();
    }
}
