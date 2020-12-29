using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode
{
    //@example: Leetcode - 393. UTF-8 Validation - https://leetcode.com/problems/utf-8-validation/ - AC with two ways
    public class UTF_8Validation_393
    {
        public bool ValidUtf8(int[] data)
        {
            if (data == null) return false;

            if (data.Length == 0) return false;

            int numberOfBytes = 0;

            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > 255) return false;
                if (data[i] >= 240 && data[i] <= 247)
                {
                    numberOfBytes = 4;
                }
                else
                if (data[i] >= 224 && data[i] <= 239)
                {
                    numberOfBytes = 3;
                }
                else
                if (data[i] >= 192 && data[i] <= 223)
                {
                    numberOfBytes = 2;
                }
                else
                if (data[i] >= 0 && data[i] <= 127)
                {
                    numberOfBytes = 1;
                }
                else
                    return false;

                for(int j=1;j<numberOfBytes;j++)
                {
                    if (i + j >= data.Length) return false;
                    if (!(data[i + j] >= 128 && data[i + j] <= 191)) return false;
                }

                i = i + numberOfBytes - 1; //Skip number of bytes
            }
            return true;

            //int bitCount = 0;

            //foreach (int n in data)
            //{

            //    if (n >= 192)
            //    {
            //        if (bitCount != 0)
            //            return false;
            //        else if (n >= 240)
            //            bitCount = 3;
            //        else if (n >= 224)
            //            bitCount = 2;
            //        else
            //            bitCount = 1;
            //    }
            //    else if (n >= 128)
            //    {
            //        bitCount--;
            //        if (bitCount < 0)
            //            return false;
            //    }
            //    else if (bitCount > 0)
            //    {
            //        return false;
            //    }
            //}

            //return bitCount == 0;
        }

        public static void main()
        {
            //[240,162,138,147,17]
            int[] data = new int[] { 240, 162, 138, 147, 145 };

            UTF_8Validation_393 s = new UTF_8Validation_393();
            Console.WriteLine(s.ValidUtf8(data));

        }
    }
}
