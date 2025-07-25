using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStreamOperator
    {
        public void Seek_Beginnning(Stream stream)
        {
            stream.Seek(
                0,
                SeekOrigin.Begin);
        }
    }
}
