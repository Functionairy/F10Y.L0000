using System;
using System.Globalization;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOperator
    {
        public DateTime From(
            int year,
            int month,
            int day,
            int hour,
            int minute,
            int second)
            => new DateTime(year, month, day, hour, minute, second);

        public string Format(
            DateTime dateTime,
            string formatTemplate)
        {
            var output = Instances.StringOperator.Format(
                formatTemplate,
                dateTime);

            return output;
        }

        public DateTime Get_Now_Local()
        {
            var output = DateTime.Now;
            return output;
        }

        public DateTime Get_Now_Utc()
        {
            var output = DateTime.UtcNow;
            return output;
        }

        /// <summary>
		/// Chooses <see cref="Get_Now_Local"/> as the default.
		/// </summary>
		public DateTime Get_Now()
        {
            var output = this.Get_Now_Local();
            return output;
        }

        public int Get_Year(DateTime dateTime)
        {
            var output = dateTime.Year;
            return output;
        }

        public DateTime Get_Zero()
            => new DateTime();

        /// <summary>
        /// Uses <see cref="IDateTimeFormats.yyyyMMdd"/>.
        /// </summary>
        public DateTime From_YYYYMMDD(string YYYYMMDD)
            => this.Parse_Exact(
                YYYYMMDD,
                Instances.DateTimeFormats.yyyyMMdd);

        public DateTime Parse_Exact(
            string dateTime,
            string format,
            CultureInfo cultureInfo)
        {
            var output = DateTime.ParseExact(dateTime, format, cultureInfo);
            return output;
        }

        /// <summary>
        /// Uses the <see cref="ICultureInfos.Default"/> culture information.
        /// </summary>
        public DateTime Parse_Exact(
            string dateTime,
            string format)
            => this.Parse_Exact(
                dateTime,
                format,
                Instances.CultureInfos.Default);
    }
}
