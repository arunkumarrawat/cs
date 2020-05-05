using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventArgsTest
{
    public class FireEventArgs : EventArgs
    {
        public FireEventArgs(string room, int ferocity)
        {
            this.room = room;
            this.ferocity = ferocity;
        }

        public string room;
        public int ferocity;
    }	
    
    public class FireAlarm
    {

        public delegate void FireEventHandler(object sender, FireEventArgs fe);

        public event FireEventHandler FireEvent;

        public void ActivateFireAlarm(string room, int ferocity)
        {
            FireEventArgs fireArgs = new FireEventArgs(room, ferocity);
            
            FireEvent(this, fireArgs);
        }
    }	
    

    class FireHandlerClass
    {
        public FireHandlerClass(FireAlarm fireAlarm)
        {
            fireAlarm.FireEvent += new FireAlarm.FireEventHandler(ExtinguishFire);
        }

        void ExtinguishFire(object sender, FireEventArgs fe)
        {

            Console.WriteLine("\nThe ExtinguishFire function was called by {0}.", sender.ToString());

            if (fe.ferocity < 2)
                Console.WriteLine("This fire in the {0} is no problem.  I'm going to pour some water on it.", fe.room);
            else if (fe.ferocity < 5)
                Console.WriteLine("I'm using FireExtinguisher to put out the fire in the {0}.", fe.room);
            else
                Console.WriteLine("The fire in the {0} is out of control.  I'm calling the fire department!", fe.room);
        }
    }	

    class Program
    {
        static void Main(string[] args)
        {
            FireAlarm myFireAlarm = new FireAlarm();
            FireHandlerClass myFireHandler = new FireHandlerClass(myFireAlarm);
            
            myFireAlarm.ActivateFireAlarm("Kitchen", 3);
            myFireAlarm.ActivateFireAlarm("Study", 1);
            myFireAlarm.ActivateFireAlarm("Porch", 5);
        }
    }
}
