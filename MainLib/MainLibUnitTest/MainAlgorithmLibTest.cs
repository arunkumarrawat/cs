using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainLib.Algorithm;

namespace MainLibUnitTest
{
    [TestClass]
    public class MainAlgorithmLibTest
    {
        /// <summary>
        /// Test Priority Queue Lib for C#
        /// </summary>
        [TestMethod]
        public void PriorityQueueTest()
        {
            int[] a = { 9, 7, 3, 4, 6, 10, 20 };
            PriorityQueue<int> pq = new PriorityQueue<int>();
            foreach(int x in a)
            {
                pq.Enqueue(x);
            }

            Assert.AreEqual(pq.Peek(), 3);

            PriorityQueue<int> pqMax = new PriorityQueue<int>(true);

            foreach (int x in a)
            {
                pqMax.Enqueue(x);
            }

            Assert.AreEqual(pqMax.Peek(), 20);

            pqMax.Dequeue();
            Assert.AreEqual(pqMax.Peek(), 10);
        }
    }
}
