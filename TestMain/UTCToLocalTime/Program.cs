using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UTCToLocalTime
{
    //@example: UTC to Local Time DateTime 
    class Program
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.UtcNow;
            DateTime myDt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local);
            Console.WriteLine(myDt);
        }
    }
}
