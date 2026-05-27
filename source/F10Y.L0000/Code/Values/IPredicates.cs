using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IPredicates
    {
        
    }


    [ValuesMarker]
    public partial interface IPredicates<T>
    {
        /// <summary>
        /// Always returns false.
        /// </summary>
        Func<T, bool> False => x => false;

        /// <summary>
        /// Always returns true.
        /// </summary>
        Func<T, bool> True => x => true;
    }
}
