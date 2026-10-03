using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IActionOperator
    {
        Action<T> Combine<T>(params Action<T>[] actions)
            => value => this.Run_Actions(
                value,
                actions);

        /// <summary>
        /// The correct usage is:
        /// <code>Action&lt;RepositoryContext&gt; Default => Instances.ActionOperations.DoNothing_Synchronous;</code>
        /// (No need for a double arrow, => ... => ...;)
        /// </summary>
        void Do_Nothing_Synchronous<T>(T value)
        {
            // Do nothing.
        }

        Task Do_Nothing()
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        Task Do_Nothing<T>(T value)
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        Task Do_Nothing<T1, T2>(T1 value1, T2 value2)
        {
            // Do nothing.
            return Task.CompletedTask;
        }

        TValue Run_Function_OkIfDefault<TValue>(
            TValue value,
            Func<TValue, TValue> function)
        {
            var function_IsDefault = Instances.DefaultOperator.Is_Default(function);
            if (function_IsDefault)
            {
                return value;
            }

            var output = function(value);
            return output;
        }

        void Run_Action_OkIfDefault<TValue>(
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

        TValue Run_Functions_OkIfDefault<TValue>(
            TValue value,
            IEnumerable<Func<TValue, TValue>> functions)
        {
            var output = value;

            foreach (var function in functions)
            {
                output = this.Run_Function_OkIfDefault(
                    output,
                    function);
            }

            return output;
        }

        void Run_Actions_OkIfDefault<TValue>(
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

        void Run_Action_ExceptionIfDefault<TValue>(
            TValue value,
            Action<TValue> action)
        {
            action(value);
        }

        void Run_Actions_ExceptionIfDefault<TValue>(
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
        void Run_Action<TValue>(
            TValue value,
            Action<TValue> action)
            => this.Run_Action_ExceptionIfDefault(
                value,
                action);

        /// <summary>
        /// Chooses <see cref="Run_Actions_ExceptionIfDefault{TValue}(TValue, IEnumerable{Action{TValue}})"/> as the default.
        /// </summary>
        void Run_Actions<TValue>(
            TValue value,
            IEnumerable<Action<TValue>> actions)
            => this.Run_Actions_ExceptionIfDefault(
                value,
                actions);
    }
}
