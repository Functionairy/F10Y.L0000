using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IDirectorySeparatorOperator
    {
        /// <summary>
        /// Gets the alternate directory separatator used by the current environment.
        /// (On Windows '/', but on MacOS it's the same '/' as the regular directory separator.)
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Path.AltDirectorySeparatorChar"/>.
        /// </remarks>
        public char Get_DirectorySeparator_ForEnvironment_Alternate()
        {
            var output = Path.AltDirectorySeparatorChar;
            return output;
        }

        /// <summary>
        /// Gets the opposite directory separatator from the directory separator used by the current environment.
        /// (On Windows '/' vs. on non-Windows '\')
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Path.AltDirectorySeparatorChar"/>.
        /// </remarks>
        public char Get_DirectorySeparator_ForEnvironment_Opposite()
        {
            var directorySeparator_Environment = this.Get_DirectorySeparator_ForEnvironment();

            var output = directorySeparator_Environment == Instances.DirectorySeparators.Windows
                ? Instances.DirectorySeparators.NonWindows
                : Instances.DirectorySeparators.Windows
                ;

            return output;
        }

        /// <summary>
        /// Gets the directory separatator used by the current environment.
        /// (On Windows '\' vs. on non-Windows '/')
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Path.DirectorySeparatorChar"/>.
        /// </remarks>
        public char Get_DirectorySeparator_ForEnvironment()
        {
            var output = Path.DirectorySeparatorChar;
            return output;
        }

        public bool Is_DirectorySeparator(char character)
        {
            var directorySeparators = Instances.DirectorySeparators.Both;

            var output = Instances.ArrayOperator.Contains(
                directorySeparators,
                character);

            return output;
        }
    }
}
