using System;


namespace F10Y.L0000
{
    public class Indices : IIndices
    {
        #region Infrastructure

        public static IIndices Instance { get; } = new Indices();


        private Indices()
        {
        }

        #endregion
    }
}
