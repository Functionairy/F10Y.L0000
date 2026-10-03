using System;


namespace F10Y.L0000
{
    public class CharacterSets : ICharacterSets
    {
        #region Infrastructure

        public static ICharacterSets Instance { get; } = new CharacterSets();


        private CharacterSets()
        {
        }

        #endregion
    }
}
