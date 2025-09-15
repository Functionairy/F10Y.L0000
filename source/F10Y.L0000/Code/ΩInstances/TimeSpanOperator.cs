using System;


namespace F10Y.L0000
{
    public class TimeSpanOperator : ITimeSpanOperator
    {
        #region Infrastructure

        public static ITimeSpanOperator Instance { get; } = new TimeSpanOperator();


        private TimeSpanOperator()
        {
        }

        #endregion
    }
}
