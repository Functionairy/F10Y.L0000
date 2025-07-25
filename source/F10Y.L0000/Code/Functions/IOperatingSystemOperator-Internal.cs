using System;
using System.Runtime.InteropServices;

using F10Y.T0002;


namespace F10Y.L0000.Internal
{
    [FunctionsMarker]
    public partial interface IOperatingSystemOperator
    {
        public string Get_UnknownOSPlatformExceptionMessage()
        {
            var message = $"Unknown {nameof(OSPlatform)} value. \nKnown {nameof(OSPlatform)} values:\n* {OSPlatform.Windows} (Windows)\n* {OSPlatform.OSX} (OSX)\n* {OSPlatform.Linux} (Linux)";
            return message;
        }

        public Exception Get_UnknownOSPlatformException()
        {
            var message = this.Get_UnknownOSPlatformExceptionMessage();

            var exception = new Exception(message);
            return exception;
        }
    }
}
