using System;


namespace F10Y.L0000
{
    public class DirectorySeparatorOperator : IDirectorySeparatorOperator
    {
        #region Infrastructure

        public static IDirectorySeparatorOperator Instance { get; } = new DirectorySeparatorOperator();


        private DirectorySeparatorOperator()
        {
        }

        #endregion
    }
}
