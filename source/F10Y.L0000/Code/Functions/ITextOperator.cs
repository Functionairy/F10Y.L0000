using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITextOperator
    {
        /// <summary>
        /// Joins lines using the specified line separator into a single string of text.
        /// </summary>
        public string Join_Lines(
            IEnumerable<string> lines,
            string lineSeparator)
        {
            var output = StringOperator.Instance.Join(
                lineSeparator,
                lines);

            return output;
        }

        /// <summary>
        /// Joins lines using the <see cref="IStrings.NewLine_ForEnvironment"/> separator into a single string of text.
        /// </summary>
        public string Join_Lines(IEnumerable<string> lines)
        {
            var output = this.Join_Lines(
                lines,
                Instances.Strings.NewLine_ForEnvironment);

            return output;
        }
    }
}
