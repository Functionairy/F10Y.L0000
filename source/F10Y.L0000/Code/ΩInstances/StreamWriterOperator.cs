using System;


namespace F10Y.L0000
{
    public class StreamWriterOperator : IStreamWriterOperator
    {
        #region Infrastructure

        public static IStreamWriterOperator Instance { get; } = new StreamWriterOperator();


        private StreamWriterOperator()
        {
        }

        #endregion
    }
}
