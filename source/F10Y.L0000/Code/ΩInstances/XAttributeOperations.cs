using System;


namespace F10Y.L0000
{
    public class XAttributeOperations : IXAttributeOperations
    {
        #region Infrastructure

        public static IXAttributeOperations Instance { get; } = new XAttributeOperations();


        private XAttributeOperations()
        {
        }

        #endregion
    }
}
