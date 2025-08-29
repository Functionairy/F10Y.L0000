using System;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITaskOperator
    {
        public async Task<T> Await<T>(Task<T> task)
            => await task;

        /// <inheritdoc cref="Task.Delay(int)"/>
        public Task Delay(int milliseconds)
            => Task.Delay(milliseconds);

        /// <summary>
        /// Calls <see cref="Delay(int)"/>.
        /// </summary>
        public Task Wait(int milliseconds)
            => this.Delay(milliseconds);
    }
}
