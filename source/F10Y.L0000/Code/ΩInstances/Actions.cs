using System;


namespace F10Y.L0000
{
    public class Actions : IActions
    {
        #region Infrastructure

        public static IActions Instance { get; } = new Actions();


        private Actions()
        {
        }

        #endregion
    }


    public class Actions<T> : IActions<T>
    {
        #region Infrastructure

        public static IActions<T> Instance { get; } = new Actions<T>();


        private Actions()
        {
        }

        #endregion
    }


    public class Actions<T1, T2> : IActions<T1, T2>
    {
        #region Infrastructure

        public static IActions<T1, T2> Instance { get; } = new Actions<T1, T2>();


        private Actions()
        {
        }

        #endregion
    }
}
