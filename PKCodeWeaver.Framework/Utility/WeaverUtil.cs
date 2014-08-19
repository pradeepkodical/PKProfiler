using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mono.Cecil;

namespace PKCodeWeaver.Framework
{
    internal class WeaverUtil
    {
        public static TypeReference ImportType<T>(AssemblyDefinition assembly)
        {
            return assembly.MainModule.Import(typeof(T));
        }

        public static MethodReference ImportMethod<T>(AssemblyDefinition assembly, string methodName)
        {
            return assembly.MainModule.Import(typeof(T).GetMethod(methodName));
        }

        public static CustomAttribute GetDoNotInjectAttribute(AssemblyDefinition assembly, Type attribute)
        {
            var methodRef = assembly.MainModule.Import(attribute.GetConstructor(Type.EmptyTypes));
            return new CustomAttribute(methodRef);
        }

        public static bool HasAttribute(string attributeName,
            IEnumerable<CustomAttribute> customAttributes)
        {
            return GetAttributeByName(attributeName, customAttributes) != null;
        }

        public static CustomAttribute GetAttributeByName(
            string attributeName,
            IEnumerable<CustomAttribute> customAttributes)
        {
            foreach (var attribute in customAttributes)
            {
                if (attribute.AttributeType.FullName == attributeName)
                {
                    return attribute;
                }
            }
            return null;
        }
    }
}
