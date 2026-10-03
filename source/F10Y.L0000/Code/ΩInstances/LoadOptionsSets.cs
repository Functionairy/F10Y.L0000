using System;


namespace F10Y.L0000
{
    public class LoadOptionsSets : ILoadOptionsSets
    {
        #region Infrastructure

        public static ILoadOptionsSets Instance { get; } = new LoadOptionsSets();


        private LoadOptionsSets()
        {
        }

        #endregion
    }
}
