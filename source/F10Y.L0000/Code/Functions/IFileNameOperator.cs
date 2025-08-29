using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileNameOperator
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="IFileNameOperator.Get_FileName(string, string)"/>.
        /// </summary>
        public string Add_FileExtension(string fileNameStem, string fileExtension)
            => this.Get_FileName(fileNameStem, fileExtension);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_FileName(string, string)"/>.
        /// </summary>
        public string Append_FileExtension(
            string fileNameStem,
            string fileExtension)
            => this.Get_FileName(
                fileNameStem,
                fileExtension);

        /// <summary>
        /// Places the appendix between the filename and the file extension.
        /// </summary>
        public string Append_ToFileNameStem(
            string fileName,
            string appendix)
        {
            var fileNameStem = Instances.FileNameOperator.Get_FileNameStem(fileName);
            var fileExtension = Instances.FileNameOperator.Get_FileExtension(fileName);

            var newFileNameStem = fileNameStem + appendix;

            var newFileName = Instances.FileNameOperator.Get_FileName(
                newFileNameStem,
                fileExtension);

            return newFileName;
        }

        public string Get_FileExtension(string fileName)
            => Instances.FileExtensionOperator.Get_FileExtension(fileName);

        /// <summary>
        /// Provided a file name stem and file extension, get the resulting file name.
        /// </summary>
        public string Get_FileName(
            string fileNameStem,
            string fileExtension)
        {
            var fileExtensionSeparator = Instances.Values.FileExtension_Separator;

            var output = $"{fileNameStem}{fileExtensionSeparator}{fileExtension}";
            return output;
        }

        /// <summary>
        /// If the filename has no file extension separator, the whole file name is returned.
        /// </summary>
        public string Get_FileNameStem(string fileName)
        {
            var indexOrNotFound = Instances.StringOperator.Get_LastIndexOf_OrNotFound(
                Instances.Values.FileExtension_Separator,
                fileName);

            var isFound = Instances.IndexOperator.Is_Found(indexOrNotFound);
            if (!isFound)
            {
                return fileName;
            }

            // Else.
            var output = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                indexOrNotFound,
                fileName);

            return output;
        }

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
