using System;


namespace F10Y.L0000
{
    public class ActionOperator : IActionOperator
    {
        #region Infrastructure

        public static IActionOperator Instance { get; } = new ActionOperator();


        private ActionOperator()
        {
        }

        #endregion
    }
}
