using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Array Algorithm library
    /// </summary>
    public class ArrayHelper
    {
        /// <summary>
        /// class constructor
        /// </summary>
        public ArrayHelper()
        {

        }

        /// <summary>
        /// Concat two array
        /// </summary>
        /// <param name="aFirst"></param>
        /// <param name="aSecond"></param>
        /// <returns></returns>
        public static Array Concat(Array aFirst, Array aSecond)
        {
            if (aFirst == null)
            {
                return aSecond.Clone() as Array;
            }

            if (aSecond == null)
            {
                return aFirst.Clone() as Array;
            }

            Type typeFirst = aFirst.GetType().GetElementType();
            Type typeSecond = aSecond.GetType().GetElementType();

            System.Diagnostics.Debug.Assert(typeFirst == typeSecond);

            Array aNewArray = Array.CreateInstance(typeFirst, aFirst.Length + aSecond.Length);
            aFirst.CopyTo(aNewArray, 0);
            aSecond.CopyTo(aNewArray, aFirst.Length);

            return aNewArray;
        }
    }
}
