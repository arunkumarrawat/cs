using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace PropertyGridTest
{
    public partial class Form1 : Form
    {
        public class AnimalTypeAttribute : Attribute
        {
            public AnimalTypeAttribute(int pet)
            {
                thePet = pet;
            }

            // Keep a variable internally ...
            protected int thePet;

            // .. and show a copy to the outside world.
            public int Pet
            {
                get { return thePet; }
                set { thePet = value; }
            }
        }

        public class Test
        {

            public void Calc(int i)
            {

            }

            [AnimalTypeAttribute(2)]
            public int CalcTest(int i, int j)
            {
                return i + j;
            }

            [AnimalTypeAttribute(1)]
            public int TestMember { get; set; }
        }

        public Form1()
        {
            InitializeComponent();
            colorPanel1.ColorChanged += new PropertyGridTest.ColorPanel.ColorChangedEventHandler(colorPanel1_ColorChanged);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void colorPanel1_ColorChanged(object sender, EventArgs e)
        {
            ColorPanel p = sender as ColorPanel;
            this.BackColor = p.HatchColor;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MemberInfo[] memberInfo = typeof(Test).GetMembers();

            foreach (MemberInfo m in memberInfo)
            {
                if (m.MemberType == MemberTypes.Method)
                {
                    object[] methodObject = ((MethodInfo)m).GetCustomAttributes(true);

                    if (methodObject.Length == 1)
                    {
                        MethodInfo mi = (MethodInfo) m;

                        ParameterInfo[] pi = mi.GetParameters();

                        
                    }
                }
            }

            TextBox textBox = new TextBox();

            Test t = Activator.CreateInstance<Test>();

            

        }
    }
}
