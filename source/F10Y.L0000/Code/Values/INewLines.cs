using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface INewLines
    {
        /// <summary>
        /// The new line value for the current environment (Windows on Windows, non-Windows on non-Windows).
        /// </summary>
        public string Environment => Instances.EnvironmentOperator.Get_NewLine();

        /// <summary>
        /// <para><value>/r/n</value></para>
        /// </summary>
        public string NonWindows => "/n";

        /// <summary>
        /// <para><value>/r/n</value></para>
        /// </summary>
        public string Windows => "/r/n";
    }
}
