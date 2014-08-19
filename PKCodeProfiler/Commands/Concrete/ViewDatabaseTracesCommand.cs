using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Factory.Abstract;

namespace PKCodeProfiler.Commands.Concrete
{
    public class ViewDatabaseTracesCommand: ICommand
    {
        private IAppMainView view;
        private IApplicationFactory factory;
        public ViewDatabaseTracesCommand(IAppMainView view, IApplicationFactory factory)
        {
            this.view = view;
            this.factory = factory;
        }
        #region ICommand Members
        
        public void Execute()
        {
            this.view.Add(factory.GetDatabaseTracesView());
        }

        #endregion        
    }
}
