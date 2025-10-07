using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnvironmentOperator
    {
        void Exit(int exitCode)
            => Environment.Exit(exitCode);

        void Exit_AsFailure()
            => Environment.Exit(
                Instances.ExitCodes.Failure);

        void Exit_AsSuccess()
            => Environment.Exit(
                Instances.ExitCodes.Success);

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate"/>
        char Get_DirectorySeparator_Alternate()
            => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment_Alternate();

        /// <inheritdoc cref="IDirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment"/>
        char Get_DirectorySeparator()
            => Instances.DirectorySeparatorOperator.Get_DirectorySeparator_ForEnvironment();

        /// <inheritdoc cref="Environment.GetCommandLineArgs"/>
        string[] Get_CommandLineArguments()
            => Environment.GetCommandLineArgs();

        string Get_CommandLineArgument_First()
        {
            var commandLineArguments = this.Get_CommandLineArguments();

            var output = Instances.ArrayOperator.Get_First(commandLineArguments);
            return output;
        }

        DriveInfo Get_DriveInformation(string driveName = IValues.C_DriveName_Constant)
            => new DriveInfo(driveName);

        string Get_ExecutableFilePath()
        {
            var commandLineArguments = this.Get_CommandLineArguments();

            var output = this.Get_ExecutableFilePath(commandLineArguments);
            return output;
        }

        string Get_ExecutableFilePath(string[] commandLineArguments)
        {
            // In .NET, the file path for the currently executing executable is the first argument.
            var output = Instances.ArrayOperator.Get_First(commandLineArguments);
            return output;
        }

        /// <summary>
        /// Gets the name of the machine on which code is currently executing.
        /// </summary>
        string Get_MachineName()
        {
            var output = Environment.MachineName;
            return output;
        }

        /// <summary>
        /// Gets the name of the current environment.
        /// </summary>
        string Get_Name()
        {
            var os = this.Get_OperatingSystem();

            var output = os.ToString();
            return output;
        }

        string Get_NewLine()
            => Environment.NewLine;

        OperatingSystem Get_OperatingSystem()
        {
            var output = Environment.OSVersion;
            return output;
        }

        string Get_SpecialDirectoryPath(Environment.SpecialFolder specialFolder)
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
        string Get_UserProfileDirectoryPath()
            => this.Get_SpecialDirectoryPath(Environment.SpecialFolder.UserProfile);

        /// <summary>
        /// Determines if the current machine has the given name.
        /// </summary>
        public bool Is_CurrentMachineName(string machineName)
        {
            var currentMachineName = this.Get_MachineName();

            var output = currentMachineName == machineName;
            return output;
        }

        /// <summary>
        /// Verifies that the current machine has the given name.
        /// </summary>
        /// <remarks>
        /// Useful for ensuring that some code is only run on a particular machine.
        /// </remarks>
        public void Verify_CurrentMachineNameIs(string machineName)
        {
            var isMachineName = this.Is_CurrentMachineName(machineName);
            if (!isMachineName)
            {
                var currentMachineName = this.Get_MachineName();

                throw new Exception($"'{currentMachineName}': machine name was not '{machineName}'.");
            }
        }
    }
}
