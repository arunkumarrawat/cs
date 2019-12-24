using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    public class CEnum
    {
        private enum EnumTest
        {
            Test1,
            Test2,
            Test3
        };
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
    }
}
