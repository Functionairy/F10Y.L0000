using System;


namespace F10Y.L0000
{
    public class Timestamps : ITimestamps
    {
        #region Infrastructure

        public static ITimestamps Instance { get; } = new Timestamps();


        private Timestamps()
        {
        }

        #endregion
    }
}
