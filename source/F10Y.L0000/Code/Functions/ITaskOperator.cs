using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface ITaskOperator
    {
        async Task<T> Await<T>(Task<T> task)
            => await task;

        /// <inheritdoc cref="Task.Delay(int)"/>
        Task Delay(int milliseconds)
            => Task.Delay(milliseconds);

        Task Delay_Infinite()
            => Task.Delay(Timeout.Infinite);

        /// <summary>
        /// Calls <see cref="Delay(int)"/>.
        /// </summary>
        Task Wait(int milliseconds)
            => this.Delay(milliseconds);

        Task When_All(IEnumerable<Task> tasks)
            => Task.WhenAll(tasks);
    }
}
