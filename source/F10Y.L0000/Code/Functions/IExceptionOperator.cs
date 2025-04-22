using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExceptionOperator
    {
        public Exception Get_AttributeNotFoundException(string attributeName)
        {
            var message = Instances.ExceptionMessageOperator.Get_AttributeNotFoundMessage(attributeName);

            var output = new Exception(message);
            return output;
        }
    }
}
