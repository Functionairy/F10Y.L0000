using System;


namespace F10Y.L0000.V000
{
    public static class Instances
    {
        public static L0002.IExpectationOperator ExpectationOperator => L0002.ExpectationOperator.Instance;
        public static IExpectations Expectations => V000.Expectations.Instance;
        public static IExpectationSets ExpectationSets => V000.ExpectationSets.Instance;
        public static IStringOperator StringOperator => L0000.StringOperator.Instance;
        public static ITestMethods TestMethods => V000.TestMethods.Instance;
        public static L0002.ITestOperator TestOperator => L0002.TestOperator.Instance;
        public static Z000.ITexts Texts => Z000.Texts.Instance;
    }
}