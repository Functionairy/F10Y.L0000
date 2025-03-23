using System;


namespace F10Y.L0000.Construction
{
    public class StringScripts : IStringScripts
    {
        #region Infrastructure

        public static IStringScripts Instance { get; } = new StringScripts();


        private StringScripts()
        {
        }

        #endregion
    }
}
