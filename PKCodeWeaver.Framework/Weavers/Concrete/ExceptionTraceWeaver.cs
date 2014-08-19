using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using PKCodeWeaver.Framework.Weavers.Abstract;

namespace PKCodeWeaver.Framework.Weavers.Concrete
{
    internal class ExceptionTraceWeaver : MethodWeaver
    {
        public override void Weave(AssemblyDefinition assembly, MethodDefinition method)
        {
            method.Body.InitLocals = true;
            ILProcessor ilProcessor = method.Body.GetILProcessor();
            var count = method.Body.Variables.Count;
            method.Body.Variables.Add(new VariableDefinition(WeaverUtil.ImportType<Exception>(assembly)));
            method.Body.Variables.Add(new VariableDefinition(WeaverUtil.ImportType<PKTracer.Framework.Tracer.ExceptionTracer>(assembly)));

            var lastRet = FixReturns(method);
            var firstInstruction = FirstInstructionSkipCtor(method);

            var beforeReturn = Instruction.Create(OpCodes.Nop);
            ilProcessor.InsertBefore(lastRet, beforeReturn);

            var instructions = new List<Instruction>();

            instructions.Add(ilProcessor.Create(OpCodes.Stloc, count));
            instructions.Add(ilProcessor.Create(OpCodes.Nop));
            instructions.Add(ilProcessor.Create(OpCodes.Ldstr, assembly.Name.Name));
            instructions.Add(ilProcessor.Create(OpCodes.Ldloc, count));
            instructions.Add(ilProcessor.Create(OpCodes.Callvirt, WeaverUtil.ImportMethod<Exception>(assembly, "get_Message")));
            instructions.Add(ilProcessor.Create(OpCodes.Newobj,
                          method.Module.Import(typeof(PKTracer.Framework.Tracer.ExceptionTracer).GetConstructors()[0])));
            instructions.Add(ilProcessor.Create(OpCodes.Stloc, count + 1));
            instructions.Add(ilProcessor.Create(OpCodes.Ldloc, count + 1));
            instructions.Add(ilProcessor.Create(OpCodes.Callvirt, WeaverUtil.ImportMethod<PKTracer.Framework.Tracer.ExceptionTracer>(assembly, "Dispose")));
            instructions.Add(ilProcessor.Create(OpCodes.Nop));
            instructions.Add(ilProcessor.Create(OpCodes.Ldloc, count));
            instructions.Add(ilProcessor.Create(OpCodes.Throw));

            instructions.ForEach(x =>
            {
                ilProcessor.InsertBefore(lastRet, x);
            });

            var handlerCatch = new ExceptionHandler(ExceptionHandlerType.Catch)
            {
                TryStart = firstInstruction,
                TryEnd = beforeReturn,
                HandlerStart = beforeReturn,
                HandlerEnd = lastRet,
                CatchType = WeaverUtil.ImportType<Exception>(assembly)
            };
            method.Body.ExceptionHandlers.Add(handlerCatch);
        }
    }
}
