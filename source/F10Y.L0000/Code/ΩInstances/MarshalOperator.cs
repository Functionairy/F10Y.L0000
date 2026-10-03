using System;


namespace F10Y.L0000
{
    public class MarshalOperator : IMarshalOperator
    {
        #region Infrastructure

        public static IMarshalOperator Instance { get; } = new MarshalOperator();


        private MarshalOperator()
        {
        }

        #endregion
    }
}
