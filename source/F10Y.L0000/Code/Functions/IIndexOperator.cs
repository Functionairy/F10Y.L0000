using System;

using F10Y.T0002;
using F10Y.T0011;

using Glossary = F10Y.Y0000.Glossary;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IIndexOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Checked.IIndexOperator _Checked => Checked.IndexOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles

        /// <summary>
        /// Given a zero-based index value, get the count of elements that index represents.
        /// Exclusive in the sense that the element at the index is not included.
        /// (Basically, just return the index.)
        /// </summary>
        public int Get_Count_Exclusive(int index)
        {
            var output = index;
            return output;
        }

        /// <summary>
        /// Given a zero-based index value, get the count of elements that index represents.
        /// Inclusive in the sense that the element at the index is included.
        /// (Basically, just add one to the index.)
        /// </summary>
        public int Get_Count_Inclusive(int index)
        {
            var output = index + 1;
            return output;
        }

        /// <summary>
        /// Chooses <see cref="Get_Count_Inclusive(int)"/> as the default.
        /// </summary>
        public int Get_Count(int index)
        {
            var output = this.Get_Count_Inclusive(index);
            return output;
        }

        /// <summary>
        /// The count corresponding to an index for a zero-based array is the index plus one.
        /// </summary>
        public int Get_Count_FromIndex_ZeroBased(int index)
        {
            var output = index + 1;
            return output;
        }

        /// <summary>
        /// Uses <see cref="Get_Count_FromIndex_ZeroBased(int)"/> (assumes a zero-based index).
        /// </summary>
        public int Get_Count_FromIndex(int index)
        {
            var output = this.Get_Count_FromIndex_ZeroBased(index);
            return output;
        }

        /// <summary>
        /// Gets the count of elements starting at the start index (inclusive) and ending at the end index (inclusive).
        /// </summary>
        public int Get_Count_FromInclusive_ToInclusive(
            int startIndex,
            int endIndex)
        {
            var output = endIndex - startIndex + 1;
            return output;
        }

        /// <summary>
        /// Gets the count of elements starting at the start index (but exclusive of the start index) and ending at the end index (but exclusive of the end index).
        /// </summary>
        public int Get_Count_FromExclusive_ToExclusive(
            int startIndex,
            int endIndex)
        {
            var output = endIndex - startIndex - 1;
            return output;
        }

        /// <summary>
        /// The last index of a zero-based array the the length minus one.
        /// </summary>
        public int Get_Index_FromLength_ZeroBased(int length)
        {
            var output = length - 1;
            return output;
        }

        /// <summary>
        /// Uses <see cref="Get_Index_FromLength_ZeroBased(int)"/> (assumes a zero-based index).
        /// </summary>
        public int Get_Index_FromLength(int length)
        {
            var output = this.Get_Index_FromLength_ZeroBased(length);
            return output;
        }

        /// <summary>
        /// The last index of a zero-based array the the length minus one.
        /// </summary>
        public int Get_LastIndex_FromLength_ZeroBased(int length)
        {
            var output = this.Get_Index_FromLength_ZeroBased(length);
            return output;
        }

        /// <summary>
        /// Uses <see cref="Get_LastIndex_FromLength_ZeroBased(int)"/> (assumes a zero-based index).
        /// </summary>
        public int Get_LastIndex_FromLength(int length)
        {
            var output = this.Get_LastIndex_FromLength_ZeroBased(length);
            return output;
        }

        /// <summary>
        /// The length corresponding to an index for a zero-based array is the index plus one.
        /// </summary>
        public int Get_Length_FromIndex_ZeroBased(int index)
        {
            var output = index + 1;
            return output;
        }

        /// <summary>
        /// Uses <see cref="Get_Length_FromIndex_ZeroBased(int)"/> (assumes a zero-based index).
        /// </summary>
        public int Get_Length_FromIndex(int index)
        {
            var output = this.Get_Length_FromIndex_ZeroBased(index);
            return output;
        }

        /// <summary>
        /// Gets an <inheritdoc cref="Glossary.For_Index.Exclusive" path="/name"/> index from an <inheritdoc cref="Glossary.For_Index.Inclusive" path="/name"/> index by adding one.
        /// <para><inheritdoc cref="Glossary.For_Index.ExclusiveInclusiveRelationship" path="/definition"/></para>
        /// </summary>
        public int Get_ExclusiveIndex(int inclusiveIndex)
        {
            var output = inclusiveIndex + 1;
            return output;
        }

        /// <summary>
        /// Gets an <inheritdoc cref="Glossary.For_Index.Inclusive" path="/name"/> index from an <inheritdoc cref="Glossary.For_Index.Exclusive" path="/name"/> index by subtracting one.
        /// <para><inheritdoc cref="Glossary.For_Index.ExclusiveInclusiveRelationship" path="/definition"/></para>
        /// </summary>
        public int Get_InclusiveIndex(int exclusiveIndex)
        {
            var output = exclusiveIndex - 1;
            return output;
        }

        public bool Is_Found(int index)
        {
            var output = Instances.Indices.NotFound != index;
            return output;
        }

        /// <summary>
        /// A valid length is greater-than-or-equal-to zero.
        /// </summary>
        public bool Is_ValidLength(int length)
        {
            var output = Instances.IntegerOperator.GreaterThan_OrEqualTo_Zero(length);
            return output;
        }

        /// <summary>
        /// Note: somewhat useless, since it's usually better to say what was being searched for was not found,
        /// instead of just that the result of searching was not found.
        /// But here anyway.
        /// </summary>
        public void Verify_IsFound(int index)
        {
            var isFound = this.Is_Found(index);
            if (!isFound)
            {
                throw new Exception("Index is not found.");
            }
        }

        public void Verify_IsValidLength(int length)
        {
            var is_ValidLength = this.Is_ValidLength(length);
            if(!is_ValidLength)
            {
                throw Instances.ExceptionOperator.Get_InvalidLengthException(length);
            }
        }

        public bool Was_Found(int index)
        {
            var output = this.Is_Found(index);
            return output;
        }
    }
}
