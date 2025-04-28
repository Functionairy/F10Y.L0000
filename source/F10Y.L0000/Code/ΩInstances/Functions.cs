using System;


namespace F10Y.L0000
{
    public class Functions<T> : IFunctions<T>
    {
        #region Infrastructure

        public static IFunctions<T> Instance { get; } = new Functions<T>();


        private Functions()
        {
        }

        #endregion
    }

    public class Functions : IFunctions
    {
        #region Infrastructure

        public static IFunctions Instance { get; } = new Functions();


        private Functions()
        {
        }

        #endregion
    }
}
