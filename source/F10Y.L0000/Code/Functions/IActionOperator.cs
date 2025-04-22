using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IActionOperator
    {
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

        /// <summary>
        /// Chooses <see cref="Run_Action_ExceptionIfDefault{TValue}(TValue, Action{TValue})"/> as the default.
        /// </summary>
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
