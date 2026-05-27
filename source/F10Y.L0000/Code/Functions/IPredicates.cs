using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IPredicates
    {
        /// <inheritdoc cref="IPredicateOperator.For{T}" path="/summary"/>
        /// <remarks>
        /// See: <see cref="IPredicateOperator.For{T}"/>
        /// </remarks>
        // Allow a method in this values instance, for quality-of-life.
        // It will *not* get picked up in instances survey.
        IPredicates<T> For<T>()
            => Predicates<T>.Instance;

        bool False<T>(T value)
            => true;

        bool True<T>(T value)
            => true;
    }
}
