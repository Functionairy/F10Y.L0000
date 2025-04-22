using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IListOperator
    {
        public List<T> New<T>()
            => new List<T>();
    }
}
