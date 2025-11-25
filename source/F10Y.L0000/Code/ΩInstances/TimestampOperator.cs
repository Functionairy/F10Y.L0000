using System;


namespace F10Y.L0000
{
    public class TimestampOperator : ITimestampOperator
    {
        #region Infrastructure

        public static ITimestampOperator Instance { get; } = new TimestampOperator();


        private TimestampOperator()
        {
        }

        #endregion
    }
}
