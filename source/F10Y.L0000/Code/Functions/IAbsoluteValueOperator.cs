using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    /// <summary>
    /// Provides absolute-value functions for data types.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IAbsoluteValueOperator
    {
        decimal Get_AbsoluteValue(decimal value)
            => Instances.DecimalOperator.Get_AbsoluteValue(value);

        decimal Get(decimal value)
            => this.Get_AbsoluteValue(value);
    }
}
