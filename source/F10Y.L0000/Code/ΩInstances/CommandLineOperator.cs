using System;


namespace F10Y.L0000
{
    public class CommandLineOperator : ICommandLineOperator
    {
        #region Infrastructure

        public static ICommandLineOperator Instance { get; } = new CommandLineOperator();


        private CommandLineOperator()
        {
        }

        #endregion
    }
}
