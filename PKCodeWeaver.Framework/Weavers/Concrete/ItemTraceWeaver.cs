using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using PKTracer.Framework.Tracer;
using PKCodeWeaver.Framework.Weavers.Abstract;

namespace PKCodeWeaver.Framework.Weavers.Concrete
{
    internal class ItemTraceWeaver : MethodWeaver
    {
        public override void Weave(AssemblyDefinition assembly, MethodDefinition method)
        {
            method.Body.InitLocals = true;
            ILProcessor ilProcessor = method.Body.GetILProcessor();
            var count = method.Body.Variables.Count;
            method.Body.Variables.Add(new VariableDefinition(WeaverUtil.ImportType<PKTracer.Framework.Tracer.ItemTracer>(assembly)));

            var lastRet = FixReturns(method);
            var firstInstruction = FirstInstructionSkipCtor(method);

            var beforeReturn = Instruction.Create(OpCodes.Nop);
            ilProcessor.InsertBefore(lastRet, beforeReturn);

            Instruction i3 = InsertBeginTrace(assembly, method, count, firstInstruction);

            var weaver = new ParameterTraceWeaver(count, i3);
            weaver.Parameters = this.Parameters;
            weaver.Weave(assembly, method);

            InsertEndTrace(assembly, method, count, beforeReturn, firstInstruction, lastRet);  
        }

        private void InsertEndTrace(
            AssemblyDefinition assembly,
            MethodDefinition method,
            int count,
            Instruction beforeReturn,
            Instruction firstInstruction,
            Instruction lastRet)
        {
            ILProcessor ilProcessor = method.Body.GetILProcessor();
            var instructions = new List<Instruction>();

            instructions.Add(ilProcessor.Create(OpCodes.Ldloc, count));
            instructions.Add(ilProcessor.Create(OpCodes.Callvirt, WeaverUtil.ImportMethod<ItemTracer>(assembly, "Dispose")));
            instructions.Add(ilProcessor.Create(OpCodes.Nop));
            instructions.Add(ilProcessor.Create(OpCodes.Endfinally));

            instructions.ForEach(x =>
            {
                ilProcessor.InsertBefore(lastRet, x);
            });

            var handlerFinally = new ExceptionHandler(ExceptionHandlerType.Finally)
            {
                TryStart = firstInstruction,
                TryEnd = beforeReturn,
                HandlerStart = beforeReturn,
                HandlerEnd = lastRet
            };
            method.Body.ExceptionHandlers.Add(handlerFinally);
        }

        private Instruction InsertBeginTrace(
            AssemblyDefinition assembly,
            MethodDefinition method,
            int count,
            Instruction firstInstruction)
        {
            ILProcessor ilProcessor = method.Body.GetILProcessor();
            var instructions = new List<Instruction>();
            /*
            //Begin: ItemTracer itemTracer = new ItemTracer("..Method..");	
            Instruction param1 = ilProcessor.Create(OpCodes.Ldstr, assembly.Name.Name);
            ilProcessor.InsertBefore(firstInstruction, param1);
            Instruction param2 = ilProcessor.Create(OpCodes.Ldstr, method.FullName);
            ilProcessor.InsertAfter(param1, param2);
            Instruction i2 = ilProcessor.Create(OpCodes.Newobj,
                          method.Module.Import(typeof(LogTracer.ItemTracer).GetConstructors()[0]));
            ilProcessor.InsertAfter(param2, i2);
            Instruction i3 = ilProcessor.Create(OpCodes.Stloc, count);
            ilProcessor.InsertAfter(i2, i3);
            //End: ItemTracer itemTracer = new ItemTracer("..Method..");	
            */

            instructions.Add(ilProcessor.Create(OpCodes.Ldstr, assembly.Name.Name));
            instructions.Add(ilProcessor.Create(OpCodes.Ldstr, method.FullName));
            instructions.Add(ilProcessor.Create(OpCodes.Newobj,
                          method.Module.Import(typeof(PKTracer.Framework.Tracer.ItemTracer).GetConstructors()[0])));
            instructions.Add(ilProcessor.Create(OpCodes.Stloc, count));

            instructions.ForEach(x =>
            {
                ilProcessor.InsertBefore(firstInstruction, x);
            });

            return instructions.Last();
        }        
    }
}
