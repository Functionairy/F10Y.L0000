using System;


namespace F10Y.L0000
{
    public class ExceptionMessageMasks : IExceptionMessageMasks
    {
        #region Infrastructure

        public static IExceptionMessageMasks Instance { get; } = new ExceptionMessageMasks();


        private ExceptionMessageMasks()
        {
        }

        #endregion
    }
}
