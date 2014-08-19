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
    public class StartProfilingCommand: ICommand
    {
        private IAppMainView view;
        private ITraceServerService traceService;
        public StartProfilingCommand(IAppMainView view, ITraceServerService traceService)
        {
            this.view = view;
            this.traceService = traceService;
        }
        #region ICommand Members

        public void Execute()
        {
            this.view.SetStatus("Starting Profiling...");
            traceService.StartServer();
            this.view.SetStatus("Profiling Started");
        }

        #endregion        
    }
}
