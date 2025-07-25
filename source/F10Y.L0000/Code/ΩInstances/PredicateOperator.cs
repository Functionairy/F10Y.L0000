using System;


namespace F10Y.L0000
{
    public class PredicateOperator : IPredicateOperator
    {
        #region Infrastructure

        public static IPredicateOperator Instance { get; } = new PredicateOperator();


        private PredicateOperator()
        {
        }

        #endregion
    }
}
