using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOffsetOperator
    {
        string Format(
            DateTimeOffset dateTimeOffset,
            string template)
        {
            var output = Instances.StringOperator.Format(
                template,
                dateTimeOffset);

            return output;
        }

        DateTimeOffset From_DateTime_Local(DateTime dateTimeLocal)
        {
            var localOffset = this.Get_LocalOffsetFromUtc();

            var dateTimeOffset = new DateTimeOffset(dateTimeLocal, localOffset);

            return dateTimeOffset;
        }

        /// <summary>
        /// Result is the time at UTC.
        /// <para>
        /// See: <see cref="DateTimeOffset.FromUnixTimeMilliseconds(long)"/>
        /// </para>
        /// </summary>
        DateTimeOffset From_UnixMilliseconds(long unix_Milliseconds)
        {
            var output = DateTimeOffset.FromUnixTimeMilliseconds(unix_Milliseconds);
            return output;
        }

        DateTimeOffset From_UnixMilliseconds(ulong unix_Milliseconds)
        {
            var unix_Milliseconds_Long = Instances.ConversionOperator.To_Long(unix_Milliseconds);

            var output = this.From_UnixMilliseconds(unix_Milliseconds_Long);
            return output;
        }

        TimeSpan Get_LocalOffsetFromUtc()
        {
            var currentOffset = Instances.TimeSpanOperator.Get_OffsetFromUtc();
            return currentOffset;
        }

        DateTime Get_Local(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.LocalDateTime;

        DateTime Get_UTC(DateTimeOffset dateTimeOffset)
            => dateTimeOffset.UtcDateTime;

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
