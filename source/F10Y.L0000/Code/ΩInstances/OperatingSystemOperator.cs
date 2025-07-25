using System;


namespace F10Y.L0000
{
    public class OperatingSystemOperator : IOperatingSystemOperator
    {
        #region Infrastructure

        public static IOperatingSystemOperator Instance { get; } = new OperatingSystemOperator();


        private OperatingSystemOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Internal
{
    public class OperatingSystemOperator : IOperatingSystemOperator
    {
        #region Infrastructure

        public static IOperatingSystemOperator Instance { get; } = new OperatingSystemOperator();


        private OperatingSystemOperator()
        {
        }

        #endregion
    }
}
