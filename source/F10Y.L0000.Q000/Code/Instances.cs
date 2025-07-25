using System;


namespace F10Y.L0000.Q000
{
    public static class Instances
    {
        public static IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static L0004.L000.IFilePaths FilePaths => L0004.L000.FilePaths.Instance;
        public static IGuidOperator GuidOperator => L0000.GuidOperator.Instance;
        public static L0019.INotepadPlusPlusOperator NotepadPlusPlusOperator => L0019.NotepadPlusPlusOperator.Instance;
        public static L0001.Z000.ISeeds Seeds => L0001.Z000.Seeds.Instance;
        public static IVersionOperator VersionOperator => L0000.VersionOperator.Instance;
        public static Z0000.IVersions Versions => Z0000.Versions.Instance;
    }
}