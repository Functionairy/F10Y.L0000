using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface ICharacterSets
    {
#pragma warning disable IDE1006 // Naming Styles

        private static ICharacters _Characters => L0000.Characters.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <summary>
        /// <list type="bullet">
        /// <item><inheritdoc cref="ICharacters.DollarSign" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ICharacters.EuroSign" path="descendant::value"/></item>
        /// <item><inheritdoc cref="ICharacters.PoundSign" path="descendant::value"/></item>
        /// </list>
        /// </summary>
        char[] Currencies => new char[]
        {
            _Characters.DollarSign,
            _Characters.EuroSign,
            _Characters.PoundSign
        };

        /// <summary>
        /// Includes 0-9, period, and minus (dash).
        /// </summary>
        char[] Numerics => new char[]
        {
            _Characters.Zero,
            _Characters.One,
            _Characters.Two,
            _Characters.Three,
            _Characters.Four,
            _Characters.Five,
            _Characters.Six,
            _Characters.Seven,
            _Characters.Eight,
            _Characters.Nine,
            _Characters.Period,
            _Characters.Dash
        };
    }
}
