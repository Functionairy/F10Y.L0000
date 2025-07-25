using System;


namespace F10Y.L0000
{
    public class TypeNameOperator : ITypeNameOperator
    {
        #region Infrastructure

        public static ITypeNameOperator Instance { get; } = new TypeNameOperator();


        private TypeNameOperator()
        {
        }

        #endregion
    }
}
