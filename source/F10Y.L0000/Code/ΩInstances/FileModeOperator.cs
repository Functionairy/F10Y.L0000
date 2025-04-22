using System;


namespace F10Y.L0000
{
    public class FileModeOperator : IFileModeOperator
    {
        #region Infrastructure

        public static IFileModeOperator Instance { get; } = new FileModeOperator();


        private FileModeOperator()
        {
        }

        #endregion
    }
}
