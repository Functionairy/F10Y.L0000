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

        async Task<T> Continue_With<T>(
            Task<T> task,
            params Action<T>[] actions)
        {
            var output = await task;

            Instances.ActionOperator.Run_Actions(
                output,
                actions);

            return output;
        }

        async Task<TOut> Continue_With<TIn, TOut>(
            Task<TIn> task,
            Func<TIn, TOut> function)
        {
            var input = await task;

            var output = function(input);
            return output;
        }

        /// <inheritdoc cref="Task.Delay(int)"/>
        Task Delay(int milliseconds)
            => Task.Delay(milliseconds);

        /// <inheritdoc cref="Task.Delay(TimeSpan)"/>
        Task Delay(TimeSpan timeSpan)
            => Task.Delay(timeSpan);

        Task Delay_Infinite()
            => Task.Delay(Timeout.Infinite);

        Task<T> From_Result<T>(T result)
            => Task.FromResult(result);

        /// <summary>
        /// Calls <see cref="Delay(int)"/>.
        /// </summary>
        Task Wait(int milliseconds)
            => this.Delay(milliseconds);

        Task When_All(IEnumerable<Task> tasks)
            => Task.WhenAll(tasks);

        Task When_All(params Task[] tasks)
            => Task.WhenAll(tasks);

        async Task<(T1, T2)> When_All<T1, T2>((Task<T1>, Task<T2>) tasks)
        {
            await this.When_All(
                tasks.Item1,
                tasks.Item2);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result);

            return output;
        }

        async Task<(T1, T2, T3)> When_All<T1, T2, T3>((Task<T1>, Task<T2>, Task<T3>) tasks)
        {
            await this.When_All(
                tasks.Item1,
                tasks.Item2,
                tasks.Item3);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result,
                tasks.Item3.Result);

            return output;
        }

        async Task<(T1, T2, T3, T4)> When_All<T1, T2, T3, T4>((Task<T1>, Task<T2>, Task<T3>, Task<T4>) tasks)
        {
            await this.When_All(
                tasks.Item1,
                tasks.Item2,
                tasks.Item3,
                tasks.Item4);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result,
                tasks.Item3.Result,
                tasks.Item4.Result);

            return output;
        }

        async Task<(T1, T2, T3, T4, T5)> When_All<T1, T2, T3, T4, T5>((Task<T1>, Task<T2>, Task<T3>, Task<T4>, Task<T5>) tasks)
        {
            await this.When_All(
                tasks.Item1,
                tasks.Item2,
                tasks.Item3,
                tasks.Item4,
                tasks.Item5);

            var output = (
                tasks.Item1.Result,
                tasks.Item2.Result,
                tasks.Item3.Result,
                tasks.Item4.Result,
                tasks.Item5.Result);

            return output;
        }
    }
}
