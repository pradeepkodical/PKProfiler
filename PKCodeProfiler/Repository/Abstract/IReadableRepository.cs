using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.ViewModel;
using PKTracer.Framework.Model;

namespace PKCodeProfiler.Repository.Abstract
{
    public interface IReadableRepository
    {
        List<String> GetTraceList(TraceGroupViewModel group);
        List<TraceItem> GetTraceItems(TraceGroupViewModel group);
    }
}
