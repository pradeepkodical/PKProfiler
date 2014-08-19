using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Repository.Abstract;

namespace PKCodeProfiler.Commands.Concrete
{
    public class ClearMemoryTracesCommand: ICommand
    {
        private IAppMainView view;
        private IWritableRepository memoryRepository;
        public ClearMemoryTracesCommand(IAppMainView view, IWritableRepository memoryRepository)
        {
            this.view = view;
            this.memoryRepository = memoryRepository;
        }
        #region ICommand Members

        public void Execute()
        {
            this.memoryRepository.Clear();
            this.view.SetMessage("All Trace items in memory cache has been removed");
        }

        #endregion        
    }
}
