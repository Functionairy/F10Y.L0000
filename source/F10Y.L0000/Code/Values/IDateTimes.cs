using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDateTimes
    {
        /// <summary>
        /// The maximum value of date time.
        /// </summary>
        /// <remarks>
        /// Returns <see cref="DateTime.MaxValue"/>.
        /// </remarks>
        DateTime Maximum => DateTime.MaxValue;

        /// <summary>
        /// The minimum value of date time.
        /// </summary>
        /// <remarks>
        /// Returns <see cref="DateTime.MinValue"/>.
        /// </remarks>
        DateTime Minimum => DateTime.MinValue;

        /// <inheritdoc cref="INowOperator.Get_Now_Local"/>
        DateTime Now_Local => Instances.NowOperator.Get_Now_Local();

        /// <inheritdoc cref="INowOperator.Get_Now_UTC"/>
        DateTime Now_UTC => Instances.NowOperator.Get_Now_UTC();
    }
}
