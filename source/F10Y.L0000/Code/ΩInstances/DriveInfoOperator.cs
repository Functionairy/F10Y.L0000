using System;


namespace F10Y.L0000
{
    public class DriveInfoOperator : IDriveInfoOperator
    {
        #region Infrastructure

        public static IDriveInfoOperator Instance { get; } = new DriveInfoOperator();


        private DriveInfoOperator()
        {
        }

        #endregion
    }
}
