using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IDirectoryPaths
    {
        string ApplicationData_Local => Instances.EnvironmentOperator.Get_SpecialDirectoryPath(Environment.SpecialFolder.LocalApplicationData);
        string Executable => Instances.ExecutablePathOperator.Get_ExecutableDirectoryPath();
        string Program_Files => Instances.EnvironmentOperator.Get_SpecialDirectoryPath(Environment.SpecialFolder.ProgramFiles);
        string User => Instances.EnvironmentOperator.Get_SpecialDirectoryPath(Environment.SpecialFolder.UserProfile);
    }
}
