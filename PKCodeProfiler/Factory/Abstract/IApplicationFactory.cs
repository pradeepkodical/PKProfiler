using System;
using PKCodeProfiler.ViewModel;
using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.Themes.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Repository.Abstract;

namespace PKCodeProfiler.Factory.Abstract
{
    public interface IApplicationFactory
    {
        CommandTreeNode GetApplicationRootCommand(IAppMainView mainView);
        IAssemblyServices GetAssemblyServices();
        IUITheme GetCurrentTheme();
        IChildView GetDatabaseTracesView();
        IChildView GetFileTracesView(string fileName);
        IChildView GetMemoryTracesView(IReadableRepository repo);
        IChildView GetInstrumentationView();
    }
}
