using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IFilePaths
    {
        public string Executable => Instances.ExecutablePathOperator.Get_ExecutableFilePath();
    }
}
