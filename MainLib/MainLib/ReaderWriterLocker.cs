using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace MainLib
{
    /// <summary>
    /// No Finished Yet
    /// </summary>
    public class ReaderWriterLocker : IDisposable
    {
        private ReaderWriterLockSlim lockSlim = new ReaderWriterLockSlim();

        /// <summary>
        /// 
        /// </summary>
        public ReaderWriterLocker()
        {

        }

        public void Dispose()
        {
            if(lockSlim!=null)
                lockSlim.Dispose();
        }

        public bool EnterReadLock()
        {
            bool result = true;
            if(lockSlim.IsReadLockHeld)
            {

            }

            lockSlim.EnterReadLock();

            return result;
        }

        public bool ExitReadLock()
        {
            bool result = true;
            if (lockSlim.IsReadLockHeld)
            {

            }

            lockSlim.ExitReadLock();

            return result;
        }

    }
}
