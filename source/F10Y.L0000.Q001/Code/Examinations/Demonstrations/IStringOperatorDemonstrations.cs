using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.L0000.Extensions;
using F10Y.L0001.L000.Extensions;
using F10Y.T0006;


namespace F10Y.L0000.Q001
{
    [DemonstrationsMarker]
    public partial interface IStringOperatorDemonstrations :
        T0014.T001.IScriptTextOutputInfrastructure_Definition
    {
        /// <summary>
        /// Demonstrates the function <see cref="IStringOperator.Has_IndexOfAny(string, out int, char[])"/>.
        /// </summary>
        /// <returns></returns>
        public async Task Has_IndexOfAny()
        {
            /// Inputs.
            var @string = @"C:\Temp\Temp.txt";
            var characters = new[]
            {
                '\\',
                '/'
            };

            var output_TextFilePath = this.Output_TextFilePath;


            /// Run.
            var has_IndexOfAny = Instances.StringOperator.Has_IndexOfAny(
                @string,
                out var indexOfAny_OrNotFound,
                characters);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{has_IndexOfAny}: has-index of any\n")
                .Append_If(
                    has_IndexOfAny,
                    $"{indexOfAny_OrNotFound}: index")
                .Append($"String:\n\t{@string}")
                .Append_Many(Instances.EnumerableOperator.From("Characters:")
                    .Append_Many(characters
                        .Select(character => $"{character}")
                        .Entab()
                    )
                )
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }

        public async Task Ensure_Enquoted()
        {
            /// Inputs.
            var text =
                Instances.Texts.Example_Text
                ;
            var text_Expected =
                Instances.Texts.Example_Text_Enquoted
                ;

            var output_TextFilePath = this.Output_TextFilePath;


            /// Rhn,
            var text_Enquoted = Instances.StringOperator.Ensure_Enquoted(text);

            var equal = text_Enquoted == text_Expected;

            var lines_ForOutput = Instances.EnumerableOperator.From($"{equal}: enquoted text equal to expected text?\n\n{text}: text\n{text_Enquoted}: enquoted\n{text_Expected}: expected");

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            this.Open(output_TextFilePath);
        }
    }
}
