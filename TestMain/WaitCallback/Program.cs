using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace WaitCallback
{
    class Program
    {
        //@example: ThreadPool quit after main thread quit.
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(ThreadProc));

            Console.WriteLine("Main thread does some work");
            Thread.Sleep(6000);
            Console.WriteLine("main thread exits");


        }

        static void ThreadProc(Object stateInfo)
        {
            while (true)
            {
                Console.WriteLine("Hello from the thread pool");
                Thread.Sleep(1000);
            }
        }
    }
}
