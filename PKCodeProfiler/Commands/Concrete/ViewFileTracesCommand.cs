using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Factory.Abstract;

namespace PKCodeProfiler.Commands.Concrete
{
    public class ViewFileTracesCommand: ICommand
    {
        private IAppMainView view;
        private IApplicationFactory factory;
        public ViewFileTracesCommand(IAppMainView view, IApplicationFactory factory)
        {
            this.view = view;
            this.factory = factory;
        }
        #region ICommand Members

        public void Execute()
        {
            using (var dialog = new OpenFileDialog
            {
                Filter = "PK Trace Files|*.pktrc",
                FileName = "",
                Title = "Open an exisiting PK Trace file"
            })
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    this.view.Add(factory.GetFileTracesView(dialog.FileName));
                }
            }
        }

        #endregion        
    }
}
