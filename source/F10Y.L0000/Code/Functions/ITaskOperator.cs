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
    }
}
