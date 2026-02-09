using System;


namespace F10Y.L0000
{
    public class DateTimes : IDateTimes
    {
        #region Infrastructure

        public static IDateTimes Instance { get; } = new DateTimes();


        private DateTimes()
        {
        }

        #endregion
    }
}
