using System;


namespace F10Y.L0000
{
    public class StringOperations : IStringOperations
    {
        #region Infrastructure

        public static IStringOperations Instance { get; } = new StringOperations();


        private StringOperations()
        {
        }

        #endregion
    }
}
