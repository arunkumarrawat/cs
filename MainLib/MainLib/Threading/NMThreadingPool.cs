using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MainLib.Threading
{
    /// <summary>
    /// 
    /// </summary>
    public class NMThreadingPool
    {
        /// <summary>
        /// Threading Pool
        /// </summary>
        public NMThreadingPool()
        {
           
        }

        /// <summary>
        /// Queue Thread
        /// </summary>
        /// <returns>Queue Thread</returns>
        public bool QueueThread(WaitCallback callback)
        {
            ThreadPool.SetMaxThreads(100, 100);
            return ThreadPool.QueueUserWorkItem(callback);
        }

        /// <summary>
        /// Get MaxWorking Threads
        /// </summary>
        public int MaxWorkingThreads
        {
            get
            {
                int workThreads = 0;
                int completionPortThreads = 0;
                ThreadPool.GetMaxThreads(out workThreads,out completionPortThreads );
                return workThreads;
            }
        }
    }
}
