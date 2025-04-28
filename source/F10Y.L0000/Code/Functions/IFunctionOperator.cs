using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFunctionOperator
    {
        public T Return<T>(T value)
            => value;

        /// <summary>
		/// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
		/// </summary>
        public TOutput Run<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function(
                value,
                function);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Run_Function_OkIfDefault{T, TOutput}(T, Func{T, TOutput})"/> as the default.
        /// </summary>
        public TOutput Run_Function<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var output = this.Run_Function_OkIfDefault(
                value,
                function);

            return output;
        }

        public TOutput Run_Function_OkIfDefault<T, TOutput>(
            T value,
            Func<T, TOutput> function = default)
        {
            var isNotDefault = Instances.DefaultOperator.Is_NotDefault(function);
            if (isNotDefault)
            {
                var output = function(value);
                return output;
            }

            // Else
            return default;
        }
    }
}
