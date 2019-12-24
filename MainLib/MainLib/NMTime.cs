using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Time helper
    /// </summary>
    public class NMTime
    {
        public NMTime()
        {
            
        }

        /// <summary>
        /// DateTimeToformatString
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public string DateTimeToFormatString(DateTime dt)
        {
            return dt.ToString("dd/MM/YYYY");
        }

        // UTC convert to local time
        public DateTime UTCToLocalTime(DateTime dt)
        {
            //DateTime dt = DateTime.UtcNow;
            DateTime myDt = TimeZoneInfo.ConvertTime(dt, TimeZoneInfo.Local);
            //Console.WriteLine(myDt);
            return myDt;
        }

        public void UTCToLocalTimeTest()
        {
            DateTime dt = DateTime.UtcNow;
            DateTime myDt = UTCToLocalTime(dt);
            System.Diagnostics.Trace.WriteLine(myDt);
        }

        /// <summary>
        /// get all time zone info in system
        /// </summary>
        /// <returns></returns>
        public List<TimeZoneInfo> ListAllTimeZone()
        {
            List<TimeZoneInfo> timeZoneInfo = new List<TimeZoneInfo>();
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                timeZoneInfo.Add(z);

            return timeZoneInfo;
        }
    }
}
