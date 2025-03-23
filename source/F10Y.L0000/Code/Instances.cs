using System;


namespace F10Y.L0000
{
    public static class Instances
    {
        public static ICharacters Characters => L0000.Characters.Instance;
        public static IDefaultOperator DefaultOperator => L0000.DefaultOperator.Instance;
        public static IEnumerableOperator EnumerableOperator => L0000.EnumerableOperator.Instance;
        public static IIndexOperator IndexOperator => L0000.IndexOperator.Instance;
        public static IIndices Indices => L0000.Indices.Instance;
        public static INullOperator NullOperator => L0000.NullOperator.Instance;
        public static IStrings Strings => L0000.Strings.Instance;
        public static IValues Values => L0000.Values.Instance;
    }
}