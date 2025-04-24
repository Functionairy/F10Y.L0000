using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0006;


namespace F10Y.L0000.Q000.L000
{
    [DemonstrationsMarker]
    public partial interface IVersionDemonstrations
    {
        public async Task Increment_MajorVersion()
        {
            /// Inputs.
            var version =
                Instances.Versions.Example
                ;
            var output_TextFilePath = Instances.FilePaths.Output_TextFilePath;


            /// Run.
            var version_Incremented_MajorValue = Instances.VersionOperator.Increment_MajorValue(version);
            var version_Incremented_MinorValue = Instances.VersionOperator.Increment_MinorValue(version);
            var version_Incremented_BuildValue = Instances.VersionOperator.Increment_BuildValue(version);
            var version_Incremented_RevisionValue = Instances.VersionOperator.Increment_RevisionValue(version);

            var version_String = Instances.VersionOperator.To_String(version);
            var version_Incremented_MajorValue_String = Instances.VersionOperator.To_String(version_Incremented_MajorValue);
            var version_Incremented_MinorValue_String = Instances.VersionOperator.To_String(version_Incremented_MinorValue);
            var version_Incremented_BuildValue_String = Instances.VersionOperator.To_String(version_Incremented_BuildValue);
            var version_Incremented_RevisionValue_String = Instances.VersionOperator.To_String(version_Incremented_RevisionValue);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{version_String}: version")
                .Append($"{version_Incremented_MajorValue_String}: increment major")
                .Append($"{version_Incremented_MinorValue_String}: increment minor")
                .Append($"{version_Incremented_BuildValue_String}: increment build")
                .Append($"{version_Incremented_RevisionValue_String}: increment revision")
                ;

            await Instances.FileOperator.Write_Lines(
                output_TextFilePath,
                lines_ForOutput);

            Instances.NotepadPlusPlusOperator.Open(output_TextFilePath);
        }
    }
}
