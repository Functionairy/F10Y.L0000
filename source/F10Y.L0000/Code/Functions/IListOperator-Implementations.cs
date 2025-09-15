using System;
using System.Collections.Generic;

using F10Y.T0002;


namespace F10Y.L0000.Implementations
{
    [FunctionsMarker]
    public partial interface IListOperator
    {
        public T Get_Second_ViaIndex<T>(IList<T> list)
        {
            var output = list[1];
            return output;
        }

        public T Get_Second_ViaNth<T>(IList<T> list)
        {
            var output = Instances.ListOperator.Get_Nth(list, 2);
            return output;
        }
    }
}
