using System;
using System.Collections.Generic;
using System.IO;


namespace F10Y.L0000.Extensions
{
    public static class FileSystemInfoExtensions
    {
        /// <inheritdoc cref="IFileSystemInfoOperator.Order_ByWriteTime_Descending{T}(IEnumerable{T})"/>
        public static IEnumerable<T> Order_ByWriteTime_Descending<T>(this IEnumerable<T> fileSystemInfos)
            where T : FileSystemInfo
            => Instances.FileSystemInfoOperator.Order_ByWriteTime_Descending(fileSystemInfos);
    }
}
