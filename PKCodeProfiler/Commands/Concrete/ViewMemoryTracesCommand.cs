using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Factory.Abstract;

namespace PKCodeProfiler.Commands.Concrete
{
    public class ViewMemoryTracesCommand: ICommand
    {
        private IAppMainView view;
        private IReadableRepository memoryRepository;
        private IApplicationFactory factory;
        public ViewMemoryTracesCommand(IAppMainView view, IApplicationFactory factory, IReadableRepository memoryRepository)
        {
            this.view = view;
            this.factory = factory;
            this.memoryRepository = memoryRepository;
        }
        #region ICommand Members

        public void Execute()
        {
            this.view.Add(factory.GetMemoryTracesView(memoryRepository));
        }

        #endregion        
    }
}
