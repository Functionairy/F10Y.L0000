using System;


namespace F10Y.L0000
{
    public class MemoryStreamOperator : IMemoryStreamOperator
    {
        #region Infrastructure

        public static IMemoryStreamOperator Instance { get; } = new MemoryStreamOperator();


        private MemoryStreamOperator()
        {
        }

        #endregion
    }
}
