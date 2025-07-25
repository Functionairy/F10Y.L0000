using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IExceptions
    {
        /// <summary>
        /// Quality-of-life overload of the <see cref="Null"/> exception.
        /// </summary>
        public Exception None => this.Null;

        /// <summary>
        /// The null value as an exception.
        /// </summary>
        public Exception Null => null;
    }
}
