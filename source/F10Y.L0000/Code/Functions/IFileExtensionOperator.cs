using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileExtensionOperator
    {
        public string Add(
            string fileNameStem,
            string fileExtension)
        {
            var output = Instances.StringOperator.Concatenate(
                fileNameStem,
                Instances.Values.FileExtension_Separator_String,
                fileExtension);

            return output;
        }

        public string Get_FileExtension(string fileName)
        {
            var fileExtensionSeparator = Instances.Values.FileExtension_Separator;

            var tokens = Instances.StringOperator.Split(
                fileExtensionSeparator,
                fileName,
                // Windows file names cannot end with a file extension separator (a period) or a space, but non-Windows file names can. In that case we want the empty or spaced file extension.
                // So keep empty file extensions, and do not trim file extensions.
                StringSplitOptions.None);

            // File extension is the last token.
            var fileExtension = Instances.ArrayOperator.Get_Last(tokens);
            return fileExtension;
        }

        /// <summary>
        /// <inheritdoc cref="Get_FileExtensionSeparator_Character"/>
        /// Chooses <see cref="Get_FileExtensionSeparator_Character"/> as the default.
        /// </summary>
        public char Get_FileExtensionSeparator()
            => this.Get_FileExtensionSeparator_Character();

        /// <summary>
        /// Gets the file extension separator character.
        /// <para><inheritdoc cref="IValues.FileExtension_Separator_Character" path="/summary"/></para>
        /// </summary>
        public char Get_FileExtensionSeparator_Character()
            => Instances.Values.FileExtension_Separator_Character;

        /// <summary>
        /// Gets the file extension separator string.
        /// <para><inheritdoc cref="IValues.FileExtension_Separator_String" path="/summary"/></para>
        /// </summary>
        public string Get_FileExtensionSeparator_String()
            => Instances.Values.FileExtension_Separator_String;

        public string Get_FileName(string fileNameStem, string fileExtension)
        {
            var output = Instances.FileNameOperator.Get_FileName(fileNameStem, fileExtension);
            return output;
        }

        public string Get_FileNameStem(string fileName)
            => Instances.FileNameOperator.Get_FileNameStem(fileName);

        /// <summary>
		/// Quality-of-life alias for <see cref="IPathOperator.Has_FileExtension(string, string)"/>.
		/// </summary>
		public bool Has_FileExtension(
            string filePath,
            string fileExtension)
            => Instances.PathOperator.Has_FileExtension(
                filePath,
                fileExtension);
    }
}
