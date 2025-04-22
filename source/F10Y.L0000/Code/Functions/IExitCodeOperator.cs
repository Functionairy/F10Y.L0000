using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IExitCodeOperator
    {
        public bool Is_Success(int exitCode)
        {
            var output = exitCode == Instances.ExitCodes.Success;
            return output;
        }

        public bool Is_Failure(int exitCode)
        {
            var output = exitCode != Instances.ExitCodes.Success;
            return output;
        }
    }
}
