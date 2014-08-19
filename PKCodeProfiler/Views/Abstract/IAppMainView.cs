using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Repository;

namespace PKCodeProfiler.Views.Abstract
{
    public interface IAppMainView
    {
        void Add(IChildView view);
        void SetMessage(string message);
        void SetStatus(string statusMessage);
    }
}
