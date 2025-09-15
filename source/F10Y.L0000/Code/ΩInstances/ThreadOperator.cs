using System;


namespace F10Y.L0000
{
    public class ThreadOperator : IThreadOperator
    {
        #region Infrastructure

        public static IThreadOperator Instance { get; } = new ThreadOperator();


        private ThreadOperator()
        {
        }

        #endregion
    }
}
