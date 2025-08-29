using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0006;
using F10Y.T0014.T001;


namespace F10Y.L0000.Q000
{
    [DemonstrationsMarker]
    public partial interface IHashCodeDemonstrations :
        IScriptTextOutputInfrastructure_Definition
    {
        /// <summary>
        /// Are the hash codes of integers just the integers themselves?
        /// <para>
        /// It depends on how the hash code is computed!
        /// The <see cref="HashCode.Combine{T1}(T1)"/> method returns a hash,
        /// the <see cref="System.Collections.IEqualityComparer.GetHashCode(object)"/> method just returns the integer,
        /// as does the <see cref="Object.GetHashCode"/> method.
        /// </para>
        /// </summary>
        public async Task WhatIs_HashCode_OfInteger()
        {
            var value = Instances.Integers.One;

            var hashCode_ViaCombine_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsObject(value);
            var hashCode_ViaCombine_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsType(value);

            var hashCode_ViaEqualityComparer_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsObject(value);
            var hashCode_ViaEqualityComparer_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsType(value);

            var hashCode_ViaGetHashCode_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaGetHashCode_AsObject(value);
            var hashCode_ViaGetHashCode_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaGetHashCode_AsType(value);

            var lines_ForOutput = Instances.EnumerableOperator.From($"Hash code of integer '{value}':")
                .Append($"{hashCode_ViaCombine_AsObject}: of integer as object, via combine")                       // 423521867
                .Append($"{hashCode_ViaCombine_AsType}: of integer as type, via combine")                           // 423521867
                .Append($"{hashCode_ViaEqualityComparer_AsObject}: of integer as object, via equality comparer")    // 1
                .Append($"{hashCode_ViaEqualityComparer_AsType}: of integer as type, via equality comparer")        // 1
                .Append($"{hashCode_ViaGetHashCode_AsObject}: of integer as object, via instance GetHashCode()")    // 1
                .Append($"{hashCode_ViaGetHashCode_AsType}: of integer as type, via instdance GetHashCode()")       // 1
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }

        /// <summary>
        /// For a non-null instance, does the way the hash code is computed matter?
        /// <para>
        /// It <em>does</em> matter how you compute it!
        /// The <see cref="HashCode.Combine{T1}(T1)"/> method returns a difference value from <see cref="System.Collections.IEqualityComparer.GetHashCode(object)"/>,
        /// but the equality comparer returns the same value as <see cref="Object.GetHashCode"/>.
        /// </para>
        /// </summary>
        /// <returns></returns>
        public async Task WhatIs_HashCode_OfNonNull()
        {
            var value = Instances.Strings.Apple;

            var hashCode_ViaCombine_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsObject(value);
            var hashCode_ViaCombine_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsType(value);

            var hashCode_ViaEqualityComparer_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsObject(value);
            var hashCode_ViaEqualityComparer_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsType(value);

            var hashCode_ViaGetHashCode_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaGetHashCode_AsObject(value);
            var hashCode_ViaGetHashCode_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaGetHashCode_AsType(value);

            var lines_ForOutput = Instances.EnumerableOperator.From($"Hash code of string '{value}':")
                .Append($"{hashCode_ViaCombine_AsObject}: of string as object, via combine")                    // -1996677947
                .Append($"{hashCode_ViaCombine_AsType}: of string as type, via combine")                        // -1996677947
                .Append($"{hashCode_ViaEqualityComparer_AsObject}: of string as object, via equality comparer") // 154802826
                .Append($"{hashCode_ViaEqualityComparer_AsType}: of string as type, via equality comparer")     // 154802826
                .Append($"{hashCode_ViaGetHashCode_AsObject}: of string as object, via instance GetHashCode()") // 154802826
                .Append($"{hashCode_ViaGetHashCode_AsType}: of string as type, via instdance GetHashCode()")    // 154802826
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }

        /// <summary>
        /// What is the hash code of null?
        /// Is it fixed (always the same)?
        /// Does it matter how you compute it? (<see cref="HashCode.Combine{T1}(T1)"/> vs. <see cref="System.Collections.IEqualityComparer.GetHashCode(object)"/>)
        /// <para>
        /// It <em>does</em> matter how you compute it.
        /// For the equality comparer, that always outputs zero.
        /// For the hashcode combine method, the output is not zero, and is variable. For three runs:
        /// <list type="bullet">
        /// <item>1373201260</item>
        /// <item>2045898293</item>
        /// <item>-1621035087</item>
        /// </list>
        /// </para>
        /// </summary>
        public async Task WhatIs_HashCode_OfNull()
        {
            object null_AsObject = null;
            string null_AsString = null;

            var hashCode_OfObject = Instances.HashCodeOperator.Get_HashCode(null_AsObject);
            var hashCode_OfString = Instances.HashCodeOperator.Get_HashCode(null_AsString);

            var hashCode_OfString_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsObject(null_AsString);
            var hashCode_OfString_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsType(null_AsString);

            var hashCode_OfString_ViaCombine_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsObject(null_AsString);
            var hashCode_OfString_ViaEqualityComparer_AsObject = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsObject(null_AsString);

            var hashCode_OfString_ViaCombine_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaCombine_AsType(null_AsString);
            var hashCode_OfString_ViaEqualityComparer_AsType = Instances.HashCodeOperator._Implementations.Get_HashCode_ViaEqualityComparer_AsType(null_AsString);

            var lines_ForOutput = Instances.EnumerableOperator.From("Hash code of null:")
                .Append($"{hashCode_OfObject}: of object")                                                                  // -1728499436
                .Append($"{hashCode_OfString}: of string")                                                                  // -1728499436
                .Append($"{hashCode_OfString_AsObject}: of string as object")                                               // -1728499436
                .Append($"{hashCode_OfString_AsType}: of string as type")                                                   // -1728499436
                .Append($"{hashCode_OfString_ViaCombine_AsObject}: of string as object, via combine")                       // -1728499436
                .Append($"{hashCode_OfString_ViaEqualityComparer_AsObject}: of string as object, via equality comparer")    // 0
                .Append($"{hashCode_OfString_ViaCombine_AsType}: of string as type, via combine")                           // -1728499436
                .Append($"{hashCode_OfString_ViaEqualityComparer_AsType}: of string as type, via equality comparer")        // 0
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }
    }
}
