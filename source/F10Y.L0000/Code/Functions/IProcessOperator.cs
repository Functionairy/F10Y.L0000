using F10Y.T0002;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IProcessOperator
    {
        public DataReceivedEventHandler Add_Filter(
            DataReceivedEventHandler handler,
            Func<string, bool> filter_Data_ToInclude)
        {
            void Internal(object sender, DataReceivedEventArgs dataReceived)
            {
                var data = dataReceived.Data;

                var include = filter_Data_ToInclude(data);

                if (include)
                {
                    handler(sender, dataReceived);
                }
            }

            return Internal;
        }

        /// <summary>
        /// Chooses <see cref="DataReceivedHandler_WriteToConsole(object, DataReceivedEventArgs)"/> as the default.
        /// </summary>
        public void DataReceivedHandler_Default(object sender, DataReceivedEventArgs eventArgs)
            => this.DataReceivedHandler_WriteToConsole(sender, eventArgs);

        public void DataReceivedHandler_Throw(object sender, DataReceivedEventArgs eventArgs)
        {
            this.DataReceivedHandler_WriteToConsole(sender, eventArgs);

            throw new Exception(eventArgs.Data);
        }

        public void DataReceivedHandler_WriteToConsole(object sender, DataReceivedEventArgs eventArgs)
        {
            Instances.ConsoleOperator.Write_Line(eventArgs.Data);
        }

        public void ErrorReceivedHandler_Default(object sender, DataReceivedEventArgs eventArgs)
        {
            this.DataReceivedHandler_Throw(sender, eventArgs);
        }

        public bool Filter_ExcludeNull(string data)
            => Instances.StringOperator.Is_NotNull(data);

        public bool Filter_IncludeAll(string data)
            => true;

        public DataReceivedEventHandler Get_DataReceivedEventHandler_Synchronous(
            StreamWriter writer)
        {
            void Internal(object sender, DataReceivedEventArgs dataReceived)
            {
                writer.WriteLine(dataReceived.Data);
            }

            return Internal;
        }

        public DataReceivedEventHandler Get_DataReceivedEventHandler(
            List<string> accumulator)
            => this.Get_DataReceivedEventHandler_ExcludeNull(accumulator);

        public DataReceivedEventHandler Get_DataReceivedEventHandler_Aggregate(
            IEnumerable<DataReceivedEventHandler> dataReceivedEventHandlers)
        {
            void Internal(object sender, DataReceivedEventArgs dataReceived)
            {
                foreach (var dataReceivedEventHandler in dataReceivedEventHandlers)
                {
                    dataReceivedEventHandler(sender, dataReceived);
                }
            }

            return Internal;
        }

        public DataReceivedEventHandler Get_DataReceivedEventHandler_Aggregate(
            params DataReceivedEventHandler[] dataReceivedEventHandlers)
            => this.Get_DataReceivedEventHandler_Aggregate(
                dataReceivedEventHandlers.AsEnumerable());

        public DataReceivedEventHandler Get_DataReceivedEventHandler_ExcludeNull(
            List<string> accumulator)
            => this.Add_Filter(
                this.Get_DataReceivedEventHandler_WithoutFilter(accumulator),
                this.Filter_ExcludeNull);

        public DataReceivedEventHandler Get_DataReceivedEventHandler_WithoutFilter(List<string> accumulator)
        {
            void Internal(object sender, DataReceivedEventArgs dataReceived)
            {
                var data = dataReceived.Data;

                accumulator.Add(data);
            }

            return Internal;
        }

        public DataReceivedEventHandler Get_DataReceivedEventHandler_WithoutFilter(out List<string> accumulator)
        {
            accumulator = new List<string>();

            var output = this.Get_DataReceivedEventHandler_WithoutFilter(
                accumulator);

            return output;
        }

        public void OutputReceivedHandler_Default(object sender, DataReceivedEventArgs eventArgs)
        {
            this.DataReceivedHandler_Default(sender, eventArgs);
        }

        public int Run_Synchronous(
            string command,
            string arguments,
            string workingDirectory,
            DataReceivedEventHandler output_Handler,
            DataReceivedEventHandler error_Handler)
        {
            var startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = workingDirectory,
            };

            using var process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += output_Handler;
            process.ErrorDataReceived += error_Handler;

            // Ignore whether or not a process was started (an existing process may have been used).
            process.Start();
            process.BeginOutputReadLine(); // Must occur after start.
            process.BeginErrorReadLine(); // Must occur after start.

            process.WaitForExit();

            process.OutputDataReceived -= output_Handler;
            process.ErrorDataReceived -= error_Handler;

            var exitCode = process.ExitCode; // Must get value before closing the process.

            process.Close();

            return exitCode;
        }

        public int Run_Synchronous(
            string command,
            string arguments,
            string workingDirectory,
            DataReceivedEventHandler output_Handler)
            => this.Run_Synchronous(
                command,
                arguments,
                workingDirectory,
                output_Handler,
                this.DataReceivedHandler_Default);

        public int Run_Synchronous(
            string command,
            string arguments,
            string workingDirectory)
            => this.Run_Synchronous(
                command,
                arguments,
                workingDirectory,
                this.DataReceivedHandler_Default,
                this.DataReceivedHandler_Default);

        public async Task<int> Run_Asynchronous(
            string command,
            string arguments,
            string workingDirectory,
            DataReceivedEventHandler output_Handler,
            DataReceivedEventHandler error_Handler)
        {
            var startInfo = new ProcessStartInfo(command, arguments)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                WorkingDirectory = workingDirectory,
            };

            using var process = new Process()
            {
                StartInfo = startInfo
            };

            process.OutputDataReceived += output_Handler;
            process.ErrorDataReceived += error_Handler;
            process.EnableRaisingEvents = true;

            // Result type is required, non-generic version added in net6.0.
            var tcs = new TaskCompletionSource<bool>();

            void Exited_Handler(object _sender, EventArgs _args)
            {
                tcs.SetResult(true);
            }

            process.Exited += Exited_Handler;

            // Ignore whether or not a process was started (an existing process may have been used).
            process.Start();

            process.BeginOutputReadLine(); // Must occur after start.
            process.BeginErrorReadLine(); // Must occur after start.

            await tcs.Task;

            process.OutputDataReceived -= output_Handler;
            process.ErrorDataReceived -= error_Handler;
            process.Exited -= Exited_Handler;

            // Note: Must get value before closing the process.
            var exitCode = process.ExitCode;

            process.Close();

            return exitCode;
        }

        public Task<int> Run_Asynchronous(
            string command,
            string arguments,
            string workingDirectory)
            => this.Run_Asynchronous(
                command,
                arguments,
                workingDirectory,
                this.DataReceivedHandler_Default,
                this.DataReceivedHandler_Default);
    }
}
