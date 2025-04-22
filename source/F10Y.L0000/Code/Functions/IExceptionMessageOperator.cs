using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExceptionMessageOperator
    {
        public string Get_AttributeNotFoundMessage(string attributeName)
        {
            var output = $"Attribute '{attributeName}' not found.";
            return output;
        }
    }
}
