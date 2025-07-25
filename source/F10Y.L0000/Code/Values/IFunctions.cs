using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IFunctions
    {
        // Need an attribute that explicitly states what this value is.
        public IFunctions<T> For<T>() => Functions<T>.Instance;

        /// <summary>
        /// Simply returns the input value.
        /// </summary>
        /// <remarks>
        /// This can be useful as the selector argument value for a higher-order function (functions taking a function as an input).
        /// </remarks>
        // Need an attribute that explicitly states what this value is.
        public T Return<T>(T value)
            => value;
    }


    [ValuesMarker]
    public partial interface IFunctions<T>
    {
        public Func<T, T> Return => x => x;
    }
}
