using System;


namespace F10Y.L0000
{
    public class RangeOperator : IRangeOperator
    {
        #region Infrastructure

        public static IRangeOperator Instance { get; } = new RangeOperator();


        private RangeOperator()
        {
        }

        #endregion
    }
}
