using System;
using System.Reflection;

using F10Y.T0002;


namespace F10Y.L0000.Internal
{
    [FunctionsMarker]
    public partial interface IAssemblyOperator
    {
        private static L0000.IAssemblyOperator _AssemblyOperator => L0000.AssemblyOperator.Instance;


        public Assembly Get_F10Y_L0000_Assembly()
            => _AssemblyOperator.Get_ExecutingAssembly();

        public Assembly Get_NetStandard2_1_FoundationLibrary_Assembly()
            => this.Get_F10Y_L0000_Assembly();
    }
}
