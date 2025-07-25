using System;


namespace F10Y.L0000
{
    public class HashSetOperator : IHashSetOperator
    {
        #region Infrastructure

        public static IHashSetOperator Instance { get; } = new HashSetOperator();


        private HashSetOperator()
        {
        }

        #endregion
    }
}
