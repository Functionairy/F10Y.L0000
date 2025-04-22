using System;


namespace F10Y.L0000
{
    public class ExitCodeOperator : IExitCodeOperator
    {
        #region Infrastructure

        public static IExitCodeOperator Instance { get; } = new ExitCodeOperator();


        private ExitCodeOperator()
        {
        }

        #endregion
    }
}
