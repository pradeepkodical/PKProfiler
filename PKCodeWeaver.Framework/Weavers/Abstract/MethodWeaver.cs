using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;
using Mono.Cecil.Cil;
using PKCodeWeaver.Framework.Model;

namespace PKCodeWeaver.Framework.Weavers.Abstract
{
    internal abstract class MethodWeaver
    {
        public IWeaveParameters Parameters { get; set; }
        public abstract void Weave(AssemblyDefinition assembly, MethodDefinition method);

        #region Helpers
        protected Instruction FixReturns(MethodDefinition method)
        {
            if (method.ReturnType.Name.Contains("Void"))
            {
                var instructions = method.Body.Instructions;
                var lastRet = Instruction.Create(OpCodes.Nop);
                instructions.Add(lastRet);
                instructions.Add(Instruction.Create(OpCodes.Ret));

                for (var index = 0; index < instructions.Count - 1; index++)
                {
                    var instruction = instructions[index];
                    if (instruction.OpCode == OpCodes.Ret)
                    {
                        instructions[index].OpCode = OpCodes.Leave;
                        instructions[index].Operand = lastRet;
                    }
                }
                return lastRet;
            }
            else
            {
                var instructions = method.Body.Instructions;
                var returnVariable = new VariableDefinition(method.ReturnType);
                method.Body.Variables.Add(returnVariable);
                var lastLd = Instruction.Create(OpCodes.Ldloc, returnVariable);
                instructions.Add(lastLd);
                instructions.Add(Instruction.Create(OpCodes.Ret));

                for (var index = 0; index < instructions.Count - 2; index++)
                {
                    var instruction = instructions[index];
                    if (instruction.OpCode == OpCodes.Ret)
                    {
                        instructions[index] = Instruction.Create(OpCodes.Leave, lastLd);
                        instructions.Insert(index, Instruction.Create(OpCodes.Stloc, returnVariable));
                        index++;
                    }
                }
                return lastLd;
            }
        }
        protected Instruction FirstInstructionSkipCtor(MethodDefinition method)
        {
            if (method.IsConstructor && !method.IsStatic)
            {
                var a = method.Body.Instructions.Where(x => IsConstructorCall(x)).FirstOrDefault();
                if (a != null)
                {
                    return a.Next;
                }
                return method.Body.Instructions.Skip(2).First();
            }
            return method.Body.Instructions.First();
        }
        private bool IsConstructorCall(Instruction x)
        {
            if (x.OpCode == OpCodes.Call)
            {
                if (x.Operand != null)
                {
                    return x.Operand.ToString().Contains(".ctor(");
                }
            }
            return false;
        }
        #endregion
    }
}
