using System;


namespace F10Y.L0000
{
    public class DateTimeOffsets : IDateTimeOffsets
    {
        #region Infrastructure

        public static IDateTimeOffsets Instance { get; } = new DateTimeOffsets();


        private DateTimeOffsets()
        {
        }

        #endregion
    }
}
