using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITimestampOperator
    {
        /// <summary>
        /// Gets a timestamp.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="INowOperator.Get_Now_Utc"/>.
        /// (Timestamps are always in UTC.)
        /// </remarks>
        DateTime Stamp()
            => Instances.NowOperator.Get_Now_Utc();
    }
}
