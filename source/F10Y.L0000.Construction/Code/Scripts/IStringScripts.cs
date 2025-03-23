using System;
using System.Threading.Tasks;

using F10Y.T0005;


namespace F10Y.L0000.Construction
{
    [ScriptsMarker]
    public partial interface IStringScripts
    {
        public Task Try_Ensure_Enquoted()
        {
            var text =
                Instances.Texts.Example_Text
                ;
            var text_Expected =
                Instances.Texts.Example_Text_Enquoted
                ;

            var text_Enquoted = Instances.StringOperator.Ensure_Enquoted(text);

            var equal = text_Enquoted == text_Expected;

            Console.WriteLine($"{equal}: equal?\n\n{text_Enquoted}: enquoted\n{text_Expected}: expected\n{text}: text");

            return Task.CompletedTask;
        }
    }
}
