using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IBooleanOperator
    {
        /// <summary>
        /// Chooses <see cref="From_Restrictive_Exceptive(string)"/> as the default.
        /// </summary>
        public bool From(string value)
            => this.From_Restrictive_Exceptive(value);

        /// <summary>
        /// If its not one of the representations of true, it's false.
        /// </summary>
        public bool From_Robust_NoExceptive(string value)
        {
            var output = value switch
            {
                IStrings.True_Constant => true,
                IStrings.True_Lowercase_Constant => true,
                IStrings.True_Uppercase_Constant => true,
                _ => false
            };

            return output;
        }

        /// <summary>
        /// Values other than one of the recognized boolean representations result in an exception.
        /// </summary>
        public bool From_Restrictive_Exceptive(string value)
        {
            var output = value switch
            {
                IStrings.False_Constant => false,
                IStrings.False_Lowercase_Constant => false,
                IStrings.False_Uppercase_Constant => false,
                IStrings.True_Constant => true,
                IStrings.True_Lowercase_Constant => true,
                IStrings.True_Uppercase_Constant => true,
                _ => throw Instances.ExceptionOperator.From($"{value}: unrecognized boolean representation.")
            };

            return output;
        }

        /// <summary>
        /// Outputs either <inheritdoc cref="IStrings.True" path="descendant::value"/> or <inheritdoc cref="IStrings.False" path="descendant::value"/>.
        /// </summary>
        public string To_String(bool value)
        {
            var representation = value
                ? Instances.Strings.True
                : Instances.Strings.False
                ;

            return representation;
        }

        /// <summary>
        /// Outputs either <inheritdoc cref="IStrings.True_Lowercase" path="descendant::value"/> or <inheritdoc cref="IStrings.False_Lowercase" path="descendant::value"/>.
        /// </summary>
        public string To_String_Lower(bool value)
        {
            var representation = value
                ? Instances.Strings.True_Lowercase
                : Instances.Strings.False_Lowercase
                ;

            return representation;
        }

        /// <summary>
        /// Outputs either <inheritdoc cref="IStrings.True_Uppercase" path="descendant::value"/> or <inheritdoc cref="IStrings.False_Uppercase" path="descendant::value"/>.
        /// </summary>
        public string To_String_Upper(bool value)
        {
            var representation = value
                ? Instances.Strings.True_Uppercase
                : Instances.Strings.False_Uppercase
                ;

            return representation;
        }
    }
}
