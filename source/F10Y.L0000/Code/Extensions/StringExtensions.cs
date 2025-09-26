using System;
using System.Collections.Generic;


namespace F10Y.L0000.Extensions
{
    public static class StringExtensions
    {
        public static IEnumerable<string> Append_BlankLine(this IEnumerable<string> strings)
        {
            var output = Instances.EnumerableOperator.Append(
                strings,
                Instances.Strings.Empty);

            return output;
        }

        public static string Join(this IEnumerable<string> strings,
            char separator)
        {
            var output = Instances.StringOperator.Join(
                separator,
                strings);

            return output;
        }

        public static string Join(this IEnumerable<string> strings,
            string separator)
        {
            var output = Instances.StringOperator.Join(
                separator,
                strings);

            return output;
        }

        public static string Join(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Join(
                Instances.Strings.Empty,
                strings);

            return output;
        }

        public static string Join_ToString(this IEnumerable<string> strings)
            => Instances.StringOperator.Join_ToString(strings);

        public static string Join_ToString(this string[] strings)
            => Instances.StringOperator.Join_ToString(strings);

        public static IEnumerable<string> Order_Alphabetically(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Order_Alphabetically(strings);
            return output;
        }

        public static IEnumerable<T> Order_AlphabeticallyBy<T>(this IEnumerable<T> values,
            Func<T, string> selector)
        {
            var output = Instances.StringOperator.Order_AlphabeticallyBy(
                values,
                selector);

            return output;
        }

        public static string Prefix_With(this string @string,
            char prefix)
            => Instances.StringOperator.Prefix_With(
                prefix,
                @string);

        public static string Wrap(this string @string,
            string prefix,
            string suffix)
        {
            return Instances.StringOperator.Wrap(
                @string,
                prefix,
                suffix);
        }

        /// <inheritdoc cref="IStringOperator.Trim(string)"/>
        public static IEnumerable<string> Trim(this IEnumerable<string> strings)
        {
            var output = Instances.StringOperator.Trim(strings);
            return output;
        }

        public static string Wrap(this string @string,
            char prefix,
            char suffix)
        {
            return Instances.StringOperator.Wrap(
                @string,
                prefix,
                suffix);
        }
    }
}
