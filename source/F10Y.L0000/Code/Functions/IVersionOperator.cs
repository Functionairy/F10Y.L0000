using F10Y.T0002;
using System;
using System.Collections.Generic;
using System.Linq;


namespace F10Y.L0000
{
    /// <summary>
    /// .NET Standard 2.1 foundation library.
    /// </summary>
    [FunctionsMarker]
    public partial interface IVersionOperator
    {
        /// <summary>
        /// Produces a version that has all the same values as the input version,
        /// except with the provided major value.
        /// </summary>
        public Version Change_MajorValue(
            Version version,
            int majorValue)
        {
            var output = this.New_IgnoreOutOfRangeValues(
                majorValue,
                version.Minor,
                version.Build,
                version.Revision);

            return output;
        }

        /// <summary>
        /// Produces a version that has all the same values as the input version,
        /// except with the provided major value.
        /// </summary>
        public Version Change_MinorValue(
            Version version,
            int minorValue)
        {
            var output = this.New_IgnoreOutOfRangeValues(
                version.Major,
                minorValue,
                version.Build,
                version.Revision);

            return output;
        }

        /// <summary>
        /// Produces a version that has all the same values as the input version,
        /// except with the provided major value.
        /// </summary>
        public Version Change_BuildValue(
            Version version,
            int buildValue)
        {
            var output = this.New_IgnoreOutOfRangeValues(
                version.Major,
                version.Minor,
                buildValue,
                version.Revision);

            return output;
        }

        /// <summary>
        /// Produces a version that has all the same values as the input version,
        /// except with the provided major value.
        /// </summary>
        public Version Change_RevisionValue(
            Version version,
            int revisionValue)
        {
            var output = this.New_IgnoreOutOfRangeValues(
                version.Major,
                version.Minor,
                version.Build,
                revisionValue);

            return output;
        }

        /// <inheritdoc cref="Version(string)"/>
        public Version From(string version)
        {
            var output = new Version(version);
            return output;
        }

        public Version From(
            int major,
            int minor)
        {
            var output = new Version(
                major,
                minor);

            return output;
        }

        public Version From(
            int major,
            int minor,
            int build)
        {
            var output = new Version(
                major,
                minor,
                build);

            return output;
        }

