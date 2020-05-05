using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Telerik.WinControls.UI;

namespace DelegateParameter
{
    [Serializable]
    public class MyClass
    {
        public string myFieldA;
        
        public string myFieldB;
        public MyClass()
        {
            myFieldA = "A public field";
            myFieldB = "Another public field";
        }

        private void print()
        {
            Console.WriteLine("Hi, how can you call private method?");
        }
    }

    class Program
    {

        private static void foo1(string name)
        {
            Console.WriteLine(name + "in function foo1");
        }

        private static void foo2(string name)
        {
            Console.WriteLine(name + "in function foo2");
        }

        private delegate void FooDelegate(string name);

        private static void Stub(string name, FooDelegate fooDelegate)
        {
            fooDelegate(name);
        }

        static void Main(string[] args)
        {
            //Stub("foo1", foo1);
            //Stub("foo2", foo2);

            MyClass myInstance = new MyClass();
            // Get the type of MyClass.
            Type myType = typeof(RadContextMenu);
            try
            {
                // Get the FieldInfo of MyClass.
                FieldInfo[] myFields = myType.GetFields(/*BindingFlags.Public
                    | BindingFlags.Instance|*/ BindingFlags.NonPublic);

                //myType.GetCustomAttributes
                // Display the values of the fields.
                Console.WriteLine("\nDisplaying the values of the fields of {0}.\n",
                    myType);

                //MethodInfo mi = myFields[0];
                //mi.Invoke(myInstance, new object[] { });
                //for (int i = 0; i < myFields.Length; i++)
                //{
                //    Console.WriteLine("The value of {0} is: {1}",
                //        myFields[i].Name, myFields[i].GetValue(myInstance));
                //}
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception : {0}", e.Message);
            }

        }
    }
}
