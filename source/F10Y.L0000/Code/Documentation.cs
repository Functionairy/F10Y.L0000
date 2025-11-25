using System;

using F10Y.T0001;


namespace F10Y.L0000
{
	/// <summary>
	/// .NET Standard 2.1 foundation library. (general, unopinionated, zero-dependency, functions and values only)
	/// </summary>
	[DocumentationsMarker]
	public static class Documentation
	{
        /// <inheritdoc cref="Documentation" path="/summary"/>
        /// <reference>
        /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
        /// </reference>
        public static readonly object Project_SelfDescription;

        /// <summary>
        /// Input are null-checked.
        /// </summary>
        public static readonly object Inputs_NullChecked;

        /// <summary>
        /// Input are not null-checked.
        /// </summary>
        public static readonly object Inputs_NullChecked_Not;
    }
}