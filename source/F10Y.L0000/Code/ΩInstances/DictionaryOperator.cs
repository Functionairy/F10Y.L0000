using System;


namespace F10Y.L0000
{
    public class DictionaryOperator : IDictionaryOperator
    {
        #region Infrastructure

        public static IDictionaryOperator Instance { get; } = new DictionaryOperator();


        private DictionaryOperator()
        {
        }

        #endregion
    }
}
