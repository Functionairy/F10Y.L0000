using System;


namespace F10Y.L0000
{
    public class PathOperator : IPathOperator
    {
        #region Infrastructure

        public static IPathOperator Instance { get; } = new PathOperator();


        private PathOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Implementations
{
    public class PathOperator : IPathOperator
    {
        #region Infrastructure

        public static IPathOperator Instance { get; } = new PathOperator();


        private PathOperator()
        {
        }

        #endregion
    }
}
