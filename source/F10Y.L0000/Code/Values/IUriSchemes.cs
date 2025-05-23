using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IUriSchemes
    {
        /// <summary>
        /// "file://", the file URI scheme.
        /// <para>See also: <see cref="Uri.UriSchemeFile"/></para>
        /// </summary>
        public const string File_Constant = "file://";

        /// <inheritdoc cref="File_Constant"/>
        public string File => IUriSchemes.File_Constant;

        /// <summary>
        /// "ftp://", the file-transfer protocol (FTP) URI scheme.
        /// <para>See also: <see cref="Uri.UriSchemeFtp"/></para>
        /// </summary>
        public const string Ftp_Constant = "ftp://";

        /// <inheritdoc cref="Ftp_Constant"/>
        public string Ftp => IUriSchemes.Ftp_Constant;

        /// <summary>
        /// "http://", the hypertext transfer protocol (HTTP) URI scheme.
        /// <para>See also: <see cref="Uri.UriSchemeHttp"/></para>
        /// </summary>
        public const string Http_Constant = "http://";

        /// <inheritdoc cref="Http_Constant"/>
        public string Http => IUriSchemes.Http_Constant;

        /// <summary>
        /// "https://", the secure hypertext transfer protocol (HTTPS) URI scheme.
        /// <para>See also: <see cref="Uri.UriSchemeHttps"/></para>
        /// </summary>
        public const string Https_Constant = "https://";

        /// <inheritdoc cref="Https_Constant"/>
        public string Https => IUriSchemes.Https_Constant;
    }
}
