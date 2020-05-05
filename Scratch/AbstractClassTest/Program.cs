using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AbstractClassTest
{
    public abstract class parent
    {
        private int controller;

        public virtual int Controller
        {
            get { return controller; }
            set { controller = value; }
        }
    }

    public class children : parent
    {
        private children2 child;
        public children2 Children2
        {
            get
            {
                if (child == null)
                {
                    child = new children2();
                    child.Controller = Controller;
                }
                return child;
            }
            set
            {
                child = value;
            }
        }
        public override int Controller
        {
            get { return base.Controller; }
            set { base.Controller = value + 1; }
        }
    }

    public class children2 : parent
    {
        public override int Controller
        {
            get
            {
                return base.Controller;
            }
            set
            {
                base.Controller = value+2;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            children p = new children();
            p.Controller = 3;
            

            Console.WriteLine(p.Controller);
            Console.WriteLine(p.Children2.Controller);
        }
    }
}
