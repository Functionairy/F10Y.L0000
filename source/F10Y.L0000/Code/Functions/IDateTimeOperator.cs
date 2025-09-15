using System;
using System.Globalization;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDateTimeOperator
    {
        public DateTime Add_Days(
            DateTime dateTime,
            int days_Count)
        {
            var output = dateTime.AddDays(days_Count);
            return output;
        }

        public DateTime Add_Days(
            DateTime dateTime,
            double days)
        {
            var output = dateTime.AddDays(days);
            return output;
        }

        public DateTime From(
            int year,
            int month,
            int day,
            int hour,
            int minute,
            int second)
            => new DateTime(year, month, day, hour, minute, second);

        public DateTime From(
            int hour,
            int minute,
            DateTime today)
        {
            var year = this.Get_Year(today);
            var month = this.Get_Month(today);
            var day = this.Get_Day(today);

            var output = this.From(
                year,
                month,
                day,
                hour,
                minute,
                0);

            return output;
        }

        public DateTime From_Local(
            int hour,
            int minute)
            => this.From(
                hour,
                minute,
                this.Get_Today_Local());

        public string Format(
            DateTime dateTime,
            string formatTemplate)
        {
            var output = Instances.StringOperator.Format(
                formatTemplate,
                dateTime);

            return output;
        }

        public DateTime Get_DayFrom(DateTime now)
        {
            var output = new DateTime(
                now.Year,
                now.Month,
                now.Day);

            return output;
        }

        public DateTime Get_Today_Local()
        {
            var nowLocal = Instances.DateTimeOperator.Get_Now_Local();

            var todayLocal = this.Get_DayFrom(nowLocal);
            return todayLocal;
        }

        public DateTime Get_Today_Utc()
        {
            var nowUtc = Instances.DateTimeOperator.Get_Now_Utc();

            var todayUtc = this.Get_DayFrom(nowUtc);
            return todayUtc;
        }

        public DateTime Get_Tomorrow(DateTime dateTime)
        {
            var tomorrow = this.Add_Days(
                dateTime,
                1);

            return tomorrow;
        }

        public DateTime Get_Tomorrow_Local()
        {
            var todayLocal = this.Get_Today_Local();

            var tomorrowLocal = this.Get_Tomorrow(todayLocal);
            return tomorrowLocal;
        }

        public DateTime Get_Tomorrow_Utc()
        {
            var todayUtc = this.Get_Today_Utc();

            var tomorrowUtc = this.Get_Tomorrow(todayUtc);
            return tomorrowUtc;
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

        public int Get_Day(DateTime dateTime)
        {
            var output = dateTime.Day;
            return output;
        }

        public int Get_Month(DateTime dateTime)
        {
            var output = dateTime.Month;
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
