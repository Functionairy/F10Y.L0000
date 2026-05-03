using System;
using System.IO;
using System.Threading.Tasks;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStreamReaderOperator
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(string)"/>.
        /// </summary>
        StreamReader From(string filePath)
            => this.New(filePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(Stream)"/>.
        /// </summary>
        StreamReader From(Stream stream)
            => this.New(stream);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(string)"/>.
        /// </summary>
        StreamReader Get_New(string filePath)
            => this.New(filePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(Stream)"/>.
        /// </summary>
        StreamReader Get_New(Stream stream)
            => this.New(stream);

        StreamReader New(string filePath)
            => new StreamReader(filePath);

        StreamReader New(Stream stream)
            => new StreamReader(stream);

        Task<int> Read(
            StreamReader reader,
            char[] buffer,
            int index,
            int count)
            => reader.ReadAsync(
                buffer,
                index,
                count);
    }
}
