using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;

using PKTracer.Framework;
using PKTracer.Framework.Attributes;
using PKTracer.Framework.Tracer;
using PKCodeWeaver.Framework.Injectors.Abstract;
using PKCodeWeaver.Framework.Weavers.Abstract;
using PKCodeWeaver.Framework.Weavers.Concrete;
using PKCodeWeaver.Framework.Model;

namespace PKCodeWeaver.Framework.Injectors.Concrete
{
    public class TraceInjector : CodeInjector
    {
        private MethodWeaver exceptionWeaver;
        private MethodWeaver itemTraceWeaver;

        public TraceInjector(IWeaveParameters parameters)
            : base(parameters)
        {
            exceptionWeaver = new ExceptionTraceWeaver();
            exceptionWeaver.Parameters = this.Parameters;

            itemTraceWeaver = new ItemTraceWeaver();
            itemTraceWeaver.Parameters = this.Parameters;
        }

        protected override void PatchType(AssemblyDefinition assembly, TypeDefinition type)
        {
            type.CustomAttributes.Add(WeaverUtil.GetDoNotInjectAttribute(assembly, typeof(DoNotInjectAttribute)));
            foreach (var method in type.Methods)
            {
                if (!WeaverUtil.HasAttribute(typeof(PKTracer.Framework.Attributes.DoNotTraceAttribute).FullName, method.CustomAttributes))
                {
                    if (!method.IsAddOn && !method.IsRemoveOn)
                    {
                        if (method.Body != null)
                        {
                            using (new DebugTracer("PatchType"))
                            {
                                method.CustomAttributes.Add(WeaverUtil.GetDoNotInjectAttribute(assembly, typeof(DoNotTraceAttribute)));

                                method.Body.SimplifyMacros();
                                itemTraceWeaver.Weave(assembly, method);
                                exceptionWeaver.Weave(assembly, method);
                                method.Body.OptimizeMacros();
                            }
                        }
                    }
                }
            }
        }        
    }
}
