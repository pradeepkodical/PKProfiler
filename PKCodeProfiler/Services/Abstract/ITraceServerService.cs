using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PKCodeProfiler.Services.Abstract
{
    public interface ITraceServerService
    {
        void StartServer();
        void StopServer();
    }
}
