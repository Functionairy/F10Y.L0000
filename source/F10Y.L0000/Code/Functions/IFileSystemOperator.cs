using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using F10Y.L0000.Extensions;
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

        /// <summary>
        /// Obnoxiously, the .NET file system info objects do <strong>NOT</strong> provide any way to get the actual, case-sensitive, paths for files or directories.
        /// </summary>
        /// <remarks>
        /// NOTE! This is an expensive operation, involving many file-system searches. Use this method sparingly (for example, only for display of paths of interest instead of for bulk formatting of paths).
        /// </remarks>
        public string Get_ActualPath_ForFile(string path)
        {
            var pathParts = Instances.PathOperator.Get_PathParts(path);

            // Start with the drive.
            var driveName = pathParts.Get_First();
            var directoryNames = pathParts
                .Except_First()
                .Except_Last()
                .ToArray();

            var fileName = pathParts.Get_Last();

            var drives = DriveInfo.GetDrives();

            static DriveInfo Get_Drive(
                IEnumerable<DriveInfo> drives,
                string driveName)
            {
                foreach (var drive in drives)
                {
                    var nameMatches = Instances.StringOperator.Contains_IgnoreCase(
                        drive.Name,
                        driveName);

                    if (nameMatches)
                    {
                        return drive;
                    }
                }

                // Else, error.
                throw new Exception($"No drive found for '{driveName}'.");
            }

            var drive = Get_Drive(
                drives,
                driveName);

            var drivePath = drive.Name;

            var actualDirectory = Instances.DirectoryInfoOperator.From(drivePath);

            var enumerationOptions = new EnumerationOptions
            {
                // We want a case-insensitive match.
                MatchCasing = MatchCasing.CaseInsensitive,
            };

            foreach (var directoryName in directoryNames)
            {
                var directories = actualDirectory.GetDirectories(
                    directoryName,
                    enumerationOptions)
                    // Do not ask for a single, as there could be multiple on non-Windows (case-sensitive) systems.
                    ;

                var directoryCount = directories.Length;

                // Should never happen.
                if (directoryCount < 1)
                {
                    throw new Exception($"'{directoryName}': No directory found in:\n\t{actualDirectory.FullName}");
                }

                if (directoryCount < 2)
                {
                    actualDirectory = directories.Single();
                }
                else
                {
                    // Find the exact, case-sensitive match.
                    actualDirectory = directories
                        .Where(directory => directory.Name == directoryName)
                        .Single();
                }
            }

            // Now find the file.
            var files = actualDirectory.GetFiles(
                fileName,
                enumerationOptions);

            var fileCount = files.Length;

            // Should never happen.
            if (fileCount < 1)
            {
                throw new Exception($"{fileName}: No file found in:\n\t{actualDirectory.FullName}");
            }

            var file = fileCount < 2
                ? files.Single()
                : files
                    .Where(file => file.Name == fileName)
                    .Single()
                ;

            var output = file.FullName;
            return output;
        }
    }
}
