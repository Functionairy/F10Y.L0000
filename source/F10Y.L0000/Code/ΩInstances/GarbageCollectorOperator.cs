using System;


namespace F10Y.L0000
{
    public class GarbageCollectorOperator : IGarbageCollectorOperator
    {
        #region Infrastructure

        public static IGarbageCollectorOperator Instance { get; } = new GarbageCollectorOperator();


        private GarbageCollectorOperator()
        {
        }

        #endregion
    }
}
