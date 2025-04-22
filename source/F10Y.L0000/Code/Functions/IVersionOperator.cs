using System;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IVersionOperator
    {
        public bool Is_OutOfRange(int versionPropertyValue)
            => Instances.IntegerOperator.Is_LessThanZero(versionPropertyValue);

        public bool Is_WithinRange(int versionPropertyValue)
            => !this.Is_OutOfRange(versionPropertyValue);

        /// <summary>
        /// Creates a new version instance after testing the build and revision values for whether they are out of range,
        /// and then choosing a constructor that only uses valid values.
        /// </summary>
        /// <remarks>
        /// Altering a version by changing just a single value is painful since you have to choose a specific construtor to avoid the exception:
        /// <para>System.ArgumentOutOfRangeException: 'revision ('-1') must be a non-negative value. (Parameter 'revision') Actual value was -1.'</para>
        /// </remarks>
        public Version New_IgnoreOutOfRangeValues(
            int major,
            int minor,
            int build,
            int revision)
        {
            var build_IsWithinRange = this.Is_WithinRange(build);
            var revision_IsWithinRange = this.Is_WithinRange(revision);

            if (build_IsWithinRange)
            {
                if (revision_IsWithinRange)
                {
                    return new Version(
                        major,
                        minor,
                        build,
                        revision);
                }
                else
                {
                    return new Version(
                        major,
                        minor,
                        build);
                }
            }
            else
            {
                // Assumes that if build is not set, revision cannot be set.
                // This is a good assumption, since the available version constructors require a build to be set if you want to set a revision.
                return new Version(
                    major,
                    minor);
            }
        }

        /// <summary>
		/// <inheritdoc cref="To_String_Major_Minor_Build_FewerTokensOk(Version)" path="/summary"/>
		/// </summary>
		/// <remarks>
        /// Chooses <see cref="To_String_Major_Minor_Build_FewerTokensOk(Version)"/> as the default.
        /// </remarks>
        public string To_String_Major_Minor_Build(Version version)
        {
            var output = this.To_String_Major_Minor_Build_FewerTokensOk(version);
            return output;
        }

        /// <summary>
		/// Will return X.Y.Z, and will not throw if the version defines fewer tokens.
		/// </summary>
		public string To_String_Major_Minor_Build_FewerTokensOk(Version version)
        {
            var normalizedVersion = this.NormalizeTo_Major_Minor_Build(version);

            var output = this.To_String_Major_Minor_Build_ThrowIfFewerTokens(normalizedVersion);
            return output;
        }

        public Version NormalizeTo_Major_Minor_Build(Version version)
        {
            var definedTokenCount = this.Get_DefinedTokenCount(version);
            if (definedTokenCount > 3)
            {
                // Normalize to three.
                var outputVersion = new Version(version.Major, version.Minor, version.Build);
                return outputVersion;
            }

            // If not 4 tokens, but greater than 2, then it is 3.
            if (definedTokenCount > 2)
            {
                return version;
            }

            var defaultVersionPropertyValue = Instances.Values.Version_UndefinedPropertyValue;

            if (definedTokenCount > 1)
            {
                var outputVersion = new Version(version.Major, version.Minor, defaultVersionPropertyValue);
                return outputVersion;
            }

            if (definedTokenCount > 0)
            {
                var outputVersion = new Version(version.Major, defaultVersionPropertyValue, defaultVersionPropertyValue);
                return outputVersion;
            }
            else
            {
                var outputVersion = new Version(defaultVersionPropertyValue, defaultVersionPropertyValue, defaultVersionPropertyValue);
                return outputVersion;
            }
        }

        public int[] Get_AllTokens(Version version)
        {
            var tokens = new[]
            {
                version.Major,
                version.Minor,
                version.Build,
                version.Revision,
            };

            return tokens;
        }

        public int Get_DefinedTokenCount(Version version)
        {
            var undefinedVersionValue = this.Get_UndefinedVersionPropertyValue();

            var tokens = this.Get_AllTokens(version);

            var definedTokenCount = tokens
                .Where(this.Is_DefinedVersionPropertyValue)
                .Count();

            return definedTokenCount;
        }

        /// <summary>
        /// Returns the value of undefined version properties (which is -1, negative one).
        /// </summary>
        public int Get_UndefinedVersionPropertyValue()
        {
            var output = Instances.Values.Version_UndefinedPropertyValue;
            return output;
        }

        /// <summary>
		/// Will throw if the major, minor, and build properties of version are not set.
		/// </summary>
		public string To_String_Major_Minor_Build_ThrowIfFewerTokens(Version version)
        {
            // This ToString() implementation throws if there are too few tokens.
            var output = version.ToString(3);
            return output;
        }

        /// <summary>
		/// Determines if the version property value is the value returned by <see cref="Get_UndefinedVersionPropertyValue"/> (which is -1, negative one).
		/// </summary>
		public bool Is_DefinedVersionPropertyValue(int versionPropertyValue)
        {
            // Use not-equal instead of greater than to avoid relying on knowledged that the undefined value is negative one.
            var output = versionPropertyValue != Instances.Values.Version_UndefinedPropertyValue;
            return output;
        }
    }
}
