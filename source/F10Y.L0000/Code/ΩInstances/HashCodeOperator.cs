using System;


namespace F10Y.L0000
{
    public class HashCodeOperator : IHashCodeOperator
    {
        #region Infrastructure

        public static IHashCodeOperator Instance { get; } = new HashCodeOperator();


        private HashCodeOperator()
        {
        }

        #endregion
    }
}


namespace F10Y.L0000.Implementations
{
    public class HashCodeOperator : IHashCodeOperator
    {
        #region Infrastructure

        public static IHashCodeOperator Instance { get; } = new HashCodeOperator();


        private HashCodeOperator()
        {
        }

        #endregion
    }
}
