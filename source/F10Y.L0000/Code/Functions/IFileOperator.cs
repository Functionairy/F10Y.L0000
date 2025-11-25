using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileOperator
    {
        bool Exists(string filePath)
            => Instances.FileSystemOperator.Exists_File(filePath);

        string[] Get_LinesFromText(string text)
        {
            if (Instances.StringOperator.Is_Empty(text))
            {
                return Array.Empty<string>();
            }

            var lines = text.Split(
                new[]
                {
                    Instances.Strings.NewLine_NonWindows,
                    Instances.Strings.NewLine_Windows,
                },
                StringSplitOptions.None);

            return lines;
        }

        void Copy_File(
            string sourceFilePath,
            string destinationFilePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            File.Copy(
                sourceFilePath,
                destinationFilePath,
                overwrite);
        }

        async Task<bool> Files_AreEqual_ByteLevel(
            string filePathA,
            string filePathB)
        {
            var gettingBytesA = this.Read_AllBytes(filePathA);
            var gettingBytesB = this.Read_AllBytes(filePathB);

            await Task.WhenAll(
                gettingBytesA,
                gettingBytesB);

            var bytesA = await gettingBytesA;
            var bytesB = await gettingBytesB;

            var output = Instances.ByteOperator.Are_Equal(
                bytesA,
                bytesB);

            return output;
        }

        StreamWriter Open_ForWrite(
            string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            var output = Instances.StreamWriterOperator.New_Write(
                filePath,
                overwrite);

            return output;
        }

        /// <summary>
        /// Overwrite is the opposite of append.
        /// </summary>
        bool Overwrite_ToAppend(bool overwrite)
            => !overwrite;

        Task<byte[]> Read_AllBytes(string filePath)
            => File.ReadAllBytesAsync(filePath);

        byte[] Read_AllBytes_Synchronous(string filePath)
            => File.ReadAllBytes(filePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Read_AllLines_IncludingBlankLines(string)"/>.
        /// </summary>
        async Task<string[]> Read_AllLines(string filePath)
        {
            var lines = await this.Read_AllLines_IncludingBlankLines(filePath);
            return lines;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Read_AllLines_IncludingBlankLines_Synchronous(string)"/>.
        /// </summary>
        string[] Read_AllLines_Synchronous(string filePath)
        {
            var lines = this.Read_AllLines_IncludingBlankLines_Synchronous(filePath);
            return lines;
        }

        /// <summary>
		/// Actually reads all lines. The <see cref="File.ReadLines(string)"/> method omits blank lines, instead adding the new line character to the previous line!
		/// </summary>
		async Task<string[]> Read_AllLines_IncludingBlankLines(string filePath)
        {
            var text = await File.ReadAllTextAsync(filePath);

            var lines = this.Get_LinesFromText(text);
            return lines;
        }

        /// <inheritdoc cref="Read_AllLines_IncludingBlankLines(string)"/>
        string[] Read_AllLines_IncludingBlankLines_Synchronous(string filePath)
        {
            var text = File.ReadAllText(filePath);

            var lines = this.Get_LinesFromText(text);
            return lines;
        }

        /// <inheritdoc cref="File.ReadAllText(string)"/>
        Task<string> Read_AllText(string filePath)
            => File.ReadAllTextAsync(filePath);

        /// <inheritdoc cref="Read_AllText(string)"/>
        /// <remarks>
        /// Quality-of-life overload for <see cref="Read_AllText(string)"/>.
        /// </remarks>
        Task<string> Read_Text(string filePath)
            => this.Read_AllText(filePath);

        string Read_AllText_Synchronous(string filePath)
            => File.ReadAllText(filePath);

        Task<byte[]> Read_Bytes(string filePath)
        {
            var output = File.ReadAllBytesAsync(filePath);
            return output;
        }

        Task<string[]> Read_Lines(string filePath)
            => File.ReadAllLinesAsync(filePath);

        /// <summary>
        /// Chooses <see cref="Verify_Files_AreEqual_ByteLevel(string, string)"/> as the default.
        /// </summary>
        Task Verify_Files_AreEqual(
            string filePathA,
            string filePathB)
            => this.Verify_Files_AreEqual_ByteLevel(
                filePathA,
                filePathB);

        /// <summary>
        /// Byte-by-byte, verify that two files are the same.
        /// </summary>
        async Task Verify_Files_AreEqual_ByteLevel(
            string filePathA,
            string filePathB)
        {
            var gettingBytesA = this.Read_AllBytes(filePathA);
            var gettingBytesB = this.Read_AllBytes(filePathB);

            await Task.WhenAll(
                gettingBytesA,
                gettingBytesB);

            var bytesA = await gettingBytesA;
            var bytesB = await gettingBytesB;

            Instances.ByteOperator.Verify_AreEqual(
                bytesA,
                bytesB);
        }

        /// <summary>
        /// Chooses <see cref="Verify_Files_AreEqual_ByteLevel_Synchonous(string, string)"/> as the default.
        /// </summary>
        void Verify_Files_AreEqual_Synchonous(
            string filePathA,
            string filePathB)
            => this.Verify_Files_AreEqual_ByteLevel_Synchonous(
                filePathA,
                filePathB);

        /// <inheritdoc cref="Verify_Files_AreEqual_ByteLevel(string, string)"/>
        void Verify_Files_AreEqual_ByteLevel_Synchonous(
            string filePathA,
            string filePathB)
        {
            var bytesA = this.Read_AllBytes_Synchronous(filePathA);
            var bytesB = this.Read_AllBytes_Synchronous(filePathB);

            Instances.ByteOperator.Verify_AreEqual(
                bytesA,
                bytesB);
        }

        /// <summary>
        /// Writes the provided lines (and only the provided lines, with no trailing blank line) to a file.
        /// </summary>
        Task Write_Lines(
            string textFilePath,
            IEnumerable<string> lines)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            var text = Instances.StringOperator.Join(
                Instances.Characters.NewLine,
                lines);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        Task Write_Lines(
            string textFilePath,
            Encoding encoding,
            IEnumerable<string> lines)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            return File.WriteAllLinesAsync(
                textFilePath,
                lines,
                encoding);
        }

        Task Write_Lines(
            string textFilePath,
            Encoding encoding,
            params string[] lines)
            => this.Write_Lines(
                textFilePath,
                encoding,
                lines.AsEnumerable());

        Task Write_Text(
            string textFilePath,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            return File.WriteAllTextAsync(
                textFilePath,
                text);
        }

        Task Write_Text(
            string textFilePath,
            Encoding encoding,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            return File.WriteAllTextAsync(
                textFilePath,
                text,
                encoding);
        }

        void Write_Text_Synchronous(
            string textFilePath,
            string text)
        {
            Instances.FileSystemOperator.Ensure_DirectoryExists_ForFilePath(textFilePath);

            File.WriteAllText(
                textFilePath,
                text);
        }
    }
}
