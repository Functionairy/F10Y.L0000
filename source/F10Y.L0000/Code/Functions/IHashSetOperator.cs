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
        HashSet<T> Add_Range<T>(HashSet<T> hashSet, IEnumerable<T> items)
            => this.Add_Range_KeepLast(hashSet, items);

        /// <summary>
        /// If the hash set already contains the item, replace it with any later items.
        /// (This is the default behavior for <see cref="HashSet{T}"/>.)
        /// </summary>
        HashSet<T> Add_Range_KeepLast<T>(HashSet<T> hashSet, IEnumerable<T> items)
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
        HashSet<T> Add_Range_KeepFirst<T>(HashSet<T> hashSet, IEnumerable<T> items)
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

        void Add_Range_ExceptionIfDuplicate<T>(HashSet<T> hashSet, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                var alreadyPresent = hashSet.Contains(item);
                if (alreadyPresent)
                {
                    throw this.Get_ValueAlreadyExistsException(item);
                }

                hashSet.Add(item);
            }
        }

        bool Contains<T>(
            HashSet<T> hashSet,
            T item)
        {
            var output = hashSet.Contains(item);
            return output;
        }

        bool Not_Contains<T>(
            HashSet<T> hashSet,
            T item)
            => !this.Contains(
                hashSet,
                item);

        /// <summary>
        /// <para>Chooses <see cref="From_KeepLast{T}(IEnumerable{T})"/> as the default.</para>
        /// <inheritdoc cref="From_KeepLast{T}(IEnumerable{T})" path="/summary"/>
        /// </summary>
        HashSet<T> From<T>(IEnumerable<T> values)
            => this.From_KeepLast(values);

        /// <inheritdoc cref="Add_Range_KeepLast{T}(HashSet{T}, IEnumerable{T})"/>
        HashSet<T> From_KeepLast<T>(IEnumerable<T> items)
            // Leverage the default behavior of the hashset (which is keep last).
            => new HashSet<T>(items);

        HashSet<T> From_KeepFirst<T>(
            IEnumerable<T> items,
            IEqualityComparer<T> equalityComparer)
        {
            var output = this.New(equalityComparer);

            this.Add_Range_KeepFirst(
                output,
                items);

            return output;
        }

        HashSet<T> From_KeepFirst<T>(IEnumerable<T> items)
            => this.From_KeepFirst(
                items,
                Instances.EqualityComparerOperator.Get_Default<T>());

        HashSet<T> From_ExceptionIfDuplicate<T>(
            IEnumerable<T> items,
            IEqualityComparer<T> equality_Comparer)
        {
            var output = this.New(equality_Comparer);

            this.Add_Range_ExceptionIfDuplicate(
                output,
                items);

            return output;
        }

        Exception Get_ValueAlreadyExistsException<T>(T value)
        {
            var output = new Exception($"Value already exists. Attempted to add duplicate value: {value}");
            return output;
        }

        bool Has_Any<T>(HashSet<T> hash)
            => hash.Count > 0;

        HashSet<T> New<T>()
            => new HashSet<T>();

        HashSet<T> New<T>(
            IEnumerable<T> items)
            => new HashSet<T>(items);

        HashSet<T> New<T>(
            params T[] items)
            => new HashSet<T>(items);

        HashSet<T> New<T>(IEqualityComparer<T> equalityComparer)
            => new HashSet<T>(equalityComparer);

        HashSet<T> New_WithEqualityComparer<T>(IEqualityComparer<T> equalityComparer)
            => new HashSet<T>(equalityComparer);

        bool Remove<T>(
            HashSet<T> hash,
            T item)
            => hash.Remove(item);

        void Remove_Idempotent<T>(
            HashSet<T> hash,
            T item)
            // The hashset's remove method is idempotent (returns false if the element was not present).
            => hash.Remove(item);

        void Remove_Range<T>(
            HashSet<T> hash,
            IEnumerable<T> itemsToRemove)
        {
            foreach (var value in itemsToRemove)
            {
                this.Remove(hash, value);
            }
        }

        void Remove_Range_Idempotent<T>(
            HashSet<T> hash,
            IEnumerable<T> itemsToRemove)
            // The hashset's remove method is idempotent (returns false if the element was not present).
            => this.Remove_Range(hash, itemsToRemove);

        T[] To_Array<T>(HashSet<T> hash)
            => hash.ToArray();
    }
}
