using System;
using System.Diagnostics;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICommandLineOperator
    {
        /// <summary>
        /// Starts a process, then moves on without waiting for the process.
        /// </summary>
        /// <remarks>
        /// Note: just starting a process, not waiting for the process to complete, and moving on is a fundamentally synchronous process.
        /// That is why there is no asynchronous version of this method.
        /// </remarks>
        public void Run_NoWait(
            string command,
            string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                // Will be false by default on .NET Core apps, but set to false in case of .NET Framework apps.
                UseShellExecute = false,
                // Do no create an extra OS shell window that either just sits around after invocation completion, or blinks into and out-of existence.
                CreateNoWindow = true,
            };

            // Disposing the .NET process instance will not close the executing process.
            using var process = new Process()
            {
                StartInfo = startInfo
            };

            process.Start();
        }

        public int Run_Synchronous(
            string command,
            string arguments,
            string workingDirectory)
            => Instances.ProcessOperator.Run_Synchronous(
                command,
                arguments,
                workingDirectory);

        public int Run_Synchronous(
            string command,
            string arguments)
            => this.Run_Synchronous(
                command,
                arguments,
                Instances.Values.WorkingDirectory_Default);

        /// <inheritdoc cref="Run_NoWait(string, string)"/>
        public void Run_NoWait(string command)
            => this.Run_NoWait(
                command,
                Instances.Values.EmptyCommandArguments);

        /// <inheritdoc cref="Run_NoWait(string, string)"/>
        public void Run_NoWait_Synchronous(
            string command,
            string arguments)
            // Starting a command and not waiting for it to finish is a fundamentaly synchronous process.
            => this.Run_NoWait(
                command,
                arguments);

        /// <inheritdoc cref="Run_NoWait(string)"/>
        public void Run_NoWait_Synchronous(string command)
            // Starting a command and not waiting for it to finish is a fundamentaly synchronous process.
            => this.Run_NoWait(command);
    }
}
