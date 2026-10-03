using System;


namespace F10Y.L0000
{
    public class Tasks : ITasks
    {
        #region Infrastructure

        public static ITasks Instance { get; } = new Tasks();


        private Tasks()
        {
        }

        #endregion
    }
}
