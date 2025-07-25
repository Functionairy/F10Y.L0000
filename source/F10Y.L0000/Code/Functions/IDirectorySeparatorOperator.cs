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
        /// (On Windows '/' vs. on non-Windows '\')
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
