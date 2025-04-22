using System;


namespace F10Y.L0000
{
    public class ProcessOperator : IProcessOperator
    {
        #region Infrastructure

        public static IProcessOperator Instance { get; } = new ProcessOperator();


        private ProcessOperator()
        {
        }

        #endregion
    }
}
