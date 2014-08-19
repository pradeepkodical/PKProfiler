using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

using PKTracer.Framework.Model;

namespace PKTracer.Framework.Tracer
{
    /// <summary>
    /// 
    /// </summary>
    public class ExceptionTracer : ItemTracer
    {
        public ExceptionTracer(string assemblyName, string str)
            : base(assemblyName, str)
        { 
        }

        protected override TraceItem FixBeginTraceItem(TraceItem item)
        {
            item.IsException = true;
            return item;
        }

        protected override TraceItem FixEndTraceItem(TraceItem item)
        {
            item.IsException = true;
            return item;
        }
    }
}
