using System;
using System.Threading.Tasks;


namespace F10Y.L0000.Construction
{
    class Program
    {
        static async Task Main()
        {
            //await Program.Demonstrations_();
            //await Program.Demonstrations_Guid();
            await Program.Demonstrations_StringOperator();
            //await Program.Demonstrations_Version();

            //await Program.Scripts_();
            //await Program.Scripts_String();
        }


        #region Demonstrations

        static Task Demonstrations_()
        {
            throw new NotImplementedException();
        }

        static async Task Demonstrations_Guid()
        {
            await Instances.GuidDemonstrations
                //.Generate_New_Guid_Seeded()
                .Generate_New_Guid()
                ;
        }

        static async Task Demonstrations_Version()
        {
            await Instances.VersionDemonstrations
                .Increment_MajorVersion()
                ;
        }

        static async Task Demonstrations_StringOperator()
        {
            await StringOperatorDemonstrations.Instance
                .Ensure_Enquoted()
                //.Has_IndexOfAny()
                ;
        }

        #endregion


        #region Scripts

        static Task Scripts_()
        {
            throw new NotImplementedException();
        }

        static async Task Scripts_String()
        {
            await StringScripts.Instance
                .Try_Ensure_Enquoted()
                ;
        }

        #endregion
    }
}