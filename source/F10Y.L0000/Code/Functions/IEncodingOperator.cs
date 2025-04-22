using System;
using System.Text;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEncodingOperator
    {
        public Encoding Get_UTF8_WithoutBOM()
            => new UTF8Encoding(false);
    }
}
