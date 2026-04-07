using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IFunctions
    {
        // Need an attribute that explicitly states what this value is.
        IFunctions<T> For<T>() => Functions<T>.Instance;

        /// <summary>
        /// Simply returns the input value.
        /// </summary>
        /// <remarks>
        /// This can be useful as the selector argument value for a higher-order function (functions taking a function as an input).
        /// </remarks>
        // Need an attribute that explicitly states what this value is.
        T Return<T>(T value)
            => value;

        /// <summary>
        /// For a value of a type, ignore the value, and return the default value for that type.
        /// (Null for references types, initial state for value types.)
        /// </summary>
        T Return_Default<T>(T value)
            => default;

        /// <summary>
        /// For a value of a type, ignore the value, and return false.
        /// </summary>
        bool Return_False<T>(T value)
            => false;
    }


    [ValuesMarker]
    public partial interface IFunctions<T>
    {
        Func<T, T> Return => x => x;

        Func<T, bool> Return_False => x => false;

        Func<T, bool> Return_True => x => true;
    }
}
