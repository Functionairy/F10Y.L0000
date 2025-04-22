using System;


namespace F10Y.L0000
{
    public class StopwatchOperator : IStopwatchOperator
    {
        #region Infrastructure

        public static IStopwatchOperator Instance { get; } = new StopwatchOperator();


        private StopwatchOperator()
        {
        }

        #endregion
    }
}
