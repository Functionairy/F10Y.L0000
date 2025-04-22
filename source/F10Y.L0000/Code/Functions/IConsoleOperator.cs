using System;
using System.Collections.Generic;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IConsoleOperator
    {
        public TextWriter Get_OutputStream()
            => Console.Out;

        public void Write(char character)
            => Console.Write(character);

        public void Write(string @string)
            => Console.Write(@string);

        public void Write_Line()
            => Console.WriteLine();

        public void Write_Line(string line)
            => Console.WriteLine(line);

        public void Write_Line<T>(T value)
            => Console.WriteLine(value);

        public void Write_Lines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                this.Write_Line(line);
            }
        }

        public void Write_Lines<T>(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                this.Write_Line(value.ToString());
            }
        }
    }
}
