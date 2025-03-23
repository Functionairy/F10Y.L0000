using System;


namespace F10Y.L0000.Construction
{
    public static class Instances
    {
        public static IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static ITexts Texts => Construction.Texts.Instance;
    }
}