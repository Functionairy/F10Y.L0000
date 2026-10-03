using System;


namespace F10Y.L0000
{
    public class MathOperator : IMathOperator
    {
        #region Infrastructure

        public static IMathOperator Instance { get; } = new MathOperator();


        private MathOperator()
        {
        }

        #endregion
    }
}
