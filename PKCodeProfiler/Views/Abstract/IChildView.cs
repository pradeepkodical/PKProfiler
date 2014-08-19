using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PKCodeProfiler.Themes.Abstract;

namespace PKCodeProfiler.Views.Abstract
{
    public interface IChildView
    {
        event Action OnToggleFullScreen;
        event Action<string> OnSetMessage;
        event Action<IChildView> Close;
        IUITheme Theme { set; }
        BaseChildView ChildControl { get; }
        string TabHeader { get; }        
    }
}
