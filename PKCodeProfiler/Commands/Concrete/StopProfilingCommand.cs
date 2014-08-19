using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Views.Concrete;
using PKCodeProfiler.Repository;

using System.Threading;
using PKCodeProfiler.Services.Abstract;

namespace PKCodeProfiler.Commands.Concrete
{
    public class StopProfilingCommand: ICommand
    {
        private IAppMainView view;
        private ITraceServerService traceService;
        public StopProfilingCommand(IAppMainView view, ITraceServerService traceService)
        {
            this.view = view;
            this.traceService = traceService;
        }
        #region ICommand Members

        public void Execute()
        {
            this.view.SetStatus("Stopping Profiling...");
            this.traceService.StopServer();
            this.view.SetStatus("Profiling Stopped");
        }

        #endregion        
    }
}
