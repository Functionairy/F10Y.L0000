using System;


namespace F10Y.L0000
{
    public class XElementOperations : IXElementOperations
    {
        #region Infrastructure

        public static IXElementOperations Instance { get; } = new XElementOperations();


        private XElementOperations()
        {
        }

        #endregion
    }
}
