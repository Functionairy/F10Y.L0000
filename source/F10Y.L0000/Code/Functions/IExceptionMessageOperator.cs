using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExceptionMessageOperator
    {
        string Get_AttributeNotFoundMessage(string attributeName)
        {
            var output = Instances.StringOperator.Format(
                Instances.ExceptionMessageMasks.AttributeNotFound,
                attributeName);

            return output;
        }

        /// <inheritdoc cref="IExceptionMessageMasks.InvalidLength"/>
        string Get_InvalidLengthMessage(int length)
        {
            var output = Instances.StringOperator.Format(
                Instances.ExceptionMessageMasks.InvalidLength,
                length);

            return output;
        }
    }
}
