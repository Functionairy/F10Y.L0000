using System;
using System.Threading;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IThreadOperator
    {
        public void Sleep_ForMilliseconds(int numberOf_Milliseconds)
        {
            Thread.Sleep(numberOf_Milliseconds);
        }
    }
}
