using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.ViewModel;
using PKCodeWeaver.Framework.Model;

namespace PKCodeProfiler.Commands.Concrete
{
    public class WeaveFileCommand: ICommand
    {
        private IWeaveParameters parameter;        
        private ICodeWeaverService service;
        public WeaveFileCommand(ICodeWeaverService service, IWeaveParameters parameter)
        {
            this.parameter = parameter;
            this.service = service;
        }
        #region ICommand Members

        public void Execute()
        {
            this.service.Process(parameter);
        }

        #endregion        
    }
}
