using System;


namespace F10Y.L0000.Construction
{
    public static class Instances
    {
        public static IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static L0004.L000.IFilePaths FilePaths => L0004.L000.FilePaths.Instance;
        public static Q000.IGuidDemonstrations GuidDemonstrations => Q000.GuidDemonstrations.Instance;
        public static L0019.INotepadPlusPlusOperator NotepadPlusPlusOperator => L0019.NotepadPlusPlusOperator.Instance;
        public static IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static ITexts Texts => Construction.Texts.Instance;
        public static Q000.IVersionDemonstrations VersionDemonstrations => Q000.VersionDemonstrations.Instance;
    }
}