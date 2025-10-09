using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    /// <summary>
    /// Operator for the <see cref="DriveInfo"/> type.
    /// </summary>
    /// <remarks>
    /// <inheritdoc cref="Documentation.Project_SelfDescription" path="/summary"/>
    /// </remarks>
    [FunctionsMarker]
    public partial interface IDriveInfoOperator
    {
        long Get_FreeSpace(DriveInfo drive)
            => drive.TotalFreeSpace;

        /// <inheritdoc cref="DriveInfo.Name"/>
        string Get_Name(DriveInfo drive)
            => drive.Name;

        /// <inheritdoc cref="DriveInfo.GetDrives"/>
        DriveInfo[] Get_Drives()
            => DriveInfo.GetDrives();

        long Get_Size(DriveInfo drive)
            => drive.TotalSize;

        bool Is_Fixed(DriveInfo drive)
            => drive.DriveType == DriveType.Fixed;
    }
}
