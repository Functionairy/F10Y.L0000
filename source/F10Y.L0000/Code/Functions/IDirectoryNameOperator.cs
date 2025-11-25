using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDirectoryNameOperator
    {
        /// <summary>
        /// Converts a possible directory name into a string capable of being a Windows directory name.
        /// </summary>
        /// <returns>
        /// Whether the name was changed, and the directory name as an out parameter.
        /// </returns>
        /// <remarks>
        /// See <see href="https://learn.microsoft.com/en-us/windows/win32/fileio/naming-a-file#naming-conventions"/>.
        /// </remarks>
        bool Ensure_IsValidWindowsDirectoryName(
            string possibleDirectoryName,
            out string directoryName)
        {
            directoryName = possibleDirectoryName;

            // Replace all invalid characters with '_'.
            var invalidCharacters = Instances.PathOperator.Get_InvalidFileNameCharacters();

            directoryName = Instances.StringOperator.Replace(
                directoryName,
                Instances.Characters.Underscore,
                invalidCharacters);

            // Trim the ending of any spaces (' ') or periods ('.').
            directoryName = directoryName.TrimEnd(
                Instances.Characters.Space,
                Instances.Characters.Period);

            var isChanged = possibleDirectoryName != directoryName;

            return isChanged;
        }

        /// <summary>
        /// Chooses <see cref="Ensure_IsValidWindowsDirectoryName(string, out string)"/> as the default.
        /// </summary>
        bool Ensure_IsValidDirectoryName(
            string possibleDirectoryName,
            out string directoryName)
            => this.Ensure_IsValidWindowsDirectoryName(
                possibleDirectoryName,
                out directoryName);

        string Ensure_IsValidDirectoryName(string possibleDirectoryName)
        {
            // Ignore whether there was a change.
            this.Ensure_IsValidDirectoryName(
                possibleDirectoryName,
                out var output);

            return output;
        }

        string Ensure_IsValid(string directoryName)
        {
            // TODO: actually implement.
            var output = directoryName;
            return output;
        }

        bool Is_SpecialDirectoryName(string directoryName)
        {
            var output = false
                || directoryName == Instances.DirectoryNames.Current
                || directoryName == Instances.DirectoryNames.Parent
                ;

            return output;
        }
    }
}
