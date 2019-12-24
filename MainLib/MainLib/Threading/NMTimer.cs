using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace MainLib.Threading
{
    public class NMTimer
    {
        private Timer timer = null;

        /// <summary>
        /// seconds of interval
        /// </summary>
        /// <param name="interval"></param>
        public NMTimer(int interval, ElapsedEventHandler timerHandler)
        {
            timer = new Timer(interval);
            timer.Elapsed += timerHandler;

            timer.AutoReset = true;
            timer.Enabled = true;
        }


        public void Stop()
        {
            timer.Stop();
            timer.Dispose();
        }
    }
}
