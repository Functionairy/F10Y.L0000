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

        /// <summary>
        /// Non-idempotently deletes a directory.
        /// An exception is thrown if the directory does not exist.
        /// </summary>
        public void Delete_Directory_NonIdempotent(string directoryPath)
        {
            if (!this.Exists_Directory(directoryPath))
            {
                throw new DirectoryNotFoundException(directoryPath);
            }

            this.Delete_Directory_Robust(directoryPath);
        }

        public bool Delete_Directory_Idempotent(string directoryPath)
        {
            if (this.Exists_Directory(directoryPath))
            {
                this.Delete_Directory_Robust(directoryPath);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Deletes a directory path.
        /// The <see cref="System.IO.Directory.Delete(string)"/> method throws a <see cref="System.IO.DirectoryNotFoundException"/> if attempting to delete a non-existent directory. This is annoying.
        /// All you really want is the directory to not exist, so this method simply takes care of checking if the directory exists.
        /// Also annoying, you need to specify the recursive option to delete a directory with anything in it. This method also takes care of specifying true for the recursive option.
        /// Even more annoying, even after specifying the recursive option, the system method will not delete read-only files. Thus this method disables read-only options on all files recursively.
        /// </summary>
        public void Delete_Directory_Robust(string directoryPath)
        {
            if (this.Exists_Directory(directoryPath))
            {
                this.Disable_ReadOnly(directoryPath);

                this.Delete_Directory_NonRobust(directoryPath);
            }
        }

        public void Delete_Directory_NonRobust(string directoryPath)
        {
            Directory.Delete(directoryPath, true);
        }

        public void Delete_Directories_Idempotent(IEnumerable<string> directoryPaths)
        {
            foreach (var directoryPath in directoryPaths)
            {
                this.Delete_Directory_Idempotent(directoryPath);
            }
        }

        /// <summary>
        /// Chooses <see cref="Delete_Directories_Idempotent(IEnumerable{string})"/> as the default.
        /// </summary>
        public void Delete_Directories(IEnumerable<string> directoryPaths)
            => this.Delete_Directories_Idempotent(directoryPaths);

        public void Delete_Directory_OkIfNotExists(string directoryPath)
        {
            this.Delete_Directory_Idempotent(directoryPath);
        }

        public void Delete_Directory(string directoryPath)
            => this.Delete_Directory_Idempotent(directoryPath);

        public void Disable_ReadOnly(string directoryPath)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            this.Disable_ReadOnly(directoryInfo);
        }

        /// <summary>
        /// Remove the read-only attribute from all files.
        /// </summary>
        /// <remarks>
        /// Adapted from: https://stackoverflow.com/questions/1982209/cannot-programatically-delete-svn-working-copy
        /// </remarks>
        public void Disable_ReadOnly(DirectoryInfo directoryInfo)
        {
            foreach (var file in directoryInfo.GetFiles())
            {
                if (file.IsReadOnly)
                {
                    file.IsReadOnly = false;
                }
            }

            foreach (var subdirectory in directoryInfo.GetDirectories())
            {
                this.Disable_ReadOnly(subdirectory);
            }
        }

        public void Ensure_DirectoryExists(string directoryPath)
        {
            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public void Ensure_DirectoryExists_ForFilePath(string filePath)
        {
            var directoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(filePath);

            this.Create_Directory_OkIfAlreadyExists(directoryPath);
        }

        public void Ensure_DirectoryDoesNotExist(string directoryPath)
            => this.Delete_Directory_Idempotent(directoryPath);

        /// <summary>
        /// Enumerates child files in the directory (not including in any sub-directories).
        /// </summary>
        /// <remarks>
        /// Actually enumerates files as they come in (via <see cref="Directory.EnumerateFiles(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetFiles(string)"/>).
        /// </remarks>
        public IEnumerable<string> Enumerate_ChildFilePaths(string directoryPath)
        {
            var output = Directory.EnumerateFiles(directoryPath);
            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateFiles(
                directoryPath,
                searchPattern,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildFilePaths(string)"/>
        public IEnumerable<string> Enumerate_ChildFilePaths_ByFileExtension(
            string directoryPath,
            string fileExtension)
        {
            var searchPattern = Instances.SearchPatternOperator.Files_WithExtension(fileExtension);

            return this.Enumerate_ChildFilePaths(
                directoryPath,
                searchPattern);
        }

        /// <summary>
        /// Enumerates child DLL files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildDllFiles(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.dll);
        }

        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = Directory.EnumerateDirectories(directoryPath, searchPattern, SearchOption.TopDirectoryOnly)
                // The system method has a bad habit of not directory-indicating directory paths.
                .Select(directoryPath => Instances.PathOperator.Ensure_IsDirectoryIndicated(directoryPath));

            return output;
        }

        /// <summary>
        /// Enumerates all child directories of the directory.
        /// </summary>
        /// <remarks>
        /// Actually enumerates directories as they come in (via <see cref="Directory.EnumerateDirectories(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetDirectories(string)"/>).
        /// </remarks>
        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            string directoryPath)
            => this.Enumerate_ChildDirectoryPaths(
                directoryPath,
                Instances.SearchPatterns.All);

        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            IEnumerable<string> directoryPaths)
        {
            var output = directoryPaths
                .SelectMany(this.Enumerate_ChildDirectoryPaths)
                ;

            return output;
        }

        public IEnumerable<string> Enumerate_ChildDirectoryPaths(
            params string[] directoryPaths)
            => this.Enumerate_ChildDirectoryPaths(
                directoryPaths.AsEnumerable());

        /// <summary>
        /// Enumerates child XML files in the directory.
        /// </summary>
        public IEnumerable<string> Enumerate_ChildXmlFiles(string directoryPath)
        {
            return this.Enumerate_ChildFilePaths_ByFileExtension(
                directoryPath,
                Instances.FileExtensions.xml);
        }

        /// <inheritdoc cref="Enumerate_ChildDllFiles"/>
        public IEnumerable<string> Enumerate_DllFiles(string directoryPath)
        {
            return this.Enumerate_ChildDllFiles(directoryPath);
        }

        /// <summary>
        /// Enumerates all child-of-child (grandchild) directory paths.
        /// </summary>=
        public IEnumerable<string> Enumerate_GrandchildDirectoryPaths(
            string directoryPath)
        {
            var childDirectoryPaths = this.Enumerate_ChildDirectoryPaths(
                directoryPath);

            var output = childDirectoryPaths
                .SelectMany(this.Enumerate_ChildDirectoryPaths)
                ;

            return output;
        }

        /// <inheritdoc cref="Enumerate_ChildXmlFiles"/>
        public IEnumerable<string> Enumerate_XmlFiles(string directoryPath)
        {
            return this.Enumerate_ChildXmlFiles(directoryPath);
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

        public string[] Get_ChildDirectoryPaths(
            string directoryPath,
            string searchPattern)
        {
            var output = this.Get_Directories(
                directoryPath,
                searchPattern,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        public string[] Get_ChildDirectoryPaths(
            string directoryPath)
        {
            var output = this.Get_Directories(
                directoryPath,
                Instances.SearchPatterns.All,
                SearchOption.TopDirectoryOnly);

            return output;
        }

        /// <summary>
        /// Tests whether a file exists, and if it doesn't, throws a <see cref="FileNotFoundException"/>.
        /// </summary>
        public void Verify_File_Exists(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if (!fileExists)
            {
                throw new FileNotFoundException("File did not exist.", filePath);
            }
        }

        /// <summary>
        /// Ensures that all returned directory paths are directory-indicated.
        /// </summary>
        public string[] Get_Directories(
            string path,
            string searchPattern,
            SearchOption searchOption)
        {
            var nonDirectoryIndicatedDirectoryPaths = Directory.GetDirectories(
                path,
                searchPattern,
                searchOption);

            var output = Instances.PathOperator.Ensure_AreDirectoryIndicated(nonDirectoryIndicatedDirectoryPaths)
                .ToArray();

            return output;
        }

        /// <summary>
        /// <inheritdoc cref="IDirectoryInfoOperator.Get_LastModifiedTime(DirectoryInfo)" path="/summary"/>
        /// </summary>
        public DateTime Get_LastModifiedTime_ForDirectory(string directoryPath)
        {
            var directory = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_LastModifiedTime(directory);
            return output;
        }

        public DateTime Get_LastModifiedTime_ForFiles(
            string directoryPath,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_LastModifiedTime_ForFiles(
                directoryInfo,
                descendantDirectoryRecursionPredicate);

            return output;
        }

        /// <summary>
        /// Tests whether a file exists, and if it does, throws an <see cref="Exception"/>.
        /// </summary>
        public void Verify_File_DoesNotExist(string filePath)
        {
            var fileExists = this.Exists_File(filePath);
            if (fileExists)
            {
                throw new Exception($"File exists:\n{filePath}");
            }
        }
    }
}
