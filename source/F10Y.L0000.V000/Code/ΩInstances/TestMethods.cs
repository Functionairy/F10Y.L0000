using System;


namespace F10Y.L0000.V000
{
    public class TestMethods : ITestMethods
    {
        #region Infrastructure

        public static ITestMethods Instance { get; } = new TestMethods();


        private TestMethods()
        {
        }

        #endregion
    }
}
