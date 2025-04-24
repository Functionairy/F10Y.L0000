using System;
using System.Threading.Tasks;


namespace F10Y.L0000.Q000
{
    class Program
    {
        static async Task Main()
        {
            //await Program.Demonstrations_();
            //await Program.Demonstrations_Guid();
            await Program.Demonstrations_Version();
        }

        #region Demonstrations

        static Task Demonstrations_()
        {
            throw new NotImplementedException();
        }

        static async Task Demonstrations_Guid()
        {
            await Instances.GuidDemonstrations.Generate_New_Guid_Seeded();
            //await Instances.GuidDemonstrations.Generate_New_Guid();
        }

        static async Task Demonstrations_Version()
        {
            await Instances.VersionDemonstrations.Increment_MajorVersion();
        }

        #endregion
    }
}
