using System;
using System.Collections.Generic;


namespace F10Y.L0000.Extensions
{
    public static class CharacterExtensions
    {
        public static string Concatenate(this IEnumerable<char> characters)
            => Instances.StringOperator.Concatenate(characters);
    }
}
