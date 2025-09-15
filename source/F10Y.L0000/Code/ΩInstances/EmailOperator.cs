using System;


namespace F10Y.L0000
{
    public class EmailOperator : IEmailOperator
    {
        #region Infrastructure

        public static IEmailOperator Instance { get; } = new EmailOperator();


        private EmailOperator()
        {
        }

        #endregion
    }
}
