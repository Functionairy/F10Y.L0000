using System;

using F10Y.T0002;


namespace F10Y.L0000.Unchecked
{
    [FunctionsMarker]
    public partial interface IStringOperator
    {
        /// <inheritdoc cref="L0000.IStringOperator.Get_Character(string, int)" path="/summary"/>
        /// <remarks>
        /// Unchecked in the sense that an exception will be thrown if the string does have the required length.
        /// </remarks>
        public char Get_Character_Unchecked(
            string @string,
            int index)
        {
            var output = @string[index];
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Unchecked in that an exception will be thrown if the string is null or empty.
        /// </remarks>
        public char Get_Character_Last_Unchecked(string @string)
        {
            var indexOfLast = this.Get_IndexOf_Last_Unchecked(@string);

            var output = this.Get_Character_Unchecked(
                @string,
                indexOfLast);

            return output;
        }

        /// <inheritdoc cref="L0000.IStringOperator.Get_IndexOf_Last(string)" path="/summary"/>
        /// <inheritdoc cref="Get_Length_Unchecked(string)" path="/remarks"/>
        public int Get_IndexOf_Last_Unchecked(string @string)
        {
            var length = this.Get_Length_Unchecked(@string);

            // Length will be good if unchecked succeeds.
            var lastIndex = Instances.IndexOperator.Get_LastIndex_FromLength(length);
            return lastIndex;
        }

        /// <inheritdoc cref="L0000.IStringOperator.Get_Length(string)" path="/summary"/>
        /// <remarks>
        /// Unchecked in the sense that an exception will be thrown if the string is null.
        /// </remarks>
        public int Get_Length_Unchecked(string @string)
        {
            var output = @string.Length;
            return output;
        }
    }
}
