using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib;
using MainLib.Algorithm;

namespace MainLibUnitTest
{
    [TestClass]
    public class AlgorithmTest
    {
        [TestMethod]
        public void HeapSortTest()
        {
            int[] op_array = { 3, 5, 7, 1, 3, 12, 56, 8, 7, 16 };
            int i;
            Heapsort h = new Heapsort(op_array);
            Console.WriteLine("Heap Tree Test\n");
            Console.WriteLine("Heap Size {0}", h.HeapSize);

            h.MaxHeapSort();
        }
    }
}
