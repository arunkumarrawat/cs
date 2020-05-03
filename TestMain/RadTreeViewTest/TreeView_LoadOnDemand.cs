using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace RadTreeViewTest
{
    public partial class TreeView_LoadOnDemand : Form
    {
        public TreeView_LoadOnDemand()
        {
            InitializeComponent();
            radTreeView1.LazyMode = true;
        }

        private void radTreeView1_NodesNeeded(object sender, Telerik.WinControls.UI.NodesNeededEventArgs args)
        {
            if (args.Parent == null)
            {
                LoadRoot(args.Nodes);
                return;
            }

            if (args.Parent.Text == "Favorites")
            {
                LoadFavorites(args.Nodes);
            }
            else if (args.Parent.Text == "Libraries")
            {
                LoadLibraries(args.Nodes);
                args.Parent.Expand();
            }
            else if (args.Parent.Text == "Computer")
            {
                LoadComputer(args.Nodes);
            }
            else if (args.Parent.Text == "Network")
            {
                LoadNetwork(args.Nodes);
            }
            else if (args.Parent.Text == "System")
            {
                LoadSystem(args.Nodes);
            }
        }


        private void LoadRoot(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("Favorites");
            node.ImageKey = "favorites";
            //node.TreeViewElement.ShowExpandCollapse = false;
            nodes.Add(node);

            node = new RadTreeNode("Libraries");
            node.ImageKey = "libraries";
            nodes.Add(node);

            node = new RadTreeNode("Computer");
            node.ImageKey = "computer";
            nodes.Add(node);

            node = new RadTreeNode("Network");
            node.ImageKey = "network";
            nodes.Add(node);
        }

        private void LoadFavorites(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("Work");
            node.ImageKey = "work";
            nodes.Add(node);

            node = new RadTreeNode("Downloads");
            node.ImageKey = "downloads";
            nodes.Add(node);

            node = new RadTreeNode("Desktop");
            node.ImageKey = "desktop";
            nodes.Add(node);

            node = new RadTreeNode("Virtual Machines");
            node.ImageKey = "virtual machines";
            nodes.Add(node);

            foreach (RadTreeNode r in nodes)
            {
                r.TreeView.ShowExpandCollapse = false;
            }
        }

        private void LoadLibraries(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("Documents");
            node.ImageKey = "documents";
            nodes.Add(node);

            node = new RadTreeNode("Music");
            //node.ImageKey = "music";
            nodes.Add(node);

            node = new RadTreeNode("Pictures");
            //node.ImageKey = "pictures";
            nodes.Add(node);

            node = new RadTreeNode("Videos");
            //node.ImageKey = "video";
            nodes.Add(node);
        }

        private void LoadComputer(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("System");
            node.ImageKey = "hdd";
            nodes.Add(node);

            node = new RadTreeNode("Resources");
            node.ImageKey = "network drive";
            nodes.Add(node);

            node = new RadTreeNode("Share");
            node.ImageKey = "network drive";
            nodes.Add(node);
        }

        private void LoadNetwork(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("PC1");
            node.ImageKey = "computer";
            nodes.Add(node);

            node = new RadTreeNode("PC2");
            node.ImageKey = "computer";
            nodes.Add(node);

            node = new RadTreeNode("Laptop1");
            node.ImageKey = "computer";
            nodes.Add(node);

            node = new RadTreeNode("Laptop2");
            node.ImageKey = "computer";
            nodes.Add(node);
        }

        private void LoadSystem(IList<RadTreeNode> nodes)
        {
            RadTreeNode node = new RadTreeNode("Program Files");
            node.ImageKey = "folder";
            nodes.Add(node);

            node = new RadTreeNode("Program Files (x86)");
            node.ImageKey = "folder";
            nodes.Add(node);

            node = new RadTreeNode("Users");
            node.ImageKey = "folder";
            nodes.Add(node);

            node = new RadTreeNode("Windows");
            node.ImageKey = "folder";
            nodes.Add(node);
        }
    }
}
