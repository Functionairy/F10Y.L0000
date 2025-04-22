using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileSystemOperator
    {
        /// <summary>
        /// Creates a directory idempotently (meaning there is no problem with issuing the command multiple times).
        /// </summary>
        /// <remarks>
        /// The system method <see cref="Directory.CreateDirectory(string)"/> does not throw an exception if you create a directory that already exists.
        /// However, it's hard to remember this fact, so this method name makes that fact explicit.
        /// </remarks>
        public void Create_Directory_Idempotent(string directoryPath)
        {
            // Does not throw an exception if a directory already exists.
            // See proof at: https://github.com/MinexAutomation/Public/blob/a8c302415b56fb8903c751436cbeef3eae8e1692/Source/Experiments/CSharp/ExaminingCSharp/ExaminingCSharp/Code/Experiments/IOExperiments.cs#L24
            Directory.CreateDirectory(directoryPath);
        }

        /// <summary>
        /// <inheritdoc cref="Create_Directory_Idempotent(string)" path="/summary"/>
        /// <para>
        /// Quality-of-life overload for <see cref="Create_Directory_Idempotent(string)"/>.
        /// </para>
        /// </summary>
        /// <inheritdoc cref="Create_Directory_Idempotent(string)" path="/remarks"/>
        public void Create_Directory_OkIfAlreadyExists(string directoryPath)
        {
            this.Create_Directory_Idempotent(directoryPath);
        }

        public void Ensure_DirectoryExists_ForFilePath(string filePath)
        {
            var directoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(filePath);

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public bool Exists_Directory(string directoryPath)
        {
            var output = Directory.Exists(directoryPath);
            return output;
        }

        public bool Exists_File(string filePath)
        {
            var output = File.Exists(filePath);
            return output;
        }
    }
}
