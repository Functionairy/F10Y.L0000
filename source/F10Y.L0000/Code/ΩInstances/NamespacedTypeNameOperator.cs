using System;


namespace F10Y.L0000
{
    public class NamespacedTypeNameOperator : INamespacedTypeNameOperator
    {
        #region Infrastructure

        public static INamespacedTypeNameOperator Instance { get; } = new NamespacedTypeNameOperator();


        private NamespacedTypeNameOperator()
        {
        }

        #endregion
    }
}
