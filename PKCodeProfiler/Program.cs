using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using PKCodeProfiler.Views.Concrete;
using PKCodeProfiler.Factory.Concrete;

namespace PKCodeProfiler
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);            
            Application.Run(new ApplicationMainView { 
                Factory = new ApplicationFactory()
            });
        }
    }
}
