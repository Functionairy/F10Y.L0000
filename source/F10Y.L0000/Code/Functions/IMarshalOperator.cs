using System;
using System.Runtime.InteropServices;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IMarshalOperator
    {
        /// <summary>
        /// <inheritdoc cref="Release_COMObject_WithNullCheck(object)" path="/summary"/>
        /// <para>Chooses <see cref="Release_COMObject_WithNullCheck(object)"/> as the default.</para>
        /// </summary>
        int Release_COMObject(object @object)
            => this.Release_COMObject_WithNullCheck(@object);

        /// <inheritdoc cref="Release_COMObject_WithoutNullCheck(object)"/>
        int Release_COMObject_WithNullCheck(object @object)
        {
            var is_Null = Instances.NullOperator.Is_Null(@object);

            var output = is_Null
                ? Instances.Integers.NegativeOne
                : this.Release_COMObject_WithoutNullCheck(@object)
                ;

            return output;
        }

        /// <summary>
        /// Decrements the reference count of a COM object.
        /// </summary>
        int Release_COMObject_WithoutNullCheck(object @object)
        {
            var output = Marshal.ReleaseComObject(@object);
            return output;
        }

        /// <summary>
        /// <inheritdoc cref="FinalRelease_COMObject_WithNullCheck(object)" path="/summary"/>
        /// <para>Chooses <see cref="FinalRelease_COMObject_WithNullCheck(object)"/> as the default.</para>
        /// </summary>
        int FinalRelease_COMObject(object @object)
            => this.FinalRelease_COMObject_WithNullCheck(@object);

        /// <inheritdoc cref="FinalRelease_COMObject_WithoutNullCheck(object)"/>
        int FinalRelease_COMObject_WithNullCheck(object @object)
        {
            var is_Null = Instances.NullOperator.Is_Null(@object);

            var output = is_Null
                ? Instances.Integers.NegativeOne
                : this.FinalRelease_COMObject_WithoutNullCheck(@object)
                ;

            return output;
        }

        /// <summary>
        /// Sets the reference count of a COM object to zero.
        /// </summary>
        int FinalRelease_COMObject_WithoutNullCheck(object @object)
        {
            var output = Marshal.FinalReleaseComObject(@object);
            return output;
        }
    }
}
