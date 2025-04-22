using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnvironmentOperator
    {
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
    }
}
