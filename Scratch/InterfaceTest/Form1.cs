using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace InterfaceTest
{
    interface IDrawable
    {
        void Draw();
    }

    interface ISurface
    {
        void PopUp();
        void Draw();
    }

    public class MyMessage : IDrawable, ISurface
    {
        void IDrawable.Draw()
        {
            MessageBox.Show("This is the Draw from IDrawable interface");
        }

        void ISurface.Draw()
        {
            MessageBox.Show("This is the Draw from ISurface interface");
        }

        public void Draw()
        {
            MessageBox.Show("This is the Draw from MyMessage");
        }

        public void PopUp()
        {
            MessageBox.Show("MyMessage popup");
        }

        void ISurface.PopUp()
        {
            MessageBox.Show("ISurface popup");
        }
    }

    public partial class Form1 : Form
    {
        MyMessage my;
        public Form1()
        {
            InitializeComponent();
            my = new MyMessage();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            my.Draw();
            ((ISurface)my).Draw();
            ((IDrawable)my).Draw();
        }
    }
}
