using System;


namespace F10Y.L0000
{
    public class TaskOperator : ITaskOperator
    {
        #region Infrastructure

        public static ITaskOperator Instance { get; } = new TaskOperator();


        private TaskOperator()
        {
        }

        #endregion
    }
}
