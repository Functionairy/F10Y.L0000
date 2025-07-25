using System;


namespace F10Y.L0000
{
    public class LengthOperator : ILengthOperator
    {
        #region Infrastructure

        public static ILengthOperator Instance { get; } = new LengthOperator();


        private LengthOperator()
        {
        }

        #endregion
    }
}
