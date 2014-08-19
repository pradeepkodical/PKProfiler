using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Model;

using PKTracer.Framework.Model;
using PKTracer.Framework.Tracer;

namespace PKCodeProfiler.Repository.Concrete
{
    public class MemoryRepository : IReadableRepository, IWritableRepository
    {
        List<TraceItem> items = new List<TraceItem>();
        #region IRepository Members

        public List<TraceItem> GetTraceItems(TraceGroupViewModel group)
        {
            lock (items)
            {
                using (new DebugTracer("GetTraceItems"))
                {
                    return items
                            .Where(x =>
                                x.GroupKey == group.GroupKey &&
                                x.EventDate >= group.StartDate &&
                                x.EventDate <= group.EndDate)
                            .OrderBy(x => x.GroupKey)
                            .ThenBy(x => x.EventDate)
                            .ThenBy(x => x.TraceOrderBy)
                            .ToList();
                }
            }
        }

        public List<string> GetTraceList(TraceGroupViewModel group)
        {
            lock (items)
            {
                return items
                    .Where(x => x.EventDate >= group.StartDate && x.EventDate <= group.EndDate)
                    .Select(x => x.GroupKey).Distinct().ToList();
            }
        }

        #endregion

        #region IWritableRepository Members
        public void Clear()
        {
            lock (items)
            {
                items.Clear();
            }
        }
        public void Add(TraceItem item)
        {
            lock (items)
            {
                items.Add(item);
            }
        }
        public void AddRange(TraceItem[] arr)
        {
            lock (items)
            {
                items.AddRange(arr);
            }
        }
        #endregion
    }
}
