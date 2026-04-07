using System;


namespace F10Y.L0000
{
    public class CustomAttributeDataOperator : ICustomAttributeDataOperator
    {
        #region Infrastructure

        public static ICustomAttributeDataOperator Instance { get; } = new CustomAttributeDataOperator();


        private CustomAttributeDataOperator()
        {
        }

        #endregion
    }
}
