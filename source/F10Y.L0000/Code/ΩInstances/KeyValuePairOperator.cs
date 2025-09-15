using System;


namespace F10Y.L0000
{
    public class KeyValuePairOperator : IKeyValuePairOperator
    {
        #region Infrastructure

        public static IKeyValuePairOperator Instance { get; } = new KeyValuePairOperator();


        private KeyValuePairOperator()
        {
        }

        #endregion
    }
}
