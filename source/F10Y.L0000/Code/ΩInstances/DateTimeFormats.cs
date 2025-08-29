using System;


namespace F10Y.L0000
{
    public class DateTimeFormats : IDateTimeFormats
    {
        #region Infrastructure

        public static IDateTimeFormats Instance { get; } = new DateTimeFormats();


        private DateTimeFormats()
        {
        }

        #endregion
    }
}
