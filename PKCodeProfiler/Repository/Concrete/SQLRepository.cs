using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Model;
using PKTracer.Framework.Model;

namespace PKCodeProfiler.Repository.Concrete
{
    public class SQLRepository: IReadableRepository
    {
        #region IRepository Members

        public List<TraceItem> GetTraceItems(TraceGroupViewModel group)
        {
            using (var context = new TraceDataContext())
            {
                return context.TestTraceLogs
                    .Where(x => 
                        x.GroupKey == group.GroupKey 
                        && 
                        x.UserKey.Contains(group.UserKey)
                        &&
                        x.HostName.Contains(group.HostName)
                        && 
                        x.EventDate >= group.StartDate 
                        && 
                        x.EventDate <= group.EndDate)
                    .OrderBy(x => x.GroupKey)
                    .ThenBy(x => x.EventDate)
                    .ThenBy(x => x.TraceOrderBy)
                    .Select(x => new TraceItem { 
                        EventDate = x.EventDate,
                        EventDescription = x.EventDescription,
                        EventType = x.EventType,
                        GroupKey = x.GroupKey,
                        TraceKey = x.TraceKey,
                        TraceOrderBy = x.TraceOrderBy,
                        UserKey = x.UserKey,
                        AssemblyName = x.AssemblyName,
                        CurrentTick = x.CurrentTick,
                        IsException = x.IsException,
                        MemoryUsage = x.MemoryUsage,
                        Parameters = x.Parameters,
                        HostName = x.HostName
                    })
                    .ToList();
            }
        }

        public List<string> GetTraceList(TraceGroupViewModel group)
        {
            using (var context = new TraceDataContext())
            {
                return context.TestTraceLogs
                    .Where(x => 
                        x.UserKey.Contains(group.UserKey)
                        &&
                        x.HostName.Contains(group.HostName)
                        &&
                        x.EventDate >= group.StartDate 
                        && 
                        x.EventDate <= group.EndDate)
                    .Select(x => x.GroupKey)
                    .Distinct()
                    .ToList();
            }
        }

        #endregion
    }
}
