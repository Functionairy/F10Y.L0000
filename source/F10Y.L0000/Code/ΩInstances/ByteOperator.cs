using System;


namespace F10Y.L0000
{
    public class ByteOperator : IByteOperator
    {
        #region Infrastructure

        public static IByteOperator Instance { get; } = new ByteOperator();


        private ByteOperator()
        {
        }

        #endregion
    }
}
