using System;


namespace F10Y.L0000
{
    public class NewLines : INewLines
    {
        #region Infrastructure

        public static INewLines Instance { get; } = new NewLines();


        private NewLines()
        {
        }

        #endregion
    }
}
