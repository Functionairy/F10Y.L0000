using System;


namespace F10Y.L0000
{
    public class AbsoluteValueOperator : IAbsoluteValueOperator
    {
        #region Infrastructure

        public static IAbsoluteValueOperator Instance { get; } = new AbsoluteValueOperator();


        private AbsoluteValueOperator()
        {
        }

        #endregion
    }
}
