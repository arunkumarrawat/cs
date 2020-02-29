using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// all functions related with Enum
    /// </summary>
    public class CEnum
    {
        private enum EnumTest
        {
            Test1,
            Test2,
            Test3
        };

        enum EmpType : byte
        {
            Manager = 10,
            Grunt = 1,
            Contractor = 100,
            VicePresident = 9
        }

        /// <summary>
        /// print out all information for Enum
        /// </summary>
        public void EnumInfo()
        {
            EmpType e = EmpType.Manager;

            Console.WriteLine("Enum Name: " + e.GetType().Name);
            Console.WriteLine("Underlying storage type: {0}",
              Enum.GetUnderlyingType(e.GetType()));
        }

        /// <summary>
        /// Convert Enum to List
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public List<string> ConvertEnumToList<T>()
        {
            List<string> lstT = new List<string>();

            foreach (var n in Enum.GetValues(typeof(T)))
            {
                lstT.Add(n.ToString());
            }

            return lstT;
        }

        public void ConvertEnumToListTest()
        {
            List<string> output = ConvertEnumToList<EnumTest>();

            foreach (string p in output)
                System.Diagnostics.Trace.WriteLine(p);

            //System.Diagnostics.Trace.WriteLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(String[] args)
        {
            CEnum s = new CEnum();
            s.EnumInfo();
        }
    }
}
