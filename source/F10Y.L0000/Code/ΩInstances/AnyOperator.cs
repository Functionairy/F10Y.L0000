using System;


namespace F10Y.L0000
{
    public class AnyOperator : IAnyOperator
    {
        #region Infrastructure

        public static IAnyOperator Instance { get; } = new AnyOperator();


        private AnyOperator()
        {
        }

        #endregion
    }
}
