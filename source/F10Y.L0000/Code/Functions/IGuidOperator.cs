using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;

using GuidDocumentation = F10Y.Y0000.Documentation.For_Guid;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IGuidOperator
    {
        /// <summary>
        /// A quality-of-life overload for <see cref="Parse(string)"/>.
        /// </summary>
        public Guid From(string guidString)
            => this.Parse(guidString);

        /// <summary>
        /// A quality-of-life overload for <see cref="Parse(IEnumerable{string})"/>.
        /// </summary>
        public IEnumerable<Guid> From(IEnumerable<string> guidStrings)
            => this.From(guidStrings);

        public Guid New()
        {
            var output = Guid.NewGuid();
            return output;
        }

        public Guid Parse(string guidString)
        {
            var output = Guid.Parse(guidString);
            return output;
        }

        public IEnumerable<Guid> Parse(IEnumerable<string> guidStrings)
            => guidStrings
                .Select(this.Parse)
                ;

        /// <summary>
        /// Returns a new Guid using the specified random (for seeded Guids, useful in testing).
        /// </summary>
        /// <remarks>
        /// Source: https://stackoverflow.com/a/13188409/10658484
        /// </remarks>
        public Guid New_From(Random random)
        {
            var guidBytes = new byte[16];

            random.NextBytes(guidBytes);

            var output = new Guid(guidBytes);
            return output;
        }

        public Guid New_Seeded(
            int seed,
            out Random random)
        {
            random = Instances.RandomOperator.New_WithSeed(seed);

            var output = this.New_From(random);
            return output;
        }

        /// <summary>
        /// Quality-of-life over for <see cref="New_Seeded(int, out Random)"/> that just ignores the out parameter random.
        /// </summary>
        public Guid New_Seeded(int seed)
            => this.New_Seeded(
                seed,
                out _);

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Format"/>
        /// </summary>
        public string To_String_B_Format(Guid guid)
        {
            var output = guid.ToString("B");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.B_Uppercase_Format"/>
        /// </summary>
        public string To_String_B_Uppercase_Format(Guid guid)
        {
            var output = this.To_String_B_Format(guid);

            var output_Uppered = Instances.StringOperator.To_Upper(output);
            return output_Uppered;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string To_String_D_Format(Guid guid)
        {
            var output = guid.ToString("D");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.D_Uppercase_Format"/>
        /// </summary>
        public string To_String_D_Uppercase_Format(Guid guid)
        {
            var output = this.To_String_D_Format(guid);

            var output_Uppered = Instances.StringOperator.To_Upper(output);
            return output_Uppered;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.N_Format"/>
        /// </summary>
        public string To_String_N_Format(Guid guid)
        {
            var output = guid.ToString("N");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.P_Format"/>
        /// </summary>
        public string To_String_P_Format(Guid guid)
        {
            var output = guid.ToString("P");
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="GuidDocumentation.X_Format"/>
        /// </summary>
        public string To_String_X_Format(Guid guid)
        {
            var output = guid.ToString("X");
            return output;
        }

        /// <summary>
        /// <para>The default is the D format.</para>
        /// <inheritdoc cref="GuidDocumentation.D_Format"/>
        /// </summary>
        public string To_String(Guid guid)
        {
            var output = guid.ToString();
            return output;
        }

        /// <inheritdoc cref="Guid.ToString(string)"/>
        public string To_String(
            Guid guid,
            string format)
        {
            var output = guid.ToString(format);
            return output;
        }

        /// <inheritdoc cref="Guid.ToString(string, IFormatProvider)"/>;
        public string To_String(
            Guid guid,
            string format,
            IFormatProvider formatProvider)
        {
            var output = guid.ToString(
                format,
                formatProvider);

            return output;
        }
    }
}
