using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ISearchPatternOperator
    {
        public string Directories_StartingWith(string directoryNameStart)
        {
            var output = this.Entries_StartingWith(directoryNameStart);
            return output;
        }

        /// <summary>
        /// Entries are files and directories.
        /// </summary>
        public string Entries_StartingWith(string nameStart)
        {
            var output = $"{nameStart}{Instances.SearchPatterns.All}";
            return output;
        }

        public string Files_StartingWith(string fileNameStart)
        {
            var output = this.Entries_StartingWith(fileNameStart);
            return output;
        }

        public string Files_WithExtension(string fileExtension)
        {
            var output = $"{Instances.SearchPatterns.All}{fileExtension}";
            return output;
        }
    }
}
