using System;
using System.Threading;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ICancellationTokens
    {
        /// <inheritdoc cref="CancellationToken.None"/>
        public CancellationToken None => CancellationToken.None;
    }
}
