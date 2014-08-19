using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PKTracer.Framework.Queue
{
    public class BlockingQueue<T>
    {
        private readonly int size = 0;
        private readonly Queue<T> queue = new Queue<T>();
        private readonly object key = new object();
        private bool quit = false;

        public BlockingQueue(int size)
        {
            this.size = size;
        }

        public void Quit()
        {
            lock (key)
            {
                quit = true;
                Monitor.PulseAll(key);
            }
        }

        public bool Enqueue(T item)
        {
            lock (key)
            {
                while (!quit && queue.Count >= size)
                {
                    Monitor.Wait(key);
                }
                if (quit)
                {
                    return false;
                }
                queue.Enqueue(item);
                Monitor.PulseAll(key);
            }
            return true;
        }

        public bool Dequeue(out T item)
        {
            item = default(T);

            lock (key)
            {
                while (!quit && queue.Count == 0)
                {
                    Monitor.Wait(key);
                }
                if (queue.Count == 0)
                {
                    return false;
                }
                item = queue.Dequeue();
                Monitor.PulseAll(key);
            }

            return true;
        }
    }
}
