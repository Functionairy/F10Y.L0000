using System;


namespace F10Y.L0000
{
    public class Assemblies : IAssemblies
    {
        #region Infrastructure

        public static IAssemblies Instance { get; } = new Assemblies();


        private Assemblies()
        {
        }

        #endregion
    }
}
