using System;


namespace F10Y.L0000
{
    public class CollectionOperator : ICollectionOperator
    {
        #region Infrastructure

        public static ICollectionOperator Instance { get; } = new CollectionOperator();


        private CollectionOperator()
        {
        }

        #endregion
    }
}
