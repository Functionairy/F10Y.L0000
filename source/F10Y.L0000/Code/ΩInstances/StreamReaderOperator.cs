using System;


namespace F10Y.L0000
{
    public class StreamReaderOperator : IStreamReaderOperator
    {
        #region Infrastructure

        public static IStreamReaderOperator Instance { get; } = new StreamReaderOperator();


        private StreamReaderOperator()
        {
        }

        #endregion
    }
}
