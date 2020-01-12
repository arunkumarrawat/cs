using System;

namespace MainLib.Algorithm
{
    /// <summary>
    /// introduction to algorithm chapter 6 heapsort
    /// </summary>
    public class Heapsort
    {
        private int[] op_array;
        private int heapSize;

        /// <summary>
        /// 
        /// </summary>
        public int HeapSize
        {
            get
            {
                return heapSize;
            }

            set
            {
                heapSize = value;
            }
        }

        /// <summary>
        /// Heap Sort
        /// </summary>
        /// <param name="op_array"></param>
        public Heapsort(int[] op_array)
        {
            this.op_array = op_array;
            this.HeapSize = op_array.Length;
        }
        /// <summary>
        /// heap sort parent node
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        private int Parent(int i)
        {
            if (i == 0)
                return 0;

            return (i + 1) / 2 - 1;
        }

        /// <summary>
        /// Left i
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        int Left(int i)
        {
            return 2 * (i + 1) - 1;
        }

        int Right(int i)
        {
            return 2 * (i + 1);
        }

        void MaxHeapify(int i)
        {
            int l = Left(i);
            int r = Right(i);

            int largest = i;

            if (l < HeapSize && op_array[l] > op_array[i])
                largest = l;

            if (r < HeapSize && op_array[r] > op_array[largest])
                largest = r;

            if (largest != i)
            {
                // exchange(&op_array[i],&op_array[largest]);
                int temp = op_array[i];
                op_array[i] = op_array[largest];
                op_array[largest] = temp;

                MaxHeapify(largest);
            }
        }


        public void Build_Max_Heap()
        {
            int i = 0;
            for (i = op_array.Length / 2 - 1; i >= 0; i--)
                MaxHeapify(i);
        }

        /// <summary>
        /// 
        /// </summary>
        public void MaxHeapSort()
        {
            Build_Max_Heap();

            for (int i = op_array.Length - 1; i >= 1; i--)
            {
                int temp = op_array[0];
                op_array[0] = op_array[i];
                op_array[i] = temp;
                HeapSize--;
                MaxHeapify(0);
            }

            printArray();
        }

        void printArray()
        {
            for (int i = 0; i < op_array.Length; i++)
                Console.Write("{0}\t", op_array[i]);

            Console.WriteLine();
        }

    }
}
