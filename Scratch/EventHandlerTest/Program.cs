using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*
Example 1 	Declaring an event in an interface and implementing it in a class.
Example 2 	Using a hash table to store event instances.
Example 3 	Implementing, via event properties, two interfaces that have an event with the same name.
 */
namespace EventHandlerTest
{
    public delegate void MyDelegate();
    public interface IMyEvent
    {
        event MyDelegate MyEvent;
        void FireAway();
    }

    public class MyClass : IMyEvent
    {
        public event MyDelegate MyEvent;
        public void FireAway()
        {
            if (MyEvent != null)
            {
                MyEvent();
            }
        }
    }

    class Program
    {
        static private void f()
        {
            Console.WriteLine("Delegate Called");
        }
        static void Main(string[] args)
        {
            IMyEvent myEvent = new MyClass();
            myEvent.MyEvent+= new MyDelegate(f);
            myEvent.FireAway();
        }
    }
}
