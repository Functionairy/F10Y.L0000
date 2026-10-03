using System;
using System.Threading.Tasks;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ITasks
    {
        /// <inheritdoc cref="Task.CompletedTask"/>
        Task Completed => Task.CompletedTask;
    }
}
