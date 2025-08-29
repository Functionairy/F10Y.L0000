using System;
using System.Linq;
using System.Threading.Tasks;

using F10Y.L0000.Extensions;
using F10Y.L0001.L000.Extensions;
using F10Y.T0006;
using F10Y.T0014.T001;


namespace F10Y.L0000.Q000
{
    [DemonstrationsMarker]
    public partial interface IPathDemonstrations :
        IScriptTextOutputInfrastructure_Definition
    {
        public async Task Get_FileName_OfFilePath()
        {
            /// Inputs.
            var path = Instances.Paths
                .Example_FilePath
                ;


            /// Run.
            var fileName = Instances.PathOperator.Get_FileName(path);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{fileName} - File name of file path:")
                .Append($"{path}".Entab())
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }

        /// <summary>
        /// Display the last path part.
        /// </summary>
        public async Task Display_PathPart_Last()
        {
            /// Inputs.
            var path = Instances.Paths
                .Example_FilePath
                ;


            /// Run.
            var pathPart_Last = Instances.PathOperator.Get_PathPart_Last(path);

            var lines_ForOutput = Instances.EnumerableOperator.From($"{pathPart_Last} - last path part of path:")
                .Append($"{path}".Entab())
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }


        /// <summary>
        /// For a path, break it into parts, then write the parts to an output file.
        /// <para>
        /// This is a demonstration of <demonstration-of><see cref="F10Y.L0000.IPathOperator.Get_PathParts_NonEmpty(string)"/>.</demonstration-of>
        /// </para>
        /// </summary>
        public async Task Display_PathParts_NonEmpty()
        {
            /// Inputs.
            var path = Instances.Paths
                .Example_FilePath
                ;


            /// Run.
            var pathParts = Instances.PathOperator.Get_PathParts_NonEmpty(path);

            var lines_ForOutput = Instances.EnumerableOperator.From("Path parts:")
                .Append_BlankLine()
                .Append_Many(pathParts)
                .Append_BlankLine()
                .Append(path)
                ;

            await this.Write_Lines_AndOpen(lines_ForOutput);
        }
    }
}
