using System;


namespace F10Y.L0000
{
    public class FileExtensionOperator : IFileExtensionOperator
    {
        #region Infrastructure

        public static IFileExtensionOperator Instance { get; } = new FileExtensionOperator();


        private FileExtensionOperator()
        {
        }

        #endregion
    }
}
