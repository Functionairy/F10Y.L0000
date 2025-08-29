using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using F10Y.T0002;
using F10Y.T0011;

using F10Y.L0000.Extensions;


namespace F10Y.L0000
{
    [FunctionsMarker]
    public partial interface IAssemblyOperator
    {
#pragma warning disable IDE1006 // Naming Styles

        [Ignore]
        public Internal.IAssemblyOperator _Internal => Internal.AssemblyOperator.Instance;

#pragma warning restore IDE1006 // Naming Styles


        /// <inheritdoc cref="Enumerate_AssemblyFilePaths_AssumeAllDlls(string)"/>
        public IEnumerable<string> Enumerate_AssemblyFilePaths(string directoryPath)
        {
            return this.Enumerate_AssemblyFilePaths_AssumeAllDlls(directoryPath);
        }

        public IEnumerable<string> Enumerate_AssemblyFilePaths_InDirectoryOfAssembly(string assemblyFilePath)
        {
            var assemblyDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);

            var output = this.Enumerate_AssemblyFilePaths(assemblyDirectoryPath);
            return output;
        }

        /// <summary>
        /// Get all DLL assembly files in the directory assuming all DLL files are assembly files.
        /// </summary>
        public IEnumerable<string> Enumerate_AssemblyFilePaths_AssumeAllDlls(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_DllFiles(directoryPath);
        }

        public IEnumerable<MemberInfo> Enumerate_Members(Assembly assembly)
        {
            var output = this.Enumerate_Types(assembly)
                .SelectMany(typeInfo => Instances.EnumerableOperator.Empty<MemberInfo>()
                    .Append(typeInfo)
                    .Append(
                        Instances.TypeInfoOperator.Enumerate_MemberInfos(typeInfo)
                    )
                )
                ;

            return output;
        }

        public string[] Get_AssemblyFilePaths(string directoryPath)
            => this.Enumerate_AssemblyFilePaths(directoryPath)
                .ToArray();

        public string[] Get_AssemblyFilePaths_InDirectoryOfAssembly(string assemblyFilePath)
            => this.Enumerate_AssemblyFilePaths_InDirectoryOfAssembly(assemblyFilePath)
                .ToArray();

        public MemberInfo[] Get_Members(Assembly assembly)
            => this.Enumerate_Members(assembly)
                .ToArray();

        /// <summary>
        /// Returns <see cref="Assembly.DefinedTypes"/>.
        /// </summary>
        public IEnumerable<TypeInfo> Enumerate_Types(Assembly assembly)
        {
            return assembly.DefinedTypes;
        }

        /// <summary>
        /// Gets the F10Y.L0000 assembly.
        /// </summary>
        public Assembly Get_Assembly()
            => this.Get_ExecutingAssembly();

        public Assembly Get_AssemblyForType<T>()
        {
            var type = Instances.TypeOperator.Get_Type<T>();

            var output = this.Get_AssemblyForType(type);
            return output;
        }

        public Assembly Get_AssemblyForType(Type type)
            => Instances.TypeOperator.Get_AssemblyForType(type);

        /// <summary>
        /// Get the assemby file name stem given an assembly name.
        /// </summary>
        public string Get_AssemblyFileNameStem(string assemblyName)
        {
            // The file name stem is just the assembly name.
            var assemblyFileNameStem = assemblyName;
            return assemblyFileNameStem;
        }

        public string Get_AssemblyName_FromFilePath(string assemblyFilePath)
        {
            var assemblyFileName = Instances.PathOperator.Get_FileName(assemblyFilePath);

            var output = this.Get_AssemblyName_FromFileName(assemblyFileName);
            return output;
        }

        public string Get_AssemblyName_FromFileName(string assemblyFileName)
        {
            var fileNameStem = Instances.FileNameOperator.Get_FileNameStem(assemblyFileName);

            var output = this.Get_AssemblyName_FromFileNameStem(fileNameStem);
            return output;
        }

        public string Get_AssemblyName_FromFileNameStem(string assemblyFileNameStem)
        {
            // The assembly name is just the file name stem.
            var output = assemblyFileNameStem;
            return output;
        }

        public Assembly Get_ExecutingAssembly()
        {
            var output = Assembly.GetCallingAssembly();
            return output;
        }

        /// <summary>
        /// Returns the .NET system assembly.
        /// </summary>
        /// <remarks>
        /// Returns the currently loaded assembly containing the <see cref="string"/> type.
        /// </remarks>
        public Assembly Get_System_CoreAssembly()
        {
            var output = typeof(string).Assembly;
            return output;
        }

        /// <summary>
        /// Returns the entry-point .NET assembly.
        /// </summary>
        /// <remarks>
        /// Returns the result of <see cref="Assembly.GetEntryAssembly"/>.
        /// </remarks>
        public Assembly Get_EntryPointAssembly()
        {
            var output = Assembly.GetEntryAssembly();
            return output;
        }

        /// <summary>
        /// Get the path of the file containing the assembly.
        /// </summary>
        /// <remarks>
        /// Returns the <see cref="Assembly.Location"/> value.
        /// </remarks>
        public string Get_FilePath(Assembly assembly)
            => assembly.Location;
    }
}
