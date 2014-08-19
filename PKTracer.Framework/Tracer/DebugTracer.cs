using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace PKTracer.Framework.Tracer
{
    public class DebugTracer:IDisposable
    {
        DateTime startDate;
        string methodName;
        public DebugTracer(string method)
        {
            startDate = DateTime.Now;
            methodName = method;
        }
        #region IDisposable Members

        public void Dispose()
        {
            Debug.WriteLine(string.Format("Time Taken: {0} - {1} ", DateTime.Now.Subtract(startDate).TotalMilliseconds, methodName));
        }

        #endregion
    }
}
