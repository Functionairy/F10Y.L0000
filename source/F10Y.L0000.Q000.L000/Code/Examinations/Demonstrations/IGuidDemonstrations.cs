using System;
using System.Threading.Tasks;

using F10Y.T0006;


namespace F10Y.L0000.Q000.L000
{
    [DemonstrationsMarker]
    public partial interface IGuidDemonstrations
    {
        /// <summary>
        /// Generates a new, seeded guid, that will always be exactly the same: 351673f3-4a09-8529-fdff-2cb38696b28f.
        /// </summary>
        public async Task Generate_New_Guid_Seeded()
        {
            /// Inputs.
            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run
            var guid = Instances.GuidOperator.New_Seeded(
                Instances.Seeds.Default);

            var guid_String = Instances.GuidOperator.To_String(guid);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{guid_String}\n\t: new guid");

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }

        /// <summary>
        /// Generates a new guid that will be different each time.
        /// </summary>
        public async Task Generate_New_Guid()
        {
            /// Inputs.
            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run
            var guid = Instances.GuidOperator.New();

            var guid_String = Instances.GuidOperator.To_String(guid);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{guid_String}\n\t: new guid");

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
