using System;


namespace F10Y.L0000
{
    public class AssemblyNameOperator : IAssemblyNameOperator
    {
        #region Infrastructure

        public static IAssemblyNameOperator Instance { get; } = new AssemblyNameOperator();


        private AssemblyNameOperator()
        {
        }

        #endregion
    }
}
