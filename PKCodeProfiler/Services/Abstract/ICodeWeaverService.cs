using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeWeaver.Framework.Model;


namespace PKCodeProfiler.Services.Abstract
{
    public interface ICodeWeaverService
    {
        void Process(IWeaveParameters parameters);
    }
}
