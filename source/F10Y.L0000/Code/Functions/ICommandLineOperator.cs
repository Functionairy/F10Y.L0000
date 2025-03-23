using System;
using System.Diagnostics;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ICommandLineOperator
    {
        public void Run_Synchronous_NoWait(
            string command,
            string arguments)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true
            };

            Process process = new Process()
            {
                StartInfo = startInfo
            };

            process.Start();
        }

        public void Run_Synchronous_NoWait(string command)
            => this.Run_Synchronous_NoWait(
                command,
                Instances.Values.EmptyCommandArguments);
    }
}
