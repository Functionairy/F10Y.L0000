using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITimeSpanOperator
    {
        public TimeSpan From_Days(int days)
            => new TimeSpan(days, 0, 0, 0);

        public TimeSpan From_Hours(int hours)
            => new TimeSpan(hours, 0, 0);

        public TimeSpan From_Milliseconds(int milliseconds)
            => new TimeSpan(0, 0, 0, 0, milliseconds);

        public TimeSpan From_Minutes(int minutes)
            => new TimeSpan(0, minutes, 0);

        public TimeSpan From_Seconds(int seconds)
            => new TimeSpan(0, 0, seconds);

        public TimeSpan From_Ticks(long ticks)
            => new TimeSpan(ticks);

        /// <summary>
		/// The offset returned satisfies:
		/// local time = UTC time + offset.
		/// </summary>
		/// <returns></returns>
		public TimeSpan Get_OffsetFromUtc()
        {
            var offsetFromUtc = DateTimeOffset.Now.Offset;
            return offsetFromUtc;
        }

        public double Get_Seconds_Total(TimeSpan timeSpan)
            => timeSpan.TotalSeconds;

        public string To_String_NumberOfSeconds_WithMilliseconds(TimeSpan timeSpan)
        {
            var seconds = this.Get_Seconds_Total(timeSpan);

            var representation = Instances.DoubleOperator.To_String_WithThreeDecimalPlaces(seconds);
            return representation;
        }
    }
}
