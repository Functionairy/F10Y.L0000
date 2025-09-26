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


        Assembly Acquire(AssemblyName assemblyName)
            => Assembly.Load(assemblyName);

        /// <inheritdoc cref="Enumerate_AssemblyFilePaths_AssumeAllDlls(string)"/>
        IEnumerable<string> Enumerate_AssemblyFilePaths(string directoryPath)
        {
            return this.Enumerate_AssemblyFilePaths_AssumeAllDlls(directoryPath);
        }

        IEnumerable<string> Enumerate_AssemblyFilePaths_InDirectoryOfAssembly(string assemblyFilePath)
        {
            var assemblyDirectoryPath = Instances.PathOperator.Get_ParentDirectoryPath_ForFile(assemblyFilePath);

            var output = this.Enumerate_AssemblyFilePaths(assemblyDirectoryPath);
            return output;
        }

        /// <summary>
        /// Get all DLL assembly files in the directory assuming all DLL files are assembly files.
        /// </summary>
        IEnumerable<string> Enumerate_AssemblyFilePaths_AssumeAllDlls(string directoryPath)
        {
            return Instances.FileSystemOperator.Enumerate_DllFiles(directoryPath);
        }

        IEnumerable<MemberInfo> Enumerate_Members(Assembly assembly)
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

        AssemblyName[] Get_AssemblyNames_OfReferencedAssemblies(Assembly assembly)
            => assembly.GetReferencedAssemblies();

        string Get_FullName(Assembly assembly)
            => assembly.FullName;

        Assembly[] Get_ReferencedAssemblies_Direct(Assembly assembly)
        {
            var assemblyNames = this.Get_AssemblyNames_OfReferencedAssemblies(assembly);

            var output = assemblyNames
                .Select(this.Acquire)
                .Now();

            return output;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// Inclusive of the 
        /// </remarks>
        Assembly[] Get_ReferencedAssemblies_Recursive_Inclusive(Assembly assembly)
        {
            var assembly_Accumulator = Instances.HashSetOperator.New<Assembly>();

            static void AccumulateAssemblies(
                Assembly assembly,
                HashSet<Assembly> assembly_Accumulator)
            {
                // Add the current assembly.
                assembly_Accumulator.Add(assembly);

                var assemblyNames_ReferencedAssemblies = Instances.AssemblyOperator.Get_AssemblyNames_OfReferencedAssemblies(assembly);

                foreach (var assemblyName in assemblyNames_ReferencedAssemblies)
                {
                    var assembly_Current = Instances.AssemblyOperator.Acquire(assemblyName);

                    var alreadyAdded = Instances.HashSetOperator.Contains(
                        assembly_Accumulator,
                        assembly_Current);

                    if (!alreadyAdded)
                    {
                        AccumulateAssemblies(
                            assembly_Current,
                            assembly_Accumulator);
                    }
                }
            }

            AccumulateAssemblies(
                assembly,
                assembly_Accumulator);

            var output = assembly_Accumulator.ToArray();
            return output;
        }

        Assembly[] Get_ReferencedAssemblies_Recursive_Exclusive(Assembly assembly)
        {
            var referencedAssemblies_Recursive_Inclusive = this.Get_ReferencedAssemblies_Recursive_Inclusive(assembly);

            var output = referencedAssemblies_Recursive_Inclusive
                .Except(assembly)
                .Now();

            return output;
        }

        string[] Get_AssemblyFilePaths(string directoryPath)
            => this.Enumerate_AssemblyFilePaths(directoryPath)
                .ToArray();

        string[] Get_AssemblyFilePaths_InDirectoryOfAssembly(string assemblyFilePath)
            => this.Enumerate_AssemblyFilePaths_InDirectoryOfAssembly(assemblyFilePath)
                .ToArray();

        string[] Get_MemberNames(Assembly assembly)
        {
            var members = Instances.AssemblyOperator.Get_Members(assembly);

            var output = members
                .Select(Instances.MemberInfoOperator.To_String)
                .Now();

            return output;
        }

        MemberInfo[] Get_Members(Assembly assembly)
            => this.Enumerate_Members(assembly)
                .ToArray();

        /// <summary>
        /// Returns <see cref="Assembly.DefinedTypes"/>.
        /// </summary>
        IEnumerable<TypeInfo> Enumerate_Types(Assembly assembly)
        {
            return assembly.DefinedTypes;
        }

        /// <summary>
        /// Gets the F10Y.L0000 assembly.
        /// </summary>
        Assembly Get_Assembly()
            => this.Get_ExecutingAssembly();

        Assembly Get_AssemblyForType<T>()
        {
            var type = Instances.TypeOperator.Get_Type<T>();

            var output = this.Get_AssemblyForType(type);
            return output;
        }

        Assembly Get_AssemblyForType(Type type)
            => Instances.TypeOperator.Get_AssemblyForType(type);

        /// <summary>
        /// Get the assemby file name stem given an assembly name.
        /// </summary>
        string Get_AssemblyFileNameStem(string assemblyName)
        {
            // The file name stem is just the assembly name.
            var assemblyFileNameStem = assemblyName;
            return assemblyFileNameStem;
        }

        string Get_AssemblyName_FromFilePath(string assemblyFilePath)
        {
            var assemblyFileName = Instances.PathOperator.Get_FileName(assemblyFilePath);

            var output = this.Get_AssemblyName_FromFileName(assemblyFileName);
            return output;
        }

        string Get_AssemblyName_FromFileName(string assemblyFileName)
        {
            var fileNameStem = Instances.FileNameOperator.Get_FileNameStem(assemblyFileName);

            var output = this.Get_AssemblyName_FromFileNameStem(fileNameStem);
            return output;
        }

        string Get_AssemblyName_FromFileNameStem(string assemblyFileNameStem)
        {
            // The assembly name is just the file name stem.
            var output = assemblyFileNameStem;
            return output;
        }

        Assembly Get_ExecutingAssembly()
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
        Assembly Get_System_CoreAssembly()
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
        Assembly Get_EntryPointAssembly()
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
        string Get_FilePath(Assembly assembly)
            => assembly.Location;
    }
}
