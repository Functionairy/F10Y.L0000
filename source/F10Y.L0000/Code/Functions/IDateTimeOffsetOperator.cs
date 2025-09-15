using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOffsetOperator
    {
        public string Format(
            DateTimeOffset dateTimeOffset,
            string template)
        {
            var output = Instances.StringOperator.Format(
                template,
                dateTimeOffset);

            return output;
        }

        public DateTimeOffset From_DateTime_Local(DateTime dateTimeLocal)
        {
            var localOffset = this.Get_LocalOffsetFromUtc();

            var dateTimeOffset = new DateTimeOffset(dateTimeLocal, localOffset);

            return dateTimeOffset;
        }

        public TimeSpan Get_LocalOffsetFromUtc()
        {
            var currentOffset = Instances.TimeSpanOperator.Get_OffsetFromUtc();
            return currentOffset;
        }

        public DateTime Get_Local(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.LocalDateTime;

        public DateTime Get_UTC(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.LocalDateTime;

        DateTimeOffset Get_DateTimeOffset_Of(DateTime dateTime)
            => new DateTimeOffset(dateTime);

        /// <inheritdoc cref="DateTimeOffset.MinValue"/>
        DateTimeOffset Get_Minimum() => DateTimeOffset.MinValue;

        /// <inheritdoc cref="DateTimeOffset.Now"/>
        DateTimeOffset Get_Now_Local() => DateTimeOffset.Now;

        /// <inheritdoc cref="DateTimeOffset.UtcNow"/>
        DateTimeOffset Get_Now_Utc() => DateTimeOffset.UtcNow;

        /// <inheritdoc cref="Get_Now_Local" path="/summary"/>
        /// <remarks>
        /// Chooses <see cref="Get_Now_Local"/> as the default.
        /// </remarks>
        DateTimeOffset Get_Now()
            => this.Get_Now_Local();

        DateTimeOffset Get_Utc_ForLocal(DateTime local)
        {
            var dateTimeOffset = this.Get_DateTimeOffset_Of(local);

            var output = this.Get_Utc_ForLocal(dateTimeOffset);
            return output;
        }

        DateTimeOffset Get_Utc_ForLocal(DateTimeOffset local)
            => local.UtcDateTime;
    }
}
