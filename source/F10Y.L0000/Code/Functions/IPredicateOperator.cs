using System;
using System.Collections.Generic;
using System.Linq;
using F10Y.T0002;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IPredicateOperator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Short-circuting.
        /// <use-collection>Use a collection to ensure predicates are evaluated once.</use-collection>
        /// <para>Note: And() of empty is true.</para>
        /// </remarks>
        public Func<T, bool> And<T>(
            ICollection<Func<T, bool>> predicates)
        {
            bool Internal(T value)
            {
                foreach (var predicate in predicates)
                {
                    var stool = predicate(value);
                    if(!stool)
                    {
                        return false;
                    }
                }

                return true;
            }

            return Internal;
        }

        public Func<T, bool> And<T>(params Func<T, bool>[] predicates)
            => this.And(predicates as ICollection<Func<T, bool>>);

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Short-circuiting.
        /// </remarks>
        public Func<T, bool> And<T>(
            IEnumerable<Func<T, bool>> predicates)
        {
            bool Internal(T meal)
            {
                foreach (var predicate in predicates)
                {
                    var stool = predicate(meal);
                    if (!stool)
                    {
                        return false;
                    }
                }

                // Else, if all predicates pass.
                return true;
            }

            return Internal;
        }

        /// <summary>
        /// Creates an ANY predicate from a collection of predicates.
        /// </summary>
        /// <remarks>
        /// <inheritdoc cref="And{T}(ICollection{Func{T, bool}})" path="/remarks/use-collection"/>
        /// <para>Note: Any() of empty is false.</para>
        /// </remarks>
        public Func<T, bool> Any<T>(ICollection<Func<T, bool>> predicates)
        {
            bool Internal(T value)
            {
                foreach (var predicate in predicates)
                {
                    var stool = predicate(value);
                    if (stool)
                    {
                        return true;
                    }
                }

                return false;
            }

            return Internal;
        }

        /// <summary>
        /// Returns a typed predicates value instance (<see cref="IPredicates{T}"/>).
        /// </summary>
        public IPredicates<T> For<T>()
            => L0000.Predicates<T>.Instance;

        public bool If_TypeIs_ElseFalse<T>(
            object @object,
            Func<T, bool> predicate)
        {
            var is_Type = Instances.TypeOperator.Type_Is<T>(
                @object,
                out var object_IsT);

            // Short-circuited && operator will only evaluate the predicate if the object is of the given type.
            var output = is_Type && predicate(object_IsT);
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <inheritdoc cref="ITypeOperator.Type_Is{T}(object, out T)" path="/remarks"/>
        public bool If_TypeIs_ElseTrue<T>(
            object @object,
            Func<T, bool> predicate)
        {
            var is_Type = Instances.TypeOperator.Type_Is<T>(
                @object,
                out var object_IsT);

            // Short-circuited || operator will only evaluate the predicate if the object is not of the given type.
            var output = !is_Type || predicate(object_IsT);
            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <inheritdoc cref="ITypeOperator.Type_Is{T}(object, out T)" path="/remarks"/>
        public bool If_TypeIs_Else<T>(
            object @object,
            Func<T, bool> predicate,
            bool value_Default)
        {
            var output = value_Default
                ? this.If_TypeIs_ElseTrue(
                    @object,
                    predicate)
                : this.If_TypeIs_ElseFalse(
                    @object,
                    predicate)
                ;

            return output;
        }

        /// <summary>
        /// Chooses <see cref="If_TypeIs_ElseFalse{T}(object, Func{T, bool})"/> as the default.
        /// </summary>
        public bool If_TypeIs<T>(
            object @object,
            Func<T, bool> predicate)
            => this.If_TypeIs_ElseFalse(
                @object,
                predicate);

        public IEnumerable<T> Where<T>(
            Func<T, bool> predicate,
            IEnumerable<T> values)
            => values.Where(predicate);
    }
}
