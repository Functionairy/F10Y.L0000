using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExecutablePathOperator
    {
        public string Get_ExecutableFilePath()
            => Instances.EnvironmentOperator.Get_ExecutableFilePath();

        public string Get_ExecutableDirectoryPath()
        {
            var executableFilePath = this.Get_ExecutableFilePath();

            var output = this.Get_ExecutableDirectoryPath(executableFilePath);
            return output;
        }

        public string Get_ExecutableDirectoryPath(string executableFilePath)
        {
            var executableDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(executableFilePath);
            return executableDirectoryPath;
        }

        public string Get_Path_FromExecutableDirectoryRelativePath(string path_ExecutableDirectoryRelative)
        {
            var executableDirectoryPath = this.Get_ExecutableDirectoryPath();

            /// TODO: needs to test the relative path to make sure it it not root-indicated, since <see cref="System.IO.Path.Combine(string, string)"/> fails if the relative path is root-indicated.
            var output = Instances.PathOperator.Get_Path(
                executableDirectoryPath,
                path_ExecutableDirectoryRelative);

            return output;
        }
    }
}
