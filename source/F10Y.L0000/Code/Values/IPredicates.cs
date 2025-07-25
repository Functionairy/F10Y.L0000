using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IPredicates
    {
        /// <inheritdoc cref="IPredicateOperator.For{T}" path="/summary"/>
        /// <remarks>
        /// See: <see cref="IPredicateOperator.For{T}"/>
        /// </remarks>
        // Allow a method in this values instance, for quality-of-life.
        // It will *not* get picked up in instances survey.
        public IPredicates<T> For<T>()
            => Predicates<T>.Instance;
    }


    [ValuesMarker]
    public partial interface IPredicates<T>
    {
        /// <summary>
        /// Always returns false.
        /// </summary>
        Func<T, bool> False => x => false;

        /// <summary>
        /// Always returns true.
        /// </summary>
        Func<T, bool> True => x => true;
    }
}
