using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IIndices
    {
        /// <summary>
        /// <para><value>-1</value></para>
        /// </summary>
        public int Negative_One => -1;

        /// <summary>
        /// <para><value>0</value></para>
        /// </summary>
        public int Zero => 0;

        /// <summary>
        /// <para><value>1</value></para>
        /// </summary>
        public int One => 1;

        /// <summary>
        /// <para><inheritdoc cref="Negative_One" path="descendant::value"/></para>
        /// Throughout the .NET standard library, the index <inheritdoc cref="Negative_One" path="descendant::value"/> is returned to indicate that a value was not found.
        /// </summary>
        public int NotFound => this.Negative_One;
    }
}
