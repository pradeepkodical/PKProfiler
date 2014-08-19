using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using System.IO;

using System.Reflection;
using System;
using System.Collections.Generic;
using PKCodeWeaver.Framework.Model;

namespace PKCodeWeaver.Framework.Injectors.Abstract
{
    public abstract class CodeInjector
    {
        public IWeaveParameters Parameters { get; protected set; }
        public CodeInjector(IWeaveParameters parameters)
        {
            this.Parameters = parameters;            
        }

        public void Process()
        {
            var includedClassNames = new Dictionary<string, string>();

            if (this.Parameters.IncludeClasses != null)
            {
                this.Parameters.IncludeClasses.ForEach(x =>
                {
                    includedClassNames[x] = x;
                });
            }

            string assemblyDirectory = Path.GetDirectoryName(this.Parameters.FileName);

            var assemblyResolver = new DefaultAssemblyResolver();
            assemblyResolver.AddSearchDirectory(assemblyDirectory);
            var readerParameters = new ReaderParameters
            {
                AssemblyResolver = assemblyResolver
            };

            var assembly = AssemblyDefinition.ReadAssembly(this.Parameters.FileName, readerParameters);

            foreach (var moduleDefinition in assembly.Modules)
            {
                foreach (var type in moduleDefinition.Types)
                {

                    if (includedClassNames.Count == 0 || includedClassNames.ContainsKey(type.FullName))
                    {
                        PatchType(assembly, type);
                    }
                }
            }

            var writeParams = new WriterParameters
            {
                WriteSymbols = true,                
            };

            if (!string.IsNullOrEmpty(this.Parameters.AssemblySignKeyFile))
            {
                var key = new StrongNameKeyPair(new FileStream(this.Parameters.AssemblySignKeyFile, FileMode.Open));
                writeParams.StrongNameKeyPair = key;
            }
                        
            assembly.Write(this.Parameters.FileName, writeParams);

            if (this.Parameters.IISReset)
            {
                new System.EnterpriseServices.Internal.Publish().GacInstall(this.Parameters.FileName);
                System.Diagnostics.Process.Start(@"iisreset.exe");
            }
        }        
        protected abstract void PatchType(AssemblyDefinition assembly, TypeDefinition type);      
    }
}
