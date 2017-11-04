using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace hw_02_05
{
    class Program
    {
        static void Main(string[] args)
        {
            int counter = 0;
            object objectUsedForLock = new object();
            Parallel.For(0, 100000, (i) =>
            {
                Thread.Sleep(1);
                lock (objectUsedForLock)
                {
                    counter += 1;
                }
            });
            Console.WriteLine("Counter  should  be  100000.  Counter  is {0}", counter);
        }
        public static void LongOperation(string taskName)
        {
            Thread.Sleep(1000);
            Console.WriteLine("{0}  Finished. Executing  Thread: {1}", taskName,
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
