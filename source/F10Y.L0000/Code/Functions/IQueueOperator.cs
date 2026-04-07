using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IQueueOperator
    {
        Queue<T> New<T>()
            => new Queue<T>();

        Queue<T> New<T>(IEnumerable<T> items)
            => new Queue<T>(items);

        Queue<T> New<T>(params T[] items)
            => new Queue<T>(items);
    }
}
