using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Threading;

namespace RadTreeViewTest
{
    public partial class TreeView_Performance : Form
    {
        DateTime time;
        bool working;
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeView_Performance));

        public TreeView_Performance()
        {
            InitializeComponent();

            this.radTreeViewDemo.NodeFormatting += new TreeNodeFormattingEventHandler(radTreeViewDemo_NodeFormatting); 
            this.radTreeViewDemo.TreeViewElement.Text = "Click the Load buton to load nodes"; 
            this.radTreeViewDemo.TreeViewElement.TextWrap = true;
            this.radTreeViewDemo.TreeViewElement.TextAlignment = ContentAlignment.MiddleCenter;
        }

        void StartWaiting()
        {
            this.radBtnLoad.Enabled = false;
            working = true;
            time = DateTime.Now;
            this.radTreeViewDemo.BeginUpdate();
            this.radProgressBar1.Value1 = 0;
        }

        void EndWaiting()
        {
            this.radTreeViewDemo.EndUpdate();
            this.radProgressBar1.Value1 = 100;
            TimeSpan end = DateTime.Now.Subtract(time);
            this.radLabel1.Size = new Size(100, 20);
            radLabel1.Text = "Time elapsed: " + end.TotalSeconds.ToString("#.##") + " sec";
            working = false;
            this.radBtnLoad.Enabled = true;
        }

        void LoadNodes(object state)
        {
            int index = 0;

            this.Invoke((MethodInvoker)delegate() { StartWaiting(); });
            this.Invoke((MethodInvoker)delegate() { this.radTreeViewDemo.Nodes.Clear(); });

            for (int i = 0; i < 3125; i++)
            {
                index++;
                RadTreeNode node = new RadTreeNode("Node" + index);

                for (int j = 0; j < 5; j++)
                {
                    index++;
                    RadTreeNode child = new RadTreeNode("Node" + index);
                    node.Nodes.Add(child);
                    for (int p = 0; p < 2; p++)
                    {
                        index++;
                        RadTreeNode childChild = new RadTreeNode("Node" + index);
                        child.Nodes.Add(childChild);
                    }

                }
                this.Invoke((MethodInvoker)delegate()
                {
                    this.radTreeViewDemo.Nodes.Add(node);
                    //this.radProgressBar1.Value1 = (index*100/31250);
                });
            }
            this.Invoke((MethodInvoker)delegate() { EndWaiting(); });
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.radTreeViewDemo.AllowAdd = true;
            this.radTreeViewDemo.AllowRemove = true;
        }

        private void radBtnLoad_Click(object sender, EventArgs e)
        {
            this.radTreeViewDemo.TreeViewElement.Text = "";

            if (!working)
            {
                ThreadPool.QueueUserWorkItem(new WaitCallback(LoadNodes));
            }
        }

        private void radTreeViewDemo_NodeFormatting(object sender, TreeNodeFormattingEventArgs e)
        {
            e.NodeElement.ImageElement.Image = (Image)resources.GetObject("Image1");
        }
    }
}
