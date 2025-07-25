using System;

using F10Y.T0003;


namespace F10Y.L0000
{
    [ValuesMarker]
    public partial interface IVolumeSeparators
    {
        /// <inheritdoc cref="Windows"/>
        public char VolumeSeparator => this.Windows;

        /// <inheritdoc cref="ICharacters.Colon"/>
        public char Windows => Instances.Characters.Colon;
    }
}
