using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MainLib.Algorithm
{
    /// <summary>
    /// introduction to algorithm chapter 6 heapsort
    /// </summary>
    public class Heapsort
    {
        /// <summary>
        /// heap sort parent node
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int Parent(int i)
        {
            return i / 2;
        }

        /// <summary>
        /// Left i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int Left(int i)
        {
            return 2 * i;
        }

        /// <summary>
        /// Right i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int Right(int i)
        {
            return 2 * i + 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array"></param>
        /// <param name="i"></param>
        private void MaxHeapify(int[] array, int i)
        {

        }
    }
}
