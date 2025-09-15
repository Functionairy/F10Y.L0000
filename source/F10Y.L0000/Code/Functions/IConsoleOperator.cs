using System;
using System.Collections.Generic;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IConsoleOperator
    {
        /// <summary>
        /// Returns <see cref="Console.Out"/>.
        /// </summary>
        /// <remarks>
        /// Same as <see cref="Get_OutputWriter"/>
        /// </remarks>
        TextWriter Get_OutputStream()
            => Console.Out;

        /// <inheritdoc cref="Get_OutputStream" path="/summary"/>
        /// <remarks>
        /// Same as <see cref="Get_OutputStream"/>
        /// </remarks>
        TextWriter Get_OutputWriter()
            => Console.Out;

        void Wait_UntilAnyKey(string message)
        {
            this.Write(message);

            this.Read_Key();
        }

        /// <inheritdoc cref="Console.ReadKey(bool)"/>
        ConsoleKeyInfo Read_Key(bool intercept)
            => Console.ReadKey(intercept);

        /// <inheritdoc cref="Console.ReadKey()"/>
        ConsoleKeyInfo Read_Key()
            => Console.ReadKey();

        void Write(char character)
            => Console.Write(character);

        public void Write(string @string)
            => Console.Write(@string);

        void Write_Line()
            => Console.WriteLine();

        void Write_Line(string line)
            => Console.WriteLine(line);

        void Write_Line<T>(T value)
            => Console.WriteLine(value);

        void Write_Lines(IEnumerable<string> lines)
        {
            foreach (var line in lines)
            {
                this.Write_Line(line);
            }
        }

        void Write_Lines<T>(IEnumerable<T> values)
        {
            foreach (var value in values)
            {
                this.Write_Line(value.ToString());
            }
        }
    }
}
