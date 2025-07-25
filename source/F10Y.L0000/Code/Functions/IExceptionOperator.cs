using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExceptionOperator
    {
        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Exception(string)"/>.
        /// </summary>
        public Exception From(string message)
        {
            var output = this.Get_Exception(message);
            return output;
        }

        public Exception Get_AttributeNotFoundException(string attributeName)
        {
            var message = Instances.ExceptionMessageOperator.Get_AttributeNotFoundMessage(attributeName);

            var output = this.Get_Exception(message);
            return output;
        }

        public Exception Get_Exception(string message)
        {
            var output = new Exception(message);
            return output;
        }

        /// <summary>
        /// Length must be greater-than-or-equal-to zero.
        /// </summary>
        public Exception Get_InvalidLengthException(int length)
        {
            var message = Instances.ExceptionMessageOperator.Get_InvalidLengthMessage(length);

            var output = this.Get_Exception(message);
            return output;
        }

        public void Throw(string message)
        {
            var exception = this.From(message);

            this.Throw(exception);
        }

        public void Throw(Exception exception)
        {
            throw exception;
        }
    }
}
