using System;
using System.Diagnostics;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStopwatchOperator
    {
        /// <inheritdoc cref="Stopwatch.Frequency"/>
        public long Get_Frequency()
            => Instances.Values.Stopwatch_Frequency;

        public bool Is_HighResolution()
            => Instances.Values.Stopwatch_Is_HighResolution;

        /// <summary>
        /// Gets a new stopwatch that has not been started.
        /// </summary>
        public Stopwatch New_Stopwatch()
            => new Stopwatch();

        /// <summary>
        /// Gets a stopwatch that has been started.
        /// </summary>
        public Stopwatch New_Stopwatch_Started()
            => Stopwatch.StartNew();

        /// <inheritdoc cref="Stopwatch.Elapsed"/>
        /// <remarks>
        /// Note: does not stop the stopwatch.
        /// </remarks>
        public TimeSpan Get_Elapsed(Stopwatch stopwatch)
            => stopwatch.Elapsed;

        public TimeSpan Get_Elapsed_WithStop(Stopwatch stopwatch)
        {
            this.Stop_Only(stopwatch);

            var output = this.Get_Elapsed(stopwatch);
            return output;
        }

        /// <inheritdoc cref="Stopwatch.ElapsedMilliseconds"/>
        public long Get_Elapsed_Milliseconds(Stopwatch stopwatch)
            => stopwatch.ElapsedMilliseconds;

        /// <inheritdoc cref="Stopwatch.ElapsedTicks"/>
        public long Get_Elapsed_Ticks(Stopwatch stopwatch)
            => stopwatch.ElapsedTicks;

        /// <inheritdoc cref="Stopwatch.IsRunning"/>
        public bool Is_Running(Stopwatch stopwatch)
            => stopwatch.IsRunning;

        /// <inheritdoc cref="Stopwatch.Reset"/>
        public void Reset(Stopwatch stopwatch)
            => stopwatch.Reset();

        /// <inheritdoc cref="Stopwatch.Restart"/>
        public void Restart(Stopwatch stopwatch)
            => stopwatch.Restart();

        /// <inheritdoc cref="Stopwatch.Start"/>
        public void Start(Stopwatch stopwatch)
            => stopwatch.Start();

        /// <inheritdoc cref="Stopwatch.Stop"/>
        public void Stop_Only(Stopwatch stopwatch)
            => stopwatch.Stop();

        /// <summary>
        /// Quality-of-life overload for <see cref="Get_Elapsed_WithStop(Stopwatch)"/>.
        /// </summary>
        public TimeSpan Stop(Stopwatch stopwatch)
            => this.Get_Elapsed_WithStop(stopwatch);

        public TimeSpan Measure_Duration(Action action)
        {
            var stopwatch = this.New_Stopwatch_Started();

            action();

            var duration = this.Stop(stopwatch);
            return duration;
        }

        public async Task<TimeSpan> Measure_Duration(Task action)
        {
            var stopwatch = this.New_Stopwatch_Started();

            await action;

            var duration = this.Stop(stopwatch);
            return duration;
        }

        public async Task<TimeSpan> Measure_Duration(Func<Task> action)
        {
            var stopwatch = this.New_Stopwatch_Started();

            await action();

            var duration = this.Stop(stopwatch);
            return duration;
        }

        public TOut Measure_Duration<TOut>(
            Func<TOut> function,
            out TimeSpan duration)
        {
            var stopwatch = this.New_Stopwatch_Started();

            var output = function();

            duration = this.Stop(stopwatch);

            return output;
        }

        public async Task<(TOut Out, TimeSpan Duration)> Measure_Duration<TOut>(Func<Task<TOut>> function)
        {
            var stopwatch = this.New_Stopwatch_Started();

            var output = await function();

            var duration = this.Stop(stopwatch);

            return (output, duration);
        }
    }
}
