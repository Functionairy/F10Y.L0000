using System;
using System.IO;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMemoryStreamOperator
    {
        public MemoryStream FromBytes(byte[] bytes)
        {
            var memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }

        public async Task<MemoryStream> FromFile(string filePath)
        {
            var fileBytes = await Instances.FileOperator.Read_Bytes(filePath);

            var memoryStream = this.FromBytes(fileBytes);
            return memoryStream;
        }

        public MemoryStream Get_New()
            => new MemoryStream();
    }
}
