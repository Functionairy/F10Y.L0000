using System;
using System.Threading.Tasks;


namespace F10Y.L0000.Construction
{
    class Program
    {
        static async Task Main()
        {
            await Program.Demonstrations();
            //await Program.Scripts();
        }


        static async Task Demonstrations()
        {
            await Program.Demonstrations_String();
        }

        static async Task Demonstrations_String()
        {
            await StringDemonstrations.Instance.Ensure_Enquoted();
        }

        static async Task Scripts()
        {
            await Program.Scripts_String();
        }

        static async Task Scripts_String()
        {
            await StringScripts.Instance.Try_Ensure_Enquoted();
        }
    }
}