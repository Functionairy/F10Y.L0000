using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDirectoryInfoOperator
    {
        /// <summary>
        /// Enumerates child files in the directory (not including in any sub-directories).
        /// </summary>
        /// <remarks>
        /// Actually enumerates files as they come in (via <see cref="Directory.EnumerateFiles(string)"/>)
        /// as opposed to waiting to get all directories (as an array via <see cref="Directory.GetFiles(string)"/>).
        /// </remarks>
        IEnumerable<FileInfo> Enumerate_ChildFiles(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.EnumerateFiles();
            return output;
        }

        IEnumerable<DirectoryInfo> Enumerate_ChildDirectories(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.EnumerateDirectories();
            return output;
        }

        IEnumerable<FileInfo> Enumerate_Files(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var childFiles = this.Enumerate_ChildFiles(directoryInfo);
            foreach (var fileInfo in childFiles)
            {
                yield return fileInfo;
            }

            var childDirectories = this.Enumerate_ChildDirectories(directoryInfo);
            foreach (var childDirectory in childDirectories)
            {
                var recurseIntoDirectory = descendantDirectoryRecursionPredicate(childDirectory);
                if (recurseIntoDirectory)
                {
                    var subFiles = this.Enumerate_Files(
                        childDirectory,
                        descendantDirectoryRecursionPredicate);

                    foreach (var subFile in subFiles)
                    {
                        yield return subFile;
                    }
                }
            }
        }

        DirectoryInfo From(string directoryPath)
        {
            var output = new DirectoryInfo(directoryPath);
            return output;
        }

        string Get_DirectoryName(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.Name;
            return output;
        }

        string Get_DirectoryPath(DirectoryInfo directoryInfo)
        {
            var output = directoryInfo.FullName;
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="Get_LastModifiedFile(DirectoryInfo, Func{DirectoryInfo, bool})" path="/summary"/>
        /// <para>Throws an exception if the directory is empty.</para>
        /// </summary>
        FileInfo Get_LastModifiedFile_ThrowIfEmpty(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
        {
            var output = this.Enumerate_Files(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                .Order_ByWriteTime_Descending()
                // Choose first instead of first-or-default to throw an exception if the directory is empty.
                .First();

            return output;
        }

        /// <summary>
        /// Gets the last file in the directory to be modified.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Get_LastModifiedFile_ThrowIfEmpty(DirectoryInfo, Func{DirectoryInfo, bool})"/> as the default.
        /// </remarks>
        FileInfo Get_LastModifiedFile(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile_ThrowIfEmpty(
                directoryInfo,
                descendantDirectoryRecursionPredicate);

        /// <remarks>
        /// Chooses <see cref="Get_LastModifiedTime_ForFiles_Local(DirectoryInfo, Func{DirectoryInfo, bool})"/> as the default.
        /// </remarks>
        DateTime Get_LastModifiedTime_ForFiles(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedTime_ForFiles_Local(
                directoryInfo,
                descendantDirectoryRecursionPredicate);

        DateTime Get_LastModifiedTime_ForFiles_Local(
            DirectoryInfo directoryInfo,
            Func<DirectoryInfo, bool> descendantDirectoryRecursionPredicate)
            => this.Get_LastModifiedFile(
                directoryInfo,
                descendantDirectoryRecursionPredicate)
                // Return the local time.
                .LastWriteTime;

        DirectoryInfo Get_Parent(DirectoryInfo directoryInfo)
            => directoryInfo.Parent;

        string Get_ParentDirectoryPath(DirectoryInfo directoryInfo)
        {
            var parent = this.Get_Parent(directoryInfo);

            var output = this.Get_DirectoryPath(parent);
            return output;
        }

        /// <summary>
        /// For a directory, get the directory's own last modified time.
        /// </summary>
        DateTime Get_LastModifiedTime(DirectoryInfo directoryInfo)
            => Instances.FileSystemInfoOperator.Get_LastModifiedTime(directoryInfo);
    }
}
