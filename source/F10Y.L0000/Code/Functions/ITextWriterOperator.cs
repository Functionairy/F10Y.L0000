using System;
using System.Collections.Generic;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITextWriterOperator
    {
        public void Write_Lines_Synchronous(
            TextWriter textWriter,
            IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                this.Write_Line_Synchronous(
                    textWriter,
                    line);
            }
        }

        public void Write_Line_Synchronous(
            TextWriter textWriter,
            string line)
        {
            textWriter.WriteLine(line);
        }
    }
}
