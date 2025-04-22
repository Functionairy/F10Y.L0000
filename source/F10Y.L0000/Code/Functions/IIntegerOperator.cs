using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IIntegerOperator
    {
        public bool Is_LessThanZero(int integer)
            => integer < Instances.Integers.Zero;

        public bool Is_Negative(int integer)
            => this.Is_LessThanZero(integer);

        public string To_String(int integer)
            => integer.ToString();
    }
}
