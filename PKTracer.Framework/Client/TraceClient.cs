using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO.Pipes;
using System.Security.Principal;
using System.IO;

using PKTracer.Framework.Model;
using PKTracer.Framework.Utility;

namespace PKTracer.Framework.Client
{
    internal class TraceClient
    {
        private static DateTime LastFailedToConnect { get; set; }
        private static bool failedToConnect;
        public static bool FailedToConnect
        { 
            get
            {
                return failedToConnect && (DateTime.Now.Subtract(LastFailedToConnect).Minutes < 5);
            }
            private set
            {
                failedToConnect = value;
            }
        }

        public static long _uid;
        public static long _id;
        public static long GetNextUid()
        {
            Interlocked.Increment(ref _uid);
            return _uid;
        }
        public static long GetNextId()
        {
            Interlocked.Increment(ref _id);
            return _id;
        }
        
        public static void PostAsync(TraceItem item)
        {
            if (!FailedToConnect)
            {
                PostMessage(XmlUtil.SerializeObject(item));
            }
        }

        private static void PostMessage(string strContents)
        {
            try
            {
                using (var pipeClient =
                        new NamedPipeClientStream(
                            ".",
                            "agentOftheGreenEyedMan",
                            PipeDirection.InOut,
                            PipeOptions.None,
                            TokenImpersonationLevel.Anonymous))
                {
                    if (!pipeClient.IsConnected)
                    {
                        pipeClient.Connect(1000);
                    }
                    using (var sw = new StreamWriter(pipeClient))
                    {
                        sw.WriteLine(strContents);
                        sw.Flush();
                    }
                    pipeClient.Close();
                }
            }
            catch
            {
                FailedToConnect = true;
                LastFailedToConnect = DateTime.Now;
            }
        }
    }
}
