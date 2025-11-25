using System;


namespace F10Y.L0000
{
    public class AsynchronousOperator : IAsynchronousOperator
    {
        #region Infrastructure

        public static IAsynchronousOperator Instance { get; } = new AsynchronousOperator();


        private AsynchronousOperator()
        {
        }

        #endregion
    }
}
