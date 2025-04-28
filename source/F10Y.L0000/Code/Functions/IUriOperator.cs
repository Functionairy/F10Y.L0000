using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IUriOperator
    {
        public string Escape_DataString(string value)
        {
            var output = Uri.EscapeDataString(value);
            return output;
        }

        public Uri From(string uri)
        {
            var output = new Uri(uri);
            return output;
        }

        public Uri From(
            Uri baseUri,
            string relativeUri)
        {
            var output = new Uri(
                baseUri,
                relativeUri);

            return output;
        }

        public Uri From(
            string baseUri,
            string relativeUri)
        {
            var baseUriObject = this.From(baseUri);

            var output = this.From(
                baseUriObject,
                relativeUri);

            return output;
        }

        public Uri From_Path(string path)
        {
            var output = this.From(
                Instances.UriSchemes.File,
                path);

            return output;
        }

        public Uri Make_RelativeUri(
            Uri sourceUri,
            Uri destinationUri)
        {
            var output = sourceUri.MakeRelativeUri(destinationUri);
            return output;
        }

        public string To_String(Uri uri)
        {
            var output = uri.ToString();
            return output;
        }

        public string Unescape_DataString(string uri)
        {
            var output = Uri.UnescapeDataString(uri);
            return output;
        }
    }
}
