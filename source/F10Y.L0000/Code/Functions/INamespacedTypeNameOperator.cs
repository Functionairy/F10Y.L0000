using System;

using F10Y.T0002;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface INamespacedTypeNameOperator
    {
        public string Combine(params string[] tokens)
        {
            if (tokens.Length < 1)
            {
                return Instances.Strings.Empty;
            }

            if (tokens.Length < 2)
            {
                return tokens.Get_First();
            }

            var output = Instances.StringOperator.Join(
                Instances.TokenSeparators.NamespaceNameTokenSeparator,
                tokens);

            return output;
        }

        public string Get_NamespacedTypeName(
            string namespaceName,
            string typeName)
        {
            if (Instances.StringOperator.Is_NullOrEmpty(namespaceName))
            {
                return typeName;
            }

            var namespacedTypeName = this.Combine(namespaceName, typeName);
            return namespacedTypeName;
        }

        public string Get_TokenSeparator_String()
        {
            var output = Instances.Strings.Period;
            return output;
        }

        public char Get_TokenSeparator_Character()
        {
            var output = Instances.Characters.Period;
            return output;
        }

        /// <summary>
        /// Chooses character as the default token separator type.
        /// </summary>
        public char Get_TokenSeparator()
        {
            var output = this.Get_TokenSeparator_Character();
            return output;
        }
    }
}
