using System;


namespace F10Y.L0000
{
    public class FunctionOperator : IFunctionOperator
    {
        #region Infrastructure

        public static IFunctionOperator Instance { get; } = new FunctionOperator();


        private FunctionOperator()
        {
        }

        #endregion
    }
}
