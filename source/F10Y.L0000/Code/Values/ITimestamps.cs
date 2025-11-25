using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ITimestamps
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Timestamps are always in UTC.
        /// </remarks>
        DateTime Now
            => Instances.TimestampOperator.Stamp();
    }
}
