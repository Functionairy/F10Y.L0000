using System;


namespace F10Y.L0000
{
    public class HexadecimalOperator : IHexadecimalOperator
    {
        #region Infrastructure

        public static IHexadecimalOperator Instance { get; } = new HexadecimalOperator();


        private HexadecimalOperator()
        {
        }

        #endregion
    }
}
