using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IHashSetOperator
    {
        /// <summary>
        /// Chooses <see cref="Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/> as the default behavior (which it is for <see cref="HashSet{T}"/>).
        /// Idempotent.
        /// </summary>
        public HashSet<T> Add_Range<T>(HashSet<T> hashSet, IEnumerable<T> items)
            => this.Add_Range_KeepLast(hashSet, items);

        /// <summary>
        /// If the hash set already contains the item, replace it with any later items.
        /// (This is the default behavior for <see cref="HashSet{T}"/>.)
        /// </summary>
        public HashSet<T> Add_Range_KeepLast<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                hashSet.Add(item);
            }

            return hashSet;
        }

        /// <summary>
        /// If the hash set already contains the item, do not replace it with any later items.
        /// </summary>
        public HashSet<T> Add_Range_KeepFirst<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var containsItem = hashSet.Contains(item);

                // Only add the item if the hash set does not already have the item.
                if (!containsItem)
                {
                    hashSet.Add(item);
                }
            }

            return hashSet;
        }

        public void Add_Range_ThrowIfDuplicate<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var alreadyPresent = hashSet.Contains(item);
                if (alreadyPresent)
                {
                    throw this.Get_ValueAlreadyExistsException(item);
                }
            }
        }

        public bool Contains<T>(
            HashSet<T> hashSet,
            T item)
        {
            var output = hashSet.Contains(item);
            return output;
        }

        /// <summary>
        /// <para>Chooses <see cref="From_KeepLast{T}(IEnumerable{T})"/> as the default.</para>
        /// <inheritdoc cref="From_KeepLast{T}(IEnumerable{T})" path="/summary"/>
        /// </summary>
        public HashSet<T> From<T>(IEnumerable<T> values)
            => this.From_KeepLast(values);

        /// <inheritdoc cref="Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/>
        public HashSet<T> From_KeepLast<T>(IEnumerable<T> values)
            // Leverage the default behavior of the hashset (which is keep last).
            => new HashSet<T>(values);

        public Exception Get_ValueAlreadyExistsException<T>(T value)
        {
            var output = new Exception($"Value already exists. Attempted to add duplicate value: {value}");
            return output;
        }

        public bool Has_Any<T>(HashSet<T> hash)
            => hash.Count > 0;

        public HashSet<T> New<T>()
            => new HashSet<T>();

        public HashSet<T> New_WithEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
            => new HashSet<T>(equalityComparer);

        public bool Remove<T>(
            HashSet<T> hash,
            T item)
            => hash.Remove(item);

        public void Remove_Idempotent<T>(
            HashSet<T> hash,
            T item)
            // The hashset's remove method is idempotent (returns false if the element was not present).
            => hash.Remove(item);

        public void Remove_Range<T>(
            HashSet<T> hash,
            IEnumerable<T> itemsToRemove)
        {
            foreach (var value in itemsToRemove)
            {
                this.Remove(hash, value);
            }
        }

        public void Remove_Range_Idempotent<T>(
            HashSet<T> hash,
            IEnumerable<T> itemsToRemove)
            // The hashset's remove method is idempotent (returns false if the element was not present).
            => this.Remove_Range(hash, itemsToRemove);

        public T[] To_Arary<T>(HashSet<T> hash)
            => hash.ToArray();
    }
}
