using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IRangeOperator
    {
        public bool Contains(
            Range range,
            int index)
        {
            var output = this.Contains_Inclusive(
                range,
                index);

            return output;
        }

        /// <summary>
        /// Inclusive of the start and end indices.
        /// </summary>
        public bool Contains_Inclusive(
            Range range,
            int index)
        {
            var output = true
                && range.Start.Value <= index
                && range.End.Value > index
                ;

            return output;
        }
    }
}
