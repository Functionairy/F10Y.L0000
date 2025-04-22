using System;
using System.IO;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IFileModeOperator
    {
        public FileMode Get_FileMode(bool overwrite)
        {
            var output = overwrite
                ? FileMode.Create
                : FileMode.CreateNew
                ;

            return output;
        }

        public FileMode Get_FileMode_Overwrite()
            => this.Get_FileMode(true);

        public FileMode Get_FileMode_Preserve()
            => this.Get_FileMode(false);
    }
}
