using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RadTreeViewTest.TimeSchedule
{
    public partial class TimeSchedule : Form
    {
        List<TimeScheduleTest> timeScheduleList = new List<TimeScheduleTest>();

        List<ReaderModeList> readerMostList = new List<ReaderModeList>(); 

        private BindingSource bs;
        private BindingManagerBase bindingManager;
        public TimeSchedule()
        {
            InitializeComponent();

            init();
        }

        private void init()
        {
            TimeScheduleTest t = new TimeScheduleTest();
            t.Day.Span.TS= new TimeSpan(1,2,3);
            t.ObjectName = "Time Schedule 1";
            TimeScheduleTest t2 = new TimeScheduleTest();
            t2.Day.Span.TS = new TimeSpan(2, 2, 3);
            t2.ObjectName = "Time Schedule 2";

            timeScheduleList.Add(t);
            timeScheduleList.Add(t2);

            bs = new BindingSource();
            bs.DataSource = timeScheduleList;

            bindingManager = this.BindingContext[bs];



            radListControl1.DataSource = bs;
            radListControl1.DisplayMember = "ObjectName";

            //timeScheduleCell1.RadCheckBox1.Visible = !timeScheduleCell1.RadCheckBox1.Visible;

            //timeSpanControl1.DataBindings.Add("CustomTimeSpan", bs, "Day.Span.TS", true,DataSourceUpdateMode.OnPropertyChanged);

            foreach (ReaderMode r in System.Enum.GetValues(typeof(ReaderMode)))
                readerMostList.Add(new ReaderModeList(r.ToString(), r));

            radDropDownList2.DataSource = readerMostList;
            radDropDownList2.DisplayMember = "Name";
            radDropDownList2.ValueMember = "ReaderMode";

            radDropDownList2.DataBindings.Add("SelectedValue", bs, "Day.Span.ReaderMode", true, DataSourceUpdateMode.OnPropertyChanged);
            //radListControl1.DataBindings.Add("SelectedValue", bs, "Day.Span.ReaderMode", true, DataSourceUpdateMode.OnPropertyChanged);
            
            radRadioButton1.DataBindings.Add("IsChecked", bs, "Checked", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //radDropDownList2.Visible = !radDropDownList2.Visible;
            int i = 0;
        }

        private class ReaderModeList
        {
            public ReaderModeList(string s, ReaderMode rm)
            {
                Name = s;
                ReaderMode = rm;
            }

            public string Name
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
}
