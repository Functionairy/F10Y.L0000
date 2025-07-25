using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

using F10Y.T0002;
using F10Y.T0011;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IStringOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Implementations.IStringOperator _Implementations => Implementations.StringOperator.Instance;

        [Ignore]
        public Unchecked.IStringOperator _Unchecked => Unchecked.StringOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// Uses the provided <paramref name="caseStandardization_Function"/> to standardized case before comparing.
        /// </summary>
        public bool Are_Equal_CaseInsensitive(
            string a,
            string b,
            Func<string, string> caseStandardization_Function)
        {
            var a_Invariant = caseStandardization_Function(a);
            var b_Invariant = caseStandardization_Function(b);

            var output = this.Are_Equal_CaseSensitive(a_Invariant, b_Invariant);
            return output;
        }

        /// <summary>
        /// Uses <see cref="To_Lower_Invariant(string)"/> as the case standardization function.
        /// </summary>
        public bool Are_Equal_CaseInsensitive(
            string a,
            string b)
            => this.Are_Equal_CaseInsensitive(
                a,
                b,
                this.To_Lower_Invariant);


        public bool Are_Equal_CaseSensitive(
            string a,
            string b)
        {
            var output = a == b;
            return output;
        }

        /// <summary>
        /// A quality-of-life over for <see cref="Are_Equal_CaseSensitive(string, string)"/>.
        /// </summary>
        public bool Are_Equal_Exact(
            string a,
            string b)
            => this.Are_Equal_CaseSensitive(
                a,
                b);

        /// <summary>
        /// Chooses <see cref="Are_Equal_CaseSensitive(string, string)"/> as the default.
        /// </summary>
        public bool Are_Equal(
            string a,
            string b)
            => this.Are_Equal_CaseSensitive(
                a,
                b);

        /// <summary>
        /// Chooses <see cref="Are_Equal_CaseSensitive(string, string)"/> as the default.
        /// </summary>
        public bool Are_Equal_Not(
            string a,
            string b)
            => !this.Are_Equal(
                a,
                b);

        public bool Are_Equal(
            string a,
            string b,
            StringComparison stringComparison)
            => a.Equals(b, stringComparison);

        public int Compare(
            string a,
            string b)
        {
            var output = a.CompareTo(b);
            return output;
        }

        public string Concatenate(params string[] strings)
            => String.Concat(strings);

        public string Concatenate(IEnumerable<string> strings)
            => String.Concat(strings);

        public bool Contains(
            string @string,
            char character)
            => _Implementations.Contains_ViaStringContains(
                @string,
                character);

        public bool Contains(
            string @string,
            params char[] characters)
        {
            var hash = Instances.HashSetOperator.From(characters);

            foreach (var character in @string)
            {
                hash.Remove(character);

                var any = Instances.HashSetOperator.Has_Any(hash);
                if(!any)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains(
            string @string,
            string subString,
            StringComparison stringComparison)
        {
            var output = @string.Contains(
                subString,
                stringComparison);

            return output;
        }

        public bool Contains_ConsiderCase(
            string @string,
            string subString)
        {
            var output = @string.Contains(subString);
            return output;
        }

        public bool Contains_IgnoreCase(
            string @string,
            string subString)
        {
            var output = this.Contains(
                @string,
                subString,
                StringComparison.InvariantCultureIgnoreCase);

            return output;
        }

        /// <summary>
        /// Ensure the first and last characters of a string are a <inheritdoc cref="ICharacters.QuotationMark" path="descendant::name"/> (<inheritdoc cref="ICharacters.QuotationMark" path="descendant::value"/>)
        /// by adding characters if necessary.
        /// </summary>
        public string Ensure_Enquoted(string @string)
        {
            var firstChar = this.Get_Character_First(@string);
            var lastChar = this.Get_Character_Last(@string);

            var firstChar_IsQuotationMark = firstChar == Instances.Characters.QuotationMark;
            var lastChar_IsQuotationMark = lastChar == Instances.Characters.QuotationMark;

            var firstQuotationMarkToken = firstChar_IsQuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var lastQuotationMarkToken = lastChar_IsQuotationMark
                ? Instances.Strings.Empty
                : Instances.Strings.Quote
                ;

            var output = $"{firstQuotationMarkToken}{@string}{lastQuotationMarkToken}";
            return output;
        }

        public string Format_WithTemplate(
            string template,
            params object[] objects)
        {
            var output = String.Format(
                template,
                objects);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Format_WithTemplate(string, object[])"/> as the default.
        /// </summary>
        public string Format(
            string template,
            params object[] objects)
            => this.Format_WithTemplate(
                template,
                objects);

        public Func<string, bool> Get_Equals_Predicate(
            string b,
            StringComparison comparison)
            => a => this.Are_Equal(
                a,
                b,
                comparison);

        public string Except_First(string @string)
        {
            var output = this.Get_Substring_FromExclusive(
                Instances.Indices.Zero,
                @string);

            return output;
        }

        public string Except_Last(string @string)
        {
            var length = this.Get_Length(@string);

            var lastIndex = Instances.IndexOperator.Get_LastIndex_FromLength_ZeroBased(length);

            var output = this.Get_Substring_UptoExclusive(
                lastIndex,
                @string);

            return output;
        }

        public char Get_Character_First(string @string)
        {
            var output = this.Get_Character(
                @string,
                Instances.Indices.Zero);

            return output;
        }

        public char Get_Character_Last(string @string)
        {
            var lastIndex = this.Get_IndexOf_Last(@string);

            var output = this.Get_Character(
                @string,
                lastIndex);

            return output;
        }

        /// <summary>
        /// Returns the character at the provided index.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="Unchecked.IStringOperator.Get_Character_Unchecked(string, int)"/>.
        /// </remarks>
        public char Get_Character(
            string @string,
            int index)
        {
            var output = _Unchecked.Get_Character_Unchecked(
                @string,
                index);

            return output;
        }

        /// <summary>
        /// The default <see cref="String.GetHashCode()"/> is non-deterministic.
        /// This method provides a deterministic implementation.
        /// </summary>
        /// <remarks>
        /// Source: https://andrewlock.net/why-is-string-gethashcode-different-each-time-i-run-my-program-in-net-core/#a-deterministic-gethashcode-implementation
        /// </remarks>
        public int Get_HashCode_Deterministic(string @string)
        {
            unchecked
            {
                int hash1 = (5381 << 16) + 5381;
                int hash2 = hash1;

                for (int i = 0; i < @string.Length; i += 2)
                {
                    hash1 = ((hash1 << 5) + hash1) ^ @string[i];

                    if (i == @string.Length - 1)
                        break;

                    hash2 = ((hash2 << 5) + hash2) ^ @string[i + 1];
                }

                return hash1 + (hash2 * 1566083941);
            }
        }

        /// <summary>
        /// Gets the index of the last character in the string.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="Unchecked.IStringOperator.Get_IndexOf_Last_Unchecked(string)"/>.
        /// </remarks>
        public int Get_IndexOf_Last(string @string)
        {
            var lastIndex = _Unchecked.Get_IndexOf_Last_Unchecked(@string);
            return lastIndex;
        }

        /// <summary>
        /// Gets the length of the string.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="Unchecked.IStringOperator.Get_Length_Unchecked(string)"/>.
        /// </remarks>
        public int Get_Length(string @string)
        {
            var output = _Unchecked.Get_Length_Unchecked(@string);
            return output;
        }

        /// <summary>
        /// Gets the new line string for the currently executing environment.
        /// </summary>
        public string Get_NewLine_ForEnvironment()
        {
            var output = Instances.EnvironmentOperator.Get_NewLine();
            return output;
        }

        public string Get_Substring_FromExclusive_ToExclusive(
            int startIndex,
            int endIndex,
            string @string)
        {
            var length = Instances.IndexOperator.Get_Count_FromExclusive_ToExclusive(
                startIndex,
                endIndex);

            var output = this.Get_Substring_FromExclusive(
                startIndex,
                length,
                @string);

            return output;
        }

        public string Get_Substring_FromExclusive(
            int startIndex,
            int length,
            string @string)
        {
            var actualStartIndex = startIndex + 1;

            var output = this.Get_Substring_FromInclusive(
                actualStartIndex,
                length,
                @string);

            return output;
        }

        /// <summary>
        /// Gets a substring, starting at an index and going to the end.
        /// </summary>
        public string Get_Substring_FromExclusive(
            int startIndex_Exclusive,
            string @string)
        {
            var output = @string[(startIndex_Exclusive + 1)..];
            return output;
        }

        /// <summary>
        /// Gets a substring, staring at (and including) the given start index, of the given length.
        /// </summary>
        public string Get_Substring_FromInclusive(
            int startIndex,
            int length,
            string @string)
        {
            var output = @string.Substring(startIndex, length);
            return output;
        }

        public string Get_Substring_FromInclusive_ToInclusive(
            int startIndex,
            int endIndex,
            string @string)
        {
            var length = Instances.IndexOperator.Get_Count_FromInclusive_ToInclusive(
                startIndex,
                endIndex);

            var output = this.Get_Substring_FromInclusive(
                startIndex,
                length,
                @string);

            return output;
        }

        public string Get_Substring_UptoInclusive(
            int endIndex_Inclusive,
            string @string)
        {
            var endIndex_Exclusive = Instances.IndexOperator.Get_ExclusiveIndex(endIndex_Inclusive);

            var output = this.Get_Substring_UptoExclusive(
                endIndex_Exclusive,
                @string);

            return output;
        }

        public string Get_Substring_UptoExclusive(
            int endIndex_Exclusive,
            string @string)
        {
            var output = @string[..endIndex_Exclusive];
            return output;
        }

        public bool Has_Character(
            string @string,
            int index,
            out char character)
        {
            var is_Null = this.Is_Null(@string);
            if (is_Null)
            {
                character = Instances.Values.NotFound_Character;
                return false;
            }
            // Else.

            var length_Required = Instances.IndexOperator.Get_Length_FromIndex(index);

            var is_LongEnough = Instances.StringOperator.Length_IsAtLeast(
                @string,
                length_Required);

            if (!is_LongEnough)
            {
                character = Instances.Values.NotFound_Character;
                return false;
            }
            // Else.

            character = _Unchecked.Get_Character_Unchecked(
                @string,
                index);

            return true;
        }

        public bool Has_Character_First(
            string @string,
            out char character_First)
        {
            var output = this.Has_Character(
                @string,
                Instances.Indices.Zero,
                out character_First);

            return output;
        }

        /// <summary>
        /// Does a string have a last character?
        /// (If the string is null or empty, it does not.)
        /// If so, output the last character.
        /// </summary>
        public bool Has_Character_Last(
            string @string,
            out char character_Last)
        {
            var is_NullOrEmpty = this.Is_NullOrEmpty(@string);
            if (is_NullOrEmpty)
            {
                character_Last = Instances.Values.NotFound_Character;

                return false;
            }
            // Else.

            // String is not null or empty, so there is at least one character.
            character_Last = _Unchecked.Get_Character_Last_Unchecked(@string);

            return true;
        }

        public bool Has_IndexOf_First(
            string @string,
            out int index_OrNotFound,
            char character)
        {
            index_OrNotFound = @string.IndexOf(character);

            var output = this.Was_Found(index_OrNotFound);
            return output;
        }

        public bool Has_IndexOf_Last(
            string @string,
            out int index_OrNotFound,
            char character)
        {
            index_OrNotFound = @string.LastIndexOf(character);

            var output = this.Was_Found(index_OrNotFound);
            return output;
        }

        public bool Has_IndexOfAny_First(
            string @string,
            out int indexOfAny_OrNotFound,
            params char[] characters)
        {
            indexOfAny_OrNotFound = @string.IndexOfAny(characters);

            var output = this.Was_Found(indexOfAny_OrNotFound);
            return output;
        }

        public bool Has_IndexOfAny_Last(
            string @string,
            out int indexOfAny_OrNotFound,
            params char[] characters)
        {
            indexOfAny_OrNotFound = @string.LastIndexOfAny(characters);

            var output = this.Was_Found(indexOfAny_OrNotFound);
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Has_IndexOfAny_First(string, out int, char[])"/> as the default.
        /// </summary>
        public bool Has_IndexOfAny(
            string @string,
            out int indexOfAny_OrNotFound,
            params char[] characters)
            => this.Has_IndexOfAny_First(
                @string,
                out indexOfAny_OrNotFound,
                characters);

        /// <summary>
        /// Determines if the input is specifically the <see cref="IStrings.Empty"/> string.
        /// </summary>
        public bool Is_Empty(string value)
        {
            var isEmpty = value == Instances.Strings.Empty;
            return isEmpty;
        }

        public bool Is_NotNull(string @string)
            => Instances.NullOperator.Is_NotNull(@string);

        public bool Is_Null(string @string)
            => Instances.NullOperator.Is_Null(@string);

        public bool Is_NullOrEmpty(string @string)
            => String.IsNullOrEmpty(@string);

        public string Join(
            char separator,
            IEnumerable<string> strings)
        {
            var output = String.Join(separator, strings);
            return output;
        }

        public string Join(
            string separator,
            IEnumerable<string> strings)
        {
            var output = String.Join(separator, strings);
            return output;
        }

        public string Join_ToString(IEnumerable<string> strings)
        {
            var output = String.Concat(strings);
            return output;
        }

        public string Join_ToString(params string[] strings)
        {
            var output = String.Concat(strings);
            return output;
        }

        public bool Length_IsAtLeast(
            string @string,
            int length)
        {
            var length_OfString = this.Get_Length(@string);

            var output = Instances.IntegerOperator.GreaterThan_OrEqualTo(
                length_OfString,
                length);

            return output;
        }

        public bool Length_IsAtLeast_One(string @string)
        {
            var output = this.Length_IsAtLeast(
                @string,
                Instances.Integers.One);

            return output;
        }

        public bool Length_IsGreaterThan(
            string @string,
            int length)
        {
            var length_OfString = this.Get_Length(@string);

            var output = Instances.IntegerOperator.GreaterThan(
                length_OfString,
                length);

            return output;
        }

        public bool Length_IsLessThan(
            string @string,
            int length)
        {
            var length_OfString = this.Get_Length(@string);

            var output = length_OfString < length;
            return output;
        }

        public IEnumerable<string> Order_Alphabetically(IEnumerable<string> strings)
        {
            var output = strings
                .OrderBy(x => x)
                ;

            return output;
        }

        public IEnumerable<T> Order_AlphabeticallyBy<T>(
            IEnumerable<T> values,
            Func<T, string> selector)
        {
            var output = values
                .OrderBy(selector)
                ;

            return output;
        }

        public string Serialize_UsingMemoryStream(
            Action<MemoryStream> memoryStreamAction)
        {
            using var memoryStream = Instances.MemoryStreamOperator.Get_New();

            memoryStreamAction(memoryStream);

            Instances.StreamOperator.Seek_Beginnning(memoryStream);

            using var reader = Instances.StreamReaderOperator.Get_New(memoryStream);

            var output = reader.ReadToEnd();
            return output;
        }

        /// <summary>
        /// Returns true if the first character of the given string is the given character, false otherwise.
        /// </summary>
        /// <remarks>
        /// Throws no exceptions.
        /// </remarks>
        public bool Starts_With_Noexceptive(
            string @string,
            char character)
        {
            var is_NullOrEmpty = this.Is_NullOrEmpty(@string);
            if (is_NullOrEmpty)
            {
                return false;
            }

            // Ok to use exceptive method at this point; string is long enough.
            var output = this.Starts_With_Exceptive(
                @string,
                character);

            return output;
        }

        public string[] Split(
            char[] separators,
            string @string,
            StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separators, options);
            return output;
        }

        public string[] Split(
            char separator,
            string @string,
            StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separator, options);
            return output;
        }

        public string[] Split(
            string separator,
            string @string,
            StringSplitOptions options = StringSplitOptions.None)
        {
            var output = @string.Split(separator, options);
            return output;
        }

        public string[] Split_Lines(
            string text,
            string lineSeparator)
        {
            var output = this.Split(
                lineSeparator,
                text);

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Uses <see cref="IStrings.NewLine_ForEnvironment"/> as the line separator
        /// </remarks>
        public string[] Split_Lines(string text)
        {
            var lineSeparator = Instances.Strings.NewLine_ForEnvironment;

            var output = this.Split_Lines(
                text,
                lineSeparator);

            return output;
        }

        public bool Starts_With_Exceptive(
            string @string,
            char character)
        {
            var firstCharacter = this.Get_Character_First(@string);

            var output = Instances.CharacterOperator.Are_Equal(
                firstCharacter,
                character);

            return output;
        }

        /// <summary>
        /// Chooses <see cref="Starts_With_Exceptive(string, char)"/> as the default.
        /// </summary>
        public bool Starts_With(
            string @string,
            char character)
        {
            var output = this.Starts_With_Exceptive(
                @string,
                character);

            return output;
        }

        public bool Starts_With(
            string @string,
            string start)
        {
            var string_IsNull = Instances.NullOperator.Is_Null(@string);
            var start_IsNull = Instances.NullOperator.Is_Null(start);

            if (string_IsNull)
            {
                // If the string is null, then it all depends on the start. If the start is null, then true, else false.
                return start_IsNull;
            }
            // Now we know the string is not null.

            if (start_IsNull)
            {
                // If the string is not null, but the start is null, then false.
                return false;
            }
            // Now we know the start is not null.

            var string_Length = _Unchecked.Get_Length_Unchecked(@string);
            var start_Length = _Unchecked.Get_Length_Unchecked(start);

            var string_IsTooShort = string_Length < start_Length;
            if (string_IsTooShort)
            {
                return false;
            }
            // Now we know it is at least of the right length.

            // Use a span to avoid creating an extra string on the heap.
            var output = MemoryExtensions.Equals(
                @string.AsSpan(0, start_Length),
                start,
                StringComparison.Ordinal);

            return output;
        }

        /// <summary>
        /// Returns the lowered version of a string.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="String.ToLowerInvariant"/>.
        /// </remarks>
        public string To_Lower_Invariant(string @string)
            => @string.ToLowerInvariant();

        /// <summary>
        /// Chooses <see cref="To_Lower_Invariant(string)"/> as the default.
        /// </summary>
        public string To_Lower(string @string)
            => this.To_Lower_Invariant(@string);

        public string To_Lower(
            string @string,
            CultureInfo cultureInfo)
        {
            var output = @string.ToLower(cultureInfo);
            return output;
        }

        /// <summary>
        /// Returns the uppered version of a string.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="String.ToUpperInvariant"/>.
        /// </remarks>
        public string To_Upper_Invariant(string @string)
            => @string.ToUpperInvariant();

        /// <summary>
        /// Chooses <see cref="To_Upper_Invariant(string)"/> as the default.
        /// </summary>
        public string To_Upper(string @string)
            => this.To_Upper_Invariant(@string);

        public string To_Upper(
            string @string,
            CultureInfo cultureInfo)
        {
            var output = @string.ToUpper(cultureInfo);
            return output;
        }

        public string Prefix_With(
            char prefix,
            string @string)
        {
            var output = prefix + @string;
            return output;
        }

        public string Prefix_With(
            string prefix,
            string @string)
        {
            var output = prefix + @string;
            return output;
        }

        public bool Was_Found(int index)
        {
            return Instances.IndexOperator.Was_Found(index);
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Prefix_With(char, string)"/>.
        /// </summary>
        public string With_Prefix(
            char prefix,
            string @string)
        {
            var output = this.Prefix_With(
                prefix,
                @string);

            return output;
        }

        /// <summary>
        /// Quality-of-life overload for <see cref="Prefix_With(string, string)"/>.
        /// </summary>
        public string With_Prefix(
            string prefix,
            string @string)
        {
            var output = this.Prefix_With(
                prefix,
                @string);

            return output;
        }

        public string Without_Start(
            string @string,
            string start)
        {
            var start_Length = _Unchecked.Get_Length_Unchecked(start);

            var start_Index = Instances.IndexOperator.Get_Index_FromLength_ZeroBased(start_Length);

            var output = this.Get_Substring_FromExclusive(
                start_Index,
                @string);

            return output;
        }
    }
}
