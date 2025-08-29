using System;


namespace F10Y.L0000.Q000
{
    public static class Instances
    {
        public static IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static IGuidOperator GuidOperator => L0000.GuidOperator.Instance;
        public static IHashCodeOperator HashCodeOperator => L0000.HashCodeOperator.Instance;
        public static IIntegers Integers => L0000.Integers.Instance;
        public static IPathOperator PathOperator => L0000.PathOperator.Instance;
        public static IPaths Paths => Q000.Paths.Instance;
        public static L0001.Z000.ISeeds Seeds => L0001.Z000.Seeds.Instance;
        public static Z0000.IStrings Strings => Z0000.Strings.Instance;
        public static IVersionOperator VersionOperator => L0000.VersionOperator.Instance;
        public static Z0000.IVersions Versions => Z0000.Versions.Instance;
    }
}