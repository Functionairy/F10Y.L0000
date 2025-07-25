using System;


namespace F10Y.L0000
{
    public class VolumeSeparators : IVolumeSeparators
    {
        #region Infrastructure

        public static IVolumeSeparators Instance { get; } = new VolumeSeparators();


        private VolumeSeparators()
        {
        }

        #endregion
    }
}
