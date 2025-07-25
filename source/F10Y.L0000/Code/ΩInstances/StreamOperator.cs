using System;


namespace F10Y.L0000
{
    public class StreamOperator : IStreamOperator
    {
        #region Infrastructure

        public static IStreamOperator Instance { get; } = new StreamOperator();


        private StreamOperator()
        {
        }

        #endregion
    }
}
