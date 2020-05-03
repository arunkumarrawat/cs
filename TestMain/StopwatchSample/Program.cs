using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace StopwatchSample
{
    //@example: stop watch
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch stopWatch = new Stopwatch();
            for (int i = 0; i < 10; i++)
            {
                stopWatch.Start();
                string str = "a b c d e f g h i j k l m n o p q r s t u v w x y z";
                str = str.Replace(" ", "");
                stopWatch.Stop();
                Console.WriteLine(stopWatch.Elapsed.TotalMilliseconds);
            }
            // Get the elapsed time as a TimeSpan value.
            TimeSpan ts = stopWatch.Elapsed;

            // Format and display the TimeSpan value.
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10);
            Console.WriteLine("RunTime " + elapsedTime);
        }
    }
}
