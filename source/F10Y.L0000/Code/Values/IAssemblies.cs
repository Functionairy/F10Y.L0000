using System;
using System.Reflection;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IAssemblies
    {
        public Assembly Current => Instances.AssemblyOperator.Get_ExecutingAssembly();
        public Assembly System_Core => Instances.AssemblyOperator.Get_System_CoreAssembly();

        public Assembly F10Y_L0000 => this.Current;
    }
}
