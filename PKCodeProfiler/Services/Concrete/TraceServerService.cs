using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;
using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKTracer.Framework.Server;
using PKTracer.Framework.Model;
using PKTracer.Framework.Tracer;


namespace PKCodeProfiler.Services.Concrete
{
    public class TraceServerService: ITraceServerService
    {
        private TraceServer traceServer;
        private IWritableRepository repo;        

        public TraceServerService(IWritableRepository repo)
        {
            this.repo = repo;            
        }

        #region ITraceServerService Members

        public void StartServer()
        {
            if (traceServer == null)
            {
                traceServer = new TraceServer();
                traceServer.Received += new Action<TraceItem>((arr) =>
                {
                    repo.Add(arr);
                });
                ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
                {
                    traceServer.Listen();
                }));                
            }
        }

        public void StopServer()
        {
            if (traceServer != null)
            {
                using (new ItemTracer("Terminator", "Terminator"))
                {
                    traceServer.StopServer = true;
                }
                traceServer = null;                
            }
        }

        #endregion
    }
}
