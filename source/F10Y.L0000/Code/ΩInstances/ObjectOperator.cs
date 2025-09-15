using System;


namespace F10Y.L0000
{
    public class ObjectOperator : IObjectOperator
    {
        #region Infrastructure

        public static IObjectOperator Instance { get; } = new ObjectOperator();


        private ObjectOperator()
        {
        }

        #endregion
    }
}
