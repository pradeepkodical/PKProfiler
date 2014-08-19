using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.IO;
using System.Threading;
using System.Security.Principal;
using System.Security.AccessControl;

using PKTracer.Framework.Queue;
using PKTracer.Framework.Model;
using PKTracer.Framework.Utility;

namespace PKTracer.Framework.Server
{
    public class TraceServer
    {
        private static BlockingQueue<string> queue = new BlockingQueue<string>(100000);        
        public event Action<TraceItem> Received;
        public bool StopServer { get; set; }
        public TraceServer()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback((o) =>
            {
                string strContents;
                while (queue.Dequeue(out strContents))
                {
                    Process(strContents);
                }                
            }));
        }

        private void Process(string strContents)
        {
            try
            {
                var item = XmlUtil.Deserialize<TraceItem>(strContents);
                if (Received != null)
                {
                    Received(item);
                }
            }
            catch
            { 
            }
        }        

        public void Listen()
        {
            var sid = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
            var rule = new PipeAccessRule(sid, PipeAccessRights.ReadWrite,
                                          AccessControlType.Allow);
            var sec = new PipeSecurity();
            sec.AddAccessRule(rule);

            using (NamedPipeServerStream pipeServer = new NamedPipeServerStream
                  ("agentOftheGreenEyedMan", PipeDirection.InOut, 100,
                   PipeTransmissionMode.Byte, PipeOptions.None, 0, 0, sec))
            {
                do
                {
                    pipeServer.WaitForConnection();
                    var sr = new StreamReader(pipeServer);
                    var strContents = sr.ReadToEnd();
                    pipeServer.Disconnect();
                    queue.Enqueue(strContents);

                } while (!StopServer);
            }
            System.Diagnostics.Debug.Write("Test");
        }
    }
}
