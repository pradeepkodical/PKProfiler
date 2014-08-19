using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKTracer.Framework.Model;


namespace PKCodeProfiler.Repository.Abstract
{
    public interface IWritableRepository
    {
        void AddRange(TraceItem[] arr);
        void Clear();
        void Add(TraceItem arr);
    }
}
