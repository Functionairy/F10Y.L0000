using System;


namespace F10Y.L0000
{
    public class DefaultOperator : IDefaultOperator
    {
        #region Infrastructure

        public static IDefaultOperator Instance { get; } = new DefaultOperator();


        private DefaultOperator()
        {
        }

        #endregion
    }


    public class DefaultOperator<T> : IDefaultOperator<T>
    {
        #region Infrastructure

        public static IDefaultOperator<T> Instance { get; } = new DefaultOperator<T>();


        private DefaultOperator()
        {
        }

        #endregion
    }
}
