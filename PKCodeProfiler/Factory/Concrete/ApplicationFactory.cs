using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PKCodeProfiler.Factory.Abstract;

using PKCodeProfiler.ViewModel;

using PKCodeProfiler.Commands.Abstract;
using PKCodeProfiler.Commands.Concrete;

using PKCodeProfiler.Themes.Abstract;
using PKCodeProfiler.Themes.Concrete;

using PKCodeProfiler.Services.Abstract;
using PKCodeProfiler.Services.Concrete;

using PKCodeProfiler.Views.Abstract;
using PKCodeProfiler.Views.Concrete;

using PKCodeProfiler.Repository.Abstract;
using PKCodeProfiler.Repository.Concrete;

namespace PKCodeProfiler.Factory.Concrete
{
    public class ApplicationFactory : IApplicationFactory
    {
        private IUITheme currentTheme;
        private ITraceServerService traceServerService;
        private MemoryRepository memoryRepository;
        
        public ApplicationFactory()
        {
            currentTheme = new DefaultUITheme();
            memoryRepository = new MemoryRepository();
            traceServerService = new TraceServerService(memoryRepository);
        }

        public CommandTreeNode GetApplicationRootCommand(IAppMainView mainView)
        {            
            var rootNode = new CommandTreeNode
            {
                ImageIndex = 0,
                SelectedImageIndex = 0,
                Text = "Dashboard",
                ToolTipText = "Dashboard"
            };
            rootNode.Nodes.Add(CreateInstrumentationCommands(mainView));
            rootNode.Nodes.Add(CreateLocalTracesCommands(mainView));
            rootNode.Nodes.Add(CreateRemoteTracesCommands(mainView));
            rootNode.Nodes.Add(CreateLocalProfilingCommands(mainView));            
            return rootNode;
        }

        private CommandTreeNode CreateInstrumentationCommands(IAppMainView mainView)
        {
            var command = new CommandTreeNode{
                ImageIndex = 9,
                SelectedImageIndex = 9,
                Text = "Instrumentation",
                ToolTipText = "Instrumentation"
            };

            command.Nodes.Add(new CommandTreeNode{
                ImageIndex = 1,
                SelectedImageIndex = 1,
                Text = "Instrument Assembly",
                ToolTipText = "Instrument an Assembly (exe/dll)",
                Command = new ViewInstrumentationCommand(mainView, this)
            });
                                
            return command;
        }

        private CommandTreeNode CreateLocalTracesCommands(IAppMainView mainView)
        {
            var command = new CommandTreeNode
            {
                ImageIndex = 11,
                SelectedImageIndex = 11,
                Text = "Local Traces",
                ToolTipText = "In-Memory Traces",
            };            

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 2,
                SelectedImageIndex = 2,
                Text = "View Memory Traces",
                ToolTipText = "View In-Memory Traces",
                Command = new ViewMemoryTracesCommand(mainView, this, memoryRepository)
            });

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 3,
                SelectedImageIndex = 3,
                Text = "Clear Memory Traces",
                ToolTipText = "Clear In-Memory Traces",
                Command = new ClearMemoryTracesCommand(mainView, memoryRepository)
            });

            return command;
        }

        private CommandTreeNode CreateRemoteTracesCommands(IAppMainView mainView)
        {
            var command = new CommandTreeNode
            {
                ImageIndex = 10,
                SelectedImageIndex = 10,
                Text = "Remote Traces",
                ToolTipText = "Saved Traces (Database or FileSystem)",
            };

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 4,
                SelectedImageIndex = 4,
                Text = "View Database Traces",
                ToolTipText = "Remote Database Traces",
                Command = new ViewDatabaseTracesCommand(mainView, this)
            });

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 5,
                SelectedImageIndex = 5,
                Text = "View File Traces",
                ToolTipText = "FileSystem Traces",
                Command = new ViewFileTracesCommand(mainView, this)
            });

            return command;
        }

        private CommandTreeNode CreateLocalProfilingCommands(IAppMainView mainView)
        {
            var command = new CommandTreeNode
            {
                ImageIndex = 6,
                SelectedImageIndex = 6,
                Text = "Profiling",
                ToolTipText = "Local Profiling",
            };

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 7,
                SelectedImageIndex = 7,
                Text = "Start Profiling",
                ToolTipText = "Start the Local Profiling Server",
                Command = new StartProfilingCommand(mainView, traceServerService)
            });

            command.Nodes.Add(new CommandTreeNode
            {
                ImageIndex = 8,
                SelectedImageIndex = 8,
                Text = "Stop Profiling",
                ToolTipText = "Stop the Local Profiling Server",
                Command = new StopProfilingCommand(mainView, traceServerService)
            });

            return command;
        }

        public IUITheme GetCurrentTheme()
        {
            return currentTheme;
        }

        public IChildView GetInstrumentationView()
        {
            var model = new ParametersViewModel();            
            var command = new WeaveFileCommand(new CodeWeaverService(), model);

            model.Clear();

            var view = new AssemblyInstrumentationView {
                AssemblyServices = this.GetAssemblyServices(),
                WeaveCommand = command,
                Parameter = model
            };            
            return view;
        }

        public IChildView GetDatabaseTracesView()
        {
            var view = new TracesView {
                TabHeader = "Database Traces"
            };
            view.SetServices(new TraceServices(new SQLRepository()));
            return view;
        }

        public IChildView GetFileTracesView(string fileName)
        {
            var view = new TracesView
            {
                TabHeader = "File Traces"
            };
            view.SetServices(new TraceServices(new FileRepository(fileName)));
            return view;
        }

        public IChildView GetMemoryTracesView(IReadableRepository repo)
        {
            var view = new TracesView
            {
                TabHeader = "Memory Traces"
            };
            view.SetServices(new TraceServices(repo));
            return view;
        }

        public IAssemblyServices GetAssemblyServices()
        {
            return new AssemblyServices();
        }
    }
}
