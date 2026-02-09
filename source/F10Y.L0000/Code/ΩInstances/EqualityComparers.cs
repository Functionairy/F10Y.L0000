using System;


namespace F10Y.L0000
{
    public class EqualityComparers : IEqualityComparers
    {
        #region Infrastructure

        public static IEqualityComparers Instance { get; } = new EqualityComparers();


        private EqualityComparers()
        {
        }

        #endregion
    }


    public class EqualityComparers<TValue> : IEqualityComparers<TValue>
    {
        #region Infrastructure

        public static IEqualityComparers<TValue> Instance { get; } = new EqualityComparers<TValue>();


        private EqualityComparers()
        {
        }

        #endregion
    }
}
