using System;


namespace F10Y.L0000
{
    public class PropertyInfoOperator : IPropertyInfoOperator
    {
        #region Infrastructure

        public static IPropertyInfoOperator Instance { get; } = new PropertyInfoOperator();


        private PropertyInfoOperator()
        {
        }

        #endregion
    }
}
