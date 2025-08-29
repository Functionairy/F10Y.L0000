using System;
using System.Linq;


namespace F10Y.L0000.Implementations
{
    public partial interface IStringOperator
    {
        public bool Contains_ViaForeach(
            string @string,
            char character)
        {
            foreach (var character_Current in @string)
            {
                var isEqual = Instances.CharacterOperator.Are_Equal(
                    character_Current,
                    character);

                if (isEqual)
                {
                    return true;
                }
            }

            return false;
        }

        public bool Contains_ViaStringContains(
            string @string,
            char character)
        {
            var output = @string.Contains(character);
            return output;
        }

        public int Get_CountOf_ViaLinq(
            char character,
            string @string)
        {
            var output = @string
                .Where(c => c == character)
                .Count();

            return output;
        }

        public int Get_CountOf_ViaForLoop(
            char character,
            string @string)
        {
            var count = 0;

            for (int iCharacter = 0; iCharacter < @string.Length; iCharacter++)
            {
                var currentCharacter = @string[iCharacter];

                if (currentCharacter == character)
                {
                    count++;
                }
            }

            return count;
        }

        public string Get_Substring_Upto_Inclusive(
            int endIndex_Inclusive,
            string @string)
        {
            var endIndex_Exclusive = Instances.IndexOperator.Get_ExclusiveIndex(endIndex_Inclusive);

            var output = Instances.StringOperator.Get_Substring_Upto_Exclusive(
                endIndex_Exclusive,
                @string);

            return output;
        }

        public string Get_Substring_Upto_Inclusive_Simple(
            int endIndex_Inclusive,
            string @string)
        {
            var output = @string[..(endIndex_Inclusive + 1)];
            return output;
        }
    }
}
