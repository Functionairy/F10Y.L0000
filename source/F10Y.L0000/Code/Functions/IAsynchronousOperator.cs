using System;
using System.Threading;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAsynchronousOperator
    {
        /// <inheritdoc cref="Execute_Synchronously(Task)"/>>
        void Execute_Synchronously(Func<Task> action)
        {
            var task = action();

            this.Execute_Synchronously(task);
        }

        /// <summary>
        /// Solves the famed-and-fabled sync-over-async problem.
        /// </summary>
        void Execute_Synchronously(Task task)
        {
            // Force synchronously executing thread to wait for the asynchrous work to to be done.
            var semaphore = new SemaphoreSlim(0);

            async Task Execute_Task_Asynchronously()
            {
                await task;

                semaphore.Release();
            }

            // Fire and forget in the threadpool.
            var executionTask = Execute_Task_Asynchronously();

            semaphore.Wait();

            if (executionTask.IsFaulted)
            {
                throw executionTask.Exception;
            }
        }
    }
}
