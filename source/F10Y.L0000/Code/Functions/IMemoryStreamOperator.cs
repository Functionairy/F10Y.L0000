using System;
using System.IO;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMemoryStreamOperator
    {
        MemoryStream From_Bytes(byte[] bytes)
        {
            var memoryStream = new MemoryStream(bytes);
            return memoryStream;
        }

        async Task<MemoryStream> From_File(string filePath)
        {
            var fileBytes = await Instances.FileOperator.Read_Bytes(filePath);

            var memoryStream = this.From_Bytes(fileBytes);
            return memoryStream;
        }

        MemoryStream Get_New()
            => this.New();

        MemoryStream New()
            => new MemoryStream();
    }
}
