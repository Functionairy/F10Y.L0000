using System;


namespace F10Y.L0000
{
    public class ExceptionMessageOperator : IExceptionMessageOperator
    {
        #region Infrastructure

        public static IExceptionMessageOperator Instance { get; } = new ExceptionMessageOperator();


        private ExceptionMessageOperator()
        {
        }

        #endregion
    }
}
