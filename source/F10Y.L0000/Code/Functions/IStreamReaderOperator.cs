using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStreamReaderOperator
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(string)"/>.
        /// </summary>
        public StreamReader From(string filePath)
            => this.Get_New(filePath);

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_New(Stream)"/>.
        /// </summary>
        public StreamReader From(Stream stream)
            => this.Get_New(stream);

        public StreamReader Get_New(string filePath)
            => new StreamReader(filePath);

        public StreamReader Get_New(Stream stream)
            => new StreamReader(stream);
    }
}
