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
        Exception From(string message)
        {
            var output = this.Get_Exception(message);
            return output;
        }

        Exception Get_AttributeNotFoundException(string attributeName)
        {
            var message = Instances.ExceptionMessageOperator.Get_AttributeNotFoundMessage(attributeName);

            var output = this.Get_Exception(message);
            return output;
        }

        Exception Get_Exception(string message)
        {
            var output = new Exception(message);
            return output;
        }

        /// <summary>
        /// Length must be greater-than-or-equal-to zero.
        /// </summary>
        Exception Get_InvalidLengthException(int length)
        {
            var message = Instances.ExceptionMessageOperator.Get_InvalidLengthMessage(length);

            var output = this.Get_Exception(message);
            return output;
        }

        ArgumentNullException New_ArgumentNullException(string argumentName)
            => new ArgumentNullException(argumentName);

        void Throw(string message)
        {
            var exception = this.From(message);

            this.Throw(exception);
        }

        void Throw(Exception exception)
        {
            throw exception;
        }

        void Throw_NotImplementedException()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Output value is to allow fitting into Func&lt;TOut&gt;.
        /// </remarks>
        TOut Throw_NotImplementedException<TOut>()
        {
            throw new NotImplementedException();
        }
    }
}
