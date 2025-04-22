using System;


namespace F10Y.L0000
{
    public class ZipOperator : IZipOperator
    {
        #region Infrastructure

        public static IZipOperator Instance { get; } = new ZipOperator();


        private ZipOperator()
        {
        }

        #endregion
    }
}
