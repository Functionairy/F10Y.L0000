using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    /// <summary>
    /// A stringly-typed path operator (NET Standard 2.1 Foundation Library).
    /// </summary>
    /// <remarks>
    /// See F10Y.L0027 repository for tests and demonstrations.
    /// </remarks>
    [FunctionsMarker]
    public partial interface IPathOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Implementations.IPathOperator _Implementations => Implementations.PathOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        public string Combine(params string[] pathParts)
        {
            var output = Path.Combine(pathParts);
            return output;
        }

        public IEnumerable<string> Ensure_AreDirectoryIndicated(IEnumerable<string> paths)
            => paths
                .Select(this.Ensure_IsDirectoryIndicated)
                ;

        /// <summary>
		/// Ensures the path ends with a directory separator.
		/// The directory separator to use is detected within the path.
		/// </summary>
        /// <inheritdoc cref="Make_DirectoryIndicated(string)" path="/remarks"/>
		public string Ensure_IsDirectoryIndicated(string pathPart)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(pathPart);

            var output = isDirectoryIndicated
                ? pathPart
                : this.Make_DirectoryIndicated(pathPart)
                ;

            return output;
        }

        public string Ensure_NotDirectoryIndicated(string pathPart)
        {
            var isDirectoryIndicated = this.Is_DirectoryIndicated(pathPart);

            var output = isDirectoryIndicated
                ? this.Make_NotDirectoryIndicated(pathPart)
                : pathPart
                ;

            return output;
        }

        public string Get_DirectoryName(string directoryPath)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_DirectoryName(directoryInfo);
            return output;
        }

        public string Get_DirectoryPath(
            string baseDirectoryPath,
            string relativeDirectoryPath)
        {
            var output_Variable = this.Get_Path(
                baseDirectoryPath,
                relativeDirectoryPath);

            var output = this.Ensure_IsDirectoryIndicated(output_Variable);
            return output;
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            IEnumerable<string> directoryNames)
        {
            var directoryPath = parentDirectoryPath;

            foreach (var directoryName in directoryNames)
            {
                directoryPath = this.Get_DirectoryPath(directoryPath, directoryName);
            }

            var output = this.Ensure_IsDirectoryIndicated(directoryPath);
            return output;
        }

        public string Get_DirectoryPath(
            string parentDirectoryPath,
            params string[] directoryNames)
        {
            var output = this.Get_DirectoryPath(
                parentDirectoryPath,
                directoryNames.AsEnumerable());

            return output;
        }

        /// <summary>
        /// Gets the file name of a file path.
        /// </summary>
        /// <remarks>
        /// Chooses <see cref="Implementations.IPathOperator.Get_FileName_ViaLastPathPart(string)"/> as the default implementation.
        /// </remarks>
        public string Get_FileName(string filePath)
        {
            var output = _Implementations.Get_FileName_ViaLastPathPart(filePath);
            return output;
        }

        public string Get_FileNameStem(string filePath)
        {
            var fileName = this.Get_FileName(filePath);

            var output = Instances.FileNameOperator.Get_FileNameStem(fileName);
            return output;
        }

        public string Get_FilePath(
            string directoryPath,
            string fileName)
        {
            var output = this.Combine(
                directoryPath,
                fileName);

            return output;
        }

        public string Get_ParentDirectoryPath_ForDirectory(string directoryPath)
        {
            var directoryInfo = Instances.DirectoryInfoOperator.From(directoryPath);

            var output = Instances.DirectoryInfoOperator.Get_ParentDirectoryPath(directoryInfo);
            return output;
        }

        public string Get_ParentDirectoryPath_ForFile(string filePath)
        {
            var fileInfo = new FileInfo(filePath);

            var parentDirectoryPath = fileInfo.Directory.FullName;

            // Unchecked, since we know the directory full name is *not* directory indicated.
            var output = this.Make_DirectoryIndicated(parentDirectoryPath);
            return output;
        }

        public string Get_Path(
            string basePath,
            string path_RelativeToBasePath)
        {
            var output = Path.Combine(
                basePath,
                path_RelativeToBasePath);

            return output;
        }

        public string Get_PathPart_Last(string path)
        {
            var pathParts = this.Get_PathParts_NonEmpty(path);

            var fileName = Instances.ArrayOperator.Get_Last(pathParts);
            return fileName;
        }

        public string[] Get_PathParts_NonEmpty(string path)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            // Split path on directory separators, removing empty entries.
            var pathParts = Instances.StringOperator.Split(
                directorySeparators,
                path,
                StringSplitOptions.RemoveEmptyEntries);

            return pathParts;
        }

        /// <summary>
        /// Chooses <see cref="Get_PathParts_NonEmpty(string)"/> as the default.
        /// </summary>
        public string[] Get_PathParts(string path)
        {
            var output = this.Get_PathParts_NonEmpty(path);
            return output;
        }

        /// <summary>
        /// Gets the relative path from A to B.
        /// </summary>
        public string Get_RelativePath(
            string pathA,
            string pathB)
        {
            var output = Path.GetRelativePath(
                pathA,
                pathB);

            return output;
        }

        public bool Has_FileExtension(
            string filePath,
            string fileExtension)
        {
            var hasFileExtension = Instances.StringOperator.Ends_With(
                filePath,
                fileExtension);

            return hasFileExtension;
        }

        /// <summary>
        /// Is a path directory-indicated (ends with a directory separator)?
        /// </summary>
        /// <remarks>
        /// Null or empty paths are not directory indicated.
        /// </remarks>
        public bool Is_DirectoryIndicated(string path)
        {
            var hasLastCharacter = Instances.StringOperator.Has_Character_Last(
                path,
                out var character_Last);

            if (!hasLastCharacter)
            {
                return false;
            }
            // Else.

            var output = Instances.DirectorySeparatorOperator.Is_DirectorySeparator(character_Last);
            return output;
        }

        /// <summary>
        /// Is a path root-indicated (starts with a directory separator)?
        /// With the caveat that paths with a <see cref="IVolumeSeparators.VolumeSeparator"/> before the first directory separator are also root indicated.
        /// </summary>
        /// <remarks>
        /// Note that "C:" is <em>not</em> root indicated! It lacks a directory separator. (So "C:\" is root-indicated.)
        /// </remarks>
        public bool Is_RootIndicated(string path)
        {
            // Does the path start with a directory separator?
            var hasFirstCharacter = Instances.StringOperator.Has_Character_First(
                path,
                out var character_First);

            if (!hasFirstCharacter)
            {
                return false;
            }

            var isDirectorySeparator = Instances.DirectorySeparatorOperator.Is_DirectorySeparator(character_First);
            if (isDirectorySeparator)
            {
                return true;
            }

            // If not, is the first volume separator before the first directory separator? (E.g. for "C:\", ':' is the volume separator and it comes before the directory separator '\'.)
            var hasDirectorySeparatorIndex = Instances.StringOperator.Has_IndexOfAny_First(
                path,
                out var indexOfDirectorySeparator_OrNotFound,
                Instances.DirectorySeparators.Both);

            var filePart_First = hasDirectorySeparatorIndex
                ? Instances.StringOperator.Get_Substring_Upto_Exclusive(
                    indexOfDirectorySeparator_OrNotFound,
                    path)
                : path
                ;

            var hasVolumeSeparatorIndex = Instances.StringOperator.Has_IndexOf_First(
                filePart_First,
                out var indexOfVolumeSeparator_OrNotFound,
                Instances.VolumeSeparators.Windows);

            var output = hasVolumeSeparatorIndex
                && indexOfVolumeSeparator_OrNotFound < indexOfDirectorySeparator_OrNotFound;

            return output;
        }

        public bool Is_Resolved(string path)
        {
            // The opposite of unresolved.
            var isUnresolved = this.Is_Unresolved(path);

            var output = !isUnresolved;
            return output;
        }

        /// <summary>
        /// Is a path unresolved? (Does it contain the current directory (<see cref="IDirectoryNames.Current"/>) or parent directory (<see cref="IDirectoryNames.Parent"/>) directory names?)
        /// </summary>
        public bool Is_Unresolved(string path)
        {
            // Split the path, test if any path parts are the current or parent directory names.
            var pathParths = this.Split(path);

            var output = pathParths
                .Where(Instances.DirectoryNameOperator.Is_SpecialDirectoryName)
                .Any();

            return output;
        }

        public bool Is_Platform_Mixed(string path)
        {
            var output = Instances.StringOperator.Contains(
                path,
                Instances.DirectorySeparators.Both);

            return output;
        }

        public bool Is_Platform_NonWindows(
            string path,
            bool default_IfNone = true)
            => this.Is_DirectorySeparator_First(
                path,
                Instances.DirectorySeparators.NonWindows,
                default_IfNone);

        public bool Is_Platform_Windows(
            string path,
            bool default_IfNone = true)
            => this.Is_DirectorySeparator_First(
                path,
                Instances.DirectorySeparators.Windows,
                default_IfNone);

        public bool Is_DirectorySeparator_First(
            string path,
            char directorySeparator,
            bool default_IfNone = true)
        {
            var hasDirectoryIndicator = Instances.StringOperator.Has_IndexOfAny_First(
                path,
                out var indexOfAny_OrNotFound,
                Instances.DirectorySeparators.Both);

            if (!hasDirectoryIndicator)
            {
                return default_IfNone;
            }

            var directorySeparator_Found = Instances.StringOperator.Get_Character(
                path,
                indexOfAny_OrNotFound);

            var output = Instances.CharacterOperator.Are_Equal(
                directorySeparator_Found,
                directorySeparator);

            return output;
        }

        public string Make_DirectoryIndicated(string path)
        {
            var output = path + "\\"; // this.Make_DirectoryIndicated(path, true);
            return output;
        }

        public string Make_NotDirectoryIndicated(string path)
        {
            var output = path.TrimEnd(Instances.DirectorySeparators.Both);
            return output;
        }

        public string Resolve(string path_Unresolved)
        {
            var output = _Implementations.Resolve_GetFullPath(path_Unresolved);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Split_WithDirectorySeparators_KeepEmpty(string)"/> as the default.
        /// </summary>
        public string[] Split(string path)
            => this.Split_WithDirectorySeparators_KeepEmpty(path);

        /// <summary>
        /// Splits a path into path parts using directory separators as 
        /// </summary>
        public string[] Split_WithDirectorySeparators_KeepEmpty(string path)
        {
            var output = Instances.StringOperator.Split(
                Instances.DirectorySeparators.Both,
                path);

            return output;
        }
    }
}
