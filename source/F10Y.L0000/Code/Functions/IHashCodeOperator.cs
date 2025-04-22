using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHashCodeOperator
    {
        public int Default<T>(T obj)
            => obj.GetHashCode();
    }
}
