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
    internal class ParameterTraceWeaver : MethodWeaver
    {
        private int tracerIndex;
        private Instruction lastInstruction;
        public ParameterTraceWeaver(int tracerIndex, Instruction lastInstruction)
        {
            this.tracerIndex = tracerIndex;
            this.lastInstruction = lastInstruction;
        }
        public override void Weave(AssemblyDefinition assembly, MethodDefinition method)
        {
            ILProcessor ilProcessor = method.Body.GetILProcessor();
            var objTracingInstructions = new List<Instruction>();

            TypeSpecification referencedTypeSpec = null;
            MetadataType paramMetaData;
            TypeReference typeObject = assembly.MainModule.TypeSystem.Object;
            bool pointerToValueTypeVariable = false;

            int intMethodParamsCount = method.Parameters.Count;
            int intArrayVarNumber = method.Body.Variables.Count;
            ArrayType objArrType = new ArrayType(typeObject);
            method.Body.Variables.Add(new VariableDefinition((TypeReference)objArrType));
            method.Body.InitLocals = true;

            //objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldstr,method.ToString()));
            objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldc_I4, intMethodParamsCount));
            objTracingInstructions.Add(ilProcessor.Create(OpCodes.Newarr, typeObject));
            objTracingInstructions.Add(ilProcessor.Create(OpCodes.Stloc, intArrayVarNumber));

            // Loop over all the parameters of method and add their value to object[]
            // ------------------------------------------------------------
            for (int i = 0; i < intMethodParamsCount; i++)
            {
                paramMetaData = method.Parameters[i].ParameterType.MetadataType;
                if (paramMetaData == MetadataType.UIntPtr ||
                    paramMetaData == MetadataType.FunctionPointer ||
                    paramMetaData == MetadataType.IntPtr ||
                    paramMetaData == MetadataType.Pointer)
                {
                    // We don't want to log values of these parameters, so skip
                    // this iteration
                    break;
                }

                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldloc, intArrayVarNumber));
                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldc_I4, i));

                // Instance methods have an an implicit argument called "this"
                // and hence, we need to refer to actual arguments with +1 position
                // whereas, in case of static methods, "this" argument is not there
                // ------------------------------------------------------------
                if (method.IsStatic)
                {
                    objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldarg, i));
                }
                else
                {
                    objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldarg, i + 1));
                }

                // Reset boolean flag variable to false
                pointerToValueTypeVariable = false;

                // If aparameter is passed by reference then you need to use ldind
                // ------------------------------------------------------------
                TypeReference paramType = method.Parameters[i].ParameterType;
                if (paramType.IsByReference)
                {
                    referencedTypeSpec = paramType as TypeSpecification;
                    //Trace.WriteLine(string.Format("Parameter Name:{0}, Type:{1}", metDef.Parameters[i].Name, metDef.Parameters[i].ParameterType.Name));

                    if (referencedTypeSpec != null)
                    {
                        switch (referencedTypeSpec.ElementType.MetadataType)
                        {
                            //Indirect load value of type int8 as int32 on the stack
                            case MetadataType.Boolean:
                            case MetadataType.SByte:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_I1));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type int16 as int32 on the stack
                            case MetadataType.Int16:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_I2));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type int32 as int32 on the stack
                            case MetadataType.Int32:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_I4));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type int64 as int64 on the stack
                            // Indirect load value of type unsigned int64 as int64 on the stack (alias for ldind.i8)
                            case MetadataType.Int64:
                            case MetadataType.UInt64:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_I8));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type unsigned int8 as int32 on the stack
                            case MetadataType.Byte:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_U1));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type unsigned int16 as int32 on the stack
                            case MetadataType.UInt16:
                            case MetadataType.Char:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_U2));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type unsigned int32 as int32 on the stack
                            case MetadataType.UInt32:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_U4));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type float32 as F on the stack
                            case MetadataType.Single:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_R4));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type float64 as F on the stack
                            case MetadataType.Double:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_R8));
                                pointerToValueTypeVariable = true;
                                break;

                            // Indirect load value of type native int as native int on the stack
                            case MetadataType.IntPtr:
                            case MetadataType.UIntPtr:
                                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_I));
                                pointerToValueTypeVariable = true;
                                break;

                            default:
                                // Need to check if it is a value type instance, in which case
                                // we use ldobj instruction to copy the contents of value type
                                // instance to stack and then box it
                                if (referencedTypeSpec.ElementType.IsValueType)
                                {
                                    objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldobj, referencedTypeSpec.ElementType));
                                    pointerToValueTypeVariable = true;
                                }
                                else
                                {
                                    // It is a reference type so just use reference the pointer
                                    objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldind_Ref));
                                    pointerToValueTypeVariable = false;
                                }
                                break;
                        }
                    }
                    else
                    {
                        // We dont have complete details about the type of referenced parameter
                        // So we will just ignore this parameter value
                    }
                }

                // If it is a value type then you need to box the instance as we are going
                // to add it to an array which is of type object (reference type)
                // ------------------------------------------------------------
                if (paramType.IsValueType || pointerToValueTypeVariable)
                {
                    if (pointerToValueTypeVariable)
                    {
                        // Box the dereferenced parameter type
                        objTracingInstructions.Add(ilProcessor.Create(OpCodes.Box, referencedTypeSpec.ElementType));
                    }
                    else
                    {
                        // Box the parameter type
                        objTracingInstructions.Add(ilProcessor.Create(OpCodes.Box, paramType));
                    }
                }

                // Store parameter in object[] array
                // ------------------------------------------------------------
                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Stelem_Ref));
            }

            // Load address of array variable on evaluation stack, to pass
            // it as a paremter
            // ------------------------------------------------------------
            objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldloc, tracerIndex));
            objTracingInstructions.Add(ilProcessor.Create(OpCodes.Ldloc, intArrayVarNumber));
            if (this.Parameters.DecodeParameters)
            {
                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Callvirt, WeaverUtil.ImportMethod<ItemTracer>(assembly, "SetParametersWithDecode")));
            }
            else
            {
                objTracingInstructions.Add(ilProcessor.Create(OpCodes.Callvirt, WeaverUtil.ImportMethod<ItemTracer>(assembly, "SetParameters")));
            }

            for (var i = objTracingInstructions.Count - 1; i >= 0; i--)
            {
                ilProcessor.InsertAfter(lastInstruction, objTracingInstructions[i]);
            }   
        }
    }
}
