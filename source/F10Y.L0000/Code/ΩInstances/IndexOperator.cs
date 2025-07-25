using System;


namespace F10Y.L0000
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IIndexOperator Instance { get; } = new IndexOperator();


        private IndexOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Checked
{
    public class IndexOperator : IIndexOperator
    {
        #region Infrastructure

        public static IIndexOperator Instance { get; } = new IndexOperator();


        private IndexOperator()
        {
        }

        #endregion
    }
}