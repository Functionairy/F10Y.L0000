using System;
using System.Collections.Generic;
using System.Linq;

using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IEnumerableOperator
    {
        public bool Any<T>(IEnumerable<T> enumerable)
            => enumerable.Any();

        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            params T[] appendices)
            => this.Append(
                enumerable,
                appendices.AsEnumerable());

        public IEnumerable<T> Append<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
            => this.Append_Many(
                enumerable,
                appendix);

        public IEnumerable<T> Append_If<T>(
            IEnumerable<T> enumerable,
            bool condition,
            IEnumerable<T> appendix)
        {
            var output = condition
                ? this.Append_Many(
                    enumerable,
                    appendix)
                : enumerable
                ;

            return output;
        }

        public IEnumerable<T> Append_If<T>(
            IEnumerable<T> enumerable,
            bool condition,
            IEnumerable<T> appendix_IfTrue,
            IEnumerable<T> appendix_IfFalse)
        {
            var output = condition
                ? this.Append_Many(
                    enumerable,
                    appendix_IfTrue)
                : this.Append_Many(
                    enumerable,
                    appendix_IfFalse)
                ;

            return output;
        }

        public IEnumerable<T> Append_If<T>(
            IEnumerable<T> enumerable,
            bool condition,
            Func<IEnumerable<T>> get_Appendix_IfTrue,
            Func<IEnumerable<T>> get_Appendix_IfFalse)
        {
            var output = condition
                ? this.Append_Many(
                    enumerable,
                    get_Appendix_IfTrue())
                : this.Append_Many(
                    enumerable,
                    get_Appendix_IfFalse())
                ;

            return output;
        }

        public IEnumerable<T> Append_If<T>(
            IEnumerable<T> enumerable,
            bool condition,
            params T[] appendix)
            => this.Append_If(
                enumerable,
                condition,
                appendix.AsEnumerable());

        public IEnumerable<T> Append_Many<T>(
            IEnumerable<T> enumerable,
            IEnumerable<T> appendix)
            => Enumerable.Concat(
                enumerable,
                appendix);

        public int Get_Count<T>(IEnumerable<T> enumerable)
            => enumerable.Count();

        public T Get_Nth<T>(
            IEnumerable<T> values,
            int n)
        {
            var output = values
                .Skip(n - 1)
                .First();

            return output;
        }

        public T Get_Second<T>(IEnumerable<T> values)
        {
            var output = this.Get_Nth(values, 2);
            return output;
        }

        public IEnumerable<T> Enumerate_Distinct<T>(IEnumerable<T> enumerable)
            => enumerable.Distinct();

        public IEnumerable<T> Empty<T>()
            => Enumerable.Empty<T>();

        /// <summary>
		/// Returns the entire sequence, except for the first element (skips the first element).
		/// </summary>
		public IEnumerable<T> Except_First<T>(IEnumerable<T> enumerable)
        {
            // Skip the last element.
            var output = this.Except_First(enumerable, 1);
            return output;
        }

        /// <summary>
		/// Quality-of-life name for <see cref="Enumerable.Skip{TSource}(IEnumerable{TSource}, int)"/>
		/// </summary>
		public IEnumerable<T> Except_First<T>(
            IEnumerable<T> enumerable,
            int numberOfElements)
        {
            // Use SkipLast().
            var output = enumerable.Skip(numberOfElements);
            return output;
        }

        /// <summary>
		/// Returns the entire sequence, except for the last element (skips the last element).
		/// </summary>
		public IEnumerable<T> Except_Last<T>(IEnumerable<T> enumerable)
        {
            // Skip the last element.
            var output = this.Except_Last(enumerable, 1);
            return output;
        }

        /// <summary>
		/// Quality-of-life name for <see cref="Enumerable.SkipLast{TSource}(IEnumerable{TSource}, int)"/>
		/// </summary>
		public IEnumerable<T> Except_Last<T>(
            IEnumerable<T> enumerable,
            int numberOfElements)
        {
            // Use SkipLast().
            var output = enumerable.SkipLast(numberOfElements);
            return output;
        }

        public IEnumerable<T> From<T>(params T[] instances)
            // Just return the instances.
            => instances;

        /// <summary>
        /// Usually <see cref="From{T}(T[])"/> is good enough, but sometimes the input value is null and then the C# compiler issues an ambiguous call error.
        /// </summary>
        public IEnumerable<T> From_Instance<T>(T instance)
        {
            yield return instance;
        }

        public IEnumerable<T> From<T>(params IEnumerable<T>[] enumerables)
        {
            var output = this.From_Enumerables(enumerables);
            return output;
        }

        public IEnumerable<T> From_Enumerables<T>(params IEnumerable<T>[] enumerables)
        {
            var output = enumerables.SelectMany(enumerable => enumerable);
            return output;
        }

        public IEnumerable<T> From<T>(Func<T> generator)
        {
            var instance = generator();

            var output = this.From(instance);
            return output;
        }

        /// <summary>
        /// Returns true if the enumerable has no elements.
        /// </summary>
        public bool Is_Empty<T>(IEnumerable<T> items)
        {
            var any = items.Any();

            // None is not-any.
            var output = !any;
            return output;
        }

        public bool Is_Null<T>(IEnumerable<T> items)
        {
            var output = Instances.NullOperator.Is_Null(items);
            return output;
        }

        public bool Is_NullOrEmpty<T>(IEnumerable<T> items)
        {
            var isNull = this.Is_Null(items);
            if (isNull)
            {
                return true;
            }

            var isEmpty = this.Is_Empty(items);
            if (isEmpty)
            {
                return true;
            }

            return false;
        }

        public bool Is_NotNullOrEmpty<T>(IEnumerable<T> array)
        {
            var is_NullOrEmpty = this.Is_NullOrEmpty(array);

            var output = !is_NullOrEmpty;
            return output;
        }

        public IEnumerable<T> Join<T>(
            IEnumerable<T> items,
            T separator)
        {
            var enumerator = items.GetEnumerator();

            var has_Next = enumerator.MoveNext();
            if(has_Next)
            {
                while (has_Next)
                {
                    var current = enumerator.Current;

                    has_Next = enumerator.MoveNext();
                    if (has_Next)
                    {
                        yield return current;

                        yield return separator;
                    }
                    else
                    {
                        yield return current;
                    }
                }
            }
        }

        /// <summary>
        /// Returns a new, empty enumerable.
        /// </summary>
        public IEnumerable<T> New<T>()
            => this.Empty<T>();

        /// <summary>
        /// <para>The opposite of Any().</para>
        /// Quality-of-life overload for <see cref="Is_Empty{T}(IEnumerable{T})"/>.
        /// </summary>
        public bool None<T>(IEnumerable<T> items)
            => this.Is_Empty(items);

        /// <summary>
        /// Evaluates the given enumerable <em>now</em>.
        /// </summary>
        /// <remarks>
        /// This is a quality-of-life overload of <see cref="Enumerable.ToArray{TSource}(IEnumerable{TSource})"/>.
        /// <para>
        /// While the ToArray() method <em>does</em> enumerate the enumerable at the moment it is called, it's name (ToArray) suggests that purpose of the method is to change data type,
        /// and that the immediate evaluation of the enumerable is just a side effect.
        /// You frequently want to communicate to callers that you are enumerating the enumerable now, not turning it into an array.
        /// </para>
        /// </remarks>
        public T[] Now<T>(IEnumerable<T> items)
        {
            var output = items.ToArray();
            return output;
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order.
        /// </summary>
        /// <remarks>
        /// As-of .NET 7, this method is a provided by a built-in extension method.
        /// <para>See: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.order?view=net-7.0"/></para>
        /// </remarks>
        public IOrderedEnumerable<T> Order_Ascending<T>(IEnumerable<T> enumerable)
            => enumerable.OrderBy(x => x);

        /// <summary>
        /// Sorts the elements of a sequence in descending order.
        /// </summary>
        /// <remarks>
        /// As-of .NET 7, this method is a provided by a built-in extension method.
        /// <para>See: <see href="https://learn.microsoft.com/en-us/dotnet/api/system.linq.enumerable.orderdescending?view=net-7.0"/></para>
        /// </remarks>
        public IOrderedEnumerable<T> Order_Descending<T>(IEnumerable<T> enumerable)
            => enumerable.OrderByDescending(x => x);

        /// <summary>
        /// Chooses <see cref="Order_Ascending{T}(IEnumerable{T})"/> as the default.
        /// </summary>
        public IOrderedEnumerable<T> Order<T>(IEnumerable<T> enumerable)
            => enumerable.OrderBy(x => x);

        public IEnumerable<T> Select_Many<T>(params IEnumerable<T>[] enumerables)
        {
            var output = enumerables
                .SelectMany(Instances.Functions.Return)
                ;

            return output;
        }

        public HashSet<T> To_HashSet<T>(IEnumerable<T> values)
            => Instances.HashSetOperator.From(values);

        public IEnumerable<(T, T)> Zip<T>(
            IEnumerable<T> a,
            IEnumerable<T> b)
        {
            var output = a.Zip(
                b,
                (a, b) => (a, b));

            return output;
        }
    }
}
