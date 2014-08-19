using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Services.Abstract;

using PKCodeWeaver.Framework.Model;
using PKCodeWeaver.Framework.Injectors.Concrete;

namespace PKCodeProfiler.Services.Concrete
{
    public class CodeWeaverService
        : ICodeWeaverService
    {
        #region ICodeWeaverService Members

        public void Process(IWeaveParameters parameters)
        {
            var weaver = new TraceInjector(parameters);
            weaver.Process();
        }

        #endregion
    }
}
