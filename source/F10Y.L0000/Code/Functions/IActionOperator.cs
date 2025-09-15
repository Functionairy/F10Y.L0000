using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IActionOperator
    {
        /// <summary>
        /// The correct usage is:
        /// <code>public Action&lt;RepositoryContext&gt; Default => Instances.ActionOperations.DoNothing_Synchronous;</code>
        /// (No need for a double arrow, => ... => ...;)
        /// </summary>
        public void Do_Nothing_Synchronous<T>(T value)
        {
            // Do nothing.
        }

        public Task Do_Nothing()
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        public Task Do_Nothing<T>(T value)
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        public Task Do_Nothing<T1, T2>(T1 value1, T2 value2)
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        public void Run_Action_OkIfDefault<TValue>(
            TValue value,
            Action<TValue> action)
        {
            var action_IsDefault = Instances.DefaultOperator.Is_Default(action);
            if (action_IsDefault)
            {
                return;
            }

            action(value);
        }

        public void Run_Actions_OkIfDefault<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
        {
            foreach (var action in actions)
            {
                this.Run_Action_OkIfDefault(
                    value,
                    action);
            }
        }

        public void Run_Action_ExceptionIfDefault<TValue>(
            TValue value,
            Action<TValue> action)
        {
            action(value);
        }

        public void Run_Actions_ExceptionIfDefault<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
        {
            foreach (var action in actions)
            {
                this.Run_Action_ExceptionIfDefault(
                    value,
                    action);
            }
        }

        /// <remarks>
        /// Chooses <see cref="Run_Action_ExceptionIfDefault{TValue}(TValue, Action{TValue})"/> as the default.
        /// </remarks>
        public void Run_Action<TValue>(
            TValue value,
            Action<TValue> action)
            => this.Run_Action_ExceptionIfDefault(
                value,
                action);

        /// <summary>
        /// Chooses <see cref="Run_Actions_ExceptionIfDefault{TValue}(TValue, IEnumerable{Action{TValue}})"/> as the default.
        /// </summary>
        public void Run_Actions<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
            => this.Run_Actions_ExceptionIfDefault(
                value,
                actions);
    }
}
