using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib
{
    public class RandomHelper
    {
        private static Random rand = new Random();

        /// <summary>
        /// Random Helper
        /// </summary>
        public RandomHelper()
        {
            
        }

        /// <summary>
        /// Get Random within Min and Max
        /// </summary>
        /// <param name="min">Min</param>
        /// <param name="max">Max</param>
        /// <returns></returns>
        public static int GetRandomInt(int min, int max)
        {
            return (rand.Next(min, max));
        }
    }
}
