using System;


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
    }
}
