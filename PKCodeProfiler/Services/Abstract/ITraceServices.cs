using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Model;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.ViewModel;

namespace PKCodeProfiler.Services.Abstract
{
    public interface ITraceServices
    {
        IReadableRepository Repository { get; }
        List<string> GetTraceList(TraceGroupViewModel tg);
        TraceTreeNode GetTraceViewModel(TraceGroupViewModel tg);
        TraceGroupViewModel GetTraceGroupViewModel();
    }
}
