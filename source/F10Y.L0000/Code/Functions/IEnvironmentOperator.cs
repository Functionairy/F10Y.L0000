using System;
using System.IO;
using System.Linq;
using F10Y.L0000.Extensions;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnvironmentOperator
    {
        /// <inheritdoc cref="Environment.Exit(int)"/>
        void Exit(int exitCode)
            => Environment.Exit(exitCode);

        /// <summary>
        /// Exits with the <see cref="IExitCodes.Failure"/> (<inheritdoc cref="IExitCodes.Failure" path="descendant::value"/>) value.
        /// </summary>
        void Exit_AsFailure()
            => Environment.Exit(
                Instances.ExitCodes.Failure);

        /// <summary>
        /// Exits with the <see cref="IExitCodes.Success"/> (<inheritdoc cref="IExitCodes.Success" path="descendant::value"/>) value.
        /// </summary>
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

        /// <inheritdoc cref="Environment.CurrentDirectory"/>
        string Get_CurrentDirectoryPath()
            => Environment.CurrentDirectory;

        void Set_CurrentDirectoryPath(string directoryPath)
            => Environment.CurrentDirectory = directoryPath;

        DriveInfo Get_Drive(string driveName = IValues.C_DriveName_Constant)
            => new DriveInfo(driveName);

        /// <inheritdoc cref="IDriveInfoOperator.Get_Drives"/>
        /// <remarks>
        /// Chooses <see cref="Get_Drives_Fixed"/> as the default.
        /// </remarks>
        DriveInfo[] Get_Drives()
            => this.Get_Drives_Fixed();

        /// <inheritdoc cref="IDriveInfoOperator.Get_Drives"/>
        DriveInfo[] Get_Drives_All()
            => Instances.DriveInfoOperator.Get_Drives();

        /// <summary>
        /// Gets drives that are fixed (like hard drives, as opposed to removable drives, like CD-ROMs).
        /// <para>
        /// <inheritdoc cref="Get_Drives_All" path="/summary"/>
        /// </para>
        /// </summary>
        /// <inheritdoc cref="Get_Drives_All"/>
        DriveInfo[] Get_Drives_Fixed()
            => this.Get_Drives_All()
                .Where(Instances.DriveInfoOperator.Is_Fixed)
                .Now();

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

        /// <inheritdoc cref="Environment.MachineName"/>
        /// <remarks>
        /// Gets the name of the machine on which code is currently executing.
        /// (e.g. VANESSSA)
        /// </remarks>
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

        /// <inheritdoc cref="Environment.OSVersion"/>
        /// <remarks>
        /// e.g. "Microsoft Windows NT 10.0.19045.0"
        /// </remarks>
        OperatingSystem Get_OperatingSystem()
        {
            var output = Environment.OSVersion;
            return output;
        }

        /// <inheritdoc cref="Environment.ProcessorCount"/>
        /// <remarks>
        /// Note: returns logical processors, not cores.
        /// </remarks>
        int Get_ProcessorCount_Logical()
            // e.g. 12, shows logical processors, not cores.
            => Environment.ProcessorCount;

        /// <inheritdoc cref="Get_ProcessorCount_Logical" path="/summary"/>
        /// <remarks>
        /// Chooses <see cref="Get_ProcessorCount_Logical"/> as the default.
        /// </remarks>
        int Get_ProcessorCount()
            => this.Get_ProcessorCount_Logical();

        string Get_SpecialDirectoryPath(Environment.SpecialFolder specialFolder)
        {
            var output = Environment.GetFolderPath(specialFolder);
            return output;
        }

        /// <inheritdoc cref="Environment.SystemDirectory"/>
        /// <remarks>
        /// e.g. C:\WINDOWS\system32 (note lack of trailing directory path indicator)
        /// </remarks>
        string Get_SystemDirectoryPath()
            => Environment.SystemDirectory;

        /// <inheritdoc cref="Environment.SystemPageSize"/>
        int Get_SystemPageSize_InBytes()
            => Environment.SystemPageSize;

        /// <inheritdoc cref="Get_SystemPageSize_InBytes" path="/summary"/>
        /// <remarks>
        /// Chooses <see cref="Get_SystemPageSize_InBytes"/> as the default.
        /// </remarks>
        int Get_SystemPageSize()
            => this.Get_SystemPageSize_InBytes();

        /// <inheritdoc cref="Environment.UserDomainName"/>
        /// <remarks>
        /// e.g. "VANESSA" (not sure how this is different from machine name)
        /// </remarks>
        string Get_UserDomainName()
            => Environment.UserDomainName;

        /// <inheritdoc cref="Environment.UserName"/>
        /// <remarks>
        /// e.g. "David"
        /// </remarks>
        string Get_UserName()
            => Environment.UserName;

        /// <summary>
        /// Gets the system directory path for the current user.
        /// </summary>
        /// <remarks>
        /// Returns the value for <see cref="Environment.SpecialFolder.UserProfile"/>,
        /// which is <inheritdoc cref="Y0000.Documentation.For_Directories.UserProfile_OnWindows" path="descendant::summary"/>.
        /// </remarks>
        string Get_UserProfileDirectoryPath()
            => this.Get_SpecialDirectoryPath(Environment.SpecialFolder.UserProfile);

        /// <inheritdoc cref="Environment.Version"/>
        /// <remarks>
        /// e.g. 8.0.1
        /// </remarks>
        Version Get_Version()
            => Environment.Version;

        /// <inheritdoc cref="Get_CLR_Version"/>
        /// <remarks>
        /// <inheritdoc cref="Get_Version" path="/remarks"/>
        /// <para>Quality-of-life overload for <see cref="Get_CLR_Version"/>.</para>
        /// </remarks>
        Version Get_Version_OfCLR()
            => this.Get_CLR_Version();

        /// <summary>
        /// Gets the version of the currently executing common language runtime.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="Get_Version" path="/remarks"/>
        /// <para>Quality-of-life overload for <see cref="Get_Version"/>.</para>
        /// </remarks>
        Version Get_CLR_Version()
            => this.Get_Version();

        /// <inheritdoc cref="Environment.WorkingSet"/>
        /// <remarks>
        /// e.g. 28631040, or 28 MB
        /// </remarks>
        long Get_WorkingSet()
            => Environment.WorkingSet;

        /// <inheritdoc cref="Environment.Is64BitOperatingSystem"/>
        bool Is_64BitOperatingSystem()
            => Environment.Is64BitOperatingSystem;

        /// <inheritdoc cref="Environment.Is64BitProcess"/>
        bool Is_64BitProcess()
            => Environment.Is64BitProcess;

        /// <summary>
        /// Determines if the current machine has the given name.
        /// </summary>
        bool Is_CurrentMachineName(string machineName)
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
        void Verify_CurrentMachineNameIs(string machineName)
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
