using System;


namespace F10Y.L0000
{
    public class TypeInfoOperator : ITypeInfoOperator
    {
        #region Infrastructure

        public static ITypeInfoOperator Instance { get; } = new TypeInfoOperator();


        private TypeInfoOperator()
        {
        }

        #endregion
    }
}
