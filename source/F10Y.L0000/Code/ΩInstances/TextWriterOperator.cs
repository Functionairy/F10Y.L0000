using System;


namespace F10Y.L0000
{
    public class TextWriterOperator : ITextWriterOperator
    {
        #region Infrastructure

        public static ITextWriterOperator Instance { get; } = new TextWriterOperator();


        private TextWriterOperator()
        {
        }

        #endregion
    }
}