        public Version From(
            int major,
            int minor,
            int build,
            int revision)
        {
            var output = new Version(
                major,
                minor,
                build,
                revision);

            return output;
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

        public Version Get_Default()
            => new Version();

        public Version Get_Lastest(IEnumerable<Version> versions)
            => versions.Max();

        /// <summary>
        /// Get the latest available version that matches the major version, and is the highest minor version greater-than or equal-to the target version.
        /// </summary>
        public Version Get_Latest_MatchingMajor(
            Version targetVersion,
            IEnumerable<Version> availableVersions)
        {
            var matchingVersions = availableVersions
                .Where(version => this.Matches_MajorVersion(
                    version,
                    targetVersion)
                )
                ;

            var anyMatchingVersions = matchingVersions.Any();
            if (!anyMatchingVersions)
            {
                throw new Exception($"No version matches target version '{targetVersion}'.");
            }
            ;

            var output = matchingVersions
                .OrderByDescending(x => x)
                .First()
                ;

            return output;
        }

        public int Get_MajorVersion(Version version)
            => version.Major;

        public int Get_MinorVersion(Version version)
            => version.Minor;

        public int Get_RevisionVersion(Version version)
            => version.Revision;

        public int Get_BuildVersion(Version version)
            => version.Build;

        public bool Has_Latest_MatchingMajorVersion(
            int targetMajorVersion,
            IEnumerable<Version> availableVersions,
            out Version availableVersion_OrDefault)
        {
            var matchingVersions = availableVersions
                .Where(version => this.Is_MajorVersion(
                    version,
                    targetMajorVersion)
                )
                ;

            var output = matchingVersions.Any();

            availableVersion_OrDefault = matchingVersions
                .OrderByDescending(x => x)
                .FirstOrDefault()
                ;

            return output;
        }

        public bool Has_Latest_MatchingMajorVersion(
            Version targetVersion,
            IEnumerable<Version> availableVersions,
            out Version availableVersion_OrDefault)
        {
            var targetMajorVersion = this.Get_MajorVersion(targetVersion);

            var output = this.Has_Latest_MatchingMajorVersion(
                targetMajorVersion,
                availableVersions,
                out availableVersion_OrDefault);

            return output;
        }

        /// <summary>
		/// Returns the value of a version component that is defined, but has the default value (which is 0, zero).
		/// </summary>
		public int Get_DefinedDefault_ComponentValue()
        {
            var output = Instances.Values.Version_DefinedDefaultComponentValue;
            return output;
        }

        /// <summary>
        /// Returns the value of undefined version component (which is -1, negative one).
        /// </summary>
        public int Get_Undefined_ComponentValue()
        {
            var output = Instances.Values.Version_UndefinedComponentValue;
            return output;
        }

        public int Get_DefinedTokenCount(Version version)
        {
            var tokens = this.Get_AllTokens(version);

            var definedTokenCount = tokens
                .Where(this.Is_DefinedVersionComponentValue)
                .Count();

            return definedTokenCount;
        }

        public Version Increment_MajorValue(
            Version version,
            int increment = IIntegers.One_Constant)
        {
            var majorValue_New = version.Major + increment;

            var output = this.Change_MajorValue(
                version,
                majorValue_New);

            return output;
        }

        public Version Increment_MinorValue(
            Version version,
            int increment = IIntegers.One_Constant)
        {
            var minorValue_New = version.Minor + increment;

            var output = this.Change_MinorValue(
                version,
                minorValue_New);

            return output;
        }

        public Version Increment_BuildValue(
            Version version,
            int increment = IIntegers.One_Constant)
        {
            var buildValue_New = version.Build + increment;

            var output = this.Change_BuildValue(
                version,
                buildValue_New);

            return output;
        }

        public Version Increment_RevisionValue(
            Version version,
            int increment = IIntegers.One_Constant)
        {
            var revisionValue_New = version.Revision + increment;

            var output = this.Change_RevisionValue(
                version,
                revisionValue_New);

            return output;
        }

        public bool Is_MajorVersion(
            Version version,
            int targetMajorVersion)
        {
            var majorVersion = this.Get_MajorVersion(version);

            var output = majorVersion == targetMajorVersion;
            return output;
        }

        public bool Is_MinorVersion(
            Version version,
            int targetMinorVersion)
        {
            var minorVersion = this.Get_MinorVersion(version);

            var output = minorVersion == targetMinorVersion;
            return output;
        }

        public bool Is_OutOfRange(int versionPropertyValue)
            => Instances.IntegerOperator.Is_LessThanZero(versionPropertyValue);

        public bool Is_WithinRange(int versionPropertyValue)
            => !this.Is_OutOfRange(versionPropertyValue);

        public bool Matches_MajorVersion(
            Version version,
            Version targetVersion)
        {
            var targetMajorVersion = this.Get_MajorVersion(targetVersion);

            var output = this.Is_MajorVersion(
                version,
                targetMajorVersion);

            return output;
        }

        public bool Matches_MinorVersion(
            Version version,
            Version targetVersion)
        {
            var targetMinorVersion = this.Get_MinorVersion(targetVersion);

            var output = this.Is_MajorVersion(
                version,
                targetMinorVersion);

            return output;
        }

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

            var defaultVersionComponentValue = Instances.Values.Version_UndefinedComponentValue;

            if (definedTokenCount > 1)
            {
                var outputVersion = new Version(version.Major, version.Minor, defaultVersionComponentValue);
                return outputVersion;
            }

            if (definedTokenCount > 0)
            {
                var outputVersion = new Version(version.Major, defaultVersionComponentValue, defaultVersionComponentValue);
                return outputVersion;
            }
            else
            {
                var outputVersion = new Version(defaultVersionComponentValue, defaultVersionComponentValue, defaultVersionComponentValue);
                return outputVersion;
            }
        }

        public Version Parse(string version)
        {
            var output = Version.Parse(version);
            return output;
        }

        public string To_String(Version version)
        {
            var output = version.ToString();
            return output;
        }

        public string To_String(
            Version version,
            int fieldCount)
        {
            var output = version.ToString(fieldCount);
            return output;
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
		/// Determines if the version property value is the value <see cref="IValues.Version_UndefinedComponentValue"/> (which is -1, negative one).
		/// </summary>
		public bool Is_DefinedVersionComponentValue(int versionComponentValue)
        {
            // Use not-equal instead of greater than to avoid relying on knowledged that the undefined value is negative one.
            var output = versionComponentValue != Instances.Values.Version_UndefinedComponentValue;
            return output;
        }
    }
}
