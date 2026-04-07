using System;


namespace F10Y.L0000
{
    public class QueueOperator : IQueueOperator
    {
        #region Infrastructure

        public static IQueueOperator Instance { get; } = new QueueOperator();


        private QueueOperator()
        {
        }

        #endregion
    }
}
