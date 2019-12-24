using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib.LINQ
{
    public class NumOperation
    {
        /// <summary>
        /// ints larger than 4
        /// </summary>
        /// <param name="ints"></param>
        /// <returns></returns>
        public IEnumerable<string> IntegerLargeThan(ref int[] ints)
        {
            var intsToStrings = from i in ints
                                where i > 4
                                select i.ToString();
            return intsToStrings;
        }

    }
}
