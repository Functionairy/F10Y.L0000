using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileSystemInfoOperator
    {
        /// <summary>
        /// Orders file system entries by write time in descending order.
        /// </summary>
        /// <remarks>
        /// This method handles the trap that <see cref="FileSystemInfo.LastWriteTime"/> is a <strong>local</strong> time!
        /// This is not usually a problem: if all entries are from the same file system, their relative local times are chronologically correct.
        /// However, if you are sorting a set of file system entries <strong>in general</strong>, those entries might be from different systems with different local times
        /// In this case sorting by local time would put those from earlier time zones before those from later time zones,
        /// even if the event in the earlier time zone happened after the event in the later time zone
        /// (for example 8am in London happens before 7am in New York).
        /// </remarks>
        IEnumerable<T> Order_ByWriteTime_Descending<T>(IEnumerable<T> fileSystemInfos)
            where T : FileSystemInfo
            => fileSystemInfos
                // Need to use UTC time to get an absolute sort (as local times would loop every 12 or 24 hours!
                .OrderByDescending(x => x.LastWriteTimeUtc)
                ;

        DateTime Get_LastModifiedTime(FileSystemInfo fileSystemInfo)
            => fileSystemInfo.LastWriteTime;
    }
}
