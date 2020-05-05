using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RadGridViewTest1
{
    public partial class Form1 : Form
    {
        private Dictionary<string, ITest> dict = new Dictionary<string, ITest>();

        public enum MacroType
        {
            TypeOne,
            TypeTwo
        }

        public interface ITest
        {

        }

        public class NodeOne : ITest
        {
            public string Name { get; set; }
            public int Length { get; set; }
        }

        public class NodeTwo : ITest
        {
            public MacroType MacroType { get; set; }
            public string Name { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dict.Add("NodeOne", new NodeOne());
            dict.Add("NodeTwo", new NodeTwo());

            //radDropDownList1.DataSource = dict.Keys;

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Panel panel = new System.Windows.Forms.Panel();

            panel.Dock = DockStyle.Top;
            panel.Name = "Panel4";
            panel.Controls.Add(new Button(){Text = "Test" + (this.panel1.Controls.Count + 1)});
            panel.Location = new Point(0, 100 * panel1.Controls.Count);

            this.panel1.Controls.Add(panel);
        }
    }
}
