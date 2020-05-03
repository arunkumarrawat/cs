using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RadTreeViewTest.TimeSchedule
{
    [Serializable]
    public class TimeScheduleTest
    {
        public TimeScheduleTest()
        {
            Day = new TimeScheduleDay();
        }

        public TimeScheduleDay Day { get; set; }
        public string ObjectName { get; set; }
        public bool Checked { get; set; }

    }



    [Serializable]
    public class TimeScheduleDay    
    {
        public TimeScheduleDay()
        {
            Span = new TimeScheduleSpan();    
        }

        public TimeScheduleSpan Span { get; set; }
    }

    public enum ReaderMode
    {
        None,
        PIN,
        CardPIN,
    }

    [Serializable]
    public class TimeScheduleSpan
    {

        public TimeSpan TS
        {
            get;
            set;
        }

        public ReaderMode ReaderMode
        {
            get; 
            set;
        }
    }
}
