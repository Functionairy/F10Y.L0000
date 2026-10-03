using System;


namespace F10Y.L0000
{
    public class NumberStylesSets : INumberStylesSets
    {
        #region Infrastructure

        public static INumberStylesSets Instance { get; } = new NumberStylesSets();


        private NumberStylesSets()
        {
        }

        #endregion
    }
}
