using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;

namespace xdel
{
    class Program
    {
        public sealed class DisplayExpressionAttribute : Attribute
        {
        }
        public class TestClass
        {

            [DisplayExpressionAttribute]
            public void Test()
            {
                
            }
        }


        //@todo: remove all folder name with same name, logical should be very simple.
        static void Main(string[] args)
        {
            
        }
    }
}
