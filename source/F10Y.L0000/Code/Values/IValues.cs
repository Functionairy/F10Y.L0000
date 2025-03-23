using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IValues
    {
        /// <summary>
		/// The value for the command line to have no arguments is null.
		/// </summary>
		public string EmptyCommandArguments => null;
    }
}
