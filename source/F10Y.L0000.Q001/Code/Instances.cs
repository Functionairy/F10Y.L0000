using System;


namespace F10Y.L0000.Q001
{
    public static class Instances
    {
        public static IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static IFileOperator FileOperator => L0000.FileOperator.Instance;
        public static IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static Z000.ITexts Texts => Z000.Texts.Instance;
    }
}