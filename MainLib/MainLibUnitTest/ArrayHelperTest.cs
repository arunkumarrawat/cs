using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;

namespace MainLibUnitTest
{
    /// <summary>
    /// ArrayHelper Convert Function
    /// </summary>
    [TestClass]
    public class ArrayHelperTest
    {
        /// <summary>
        /// Test ArrayHelper Convert function
        /// </summary>
        [TestMethod]
        public void TestConvert()
        {
            ArrayHelper arrayHelper = new ArrayHelper();
            int[,] p = { { 0, 0 }, { 0, 1 }, { 1, 0 }, { 0, 2 }, { 2, 0 } };
            int[][] result = arrayHelper.convert(p);
            for(int i=0;i<result.Length;i++)
            {
                for(int j=0;j<result[0].Length;j++)
                {
                    Console.Write(result[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
