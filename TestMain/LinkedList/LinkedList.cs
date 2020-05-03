using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedList
{
    public class LinkedList
    {
        private object first;
        private LinkedList next;

        public LinkedList(object dataValue):this(dataValue,null)
        {

        }

        public LinkedList(object dataValue, LinkedList next)
        {
            this.first = dataValue;
            this.next = next;
        }

        public object First
        {
            get { return first; }
            set { first = value; }
        }

        public LinkedList Next
        {
            get { return next; }
            set { next = value; }
        }


    }
}
