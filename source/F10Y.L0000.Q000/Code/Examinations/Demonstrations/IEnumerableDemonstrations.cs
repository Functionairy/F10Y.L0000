using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.T0006;
using F10Y.T0014.T001;


namespace F10Y.L0000.Q000
{
    [DemonstrationsMarker]
    public partial interface IEnumerableDemonstrations :
        IScriptTextOutputInfrastructure_Definition
    {
        /// <summary>
        /// What happens when you call the Max() extension method on an empty enumerable?
        /// <para>
        /// Result: the max throws an exception when the enumerable's type is a struct, and null when it is a 
        /// </para>
        /// </summary>
        public async Task WhatIsMax_OfEmpty()
        {
            var enumerable = Instances.EnumerableOperator
                //.Empty<string>() // Max is null.
                //.Empty<object>() // Max is null.
                .Empty<DateTime>() // Throws exception: System.InvalidOperationException: 'Sequence contains no elements'
                ;

            var max = enumerable.Max();

            var lines_ForOutput = Instances.EnumerableOperator.From("Success")
                .Append($"{max}: max of empty enumerable")
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }
    }
}
