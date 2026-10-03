using System;


namespace F10Y.L0000
{
    public class ConversionOperator : IConversionOperator
    {
        #region Infrastructure

        public static IConversionOperator Instance { get; } = new ConversionOperator();


        private ConversionOperator()
        {
        }

        #endregion
    }
}
