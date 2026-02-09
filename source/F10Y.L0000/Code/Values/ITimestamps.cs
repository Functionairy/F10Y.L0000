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
        /// Timestamps are in UTC by default.
        /// </remarks>
        DateTime Now
            => Instances.TimestampOperator.Stamp();

        DateTime Now_Local
            => Instances.TimestampOperator.Stamp_Local();
    }
}
