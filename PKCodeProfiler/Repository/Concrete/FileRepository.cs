using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Repository.Abstract;
using PKTracer.Framework.Model;
using PKTracer.Framework.Utility;

namespace PKCodeProfiler.Repository.Concrete
{
    internal class FileRepository : IReadableRepository
    {
        private string fileName;
        public FileRepository(string fileName)
        {
            this.fileName = fileName;
        }
        #region IReadableRepository Members

        public List<string> GetTraceList(TraceGroupViewModel group)
        {
            return new List<string> { "Test" };
        }

        public List<TraceItem> GetTraceItems(TraceGroupViewModel group)
        {
            return XmlUtil.Deserialize<List<TraceItem>>(File.ReadAllText(fileName));
        }

        #endregion
    }
}
