using System;


namespace F10Y.L0000
{
    public class EncodingOperator : IEncodingOperator
    {
        #region Infrastructure

        public static IEncodingOperator Instance { get; } = new EncodingOperator();


        private EncodingOperator()
        {
        }

        #endregion
    }
}
