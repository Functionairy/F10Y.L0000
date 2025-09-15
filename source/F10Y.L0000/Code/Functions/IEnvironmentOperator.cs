using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnvironmentOperator
    {
        public void Exit(int exitCode)
            => Environment.Exit(exitCode);

        public void Exit_AsFailure()
            => Environment.Exit(
                Instances.ExitCodes.Failure);

        public void Exit_AsSuccess()
            => Environment.Exit(
                Instances.ExitCodes.Success);

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate"/>
        public char Get_DirectorySeparator_Alternate()
            => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate();

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment"/>
        public char Get_DirectorySeparator()
            => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment();

        /// <inheritdoc cref="Environment.GetCommandLineArgs"/>
        public string[] Get_CommandLineArguments()
            => Environment.GetCommandLineArgs();

        public string Get_CommandLineArgument_First()
        {
            var commandLineArguments = this.Get_CommandLineArguments();

            var output = Instances.ArrayOperator.Get_First(commandLineArguments);
            return output;
        }

        public string Get_ExecutableFilePath()
        {
            var commandLineArguments = this.Get_CommandLineArguments();

            var output = this.Get_ExecutableFilePath(commandLineArguments);
            return output;
        }

        public string Get_ExecutableFilePath(string[] commandLineArguments)
        {
            // In .NET, the file path for the currently executing executable is the first argument.
            var output = Instances.ArrayOperator.Get_First(commandLineArguments);
            return output;
        }

        /// <summary>
        /// Gets the name of the current environment.
        /// </summary>
        public string Get_Name()
        {
            var os = this.Get_OperatingSystem();

            var output = os.ToString();
            return output;
        }

        public string Get_NewLine()
            => Environment.NewLine;

        public OperatingSystem Get_OperatingSystem()
        {
            var output = Environment.OSVersion;
            return output;
        }

        public string Get_SpecialDirectoryPath(Environment.SpecialFolder specialFolder)
        {
            var output = Environment.GetFolderPath(specialFolder);
            return output;
        }

        /// <summary>
        /// Gets the system directory path for the current user.
        /// </summary>
        /// <remarks>
        /// Returns the value for <see cref="Environment.SpecialFolder.UserProfile"/>,
        /// which is <inheritdoc cref="Y0000.Documentation.For_Directories.UserProfile_OnWindows" path="descendant::summary"/>.
        /// </remarks>
        public string Get_UserProfileDirectoryPath()
            => this.Get_SpecialDirectoryPath(Environment.SpecialFolder.UserProfile);
    }
}
