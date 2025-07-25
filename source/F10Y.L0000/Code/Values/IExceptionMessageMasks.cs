using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IExceptionMessageMasks
    {
        /// <summary>
        /// <para><value>Attribute '{0}' not found.</value></para>
        /// </summary>
        public string AttributeNotFound => "Attribute '{0}' not found.";

        /// <summary>
        /// <para><value>Invalid length: {0}.\nLength must be greater-than-or-equal-to zero.</value></para>
        /// </summary>
        public string InvalidLength => "Invalid length: {0}.\nLength must be greater-than-or-equal-to zero.";
    }
}
