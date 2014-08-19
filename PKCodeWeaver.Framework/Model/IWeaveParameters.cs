using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKCodeWeaver.Framework.Model
{
    public interface IWeaveParameters
    {
        bool IISReset { get; }
        bool DecodeParameters { get; }
        List<string> IncludeClasses { get; }
        string AssemblySignKeyFile { get; }
        string FileName { get; }
    }    
}
