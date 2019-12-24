using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    /// <summary>
    /// Type Convert Helper
    /// </summary>
    public class TypeConvertHelper
    {
        /// <summary>
        /// Convert String Id to Int
        /// </summary>
        /// <param name="id">int id wihin string value</param>
        /// <returns></returns>
        public static int ConvertStringIdToInt(string id)
        {
            int intId = -1;
            try
            {
                if (!string.IsNullOrEmpty(id))
                    intId = Convert.ToInt32(id);
            }
            catch
            {
                //log
            }
            return intId;
        }

    }
}
