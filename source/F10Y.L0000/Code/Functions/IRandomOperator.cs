using System;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IRandomOperator
    {
        /// <inheritdoc cref="Random()"/>
        public Random New()
        {
            var output = new Random();
            return output;
        }

        public Random New_WithSeed(int seed)
        {
            var output = new Random(seed);
            return output;
        }

        /// <summary>
        /// Get a random seeded with a seed-phrase.
        /// </summary>
        /// <remarks>
        /// Uses the hashcode of the seed phrase as the seed of the random.
        /// </remarks>
        public Random New_WithSeed(string seed_Phrase)
        {
            var hashcode = Instances.StringOperator.Get_HashCode_Deterministic(seed_Phrase);

            var output = this.New_WithSeed(hashcode);
            return output;
        }
    }
}
