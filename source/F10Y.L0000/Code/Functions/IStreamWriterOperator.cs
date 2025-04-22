using System;
using System.IO;
using System.Text;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStreamWriterOperator
    {
        public StreamWriter New(string filePath)
            => new StreamWriter(filePath);

        public StreamWriter New(
            string filePath,
            Encoding encoding,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            var append = Instances.FileOperator.Overwrite_ToAppend(overwrite);

            var output = new StreamWriter(
                filePath,
                append,
                encoding);

            return output;
        }
            

        public StreamWriter New(
            Stream stream,
            Encoding encoding)
            => new StreamWriter(
                stream,
                encoding);

        public StreamWriter New_WithByteOrderMark(Stream stream)
            => this.New(
                stream,
                Instances.Encodings.UTF8_WithBOM);

        /// <summary>
        /// Chooses <see cref="New_CloseAfter(Stream)"/> as the default, since by default the stream write closes its underlying stream.
        /// </summary>
        public StreamWriter New(Stream stream)
            => this.New_CloseAfter(stream);

        /// <summary>
        /// The <see cref="StreamWriter"/> class by default closes the underlying stream to which it writes. The <see cref="IStreamWriterOperator.New_LeaveOpen(Stream)"/> method creates a <see cref="StreamWriter"/> that will be left open.
        /// This method provides the default <see cref="StreamWriter"/> behavior, to allow library users to get in the habit of using the <see cref="IStreamWriterOperator"/> in all cases, and to make the behavior of the <see cref="StreamWriter"/> explicit.
        /// </summary>
        /// <remarks>
        /// Note: Returned writer produces no BOM.
        /// </remarks>
        public StreamWriter New_CloseAfter(Stream stream)
        {
            // This constructor produces no BOM as proven in an ExaminingCSharp experiment.
            var output = new StreamWriter(stream);
            return output;
        }

        /// <summary>
        /// The <see cref="StreamWriter"/> class has a constructor that helpfully leaves the underlying stream open after writing.
        /// However, this constructor puts the argument to leave the underlying stream open at the end of the input arguments list, behind lots of values crazy random values.
        /// This method produces a <see cref="StreamWriter"/> that will leave the underlying stream open with the ease of the default constructor.
        /// </summary>
        /// <remarks>
        /// Note: Whether or not the returned writer produces a byte-order mark (BOM) 
        /// </remarks>
        public StreamWriter New_LeaveOpen(
            Stream stream,
            Encoding encoding)
        {
            // Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks.
            var output = new StreamWriter(stream,
                encoding,
                Instances.Values.StreamBufferSize_Default,
                true);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="New_LeaveOpen_WithByteOrderMark(Stream)"/> as the default, since the default UTF8 encoding includes the BOM.
        /// </summary>
        public StreamWriter New_LeaveOpen(Stream stream)
            => this.New_LeaveOpen_WithByteOrderMark(stream);

        /// <summary>
        /// Returns a writer that will produce initial byte-order-marks (BOM).
        /// </summary>
        public StreamWriter New_LeaveOpen_WithByteOrderMark(Stream stream)
            => this.New_LeaveOpen(
                stream,
                Instances.Encodings.UTF8_WithBOM);

        /// <summary>
        /// Note new UTF8Encoding(false), instead of Encoding.UTF8, to prevent random byte-order-marks (BOM) marks.
        /// This was a big problem in writing to existing memory streams since the odd-number of BOM bytes (3) would be placed where writing started, in the middle of the memory stream!
        /// </summary>
        public StreamWriter New_LeaveOpen_WithoutByteOrderMark(Stream stream)
            => this.New_LeaveOpen(
                stream,
                Instances.Encodings.UTF8_WithoutBOM);

        /// <summary>
        /// Gets a new file stream opened for writing.
        /// </summary>
        public StreamWriter New_Write(
            string filePath,
            bool overwrite = IValues.Overwrite_Default_Constant)
        {
            var stream = Instances.FileStreamOperator.Open_Write(filePath, overwrite);

            var output = this.New_CloseAfter(stream);
            return output;
        }
    }
}
