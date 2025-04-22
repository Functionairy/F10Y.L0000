using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IBooleanOperator
    {
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
    }
}
