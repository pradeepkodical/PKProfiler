using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKTracer.Framework.Model
{
    public class TraceItem
    {
        public string AssemblyName { get; set; }
        public long TraceOrderBy { get; set; }
        public long TraceKey { get; set; }
        public string EventType { get; set; }
        public long CurrentTick { get; set; }
        public DateTime EventDate { get; set; }
        public string EventDescription { get; set; }
        public string GroupKey { get; set; }
        public string UserKey { get; set; }
        public bool IsException { get; set; }
        public string Parameters { get; set; }
        public long MemoryUsage { get; set; }
        public string HostName { get; set; }
        public string Ticket { get; set; }
    }
}
