using System;


namespace F10Y.L0000
{
    public class EnvironmentOperator : IEnvironmentOperator
    {
        #region Infrastructure

        public static IEnvironmentOperator Instance { get; } = new EnvironmentOperator();


        private EnvironmentOperator()
        {
        }

        #endregion
    }
}
