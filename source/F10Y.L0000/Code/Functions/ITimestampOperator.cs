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
        /// Uses <see cref="INowOperator.Get_Now_UTC"/>.
        /// (Timestamps are in UTC by default.)
        /// </remarks>
        DateTime Stamp()
            => Instances.NowOperator.Get_Now_UTC();

        /// <summary>
        /// Gets a timestamp.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="INowOperator.Get_Now_Local"/>.
        /// (Timestamps are in UTC by default.)
        /// </remarks>
        DateTime Stamp_Local()
            => Instances.NowOperator.Get_Now_Local();
    }
}
